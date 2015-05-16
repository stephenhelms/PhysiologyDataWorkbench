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
    public partial class RecordingSubTablesViewer : UserControl, INotifyPropertyChanged
    {
        public event EventHandler DataSetChanged;
        private PhysiologyDataSet _DataSet;
        [Bindable(true)]
        public PhysiologyDataSet DataSet
        {
            get { return _DataSet; }
            set {
                _DataSet = value;

                if (DataSet != null)
                {
                    RecordingBindingSource.DataSource = DataSet;
                }
                else RecordingBindingSource.DataSource = typeof(PhysiologyDataSet);

                if (DataSetChanged != null) DataSetChanged(this, EventArgs.Empty);
                NotifyPropertyChanged("DataSet");
            }
        }

        public event EventHandler CurrentRecordingIDChanged;

        private long _CurrentRecordingID = 1;
        [Bindable(true)]
        public long CurrentRecordingID
        {
            get { return _CurrentRecordingID; }
            set
            {
                _CurrentRecordingID = value;
                OnCurrentRecordingIDChanged(EventArgs.Empty);
                NotifyPropertyChanged("CurrentRecordingID");
            }
        }

        protected virtual void OnCurrentRecordingIDChanged(EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<EventArgs>(OnCurrentRecordingIDChanged), e);
                return;
            }

            if (RecordingBindingSource.DataSource != null)
            {
                try
                {
                    RecordingBindingSource.CurrencyManager.Position = RecordingBindingSource.Find("RecordingID", CurrentRecordingID);
                    RecordingBindingSource.ResetBindings(true);
                    RecordingBindingSource.ResetCurrentItem();

                    MetaDataBindingSource.ResetBindings(true);
                    MetaDataBindingSource.ResetCurrentItem();

                    ProtocolSettingsBindingSource.ResetBindings(true);
                    ProtocolSettingsBindingSource.ResetCurrentItem();

                    EquipmentSettingsBindingSource.ResetBindings(true);
                    EquipmentSettingsBindingSource.ResetCurrentItem();

                    Invalidate(true);
                }
                catch (Exception x)
                {
                    if (CurrentRecordingID != 0) MessageBox.Show("Error while selecting recording: " + x.Message);
                }
            }

            if (RecordingBindingSource.Current == null) Enabled = false;
            else Enabled = true;

            if (CurrentRecordingIDChanged != null)
                try
                {
                    CurrentRecordingIDChanged(this, e);
                }
                catch (Exception x) { ; }
        }

        public RecordingSubTablesViewer()
        {
            InitializeComponent();
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string property)
        {
            if(PropertyChanged != null)
                try {
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
                } catch(Exception e) { ; }
        }

        #endregion
    }
}
