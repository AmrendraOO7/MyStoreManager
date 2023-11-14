using MSMControl.Connection;
using MSMControl.ProgressBar;
using MyStoreManager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MSMControl.DataBase
{
    public partial class Frm_Server_Entry : Form
    {
        public SqlConnection MasCon;
        public SqlConnection Con;
        public SqlCommand Cmd;
        public SqlDataAdapter Sda;
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();

        // public string ExeQuery = string.Empty;


        public static string ServerDesc = string.Empty;
        public static string Database = string.Empty;   //"DESKTOP-RJRSTJN\\MY_WORK_LAB";//"(LocalDB)\\MSSQLLocalDB";
        public static string InitialCatalogMaster = "master";//string.Empty;
        public static string UserId = string.Empty;    //"sa";
        public static string Password = string.Empty;   //"321";

        public string Query = string.Empty;
        private int IsOk;
        public string NonQuery = string.Empty;
        public string CreateTable = string.Empty;

        public Frm_Server_Entry()
        {
            InitializeComponent();
        }


        internal bool Validcheck()
        {
            if (string.IsNullOrEmpty(txtServer.Text.Trim()))
            {
                MessageBox.Show("Server Address is Blank..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtServer.Focus();
                return false;
            }

            else if (string.IsNullOrEmpty(txtUserID.Text.Trim()))
            {
                MessageBox.Show("UserID is Blank..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Password is Blank..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return true;
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            if (Validcheck())
            {
                if (!string.IsNullOrWhiteSpace(txtServer.Text.Trim().Replace("'", "''")))
                {
                    Database = txtServer.Text.Trim().Replace("'", "''");
                    UserId = txtUserID.Text.Trim().Replace("'", "''");
                    Password = txtPassword.Text.Trim().Replace("'", "''");
                    Global.ServerName = Database;
                    Global.UserId = UserId;
                    Global.Password = Password;
                    Global.InitialCatalogMaster = InitialCatalogMaster;
                    Query = @"SELECT DISTINCT 1 as IsExists FROM dbo.sysobjects where id = object_id('[dbo].[master.ServerConnInfo]')";
                    var dt = Execute.ExecuteDataSetOnLocalMaster(Query).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        Load_Function();
                    }
                    else if (dt.Rows.Count == 0)
                    {
                        CreateTable = $@"CREATE TABLE [master.ServerConnInfo] ([ServerID] [int] IDENTITY(1,1),[ServerName] [nvarchar](200) NOT NULL,[UserId] [varchar](20) NULL,UserPassword nvarchar(20) NULL);"+
                                        "INSERT INTO dbo.[master.ServerConnInfo] (ServerName, UserId, UserPassword) values('" + Database + "','" + UserId + "', '" + Password + "');" +
                                        "CREATE TABLE [dbo].[master.CompanyMasterInfo] ([cid] [int] NOT NULL,[cname] [varchar](100) NULL,[regno] [varchar](30) NULL,[address] [varchar](200) NULL,[contact] [varchar](50) NULL,[email] [varchar](100) NULL,[city] [varchar](100) NULL,[country] [varchar](20) NULL,[catalog] [varchar](50) NOT NULL,[Location] [varchar](100) NULL,[StateName] varchar (100) NULL) ; " +
                                        "CREATE TABLE [dbo].[master.ComboBoxVal](CbId int identity(1,1) not null,StateName nvarchar(30),Country nvarchar(30),constraint PK_CbId  primary key (CbId)); " +
                                        "INSERT INTO [dbo].[master.ComboBoxVal] ([StateName], [Country]) VALUES('Province No. 1','Nepal'),('Madhesh Province','Nepal'),('Bagmati Province','Nepal'),('Gandaki Province','Nepal'),('Lumbini Province','Nepal'),('Karnali Province','Nepal'),('Sudurpashchim Province','Nepal');";
                        IsOk =  Execute.ExecuteNonQueryLocalMaster(CreateTable);
                        if(IsOk != 0)
                        {
                            Load_Function();
                        }
                    }
                    else
                    {
                        MessageBox.Show("System Error Please Contact System Provider", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Server Address is Blank..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtServer.Focus();
            }

        }


        public void Close_Function()
        {
            this.Close();
        }
        public void Load_Function()
        {
            this.Hide();
            var Frm = new DisplayScreen();
            Frm.ShowDialog();
        }


        private void Frm_Server_Entry_Load(object sender, EventArgs e)
        {
            ////SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            ////DataTable table = instance.GetDataSources();
            ////string ServerName = Environment.MachineName;
            ////Global.ServerName = ServerName.ToString();
            Query = @"SELECT DISTINCT 1 as IsExists FROM dbo.sysobjects where id = object_id('[dbo].[master.ServerConnInfo]')";
            var dt = Execute.ExecuteDataSetOnLocalMaster(Query).Tables[0];
            if (dt.Rows.Count > 0)
            {
                Query = @"select * from [master.ServerConnInfo] where ServerID = 1";
                var dat = Execute.ExecuteDataSetOnLocalMaster(Query).Tables[0];
                if (dat.Rows.Count <= 0) return;
                txtServer.Text = dat.Rows[0]["ServerName"].ToString();
                txtUserID.Text = dat.Rows[0]["UserId"].ToString();
                txtPassword.Text = dat.Rows[0]["UserPassword"].ToString();
                btn_Connect.PerformClick();
            }
            else
            {
                txtServer.Clear();
                txtUserID.Clear();
                txtPassword.Clear();
                txtServer.Focus();
            }
        }

        private void globalTab_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar is (char)Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

