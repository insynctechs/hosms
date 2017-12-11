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
    public partial class frmConsultationDetails : Form
    {
        log4net.ILog ilog;
        ConsultationDetails objCD = new ConsultationDetails();
        //DataSet ds;
        //SqlDataAdapter adap;
        //SqlCommandBuilder scb;
        public frmConsultationDetails()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
            ilog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        }

        public frmConsultationDetails(int aptid, int patid)
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
            ilog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            txtAppID.Text = aptid.ToString();
            txtPatientID.Text = patid.ToString();
        }

        private void frmConsultationDetails_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            
            cmbProcedure.DataSource = objCD.ProceduresCombo(0);
            cmbStatus.DataSource = objCD.StatusCombo(0);
            getConsultationDetails();
            getProcedureList();
            setGridViews();

        }

        private void getProcedureList()
        {
            dgvProc.DataSource = objCD.getProceduresFromApptID(Convert.ToInt32(txtAppID.Text));
        }

        private void setGridViews()
        {
            try
            {                
                dgvApptHistory.DataSource = objCD.getApptHistory(Convert.ToInt32(txtAppID.Text),Convert.ToInt32(txtPatientID.Text));
                dgvApptHistory.Rows[0].Selected = true;        
                int app_id = Convert.ToInt32(dgvApptHistory.Rows[0].Cells[0].Value);
                dgvHistoryProcedures.DataSource = objCD.getProceduresFromApptID(app_id);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void getConsultationDetails()
        {            
            DataTable dt = objCD.getRecordFromID(Convert.ToInt32(txtAppID.Text));
            txtPatientID.Text = dt.Rows[0]["patient_id"].ToString();
            txtPatientNo.Text = dt.Rows[0]["patient_number"].ToString();
            txtPatientName.Text = dt.Rows[0]["patient_name"].ToString();
            if (dt.Rows[0]["gender"].ToString() == "M")
                rbGender1.Checked = true;
            else
                rbGender2.Checked = true;

            dtpDob.Text = dt.Rows[0]["dob"].ToString();
            txtAge.Text =  dt.Rows[0]["age"].ToString();
            txtPhone.Text  = dt.Rows[0]["phone"].ToString();
            txtNationality.Text = dt.Rows[0]["nationality"].ToString();
            txtLastVisitDate.Text= dt.Rows[0]["prev_date"].ToString();
            txtApptDate.Text = dt.Rows[0]["appointment_date"].ToString();
            txtBillDue.Text = dt.Rows[0]["dues"].ToString();
            txtMedicalNotes.Text = dt.Rows[0]["history"].ToString();
            txtAllergies.Text   = dt.Rows[0]["allergies"].ToString();
            txtApptNotes.Text = dt.Rows[0]["notes"].ToString();
            txtDoctor.Text = dt.Rows[0]["doctor_name"].ToString();            
            txtDoctorID.Text = dt.Rows[0]["doctor_id"].ToString();
        }

        private void btnSaveProcedure_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                int rtn = -1;                
                if (txtApptProcID.Text.Trim() == "") //add data
                {
                    rtn = objCD.addProcedures(Convert.ToInt32(txtPatientID.Text), Convert.ToInt32(txtDoctorID.Text), Convert.ToInt32(txtAppID.Text), Convert.ToInt32(cmbProcedure.SelectedValue.ToString()),txtProcNotes.Text.Trim(), Convert.ToDecimal(txtFee.Text), Convert.ToInt32(cmbStatus.SelectedValue.ToString()));
                    if (rtn == -1)
                    {
                        ShowStatus(0, "Some error occurred... Record cannot be added!");
                    }
                    else if (rtn == 0)
                        ShowStatus(0, "Name must be unique!");
                    else if (rtn == 1)
                    {

                        ShowStatus(1, "Record succesfully added!");
                        clearFormFields();
                        getProcedureList();
                    }
                }
                else //edit record
                {
                    rtn = objCD.editProcedures(Convert.ToInt32(txtApptProcID.Text.Trim()), Convert.ToInt32(txtPatientID.Text), Convert.ToInt32(txtDoctorID.Text), Convert.ToInt32(txtAppID.Text), Convert.ToInt32(cmbProcedure.SelectedValue.ToString()), txtProcNotes.Text.Trim(), Convert.ToDecimal(txtFee.Text), Convert.ToInt32(cmbStatus.SelectedValue.ToString()));
                    if (rtn == 0)
                        ShowStatus(0, "This name already exists. Please provide unique name!");
                    else if (rtn == 1)
                    {
                        ShowStatus(1, "Record succesfully updated!");
                        clearFormFields();
                        getProcedureList();
                    }
                    else if (rtn == -1)
                    {
                        ShowStatus(0, "Some error occurred... Record cannot be added!");
                    }
                }
                
            }
        }

        private void clearFormFields()
        {
            txtApptProcID.Text = "";
            txtFee.Text = "";
            cmbProcedure.SelectedValue = 0;
            cmbStatus.SelectedValue = 0;
            txtProcNotes.Text = "";
        }
        private void dgvProc_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtApptProcID.Text = dgvProc.Rows[e.RowIndex].Cells["cid"].Value.ToString();
            DataTable dt = objCD.getProceduresFromProcID(Convert.ToInt32(txtApptProcID.Text));
            txtFee.Text = dt.Rows[0]["fee"].ToString();
            cmbProcedure.SelectedValue = dt.Rows[0]["procedure_id"].ToString();
            cmbStatus.SelectedValue = dt.Rows[0]["status"].ToString();
            txtProcNotes.Text = dt.Rows[0]["notes"].ToString();
        }

        private void cmbProcedure_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(txtApptProcID.Text=="") //load fees from procedure table
            {
                txtFee.Text = objCD.getProcedureFees(Convert.ToInt32(cmbProcedure.SelectedValue.ToString()));
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //to save medical notes and known allergies in patient table and
            //to save appointment notes in appointment table
            int rtn = objCD.saveDiagnosis(Int32.Parse(txtAppID.Text.Trim()), Int32.Parse(txtPatientID.Text.Trim()),txtMedicalNotes.Text.Trim(),txtAllergies.Text.Trim(),txtApptNotes.Text.Trim());
            //if (rtn == 0)
            //  lblStatus.Text = "This name already exists. Please provide unique name.";
            //else
            if (rtn == 1)
            {
                ShowStatus(1, "Record succesfully updated");
                
            }
            else if (rtn == -1)
            {
                ShowStatus(0, "Some error occurred... Record cannot be added.");
            }
        }

        private void ShowStatus(int success, string msg)
        {
            MessageBox.Show(msg, "Information", MessageBoxButtons.OK);
            /*
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
            */
        }

        private void dgvApptHistory_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int app_id = Convert.ToInt32(dgvApptHistory.Rows[e.RowIndex].Cells["colid"].Value.ToString());
            dgvHistoryProcedures.DataSource = objCD.getProceduresFromApptID(app_id);

        }

        private void cmbProcedure_Validating(object sender, CancelEventArgs e)
        {
            if (cmbProcedure.SelectedIndex == 0)
            {
                e.Cancel = true;
                //cmbProcType.Focus();
                errorProvider.SetError(cmbProcedure, "Required");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(cmbProcedure, null);
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

        private void cmbStatus_Validating(object sender, CancelEventArgs e)
        {
            if (cmbStatus.SelectedIndex == 0)
            {
                e.Cancel = true;
                //cmbProcType.Focus();
                errorProvider.SetError(cmbStatus, "Required");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(cmbStatus, null);
            }
        }
    }
}
