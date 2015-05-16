using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RRLab.PhysiologyWorkbench.GUI
{
    public partial class SaveWholeCellTestPulseDataButton : SaveTestPulseDataButton
    {
        public SaveWholeCellTestPulseDataButton()
        {
            InitializeComponent();
        }

        protected override bool IsDataSaved
        {
            get
            {
                if (DataSet == null) return true;

                
                    return Cell != null && !Cell.IsMembranePotentialNull() && !Cell.IsMembraneResistanceNull() && Cell.MembraneResistance > 0
                        && !Cell.IsCellCapacitanceNull() && Cell.CellCapacitance > 0;
                
            }
        }

        public override void SaveData()
        {
            lock (this)
            {
                lock (DataSet)
                {
                    Cell.BeginEdit();
                    // Save membrane potential, membrane resistance, and cell capacitance
                    Cell.MembranePotential = Recording.HoldingPotential;
                    Cell.MembraneResistance = (float)(TestPulseProtocol.Resistance * 1E3);
                    Cell.BreakInTime = DateTime.Now;
                    Cell.EndEdit();

                    Recording.BeginEdit();
                    if (Recording.DoesEquipmentSettingExist("AmplifierCapacitanceCorrection"))
                        try
                        {
                            Cell.CellCapacitance = Single.Parse(Recording.GetEquipmentSetting("AmplifierCapacitanceCorrection"));
                        }
                        catch (Exception x) { ; }

                    Recording.Title = "Test Pulse (Whole Cell)";
                    Recording.Description =
                            "Test pulse in whole cell configuration. Autosaved membrane potential, resistance, and capacitance.";
                    Recording.EndEdit();
                }
            }

            base.SaveData();
        }
    }
}

