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
                    LoggedUser.id = Int32.Parse(dtUser.Rows[0]["id"].ToString());
                    LoggedUser.emp_id = dtUser.Rows[0]["emp_id"].ToString();
                    LoggedUser.type_id = Int32.Parse(dtUser.Rows[0]["user_type_id"].ToString());
                    LoggedUser.type_name = dtUser.Rows[0]["type_name"].ToString();
                    LoggedUser.phone = dtUser.Rows[0]["staff_phone"].ToString();
                    LoggedUser.last_log_date = Convert.ToDateTime(dtUser.Rows[0]["log_date"].ToString());
                    LoggedUser.name = dtUser.Rows[0]["staff_name"].ToString();
                    LoggedUser.staff_id = Int32.Parse(dtUser.Rows[0]["staff_id"].ToString());
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
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmStaffs))
                {
                    form.Activate();
                    return;
                }
            }
            frmStaffs frm = new frmStaffs();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuItemDocs_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmDoctors))
                {
                    form.Activate();
                    return;
                }
            }
            frmDoctors frm = new frmDoctors();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuItemStaffType_Click(object sender, EventArgs e)
        {

            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmStaffTypes))
                {
                    form.Activate();
                    return;
                }
            }
            frmStaffTypes frm = new frmStaffTypes();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuItemDept_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmDepartments))
                {
                    form.Activate();
                    return;
                }
            }
            frmDepartments frm = new frmDepartments();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuItemProc_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmProcedures))
                {
                    form.Activate();
                    return;
                }
            }
            frmProcedures frm = new frmProcedures();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuItemUserRoles_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmUserRoles))
                {
                    form.Activate();
                    return;
                }
            }
            frmUserRoles frm = new frmUserRoles();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuItemProcType_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmProcTypes))
                {
                    form.Activate();
                    return;
                }
            }
            frmProcTypes frm = new frmProcTypes();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuItemOpt_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmOptions))
                {
                    form.Activate();
                    return;
                }
            }
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
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmPatient))
                {
                    form.Activate();
                    return;
                }
            }
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
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(frmConsultations))
                    {
                        form.Activate();
                        return;
                    }
                }
                frmConsultations frm = new frmConsultations();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {

                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(frmAppointments))
                    {
                        form.Activate();
                        return;
                    }
                }
                frmAppointments frm = new frmAppointments();
                frm.MdiParent = this;
                frm.Show();
            }
        }
        

        private void menuItemBillSearch_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmBilling))
                {
                    form.Activate();
                    return;
                }
            }
            frmBilling frm = new frmBilling();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuItemPatSearch_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmPatient))
                {
                    form.Activate();
                    return;
                }
            }
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

        

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmDashboard))
                {
                    form.Activate();
                    return;
                }
            }

            frmDashboard frm = new frmDashboard();
            frm.MdiParent = this;
            frm.Show();
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
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(frmConsultations))
                    {
                        form.Activate();
                        return;
                    }
                }
                frmConsultations frm = new frmConsultations();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {

                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(frmAppointments))
                    {
                        form.Activate();
                        return;
                    }
                }
                frmAppointments frm = new frmAppointments();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmPatient))
                {
                    form.Activate();
                    return;
                }
            }

            frmPatient frm = new frmPatient();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuitemBillingReport_Click(object sender, EventArgs e)
        {
            frmRptBilling rep = new frmRptBilling();
            rep.MdiParent = this;
            rep.Show();
            
        }

        private void miPatientRpt_Click(object sender, EventArgs e)
        {
            frmRptPatient fmPat = new frmRptPatient();
            fmPat.MdiParent = this;
            fmPat.Show();
        }

        private void miSickLeaveRpt_Click(object sender, EventArgs e)
        {
            frmRptSickLeave rsl = new frmRptSickLeave();
            rsl.ShowDialog(this);
        }
    }
}
