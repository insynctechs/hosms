using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HospitalERP.Procedures;
namespace HospitalERP
{
    
    public partial class frmDepartments : Form
    {
        //log4net.ILog log;
        Departments dt = new Departments();
        public frmDepartments()
        {
            InitializeComponent();
        }

        private void frmDepartments_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            PopulateSearch();
            ShowDepartments();
        }
        private void PopulateSearch()
        {
            cmbSearch.DataSource = dt.SearchValues();
            cmbSearch.ValueMember = "Value";
            cmbSearch.DisplayMember = "Display";
        }

        private void ShowDepartments()
        {
            dgvDept.DataSource = dt.GetDepartments(cmbSearch.SelectedValue.ToString(), txtSearch.Text);
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int rtn = -1;
            if (txtID.Text.Trim() == "") //add data
            {
                rtn = dt.addTypes(txtName.Text, txtDesc.Text, chkActive.Checked);
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
                rtn = dt.editTypes(Int32.Parse(txtID.Text.Trim()),txtName.Text, txtDesc.Text, chkActive.Checked);
                if (rtn == 0)
                    lblStatus.Text = "This name already exists. Please provide unique name.";
                else if (rtn == 1)
                {
                    lblStatus.Text = "Record succesfully updated";
                    txtName.Text = "";
                    txtDesc.Text = "";
                    chkActive.Checked = false;

                }
                else if (rtn == -1)
                {
                    lblStatus.Text = "Some error occurred... Record cannot be added.";
                }
            }
        }
        private void tabSub_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabSub.SelectedIndex)
            {
                case 0:
                    ShowDepartments();
                    break;
                case 1:
                    break;
            }
        }

       
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowDepartments();
        }

        private void dgvDept_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtID.Text = dgvDept.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = dgvDept.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDesc.Text = dgvDept.Rows[e.RowIndex].Cells[2].Value.ToString();
            //chkActive.Checked = Int32.Parse(dgvDept.Rows[e.RowIndex].Cells[2].Value.ToString());

            tabSub.SelectedIndex = 0;
        }
    }
}
