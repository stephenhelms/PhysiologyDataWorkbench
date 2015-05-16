using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace RRLab.PhysiologyWorkbench.Devices
{
    [Serializable]
    public class DeviceManager : Component
    {
        [field: NonSerialized]
        public event EventHandler AvailableDevicesChanged;
        [field: NonSerialized]
        public event EventHandler DeviceSettingsChanged;

        public static string PersistenceFilePath
        {
            get
            {
                return Properties.Settings.Default.DeviceManagerPersistenceFilePath;
            }
        }
        public static bool PersistenceFileExists
        {
            get
            {
                return File.Exists(PersistenceFilePath);
            }
        }

        public event EventHandler DefaultAmplifierChanged;
        private Amplifier _DefaultAmplifier;

        public Amplifier DefaultAmplifier
        {
            get { return _DefaultAmplifier; }
            set {
                _DefaultAmplifier = value;
                if (DefaultAmplifierChanged != null) DefaultAmplifierChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler DefaultLaserChanged;
        private SpectraPhysicsNitrogenLaser _DefaultLaser;

        public SpectraPhysicsNitrogenLaser DefaultLaser
        {
            get { return _DefaultLaser; }
            set {
                _DefaultLaser = value;
                if (DefaultLaserChanged != null) DefaultLaserChanged(this, EventArgs.Empty);
            }
        }
	
	

        private List<Device> _DeviceList;

        public DeviceManager()
        {
            _DeviceList = new List<Device>();
        }

        public virtual ICollection<Device> GetAvailableDevices()
        {
            return _DeviceList.AsReadOnly();
        }
        public virtual ICollection<Device> GetAvailableDevices(Type deviceType)
        {
            // Validation
            if(!typeof(Device).IsAssignableFrom(deviceType)) throw new ArgumentException("Device type must be derived from Device.");
            
            // Generate a list of compatible Devices
            List<Device> devices = new List<Device>(_DeviceList.Count);
            foreach (Device d in _DeviceList)
            {
                if (deviceType.IsAssignableFrom(d.GetType())) devices.Add(d);
            }
            devices.TrimExcess();
            return devices;
        }
        public virtual void AddDevice(Device device)
        {
            _DeviceList.Add(device);

            if (DefaultAmplifier == null && device is Amplifier) DefaultAmplifier = device as Amplifier;
            if (DefaultLaser == null && device is SpectraPhysicsNitrogenLaser) DefaultLaser = device as SpectraPhysicsNitrogenLaser;

            device.DeviceSettingsChanged += new EventHandler(OnMemberDeviceSettingsChanged);
            if (AvailableDevicesChanged != null) AvailableDevicesChanged(this, EventArgs.Empty);
        }
        public virtual void RemoveDevice(Device device)
        {
            _DeviceList.Remove(device);

            if (DefaultAmplifier == device) DefaultAmplifier = null;
            if (DefaultLaser == device) DefaultLaser = null;

            device.DeviceSettingsChanged -= new EventHandler(OnMemberDeviceSettingsChanged);
            if (AvailableDevicesChanged != null) AvailableDevicesChanged(this, EventArgs.Empty);
        }

        public virtual void SaveDeviceSettings()
        {
            FileStream fileStream = null;
            try
            {
                fileStream = File.Open(PersistenceFilePath, FileMode.OpenOrCreate);
                SaveDeviceSettings(fileStream);
            }
            catch (SerializationException e)
            {
                System.Windows.Forms.MessageBox.Show("Device settings could not be saved: " + e.Message);
            }
            finally
            {
                if (fileStream != null) fileStream.Close();
            }
        }
        public virtual void SaveDeviceSettings(Stream stream)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(stream, _DeviceList);
        }
        public virtual void RestoreSavedDeviceSettings()
        {
            if (!PersistenceFileExists) return;

            FileStream fileStream = null;

            try
            {
                fileStream = File.OpenRead(PersistenceFilePath);
                RestoreSavedDeviceSettings(fileStream);

                foreach (Device d in GetAvailableDevices()) d.DeviceSettingsChanged += new EventHandler(OnMemberDeviceSettingsChanged);

                List<Device> amps = new List<Device>(GetAvailableDevices(typeof(Amplifier)));
                if (amps.Count > 0) DefaultAmplifier = amps[0] as Amplifier;
                else DefaultAmplifier = null;

                List<Device> lasers = new List<Device>(GetAvailableDevices(typeof(SpectraPhysicsNitrogenLaser)));
                if (lasers.Count > 0) DefaultLaser = lasers[0] as SpectraPhysicsNitrogenLaser;
                else DefaultLaser = null;
            }
            finally
            {
                if (fileStream != null) fileStream.Close();
            }
        }
        public virtual void RestoreSavedDeviceSettings(Stream stream)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            try
            {
                _DeviceList = binaryFormatter.Deserialize(stream) as List<Device>;
            }
            catch (SerializationException e)
            {
                _DeviceList = new List<Device>();
            }
            
            if (AvailableDevicesChanged != null) AvailableDevicesChanged(this, EventArgs.Empty);
            if (DeviceSettingsChanged != null) DeviceSettingsChanged(this, EventArgs.Empty);
        }

        protected virtual void OnMemberDeviceSettingsChanged(object sender, EventArgs e)
        {
            if (DeviceSettingsChanged != null) DeviceSettingsChanged(this, e);
        }

        public bool TryInitializeDevices()
        {
            try
            {
                InitializeDevices();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public virtual void InitializeDevices()
        {
            foreach (Device d in _DeviceList)
                d.InitializeDevice();
        }
        public bool TryFinalizeDevices()
        {
            try
            {
                FinalizeDevices();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public virtual void FinalizeDevices()
        {
            foreach (Device d in _DeviceList)
                d.FinalizeDevice();
        }
    }
}
