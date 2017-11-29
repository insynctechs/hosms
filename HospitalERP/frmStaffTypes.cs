﻿using System;
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
