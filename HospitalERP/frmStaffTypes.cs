using System;
using System.Windows.Forms;
using HospitalERP.Procedures;

namespace HospitalERP
{
    public partial class frmStaffTypes : Form
    {
        StaffTypes st = new StaffTypes();
        
        public frmStaffTypes()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmStaffTypes_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int t = st.addStaffs(txtName.Text,txtDesc.Text,chkActive.Checked);
            if (t == -1)
                lblStatus.Text="Some error occurred... Record cannot be added.";
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
}
