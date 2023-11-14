using MSMControl.Class;
using MSMControl.Connection;
using MSMControl.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStoreManager.Setup
{
    public partial class frm_RoleSetup : Form
    {
        private readonly IMainMaster mainMaster = new ClsMainMaster();
        int IsMDIActive = MDI_UserPanel.IsFormActive;
        public string ToPerform = string.Empty;
        public int RoleId = 0;
        public int MouseBtn = 0;
        public string TableName = "MSM.UsersRole";
        public string DbName = Global.InitialCatalogMain;
        clsPleaseWaitForm PleaseWait = new clsPleaseWaitForm();

        public frm_RoleSetup()
        {
            InitializeComponent();
        }

        public void FormStatus(bool btn,bool txt) 
        {
            txtState.Enabled = chk_RoleStatus.Enabled = Btn_Ok.Enabled = btn_Search.Enabled = txt;
            btn_Save.Enabled = btn_Delete.Enabled = btn_Edit.Enabled = btn;
        }

        public void Clear()
        {
            ToPerform = string.Empty;
            RoleId = 0;
            MouseBtn = 0;
            txtState.Clear();
            chk_RoleStatus.Checked = false;
            FormStatus(true, false);
        }

        private bool FormIsValid()
        {
            if (string.IsNullOrWhiteSpace(txtState.Text.Trim().Replace("'", "''")))
            {
                MessageBox.Show("Enter Value...!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }

        }
        public int UserRole()
        {
            if(ToPerform != null)
            {
                RoleId = ToPerform is "Insert" ? Int32.Parse(ClsMainMaster.getInt("MSM.UsersRole", "RoleId").ToString()) : RoleId;
                mainMaster.UserRole.ToPerform = ToPerform;
                mainMaster.UserRole.RoleId = RoleId;
                mainMaster.UserRole.RoleName = txtState.Text.Trim().Replace("'", "''");
                mainMaster.UserRole.RoleStatus = chk_RoleStatus.Checked;
                mainMaster.UserRole.Creator = Global.LoginID;
                return mainMaster.UserRoleSetup();
            }
            else return 0;
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            ToPerform = "Insert";
            FormStatus(false, true);
            txtState.Focus();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            ToPerform = "Update";
            FormStatus(false, true);
            btn_Search.Focus();
        }

        private void globalTab_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar is (char)Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            ToPerform = "Delete";
            FormStatus(false, false);
            btn_Search.Enabled = true;
            Btn_Ok.Enabled = true;
            Btn_Ok.Focus();
        }

        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            if(FormIsValid() is true)
            {
                //progress bar implememtation starts
                PleaseWait.Show();
                
                if (UserRole() == 1)
                {
                    PleaseWait.Close();
                    MessageBox.Show($@"{ToPerform.ToUpper()} Done...!!!", "Done", MessageBoxButtons.OK, MessageBoxIcon.None);
                    Clear();
                }
                else
                {
                    PleaseWait.Close();
                    MessageBox.Show($@"{ToPerform.ToUpper()} Error...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.None);
                    txtState.Focus();
                }

            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            if (MouseBtn == 1)
            {
                Clear();
                FormStatus(true, false);
            }
            else
            {
                if (MessageBox.Show("Are you sure to Refresh...!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                Clear();
                FormStatus(true, false);
            }
            
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to Close...!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            if (IsMDIActive == 1) this.Close();
            else Application.Exit();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            btn_Search.Enabled = false;
            if (ToPerform == "Insert") return;
            var popup = new frm_PopUpSearch(RoleId, TableName, DbName, "GetUserRole",0, string.Empty, 0);
            if (frm_PopUpSearch.dt.Rows.Count > 0)
            {
                popup.ShowDialog();
                if (popup.SelectedRow.Count > 0)
                {
                    txtState.Text = popup.SelectedRow[0]["RoleName"].ToString();
                    var RoleStatus = popup.SelectedRow[0]["RoleStatus"].ToString();
                    if (RoleStatus == "True") chk_RoleStatus.Checked = true;
                    else chk_RoleStatus.Checked = false;
                    RoleId = (int)popup.SelectedRow[0]["RoleId"];
                }
            }
            else
            {
                MessageBox.Show("No Data..!!", "Stop..!!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void frm_RoleSetup_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar is (char)Keys.Escape) btn_Refresh.PerformClick();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = ColorTranslator.FromHtml(Global.BackgroundColor);
        }

        private void frm_RoleSetup_Load(object sender, EventArgs e)
        {
            Clear();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MouseBtn = 1;
            btn_Refresh_Click(sender, e);
        }
    }
}
