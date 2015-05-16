using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RRLab.PhysiologyWorkbench.GUI
{
    public partial class SaveCellAttachedTestPulseData : SaveTestPulseDataButton
    {
        public SaveCellAttachedTestPulseData()
        {
            InitializeComponent();
        }

        protected override bool IsDataSaved
        {
            get
            {
                if (DataSet == null) return true;

                
                    return Cell != null && !Cell.IsSealResistanceNull() && Cell.SealResistance > 0;
                
            }
        }

        public override void SaveData()
        {
            if (Cell == null || Recording == null || TestPulseProtocol == null) return;

            lock (this)
            {
                lock (DataSet)
                {
                    Cell.BeginEdit();
                    Cell.SealResistance = (float)TestPulseProtocol.Resistance;
                    Cell.EndEdit();

                    Recording.BeginEdit();
                    Recording.Title = "Test Pulse (Cell Attached)";
                    Recording.Description = "Test pulse in cell attached configuration. Autosaved seal resistance.";
                    Recording.EndEdit();
                }
            }

            base.SaveData();
        }
    }
}

