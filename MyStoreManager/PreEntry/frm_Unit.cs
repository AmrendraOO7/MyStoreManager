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
    public partial class frm_Unit : Form
    {
        private string ToPerform;
        private int UnitID,UID;
        public int Unitid; //shared with multiple forms
        private System.DateTime dateCreated;
        private readonly IMainMaster mainMaster = new ClsMainMaster();
        private string DbName = Global.InitialCatalogMain;
        private string UserTable = "MSM.UnitMaster";
        private string UnitStatus = string.Empty;
        public string UnitCode = string.Empty; //shared with multiple forms
        public string UnitName = string.Empty; //shared with multiple forms
        private int MouseBtn = 0;
        private readonly bool _NewEntry;

        public frm_Unit(bool NewEntry)
        {
            InitializeComponent();
            _NewEntry = NewEntry;
        }

        public void clear()
        {
            UnitID = UID = 0 ;
            UnitStatus = string.Empty;
            UnitCode = string.Empty;
            ToPerform = string.Empty;
            MouseBtn = 0;
            txtUnit.Clear();
            txtunitCode.Clear();
            txtreadonly(true);
        }

        private void txtreadonly(bool ReadOnly)
        {
            txtUnit.ReadOnly = txtunitCode.ReadOnly = ReadOnly;
        }
        public void FormStatus(bool btn,bool txt)
        {
            txtUnit.Enabled = txtunitCode.Enabled = Btn_Ok.Enabled=btn_Search.Enabled=chk_Status.Enabled = txt;
            btn_Delete.Enabled = btn_Edit.Enabled = btn_Save.Enabled = btn;
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            ToPerform = "Insert";
            FormStatus(false, true);
            txtreadonly(false);
            txtUnit.Focus();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            ToPerform = "Update";
            FormStatus(false, true);
            txtreadonly(true);
            txtUnit.Focus();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            ToPerform = "Delete";
            FormStatus(false, true);
            txtreadonly(true);
            txtUnit.Focus();
        }

        private void frm_Unit_Load(object sender, EventArgs e)
        {
            clear();
            FormStatus(true, false);
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

        private void globalTab_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar is (char)Keys.Enter) SendKeys.Send("{TAB}");
        }

        public bool FormIsOK()
        {
            if (string.IsNullOrWhiteSpace(txtUnit.Text.Trim()))
            {
                MessageBox.Show("You must Enter Unit Name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUnit.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtunitCode.Text.Trim()))
            {
                MessageBox.Show("You must Enter Unit Code", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtunitCode.Focus();
                return false;
            }
            else return true;
        }

        public int UnitSetup()
        {
            mainMaster.UnitEntry.ToPerform = ToPerform;
            UID = mainMaster.UnitEntry.UnitID = ToPerform is "Insert" ? ClsMainMaster.getInt("MSM.UnitMaster", "UnitID") : UnitID;
            mainMaster.UnitEntry.Unit = txtUnit.Text.Trim().Replace("'", "''");
            mainMaster.UnitEntry.UnitCode = txtunitCode.Text.Trim().Replace("'", "''");
            mainMaster.UnitEntry.ActiveStatus = chk_Status.Checked;
            mainMaster.UnitEntry.UserID = Global.LoginID;
            return mainMaster.GetUnitSetup();
        }

        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            if (ToPerform is null) return;
            if(FormIsOK())
            {
                //progress bar implememtation starts
                
                
                if (UnitSetup() != 0)
                {
                    if (_NewEntry) // function to access data from another form
                    {
                        Unitid = UID;
                        UnitCode = txtunitCode.Text;
                        UnitName = txtUnit.Text;                        
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
                    txtUnit.Focus();
                }
            }
        }

        private void txtUnit_Validating(object sender, CancelEventArgs e)
        {
            if(!string.IsNullOrEmpty(txtUnit.Text.Trim()) && ToPerform is "Insert")
                txtunitCode.Text = string.IsNullOrEmpty(txtunitCode.Text.Trim().Replace("'", "''")) ? 
                    ClsIncrement.AutoIncrement("Unit", txtUnit.Text.Trim().Replace("'", "''")) 
                    :txtunitCode.Text.Trim();
        }

        private void txtunitCode_Validating(object sender, CancelEventArgs e)
        {
            if(UnitCode != txtunitCode.Text.ToString())
            {
                var dt = mainMaster.CheckAvailability("MSM.UnitMaster", "UnitCode", txtunitCode.Text.Trim());
                if (dt == null || dt.Rows.Count <= 0) return;
                MessageBox.Show(@"Code Is Taken..!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtunitCode.Focus();
            }
            
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            btn_Search.Enabled = false;
            if (ToPerform == "Update") txtreadonly(false);
            else if (ToPerform == "Delete")
            {
                FormStatus(false, false);
                txtUnit.Enabled = Btn_Ok.Enabled = true;
                Btn_Ok.Focus();
            }
            if (ToPerform == "Insert") return;
            var popup = new frm_PopUpSearch(UnitID, UserTable, DbName, "GetUnit",0, string.Empty, 0);
            if (frm_PopUpSearch.dt.Rows.Count > 0)
            {
                popup.ShowDialog();
                if (popup.SelectedRow.Count > 0)
                {
                    UnitID = (int)popup.SelectedRow[0]["UnitID"];
                    txtUnit.Text = popup.SelectedRow[0]["Unit"].ToString();
                    txtunitCode.Text= UnitCode = popup.SelectedRow[0]["UnitCode"].ToString();
                    UnitStatus = popup.SelectedRow[0]["ActiveStatus"].ToString();
                    if (UnitStatus == "True") chk_Status.Checked = true;
                    else chk_Status.Checked = false;
                }
            }
            else
            {
                MessageBox.Show("No Data..!!", "Stop..!!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = ColorTranslator.FromHtml(Global.BackgroundColor);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MouseBtn = 1;
            btn_Refresh_Click(sender, e);
        }

        private void txtUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.F1 && ToPerform is "Update" || ToPerform is "Delete" && txtUnit.ReadOnly is true)
            {
                btn_Search.PerformClick();
            }
        }
    }
}
