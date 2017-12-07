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
            PopulateSearch();
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
            dgvPatient.DataSource = pat.GetRecords(cmbSearch.SelectedValue.ToString(), txtSearch.Text);
        }

        private void txtPatNum_TextChanged(object sender, EventArgs e)
        {
            if(txtPatNum.Text.Trim() != "" && cmbDoc.SelectedValue.ToString() != Convert.ToString(0))
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
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
            int ret = app.addAppointment(Int32.Parse(txtPatientID.Text), Int32.Parse(cmbDoc.SelectedValue.ToString()), Convert.ToDateTime(dtpAppDate.Text), Int32.Parse(Utils.ProcedureStatus["Scheduled"]));
            if(ret >= 1)
            {
                MessageBox.Show("Added");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {

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
            txtPatientID.Text = dgvPatient.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtPatNum.Text = dgvPatient.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void cmbDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtPatNum.Text.Trim() != "" && cmbDoc.SelectedValue.ToString() != Convert.ToString(0))
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }
        }
    }
}
