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
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    System.Windows.Forms.Control Mdi = (MdiClient)ctl;

                    Mdi.BackColor = System.Drawing.Color.White;
                }
                catch (Exception a)
                {

                }
            }
        }
        

        private void menuItemStaffOthers_Click(object sender, EventArgs e)
        {
            frmStaffs frm = new frmStaffs();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuItemDocs_Click(object sender, EventArgs e)
        {
            frmDoctors frm = new frmDoctors();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuItemStaffType_Click(object sender, EventArgs e)
        {
            
            frmStaffTypes frm = new frmStaffTypes();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuItemDept_Click(object sender, EventArgs e)
        {
            frmDepartments frm = new frmDepartments();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuItemProc_Click(object sender, EventArgs e)
        {

        }

        private void menuItemUserRoles_Click(object sender, EventArgs e)
        {
            frmUserRoles frm = new frmUserRoles();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuItemProcType_Click(object sender, EventArgs e)
        {
            frmProcTypes frm = new frmProcTypes();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
