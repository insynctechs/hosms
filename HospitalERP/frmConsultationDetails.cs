using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using HospitalERP.Procedures;
using HospitalERP.Helpers;

namespace HospitalERP
{
    public partial class frmConsultationDetails : Form
    {
        log4net.ILog ilog;
        ConsultationDetails objCD = new ConsultationDetails();
        Appointments objApp = new Appointments();
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
                ShowProceduresHistory(0);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ShowProceduresHistory(int index)
        {
            dgvApptHistory.Rows[index].Selected = true;
            int app_id = Convert.ToInt32(dgvApptHistory.Rows[index].Cells["colHistID"].Value);
            lblHeadProcHist.Text = "PROCEDURES DONE ON APPT. DATE " + Utils.FormatDateShort(dgvApptHistory.Rows[index].Cells["colHistDate"].Value.ToString());
            dgvHistoryProcedures.DataSource = objCD.getProceduresFromApptID(app_id);
        }


        private void getConsultationDetails()
        {            
            DataTable dt = objCD.getRecordFromID(Convert.ToInt32(txtAppID.Text));
            txtPatientID.Text = dt.Rows[0]["patient_id"].ToString();
            txtPatientNo.Text = dt.Rows[0]["patient_number"].ToString();
            txtPatientName.Text = dt.Rows[0]["patient_name"].ToString();
            txtGender.Text = Utils.Gender[dt.Rows[0]["gender"].ToString()];
            txtDob.Text = Utils.FormatDateShort(dt.Rows[0]["dob"].ToString());
            txtAge.Text =  dt.Rows[0]["age"].ToString();
            txtPhone.Text  = dt.Rows[0]["phone"].ToString();
            txtNationality.Text = dt.Rows[0]["nationality"].ToString();
            
            if (dt.Rows[0]["prev_date"].ToString() != "")
            {
                txtLastVisitDate.Text = Utils.FormatDateShort(dt.Rows[0]["prev_date"].ToString());
            }
            txtMeetDate.Text = Utils.FormatDateShort(dt.Rows[0]["appointment_date"].ToString());
            txtDues.Text = dt.Rows[0]["dues"].ToString();
            txtMedicalNotes.Text = dt.Rows[0]["history"].ToString();
            txtAllergies.Text   = dt.Rows[0]["allergies"].ToString();
            txtApptNotes.Text = dt.Rows[0]["notes"].ToString();
            txtDoctor.Text = Utils.FormatDoctorName(dt.Rows[0]["doctor_name"].ToString());            
            txtDoctorID.Text = dt.Rows[0]["doctor_id"].ToString();
            cmbAppStatus.SelectedValue = dt.Rows[0]["status"];
            if (Convert.ToInt16(dt.Rows[0]["status_edit_lock"].ToString()) == 1)
                EnableEditableButtons(false);
            else
                EnableEditableButtons(true);
        }

        private void EnableEditableButtons(bool val)
        {
            btnSave.Enabled = val;
            btnSaveProcedure.Enabled = val;
            btnAddNew.Enabled = val;
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
            int rtn = objCD.saveDiagnosis(Int32.Parse(txtAppID.Text.Trim()), Int32.Parse(txtPatientID.Text.Trim()),txtMedicalNotes.Text.Trim(),txtAllergies.Text.Trim(),txtApptNotes.Text.Trim(), Convert.ToInt16(cmbAppStatus.SelectedValue));
            
            if (rtn == 1)
            {
                ShowStatus(1, "Record succesfully updated");
                
            }
            else if (rtn == -1)
            {
                ShowStatus(0, "Some error occurred... Record cannot be added.");
            }
            getConsultationDetails();
        }

        private void ShowStatus(int success, string msg)
        {
            MessageBox.Show(msg, "Information", MessageBoxButtons.OK);
           
        }

        private void dgvApptHistory_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ShowProceduresHistory(e.RowIndex);       

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

        private void btnAddNewProcedure_Click(object sender, EventArgs e)
        {
            frmProcedures fp = new frmProcedures(600,500);
            //fp.MdiParent = this.MdiParent;
            fp.ShowDialog(this);
            cmbProcedure.DataSource = objCD.ProceduresCombo(0);

        }

        private void frmConsultationDetails_Activated(object sender, EventArgs e)
        {
            
        }

        private void frmConsultationDetails_Shown(object sender, EventArgs e)
        {
            //cmbProcedure.DataSource = objCD.ProceduresCombo(0);
            //cmbStatus.DataSource = objCD.StatusCombo(0);
            PopulateAppointmentStatusCombo();
            getConsultationDetails();           
           
        }

        private void tabConsult_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabConsult.SelectedIndex)
            {
                case 0:

                    break;
                case 1:
                    cmbProcedure.DataSource = objCD.ProceduresCombo(0);
                    cmbStatus.DataSource = objCD.StatusCombo(0);
                    getProcedureList();
                    break;
                case 2:
                    dgvHistoryProcedures.AutoGenerateColumns = false;
                    setGridViews();
                    break;
            }
        }

        private void dgvApptHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (dgvApptHistory.Columns[e.ColumnIndex].Name)
            {
                case "btnHistSelect":
                    ShowProceduresHistory(e.RowIndex);
                    break;
            }
        }

        private void PopulateAppointmentStatusCombo()
        {
            cmbAppStatus.DataSource = objApp.getAppointmentStatus();
            cmbAppStatus.DisplayMember = "name";
            cmbAppStatus.ValueMember = "id";
            
        }

        private void btnGenerateBill_Click(object sender, EventArgs e)
        {
            frmRptSickLeave rsl = new frmRptSickLeave(Int32.Parse(txtAppID.Text.Trim()), Int32.Parse(txtPatientID.Text.Trim()));
            rsl.ShowDialog(this);
        }

        private void btnMedicalReport_Click(object sender, EventArgs e)
        {
            frmRptMedical fm = new frmRptMedical(Int32.Parse(txtAppID.Text.Trim()));
            fm.ShowDialog(this);
        }

        
    }
}
