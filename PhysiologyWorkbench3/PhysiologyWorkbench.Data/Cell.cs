using System;
using System.Collections;
using System.Collections.Generic;

namespace RRLab.PhysiologyWorkbench.Data
{
	/// <summary>
	/// Cell is a class which holds all recorded data for a particular cell, including Recording, seal resistance, and Annotation objects.
	/// </summary>
	[Serializable()]
	public class Cell
	{
		[field: NonSerialized()] public event EventHandler InformationUpdated;

		/// <summary>
		/// <c>Cell()</c> creates an empty <c>Cell</c> object.
		/// </summary>
		public Cell()
		{
		}
		/// <summary>
		/// Creates a <c>Cell</c> object with <c>Recorded=creationDate</c> and <c>Name=genotype</c>.
		/// </summary>
		/// <param genotype="creationDate">The time at which recording on the cell began.</param>
		/// <param genotype="genotype">An identifier for the cell.</param>
		public Cell(DateTime creationDate, String genotype)
		{
            Created = creationDate;
            Genotype = genotype;
		}


		/// <summary>
		/// Stores a <c>Recording</c> object recorded on this cell.
		/// </summary>
		/// <param genotype="measurementTime">The time at which the recording was started.</param>
		/// <param genotype="recording">The recording.</param>
		public virtual void AddRecording(Recording recording) 
		{
			_Recordings.Add(recording);
			if((InformationUpdated != null) && (!SuppressUpdateNotification)) InformationUpdated(this, new EventArgs());
		}
        public virtual void RemoveRecording(Recording recording)
        {
            if (_Recordings.Contains(recording)) _Recordings.Remove(recording);
            if ((InformationUpdated != null) && (!SuppressUpdateNotification)) InformationUpdated(this, EventArgs.Empty);
        }

        public override string ToString()
        {
            if (Genotype != null)
                return Genotype + " (" + Created.ToShortTimeString() + ")";
            else return "Cell (" + Created.ToShortTimeString() + ")";
        }

        public event EventHandler DescriptionChanged;
        private string _Description = "";
        
        public virtual string Description
        {
            get { return _Description; }
            set {
                _Description = value;
                OnDescriptionChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnDescriptionChanged(EventArgs e)
        {
            if (DescriptionChanged != null && !SuppressUpdateNotification) DescriptionChanged(this, EventArgs.Empty);
        }


        public event EventHandler CreatedChanged;

		private DateTime _Created = DateTime.Now;
		/// <summary>
		/// The time at which the cell was generated. The default value is DateTime.MinValue.
		/// </summary>
		public virtual DateTime Created 
		{
			get 
			{
				return _Created;
			}
			set 
			{
				_Created = value;
                OnCreatedChanged(EventArgs.Empty);
			}
		}

        protected virtual void OnCreatedChanged(EventArgs e)
        {
            if (CreatedChanged != null && !SuppressUpdateNotification) CreatedChanged(this, e);
        }

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

        protected virtual void OnSuppressUpdateNotificationChanged(EventArgs e)
        {
            if (SuppressUpdateNotificationChanged != null && !SuppressUpdateNotification) SuppressUpdateNotificationChanged(this, EventArgs.Empty);
            if (!SuppressUpdateNotification)
            {
                OnBreakInTimeChanged(e);
                OnCellCapacitanceChanged(e);
                OnCreatedChanged(e);
                OnDescriptionChanged(e);
                OnGenotypeChanged(e);
                OnMembranePotentialChanged(e);
                OnMembraneResistanceChanged(e);
                OnPipetteResistanceChanged(e);
                OnRecordingsChanged(e);
                OnSealResistanceChanged(e);
                OnSeriesResistanceChanged(e);
            }
        }


        public event EventHandler SealResistanceChanged;
        private float _SealResistance = 0;
        /// <summary>
        /// SealResistance (GOhm)
        /// </summary>
        public virtual float SealResistance
        {
            get { return _SealResistance; }
            set {
                _SealResistance = value;
                OnSealResistanceChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnSealResistanceChanged(EventArgs e)
        {
            if (SealResistanceChanged != null && !SuppressUpdateNotification) SealResistanceChanged(this, e);
        }

        public event EventHandler PipetteResistanceChanged;
        private float _PipetteResistance = 0;
        /// <summary>
        /// Pipette Resistance (MOhm)
        /// </summary>
        public virtual float PipetteResistance
        {
            get { return _PipetteResistance; }
            set {
                _PipetteResistance = value;
                OnPipetteResistanceChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnPipetteResistanceChanged(EventArgs e)
        {
            if (PipetteResistanceChanged != null && !SuppressUpdateNotification) PipetteResistanceChanged(this, e);
        }


        public event EventHandler SeriesResistanceChanged;
        private float _SeriesResistance = 0;
        /// <summary>
        /// Series Resistance (MOhm)
        /// </summary>
        public virtual float SeriesResistance
        {
            get { return _SeriesResistance; }
            set {
                _SeriesResistance = value;
                OnSeriesResistanceChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnSeriesResistanceChanged(EventArgs e)
        {
            if (SeriesResistanceChanged != null && !SuppressUpdateNotification) SeriesResistanceChanged(this, e);
        }

        public event EventHandler MembraneResistanceChanged;
        private float _MembraneResistance = 0;
        /// <summary>
        /// The membrane resistance (GOhm)
        /// </summary>
        public virtual float MembraneResistance
        {
            get { return _MembraneResistance; }
            set {
                _MembraneResistance = value;
                OnMembraneResistanceChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnMembraneResistanceChanged(EventArgs e)
        {
            if (MembraneResistanceChanged != null && !SuppressUpdateNotification) MembraneResistanceChanged(this, e);
        }


        public event EventHandler CellCapacitanceChanged;
        private float _CellCapacitance = 0;
        /// <summary>
        /// The whole-cell capacitance (pF).
        /// </summary>
        public virtual float CellCapacitance
        {
            get { return _CellCapacitance; }
            set {
                _CellCapacitance = value;
                OnCellCapacitanceChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnCellCapacitanceChanged(EventArgs e)
        {
            if (CellCapacitanceChanged != null && !SuppressUpdateNotification) CellCapacitanceChanged(this, e);
        }

        public event EventHandler UserNameChanged;
        private string _UserName;

        public virtual string UserName
        {
            get { return _UserName; }
            set {
                _UserName = value;
                OnUserNameChanged(EventArgs.Empty);
            }
        }

        public event EventHandler RoughAppearanceRatingChanged;
        private ushort _RoughAppearanceRating = 0;

        public virtual ushort RoughAppearanceRating
        {
            get { return _RoughAppearanceRating; }
            set {
                _RoughAppearanceRating = value;
                OnRoughAppearanceRatingChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnRoughAppearanceRatingChanged(EventArgs e)
        {
            if (RoughAppearanceRatingChanged != null)
                try
                {
                    RoughAppearanceRatingChanged(this, e);
                }
                catch (Exception x) { ; }
        }

        public event EventHandler LengthAppearanceRatingChanged;
        private ushort _LengthAppearanceRating = 0;

        public virtual ushort LengthAppearanceRating
        {
            get { return _LengthAppearanceRating; }
            set
            {
                _LengthAppearanceRating = value;
                OnLengthAppearanceRatingChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnLengthAppearanceRatingChanged(EventArgs e)
        {
            if (LengthAppearanceRatingChanged != null)
                try
                {
                    LengthAppearanceRatingChanged(this, e);
                }
                catch (Exception x) { ; }
        }

        public event EventHandler ShapeAppearanceRatingChanged;
        private ushort _ShapeAppearanceRating = 0;

        public virtual ushort ShapeAppearanceRating
        {
            get { return _ShapeAppearanceRating; }
            set
            {
                _ShapeAppearanceRating = value;
                OnShapeAppearanceRatingChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnShapeAppearanceRatingChanged(EventArgs e)
        {
            if (ShapeAppearanceRatingChanged != null)
                try
                {
                    ShapeAppearanceRatingChanged(this, e);
                }
                catch (Exception x) { ; }
        }

        protected virtual void OnUserNameChanged(EventArgs e)
        {
            if (UserNameChanged != null)
                try
                {
                    UserNameChanged(this, e);
                }
                catch (Exception x) { ; }
        }


        public event EventHandler AnnotationsChanged;
        private List<Annotation> _Annotations = new List<Annotation>();
        public virtual ICollection<Annotation> Annotations
        {
            get { return _Annotations.AsReadOnly(); }
        }

        public event EventHandler RecordingsChanged;
		private List<Recording> _Recordings = new List<Recording>();
		/// <summary>
		/// The <c>Recording</c> recordings, with keys equal to the <c>DateTime</c> at which the
		/// recordings were made.
		/// </summary>
		public virtual ICollection<Recording> Recordings 
		{
			get 
			{
				return _Recordings.AsReadOnly();
			}
		}
        protected virtual void OnRecordingsChanged(EventArgs e)
        {
            if (RecordingsChanged != null && !SuppressUpdateNotification) RecordingsChanged(this, e);
        }

        public event EventHandler GenotypeChanged;
		private string _Genotype;
		/// <summary>
		/// The genotype of the cell.
		/// </summary>
		public virtual string Genotype 
		{
			get 
			{
				return _Genotype;
			}
			set 
			{
				_Genotype = value;
                OnGenotypeChanged(EventArgs.Empty);
			}
		}

        protected virtual void OnGenotypeChanged(EventArgs e)
        {
            if (GenotypeChanged != null && !SuppressUpdateNotification) GenotypeChanged(this, e);
        }

        public event EventHandler BreakInTimeChanged;

		private DateTime _BreakInTime = DateTime.MinValue;
		/// <summary>
		/// The time at which the cell was broken into, if whole cell patch clamp was performed. The
		/// default value is <c>DateTime.MinValue</c>.
		/// </summary>
		public virtual DateTime BreakInTime 
		{
			get 
			{
				return _BreakInTime;
			}
			set 
			{
				_BreakInTime = value;
                OnBreakInTimeChanged(EventArgs.Empty);
			}
		}

        protected virtual void OnBreakInTimeChanged(EventArgs e)
        {
            if (BreakInTimeChanged != null && !SuppressUpdateNotification) BreakInTimeChanged(this, e);
        }

        public event EventHandler MembranePotentialChanged;
        private float _MembranePotential;

        public virtual float MembranePotential
        {
            get { return _MembranePotential; }
            set {
                _MembranePotential = value;
                OnMembranePotentialChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnMembranePotentialChanged(EventArgs e)
        {
            if (MembranePotentialChanged != null && !SuppressUpdateNotification) MembranePotentialChanged(this, e);
        }


        public virtual void AddAnnotation(Annotation annotation)
        {
            _Annotations.Add(annotation);
            OnAnnotationsChanged(EventArgs.Empty);
        }
        public virtual void RemoveAnnotation(Annotation annotation)
        {
            _Annotations.Remove(annotation);
            OnAnnotationsChanged(EventArgs.Empty);
        }
        protected virtual void OnAnnotationsChanged(EventArgs e)
        {
            if (AnnotationsChanged != null) AnnotationsChanged(this, e);
        }
	}
}
