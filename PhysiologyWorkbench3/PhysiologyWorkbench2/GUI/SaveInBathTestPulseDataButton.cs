using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RRLab.PhysiologyWorkbench.GUI
{
    public partial class SaveInBathTestPulseDataButton : SaveTestPulseDataButton
    {
        public SaveInBathTestPulseDataButton()
        {
            InitializeComponent();
        }

        protected override bool IsDataSaved
        {
            get
            {
                if (DataSet == null) return true;

                
                    return Cell != null && !Cell.IsPipetteResistanceNull() && Cell.PipetteResistance > 0;
                
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
                    // Save and convert from GOhm to MOhm
                    Cell.PipetteResistance = (float)(TestPulseProtocol.Resistance * 1E3);
                    Cell.EndEdit();

                    Recording.BeginEdit();
                    Recording.Title = "Test Pulse (Bath)";
                    Recording.Description = "Test pulse in bath configuration. Autosaved pipette resistance.";
                    Recording.EndEdit();
                }
            }

            base.SaveData();
        }
    }
}

