using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalERP
{
    public partial class frmDoctors : Form
    {
        public frmDoctors()
        {
            InitializeComponent();
        }

        private void frmDoctors_Load(object sender, EventArgs e)
        {
            
            this.WindowState = FormWindowState.Maximized;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void tabDoctors_DrawItem(object sender, DrawItemEventArgs e)
        {
            Font fntTab;
            Brush bshBack;
            Brush bshFore;

            if (e.Index == this.tabSub.SelectedIndex)
            {
                fntTab = new Font(e.Font, FontStyle.Bold);
                bshBack = new System.Drawing.Drawing2D.LinearGradientBrush(e.Bounds, SystemColors.Control, SystemColors.Control, System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal);
                bshFore = Brushes.Black;
                //bshBack = new System.Drawing.Drawing2D.LinearGradientBrush(e.Bounds, Color.LightSkyBlue , Color.LightGreen, System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal);
                //bshFore = Brushes.Blue;
            }
            else
            {
                fntTab = e.Font;
                bshBack = new SolidBrush(Color.Red);
                bshFore = new SolidBrush(Color.Aqua);

                //bshBack = new SolidBrush(Color.White);
                //bshFore = new SolidBrush(Color.Black);
            }

            string tabName = this.tabSub.TabPages[e.Index].Text;
            StringFormat sftTab = new StringFormat();
            e.Graphics.FillRectangle(bshBack, e.Bounds);
            Rectangle recTab = e.Bounds;
            recTab = new Rectangle(recTab.X, recTab.Y + 4, recTab.Width, recTab.Height - 4);
            e.Graphics.DrawString(tabName, fntTab, bshFore, recTab, sftTab);

            /*if (e.Index == tabDoctors.SelectedIndex)
            {
                e.Graphics.FillRectangle(Brushes.MediumTurquoise, e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.LightCyan, e.Bounds);
            }*/
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            Rectangle lasttabrect = tabSub.GetTabRect(tabSub.TabPages.Count - 1);
            RectangleF emptyspacerect = new RectangleF(
                    lasttabrect.X + lasttabrect.Width + tabSub.Left,
                    tabSub.Top + lasttabrect.Y,
                    tabSub.Width - (lasttabrect.X + lasttabrect.Width),
                    lasttabrect.Height);

            Brush b = Brushes.BlueViolet; // the color you want
            e.Graphics.FillRectangle(b, emptyspacerect);
        }
    }
}
