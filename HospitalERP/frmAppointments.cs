﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
            ilog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }
        public frmAppointments(int patientid)
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
            ilog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            patient_id = patientid;
        }

        private void frmAppointments_Load(object sender, EventArgs e)
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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmPatient frm = new frmPatient();
            frm.MdiParent = this.ParentForm;
            frm.Show();
        }
        private void GetDoctorsCombo(int tid)
        {
            cmbDoc.ValueMember = "id";
            cmbDoc.DisplayMember = "name";
            cmbDoc.DataSource = doc.getDoctorsCombo(tid);

        }
        private void PopulateSearch()
        {
            cmbSearch.DataSource = pat.SearchValues(0);
            cmbSearch.ValueMember = "Value";
            cmbSearch.DisplayMember = "Display";
        }
        private void ShowSearchedRecords()
        {
            DataTable dtRecords  = pat.GetRecords(cmbSearch.SelectedValue.ToString(), txtSearch.Text);
            dgvPatient.DataSource = dtRecords;
            if (dtRecords.Rows.Count == 0)
            {
                MessageBox.Show(Utils.FormatZeroSearch());
            }
        }

        private void txtPatNum_TextChanged(object sender, EventArgs e)
        {
            enableSaveButton();
        }

        private void txtPatientID_TextChanged(object sender, EventArgs e)
        {
            if (txtPatientID.Text.Trim() != "")
            {
                DataTable dtPat = pat.getRecordFromID(Int32.Parse(txtPatientID.Text));
                if (dtPat.Rows.Count > 0)
                    txtPatNum.Text = dtPat.Rows[0]["patient_number"].ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            DataTable dtPatient = pat.GetRecords("patient_number", txtPatNum.Text);
            if (dtPatient.Rows.Count > 0)
            {
                if(txtPatientID.Text != dtPatient.Rows[0]["id"].ToString())
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
            DataTable dtApps = app.getAllAppointmentsForDate(Convert.ToDateTime(dtpAppDate.Text), Int32.Parse(cmbDoc.SelectedValue.ToString()));
            dgvApp.DataSource = dtApps;
            if (dtApps.Rows.Count == 0 && click ==1)
            {
                MessageBox.Show("No Appointments Scheduled for the Chosen Date and Doctor");
            }
        }
        

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim() == "")
                btnSearch.Enabled = false;
            else
                btnSearch.Enabled = true;
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

        private void dgvApp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           // MessageBox.Show(e.ColumnIndex.ToString());
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

        private void dgvApp_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ViewDetails(Int32.Parse(dgvApp.Rows[e.RowIndex].Cells["AID"].Value.ToString()), Int32.Parse(dgvApp.Rows[e.RowIndex].Cells["APatID"].Value.ToString()));

        }

        private void frmAppointments_Activated(object sender, EventArgs e)
        {
            if (startload == 1)
                getAppointmentList();
        }

        private void ViewDetails(int app_id, int pat_id)
        {
            if (Application.OpenForms.OfType<frmConsultationDetails>().Count() == 1)
                Application.OpenForms.OfType<frmConsultationDetails>().First().Close();
            frmConsultationDetails frm = new frmConsultationDetails(app_id, pat_id);
            frm.MdiParent = this.ParentForm;
            frm.Show();
        }

        private void ViewBill(int app_id, int pat_id)
        {
            
            if (Application.OpenForms.OfType<frmAppointmentBill>().Count() == 1)
                Application.OpenForms.OfType<frmAppointmentBill>().First().Close();
            frmAppointmentBill frm = new frmAppointmentBill(app_id, pat_id);
            frm.MdiParent = this.ParentForm;
            frm.Show();
        }

        private void SelectPatient(string pid, string pnum)
        {
            txtPatientID.Text = pid;
            txtPatNum.Text = pnum;
        }

        private void dgvPatient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (dgvPatient.Columns[e.ColumnIndex].Name)
            {
                case "PBtnSelect":
                    SelectPatient(dgvPatient.Rows[e.RowIndex].Cells["PID"].Value.ToString(), dgvPatient.Rows[e.RowIndex].Cells["PNum"].Value.ToString());

                    break;
            }
        }
    }
}
