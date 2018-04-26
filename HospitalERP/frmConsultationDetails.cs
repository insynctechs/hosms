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

        ConsultationDetails objCD = new ConsultationDetails();
        Appointments objApp = new Appointments();
        //DataSet ds;
        //SqlDataAdapter adap;
        //SqlCommandBuilder scb;
        public frmConsultationDetails()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        public frmConsultationDetails(int aptid, int patid)
        {
            try
            {
                InitializeComponent();
                txtAppID.Text = aptid.ToString();
                txtPatientID.Text = patid.ToString();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void frmConsultationDetails_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
                dgvProc.AutoGenerateColumns = false;
                dgvApptHistory.AutoGenerateColumns = false;
                dgvHistoryProcedures.AutoGenerateColumns = false;
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void getProcedureList()
        {
            try
            {
                dgvProc.DataSource = objCD.getProceduresFromApptID(Convert.ToInt32(txtAppID.Text));
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

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
            try
            {
                dgvApptHistory.Rows[index].Selected = true;
                int app_id = Convert.ToInt32(dgvApptHistory.Rows[index].Cells["colHistID"].Value);
                lblHeadProcHist.Text = "PROCEDURES DONE ON APPT. DATE " + Utils.FormatDateShort(dgvApptHistory.Rows[index].Cells["colHistDate"].Value.ToString());
                dgvHistoryProcedures.DataSource = objCD.getProceduresFromApptID(app_id);
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }


        private void getConsultationDetails()
        {
            try
            {
                DataTable dt = objCD.getRecordFromID(Convert.ToInt32(txtAppID.Text));
                txtPatientID.Text = dt.Rows[0]["patient_id"].ToString();
                txtPatientNo.Text = dt.Rows[0]["patient_number"].ToString();
                txtPatientName.Text = dt.Rows[0]["patient_name"].ToString();
                txtGender.Text = Utils.Gender[dt.Rows[0]["gender"].ToString()];
                txtDob.Text = Utils.FormatDateShort(dt.Rows[0]["dob"].ToString());
                txtAge.Text = dt.Rows[0]["age"].ToString();
                txtPhone.Text = dt.Rows[0]["phone"].ToString();
                txtNationality.Text = dt.Rows[0]["nationality"].ToString();
                txtReferredBy.Text = dt.Rows[0]["referred_doctor_name"].ToString();
                if (dt.Rows[0]["prev_date"].ToString() != "")
                {
                    txtLastVisitDate.Text = Utils.FormatDateShort(dt.Rows[0]["prev_date"].ToString());
                }
                txtMeetDate.Text = Utils.FormatDateShort(dt.Rows[0]["appointment_date"].ToString());
                txtDues.Text = dt.Rows[0]["dues"].ToString();
                txtMedicalNotes.Text = dt.Rows[0]["history"].ToString();
                txtAllergies.Text = dt.Rows[0]["allergies"].ToString();
                txtApptNotes.Text = dt.Rows[0]["notes"].ToString();
                txtDoctor.Text = Utils.FormatDoctorName(dt.Rows[0]["doctor_name"].ToString());
                txtDoctorID.Text = dt.Rows[0]["doctor_id"].ToString();
                cmbAppStatus.SelectedValue = dt.Rows[0]["status"];
                txtAddress.Text = Utils.FormatAddress(dt.Rows[0]["address"].ToString(), dt.Rows[0]["city"].ToString(), dt.Rows[0]["state"].ToString(), dt.Rows[0]["zip"].ToString());
                if (Convert.ToInt16(dt.Rows[0]["status_edit_lock"].ToString()) == 1)
                    EnableEditableButtons(false);
                else
                    EnableEditableButtons(true);
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void EnableEditableButtons(bool val)
        {
            try
            {
                btnSave.Enabled = val;
                btnSaveProcedure.Enabled = val;
                btnAddNew.Enabled = val;
                cmbAppStatus.Enabled = val;
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void btnSaveProcedure_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    int rtn = -1;
                    if (txtApptProcID.Text.Trim() == "") //add data
                    {
                        rtn = objCD.addProcedures(Convert.ToInt32(txtPatientID.Text), Convert.ToInt32(txtDoctorID.Text), Convert.ToInt32(txtAppID.Text), Convert.ToInt32(cmbProcedure.SelectedValue.ToString()), txtProcNotes.Text.Trim(), Convert.ToDecimal(txtFee.Text), Convert.ToInt32(cmbStatus.SelectedValue.ToString()));
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
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void clearFormFields()
        {
            try
            {
                txtApptProcID.Text = "";
                txtFee.Text = "";
                cmbProcedure.SelectedValue = 0;
                cmbStatus.SelectedValue = 0;
                txtProcNotes.Text = "";
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }
        private void dgvProc_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txtApptProcID.Text = dgvProc.Rows[e.RowIndex].Cells["cid"].Value.ToString();
                DataTable dt = objCD.getProceduresFromProcID(Convert.ToInt32(txtApptProcID.Text));
                txtFee.Text = dt.Rows[0]["fee"].ToString();
                cmbProcedure.SelectedValue = dt.Rows[0]["procedure_id"].ToString();
                cmbStatus.SelectedValue = dt.Rows[0]["status"].ToString();
                txtProcNotes.Text = dt.Rows[0]["notes"].ToString();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void cmbProcedure_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtApptProcID.Text == "") //load fees from procedure table
                {
                    txtFee.Text = objCD.getProcedureFees(Convert.ToInt32(cmbProcedure.SelectedValue.ToString()));
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //to save medical notes and known allergies in patient table and
                //to save appointment notes in appointment table
                int rtn = objCD.saveDiagnosis(Int32.Parse(txtAppID.Text.Trim()), Int32.Parse(txtPatientID.Text.Trim()), txtMedicalNotes.Text.Trim(), txtAllergies.Text.Trim(), txtApptNotes.Text.Trim(), Convert.ToInt16(cmbAppStatus.SelectedValue));

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
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void ShowStatus(int success, string msg)
        {
            try
            {
                MessageBox.Show(msg, "Information", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void dgvApptHistory_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                ShowProceduresHistory(e.RowIndex);
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void cmbProcedure_Validating(object sender, CancelEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void txtFee_Validating(object sender, CancelEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void cmbStatus_Validating(object sender, CancelEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void btnAddNewProcedure_Click(object sender, EventArgs e)
        {
            try
            {
                frmProcedures fp = new frmProcedures(600, 500);
                //fp.MdiParent = this.MdiParent;
                fp.ShowDialog(this);
                cmbProcedure.DataSource = objCD.ProceduresCombo(0);
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void frmConsultationDetails_Activated(object sender, EventArgs e)
        {
            
        }

        private void frmConsultationDetails_Shown(object sender, EventArgs e)
        {
            try
            {
                //cmbProcedure.DataSource = objCD.ProceduresCombo(0);
                //cmbStatus.DataSource = objCD.StatusCombo(0);
                PopulateAppointmentStatusCombo();
                getConsultationDetails();
                //Buttons are disabled when
                //prev dates , completed status and users not doctors and super admin 
                if (Utils.DaysBetweenDates(txtMeetDate.Text, DateTime.Now.ToShortDateString()) > 0 || (cmbAppStatus.SelectedValue.ToString() =="2")) /*|| (LoggedUser.type_id !=1 && LoggedUser.type_id != 3)*/
                {
                    EnableEditableButtons(false);
                }
                else
                {
                    EnableEditableButtons(true);
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }


        }

        private void tabConsult_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void dgvApptHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (dgvApptHistory.Columns[e.ColumnIndex].Name)
                {
                    case "btnHistSelect":
                        ShowProceduresHistory(e.RowIndex);
                        break;
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void PopulateAppointmentStatusCombo()
        {
            try
            {
                cmbAppStatus.DataSource = objApp.getAppointmentStatus();
                cmbAppStatus.DisplayMember = "name";
                cmbAppStatus.ValueMember = "id";
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void btnGenerateBill_Click(object sender, EventArgs e)
        {
           
        }

        private void btnMedicalReport_Click(object sender, EventArgs e)
        {
            try
            {
                frmRptMedical fm = new frmRptMedical(Int32.Parse(txtAppID.Text.Trim()));
                fm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void btnRefer_Click(object sender, EventArgs e)
        {
            try
            {
                frmReferToDoctor frt = new frmReferToDoctor(Int32.Parse(txtDoctorID.Text.Trim()), Int32.Parse(txtAppID.Text.Trim()), Int32.Parse(txtPatientID.Text.Trim()));
                frt.ShowDialog(this);
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void btnSickLeave_Click(object sender, EventArgs e)
        {
            try
            {
                frmRptSickLeave rsl = new frmRptSickLeave(Int32.Parse(txtAppID.Text.Trim()), Int32.Parse(txtPatientID.Text.Trim()));
                rsl.ShowDialog(this);
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void btnGenBill_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbAppStatus.SelectedValue.ToString() == "2")
                {
                    frmOneTimeBill frm = new frmOneTimeBill(Int32.Parse(txtAppID.Text.ToString()), Int32.Parse(txtPatientID.Text));
                    frm.ShowDialog();
                }
                else
                    MessageBox.Show("Bill can be generated only for completed appointments. \n Please change the status to completed before generating the bill.");
               
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void frmConsultationDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utils.toggleChildCloseButton(this.MdiParent, 1);
            objCD.Dispose();
            objApp.Dispose();
        }
    }
}
