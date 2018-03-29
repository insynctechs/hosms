using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using HospitalERP.Procedures;
using HospitalERP.Helpers;
namespace HospitalERP
{

    public partial class frmAppointments : Form
    {        
        log4net.ILog ilog;
        Doctors doc = new Doctors();
        Appointments app = new Appointments();
        Patients pat = new Patients();
        int startload = 0;
        int patient_id = 0;
        public frmAppointments()
        {
            try
            {
                InitializeComponent();
                log4net.Config.XmlConfigurator.Configure();
                ilog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }
        public frmAppointments(int patientid)
        {
            try
            {
                InitializeComponent();
                log4net.Config.XmlConfigurator.Configure();
                ilog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                patient_id = patientid;
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void frmAppointments_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
                GetDoctorsCombo(0);
                PopulateSearch();
                if (patient_id > 0)
                {
                    txtPatientID.Text = patient_id.ToString();

                }
                getAppointmentList();
                startload = 1;
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                frmPatient frm = new frmPatient();
                frm.MdiParent = this.ParentForm;
                frm.Show();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }
        private void GetDoctorsCombo(int tid)
        {
            try
            {
                cmbDoc.ValueMember = "id";
                cmbDoc.DisplayMember = "name";
                cmbDoc.DataSource = doc.getDoctorsCombo(tid);
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
                cmbSearch.DataSource = pat.SearchValues(0);
                cmbSearch.ValueMember = "Value";
                cmbSearch.DisplayMember = "Display";
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }
        private void ShowSearchedRecords()
        {
            try
            {
                DataTable dtRecords = pat.GetRecords(cmbSearch.SelectedValue.ToString(), txtSearch.Text);
                dgvPatient.DataSource = dtRecords;
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

        private void txtPatNum_TextChanged(object sender, EventArgs e)
        {
            enableSaveButton();
        }

        private void txtPatientID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtPatientID.Text.Trim() != "")
                {
                    DataTable dtPat = pat.getRecordFromID(Int32.Parse(txtPatientID.Text));
                    if (dtPat.Rows.Count > 0)
                        txtPatNum.Text = dtPat.Rows[0]["patient_number"].ToString();
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
                DataTable dtPatient = pat.GetRecords("patient_number", txtPatNum.Text);
                if (dtPatient.Rows.Count > 0)
                {
                    if (txtPatientID.Text != dtPatient.Rows[0]["id"].ToString())
                    {
                        txtPatientID.Text = dtPatient.Rows[0]["id"].ToString();
                    }
                    int ret = app.addAppointment(Int32.Parse(txtPatientID.Text), Int32.Parse(cmbDoc.SelectedValue.ToString()), Convert.ToDateTime(dtpAppDate.Text), Int32.Parse(Utils.ProcedureStatus["Scheduled"]));
                    if (ret >= 1)
                    {
                        getAppointmentList();
                        MessageBox.Show("Appointment scheduled successfully!");
                    }
                    else if (ret == 0)
                    {
                        MessageBox.Show("Appointment already scheduled!");
                    }
                    else
                    {
                        MessageBox.Show("Error in scheduling appointment!");
                    }
                }
                else
                {
                    MessageBox.Show("No such patient exists!");
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            getAppointmentList(1);
        }

        private void getAppointmentList(int click=0)
        {
            /*DataGridViewComboBoxColumn dcombo;
            dcombo= (DataGridViewComboBoxColumn) dgvApp.Columns["colStatus"];
            dcombo.DataSource = app.getAppointmentStatus();
            dcombo.DisplayMember = "name";
            dcombo.ValueMember = "id";*/
            try
            {
                DataTable dtApps = app.getAllAppointmentsForDate(Convert.ToDateTime(dtpAppDate.Text), Int32.Parse(cmbDoc.SelectedValue.ToString()));
                dgvApp.DataSource = dtApps;
                if (dtApps.Rows.Count == 0 && click == 1)
                {
                    MessageBox.Show("No Appointments Scheduled for the Chosen Date and Doctor");
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text.Trim() == "")
                    btnSearch.Enabled = false;
                else
                    btnSearch.Enabled = true;
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowSearchedRecords();
        }

        private void dgvPatient_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SelectPatient(dgvPatient.Rows[e.RowIndex].Cells["PID"].Value.ToString(), dgvPatient.Rows[e.RowIndex].Cells["PNum"].Value.ToString());
        }

        private void cmbDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            getAppointmentList();
            enableSaveButton();

        }

        private void dtpAppDate_ValueChanged(object sender, EventArgs e)
        {
            if (startload == 1)
                getAppointmentList();
            enableSaveButton();
        }

        private void enableSaveButton()
        {
            try
            {
                TimeSpan difference = DateTime.Now - dtpAppDate.Value;
                if (txtPatNum.Text.Trim() != "" && cmbDoc.SelectedValue.ToString() != Convert.ToString(0) && Convert.ToInt32(difference.TotalDays) <= 0)
                {
                    btnSave.Enabled = true;
                }
                else
                {
                    btnSave.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void dgvApp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // MessageBox.Show(e.ColumnIndex.ToString());
            try
            {
                switch (dgvApp.Columns[e.ColumnIndex].Name)
                {
                    case "ABtnBill":
                        ViewBill(Int32.Parse(dgvApp.Rows[e.RowIndex].Cells["AID"].Value.ToString()), Int32.Parse(dgvApp.Rows[e.RowIndex].Cells["APatID"].Value.ToString()));
                        break;
                    case "ABtnDetails":
                        ViewDetails(Int32.Parse(dgvApp.Rows[e.RowIndex].Cells["AID"].Value.ToString()), Int32.Parse(dgvApp.Rows[e.RowIndex].Cells["APatID"].Value.ToString()));
                        break;
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void dgvApp_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                ViewDetails(Int32.Parse(dgvApp.Rows[e.RowIndex].Cells["AID"].Value.ToString()), Int32.Parse(dgvApp.Rows[e.RowIndex].Cells["APatID"].Value.ToString()));
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }


        }

        private void frmAppointments_Activated(object sender, EventArgs e)
        {
            try
            {
                if (startload == 1)
                    getAppointmentList();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void ViewDetails(int app_id, int pat_id)
        {
            try
            {
                if (Application.OpenForms.OfType<frmConsultationDetails>().Count() == 1)
                    Application.OpenForms.OfType<frmConsultationDetails>().First().Close();
                frmConsultationDetails frm = new frmConsultationDetails(app_id, pat_id);
                frm.MdiParent = this.ParentForm;
                frm.Show();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void ViewBill(int app_id, int pat_id)
        {
            try
            {
                if (Application.OpenForms.OfType<frmAppointmentBill>().Count() == 1)
                    Application.OpenForms.OfType<frmAppointmentBill>().First().Close();
                frmAppointmentBill frm = new frmAppointmentBill(app_id, pat_id);
                frm.MdiParent = this.ParentForm;
                frm.Show();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void SelectPatient(string pid, string pnum)
        {
            try
            {
                txtPatientID.Text = pid;
                txtPatNum.Text = pnum;
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void dgvPatient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (dgvPatient.Columns[e.ColumnIndex].Name)
                {
                    case "PBtnSelect":
                        SelectPatient(dgvPatient.Rows[e.RowIndex].Cells["PID"].Value.ToString(), dgvPatient.Rows[e.RowIndex].Cells["PNum"].Value.ToString());

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
