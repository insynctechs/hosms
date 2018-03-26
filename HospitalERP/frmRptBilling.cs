using System;
using System.Data;
using Microsoft.Reporting.WinForms;
using System.Windows.Forms;
using HospitalERP.Procedures;

namespace HospitalERP
{
    public partial class frmRptBilling : Form
    {
        Bill bill = new Bill();
        public frmRptBilling()
        {
            InitializeComponent();
        }

        private void frmRptBilling_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateStatusCombo();
                PopulateTypesCombo();
                this.uspReport_BillingTableAdapter.Connection.Close();
                this.uspReport_BillingTableAdapter.Connection.ConnectionString = Helpers.DBHelper.Constr;
                this.uspReport_BillingTableAdapter.Connection.Open();
                /*
                     Microsoft.Reporting.WinForms.ReportParameter[] rparams = new Microsoft.Reporting.WinForms.ReportParameter[]
                   {
                   new Microsoft.Reporting.WinForms.ReportParameter("fromDate", dtFromDate.Value.Date.ToShortDateString()),
                   new Microsoft.Reporting.WinForms.ReportParameter("toDate", dtToDate.Value.Date.ToShortDateString())
                   };
                   reportViewer.LocalReport.SetParameters(rparams);

                   // TODO: This line of code loads data into the 'DataSetBilling.uspReport_Billing' table. You can move, or remove it, as needed.
                   this.uspReport_BillingTableAdapter.Fill(this.DataSetBilling.uspReport_Billing, Convert.ToDateTime(dtFromDate.Value), Convert.ToDateTime(dtToDate.Value), Int32.Parse(cmbType.SelectedValue.ToString()),Int32.Parse(cmbStatus.SelectedValue.ToString()));
                   this.reportViewer.RefreshReport();
                   */

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void populateReport()
        {
            try
            {
                MessageBox.Show(this.uspReport_BillingTableAdapter.Connection.ConnectionString);
                this.uspReport_BillingTableAdapter.ClearBeforeFill = true;
                /*reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.DataSources.Add(new ReportDataSource("dsname", uspReport_BillingBindingSource));
                */ReportParameter[] rparams = new ReportParameter[2]; 
                rparams[0] = new ReportParameter("fromDate", dtFromDate.Value.Date.ToShortDateString()); 
                rparams[1] = new ReportParameter("toDate", dtToDate.Value.Date.ToShortDateString()); 
                this.reportViewer.LocalReport.SetParameters(rparams);
                /*
                Microsoft.Reporting.WinForms.ReportParameter[] rparams = new Microsoft.Reporting.WinForms.ReportParameter[]
                {
                new Microsoft.Reporting.WinForms.ReportParameter("fromDate", dtFromDate.Value.Date.ToShortDateString()),
                new Microsoft.Reporting.WinForms.ReportParameter("toDate", dtToDate.Value.Date.ToShortDateString())
                };
                reportViewer.LocalReport.se.SetParameters(rparams);*/
                this.DataSetBilling.Clear();
                this.uspReport_BillingTableAdapter.Fill(this.DataSetBilling.uspReport_Billing, Convert.ToDateTime(dtFromDate.Value), Convert.ToDateTime(dtToDate.Value), Int32.Parse(cmbType.SelectedValue.ToString()), Int32.Parse(cmbStatus.SelectedValue.ToString()));
                this.reportViewer.RefreshReport();
            }
            catch (ConstraintException)
            {
                DataRow[] rowErrors = this.DataSetBilling.uspReport_Billing.GetErrors();

                System.Diagnostics.Debug.WriteLine("YourDataTable Errors:"
                    + rowErrors.Length);

                for (int i = 0; i < rowErrors.Length; i++)
                {
                    System.Diagnostics.Debug.WriteLine(rowErrors[i].RowError);

                    foreach (DataColumn col in rowErrors[i].GetColumnsInError())
                    {
                        System.Diagnostics.Debug.WriteLine(col.ColumnName
                            + ":" + rowErrors[i].GetColumnError(col));
                        //MessageBox.Show(col.ColumnName + ":" + rowErrors[i].GetColumnError(col));
                    }
                }
            }
        }
        private void PopulateStatusCombo()
        {
            cmbStatus.DataSource = bill.GetBillStatus(1);
            cmbStatus.DisplayMember = "name";
            cmbStatus.ValueMember = "id";
        }

        private void PopulateTypesCombo()
        {
            cmbType.DataSource = bill.GetBillTypes(1);
            cmbType.DisplayMember = "name";
            cmbType.ValueMember = "id";
        }


        private void btnReport_Click(object sender, EventArgs e)
        {
            populateReport();
        }

        private void frmRptBilling_Shown(object sender, EventArgs e)
        {
            populateReport();
        }
    }
}
