using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Data.SqlClient;
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
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\HospitalERP\dset\",true);

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
                        key.SetValue("catlog", "HospitalERP_db");
                        key.SetValue("usrkey", txtUserName.Text.Trim());
                        key.SetValue("usrval", txtPassword.Text.Trim());
                        key.Close();

                        //opening the subkey  
                        RegistryKey key1 = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\HospitalERP",true);
                        key1.SetValue("first_run", false);
                        key1.Close();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Connection cannot be established.");
                    }
                    
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmDbConfig_Load(object sender, EventArgs e)
        {
           // var settings = ConfigurationManager.ConnectionStrings["HospitalERP.Properties.Settings.connstr"];
           // MessageBox.Show(settings.ConnectionString.ToString());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
