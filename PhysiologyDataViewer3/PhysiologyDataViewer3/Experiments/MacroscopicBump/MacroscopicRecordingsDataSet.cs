using MySql.Data.MySqlClient;
using System;
namespace RRLab.PhysiologyDataWorkshop.Experiments.MacroscopicBump {


    partial class MacroscopicRecordingsDataSet
    {
        partial class MacroscopicRecordingsDataTable
        {
            public void Update(MySqlConnection connection)
            {
                string selectCommandText = @"SELECT        cells.CellID, expt_macro.RecordingID, genotypes.Genotype, expt_macro.AnalysisDate, recordings.Recorded, users.Name, recordings.Title, expt_macro.RelativeLogIntensity, 
                         expt_macro.CalciumConcentration, expt_macro.Amplitude, expt_macro.TimeOfPeak, expt_macro.ChargeIntegral, expt_macro.LatencyTime, expt_macro.SlowActivationTime, expt_macro.FastActivationTime, 
                         expt_macro.FastInactivationTime, expt_macro.SlowInactivationTime, cells.Description AS CellDescription, recordings.Description AS RecordingDescription, 
                         recordings.HoldingPotential, cells.PipetteResistance, cells.SealResistance, cells.CellCapacitance, cells.SeriesResistance, cells.MembraneResistance, 
                         cells.MembranePotential, cells.BreakInTime, timediff(cells.BreakInTime, recordings.Recorded) AS TimeSinceBreakIn, cells.RoughAppearanceRating, 
                         cells.LengthAppearanceRating, cells.ShapeAppearanceRating, recordings.BathSolution, recordings.PipetteSolution, expt_macro.Comments
FROM            expt_macro, cells, recordings, users, genotypes
WHERE        (expt_macro.RecordingID = recordings.RecordingID) AND (recordings.CellID = cells.CellID) AND (cells.FlyStockID = genotypes.FlyStockID) AND 
                         (cells.UserID = users.UserID)";

                using (MySqlCommand selectCommand = new MySqlCommand(
                    selectCommandText, connection),
                   updateCommand = new MySqlCommand(
                   @"UPDATE expt_macro SET RecordingID = ?p1, AnalysisDate = ?p2, RelativeLogIntensity = ?p3, CalciumConcentration = ?p4,
                Amplitude = ?p5, TimeOfPeak = ?p6, ChargeIntegral = ?p7, LatencyTime = ?p8, SlowActivationTime = ?p9, FastActivationTime = ?p10,
                FastInactivationTime = ?p11, SlowInactivationTime = ?p12, Comments = ?p13;" +
                  selectCommandText + " AND expt_macro.RecordingID = ?p1", connection),
                  insertCommand = new MySqlCommand(@"INSERT INTO expt_macro (RecordingID,AnalysisDate,RelativeLogIntensity,CalciumConcentration,Amplitude,TimeOfPeak,ChargeIntegral,LatencyTime,SlowActivationTime,FastActivationTime,FastInactivationTime,SlowInactivationTime,Comments)" +
                    @"VALUES (?p1,?p2,?p3,?p4,?p5,?p6,?p7,?p8,?p9,?p10,?p11,?p12,?p13);" +
                    selectCommandText + " AND expt_macro.RecordingID = ?p1", connection),
                  deleteCommand = new MySqlCommand("DELETE FROM expt_macro WHERE RecordingID = ?p1", connection))
                {
                    updateCommand.Parameters.Add("?p1", MySqlDbType.Int64, 0, "RecordingID");
                    updateCommand.Parameters.Add("?p2", MySqlDbType.Datetime, 0, "AnalysisDate");
                    updateCommand.Parameters.Add("?p3", MySqlDbType.Float, 0, "RelativeLogIntensity");
                    updateCommand.Parameters.Add("?p4", MySqlDbType.Float, 0, "CalciumConcentration");
                    updateCommand.Parameters.Add("?p5", MySqlDbType.Double, 0, "Amplitude");
                    updateCommand.Parameters.Add("?p6", MySqlDbType.Float, 0, "TimeOfPeak");
                    updateCommand.Parameters.Add("?p7", MySqlDbType.Double, 0, "ChargeIntegral");
                    updateCommand.Parameters.Add("?p8", MySqlDbType.Float, 0, "LatencyTime");
                    updateCommand.Parameters.Add("?p9", MySqlDbType.Float, 0, "SlowActivationTime");
                    updateCommand.Parameters.Add("?p10", MySqlDbType.Float, 0, "FastActivationTime");
                    updateCommand.Parameters.Add("?p11", MySqlDbType.Float, 0, "FastInactivationTime");
                    updateCommand.Parameters.Add("?p12", MySqlDbType.Float, 0, "SlowInactivationTime");
                    updateCommand.Parameters.Add("?p13", MySqlDbType.String, 0, "Comments");
                    updateCommand.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord;

                    insertCommand.Parameters.Add("?p1", MySqlDbType.Int64, 0, "RecordingID");
                    insertCommand.Parameters.Add("?p2", MySqlDbType.Datetime, 0, "AnalysisDate");
                    insertCommand.Parameters.Add("?p3", MySqlDbType.Float, 0, "RelativeLogIntensity");
                    insertCommand.Parameters.Add("?p4", MySqlDbType.Float, 0, "CalciumConcentration");
                    insertCommand.Parameters.Add("?p5", MySqlDbType.Double, 0, "Amplitude");
                    insertCommand.Parameters.Add("?p6", MySqlDbType.Float, 0, "TimeOfPeak");
                    insertCommand.Parameters.Add("?p7", MySqlDbType.Double, 0, "ChargeIntegral");
                    insertCommand.Parameters.Add("?p8", MySqlDbType.Float, 0, "LatencyTime");
                    insertCommand.Parameters.Add("?p9", MySqlDbType.Float, 0, "SlowActivationTime");
                    insertCommand.Parameters.Add("?p10", MySqlDbType.Float, 0, "FastActivationTime");
                    insertCommand.Parameters.Add("?p11", MySqlDbType.Float, 0, "FastInactivationTime");
                    insertCommand.Parameters.Add("?p12", MySqlDbType.Float, 0, "SlowInactivationTime");
                    insertCommand.Parameters.Add("?p13", MySqlDbType.String, 0, "Comments");
                    insertCommand.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord;

                    deleteCommand.Parameters.Add("?p1", MySqlDbType.Int64, 0, "RecordingID");

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand))
                    {
                        adapter.InsertCommand = insertCommand;
                        adapter.UpdateCommand = updateCommand;
                        adapter.DeleteCommand = deleteCommand;

                        try
                        {
                            adapter.Update(this.Select());
                        }
                        catch (Exception x)
                        {
                            System.Diagnostics.Debug.Fail("MacroscopicBumpTableAdapter: Error during update.", x.Message);
                        }
                    }
                }
            }
        }
    }
}
