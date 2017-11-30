using System;
using System.Windows.Forms;
using HospitalERP.Procedures;
namespace HospitalERP
{
    public partial class frmProcTypes : Form
    {
        ProcTypes pt = new ProcTypes();
        log4net.ILog ilog;
        public frmProcTypes()
        {
            InitializeComponent();
            
        }

        private void frmProcTypes_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            PopulateSearch();
            ShowRecords();
            log4net.Config.XmlConfigurator.Configure();
            ilog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
                int rtn = -1;
                if (txtID.Text.Trim() == "") //add data
                {
                    rtn = pt.InsertProc(txtName.Text, txtDesc.Text, chkActive.Checked);
                    if (rtn == -1)
                        lblStatus.Text = "Some error occurred... Record cannot be added.";
                    else if (rtn == 0)
                        lblStatus.Text = "Type name should be unique";
                    else if (rtn == 1)
                    {
                        lblStatus.Text = "Record succesfully added";
                        txtName.Text = "";
                        txtDesc.Text = "";
                        chkActive.Checked = false;
                    }
                }
                else //edit record
                {
                    rtn = pt.editTypes(Int32.Parse(txtID.Text.Trim()), txtName.Text, txtDesc.Text, chkActive.Checked);
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
