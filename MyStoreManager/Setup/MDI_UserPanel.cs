using MSMControl.Connection;
using MSMControl.DataBase;
using MSMControl.Properties;
using MyStoreManager.BillEntry.Purchase;
using MyStoreManager.BillEntry.Sales;
using MyStoreManager.PleaseWaitControl;
using MyStoreManager.PreEntry;
using MyStoreManager.Print;
using MyStoreManager.Production;
using MyStoreManager.RDLC_Reports;
using MyStoreManager.Reports;
using MyStoreManager.spinner;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStoreManager.Setup
{
    public partial class MDI_UserPanel : Form
    {

        #region Global
        public static int IsFormActive = 0;
        public static string MDI_Action = string.Empty;

        public MDI_UserPanel()
        {
            InitializeComponent();
        }
        #endregion

        #region Functions
        public void FullScreen()
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }

        public void StatusStripLoad()
        {
            timer.Start();
            toolStripUserLabel.Text = "Login User:-" + Global.LoginUser + " /";
            toolStripDBLabel.Text = "Database:-" + Global.InitialCatalogMain + " /";
            toolStripDateLabel.Text = "Date:-" + DateTime.Now.ToLongDateString() + " /";
            toolStripInstanceLabel.Text = "Server Instance:-" + Global.ServerName + " /";
            toolStripFiscalYearLabel.Text = "Transection Year:-" + Global.CurrentYear + "/";
            toolStripLicenseDays.Text = "License:- " + Global.remainingDays +" Days Remaining";

            toolStripCompanyLabel.Text = "Company Name:-" + Global.CompanyName + " /";
            toolStripRegistrationLabel.Text = "Registration:-" + Global.Registration + " /";
            toolStripContactLabel.Text = "Contact:-" + Global.Contact + " /";
            toolStripAddressLabel.Text = "Address:-" + Global.Address + " /";
            toolStripCityLabel.Text = "City:-" + Global.City + " /";
            toolStripStateLabel.Text = "State:-" + Global.State + " /";
            toolStripCountryLabel.Text = "Country:-" + Global.Country;
        }
        #endregion

        #region Events
        private void MDI_UserPanel_Load(object sender, EventArgs e)
        {
            FullScreen();
            Global.IsFormActive = IsFormActive = 1;
            StatusStripLoad();
        }
        private void MDI_UserPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        //Custom minimize function
        //private void btn_Minimize_Click(object sender, EventArgs e)
        //{
        //    if (this.WindowState == FormWindowState.Maximized)
        //    {
        //        this.WindowState = FormWindowState.Minimized;
        //    }
        //}
        //Custom close function
        //private void btn_Close_Click(object sender, EventArgs e)
        //{
        //    if (MessageBox.Show("Are you sure to Close...!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
        //    else Application.Exit();
        //}
        private void timer_Tick(object sender, EventArgs e)
        {
            toolStripTimeLabel.Text = "Time:-" + DateTime.Now.ToLongTimeString() + " /";
            timer.Start();
        }

        private void roleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var IsPassed = Global.IsAdmin;
            var Session = Global.CurrentSession;
            if (IsPassed is 1 || Session is 1) new frm_RoleSetup().ShowDialog();
            else
            {
                if (MessageBox.Show("You Dont have Admin Permission. Click yes to Admin login!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                sessionPermissionToolStripMenuItem_Click(sender, e);
            }
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var IsPassed = Global.IsAdmin;
            var Session = Global.CurrentSession;
            if (IsPassed is 1 || Session is 1) new frm_UserEntry().ShowDialog();
            else
            {
                if (MessageBox.Show("You Dont have Admin Permission. Click yes to Admin login!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                sessionPermissionToolStripMenuItem_Click(sender, e);
            }
        }
        private void companySettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var IsPassed = Global.IsAdmin;
            var Session = Global.CurrentSession;
            if (IsPassed is 1 || Session is 1) new frm_CompanySetup().ShowDialog();
            else
            {
                if (MessageBox.Show("You Dont have Admin Permission. Click yes to Admin login!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                sessionPermissionToolStripMenuItem_Click(sender, e);
            }
        }

        private void stateCountryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frm_Country_State(false).ShowDialog();
        }

        private void changeDatabaseInstanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var IsPassed = Global.IsAdmin;
            if (IsPassed is 1) new frm_InstenceChange().ShowDialog();
            else
            {
                if (MessageBox.Show("You Dont have Admin Permission.\n Ask Admin for Configuration!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK) return;
            }

        }

        private void databaseUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Query = Execute.ExecuteNonQueryOnMainResources(Resource.MSM_UPDATE_TABLE_ON_MAIN);
            if (Query != 0) MessageBox.Show("Database Updated...!!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Database Updated Failed...!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void sessionPermissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDI_Action = "sessionPermission";
            new frm_ChkAdmin().ShowDialog();
        }

        public static void sessionPermission_Click(object sender, EventArgs e)
        {
            MDI_Action = "sessionPermission";
            new frm_ChkAdmin().ShowDialog();
        }
        private void ConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var IsPassed = Global.IsAdmin;
            var IsAdminLogin = Global.LoginID;
            if (IsPassed is 1 || IsAdminLogin is 1) new frm_Configuration().ShowDialog();
            else
            {
                if (MessageBox.Show("You Dont have Admin Permission. Click yes to Admin login!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                MDI_Action = "Configuration";
                new frm_ChkAdmin().ShowDialog();
            }
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to Restart...!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            Close();
            Application.Exit();
            Process.Start("MyStoreManager.exe");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to Close...!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            Close();
            Application.Exit();

        }

        private void unitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var IsPassed = Global.IsAdmin;
            var Session = Global.CurrentSession;
            if (IsPassed is 1 || Session is 1) new frm_Unit(false).ShowDialog();
            else
            {
                if (MessageBox.Show("You Dont have Admin Permission. Click yes to Admin login!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                sessionPermissionToolStripMenuItem_Click(sender, e);
            }
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var IsPassed = Global.IsAdmin;
            var Session = Global.CurrentSession;
            if (IsPassed is 1 || Session is 1) new frm_CustomerEntry(false).ShowDialog();
            else
            {
                if (MessageBox.Show("You Dont have Admin Permission. Click yes to Admin login!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                sessionPermissionToolStripMenuItem_Click(sender, e);
            }
        }
        private void productCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frm_ProductTypes(false).ShowDialog();
        }
        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var IsPassed = Global.IsAdmin;
            var Session = Global.CurrentSession;
            if (IsPassed is 1 || Session is 1) new frm_ProductEntry(false).ShowDialog();
            else
            {
                if (MessageBox.Show("You Dont have Admin Permission. Click yes to Admin login!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                sessionPermissionToolStripMenuItem_Click(sender, e);
            }
        }

        private void purchaseOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frm_PurchaseOrder().ShowDialog();
        }

        private void godownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frm_Godown(false).ShowDialog();
        }
        private void printTestingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frm_Print_Data().ShowDialog();
            //new frmSimulSoft().ShowDialog();
        }

        private void purcahseGoodsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frm_PurchaseGoods().ShowDialog();
        }
        private void purchaseReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frm_PurchaseReturn().ShowDialog();
        }
        private void salesEntryPOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frm_sales_Entry().ShowDialog();
        }
        private void salesReturnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new frm_SalesReturn().ShowDialog();
        }

        private void billRePrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new rptPrint(string.Empty, string.Empty).ShowDialog();
        }

        private void orderCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmOrderCard().ShowDialog();
        }

        private void issueSlipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmIssueSlip().ShowDialog();
        }

        private void orderProductionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmOrderProductionStart().ShowDialog();
        }

        private void orderInProductionToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // new frmOrderInProduction().ShowDialog();
        }

        private void orderStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmOrderStatus().ShowDialog();
        }
        private void finishedGoodsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmReadyGoods().ShowDialog();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frm_Backup().ShowDialog();
        }

        private void licenseUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frm_License_Entry().ShowDialog();
        }
        private void spinnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new Spinner().ShowDialog();
            //new pleaseWaitForm().ShowDialog();
        }

        private void reportTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmRDLC_ReportViewer().ShowDialog();
        }

        private void rptGetReports_Click(object sender, EventArgs e)
        {
            new frm_BulkReport().ShowDialog();
        }


        #endregion
    }
}
