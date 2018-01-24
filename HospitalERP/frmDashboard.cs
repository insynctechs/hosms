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
    public partial class frmDashboard : Form
    {
        log4net.ILog ilog;

        Users usr = new Users();
        Menus mn = new Menus();

        public frmDashboard()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
            ilog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            if (LoggedUser.id > 0)
            {
                SetMenuItems();
                
            }
        }

        private void SetMenuItems()
        {
            DataTable dtMenu = mn.GetUserTypeMenusRemoveList(LoggedUser.type_id);
            foreach (DataRow dr in dtMenu.Rows)
            {
                string menu_name = dr["menu_name"].ToString();
                string btn_name = menu_name.Replace("menuItem", "btnDash");
                if (flowPanelDashMain.Controls.ContainsKey(btn_name))
                    flowPanelDashMain.Controls.RemoveByKey(btn_name);
            }
        }

        private void frmDashboard_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnDashBillSearch_Click(object sender, EventArgs e)
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
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnDashApp_Click(object sender, EventArgs e)
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
                frm.MdiParent = this.MdiParent;
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
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
            
            
        }

        private void btnDashReg_Click(object sender, EventArgs e)
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
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnDashDocs_Click(object sender, EventArgs e)
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
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnDashStffGen_Click(object sender, EventArgs e)
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
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnDashStaffType_Click(object sender, EventArgs e)
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
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnDashDept_Click(object sender, EventArgs e)
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
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnDashProc_Click(object sender, EventArgs e)
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
            frm.MdiParent = this.MdiParent;
            frm.Show();
            
        }

        private void btnDashUserRoles_Click(object sender, EventArgs e)
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
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnDashOpt_Click(object sender, EventArgs e)
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
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnDashReports_Click(object sender, EventArgs e)
        {
            /*foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmReports))
                {
                    form.Activate();
                    return;
                }
            }
            frmOptions frm = new frmOptions();
            frm.MdiParent = this.MdiParent;
            frm.Show();*/
        }

        private void btnDashProcType_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmProcTypes ))
                {
                    form.Activate();
                    return;
                }
            }
            frmProcTypes frm = new frmProcTypes();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }
    }
}
