using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RRLab.PhysiologyWorkbench.Data;

namespace RRLab.PhysiologyWorkbench.Data
{
    public class DataSetBackedRecording : Recording
    {
        protected double[] _CommonTime = null;

        private PhysiologyData _BackingDataSet;

        public PhysiologyData BackingDataSet
        {
            get { return _BackingDataSet; }
            set { _BackingDataSet = value; }
        }

        public long RecordingID
        {
            get {
                if (BackingDataSet == null) throw new Exception("Underlying dataset must not be null.");
                return BackingRow.RecordingID;
            }
            set {
                if (BackingDataSet == null) throw new Exception("Underlying dataset must not be null.");
                BackingRow = BackingDataSet.Recordings.FindByRecordingID(value) as PhysiologyData.RecordingsRow;
            }
        }

        // Overridden properties
        public override ICollection<Annotation> Annotations
        {
            get
            {
                if (BackingDataSet == null) throw new Exception("Underlying dataset must not be null.");

                PhysiologyData.Recordings_AnnotationsRow[] rows = BackingRow.GetRecordings_AnnotationsRows();
                List<Annotation> annotations = new List<Annotation>(rows.Length);
                foreach (PhysiologyData.Recordings_AnnotationsRow row in rows)
                    annotations.Add(new Annotation(row.Entered, row.Text, row.UsersRow.Name));

                return annotations;
            }
            protected set
            {
                throw new Exception("Not supported.");
            }
        }
        // TODO: Implement Cells

        public override DateTime Recorded
        {
            get
            {
                if (BackingDataSet == null) throw new Exception("Underlying dataset must not be null.");

                return BackingRow.Recorded;
            }
            set
            {
                if (BackingDataSet == null) throw new Exception("Underlying dataset must not be null.");

                BackingRow.Recorded = value;
                OnRecordedChanged(EventArgs.Empty);
            }
        }

        public override string Description
        {
            get
            {
                if (BackingDataSet == null) throw new Exception("Underlying dataset must not be null.");
                if (BackingRow.IsDescriptionNull())
                    return "";
                return BackingRow.Description;
            }
            set
            {
                if (BackingDataSet == null) throw new Exception("Underlying dataset must not be null.");

                BackingRow.Description = value;
                OnDescriptionChanged(EventArgs.Empty);
            }
        }

        public override string Title
        {
            get
            {
                if (BackingDataSet == null) throw new Exception("Underlying dataset must not be null.");
                if (BackingRow.IsTitleNull())
                    return "";
                return BackingRow.Title;
            }
            set
            {
                if (BackingDataSet == null) throw new Exception("Underlying dataset must not be null.");

                BackingRow.Title = value;
                OnTitleChanged(EventArgs.Empty);
            }
        }

        public override IDictionary<string, string> EquipmentSettings
        {
            get
            {
                if (BackingDataSet == null) throw new Exception("Underlying dataset must not be null.");

                PhysiologyData.Recordings_EquipmentSettingsRow[] rows = BackingRow.GetRecordings_EquipmentSettingsRows();

                SortedList<string, string> settings = new SortedList<string, string>(rows.Length);
                foreach (PhysiologyData.Recordings_EquipmentSettingsRow row in rows)
                    settings.Add(row.Name, row.Value);

                return settings;
            }
        }
        public override IDictionary<string, string> MetaData
        {
            get
            {
                if (BackingDataSet == null) throw new Exception("Underlying dataset must not be null.");

                PhysiologyData.Recordings_MetaDataRow[] rows = BackingRow.GetRecordings_MetaDataRows();

                SortedList<string, string> metaData = new SortedList<string, string>(rows.Length);
                foreach (PhysiologyData.Recordings_MetaDataRow row in rows)
                    metaData.Add(row.Name, row.Value);

                return metaData;
            }
        }
        public override IDictionary<string, string> ProtocolSettings
        {
            get
            {
                if (BackingDataSet == null) throw new Exception("Underlying dataset must not be null.");

                PhysiologyData.Recordings_ProtocolSettingsRow[] rows = BackingRow.GetRecordings_ProtocolSettingsRows();

                SortedList<string, string> settings = new SortedList<string, string>(rows.Length);
                foreach (PhysiologyData.Recordings_ProtocolSettingsRow row in rows)
                    settings.Add(row.Name, row.Value);

                return settings;
            }
        }
        public override IDictionary<string, TimeResolvedData> Data
        {
            get
            {
                if (BackingDataSet == null) throw new Exception("Underlying dataset must not be null.");

                PhysiologyData.Recordings_DataRow[] rows = BackingRow.GetRecordings_DataRows();
                SortedList<string, TimeResolvedData> data = new SortedList<string, TimeResolvedData>();
                
                // Figure out which channels are present
                foreach (PhysiologyData.Recordings_DataRow row in rows)
                    if (!data.ContainsKey(row.DataName)) data.Add(row.DataName, null);

                foreach (string key in data.Keys) {
                    PhysiologyData.Recordings_DataRow[] specificRows = BackingDataSet.Recordings_Data.Select(
                        String.Format("RecordingID = {0} AND DataName = '{1}'", RecordingID, key),"Time") as PhysiologyData.Recordings_DataRow[];

                    float[] time = new float[specificRows.Length];
                    double[] values = new double[specificRows.Length];
                    for (int i = 0; i < specificRows.Length; i++)
                    {
                        time[i] = specificRows[i].Time;
                        values[i] = specificRows[i].Value;
                    }

                    data[key] = new TimeResolvedData(time, values, specificRows[0].Units);
                }
                return data;
            }
        }
        public override int NumberOfChannels
        {
            get
            {
                if (BackingDataSet == null) throw new Exception("Underlying dataset must not be null.");

                PhysiologyData.Recordings_DataRow[] rows = BackingRow.GetRecordings_DataRows();
                List<string> channels = new List<string>();
                foreach (PhysiologyData.Recordings_DataRow row in rows)
                    if (!channels.Contains(row.DataName)) channels.Add(row.DataName);
                return channels.Count;
            }
        }

        public event EventHandler BackingRowChanged;
        private PhysiologyData.RecordingsRow _BackingRow;
        public PhysiologyData.RecordingsRow BackingRow
        {
            get
            {
                return _BackingRow;
            }
            set
            {
                if (value.Table.DataSet is PhysiologyData) BackingDataSet = value.Table.DataSet as PhysiologyData;
                else throw new Exception("DataSet must be PhysiologyData.");

                _BackingRow = value;
                if (BackingRowChanged != null) BackingRowChanged(this, EventArgs.Empty);
            }
        }

        public DataSetBackedRecording()
        {
            BackingDataSet = new PhysiologyData();
            CreateNewRecordingEntryInDataSet();
        }
        public DataSetBackedRecording(DataSetBackedCell parentCell)
        {
            BackingDataSet = parentCell.BackingDataSet;
            CreateNewRecordingEntryInDataSet(parentCell);
        }
        public DataSetBackedRecording(DataSetBackedCell parentCell, Recording baseRecording)
        {
            BackingDataSet = parentCell.BackingDataSet;
            CreateNewRecordingEntryInDataSet(parentCell);
            LoadDataFromRecording(baseRecording);
        }
        public DataSetBackedRecording(PhysiologyData dataSet, long recordingID)
        {
            BackingDataSet = dataSet;
            RecordingID = recordingID;
        }
        public DataSetBackedRecording(PhysiologyData dataSet, Recording baseRecording)
        {
            BackingDataSet = dataSet;
            CreateNewRecordingEntryInDataSet();

            LoadDataFromRecording(baseRecording);
        }

        protected virtual void CreateNewRecordingEntryInDataSet()
        {
            CreateNewRecordingEntryInDataSet(new DataSetBackedCell(BackingDataSet));
        }
        protected virtual void CreateNewRecordingEntryInDataSet(DataSetBackedCell cell)
        {
            if (BackingDataSet == null) throw new Exception("No backing DataSet.");

            PhysiologyData.RecordingsRow row = BackingDataSet.Recordings.NewRecordingsRow();
            
            // Deal with null values
            row.BeginEdit();
            row.Recorded = DateTime.Now;
            row.BathSolution = "Unknown";
            row.CellsRow = cell.BackingRow;
            row.EndEdit();
            
            BackingDataSet.Recordings.Rows.Add(row);
            RecordingID = row.RecordingID;
        }
        protected virtual void LoadFromEntryInDataSet(long recordingID)
        {
            if (BackingDataSet == null) throw new Exception("No backing DataSet.");

            PhysiologyData.RecordingsRow row = BackingDataSet.Recordings.Rows.Find(recordingID) as PhysiologyData.RecordingsRow;
            
            if (row != null) RecordingID = row.RecordingID;
            else throw new Exception("No row with provided RecordingID.");

            // Load data from row
        }
        public virtual void LoadDataFromRecording(Recording recording)
        {
            lock (this)
            {
                lock (recording)
                {
                    this.Recorded = recording.Recorded;
                    this.Description = recording.Description;
                    this.Experimenter = recording.Experimenter;
                    this.Title = recording.Title;
                    //SetTime(recording.Time);

                    foreach (Annotation a in recording.Annotations)
                        AddAnnotation(a);
                    foreach (KeyValuePair<string, string> kv in recording.EquipmentSettings)
                        SetEquipmentSetting(kv.Key, kv.Value);
                    foreach (KeyValuePair<string, string> kv in recording.MetaData)
                        SetMetaData(kv.Key, kv.Value);
                    foreach (KeyValuePair<string, string> kv in recording.ProtocolSettings)
                        SetProtocolSetting(kv.Key, kv.Value);
                    foreach (KeyValuePair<string, TimeResolvedData> kv in recording.Data)
                        AddData(kv.Key, kv.Value);
                }
            }
        }
        public virtual void StoreInDataSet(PhysiologyData dataSet)
        {
            PhysiologyData.RecordingsRow row = dataSet.Recordings.NewRecordingsRow();
            BackingRow.RecordingID = row.RecordingID;
            dataSet.Recordings.AddRecordingsRow(BackingRow);
            BackingDataSet = dataSet;
        }

        public override void AddData(string dataName, TimeResolvedData data)
        {
            AddData(dataName, data.Time, data.Values, data.Units);
        }
        public override void AddData(string channelName, float[] time, double[] data, string units)
        {
            if (BackingDataSet == null) throw new ApplicationException("No underlying dataset.");
            
            if (BackingDataSet.Recordings_Data.Select(String.Format("RecordingID = {0} AND DataName = '{1}'", RecordingID, channelName)).Length > 0)
                throw new Exception("Channel already exists.");

            for (int i = 0; i < data.Length; i++)
            {
                PhysiologyData.Recordings_DataRow row = BackingDataSet.Recordings_Data.NewRecordings_DataRow();
                
                row.BeginEdit();
                
                row.RecordingID = RecordingID;
                row.DataName = channelName;
                row.Time = time[i];
                row.Value = data[i];
                row.Units = units;

                row.EndEdit();
                BackingDataSet.Recordings_Data.AddRecordings_DataRow(row);
            }
        }

        public override void AddAnnotation(Annotation annotation)
        {
            if (BackingDataSet == null) throw new ApplicationException("No underlying dataset.");
            if (annotation == null) return;

            PhysiologyData.Recordings_AnnotationsRow row = BackingDataSet.Recordings_Annotations.NewRecordings_AnnotationsRow();
            row.BeginEdit();
            
            row.RecordingID = RecordingID;
            row.Entered = annotation.Time;
            row.Text = annotation.Text;
            if(annotation.User != null) {
                PhysiologyData.UsersRow[] rows = BackingDataSet.Users.Select("Name = '" + annotation.User + "'") as PhysiologyData.UsersRow[];
                if(rows.Length == 0) {
                    PhysiologyData.UsersRow usersRow = BackingDataSet.Users.NewUsersRow();
                    usersRow.Name = annotation.User;
                    row.UsersRow = usersRow;
                } else row.UsersRow = rows[0];
            } else row.UserID = BackingRow.UserID;
            
            row.EndEdit();
            BackingDataSet.Recordings_Annotations.AddRecordings_AnnotationsRow(row);
        }
        public override void RemoveAnnotation(Annotation annotation)
        {
            if (BackingDataSet == null) throw new ApplicationException("No underlying dataset.");
            if (annotation == null) return;

            PhysiologyData.Recordings_AnnotationsRow[] rows = BackingDataSet.Recordings_Annotations.Select(String.Format("RecordingID = {0} AND Text = '{1}'", RecordingID, annotation.Text)) as PhysiologyData.Recordings_AnnotationsRow[];
            if (rows.Length > 0)
            {
                foreach(PhysiologyData.Recordings_AnnotationsRow row in rows)
                    if (annotation.Time == row.Entered)
                    {
                        row.Delete();
                    }
            }
        }

        public override void RemoveAllData()
        {
            if (BackingDataSet == null) throw new ApplicationException("No underlying dataset.");

            foreach (PhysiologyData.Recordings_DataRow row in BackingRow.GetRecordings_DataRows())
            {
                row.Delete();
            }
        }
        public override void RemoveData(string channel)
        {
            if (BackingDataSet == null) throw new ApplicationException("No underlying dataset.");

            foreach (PhysiologyData.Recordings_DataRow row in
                BackingDataSet.Recordings_Data.Select(String.Format("RecordingID = {0} AND DataName = {1}", RecordingID, channel)) as PhysiologyData.Recordings_DataRow[])
            {
                row.Delete();
            }
        }
        public override void RemoveEquipmentSetting(string setting)
        {
            if (BackingDataSet == null) throw new ApplicationException("No underlying dataset.");

            PhysiologyData.Recordings_EquipmentSettingsRow[] rows = BackingDataSet.Recordings_EquipmentSettings.Select(
                String.Format("RecordingID = {0} AND Name = {1}", RecordingID, setting)) as PhysiologyData.Recordings_EquipmentSettingsRow[];
            foreach (PhysiologyData.Recordings_EquipmentSettingsRow row in rows)
            {
                row.Delete();
            }
        }
        public override void RemoveMetaData(string title)
        {
            if (BackingDataSet == null) throw new ApplicationException("No underlying dataset.");

            PhysiologyData.Recordings_MetaDataRow[] rows = BackingDataSet.Recordings_MetaData.Select(
                String.Format("RecordingID = {0} AND Name = {1}", RecordingID, title)) as PhysiologyData.Recordings_MetaDataRow[];
            foreach (PhysiologyData.Recordings_MetaDataRow row in rows)
            {
                row.Delete();
            }
        }
        public override void RemoveProtocolSetting(string setting)
        {
            if (BackingDataSet == null) throw new ApplicationException("No underlying dataset.");

            PhysiologyData.Recordings_ProtocolSettingsRow[] rows = BackingDataSet.Recordings_ProtocolSettings.Select(
                String.Format("RecordingID = {0} AND Name = {1}", RecordingID, setting)) as PhysiologyData.Recordings_ProtocolSettingsRow[];
            foreach (PhysiologyData.Recordings_ProtocolSettingsRow row in rows)
            {
                row.Delete();
            }
        }
        public override void SetChannelData(string name, double[] data)
        {
            if (BackingDataSet == null) throw new ApplicationException("No underlying dataset.");

            PhysiologyData.Recordings_DataRow[] rows = BackingDataSet.Recordings_Data.Select(
                String.Format("RecordingID = {0} AND DataName = {1}", RecordingID, name)) as PhysiologyData.Recordings_DataRow[];
            if (rows == null || rows.Length == 0)
                throw new Exception("Data does not already exist. Add the channel instead.");
            else
            {
                if (rows.Length != data.Length) throw new Exception("New data must be the same length as previous data.");

                for (int i = 0; i < rows.Length; i++)
                    rows[i].Value = data[i];
            }
        }
        
        public override void SetChannelName(int channel, string name)
        {
            throw new Exception("Method not supported.");
            if (BackingDataSet == null) throw new ApplicationException("No underlying dataset.");
            

        }
        public override void SetEquipmentSetting(string setting, string value)
        {
            if (BackingDataSet == null) throw new ApplicationException("No underlying dataset.");

            PhysiologyData.Recordings_EquipmentSettingsRow[] rows = BackingDataSet.Recordings_EquipmentSettings.Select(
                String.Format("RecordingID = {0} AND Name = '{1}'", RecordingID, setting)) as PhysiologyData.Recordings_EquipmentSettingsRow[];
            if (rows == null || rows.Length == 0)
            {
                PhysiologyData.Recordings_EquipmentSettingsRow row = BackingDataSet.Recordings_EquipmentSettings.NewRecordings_EquipmentSettingsRow();
                row.BeginEdit();
                row.RecordingID = RecordingID;
                row.Name = setting;
                row.Value = value;
                row.EndEdit();
                BackingDataSet.Recordings_EquipmentSettings.AddRecordings_EquipmentSettingsRow(row);
            }
            else
            {
                foreach (PhysiologyData.Recordings_EquipmentSettingsRow row in rows)
                {
                    row.Value = value;
                }
            }
        }
        public override void SetMetaData(string title, string value)
        {
            if (BackingDataSet == null) throw new ApplicationException("No underlying dataset.");

            PhysiologyData.Recordings_MetaDataRow[] rows = BackingDataSet.Recordings_MetaData.Select(
                String.Format("RecordingID = {0} AND Name = '{1}'", RecordingID, title)) as PhysiologyData.Recordings_MetaDataRow[];
            if (rows == null || rows.Length == 0)
            {
                PhysiologyData.Recordings_MetaDataRow row = BackingDataSet.Recordings_MetaData.NewRecordings_MetaDataRow();
                row.BeginEdit();
                row.RecordingID = RecordingID;
                row.Name = title;
                row.Value = value;
                row.EndEdit();
                BackingDataSet.Recordings_MetaData.AddRecordings_MetaDataRow(row);
            }
            else
            {
                foreach (PhysiologyData.Recordings_MetaDataRow row in rows)
                {
                    row.Value = value;
                }
            }
        }
        public override void SetProtocolSetting(string setting, string value)
        {
            if (BackingDataSet == null) throw new ApplicationException("No underlying dataset.");

            PhysiologyData.Recordings_ProtocolSettingsRow[] rows = BackingDataSet.Recordings_ProtocolSettings.Select(
                String.Format("RecordingID = {0} AND Name = '{1}'", RecordingID, setting)) as PhysiologyData.Recordings_ProtocolSettingsRow[];
            if (rows == null || rows.Length == 0)
            {
                PhysiologyData.Recordings_ProtocolSettingsRow row = BackingDataSet.Recordings_ProtocolSettings.NewRecordings_ProtocolSettingsRow();
                row.BeginEdit();
                row.RecordingID = RecordingID;
                row.Name = setting;
                row.Value = value;
                row.EndEdit();
                BackingDataSet.Recordings_ProtocolSettings.AddRecordings_ProtocolSettingsRow(row);
            }
            else
            {
                foreach (PhysiologyData.Recordings_ProtocolSettingsRow row in rows)
                {
                    row.Value = value;
                }
            }
        }
    }
}
