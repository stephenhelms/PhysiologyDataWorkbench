using System;
using RRLab.Utilities;
namespace RRLab.PhysiologyWorkbench.Data
{
    public interface IPhysiologyDataDatabaseConnector
    {
        void BeginLoadCellAndSubdata(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet, int cellID, RRLab.Utilities.IProgressCallback callback);
        void BeginLoadRecordingSubdataFromDatabase(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet, long recordingID, RRLab.Utilities.IProgressCallback callback);
        void BeginUpdateRecordingAndSubdataToDatabase(PhysiologyDataSet dataSet, long recordingID, IProgressCallback callback);
        void BeginUpdateCellAndSubdataToDatabase(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet, int cellID, RRLab.Utilities.IProgressCallback callback);
        void BeginUpdateDataSetToDatabase(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet, RRLab.Utilities.IProgressCallback callback);
        bool CheckConnectionSettings();
        string Database { get; set; }
        event EventHandler DatabaseChanged;
        void FillDataSetFromDatabase(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet, DatabaseSyncOptions options);
        void LoadCellAndSubdata(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet, int cellID);
        void LoadCellAndSubdata(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet, int cellID, RRLab.Utilities.IProgressCallback callback);
        void LoadCellAnnotationsFromDatabase(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet);
        void LoadCellAnnotationsFromDatabase(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet, int cellID);
        void LoadCellsFromDatabase(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet, DatabaseSyncOptions options);
        RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet LoadDataSetFromDatabase(DatabaseSyncOptions options);
        void LoadGenotypesFromDatabase(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet);
        void LoadRecordingsAnnotationsFromDatabase(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet);
        void LoadRecordingsAnnotationsFromDatabase(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet, long recordingID);
        void LoadRecordingsDataFromDatabase(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet, long recordingID);
        void LoadRecordingsDataFromDatabase(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet);
        void LoadRecordingsEquipmentSettingsFromDatabase(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet);
        void LoadRecordingsEquipmentSettingsFromDatabase(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet, long recordingID);
        void LoadRecordingsFromDatabase(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet);
        void LoadRecordingsFromDatabase(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet, int cellID);
        void LoadRecordingsMetadataFromDatabase(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet, long recordingID);
        void LoadRecordingsMetadataFromDatabase(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet);
        void LoadRecordingsProtocolSettingsFromDatabase(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet, long recordingID);
        void LoadRecordingsProtocolSettingsFromDatabase(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet);
        void LoadRecordingSubdataFromDatabase(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet, long recordingID, RRLab.Utilities.IProgressCallback callback);
        void LoadUsersFromDatabase(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet);
        string Password { get; set; }
        event EventHandler PasswordChanged;
        bool RequestUserToConfigureConnection();
        string Server { get; set; }
        event EventHandler ServerChanged;
        event EventHandler SyncError;
        event EventHandler SyncFinished;
        void UpdateCellAndSubdataToDatabase(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet, int cellID, RRLab.Utilities.IProgressCallback callback);
        void UpdateCellAndSubdataToDatabase(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet, int cellID);
        void UpdateCellsAnnotationsToDatabase(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet);
        void UpdateCellsToDatabase(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet);
        void UpdateDataSetToDatabase(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet);
        void UpdateDataSetToDatabase(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet, RRLab.Utilities.IProgressCallback callback);
        void UpdateGenotypesToDatabase(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet);
        void UpdateRecordingsAnnotationsToDatabase(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet);
        void UpdateRecordingsDataToDatabase(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet);
        void UpdateRecordingsEquipmentSettingsToDatabase(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet);
        void UpdateRecordingsMetadataToDatabase(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet);
        void UpdateRecordingsProtocolSettingsToDatabase(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet);
        void UpdateRecordingsToDatabase(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet);
        void UpdateUsersToDatabase(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet dataSet);
        string User { get; set; }
        event EventHandler UserChanged;
    }
}
