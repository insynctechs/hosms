﻿namespace HospitalERP
{
    partial class frmMain
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
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.menuItemMain = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDept = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemProc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemStaffType = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemProcType = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemUserRoles = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOpt = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemStaffs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDocs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemStaffGen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPatients = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemApp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemReg = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPatSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemBill = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemReports = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblEmpID = new System.Windows.Forms.Label();
            this.lnkLogout = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAppName = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.MainMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Font = new System.Drawing.Font("Calibri", 11F);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemMain,
            this.menuItemStaffs,
            this.menuItemPatients,
            this.menuItemBill,
            this.menuItemReports,
            this.menuItemAbout});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(918, 26);
            this.MainMenu.TabIndex = 1;
            this.MainMenu.Text = "menuStrip1";
            // 
            // menuItemMain
            // 
            this.menuItemMain.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemDept,
            this.menuItemProc,
            this.menuItemStaffType,
            this.menuItemProcType,
            this.menuItemUserRoles,
            this.menuItemOpt});
            this.menuItemMain.Name = "menuItemMain";
            this.menuItemMain.Size = new System.Drawing.Size(51, 22);
            this.menuItemMain.Text = "Main";
            // 
            // menuItemDept
            // 
            this.menuItemDept.Name = "menuItemDept";
            this.menuItemDept.Size = new System.Drawing.Size(178, 22);
            this.menuItemDept.Text = "Departments";
            this.menuItemDept.Click += new System.EventHandler(this.menuItemDept_Click);
            // 
            // menuItemProc
            // 
            this.menuItemProc.Name = "menuItemProc";
            this.menuItemProc.Size = new System.Drawing.Size(178, 22);
            this.menuItemProc.Text = "Procedures";
            this.menuItemProc.Click += new System.EventHandler(this.menuItemProc_Click);
            // 
            // menuItemStaffType
            // 
            this.menuItemStaffType.Name = "menuItemStaffType";
            this.menuItemStaffType.Size = new System.Drawing.Size(178, 22);
            this.menuItemStaffType.Text = "Staff Types";
            this.menuItemStaffType.Click += new System.EventHandler(this.menuItemStaffType_Click);
            // 
            // menuItemProcType
            // 
            this.menuItemProcType.Name = "menuItemProcType";
            this.menuItemProcType.Size = new System.Drawing.Size(178, 22);
            this.menuItemProcType.Text = "Procedure Types";
            this.menuItemProcType.Click += new System.EventHandler(this.menuItemProcType_Click);
            // 
            // menuItemUserRoles
            // 
            this.menuItemUserRoles.Name = "menuItemUserRoles";
            this.menuItemUserRoles.Size = new System.Drawing.Size(178, 22);
            this.menuItemUserRoles.Text = "User Roles";
            this.menuItemUserRoles.Click += new System.EventHandler(this.menuItemUserRoles_Click);
            // 
            // menuItemOpt
            // 
            this.menuItemOpt.Name = "menuItemOpt";
            this.menuItemOpt.Size = new System.Drawing.Size(178, 22);
            this.menuItemOpt.Text = "Options";
            this.menuItemOpt.Click += new System.EventHandler(this.menuItemOpt_Click);
            // 
            // menuItemStaffs
            // 
            this.menuItemStaffs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemDocs,
            this.menuItemStaffGen});
            this.menuItemStaffs.Name = "menuItemStaffs";
            this.menuItemStaffs.Size = new System.Drawing.Size(54, 22);
            this.menuItemStaffs.Text = "Staffs";
            // 
            // menuItemDocs
            // 
            this.menuItemDocs.Name = "menuItemDocs";
            this.menuItemDocs.Size = new System.Drawing.Size(125, 22);
            this.menuItemDocs.Text = "Doctors";
            this.menuItemDocs.Click += new System.EventHandler(this.menuItemDocs_Click);
            // 
            // menuItemStaffGen
            // 
            this.menuItemStaffGen.Name = "menuItemStaffGen";
            this.menuItemStaffGen.Size = new System.Drawing.Size(125, 22);
            this.menuItemStaffGen.Text = "General";
            this.menuItemStaffGen.Click += new System.EventHandler(this.menuItemStaffOthers_Click);
            // 
            // menuItemPatients
            // 
            this.menuItemPatients.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemApp,
            this.menuItemReg,
            this.menuItemPatSearch});
            this.menuItemPatients.Name = "menuItemPatients";
            this.menuItemPatients.Size = new System.Drawing.Size(70, 22);
            this.menuItemPatients.Text = "Patients";
            // 
            // menuItemApp
            // 
            this.menuItemApp.Name = "menuItemApp";
            this.menuItemApp.Size = new System.Drawing.Size(182, 22);
            this.menuItemApp.Text = "Appointments";
            // 
            // menuItemReg
            // 
            this.menuItemReg.Name = "menuItemReg";
            this.menuItemReg.Size = new System.Drawing.Size(182, 22);
            this.menuItemReg.Text = "New Registration";
            this.menuItemReg.Click += new System.EventHandler(this.menuItemReg_Click);
            // 
            // menuItemPatSearch
            // 
            this.menuItemPatSearch.Name = "menuItemPatSearch";
            this.menuItemPatSearch.Size = new System.Drawing.Size(182, 22);
            this.menuItemPatSearch.Text = "Search";
            // 
            // menuItemBill
            // 
            this.menuItemBill.Name = "menuItemBill";
            this.menuItemBill.Size = new System.Drawing.Size(59, 22);
            this.menuItemBill.Text = "Billing";
            // 
            // menuItemReports
            // 
            this.menuItemReports.Name = "menuItemReports";
            this.menuItemReports.Size = new System.Drawing.Size(68, 22);
            this.menuItemReports.Text = "Reports";
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Name = "menuItemAbout";
            this.menuItemAbout.Size = new System.Drawing.Size(58, 22);
            this.menuItemAbout.Text = "About";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(918, 100);
            this.panel1.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.47288F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.52712F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 256F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblAppName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(918, 100);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.4F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.6F));
            this.tableLayoutPanel2.Controls.Add(this.lblEmpID, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lnkLogout, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(664, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.3617F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.6383F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(250, 94);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // lblEmpID
            // 
            this.lblEmpID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEmpID.AutoSize = true;
            this.lblEmpID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpID.ForeColor = System.Drawing.Color.Aqua;
            this.lblEmpID.Location = new System.Drawing.Point(89, 15);
            this.lblEmpID.Name = "lblEmpID";
            this.lblEmpID.Size = new System.Drawing.Size(101, 21);
            this.lblEmpID.TabIndex = 2;
            this.lblEmpID.Text = "Super Admin";
            // 
            // lnkLogout
            // 
            this.lnkLogout.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lnkLogout.AutoSize = true;
            this.lnkLogout.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkLogout.ForeColor = System.Drawing.Color.White;
            this.lnkLogout.LinkColor = System.Drawing.Color.Snow;
            this.lnkLogout.Location = new System.Drawing.Point(89, 56);
            this.lnkLogout.Name = "lnkLogout";
            this.lnkLogout.Size = new System.Drawing.Size(52, 17);
            this.lnkLogout.TabIndex = 0;
            this.lnkLogout.TabStop = true;
            this.lnkLogout.Text = "Logout";
            this.lnkLogout.VisitedLinkColor = System.Drawing.Color.Orange;
            this.lnkLogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLogout_LinkClicked);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Aqua;
            this.label1.Location = new System.Drawing.Point(5, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome: ";
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new System.Drawing.Font("Cambria", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppName.ForeColor = System.Drawing.Color.AliceBlue;
            this.lblAppName.Location = new System.Drawing.Point(3, 0);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Padding = new System.Windows.Forms.Padding(20, 20, 0, 0);
            this.lblAppName.Size = new System.Drawing.Size(222, 64);
            this.lblAppName.TabIndex = 0;
            this.lblAppName.Text = "EEZCLINIC";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(270, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(388, 94);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 50);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(382, 41);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(918, 262);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MainMenu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MainMenu;
            this.Name = "frmMain";
            this.Text = " EEZCLINIC";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.Hospital_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemMain;
        private System.Windows.Forms.ToolStripMenuItem menuItemStaffs;
        private System.Windows.Forms.ToolStripMenuItem menuItemPatients;
        private System.Windows.Forms.ToolStripMenuItem menuItemStaffType;
        private System.Windows.Forms.ToolStripMenuItem menuItemProcType;
        private System.Windows.Forms.ToolStripMenuItem menuItemDocs;
        private System.Windows.Forms.ToolStripMenuItem menuItemStaffGen;
        private System.Windows.Forms.ToolStripMenuItem menuItemBill;
        private System.Windows.Forms.ToolStripMenuItem menuItemReports;
        private System.Windows.Forms.ToolStripMenuItem menuItemAbout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.ToolStripMenuItem menuItemApp;
        private System.Windows.Forms.ToolStripMenuItem menuItemReg;
        private System.Windows.Forms.ToolStripMenuItem menuItemPatSearch;
        private System.Windows.Forms.ToolStripMenuItem menuItemProc;
        private System.Windows.Forms.ToolStripMenuItem menuItemUserRoles;
        private System.Windows.Forms.ToolStripMenuItem menuItemDept;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpt;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEmpID;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.LinkLabel lnkLogout;
    }
}

