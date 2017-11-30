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
            
            if (e.Index == tabDoctors.SelectedIndex)
            {
                e.Graphics.FillRectangle(Brushes.MediumTurquoise, e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.LightCyan, e.Bounds);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
