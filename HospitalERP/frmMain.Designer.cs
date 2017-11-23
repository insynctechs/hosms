namespace HospitalERP
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
            this.patientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patientToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.billingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doctorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.othersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultationFeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doctorsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.othersToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.patientToolStripMenuItem,
            this.staffToolStripMenuItem,
            this.patientToolStripMenuItem1,
            this.billingToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(918, 24);
            this.MainMenu.TabIndex = 1;
            this.MainMenu.Text = "menuStrip1";
            // 
            // patientToolStripMenuItem
            // 
            this.patientToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.doctorsToolStripMenuItem,
            this.othersToolStripMenuItem,
            this.consultationFeeToolStripMenuItem});
            this.patientToolStripMenuItem.Name = "patientToolStripMenuItem";
            this.patientToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.patientToolStripMenuItem.Text = "Main";
            this.patientToolStripMenuItem.Click += new System.EventHandler(this.patientToolStripMenuItem_Click);
            // 
            // staffToolStripMenuItem
            // 
            this.staffToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.doctorsToolStripMenuItem1,
            this.othersToolStripMenuItem1});
            this.staffToolStripMenuItem.Name = "staffToolStripMenuItem";
            this.staffToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.staffToolStripMenuItem.Text = "Staffs";
            this.staffToolStripMenuItem.Click += new System.EventHandler(this.staffToolStripMenuItem_Click);
            // 
            // patientToolStripMenuItem1
            // 
            this.patientToolStripMenuItem1.Name = "patientToolStripMenuItem1";
            this.patientToolStripMenuItem1.Size = new System.Drawing.Size(61, 20);
            this.patientToolStripMenuItem1.Text = "Patients";
            // 
            // billingToolStripMenuItem
            // 
            this.billingToolStripMenuItem.Name = "billingToolStripMenuItem";
            this.billingToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.billingToolStripMenuItem.Text = "Billing";
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // doctorsToolStripMenuItem
            // 
            this.doctorsToolStripMenuItem.Name = "doctorsToolStripMenuItem";
            this.doctorsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.doctorsToolStripMenuItem.Text = "Staff Types";
            // 
            // othersToolStripMenuItem
            // 
            this.othersToolStripMenuItem.Name = "othersToolStripMenuItem";
            this.othersToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.othersToolStripMenuItem.Text = "Procedures";
            // 
            // consultationFeeToolStripMenuItem
            // 
            this.consultationFeeToolStripMenuItem.Name = "consultationFeeToolStripMenuItem";
            this.consultationFeeToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.consultationFeeToolStripMenuItem.Text = "Registration Fee";
            // 
            // doctorsToolStripMenuItem1
            // 
            this.doctorsToolStripMenuItem1.Name = "doctorsToolStripMenuItem1";
            this.doctorsToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.doctorsToolStripMenuItem1.Text = "Doctors";
            this.doctorsToolStripMenuItem1.Click += new System.EventHandler(this.doctorsToolStripMenuItem1_Click);
            // 
            // othersToolStripMenuItem1
            // 
            this.othersToolStripMenuItem1.Name = "othersToolStripMenuItem1";
            this.othersToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.othersToolStripMenuItem1.Text = "Others";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(918, 262);
            this.Controls.Add(this.MainMenu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MainMenu;
            this.Name = "frmMain";
            this.Text = "Hospital ERP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Hospital_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem patientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem staffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patientToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem doctorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem othersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultationFeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doctorsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem othersToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem billingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

