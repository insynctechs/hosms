using System;
using System.Data;
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
        
        private void GetBills(int click=0)
        {

            DataTable dtRecords = bill.SearchBills(cmbSearch.SelectedValue.ToString(), txtSearch.Text, Convert.ToDateTime(dtpDate.Value), chkDate.Checked);
            dgvList.DataSource = dtRecords;
            if (dtRecords.Rows.Count == 0 && click == 1)
            {
                MessageBox.Show(Utils.FormatZeroSearch());
            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetBills(1);
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (dgvList.Columns[e.ColumnIndex].Name)
            {
                case "bBtnBill":
                    if (dgvList.Rows[e.RowIndex].Cells["bTypeID"].Value.ToString() == "1")
                    {
                        frmConsultationBill frm = new frmConsultationBill(Int32.Parse(dgvList.Rows[e.RowIndex].Cells["bID"].Value.ToString()));
                        frm.ShowDialog();
                    }
                    else if (dgvList.Rows[e.RowIndex].Cells["bTypeID"].Value.ToString() == "2")
                    {
                        frmProceduresBill frm = new frmProceduresBill(Int32.Parse(dgvList.Rows[e.RowIndex].Cells["bID"].Value.ToString()));
                        frm.ShowDialog();
                    }
                    break;
            }
        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
