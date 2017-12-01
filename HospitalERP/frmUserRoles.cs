using System;
using System.Windows.Forms;
using System.Drawing;
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
            PopulateSearch();
            
        }
        private void PopulateSearch()
        {
            cmbSearch.DataSource = UR.SearchValues();
            cmbSearch.ValueMember = "Value";
            cmbSearch.DisplayMember = "Display";
        }

        private void ShowRecords()
        {
            dgvDept.DataSource = UR.GetRecords(cmbSearch.SelectedValue.ToString(), txtSearch.Text);
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                
                int rtn = -1;
                if (txtID.Text.Trim() == "") //add data
                {
                    rtn = UR.addTypes(txtName.Text, txtDesc.Text, chkActive.Checked);
                    if (rtn == 0)
                        ShowStatus(0, "Type name should be unique");
                    else if (rtn == 1)
                    {
                        ShowStatus(1, "Record succesfully added");
                        clearFormFields();

                    }
                    else if (rtn == -1)
                    {
                        ShowStatus(0, "Some error occurred... Record cannot be added.");
                    }
                }
                else //edit record
                {
                    rtn = UR.editTypes(Int32.Parse(txtID.Text.Trim()), txtName.Text, txtDesc.Text, chkActive.Checked);
                    if (rtn == 0)
                        ShowStatus(0, "This name already exists. Please provide unique name.");
                    else if (rtn == 1)
                    {
                        ShowStatus(1, "Record succesfully updated");
                        clearFormFields();

                    }
                    else if (rtn == -1)
                    {
                        ShowStatus(0,"Some error occurred... Record cannot be added.");
                    }
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

        private void dgvDept_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtID.Text = dgvDept.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = dgvDept.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDesc.Text = dgvDept.Rows[e.RowIndex].Cells[2].Value.ToString();
            chkActive.Checked = (bool)dgvDept.Rows[e.RowIndex].Cells[3].Value;

            tabSub.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowRecords();
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

        private void clearFormFields()
        {

            txtName.Text = "";
            txtDesc.Text = "";
            chkActive.Checked = false;
            txtID.Text = "";
            //PopulateProcTypeCombo(0);
        }

        private void tabSub_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabSub.SelectedIndex)
            {
                case 0:

                    break;
                case 1:
                    ShowRecords();
                    break;
            }
        }
    }
}
