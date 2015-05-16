using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RRLab.PhysiologyWorkbench.Data;

namespace RRLab.PhysiologyData.GUI
{
    public partial class CellAndRecordingInfoPanel : UserControl
    {
        public event EventHandler DataSetChanged;
        private PhysiologyDataSet _DataSet;
        [Bindable(true)]
        public PhysiologyDataSet DataSet
        {
            get { return _DataSet; }
            set {
                _DataSet = value;
                OnDataSetChanged(EventArgs.Empty);
            }
        }

        public event EventHandler CurrentCellIDChanged;
        private int _CurrentCellID = 1;
        [Bindable(true)]
        public int CurrentCellID
        {
            get { return _CurrentCellID; }
            set {
                _CurrentCellID = value;
                if (CellsBindingSource.DataSource != null)
                    CellsBindingSource.Position = CellsBindingSource.Find("CellID", CurrentCellID);
                Validate();
                if (CurrentCellIDChanged != null) CurrentCellIDChanged(this, EventArgs.Empty);
            }
        }
	

        public event EventHandler CurrentRecordingIDChanged;
        private long _CurrentRecordingID;
        [Bindable(true)]
        public long CurrentRecordingID
        {
            get { return _CurrentRecordingID; }
            set {
                _CurrentRecordingID = value;
                if (RecordingsBindingSource.DataSource != null && RecordingsBindingSource.Count != 0)
                    try
                    {
                        RecordingsBindingSource.Position = RecordingsBindingSource.Find("RecordingID", CurrentRecordingID);
                        RecordingsBindingSource.ResetBindings(false);
                        RecordingsBindingSource.ResetCurrentItem();
                        Validate();
                    }
                    catch (Exception e) { ; }
                if (CurrentRecordingIDChanged != null) CurrentRecordingIDChanged(this, EventArgs.Empty);
            }
        }
	


        protected virtual void OnDataSetChanged(EventArgs e)
        {
            if (DataSet != null)
            {
                CellsBindingSource.DataSource = DataSet;
                UsersBindingSource.DataSource = DataSet;
                GenotypesBindingSource.DataSource = DataSet;
            }
            else
            {
                CellsBindingSource.DataSource = typeof(PhysiologyDataSet);
                UsersBindingSource.DataSource = typeof(PhysiologyDataSet);
                GenotypesBindingSource.DataSource = typeof(PhysiologyDataSet);
            }

            if (DataSetChanged != null) DataSetChanged(this, EventArgs.Empty);
        }
	

        public CellAndRecordingInfoPanel()
        {
            InitializeComponent();
        }
    }
}
