using System;
using System.Collections.Generic;
using System.Text;
using RRLab.PhysiologyWorkbench.Data;
using System.Windows.Forms;

namespace RRLab.PhysiologyDataWorkshop.Experiments
{
    public interface IExperiment
    {
        /// <summary>
        /// Occurs when the Name property changes.
        /// </summary>
        event EventHandler NameChanged;

        /// <summary>
        /// An identifying name for the experiment.
        /// </summary>
        string Name
        {
            get;
        }

        /// <summary>
        /// Occurs when the Program property changes.
        /// </summary>
        event EventHandler ProgramChanged;
        /// <summary>
        /// A reference to the program in order for the experiment to
        /// interact with the program.
        /// </summary>
        [System.ComponentModel.Bindable(true)]
        PhysiologyDataWorkshopProgram Program
        {
            get;
            set;
        }

        /// <summary>
        /// Occurs when the list of cell actions has changed.
        /// </summary>
        event EventHandler CellActionsChanged;
        /// <summary>
        /// A list of actions related to this experiment that the user can
        /// perform on cells being viewed. E.g., mark a cell for a calcium
        /// imaging experiment. This list will be used to generate a menu.
        /// </summary>
        IDictionary<string, Action<PhysiologyDataSet.CellsRow>> CellActions
        {
            get;
        }

        /// <summary>
        /// Occurs when the list of recording actions has changed.
        /// </summary>
        event EventHandler RecordingActionsChanged;
        /// <summary>
        /// A list of actions related to this experiment that the user can
        /// perform on recordings being viewed. E.g., mark a recording as a
        /// macroscopic bump.
        /// </summary>
        IDictionary<string, Action<PhysiologyDataSet.RecordingsRow>> RecordingActions
        {
            get;
        }

        /// <summary>
        /// Occurs when the PhysiologyDataSet property changes.
        /// </summary>
        event EventHandler PhysiologyDataSetChanged;
        /// <summary>
        /// A PhysiologyDataSet containing all the cells and recordings loaded.
        /// </summary>
        [System.ComponentModel.Bindable(true)]
        PhysiologyDataSet PhysiologyDataSet {
            get;
            set;
        }

        /// <summary>
        /// Determines whether an action is valid for the cell of interest
        /// </summary>
        /// <param name="actionName">The action to be performed</param>
        /// <param name="cell">The cell to perform the action on</param>
        /// <returns>True if the action is allowed</returns>
        bool IsCellActionEnabled(string actionName, PhysiologyDataSet.CellsRow cell);
        /// <summary>
        /// Determines whether an action is valid for the recording of interest
        /// </summary>
        /// <param name="actionName">The action to be performed</param>
        /// <param name="recording">The recording to perform the action on</param>
        /// <returns>True if the action is allowed</returns>
        bool IsRecordingActionEnabled(string actionName, PhysiologyDataSet.RecordingsRow recording);

        /// <summary>
        /// Returns a control for interacting with this experiment. This will typically
        /// be used as large panel taking up most of the window.
        /// </summary>
        /// <returns>The control</returns>
        Control GetExperimentPanelControl();
    }
}
