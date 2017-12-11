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
using HospitalERP.Helpers;

namespace HospitalERP
{
    public partial class frmAppointmentBill : Form
    {

        public int appointment_id = 0;
        public int patient_id = 0;

        log4net.ILog ilog;
        Bill bill = new Bill();
        Appointments app = new Appointments();
        Patients pat = new Patients();

        public frmAppointmentBill()
        {
            
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
            ilog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            PopulateBillTypes();
        }

        public frmAppointmentBill(int app_id, int pat_id)
        {
            InitializeComponent();
            appointment_id = app_id;
            patient_id = pat_id;
            log4net.Config.XmlConfigurator.Configure();
            ilog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            PopulateBillTypes();


        }

        private void frmAppointmentBill_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            loadPatientAppInfo();
           

        }

        private void btnGenerateBill_Click(object sender, EventArgs e)
        {
            switch(cmbBillType.SelectedValue.ToString())            
            {
                case "0": MessageBox.Show("Please choose a bill type!");
                    break;
                case "1":
                    frmConsultationBill frm = new frmConsultationBill(appointment_id, patient_id);
                    frm.ShowDialog();
                    break;
                case "2":
                    frmProceduresBill frm1 = new frmProceduresBill(appointment_id, patient_id);
                    frm1.ShowDialog();
                    break;
            }
            
        }

        private void loadPatientAppInfo()
        {
            DataTable dtPat = pat.getDetailedPatientRecordFromID(patient_id, appointment_id);
            txtPatNum.Text = dtPat.Rows[0]["patient_number"].ToString();
            txtPatName.Text = dtPat.Rows[0]["patient_name"].ToString();
            string gender = dtPat.Rows[0]["gender"].ToString();
            if (gender == "M")
                rbGender1.Checked = true;
            else
                rbGender2.Checked = true;
            txtDob.Text = Convert.ToDateTime(dtPat.Rows[0]["dob"].ToString()).ToShortDateString();
            txtAge.Text = dtPat.Rows[0]["age"].ToString();
            txtNationality.Text = dtPat.Rows[0]["nationality"].ToString();
            txtPhone.Text = dtPat.Rows[0]["phone"].ToString();
            txtAddress.Text = dtPat.Rows[0]["address"].ToString() + "\r\n" + dtPat.Rows[0]["city"].ToString() + ", " + dtPat.Rows[0]["state"].ToString() + " " + dtPat.Rows[0]["zip"].ToString();
            if(dtPat.Rows[0]["meet_date"].ToString()!= "" && dtPat.Rows[0]["meet_date"].ToString() != null)
                txtMeetDate.Text = Convert.ToDateTime(dtPat.Rows[0]["meet_date"].ToString()).ToShortDateString();
            txtDoctor.Text = dtPat.Rows[0]["doctor_name"].ToString();
            txtDues.Text = dtPat.Rows[0]["dues"].ToString();
            txtAppID.Text = dtPat.Rows[0]["appointment_id"].ToString();
            return;
        }

        private void PopulateBillTypes()
        {
            cmbBillType.DataSource = bill.GetBillTypes(1);
            cmbBillType.DisplayMember = "name";
            cmbBillType.ValueMember = "id";
            return;
        }

        private void frmAppointmentBill_Activated(object sender, EventArgs e)
        {
            ListBills();
        }

        private void ListBills()
        {
            dgvList.DataSource = bill.GetAppointmentAllBills(appointment_id, patient_id);
        }

        private void btnListBills_Click(object sender, EventArgs e)
        {
            ListBills();
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (dgvList.Columns[e.ColumnIndex].Name)
            {
                case "bBtnBill":
                    if(dgvList.Rows[e.RowIndex].Cells["bTypeID"].Value.ToString() == "1")
                    {
                        frmConsultationBill frm = new frmConsultationBill(Int32.Parse(dgvList.Rows[e.RowIndex].Cells["bID"].Value.ToString()));
                        frm.ShowDialog();
                    }
                    else if (dgvList.Rows[e.RowIndex].Cells["bTypeID"].Value.ToString() == "2")
                    {
                        frmConsultationBill frm = new frmConsultationBill(Int32.Parse(dgvList.Rows[e.RowIndex].Cells["bID"].Value.ToString()));
                        frm.ShowDialog();
                    }
                    break;
            }
        }
    }
}
