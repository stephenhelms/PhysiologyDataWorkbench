using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.DAQmx;

namespace RRLab.PhysiologyWorkbench.Daq
{
    public partial class OscilloscopeConfigurationControl : UserControl
    {
        public event EventHandler ProtocolChanged;

        private OscilloscopeProtocol _Protocol;

        public OscilloscopeProtocol Protocol
        {
            get { return _Protocol; }
            set
            {
                _Protocol = value;
                OnProtocolChanged(EventArgs.Empty);
            }
        }

        private void OnProtocolChanged(EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<EventArgs>(OnProtocolChanged), e);
                return;
            }

            if (Protocol == null)
            {
                ProtocolBindingSource.DataSource = typeof(OscilloscopeProtocol);
                OnChannelsToRecordChanged(this, EventArgs.Empty);
                Enabled = false;
            }
            else
            {
                ProtocolBindingSource.DataSource = Protocol;
                Protocol.ChannelsToRecordChanged += new EventHandler(OnChannelsToRecordChanged);
                Enabled = true;
            }

            if (ProtocolChanged != null) ProtocolChanged(this, e);
        }
	

        public OscilloscopeConfigurationControl() : this(null)
        {
        }
        public OscilloscopeConfigurationControl(OscilloscopeProtocol protocol)
        {
            InitializeComponent();
            Protocol = protocol;

            try
            {
                PhysicalChannelComboBox.Items.AddRange(
                    DaqSystem.Local.GetPhysicalChannels(
                        PhysicalChannelTypes.AI, PhysicalChannelAccess.External)
                    );
                if (PhysicalChannelComboBox.Items.Count > 0)
                    PhysicalChannelComboBox.SelectedIndex = 0;
            }
            catch (NationalInstruments.DAQmx.DaqException x)
            {
                PhysicalChannelComboBox.Items.Clear();
            }
        }

        protected virtual void OnAddChannelClicked(object sender, EventArgs e)
        {
            if (Protocol == null) return;
            Protocol.AddChannel("New channel", "");
            ChannelsListBox.SelectedIndex = ChannelsListBox.Items.Count - 1;
        }

        protected virtual void OnRemoveChannelClicked(object sender, EventArgs e)
        {
            if (Protocol == null) return;
            if (ChannelsListBox.SelectedItem == null) return;
            string channel = ChannelsListBox.SelectedItem as string;
            Protocol.RemoveChannel(channel);
        }

        protected virtual void OnChannelsToRecordChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnChannelsToRecordChanged), sender, e);
                return;
            }

            if (Protocol == null)
            {
                ChannelsListBox.Items.Clear();
                return;
            }

            ChannelsListBox.Items.Clear();
            foreach (string channelName in Protocol.ChannelsToRecord.Keys)
                ChannelsListBox.Items.Add(channelName);
        }

        protected virtual void OnSelectedChannelChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnSelectedChannelChanged), sender, e);
                return;
            }

            if (ChannelsListBox.SelectedIndex < 0)
            {
                ChannelNameTextBox.Text = "";
                ChannelNameTextBox.Enabled = false;
                PhysicalChannelComboBox.SelectedItem = null;
                PhysicalChannelComboBox.Enabled = false;
            }
            else
            {
                SortedList<string, string> list = new SortedList<string, string>(Protocol.ChannelsToRecord);

                ChannelNameTextBox.Text = list.Keys[ChannelsListBox.SelectedIndex];
                ChannelNameTextBox.Enabled = true;
                PhysicalChannelComboBox.SelectedItem = list.Values[ChannelsListBox.SelectedIndex];
                PhysicalChannelComboBox.Enabled = true;
            }
        }

        protected virtual void OnUpdateClicked(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnUpdateClicked), sender, e);
                return;
            }

            if (Protocol == null) return;

            string channelName = ChannelNameTextBox.Text;
            string address = PhysicalChannelComboBox.SelectedItem as string;

            Protocol.RemoveChannel(ChannelsListBox.SelectedItem as string);
            Protocol.AddChannel(channelName, address);
        }
    }
}
