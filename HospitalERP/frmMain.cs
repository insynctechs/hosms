using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalERP.Procedures;
using System.Windows.Forms;

namespace HospitalERP
{
    
    public partial class frmMain : Form
    {

        Users usr = new Users();
        
        public frmMain()
        {
            InitializeComponent();
        }

        public frmMain(string empid)
        {
            InitializeComponent();
            try
            { 
                DataTable dtUser = usr.GetLoggedUser(empid);
                lblEmpID.Text = empid;
                if (dtUser.Rows.Count > 0)
                {
                    LoggedUser.id = Int32.Parse(dtUser.Rows[0]["id"].ToString());
                    LoggedUser.emp_id = dtUser.Rows[0]["emp_id"].ToString();
                    LoggedUser.type_id = dtUser.Rows[0]["user_type_id"].ToString();
                    LoggedUser.type_name = dtUser.Rows[0]["type_name"].ToString();
                    LoggedUser.phone = dtUser.Rows[0]["staff_phone"].ToString();
                    LoggedUser.last_log_date = Convert.ToDateTime(dtUser.Rows[0]["log_date"].ToString());
                    usr.SetLoginDate(empid);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }
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

            //MainMenu.Items.RemoveByKey("menuItemMain");
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
            frmProcedures frm = new frmProcedures();
            frm.MdiParent = this;
            frm.Show();
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

        private void menuItemOpt_Click(object sender, EventArgs e)
        {
            frmOptions frm = new frmOptions();
            frm.MdiParent = this;
            frm.Show();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            closeChildren(this);
            
            
        }
        static void closeChildren(Form parent)
        {
            foreach (var child in parent.MdiChildren)
            {
                closeChildren(child);
                child.Close();
            }
        }
    }
}
