using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalERP.Procedures;
using HospitalERP.Helpers;
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
            if (Application.OpenForms.OfType<frmBilling>().Count() == 1)
                Application.OpenForms.OfType<frmBilling>().First().Activate();
            else
            {
                frmBilling frm = new frmBilling();
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
        }

        private void btnDashApp_Click(object sender, EventArgs e)
        {
            if (LoggedUser.type_name.ToUpper() == "DOCTOR")
            {
                if (Application.OpenForms.OfType<frmConsultations>().Count() == 1)
                    Application.OpenForms.OfType<frmConsultations>().First().Activate();
                else
                {
                    frmConsultations frm = new frmConsultations();
                    frm.MdiParent = this.MdiParent;
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
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
            }
            
            
        }

        private void btnDashReg_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<frmPatient>().Count() == 1)
                Application.OpenForms.OfType<frmPatient>().First().Activate();
            else
            {
                frmPatient frm = new frmPatient(1);
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
        }

        private void btnDashDocs_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<frmDoctors>().Count() == 1)
                Application.OpenForms.OfType<frmDoctors>().First().Activate();
            else
            {
                frmDoctors frm = new frmDoctors();
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
        }

        private void btnDashStffGen_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<frmStaffs>().Count() == 1)
                Application.OpenForms.OfType<frmStaffs>().First().Activate();
            else
            {
                frmStaffs frm = new frmStaffs();
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
        }

        private void btnDashStaffType_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<frmStaffTypes>().Count() == 1)
                Application.OpenForms.OfType<frmStaffTypes>().First().Activate();
            else
            {
                frmStaffTypes frm = new frmStaffTypes();
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
        }

        private void btnDashDept_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<frmDepartments>().Count() == 1)
                Application.OpenForms.OfType<frmDepartments>().First().Activate();
            else
            {
                frmDepartments frm = new frmDepartments();
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
        }

        private void btnDashProc_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<frmProcedures>().Count() == 1)
                Application.OpenForms.OfType<frmProcedures>().First().Activate();
            else
            {
                frmProcedures frm = new frmProcedures();
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
            
        }

        private void btnDashUserRoles_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<frmUserRoles>().Count() == 1)
                Application.OpenForms.OfType<frmUserRoles>().First().Activate();
            else
            {
                frmUserRoles frm = new frmUserRoles();
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
        }

        private void btnDashOpt_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<frmOptions>().Count() == 1)
                Application.OpenForms.OfType<frmOptions>().First().Activate();
            else
            {
                frmOptions frm = new frmOptions();
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
        }

        private void btnDashReports_Click(object sender, EventArgs e)
        {
            /*if (Application.OpenForms.OfType<frmOptions>().Count() == 1)
                Application.OpenForms.OfType<frmOptions>().First().Activate();
                else {
            frmOptions frm = new frmOptions();
            frm.MdiParent = this.MdiParent;
            frm.Show();}*/
        }

        private void btnDashProcType_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<frmProcTypes>().Count() == 1)
                Application.OpenForms.OfType<frmProcTypes>().First().Activate();
            else
            {
                frmProcTypes frm = new frmProcTypes();
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void frmDashboard_Shown(object sender, EventArgs e)
        {
            if(LoggedUser.id > 0)
            {
                lblUEmpID.Text = LoggedUser.emp_id;
                lblUName.Text = LoggedUser.name;
                lblURole.Text = LoggedUser.type_name;
                lblUDesig.Text = LoggedUser.designation;
                lblUDept.Text = LoggedUser.department;
                lblUNationality.Text = LoggedUser.nationality;
                if(LoggedUser.gender!="" && LoggedUser.gender!= null)
                lblUGender.Text = Utils.Gender[LoggedUser.gender].ToString();
                else
                    lblUGender.Text = "";
                lblUType.Text = LoggedUser.staff_type;
                lblULastLog.Text = LoggedUser.last_log_date.ToString();
                if (LoggedUser.dob != null)
                    lblUDob.Text = LoggedUser.dob.ToString();
                else
                    lblUDob.Text = "";
                lblUPhone.Text = LoggedUser.phone;               
                
              
            }
            OptionVals opt = new OptionVals();
            DataTable dtOpt = opt.GetOptionFromName("CLINIC_NAME");
            if (dtOpt.Rows.Count > 0)
                lblClinic.Text = dtOpt.Rows[0]["op_value"].ToString();
        }

        private void lnkChangePwd2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmChangePassword frm = new frmChangePassword();
            frm.ShowDialog();
        }

        private void lnkLogout2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.MdiParent.Close();
        }
    }
}
