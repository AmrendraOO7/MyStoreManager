using MSMControl.Class;
using MSMControl.Connection;
using MSMControl.Interface;
using MSMControl.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MyStoreManager.Setup
{
    public partial class frm_CompanySetup : Form
    {

        private readonly IMainMaster mainMaster = new ClsMainMaster();
        DriveInfo[] allDrives = DriveInfo.GetDrives();

        public string ToPerform = string.Empty;
        public string initial = string.Empty;
        private string drive = string.Empty;
        public string database = Global.InitialCatalogMain;
        public string location = string.Empty;
        public string EXT = "MSM_";
        Random rnd = new Random();

        public string Query = string.Empty;
        
        public static int ID = 0;
        public static int DupID = 0;
        public int MouseBtn = 0;
        public string TableName = "[dbo].[master.CompanyMasterInfo]";
        public string DbName = "master";

        int IsMDIActive = MDI_UserPanel.IsFormActive;
        //clsPleaseWaitForm PleaseWait = new clsPleaseWaitForm();
        public frm_CompanySetup()
        {
            InitializeComponent();
        }

        private void frm_CompanySetup_Load(object sender, EventArgs e)
        {
            if (IsMDIActive == 1) //this.Hide();
            {
                if (MessageBox.Show("Creating new company cause restart Application..\n Kindly ckeck for unsaved work", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) this.Close(); 
            }
            clear();
            FormStatus(true, false);
            State_Country_Load();
        }

        public void State_Country_Load()
        {
            //cmb_State.DataSource = mainMaster.Get_State();
            //cmb_State.ValueMember = "Name";
            //if (cmb_State.Items.Count > 0) cmb_State.SelectedIndex = 0;

            //cmb_Country.DataSource = mainMaster.Get_Country();
            //cmb_Country.ValueMember = "Name";
            //if (cmb_Country.Items.Count > 0) cmb_Country.SelectedIndex = 0;

            cmb_Drive.DataSource = allDrives;   
        }

        public void clear()
        {
            initial = string.Empty;
            location = string.Empty;
            Query = string.Empty;
            ID = 0;
            ToPerform = string.Empty;
            MouseBtn = 0;
            txtCompName.Clear();
            txt_Address.Clear();
            txt_City.Clear();
            txt_Contact.Clear();
            txt_Email.Clear();
            txt_Registration.Clear();
        }

        public void FormStatus(bool btn, bool txt)
        {
            btn_Save.Enabled = btn_Edit.Enabled = btn_Delete.Enabled = btn;
            txtCompName.Enabled = txt_Registration.Enabled = txt_Address.Enabled = txt_City.Enabled = txt_Contact.Enabled = txt_Email.Enabled = btn_Search.Enabled = lbl_AddCountry.Enabled = txt_State.Enabled = txt_Country.Enabled= cmb_Drive.Enabled = Btn_Ok.Enabled = txt;
        }

        private bool FormIsOK()
        {
            if(string.IsNullOrWhiteSpace(txtCompName.Text.Trim()))
            {
                MessageBox.Show("You must Enter Company Name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCompName.Focus();
                return false;
            }
            if(ToPerform == "Update" && drive != cmb_Drive.Text)
            {
                MessageBox.Show("You cannot change database location once set..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_Drive.Focus();
                return false;
            }
            else return true;
        }
        public int Company_Setup()
        {  
            mainMaster.compInfo.ToPerform = ToPerform;
            mainMaster.compInfo.cid = ToPerform is "Insert" ? ClsMainMaster.getIntMaster("dbo.[master.CompanyMasterInfo]", "cid") : ID;
            mainMaster.compInfo.cname = txtCompName.Text.Trim().Replace("'", "''");
            mainMaster.compInfo.regno = txt_Registration.Text.Trim().Replace("'", "''");
            mainMaster.compInfo.contact = txt_Contact.Text.Trim().Replace("'", "''");
            mainMaster.compInfo.email = txt_Email.Text.Trim().Replace("'", "''");
            mainMaster.compInfo.address = txt_Address.Text.Trim().Replace("'", "''");
            mainMaster.compInfo.city = txt_City.Text.Trim().Replace("'", "''");
            mainMaster.compInfo.StateName = txt_State.Text;
            mainMaster.compInfo.country = txt_Country.Text;
            mainMaster.compInfo.Location = cmb_Drive.Text+"MSMDatabase";
            if (ToPerform == "Insert") mainMaster.compInfo.catalog = initial;
            else mainMaster.compInfo.catalog = Global.InitialCatalogMain;

            mainMaster.dupcompInfo.ToPerform = ToPerform;
            mainMaster.dupcompInfo.Dup_cid = mainMaster.compInfo.cid;//ToPerform is "Insert" ? ClsMainMaster.getInt("[MSM].[CompanyMasterInfo]", "cid") : DupID;
            mainMaster.dupcompInfo.Dup_cname = txtCompName.Text.Trim().Replace("'", "''");
            mainMaster.dupcompInfo.Dup_regno = txt_Registration.Text.Trim().Replace("'", "''");
            mainMaster.dupcompInfo.Dup_contact = txt_Contact.Text.Trim().Replace("'", "''");
            mainMaster.dupcompInfo.Dup_email = txt_Email.Text.Trim().Replace("'", "''");
            mainMaster.dupcompInfo.Dup_address = txt_Address.Text.Trim().Replace("'", "''");
            mainMaster.dupcompInfo.Dup_city = txt_City.Text.Trim().Replace("'", "''");
            mainMaster.dupcompInfo.Dup_StateName = txt_State.Text;
            mainMaster.dupcompInfo.Dup_country = txt_Country.Text;
            mainMaster.dupcompInfo.Dup_Location = cmb_Drive.Text + "MSMDatabase";
            if (ToPerform == "Insert") mainMaster.dupcompInfo.Dup_catalog = initial;
            else mainMaster.dupcompInfo.Dup_catalog = Global.InitialCatalogMain;
            mainMaster.dupcompInfo.Dup_UserID = Global.LoginID;

            return mainMaster.CompanyInfo();
            
        }

        public int CreateTables()
        {
            var Query = Execute.ExecuteNonQueryOnMain(Resource.MSM_TABLE_CREATE);
            if(Query != 0) return 1;
            else return 0;
        }
        public int CreateDatabase()
        {
            int rndnum = rnd.Next(1000);
            var ext = EXT.ToString();
            var companeyName = (txtCompName.Text.Substring(0, 4).Trim().Replace(" ", "").ToUpper()).Replace("'","''");
            initial = ext + companeyName + rndnum;
            location = cmb_Drive.Text;
            string dir = $@"{location}MSMDatabase"; // If directory does not exist, create it.
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            var Query = $@"CREATE DATABASE [{initial}]
                            CONTAINMENT = NONE
                            ON  PRIMARY 
                            ( NAME = N'{initial}', FILENAME = N'{location}MSMDatabase\{initial}.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
                            LOG ON 
                            ( NAME = N'{initial}_log', FILENAME = N'{location}MSMDatabase\{initial}.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
                            ALTER DATABASE [{initial}] SET COMPATIBILITY_LEVEL = 150
                            IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
                            begin
                            EXEC [{initial}].[dbo].[sp_fulltext_database] @action = 'enable'
                            end";
            var exe = Execute.ExecuteNonQueryOnMain(Query);
            if (exe != 0)
            {
                Global.InitialCatalogMain = initial;
                if (CreateTables() == 1)
                {
                    //MessageBox.Show("Company And Database Created successfully...!!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return 1;

                }
                else return 0;
  
            }
            else
            {
                MessageBox.Show("Error in Creation...!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

        }

        private void globalTab_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar is (char)Keys.Enter) SendKeys.Send("{TAB}");
        }
       

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            btn_Close.PerformClick();
        }

        private void btn_Save_Click(object sender, EventArgs e)  // this is new button in display
        {
            clear();
            ToPerform = "Insert";
            FormStatus(false, true);
            txtCompName.Focus();
        }
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            clear();
            ToPerform = "Update";
            FormStatus(false, true);
            txtCompName.Focus();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            clear();
            ToPerform = "Delete";
            FormStatus(false, true);
            btn_Search.Enabled = true;
            //Btn_Ok.Focus();
        }

        private void btn_CompDelete_Click(object sender, EventArgs e)
        {
            ToPerform = "Delete";
            FormStatus(true, true);
            btn_Delete.Visible = false;
            btn_Edit.Visible = false;
            Btn_Ok.PerformClick();
            Btn_Ok.Enabled = false;
        }

        private void lbl_AddCountry_Click(object sender, EventArgs e)
        {
            var frm = new frm_Country_State(true);
            frm.ShowDialog();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to Close...!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            if(IsMDIActive == 1) this.Close();
            else Application.Exit();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            if (MouseBtn == 1)
            {
                clear();
                FormStatus(true, false);
                State_Country_Load();
            }
            else
            {
                if (MessageBox.Show("Are you sure to Refresh...!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                clear();
                FormStatus(true, false);
                State_Country_Load();
            }
            
        }

        //public static void Calculate(int i)
        //{
        //    var pow = Math.Pow(i, i);
        //}
        //public static void DoWork(IProgress<int> progress)
        //{
        //    for (var j = 0; j < 100000; j++)
        //    {
        //        Calculate(j);
        //        progress?.Report((j + 1) * 100 / 100000);
        //    }
        //}
        //public async void BtnProgressBar_Click(object sender, EventArgs e)
        //{

        //}

        private void BtnProgressBar_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {
                // Wait 50 milliseconds.  
                Thread.Sleep(50);
                // Report progress.  
                backgroundWorker.ReportProgress(i);
            }
        }

        private void BtnProgressBar_ProgressChanged(object sender,
            ProgressChangedEventArgs e)
        {
            // Change the value of the ProgressBar  
            BtnProgressBar.Value = e.ProgressPercentage;
            // Set the text.  
            this.Text = "Progress: " + e.ProgressPercentage.ToString() + "%";
        }

        private void Btn_Ok_Click(object sender, EventArgs e) // this is save button in the display
        {
            try
            {
                backgroundWorker.WorkerReportsProgress = true;
                backgroundWorker.RunWorkerAsync();
                //progress bar implememtation starts

                switch (ToPerform)
                {
                    case "Insert":
                        {
                            if (FormIsOK())
                            {
                                ////PleaseWait.Show();
                                if (CreateDatabase() == 1)
                                {
                                    if (Company_Setup() != 0)
                                    {
                                        ////PleaseWait.Close();
                                        MessageBox.Show($@"Company {ToPerform} successfully Done...!!.", "Done..!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        if (IsMDIActive == 1) //this.Hide();
                                        {
                                            if (MessageBox.Show("Application will Restart", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                                            Close();
                                            Application.Exit();
                                            Process.Start("MyStoreManager.exe");
                                            return;
                                        }
                                        else
                                        {
                                            Close();
                                            Application.Exit();
                                            Process.Start("MyStoreManager.exe");
                                            return;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                //PleaseWait.Close();
                                MessageBox.Show("Error...!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            break;
                        }
                    case "Update":
                        {
                            if (FormIsOK())
                            {
                                //PleaseWait.Show();
                                if (Company_Setup() != 0)
                                {
                                    //PleaseWait.Close();
                                    MessageBox.Show($@"Company {ToPerform} successfully Done...!!.", "Done..!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    if (IsMDIActive == 1) this.Hide();
                                    else
                                    {
                                        Close();
                                        Application.Exit();
                                        Process.Start("MyStoreManager.exe");
                                        return;
                                    }
                                }
                            }
                            break;
                        }
                    case "Delete":
                        {
                            if (FormIsOK())
                            {
                                //PleaseWait.Show();
                                if (ID != 0)
                                {
                                    Company_Setup();
                                    if (ToPerform == "Delete")
                                    {
                                        var Kill = $@"USE MASTER
			                                            DECLARE @SQL AS VARCHAR(20), @SPID AS INT
			                                            SELECT @SPID = MIN(SPID)  FROM MASTER..SYSPROCESSES  WHERE DBID = DB_ID('{database}') AND SPID != @@SPID
			                                            WHILE (@SPID IS NOT NULL)
			                                            BEGIN
			                                            -- PRINT 'KILLING PROCESS ' + CAST(@SPID AS VARCHAR) + ' ...'
			                                            SET @SQL = 'KILL ' + CAST(@SPID AS VARCHAR)
			                                            EXEC (@SQL)
			                                            SELECT
				                                            @SPID = MIN(SPID)
			                                            FROM
				                                            MASTER..SYSPROCESSES
			                                            WHERE
				                                            DBID = DB_ID('{database}')
				                                            AND SPID != @@SPID
			                                            END
			                                            --PRINT 'PROCESS COMPLETED...'";
                                        var killconn = Execute.ExecuteNonQueryMaster(Kill);
                                        if (killconn != 0)
                                        {
                                            var dropdb = $@"DROP DATABASE {database}";
                                            var killconndropdb = Execute.ExecuteNonQueryMaster(dropdb);
                                            var val = killconndropdb;
                                            if (killconndropdb != 0)
                                            {
                                                //PleaseWait.Close();
                                                MessageBox.Show($@"Company {ToPerform} successfully Done...!!.", "Done..!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                Close();
                                                Application.Exit();
                                                Process.Start("MyStoreManager.exe");

                                            }
                                            else
                                            {
                                                //PleaseWait.Close();
                                                MessageBox.Show($@"Company {ToPerform} Partially Completed...!!, Please Close and Start application.", "Partially Deleted..!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                Close();
                                                Application.Exit();
                                                Process.Start("MyStoreManager.exe");
                                            }
                                        }

                                    }


                                }
                            }
                            break;
                        }
                }
            }
            catch
            {
                //ignore
            }
            
        }

        private void txt_Contact_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_Contact.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txt_Contact.Text = txt_Contact.Text.Remove(txt_Contact.Text.Length - 1);
            }
        }

        private void txtCompName_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCompName.Text) && txtCompName.Text.Length < 4)
            {
                MessageBox.Show("Minimum 4 three character required..!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtCompName.Focus();
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            btn_Search.Enabled = false;
            if (ToPerform == "Insert") return;
            var popup = new frm_PopUpSearch(ID, TableName, DbName, "LoginCompanySelect",0, string.Empty, 0);
            if (frm_PopUpSearch.dt.Rows.Count > 0)
            {
                popup.ShowDialog();
                if (popup.SelectedRow.Count > 0)
                {
                    //CID = Int64.Parse(popup.SelectedRow[0]["cid"].ToString());
                    //ID = (int)CID;
                    ID = (int)popup.SelectedRow[0]["cid"];
                    txtCompName.Text = popup.SelectedRow[0]["cname"].ToString();
                    txt_Registration.Text = popup.SelectedRow[0]["regno"].ToString();
                    var Contact = popup.SelectedRow[0]["contact"].ToString();
                    if (Contact == "NULL") txt_Contact.Text = "";
                    else txt_Contact.Text = Contact;
                    txt_Email.Text = popup.SelectedRow[0]["email"].ToString();
                    txt_Address.Text = popup.SelectedRow[0]["address"].ToString();
                    txt_City.Text = popup.SelectedRow[0]["city"].ToString();
                    txt_State.Text = popup.SelectedRow[0]["StateName"].ToString();
                    txt_Country.Text = popup.SelectedRow[0]["country"].ToString();
                    var Drive = popup.SelectedRow[0]["Location"].ToString();
                    cmb_Drive.Text = drive = Drive.Substring(0, 3);
                    if (ToPerform == "Delete")
                    {
                        btn_Save.Enabled = true;
                        btn_Save.Focus();
                    }
                }
            }
            else
            {
                MessageBox.Show("No Data..!!", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        //Removed perpously--form wont work when database is not created
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //panel1.BackColor = mainMaster.BackgroundColor();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MouseBtn = 1;
            btn_Refresh_Click(sender, e);
        }

        public void getCountryorState()
        {
            var dt = mainMaster.Get_State();
            if (dt == null) return;
            var popup = new frm_PopUpSearch(0, TableName, DbName, "CountryOrStateList", 0, string.Empty, 0);
            {
                popup.ShowDialog();
                if (popup.SelectedRow.Count > 0)
                {
                    txt_State.Text = popup.SelectedRow[0]["StateName"].ToString();
                    txt_Country.Text = popup.SelectedRow[0]["CountryName"].ToString();
                }
            }
        }

        private void txt_State_KeyDown(object sender, KeyEventArgs e)
        {
            if (ToPerform != "Delete" && e.KeyCode is Keys.F1)
            {
                getCountryorState();
            }
            if (e.Control is true && e.KeyCode is Keys.N)
            {
                var frm = new frm_Country_State(true);
                frm.ShowDialog();
                txt_Country.Text = frm.country;
                txt_State.Text = frm.state;
                return;
            }
        }
    }
}
