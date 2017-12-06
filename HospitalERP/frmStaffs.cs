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
            PopulateSearch();
            GetDepartmentsCombo(0);
            GetStaffTypeCombo(0);
            if (txtID.Text == "")
            {
                lblempid.Visible = false;
                txtempid.Visible = false;
            }
            else
            {
                lblempid.Visible = false;
                txtempid.Visible = false;
            }
        }

        private void PopulateSearch()
        {
            cmbSearch.DataSource = objStaffs.SearchValues();
            cmbSearch.ValueMember = "Value";
            cmbSearch.DisplayMember = "Display";
        }

        private void ShowStaffs()
        {
            dgvDept.DataSource = objStaffs.GetStaffs(cmbSearch.SelectedValue.ToString(), txtSearch.Text);
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
                    
                    rtn = objStaffs.addStaffs(txtFirstName.Text, txtLastName.Text, Convert.ToInt32(cmbStaffType.SelectedValue.ToString()), txtDesignation.Text, txtQualification.Text, cmbStaffType.SelectedIndex, gender, Convert.ToDateTime(dtpDob.Text), txtNationality.Text, txtPathaka.Text, Convert.ToDateTime(dtpPathakaExpiry.Text), txtAddress.Text, txtCity.Text, txtDistrict.Text, txtZip.Text, txtPhone.Text, txtEmail.Text, chkActive.Checked);

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
                    rtn = objStaffs.editStaffs(Int32.Parse(txtID.Text.Trim()), Int32.Parse(txtUSERID.Text.Trim()), txtFirstName.Text, txtLastName.Text, cmbDept.SelectedIndex, txtDesignation.Text, txtQualification.Text, Convert.ToInt32(cmbStaffType.SelectedValue.ToString()), gender, Convert.ToDateTime(dtpDob.Text), txtNationality.Text, txtPathaka.Text, Convert.ToDateTime(dtpPathakaExpiry.Text), txtAddress.Text, txtCity.Text, txtDistrict.Text, txtZip.Text, txtPhone.Text, txtEmail.Text, chkActive.Checked,logged_in_user);
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

        private void dgvDept_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txtID.Text = dgvDept.Rows[e.RowIndex].Cells[0].Value.ToString();
                DataTable dt = objStaffs.getRecordFromID(Convert.ToInt32(txtID.Text));
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
                cmbDept.SelectedValue = dt.Rows[0]["department_id"].ToString();
                cmbStaffType.SelectedValue = dt.Rows[0]["staff_type_id"].ToString();
                txtUSERID.Text = dt.Rows[0]["user_id"].ToString();
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
                        lblempid.Visible = false;
                        txtempid.Visible = false;
                    }
                    else
                    {
                        lblempid.Visible = false;
                        txtempid.Visible = false;
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


    }
}
