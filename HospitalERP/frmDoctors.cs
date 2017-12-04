using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HospitalERP.Procedures;

namespace HospitalERP
{
    public partial class frmDoctors : Form
    {
        log4net.ILog ilog;
        Doctors doc = new Doctors();

        public frmDoctors()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
            ilog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        }

        private void frmDoctors_Load(object sender, EventArgs e)
        {            
            this.WindowState = FormWindowState.Maximized;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            PopulateSearch();
            ShowDoctors();
        }

        private void PopulateSearch()
        {
            cmbSearch.DataSource = doc.SearchValues();
            cmbSearch.ValueMember = "Value";
            cmbSearch.DisplayMember = "Display";
        }

        private void ShowDoctors()
        {
            dgvDept.DataSource = doc.GetDoctors(cmbSearch.SelectedValue.ToString(), txtSearch.Text);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                int rtn = -1;
                if (txtID.Text.Trim() == "") //add data
                {
                    rtn = doc.addDoctors(txtFirstName.Text, txtLastName.Text, 1, txtDesignation.Text, txtQualification.Text, txtSpecialization.Text, 'M', Convert.ToDateTime(dtpDob.Text), txtNationality.Text, txtPathaka.Text, Convert.ToDateTime(dtpPathakaExpiry.Text), txtAddress.Text, txtCity.Text, txtDistrict.Text, txtZip.Text, txtPhone.Text, txtEmail.Text, chkActive.Checked, Convert.ToDouble(txtFee.Text));

                    if (rtn == 0)
                        lblStatus.Text = "Type name should be unique";
                    else if (rtn == 1)
                    {
                        lblStatus.Text = "Record succesfully added";

                        chkActive.Checked = false;

                    }
                    else if (rtn == -1)
                    {
                        lblStatus.Text = "Some error occurred... Record cannot be added.";
                    }
                }
                else //edit record
                {
                    rtn = doc.editDoctors(Int32.Parse(txtID.Text.Trim()), txtFirstName.Text, txtLastName.Text, cmbDept.SelectedIndex, txtDesignation.Text, txtQualification.Text, txtSpecialization.Text, 'M', Convert.ToDateTime(dtpDob.Text), txtNationality.Text, txtPathaka.Text, Convert.ToDateTime(dtpPathakaExpiry.Text), txtAddress.Text, txtCity.Text, txtDistrict.Text, txtZip.Text, txtPhone.Text, txtEmail.Text, chkActive.Checked, Convert.ToDouble(txtFee.Text));
                    //if (rtn == 0)
                    //  lblStatus.Text = "This name already exists. Please provide unique name.";
                    //else
                    if (rtn == 1)
                    {
                        lblStatus.Text = "Record succesfully updated";
                        chkActive.Checked = false;

                    }
                    else if (rtn == -1)
                    {
                        lblStatus.Text = "Some error occurred... Record cannot be added.";
                    }
                }
                ShowDoctors();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowDoctors();
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                e.Cancel = true;
                txtFirstName.Focus();
                errorProvider.SetError(txtFirstName, "Required");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtFirstName, null);
            }

        }
    }
}
