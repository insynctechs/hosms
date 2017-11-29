using System;
using System.Windows.Forms;
using HospitalERP.Procedures;

namespace HospitalERP
{
    public partial class frmUserRoles : Form
    {
        UserRoles UR = new UserRoles();
        public frmUserRoles()
        {
            InitializeComponent();
        }

        private void frmUserRoles_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                int t = UR.addTypes(txtName.Text, txtDesc.Text, chkActive.Checked);
                if (t == -1)
                    lblStatus.Text = "Some error occurred... Record cannot be added.";
                else if (t == 0)
                    lblStatus.Text = "Type name should be unique";
                else if (t == 1)
                {
                    lblStatus.Text = "Record succesfully added";
                    txtName.Text = "";
                    txtDesc.Text = "";
                    chkActive.Checked = false;
                }
            }
        }

        
        private void txtName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtName.Text))
            {
                e.Cancel = true;
                txtName.Focus();
                errorProvider.SetError(txtName, "Required");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtName, null);
            }
        }
    }
}
