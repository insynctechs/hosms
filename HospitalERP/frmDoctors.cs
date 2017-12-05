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
    public partial class frmDoctors : Form
    {
        log4net.ILog ilog;
        Doctors doc = new Doctors();

        public frmDoctors()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
            ilog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        }

        private void frmDoctors_Load(object sender, EventArgs e)
        {            
            this.WindowState = FormWindowState.Maximized;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            PopulateSearch();
            GetDepartmentsCombo(0);
            
        }

        private void PopulateSearch()
        {
            cmbSearch.DataSource = doc.SearchValues();
            cmbSearch.ValueMember = "Value";
            cmbSearch.DisplayMember = "Display";
        }

        private void ShowDoctors()
        {
            dgvDept.DataSource = doc.GetDoctors(cmbSearch.SelectedValue.ToString(), txtSearch.Text);
        }


        private void tabDoctors_DrawItem(object sender, DrawItemEventArgs e)
        {            
            if (e.Index == tabDoctors.SelectedIndex)
            {
                e.Graphics.FillRectangle(Brushes.MediumTurquoise, e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.LightCyan, e.Bounds);
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
            txtSpecialization.Text = "";
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
            txtFee.Text = "";
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
                    
                    rtn = doc.addDoctors(txtFirstName.Text, txtLastName.Text, 1, txtDesignation.Text, txtQualification.Text, txtSpecialization.Text, gender, Convert.ToDateTime(dtpDob.Text), txtNationality.Text, txtPathaka.Text, Convert.ToDateTime(dtpPathakaExpiry.Text), txtAddress.Text, txtCity.Text, txtDistrict.Text, txtZip.Text, txtPhone.Text, txtEmail.Text, chkActive.Checked, Convert.ToDouble(txtFee.Text));

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
                    rtn = doc.editDoctors(Int32.Parse(txtID.Text.Trim()), Int32.Parse(txtUSERID.Text.Trim()), txtFirstName.Text, txtLastName.Text, cmbDept.SelectedIndex, txtDesignation.Text, txtQualification.Text, txtSpecialization.Text, gender, Convert.ToDateTime(dtpDob.Text), txtNationality.Text, txtPathaka.Text, Convert.ToDateTime(dtpPathakaExpiry.Text), txtAddress.Text, txtCity.Text, txtDistrict.Text, txtZip.Text, txtPhone.Text, txtEmail.Text, chkActive.Checked, Convert.ToDouble(txtFee.Text),logged_in_user);
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
            ShowDoctors();
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

        private void txtFee_Validating(object sender, CancelEventArgs e)
        {
            decimal d;
            if (string.IsNullOrEmpty(txtFee.Text))
            {
                e.Cancel = true;
                //txtFee.Focus();
                errorProvider.SetError(txtFee, "Required");
            }
            else if (!decimal.TryParse(txtFee.Text, out d))
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

        private void GetDepartmentsCombo(int tid)
        {
            cmbDept.DataSource = doc.GetDepartmentsCombo(tid);
            cmbDept.ValueMember = "Value";
            cmbDept.DisplayMember = "Display";
        }

        private void dgvDept_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtID.Text = dgvDept.Rows[e.RowIndex].Cells[0].Value.ToString();
            DataTable dt = doc.getRecordFromID(Convert.ToInt32(txtID.Text));
            txtempid.Text = dt.Rows[0]["emp_id"].ToString();
            txtFirstName.Text = dt.Rows[0]["first_name"].ToString();
            txtLastName.Text = dt.Rows[0]["last_name"].ToString();
            txtDesignation.Text = dt.Rows[0]["designation"].ToString();
            txtQualification.Text = dt.Rows[0]["qualification"].ToString();
            txtSpecialization.Text = dt.Rows[0]["specialization"].ToString();
            if (dt.Rows[0]["gender"].ToString() == "M")
                rbGender1.Checked = true;
            else
                rbGender2.Checked = true;
            dtpDob.Text = dt.Rows[0]["dob"].ToString();
            txtNationality.Text = dt.Rows[0]["nationality"].ToString();
            txtPathaka.Text = dt.Rows[0]["legal_id"].ToString();
            dtpPathakaExpiry.Text= dt.Rows[0]["legal_id_expiry"].ToString();
            txtAddress.Text = dt.Rows[0]["address"].ToString();
            txtCity.Text = dt.Rows[0]["city"].ToString();
            txtDistrict.Text = dt.Rows[0]["state"].ToString();
            txtZip.Text  = dt.Rows[0]["zip"].ToString();
            txtPhone.Text = dt.Rows[0]["phone"].ToString();
            txtEmail.Text = dt.Rows[0]["email"].ToString();
            chkActive.Checked = Convert.ToBoolean(dt.Rows[0]["active"].ToString());
            txtFee.Text = dt.Rows[0]["consultation_fee"].ToString();
            GetDepartmentsCombo(Convert.ToInt32(dt.Rows[0]["department_id"].ToString()));
            cmbDept.SelectedValue = dt.Rows[0]["department_id"].ToString();
            txtUSERID.Text = dt.Rows[0]["user_id"].ToString();
            tabDoctors.SelectedIndex = 0;
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

        private void tabDoctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabDoctors.SelectedIndex)
            {
                case 0:

                    break;
                case 1:
                    clearControls();
                    ShowDoctors();
                    break;
            }
        }
    }
}
