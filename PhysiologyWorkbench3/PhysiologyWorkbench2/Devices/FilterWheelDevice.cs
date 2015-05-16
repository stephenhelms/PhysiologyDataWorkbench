using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;

namespace RRLab.PhysiologyWorkbench.Devices
{
    [Serializable]
    public abstract class FilterWheelDevice : Device, ICustomDeviceConfigurationControlProvider
    {
        #region Properties

        public event EventHandler FilterChanged;

        public event EventHandler FiltersChanged;
        private SortedList<string, FilterWheelState> _Filters = new SortedList<string,FilterWheelState>();
        public virtual IDictionary<string, FilterWheelState> Filters
        {
            get
            {
                return _Filters;
            }
        }

        private string _DefaultFilter = "";

        public string DefaultFilter
        {
            get { return _DefaultFilter; }
            set { _DefaultFilter = value; }
        }

        private string _CurrentFilter;

        public string CurrentFilter
        {
            get { return _CurrentFilter; }
            protected set { _CurrentFilter = value;}
        }

        private FilterWheelState _CurrentFilterWheelState;

        public FilterWheelState CurrentFilterWheelState
        {
            get { return _CurrentFilterWheelState; }
            protected set { _CurrentFilterWheelState = value; }
        }
	
	

        public event EventHandler ShutterStateChanged;

        private FilterWheelShutterStatus _ShutterAStatus;

        public FilterWheelShutterStatus ShutterAStatus
        {
            get { return _ShutterAStatus; }
            protected set
            {
                _ShutterAStatus = value;
            }
        }

        private FilterWheelShutterStatus _ShutterBStatus;

        public FilterWheelShutterStatus ShutterBStatus
        {
            get { return _ShutterBStatus; }
            protected set
            {
                _ShutterBStatus = value;
            }
        }

        #endregion


        #region Methods

        public virtual void AnnotateEquipmentData(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet.RecordingsRow data)
        {
            if (data == null) return;
            data.AddEquipmentSetting(String.Format("{0}-Filter", Name ?? "Filter Wheel"), CurrentFilter);
        }

        public override void InitializeDevice()
        {
            try
            {
                if (DefaultFilter != null && DefaultFilter != "")
                    if (Filters.ContainsKey(DefaultFilter))
                        SelectFilter(DefaultFilter);
            }
            catch (Exception x)
            {
                System.Diagnostics.Trace.WriteLine("Could not initialize device: " + x.Message);
            }
            
            base.InitializeDevice();
        }
        public override void FinalizeDevice()
        {
            try
            {
                if (DefaultFilter != null && DefaultFilter != "")
                    if (Filters.ContainsKey(DefaultFilter))
                        SelectFilter(DefaultFilter);
            }
            catch (Exception x)
            {
                System.Diagnostics.Trace.WriteLine("Could not finalize device: " + x.Message);
            }

            base.FinalizeDevice();
        }

        public virtual void AddFilter(string name, FilterWheelState state)
        {
            if (!_Filters.ContainsKey(name) && !_Filters.ContainsValue(state))
                _Filters.Add(name, state);
            else throw new ArgumentException("Filter already added.");

            if(FiltersChanged != null)
                try
                {
                    FiltersChanged(this, EventArgs.Empty);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("Error during FiltersChanged event.", x.Message);
                }
        }
        public virtual void RemoveFilter(string name)
        {
            if (_Filters.ContainsKey(name)) _Filters.Remove(name);

            if (FiltersChanged != null)
                try
                {
                    FiltersChanged(this, EventArgs.Empty);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("Error during FiltersChanged event.", x.Message);
                }
        }
        public virtual void RemoveFilter(FilterWheelState state)
        {
            if (_Filters.ContainsValue(state)) _Filters.RemoveAt(_Filters.IndexOfValue(state));

            if (FiltersChanged != null)
                try
                {
                    FiltersChanged(this, EventArgs.Empty);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("Error during FiltersChanged event.", x.Message);
                }
        }

        #endregion

        #region Methods to implement

        public virtual void SelectFilter(string name)
        {
            SelectFilter(Filters[name]);
        }
        public virtual void SelectFilter(FilterWheelState state)
        {
            CurrentFilterWheelState = state;
            string name = String.Format("Unnamed State ({0},{1})", state.WheelAPosition, state.WheelBPosition);
            if (_Filters.ContainsValue(state))
                name = _Filters.Keys[_Filters.IndexOfValue(state)];
            CurrentFilter = name;
            if(FilterChanged != null)
                try
                {
                    FilterChanged(this, EventArgs.Empty);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("Error during FilterChanged event.", x.Message);
                }
        }

        public virtual void SetShutterState(char wheel, FilterWheelShutterStatus state)
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
                    throw new ArgumentException("Invalid wheel");
                    break;
            }
            if(ShutterStateChanged != null)
                try
                {
                    ShutterStateChanged(this, EventArgs.Empty);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("Error during ShutterStateChanged event.", x.Message);
                }
        }

        #endregion

        #region ICustomDeviceConfigurationControlProvider Members

        public System.Windows.Forms.Control GetDeviceConfigurationControl()
        {
            return new FilterWheelDeviceConfigurationControl(this);
        }

        #endregion
    }

    [Serializable]
    public enum FilterWheelShutterStatus { Closed, ConditionalOpen, Open };

    [Serializable]
    public struct FilterWheelState
    {
        public int WheelAPosition;
        public int WheelBPosition;

        public FilterWheelState(int wheelA, int wheelB)
        {
            WheelAPosition = wheelA;
            WheelBPosition = wheelB;
        }
    }

    [Serializable]
    public class SerialPortFilterWheelDevice : FilterWheelDevice
    {
        /// <summary>
        /// From the Sutter Instruments Lambda 10-2 Manual
        /// </summary>
        [NonSerialized]
        private SerialPort port;
        protected int BaudRate = 9600;
        protected int DataBits = 8;
        protected Parity Parity = Parity.None;
        protected StopBits StopBits = StopBits.One;

        protected int ReadTimeout = 10000;

        protected bool IsComputerControlled = false;


        public SerialPortFilterWheelDevice()
        {
        }
        public SerialPortFilterWheelDevice(string PortName, string Name)
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

        public override void InitializeDevice()
        {
            ForceComputerControl();
            SetShutterState('A', FilterWheelShutterStatus.Open);
            SetShutterState('B', FilterWheelShutterStatus.Open);

            base.InitializeDevice();
        }

        public virtual void ForceComputerControl()
        {
            GenerateSerialPort();

            string strInput = "";
            byte startByte = 238;
            try
            {
                port.Open();
                port.Write(new byte[] { startByte }, 0, 1);
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

            base.SetShutterState(wheel, state);
        }

        public override void SelectFilter(FilterWheelState state)
        {
            int speed = 2;
            SetWheelPosition('A', state.WheelAPosition, speed);
            SetWheelPosition('B', state.WheelBPosition, speed);
            base.SelectFilter(state);
        }
        public virtual void SetWheelPosition(char wheel, int position, int speed)
        {
            if (!IsComputerControlled) ForceComputerControl();

            GenerateSerialPort();
            byte[] commandByte = GetFilterWheelCommand(wheel, position, speed);

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
            if (strInput != encodedOutput) throw new Exception("Filter Wheel Controller did not accept command. Output: " + commandByte.ToString() + " Returned Value: " + strInput);
        }

        public virtual byte[] GetFilterWheelCommand(char FilterWheel, int Position, int Speed)
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
}
