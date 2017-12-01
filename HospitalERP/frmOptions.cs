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
    public partial class frmOptions : Form
    {
        OptionVals opt = new OptionVals();
        log4net.ILog ilog;
        public frmOptions()
        {
            InitializeComponent();
        }

        private void tabSub_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            PopulateSearch();
            log4net.Config.XmlConfigurator.Configure();
            ilog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        private void ShowRecords()
        {
            dgvDept.DataSource = opt.GetRecords(cmbSearch.SelectedValue.ToString(), txtSearch.Text);
        }

        private void PopulateSearch()
        {
            cmbSearch.DataSource = opt.SearchValues();
            cmbSearch.ValueMember = "Value";
            cmbSearch.DisplayMember = "Display";
        }

        private void ShowStatus(int success, string msg)
        {
            lblStatus.Visible = true;
            if (success == 1)
            {
                lblStatus.BackColor = Color.YellowGreen;
                lblStatus.ForeColor = Color.DarkGreen;
            }
            else
            {
                lblStatus.BackColor = Color.Salmon;
                lblStatus.ForeColor = Color.DarkRed;
            }
            lblStatus.Text = msg;
            var t = new Timer();
            t.Interval = 5000; // it will Tick in 3 seconds
            t.Tick += (s, e) =>
            {
                lblStatus.Hide();
                t.Stop();
            };
            t.Start();
        }

        private void clearFormFields()
        {

            txtName.Text = "";
            txtDesc.Text = "";
            txtVal.Text = "";
            txtID.Text = "";
            //PopulateProcTypeCombo(0);
        }


    }
}
