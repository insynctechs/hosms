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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void Hospital_Load(object sender, EventArgs e)
        {

        }

        private void patientToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void staffToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void doctorsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDoctors doc = new frmDoctors();
            doc.MdiParent = this;
            doc.Show();
        }
    }
}
