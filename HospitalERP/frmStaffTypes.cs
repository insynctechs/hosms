using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using HospitalERP.Procedures;
using HospitalERP.Helpers;
namespace HospitalERP
{
    public partial class frmStaffTypes : Form
    {
        StaffTypes st = new StaffTypes();
        log4net.ILog ilog;
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
            
            log4net.Config.XmlConfigurator.Configure();
            ilog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;

            
        }

        private void PopulateSearch()
        {
            cmbSearch.DataSource = st.SearchValues();
            cmbSearch.ValueMember = "Value";
            cmbSearch.DisplayMember = "Display";
        }

        private void ShowRecords()
        {
            DataTable dtRecords = st.GetRecords(cmbSearch.SelectedValue.ToString(), txtSearch.Text);
            dgvList.DataSource = dtRecords;
            if(dtRecords.Rows.Count == 0)
            {
                MessageBox.Show(Utils.FormatZeroSearch());
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            int rtn = -1;
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                if (txtID.Text.Trim() == "") //add data
                {
                    rtn = st.addStaffs(txtName.Text, txtDesc.Text, chkActive.Checked);
                    if (rtn == 0)
                        ShowStatus(0,"Type name should be unique!");
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
                    rtn = st.editTypes(Int32.Parse(txtID.Text.Trim()), txtName.Text, txtDesc.Text, chkActive.Checked);
                    if (rtn == 0)
                        ShowStatus(0, "This name already exists. Please provide unique name.");
                    else if (rtn == 1)
                    {
                        ShowStatus(1, "Record succesfully updated!");
                        clearFormFields();

                    }
                    else if (rtn == -1)
                    {
                        ShowStatus(0, "Some error occurred... Record cannot be added.");
                    }
                }
                
            }
        }

        private void dgvList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {


            setFormFields(e.RowIndex);
            tabSub.SelectedIndex = 0;
        }

        private void setFormFields(int index)
        {
            txtID.Text = dgvList.Rows[index].Cells["colID"].Value.ToString();
            txtName.Text = dgvList.Rows[index].Cells["colName"].Value.ToString();
            txtDesc.Text = dgvList.Rows[index].Cells["colDescription"].Value.ToString();
            chkActive.Checked = (bool)dgvList.Rows[index].Cells["colActive"].Value;
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowRecords();
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (dgvList.Columns[e.ColumnIndex].Name)
            {
                case "colBtnEdit":
                    setFormFields(e.RowIndex);
                    tabSub.SelectedIndex = 0;
                    break;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearFormFields();
        }

        private void frmStaffTypes_FormClosed(object sender, FormClosedEventArgs e)
        {

            Utils.toggleChildCloseButton(this.MdiParent,1);
            st.Dispose();
           
            
        }

        

        private void frmStaffTypes_Shown(object sender, EventArgs e)
        {
            PopulateSearch();
        }
    }
}
