using System;
using System.Collections.Generic;
using System.Text;

using FT_HANDLE = System.UInt32;
using System.Runtime.InteropServices;

namespace RRLab.PhysiologyWorkbench.Devices
{
    [Serializable]
    public class USBFilterWheelDevice : FilterWheelDevice
    {
        public USBFilterWheelDevice()
        {
        }

        #region Properties
        private string _SerialNumber;

        public string SerialNumber
        {
            get { return _SerialNumber; }
            set { _SerialNumber = value; }
        }

        private FT_HANDLE _DeviceHandle;
        protected FT_HANDLE DeviceHandle
        {
            get { return _DeviceHandle; }
            set { _DeviceHandle = value; }
        }

        private bool _IsPortOpen = false;
        protected bool IsPortOpen
        {
            get { return _IsPortOpen; }
            set { _IsPortOpen = value; }
        }

        private int _Timeout = 1000;

        public int Timeout
        {
            get { return _Timeout; }
            set { _Timeout = value; }
        }


        private int _DefaultSpeed = 2;

        public int DefaultSpeed
        {
            get { return _DefaultSpeed; }
            set { _DefaultSpeed = value; }
        }
	
        #endregion

        public override void InitializeDevice()
        {
            ForceComputerControl();
            SetShutterState('A', FilterWheelShutterStatus.Open);
            SetShutterState('B', FilterWheelShutterStatus.Open);

            base.InitializeDevice();
        }

        public override void SelectFilter(FilterWheelState state)
        {
            SetWheelPosition('A', state.WheelAPosition, DefaultSpeed);
            SetWheelPosition('B', state.WheelBPosition, DefaultSpeed);

            base.SelectFilter(state);
        }
        public virtual void SetWheelPosition(char wheel, int position, int speed)
        {
            SendCommand(GetFilterWheelCommand(wheel, position, speed));
        }

        public virtual byte GetFilterWheelCommand(char FilterWheel, int Position, int Speed)
        {
            // Wheel bit is 7, with 0 = Wheel A
            byte wheelByte = 0;
            switch (Char.ToLower(FilterWheel))
            {
                case 'a':
                    wheelByte = 0;
                    break;
                case 'b':
                    wheelByte = 128;
                    break;
                default:
                    throw new ArgumentException("Wheel must be either A or B.");
            }

            if ((Position < 0) || (Position > 9))
                throw new ArgumentException("Position must be between 0-9.");

            return Convert.ToByte(wheelByte + (Speed * 16) + Position);
        }

        protected unsafe virtual void OpenPort()
        {
            if (IsPortOpen) return;

            D2XXAccess.FT_STATUS result = D2XXAccess.FT_STATUS.FT_OTHER_ERROR;

            // Open port and get device handle
            FT_HANDLE deviceHandle = 0;
            IntPtr serialNumber = Marshal.StringToCoTaskMemAnsi(SerialNumber);
            result = D2XXAccess.FT_OpenEx(serialNumber.ToPointer(), D2XXAccess.FT_OPEN_BY_SERIAL_NUMBER, ref deviceHandle);
            Marshal.FreeCoTaskMem(serialNumber);

            // If port opened, do the following
            if (result == D2XXAccess.FT_STATUS.FT_OK)
            {
                IsPortOpen = true;

                DeviceHandle = deviceHandle;

                // Reset device
                result = D2XXAccess.FT_STATUS.FT_OTHER_ERROR;
                result = D2XXAccess.FT_ResetDevice(DeviceHandle);
                if (result != D2XXAccess.FT_STATUS.FT_OK) System.Windows.Forms.MessageBox.Show("Error while resetting device: " + result.ToString());

                // Purge buffers
                PurgeIOBuffers();

                // Set timeouts
                result = D2XXAccess.FT_STATUS.FT_OTHER_ERROR;
                result = D2XXAccess.FT_SetTimeouts(DeviceHandle, Convert.ToUInt32(Timeout), Convert.ToUInt32(Timeout));
                if (result != D2XXAccess.FT_STATUS.FT_OK) System.Windows.Forms.MessageBox.Show("Error setting timeouts: " + result.ToString());

                // Set the baud rate
                result = D2XXAccess.FT_STATUS.FT_OTHER_ERROR;
                result = D2XXAccess.FT_SetBaudRate(DeviceHandle, 128000);
                //result = D2XXAccess.FT_SetBaudRate(DeviceHandle, Convert.ToUInt32(BaudRate));
                if (result != D2XXAccess.FT_STATUS.FT_OK) System.Windows.Forms.MessageBox.Show("Error setting baud rate: " + result.ToString());

                // Set USB parameters
                result = D2XXAccess.FT_STATUS.FT_OTHER_ERROR;
                result = D2XXAccess.FT_SetUSBParameters(DeviceHandle, 64, 0);
                if (result != D2XXAccess.FT_STATUS.FT_OK) System.Windows.Forms.MessageBox.Show("Error setting USB parameters: " + result.ToString());

                // Sleep while the board finishes resetting
                System.Threading.Thread.Sleep(150);
            }
            else IsPortOpen = false;
        }
        protected virtual void ClosePort()
        {
            if (!IsPortOpen) return;

            D2XXAccess.FT_STATUS result = D2XXAccess.FT_STATUS.FT_OTHER_ERROR;
            result = D2XXAccess.FT_Close(DeviceHandle);
            if (result == D2XXAccess.FT_STATUS.FT_OK) IsPortOpen = false;
            else throw new Exception("Port could not be closed: " + result.ToString());
        }


        protected bool IsComputerControlled = false;

        public virtual void ForceComputerControl()
        {
            OpenPort();

            SendCommand(238);
        }

        public override void SetShutterState(char wheel, FilterWheelShutterStatus state)
        {
            byte command = 0;

            if (Char.ToUpper(wheel) == 'A')
            {
                switch (state)
                {
                    case FilterWheelShutterStatus.Closed:
                        command = 172;
                        break;
                    case FilterWheelShutterStatus.ConditionalOpen:
                        command = 171;
                        break;
                    case FilterWheelShutterStatus.Open:
                        command = 170;
                        break;
                    default:
                        break;
                }
            }
            else if (Char.ToUpper(wheel) == 'B')
            {
                switch (state)
                {
                    case FilterWheelShutterStatus.Closed:
                        command = 188;
                        break;
                    case FilterWheelShutterStatus.ConditionalOpen:
                        command = 187;
                        break;
                    case FilterWheelShutterStatus.Open:
                        command = 186;
                        break;
                    default:
                        break;
                }
            }
            else throw new ArgumentException("Invalid wheel.");

            if (command != 0) SendCommand(command);
            
            base.SetShutterState(wheel, state);
        }

        protected unsafe virtual void SendCommand(byte command)
        {
            if (!IsPortOpen) OpenPort();

            try
            {
                PurgeIOBuffers();

                uint bytesWritten = 0;

                D2XXAccess.FT_STATUS result = D2XXAccess.FT_STATUS.FT_OTHER_ERROR;

                byte[] buffer = new byte[] { command, 13 };
                byte[] outputBuffer = new byte[2];
                fixed (byte *pBuffer = buffer)
                {
                    result = D2XXAccess.FT_Write(DeviceHandle, pBuffer, 2U, ref bytesWritten);

                    if (result != D2XXAccess.FT_STATUS.FT_OK) System.Windows.Forms.MessageBox.Show("Error sending command: " + result.ToString());
                    if (bytesWritten == 0) throw new Exception("No command sent.");
                }
                fixed (byte* pOutput = outputBuffer)
                {
                    uint bytesRead = 0;
                    result = D2XXAccess.FT_STATUS.FT_OTHER_ERROR;
                    result = D2XXAccess.FT_Read(DeviceHandle, pOutput, 1U, ref bytesRead);
                    if (result != D2XXAccess.FT_STATUS.FT_OK) System.Windows.Forms.MessageBox.Show("Error reading from device: " + result.ToString());
                    if (bytesRead == 0) System.Windows.Forms.MessageBox.Show("No bytes read.");
                }
                if (outputBuffer[0] != command) System.Windows.Forms.MessageBox.Show("Command not accepted: " + outputBuffer[0].ToString() + " != " + command.ToString());
                else
                {
                    outputBuffer = new byte[1];
                    fixed (byte* pOutput = outputBuffer)
                    {
                        uint bytesRead = 0;
                        result = D2XXAccess.FT_STATUS.FT_OTHER_ERROR;
                        result = D2XXAccess.FT_Read(DeviceHandle, pOutput, 1U, ref bytesRead);
                        if (result != D2XXAccess.FT_STATUS.FT_OK) System.Windows.Forms.MessageBox.Show("Error reading from device: " + result.ToString());
                        if (bytesRead == 0) System.Windows.Forms.MessageBox.Show("No bytes read.");
                    }
                    if (outputBuffer[0] != 13) System.Windows.Forms.MessageBox.Show("Device did not complete task.");
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error while sending filter wheel command: " + e.Message);
            }
        }

        protected virtual void PurgeIOBuffers()
        {
            D2XXAccess.FT_Purge(DeviceHandle, D2XXAccess.FT_PURGE_RX | D2XXAccess.FT_PURGE_TX);
        }

        protected static class D2XXAccess
        {
            public enum FT_STATUS//:Uint32
            {
                FT_OK = 0,
                FT_INVALID_HANDLE,
                FT_DEVICE_NOT_FOUND,
                FT_DEVICE_NOT_OPENED,
                FT_IO_ERROR,
                FT_INSUFFICIENT_RESOURCES,
                FT_INVALID_PARAMETER,
                FT_INVALID_BAUD_RATE,
                FT_DEVICE_NOT_OPENED_FOR_ERASE,
                FT_DEVICE_NOT_OPENED_FOR_WRITE,
                FT_FAILED_TO_WRITE_DEVICE,
                FT_EEPROM_READ_FAILED,
                FT_EEPROM_WRITE_FAILED,
                FT_EEPROM_ERASE_FAILED,
                FT_EEPROM_NOT_PRESENT,
                FT_EEPROM_NOT_PROGRAMMED,
                FT_INVALID_ARGS,
                FT_OTHER_ERROR
            };

            public const UInt32 FT_BAUD_300 = 300;
            public const UInt32 FT_BAUD_600 = 600;
            public const UInt32 FT_BAUD_1200 = 1200;
            public const UInt32 FT_BAUD_2400 = 2400;
            public const UInt32 FT_BAUD_4800 = 4800;
            public const UInt32 FT_BAUD_9600 = 9600;
            public const UInt32 FT_BAUD_14400 = 14400;
            public const UInt32 FT_BAUD_19200 = 19200;
            public const UInt32 FT_BAUD_38400 = 38400;
            public const UInt32 FT_BAUD_57600 = 57600;
            public const UInt32 FT_BAUD_115200 = 115200;
            public const UInt32 FT_BAUD_230400 = 230400;
            public const UInt32 FT_BAUD_460800 = 460800;
            public const UInt32 FT_BAUD_921600 = 921600;

            public const UInt32 FT_LIST_NUMBER_ONLY = 0x80000000;
            public const UInt32 FT_LIST_BY_INDEX = 0x40000000;
            public const UInt32 FT_LIST_ALL = 0x20000000;
            public const UInt32 FT_OPEN_BY_SERIAL_NUMBER = 1;
            public const UInt32 FT_OPEN_BY_DESCRIPTION = 2;

            // Word Lengths
            public const byte FT_BITS_8 = 8;
            public const byte FT_BITS_7 = 7;
            public const byte FT_BITS_6 = 6;
            public const byte FT_BITS_5 = 5;

            // Stop Bits
            public const byte FT_STOP_BITS_1 = 0;
            public const byte FT_STOP_BITS_1_5 = 1;
            public const byte FT_STOP_BITS_2 = 2;

            // Parity
            public const byte FT_PARITY_NONE = 0;
            public const byte FT_PARITY_ODD = 1;
            public const byte FT_PARITY_EVEN = 2;
            public const byte FT_PARITY_MARK = 3;
            public const byte FT_PARITY_SPACE = 4;

            // Flow Control
            public const UInt16 FT_FLOW_NONE = 0;
            public const UInt16 FT_FLOW_RTS_CTS = 0x0100;
            public const UInt16 FT_FLOW_DTR_DSR = 0x0200;
            public const UInt16 FT_FLOW_XON_XOFF = 0x0400;

            // Purge rx and tx buffers
            public const byte FT_PURGE_RX = 1;
            public const byte FT_PURGE_TX = 2;

            // Events
            public const UInt32 FT_EVENT_RXCHAR = 1;
            public const UInt32 FT_EVENT_MODEM_STATUS = 2;

            [DllImport("FTD2XX.dll")]
            public static extern unsafe FT_STATUS FT_ListDevices(void* pvArg1, void* pvArg2, UInt32 dwFlags);	// FT_ListDevices by number only
            [DllImport("FTD2XX.dll")]
            public static extern unsafe FT_STATUS FT_ListDevices(UInt32 pvArg1, void* pvArg2, UInt32 dwFlags);	// FT_ListDevcies by serial number or description by index only
            [DllImport("FTD2XX.dll")]
            public static extern FT_STATUS FT_Open(UInt32 uiPort, ref FT_HANDLE ftHandle);
            [DllImport("FTD2XX.dll")]
            public static extern unsafe FT_STATUS FT_OpenEx(void* pvArg1, UInt32 dwFlags, ref FT_HANDLE ftHandle);
            [DllImport("FTD2XX.dll")]
            public static extern FT_STATUS FT_Close(FT_HANDLE ftHandle);
            [DllImport("FTD2XX.dll")]
            public static extern unsafe FT_STATUS FT_Read(FT_HANDLE ftHandle, void* lpBuffer, UInt32 dwBytesToRead, ref UInt32 lpdwBytesReturned);
            [DllImport("FTD2XX.dll")]
            public static extern unsafe FT_STATUS FT_Write(FT_HANDLE ftHandle, void* lpBuffer, UInt32 dwBytesToRead, ref UInt32 lpdwBytesWritten);
            [DllImport("FTD2XX.dll")]
            public static extern unsafe FT_STATUS FT_SetBaudRate(FT_HANDLE ftHandle, UInt32 dwBaudRate);
            [DllImport("FTD2XX.dll")]
            public static extern unsafe FT_STATUS FT_SetDataCharacteristics(FT_HANDLE ftHandle, byte uWordLength, byte uStopBits, byte uParity);
            [DllImport("FTD2XX.dll")]
            public static extern unsafe FT_STATUS FT_SetFlowControl(FT_HANDLE ftHandle, ushort usFlowControl, byte uXon, byte uXoff);
            [DllImport("FTD2XX.dll")]
            public static extern unsafe FT_STATUS FT_SetDtr(FT_HANDLE ftHandle);
            [DllImport("FTD2XX.dll")]
            public static extern unsafe FT_STATUS FT_ClrDtr(FT_HANDLE ftHandle);
            [DllImport("FTD2XX.dll")]
            public static extern unsafe FT_STATUS FT_SetRts(FT_HANDLE ftHandle);
            [DllImport("FTD2XX.dll")]
            public static extern unsafe FT_STATUS FT_ClrRts(FT_HANDLE ftHandle);
            [DllImport("FTD2XX.dll")]
            public static extern unsafe FT_STATUS FT_GetModemStatus(FT_HANDLE ftHandle, ref UInt32 lpdwModemStatus);
            [DllImport("FTD2XX.dll")]
            public static extern unsafe FT_STATUS FT_SetChars(FT_HANDLE ftHandle, byte uEventCh, byte uEventChEn, byte uErrorCh, byte uErrorChEn);
            [DllImport("FTD2XX.dll")]
            public static extern unsafe FT_STATUS FT_Purge(FT_HANDLE ftHandle, UInt32 dwMask);
            [DllImport("FTD2XX.dll")]
            public static extern unsafe FT_STATUS FT_SetTimeouts(FT_HANDLE ftHandle, UInt32 dwReadTimeout, UInt32 dwWriteTimeout);
            [DllImport("FTD2XX.dll")]
            public static extern unsafe FT_STATUS FT_GetQueueStatus(FT_HANDLE ftHandle, ref UInt32 lpdwAmountInRxQueue);
            [DllImport("FTD2XX.dll")]
            public static extern unsafe FT_STATUS FT_SetBreakOn(FT_HANDLE ftHandle);
            [DllImport("FTD2XX.dll")]
            public static extern unsafe FT_STATUS FT_SetBreakOff(FT_HANDLE ftHandle);
            [DllImport("FTD2XX.dll")]
            public static extern unsafe FT_STATUS FT_GetStatus(FT_HANDLE ftHandle, ref UInt32 lpdwAmountInRxQueue, ref UInt32 lpdwAmountInTxQueue, ref UInt32 lpdwEventStatus);
            [DllImport("FTD2XX.dll")]
            public static extern unsafe FT_STATUS FT_SetEventNotification(FT_HANDLE ftHandle, UInt32 dwEventMask, void* pvArg);
            [DllImport("FTD2XX.dll")]
            public static extern unsafe FT_STATUS FT_ResetDevice(FT_HANDLE ftHandle);
            [DllImport("FTD2XX.dll")]
            public static extern unsafe FT_STATUS FT_SetDivisor(FT_HANDLE ftHandle, char usDivisor);
            [DllImport("FTD2XX.dll")]
            public static extern unsafe FT_STATUS FT_GetLatencyTimer(FT_HANDLE ftHandle, ref byte pucTimer);
            [DllImport("FTD2XX.dll")]
            public static extern unsafe FT_STATUS FT_SetLatencyTimer(FT_HANDLE ftHandle, byte ucTimer);
            [DllImport("FTD2XX.dll")]
            public static extern unsafe FT_STATUS FT_GetBitMode(FT_HANDLE ftHandle, ref byte pucMode);
            [DllImport("FTD2XX.dll")]
            public static extern unsafe FT_STATUS FT_SetBitMode(FT_HANDLE ftHandle, byte ucMask, byte ucEnable);
            [DllImport("FTD2XX.dll")]
            public static extern unsafe FT_STATUS FT_SetUSBParameters(FT_HANDLE ftHandle, UInt32 dwInTransferSize, UInt32 dwOutTransferSize);
        }
    }
}
