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
            PopulateSearch();
            ShowRecords();
        }

        private void PopulateSearch()
        {
            cmbSearch.DataSource = st.SearchValues();
            cmbSearch.ValueMember = "Value";
            cmbSearch.DisplayMember = "Display";
        }

        private void ShowRecords()
        {
            dgvDept.DataSource = st.GetRecords(cmbSearch.SelectedValue.ToString(), txtSearch.Text);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            int rtn = -1;
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                if (txtID.Text.Trim() == "") //add data
                {
                    rtn = st.addStaffs(txtName.Text, txtDesc.Text, chkActive.Checked);
                    if (rtn == 0)
                        lblStatus.Text = "Type name should be unique";
                    else if (rtn == 1)
                    {
                        lblStatus.Text = "Record succesfully added";
                        txtName.Text = "";
                        txtDesc.Text = "";
                        chkActive.Checked = false;

                    }
                    else if (rtn == -1)
                    {
                        lblStatus.Text = "Some error occurred... Record cannot be added.";
                    }
                }
                else //edit record
                {
                    rtn = st.editTypes(Int32.Parse(txtID.Text.Trim()), txtName.Text, txtDesc.Text, chkActive.Checked);
                    if (rtn == 0)
                        lblStatus.Text = "This name already exists. Please provide unique name.";
                    else if (rtn == 1)
                    {
                        lblStatus.Text = "Record succesfully updated";
                        txtName.Text = "";
                        txtDesc.Text = "";
                        txtID.Text = "";
                        chkActive.Checked = false;

                    }
                    else if (rtn == -1)
                    {
                        lblStatus.Text = "Some error occurred... Record cannot be added.";
                    }
                }
                ShowRecords();
            }
        }

        private void dgvDept_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            txtID.Text = dgvDept.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = dgvDept.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDesc.Text = dgvDept.Rows[e.RowIndex].Cells[2].Value.ToString();
            chkActive.Checked = (bool)dgvDept.Rows[e.RowIndex].Cells[3].Value;

            tabSub.SelectedIndex = 0;
        }

        
    }
}
