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
    public partial class frmRptPatient : Form
    {
        Patients pat = new Patients();

        public frmRptPatient()
        {
            InitializeComponent();
        }

        private void frmRptPatient_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSetPatient.uspReport_Patient' table. You can move, or remove it, as needed.
            //this.uspReport_PatientTableAdapter.Fill(this.DataSetPatient.uspReport_Patient);

            this.reportViewer.RefreshReport();
            PopulateSearch();
        }
        private void PopulateSearch()
        {
            cmbSearch.DataSource = pat.SearchValues(1);
            cmbSearch.ValueMember = "Value";
            cmbSearch.DisplayMember = "Display";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            populateReport();

        }

        private void populateReport()
        {
            try
            {
                this.uspReport_PatientTableAdapter.ClearBeforeFill = true;

                Microsoft.Reporting.WinForms.ReportParameter[] rparams = new Microsoft.Reporting.WinForms.ReportParameter[]
                {
                new Microsoft.Reporting.WinForms.ReportParameter("fromDate", dtFromDate.Value.Date.ToShortDateString()),
                new Microsoft.Reporting.WinForms.ReportParameter("toDate", dtToDate.Value.Date.ToShortDateString())
                };
                reportViewer.LocalReport.SetParameters(rparams);
                this.DataSetPatient.Clear();
                this.uspReport_PatientTableAdapter.Fill(this.DataSetPatient.uspReport_Patient, Convert.ToDateTime(dtFromDate.Value), Convert.ToDateTime(dtToDate.Value), cmbSearch.SelectedValue.ToString(), txtSearch.Text);
                this.reportViewer.RefreshReport();
            }
            catch (ConstraintException)
            {
                DataRow[] rowErrors = this.DataSetPatient.uspReport_Patient.GetErrors();

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

        private void frmRptPatient_Shown(object sender, EventArgs e)
        {
            populateReport();
        }
    }
}
