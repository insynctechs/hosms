namespace HospitalERP
{
    partial class frmReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataSetBilling = new HospitalERP.DataSetBilling();
            this.dataSetBillingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DataSetBilling)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetBillingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer
            // 
            this.reportViewer.LocalReport.ReportEmbeddedResource = "HospitalERP.Report.rdlc";
            this.reportViewer.LocalReport.ReportPath = "Report.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(12, 3);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(542, 246);
            this.reportViewer.TabIndex = 0;
            // 
            // DataSetBilling
            // 
            this.DataSetBilling.DataSetName = "DataSetBilling";
            this.DataSetBilling.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSetBillingBindingSource
            // 
            this.dataSetBillingBindingSource.DataSource = this.DataSetBilling;
            this.dataSetBillingBindingSource.Position = 0;
            // 
            // frmReport
            // 
            this.ClientSize = new System.Drawing.Size(566, 261);
            this.Controls.Add(this.reportViewer);
            this.Name = "frmReport";
            this.Load += new System.EventHandler(this.frmReport_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.DataSetBilling)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetBillingBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnReport;
        private Microsoft.Reporting.WinForms.ReportViewer rptBilling;
        private System.Windows.Forms.BindingSource uspReport_BillingBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource dataSetBillingBindingSource;
        private DataSetBilling DataSetBilling;
        private DataSetBillingTableAdapters.uspReport_BillingTableAdapter uspReport_BillingTableAdapter;
    }
}