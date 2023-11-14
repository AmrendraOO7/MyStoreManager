using MSMControl.Connection;
using MSMControl.ProgressBar;
using MSMControl.Properties;
using MyStoreManager.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSMControl
{
    public partial class DisplayScreen : Form
    {
        public string Query = string.Empty;
        public int ID = 0;
        public long CID = 0;
        public string TableName = "[dbo].[master.CompanyMasterInfo]";
        public string DbName = "master";
        public DisplayScreen()
        {
            InitializeComponent();
        }

        private Task ProcessData(List<string> list, IProgress<DisplayProBar> progress)
        {
            int index = 1;
            int totalProcess = list.Count;
            var progressReport = new DisplayProBar();
            return Task.Run(() =>
            {
                for (int i = 0; i <= totalProcess; i++)
                {
                    progressReport.processPerCent = index++ * 100 / totalProcess;
                    progress.Report(progressReport);
                    Thread.Sleep(5); //used to simulate length
                }
            });
        }

        private bool CompanyCheck()
        {
            var popup = new frm_PopUpSearch(ID, TableName, DbName, "CompanySelect",0,string.Empty, 0);
            if (frm_PopUpSearch.dt.Rows.Count > 0)
            {
                popup.ShowDialog();
                if (popup.SelectedRow.Count > 0)
                {
                    CID = Int64.Parse(popup.SelectedRow[0]["cid"].ToString());
                    ID = (int)CID;
                    Query = $@"SELECT * FROM dbo.[master.CompanyMasterInfo] ci ,dbo.[master.ServerConnInfo] sc where ci.cid = {ID};";
                    var dt = Execute.ExecuteDataSetOnLocalMaster(Query).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        Global.CompanyID = CID;
                        Global.CompanyName= dt.Rows[0]["cname"].ToString();
                        Global.Registration= dt.Rows[0]["regno"].ToString();
                        Global.Contact= dt.Rows[0]["contact"].ToString();
                        Global.Address = dt.Rows[0]["address"].ToString();
                        Global.State = dt.Rows[0]["StateName"].ToString();
                        Global.City = dt.Rows[0]["city"].ToString();
                        Global.Country = dt.Rows[0]["country"].ToString();
                        Global.ServerName = dt.Rows[0]["ServerName"].ToString();
                        Global.InitialCatalogMain = dt.Rows[0]["catalog"].ToString();
                        Global.UserId = dt.Rows[0]["UserId"].ToString();
                        Global.Password = dt.Rows[0]["UserPassword"].ToString();
                        Global.InitialCatalogMaster = "master";
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
            //Query = @"select * from [dbo].[master.CompanyMasterInfo] where cid = 1;";
            //var CompInfo = Execute.ExecuteDataSetOnLocalMaster(Query).Tables[0];
            //if (CompInfo.Rows.Count > 0)
            //{


            //}
        }

        //public void checkUpdate()
        //{
        //    var Query = Execute.ExecuteNonQueryOnMainResources(Resource.MSM_UPDATE_TABLE_ON_MAIN);
        //}
        private async void DisplayScreen_Load(object sender, EventArgs e)
        {
            progressBar.ForeColor = Color.BlueViolet;
            List<string> list = new List<string>();
            for (int i = 0; i <= 250; i++)
                list.Add(i.ToString());
            lbl_Loading.Text = "Loading...";
            var progress = new Progress<DisplayProBar>();
            progress.ProgressChanged += (o, report) =>
            {
                lbl_Loading.Text = string.Format("Loading...{0}%", report.processPerCent);
                progressBar.Value = report.processPerCent;
                progressBar.Update();
            };
            await ProcessData(list, progress);
            lbl_Loading.Text = "Completed...";
            this.Hide();
            if(CompanyCheck())
            {
                var usrLogin = new frm_UserLogin();
                usrLogin.ShowDialog();
            }
            else
            {
                var CompanySetup = new frm_CompanySetup();
                CompanySetup.ShowDialog();
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
