using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO.Ports;

namespace RRLab.PhysiologyWorkbench.Devices
{
    [Serializable]
    public enum FilterWheelShutterStatus { Closed, ConditionalOpen, Open };

	/// <summary>
	/// 
	/// </summary>
    [Serializable]
	public abstract class FilterWheel : RRLab.PhysiologyWorkbench.Devices.Device, ICustomDeviceConfigurationControlProvider
	{
        [field: NonSerialized] public event EventHandler ShutterStateChanged;

        private SortedList<string, string> filterDescriptions = new SortedList<string, string>();

        [System.ComponentModel.Category("Information")]
        public int NumberOfWheels
        {
            get
            {
                return GetAvailableWheels().Length;
            }
        }
        private int _NumberOfFilters = 10;
        [System.ComponentModel.Category("Information")]
        public int NumberOfFilters
        {
            get
            {
                return _NumberOfFilters;
            }
            set
            {
                _NumberOfFilters = value;
            }
        }
        private int _DefaultSpeed = 2;
        
        [System.ComponentModel.Category("Behavior")]
        public int DefaultSpeed
        {
            get { return _DefaultSpeed; }
            set { _DefaultSpeed = value; }
        }

        private FilterWheelShutterStatus _ShutterAStatus;

        public FilterWheelShutterStatus ShutterAStatus
        {
            get { return _ShutterAStatus; }
            protected set {
                _ShutterAStatus = value;
                if (ShutterStateChanged != null) ShutterStateChanged(this, EventArgs.Empty);
            }
        }

        private FilterWheelShutterStatus _ShutterBStatus;

        public FilterWheelShutterStatus ShutterBStatus
        {
            get { return _ShutterBStatus; }
            protected set {
                _ShutterBStatus = value;
                if (ShutterStateChanged != null) ShutterStateChanged(this, EventArgs.Empty);
            }
        }
	    	

		public abstract FilterWheelStatus GetFilterWheelStatus();
		public abstract void SetFilterWheelPosition(char FilterWheel, int Position, int Speed);

		public virtual byte[] GetFilterWheelCommand(char FilterWheel, int Position, int Speed) 
		{
			// Check for argument errors
			if((Position < 0) || (Position > 9)) throw new ArgumentException("Position must be between 0 and 9.", "Position");
			if((Speed < 0) || (Speed > 7)) throw new ArgumentException("Speed must be between 0 and 7.", "Speed");

			switch(FilterWheel) 
			{
				case 'B':
					return new byte[] { (byte) (128 + Speed*16 + Position) };
				case 'A':
					return new byte[] { (byte) (Speed*16 + Position) };
				case 'C':
					return new byte[] { 252, (byte) (Speed*16 + Position) };
				default: throw new ArgumentException("FilterWheel must be set to either A,B, or C.", "FilterWheel");
			}
		}

		protected virtual FilterWheelStatus InterpretFilterWheelStatusBytes(byte[] StatusBytes) 
		{
			int FilterWheelAPosition = -1;
			int FilterWheelBPosition = -1;
			int FilterWheelCPosition = -1;

			return new FilterWheelStatus(FilterWheelAPosition, FilterWheelBPosition, FilterWheelCPosition);
		}

        public virtual char[] GetAvailableWheels()
        {
            return new char[] { 'A', 'B' };
        }

        public virtual string GetFilterDescription(char FilterWheel, int Position)
        {
            string search = FilterWheel.ToString() + Position.ToString();
            if(filterDescriptions.ContainsKey(search)) {
                return filterDescriptions[search];
            } else {
                return null;
            }
        }
        public virtual void SetFilterDescription(char FilterWheel, int Position, string description)
        {
            string search = FilterWheel.ToString() + Position.ToString();
            if (filterDescriptions.ContainsKey(search))
            {
                filterDescriptions[search] = description;
            }
            else
            {
                filterDescriptions.Add(search, description);
            }
        }

        public abstract void SetShutterState(char wheel, FilterWheelShutterStatus state);

        #region ICustomDeviceConfigurationControlProvider Members

        public System.Windows.Forms.Control GetDeviceConfigurationControl()
        {
            return new FilterWheelConfigurationControl(this);
        }

        #endregion
    }

    [Serializable]
	public class SerialPortFilterWheel : FilterWheel 
	{
		/// <summary>
		/// From the Sutter Instruments Lambda 10-2 Manual
		/// </summary>
		[NonSerialized] private SerialPort port;
		protected int BaudRate = 9600;
		protected int DataBits = 8;
		protected Parity Parity = Parity.None;
		protected StopBits StopBits = StopBits.One;

		protected int ReadTimeout = 10000;

        protected bool IsComputerControlled = false;
	

        public SerialPortFilterWheel()
        {
        }
		public SerialPortFilterWheel(string PortName, string Name) 
		{
			this.Name = Name;
			this.PortName = PortName;
		}

		protected void GenerateSerialPort() 
		{
			port = new SerialPort(PortName, BaudRate, Parity, DataBits, StopBits);
			port.ReadTimeout = ReadTimeout;
            port.Handshake = Handshake.None;
            //port.Encoding = new System.Text.ASCIIEncoding();
            
            port.NewLine = "\r";
		}

        public virtual void ForceComputerControl()
        {
            GenerateSerialPort();

            string strInput = "";
            byte startByte = 238;
            try {
                port.Open();
                port.Write(new byte[] { startByte },0, 1);
                strInput = port.ReadExisting();
                if (strInput.Length == 0) return;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error while sending filter wheel command: " + e.Message);
            }
            finally
            {
                port.Close();
            }
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] byteInput = encoding.GetBytes(strInput);
            if (byteInput[0] != startByte) throw new Exception("Filter Wheel Controller did not accept command. Output: " + startByte.ToString() + " Returned Value: " + strInput);
            else IsComputerControlled = true;
        }

        public override void SetShutterState(char wheel, FilterWheelShutterStatus state)
        {
            byte output = 0;
            switch (Char.ToUpper(wheel))
            {
                case 'A':
                    switch (state)
                    {
                        case FilterWheelShutterStatus.Closed:
                            output = 172;
                            break;
                        case FilterWheelShutterStatus.ConditionalOpen:
                            output = 171;
                            break;
                        case FilterWheelShutterStatus.Open:
                            output = 170;
                            break;
                        default:
                            break;
                    }
                    break;
                case 'B':
                    switch (state)
                    {
                        case FilterWheelShutterStatus.Closed:
                            output = 188;
                            break;
                        case FilterWheelShutterStatus.ConditionalOpen:
                            output = 187;
                            break;
                        case FilterWheelShutterStatus.Open:
                            output = 186;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            if (output == 0) throw new ArgumentException("Invalid command.");

            GenerateSerialPort();
            string strInput = "";
            try
            {
                port.Open();
                port.Write(new byte[] { output }, 0, 1);
                strInput = port.ReadExisting();
                if (strInput.Length == 0) return;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error while sending filter wheel command: " + e.Message);
            }
            finally
            {
                port.Close();
            }
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] byteInput = encoding.GetBytes(strInput);
            if (byteInput[0] != output) throw new Exception("Filter Wheel Controller did not accept command. Output: " + output.ToString() + " Returned Value: " + strInput);
            else
            {
                switch (Char.ToUpper(wheel))
                {
                    case 'A':
                        ShutterAStatus = state;
                        break;
                    case 'B':
                        ShutterBStatus = state;
                        break;
                    default:
                        break;
                }
            }
        }

		public override FilterWheelStatus GetFilterWheelStatus() 
		{
			GenerateSerialPort();
			System.Text.Encoding encoding = System.Text.Encoding.Default;
			byte[] input = encoding.GetBytes(port.ReadLine());
			return base.InterpretFilterWheelStatusBytes(input);
		}
		public override void SetFilterWheelPosition(char FilterWheel, int Position, int Speed) 
		{
            if (!IsComputerControlled) ForceComputerControl();

			GenerateSerialPort();
			byte[] commandByte = GetFilterWheelCommand(FilterWheel, Position, Speed);
			
			string strInput = " ";
            try
            {
                port.Open();
                byte[] output = new byte[commandByte.Length];
                for (int i = 0; i < output.Length; i++)
                    output[i] = commandByte[i];
                port.Write(output, 0, 1);
                strInput = port.ReadLine();
                if (strInput.Length == 0) return;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error while sending filter wheel command: " + e.Message);
            }
			finally 
			{
				port.Close();
			}
			System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
			byte[] byteInput = encoding.GetBytes(strInput);
            string encodedOutput = encoding.GetString(commandByte);
			if(strInput != encodedOutput) throw new Exception("Filter Wheel Controller did not accept command. Output: " + commandByte.ToString() + " Returned Value: " + strInput);
		}

        public override byte[] GetFilterWheelCommand(char FilterWheel, int Position, int Speed)
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

            // Position bits are 0-3
            if ((Position < 0) || (Position > 7))
                throw new ArgumentException("Position must be between 0-7.");
            byte positionByte = Convert.ToByte(Position);

            // Speed is bits 4-6
            byte speedByte = 0;
            switch (Speed)
            {
                case 0:
                    speedByte = 0;
                    break;
                case 1:
                    speedByte = 16;
                    break;
                case 2:
                    speedByte = 32;
                    break;
                case 3:
                    speedByte = 48;
                    break;
                case 4:
                    speedByte = 64;
                    break;
                case 5:
                    speedByte = 70;
                    break;
                case 6:
                    speedByte = 96;
                    break;
                case 7:
                    speedByte = 112;
                    break;
                default:
                    throw new ArgumentException("Speed must be between 0-7.");
            }

            return new byte[] { Convert.ToByte(wheelByte | speedByte | positionByte) };
        }
        protected override FilterWheelStatus InterpretFilterWheelStatusBytes(byte[] StatusBytes)
        {
            return base.InterpretFilterWheelStatusBytes(StatusBytes);
        }

		private string _PortName;
        [System.ComponentModel.Category("Connection")]
        [System.ComponentModel.Description("The serial port to use, e.g. COM1.")]
        [System.ComponentModel.TypeConverter(typeof(PortNameChooser))]
		public string PortName 
		{
			get { return _PortName; }
			set 
			{
				_PortName = value;
			}
		}
	}

    [Serializable]
    public class PortNameChooser : System.ComponentModel.StringConverter
    {
        public PortNameChooser()
        {
        }

        public override bool GetStandardValuesSupported(System.ComponentModel.ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(System.ComponentModel.ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(new List<string>(SerialPort.GetPortNames()));
        }
    }

    [Serializable]
	public class USBPortFilterWheel : FilterWheel 
	{
        public USBPortFilterWheel()
        {
        }
		public USBPortFilterWheel(string USBDeviceName, string Name) 
		{
			this.USBDeviceName = USBDeviceName;
			this.Name = Name;
		}

        public override void SetShutterState(char wheel, FilterWheelShutterStatus state)
        {
            throw new Exception("The method or operation is not implemented.");
        }

		public override FilterWheelStatus GetFilterWheelStatus() 
		{
			System.Collections.ArrayList input = new System.Collections.ArrayList();
			byte[] currentRead = new byte[1];
			while(currentRead[0] != 13) 
			{
				FTDI2XXDriverInterface.FT_Read(currentRead,1);
				input.Add(currentRead);
			}
			byte[] byteInput = new byte[input.Count];
			for(int i=0; i<input.Count; i++) byteInput[i] = (byte) input[i];

			return base.InterpretFilterWheelStatusBytes(byteInput);
		}
		public override void SetFilterWheelPosition(char FilterWheel, int Position, int Speed) 
		{
			byte[] commandByte = GetFilterWheelCommand(FilterWheel, Position, Speed);
			
			FTDI2XXDriverInterface.FT_Open(); //port.Open();
			FTDI2XXDriverInterface.FT_Write(commandByte,(ulong) commandByte.Length); //port.Write(commandByte,0,1);
			
			int bytesToRead;
			if(FilterWheel=='C') bytesToRead=3;
			else bytesToRead=2;

			byte[] buffer = new byte[bytesToRead];
			byte[] input = System.BitConverter.GetBytes(FTDI2XXDriverInterface.FT_Read(buffer, (ulong) bytesToRead)); //strInput = port.ReadLine();
			
			FTDI2XXDriverInterface.FT_Close(); //port.Close();
			
			
			if(input[bytesToRead-1] != commandByte[commandByte.Length-1]) throw new Exception("Filter Wheel Controller did not accept command. Output: " + commandByte.ToString() + " Returned Value: " + input.ToString());
		}

		public static uint GetNumberOfUSBDevices() 
		{
			return FTDI2XXDriverInterface.FT_ListDevices();
		}

		private string _USBDeviceName;
		public string USBDeviceName 
		{
			get { return _USBDeviceName; }
			set { _USBDeviceName = value; }
		}

        [Serializable]
		protected class FTDI2XXDriverInterface 
		{
			[DllImport("AID.dll")]
			public static extern uint FT_ListDevices();
			[DllImport("AID.dll")]
			public static extern uint FT_Open();
			[DllImport("AID.dll")]
			public static extern uint FT_Close();
			[DllImport("AID.dll")]
			public static extern uint FT_Write([MarshalAs(UnmanagedType.LPArray)] byte[] p_data,ulong size);
			[DllImport("AID.dll")]
			public static extern uint FT_GetStatus(ref ulong rxsize, ref ulong txsize);
			[DllImport("AID.dll")]
			public static extern uint FT_SetBitMode(byte mask, byte enable);
			[DllImport("AID.dll")]
			public static extern uint FT_Read([MarshalAs(UnmanagedType.LPArray)] byte[] p_data,ulong size);
			[DllImport("AID.dll")]
			public static extern uint FT_EE_Read(ref ushort vid,ref ushort pid, ref ushort power);
			[DllImport("AID.dll")]
			public static extern uint FT_EE_Program(ushort power);
			[DllImport("AID.dll")]
			public static extern uint FT_EE_ProgramToDefault();
			[DllImport("AID.dll")]
			public static extern uint KCAN_Send(uint channel, uint id, uint dlc, [MarshalAs(UnmanagedType.LPArray)] byte[] p_data);
			[DllImport("AID.dll")]
			public static extern uint KCAN_Receive(ref uint channel, ref uint id, ref uint dlc, [MarshalAs(UnmanagedType.LPArray)] byte[] p_data);
			[DllImport("AID.dll")]
			public static extern uint KCAN_Init(uint baudraute);
		}
	}

    [Serializable]
	public struct FilterWheelStatus 
	{
		public FilterWheelStatus(int FilterWheelAPosition, int FilterWheelBPosition, int FilterWheelCPosition) 
		{
			this.FilterWheelAPosition = FilterWheelAPosition;
			this.FilterWheelBPosition = FilterWheelBPosition;
			this.FilterWheelCPosition = FilterWheelCPosition;
		}

		public int FilterWheelAPosition;
		public int FilterWheelBPosition;
		public int FilterWheelCPosition;
		// May add more status items later
	}
}
