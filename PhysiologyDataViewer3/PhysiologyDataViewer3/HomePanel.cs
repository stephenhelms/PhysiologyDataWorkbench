using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RRLab.PhysiologyWorkbench.Data;

namespace RRLab.PhysiologyDataWorkshop
{
    public partial class HomePanel : UserControl, INotifyPropertyChanged
    {
        public enum WhoseData { Me, Everybody };
        public enum DatesToShow { Today, ThisWeek, ThisMonth, Anytime };

        public event EventHandler ProgramChanged;
        private PhysiologyDataWorkshopProgram _Program;
        [Bindable(true)]
        public PhysiologyDataWorkshopProgram Program
        {
            get { return _Program; }
            set
            {
                if (Program != null) Program.DataSetChanged -= new EventHandler(OnDataSetChanged);
                _Program = value;
                if (Program != null)
                {
                    ProgramBindingSource.DataSource = Program;
                    Program.DataSetChanged += new EventHandler(OnDataSetChanged);
                }
                else ProgramBindingSource.DataSource = typeof(PhysiologyDataWorkshopProgram);
                OnDataSetChanged(this, EventArgs.Empty);
                if (ProgramChanged != null) ProgramChanged(this, EventArgs.Empty);
                NotifyPropertyChanged("Program");
            }
        }

        public event EventHandler WhoseDataIsShownChanged;
        private WhoseData _WhoseDataIsShown = WhoseData.Me;
        [Bindable(true)]
        [SettingsBindable(true)]
        [DefaultValue(HomePanel.WhoseData.Me)]
        public WhoseData WhoseDataIsShown
        {
            get { return _WhoseDataIsShown; }
            set {
                _WhoseDataIsShown = value;
                OnWhoseDataIsShownChanged(EventArgs.Empty);
                NotifyPropertyChanged("WhoseDataIsShown");
            }
        }

        public event EventHandler WhichDatesToShowChanged;
        private DatesToShow _WhichDatesToShow = DatesToShow.Anytime;
        [Bindable(true)]
        [SettingsBindable(true)]
        [DefaultValue(HomePanel.DatesToShow.Anytime)]
        public DatesToShow WhichDatesToShow
        {
            get { return _WhichDatesToShow; }
            set {
                _WhichDatesToShow = value;
                OnWhichDatesToShowChanged(EventArgs.Empty);
                NotifyPropertyChanged("WhichDatesToShow");
            }
        }
	
	

        public HomePanel()
        {
            InitializeComponent();
        }

        protected virtual void OnDataSetChanged(object sender, EventArgs e)
        {
            if (Program != null && Program.DataSet != null)
            {
                CellsBindingSource.DataSource = Program.DataSet;
            }
            else
            {
                CellsBindingSource.DataSource = typeof(PhysiologyDataSet);
            }

            CheckIfControlShouldBeEnabled();
        }

        protected virtual void CheckIfControlShouldBeEnabled()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(CheckIfControlShouldBeEnabled));
                return;
            }

            if (Program == null || Program.DataSet == null ||
                !(CellsBindingSource.Current is DataRowView))
                Enabled = false;
            else Enabled = true;
        }

        private void OnCurrentCellChanged(object sender, EventArgs e)
        {
            if (CellsDataGridView.CurrentRow != null && Program != null)
                Program.CurrentCellID = (int)CellsDataGridView.CurrentRow.Cells[0].Value;
        }

        private void OnDatesToShowSelectionChanged(object sender, EventArgs e)
        {
            switch (DateRangeComboBox.Text)
            {
                case "Today":
                    WhichDatesToShow = DatesToShow.Today;
                    break;
                case "This Week":
                    WhichDatesToShow = DatesToShow.ThisWeek;
                    break;
                case "This Month":
                    WhichDatesToShow = DatesToShow.ThisMonth;
                    break;
                case "Anytime":
                default:
                    WhichDatesToShow = DatesToShow.Anytime;
                    break;
            }
        }

        private void OnWhoseDataSelectionChanged(object sender, EventArgs e)
        {
            switch (WhoseDataComboBox.Text)
            {
                case "Me":
                    WhoseDataIsShown = WhoseData.Me;
                    break;
                case "Everybody":
                    WhoseDataIsShown = WhoseData.Everybody;
                    break;
                default:
                    WhoseDataIsShown = WhoseData.Everybody;
                    break;
            }
        }

        protected virtual void OnWhoseDataIsShownChanged(EventArgs e)
        {
            UpdateDataFilter();

            if(WhoseDataIsShownChanged != null)
                try
                {
                    WhoseDataIsShownChanged(this, e);
                }
                catch (Exception x) { ; }
        }
        protected virtual void OnWhichDatesToShowChanged(EventArgs e)
        {
            UpdateDataFilter();

            if (WhichDatesToShowChanged != null)
                try
                {
                    WhichDatesToShowChanged(this, e);
                }
                catch (Exception x) { ; }
        }

        protected virtual void UpdateDataFilter()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(UpdateDataFilter));
                return;
            }

            string userFilter = null;
            if (WhoseDataIsShown == WhoseData.Me)
                userFilter = String.Format("UserID = {0}", Program.MyUserID);

            string dateFilter = null;
            switch (WhichDatesToShow)
            {
                case DatesToShow.Today:
                    dateFilter = String.Format("Created = '{0}/{1}/{2}'", DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
                    break;
                case DatesToShow.ThisWeek:
                    DateTime beginningOfWeek = DateTime.Today;
                    beginningOfWeek = beginningOfWeek.AddDays(1-(int)beginningOfWeek.DayOfWeek);
                    DateTime endOfWeek = DateTime.Today;
                    endOfWeek = endOfWeek.AddDays(7 - (int)endOfWeek.DayOfWeek);
                    dateFilter = String.Format("Created > '{0}/{1}/{2}' AND Created < '{3}/{4}/{5}'", beginningOfWeek.Year, beginningOfWeek.Month, beginningOfWeek.Day, endOfWeek.Year, endOfWeek.Month, endOfWeek.Day);
                    break;
                case DatesToShow.ThisMonth:
                    DateTime beginningOfMonth = DateTime.Today;
                    beginningOfMonth = beginningOfMonth.AddDays(1-beginningOfMonth.Day);
                    DateTime endOfMonth = beginningOfMonth.AddMonths(1).AddDays(-1);
                    dateFilter = String.Format("Created > '{0}/{1}/{2}' AND Created < '{3}/{4}/{5}'", beginningOfMonth.Year, beginningOfMonth.Month, beginningOfMonth.Day, endOfMonth.Year, endOfMonth.Month, endOfMonth.Day);
                    break;
                default:
                    break;
            }

            if (userFilter != null && dateFilter != null)
                CellsBindingSource.Filter = String.Format("({0}) AND ({1})", userFilter, dateFilter);
            else if (userFilter != null)
                CellsBindingSource.Filter = userFilter;
            else CellsBindingSource.Filter = dateFilter;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string property)
        {
            if(PropertyChanged != null)
                try
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
                }
                catch (Exception x) { ; }
        }

        #endregion
    }
}
