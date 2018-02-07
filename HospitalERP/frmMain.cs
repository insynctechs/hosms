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
            LoggedUser.id = 1;
            LoggedUser.emp_id = "ADMIN";
            LoggedUser.type_id = 1;
            LoggedUser.type_name = "SUPER ADMIN";
            LoggedUser.phone = "";
            LoggedUser.last_log_date = Convert.ToDateTime("12-12-2017");
            LoggedUser.name = "ADMIN";
            LoggedUser.staff_id = 0;
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
                    
                    LoggedUser.setLoggedUser(dtUser);
                    usr.SetLoginDate(empid);
                    lblEmpID.Text = LoggedUser.name;
                    if (LoggedUser.type_id == 1)
                        lblEmpID.Text = "SUPER ADMIN";
                    

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
            frmDashboard frm = new frmDashboard();
            frm.MdiParent = this;
            frm.Show();

        }
        

        private void menuItemStaffOthers_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<frmStaffs>().Count() == 1)
                Application.OpenForms.OfType<frmStaffs>().First().Activate();
            else
            {
                frmStaffs frm = new frmStaffs();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void menuItemDocs_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<frmDoctors>().Count() == 1)
                Application.OpenForms.OfType<frmDoctors>().First().Activate();
            else
            {
                frmDoctors frm = new frmDoctors();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void menuItemStaffType_Click(object sender, EventArgs e)
        {

            if (Application.OpenForms.OfType<frmStaffTypes>().Count() == 1)
                Application.OpenForms.OfType<frmStaffTypes>().First().Activate();
            else
            {
                frmStaffTypes frm = new frmStaffTypes();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void menuItemDept_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<frmDepartments>().Count() == 1)
                Application.OpenForms.OfType<frmDepartments>().First().Activate();
            else
            {
                frmDepartments frm = new frmDepartments();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void menuItemProc_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<frmProcedures>().Count() == 1)
                Application.OpenForms.OfType<frmProcedures>().First().Activate();
            else
            {
                frmProcedures frm = new frmProcedures();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void menuItemUserRoles_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<frmUserRoles>().Count() == 1)
                Application.OpenForms.OfType<frmUserRoles>().First().Activate();
            else
            {
                frmUserRoles frm = new frmUserRoles();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void menuItemProcType_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<frmProcTypes>().Count() == 1)
                Application.OpenForms.OfType<frmProcTypes>().First().Activate();
            else
            {
                frmProcTypes frm = new frmProcTypes();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void menuItemOpt_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<frmOptions>().Count() == 1)
                Application.OpenForms.OfType<frmOptions>().First().Activate();
            else
            {
                frmOptions frm = new frmOptions();
                frm.MdiParent = this;
                frm.Show();
            }
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
                child.Dispose();
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
            if (Application.OpenForms.OfType<frmPatient>().Count() == 1)
                Application.OpenForms.OfType<frmPatient>().First().Activate();
            else
            {
                frmPatient frm = new frmPatient();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void lnkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void menuItemApp_Click(object sender, EventArgs e)
        {
            if (LoggedUser.type_name.ToUpper() == "DOCTOR")
            {
                if (Application.OpenForms.OfType<frmConsultations>().Count() == 1)
                    Application.OpenForms.OfType<frmConsultations>().First().Activate();
                else
                {
                    frmConsultations frm = new frmConsultations();
                    frm.MdiParent = this;
                    frm.Show();
                }
            }
            else
            {

                if (Application.OpenForms.OfType<frmAppointments>().Count() == 1)
                    Application.OpenForms.OfType<frmAppointments>().First().Activate();
                else
                {
                    frmAppointments frm = new frmAppointments();
                    frm.MdiParent = this;
                    frm.Show();
                }
            }
        }
        

        private void menuItemBillSearch_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<frmBilling>().Count() == 1)
                Application.OpenForms.OfType<frmBilling>().First().Activate();
            else
            {
                frmBilling frm = new frmBilling();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void menuItemPatSearch_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<frmPatient>().Count() == 1)
                Application.OpenForms.OfType<frmPatient>().First().Activate();
            else
            {
                frmPatient frm = new frmPatient(1);
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void menuItemConsultations_Click(object sender, EventArgs e)
        {

        }

        private void lnkChangePwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmChangePassword frm = new frmChangePassword();
            frm.ShowDialog();
        }

        

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<frmDashboard>().Count() == 1)
                Application.OpenForms.OfType<frmDashboard>().First().Activate();
            else
            {
                frmDashboard frm = new frmDashboard();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnChildClose_Click(object sender, EventArgs e)
        {
            //this.ActiveMdiChild.Dispose();
            this.ActiveMdiChild.Close();
            int childCount = getChildCount();
            if(childCount == 0)
                btnChildClose.Visible = false;
            else
                btnChildClose.Visible = true;
        }

        private void MainMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void frmMain_MdiChildActivate(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() != typeof(frmDashboard) && form.GetType() != typeof(frmMain) && form.GetType() != typeof(frmLogin))
                {
                    btnChildClose.Visible = true;
                    //MessageBox.Show(form.GetType().Name);
                    return;
                }
            }
            
            
        }

        public void DisposeAllButThis(Form form)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType() == form.GetType()
                    && frm != form)
                {
                    frm.Dispose();
                    frm.Close();
                }
            }
        }

        

        public int getChildCount()
        {
            int childCount = 0;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType() != typeof(frmDashboard) && frm.GetType() != typeof(frmMain) && frm.GetType() != typeof(frmLogin))
                {
                    childCount++;
                }
            }
            return childCount;
        }

        private void btnApp_Click(object sender, EventArgs e)
        {
            if (LoggedUser.type_name.ToUpper() == "DOCTOR")
            {
                if (Application.OpenForms.OfType<frmConsultations>().Count() == 1)
                    Application.OpenForms.OfType<frmConsultations>().First().Activate();
                else
                {
                    frmConsultations frm = new frmConsultations();
                    frm.MdiParent = this;
                    frm.Show();
                }
            }
            else
            {

                if (Application.OpenForms.OfType<frmAppointments>().Count() == 1)
                    Application.OpenForms.OfType<frmAppointments>().First().Activate();
                else
                {
                    frmAppointments frm = new frmAppointments();
                    frm.MdiParent = this;
                    frm.Show();
                }
            }
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<frmPatient>().Count() == 1)
                Application.OpenForms.OfType<frmPatient>().First().Activate();
            else
            {
                frmPatient frm = new frmPatient();
                frm.MdiParent = this;
                frm.Show();
            }
        }
    }
}
