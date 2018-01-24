namespace HospitalERP
{
    partial class frmStaffs
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabStaffs = new System.Windows.Forms.TabControl();
            this.tabPgAddStaffs = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDistrict = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblgender = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblNationality = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtZip = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPathaka = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblHead1 = new System.Windows.Forms.Label();
            this.lblHead2 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.rbGender1 = new System.Windows.Forms.RadioButton();
            this.rbGender2 = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.txtNationality = new System.Windows.Forms.TextBox();
            this.dtpPathakaExpiry = new System.Windows.Forms.DateTimePicker();
            this.dtpDob = new System.Windows.Forms.DateTimePicker();
            this.txtempid = new System.Windows.Forms.TextBox();
            this.lblQualification = new System.Windows.Forms.Label();
            this.txtQualification = new System.Windows.Forms.TextBox();
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.txtDesignation = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtUSERID = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblempid = new System.Windows.Forms.Label();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbStaffType = new System.Windows.Forms.ComboBox();
            this.lblActive = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.tabPgListStaffs = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbSearch = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvDept = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.designation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathaka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staff_type_title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabStaffs.SuspendLayout();
            this.tabPgAddStaffs.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            this.flowLayoutPanel7.SuspendLayout();
            this.tabPgListStaffs.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tabStaffs
            // 
            this.tabStaffs.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabStaffs.Controls.Add(this.tabPgAddStaffs);
            this.tabStaffs.Controls.Add(this.tabPgListStaffs);
            this.tabStaffs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabStaffs.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabStaffs.Location = new System.Drawing.Point(0, 0);
            this.tabStaffs.Margin = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.tabStaffs.Multiline = true;
            this.tabStaffs.Name = "tabStaffs";
            this.tabStaffs.Padding = new System.Drawing.Point(20, 10);
            this.tabStaffs.SelectedIndex = 0;
            this.tabStaffs.ShowToolTips = true;
            this.tabStaffs.Size = new System.Drawing.Size(1008, 627);
            this.tabStaffs.TabIndex = 2;
            this.tabStaffs.SelectedIndexChanged += new System.EventHandler(this.tabStaffs_SelectedIndexChanged);
            // 
            // tabPgAddStaffs
            // 
            this.tabPgAddStaffs.BackColor = System.Drawing.Color.White;
            this.tabPgAddStaffs.Controls.Add(this.tableLayoutPanel2);
            this.tabPgAddStaffs.Location = new System.Drawing.Point(4, 45);
            this.tabPgAddStaffs.Name = "tabPgAddStaffs";
            this.tabPgAddStaffs.Padding = new System.Windows.Forms.Padding(3);
            this.tabPgAddStaffs.Size = new System.Drawing.Size(1000, 578);
            this.tabPgAddStaffs.TabIndex = 0;
            this.tabPgAddStaffs.Text = "Add Staffs";
            this.tabPgAddStaffs.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoScroll = true;
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtDistrict, 1, 13);
            this.tableLayoutPanel2.Controls.Add(this.txtAddress, 1, 12);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 12);
            this.tableLayoutPanel2.Controls.Add(this.lblgender, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.txtLastName, 3, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblName, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblNationality, 2, 8);
            this.tableLayoutPanel2.Controls.Add(this.label3, 2, 12);
            this.tableLayoutPanel2.Controls.Add(this.txtCity, 3, 12);
            this.tableLayoutPanel2.Controls.Add(this.txtZip, 3, 13);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 13);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 14);
            this.tableLayoutPanel2.Controls.Add(this.label7, 2, 14);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 10);
            this.tableLayoutPanel2.Controls.Add(this.txtPathaka, 1, 10);
            this.tableLayoutPanel2.Controls.Add(this.txtEmail, 3, 14);
            this.tableLayoutPanel2.Controls.Add(this.lblHead1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblHead2, 0, 11);
            this.tableLayoutPanel2.Controls.Add(this.txtPhone, 1, 14);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 2, 19);
            this.tableLayoutPanel2.Controls.Add(this.txtFirstName, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel2, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.label13, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.txtNationality, 1, 9);
            this.tableLayoutPanel2.Controls.Add(this.dtpPathakaExpiry, 3, 10);
            this.tableLayoutPanel2.Controls.Add(this.dtpDob, 3, 8);
            this.tableLayoutPanel2.Controls.Add(this.txtempid, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblQualification, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.txtQualification, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.cmbDept, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.txtDesignation, 3, 6);
            this.tableLayoutPanel2.Controls.Add(this.txtID, 0, 20);
            this.tableLayoutPanel2.Controls.Add(this.label10, 2, 13);
            this.tableLayoutPanel2.Controls.Add(this.txtUSERID, 1, 20);
            this.tableLayoutPanel2.Controls.Add(this.lblStatus, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label12, 2, 10);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel4, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblempid, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel5, 2, 6);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel6, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel7, 2, 7);
            this.tableLayoutPanel2.Controls.Add(this.cmbStaffType, 3, 7);
            this.tableLayoutPanel2.Controls.Add(this.lblActive, 0, 17);
            this.tableLayoutPanel2.Controls.Add(this.chkActive, 1, 17);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(25, 3, 25, 15);
            this.tableLayoutPanel2.RowCount = 21;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(994, 572);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(491, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "*";
            // 
            // txtDistrict
            // 
            this.txtDistrict.Location = new System.Drawing.Point(167, 429);
            this.txtDistrict.Name = "txtDistrict";
            this.txtDistrict.Size = new System.Drawing.Size(250, 25);
            this.txtDistrict.TabIndex = 13;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(167, 398);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(250, 25);
            this.txtAddress.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 395);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "Address:";
            // 
            // lblgender
            // 
            this.lblgender.AutoSize = true;
            this.lblgender.Location = new System.Drawing.Point(28, 258);
            this.lblgender.Name = "lblgender";
            this.lblgender.Size = new System.Drawing.Size(58, 18);
            this.lblgender.TabIndex = 8;
            this.lblgender.Text = "Gender:";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(630, 166);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(250, 25);
            this.txtLastName.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(491, 163);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(79, 18);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Last Name: ";
            // 
            // lblNationality
            // 
            this.lblNationality.AutoSize = true;
            this.lblNationality.Location = new System.Drawing.Point(491, 258);
            this.lblNationality.Name = "lblNationality";
            this.lblNationality.Size = new System.Drawing.Size(93, 18);
            this.lblNationality.TabIndex = 9;
            this.lblNationality.Text = "Date of Birth: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(491, 395);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 18);
            this.label3.TabIndex = 15;
            this.label3.Text = "City:";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(630, 398);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(250, 25);
            this.txtCity.TabIndex = 12;
            // 
            // txtZip
            // 
            this.txtZip.Location = new System.Drawing.Point(630, 429);
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(250, 25);
            this.txtZip.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 426);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 18);
            this.label4.TabIndex = 18;
            this.label4.Text = "District: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 457);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 18);
            this.label5.TabIndex = 21;
            this.label5.Text = "Phone:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(491, 457);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 18);
            this.label7.TabIndex = 24;
            this.label7.Text = "Email:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 320);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 18);
            this.label8.TabIndex = 25;
            this.label8.Text = "Pathaka ID:";
            // 
            // txtPathaka
            // 
            this.txtPathaka.Location = new System.Drawing.Point(167, 323);
            this.txtPathaka.Name = "txtPathaka";
            this.txtPathaka.Size = new System.Drawing.Size(250, 25);
            this.txtPathaka.TabIndex = 9;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(630, 460);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(250, 25);
            this.txtEmail.TabIndex = 16;
            // 
            // lblHead1
            // 
            this.lblHead1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHead1.AutoSize = true;
            this.lblHead1.BackColor = System.Drawing.Color.LightCyan;
            this.tableLayoutPanel2.SetColumnSpan(this.lblHead1, 5);
            this.lblHead1.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHead1.ForeColor = System.Drawing.Color.DimGray;
            this.lblHead1.Location = new System.Drawing.Point(28, 84);
            this.lblHead1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.lblHead1.Name = "lblHead1";
            this.lblHead1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.lblHead1.Size = new System.Drawing.Size(921, 28);
            this.lblHead1.TabIndex = 29;
            this.lblHead1.Text = "PERSONAL DETAILS";
            this.lblHead1.UseWaitCursor = true;
            // 
            // lblHead2
            // 
            this.lblHead2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHead2.AutoSize = true;
            this.lblHead2.BackColor = System.Drawing.Color.LightCyan;
            this.tableLayoutPanel2.SetColumnSpan(this.lblHead2, 5);
            this.lblHead2.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHead2.ForeColor = System.Drawing.Color.DimGray;
            this.lblHead2.Location = new System.Drawing.Point(28, 366);
            this.lblHead2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.lblHead2.Name = "lblHead2";
            this.lblHead2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.lblHead2.Size = new System.Drawing.Size(921, 29);
            this.lblHead2.TabIndex = 30;
            this.lblHead2.Text = "CONTACT DETAILS";
            this.lblHead2.UseWaitCursor = true;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(167, 460);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(250, 25);
            this.txtPhone.TabIndex = 15;
            // 
            // flowLayoutPanel1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(491, 511);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 39);
            this.flowLayoutPanel1.TabIndex = 37;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 33);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(84, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 33);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(167, 166);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(250, 25);
            this.txtFirstName.TabIndex = 1;
            this.txtFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.txtFirstName_Validating);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.rbGender1);
            this.flowLayoutPanel2.Controls.Add(this.rbGender2);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(167, 261);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(173, 25);
            this.flowLayoutPanel2.TabIndex = 40;
            // 
            // rbGender1
            // 
            this.rbGender1.AutoSize = true;
            this.rbGender1.Checked = true;
            this.rbGender1.Location = new System.Drawing.Point(3, 3);
            this.rbGender1.Name = "rbGender1";
            this.rbGender1.Size = new System.Drawing.Size(57, 22);
            this.rbGender1.TabIndex = 5;
            this.rbGender1.TabStop = true;
            this.rbGender1.Text = "Male";
            this.rbGender1.UseVisualStyleBackColor = true;
            // 
            // rbGender2
            // 
            this.rbGender2.AutoSize = true;
            this.rbGender2.Location = new System.Drawing.Point(66, 3);
            this.rbGender2.Name = "rbGender2";
            this.rbGender2.Size = new System.Drawing.Size(72, 22);
            this.rbGender2.TabIndex = 6;
            this.rbGender2.TabStop = true;
            this.rbGender2.Text = "Female";
            this.rbGender2.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(28, 289);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 18);
            this.label13.TabIndex = 42;
            this.label13.Text = "Nationality: ";
            // 
            // txtNationality
            // 
            this.txtNationality.Location = new System.Drawing.Point(167, 292);
            this.txtNationality.Name = "txtNationality";
            this.txtNationality.Size = new System.Drawing.Size(250, 25);
            this.txtNationality.TabIndex = 8;
            // 
            // dtpPathakaExpiry
            // 
            this.dtpPathakaExpiry.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPathakaExpiry.Location = new System.Drawing.Point(630, 323);
            this.dtpPathakaExpiry.Name = "dtpPathakaExpiry";
            this.dtpPathakaExpiry.Size = new System.Drawing.Size(112, 25);
            this.dtpPathakaExpiry.TabIndex = 10;
            // 
            // dtpDob
            // 
            this.dtpDob.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDob.Location = new System.Drawing.Point(630, 261);
            this.dtpDob.Name = "dtpDob";
            this.dtpDob.Size = new System.Drawing.Size(112, 25);
            this.dtpDob.TabIndex = 7;
            // 
            // txtempid
            // 
            this.txtempid.Location = new System.Drawing.Point(167, 135);
            this.txtempid.Name = "txtempid";
            this.txtempid.ReadOnly = true;
            this.txtempid.Size = new System.Drawing.Size(250, 25);
            this.txtempid.TabIndex = 49;
            // 
            // lblQualification
            // 
            this.lblQualification.AutoSize = true;
            this.lblQualification.Location = new System.Drawing.Point(28, 226);
            this.lblQualification.Name = "lblQualification";
            this.lblQualification.Size = new System.Drawing.Size(90, 18);
            this.lblQualification.TabIndex = 4;
            this.lblQualification.Text = "Qualification:";
            // 
            // txtQualification
            // 
            this.txtQualification.Location = new System.Drawing.Point(167, 229);
            this.txtQualification.Name = "txtQualification";
            this.txtQualification.Size = new System.Drawing.Size(250, 25);
            this.txtQualification.TabIndex = 3;
            // 
            // cmbDept
            // 
            this.cmbDept.FormattingEnabled = true;
            this.cmbDept.Location = new System.Drawing.Point(167, 197);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(250, 26);
            this.cmbDept.TabIndex = 52;
            this.cmbDept.Validating += new System.ComponentModel.CancelEventHandler(this.cmbDept_Validating);
            // 
            // txtDesignation
            // 
            this.txtDesignation.Location = new System.Drawing.Point(630, 197);
            this.txtDesignation.Name = "txtDesignation";
            this.txtDesignation.Size = new System.Drawing.Size(250, 25);
            this.txtDesignation.TabIndex = 53;
            this.txtDesignation.Validating += new System.ComponentModel.CancelEventHandler(this.txtDesignation_Validating);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(28, 556);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 25);
            this.txtID.TabIndex = 60;
            this.txtID.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(491, 426);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 18);
            this.label10.TabIndex = 62;
            this.label10.Text = "PB No:";
            // 
            // txtUSERID
            // 
            this.txtUSERID.Location = new System.Drawing.Point(167, 556);
            this.txtUSERID.Name = "txtUSERID";
            this.txtUSERID.Size = new System.Drawing.Size(100, 25);
            this.txtUSERID.TabIndex = 63;
            this.txtUSERID.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Salmon;
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel2.SetColumnSpan(this.lblStatus, 2);
            this.lblStatus.Font = new System.Drawing.Font("Cambria", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.lblStatus.Location = new System.Drawing.Point(28, 23);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(3, 20, 3, 20);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Padding = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.lblStatus.Size = new System.Drawing.Size(42, 31);
            this.lblStatus.TabIndex = 64;
            this.lblStatus.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(491, 320);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 36);
            this.label12.TabIndex = 41;
            this.label12.Text = "Pathaka Expiry Date: ";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.label11);
            this.flowLayoutPanel4.Controls.Add(this.lblID);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(28, 166);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(133, 25);
            this.flowLayoutPanel4.TabIndex = 66;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 18);
            this.label11.TabIndex = 0;
            this.label11.Text = "*";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(24, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(79, 18);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "First Name:";
            // 
            // lblempid
            // 
            this.lblempid.AutoSize = true;
            this.lblempid.Location = new System.Drawing.Point(28, 132);
            this.lblempid.Name = "lblempid";
            this.lblempid.Size = new System.Drawing.Size(48, 18);
            this.lblempid.TabIndex = 48;
            this.lblempid.Text = "EMPID";
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.label16);
            this.flowLayoutPanel5.Controls.Add(this.label18);
            this.flowLayoutPanel5.Location = new System.Drawing.Point(491, 197);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(133, 25);
            this.flowLayoutPanel5.TabIndex = 66;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(3, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(15, 18);
            this.label16.TabIndex = 0;
            this.label16.Text = "*";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(24, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(85, 18);
            this.label18.TabIndex = 0;
            this.label18.Text = "Designation:";
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.Controls.Add(this.label17);
            this.flowLayoutPanel6.Controls.Add(this.label19);
            this.flowLayoutPanel6.Location = new System.Drawing.Point(28, 197);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(133, 25);
            this.flowLayoutPanel6.TabIndex = 66;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(3, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(15, 18);
            this.label17.TabIndex = 0;
            this.label17.Text = "*";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(24, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(87, 18);
            this.label19.TabIndex = 0;
            this.label19.Text = "Department:";
            // 
            // flowLayoutPanel7
            // 
            this.flowLayoutPanel7.Controls.Add(this.label2);
            this.flowLayoutPanel7.Controls.Add(this.label20);
            this.flowLayoutPanel7.Location = new System.Drawing.Point(491, 229);
            this.flowLayoutPanel7.Name = "flowLayoutPanel7";
            this.flowLayoutPanel7.Size = new System.Drawing.Size(133, 25);
            this.flowLayoutPanel7.TabIndex = 66;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "*";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(24, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(72, 18);
            this.label20.TabIndex = 0;
            this.label20.Text = "Staff Type:";
            // 
            // cmbStaffType
            // 
            this.cmbStaffType.FormattingEnabled = true;
            this.cmbStaffType.Location = new System.Drawing.Point(630, 229);
            this.cmbStaffType.Name = "cmbStaffType";
            this.cmbStaffType.Size = new System.Drawing.Size(250, 26);
            this.cmbStaffType.TabIndex = 52;
            this.cmbStaffType.Validating += new System.ComponentModel.CancelEventHandler(this.cmbStaffType_Validating);
            // 
            // lblActive
            // 
            this.lblActive.AutoSize = true;
            this.lblActive.Location = new System.Drawing.Point(28, 488);
            this.lblActive.Name = "lblActive";
            this.lblActive.Size = new System.Drawing.Size(50, 18);
            this.lblActive.TabIndex = 56;
            this.lblActive.Text = "Active:";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(167, 491);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(15, 14);
            this.chkActive.TabIndex = 57;
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // tabPgListStaffs
            // 
            this.tabPgListStaffs.BackColor = System.Drawing.Color.White;
            this.tabPgListStaffs.Controls.Add(this.flowLayoutPanel3);
            this.tabPgListStaffs.Controls.Add(this.dgvDept);
            this.tabPgListStaffs.Location = new System.Drawing.Point(4, 45);
            this.tabPgListStaffs.Name = "tabPgListStaffs";
            this.tabPgListStaffs.Padding = new System.Windows.Forms.Padding(3);
            this.tabPgListStaffs.Size = new System.Drawing.Size(1000, 578);
            this.tabPgListStaffs.TabIndex = 1;
            this.tabPgListStaffs.Text = "Search/List Staffs";
            this.tabPgListStaffs.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label9);
            this.flowLayoutPanel3.Controls.Add(this.cmbSearch);
            this.flowLayoutPanel3.Controls.Add(this.txtSearch);
            this.flowLayoutPanel3.Controls.Add(this.btnSearch);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Padding = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.flowLayoutPanel3.Size = new System.Drawing.Size(994, 80);
            this.flowLayoutPanel3.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(30, 25);
            this.label9.Margin = new System.Windows.Forms.Padding(30, 5, 3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 23);
            this.label9.TabIndex = 6;
            this.label9.Text = "Search";
            // 
            // cmbSearch
            // 
            this.cmbSearch.BackColor = System.Drawing.Color.LightCyan;
            this.cmbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearch.FormattingEnabled = true;
            this.cmbSearch.Location = new System.Drawing.Point(98, 23);
            this.cmbSearch.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.cmbSearch.Name = "cmbSearch";
            this.cmbSearch.Size = new System.Drawing.Size(150, 27);
            this.cmbSearch.TabIndex = 5;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(271, 23);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 27);
            this.txtSearch.TabIndex = 7;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(494, 23);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(59, 29);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "GO";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvDept
            // 
            this.dgvDept.AllowUserToAddRows = false;
            this.dgvDept.AllowUserToDeleteRows = false;
            this.dgvDept.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDept.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDept.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvDept.BackgroundColor = System.Drawing.Color.White;
            this.dgvDept.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDept.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvDept.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDept.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDept.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDept.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.EmpID,
            this.colName,
            this.dept,
            this.designation,
            this.phone,
            this.gender,
            this.pathaka,
            this.staff_type_title,
            this.colActive});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDept.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDept.GridColor = System.Drawing.Color.LightCyan;
            this.dgvDept.Location = new System.Drawing.Point(3, 89);
            this.dgvDept.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.dgvDept.Name = "dgvDept";
            this.dgvDept.ReadOnly = true;
            this.dgvDept.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDept.Size = new System.Drawing.Size(980, 456);
            this.dgvDept.TabIndex = 12;
            this.dgvDept.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDept_RowHeaderMouseClick);
            // 
            // colID
            // 
            this.colID.DataPropertyName = "id";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            // 
            // EmpID
            // 
            this.EmpID.DataPropertyName = "emp_id";
            this.EmpID.HeaderText = "Employee ID";
            this.EmpID.Name = "EmpID";
            this.EmpID.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "name";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // dept
            // 
            this.dept.DataPropertyName = "department";
            this.dept.HeaderText = "Department";
            this.dept.Name = "dept";
            this.dept.ReadOnly = true;
            // 
            // designation
            // 
            this.designation.DataPropertyName = "designation";
            this.designation.HeaderText = "Designation";
            this.designation.Name = "designation";
            this.designation.ReadOnly = true;
            // 
            // phone
            // 
            this.phone.DataPropertyName = "phone";
            this.phone.HeaderText = "Phone";
            this.phone.Name = "phone";
            this.phone.ReadOnly = true;
            // 
            // gender
            // 
            this.gender.DataPropertyName = "gender";
            this.gender.HeaderText = "Gender";
            this.gender.Name = "gender";
            this.gender.ReadOnly = true;
            // 
            // pathaka
            // 
            this.pathaka.DataPropertyName = "pathaka";
            this.pathaka.HeaderText = "Pathaka";
            this.pathaka.Name = "pathaka";
            this.pathaka.ReadOnly = true;
            // 
            // staff_type_title
            // 
            this.staff_type_title.DataPropertyName = "type_title";
            this.staff_type_title.HeaderText = "Staff Type";
            this.staff_type_title.Name = "staff_type_title";
            this.staff_type_title.ReadOnly = true;
            // 
            // colActive
            // 
            this.colActive.DataPropertyName = "active";
            this.colActive.HeaderText = "Active";
            this.colActive.Name = "colActive";
            this.colActive.ReadOnly = true;
            this.colActive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmStaffs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1008, 627);
            this.ControlBox = false;
            this.Controls.Add(this.tabStaffs);
            this.Name = "frmStaffs";
            this.Text = "Manage Staffs";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmStaffs_Load);
            this.tabStaffs.ResumeLayout(false);
            this.tabPgAddStaffs.ResumeLayout(false);
            this.tabPgAddStaffs.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
            this.flowLayoutPanel7.ResumeLayout(false);
            this.flowLayoutPanel7.PerformLayout();
            this.tabPgListStaffs.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabStaffs;
        private System.Windows.Forms.TabPage tabPgAddStaffs;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox txtDistrict;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblgender;
        private System.Windows.Forms.Label lblQualification;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblNationality;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtZip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPathaka;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblHead1;
        private System.Windows.Forms.Label lblHead2;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TabPage tabPgListStaffs;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtQualification;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.RadioButton rbGender1;
        private System.Windows.Forms.RadioButton rbGender2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtNationality;
        private System.Windows.Forms.DateTimePicker dtpPathakaExpiry;
        private System.Windows.Forms.DateTimePicker dtpDob;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblempid;
        private System.Windows.Forms.TextBox txtempid;
        private System.Windows.Forms.ComboBox cmbDept;
        private System.Windows.Forms.TextBox txtDesignation;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvDept;
        private System.Windows.Forms.Label lblActive;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtUSERID;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cmbStaffType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dept;
        private System.Windows.Forms.DataGridViewTextBoxColumn designation;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathaka;
        private System.Windows.Forms.DataGridViewTextBoxColumn staff_type_title;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colActive;
    }
}