using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RRLab.PhysiologyDataConnectivity
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

        public string ConnectionString
        {
            get
            {
                return String.Format("server={0};user={1};pwd={2};database={3}",
                    DatabaseServerAddress, DatabaseUser, DatabasePassword, Database);
            }
        }
	

        public LogInDialog()
        {
            InitializeComponent();
            StoredLocationsComboBox.SelectedIndex = 0;
        }

        private void DataSourceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(DataSourceComboBox_SelectedIndexChanged), sender, e);
                return;
            }

            switch (StoredLocationsComboBox.SelectedIndex)
            {
                case 0:
                    DatabaseServerAddress = "IMG_PHYS";
                    break;
                case 1:
                    DatabaseServerAddress = "129.112.108.86";
                    break;
                case 2:
                    DatabaseServerAddress = "localhost";
                    break;
                default:
                    DatabaseServerAddress = "IMG_PHYS";
                    break;
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
            //    PhysiologyDataSet.UsersRow row = Data.Users.NewUsersRow();
            //    row.Name = User;
            //    Data.Users.AddUsersRow(row);
            //}
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void OnCancelClicked(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}