using System;
using System.Data;
using System.Text;
using System.Collections.Generic;

namespace RRLab.PhysiologyWorkbench.Data {
    
    
    public partial class PhysiologyDataSet {
        partial class Cells_AnnotationsDataTable
        {
        }
    
        public partial class CellsRow
        {
            public PhysiologyDataSet PhysiologyDataSet
            {
                get
                {
                    return Table.DataSet as PhysiologyDataSet;
                }
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

                Cells_AnnotationsRow row = PhysiologyDataSet.Cells_Annotations.NewCells_AnnotationsRow();

                row.CellID = CellID;
                row.Entered = entered;
                row.Text = text;
                if (user != null) row.UserID = (short)user;

                PhysiologyDataSet.Cells_Annotations.AddCells_AnnotationsRow(row);
            }
        }

        public partial class RecordingsRow
        {
            public PhysiologyDataSet PhysiologyDataSet
            {
                get { return this.Table.DataSet as PhysiologyDataSet; }
            }

            public RecordingsDataTable RecordingsDataTable
            {
                get { return this.Table as RecordingsDataTable; }
            }

            public virtual bool DoesMetaDataExist(string title)
            {
                Recordings_MetaDataRow[] rows = PhysiologyDataSet.Recordings_MetaData.Select(
                String.Format("RecordingID = {0} AND Name = '{1}'", RecordingID, title)) as Recordings_MetaDataRow[];
                return rows.Length != 0;
            }
            public virtual bool DoesEquipmentSettingExist(string title)
            {
                Recordings_EquipmentSettingsRow[] rows = PhysiologyDataSet.Recordings_EquipmentSettings.Select(
                    String.Format("RecordingID = {0} AND Name = '{1}'", RecordingID, title)) as Recordings_EquipmentSettingsRow[];
                return rows.Length != 0;
            }
            public virtual string GetMetaData(string title)
            {
                PhysiologyDataSet dataSet = PhysiologyDataSet;
                Recordings_MetaDataRow[] rows = dataSet.Recordings_MetaData.Select(
                String.Format("RecordingID = {0} AND Name = '{1}'", RecordingID, title)) as Recordings_MetaDataRow[];

                if (rows != null && rows.Length > 0)
                    return rows[0].Value;
                else return null;
            }
            public virtual void RemoveMetaData(string title)
            {
                PhysiologyDataSet dataSet = PhysiologyDataSet;
                Recordings_MetaDataRow[] rows = dataSet.Recordings_MetaData.Select(
                String.Format("RecordingID = {0} AND Name = '{1}'", RecordingID, title)) as Recordings_MetaDataRow[];

                if (rows != null && rows.Length > 0)
                    foreach (Recordings_MetaDataRow row in rows)
                    {
                        row.Delete();
                    }
            }
            public virtual void AddMetaData(string title, string value)
            {
                Recordings_MetaDataRow row = PhysiologyDataSet.Recordings_MetaData.NewRecordings_MetaDataRow();
                row.BeginEdit();
                row.RecordingID = RecordingID;
                row.Name = title;
                row.Value = value;
                row.EndEdit();
                PhysiologyDataSet.Recordings_MetaData.AddRecordings_MetaDataRow(row);
            }
            public virtual void SetMetaData(string title, string value)
            {
                PhysiologyDataSet dataSet = PhysiologyDataSet;
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

            public virtual void AddProtocolSetting(string setting, string value)
            {
                Recordings_ProtocolSettingsRow row = PhysiologyDataSet.Recordings_ProtocolSettings.NewRecordings_ProtocolSettingsRow();
                row.BeginEdit();
                row.RecordingID = RecordingID;
                row.Name = setting;
                row.Value = value;
                row.EndEdit();
                PhysiologyDataSet.Recordings_ProtocolSettings.AddRecordings_ProtocolSettingsRow(row);
            }

            public virtual void SetProtocolSetting(string setting, string value)
            {
                Recordings_ProtocolSettingsRow[] rows = PhysiologyDataSet.Recordings_ProtocolSettings.Select(
                    String.Format("RecordingID = {0} AND Name = '{1}'", RecordingID, setting)) as Recordings_ProtocolSettingsRow[];
                if (rows == null || rows.Length == 0)
                {
                    Recordings_ProtocolSettingsRow row = PhysiologyDataSet.Recordings_ProtocolSettings.NewRecordings_ProtocolSettingsRow();
                    row.BeginEdit();
                    row.RecordingID = RecordingID;
                    row.Name = setting;
                    row.Value = value;
                    row.EndEdit();
                    PhysiologyDataSet.Recordings_ProtocolSettings.AddRecordings_ProtocolSettingsRow(row);
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
                Recordings_ProtocolSettingsRow[] rows = PhysiologyDataSet.Recordings_ProtocolSettings.Select(
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
            public virtual void ReplaceOrAddData(string[] dataNames, string[] units, float[] time, double[,] data)
            {
                int singleLength = data.Length / dataNames.Length;
                for (int i = 0; i < dataNames.Length; i++)
                {
                    double[] singleData = new double[singleLength];
                    for (int j = 0; j < singleLength; j++)
                        singleData[j] = data[i, j];
                    if (GetData(dataNames[i]).DataPoints.Length == 0)
                        AddData(dataNames[i], units[i], time, singleData);
                    else ReplaceData(dataNames[i], singleData);
                }
            }
            public virtual void AddData(string dataName, string units, float[] time, double[] data)
            {
                if (dataName == null) throw new ArgumentException("DataName must be provided.");
                if (PhysiologyDataSet.Recordings_Data.Select(String.Format("RecordingID = {0} AND DataName = '{1}'", RecordingID, dataName)).Length > 0)
                    throw new Exception("Channel already exists.");
                if (time.Length != data.Length) throw new ArgumentException("Time and Data must be the same length.");
                if (time == null || data == null) throw new ArgumentException("Time and Data must not be null.");
                if (units == null) units = "Unspecified";

                PhysiologyDataSet.Recordings_Data.BeginLoadData();

                for (int i = 0; i < data.Length; i++)
                {
                    Recordings_DataRow row = PhysiologyDataSet.Recordings_Data.NewRecordings_DataRow();

                    row.BeginEdit();

                    row.RecordingID = RecordingID;
                    row.DataName = dataName;
                    row.Time = time[i];
                    row.Value = data[i];
                    row.Units = units;

                    row.EndEdit();
                    PhysiologyDataSet.Recordings_Data.AddRecordings_DataRow(row);
                }

                PhysiologyDataSet.Recordings_Data.EndLoadData();
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

                Recordings_DataRow[] rows = PhysiologyDataSet.Recordings_Data.Select(String.Format("RecordingID = {0} AND DataName = '{1}'", RecordingID, dataName)) as Recordings_DataRow[];
                foreach (Recordings_DataRow row in rows)
                    row.Delete();
            }
            public virtual void ClearEquipmentSettings()
            {
                DataRow[] rows = PhysiologyDataSet.Recordings_EquipmentSettings.Select(
                    String.Format("RecordingID = {0}", RecordingID));
                foreach (DataRow row in rows)
                    row.Delete();
            }
            public virtual void ClearMetaData()
            {
                DataRow[] rows = PhysiologyDataSet.Recordings_MetaData.Select(
                    String.Format("RecordingID = {0}", RecordingID));
                foreach (DataRow row in rows)
                    row.Delete();
            }
            public virtual void ClearProtocolSettings()
            {
                DataRow[] rows = PhysiologyDataSet.Recordings_ProtocolSettings.Select(
                    String.Format("RecordingID = {0}", RecordingID));
                foreach (DataRow row in rows)
                    row.Delete();
            }

            public virtual TimeResolvedData GetData(string dataName)
            {
                Recordings_DataRow[] rows = GetDataRows(dataName);

                TimeResolvedDataPoint[] points = new TimeResolvedDataPoint[rows.Length];
                for (int i = 0; i < rows.Length; i++)
                    points[i] = new TimeResolvedDataPoint(rows[i].Time, rows[i].Value);

                return new TimeResolvedData(points);
            }

            public virtual Recordings_DataRow[] GetDataRows(string dataName)
            {
                return PhysiologyDataSet.Recordings_Data.Select(
                    String.Format("RecordingID = {0} AND DataName = '{1}'", RecordingID, dataName), "Time") as Recordings_DataRow[];
            }

            public virtual void ReplaceData(string dataName, double[] data)
            {
                Recordings_DataRow[] rows = GetDataRows(dataName);
                if (rows.Length != data.Length) throw new ArgumentException("New data must be of same length as old data.");
                for (int i = 0; i < rows.Length; i++)
                    rows[i].Value = data[i];
            }

            public virtual void ModifyData(string dataName, Transform<double> transform, string newUnits)
            {
                Recordings_DataRow[] rows = GetDataRows(dataName);
                for (int i = 0; i < rows.Length; i++)
                {
                    rows[i].Value = transform(rows[i].Value);
                    if(newUnits != null) rows[i].Units = newUnits;
                }
            }
            public virtual void ModifyData(string dataName, ContextualTransform<double, Recordings_DataRow> rowBasedTransform, string newUnits)
            {
                Recordings_DataRow[] rows = GetDataRows(dataName);
                for (int i = 0; i < rows.Length; i++)
                {
                    rows[i].Value = rowBasedTransform(rows[i].Value, rows[i]);
                    if(newUnits != null) rows[i].Units = newUnits;
                }
            }
            public virtual void ModifyData(string dataName, ContextualTransform<double, float> timeBasedTransform, string newUnits)
            {
                Recordings_DataRow[] rows = GetDataRows(dataName);
                for (int i = 0; i < rows.Length; i++)
                {
                    rows[i].Value = timeBasedTransform(rows[i].Value, rows[i].Time);
                    if(newUnits != null) rows[i].Units = newUnits;
                }
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

                Recordings_AnnotationsRow row = PhysiologyDataSet.Recordings_Annotations.NewRecordings_AnnotationsRow();

                row.RecordingID = RecordingID;
                row.Entered = entered;
                row.Text = text;
                if(user != null) row.UserID = (short) user;

                PhysiologyDataSet.Recordings_Annotations.AddRecordings_AnnotationsRow(row);
            }
            public virtual void AddEquipmentSetting(string setting, string value)
            {
                Recordings_EquipmentSettingsRow row = PhysiologyDataSet.Recordings_EquipmentSettings.NewRecordings_EquipmentSettingsRow();
                row.BeginEdit();
                row.RecordingID = RecordingID;
                row.Name = setting;
                row.Value = value;
                row.EndEdit();
                PhysiologyDataSet.Recordings_EquipmentSettings.AddRecordings_EquipmentSettingsRow(row);
            }
            public virtual void SetEquipmentSetting(string setting, string value)
            {
                Recordings_EquipmentSettingsRow[] rows = PhysiologyDataSet.Recordings_EquipmentSettings.Select(
                    String.Format("RecordingID = {0} AND Name = '{1}'", RecordingID, setting)) as PhysiologyDataSet.Recordings_EquipmentSettingsRow[];
                if (rows == null || rows.Length == 0)
                {
                    Recordings_EquipmentSettingsRow row = PhysiologyDataSet.Recordings_EquipmentSettings.NewRecordings_EquipmentSettingsRow();
                    row.BeginEdit();
                    row.RecordingID = RecordingID;
                    row.Name = setting;
                    row.Value = value;
                    row.EndEdit();
                    PhysiologyDataSet.Recordings_EquipmentSettings.AddRecordings_EquipmentSettingsRow(row);
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
                PhysiologyDataSet dataSet = PhysiologyDataSet;
                Recordings_EquipmentSettingsRow[] rows = dataSet.Recordings_EquipmentSettings.Select(
                String.Format("RecordingID = {0} AND Name = '{1}'", RecordingID, setting)) as Recordings_EquipmentSettingsRow[];

                if (rows != null && rows.Length > 0)
                    return rows[0].Value;
                else return null;
            }
            public virtual void RemoveEquipmentSetting(string setting)
            {
                Recordings_EquipmentSettingsRow[] rows = PhysiologyDataSet.Recordings_EquipmentSettings.Select(
                    String.Format("RecordingID = {0} AND Name = {1}", RecordingID, setting)) as Recordings_EquipmentSettingsRow[];
                foreach (Recordings_EquipmentSettingsRow row in rows)
                {
                    row.Delete();
                }
            }
        }
    }
}
