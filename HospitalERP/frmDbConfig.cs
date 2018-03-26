using System;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.Win32;

namespace HospitalERP
{
    public partial class frmDbConfig : Form
    {
        public frmDbConfig()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {

                try
                {

                    //string strConn = "Data Source=" + txtServer.Text.Trim() + ";Initial Catalog=" + txtDatabase.Text.Trim() + ";Persist Security Info=True;User ID=" + txtUserName.Text.Trim() + ";Password=" + txtPassword.Text.Trim();

                    /*
                    //update config with new connection string
                    var settings = ConfigurationManager.ConnectionStrings["HospitalERP.Properties.Settings.connstr"];
                    var fi = typeof(ConfigurationElement).GetField("_bReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
                    fi.SetValue(settings, false);                
                    settings.ConnectionString = strConn;
                    ConfigurationManager.RefreshSection("ConnectionString");
                    //MessageBox.Show(settings.ConnectionString.ToString());
                    */

                    //Update  registry with new connection string
                    //opening the subkey  
                    RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\HospitalERP\dset\", true);

                    //if it does exist, retrieve the stored values  
                    if (key != null)
                    {
                        //first chk the connection string is valid
                        //if yes insert the values to registry
                        //else give error msg
                        try
                        {
                            //var conn = new SqlConnection(strConn);
                            key.SetValue("srvr", txtServer.Text.Trim());
                            key.SetValue("catlog", "hospitalERP_db");
                            key.SetValue("usrkey", txtUserName.Text.Trim());
                            key.SetValue("usrval", txtPassword.Text.Trim());
                            key.SetValue("reset", "true");
                            key.Close();

                            //opening the subkey  
                            RegistryKey key1 = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\HospitalERP", true);
                            key1.SetValue("first_run", false);
                            key1.Close();
                            this.Close();
                           // MessageBox.Show("Finished dbconfig");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Connection cannot be established.");
                        }

                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void frmDbConfig_Load(object sender, EventArgs e)
        {
           // var settings = ConfigurationManager.ConnectionStrings["HospitalERP.Properties.Settings.connstr"];
           // MessageBox.Show(settings.ConnectionString.ToString());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you Sure?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
            
        }

        private void txtServer_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtServer.Text.Trim()))
            {
                e.Cancel = true;
                txtServer.Focus();
                errorProvider.SetError(txtServer, "Required");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtServer, null);
            }
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                txtUserName.Focus();
                errorProvider.SetError(txtUserName, "Required");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtUserName, null);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                txtPassword.Focus();
                errorProvider.SetError(txtPassword, "Required");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtPassword, null);
            }
        }
    }
}
