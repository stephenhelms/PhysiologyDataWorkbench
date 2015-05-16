using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using RRLab.PhysiologyWorkbench.Daq;
using RRLab.PhysiologyWorkbench.Data;
using RRLab.PhysiologyWorkbench.Devices;
using RRLab.PhysiologyDataConnectivity;
using System.ComponentModel;
using System.Reflection;
using System.IO;
using System.Data;

namespace RRLab.PhysiologyWorkbench
{
    public class PhysiologyWorkbenchProgram : IDataManagerSource, IDeviceManagerUser
    {
        

        public event EventHandler UserChanged;

        private short _User;

        public short User
        {
            get {
                if (DataManager.CurrentCell != null)
                    return DataManager.CurrentCell.UserID;
                else return 0;
            }
        }
	

        public event EventHandler DataManagerChanged;

        private DataManager _DataManager;

        public DataManager DataManager
        {
            get { return _DataManager; }
            set {
                if (DataManager != null)
                {
                    DataManager.StartingDatabaseUpdate -= new EventHandler(OnDatabaseUpdateStarting);
                    DataManager.FinishedDatabaseUpdate -= new EventHandler(OnDatabaseUpdateFinished);
                }
                _DataManager = value;
                if (DataManager != null)
                {
                    DataManager.StartingDatabaseUpdate += new EventHandler(OnDatabaseUpdateStarting);
                    DataManager.FinishedDatabaseUpdate += new EventHandler(OnDatabaseUpdateFinished);
                }
                if (DataManagerChanged != null) DataManagerChanged(this, EventArgs.Empty);
            }
        }

        protected virtual void OnDatabaseUpdateStarting(object sender, EventArgs e)
        {
            SuspendDataBinding();
        }
        protected virtual void OnDatabaseUpdateFinished(object sender, EventArgs e)
        {
            ResumeDataBinding();
        }

        #region IDeviceManagerUser Members

        public event EventHandler DeviceManagerChanged;

        private DeviceManager _DeviceManager;

        public DeviceManager DeviceManager
        {
            get
            {
                return _DeviceManager;
            }
            set
            {
                _DeviceManager = value;
                if (DeviceManager != null)
                    DeviceManager.DefaultAmplifierChanged += new EventHandler(OnDefaultAmplifierChanged);
                if (DeviceManagerChanged != null) DeviceManagerChanged(this, EventArgs.Empty);
            }
        }

        #endregion

        public event EventHandler HotkeyManagerChanged;

        private HotkeyManager _HotkeyManager;
        private BindingSource CellsBindingSource;
        private IContainer components;
        private BindingSource RecordingsBindingSource;

        public HotkeyManager HotkeyManager
        {
            get { return _HotkeyManager; }
            set {
                _HotkeyManager = value;
                OnHotkeyManagerChanged(EventArgs.Empty);
            }
        }

        public event EventHandler TestPulseProtocolChanged;

        private TestPulseProtocol _TestPulseProtocol;

        public TestPulseProtocol TestPulseProtocol
        {
            get { return _TestPulseProtocol; }
            set {
                if (TestPulseProtocol != null)
                {
                    TestPulseProtocol.Starting -= new EventHandler(OnTestPulseStarting);
                    TestPulseProtocol.Finished -= new EventHandler(OnTestPulseFinished);
                }

                _TestPulseProtocol = value;

                if (TestPulseProtocol != null)
                {
                    TestPulseProtocol.Program = this;
                    TestPulseProtocol.Starting += new EventHandler(OnTestPulseStarting);
                    TestPulseProtocol.Finished += new EventHandler(OnTestPulseFinished);
                }

                OnDefaultAmplifierChanged(this, EventArgs.Empty);
                
                if (TestPulseProtocolChanged != null) TestPulseProtocolChanged(this, EventArgs.Empty);
            }
        }

        private List<DaqProtocol> _Protocols = new List<DaqProtocol>();

        public IList<DaqProtocol> Protocols
        {
            get { return _Protocols.AsReadOnly(); }
            protected set { _Protocols.Clear(); _Protocols.AddRange(value); }
        }

        public event EventHandler CurrentProtocolChanged;

        private DaqProtocol _CurrentProtocol;

        public DaqProtocol CurrentProtocol
        {
            get { return _CurrentProtocol; }
            set {
                if (CurrentProtocol == value) return;

                _CurrentProtocol = value;
                
                if(CurrentProtocol != null)
                    CurrentProtocol.Program = this;
                
                if (CurrentProtocolChanged != null) CurrentProtocolChanged(this, EventArgs.Empty);
            }
        }


        public event EventHandler MainWindowChanged;

        private MainWindow _MainWindow;

        public MainWindow MainWindow
        {
            get { return _MainWindow; }
            set {
                _MainWindow = value;
                if (MainWindow != null)
                {
                    MainWindow.Program = this;
                    
                }
                if (MainWindowChanged != null) MainWindowChanged(this, EventArgs.Empty);
            }
        }
	
	

        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            // TODO: Deserialize saved program info if available
            PhysiologyWorkbenchProgram program = new PhysiologyWorkbenchProgram(new MainWindow());
            program.OnApplicationStart(EventArgs.Empty);
            Application.Run(program.MainWindow);
        }

        public PhysiologyWorkbenchProgram()
        {
            Initialize();
        }
        public PhysiologyWorkbenchProgram(MainWindow window)
        {
            MainWindow = window;
            Initialize();
        }

        protected virtual void Initialize()
        {
            TestPulseProtocol = new TestPulseProtocol();
            HotkeyManager = new HotkeyManager();
            
            DeviceManager = new DeviceManager();

            DataManager = new DataManager();

            Protocols = new List<DaqProtocol>(GetAvailableProtocols());

            RegisterEventHandlers();
        }

        protected virtual void RegisterEventHandlers()
        {
            //if (MainWindow != null) MainWindow.Load += new EventHandler(OnApplicationStart);
            Application.ApplicationExit += new EventHandler(OnApplicationExit);
        }

        private void OnApplicationStart(object sender, EventArgs e)
        {
            OnApplicationStart(e);
        }
        protected virtual void OnApplicationStart(EventArgs e)
        {
            HotkeyManager.RestoreSavedHotkeys();
            
            DeviceManager.RestoreSavedDeviceSettings();
            if (!DeviceManager.TryInitializeDevices())
                MessageBox.Show("Devices were not successfully initialized.");

            DataManager.DatabaseConnector.RequestUserToConfigureConnection();
            DataManager.Initialize();
            DataManager.DefaultUserID = DataManager.Data.Users[0].UserID;
            DataManager.DefaultFlyStockID = DataManager.Data.Genotypes[0].FlyStockID;
        }

        private bool _Exiting = false;
        public bool Exiting
        {
            get { return _Exiting; }
            protected set { _Exiting = value; }
        }

        protected virtual void OnApplicationExit(object sender, EventArgs e)
        {
            Exiting = true;

            if (!DeviceManager.TryFinalizeDevices())
                MessageBox.Show("Devices were not successfully finalized.");
        }

        protected virtual void OnDefaultAmplifierChanged(object sender, EventArgs e)
        {
            if (TestPulseProtocol != null && DeviceManager != null)
                TestPulseProtocol.Amplifier = DeviceManager.DefaultAmplifier;
        }

        protected virtual void OnHotkeyManagerChanged(EventArgs e)
        {
            if (HotkeyManager == null) return;

            HotkeyManager.RegisterAction("Mark Break-In", new System.Threading.ThreadStart(MarkBreakIn));
        }

        public virtual void MarkBreakIn()
        {
            if (DataManager == null || DataManager.CurrentCell == null) return;

            DataManager.CurrentCell.BreakInTime = DateTime.Now;
        }

        protected virtual void OnTestPulseStarting(object sender, EventArgs e)
        {
            SuspendDataBinding();
        }
        protected virtual void OnTestPulseFinished(object sender, EventArgs e)
        {
            ResumeDataBinding();
        }

        public virtual void SuspendDataBinding()
        {
            MainWindow.SuspendDataBinding();
        }
        public virtual void ResumeDataBinding()
        {
            if(!Exiting)
                MainWindow.ResumeDataBinding();
        }

        protected virtual ICollection<DaqProtocol> GetAvailableProtocols()
        {
            return GetAvailableProtocols(typeof(DaqProtocol));
        }
        protected virtual ICollection<DaqProtocol> GetAvailableProtocols(Type protocolType)
        {
            if (!typeof(DaqProtocol).IsAssignableFrom(protocolType)) throw new ArgumentException("Protocol type must be a DaqProtocol.");
            List<DaqProtocol> protocols = new List<DaqProtocol>();

            foreach (Assembly assembly in GetProtocolAssemblies())
            {
                try
                {
                    foreach (Type type in assembly.GetTypes())
                    {
                        if ((protocolType.IsAssignableFrom(type)) && (!type.IsAbstract) && (!type.IsInterface) && (type.GetConstructor(new Type[] { }) != null))
                        {
                            try
                            {
                                DaqProtocol protocol = Activator.CreateInstance(type) as DaqProtocol;
                                protocols.Add(protocol);
                            }
                            catch (Exception x) { ; }
                        }
                    }
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.WriteLine("Error loading protocol assembly types.");
                }
            }

            return protocols;
        }
        protected virtual ICollection<Assembly> GetProtocolAssemblies()
        {
            List<Assembly> assemblies = new List<Assembly>();

            // Search current directory
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo info = new DirectoryInfo(currentDirectory);
            FileInfo[] dllFiles = info.GetFiles("*.dll");
            foreach (FileInfo dllFile in dllFiles)
            {
                try
                {
                    assemblies.Add(Assembly.LoadFrom(dllFile.FullName));
                }
                catch (Exception e) { ; }
            }

            try
            {
                // Add currently loaded assemblies
                Assembly currentThread = Assembly.GetExecutingAssembly();
                if (!assemblies.Contains(currentThread)) assemblies.Add(currentThread);
            }
            catch (Exception e) { ; }

            return assemblies;
        }
    }

    public interface IPhysiologyWorkbenchProgramProvider
    {
        event EventHandler ProgramChanged;
        PhysiologyWorkbenchProgram Program { get; }
    }
}
