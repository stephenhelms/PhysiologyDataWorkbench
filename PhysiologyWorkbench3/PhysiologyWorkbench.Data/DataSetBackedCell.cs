using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RRLab.PhysiologyWorkbench.Data;

namespace RRLab.PhysiologyWorkbench.Data
{
    public class DataSetBackedCell : Cell
    {
        private PhysiologyData _BackingDataSet;

        public PhysiologyData BackingDataSet
        {
            get { return _BackingDataSet; }
            set { _BackingDataSet = value; }
        }

        public int CellID
        {
            get {
                if (BackingDataSet == null) throw new Exception("Underlying dataset must not be null.");
                return BackingRow.CellID;
            }
            set {
                if (BackingDataSet == null) throw new Exception("Underlying dataset must not be null.");
                BackingRow = BackingDataSet.Cells.FindByCellID(value) as PhysiologyData.CellsRow;
            }
        }

        public event EventHandler BackingRowChanged;
        private PhysiologyData.CellsRow _BackingRow;
        public PhysiologyData.CellsRow BackingRow
        {
            get {
                return _BackingRow;
            }
            set {
                if (value.Table.DataSet is PhysiologyData) BackingDataSet = value.Table.DataSet as PhysiologyData;
                else throw new Exception("DataSet must be PhysiologyData.");

                _BackingRow = value;

                if (BackingRowChanged != null) BackingRowChanged(this, EventArgs.Empty);
            }
        }
		
        // Overridden properties
        public override DateTime BreakInTime
        {
            get
            {
                if (BackingDataSet == null) throw new Exception("Underlying dataset must not be null.");
                if (BackingRow.IsBreakInTimeNull()) return DateTime.MinValue;
                else return BackingRow.BreakInTime;
            }
            set
            {
                if (BackingDataSet == null) throw new Exception("Underlying dataset must not be null.");
                if (value == DateTime.MinValue)
                    BackingRow.SetBreakInTimeNull();
                else BackingRow.BreakInTime = value;
                OnBreakInTimeChanged(EventArgs.Empty);
            }
        }

        public override float CellCapacitance
        {
            get
            {
                if (BackingDataSet == null) throw new Exception("Underlying dataset must not be null.");
                if (BackingRow.IsCellCapacitanceNull())
                    return 0f;
                return BackingRow.CellCapacitance;
            }
            set
            {
                if (BackingDataSet == null) throw new Exception("Underlying dataset must not be null.");
                BackingRow.CellCapacitance = value;
                OnCellCapacitanceChanged(EventArgs.Empty);
            }
        }
        public override DateTime Created
        {
            get
            {
                if (BackingDataSet == null) throw new Exception("Underlying dataset must not be null.");
                return BackingRow.Created;
            }
            set
            {
                if (BackingDataSet == null) throw new Exception("Underlying dataset must not be null.");
                BackingRow.Created = value;
                OnCreatedChanged(EventArgs.Empty);
            }
        }
        public override string Description
        {
            get
            {
                if (BackingDataSet == null) throw new Exception("Underlying dataset must not be null.");
                if (BackingRow.IsDescriptionNull())
                    return null;
                return BackingRow.Description;
            }
            set
            {
                if (BackingDataSet == null) throw new Exception("Underlying dataset must not be null.");
                BackingRow.Description = value;
                OnDescriptionChanged(EventArgs.Empty);
            }
        }
        public override string Genotype
        {
            get
            {
                if (BackingDataSet == null) throw new Exception("Underlying dataset must not be null.");
                return BackingRow.GenotypesRow.Genotype;
            }
            set
            {
                if (BackingDataSet == null) throw new Exception("Underlying dataset must not be null.");
                PhysiologyData.GenotypesRow[] matches = BackingDataSet.Genotypes.Select("Genotype = '" + (value ?? "Unknown") + "'") as PhysiologyData.GenotypesRow[];
                if (matches == null || matches.Length == 0)
                {
                    PhysiologyData.GenotypesRow row = BackingDataSet.Genotypes.NewGenotypesRow();
                    row.Genotype = value ?? "Unknown";
                    BackingDataSet.Genotypes.AddGenotypesRow(row);
                    BackingRow.GenotypesRow = row;
                    BackingDataSet.Genotypes.AddGenotypesRow(row);
                }
                else
                {
                    BackingRow.GenotypesRow = matches[0];
                }
                OnGenotypeChanged(EventArgs.Empty);
            }
        }
        public override float MembranePotential
        {
            get
            {
                if (BackingRow.IsMembranePotentialNull())
                    return 0f;
                return BackingRow.MembranePotential;
            }
            set
            {
                BackingRow.MembranePotential = Convert.ToInt16(value);
                OnMembranePotentialChanged(EventArgs.Empty);
            }
        }
        public override float MembraneResistance
        {
            get
            {
                if (BackingDataSet == null) throw new Exception("Underlying dataset must not be null.");
                if (BackingRow.IsMembraneResistanceNull())
                    return 0f;
                return BackingRow.MembraneResistance;
            }
            set
            {
                if (BackingDataSet == null) throw new Exception("Underlying dataset must not be null.");
                BackingRow.MembraneResistance = value;
                OnMembraneResistanceChanged(EventArgs.Empty);
            }
        }
        public override float PipetteResistance
        {
            get
            {
                if (BackingDataSet == null) throw new Exception("Underlying dataset must not be null.");
                if (BackingRow.IsPipetteResistanceNull())
                    return 0f;
                return BackingRow.PipetteResistance;
            }
            set
            {
                if (BackingDataSet == null) throw new Exception("Underlying dataset must not be null.");
                BackingRow.PipetteResistance = value;
                OnPipetteResistanceChanged(EventArgs.Empty);
            }
        }
        public override ICollection<Recording> Recordings
        {
            get
            {
                if (BackingDataSet == null) throw new Exception("Underlying dataset must not be null.");

                PhysiologyData.RecordingsRow[] rows = BackingRow.GetRecordingsRows();

                List<Recording> recordings = new List<Recording>(rows.Length);
                foreach (PhysiologyData.RecordingsRow row in rows)
                    recordings.Add(new DataSetBackedRecording(BackingDataSet, row.RecordingID));

                return recordings;
            }
        }
        public override float SealResistance
        {
            get
            {
                if (BackingDataSet == null) throw new Exception("Underlying dataset must not be null.");
                if (BackingRow.IsSealResistanceNull())
                    return 0f;
                return BackingRow.SealResistance;
            }
            set
            {
                if (BackingDataSet == null) throw new Exception("Underlying dataset must not be null.");
                BackingRow.SealResistance = value;
                OnSealResistanceChanged(EventArgs.Empty);
            }
        }
        public override float SeriesResistance
        {
            get
            {
                if (BackingDataSet == null) throw new Exception("Underlying dataset must not be null.");
                if (BackingRow.IsSeriesResistanceNull())
                    return 0f;
                return BackingRow.SeriesResistance;
            }
            set
            {
                if (BackingDataSet == null) throw new Exception("Underlying dataset must not be null.");
                BackingRow.SeriesResistance = value;
                OnSeriesResistanceChanged(EventArgs.Empty);
            }
        }

        public short UserID
        {
            get
            {
                if (BackingRow == null) throw new Exception("No backing row.");
                return BackingRow.UserID;
            }
            set
            {
                if (BackingRow == null) throw new Exception("No backing row.");
                BackingRow.UserID = value;
                OnUserNameChanged(EventArgs.Empty);
            }
        }

        public override string UserName
        {
            get
            {
                if (BackingRow == null) throw new Exception("No backing row.");
                return BackingRow.UsersRow.Name;
            }
            set
            {
                if (BackingRow == null) throw new Exception("No backing row.");
                PhysiologyData.UsersRow[] rows = BackingDataSet.Users.Select(
                    String.Format("Name = '{0}'", value)) as PhysiologyData.UsersRow[];
                if (rows != null && rows.Length > 0)
                    BackingRow.UsersRow = rows[0];
                else
                {
                    PhysiologyData.UsersRow row = BackingDataSet.Users.AddUsersRow(value);
                    BackingRow.UsersRow = row;
                }
                OnUserNameChanged(EventArgs.Empty);
            }
        }

        public DataSetBackedCell()
        {
            BackingDataSet = new PhysiologyData();
            CreateNewCellEntryInDataSet();
        }
        public DataSetBackedCell(PhysiologyData dataSet)
        {
            BackingDataSet = dataSet;
            CreateNewCellEntryInDataSet();
        }
        public DataSetBackedCell(PhysiologyData dataSet, int cellID)
        {
            BackingDataSet = dataSet;
            CellID = cellID;
        }
        public DataSetBackedCell(PhysiologyData dataSet, Cell cell)
        {
            BackingDataSet = dataSet;
            CreateNewCellEntryInDataSet();
            LoadDataFromCell(cell);
        }

        protected virtual void CreateNewCellEntryInDataSet()
        {
            if (BackingDataSet == null) throw new Exception("No backing DataSet.");

            PhysiologyData.CellsRow row = BackingDataSet.Cells.NewCellsRow();

            // Deal with null values
            row.BeginEdit();
            row.Created = DateTime.Now;

            PhysiologyData.GenotypesRow genotypesRow;
            if (BackingDataSet.Genotypes.Select("Genotype = 'Unknown'").Length == 0)
            {
                genotypesRow = BackingDataSet.Genotypes.NewGenotypesRow();
                genotypesRow.Genotype = "Unknown";
                BackingDataSet.Genotypes.AddGenotypesRow(genotypesRow);
            }
            else
            {
                PhysiologyData.GenotypesRow[] rows = BackingDataSet.Genotypes.Select("Genotype = 'Unknown'") as PhysiologyData.GenotypesRow[];
                genotypesRow = rows[0];
            }
            row.GenotypesRow = genotypesRow;

            PhysiologyData.UsersRow[] users = BackingDataSet.Users.Select("Name = 'Unknown'") as PhysiologyData.UsersRow[];
            if (users != null && users.Length > 0)
                row.UsersRow = users[0];
            else row.UsersRow = BackingDataSet.Users.AddUsersRow("Unknown");

            row.EndEdit();

            BackingDataSet.Cells.AddCellsRow(row);
            CellID = row.CellID;
        }
        public virtual void LoadDataFromCell(Cell cell)
        {
            this.BreakInTime = cell.BreakInTime;
            this.Created = cell.Created;
            this.Description = cell.Description;
            this.Genotype = cell.Genotype;

            this.CellCapacitance = cell.CellCapacitance;
            this.MembranePotential = cell.MembranePotential;
            this.MembraneResistance = cell.MembraneResistance;
            this.PipetteResistance = cell.PipetteResistance;
            this.SealResistance = cell.SealResistance;
            this.SeriesResistance = cell.SeriesResistance;
            
            this.RoughAppearanceRating = cell.RoughAppearanceRating;
            this.LengthAppearanceRating = cell.LengthAppearanceRating;
            this.ShapeAppearanceRating = cell.ShapeAppearanceRating;
            
            this.UserName = cell.UserName;

            foreach (Recording recording in cell.Recordings)
                new DataSetBackedRecording(this, recording);

            foreach (Annotation annotation in cell.Annotations)
                AddAnnotation(annotation);
        }

        public override void AddRecording(Recording recording)
        {
            if (recording is DataSetBackedRecording)
            {
                DataSetBackedRecording dataSetRecording = recording as DataSetBackedRecording;
                if (dataSetRecording.BackingDataSet == BackingDataSet)
                    dataSetRecording.Cell = this;
                else
                {
                    dataSetRecording.StoreInDataSet(BackingDataSet);
                    dataSetRecording.Cell = this;
                }
            }
            else recording.Cell = this;
        }
        public override void RemoveRecording(Recording recording)
        {
            recording.Cell = null;
        }

        public override void AddAnnotation(Annotation annotation)
        {
            if (BackingRow == null) throw new Exception("No backing row.");

            PhysiologyData.Cells_AnnotationsRow row = BackingDataSet.Cells_Annotations.NewCells_AnnotationsRow();
            row.CellsRow = BackingRow;
            if (annotation.User != null)
            {
                PhysiologyData.UsersRow[] users = BackingDataSet.Users.Select(
                    String.Format("Name = {0}", annotation.User)) as PhysiologyData.UsersRow[];
                if (users != null && users.Length > 0)
                    row.UsersRow = users[0];
                else row.UsersRow = BackingRow.UsersRow;
            }
            else row.UsersRow = BackingRow.UsersRow;
            row.Entered = annotation.Time;
            row.Text = annotation.Text;

            BackingDataSet.Cells_Annotations.AddCells_AnnotationsRow(row);

            OnAnnotationsChanged(EventArgs.Empty);
        }
        public override void RemoveAnnotation(Annotation annotation)
        {
            if (BackingRow == null) throw new Exception("No backin row.");

            PhysiologyData.Cells_AnnotationsRow[] rows = BackingDataSet.Cells_Annotations.Select(
                String.Format("CellID = {0}, Time = {1}, Text = '{2}'", BackingRow.CellID, annotation.Time, @annotation.Text))
                as PhysiologyData.Cells_AnnotationsRow[];
            foreach (PhysiologyData.Cells_AnnotationsRow row in rows)
                row.Delete();

            OnAnnotationsChanged(EventArgs.Empty);
        }

        public override ICollection<Annotation> Annotations
        {
            get
            {
                PhysiologyData.Cells_AnnotationsRow[] rows = BackingDataSet.Cells_Annotations.Select(
                    String.Format("CellID = {0}", BackingRow.CellID)) as PhysiologyData.Cells_AnnotationsRow[];
                List<Annotation> annotations = new List<Annotation>(rows.Length);
                foreach (PhysiologyData.Cells_AnnotationsRow row in rows)
                    annotations.Add(new Annotation(row.Entered, row.Text, row.UsersRow.Name));

                return annotations;
            }
        }

        public override ushort LengthAppearanceRating
        {
            get
            {
                if (BackingRow.IsLengthAppearanceRatingNull())
                    return 0;
                return BackingRow.LengthAppearanceRating;
            }
            set
            {
                BackingRow.LengthAppearanceRating = value;
                OnLengthAppearanceRatingChanged(EventArgs.Empty);
            }
        }

        public override ushort RoughAppearanceRating
        {
            get
            {
                if (BackingRow.IsRoughAppearanceRatingNull())
                    return 0;
                return BackingRow.RoughAppearanceRating;
                
            }
            set
            {
                BackingRow.RoughAppearanceRating = value;
                OnRoughAppearanceRatingChanged(EventArgs.Empty);
            }
        }

        public override ushort ShapeAppearanceRating
        {
            get
            {
                if (BackingRow.IsShapeAppearanceRatingNull())
                    return 0;
                return BackingRow.ShapeAppearanceRating;
            }
            set
            {
                BackingRow.ShapeAppearanceRating = value;
                OnShapeAppearanceRatingChanged(EventArgs.Empty);
            }
        }
    }
}
