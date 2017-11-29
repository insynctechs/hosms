﻿using System;
using System.Windows.Forms;
using HospitalERP.Procedures;
namespace HospitalERP
{
    public partial class frmProcTypes : Form
    {
        ProcTypes pt = new ProcTypes();
        log4net.ILog log = HospitalERP.Helpers.DBHelper.GetLogObject();
        public frmProcTypes()
        {
            InitializeComponent();
            
        }

        private void frmProcTypes_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            PopulateSearch();
            ShowRecords();
        }

        private void PopulateSearch()
        {
            cmbSearch.DataSource = pt.SearchValues();
            cmbSearch.ValueMember = "Value";
            cmbSearch.DisplayMember = "Display";
        }

        private void ShowRecords()
        {
            dgvDept.DataSource = pt.GetRecords(cmbSearch.SelectedValue.ToString(), txtSearch.Text);
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                int t = pt.InsertProc(txtName.Text, txtDesc.Text, chkActive.Checked);
                if (t > 0)
                    lblStatus.Text = "Record added succesfully";
                /*
                int t = pt.addTypes(txtName.Text, txtDesc.Text, chkActive.Checked);
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
                */
            }
        }

        private void txtName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtName.Text))
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
    }
}
