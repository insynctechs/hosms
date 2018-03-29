﻿using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using HospitalERP.Procedures;
using HospitalERP.Helpers;

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
            try
            {
                this.WindowState = FormWindowState.Maximized;
                log4net.Config.XmlConfigurator.Configure();
                ilog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }
        private void PopulateSearch()
        {
            try
            {
                cmbSearch.DataSource = dt.SearchValues();
                cmbSearch.ValueMember = "Value";
                cmbSearch.DisplayMember = "Display";
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void ShowDepartments()
        {
            try
            {
                DataTable dtDept = dt.GetDepartments(cmbSearch.SelectedValue.ToString(), txtSearch.Text);
                dgvDept.DataSource = dtDept;
                if (dtDept.Rows.Count == 0)
                    MessageBox.Show(Utils.FormatZeroSearch());
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
                        rtn = dt.addTypes(txtName.Text, txtDesc.Text, chkActive.Checked);
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
                        rtn = dt.editTypes(Int32.Parse(txtID.Text.Trim()), txtName.Text, txtDesc.Text, chkActive.Checked);
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
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
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
                        ShowDepartments();
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
            ShowDepartments();
        }

        private void setFormFields(int index)
        {
            try
            {
                txtID.Text = dgvDept.Rows[index].Cells["colID"].Value.ToString();
                txtName.Text = dgvDept.Rows[index].Cells["colName"].Value.ToString();
                txtDesc.Text = dgvDept.Rows[index].Cells["colDesc"].Value.ToString();
                chkActive.Checked = (bool)dgvDept.Rows[index].Cells["colActive"].Value;
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void dgvDept_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                setFormFields(e.RowIndex);
                tabSub.SelectedIndex = 0;
            }
            catch(Exception ex)
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
                //PopulateProcTypeCombo(0);
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                clearFormFields();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void frmDepartments_Shown(object sender, EventArgs e)
        {
            try
            {
                PopulateSearch();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void frmDepartments_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Utils.toggleChildCloseButton(this.MdiParent, 1);
                dt.Dispose();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void dgvDept_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (dgvDept.Columns[e.ColumnIndex].Name)
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
    }
}
