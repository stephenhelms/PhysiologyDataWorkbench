using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RRLab.PhysiologyWorkbench.Data;

namespace RRLab.PhysiologyWorkbench.GUI
{
    public partial class BreakInTimerControl : UserControl
    {
        private DataManager _DataManager;
        public DataManager DataManager
        {
            get
            {
                return _DataManager;
            }
            set
            {
                if (DataManager != null)
                {
                    DataManager.CurrentCellChanged -= new EventHandler(OnCellChanged);
                }
                _DataManager = value;
                if (DataManager != null)
                {
                    DataManager.CurrentCellChanged += new EventHandler(OnCellChanged);
                }
            }
        }

        private TimeSpan _WarningTime = new TimeSpan(0, 10, 0);
        public TimeSpan WarningTime
        {
            get { return _WarningTime; }
            set { _WarningTime = value; }
        }

        private Color _WarningColor = Color.Maroon;
        public Color WarningColor
        {
            get { return _WarningColor; }
            set { _WarningColor = value; }
        }

        public BreakInTimerControl()
        {
            InitializeComponent();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if ((DataManager == null) || (DataManager.CurrentCell == null)) return;

            if (InvokeRequired)
            {
                Invoke(new EventHandler(Timer_Tick), sender, e);
                return;
            }

            if (!DataManager.CurrentCell.IsBreakInTimeNull() && DataManager.CurrentCell.BreakInTime != DateTime.MinValue)
            {
                try
                {
                    TimeSpan breakInLength = DateTime.Now - DataManager.CurrentCell.BreakInTime;
                    BreakInLabel.Text = breakInLength.Minutes + ":" + breakInLength.Seconds;
                    // Check if the break-in length surpasses the warning time and apply formatting
                    if (breakInLength >= WarningTime)
                    {
                        BreakInLabel.ForeColor = WarningColor;
                    }
                    else
                    {
                        BreakInLabel.ForeColor = Color.Black;
                    }
                }
                catch (Exception x) { BreakInLabel.Text = "Error"; }
            }
            else
            {
                BreakInLabel.Text = "Not Broke In";
            }
        }

        protected virtual void OnCellChanged(object sender, EventArgs e)
        {
            if (DataManager == null) return;

            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnCellChanged), sender, e);
                return;
            }
            if (DataManager.CurrentCell == null) Enabled = false;
            else Enabled = true;
        }
    }
}
