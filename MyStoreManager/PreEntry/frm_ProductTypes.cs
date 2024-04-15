using MSMControl.Class;
using MSMControl.Connection;
using MSMControl.Interface;
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
    public partial class frm_ProductTypes : Form
    {
        private readonly IMainMaster mainMaster = new ClsMainMaster();
        private int TypeID = 0;
        private string ToPerform = string.Empty;
        public int CategoryID;
        public string CategoryCode = string.Empty;
        public string ProdType = string.Empty;
        private readonly bool _NewEntry;
        private int MouseBtn = 0;
        private string DbName = Global.InitialCatalogMain;
        private string UserTable = "MSM.ProductCategory";
        private string UnitStatus = string.Empty;

        public frm_ProductTypes(bool NewEntry)
        {
            InitializeComponent();
            _NewEntry = NewEntry;
        }

        public void FormStatus(bool btn, bool txt)
        {
            btn_Delete.Enabled = btn_Edit.Enabled = btn_Save.Enabled = btn;
            txt_Name.Enabled = txtCategoryCode.Enabled = btn_Search.Enabled = Btn_Ok.Enabled = txt;
        }
        private void txtreadonly(bool ReadOnly)
        {
            txt_Name.ReadOnly= txtCategoryCode.ReadOnly =  ReadOnly;
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            panel.BackColor = ColorTranslator.FromHtml(Global.BackgroundColor);
        }

        public void clear()
        {
            TypeID = 0;
            ToPerform = string.Empty;
            ProdType = string.Empty;
            MouseBtn = 0;
            txt_Name.Clear();
            txtCategoryCode.Clear();
            chk_Status.Checked = true;
            txtreadonly(true);
        }

        public bool FormIsOK()
        {
            if (ToPerform != null)
            {
                if (MessageBox.Show($@"Are you sure to {ToPerform}...!!", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return false;
            }
            if (string.IsNullOrWhiteSpace(txt_Name.Text.Trim()))
            {
                MessageBox.Show("You must Enter Category Name.", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Name.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCategoryCode.Text.Trim()))
            {
                MessageBox.Show("Category Code Cannot be Empty.", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategoryCode.Focus();
                return false;
            }
            else return true;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            ToPerform = "Insert";
            FormStatus(false, true);
            txtreadonly(false);
            txt_Name.Focus();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            ToPerform = "Update";
            FormStatus(false, true);
            txtreadonly(true);
            txt_Name.Focus();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            ToPerform = "Delete";
            FormStatus(false, true);
            txtreadonly(true);
            txt_Name.Focus();
        }

        private void globalTab_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar is (char)Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            btn_Search.Enabled = false;
            if (ToPerform == "Update") txtreadonly(false);
            else if (ToPerform == "Delete")
            {
                FormStatus(false, false);
                txt_Name.Enabled = Btn_Ok.Enabled = true;
                Btn_Ok.Focus();
            }
            if (ToPerform == "Insert") return;
            var popup = new frm_PopUpSearch(TypeID, UserTable, DbName, "GetCategory", 0, string.Empty, 0);
            if (frm_PopUpSearch.dt.Rows.Count > 0)
            {
                popup.ShowDialog();
                if (popup.SelectedRow.Count > 0)
                {
                    TypeID = (int)popup.SelectedRow[0]["CatID"];
                    txt_Name.Text = popup.SelectedRow[0]["Category"].ToString();
                    txtCategoryCode.Text = CategoryCode = popup.SelectedRow[0]["CategoryID"].ToString();
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

        public int ProductSetup()
        {
            mainMaster.TypeMaster.ToPerform = ToPerform;
            mainMaster.TypeMaster.CatID = TypeID = ToPerform is "Insert" ? ClsMainMaster.getInt("MSM.ProductCategory", "CatID") : TypeID;
            mainMaster.TypeMaster.Category = txt_Name.Text.Trim().Replace("'", "''");
            mainMaster.TypeMaster.CategoryID = txtCategoryCode.Text.Trim().Replace("'", "''");
            mainMaster.TypeMaster.ActiveStatus = chk_Status.Checked;
            mainMaster.TypeMaster.UserID = Global.LoginID;
            return mainMaster.GetProcuctTypeSetup();
        }

        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            if (FormIsOK())
            {
                //progress bar implememtation starts
                
                
                if (ProductSetup() != 0)
                {
                    if (_NewEntry) // function to access data from another form
                    {
                        CategoryID = TypeID;
                        ProdType = txt_Name.Text;
                        
                        Close();
                        return;
                    }
                    
                    MessageBox.Show($@"{ToPerform.ToUpper()} Done...!!!", "Done", MessageBoxButtons.OK, MessageBoxIcon.None);
                    clear();
                    FormStatus(true, false);
                }
                else
                {
                    MessageBox.Show($@"{ToPerform.ToUpper()} Error...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.None);
                    txt_Name.Focus();
                }
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

        private void frm_ProductTypes_Load(object sender, EventArgs e)
        {
            clear();
            ToPerform = string.Empty;
            FormStatus(true, false);
            btn_Save.Focus();
        }

        private void txt_Name_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_Name.Text.Trim()) && ToPerform is "Insert")
                txtCategoryCode.Text = string.IsNullOrEmpty(txtCategoryCode.Text.Trim().Replace("'", "''")) ?
                    ClsIncrement.AutoIncrement("CategoryID", txt_Name.Text.Trim().Replace("'", "''"))
                    : txtCategoryCode.Text.Trim();
        }

        private void txtCategoryCode_Validating(object sender, CancelEventArgs e)
        {
            if (CategoryCode != txtCategoryCode.Text.ToString())
            {
                var dt = mainMaster.CheckAvailability("MSM.ProductCategory", "CategoryID", txtCategoryCode.Text.Trim());
                if (dt == null || dt.Rows.Count <= 0) return;
                MessageBox.Show(@"Code Is Taken..!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategoryCode.Focus();
            }
        }

        private void txt_Name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.F1 && ToPerform is "Update" || ToPerform is "Delete" && txt_Name.ReadOnly is true)
            {
                btn_Search.PerformClick();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            ToPerform = "Update";
            var popup = new frm_PopUpSearch(TypeID, UserTable, DbName, "GetCategory", 0, string.Empty, 0);
            if (frm_PopUpSearch.dt.Rows.Count > 0) popup.ShowDialog();
            else MessageBox.Show("No Data..!!", "Stop..!!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }
}
