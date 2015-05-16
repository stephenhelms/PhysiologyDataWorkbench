using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Transactions;
using RRLab.PhysiologyWorkbench.Data;
using MySql.Data.MySqlClient;
using System.Threading;
using RRLab.Utilities;

namespace RRLab.PhysiologyDataConnectivity
{     
    public class MySqlDataManagerDatabaseConnector : Component, IPhysiologyDataDatabaseConnector
    {
        public event EventHandler SyncError, SyncFinished;

        public event EventHandler UserChanged;
        private string _User;

        public string User
        {
            get { return _User; }
            set {
                _User = value;
                if (UserChanged != null) UserChanged(this, EventArgs.Empty);
            }
        }


        public event EventHandler PasswordChanged;
        private string _Password;

        public string Password
        {
            get { return _Password; }
            set {
                _Password = value;
                if (PasswordChanged != null) PasswordChanged(this, EventArgs.Empty);

                
            }
        }

        public event EventHandler ServerChanged;
        private string _Server;

        public string Server
        {
            get { return _Server; }
            set {
                _Server = value;
                if (ServerChanged != null) ServerChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler DatabaseChanged;
        private string _Database;

        public string Database
        {
            get { return _Database; }
            set {
                _Database = value;
                if (DatabaseChanged != null) DatabaseChanged(this, EventArgs.Empty);
            }
        }	

        public MySqlDataManagerDatabaseConnector()
        {
        }

        public virtual bool RequestUserToConfigureConnection()
        {
            LogInDialog dialog = new LogInDialog();
            dialog.DatabaseUser = User;
            dialog.DatabasePassword = Password;
            dialog.Database = Database;
            dialog.DatabaseServerAddress = Server;

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                User = dialog.DatabaseUser;
                Password = dialog.DatabasePassword;
                Database = dialog.Database;
                Server = dialog.DatabaseServerAddress;

                return CheckConnectionSettings();
            }
            else return false;
        }

        public virtual bool CheckConnectionSettings()
        {
            using(MySqlConnection conn = GenerateMySqlConnection()) {
                try
                {
                    conn.Open();
                    return true;
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Connection error: " + e.Message);
                    return false;
                }
            }
        }

        protected virtual MySqlConnection GenerateMySqlConnection()
        {
            // Check for required information
            string errorMessage = null;
            if (User == null) errorMessage = "User must not be null. ";
            if (Server == null) errorMessage += "Server must not be null. ";
            if (Database == null) errorMessage += "Database must not be null. ";

            if (errorMessage != null)
            {
                System.Windows.Forms.MessageBox.Show(errorMessage); // Notify the user
                if (RequestUserToConfigureConnection()) // Give the user the chance to correct error
                    return GenerateMySqlConnection();
                else throw new Exception(errorMessage); // Otherwise throw an exception
            }

            // Build connection
            string connectionString = String.Format(
                "Server={0};Uid={1};Pwd={2};Database={3};pooling=true",
                Server, User, Password, Database);
            return new MySqlConnection(connectionString);
        }

        #region IDataManagerDatabaseConnector Members

        public virtual PhysiologyDataSet LoadDataSetFromDatabase(DatabaseSyncOptions options)
        {
            PhysiologyDataSet dataSet = new PhysiologyDataSet();
            FillDataSetFromDatabase(dataSet, options);
            return dataSet;
        }
        public virtual void FillDataSetFromDatabase(PhysiologyDataSet dataSet, DatabaseSyncOptions options)
        {
            using (MySqlConnection connection = GenerateMySqlConnection())
            {
                connection.Open();

                LoadUsersFromDatabase(dataSet, connection);
                LoadGenotypesFromDatabase(dataSet, connection);
                LoadCellsFromDatabase(dataSet, options, connection);
                LoadCellAnnotationsFromDatabase(dataSet, connection);
                LoadRecordingsFromDatabase(dataSet, connection);
                LoadRecordingsAnnotationsFromDatabase(dataSet, connection);
                LoadRecordingsDataFromDatabase(dataSet, connection);
                LoadRecordingsEquipmentSettingsFromDatabase(dataSet, connection);
                LoadRecordingsMetadataFromDatabase(dataSet, connection);
                LoadRecordingsProtocolSettingsFromDatabase(dataSet, connection);
            }
        }

        public virtual void LoadUsersFromDatabase(PhysiologyDataSet dataSet)
        {
            using (MySqlConnection connection = GenerateMySqlConnection())
            {
                LoadUsersFromDatabase(dataSet, connection);
            }
        }
        public virtual void LoadUsersFromDatabase(PhysiologyDataSet dataSet, MySqlConnection connection)
        {            
            string selectSQLcommand = "select * from users";

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectSQLcommand, connection))
            {
                adapter.Fill(dataSet, "Users");
            }
        }

        public virtual void LoadGenotypesFromDatabase(PhysiologyDataSet dataSet)
        {
            using (MySqlConnection connection = GenerateMySqlConnection())
            {
                LoadGenotypesFromDatabase(dataSet, connection);
            }
        }
        public virtual void LoadGenotypesFromDatabase(PhysiologyDataSet dataSet, MySqlConnection connection)
        {
            string selectSQLcommand = "select * from genotypes";
            string table = "Genotypes";

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectSQLcommand, connection))
            {
                adapter.Fill(dataSet, table);
            }
        }
        public virtual void LoadCellsFromDatabase(PhysiologyDataSet dataSet, DatabaseSyncOptions options)
        {
            using (MySqlConnection connection = GenerateMySqlConnection())
            {
                LoadCellsFromDatabase(dataSet, options, connection);
            }
        }
        public virtual void LoadCellsFromDatabase(PhysiologyDataSet dataSet, DatabaseSyncOptions options, MySqlConnection connection)
        {        
            string selectSQLcommand = "SELECT * FROM cells";

            // Add WHERE clause as necessary based on options
            //string createdColumn = "Created";

            DateTime today = DateTime.Now;
            string todaySQL = String.Format("{0}-{1}-{2}",
                today.Year, today.Month, today.Day);

            DateTime tomorrow = DateTime.Today.AddDays(1);
            string tomorrowSQL = String.Format("{0}-{1}-{2}",
                tomorrow.Year, tomorrow.Month, tomorrow.Day);

            int dayOfWeek = (int)DateTime.Today.DayOfWeek;
            DateTime firstDayOfWeek = DateTime.Today.AddDays(-dayOfWeek);
            string firstDayOfWeekSQL = String.Format("{0}-{1}-{2}",
                firstDayOfWeek.Year, firstDayOfWeek.Month, firstDayOfWeek.Day);

            switch (options)
            {
                case DatabaseSyncOptions.Today:
                    selectSQLcommand += String.Format(" WHERE (Created >= {0}) AND (Created < {1})",
                        todaySQL, tomorrowSQL);
                    break;
                case DatabaseSyncOptions.ThisWeek:
                    selectSQLcommand += String.Format(" WHERE (Created >= {0}) AND (Created < {1})",
                        firstDayOfWeekSQL, tomorrowSQL);
                    break;
                case DatabaseSyncOptions.All:
                    break;
                default:
                    // Return all data (No WHERE clause)
                    break;
            };



            string dsTable = "Cells";

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectSQLcommand, connection))
            {
                adapter.Fill(dataSet, dsTable);
            }
        }

        public void LoadCellAndSubdata(PhysiologyDataSet dataSet, int cellID)
        {
            using (MySqlConnection connection = GenerateMySqlConnection())
            {
                LoadCellAndSubdata(dataSet, cellID, connection);
            }
        }
        public virtual void LoadCellAndSubdata(PhysiologyDataSet dataSet, int cellID, MySqlConnection connection)
        {
            throw new Exception("Not implemented.");
        }
        public virtual void BeginLoadCellAndSubdata(PhysiologyDataSet dataSet, int cellID, IProgressCallback callback)
        {
            ProgressCallbackDynamicallyInvokedTask task = new ProgressCallbackDynamicallyInvokedTask(callback,
                new DataSetAndIdentifierProgressTaskMethod<int>(LoadCellAndSubdata),
                dataSet, cellID, callback);

            task.BeginExecute(null, null);
        }
        public virtual void LoadCellAndSubdata(PhysiologyDataSet dataSet, int cellID, IProgressCallback callback)
        {
            using (MySqlConnection connection = GenerateMySqlConnection())
            {
                LoadCellAndSubdata(dataSet, cellID, connection, callback);
            }
        }
        public virtual void LoadCellAndSubdata(PhysiologyDataSet dataSet, int cellID, MySqlConnection connection, IProgressCallback callback)
        {
            if (callback.IsAborting) return;

            callback.SetTitle("Loading cell...");

            callback.SetRange(0, 100);
            callback.StepTo(0);

            callback.SetTaskInfo("Loading cell annotations...");
            LoadCellAnnotationsFromDatabase(dataSet, cellID, connection);
            callback.Increment(1);

            if (callback.IsAborting) return;

            callback.SetTaskInfo("Loading recordings...");
            LoadRecordingsFromDatabase(dataSet, cellID);
            callback.Increment(1);

            if (callback.IsAborting) return;

            PhysiologyDataSet.RecordingsRow[] recordings = dataSet.Cells.FindByCellID(cellID).GetRecordingsRows();
            int nRecordings = recordings.Length;

            callback.SetRange(0, 2 + nRecordings*5);

            for(int i=0; i < recordings.Length; i++)
            {
                if (callback.IsAborting) return;

                string prefix = String.Format("Loading recording {0} of {1}: ", i, nRecordings);
                
                callback.SetTaskInfo(prefix + "Annotations");
                LoadRecordingsAnnotationsFromDatabase(dataSet, recordings[i].RecordingID, connection);
                callback.Increment(1);

                if (callback.IsAborting) return;

                callback.SetTaskInfo(prefix + "Data (may take a while)");
                LoadRecordingsDataFromDatabase(dataSet, recordings[i].RecordingID, connection);
                callback.Increment(1);

                if (callback.IsAborting) return;

                callback.SetTaskInfo(prefix + "Equipment Settings");
                LoadRecordingsEquipmentSettingsFromDatabase(dataSet, recordings[i].RecordingID, connection);
                callback.Increment(1);

                if (callback.IsAborting) return;

                callback.SetTaskInfo(prefix + "MetaData");
                LoadRecordingsMetadataFromDatabase(dataSet, recordings[i].RecordingID, connection);
                callback.Increment(1);

                if (callback.IsAborting) return;

                callback.SetTaskInfo(prefix + "Protocol Settings");
                LoadRecordingsProtocolSettingsFromDatabase(dataSet, recordings[i].RecordingID, connection);
                callback.Increment(1);

                if (callback.IsAborting) return;
            }

            callback.NotifyFinished();
        }

        public virtual void BeginLoadRecordingSubdataFromDatabase(PhysiologyDataSet dataSet, long recordingID, IProgressCallback callback)
        {
            ProgressCallbackDynamicallyInvokedTask task = new ProgressCallbackDynamicallyInvokedTask(callback,
                new DataSetAndIdentifierProgressTaskMethod<long>(LoadRecordingSubdataFromDatabase),
                dataSet, recordingID, callback);

            task.BeginExecute(null, null);
        }
        public virtual void LoadRecordingSubdataFromDatabase(PhysiologyDataSet dataSet, long recordingID, IProgressCallback callback)
        {
            using (MySqlConnection connection = GenerateMySqlConnection())
            {
                LoadRecordingSubdataFromDatabase(dataSet, recordingID, connection, callback);
            }
        }
        public virtual void LoadRecordingSubdataFromDatabase(PhysiologyDataSet dataSet, long recordingID, MySqlConnection connection, IProgressCallback callback)
        {
            if (callback.IsAborting) return;

            callback.SetRange(0, 5);
            callback.StepTo(0);

            callback.SetTaskInfo("Loading Annotations");
            LoadRecordingsAnnotationsFromDatabase(dataSet, recordingID, connection);
            callback.Increment(1);

            if (callback.IsAborting) return;

            callback.SetTaskInfo("Loading Data (may take a while)");
            LoadRecordingsDataFromDatabase(dataSet, recordingID, connection);
            callback.Increment(1);

            if (callback.IsAborting) return;

            callback.SetTaskInfo("Loading Equipment Settings");
            LoadRecordingsEquipmentSettingsFromDatabase(dataSet, recordingID, connection);
            callback.Increment(1);

            if (callback.IsAborting) return;

            callback.SetTaskInfo("Loading MetaData");
            LoadRecordingsMetadataFromDatabase(dataSet, recordingID, connection);
            callback.Increment(1);

            if (callback.IsAborting) return;

            callback.SetTaskInfo("Loading Protocol Settings");
            LoadRecordingsProtocolSettingsFromDatabase(dataSet, recordingID, connection);
            callback.Increment(1);

            callback.NotifyFinished();
        }

        public virtual void LoadCellAnnotationsFromDatabase(PhysiologyDataSet dataSet)
        {
            using (MySqlConnection connection = GenerateMySqlConnection())
            {
                LoadCellAnnotationsFromDatabase(dataSet, connection);
            }
        }
        public virtual void LoadCellAnnotationsFromDatabase(PhysiologyDataSet dataSet, MySqlConnection connection)
        {
            foreach (PhysiologyDataSet.CellsRow row in dataSet.Cells)
                LoadCellAnnotationsFromDatabase(dataSet, row.CellID, connection);
        }
        public virtual void LoadCellAnnotationsFromDatabase(PhysiologyDataSet dataSet, int cellID)
        {
            using (MySqlConnection connection = GenerateMySqlConnection())
            {
                LoadCellAnnotationsFromDatabase(dataSet, cellID);
            }
        }
        public virtual void LoadCellAnnotationsFromDatabase(PhysiologyDataSet dataSet, int cellID, MySqlConnection connection)
        {
            string selectSQLcommand = "SELECT * FROM cells_annotations WHERE CellID = " + cellID.ToString();

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectSQLcommand, connection))
            {
                adapter.Fill(dataSet, "Cells_Annotations");
            }
        }

        public virtual void BeginUpdateDataSetToDatabase(PhysiologyDataSet dataSet, IProgressCallback callback)
        {
            ProgressCallbackDynamicallyInvokedTask task = new ProgressCallbackDynamicallyInvokedTask(callback,
                new DataSetProgressTaskMethod(UpdateDataSetToDatabase), dataSet, callback);

            task.BeginExecute(null, null);
        }
        public virtual void UpdateDataSetToDatabase(PhysiologyDataSet dataSet)
        {
            UpdateDataSetToDatabase(dataSet, null);
        }
        public virtual void UpdateDataSetToDatabase(PhysiologyDataSet dataSet, IProgressCallback callback)
        {
            if (callback != null)
            {
                callback.SetTitle("Updating Dataset...");
                callback.SetRange(0, 12);
            }

            MySqlConnection connection = GenerateMySqlConnection(); ;

            if(callback != null) callback.SetTaskInfo("Opening connection...");
            connection.Open();
            if (callback != null) callback.Increment(1);

            using (MySqlTransaction transaction = connection.BeginTransaction())
            {
                    if (callback != null) callback.SetTaskInfo("Updating users...");
                    UpdateUsersToDatabase(dataSet, connection);
                    if (callback != null)
                    {
                        callback.Increment(1);
                        if (callback.IsAborting) return;
                    }

                    if (callback != null) callback.SetTaskInfo("Updating genotypes...");
                    UpdateGenotypesToDatabase(dataSet, connection);
                    if (callback != null)
                    {
                        callback.Increment(1);
                        if (callback.IsAborting) return;
                    }

                    if (callback != null) callback.SetTaskInfo("Updating cells...");
                    UpdateCellsToDatabase(dataSet, connection);
                    if (callback != null)
                    {
                        callback.Increment(1);
                        if (callback.IsAborting) return;
                    }

                    if (callback != null) callback.SetTaskInfo("Updating cell annotations");
                    UpdateCellsAnnotationsToDatabase(dataSet, connection);
                    if (callback != null)
                    {
                        callback.Increment(1);
                        if (callback.IsAborting) return;
                    }

                    if (callback != null) callback.SetTaskInfo("Updating recordings...");
                    UpdateRecordingsToDatabase(dataSet, connection);
                    if (callback != null)
                    {
                        callback.Increment(1);
                        if (callback.IsAborting) return;
                    }

                    if (callback != null) callback.SetTaskInfo("Updating recording annotations...");
                    UpdateRecordingsAnnotationsToDatabase(dataSet, connection);
                    if (callback != null)
                    {
                        callback.Increment(1);
                        if (callback.IsAborting) return;
                    }

                    if (callback != null) callback.SetTaskInfo("Updating recording data (may take a while)...");
                    UpdateRecordingsDataToDatabase(dataSet, connection);
                    if (callback != null)
                    {
                        callback.Increment(1);
                        if (callback.IsAborting) return;
                    }

                    if (callback != null) callback.SetTaskInfo("Updating recording equipment data...");
                    UpdateRecordingsEquipmentSettingsToDatabase(dataSet, connection);
                    if (callback != null)
                    {
                        callback.Increment(1);
                        if (callback.IsAborting) return;
                    }

                    if (callback != null) callback.SetTaskInfo("Updating recording metadata...");
                    UpdateRecordingsMetadataToDatabase(dataSet, connection);
                    if (callback != null)
                    {
                        callback.Increment(1);
                        if (callback.IsAborting) return;
                    }

                    if (callback != null) callback.SetTaskInfo("Updating recording protocol settings...");
                    UpdateRecordingsProtocolSettingsToDatabase(dataSet, connection);
                    if (callback != null)
                    {
                        callback.Increment(1);
                        if (callback.IsAborting) return;
                    }

                if (callback != null) callback.SetTaskInfo("Committing changes...");
                transaction.Commit();
                if (callback != null)
                {
                    callback.Increment(1);
                    callback.NotifyFinished();
                }
            }
            if (connection != null) connection.Dispose();
        }

        public virtual void UpdateUsersToDatabase(PhysiologyDataSet dataSet)
        {
            using (MySqlConnection connection = GenerateMySqlConnection())
            {
                UpdateUsersToDatabase(dataSet, connection);
            }
        }
        public virtual void UpdateUsersToDatabase(PhysiologyDataSet dataSet, MySqlConnection connection)
        {
            string selectSQLcommand = "SELECT * FROM users LIMIT 1";

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectSQLcommand, connection))
            {
                using (MySqlCommand deleteCommand = new MySqlCommand(
                    "DELETE FROM users WHERE UserID = ?p1",
                    connection),
                    updateCommand = new MySqlCommand(
                    "UPDATE users SET Name = ?p1 " +
                    "WHERE UserID = ?p2; " +
                    "SELECT * FROM users WHERE UserID = ?p2",
                    connection),
                    insertCommand = new MySqlCommand(
                    "INSERT INTO users (Name) VALUES (?p1); " +
                    "SELECT * FROM users WHERE UserID = LAST_INSERT_ID();",
                    connection))
                {
                    deleteCommand.Parameters.Add("?p1", MySqlDbType.Int16, 0, "UserID");
                    deleteCommand.Parameters["?p1"].SourceVersion = System.Data.DataRowVersion.Original;

                    updateCommand.Parameters.Add("?p1", MySqlDbType.VarChar, 0, "Name");
                    updateCommand.Parameters.Add("?p2", MySqlDbType.Int16, 0, "UserID");
                    updateCommand.Parameters["?p2"].SourceVersion = System.Data.DataRowVersion.Original;
                    updateCommand.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord;

                    insertCommand.Parameters.Add("?p1", MySqlDbType.VarChar, 0, "Name");
                    insertCommand.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord;

                    adapter.DeleteCommand = deleteCommand;
                    adapter.InsertCommand = insertCommand;
                    adapter.UpdateCommand = updateCommand;

                    adapter.Update(dataSet, "Users");
                }
            }
        }

        public virtual void UpdateGenotypesToDatabase(PhysiologyDataSet dataSet)
        {
            using (MySqlConnection connection = GenerateMySqlConnection())
            {
                UpdateGenotypesToDatabase(dataSet, connection);
            }
        }
        public virtual void UpdateGenotypesToDatabase(PhysiologyDataSet dataSet, MySqlConnection connection)
        {
            string selectSQLcommand = "SELECT * FROM genotypes LIMIT 1";

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectSQLcommand, connection))
            {
                using (MySqlCommand deleteCommand = new MySqlCommand(
                    "DELETE FROM genotypes WHERE GenotypeID = ?p1",
                    connection),
                    updateCommand = new MySqlCommand(
                    "UPDATE genotypes SET Genotype = ?p1, Notes = ?p2 " +
                    "WHERE FlyStockID = ?p3; " +
                    "SELECT * FROM genotypes WHERE FlyStockID = ?p3;",
                    connection),
                    insertCommand = new MySqlCommand(
                    "INSERT INTO genotypes (Genotype, Notes) VALUES (?p1, ?p2); " +
                    "SELECT * FROM genotypes WHERE FlyStockID = LAST_INSERT_ID();",
                    connection))
                {
                    deleteCommand.Parameters.Add("?p1", MySqlDbType.Int16, 0, "GenotypeID");
                    deleteCommand.Parameters["?p1"].SourceVersion = System.Data.DataRowVersion.Original;

                    updateCommand.Parameters.Add("?p1", MySqlDbType.VarChar, 0, "Genotype");
                    updateCommand.Parameters.Add("?p2", MySqlDbType.VarString, 0, "Notes");
                    updateCommand.Parameters.Add("?p3", MySqlDbType.Int16, 0, "FlyStockID");
                    updateCommand.Parameters["?p3"].SourceVersion = System.Data.DataRowVersion.Original;
                    updateCommand.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord;

                    insertCommand.Parameters.Add("?p1", MySqlDbType.VarChar, 0, "Genotype");
                    insertCommand.Parameters.Add("?p2", MySqlDbType.VarString, 0, "Notes");
                    insertCommand.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord;

                    adapter.DeleteCommand = deleteCommand;
                    adapter.InsertCommand = insertCommand;
                    adapter.UpdateCommand = updateCommand;

                    adapter.Update(dataSet, "Genotypes");
                }
            }
        }

        public virtual void UpdateCellAndSubdataToDatabase(PhysiologyDataSet dataSet, int cellID)
        {
        }
        public virtual void BeginUpdateCellAndSubdataToDatabase(PhysiologyDataSet dataSet, int cellID, IProgressCallback callback)
        {
            ProgressCallbackDynamicallyInvokedTask task = new ProgressCallbackDynamicallyInvokedTask(callback,
                new DataSetAndIdentifierProgressTaskMethod<int>(UpdateCellAndSubdataToDatabase),
                dataSet, cellID, callback);

            task.BeginExecute(null, null);
        }
        public virtual void UpdateCellAndSubdataToDatabase(PhysiologyDataSet dataSet, int cellID, IProgressCallback callback)
        {
            using (MySqlConnection connection = GenerateMySqlConnection())
            {
                UpdateCellAndSubdataToDatabase(dataSet, cellID, callback, connection);
            }
        }
        public virtual void UpdateCellAndSubdataToDatabase(PhysiologyDataSet dataSet, int cellID, IProgressCallback callback, MySqlConnection connection)
        {
            callback.SetTitle("Updating cell to database...");

            callback.Begin(1, 100);

            callback.SetTaskInfo("Opening connection...");
            connection.Open();

            using (MySqlTransaction transaction = connection.BeginTransaction())
            {
                callback.Increment(1);

                callback.SetTaskInfo("Updating cell information to database...");
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(
                    String.Format("SELECT * FROM cells", cellID), // WHERE CellID = {0}
                    connection))
                {
                    using (MySqlCommand deleteCommand = new MySqlCommand(
                        //"DELETE FROM `physiology_data`.`cells` WHERE ((`CellID` = ?p1) AND (`FlyStockID` = ?p2) AND (`Created` = ?p3) AND ((?p4 = 1 AND `Description` IS NULL) OR (`Description` = ?p5)) AND ((?p6 = 1 AND `PipetteResistance` IS NULL) OR (`PipetteResistance` = ?p7)) AND ((?p8 = 1 AND `SealResistance` IS NULL) OR (`SealResistance` = ?p9)) AND ((?p10 = 1 AND `MembraneResistance` IS NULL) OR (`MembraneResistance` = ?p11)) AND ((?p12 = 1 AND `MembranePotential` IS NULL) OR (`MembranePotential` = ?p13)) AND ((?p14 = 1 AND `CellCapacitance` IS NULL) OR (`CellCapacitance` = ?p15)) AND ((?p16 = 1 AND `SeriesResistance` IS NULL) OR (`SeriesResistance` = ?p17)) AND ((?p18 = 1 AND `BreakInTime` IS NULL) OR (`BreakInTime` = ?p19)) AND ((?p20 = 1 AND `RoughAppearanceRating` IS NULL) OR (`RoughAppearanceRating` = ?p21)) AND ((?p22 = 1 AND `LengthAppearanceRating` IS NULL) OR (`LengthAppearanceRating` = ?p23)) AND ((?p24 = 1 AND `ShapeAppearanceRating` IS NULL) OR (`ShapeAppearanceRating` = ?p25)))",
                    "DELETE FROM cells WHERE CellID = ?p1",
                    connection),
                    updateCommand = new MySqlCommand(
                        //"UPDATE `physiology_data`.`cells` SET `FlyStockID` = ?p1, `Created` = ?p2, `Description` = ?p3, `PipetteResistance` = ?p4, `SealResistance` = ?p5, `MembraneResistance` = ?p6, `MembranePotential` = ?p7, `CellCapacitance` = ?p8, `SeriesResistance` = ?p9, `BreakInTime` = ?p10, `RoughAppearanceRating` = ?p11, `LengthAppearanceRating` = ?p12, `ShapeAppearanceRating` = ?p13 WHERE ((`CellID` = ?p14) AND (`FlyStockID` = ?p15) AND (`Created` = ?p16) AND ((?p17 = 1 AND `Description` IS NULL) OR (`Description` = ?p18)) AND ((?p19 = 1 AND `PipetteResistance` IS NULL) OR (`PipetteResistance` = ?p20)) AND ((?p21 = 1 AND `SealResistance` IS NULL) OR (`SealResistance` = ?p22)) AND ((?p23 = 1 AND `MembraneResistance` IS NULL) OR (`MembraneResistance` = ?p24)) AND ((?p25 = 1 AND `MembranePotential` IS NULL) OR (`MembranePotential` = ?p26)) AND ((?p27 = 1 AND `CellCapacitance` IS NULL) OR (`CellCapacitance` = ?p28)) AND ((?p29 = 1 AND `SeriesResistance` IS NULL) OR (`SeriesResistance` = ?p30)) AND ((?p31 = 1 AND `BreakInTime` IS NULL) OR (`BreakInTime` = ?p32)) AND ((?p33 = 1 AND `RoughAppearanceRating` IS NULL) OR (`RoughAppearanceRating` = ?p34)) AND ((?p35 = 1 AND `LengthAppearanceRating` IS NULL) OR (`LengthAppearanceRating` = ?p36)) AND ((?p37 = 1 AND `ShapeAppearanceRating` IS NULL) OR (`ShapeAppearanceRating` = ?p38)))",
                    "UPDATE cells SET FlyStockID = ?p1, Created = ?p2, Description = ?p3, PipetteResistance = ?p4, " +
                    "SealResistance = ?p5, MembraneResistance = ?p6, MembranePotential = ?p7, CellCapacitance = ?p8, SeriesResistance = ?p9, " +
                    "BreakInTime = ?p10, RoughAppearanceRating = ?p11, LengthAppearanceRating = ?p12, ShapeAppearanceRating = ?p13, UserID = ?p14 " +
                    "WHERE CellID = ?p14;" +
                    "SELECT * FROM cells WHERE CellID = ?p15;",
                    connection),
                    insertCommand = new MySqlCommand(
                    "INSERT INTO cells (FlyStockID, Created, Description, PipetteResistance, SealResistance, " +
                    "MembraneResistance, MembranePotential, CellCapacitance, SeriesResistance, BreakInTime, RoughAppearanceRating, " +
                    "LengthAppearanceRating, ShapeAppearanceRating, UserID) " +
                    "VALUES (?p1, ?p2, ?p3, ?p4, ?p5, ?p6, ?p7, ?p8, ?p9, ?p10, ?p11, ?p12, ?p13, ?p14); " +
                    "SELECT * FROM cells WHERE CellID = LAST_INSERT_ID();", //(SELECT MAX(CellID) FROM physiology_data.cells);",
                    connection))
                    {
                        deleteCommand.Parameters.Add("?p1", MySqlDbType.Int32, 0, "CellID");
                        deleteCommand.Parameters["?p1"].SourceVersion = System.Data.DataRowVersion.Original; // Make sure I use the original CellID, not modified

                        updateCommand.Parameters.Add("?p1", MySqlDbType.Int16, 0, "FlyStockID");
                        updateCommand.Parameters.Add("?p2", MySqlDbType.Datetime, 0, "Created");
                        updateCommand.Parameters.Add("?p3", MySqlDbType.VarChar, 0, "Description");
                        updateCommand.Parameters.Add("?p4", MySqlDbType.Float, 0, "PipetteResistance");
                        updateCommand.Parameters.Add("?p5", MySqlDbType.Float, 0, "SealResistance");
                        updateCommand.Parameters.Add("?p6", MySqlDbType.Float, 0, "MembraneResistance");
                        updateCommand.Parameters.Add("?p7", MySqlDbType.Float, 0, "MembranePotential");
                        updateCommand.Parameters.Add("?p8", MySqlDbType.Float, 0, "CellCapacitance");
                        updateCommand.Parameters.Add("?p9", MySqlDbType.Float, 0, "SeriesResistance");
                        updateCommand.Parameters.Add("?p10", MySqlDbType.Datetime, 0, "BreakInTime");
                        updateCommand.Parameters.Add("?p11", MySqlDbType.UInt16, 0, "RoughAppearanceRating");
                        updateCommand.Parameters.Add("?p12", MySqlDbType.UInt16, 0, "LengthAppearanceRating");
                        updateCommand.Parameters.Add("?p13", MySqlDbType.UInt16, 0, "ShapeApearanceRating");
                        updateCommand.Parameters.Add("?p14", MySqlDbType.Int16, 0, "UserID");
                        updateCommand.Parameters.Add("?p15", MySqlDbType.Int32, 0, "CellID");
                        updateCommand.Parameters["?p15"].SourceVersion = System.Data.DataRowVersion.Original;

                        updateCommand.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord;

                        insertCommand.Parameters.Add("?p1", MySqlDbType.Int16, 0, "FlyStockID");
                        insertCommand.Parameters.Add("?p2", MySqlDbType.Datetime, 0, "Created");
                        insertCommand.Parameters.Add("?p3", MySqlDbType.VarChar, 0, "Description");
                        insertCommand.Parameters.Add("?p4", MySqlDbType.Float, 0, "PipetteResistance");
                        insertCommand.Parameters.Add("?p5", MySqlDbType.Float, 0, "SealResistance");
                        insertCommand.Parameters.Add("?p6", MySqlDbType.Float, 0, "MembraneResistance");
                        insertCommand.Parameters.Add("?p7", MySqlDbType.Float, 0, "MembranePotential");
                        insertCommand.Parameters.Add("?p8", MySqlDbType.Float, 0, "CellCapacitance");
                        insertCommand.Parameters.Add("?p9", MySqlDbType.Float, 0, "SeriesResistance");
                        insertCommand.Parameters.Add("?p10", MySqlDbType.Datetime, 0, "BreakInTime");
                        insertCommand.Parameters.Add("?p11", MySqlDbType.UInt16, 0, "RoughAppearanceRating");
                        insertCommand.Parameters.Add("?p12", MySqlDbType.UInt16, 0, "LengthAppearanceRating");
                        insertCommand.Parameters.Add("?p13", MySqlDbType.UInt16, 0, "ShapeAppearanceRating");
                        insertCommand.Parameters.Add("?p14", MySqlDbType.Int16, 0, "UserID");
                        insertCommand.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord;

                        adapter.InsertCommand = insertCommand;
                        adapter.DeleteCommand = deleteCommand;
                        adapter.UpdateCommand = updateCommand;

                        adapter.Update(dataSet.Cells.Select(String.Format("CellID = {0}", cellID)));
                    }
                }
                callback.Increment(1);

                callback.SetTaskInfo("Updating recordings to database...");
                PhysiologyDataSet.RecordingsRow[] recordings = dataSet.Recordings.Select(
                    String.Format("CellID = {0}", cellID)) as PhysiologyDataSet.RecordingsRow[];
                for (int i = 0; i < recordings.Length; i++)
                {
                    callback.SetTitle(String.Format("Updating recording {0} of {1}...", (i + 1), recordings.Length));
                    UpdateRecordingAndSubdataToDatabaseInternal(dataSet, recordings[i].RecordingID, callback, connection);
                    callback.Increment(1);
                }
                callback.Increment(1);

                callback.NotifyFinished();

                transaction.Commit();
            }
        }

        public virtual void BeginUpdateRecordingAndSubdataToDatabase(PhysiologyDataSet dataSet, long recordingID, IProgressCallback callback)
        {
            ProgressCallbackDynamicallyInvokedTask task = new ProgressCallbackDynamicallyInvokedTask(callback,
                new DataSetAndIdentifierProgressTaskMethod<long>(UpdateRecordingAndSubdataToDatabase),
                dataSet, recordingID, callback);

            task.BeginExecute(null, null);
        }
        public virtual void UpdateRecordingAndSubdataToDatabase(PhysiologyDataSet dataSet, long recordingID, IProgressCallback callback)
        {
            callback.SetTitle("Updating recording to database...");
            callback.Begin(1, 6);
            using (MySqlConnection connection = GenerateMySqlConnection())
            {
                connection.Open();
                UpdateRecordingAndSubdataToDatabaseInternal(dataSet, recordingID, callback, connection);
            }
        }
        protected virtual void UpdateRecordingAndSubdataToDatabaseInternal(PhysiologyDataSet dataSet, long recordingID, IProgressCallback callback, MySqlConnection connection) {
            using(MySqlTransaction transaction = connection.BeginTransaction())
            {
                callback.SetTaskInfo("Updating recording to database...");
                using(MySqlDataAdapter adapter = new MySqlDataAdapter(
                    String.Format("SELECT * FROM recordings WHERE RecordingID = {0}", recordingID),
                    connection))
                {
                    using (MySqlCommand deleteCommand = new MySqlCommand(
                    "DELETE FROM recordings WHERE RecordingID = ?p1",
                    connection),
                    insertCommand = new MySqlCommand(
                    "INSERT INTO recordings (CellID, UserID, Recorded, Title, Description, HoldingPotential, BathSolution, PipetteSolution) " +
                    "VALUES (?p1, ?p2, ?p3, ?p4, ?p5, ?p6, ?p7, ?p8); " +
                    "SELECT * FROM recordings WHERE RecordingID = LAST_INSERT_ID();",
                    connection),
                    updateCommand = new MySqlCommand(
                    "UPDATE recordings SET CellID = ?p1, UserID = ?p2, Recorded = ?p3, Title = ?p4, Description = ?p5, " +
                    "HoldingPotential = ?p6, BathSolution = ?p7, PipetteSolution = ?p8 " +
                    "WHERE RecordingID = ?p9; " +
                    "SELECT * FROM recordings WHERE RecordingID = ?p9;",
                    connection))
                    {
                        deleteCommand.Parameters.Add("?p1", MySqlDbType.Int64, 0, "RecordingID");
                        deleteCommand.Parameters["?p1"].SourceVersion = System.Data.DataRowVersion.Original;

                        insertCommand.Parameters.Add("?p1", MySqlDbType.Int32, 0, "CellID");
                        insertCommand.Parameters.Add("?p2", MySqlDbType.Int16, 0, "UserID");
                        insertCommand.Parameters.Add("?p3", MySqlDbType.Datetime, 0, "Recorded");
                        insertCommand.Parameters.Add("?p4", MySqlDbType.VarChar, 0, "Title");
                        insertCommand.Parameters.Add("?p5", MySqlDbType.VarChar, 0, "Description");
                        insertCommand.Parameters.Add("?p6", MySqlDbType.Int16, 0, "HoldingPotential");
                        insertCommand.Parameters.Add("?p7", MySqlDbType.VarChar, 0, "BathSolution");
                        insertCommand.Parameters.Add("?p8", MySqlDbType.VarChar, 0, "PipetteSolution");
                        insertCommand.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord;

                        updateCommand.Parameters.Add("?p1", MySqlDbType.Int32, 0, "CellID");
                        updateCommand.Parameters.Add("?p2", MySqlDbType.Int16, 0, "UserID");
                        updateCommand.Parameters.Add("?p3", MySqlDbType.Datetime, 0, "Recorded");
                        updateCommand.Parameters.Add("?p4", MySqlDbType.VarChar, 0, "Title");
                        updateCommand.Parameters.Add("?p5", MySqlDbType.VarChar, 0, "Description");
                        updateCommand.Parameters.Add("?p6", MySqlDbType.Int16, 0, "HoldingPotential");
                        updateCommand.Parameters.Add("?p7", MySqlDbType.VarChar, 0, "BathSolution");
                        updateCommand.Parameters.Add("?p8", MySqlDbType.VarChar, 0, "PipetteSolution");
                        updateCommand.Parameters.Add("?p9", MySqlDbType.Int64, 0, "RecordingID");
                        updateCommand.Parameters["?p9"].SourceVersion = System.Data.DataRowVersion.Original;
                        updateCommand.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord;

                        adapter.DeleteCommand = deleteCommand;
                        adapter.InsertCommand = insertCommand;
                        adapter.UpdateCommand = updateCommand;

                        adapter.Update(dataSet.Recordings.Select(String.Format("RecordingID = {0}", recordingID)));
                    }
                }
                callback.Increment(1);

                callback.SetTaskInfo("Updating recording annotations to database...");
                using(MySqlDataAdapter adapter = new MySqlDataAdapter(
                    String.Format("SELECT * FROM recording_annotations WHERE RecordingID = {0}", recordingID),
                    connection))
                {
                    using (MySqlCommand deleteCommand = new MySqlCommand(
                    "DELETE FROM recordings_annotations WHERE AnnotationID = ?p1",
                    connection),
                    updateCommand = new MySqlCommand(
                    "UPDATE recordings_annotations SET RecordingID = ?p1, UserID = ?p2, Entered = ?p3, Text = ?p4; " +
                    "SELECT * FROM recordings_annotations WHERE AnnotationID = ?p5;",
                    connection),
                    insertCommand = new MySqlCommand(
                    "INSERT INTO recordings_annotations (RecordingID, UserID, Entered, Text) " +
                    "VALUES (?p1, ?p2, ?p3, ?p4); " +
                    "SELECT * FROM recordings_annotations WHERE AnnotationID = LAST_INSERT_ID();",
                    connection))
                {
                    deleteCommand.Parameters.Add("?p1", MySqlDbType.Int64, 0, "AnnotationID");
                    deleteCommand.Parameters["?p1"].SourceVersion = System.Data.DataRowVersion.Original;

                    updateCommand.Parameters.Add("?p1", MySqlDbType.Int64, 0, "RecordingID");
                    updateCommand.Parameters.Add("?p2", MySqlDbType.Int16, 0, "UserID");
                    updateCommand.Parameters.Add("?p3", MySqlDbType.Datetime, 0, "Entered");
                    updateCommand.Parameters.Add("?p4", MySqlDbType.VarString, 0, "Text");
                    updateCommand.Parameters.Add("?p5", MySqlDbType.Int64, 0, "AnnotationID");
                    updateCommand.Parameters["?p5"].SourceVersion = System.Data.DataRowVersion.Original;
                    updateCommand.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord;

                    insertCommand.Parameters.Add("?p1", MySqlDbType.Int64, 0, "RecordingID");
                    insertCommand.Parameters.Add("?p2", MySqlDbType.Int16, 0, "UserID");
                    insertCommand.Parameters.Add("?p3", MySqlDbType.Datetime, 0, "Entered");
                    insertCommand.Parameters.Add("?p4", MySqlDbType.VarString, 0, "Text");
                    insertCommand.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord;

                    adapter.DeleteCommand = deleteCommand;
                    adapter.InsertCommand = insertCommand;
                    adapter.UpdateCommand = updateCommand;

                    adapter.Update(dataSet.Recordings_Annotations.Select(
                        String.Format("RecordingID = {0}", recordingID)));
                }
                }
                callback.Increment(1);

                callback.SetTaskInfo("Updating recording data to database (may take awhile)...");
                using(MySqlDataAdapter adapter = new MySqlDataAdapter(
                    String.Format("SELECT * FROM recordings_data WHERE RecordingID = {0}", recordingID),
                    connection))
                {
                    using (MySqlCommand deleteCommand = new MySqlCommand(
                    "DELETE FROM recordings_data WHERE DataPointID = ?p1",
                    connection),
                    updateCommand = new MySqlCommand(
                    "UPDATE recordings_data SET RecordingID = ?p1, DataName = ?p2, Time = ?p3, Value = ?p4, Units = ?p5 " +
                    "WHERE DataPointID = ?p6; " +
                    "SELECT * FROM recordings_data WHERE DataPointID = ?p6;",
                    connection),
                    insertCommand = new MySqlCommand(
                    "INSERT INTO recordings_data (RecordingID, DataName, Time, Value, Units) " +
                    "VALUES (?p1, ?p2, ?p3, ?p4, ?p5); " +
                    "SELECT * FROM recordings_data WHERE DataPointID = LAST_INSERT_ID();",
                    connection))
                    {
                        deleteCommand.Parameters.Add("?p1", MySqlDbType.Int64, 0, "DataPointID");
                        deleteCommand.Parameters["?p1"].SourceVersion = System.Data.DataRowVersion.Original;

                        updateCommand.Parameters.Add("?p1", MySqlDbType.Int64, 0, "RecordingID");
                        updateCommand.Parameters.Add("?p2", MySqlDbType.VarChar, 0, "DataName");
                        updateCommand.Parameters.Add("?p3", MySqlDbType.Float, 0, "Time");
                        updateCommand.Parameters.Add("?p4", MySqlDbType.Double, 0, "Value");
                        updateCommand.Parameters.Add("?p5", MySqlDbType.VarChar, 0, "Units");
                        updateCommand.Parameters.Add("?p6", MySqlDbType.Int64, 0, "DataPointID");
                        updateCommand.Parameters["?p6"].SourceVersion = System.Data.DataRowVersion.Original;
                        updateCommand.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord;

                        insertCommand.Parameters.Add("?p1", MySqlDbType.Int64, 0, "RecordingID");
                        insertCommand.Parameters.Add("?p2", MySqlDbType.VarChar, 0, "DataName");
                        insertCommand.Parameters.Add("?p3", MySqlDbType.Float, 0, "Time");
                        insertCommand.Parameters.Add("?p4", MySqlDbType.Double, 0, "Value");
                        insertCommand.Parameters.Add("?p5", MySqlDbType.VarChar, 0, "Units");
                        insertCommand.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord;

                        adapter.DeleteCommand = deleteCommand;
                        adapter.InsertCommand = insertCommand;
                        adapter.UpdateCommand = updateCommand;

                        adapter.Update(dataSet.Recordings_Data.Select(
                            String.Format("RecordingID = {0}", recordingID)));
                    }
                }
                callback.Increment(1);

                callback.SetTaskInfo("Updating recording equipment settings to database...");
                using(MySqlDataAdapter adapter = new MySqlDataAdapter(
                    String.Format("SELECT * FROM recordings_equipmentsettings WHERE RecordingID = {0}", recordingID),
                    connection))
                {
                    using (MySqlCommand deleteCommand = new MySqlCommand(
                    "DELETE FROM recordings_equipmentsettings WHERE EquipmentSettingsID = ?p1",
                    connection),
                    updateCommand = new MySqlCommand(
                    "UPDATE recordings_equipmentsettings SET RecordingID = ?p1, Name = ?p2, Value = ?p3 " +
                    "WHERE EquipmentSettingsID = ?p4; " +
                    "SELECT * FROM recordings_equipmentsettings WHERE EquipmentSettingsID = ?p4;",
                    connection),
                    insertCommand = new MySqlCommand(
                    "INSERT INTO recordings_equipmentsettings (RecordingID, Name, Value) " +
                    "VALUE (?p1, ?p2, ?p3); " +
                    "SELECT * FROM recordings_equipmentsettings WHERE EquipmentSettingsID = LAST_INSERT_ID();",
                    connection))
                    {
                        deleteCommand.Parameters.Add("?p1", MySqlDbType.Int64, 0, "EquipmentSettingsID");

                        updateCommand.Parameters.Add("?p1", MySqlDbType.Int64, 0, "RecordingID");
                        updateCommand.Parameters.Add("?p2", MySqlDbType.VarChar, 0, "Name");
                        updateCommand.Parameters.Add("?p3", MySqlDbType.VarChar, 0, "Value");
                        updateCommand.Parameters.Add("?p4", MySqlDbType.Int64, 0, "EquipmentSettingsID");
                        updateCommand.Parameters["?p4"].SourceVersion = System.Data.DataRowVersion.Original;
                        updateCommand.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord;

                        insertCommand.Parameters.Add("?p1", MySqlDbType.Int64, 0, "RecordingID");
                        insertCommand.Parameters.Add("?p2", MySqlDbType.VarChar, 0, "Name");
                        insertCommand.Parameters.Add("?p3", MySqlDbType.VarChar, 0, "Value");
                        insertCommand.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord;

                        adapter.DeleteCommand = deleteCommand;
                        adapter.InsertCommand = insertCommand;
                        adapter.UpdateCommand = updateCommand;

                        adapter.Update(dataSet.Recordings_EquipmentSettings.Select(
                            String.Format("RecordingID = {0}", recordingID)));
                    }
                }
                callback.Increment(1);

                callback.SetTaskInfo("Updating recording metadata to database...");
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(
                    String.Format("SELECT * FROM recordings_metadata WHERE RecordingID = {0}", recordingID),
                    connection))
                {
                    using (MySqlCommand deleteCommand = new MySqlCommand(
                    "DELETE FROM recordings_metadata WHERE MetaDataID = ?p1",
                    connection),
                    updateCommand = new MySqlCommand(
                    "UPDATE recordings_metadata SET RecordingID = ?p1, Name = ?p2, Value = ?p3 " +
                    "WHERE MetaDataID = ?p4; " +
                    "SELECT * FROM recordings_metadata WHERE MetaDataID = ?p4",
                    connection),
                    insertCommand = new MySqlCommand(
                    "INSERT INTO recordings_metadata (RecordingID, Name, Value) " +
                    "VALUES (?p1, ?p2, ?p3); " +
                    "SELECT * FROM recordings_metadata WHERE MetaDataID = LAST_INSERT_ID();",
                    connection))
                    {
                        deleteCommand.Parameters.Add("?p1", MySqlDbType.Int64, 0, "MetaDataID");
                        deleteCommand.Parameters["?p1"].SourceVersion = System.Data.DataRowVersion.Original;

                        updateCommand.Parameters.Add("?p1", MySqlDbType.Int64, 0, "RecordingID");
                        updateCommand.Parameters.Add("?p2", MySqlDbType.VarChar, 0, "Name");
                        updateCommand.Parameters.Add("?p3", MySqlDbType.VarChar, 0, "Value");
                        updateCommand.Parameters.Add("?p4", MySqlDbType.Int64, 0, "MetaDataID");
                        updateCommand.Parameters["?p4"].SourceVersion = System.Data.DataRowVersion.Original;
                        updateCommand.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord;

                        insertCommand.Parameters.Add("?p1", MySqlDbType.Int64, 0, "RecordingID");
                        insertCommand.Parameters.Add("?p2", MySqlDbType.VarChar, 0, "Name");
                        insertCommand.Parameters.Add("?p3", MySqlDbType.VarChar, 0, "Value");
                        insertCommand.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord;

                        adapter.DeleteCommand = deleteCommand;
                        adapter.InsertCommand = insertCommand;
                        adapter.UpdateCommand = updateCommand;

                        adapter.Update(dataSet.Recordings_MetaData.Select(
                            String.Format("RecordingID = {0}", recordingID)));
                    }
                }
                callback.Increment(1);

                callback.SetTaskInfo("Updating recording protocol settings to database...");
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(
                    String.Format("SELECT * FROM recordings_protocolsettings WHERE RecordingID = {0}", recordingID),
                    connection))
                {
                    using (MySqlCommand deleteCommand = new MySqlCommand(
                    "DELETE FROM recordings_protocolsettings WHERE ProtocolSettingsID = ?p1",
                    connection),
                    updateCommand = new MySqlCommand(
                    "UPDATE recordings_protocolsettings SET RecordingID = ?p1, Name = ?p2, Value = ?p3 " +
                    "WHERE ProtocolSettingsID = ?p4; " +
                    "SELECT * FROM recordings_protocolsettings WHERE ProtocolSettingsID = ?p4",
                    connection),
                    insertCommand = new MySqlCommand(
                    "INSERT INTO recordings_protocolsettings (RecordingID, Name, Value) " +
                    "VALUES (?p1, ?p2, ?p3); " +
                    "SELECT * FROM recordings_protocolsettings WHERE ProtocolSettingsID = LAST_INSERT_ID();",
                    connection))
                    {
                        deleteCommand.Parameters.Add("?p1", MySqlDbType.Int64, 0, "ProtocolSettingsID");
                        deleteCommand.Parameters["?p1"].SourceVersion = System.Data.DataRowVersion.Original;

                        updateCommand.Parameters.Add("?p1", MySqlDbType.Int64, 0, "RecordingID");
                        updateCommand.Parameters.Add("?p2", MySqlDbType.VarChar, 0, "Name");
                        updateCommand.Parameters.Add("?p3", MySqlDbType.VarChar, 0, "Value");
                        updateCommand.Parameters.Add("?p4", MySqlDbType.Int64, 0, "ProtocolSettingsID");
                        updateCommand.Parameters["?p4"].SourceVersion = System.Data.DataRowVersion.Original;
                        updateCommand.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord;

                        insertCommand.Parameters.Add("?p1", MySqlDbType.Int64, 0, "RecordingID");
                        insertCommand.Parameters.Add("?p2", MySqlDbType.VarChar, 0, "Name");
                        insertCommand.Parameters.Add("?p3", MySqlDbType.VarChar, 0, "Value");
                        insertCommand.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord;

                        adapter.DeleteCommand = deleteCommand;
                        adapter.InsertCommand = insertCommand;
                        adapter.UpdateCommand = updateCommand;

                        adapter.Update(dataSet.Recordings_ProtocolSettings.Select(
                            String.Format("RecordingID = {0}", recordingID)));
                    }
                }
                callback.Increment(1);

                transaction.Commit();
            }
        }

        public virtual void UpdateCellsToDatabase(PhysiologyDataSet dataSet)
        {
            using (MySqlConnection connection = GenerateMySqlConnection())
            {
                UpdateCellsToDatabase(dataSet, connection);
            }
        }
        public virtual void UpdateCellsToDatabase(PhysiologyDataSet dataSet, MySqlConnection connection)
        {               
            string selectSQLcommand = "SELECT * FROM cells LIMIT 1";

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectSQLcommand, connection))
            {
                using (MySqlCommand deleteCommand = new MySqlCommand(
                    //"DELETE FROM `physiology_data`.`cells` WHERE ((`CellID` = ?p1) AND (`FlyStockID` = ?p2) AND (`Created` = ?p3) AND ((?p4 = 1 AND `Description` IS NULL) OR (`Description` = ?p5)) AND ((?p6 = 1 AND `PipetteResistance` IS NULL) OR (`PipetteResistance` = ?p7)) AND ((?p8 = 1 AND `SealResistance` IS NULL) OR (`SealResistance` = ?p9)) AND ((?p10 = 1 AND `MembraneResistance` IS NULL) OR (`MembraneResistance` = ?p11)) AND ((?p12 = 1 AND `MembranePotential` IS NULL) OR (`MembranePotential` = ?p13)) AND ((?p14 = 1 AND `CellCapacitance` IS NULL) OR (`CellCapacitance` = ?p15)) AND ((?p16 = 1 AND `SeriesResistance` IS NULL) OR (`SeriesResistance` = ?p17)) AND ((?p18 = 1 AND `BreakInTime` IS NULL) OR (`BreakInTime` = ?p19)) AND ((?p20 = 1 AND `RoughAppearanceRating` IS NULL) OR (`RoughAppearanceRating` = ?p21)) AND ((?p22 = 1 AND `LengthAppearanceRating` IS NULL) OR (`LengthAppearanceRating` = ?p23)) AND ((?p24 = 1 AND `ShapeAppearanceRating` IS NULL) OR (`ShapeAppearanceRating` = ?p25)))",
                    "DELETE FROM cells WHERE CellID = ?p1",
                    connection),
                    updateCommand = new MySqlCommand(
                    //"UPDATE `physiology_data`.`cells` SET `FlyStockID` = ?p1, `Created` = ?p2, `Description` = ?p3, `PipetteResistance` = ?p4, `SealResistance` = ?p5, `MembraneResistance` = ?p6, `MembranePotential` = ?p7, `CellCapacitance` = ?p8, `SeriesResistance` = ?p9, `BreakInTime` = ?p10, `RoughAppearanceRating` = ?p11, `LengthAppearanceRating` = ?p12, `ShapeAppearanceRating` = ?p13 WHERE ((`CellID` = ?p14) AND (`FlyStockID` = ?p15) AND (`Created` = ?p16) AND ((?p17 = 1 AND `Description` IS NULL) OR (`Description` = ?p18)) AND ((?p19 = 1 AND `PipetteResistance` IS NULL) OR (`PipetteResistance` = ?p20)) AND ((?p21 = 1 AND `SealResistance` IS NULL) OR (`SealResistance` = ?p22)) AND ((?p23 = 1 AND `MembraneResistance` IS NULL) OR (`MembraneResistance` = ?p24)) AND ((?p25 = 1 AND `MembranePotential` IS NULL) OR (`MembranePotential` = ?p26)) AND ((?p27 = 1 AND `CellCapacitance` IS NULL) OR (`CellCapacitance` = ?p28)) AND ((?p29 = 1 AND `SeriesResistance` IS NULL) OR (`SeriesResistance` = ?p30)) AND ((?p31 = 1 AND `BreakInTime` IS NULL) OR (`BreakInTime` = ?p32)) AND ((?p33 = 1 AND `RoughAppearanceRating` IS NULL) OR (`RoughAppearanceRating` = ?p34)) AND ((?p35 = 1 AND `LengthAppearanceRating` IS NULL) OR (`LengthAppearanceRating` = ?p36)) AND ((?p37 = 1 AND `ShapeAppearanceRating` IS NULL) OR (`ShapeAppearanceRating` = ?p38)))",
                    "UPDATE cells SET FlyStockID = ?p1, Created = ?p2, Description = ?p3, PipetteResistance = ?p4, " +
                    "SealResistance = ?p5, MembraneResistance = ?p6, MembranePotential = ?p7, CellCapacitance = ?p8, SeriesResistance = ?p9, " +
                    "BreakInTime = ?p10, RoughAppearanceRating = ?p11, LengthAppearanceRating = ?p12, ShapeAppearanceRating = ?p13, UserID = ?p14 " +
                    "WHERE CellID = ?p15;" +
                    "SELECT * FROM cells WHERE CellID = ?p14;",
                    connection),
                    insertCommand = new MySqlCommand(
                    "INSERT INTO cells (FlyStockID, Created, Description, PipetteResistance, SealResistance, " +
                    "MembraneResistance, MembranePotential, CellCapacitance, SeriesResistance, BreakInTime, RoughAppearanceRating, " +
                    "LengthAppearanceRating, ShapeAppearanceRating, UserID) " +
                    "VALUES (?p1, ?p2, ?p3, ?p4, ?p5, ?p6, ?p7, ?p8, ?p9, ?p10, ?p11, ?p12, ?p13, ?p14); " +
                    "SELECT * FROM cells WHERE CellID = LAST_INSERT_ID();", //(SELECT MAX(CellID) FROM physiology_data.cells);",
                    connection))
                {
                    deleteCommand.Parameters.Add("?p1", MySqlDbType.Int32, 0, "CellID");
                    deleteCommand.Parameters["?p1"].SourceVersion = System.Data.DataRowVersion.Original; // Make sure I use the original CellID, not modified

                    updateCommand.Parameters.Add("?p1", MySqlDbType.Int16, 0, "FlyStockID");
                    updateCommand.Parameters.Add("?p2", MySqlDbType.Datetime, 0, "Created");
                    updateCommand.Parameters.Add("?p3", MySqlDbType.VarChar, 0, "Description");
                    updateCommand.Parameters.Add("?p4", MySqlDbType.Float, 0, "PipetteResistance");
                    updateCommand.Parameters.Add("?p5", MySqlDbType.Float, 0, "SealResistance");
                    updateCommand.Parameters.Add("?p6", MySqlDbType.Float, 0, "MembraneResistance");
                    updateCommand.Parameters.Add("?p7", MySqlDbType.Float, 0, "MembranePotential");
                    updateCommand.Parameters.Add("?p8", MySqlDbType.Float, 0, "CellCapacitance");
                    updateCommand.Parameters.Add("?p9", MySqlDbType.Float, 0, "SeriesResistance");
                    updateCommand.Parameters.Add("?p10", MySqlDbType.Datetime, 0, "BreakInTime");
                    updateCommand.Parameters.Add("?p11", MySqlDbType.UInt16, 0, "RoughAppearanceRating");
                    updateCommand.Parameters.Add("?p12", MySqlDbType.UInt16, 0, "LengthAppearanceRating");
                    updateCommand.Parameters.Add("?p13", MySqlDbType.UInt16, 0, "ShapeAppearanceRating");
                    updateCommand.Parameters.Add("?p14", MySqlDbType.Int16, 0, "UserID");
                    updateCommand.Parameters.Add("?p15", MySqlDbType.Int32, 0, "CellID");
                    updateCommand.Parameters["?p15"].SourceVersion = System.Data.DataRowVersion.Original;

                    updateCommand.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord;

                    insertCommand.Parameters.Add("?p1", MySqlDbType.Int16, 0, "FlyStockID");
                    insertCommand.Parameters.Add("?p2", MySqlDbType.Datetime, 0, "Created");
                    insertCommand.Parameters.Add("?p3", MySqlDbType.VarChar, 0, "Description");
                    insertCommand.Parameters.Add("?p4", MySqlDbType.Float, 0, "PipetteResistance");
                    insertCommand.Parameters.Add("?p5", MySqlDbType.Float, 0, "SealResistance");
                    insertCommand.Parameters.Add("?p6", MySqlDbType.Float, 0, "MembraneResistance");
                    insertCommand.Parameters.Add("?p7", MySqlDbType.Float, 0, "MembranePotential");
                    insertCommand.Parameters.Add("?p8", MySqlDbType.Float, 0, "CellCapacitance");
                    insertCommand.Parameters.Add("?p9", MySqlDbType.Float, 0, "SeriesResistance");
                    insertCommand.Parameters.Add("?p10", MySqlDbType.Datetime, 0, "BreakInTime");
                    insertCommand.Parameters.Add("?p11", MySqlDbType.UInt16, 0, "RoughAppearanceRating");
                    insertCommand.Parameters.Add("?p12", MySqlDbType.UInt16, 0, "LengthAppearanceRating");
                    insertCommand.Parameters.Add("?p13", MySqlDbType.UInt16, 0, "ShapeAppearanceRating");
                    insertCommand.Parameters.Add("?p14", MySqlDbType.Int16, 0, "UserID");
                    insertCommand.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord;

                    adapter.InsertCommand = insertCommand;
                    adapter.DeleteCommand = deleteCommand;
                    adapter.UpdateCommand = updateCommand;

                    adapter.Update(dataSet, "Cells");
                }
            }
        }

        public virtual void UpdateCellsAnnotationsToDatabase(PhysiologyDataSet dataSet)
        {
            using (MySqlConnection connection = GenerateMySqlConnection())
            {
                UpdateCellsAnnotationsToDatabase(dataSet, connection);
            }
        }
        public virtual void UpdateCellsAnnotationsToDatabase(PhysiologyDataSet dataSet, MySqlConnection connection)
        {
            string selectSQLcommand = "SELECT * FROM cells_annotations LIMIT 1";

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectSQLcommand, connection))
            {
                using (MySqlCommand deleteCommand = new MySqlCommand(
                    "DELETE FROM cells_annotations WHERE AnnotationID = ?p1",
                    connection),
                    updateCommand = new MySqlCommand(
                    "UPDATE cells_annotations SET CellID = ?p1, UserID = ?p2, Entered = ?p3, Text = ?p4; " +
                    "SELECT * FROM cells_annotations WHERE AnnotationID = ?p5;",
                    connection),
                    insertCommand = new MySqlCommand(
                    "INSERT INTO cells_annotations (CellID, UserID, Entered, Text) " +
                    "VALUES (?p1, ?p2, ?p3, ?p4); " +
                    "SELECT * FROM cells_annotations WHERE AnnotationID = LAST_INSERT_ID();",
                    connection))
                {
                    deleteCommand.Parameters.Add("?p1", MySqlDbType.Int64, 0, "AnnotationID");
                    deleteCommand.Parameters["?p1"].SourceVersion = System.Data.DataRowVersion.Original;

                    updateCommand.Parameters.Add("?p1", MySqlDbType.Int32, 0, "CellID");
                    updateCommand.Parameters.Add("?p2", MySqlDbType.Int16, 0, "UserID");
                    updateCommand.Parameters.Add("?p3", MySqlDbType.Datetime, 0, "Entered");
                    updateCommand.Parameters.Add("?p4", MySqlDbType.VarString, 0, "Text");
                    updateCommand.Parameters.Add("?p5", MySqlDbType.Int64, 0, "AnnotationID");
                    updateCommand.Parameters["?p5"].SourceVersion = System.Data.DataRowVersion.Original;
                    updateCommand.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord;

                    insertCommand.Parameters.Add("?p1", MySqlDbType.Int32, 0, "CellID");
                    insertCommand.Parameters.Add("?p2", MySqlDbType.Int16, 0, "UserID");
                    insertCommand.Parameters.Add("?p3", MySqlDbType.Datetime, 0, "Entered");
                    insertCommand.Parameters.Add("?p4", MySqlDbType.VarString, 0, "Text");
                    insertCommand.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord;

                    adapter.DeleteCommand = deleteCommand;
                    adapter.InsertCommand = insertCommand;
                    adapter.UpdateCommand = updateCommand;

                    adapter.Update(dataSet, "Cells_Annotations");
                }
            }
        }

        public virtual void UpdateRecordingsToDatabase(PhysiologyDataSet dataSet)
        {
            using (MySqlConnection connection = GenerateMySqlConnection())
            {
                UpdateRecordingsToDatabase(dataSet, connection);
            }
        }
        public virtual void UpdateRecordingsToDatabase(PhysiologyDataSet dataSet, MySqlConnection connection)
        {                   
            string selectSQLcommand = "SELECT * FROM recordings LIMIT 1";

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectSQLcommand, connection))
            {
                using (MySqlCommand deleteCommand = new MySqlCommand(
                    "DELETE FROM recordings WHERE RecordingID = ?p1",
                    connection),
                    insertCommand = new MySqlCommand(
                    "INSERT INTO recordings (CellID, Recorded, Title, Description, HoldingPotential, BathSolution, PipetteSolution) " +
                    "VALUES (?p1, ?p3, ?p4, ?p5, ?p6, ?p7, ?p8); " +
                    "SELECT * FROM recordings WHERE RecordingID = LAST_INSERT_ID();",
                    connection),
                    updateCommand = new MySqlCommand(
                    "UPDATE recordings SET CellID = ?p1, Recorded = ?p3, Title = ?p4, Description = ?p5, " +
                    "HoldingPotential = ?p6, BathSolution = ?p7, PipetteSolution = ?p8 " +
                    "WHERE RecordingID = ?p9; " +
                    "SELECT * FROM recordings WHERE RecordingID = ?p9;",
                    connection))
                {
                    deleteCommand.Parameters.Add("?p1", MySqlDbType.Int64, 0, "RecordingID");
                    deleteCommand.Parameters["?p1"].SourceVersion = System.Data.DataRowVersion.Original;

                    insertCommand.Parameters.Add("?p1", MySqlDbType.Int32, 0, "CellID");
                    insertCommand.Parameters.Add("?p3", MySqlDbType.Datetime, 0, "Recorded");
                    insertCommand.Parameters.Add("?p4", MySqlDbType.VarChar, 0, "Title");
                    insertCommand.Parameters.Add("?p5", MySqlDbType.VarChar, 0, "Description");
                    insertCommand.Parameters.Add("?p6", MySqlDbType.Int16, 0, "HoldingPotential");
                    insertCommand.Parameters.Add("?p7", MySqlDbType.VarChar, 0, "BathSolution");
                    insertCommand.Parameters.Add("?p8", MySqlDbType.VarChar, 0, "PipetteSolution");
                    insertCommand.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord;

                    updateCommand.Parameters.Add("?p1", MySqlDbType.Int32, 0, "CellID");
                    updateCommand.Parameters.Add("?p3", MySqlDbType.Datetime, 0, "Recorded");
                    updateCommand.Parameters.Add("?p4", MySqlDbType.VarChar, 0, "Title");
                    updateCommand.Parameters.Add("?p5", MySqlDbType.VarChar, 0, "Description");
                    updateCommand.Parameters.Add("?p6", MySqlDbType.Int16, 0, "HoldingPotential");
                    updateCommand.Parameters.Add("?p7", MySqlDbType.VarChar, 0, "BathSolution");
                    updateCommand.Parameters.Add("?p8", MySqlDbType.VarChar, 0, "PipetteSolution");
                    updateCommand.Parameters.Add("?p9", MySqlDbType.Int64, 0, "RecordingID");
                    updateCommand.Parameters["?p9"].SourceVersion = System.Data.DataRowVersion.Original;
                    updateCommand.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord;

                    adapter.DeleteCommand = deleteCommand;
                    adapter.InsertCommand = insertCommand;
                    adapter.UpdateCommand = updateCommand;

                    adapter.Update(dataSet, "Recordings");
                }
            }
        }

        #endregion

        public virtual void UpdateRecordingsDataToDatabase(PhysiologyDataSet dataSet)
        {
            using (MySqlConnection connection = GenerateMySqlConnection())
            {
                UpdateRecordingsDataToDatabase(dataSet, connection);
            }
        }
        public virtual void UpdateRecordingsDataToDatabase(PhysiologyDataSet dataSet, MySqlConnection connection)
        {                 
            string selectSQLcommand = "SELECT * FROM recordings_data LIMIT 1";

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectSQLcommand, connection))
            {
                using (MySqlCommand deleteCommand = new MySqlCommand(
                    "DELETE FROM recordings_data WHERE DataPointID = ?p1",
                    connection),
                    updateCommand = new MySqlCommand(
                    "UPDATE recordings_data SET RecordingID = ?p1, DataName = ?p2, Time = '?p3', Value = '?p4', Units = ?p5 " +
                    "WHERE DataPointID = ?p6; " +
                    "SELECT * FROM recordings_data WHERE DataPointID = ?p6;",
                    connection),
                    insertCommand = new MySqlCommand(
                    "INSERT INTO recordings_data (RecordingID, DataName, Time, Value, Units) " +
                    "VALUES (?p1, ?p2, ?p3, ?p4, ?p5); " +
                    "SELECT * FROM recordings_data WHERE DataPointID = LAST_INSERT_ID();",
                    connection))
                {
                    deleteCommand.Parameters.Add("?p1", MySqlDbType.Int64, 0, "DataPointID");
                    deleteCommand.Parameters["?p1"].SourceVersion = System.Data.DataRowVersion.Original;

                    updateCommand.Parameters.Add("?p1", MySqlDbType.Int64, 0, "RecordingID");
                    updateCommand.Parameters.Add("?p2", MySqlDbType.VarChar, 0, "DataName");
                    updateCommand.Parameters.Add("?p3", MySqlDbType.Float, 0, "Time");
                    updateCommand.Parameters.Add("?p4", MySqlDbType.Double, 0, "Value");
                    updateCommand.Parameters.Add("?p5", MySqlDbType.VarChar, 0, "Units");
                    updateCommand.Parameters.Add("?p6", MySqlDbType.Int64, 0, "DataPointID");
                    updateCommand.Parameters["?p6"].SourceVersion = System.Data.DataRowVersion.Original;
                    updateCommand.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord;

                    insertCommand.Parameters.Add("?p1", MySqlDbType.Int64, 0, "RecordingID");
                    insertCommand.Parameters.Add("?p2", MySqlDbType.VarChar, 0, "DataName");
                    insertCommand.Parameters.Add("?p3", MySqlDbType.Float, 0, "Time");
                    insertCommand.Parameters.Add("?p4", MySqlDbType.Double, 0, "Value");
                    insertCommand.Parameters.Add("?p5", MySqlDbType.VarChar, 0, "Units");
                    insertCommand.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord;

                    adapter.DeleteCommand = deleteCommand;
                    adapter.InsertCommand = insertCommand;
                    adapter.UpdateCommand = updateCommand;

                    adapter.Update(dataSet, "Recordings_Data");
                }
            }
        }

        public virtual void UpdateRecordingsAnnotationsToDatabase(PhysiologyDataSet dataSet)
        {
            using (MySqlConnection connection = GenerateMySqlConnection())
            {
                UpdateRecordingsAnnotationsToDatabase(dataSet, connection);
            }
        }
        public virtual void UpdateRecordingsAnnotationsToDatabase(PhysiologyDataSet dataSet, MySqlConnection connection)
        {
            string selectSQLcommand = "SELECT * FROM recordings_annotations LIMIT 1";

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectSQLcommand, connection))
            {
                using (MySqlCommand deleteCommand = new MySqlCommand(
                    "DELETE FROM recordings_annotations WHERE AnnotationID = ?p1",
                    connection),
                    updateCommand = new MySqlCommand(
                    "UPDATE recordings_annotations SET RecordingID = ?p1, UserID = ?p2, Entered = ?p3, Text = ?p4; " +
                    "SELECT * FROM recordings_annotations WHERE AnnotationID = ?p5;",
                    connection),
                    insertCommand = new MySqlCommand(
                    "INSERT INTO recordings_annotations (RecordingID, UserID, Entered, Text) " +
                    "VALUES (?p1, ?p2, ?p3, ?p4); " +
                    "SELECT * FROM recordings_annotations WHERE AnnotationID = LAST_INSERT_ID();",
                    connection))
                {
                    deleteCommand.Parameters.Add("?p1", MySqlDbType.Int64, 0, "AnnotationID");
                    deleteCommand.Parameters["?p1"].SourceVersion = System.Data.DataRowVersion.Original;

                    updateCommand.Parameters.Add("?p1", MySqlDbType.Int64, 0, "RecordingID");
                    updateCommand.Parameters.Add("?p2", MySqlDbType.Int16, 0, "UserID");
                    updateCommand.Parameters.Add("?p3", MySqlDbType.Datetime, 0, "Entered");
                    updateCommand.Parameters.Add("?p4", MySqlDbType.VarString, 0, "Text");
                    updateCommand.Parameters.Add("?p5", MySqlDbType.Int64, 0, "AnnotationID");
                    updateCommand.Parameters["?p5"].SourceVersion = System.Data.DataRowVersion.Original;
                    updateCommand.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord;

                    insertCommand.Parameters.Add("?p1", MySqlDbType.Int64, 0, "RecordingID");
                    insertCommand.Parameters.Add("?p2", MySqlDbType.Int16, 0, "UserID");
                    insertCommand.Parameters.Add("?p3", MySqlDbType.Datetime, 0, "Entered");
                    insertCommand.Parameters.Add("?p4", MySqlDbType.VarString, 0, "Text");
                    insertCommand.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord;

                    adapter.DeleteCommand = deleteCommand;
                    adapter.InsertCommand = insertCommand;
                    adapter.UpdateCommand = updateCommand;

                    adapter.Update(dataSet, "Recordings_Annotations");
                }
            }
        }

        public virtual void UpdateRecordingsEquipmentSettingsToDatabase(PhysiologyDataSet dataSet)
        {
            using (MySqlConnection connection = GenerateMySqlConnection())
            {
                UpdateRecordingsEquipmentSettingsToDatabase(dataSet, connection);
            }
        }
        public virtual void UpdateRecordingsEquipmentSettingsToDatabase(PhysiologyDataSet dataSet, MySqlConnection connection)
        {   
            string selectSQLcommand = "SELECT * FROM recordings_equipmentsettings LIMIT 1";

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectSQLcommand, connection))
            {
                using (MySqlCommand deleteCommand = new MySqlCommand(
                    "DELETE FROM recordings_equipmentsettings WHERE EquipmentSettingsID = ?p1",
                    connection),
                    updateCommand = new MySqlCommand(
                    "UPDATE recordings_equipmentsettings SET RecordingID = ?p1, Name = ?p2, Value = ?p3 " +
                    "WHERE EquipmentSettingsID = ?p4; " +
                    "SELECT * FROM recordings_equipmentsettings WHERE EquipmentSettingsID = ?p4;",
                    connection),
                    insertCommand = new MySqlCommand(
                    "INSERT INTO recordings_equipmentsettings (RecordingID, Name, Value) " +
                    "VALUE (?p1, ?p2, ?p3); " +
                    "SELECT * FROM recordings_equipmentsettings WHERE EquipmentSettingsID = LAST_INSERT_ID();",
                    connection))
                {
                    deleteCommand.Parameters.Add("?p1", MySqlDbType.Int64, 0, "EquipmentSettingsID");

                    updateCommand.Parameters.Add("?p1", MySqlDbType.Int64, 0, "RecordingID");
                    updateCommand.Parameters.Add("?p2", MySqlDbType.VarChar, 0, "Name");
                    updateCommand.Parameters.Add("?p3", MySqlDbType.VarChar, 0, "Value");
                    updateCommand.Parameters.Add("?p4", MySqlDbType.Int64, 0, "EquipmentSettingsID");
                    updateCommand.Parameters["?p4"].SourceVersion = System.Data.DataRowVersion.Original;
                    updateCommand.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord;

                    insertCommand.Parameters.Add("?p1", MySqlDbType.Int64, 0, "RecordingID");
                    insertCommand.Parameters.Add("?p2", MySqlDbType.VarChar, 0, "Name");
                    insertCommand.Parameters.Add("?p3", MySqlDbType.VarChar, 0, "Value");
                    insertCommand.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord;

                    adapter.DeleteCommand = deleteCommand;
                    adapter.InsertCommand = insertCommand;
                    adapter.UpdateCommand = updateCommand;

                    adapter.Update(dataSet, "Recordings_EquipmentSettings");
                }
            }
        }


        public virtual void UpdateRecordingsProtocolSettingsToDatabase(PhysiologyDataSet dataSet)
        {
            using (MySqlConnection connection = GenerateMySqlConnection())
            {
                UpdateRecordingsProtocolSettingsToDatabase(dataSet, connection);
            }
        }
        public virtual void UpdateRecordingsProtocolSettingsToDatabase(PhysiologyDataSet dataSet, MySqlConnection connection)
        {
            string selectSQLcommand = "SELECT * FROM recordings_protocolsettings LIMIT 1";

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectSQLcommand, connection))
            {
                using (MySqlCommand deleteCommand = new MySqlCommand(
                    "DELETE FROM recordings_protocolsettings WHERE ProtocolSettingsID = ?p1",
                    connection),
                    updateCommand = new MySqlCommand(
                    "UPDATE recordings_protocolsettings SET RecordingID = ?p1, Name = ?p2, Value = ?p3 " +
                    "WHERE ProtocolSettingsID = ?p4; " +
                    "SELECT * FROM recordings_protocolsettings WHERE ProtocolSettingsID = ?p4",
                    connection),
                    insertCommand = new MySqlCommand(
                    "INSERT INTO recordings_protocolsettings (RecordingID, Name, Value) " +
                    "VALUES (?p1, ?p2, ?p3); " +
                    "SELECT * FROM recordings_protocolsettings WHERE ProtocolSettingsID = LAST_INSERT_ID();",
                    connection))
                {
                    deleteCommand.Parameters.Add("?p1", MySqlDbType.Int64, 0, "ProtocolSettingsID");
                    deleteCommand.Parameters["?p1"].SourceVersion = System.Data.DataRowVersion.Original;

                    updateCommand.Parameters.Add("?p1", MySqlDbType.Int64, 0, "RecordingID");
                    updateCommand.Parameters.Add("?p2", MySqlDbType.VarChar, 0, "Name");
                    updateCommand.Parameters.Add("?p3", MySqlDbType.VarChar, 0, "Value");
                    updateCommand.Parameters.Add("?p4", MySqlDbType.Int64, 0, "ProtocolSettingsID");
                    updateCommand.Parameters["?p4"].SourceVersion = System.Data.DataRowVersion.Original;
                    updateCommand.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord;

                    insertCommand.Parameters.Add("?p1", MySqlDbType.Int64, 0, "RecordingID");
                    insertCommand.Parameters.Add("?p2", MySqlDbType.VarChar, 0, "Name");
                    insertCommand.Parameters.Add("?p3", MySqlDbType.VarChar, 0, "Value");
                    insertCommand.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord;

                    adapter.DeleteCommand = deleteCommand;
                    adapter.InsertCommand = insertCommand;
                    adapter.UpdateCommand = updateCommand;

                    adapter.Update(dataSet, "Recordings_ProtocolSettings");
                }
            }
        }

        public virtual void UpdateRecordingsMetadataToDatabase(PhysiologyDataSet dataSet)
        {
            using (MySqlConnection connection = GenerateMySqlConnection())
            {
                UpdateRecordingsMetadataToDatabase(dataSet, connection);
            }
        }
        public virtual void UpdateRecordingsMetadataToDatabase(PhysiologyDataSet dataSet, MySqlConnection connection)
        {
            string selectSQLcommand = "SELECT * FROM recordings_metadata LIMIT 1";

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectSQLcommand, connection))
            {
                using (MySqlCommand deleteCommand = new MySqlCommand(
                    "DELETE FROM recordings_metadata WHERE MetaDataID = ?p1",
                    connection),
                    updateCommand = new MySqlCommand(
                    "UPDATE recordings_metadata SET RecordingID = ?p1, Name = ?p2, Value = ?p3 " +
                    "WHERE MetaDataID = ?p4; " +
                    "SELECT * FROM recordings_metadata WHERE MetaDataID = ?p4",
                    connection),
                    insertCommand = new MySqlCommand(
                    "INSERT INTO recordings_metadata (RecordingID, Name, Value) " +
                    "VALUES (?p1, ?p2, ?p3); " +
                    "SELECT * FROM recordings_metadata WHERE MetaDataID = LAST_INSERT_ID();",
                    connection))
                {
                    deleteCommand.Parameters.Add("?p1", MySqlDbType.Int64, 0, "MetaDataID");
                    deleteCommand.Parameters["?p1"].SourceVersion = System.Data.DataRowVersion.Original;

                    updateCommand.Parameters.Add("?p1", MySqlDbType.Int64, 0, "RecordingID");
                    updateCommand.Parameters.Add("?p2", MySqlDbType.VarChar, 0, "Name");
                    updateCommand.Parameters.Add("?p3", MySqlDbType.VarChar, 0, "Value");
                    updateCommand.Parameters.Add("?p4", MySqlDbType.Int64, 0, "MetaDataID");
                    updateCommand.Parameters["?p4"].SourceVersion = System.Data.DataRowVersion.Original;
                    updateCommand.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord;

                    insertCommand.Parameters.Add("?p1", MySqlDbType.Int64, 0, "RecordingID");
                    insertCommand.Parameters.Add("?p2", MySqlDbType.VarChar, 0, "Name");
                    insertCommand.Parameters.Add("?p3", MySqlDbType.VarChar, 0, "Value");
                    insertCommand.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord;

                    adapter.DeleteCommand = deleteCommand;
                    adapter.InsertCommand = insertCommand;
                    adapter.UpdateCommand = updateCommand;

                    adapter.Update(dataSet, "Recordings_MetaData");
                }
            }
        }

        public virtual void LoadRecordingsFromDatabase(PhysiologyDataSet dataSet)
        {
            using (MySqlConnection connection = GenerateMySqlConnection())
            {
                LoadRecordingsFromDatabase(dataSet, connection);
            }
        }
        public virtual void LoadRecordingsFromDatabase(PhysiologyDataSet dataSet, MySqlConnection connection)
        {
            foreach (PhysiologyDataSet.CellsRow row in dataSet.Cells.Rows)
                LoadRecordingsFromDatabase(dataSet, row.CellID, connection);
        }
        public virtual void LoadRecordingsFromDatabase(PhysiologyDataSet dataSet, int cellID)
        {
            using (MySqlConnection connection = GenerateMySqlConnection())
            {
                LoadRecordingsFromDatabase(dataSet, cellID, connection);
            }
        }
        public virtual void LoadRecordingsFromDatabase(PhysiologyDataSet dataSet, int cellID, MySqlConnection connection)
        {
            string selectSQLcommand = String.Format(
                "SELECT * FROM recordings WHERE CellID = {0}",
                cellID);

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectSQLcommand, connection))
            {
                adapter.Fill(dataSet, "Recordings");
            }
        }

        public virtual void LoadRecordingsDataFromDatabase(PhysiologyDataSet dataSet)
        {
            using (MySqlConnection connection = GenerateMySqlConnection())
            {
                LoadRecordingsDataFromDatabase(dataSet, connection);
            }
        }
        public virtual void LoadRecordingsDataFromDatabase(PhysiologyDataSet dataSet, MySqlConnection connection)
        {
            foreach (PhysiologyDataSet.RecordingsRow row in dataSet.Recordings.Rows)
                LoadRecordingsDataFromDatabase(dataSet, row.RecordingID, connection);
        }
        public virtual void LoadRecordingsDataFromDatabase(PhysiologyDataSet dataSet, long recordingID)
        {
            using (MySqlConnection connection = GenerateMySqlConnection())
            {
                LoadRecordingsDataFromDatabase(dataSet, recordingID, connection);
            }
        }
        public virtual void LoadRecordingsDataFromDatabase(PhysiologyDataSet dataSet, long recordingID, MySqlConnection connection)
        {
            string selectSQLcommand = String.Format(
                "SELECT * FROM recordings_data WHERE RecordingID = {0}",
                recordingID);

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectSQLcommand, connection))
            {
                adapter.Fill(dataSet, "Recordings_Data");
            }
        }

        public virtual void LoadRecordingsAnnotationsFromDatabase(PhysiologyDataSet dataSet)
        {
            using (MySqlConnection connection = GenerateMySqlConnection())
            {
                LoadRecordingsAnnotationsFromDatabase(dataSet, connection);
            }
        }
        public virtual void LoadRecordingsAnnotationsFromDatabase(PhysiologyDataSet dataSet, MySqlConnection connection)
        {
            foreach (PhysiologyDataSet.RecordingsRow row in dataSet.Recordings.Rows)
                LoadRecordingsAnnotationsFromDatabase(dataSet, row.RecordingID, connection);
        }
        public virtual void LoadRecordingsAnnotationsFromDatabase(PhysiologyDataSet dataSet, long recordingID)
        {
            using (MySqlConnection connection = GenerateMySqlConnection())
            {
                LoadRecordingsAnnotationsFromDatabase(dataSet, recordingID, connection);
            }
        }
        public virtual void LoadRecordingsAnnotationsFromDatabase(PhysiologyDataSet dataSet, long recordingID, MySqlConnection connection)
        {
            string selectSQLcommand = String.Format(
                "SELECT * FROM recordings_annotations WHERE RecordingID = {0}",
                recordingID);

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectSQLcommand, connection))
            {
                adapter.Fill(dataSet, "Recordings_Annotations");
            }
        }

        public virtual void LoadRecordingsEquipmentSettingsFromDatabase(PhysiologyDataSet dataSet)
        {
            using (MySqlConnection connection = GenerateMySqlConnection())
            {
                LoadRecordingsEquipmentSettingsFromDatabase(dataSet, connection);
            }
        }
        public virtual void LoadRecordingsEquipmentSettingsFromDatabase(PhysiologyDataSet dataSet, MySqlConnection connection)
        {
            foreach (PhysiologyDataSet.RecordingsRow row in dataSet.Recordings.Rows)
                LoadRecordingsEquipmentSettingsFromDatabase(dataSet, row.RecordingID, connection);
        }
        public virtual void LoadRecordingsEquipmentSettingsFromDatabase(PhysiologyDataSet dataSet, long recordingID)
        {
            using (MySqlConnection connection = GenerateMySqlConnection())
            {
                LoadRecordingsEquipmentSettingsFromDatabase(dataSet, recordingID, connection);
            }
        }
        public virtual void LoadRecordingsEquipmentSettingsFromDatabase(PhysiologyDataSet dataSet, long recordingID, MySqlConnection connection)
        {                    
            string selectSQLcommand = String.Format(
                "SELECT * FROM recordings_equipmentsettings WHERE RecordingID = {0}",
                recordingID);

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectSQLcommand, connection))
            {
                adapter.Fill(dataSet, "Recordings_EquipmentSettings");
            }
        }

        public virtual void LoadRecordingsMetadataFromDatabase(PhysiologyDataSet dataSet)
        {
            using (MySqlConnection connection = GenerateMySqlConnection())
            {
                LoadRecordingsMetadataFromDatabase(dataSet, connection);
            }
        }
        public virtual void LoadRecordingsMetadataFromDatabase(PhysiologyDataSet dataSet, MySqlConnection connection)
        {
            foreach (PhysiologyDataSet.RecordingsRow row in dataSet.Recordings.Rows)
                LoadRecordingsMetadataFromDatabase(dataSet, row.RecordingID, connection);
        }

        public virtual void LoadRecordingsMetadataFromDatabase(PhysiologyDataSet dataSet, long recordingID)
        {
            using (MySqlConnection connection = GenerateMySqlConnection())
            {
                LoadRecordingsMetadataFromDatabase(dataSet, recordingID, connection);
            }
        }
        public virtual void LoadRecordingsMetadataFromDatabase(PhysiologyDataSet dataSet, long recordingID, MySqlConnection connection)
        {
            string selectSQLcommand = String.Format(
                "SELECT * FROM recordings_metadata WHERE RecordingID = {0}",
                recordingID);

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectSQLcommand, connection))
            {
                adapter.Fill(dataSet, "Recordings_MetaData");
            }
        }

        public virtual void LoadRecordingsProtocolSettingsFromDatabase(PhysiologyDataSet dataSet)
        {
            using (MySqlConnection connection = GenerateMySqlConnection())
            {
                LoadRecordingsProtocolSettingsFromDatabase(dataSet, connection);
            }
        }
        public virtual void LoadRecordingsProtocolSettingsFromDatabase(PhysiologyDataSet dataSet, MySqlConnection connection)
        {
            foreach (PhysiologyDataSet.RecordingsRow row in dataSet.Recordings.Rows)
                LoadRecordingsMetadataFromDatabase(dataSet, row.RecordingID);
        }
        public virtual void LoadRecordingsProtocolSettingsFromDatabase(PhysiologyDataSet dataSet, long recordingID)
        {
            using (MySqlConnection connection = GenerateMySqlConnection())
            {
                LoadRecordingsProtocolSettingsFromDatabase(dataSet, recordingID, connection);
            }
        }
        public virtual void LoadRecordingsProtocolSettingsFromDatabase(PhysiologyDataSet dataSet, long recordingID, MySqlConnection connection)
        {
            string selectSQLcommand = String.Format(
                "SELECT * FROM recordings_protocolsettings WHERE RecordingID = {0}",
                recordingID);

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectSQLcommand, connection))
            {
                adapter.Fill(dataSet, "Recordings_ProtocolSettings");
            }
        }

        public delegate void DataSetProgressTaskMethod(PhysiologyDataSet dataSet, IProgressCallback callback);
        public delegate void DataSetAndIdentifierProgressTaskMethod<T>(PhysiologyDataSet dataSet, T id, IProgressCallback callback);
    }
}
