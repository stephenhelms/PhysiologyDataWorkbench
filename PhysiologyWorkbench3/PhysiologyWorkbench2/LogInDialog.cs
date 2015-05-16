using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RRLab.PhysiologyWorkbench.Data;

namespace RRLab.PhysiologyWorkbench
{
    public partial class LogInDialog : Form
    {
        public event EventHandler DatabaseServerAddressChanged;
        [SettingsBindable(true)]
        [Bindable(true)]
        [DefaultValue("localhost")]
        public string DatabaseServerAddress {
            get { return DatabaseServerTextBox.Text; }
            set {
                if (InvokeRequired)
                    Invoke(new Action<string>(delegate(string address)
                    {
                        DatabaseServerTextBox.Text = address;
                    }), value);
                else DatabaseServerTextBox.Text = value;
            }
        }

        public event EventHandler DatabaseUserChanged;
        [SettingsBindable(true)]
        [Bindable(true)]
        [DefaultValue("physiology_user")]
        public string DatabaseUser
        {
            get { return UsernameTextbox.Text; }
            set
            {
                if (InvokeRequired)
                    Invoke(new Action<string>(delegate(string user)
                        {
                            UsernameTextbox.Text = user;
                        }), value);
                else UsernameTextbox.Text = value;
            }
        }

        public event EventHandler DatabasePasswordChanged;
        [Bindable(true)]
        [SettingsBindable(true)]
        public string DatabasePassword
        {
            get { return PasswordTextBox.Text; }
            set
            {
                if (InvokeRequired)
                    Invoke(new Action<string>(delegate(string password)
                    {
                        PasswordTextBox.Text = password;
                    }), value);
                else PasswordTextBox.Text = value;
            }
        }

        public event EventHandler DataSourceChanged;
        [DefaultValue("MySql Database")]
        public string DataSource
        {
            get { return DataSourceComboBox.Text; }
            set
            {
                if (!DataSourceComboBox.Items.Contains(value))
                    throw new ArgumentException("Invalid DataSource.");

                if (InvokeRequired)
                    Invoke(new Action<string>(delegate(string dataSource)
                    {
                        DataSourceComboBox.SelectedValue = dataSource;
                    }), value);
                else DataSourceComboBox.SelectedValue = value;
            }
        }

        public event EventHandler ProgramChanged;

        private PhysiologyWorkbenchProgram _Program;

        public PhysiologyWorkbenchProgram Program
        {
            get { return _Program; }
            set {
                _Program = value;
                if(Program != null) ProgramBindingSource.DataSource = Program;
                else ProgramBindingSource.DataSource = typeof(PhysiologyWorkbenchProgram);
                if (ProgramChanged != null) ProgramChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler DatabaseChanged;
        [DefaultValue("physiology_data")]
        [Bindable(true)]
        [SettingsBindable(true)]
        public string Database
        {
            get
            {
                return DatabaseComboBox.Text;
            }
            set
            {
                if (InvokeRequired)
                    Invoke(new Action<string>(delegate(string text)
                    {
                        DatabaseComboBox.Text = text;
                    }), value);
                else
                    DatabaseComboBox.Text = value;

                if (DatabaseChanged != null) DatabaseChanged(this, EventArgs.Empty);
            }
        }
	
	
	

        public LogInDialog()
        {
            InitializeComponent();
        }
        public LogInDialog(PhysiologyWorkbenchProgram program) {
            InitializeComponent();
            Program = program;
        }

        private void DataSourceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(DataSourceComboBox_SelectedIndexChanged), sender, e);
                return;
            }

            if (DataSourceComboBox.Text == "MySql Database")
            {
                DatabaseServerTextBox.Enabled = true;
                UsernameTextbox.Enabled = true;
                PasswordTextBox.Enabled = true;
                DatabaseComboBox.Enabled = true;
            }
            else
            {
                DatabaseServerTextBox.Enabled = false;
                UsernameTextbox.Enabled = false;
                PasswordTextBox.Enabled = false;
                DatabaseComboBox.Enabled = false;
            }
        }

        protected virtual void OnOkClicked(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnOkClicked), sender, e);
                return;
            }
            //if (Data.Users.Select("Name = '" + User + "'").Length == 0)
            //{
            //    PhysiologyData.UsersRow row = Data.Users.NewUsersRow();
            //    row.Name = User;
            //    Data.Users.AddUsersRow(row);
            //}
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void OnDataSourceChanged(object sender, EventArgs e)
        {
            if (DataSourceChanged != null) DataSourceChanged(this, e);
        }

        private void OnCancelClicked(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}