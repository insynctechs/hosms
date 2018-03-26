using System;
using System.Linq;
using System.Windows.Forms;
using HospitalERP.Procedures;
using HospitalERP.Helpers;

namespace HospitalERP
{
    public partial class frmConsultations : Form
    {
        log4net.ILog ilog;
        Doctors doc = new Doctors();
        Appointments app = new Appointments();
        Patients pat = new Patients();
        int startload = 0;
        public frmConsultations()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
            ilog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        private void frmConsultations_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            GetDoctorsCombo(0);
            PopulateStatus();
            getAppointmentList();
            startload = 1;
        }

        private void dgvApp_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
        private void GetDoctorsCombo(int tid)
        {
            cmbDoc.ValueMember = "id";
            cmbDoc.DisplayMember = "name";
            cmbDoc.DataSource = doc.getDoctorsCombo(tid);
            //LoggedUser.type_name = "DOCTOR";
            //LoggedUser.staff_id = 1;
            if (LoggedUser.type_name.ToUpper() == "DOCTOR" && LoggedUser.staff_id > 0 )
            {
                cmbDoc.SelectedValue = LoggedUser.staff_id;
                cmbDoc.Enabled = false;
            }

        }
        private void PopulateStatus()
        {
            cmbStatus.DataSource = app.getAppointmentStatus(0);
            cmbStatus.ValueMember = "id";
            cmbStatus.DisplayMember = "name";
        }
        private void getAppointmentList()
        {
            dgvApp.DataSource = app.getAllAppointmentsForDate(Convert.ToDateTime(dtpAppDate.Text), Int32.Parse(cmbDoc.SelectedValue.ToString()), Int32.Parse(cmbStatus.SelectedValue.ToString() ));
        }

        private void dtpAppDate_ValueChanged(object sender, EventArgs e)
        {
            if(startload == 1)
                getAppointmentList();
        }

        private void frmConsultations_Activated(object sender, EventArgs e)
        {
            if (startload == 1)
                getAppointmentList();
        }

        private void cmbDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (startload == 1)
                getAppointmentList();
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (startload == 1)
                getAppointmentList();
        }

        private void btnList_Click(object sender, EventArgs e)
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
            if (Application.OpenForms.OfType<frmBilling>().Count() == 1)
                Application.OpenForms.OfType<frmBilling>().First().Close();
            frmBilling frm = new frmBilling(app_id, pat_id);
            frm.MdiParent = this.ParentForm;
            frm.Show();
        }

        private void dgvApp_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ViewDetails(Int32.Parse(dgvApp.Rows[e.RowIndex].Cells["AID"].Value.ToString()), Int32.Parse(dgvApp.Rows[e.RowIndex].Cells["APatID"].Value.ToString()));

        }
    }
}
