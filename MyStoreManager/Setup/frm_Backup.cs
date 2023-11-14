using ExcelLibrary.BinaryFileFormat;
using MSMControl.Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStoreManager.Setup
{
    public partial class frm_Backup : Form
    {
        public string serverInstanceName = string.Empty;
        DriveInfo[] allDrives = DriveInfo.GetDrives();
        public frm_Backup()
        {
            InitializeComponent();
        }

        private void frm_Backup_Load(object sender, EventArgs e)
        {
            circularProgressBar.Visible = false;
            lbl_Status.Visible = false;
            cmb_Drive.DataSource = allDrives;
        }

        public void backup()
        {
            string drive = cmb_Drive.Text;
            string databaseName = Global.InitialCatalogMain;
            drive = drive + $"{databaseName}";
            lbl_Status.Visible = true;
            lbl_Status.Text = "Please wait we are taking your database Backup....";
            //var query = "DECLARE @FileName varchar(1000);\n" + $@"SELECT @FileName = (SELECT '{drive}' + '-' + CONVERT(VARCHAR(500),GETDATE(), 105) + '.bak')" + "\n" + $@"BACKUP DATABASE {databaseName} TO DISK = @FileName";
            //var query = "Backup database " + ClsGlobal.InitialCatalogMain + " to disk='" + drive + "'";

            var query = $@"DECLARE @FileName varchar(1000); SELECT @FileName = '{drive}' + CONVERT(VARCHAR(500), GETDATE(), 105) + '.bak'; BACKUP DATABASE[{databaseName}] TO DISK = @FileName; ";
            var ok = Execute.ExecuteNonQueryOnMain(query);
            if (ok != 0)
            {
                lbl_Status.Visible = true;
                lbl_Status.Text = "Database BackUp has been created successfully.";
            }
            else
            {
                lbl_Status.Visible = true;
                lbl_Status.Text = "Database BackUp has been Failed.";
            }

        }

        public void processBar(object sender, EventArgs e)
        {
            circularProgressBar.Visible = true;
            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(5);
                circularProgressBar.Value = i;
                circularProgressBar.Text = i.ToString() + "%";
                circularProgressBar.Update();
            }
        }

        private void btn_Backup_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to take backup?", "Queestion", MessageBoxButtons.YesNo) == DialogResult.No) return;
            circularProgressBar.Visible = true;
            processBar(sender, e);
            backup();
            circularProgressBar.Visible = false;
            MessageBox.Show($@"{lbl_Status.Text}", "Info.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            panel.BackColor = ColorTranslator.FromHtml(Global.BackgroundColor);
        }
    }
}
