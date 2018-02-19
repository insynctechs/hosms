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
using Microsoft.Reporting.WinForms;

namespace HospitalERP
{
    public partial class frmReport : Form
    {
        Bill bill = new Bill();
        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetBilling.uspReport_Billing' table. You can move, or remove it, as needed.
            this.uspReport_BillingTableAdapter.Fill(this.DataSetBilling.uspReport_Billing, Convert.ToDateTime("12-12-2017"), Convert.ToDateTime("31-03-2018"), 0);
            this.reportViewer.RefreshReport();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ReportDataSource rd;
            this.rptBilling.Reset();
            /*
            this.rptBilling.RefreshReport();
            //this.uspReport_BillingTableAdapter.Fill(this.DataSetBilling.uspReport_Billing, Convert.ToDateTime(dtFromDate.Value), Convert.ToDateTime(dtToDate.Value), 0);
            DataSet dsBilling = bill.GetBillingReport(Convert.ToDateTime(dtFromDate.Value), Convert.ToDateTime(dtToDate.Value), 0);
            
            if (dsBilling != null)
            {
                rd = new ReportDataSource("DataSetBilling", dsBilling.Tables[0]);
                rptBilling.LocalReport.DataSources.Clear();
                rptBilling.LocalReport.DataSources.Add(rd);
            }
            //set the path of RDLC document
            string reportPath = "G:\\DotNet Projects\\HospitalERP\\HospitalERP\\BillingReport.rdlc";

            // Set the active report path of the ReportViewer object
            rptBilling.LocalReport.ReportPath = reportPath;

            if (dsBilling.Tables[0].Rows.Count == 0)
            {
                lblMessage.Text = "Sorry, no products under this category!";
            }

            rptBilling.LocalReport.Refresh();
            */
        }

        private void frmReport_Load_1(object sender, EventArgs e)
        {

            this.reportViewer.RefreshReport();
        }
    }
}
