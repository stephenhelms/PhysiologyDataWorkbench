using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace RRLab.PhysiologyWorkbench.Devices
{
    public partial class InstallNewDeviceDialog : Form
    {
        private DeviceManager _DeviceManager;
        public DeviceManager DeviceManager
        {
            get { return _DeviceManager; }
            set { _DeviceManager = value; }
        }

        public InstallNewDeviceDialog()
        {
            InitializeComponent();
            RefreshAvailableDeviceTypes();
        }
        public InstallNewDeviceDialog(DeviceManager manager)
        {
            InitializeComponent();
            DeviceManager = manager;
            RefreshAvailableDeviceTypes();
        }

        public virtual void RefreshAvailableDeviceTypes()
        {
            List<Type> deviceTypes = new List<Type>(GetAvailableDeviceTypes(typeof(Device)));
            DeviceTypesListBox.Items.Clear();
            foreach (Type t in deviceTypes) DeviceTypesListBox.Items.Add(t);
        }

        protected virtual ICollection<Type> GetAvailableDeviceTypes(Type searchType)
        {
            List<Type> deviceTypes = new List<Type>();

            foreach (Assembly assembly in GetDeviceAssemblies())
            {
                foreach (Type type in assembly.GetTypes())
                {
                    if ((searchType.IsAssignableFrom(type)) && (!type.IsAbstract) && (!type.IsInterface) && (type.GetConstructor(new Type[] {}) != null))
                        deviceTypes.Add(type);
                }
            }

            return deviceTypes;
        }
        protected virtual ICollection<Assembly> GetDeviceAssemblies()
        {
            List<Assembly> assemblies = new List<Assembly>();

            // Search current directory
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo info = new DirectoryInfo(currentDirectory);
            FileInfo[] dllFiles = info.GetFiles("*.dll");
            foreach (FileInfo dllFile in dllFiles)
            {
                assemblies.Add(Assembly.LoadFrom(dllFile.FullName));
            }

            // Add currently loaded assemblies
            Assembly currentThread = Assembly.GetExecutingAssembly();
            if (!assemblies.Contains(currentThread)) assemblies.Add(currentThread);

            return assemblies;
        }

        protected virtual void OnInstallClicked(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnInstallClicked), sender, e);
                return;
            }

            Type deviceType = DeviceTypesListBox.SelectedItem as Type;

            Device device = null;
            try
            {
                device = Activator.CreateInstance(deviceType) as Device;
                DeviceManager.AddDevice(device);
                this.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show("The device type could not be created: " + x.Message);
            }
        }
    }
}