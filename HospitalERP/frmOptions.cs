using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using HospitalERP.Procedures;
using HospitalERP.Helpers;
namespace HospitalERP
{
    public partial class frmOptions : Form
    {
        OptionVals opt = new OptionVals();
        log4net.ILog ilog;
        private bool errorfocus = false;
        public frmOptions()
        {
            InitializeComponent();
            
            
        }

        private void tabSub_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabSub.SelectedIndex)
            {
                case 0:

                    break;
                case 1:
                    clearFormFields();
                    ShowRecords();
                    break;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowRecords();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {

                int rtn = -1;
                if (txtID.Text.Trim() == "") //add data
                {
                    rtn = opt.InsertOption(txtName.Text.Trim().ToUpper(), txtDesc.Text.Trim(), txtVal.Text.Trim());
                    if (rtn == 0)
                        ShowStatus(0, "Name should be unique");
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
                    rtn = opt.editOptions(Int32.Parse(txtID.Text.Trim()), txtName.Text.Trim().ToUpper(), txtDesc.Text.Trim(), txtVal.Text.Trim());
                    if (rtn == 0)
                        ShowStatus(0, "This name already exists. Please provide unique name.");
                    else if (rtn == 1)
                    {
                        ShowStatus(1, "Record succesfully updated");
                        clearFormFields();

                    }
                    else if (rtn == -1)
                    {
                        ShowStatus(0, "Some error occurred... Record cannot be added.");
                    }
                }

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            PopulateSearch();
            log4net.Config.XmlConfigurator.Configure();
            ilog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
        }

        private void ShowRecords()
        {
            DataTable dtRecords = opt.GetRecords(cmbSearch.SelectedValue.ToString(), txtSearch.Text);
            dgvList.DataSource = dtRecords;
            if (dtRecords.Rows.Count == 0)
            {
                MessageBox.Show(Utils.FormatZeroSearch());
            }
        }

        private void PopulateSearch()
        {
            cmbSearch.DataSource = opt.SearchValues();
            cmbSearch.ValueMember = "Value";
            cmbSearch.DisplayMember = "Display";
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
            txtVal.Text = "";
            txtID.Text = "";
            //PopulateProcTypeCombo(0);
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (txtID.Text.Trim() != "")
                txtName.ReadOnly = true;
            else
                txtName.ReadOnly = false;
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                e.Cancel = true;
                if (errorfocus == false)
                {
                    txtName.Focus();
                    errorfocus = true;
                }
                errorProvider.SetError(txtName, "Required");
            }
            else if(Regex.IsMatch(txtName.Text, @"[^\w\-]"))
            {
                e.Cancel = true;
                if (errorfocus == false) {
                    txtName.Focus();
                    errorfocus = true;
                }

                errorProvider.SetError(txtName, "Allowed characters are alphabets, digits, hyphen and underscore.");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtName, null);
            }
        }

        private void txtVal_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtVal.Text))
            {
                e.Cancel = true;
                if (errorfocus == false)
                {
                    txtVal.Focus();
                    errorfocus = true;
                }
                errorProvider.SetError(txtVal, "Required");
            }           
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtVal, null);
            }
        }

        private void dgvList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            setFormFields(e.RowIndex);
            tabSub.SelectedIndex = 0;
        }

        private void setFormFields(int index)
        {
            txtName.Text = dgvList.Rows[index].Cells["colName"].Value.ToString();
            txtID.Text = dgvList.Rows[index].Cells["colID"].Value.ToString();
            txtDesc.Text = dgvList.Rows[index].Cells["colDesc"].Value.ToString();
            txtVal.Text = dgvList.Rows[index].Cells["colVal"].Value.ToString();
        }



        private void btnClear_Click(object sender, EventArgs e)
        {
            clearFormFields();
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

        private void frmOptions_Shown(object sender, EventArgs e)
        {

        }

        private void frmOptions_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utils.toggleChildCloseButton(this.MdiParent, 1);
            ilog = null;
            opt.Dispose();
        }
    }
}
