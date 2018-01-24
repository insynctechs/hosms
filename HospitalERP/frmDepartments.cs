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
        log4net.ILog ilog;
        Departments dt = new Departments();
        public frmDepartments()
        {
            InitializeComponent();
            //this.WindowState = FormWindowState.Maximized;



        }

        private void frmDepartments_Load(object sender, EventArgs e)
        {
            
            this.WindowState = FormWindowState.Maximized;            
            PopulateSearch();
            log4net.Config.XmlConfigurator.Configure();
            ilog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;

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
            if (txtID.Text.Trim() == "") //add data
            {
                rtn = dt.addTypes(txtName.Text, txtDesc.Text, chkActive.Checked);
                if (rtn == 0)
                    ShowStatus(0,"Type name should be unique");
                else if (rtn == 1)
                {
                    ShowStatus(1,"Record succesfully added");
                    clearFormFields();

                }
                else if (rtn == -1)
                {
                    ShowStatus(0,"Some error occurred... Record cannot be added.");
                }
            }
            else //edit record
            {
                rtn = dt.editTypes(Int32.Parse(txtID.Text.Trim()),txtName.Text, txtDesc.Text, chkActive.Checked);
                if (rtn == 0)
                    ShowStatus(0,"This name already exists. Please provide unique name.");
                else if (rtn == 1)
                {
                    ShowStatus(1,"Record succesfully updated");
                    clearFormFields();

                }
                else if (rtn == -1)
                {
                    ShowStatus(0,"Some error occurred... Record cannot be added.");
                }
            }
            
        }
        private void tabSub_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabSub.SelectedIndex)
            {
                case 0:
                    
                    break;
                case 1:
                    ShowDepartments();
                    break;
            }
        }

       
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowDepartments();
        }

        private void dgvDept_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txtID.Text = dgvDept.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dgvDept.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDesc.Text = dgvDept.Rows[e.RowIndex].Cells[2].Value.ToString();
                chkActive.Checked = (bool)dgvDept.Rows[e.RowIndex].Cells[3].Value;

                tabSub.SelectedIndex = 0;
            }
            catch(Exception ex)
            {
                ilog.Error(ex.Message, ex);
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

        private void clearFormFields()
        {

            txtName.Text = "";
            txtDesc.Text = "";
            chkActive.Checked = true;
            txtID.Text = "";
            //PopulateProcTypeCombo(0);
        }
    }


}
