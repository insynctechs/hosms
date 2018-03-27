using System;
using System.Windows.Forms;
using System.Drawing;
using HospitalERP.Procedures;
using System.Data;
using System.Linq;
using HospitalERP.Helpers;

namespace HospitalERP
{
    public partial class frmUserRoles : Form
    {
        UserRoles UR = new UserRoles();
        Menus mn = new Menus();
        log4net.ILog ilog;     

        private bool updatingTreeView;

        public frmUserRoles()
        {
            InitializeComponent();
        }

        private void frmUserRoles_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            
            log4net.Config.XmlConfigurator.Configure();
            ilog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
                        

        }
        private void PopulateSearch()
        {
            cmbSearch.DataSource = UR.SearchValues();
            cmbSearch.ValueMember = "Value";
            cmbSearch.DisplayMember = "Display";
        }

        private void ShowRecords()
        {
            DataTable dtRecords = UR.GetRecords(cmbSearch.SelectedValue.ToString(), txtSearch.Text);
            dgvList.DataSource = dtRecords;
            if (dtRecords.Rows.Count == 0)
            {
                MessageBox.Show(Utils.FormatZeroSearch());
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
                    rtn = UR.addTypes(txtName.Text.Trim(), txtDesc.Text.Trim(), chkActive.Checked);
                    if (rtn == 0)
                        ShowStatus(0, "Type name should be unique");
                    else if (rtn == 1)
                    {
                        ShowStatus(1, "Record succesfully added");
                        clearFormFields();

                    }
                    else if (rtn == -1)
                    {
                        ShowStatus(0, "Some error occurred... Record cannot be added.");
                    }
                }
                else //edit record
                {
                    rtn = UR.editTypes(Int32.Parse(txtID.Text.Trim()), txtName.Text, txtDesc.Text, chkActive.Checked);
                    int ret = UpdateMenuAccess();
                    if (rtn == 0)
                        ShowStatus(0, "This name already exists. Please provide unique name.");
                    else if (rtn == 1)
                    {
                        ShowStatus(1, "Record succesfully updated");
                        clearFormFields();

                    }
                    else if (rtn == -1)
                    {
                        ShowStatus(0,"Some error occurred... Record cannot be added.");
                    }
                }
                
            }
            
            
        }

        private int UpdateMenuAccess()
        {
            DataTable dtChkMenu = new DataTable();
            dtChkMenu.Columns.Add("id");
            foreach (TreeNode node in trvMenu.Nodes)
            {
                if (node.Checked == true)
                {
                    //dtChkMenu.Rows.Add("id");
                    dtChkMenu.Rows.Add(new object[] { node.Name.Replace("trvn", "") });

                }
                dtChkMenu = TraverseRecursiveToGetChecked(node, dtChkMenu);

            }
            if(dtChkMenu.Rows.Count > 0)
            {
                int ret = mn.UpdateUserTypeMenus(dtChkMenu, Int32.Parse(txtID.Text));
                return ret;
            }
            else
                return 0;
        }

        private DataTable TraverseRecursiveToGetChecked(TreeNode treeNode, DataTable dtChkMenu)
        {
            
            foreach (TreeNode tn in treeNode.Nodes)
            {
                if (tn.Checked == true)
                {
                    //dtChkMenu.Rows.Add("id");
                    dtChkMenu.Rows.Add(new object[] { tn.Name.Replace("trvn", "") });
                   
                }
                dtChkMenu = TraverseRecursiveToGetChecked(tn, dtChkMenu);
            }
            return dtChkMenu;
        }

        private void SetMenuChecksOnEdit()
        {

            DataTable dtCheckMenu = mn.GetUserTypeMenus(Int32.Parse(txtID.Text));
            if (dtCheckMenu.Rows.Count > 0)
            {
                foreach (TreeNode node in trvMenu.Nodes)
                {
                    TraverseRecursiveToSetChecked(node, dtCheckMenu);

                }                
            }
            
            
        }

        private void TraverseRecursiveToSetChecked(TreeNode treeNode, DataTable dtChkMenu)
        {

            foreach (TreeNode tn in treeNode.Nodes)
            {
                int id = Int32.Parse(tn.Name.Replace("trvn", ""));
                bool contains = dtChkMenu.AsEnumerable().Any(row => id == row.Field<int>("menu_id"));
                if (contains)
                {
                    tn.Checked = true;

                }
                TraverseRecursiveToSetChecked(tn, dtChkMenu);
            }
            
        }


        private void txtName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtName.Text.Trim()) && txtID.Text=="")
            {
                e.Cancel = true;
                txtName.Focus();
                errorProvider.SetError(txtName, "Required");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtName, null);
            }
        }

        private void dgvList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            setFormFields(e.RowIndex);
            tabSub.SelectedIndex = 0;
        }


        private void setFormFields(int index)
        {
            txtID.Text = dgvList.Rows[index].Cells["colID"].Value.ToString();
            txtName.Text = dgvList.Rows[index].Cells["colName"].Value.ToString();
            txtDesc.Text = dgvList.Rows[index].Cells["colDescription"].Value.ToString();
            chkActive.Checked = (bool)dgvList.Rows[index].Cells["colActive"].Value;

            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowRecords();
        }

        private void ShowStatus(int success, string msg)
        {
            lblStatus.Visible = true;
            if (success == 1)
            {
                lblStatus.BackColor = Color.YellowGreen;
                lblStatus.ForeColor = Color.DarkGreen;
            }
            else
            {
                lblStatus.BackColor = Color.Salmon;
                lblStatus.ForeColor = Color.DarkRed;
            }
            lblStatus.Text = msg;
            var t = new Timer();
            t.Interval = 5000; // it will Tick in 3 seconds
            t.Tick += (s, e) =>
            {
                lblStatus.Hide();
                t.Stop();
            };
            t.Start();
        }

        private void clearFormFields()
        {

            txtName.Text = "";
            txtDesc.Text = "";
            chkActive.Checked = true;
            txtID.Text = "";
            UncheckAllNodes(trvMenu.Nodes);
        }

        private void tabSub_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabSub.SelectedIndex)
            {
                case 0:

                    break;
                case 1:
                    clearFormFields();
                    ShowRecords();
                    break;
            }
        }

        public void BuildTree(DataTable dt, TreeView trv, Boolean expandAll)
        {
            
            trv.Nodes.Clear();
            TreeNode node = default(TreeNode);
            TreeNode subNode = default(TreeNode);
            foreach (DataRow row in dt.Rows)
            {
                
                if(Int32.Parse(row["parent_id"].ToString()) == 0)
                {
                    node = new TreeNode(row["menu_text"].ToString());
                    node.Name = "trvn" + row["id"].ToString();
                    trv.Nodes.Add(node);
                }
                else {
                    //node = trv.Nodes.("trvn" + row["parent_id"].ToString(), true);
                    node = SearchNode("trvn" + row["parent_id"].ToString(), trv);
                    if (node != null)
                    {
                        
                        subNode = new TreeNode(row["menu_text"].ToString());
                        subNode.Name = "trvn" + row["id"].ToString();                       
                        node.Nodes.Add(subNode);                        
                    }
                    else
                    {
                        node = new TreeNode(row["menu_text"].ToString());
                        node.Name = "trvn" + row["id"].ToString();
                        trv.Nodes.Add(node);
                    }
                }
                
                
            }
            if (expandAll)
            {
                trv.ExpandAll();
            }
        }

        private TreeNode SearchNode(string nodeparent, TreeView trv)
        {
            foreach (TreeNode node in trv.Nodes)
            {
                if (node.Name == nodeparent)
                {
                    return node;
                    
                }
               
            }
            return null;
            
        }

        public void CheckAllNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                node.Checked = true;
                CheckChildren(node, true);
            }
        }

        public void UncheckAllNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                node.Checked = false;
                CheckChildren(node, false);
            }
        }

        private void CheckChildren(TreeNode rootNode, bool isChecked)
        {
            foreach (TreeNode node in rootNode.Nodes)
            {
                CheckChildren(node, isChecked);
                node.Checked = isChecked;
            }
        }

        private void trvMenu_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (updatingTreeView)
                return;
            updatingTreeView = true;
            SelectChildrenOnParentSelect(e.Node, e.Node.Checked);
            SelectParentOnChildSelect(e.Node, e.Node.Checked);

            updatingTreeView = false;
        }

        private void SelectParentOnChildSelect(TreeNode node, Boolean isChecked)
        {
            var parent = node.Parent;

            if (parent == null)
                return;

            if (isChecked)
            {
                parent.Checked = true; // we should always check parent
                SelectParentOnChildSelect(parent, true);
            }
            else
            {
                if (parent.Nodes.Cast<TreeNode>().All(n => n.Checked))
                {
                    parent.Checked = true;
                    return; // do not uncheck parent if there other checked nodes
                }
                else if (parent.Nodes.Cast<TreeNode>().Any(n => n.Checked))
                {
                    parent.Checked = true;
                    return; // do not uncheck parent if there other checked nodes
                }
                else
                {
                    parent.Checked = false;
                    return; // do not uncheck parent if there other checked nodes
                }               
               
            }
        }

        
        private void SelectChildrenOnParentSelect(TreeNode node, Boolean isChecked)
        {
            bool checkChildren = (node.Checked);
            if (node.Nodes.Count == 0)
            {
                return;
            }
            if (checkChildren == true)
            {
                foreach (TreeNode childNode in node.Nodes)
                {
                    childNode.Checked = true; // !childNode.Checked;
                }
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if(txtID.Text.Trim()!="")
            {
                SetMenuChecksOnEdit();
                if (Int32.Parse(txtID.Text.Trim()) < 4)
                    txtName.ReadOnly = true;
                
            }
            else
                txtName.ReadOnly = false;
        }

        private void frmUserRoles_Shown(object sender, EventArgs e)
        {
            PopulateSearch();
            DataTable dtMenu = mn.GetMenuActive(true);
            BuildTree(dtMenu, trvMenu, true);
        }

        private void frmUserRoles_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utils.toggleChildCloseButton(this.MdiParent, 1);
            ilog = null;
            mn.Dispose();
            UR.Dispose();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearFormFields();
        }

       
        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (dgvList.Columns[e.ColumnIndex].Name)
            {
                case "colBtnEdit":
                    setFormFields(e.RowIndex);
                    tabSub.SelectedIndex = 0;
                    break;
            }
        }

        
    }
}
