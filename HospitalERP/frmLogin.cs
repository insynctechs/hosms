﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HospitalERP.Procedures;
using Microsoft.Win32;

namespace HospitalERP
{
    public partial class frmLogin : Form
    {
        Users usr = new Users();
        public frmLogin()
        {
            InitializeComponent();
            MessageBox.Show("checking registry value");
            //opening the subkey  
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\HospitalERP");

            //if it does exist, retrieve the stored values  
            if (key != null)
            {
                var frun = key.GetValue("first_run");
                
                key.Close();

                if (frun.ToString() == "true")
                {
                    //show frmDbConfig
                    frmDbConfig fdc = new frmDbConfig();
                    fdc.ShowDialog();

                    //after closing server check tem has changed. 
                    //If not don't show the login form
                    key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\HospitalERP\dset\", true);

                    //if it does exist, retrieve the stored values  
                    if (key != null)
                    {
                        frun = key.GetValue("reset");
                        if (frun.ToString() == "false")
                        {
                            Environment.Exit(1);
                            //Application.Exit();
                        }
                            
                    }
                }

                MessageBox.Show("Registry fn finished");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            submitLogin();
        }

        private void submitLogin()
        {
            int err = 0;
            lblStatus.Visible = false;
            string msg = "";
            if (txtEmpId.Text.Trim() == "")
            {
                err = 1;
                msg = "Please enter Employee ID";
                txtEmpId.Focus();
            }
            if (txtPwd.Text.Trim() == "")
            {
                err = 1;
                if (msg == "")
                {
                    msg = "Please enter Password";
                    txtPwd.Focus();
                }
                else
                    msg += " and Password";

            }
            if (err == 0)
            {
                int ret = usr.ValidateLogin(txtEmpId.Text, txtPwd.Text);
                if (ret != 1)
                {
                    txtEmpId.Focus();
                    err = 1;
                    if (ret == -1)
                        msg = "Invalid Password";
                    else
                        msg = "Invalid User";
                }


            }
            if (err == 1)
            {
                lblStatus.Visible = true;
                lblStatus.Text = msg + "!";
            }
            else
            {                
                frmMain main = new frmMain(txtEmpId.Text);
                main.Show();
                this.Close();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtEmpId.Focus();
        }

        

        private void txtEmpId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                submitLogin();
            }
        }

        private void txtPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
               submitLogin();
            }
        }
    }
}
