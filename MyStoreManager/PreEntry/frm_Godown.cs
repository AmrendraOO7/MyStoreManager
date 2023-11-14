using MSMControl.Class;
using MSMControl.Connection;
using MSMControl.Interface;
using MyStoreManager.BillEntry.Purchase;
using MyStoreManager.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStoreManager.PreEntry
{
    public partial class frm_Godown : Form
    {
        #region Global
        private string ToPerform;
        private int GodownID;
        private string DbName = Global.InitialCatalogMain;
        private string UserTable = "MSM.StoreGodown";
        private int MouseBtn = 0;
        public int Godownid;                            //shared with multiple froms.
        public string GodownName = string.Empty;        //shared with multiple froms.
        public string GodownCode = string.Empty;        //shared with multiple froms.
        public string Status = string.Empty;
        
        private readonly bool _NewEntry;
        private readonly IMainMaster mainMaster = new ClsMainMaster();
        public frm_Godown(bool NewEntry)
        {
            InitializeComponent();
            _NewEntry = NewEntry;
        }
        #endregion

        #region Event

        private void btn_Save_Click(object sender, EventArgs e)
        {
            ToPerform = "Insert";
            FormStatus(false, true);
            txtreadonly(false);
            txtGodown.Focus();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            ToPerform = "Update";
            FormStatus(false, true);
            txtreadonly(true);
            txtGodown.Focus();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            ToPerform = "Delete";
            FormStatus(false, true);
            txtreadonly(true);
            txtGodown.Focus();
        }

        private void globalTab_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar is (char)Keys.Enter) SendKeys.Send("{TAB}");
        }
        private void txtGodown_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtGodown.Text.Trim()) && ToPerform is "Insert")
                txtGodownID.Text = string.IsNullOrEmpty(txtGodownID.Text.Trim().Replace("'", "''")) ?
                    ClsIncrement.AutoIncrement("Godown", txtGodown.Text.Trim().Replace("'", "''"))
                    : txtGodownID.Text.Trim();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            btn_Search.Enabled = false;
            if (ToPerform == "Update") txtreadonly(false);
            else if (ToPerform == "Delete")
            {
                FormStatus(false, false);
                txtGodown.Enabled = Btn_Ok.Enabled = true;
                Btn_Ok.Focus();
            }
            if (ToPerform == "Insert") return;
            var popup = new frm_PopUpSearch(GodownID, UserTable, DbName, "GetGodown", 0, string.Empty, 0);
            if (frm_PopUpSearch.dt.Rows.Count > 0)
            {
                popup.ShowDialog();
                if (popup.SelectedRow.Count > 0)
                {
                    GodownID = (int)popup.SelectedRow[0]["GodID"];
                    txtGodown.Text = popup.SelectedRow[0]["GodName"].ToString();
                    txtGodownID.Text = GodownCode = popup.SelectedRow[0]["GodCode"].ToString();
                    txtAddress.Text = popup.SelectedRow[0]["GodAddress"].ToString();
                    Status = popup.SelectedRow[0]["ActiveStatus"].ToString();
                    if (Status == "True") chk_Status.Checked = true;
                    else chk_Status.Checked = false;
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

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MouseBtn = 1;
            btn_Refresh_Click(sender, e);
        }

        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            if (ToPerform is null) return;
            if (FormIsOK())
            {
                //progress bar implememtation starts
                
                
                if (GodownSetup() != 0)
                {
                    if (_NewEntry) // function to access data from another form
                    {
                        Godownid = GodownID;
                        GodownName = txtGodown.Text;
                        
                        Close();
                        return;
                    }
                    
                    MessageBox.Show($@"{ToPerform.ToUpper()} Done...!!!", "Done", MessageBoxButtons.OK, MessageBoxIcon.None);
                    clear();
                    FormStatus(true, false);
                    if (_NewEntry)
                    {
                        //var frm = new frm_PurchaseOrder();
                        Close();
                        MessageBox.Show("You must refresh the page to take Effect", "Done", MessageBoxButtons.OK, MessageBoxIcon.None);
                        //frm.refreshToolStripMenuItem_Click(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show($@"{ToPerform.ToUpper()} Error...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.None);
                    txtGodown.Focus();
                }
            }
        }

        private void txtGodownID_Validating(object sender, CancelEventArgs e)
        {
            if (GodownCode != txtGodownID.Text.ToString())
            {
                var dt = mainMaster.CheckAvailability("MSM.StoreGodown", "GodCode", txtGodownID.Text.Trim());
                if (dt == null || dt.Rows.Count <= 0) return;
                MessageBox.Show(@"Code Is Taken..!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGodownID.Focus();
            }
        }
        private void txtGodown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.F1 && txtGodown.ReadOnly is true) btn_Search.PerformClick();
        }
        #endregion

        #region Methods
        public void FormStatus(bool btn, bool txt)
        {
            txtGodown.Enabled = txtGodownID.Enabled = Btn_Ok.Enabled = btn_Search.Enabled = txtAddress.Enabled = chk_Status.Enabled = txt;
            btn_Delete.Enabled = btn_Edit.Enabled = btn_Save.Enabled = btn;
            btn_Save.Focus();
        }

        private void txtreadonly(bool ReadOnly)
        {
            txtGodown.ReadOnly = txtGodownID.ReadOnly = ReadOnly;
        }
        public bool FormIsOK()
        {
            if (string.IsNullOrWhiteSpace(txtGodown.Text.Trim()))
            {
                MessageBox.Show("You must Enter Godown Name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGodown.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtGodownID.Text.Trim()))
            {
                MessageBox.Show("You must Enter Godown Code", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGodownID.Focus();
                return false;
            }
            else return true;
        }
        public void clear()
        {
            GodownID = 0;
            ToPerform = string.Empty;
            MouseBtn = 0;
            txtAddress.Clear();
            txtGodown.Clear();
            txtGodownID.Clear();
            chk_Status.Checked = true;
            txtreadonly(true);
        }
        public int GodownSetup()
        {
            mainMaster.GodownMaster.ToPerform = ToPerform;
            mainMaster.GodownMaster.GodID = ToPerform is "Insert" ? ClsMainMaster.getInt("MSM.StoreGodown", "GodID") : GodownID;
            mainMaster.GodownMaster.GodName = txtGodown.Text.Trim().Replace("'", "''");
            mainMaster.GodownMaster.GodCode = txtGodownID.Text.Trim().Replace("'", "''");
            mainMaster.GodownMaster.GodAddress = txtAddress.Text.Trim().Replace("'", "''");
            mainMaster.GodownMaster.ActiveStatus = chk_Status.Checked;
            mainMaster.GodownMaster.UserID = Global.LoginID;
            return mainMaster.GodownSetup();
        }
        #endregion

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = ColorTranslator.FromHtml(Global.BackgroundColor);
        }
    }
}
