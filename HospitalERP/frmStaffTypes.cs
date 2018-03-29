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
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;

            
        }

        private void PopulateSearch()
        {
            try
            {
                cmbSearch.DataSource = st.SearchValues();
                cmbSearch.ValueMember = "Value";
                cmbSearch.DisplayMember = "Display";
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void ShowRecords()
        {
            try
            {
                DataTable dtRecords = st.GetRecords(cmbSearch.SelectedValue.ToString(), txtSearch.Text);
                dgvList.DataSource = dtRecords;
                if (dtRecords.Rows.Count == 0)
                {
                    MessageBox.Show(Utils.FormatZeroSearch());
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void txtName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtName.Text.Trim()))
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
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            int rtn = -1;
            try
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    if (txtID.Text.Trim() == "") //add data
                    {
                        rtn = st.addStaffs(txtName.Text.Trim(), txtDesc.Text.Trim(), chkActive.Checked);
                        if (rtn == 0)
                            ShowStatus(0, "Type name should be unique!");
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
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void dgvList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                setFormFields(e.RowIndex);
                tabSub.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void setFormFields(int index)
        {
            try
            {
                txtID.Text = dgvList.Rows[index].Cells["colID"].Value.ToString();
                txtName.Text = dgvList.Rows[index].Cells["colName"].Value.ToString();
                txtDesc.Text = dgvList.Rows[index].Cells["colDescription"].Value.ToString();
                chkActive.Checked = (bool)dgvList.Rows[index].Cells["colActive"].Value;
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void ShowStatus(int success, string msg)
        {
            try
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
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void clearFormFields()
        {
            try
            {
                txtName.Text = "";
                txtDesc.Text = "";
                chkActive.Checked = true;
                txtID.Text = "";
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

            //PopulateProcTypeCombo(0);
        }

        private void tabSub_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowRecords();
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (dgvList.Columns[e.ColumnIndex].Name)
                {
                    case "colBtnEdit":
                        setFormFields(e.RowIndex);
                        tabSub.SelectedIndex = 0;
                        break;
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearFormFields();
        }

        private void frmStaffTypes_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Utils.toggleChildCloseButton(this.MdiParent, 1);
                st.Dispose();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }



        private void frmStaffTypes_Shown(object sender, EventArgs e)
        {
            PopulateSearch();
        }
    }
}
