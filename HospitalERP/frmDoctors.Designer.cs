namespace HospitalERP
{
    partial class frmDoctors
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
            this.tabSub = new System.Windows.Forms.TabControl();
            this.tabPgAddDocs = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblgender = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblQualification = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNationality = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.lblHead1 = new System.Windows.Forms.Label();
            this.lblHead2 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.tabPgListDocs = new System.Windows.Forms.TabPage();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.tabSub.SuspendLayout();
            this.tabPgAddDocs.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSub
            // 
            this.tabSub.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabSub.Controls.Add(this.tabPgAddDocs);
            this.tabSub.Controls.Add(this.tabPgListDocs);
            this.tabSub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSub.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabSub.Location = new System.Drawing.Point(0, 0);
            this.tabSub.Margin = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.tabSub.Multiline = true;
            this.tabSub.Name = "tabSub";
            this.tabSub.Padding = new System.Drawing.Point(20, 10);
            this.tabSub.SelectedIndex = 0;
            this.tabSub.ShowToolTips = true;
            this.tabSub.Size = new System.Drawing.Size(1008, 627);
            this.tabSub.TabIndex = 2;
            this.tabSub.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabDoctors_DrawItem);
            // 
            // tabPgAddDocs
            // 
            this.tabPgAddDocs.BackColor = System.Drawing.Color.White;
            this.tabPgAddDocs.Controls.Add(this.tableLayoutPanel2);
            this.tabPgAddDocs.Location = new System.Drawing.Point(4, 45);
            this.tabPgAddDocs.Name = "tabPgAddDocs";
            this.tabPgAddDocs.Padding = new System.Windows.Forms.Padding(3);
            this.tabPgAddDocs.Size = new System.Drawing.Size(1000, 578);
            this.tabPgAddDocs.TabIndex = 0;
            this.tabPgAddDocs.Text = "Add Doctors";
            this.tabPgAddDocs.UseVisualStyleBackColor = true;
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
            this.tableLayoutPanel2.Controls.Add(this.textBox6, 1, 10);
            this.tableLayoutPanel2.Controls.Add(this.textBox5, 1, 9);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.lblgender, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.textBox2, 3, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblQualification, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.txtID, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblName, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblID, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label2, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblNationality, 2, 5);
            this.tableLayoutPanel2.Controls.Add(this.label3, 2, 9);
            this.tableLayoutPanel2.Controls.Add(this.textBox4, 3, 9);
            this.tableLayoutPanel2.Controls.Add(this.textBox7, 3, 10);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 10);
            this.tableLayoutPanel2.Controls.Add(this.label6, 2, 10);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 11);
            this.tableLayoutPanel2.Controls.Add(this.label7, 2, 11);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.textBox8, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.textBox10, 3, 11);
            this.tableLayoutPanel2.Controls.Add(this.lblHead1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblHead2, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.textBox11, 1, 11);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 2, 17);
            this.tableLayoutPanel2.Controls.Add(this.textBox1, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.textBox9, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel2, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.label12, 2, 7);
            this.tableLayoutPanel2.Controls.Add(this.label13, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.textBox13, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.dateTimePicker1, 3, 7);
            this.tableLayoutPanel2.Controls.Add(this.dateTimePicker2, 3, 5);
            this.tableLayoutPanel2.Controls.Add(this.label14, 0, 12);
            this.tableLayoutPanel2.Controls.Add(this.label15, 0, 14);
            this.tableLayoutPanel2.Controls.Add(this.textBox3, 1, 14);
            this.tableLayoutPanel2.Controls.Add(this.label16, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.textBox15, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label9, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.label10, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.comboBox1, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.textBox12, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.chkActive, 1, 17);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(25, 3, 25, 15);
            this.tableLayoutPanel2.RowCount = 19;
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
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(994, 572);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(169, 343);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(250, 25);
            this.textBox6.TabIndex = 13;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(169, 312);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(250, 25);
            this.textBox5.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 309);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "Address:";
            // 
            // lblgender
            // 
            this.lblgender.AutoSize = true;
            this.lblgender.Location = new System.Drawing.Point(28, 166);
            this.lblgender.Name = "lblgender";
            this.lblgender.Size = new System.Drawing.Size(58, 18);
            this.lblgender.TabIndex = 8;
            this.lblgender.Text = "Gender:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(640, 138);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(250, 25);
            this.textBox2.TabIndex = 4;
            // 
            // lblQualification
            // 
            this.lblQualification.AutoSize = true;
            this.lblQualification.Location = new System.Drawing.Point(28, 135);
            this.lblQualification.Name = "lblQualification";
            this.lblQualification.Size = new System.Drawing.Size(90, 18);
            this.lblQualification.TabIndex = 4;
            this.lblQualification.Text = "Qualification:";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(640, 75);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(250, 25);
            this.txtID.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(499, 72);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(79, 18);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Last Name: ";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(28, 72);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(79, 18);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "First Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(499, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Specialization:";
            // 
            // lblNationality
            // 
            this.lblNationality.AutoSize = true;
            this.lblNationality.Location = new System.Drawing.Point(499, 166);
            this.lblNationality.Name = "lblNationality";
            this.lblNationality.Size = new System.Drawing.Size(93, 18);
            this.lblNationality.TabIndex = 9;
            this.lblNationality.Text = "Date of Birth: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(499, 309);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 18);
            this.label3.TabIndex = 15;
            this.label3.Text = "City:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(640, 312);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(250, 25);
            this.textBox4.TabIndex = 12;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(640, 343);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(250, 25);
            this.textBox7.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 340);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 18);
            this.label4.TabIndex = 18;
            this.label4.Text = "District: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(499, 340);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 18);
            this.label6.TabIndex = 23;
            this.label6.Text = "PB No:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 371);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 18);
            this.label5.TabIndex = 21;
            this.label5.Text = "Phone:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(499, 371);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 18);
            this.label7.TabIndex = 24;
            this.label7.Text = "Email:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 239);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 18);
            this.label8.TabIndex = 25;
            this.label8.Text = "Pathaka ID:";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(169, 242);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(250, 25);
            this.textBox8.TabIndex = 9;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(640, 374);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(250, 25);
            this.textBox10.TabIndex = 16;
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
            this.lblHead1.Location = new System.Drawing.Point(28, 13);
            this.lblHead1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.lblHead1.Name = "lblHead1";
            this.lblHead1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.lblHead1.Size = new System.Drawing.Size(938, 28);
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
            this.lblHead2.Location = new System.Drawing.Point(28, 280);
            this.lblHead2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.lblHead2.Name = "lblHead2";
            this.lblHead2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.lblHead2.Size = new System.Drawing.Size(938, 29);
            this.lblHead2.TabIndex = 30;
            this.lblHead2.Text = "CONTACT DETAILS";
            this.lblHead2.UseWaitCursor = true;
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(169, 374);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(250, 25);
            this.textBox11.TabIndex = 15;
            // 
            // flowLayoutPanel1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(499, 475);
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(169, 75);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(250, 25);
            this.textBox1.TabIndex = 1;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(169, 138);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(250, 25);
            this.textBox9.TabIndex = 3;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.radioButton1);
            this.flowLayoutPanel2.Controls.Add(this.radioButton2);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(169, 169);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(173, 36);
            this.flowLayoutPanel2.TabIndex = 40;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(3, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(57, 22);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Male";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(66, 3);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(72, 22);
            this.radioButton2.TabIndex = 6;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Female";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(499, 239);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(134, 18);
            this.label12.TabIndex = 41;
            this.label12.Text = "Pathaka Expiry Date: ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(28, 208);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 18);
            this.label13.TabIndex = 42;
            this.label13.Text = "Nationality: ";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(169, 211);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(250, 25);
            this.textBox13.TabIndex = 8;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(640, 242);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(250, 25);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(640, 169);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(250, 25);
            this.dateTimePicker2.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.LightCyan;
            this.tableLayoutPanel2.SetColumnSpan(this.label14, 5);
            this.label14.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.DimGray;
            this.label14.Location = new System.Drawing.Point(28, 412);
            this.label14.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label14.Name = "label14";
            this.label14.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.label14.Size = new System.Drawing.Size(938, 29);
            this.label14.TabIndex = 46;
            this.label14.Text = "FEE DETAILS";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(28, 441);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(119, 18);
            this.label15.TabIndex = 47;
            this.label15.Text = "Consultation Fee: ";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(169, 444);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 25);
            this.textBox3.TabIndex = 17;
            // 
            // tabPgListDocs
            // 
            this.tabPgListDocs.BackColor = System.Drawing.Color.White;
            this.tabPgListDocs.Location = new System.Drawing.Point(4, 45);
            this.tabPgListDocs.Name = "tabPgListDocs";
            this.tabPgListDocs.Padding = new System.Windows.Forms.Padding(3);
            this.tabPgListDocs.Size = new System.Drawing.Size(1000, 578);
            this.tabPgListDocs.TabIndex = 1;
            this.tabPgListDocs.Text = "Search/List Doctors";
            this.tabPgListDocs.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(28, 41);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(86, 18);
            this.label16.TabIndex = 48;
            this.label16.Text = "Employee ID";
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(169, 44);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(250, 25);
            this.textBox15.TabIndex = 49;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(499, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 18);
            this.label9.TabIndex = 50;
            this.label9.Text = "Designation";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 18);
            this.label10.TabIndex = 51;
            this.label10.Text = "Department";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(169, 106);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(250, 26);
            this.comboBox1.TabIndex = 52;
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(640, 106);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(250, 25);
            this.textBox12.TabIndex = 53;
            // 
            // chkActive
            // 
            this.chkActive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(428, 475);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(65, 39);
            this.chkActive.TabIndex = 54;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // frmDoctors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1008, 627);
            this.ControlBox = false;
            this.Controls.Add(this.tabSub);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDoctors";
            this.Text = "Manage Doctors";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDoctors_Load);
            this.tabSub.ResumeLayout(false);
            this.tabPgAddDocs.ResumeLayout(false);
            this.tabPgAddDocs.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabSub;
        private System.Windows.Forms.TabPage tabPgAddDocs;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblgender;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblQualification;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNationality;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label lblHead1;
        private System.Windows.Forms.Label lblHead2;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TabPage tabPgListDocs;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.CheckBox chkActive;
    }
}