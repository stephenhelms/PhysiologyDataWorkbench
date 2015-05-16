using System;
using NationalInstruments.DAQmx;

namespace RRLab.PhysiologyWorkbench.Devices
{
	/// <summary>
	/// The Shutter class provides methods for controlling a Newport shutter.
	/// </summary>
    [Serializable]
	public class Shutter : RRLab.PhysiologyWorkbench.Devices.Device
	{
		/// <summary>
		/// This event is fired when the shutter is opened or closed.
		/// </summary>
        [field: NonSerialized]
		public event EventHandler ShutterToggled;

        public Shutter()
        {
            Name = "Newport Shutter";
        }
		/// <summary>
		/// Creates a new Shutter with the given properties.
		/// </summary>
		/// <param genotype="OpenLine">The DAQmx address of the Open line.</param>
		/// <param genotype="CloseLine">The DAQmx address of the Close line.</param>
		public Shutter(string OpenLine, string CloseLine) : this(OpenLine,CloseLine,null) 
		{}
		/// <summary>
		/// Creates a new Shutter with the given properties.
		/// </summary>
		/// <param genotype="OpenLine">The DAQmx address of the Open line.</param>
		/// <param genotype="CloseLine">The DAQmx address of the Close line.</param>
		/// <param genotype="Name">An identifier for this shutter.</param>
		public Shutter(string OpenLine, string CloseLine, string Name)
		{
			this.OpenLine = OpenLine;
			this.CloseLine = CloseLine;
            if (Name == null) Name = "Shutter";
            this.Name = Name;
		}


		#region Methods
		/// <summary>
		/// Opens the shutter.
		/// </summary>
		public void OpenShutter() 
		{
			WriteDualSampleToLine("OpenShutter"+Name, OpenLine, "OpenLine", true, false);
			IsShutterClosed = false;
		}
		/// <summary>
		/// Closes the shutter.
		/// </summary>
		public void CloseShutter() 
		{
			WriteDualSampleToLine("CloseShutter"+Name, CloseLine, "CloseLine", true, false);
			IsShutterClosed = true;
		}
		/// <summary>
		/// Writes two samples to a digital line with software timing.
		/// </summary>
		/// <param genotype="taskName">The task to use.</param>
		/// <param genotype="line">The DAQmx address for the digital line to write to.</param>
		/// <param genotype="lineName">A genotype for the digital line.</param>
		/// <param genotype="sample1">The first sample to send.</param>
		/// <param genotype="sample2">The second sample to send.</param>
		protected void WriteDualSampleToLine(string taskName, string line, string lineName, bool sample1, bool sample2) 
		{
			Task task = null;
			try 
			{
				// Create task
				task = new Task(taskName);

				// Add OpenLine to the channels
				task.DOChannels.CreateChannel(line,lineName,ChannelLineGrouping.OneChannelForEachLine);
				// Use software timing
				task.Control(TaskAction.Verify); // Verify task

				// Generate the writer and write { true, false } to the line to open the shutter
				DigitalSingleChannelWriter writer = new DigitalSingleChannelWriter(task.Stream);
				writer.WriteSingleSampleSingleLine(true,sample1);
				writer.WriteSingleSampleSingleLine(true,sample2);
			} 
			catch(DaqException e) 
			{
				System.Windows.Forms.MessageBox.Show("Shutter Error: " + e.Message);
			}
			finally 
			{
				// Dispose of the task
				if(task!=null) task.Dispose();
			}
		}
		#endregion

		#region Properties
		private string _OpenLine, _CloseLine;
		/// <summary>
		/// The DAQmx address of the Open line.
		/// </summary>
        [System.ComponentModel.Category("Connection")]
		public string OpenLine 
		{
			get { return _OpenLine; }
			set { _OpenLine = value; }
		}
		/// <summary>
		/// The DAQmx address of the Close line.
		/// </summary>
        [System.ComponentModel.Category("Connection")]
		public string CloseLine 
		{
			get { return _CloseLine; }
			set { _CloseLine = value; }
		}

		private bool _IsShutterClosed = true;
		/// <summary>
		/// A boolean value that is true if the shutter is closed. Note that there is currently
		/// no sure-fire way to determine if the shutter is closed. This is determined based the history
		/// of the commands sent to this object (or set via this property) based on the assumption that
		/// the shutter is initially closed.
		/// </summary>
		[System.ComponentModel.Category("Settings")]
        public bool IsShutterClosed 
		{
			get { return _IsShutterClosed; }
			set 
			{
				_IsShutterClosed = value;
				ShutterToggled(this, EventArgs.Empty);
			}
		}
		#endregion
	}
}
