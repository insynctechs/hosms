using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using HospitalERP.Procedures;

namespace HospitalERP
{
    public partial class frmChangePassword : Form
    {
        log4net.ILog ilog;
        private bool errorfocus = false;
        Users user = new Users();
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void txtPassword1_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword1.Text.Trim() == "" && txtPassword2.Text.Trim() == "")
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;
        }

        private void txtPassword2_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword1.Text.Trim() == "" && txtPassword2.Text.Trim() == "")
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int rtn = 0;
            if (txtPassword2.Text != txtPassword1.Text)
            {
                MessageBox.Show("Please re-enter the same password you entered!");
                txtPassword2.Focus();
            }
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                rtn = user.SetPassword(LoggedUser.emp_id, txtPassword1.Text, LoggedUser.type_id);
                if (rtn == 0)
                    ShowStatus(0, "Error in changing password");
                else if (rtn == 1)
                {
                    ShowStatus(1, "Password succesfully updated");
                    txtPassword1.Text = "";
                    txtPassword2.Text = "";

                }
            }

        }

        private void ShowStatus(int success, string msg)
        {
            lblStatus.Visible = true;
            if (success == 1)
            {
                lblStatus.BackColor = Color.YellowGreen;
                lblStatus.ForeColor = Color.DarkGreen;
            }
            else
            {
                lblStatus.BackColor = Color.Salmon;
                lblStatus.ForeColor = Color.DarkRed;
            }
            lblStatus.Text = msg;
            var t = new Timer();
            t.Interval = 5000; // it will Tick in 3 seconds
            t.Tick += (s, e) =>
            {
                lblStatus.Hide();
                t.Stop();
            };
            t.Start();
        }

        private void txtPassword1_Validating(object sender, CancelEventArgs e)
        {
            if(Regex.IsMatch(txtPassword1.Text, @"[^\w\-\!\#\*\$\%\+]"))
            {
                e.Cancel = true;
                if (errorfocus == false)
                {
                    txtPassword1.Focus();
                    errorfocus = true;
                }
                errorProvider.SetError(txtPassword1, "Required with allowable characters alphabets, digits and symbols -!^+#*%");
            }
        }

        private void txtPassword2_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassword1.Text != txtPassword2.Text)
            {
                e.Cancel = true;
                if (errorfocus == false)
                {
                    txtPassword2.Focus();
                    errorfocus = true;
                }
                errorProvider.SetError(txtPassword2, "Required same as new password");
            }
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
            ilog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            txtPassword1.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
