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
    public partial class frmPatient : Form
    {

        log4net.ILog ilog;
        Patients pat = new Patients();
        private bool errorfocus = false;
        public frmPatient()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
            ilog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {

                int logged_in_user = LoggedUser.id ;
                int rtn = -1;
                char gender;
                if (rbGender1.Checked == true)
                    gender = 'M';
                else
                    gender = 'F';
                if (txtID.Text.Trim() == "") //add data
                {
                    rtn = pat.addPatients(txtFirstName.Text, txtLastName.Text, gender, Convert.ToDateTime(dtpDob.Text), txtNationality.Text, txtPathaka.Text, Convert.ToDateTime(dtpPathakaExpiry.Text), txtAddress.Text, txtCity.Text, txtDistrict.Text, txtZip.Text, txtPhone.Text, txtEmail.Text, txtHistory.Text, txtAllergies.Text, logged_in_user);

                    if (rtn >= 1)
                    {
                        ShowStatus(1, "Record succesfully added. ");
                        clearFormFields();
                        if(chkAppointment.Checked == true)
                        {
                            frmAppointments app = new frmAppointments(rtn);
                            app.MdiParent = this.ParentForm;
                            app.Show();
                        }

                    }
                    else if (rtn == -1)
                    {
                        ShowStatus(0, "Some error occurred... Record cannot be added.");
                    }
                }
                else //edit record
                {

                    rtn = pat.editPatients(Int32.Parse(txtID.Text),txtFirstName.Text, txtLastName.Text, gender, Convert.ToDateTime(dtpDob.Text), txtNationality.Text, txtPathaka.Text, Convert.ToDateTime(dtpPathakaExpiry.Text), txtAddress.Text, txtCity.Text, txtDistrict.Text, txtZip.Text, txtPhone.Text, txtEmail.Text, txtHistory.Text, txtAllergies.Text, logged_in_user);

                    if (rtn > -1)
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

        private void clearFormFields()
        {
            txtID.Text = "";
            txtPatNum.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";            
            rbGender1.Checked = false;
            rbGender2.Checked = false;
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
            txtAllergies.Text = "";
            txtHistory.Text = "";
            


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

        private void frmPatient_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            PopulateSearch();
            
        }

        private void PopulateSearch()
        {
            cmbSearch.DataSource = pat.SearchValues();
            cmbSearch.ValueMember = "Value";
            cmbSearch.DisplayMember = "Display";
        }

        private void ShowRecords()
        {
            dgvList.DataSource = pat.GetRecords(cmbSearch.SelectedValue.ToString(), txtSearch.Text);
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstName.Text.Trim()))
            {
               
                e.Cancel = true;
                if (errorfocus == false)
                {
                    txtFirstName.Focus();
                    errorfocus = true;
                }
                 errorProvider.SetError(txtFirstName, "Required");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtFirstName, null);
            }
        }

        private void dtpDob_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(dtpDob.Text))
            {
                e.Cancel = true;
                if (errorfocus == false)
                {
                    dtpDob.Focus();
                    errorfocus = true;
                }                
                errorProvider.SetError(dtpDob, "Required");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(dtpDob, null);
            }
        }

        private void txtNationality_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationality.Text.Trim()))
            {
                e.Cancel = true;
                if (errorfocus == false)
                {
                    txtNationality.Focus();
                    errorfocus = true;
                }
                errorProvider.SetError(txtNationality, "Required");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtNationality, null);
            }
        }

       

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhone.Text.Trim()))
            {
                e.Cancel = true;
                if (errorfocus == false)
                {
                    txtPhone.Focus();
                    errorfocus = true;
                }
                errorProvider.SetError(txtPhone, "Required");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtPhone, null);
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (txtID.Text == "")
                chkAppointment.Visible = true;
            else
                chkAppointment.Visible = false;
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

        private void dgvList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtID.Text = dgvList.Rows[e.RowIndex].Cells[0].Value.ToString();
            DataTable dt = pat.getRecordFromID(Convert.ToInt32(txtID.Text));
            txtPatNum.Text = dt.Rows[0]["patient_number"].ToString();
            txtFirstName.Text = dt.Rows[0]["first_name"].ToString();
            txtLastName.Text = dt.Rows[0]["last_name"].ToString();
            txtAllergies.Text = dt.Rows[0]["allergies"].ToString();
            txtHistory.Text = dt.Rows[0]["history"].ToString();
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
            
            tabSub.SelectedIndex = 0;
        }
    }
}
