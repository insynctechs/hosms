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
    public partial class frmBilling : Form
    {
        public int appointment_id=0;
        public int patient_id=0;

        log4net.ILog ilog;
       
        Appointments app = new Appointments();
        Patients pat = new Patients();
        Bill bill = new Bill();

        public frmBilling()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
            ilog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public frmBilling(int app_id, int pat_id)
        {
            InitializeComponent();
            appointment_id = app_id;
            patient_id = pat_id;
            log4net.Config.XmlConfigurator.Configure();
            ilog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        private void frmBilling_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            PopulateSearchCombo();
            GetBills();

        }

        private void PopulateSearchCombo()
        {
            cmbSearch.DataSource = bill.BillSearchValues();
            cmbSearch.ValueMember = "Value";
            cmbSearch.DisplayMember = "Display";
        }   
        
        private void GetBills()
        {

            dgvList.DataSource = bill.SearchBills(cmbSearch.SelectedValue.ToString(), txtSearch.Text, Convert.ToDateTime(dtpDate.Value), chkDate.Checked);
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetBills();
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
