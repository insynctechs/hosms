using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HospitalERP.Procedures;
using HospitalERP.Helpers;

namespace HospitalERP
{
    public partial class frmConsultationBill : Form
    {
        public int appointment_id = 0;
        public int patient_id = 0;

        log4net.ILog ilog;
        Bill bill = new Bill();
        Appointments app = new Appointments();
        Patients pat = new Patients();

        public frmConsultationBill()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
            ilog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public frmConsultationBill(int app_id, int pat_id)
        {
            InitializeComponent();
            appointment_id = app_id;
            patient_id = pat_id;
            log4net.Config.XmlConfigurator.Configure();
            ilog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {

            printDialog1.PrinterSettings.DefaultPageSettings.Landscape = true;            
            printDialog1.PrinterSettings.DefaultPageSettings.PaperSize.RawKind = (int)PaperKind.A5;
            
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                PrinterSettings values = new PrinterSettings();                            
                printDialog1.Document = printDocument1;                
                printDocument1.Print();
            }
            printDocument1.Dispose();
           
        }



        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
          
            Bitmap bmp = new Bitmap(panelContent.Width, panelContent.Height, panelContent.CreateGraphics());
            panelContent.DrawToBitmap(bmp, new Rectangle(0, 0, panelContent.Width, panelContent.Height));
            RectangleF bounds = e.PageSettings.PrintableArea;
            float factor = ((float)bmp.Height / (float)bmp.Width);
            e.Graphics.DrawImage(bmp, bounds.Left, bounds.Top, bounds.Width, factor * bounds.Width);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
           
            printDialog1.PrinterSettings.DefaultPageSettings.Landscape = true;
            printDialog1.PrinterSettings.DefaultPageSettings.PaperSize.RawKind = (int)PaperKind.A5;
            printDialog1.PrintToFile = true;

            printDialog1.Document = printDocument1;
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void frmConsultationBill_Load(object sender, EventArgs e)
        {
            dgvInv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvInv.Rows.Add(new object[] { "1", "Consulation Fees and Charges", "150.00" });
            
        }

        
    }
}
