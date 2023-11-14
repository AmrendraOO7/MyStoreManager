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
    public partial class frm_UserEntry : Form
    {
        #region Global

        public static string ToPerform = string.Empty;
        public static int UID = 0;
        public static int RoleID = 0;
        public string RoleTable = "MSM.UsersRole";
        public string DbName = Global.InitialCatalogMain;
        public static int UserID = 0;
        public string UserTable = "MSM.UsersMaster";
        public static string reText = "admin";// string.Empty;
        public string UserStatus = string.Empty;
        public int MouseBtn = 0;
        private readonly IMainMaster mainMaster = new ClsMainMaster();
        clsPleaseWaitForm PleaseWait = new clsPleaseWaitForm();

        #endregion

        #region Methods
        public frm_UserEntry()
        {
            InitializeComponent();
        }
        public void clear()
        {
            UID = 0;
            RoleID = 0;
            UserID = 0;
            UserStatus = string.Empty;
            ToPerform = string.Empty;
            MouseBtn = 0;
            txtUsrName.Clear(); //IMP
            txtLoginID.Clear(); //IMP
            txtPassword.Clear(); //IMP
            txtConfirmPassword.Clear(); //IMP
            txtdepartment.Clear();
            txtRole.Clear();//IMP
            chk_PasswordBtn.Checked = false;
            chk_RoleStatus.Checked = true;
        }

        public void FormStatus(bool btn, bool txt)
        {
            btn_Save.Enabled = btn_Delete.Enabled = btn_Edit.Enabled = btn;
            txtUsrName.Enabled = txtLoginID.Enabled = txtPassword.Enabled = txtConfirmPassword.Enabled = txtdepartment.Enabled = txtRole.Enabled = txt;
            Btn_Ok.Enabled = btn_Search.Enabled = btnRoleSearch.Enabled = txt; //these btn should only be active when thext box is active
        }

        public bool FormIsOK()
        {
            if (string.IsNullOrWhiteSpace(txtUsrName.Text.Trim()))
            {
                MessageBox.Show("You must Enter Company Name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsrName.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtLoginID.Text.Trim()))
            {
                MessageBox.Show("You must Enter LoginID", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLoginID.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text.Trim()))
            {
                MessageBox.Show("You must Enter Password", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text.Trim()))
            {
                MessageBox.Show("You must Confirm Password", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtRole.Text.Trim()))
            {
                MessageBox.Show("You must Enter Role", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRole.Focus();
                return false;
            }
            if (txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
            {
                MessageBox.Show("Password does not match with each other..", "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirmPassword.Focus();
                return false;
            }
            else return true;
        }

        public int UserEntry()
        {
            UID = ToPerform is"Insert" ? ClsMainMaster.getInt("MSM.UsersMaster", "userid") : UserID;
            mainMaster.UserEntry.ToPerform = ToPerform;
            mainMaster.UserEntry.userid = UID;
            mainMaster.UserEntry.usrname = txtUsrName.Text.Trim().Replace("'", "''");
            mainMaster.UserEntry.loginid = txtLoginID.Text.Trim().Replace("'", "''");
            mainMaster.UserEntry.password = txtConfirmPassword.Text.Trim().Replace("'", "''");
            mainMaster.UserEntry.dept=txtdepartment.Text.Trim().Replace("'", "''");
            mainMaster.UserEntry.RoleID = RoleID;
            mainMaster.UserEntry.ActiveStatus = chk_RoleStatus.Checked;
            //mainMaster.UserEntry.Background = ""
            return mainMaster.UserEntrySetup();
        }

        public void ChkUserExistence()
        {
            var dt = mainMaster.CheckAvailability("MSM.UsersMaster", "loginid", txtLoginID.Text.Trim().ToLower());
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Login Id Already Taken..!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtLoginID.Focus();
            }
        }
        #endregion

        #region Events
        private void frm_UserEntry_Load(object sender, EventArgs e)
        {
            clear();
            FormStatus(true,false);
        }

        private void globalTab_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar is (char)Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void chk_Btn_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_PasswordBtn.Checked)
                txtPassword.UseSystemPasswordChar = txtConfirmPassword.UseSystemPasswordChar = false;
            else
                txtPassword.UseSystemPasswordChar = txtConfirmPassword.UseSystemPasswordChar = true;

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            clear();
            ToPerform = "Insert";
            FormStatus(false, true);
            txtUsrName.Focus();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            clear();
            ToPerform = "Update";
            FormStatus(false, true);
            txtUsrName.Focus();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            clear();
            ToPerform = "Delete";
            FormStatus(false, false);
            btn_Search.Enabled = true;
            btnRoleSearch.Enabled = false;
            Btn_Ok.Enabled = true;
            Btn_Ok.Focus();
        }

        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            if (ToPerform == null) return;
            if (FormIsOK() == true)
            {
                //progress bar implememtation starts
                PleaseWait.Show();
                
                if (UserEntry() != 0)
                {
                    PleaseWait.Close();
                    MessageBox.Show($@"{ToPerform.ToUpper()} Done...!!!", "Done", MessageBoxButtons.OK, MessageBoxIcon.None);
                    clear();
                    FormStatus(true, false);
                }
                else
                {
                    PleaseWait.Close();
                    MessageBox.Show($@"{ToPerform.ToUpper()} Error...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.None);
                    txtUsrName.Focus();
                }

            }
        }

        private void txtLoginID_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLoginID.Text))
            {

                switch (ToPerform)
                {
                    case "Insert":
                        {
                            ChkUserExistence();
                            break;
                        }
                    case "Update":
                        {
                            if (txtLoginID.Text.ToString() != reText)
                            {
                                ChkUserExistence();
                            }
                            break;
                        }
                }
            }
        }

        private void btnRoleSearch_Click(object sender, EventArgs e)
        {
            var popup = new frm_PopUpSearch(RoleID, RoleTable, DbName, "GetUserRole" ,1, string.Empty, 0);
            if (frm_PopUpSearch.dt.Rows.Count > 0)
            {
                popup.ShowDialog();
                if (popup.SelectedRow.Count > 0)
                {
                    txtRole.Text = popup.SelectedRow[0]["RoleName"].ToString();
                    RoleID = (int)popup.SelectedRow[0]["RoleId"];
                }
            }
            else
            {
                MessageBox.Show("No Data..!!", "Stop..!!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            btn_Search.Enabled = false;
            if (ToPerform == "Insert") return;
            var popup = new frm_PopUpSearch(UserID, UserTable, DbName, "GetUser",0, string.Empty, 0);
            if (frm_PopUpSearch.dt.Rows.Count > 0)
            {
                popup.ShowDialog();
                if (popup.SelectedRow.Count > 0)
                {
                    UserID = (int)popup.SelectedRow[0]["userid"];
                    txtUsrName.Text = popup.SelectedRow[0]["usrname"].ToString();
                    txtLoginID.Text = popup.SelectedRow[0]["loginid"].ToString();
                    txtPassword.Text = popup.SelectedRow[0]["password"].ToString();
                    txtConfirmPassword.Text = popup.SelectedRow[0]["password"].ToString();
                    txtdepartment.Text = popup.SelectedRow[0]["dept"].ToString();
                    RoleID = (int)popup.SelectedRow[0]["RoleID"];
                    txtRole.Text = popup.SelectedRow[0]["RoleName"].ToString();
                    UserStatus = popup.SelectedRow[0]["ActiveStatus"].ToString();
                    if (UserStatus == "True") chk_RoleStatus.Checked = true;
                    else chk_RoleStatus.Checked = false;
                }
            }
            else
            {
                MessageBox.Show("No Data..!!", "Stop..!!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            if (MouseBtn == 1)
            {
                clear();
                FormStatus(true, false);
            }
            else
            {
                if (MessageBox.Show("Are you sure to Refresh...!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                clear();
                FormStatus(true, false);
            }
        }

        #endregion

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = ColorTranslator.FromHtml(Global.BackgroundColor);
        }

        private void lbl_Role_Click(object sender, EventArgs e)
        {
            var frm = new frm_RoleSetup();
            frm.ShowDialog();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MouseBtn = 1;
            btn_Refresh_Click(sender, e);
        }

        private void txtUsrName_TextChanged(object sender, EventArgs e)
        {
            txtUsrName.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.txtUsrName.Text);
            txtUsrName.Select(txtUsrName.TextLength, 0);
        }
    }
}
