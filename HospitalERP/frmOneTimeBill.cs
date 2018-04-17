﻿using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using HospitalERP.Procedures;
using HospitalERP.Helpers;
namespace HospitalERP
{
    public partial class frmOneTimeBill : Form
    {
        public int appointment_id = 0;
        public int patient_id = 0;
        public int bill_id = 0;
        public double bill_total = 0;
        public double bill_paid = 0;
        public double bill_balance = 0;
        public DataTable dtProc;

        
        Bill bill = new Bill();
        Appointments app = new Appointments();
        Patients pat = new Patients();
        ConsultationDetails objCD = new ConsultationDetails();
        OptionVals opt = new OptionVals();
        DataTable dtPat;
        DataTable dtBill;

        public int cell_modified = 0;
        public frmOneTimeBill()
        {
            InitializeComponent();
        }

        public frmOneTimeBill(int app_id, int pat_id)
        {
            try
            {
                InitializeComponent();
                appointment_id = app_id;
                patient_id = pat_id;
                loadPatientAppInfo();
                PopulateStatusCombo();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }


        }

        public frmOneTimeBill(int b_id)
        {
            try
            {
                InitializeComponent();
                bill_id = b_id;
                dtBill = bill.GetBill(bill_id);
                appointment_id = Int32.Parse(dtBill.Rows[0]["appointment_id"].ToString());
                patient_id = Int32.Parse(dtBill.Rows[0]["patient_id"].ToString());
                loadPatientAppInfo();
                PopulateStatusCombo();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }
        private void PopulateStatusCombo()
        {
            try
            {
                cmbBillStatus.DataSource = bill.GetBillStatus();
                cmbBillStatus.DisplayMember = "name";
                cmbBillStatus.ValueMember = "id";
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void loadPatientAppInfo()
        {
            try
            {
                dtPat = pat.getDetailedPatientRecordFromID(patient_id, appointment_id);
                txtPatNum.Text = dtPat.Rows[0]["patient_number"].ToString();
                txtPatName.Text = dtPat.Rows[0]["patient_name"].ToString();
                string gender = dtPat.Rows[0]["gender"].ToString();
                txtGender.Text = Utils.Gender[gender].ToString();
                txtAge.Text = dtPat.Rows[0]["age"].ToString();
                txtNationality.Text = dtPat.Rows[0]["nationality"].ToString();
                txtAddress.Text = Utils.FormatAddress(dtPat.Rows[0]["address"].ToString(), dtPat.Rows[0]["city"].ToString(), dtPat.Rows[0]["state"].ToString(), dtPat.Rows[0]["zip"].ToString());
                //txtMeetDate.Text = Convert.ToDateTime(dtPat.Rows[0]["meet_date"].ToString()).ToShortDateString();
                txtDoctor.Text = dtPat.Rows[0]["doctor_name"].ToString();
                txtToken.Text = dtPat.Rows[0]["token"].ToString().PadLeft(3, '0');
                txtAppId.Text = dtPat.Rows[0]["appointment_id"].ToString().PadLeft(6, '0');
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

            return;
        }
        private void dgvInv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if ((e.RowIndex == -1 || e.RowIndex == dgvInv.RowCount - 1) && e.ColumnIndex >= 0)
                {
                    //if (dgvInv.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected == true)
                    //{
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);
                    using (Pen p = new Pen(Color.Black, 1))
                    {
                        System.Drawing.Rectangle rect = e.CellBounds;
                        rect.Width -= 2;
                        rect.Height -= 2;
                        //p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        e.Graphics.DrawLine(p, new Point(0, e.CellBounds.Bottom - 1), new Point(e.CellBounds.Right, e.CellBounds.Bottom - 1));

                        //e.Graphics.DrawRectangle(p, rect);

                    }
                    e.Handled = true;

                    // }
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void frmOneTimeBill_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtOpt = opt.GetOptionFromName("CLINIC_NAME");
                DataTable dtRec = new DataTable();
                dtRec.Columns.Add("appointment_id", typeof(int));
                dtRec.Columns.Add("item_no", typeof(int));
                dtRec.Columns.Add("item_name", typeof(string));
                dtRec.Columns.Add("item_amount", typeof(float));
                if (dtOpt.Rows.Count > 0)
                    lblClinic.Text = dtOpt.Rows[0]["op_value"].ToString();

                bill_total = 0;
                int k = 1;

                //displaying data to grid view
                dgvInv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                //if this appointment has bill details then get records from details table
                //else for initial loading take from appt procedures
                dtProc = bill.getBillDetails(appointment_id);
                if (dtProc == null || dtProc.Rows.Count==0)
                {
                    dtProc = objCD.getProceduresInvoiceFromApptID(appointment_id);
                    bill_total += Convert.ToDouble(dtPat.Rows[0]["doctor_fee"].ToString());
                    k = 2;
                    dtRec.Rows.Add(appointment_id, 1, "Consultation Fees and Charges", Convert.ToDouble(dtPat.Rows[0]["doctor_fee"].ToString()));
                    dgvInv.Rows.Add(new object[] { "1", "Consultation Fees and Charges", Utils.FormatAmount(Convert.ToDouble(dtPat.Rows[0]["doctor_fee"].ToString())) });
                }
                

                foreach (DataRow row in dtProc.Rows)
                {
                    dgvInv.Rows.Add(new object[] { k, row["name"].ToString(), row["fee"].ToString() });
                    dtRec.Rows.Add(appointment_id, k, row["name"].ToString(), Convert.ToDouble(row["fee"].ToString()));
                    bill_total += Convert.ToDouble(row["fee"].ToString());
                    k++;                    
                }

                
                txtTotal.Text = Utils.FormatAmount(bill_total);

                if (bill_id == 0)
                {
                    dtBill = bill.GetAppointmentBill(appointment_id, patient_id, 3);
                    if (dtBill.Rows.Count == 0)
                    {
                        if (!(LoggedUser.id > 0))
                            LoggedUser.id = 1;
                        //sj bill_id = bill.AddBill(appointment_id, patient_id, Convert.ToDecimal(dtPat.Rows[0]["doctor_fee"].ToString()), 1, LoggedUser.id);
                        bill_id = bill.AddBill(appointment_id, patient_id, Convert.ToDecimal(bill_total), 3, LoggedUser.id);

                        //add details to bill_details table
                        bill.UpdateBillDetails(dtRec, appointment_id);
                        if (bill_id > 0)
                        {
                            dtBill = bill.GetBill(bill_id);
                        }
                        else
                        {
                            MessageBox.Show("Error in Creating Bill");
                        }
                    }
                    else
                    {
                        bill_id = Int32.Parse(dtBill.Rows[0]["id"].ToString());
                    }
                }
                if (bill_id > 0)
                {
                    txtInvNum.Text = dtBill.Rows[0]["bill_number"].ToString();
                    txtDate.Text = Convert.ToDateTime(dtPat.Rows[0]["meet_date"].ToString()).ToShortDateString();
                    bill_total = Convert.ToDouble(dtBill.Rows[0]["bill_amount"].ToString());
                    bill_paid = Convert.ToDouble(dtBill.Rows[0]["bill_paid"].ToString());
                    txtPaid.Text = Utils.FormatAmount(bill_paid);
                    bill_balance = Convert.ToDouble(dtBill.Rows[0]["bill_balance"].ToString());
                    txtBalance.Text = Utils.FormatAmount(bill_balance);
                    lblTime.Text = dtBill.Rows[0]["bill_date"].ToString();
                    int creator = Int32.Parse(dtBill.Rows[0]["bill_created_userid"].ToString());
                    txtPrevDues.Text = dtPat.Rows[0]["dues"].ToString();
                    txtTotal.Text = Utils.FormatAmount(bill_total + Convert.ToDouble(txtPrevDues.Text));
                    DataTable dtUser = bill.GetBillCreatedUser(creator);
                    if (dtUser != null)
                        txtLoggedUser.Text = dtUser.Rows[0]["staff_name"].ToString();
                    cmbBillStatus.SelectedValue = dtBill.Rows[0]["bill_status"].ToString();
                    if (dtBill.Rows[0]["bill_status"].ToString() == "4")
                    {
                        txtPaid.ReadOnly = true;
                        dgvInv.ReadOnly = true;
                        btnSave.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void dgvInv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            decimal fee_total = 0;
            try
            {
                if (e.ColumnIndex == 2)
                {
                    for (int m = 0; m < dgvInv.RowCount - 1; m++)
                        fee_total += Convert.ToDecimal(dgvInv.Rows[m].Cells["Amount"].Value.ToString());

                    fee_total += Convert.ToDecimal(txtPrevDues.Text.ToString());
                    txtTotal.Text = fee_total.ToString();
                    cell_modified = 1;
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bill_total = Convert.ToDouble(txtTotal.Text);
                bill_balance = bill_total - bill_paid;
                txtBalance.Text = Utils.FormatAmount(bill_balance);
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }


        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bill_paid = Convert.ToDouble(txtPaid.Text);
                bill_balance = bill_total - bill_paid;
                txtBalance.Text = Utils.FormatAmount(bill_balance);
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Int32.Parse(cmbBillStatus.SelectedValue.ToString()) == 4 && bill_balance != 0)
                {
                    MessageBox.Show("The entire bill needs to be paid fully for 'Paid' Status");
                }
                else if (Int32.Parse(cmbBillStatus.SelectedValue.ToString()) != 4 && bill_balance == 0)
                {
                    MessageBox.Show("Please change the status to 'Paid'");
                }
                else if (Int32.Parse(cmbBillStatus.SelectedValue.ToString()) != 2 && Int32.Parse(cmbBillStatus.SelectedValue.ToString()) != 3 && bill_balance != 0)
                {
                    if (bill_balance != bill_total)
                        MessageBox.Show("Please change the status to 'Partial-Paid'");
                }
                else
                {
                    if (!(LoggedUser.id > 0))
                        LoggedUser.id = 1;
                    int res = bill.editBill(bill_id, Convert.ToDecimal(bill_total), Convert.ToDecimal(bill_paid), Convert.ToDecimal(bill_balance), Int32.Parse(cmbBillStatus.SelectedValue.ToString()), LoggedUser.id);
                    if (cmbBillStatus.SelectedValue.ToString() == "4")
                    {
                        txtPaid.ReadOnly = true;
                        dgvInv.ReadOnly = true;
                        btnSave.Enabled = false;
                    }

                    if (cell_modified == 1) //edit in patient_procedures table
                    { 
                        res = objCD.editProceduresFees(dtProc);
                        //edit bill details table
                        DataTable dtRec = new DataTable();
                        dtRec.Columns.Add("appointment_id", typeof(int));
                        dtRec.Columns.Add("item_no", typeof(int));
                        dtRec.Columns.Add("item_name", typeof(string));
                        dtRec.Columns.Add("item_amount", typeof(float));

                        foreach (DataGridViewRow row in dgvInv.Rows)
                        {      
                            if(row.Cells[0].Value!=null)
                                dtRec.Rows.Add(appointment_id, Convert.ToInt32(row.Cells[0].Value.ToString()), row.Cells[1].Value.ToString(), Convert.ToDouble(row.Cells[2].Value.ToString()));
                          
                        }
                        res = bill.UpdateBillDetails(dtRec, appointment_id);
                    }
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                printDialog1.PrinterSettings.DefaultPageSettings.Landscape = true;
                printDialog1.PrinterSettings.DefaultPageSettings.PaperSize.RawKind = (int)PaperKind.A5;
                if (chkLetterHead.Checked == true)
                {
                    int top = 100; int bottom = 100;
                    DataTable dtOpt = opt.GetOptionFromName("PRINT_LETTERHEAD_MARGIN_TOP");
                    if (dtOpt.Rows.Count > 0)
                        top = Int32.Parse(dtOpt.Rows[0]["op_value"].ToString());
                    dtOpt = opt.GetOptionFromName("PRINT_LETTERHEAD_MARGIN_BOTTOM");
                    if (dtOpt.Rows.Count > 0)
                        bottom = Int32.Parse(dtOpt.Rows[0]["op_value"].ToString());
                    printDialog1.PrinterSettings.DefaultPageSettings.Margins.Top = top;
                    printDialog1.PrinterSettings.DefaultPageSettings.Margins.Bottom = bottom;

                }

                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    PrinterSettings values = new PrinterSettings();
                    printDialog1.Document = printDocument1;
                    printDocument1.Print();
                }
                printDocument1.Dispose();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                if (chkLetterHead.Checked == true)
                    lblClinic.Visible = false;
                Bitmap bmp = new Bitmap(panelContent.Width, panelContent.Height, panelContent.CreateGraphics());
                panelContent.DrawToBitmap(bmp, new Rectangle(0, 0, panelContent.Width, panelContent.Height));
                RectangleF bounds = e.PageSettings.PrintableArea;
                float factor = ((float)bmp.Height / (float)bmp.Width);
                e.Graphics.DrawImage(bmp, bounds.Left, bounds.Top, bounds.Width, factor * bounds.Width);
                if (chkLetterHead.Checked == true)
                    lblClinic.Visible = true;
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void dgvInv_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText =
            dgvInv.Columns[e.ColumnIndex].HeaderText;

            // Abort validation if cell is not in the CompanyName column.
            if (!headerText.Equals("Amount")) return;

            // Confirm that the cell is not empty.
            if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                dgvInv.Rows[e.RowIndex].ErrorText = "Amount must not be empty";
                e.Cancel = true;
            }
        }

        private void dgvInv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvInv.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void cmbBillStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBillStatus.SelectedValue.ToString() == "3" || cmbBillStatus.SelectedValue.ToString() == "4")
            {
                foreach (DataGridViewRow row in dgvInv.Rows)
                {
                    row.Cells[2].ReadOnly = true;
                    row.Cells[1].ReadOnly = true;
                }
            }
            else 
            {
                foreach (DataGridViewRow row in dgvInv.Rows)
                {
                    row.Cells[1].ReadOnly = false;
                    row.Cells[2].ReadOnly = false;
                }
            }
        }
    }
}