using System;
using System.Data;
using System.Text;
using System.Collections.Generic;

namespace RRLab.PhysiologyWorkbench.Data {
    
    
    public partial class PhysiologyData {
        public partial class RecordingsRow
        {
            public PhysiologyData PhysiologyData
            {
                get { return this.Table.DataSet as PhysiologyData; }
            }

            public RecordingsDataTable RecordingsDataTable
            {
                get { return this.Table as RecordingsDataTable; }
            }

            public virtual bool DoesMetaDataExist(string title)
            {
                Recordings_MetaDataRow[] rows = PhysiologyData.Recordings_MetaData.Select(
                String.Format("RecordingID = {0} AND Name = '{1}'", RecordingID, title)) as Recordings_MetaDataRow[];
                return rows.Length != 0;
            }
            public virtual string GetMetaData(string title)
            {
                PhysiologyData dataSet = PhysiologyData;
                Recordings_MetaDataRow[] rows = dataSet.Recordings_MetaData.Select(
                String.Format("RecordingID = {0} AND Name = '{1}'", RecordingID, title)) as Recordings_MetaDataRow[];

                if (rows != null && rows.Length > 0)
                    return rows[0].Value;
                else return null;
            }
            public virtual void RemoveMetaData(string title)
            {
                PhysiologyData dataSet = PhysiologyData;
                Recordings_MetaDataRow[] rows = dataSet.Recordings_MetaData.Select(
                String.Format("RecordingID = {0} AND Name = '{1}'", RecordingID, title)) as Recordings_MetaDataRow[];

                if (rows != null && rows.Length > 0)
                    foreach (Recordings_MetaDataRow row in rows)
                    {
                        row.Delete();
                    }
            }
            public virtual void SetMetaData(string title, string value)
            {
                PhysiologyData dataSet = PhysiologyData;
                Recordings_MetaDataRow[] rows = dataSet.Recordings_MetaData.Select(
                String.Format("RecordingID = {0} AND Name = '{1}'", RecordingID, title)) as Recordings_MetaDataRow[];

                if (rows == null || rows.Length == 0)
                {
                    Recordings_MetaDataRow row = dataSet.Recordings_MetaData.NewRecordings_MetaDataRow();
                    row.BeginEdit();
                    row.RecordingID = RecordingID;
                    row.Name = title;
                    row.Value = value;
                    row.EndEdit();
                    dataSet.Recordings_MetaData.AddRecordings_MetaDataRow(row);
                }
                else
                {
                    foreach (Recordings_MetaDataRow row in rows)
                    {
                        row.Value = value;
                    }
                }
            }

            public virtual void SetProtocolSetting(string setting, string value)
            {
                Recordings_ProtocolSettingsRow[] rows = PhysiologyData.Recordings_ProtocolSettings.Select(
                    String.Format("RecordingID = {0} AND Name = '{1}'", RecordingID, setting)) as Recordings_ProtocolSettingsRow[];
                if (rows == null || rows.Length == 0)
                {
                    Recordings_ProtocolSettingsRow row = PhysiologyData.Recordings_ProtocolSettings.NewRecordings_ProtocolSettingsRow();
                    row.BeginEdit();
                    row.RecordingID = RecordingID;
                    row.Name = setting;
                    row.Value = value;
                    row.EndEdit();
                    PhysiologyData.Recordings_ProtocolSettings.AddRecordings_ProtocolSettingsRow(row);
                }
                else
                {
                    foreach (Recordings_ProtocolSettingsRow row in rows)
                    {
                        row.Value = value;
                    }
                }
            }
            public virtual void RemoveProtocolSetting(string setting)
            {
                Recordings_ProtocolSettingsRow[] rows = PhysiologyData.Recordings_ProtocolSettings.Select(
                    String.Format("RecordingID = {0} AND Name = {1}", RecordingID, setting)) as Recordings_ProtocolSettingsRow[];
                foreach (Recordings_ProtocolSettingsRow row in rows)
                {
                    row.Delete();
                }
            }

            public virtual ICollection<string> GetDataNames()
            {
                Recordings_DataRow[] rows = GetRecordings_DataRows();

                List<string> names = new List<string>();
                // TODO: Figure out a more efficient way to do this
                foreach (Recordings_DataRow row in rows)
                    if (!names.Contains(row.DataName)) names.Add(row.DataName);

                return names;
            }

            public virtual void AddData(string dataName, string units, TimeResolvedDataPoint[] data)
            {
                float[] time = new float[data.Length];
                double[] values = new double[data.Length];

                for (int i = 0; i < time.Length; i++)
                {
                    time[i] = data[i].Time;
                    values[i] = data[i].Data;
                }
                AddData(dataName, units, time, values);
            }
            public virtual void AddData(string[] dataNames, float[] time, double[,] data)
            {
                AddData(dataNames, time, data, null);
            }
            public virtual void AddData(string[] dataNames, float[] time, double[,] data, string[] units)
            {
                int singleLength = data.Length / dataNames.Length;

                if (units == null)
                {
                    units = new string[dataNames.Length];
                    for (int i = 0; i < dataNames.Length; i++) units[i] = "Unknown";
                }

                for (int i = 0; i < dataNames.Length; i++)
                {
                    double[] singleData = new double[singleLength];
                    for (int j = 0; j < singleLength; j++)
                        singleData[j] = data[i, j];
                    this.AddData(dataNames[i], units[i], time, singleData);
                }
            }
            public virtual void AddData(string dataName, string units, float[] time, double[] data)
            {
                if (dataName == null) throw new ArgumentException("DataName must be provided.");
                if (RecordingsDataTable.Select(String.Format("RecordingID = {0} AND DataName = '{1}'", RecordingID, dataName)).Length > 0)
                    throw new Exception("Channel already exists.");
                if (time.Length != data.Length) throw new ArgumentException("Time and Data must be the same length.");
                if (time == null || data == null) throw new ArgumentException("Time and Data must not be null.");
                if (units == null) units = "Unspecified";

                for (int i = 0; i < data.Length; i++)
                {
                    Recordings_DataRow row = PhysiologyData.Recordings_Data.NewRecordings_DataRow();

                    row.BeginEdit();

                    row.RecordingID = RecordingID;
                    row.DataName = dataName;
                    row.Time = time[i];
                    row.Value = data[i];
                    row.Units = units;

                    row.EndEdit();
                    PhysiologyData.Recordings_Data.AddRecordings_DataRow(row);
                }
            }
            public virtual void ClearData()
            {
                Recordings_DataRow[] rows = this.GetRecordings_DataRows();
                foreach (Recordings_DataRow row in rows)
                {
                    row.Delete();
                }
            }
            public virtual void ClearData(string dataName)
            {
                if (dataName == null) return;

                Recordings_DataRow[] rows = RecordingsDataTable.Select(String.Format("RecordingID = {0} AND DataName = '{1}'", RecordingID, dataName)) as Recordings_DataRow[];
                foreach (Recordings_DataRow row in rows)
                    row.Delete();
            }

            public virtual TimeResolvedDataPoint[] GetData(string dataName)
            {
                Recordings_DataRow[] rows = GetDataRows(dataName);

                TimeResolvedDataPoint[] points = new TimeResolvedDataPoint[rows.Length];
                for (int i = 0; i < rows.Length; i++)
                    points[i] = new TimeResolvedDataPoint(rows[i].Time, rows[i].Value);

                return points;
            }

            public virtual Recordings_DataRow[] GetDataRows(string dataName)
            {
                return PhysiologyData.Recordings_Data.Select(
                    String.Format("RecordingID = {0} AND DataName = '{1}'", RecordingID, dataName), "Time") as Recordings_DataRow[];
            }

            public virtual void ReplaceData(string dataName, double[] data)
            {
                Recordings_DataRow[] rows = GetDataRows(dataName);
                if (rows.Length != data.Length) throw new ArgumentException("New data must be of same length as old data.");
                for (int i = 0; i < rows.Length; i++)
                    rows[i].Value = data[i];
            }

            public virtual void ModifyData(string dataName, Transform<double> transform)
            {
                Recordings_DataRow[] rows = GetDataRows(dataName);
                for (int i = 0; i < rows.Length; i++)
                    rows[i].Value = transform(rows[i].Value);
            }
            public virtual void ModifyData(string dataName, ContextualTransform<double, Recordings_DataRow> rowBasedTransform)
            {
                Recordings_DataRow[] rows = GetDataRows(dataName);
                for (int i = 0; i < rows.Length; i++)
                    rows[i].Value = rowBasedTransform(rows[i].Value, rows[i]);
            }
            public virtual void ModifyData(string dataName, ContextualTransform<double, float> timeBasedTransform)
            {
                Recordings_DataRow[] rows = GetDataRows(dataName);
                for (int i = 0; i < rows.Length; i++)
                    rows[i].Value = timeBasedTransform(rows[i].Value, rows[i].Time);
            }
            public virtual void ModifyTime(Transform<float> transform)
            {
                Recordings_DataRow[] rows = GetRecordings_DataRows();
                foreach (Recordings_DataRow row in rows)
                    row.Time = transform(row.Time);
            }
            public virtual void ModifyTime(ContextualTransform<float, Recordings_DataRow> rowBasedTransform)
            {
                Recordings_DataRow[] rows = GetRecordings_DataRows();
                foreach (Recordings_DataRow row in rows)
                    row.Time = rowBasedTransform(row.Time, row);
            }

            public virtual void AddAnnotation(string text)
            {
                AddAnnotation(DateTime.Now, text, null);
            }
            public virtual void AddAnnotation(string text, short user)
            {
                AddAnnotation(DateTime.Now, text, user);
            }
            public virtual void AddAnnotation(DateTime entered, string text)
            {
                AddAnnotation(entered, text, null);
            }
            public virtual void AddAnnotation(DateTime entered, string text, short? user)
            {
                if (text == null) return;

                Recordings_AnnotationsRow row = PhysiologyData.Recordings_Annotations.NewRecordings_AnnotationsRow();

                row.RecordingID = RecordingID;
                row.Entered = entered;
                row.Text = text;
                if(user != null) row.UserID = (short) user;

                PhysiologyData.Recordings_Annotations.AddRecordings_AnnotationsRow(row);
            }
            public virtual void SetEquipmentSetting(string setting, string value)
            {
                Recordings_EquipmentSettingsRow[] rows = PhysiologyData.Recordings_EquipmentSettings.Select(
                    String.Format("RecordingID = {0} AND Name = '{1}'", RecordingID, setting)) as PhysiologyData.Recordings_EquipmentSettingsRow[];
                if (rows == null || rows.Length == 0)
                {
                    Recordings_EquipmentSettingsRow row = PhysiologyData.Recordings_EquipmentSettings.NewRecordings_EquipmentSettingsRow();
                    row.BeginEdit();
                    row.RecordingID = RecordingID;
                    row.Name = setting;
                    row.Value = value;
                    row.EndEdit();
                    PhysiologyData.Recordings_EquipmentSettings.AddRecordings_EquipmentSettingsRow(row);
                }
                else
                {
                    foreach (Recordings_EquipmentSettingsRow row in rows)
                    {
                        row.Value = value;
                    }
                }
            }
            public virtual string GetEquipmentSetting(string setting)
            {
                PhysiologyData dataSet = PhysiologyData;
                Recordings_EquipmentSettingsRow[] rows = dataSet.Recordings_EquipmentSettings.Select(
                String.Format("RecordingID = {0} AND Name = '{1}'", RecordingID, setting)) as Recordings_EquipmentSettingsRow[];

                if (rows != null && rows.Length > 0)
                    return rows[0].Value;
                else return null;
            }
            public virtual void RemoveEquipmentSetting(string setting)
            {
                Recordings_EquipmentSettingsRow[] rows = PhysiologyData.Recordings_EquipmentSettings.Select(
                    String.Format("RecordingID = {0} AND Name = {1}", RecordingID, setting)) as Recordings_EquipmentSettingsRow[];
                foreach (Recordings_EquipmentSettingsRow row in rows)
                {
                    row.Delete();
                }
            }
        }
    }
}
