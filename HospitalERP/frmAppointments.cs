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
    
    public partial class frmAppointments : Form
    {
        log4net.ILog ilog;
        Doctors doc = new Doctors();
        Appointments app = new Appointments();
        Patients pat = new Patients();
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
            txtPatientID.Text = patientid.ToString();
        }

        private void frmAppointments_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            GetDoctorsCombo(0);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmPatient frm = new frmPatient();
            frm.MdiParent = this.ParentForm;
            frm.Show();
        }
        private void GetDoctorsCombo(int tid)
        {
            cmbDoc.ValueMember = "Value";
            cmbDoc.DisplayMember = "Display";
            cmbDoc.DataSource = doc.getDoctorsCombo(tid);
            
        }

        private void txtPatNum_TextChanged(object sender, EventArgs e)
        {
            if(txtPatNum.Text.Trim() == "")
            {
                btnSave.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
            }
        }

        private void txtPatientID_TextChanged(object sender, EventArgs e)
        {
            if(txtPatientID.Text.Trim()!="")
            {
                DataTable dtPat = pat.getRecordFromID(Int32.Parse(txtPatientID.Text));
                if (dtPat.Rows.Count > 0)
                    txtPatNum.Text = dtPat.Rows[0]["patient_number"].ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnList_Click(object sender, EventArgs e)
        {

        }
    }
}
