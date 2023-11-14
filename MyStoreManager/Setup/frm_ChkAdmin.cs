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
    public partial class frm_ChkAdmin : Form
    {
        private readonly IMainMaster mainMaster = new ClsMainMaster();
        public string username = string.Empty;
        public string Password = string.Empty;
        public string Entered_username = string.Empty;
        public string Entered_Password = string.Empty;
        public string AdminValue = string.Empty;
        public int LoginID;
        public int RoleID;
        public static string MDI_Action;
        clsPleaseWaitForm PleaseWait = new clsPleaseWaitForm();

        public frm_ChkAdmin()
        {            
            InitializeComponent();
        }

        private void frm_ChkAdmin_Load(object sender, EventArgs e)
        {
            if (Global.LoginID == 1 || Global.IsAdmin == 1)
            {
                MessageBox.Show("Admin Permission is On", "No Need", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
       
        }

        private void globalTab_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar is (char)Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtUserID.Text) && !string.IsNullOrEmpty(txtPassword.Text))
            {
                PleaseWait.Show();
                username = txtUserID.Text.Trim();
                Password = txtPassword.Text.Trim();
                MDI_Action = MDI_UserPanel.MDI_Action;
                var dt = mainMaster.getUserLogin(username, Password,0);
                if (dt.Rows.Count > 0)
                {
                    LoginID = (int)dt.Rows[0]["userid"];
                    RoleID = (int)dt.Rows[0]["RoleID"];
                    Entered_username = dt.Rows[0]["loginid"].ToString();
                    Entered_Password = dt.Rows[0]["password"].ToString();

                    switch(MDI_Action)
                    {
                        case "sessionPermission":
                            {
                                if (username == Entered_username && Password == Entered_Password && RoleID == 1 && Global.CurrentSession == 0)
                                {
                                    Global.CurrentSession = 1;
                                    PleaseWait.Close();
                                    MessageBox.Show("You have Admin Permission For this Session", "Session Admin OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                else
                                {
                                    PleaseWait.Close();
                                    MessageBox.Show("Entered Information doesnot matched..!!", "TryAgain", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtPassword.Focus();
                                }
                                break;
                            }
                        case "Configuration":
                            {
                                if (username == Entered_username && Password == Entered_Password && RoleID == 1)
                                {
                                    this.Hide();
                                    var frm = new frm_Configuration();
                                    frm.ShowDialog();
                                }
                                else
                                {
                                    PleaseWait.Close();
                                    MessageBox.Show("Entered Information doesnot matched..!!", "TryAgain", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtPassword.Focus();
                                }
                                break;
                            }
                    }
                }
                else
                {
                    PleaseWait.Close();
                    MessageBox.Show("Entered Information doesnot matched..!!", "TryAgain", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Focus();
                }
            }
            else
            {
                PleaseWait.Close();
            }
        }

        private void chk_Btn_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Btn.Checked) txtPassword.UseSystemPasswordChar = false;
            else txtPassword.UseSystemPasswordChar = true;
        }

        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = ColorTranslator.FromHtml(Global.BackgroundColor);
        }
    }
}
