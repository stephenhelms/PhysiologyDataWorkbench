using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RRLab.PhysiologyWorkbench;

namespace RRLab.PhysiologyWorkbench.GUI
{
    public partial class HotkeyManagerDialog : Form, IHotkeyManagerUser
    {
        private HotkeyManager _HotkeyManager;

        public HotkeyManager HotkeyManager
        {
            get { return _HotkeyManager; }
            set {
                if (HotkeyManager != null) HotkeyManager.ActionsChanged -= new EventHandler(OnHotkeyDataChanged);
                if (HotkeyManager != null) HotkeyManager.HotkeyMappingsChanged -= new EventHandler(OnHotkeyDataChanged);
                _HotkeyManager = value;
                if (HotkeyManager != null) HotkeyManager.ActionsChanged += new EventHandler(OnHotkeyDataChanged);
                if (HotkeyManager != null) HotkeyManager.HotkeyMappingsChanged += new EventHandler(OnHotkeyDataChanged);
                LoadHotkeyMappings();
            }
        }

        protected Keys SelectedHotkey;

        public HotkeyManagerDialog()
        {
            InitializeComponent();
        }

        protected virtual void OnHotkeyDataChanged(object sender, EventArgs e)
        {
            LoadHotkeyMappings();
        }
        protected virtual void LoadHotkeyMappings()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(LoadHotkeyMappings));
                return;
            }
            MappingsListBox.Items.Clear();
            foreach (KeyValuePair<Keys, string> kv in HotkeyManager.HotkeyMappings)
                MappingsListBox.Items.Add(kv);

            ActionsComboBox.Items.Clear();
            foreach (string action in HotkeyManager.Actions.Keys)
                ActionsComboBox.Items.Add(action);
        }

        protected virtual void OnHotkeyEntered(object sender, KeyEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new KeyEventHandler(OnHotkeyEntered), sender, e);
                return;
            }
            SelectedHotkey = e.KeyCode | e.Modifiers;
            HotkeyTextBox.Text = SelectedHotkey.ToString();
        }

        private void OnSaveClicked(object sender, EventArgs e)
        {
            HotkeyManager.SaveHotkeys();
        }

        private void OnAddClicked(object sender, EventArgs e)
        {
            if (SelectedHotkey == Keys.None || ActionsComboBox.SelectedItem == null) return;
            HotkeyManager.SetHotkey(SelectedHotkey, ActionsComboBox.SelectedItem.ToString());
        }

        private void OnRemoveClicked(object sender, EventArgs e)
        {
            if (MappingsListBox.SelectedItem == null) return;
            HotkeyManager.RemoveHotkey(
                ((KeyValuePair<Keys,string>)MappingsListBox.SelectedItem).Key);
        }

        private void OnSelectedHotkeyMappingChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnSelectedHotkeyMappingChanged), sender, e);
                return;
            }
            if (MappingsListBox.SelectedItem == null)
            {
                ActionsComboBox.SelectedItem = null;
                SelectedHotkey = Keys.None;
                HotkeyTextBox.Text = "Press the desired hotkey.";
            }
            else
            {
                KeyValuePair<Keys,string> mapping = (KeyValuePair<Keys,string>) MappingsListBox.SelectedItem;
                if (ActionsComboBox.Items.Contains(mapping.Value))
                    ActionsComboBox.SelectedItem = mapping.Value;
                else
                {
                    ActionsComboBox.Items.Add(mapping.Value);
                    ActionsComboBox.SelectedItem = mapping.Value;
                }
                SelectedHotkey = mapping.Key;
                HotkeyTextBox.Text = SelectedHotkey.ToString();
            }
        }
    }
}