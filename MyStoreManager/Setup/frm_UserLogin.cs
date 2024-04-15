using DocumentFormat.OpenXml.Bibliography;
using MSMControl.Class;
using MSMControl.Connection;
using MSMControl.Interface;
using MSMControl.Properties;
using MyStoreManager.PleaseWaitControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStoreManager.Setup
{
    public partial class frm_UserLogin : Form
    {
        public int LoginID;
        public int RoleID;
        public int YearID;
        public int roleTypeId;

        public int days;

        public string username = string.Empty;
        public string Password = string.Empty;
        public string Entered_username = string.Empty;
        public string Entered_Password = string.Empty;
        
        public string AdminValue = string.Empty;
        public string FiscalYear = string.Empty;

        DataTable dt = new DataTable();
        private readonly IMainMaster mainMaster = new ClsMainMaster();
        //clsPleaseWaitForm PleaseWait = new clsPleaseWaitForm();
        public frm_UserLogin()
        {
            InitializeComponent();
        }

        public void FullScreen()
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }

        private void globalTab_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar is (char)Keys.Enter) SendKeys.Send("{TAB}");
        }
        private void frm_UserLogin_Load(object sender, EventArgs e)
        {
            debugCheck();
            FullScreen();
        }

        private void debugCheck()
        {
            bool isDevelopmentMode = ConfigurationManager.AppSettings["Environment"] == "Development";

            if (isDevelopmentMode)
            {
                // Development mode code
                //txtUserID.Text = "admin";
                //txtPassword.Text = "msm@admin";
                txtUserID.Clear();
                txtPassword.Clear();
            }
            else
            {
                // Production mode code
                txtUserID.Clear();
                txtPassword.Clear();
            }

        }

        public void UpdateTables()
        {
            var Query = Execute.ExecuteNonQueryOnMainResources(Resource.MSM_UPDATE_TABLE_ON_MAIN);
            //if (Query != 0) return 1;
            //else return 0;
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            //progress bar implememtation starts
            //PleaseWait.Show();
            UpdateTables();

            var licsenceInfo = mainMaster.getlicsence();


            if (licsenceInfo != null && licsenceInfo.Rows.Count > 0)
            {
                var licsenceKey = licsenceInfo.Rows[0]["licsence_key"];
                Global.licenseKey = licsenceKey.ToString();
                SKGL.Validate validate = new SKGL.Validate();
                validate.Key = licsenceKey.ToString();
                Global.remainingDays = days = validate.DaysLeft;
                if (days == 1 || days == 2 || days == 3 || days == 4 || days == 5 )
                {
                    //PleaseWait.Close();
                    MessageBox.Show($@"Your License is about to expire in {days} days." + "\nPlease contact Tech NexaVerse Solution Pvt. Ltd." + "or Visit us at (www.technexaverse.com)", "Reminder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if(days < 0)
                {
                    //PleaseWait.Close();
                    MessageBox.Show($@"Your License is expire." + "\nPlease contact Tech NexaVerse Solution Pvt. Ltd." + "or Visit us at (www.technexaverse.com)", "Reminder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //ignore
                }

                if (days <= 0)
                {
                    //PleaseWait.Close();
                    var frm = new frm_License_Entry();
                    frm.ShowDialog();
                    MessageBox.Show("Closing/Restarting application!!", "Expired", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Application.Exit();
                }
            }
            else
            {
                //PleaseWait.Close();
                var frm = new frm_License_Entry();
                frm.ShowDialog();
                MessageBox.Show("Closing/Restarting application!!", "Please Start", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
            }

            username = txtUserID.Text.Trim();
            Password = txtPassword.Text.Trim();
            dt = mainMaster.getUserLogin(username, Password, 0); // 0 for else case of background select
            if (dt.Rows.Count > 0)
            {
                LoginID = (int)dt.Rows[0]["userid"];
                RoleID = (int)dt.Rows[0]["RoleID"];
                Entered_username = dt.Rows[0]["loginid"].ToString();
                Entered_Password = dt.Rows[0]["password"].ToString();
                roleTypeId = (int)dt.Rows[0]["RoleID"];
                if (roleTypeId != 1) return;
                if (username == Entered_username && Password == Entered_Password)
                {
                    Global.LoginID = LoginID;
                    Global.RoleID = RoleID;
                    Global.LoginUser = Entered_username;
                    Global.UserName = dt.Rows[0]["usrname"].ToString();
                    AdminValue = dt.Rows[0]["IsAdmin"].ToString();
                    var initials = mainMaster.checkConfig();
                    
                    Global.YearID = YearID = Int32.Parse(initials.Rows[0]["YearID"].ToString());
                    FiscalYear = initials.Rows[0]["CurrentYear"].ToString();
                    Global.CurrentYear = FiscalYear;
                    Global.checkDate = Convert.ToBoolean(initials.Rows[0]["checkDate"]);
                    Global.checkNote = Convert.ToBoolean(initials.Rows[0]["notes"]);
                    Global.checkReturnNote = Convert.ToBoolean(initials.Rows[0]["returnNotes"]);
                    Global.billMessage = initials.Rows[0]["billMsg"].ToString();
                    Global.compType = int.Parse(initials.Rows[0]["compType"].ToString());
                    Global.isProductionPurchase = Convert.ToBoolean(initials.Rows[0]["isProduction"].ToString());
                    System.Drawing.Color color = mainMaster.BackgroundColor();
                    Global.BackgroundColor = System.Text.RegularExpressions.Regex.Match(color.ToString(), @"\[(.*)\]").Groups[1].Value;
                    if (RoleID == 1) Global.IsAdmin = Global.CurrentSession = 1;
                    else
                    {
                        if (AdminValue == "True") Global.IsAdmin = Global.CurrentSession = 1;
                        else Global.IsAdmin = Global.CurrentSession = 0;
                    }
                    dt = mainMaster.checkTransectionOnPE();
                    Global.purchaseCheck = (int)dt.Rows[0]["PEBills"];
                    //if (purchase != null) Global.purchaseCheck = purchase;
                    dt = mainMaster.checkTransectionOnSE();
                    Global.salesCheck = (int)dt.Rows[0]["SABills"];
                    //PleaseWait.Close();
                    this.Hide();                      //this.Close();  // using this will open MDI parent on login page without closing it.
                    var frm_MDI_UserPanel = new MDI_UserPanel();
                    frm_MDI_UserPanel.ShowDialog();
                }
                else
                { 
                    //PleaseWait.Close();
                    MessageBox.Show("Entered Information doesnot matched..!!", "TryAgain", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUserID.Focus();
                }
            }
            else
            {
                //PleaseWait.Close();
                MessageBox.Show("Entered Information doesnot Exists..!!", "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserID.Focus();
            }
        }

        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chk_Btn_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Btn.Checked) txtPassword.UseSystemPasswordChar = false;
            else txtPassword.UseSystemPasswordChar = true;
        }
    }
}
