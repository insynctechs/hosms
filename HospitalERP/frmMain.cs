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
        Menus mn = new Menus();

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
                    LoggedUser.type_id = Int32.Parse(dtUser.Rows[0]["user_type_id"].ToString());
                    LoggedUser.type_name = dtUser.Rows[0]["type_name"].ToString();
                    LoggedUser.phone = dtUser.Rows[0]["staff_phone"].ToString();
                    LoggedUser.last_log_date = Convert.ToDateTime(dtUser.Rows[0]["log_date"].ToString());
                    LoggedUser.name = dtUser.Rows[0]["staff_name"].ToString();
                    LoggedUser.staff_id = Int32.Parse(dtUser.Rows[0]["staff_id"].ToString());
                    LoggedUser.phone = dtUser.Rows[0]["staff_phone"].ToString();
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
            if(LoggedUser.id > 0)
            {
                SetMenuItems();
                lnkChangePwd.Visible = true;
                tblLoginPanel.Visible = true;
            }
            else
            {
                lnkChangePwd.Visible = false;
                tblLoginPanel.Visible = false;
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

        private void SetMenuItems()
        {
            DataTable dtMenu = mn.GetUserTypeMenusRemoveList(LoggedUser.type_id);
            foreach(DataRow dr in dtMenu.Rows)
            {
                string menu_name = dr["menu_name"].ToString();
                MainMenu.Items.RemoveByKey(menu_name);
            }
        }

        private void menuItemReg_Click(object sender, EventArgs e)
        {
            frmPatient frm = new frmPatient();
            frm.MdiParent = this;
            frm.Show();
        }

        private void lnkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void menuItemApp_Click(object sender, EventArgs e)
        {
            if (LoggedUser.type_name.ToUpper() == "DOCTOR")
            {
                frmConsultations frm = new frmConsultations();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {

                frmAppointments frm = new frmAppointments();
                frm.MdiParent = this;
                frm.Show();
            }
        }
        

        private void menuItemBillSearch_Click(object sender, EventArgs e)
        {
            frmBilling frm = new frmBilling();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuItemPatSearch_Click(object sender, EventArgs e)
        {
            frmPatient frm = new frmPatient(1);
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuItemConsultations_Click(object sender, EventArgs e)
        {

        }

        private void lnkChangePwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmChangePassword frm = new frmChangePassword();
            frm.ShowDialog();
        }
    }
}
