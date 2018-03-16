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
using HospitalERP.Helpers;

namespace HospitalERP
{
    public partial class frmProcedures : Form
    {
        log4net.ILog ilog;
        
        ProcTests procTest = new ProcTests();
        public bool modal = false;
        public frmProcedures()
        {
            InitializeComponent();
        }

        public frmProcedures(int width, int height)
        {
            InitializeComponent();
            this.Size = new Size(width, height);
            modal = true;
        }

        private void frmProcedures_Load(object sender, EventArgs e)
        {
            if (modal == false)
            {
                this.WindowState = FormWindowState.Maximized;                
            }
            else
            {
               tabSub.TabPages.Remove(tabPgList);
            }
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            
            log4net.Config.XmlConfigurator.Configure();
            ilog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
        }

        private void PopulateSearch()
        {
            cmbSearch.DataSource = procTest.SearchValues();
            cmbSearch.ValueMember = "Value";
            cmbSearch.DisplayMember = "Display";
        }

        private void PopulateProcTypeCombo(int tid)
        {
            using (ProcTypes procType = new ProcTypes())
            {
                cmbProcType.DataSource = procType.ProcTypesCombo(tid);
                cmbProcType.ValueMember = "Value";
                cmbProcType.DisplayMember = "Display";
            }
        }

        private void ShowProcedureTests()
        {
            DataTable dtRecords = procTest.GetRecords(cmbSearch.SelectedValue.ToString(), txtSearch.Text);
            dgvList.DataSource = dtRecords;
            if (dtRecords.Rows.Count == 0)
            {
                MessageBox.Show(Utils.FormatZeroSearch());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {           
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                int rtn = -1;
                //int cmbProcTypeVal = (int)cmbProcType.SelectedValue.ToString)();
                if (txtID.Text.Trim() == "") //add data
                {
                    rtn = procTest.InsertProcedure(txtName.Text, txtDesc.Text, Convert.ToInt32(cmbProcType.SelectedValue.ToString()), Convert.ToDecimal(txtFee.Text), chkActive.Checked);
                    if (rtn == -1)
                    {
                        ShowStatus(0,"Some error occurred... Record cannot be added!");
                    }
                    else if (rtn == 0)
                        ShowStatus(0,"Name must be unique!");
                    else if (rtn == 1)
                    {

                        ShowStatus(1,"Record succesfully added!");
                        clearFormFields();

                        if (modal == true)
                        {                            
                            this.Close();
                        }
                    }
                }
                else //edit record
                {
                    rtn = procTest.editProcedures(Int32.Parse(txtID.Text.Trim()), txtName.Text, txtDesc.Text, Convert.ToInt32(cmbProcType.SelectedValue.ToString()), Convert.ToDecimal(txtFee.Text), chkActive.Checked);
                    if (rtn == 0)
                        ShowStatus(0, "This name already exists. Please provide unique name!");
                    else if (rtn == 1)
                    {
                        ShowStatus(1,"Record succesfully updated!");
                        clearFormFields();
                    }
                    else if (rtn == -1)
                    {
                        ShowStatus(0, "Some error occurred... Record cannot be added!"); 
                    }
                }

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowProcedureTests();
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

       

        private void tabSub_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabSub.SelectedIndex)
            {
                case 0:
                    if(cmbProcType.SelectedIndex == 0)
                       PopulateProcTypeCombo(0);
                    break;
                case 1:
                    ShowProcedureTests();
                    break;
            }
        }

        private void clearFormFields()
        {
            cmbProcType.SelectedIndex = 0;
            txtName.Text = "";
            txtDesc.Text = "";
            txtFee.Text = "";
            chkActive.Checked = true;
            txtID.Text = "";
            //PopulateProcTypeCombo(0);
        }

        private void cmbProcType_Validating(object sender, CancelEventArgs e)
        {
            if(cmbProcType.SelectedIndex == 0)
            {
                e.Cancel = true;
                //cmbProcType.Focus();
                errorProvider.SetError(cmbProcType, "Required");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtName, null);
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                e.Cancel = true;
                //txtName.Focus();
                errorProvider.SetError(txtName, "Required");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtName, null);
            }
        }

        private void txtFee_Validating(object sender, CancelEventArgs e)
        {
            decimal d;
            if (string.IsNullOrEmpty(txtFee.Text))
            {
                e.Cancel = true;
                //txtFee.Focus();
                errorProvider.SetError(txtFee, "Required");
            }
            else if(!decimal.TryParse(txtFee.Text, out d))
            {
                e.Cancel = true;
                //txtFee.Focus();
                errorProvider.SetError(txtFee, "Invalid Decimal Number");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtFee, null);
            }
        }

       
        private void setFormFields(int index)
        {
            txtID.Text = dgvList.Rows[index].Cells["colID"].Value.ToString();
            DataTable dt = procTest.getRecordFromID(Convert.ToInt32(txtID.Text));
            txtName.Text = dt.Rows[0]["name"].ToString();
            txtDesc.Text = dt.Rows[0]["description"].ToString();
            txtFee.Text = dt.Rows[0]["fee"].ToString();
            PopulateProcTypeCombo(Convert.ToInt32(dt.Rows[0]["type"].ToString()));
            cmbProcType.SelectedValue = dt.Rows[0]["type"].ToString();
            //cmbProcType.SelectedItem = cmbProcType.FindStringExact(cmbText);

            chkActive.Checked = Convert.ToBoolean(dt.Rows[0]["active"].ToString());
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

        private void dgvList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            setFormFields(e.RowIndex);
            tabSub.SelectedIndex = 0;
        }

        private void frmProcedures_Shown(object sender, EventArgs e)
        {
            PopulateSearch();
            PopulateProcTypeCombo(0);
        }

        private void frmProcedures_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utils.toggleChildCloseButton(this.MdiParent, 1);
            ilog = null;
            procTest.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearFormFields();
        }
    }
}
