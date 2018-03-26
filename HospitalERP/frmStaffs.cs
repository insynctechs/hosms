using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using HospitalERP.Procedures;
using HospitalERP.Helpers;

namespace HospitalERP
{
    public partial class frmStaffs : Form
    {
        log4net.ILog ilog;
        Staffs objStaffs = new Staffs();
        
        public frmStaffs()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
            ilog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        }

        private void frmStaffs_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            
            
        }

        private void PopulateSearch()
        {
            cmbSearch.DataSource = objStaffs.SearchValues();
            cmbSearch.ValueMember = "Value";
            cmbSearch.DisplayMember = "Display";
        }

        private void ShowStaffs()
        {
            DataTable dtRecords = objStaffs.GetStaffs(cmbSearch.SelectedValue.ToString(), txtSearch.Text);
            dgvList.DataSource = dtRecords;
            if (dtRecords.Rows.Count == 0)
            {
                MessageBox.Show(Utils.FormatZeroSearch());
            }

        }
             
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clearControls()
        {
            txtID.Text = "";
            txtempid.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtDesignation.Text = "";
            txtQualification.Text = "";            
            rbGender1.Checked = true;
            dtpDob.Text = "";
            txtNationality.Text = "";
            txtPathaka.Text = "";
            dtpPathakaExpiry.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtDistrict.Text = "";
            txtZip.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            chkActive.Checked = true;
            cmbStaffType.SelectedIndex = 0;
            cmbDept.SelectedIndex = 0;
            cmbUserRole.SelectedIndex = 0;
            txtUSERID.Text = "";


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


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                int logged_in_user = LoggedUser.id;
                int rtn = -1;
                char gender;
                if (rbGender1.Checked == true)
                    gender = 'M';
                else
                    gender = 'F';
                if (txtID.Text.Trim() == "") //add data
                {
                    
                    rtn = objStaffs.addStaffs(txtFirstName.Text, txtLastName.Text, Convert.ToInt32(cmbStaffType.SelectedValue.ToString()), txtDesignation.Text, txtQualification.Text, cmbStaffType.SelectedIndex, gender, Convert.ToDateTime(dtpDob.Text), txtNationality.Text, txtPathaka.Text, Convert.ToDateTime(dtpPathakaExpiry.Text), txtAddress.Text, txtCity.Text, txtDistrict.Text, txtZip.Text, txtPhone.Text, txtEmail.Text, chkActive.Checked, Int32.Parse(cmbUserRole.SelectedValue.ToString()));

                    if (rtn == 0)
                        ShowStatus(0,"Type name should be unique");
                    else if (rtn == 1)
                    {
                        ShowStatus(1,"Record succesfully added");
                        clearControls();

                    }
                    else if (rtn == -1)
                    {
                        ShowStatus(0,"Some error occurred... Record cannot be added.");
                    }
                }
                else //edit record
                {
                    rtn = objStaffs.editStaffs(Int32.Parse(txtID.Text.Trim()), Int32.Parse(txtUSERID.Text.Trim()), txtFirstName.Text, txtLastName.Text, cmbDept.SelectedIndex, txtDesignation.Text, txtQualification.Text, Convert.ToInt32(cmbStaffType.SelectedValue.ToString()), gender, Convert.ToDateTime(dtpDob.Text), txtNationality.Text, txtPathaka.Text, Convert.ToDateTime(dtpPathakaExpiry.Text), txtAddress.Text, txtCity.Text, txtDistrict.Text, txtZip.Text, txtPhone.Text, txtEmail.Text, chkActive.Checked, Int32.Parse(cmbUserRole.SelectedValue.ToString()));
                    //if (rtn == 0)
                    //  lblStatus.Text = "This name already exists. Please provide unique name.";
                    //else
                    if (rtn == 1)
                    {
                        ShowStatus(1, "Record succesfully updated");
                        clearControls();
                       
                    }
                    else if (rtn == -1)
                    {
                        ShowStatus(0, "Some error occurred... Record cannot be added.");
                    }
                }
                
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowStaffs();
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                e.Cancel = true;
                txtFirstName.Focus();
                errorProvider.SetError(txtFirstName, "Required");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtFirstName, null);
            }

        }

        private void cmbDept_Validating(object sender, CancelEventArgs e)
        {
            if (cmbDept.SelectedIndex == 0)
            {
                e.Cancel = true;
                //cmbProcType.Focus();
                errorProvider.SetError(cmbDept, "Required");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(cmbDept, null);
            }
        }

        private void GetDepartmentsCombo(int tid)
        {
            cmbDept.DataSource = objStaffs.GetDepartmentsCombo(tid);
            cmbDept.ValueMember = "Value";
            cmbDept.DisplayMember = "Display";
        }

        private void GetUserRolesCombo(int tid)
        {
            cmbUserRole.DataSource = objStaffs.GetUserRolesCombo(tid);
            cmbUserRole.ValueMember = "Value";
            cmbUserRole.DisplayMember = "Display";
        }

        private void setFormValues(int id)
        {
            DataTable dt = objStaffs.getRecordFromID(id);
            txtempid.Text = dt.Rows[0]["emp_id"].ToString();
            txtFirstName.Text = dt.Rows[0]["first_name"].ToString();
            txtLastName.Text = dt.Rows[0]["last_name"].ToString();
            txtDesignation.Text = dt.Rows[0]["designation"].ToString();
            txtQualification.Text = dt.Rows[0]["qualification"].ToString();

            if (dt.Rows[0]["gender"].ToString() == "M")
                rbGender1.Checked = true;
            else
                rbGender2.Checked = true;
            dtpDob.Text = dt.Rows[0]["dob"].ToString();
            txtNationality.Text = dt.Rows[0]["nationality"].ToString();
            txtPathaka.Text = dt.Rows[0]["legal_id"].ToString();
            dtpPathakaExpiry.Text = dt.Rows[0]["legal_id_expiry"].ToString();
            txtAddress.Text = dt.Rows[0]["address"].ToString();
            txtCity.Text = dt.Rows[0]["city"].ToString();
            txtDistrict.Text = dt.Rows[0]["state"].ToString();
            txtZip.Text = dt.Rows[0]["zip"].ToString();
            txtPhone.Text = dt.Rows[0]["phone"].ToString();
            txtEmail.Text = dt.Rows[0]["email"].ToString();
            chkActive.Checked = Convert.ToBoolean(dt.Rows[0]["active"].ToString());
            GetStaffTypeCombo(Convert.ToInt32(dt.Rows[0]["staff_type_id"].ToString()));
            GetDepartmentsCombo(Convert.ToInt32(dt.Rows[0]["department_id"].ToString()));
            GetUserRolesCombo(Convert.ToInt32(dt.Rows[0]["user_type_id"].ToString()));
            cmbDept.SelectedValue = dt.Rows[0]["department_id"].ToString();
            cmbStaffType.SelectedValue = dt.Rows[0]["staff_type_id"].ToString();
            cmbUserRole.SelectedValue = dt.Rows[0]["user_type_id"].ToString();
            txtUSERID.Text = dt.Rows[0]["user_id"].ToString();
           
        }

        private void dgvList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txtID.Text = dgvList.Rows[e.RowIndex].Cells["colID"].Value.ToString();
                setFormValues(Int32.Parse(txtID.Text));
                tabStaffs.SelectedIndex = 0;


            }
            catch(Exception ex)
            {
                ilog.Error(ex.Message, ex);
                
            }
        }

        private void txtDesignation_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDesignation.Text))
            {
                e.Cancel = true;
                txtFirstName.Focus();
                errorProvider.SetError(txtDesignation, "Required");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtDesignation, null);
            }

        }

        private void tabStaffs_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabStaffs.SelectedIndex)
            {
                case 0:
                    if(txtID.Text=="")
                    {
                        panelEmpID.Visible = false;
                        txtempid.Visible = false;
                    }
                    else
                    {
                        panelEmpID.Visible = true;
                        txtempid.Visible = true;
                    }
                    break;
                case 1:
                    clearControls();
                    ShowStaffs();
                    break;
            }
        }

        
        private void cmbStaffType_Validating(object sender, CancelEventArgs e)
        {
            if (cmbStaffType.SelectedIndex == 0)
            {
                e.Cancel = true;
                //cmbProcType.Focus();
                errorProvider.SetError(cmbDept, "Required");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(cmbDept, null);
            }
        }

        private void GetStaffTypeCombo(int tid)
        {
            cmbStaffType.DataSource = objStaffs.GetStaffTypeCombo(tid);
            cmbStaffType.ValueMember = "Value";
            cmbStaffType.DisplayMember = "Display";
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (dgvList.Columns[e.ColumnIndex].Name)
            {
                case "colBtnEdit":
                    txtID.Text = dgvList.Rows[e.RowIndex].Cells["colID"].Value.ToString();
                    setFormValues(Int32.Parse(txtID.Text));
                    tabStaffs.SelectedIndex = 0;
                    break;

                case "colBtnResetPwd":
                    
                    txtID.Text = dgvList.Rows[e.RowIndex].Cells["colID"].Value.ToString();                    
                    DialogResult m = MessageBox.Show("Are you sure you want to reset the password for this Staff", "Reset Password", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (m == DialogResult.Yes)
                    {
                        
                        try
                        {
                            string def_pwd = "12345";
                            int rtn = 0;
                            using (OptionVals objOpt = new OptionVals())
                            {
                                DataTable dtOpt = objOpt.GetOptionFromName("DEFAULT_PWD");
                                if (dtOpt.Rows.Count > 0)
                                    def_pwd = dtOpt.Rows[0]["op_value"].ToString();
                                dtOpt = null;
                            }
                            using (Users objUsers = new Users())
                            {

                                rtn = objUsers.SetPassword(dgvList.Rows[e.RowIndex].Cells["colEmpID"].Value.ToString(), def_pwd, Int32.Parse(dgvList.Rows[e.RowIndex].Cells["colUserRoleID"].Value.ToString()));
                                if (rtn == 0)
                                    MessageBox.Show("Error in changing password", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                else if (rtn == 1)
                                {
                                    MessageBox.Show("Password succesfully reset to default value - "+def_pwd, "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information);


                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            ilog.Error(ex.Message, ex);                            
                        }
                        finally
                        {

                        }
                    }
                    else if (m == DialogResult.No)
                    {
                        // Do something else
                    }

                    break;
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            
            if (txtID.Text == "")
            {
                panelEmpID.Visible = false;
                txtempid.Visible = false;
            }
            else
            {
                panelEmpID.Visible = true;
                txtempid.Visible = true;
               
            }
        }

        private void frmStaffs_Shown(object sender, EventArgs e)
        {
            PopulateSearch();
            GetDepartmentsCombo(0);
            GetStaffTypeCombo(0);
            GetUserRolesCombo(0);
            if (txtID.Text == "")
            {
                panelEmpID.Visible = false;
                txtempid.Visible = false;
            }
            else
            {
                panelEmpID.Visible = true;
                txtempid.Visible = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearControls();
        }

        private void frmStaffs_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utils.toggleChildCloseButton(this.MdiParent, 1);
            ilog = null;
            objStaffs.Dispose();
        }
    }
}
