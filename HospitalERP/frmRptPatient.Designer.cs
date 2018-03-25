﻿namespace HospitalERP
{
    partial class frmRptPatient
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.uspReport_PatientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetPatient = new HospitalERP.DataSetPatient();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.cmbSearch = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.uspReport_PatientTableAdapter = new HospitalERP.DataSetPatientTableAdapters.uspReport_PatientTableAdapter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.uspReport_PatientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetPatient)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // uspReport_PatientBindingSource
            // 
            this.uspReport_PatientBindingSource.DataMember = "uspReport_Patient";
            this.uspReport_PatientBindingSource.DataSource = this.DataSetPatient;
            // 
            // DataSetPatient
            // 
            this.DataSetPatient.DataSetName = "DataSetPatient";
            this.DataSetPatient.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtFromDate
            // 
            this.dtFromDate.Location = new System.Drawing.Point(15, 12);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(173, 20);
            this.dtFromDate.TabIndex = 10;
            this.dtFromDate.Value = new System.DateTime(2018, 2, 5, 0, 0, 0, 0);
            // 
            // dtToDate
            // 
            this.dtToDate.Location = new System.Drawing.Point(218, 12);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(153, 20);
            this.dtToDate.TabIndex = 11;
            // 
            // cmbSearch
            // 
            this.cmbSearch.BackColor = System.Drawing.Color.LightCyan;
            this.cmbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearch.FormattingEnabled = true;
            this.cmbSearch.Location = new System.Drawing.Point(400, 12);
            this.cmbSearch.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.cmbSearch.Name = "cmbSearch";
            this.cmbSearch.Size = new System.Drawing.Size(191, 21);
            this.cmbSearch.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(629, 13);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 20);
            this.txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSearch.Location = new System.Drawing.Point(852, 10);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(59, 29);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "GO";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // reportViewer
            // 
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsPatient";
            reportDataSource1.Value = this.uspReport_PatientBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "HospitalERP.ReportPatient.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(0, 0);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(950, 270);
            this.reportViewer.TabIndex = 0;
            // 
            // uspReport_PatientTableAdapter
            // 
            this.uspReport_PatientTableAdapter.ClearBeforeFill = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.reportViewer);
            this.panel1.Location = new System.Drawing.Point(12, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(950, 270);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbSearch);
            this.panel2.Controls.Add(this.dtToDate);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.dtFromDate);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(950, 47);
            this.panel2.TabIndex = 5;
            // 
            // frmRptPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 337);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmRptPatient";
            this.Text = "frmRptPatient";
            this.Load += new System.EventHandler(this.frmRptPatient_Load);
            this.Shown += new System.EventHandler(this.frmRptPatient_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.uspReport_PatientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetPatient)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource uspReport_PatientBindingSource;
        private DataSetPatient DataSetPatient;
        private DataSetPatientTableAdapters.uspReport_PatientTableAdapter uspReport_PatientTableAdapter;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}