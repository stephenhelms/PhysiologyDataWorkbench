using System;
using System.Collections.Generic;
using System.Text;

namespace RRLab.PhysiologyWorkbench.Data
{
    [Serializable]
    public class Recording
    {
        [field:NonSerialized] public event EventHandler Updated;

        [field: NonSerialized]
        public event EventHandler SuppressUpdateNotificationChanged;

        private bool _SuppressUpdateNotification = false;

        public bool SuppressUpdateNotification
        {
            get { return _SuppressUpdateNotification; }
            set {
                _SuppressUpdateNotification = value;
                OnSuppressUpdateNotificationChanged(EventArgs.Empty);
            }
        }

        [field: NonSerialized]
        public event EventHandler AnnotationsChanged;
        private List<Annotation> _Annotations = new List<Annotation>();
        public virtual ICollection<Annotation> Annotations
        {
            get { return _Annotations.AsReadOnly(); }
            protected set {
                _Annotations = new List<Annotation>(value);
                OnAnnotationsChanged(EventArgs.Empty);
            }
        }


        [field: NonSerialized]
        public event EventHandler RecordedChanged;
        private DateTime _Recorded = DateTime.Now;
        public virtual DateTime Recorded
        {
            get { return _Recorded; }
            set {
                _Recorded = value;
                OnRecordedChanged(EventArgs.Empty);
            }
        }

        [field: NonSerialized]
        public event EventHandler ExperimenterChanged;

        private string _Experimenter = "";
        public virtual string Experimenter
        {
            get { return _Experimenter; }
            set {
                _Experimenter = value;
                OnExperimenterChanged(EventArgs.Empty);
            }
        }

        [field: NonSerialized]
        public event EventHandler TitleChanged;

        private string _Title = "";
        public virtual string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
                OnTitleChanged(EventArgs.Empty);
            }
        }

        [field: NonSerialized]
        public event EventHandler DescriptionChanged;

        private string _Description = "";

        public virtual string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
                OnDescriptionChanged(EventArgs.Empty);
            }
        }

        [field: NonSerialized]
        public event EventHandler CellChanged;

        private Cell _Cell;

        public virtual Cell Cell
        {
            get { return _Cell; }
            set {
                _Cell = value;
                OnCellChanged(EventArgs.Empty);
            }
        }

        //[field: NonSerialized]
        //public event EventHandler NumberOfChannelsChanged;

        public virtual int NumberOfChannels
        {
            get
            {
                return _Data.Count;
            }
        }

        [field: NonSerialized]
        public event EventHandler DataChanged;

        private SortedList<string,TimeResolvedData> _Data = new SortedList<string,TimeResolvedData>();
        public virtual IDictionary<string, TimeResolvedData> Data
        {
            get { return _Data; }
        }

        [field: NonSerialized]
        public event EventHandler EquipmentSettingsChanged;
        private SortedList<string, string> _EquipmentSettings = new SortedList<string, string>();
        public virtual IDictionary<string, string> EquipmentSettings
        {
            get { return _EquipmentSettings; }
        }

        [field: NonSerialized]
        public event EventHandler ProtocolSettingsChanged;
        private SortedList<string, string> _ProtocolSettings = new SortedList<string, string>();
        public virtual IDictionary<string, string> ProtocolSettings
        {
            get { return _ProtocolSettings; }
        }

        [field: NonSerialized]
        public event EventHandler MetaDataChanged;
        private SortedList<string, string> _MetaData = new SortedList<string, string>();
        public virtual IDictionary<string, string> MetaData
        {
            get { return _MetaData; }
        }

        [field: NonSerialized]
        public event EventHandler BathSolutionChanged;
        private string _BathSolution;

        public string BathSolution
        {
            get { return _BathSolution; }
            set {
                _BathSolution = value;
                OnBathSolutionChanged(EventArgs.Empty);
            }
        }

        [field: NonSerialized]
        public event EventHandler PipetteSolutionChanged;
        private string _PipetteSolution;

        public string PipetteSolution
        {
            get { return _PipetteSolution; }
            set {
                _PipetteSolution = value;
                OnPipetteSolutionChanged(EventArgs.Empty);
            }
        }

        [field: NonSerialized]
        public event EventHandler HoldingPotentialChanged;
        private short _HoldingPotential;

        public short HoldingPotential
        {
            get { return _HoldingPotential; }
            set {
                _HoldingPotential = value;
                OnHoldingPotentialChanged(EventArgs.Empty);
            }
        }	
	

        public Recording()
        {
        }

        public virtual void AddAnnotation(Annotation annotation)
        {
            _Annotations.Add(annotation);
            OnAnnotationsChanged(EventArgs.Empty);
        }
        public virtual void RemoveAnnotation(Annotation annotation)
        {
            if (_Annotations.Contains(annotation)) _Annotations.Remove(annotation);
            OnAnnotationsChanged(EventArgs.Empty);
        }
        public virtual void AddData(string dataName, TimeResolvedData data)
        {
            _Data.Add(dataName, data);
            OnDataChanged(EventArgs.Empty);
        }
        public virtual void AddData(string dataName, float[] time, double[] data, string units)
        {
            _Data.Add(dataName, new TimeResolvedData(time, data, units));
            OnDataChanged(EventArgs.Empty);
        }
        public virtual void AddData(string[] dataNames, float[] time, double[,] data, string[] units)
        {
            int singleLength = data.Length/dataNames.Length;

            for (int i=0; i < dataNames.Length; i++) {
                double[] singleData = new double[singleLength];
                for (int j = 0; j < singleLength; j++)
                    singleData[j] = data[i, j];
                _Data.Add(dataNames[i], new TimeResolvedData(time, singleData, units[i]));
            }

            OnDataChanged(EventArgs.Empty);
        }
        public virtual void RemoveData(string dataName)
        {
            if (_Data.ContainsKey(dataName))
            {
                _Data.Remove(dataName);
            }

            OnDataChanged(EventArgs.Empty);
        }
        public virtual void RemoveAllData()
        {
            _Data.Clear();
            OnDataChanged(EventArgs.Empty);
        }
        public virtual void SetChannelName(int channel, string name)
        {
            _Data.Keys[channel] = name;
            OnDataChanged(EventArgs.Empty);
        }
        public virtual void SetChannelData(string name, double[] data)
        {
            _Data[name].Values = data;
            OnDataChanged(EventArgs.Empty);
        }
        public virtual void SetChannelTime(string name, float[] time)
        {
            _Data[name].Time = time;
            OnDataChanged(EventArgs.Empty);
        }

        public virtual void SetEquipmentSetting(string setting, string value)
        {
            if (_EquipmentSettings.ContainsKey(setting))
                _EquipmentSettings[setting] = value;
            else
                _EquipmentSettings.Add(setting, value);
            OnEquipmentSettingsChanged(EventArgs.Empty);
        }
        public virtual void RemoveEquipmentSetting(string setting)
        {
            if (_EquipmentSettings.ContainsKey(setting))
                _EquipmentSettings.Remove(setting);
            else throw new ApplicationException("Equipment setting " + setting + " does not exist.");
            OnEquipmentSettingsChanged(EventArgs.Empty);
        }
        public virtual void SetProtocolSetting(string setting, string value)
        {
            if (_ProtocolSettings.ContainsKey(setting))
                _ProtocolSettings[setting] = value;
            else
                _ProtocolSettings.Add(setting, value);
            OnProtocolSettingsChanged(EventArgs.Empty);
        }
        public virtual void RemoveProtocolSetting(string setting)
        {
            if (_ProtocolSettings.ContainsKey(setting))
                _ProtocolSettings.Remove(setting);
            else throw new ApplicationException("Protocol setting " + setting + " does not exist.");
            OnProtocolSettingsChanged(EventArgs.Empty);
        }
        public virtual void SetMetaData(string title, string value)
        {
            if (_MetaData.ContainsKey(title))
                _MetaData[title] = value;
            else
                _MetaData.Add(title, value);
            OnMetaDataChanged(EventArgs.Empty);
        }
        public virtual void RemoveMetaData(string title)
        {
            if (_MetaData.ContainsKey(title))
                _MetaData.Remove(title);
            else throw new ApplicationException("Metadata " + title + " does not exist.");
            OnMetaDataChanged(EventArgs.Empty);
        }

        public override string ToString()
        {
            if (Title != null)
                return Title + " (" + Recorded.ToLocalTime().ToLongTimeString() + ")";
            else return "Untitled Recording (" + Recorded.ToLocalTime().ToLongTimeString() + ")";
        }

        protected virtual void OnUpdated(EventArgs e)
        {
            if (Updated != null && !SuppressUpdateNotification) Updated(this, e);
        }

        protected virtual void OnDataChanged(EventArgs e)
        {
            if (DataChanged != null && !SuppressUpdateNotification) DataChanged(this, e);
            OnUpdated(e);
        }

        protected virtual void OnMetaDataChanged(EventArgs e)
        {
            if (MetaDataChanged != null && !SuppressUpdateNotification) MetaDataChanged(this, e);
            OnUpdated(e);
        }

        protected virtual void OnProtocolSettingsChanged(EventArgs e)
        {
            if (ProtocolSettingsChanged != null && !SuppressUpdateNotification) ProtocolSettingsChanged(this, e);
            OnUpdated(e);
        }

        protected virtual void OnEquipmentSettingsChanged(EventArgs e)
        {
            if (EquipmentSettingsChanged != null && !SuppressUpdateNotification) EquipmentSettingsChanged(this, e);
            OnUpdated(e);
        }

        protected virtual void OnAnnotationsChanged(EventArgs e)
        {
            if (AnnotationsChanged != null && !SuppressUpdateNotification) AnnotationsChanged(this, e);
            OnUpdated(e);
        }

        protected virtual void OnTitleChanged(EventArgs e)
        {
            if (TitleChanged != null && !SuppressUpdateNotification) TitleChanged(this, e);
            OnUpdated(e);
        }

        protected virtual void OnDescriptionChanged(EventArgs e)
        {
            if (DescriptionChanged != null && !SuppressUpdateNotification) DescriptionChanged(this, e);
            OnUpdated(e);
        }

        protected virtual void OnRecordedChanged(EventArgs e)
        {
            if (RecordedChanged != null && !SuppressUpdateNotification) RecordedChanged(this, e);
            OnUpdated(e);
        }

        protected virtual void OnCellChanged(EventArgs e)
        {
            if (CellChanged != null && !SuppressUpdateNotification) CellChanged(this, e);
            OnUpdated(e);
        }

        protected virtual void OnExperimenterChanged(EventArgs e)
        {
            if (ExperimenterChanged != null && !SuppressUpdateNotification) ExperimenterChanged(this, e);
            OnUpdated(e);
        }

        protected virtual void OnSuppressUpdateNotificationChanged(EventArgs e)
        {
            if (SuppressUpdateNotificationChanged != null) SuppressUpdateNotificationChanged(this, e);

            if (!SuppressUpdateNotification)
            {
                OnUpdated(e);
                // Fire all events to make sure listeners are updated
                OnAnnotationsChanged(e);
                OnBathSolutionChanged(e);
                OnCellChanged(e);
                OnDataChanged(e);
                OnDescriptionChanged(e);
                OnEquipmentSettingsChanged(e);
                OnExperimenterChanged(e);
                OnHoldingPotentialChanged(e);
                OnMetaDataChanged(e);
                OnPipetteSolutionChanged(e);
                OnProtocolSettingsChanged(e);
                OnRecordedChanged(e);
                OnTitleChanged(e);
            }
        }

        protected virtual void OnBathSolutionChanged(EventArgs e)
        {
            if (BathSolutionChanged != null && !SuppressUpdateNotification) BathSolutionChanged(this, e);
            OnUpdated(e);
        }
        private void OnPipetteSolutionChanged(EventArgs e)
        {
            if (PipetteSolutionChanged != null && !SuppressUpdateNotification) PipetteSolutionChanged(this, e);
            OnUpdated(e);
        }
        private void OnHoldingPotentialChanged(EventArgs e)
        {
            if (HoldingPotentialChanged != null && !SuppressUpdateNotification) HoldingPotentialChanged(this, e);
            OnUpdated(e);
        }
    }
}
