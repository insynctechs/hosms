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
using HospitalERP.Helpers;
namespace HospitalERP
{
    public partial class frmProceduresBill : Form
    {
        public int appointment_id = 0;
        public int patient_id = 0;

        log4net.ILog ilog;
        Bill bill = new Bill();
        Appointments app = new Appointments();
        Patients pat = new Patients();

        public frmProceduresBill()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
            ilog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public frmProceduresBill(int app_id, int pat_id)
        {
            InitializeComponent();
            appointment_id = app_id;
            patient_id = pat_id;
            log4net.Config.XmlConfigurator.Configure();
            ilog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        private void dgvInv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void frmProceduresBill_Load(object sender, EventArgs e)
        {
            dgvInv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        }
    }
}
