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
    public partial class frm_ProductEntry : Form
    {
        #region Global
        private readonly IMainMaster mainMaster = new ClsMainMaster();
        public string ToPerform = string.Empty;
        public int ProdID, InventID;
        public string TableName = "[MSM].[ProductMaster]";
        public string DbName = Global.InitialCatalogMain;
        public int unitID;
        public int altUnitID;
        public string ProdCode = string.Empty;
        public string TestCode = string.Empty;
        private readonly bool _NewEntry;
        public string Prod_Name,Prod_Code,Prod_BCode,Qnty,AltQnty,Pprice,PMrp,PDisc,PNote,Pcategory = string.Empty;
        public string Unit, AltUnit = string.Empty;
        public int MouseBtn = 0;
        public frm_ProductEntry(bool NewEntry)
        {
            InitializeComponent();
            _NewEntry = NewEntry;
        }

        private void frm_ProductEntry_Load(object sender, EventArgs e)
        {
            clear();            
            ToPerform = string.Empty;
            FormStatus(true, false);
            btn_Save.Focus();
            lbl_TagStatus.Text = $"Copyright@ MSM_{DateTime.Today.ToString().Substring(5, 4)}";
        }
        #endregion

        #region Function

        public void ListviewLoad()
        {
            if (listView.Columns.Count == 0)
            {
                listView.Columns.Add("PRODUCT NAME", 170, HorizontalAlignment.Center);
                listView.Columns.Add("CODE", 80, HorizontalAlignment.Center);
                listView.Columns.Add("BARCODE", 180, HorizontalAlignment.Center);
                listView.Columns.Add("STATUS", 80, HorizontalAlignment.Center);
                listView.View = View.Details;
            }
            var dt = ClsMainMaster.GetProduct();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(dt.Rows[i]["PName"].ToString());
                item.SubItems.Add(dt.Rows[i]["PCode"].ToString());
                item.SubItems.Add(dt.Rows[i]["PBarcode"].ToString());
                item.SubItems.Add(dt.Rows[i]["ActiveStatus"].ToString());
                listView.Items.Add(item);
            }
        }
        public void clear()
        {
            ToPerform = string.Empty;
            ProdID = 0;
            InventID = 0;
            TableName = "[MSM].[ProductMaster]";
            DbName = Global.InitialCatalogMain;
            unitID=0;
            altUnitID=0;
            MouseBtn = 0;
            ProdCode = string.Empty;
            TestCode = string.Empty;
            //Unit_Load();
            txt_Name.Clear();
            //txt_Name.ReadOnly = false;
            txt_Code.Clear();
            txt_Unit.Clear();
            txt_AltUnit.Clear();
            txt_BCode.Clear();
            txt_Quantity.Clear();
            txt_AltQuantity.Clear();
            txt_PurchasePrice.Clear();
            txt_MRP.Clear();
            txt_OfferDiscount.Clear();
            txt_Note.Clear();
            listView.Items.Clear();
            txt_ProductType.Clear();
            ListviewLoad();
            txtreadonly(true);
        }

        private void txtreadonly(bool ReadOnly)
        {
            txt_Name.ReadOnly = txt_Code.ReadOnly = txt_BCode.ReadOnly = txt_Quantity.ReadOnly = txt_AltQuantity.ReadOnly = txt_Unit.ReadOnly = txt_AltUnit.ReadOnly = txt_PurchasePrice.ReadOnly = txt_Note.ReadOnly = txt_MRP.ReadOnly = txt_OfferDiscount.ReadOnly  = ReadOnly;
            //if (ToPerform != "Update") = ReadOnly;
            //else txt_Quantity.ReadOnly = txt_AltQuantity.ReadOnly = txt_Unit.ReadOnly = txt_AltUnit.ReadOnly = false;
        }

        public void FormStatus(bool btn, bool txt)
        {
            btn_Delete.Enabled = btn_Edit.Enabled = btn_Save.Enabled = btn;
            txt_Name.Enabled = txt_Code.Enabled = txt_BCode.Enabled = txt_Quantity.Enabled = txt_AltQuantity.Enabled = txt_PurchasePrice.Enabled = txt_Note.Enabled= txt_MRP.Enabled= txt_OfferDiscount.Enabled = txt_Unit.Enabled = txt_AltUnit.Enabled=txt_ProductType.Enabled = btn_Search.Enabled = Btn_Ok.Enabled = txt;
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            panel.BackColor = ColorTranslator.FromHtml(Global.BackgroundColor);
            //Graphics VerticalLine = panel.CreateGraphics();
            //Graphics HorizontalLine = panel.CreateGraphics();
            //Brush White = new SolidBrush(Color.White);
            //Pen Whitepen = new Pen(White, 1);
            ////length,angle,pointPlace,line Depth
            //VerticalLine.DrawLine(Whitepen, 380, 00, 380, 1050);
            //HorizontalLine.DrawLine(Whitepen, 1100, 90, 380, 90);
            //HorizontalLine.DrawLine(Whitepen, 1100, 160, 380, 160);
            //HorizontalLine.DrawLine(Whitepen, 1100, 490, 380, 490);
        }

        public bool FormIsOK()
        {
            if (ToPerform != null)
            {
                if (MessageBox.Show($@"Are you sure to {ToPerform}...!!", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return false;
            }
            if (string.IsNullOrWhiteSpace(txt_Name.Text.Trim()))
            {
                MessageBox.Show("You must Enter Product Name", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Name.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_Code.Text.Trim()))
            {
                MessageBox.Show("You must Enter Product Code", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Code.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_Unit.Text.Trim()))
            {
                MessageBox.Show("You must Enter Unit", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Unit.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_Quantity.Text.Trim()))
            {
                MessageBox.Show("You must Enter Quantity", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Quantity.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_PurchasePrice.Text.Trim()))
            {
                MessageBox.Show("You must Enter Purchase Price", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_PurchasePrice.Focus();
                return false;
            }
            if(ToPerform == "Update" && chkInventoryIncrement())
            {
                MessageBox.Show("Your selected product is in use..!!\nCannot edit.", "Edit not allowed.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //txt_PurchasePrice.Focus();
                return false;
            }


            else return true;
        }

        //public void Unit_Load()
        //{
        //    cmb_Unit.DataSource = mainMaster.Get_Unit();
        //    cmb_Unit.ValueMember = "UnitCode";
        //    if (cmb_Unit.Items.Count > 0) cmb_Unit.SelectedIndex = 0;

        //    cmb_AltUnit.DataSource = mainMaster.Get_Unit();
        //    cmb_AltUnit.ValueMember = "UnitCode";
        //    if (cmb_AltUnit.Items.Count > 0) cmb_AltUnit.SelectedIndex = 0;

        //    cmb_Type.DataSource = mainMaster.Get_ProductType();
        //    cmb_Type.ValueMember = "Category";
        //    if (cmb_Type.Items.Count > 0) cmb_Type.SelectedIndex = 0;
        //}

        public int ProductSetup()
        {
            mainMaster.ProdMaster.ToPerform = ToPerform;
            mainMaster.ProdMaster.PID = ProdID = ToPerform is "Insert" ? ClsMainMaster.getInt("MSM.ProductMaster", "PID") : ProdID;
            mainMaster.ProdMaster.InventID = ToPerform is "Insert" ? ClsMainMaster.getInt("MSM.ProductInventory", "InventID") : InventID;
            mainMaster.ProdMaster.PName = txt_Name.Text.Trim().Replace("'","''");
            mainMaster.ProdMaster.PCode = txt_Code.Text.Trim().Replace("'","''");
            mainMaster.ProdMaster.PBarcode = txt_BCode.Text.Trim().Replace("'","''");
            //var unitID = mainMaster.GetKeyID("UnitID", "UnitMaster", "UnitCode", txt_Unit.Text.Trim().Replace("'", "''"));
            //var AltUnitID = mainMaster.GetKeyID("UnitID", "UnitMaster", "UnitCode", txt_AltUnit.Text.Trim().Replace("'", "''"));
            //unitID = cmb_Unit.SelectedIndex;
            mainMaster.ProdMaster.UnitID = unitID;
            mainMaster.ProdMaster.UnitQnty = Decimal.Parse(txt_Quantity.Text.Trim().Replace("'", "''").ToString());
            if (string.IsNullOrEmpty(txt_AltQuantity.Text) || txt_AltQuantity.Text == "0.00")
            {
                txt_AltUnit.Text = null; txt_AltQuantity.Text = null;
            }
            else
            {
                mainMaster.ProdMaster.AltUnitId = altUnitID;
                mainMaster.ProdMaster.AltUnitQnty = Decimal.Parse(txt_AltQuantity.Text.Trim().Replace("'", "''").ToString());
            }
            if (txt_PurchasePrice.Text == "0" || txt_PurchasePrice.Text == "0.00") mainMaster.ProdMaster.PurchasePrice = null; else mainMaster.ProdMaster.PurchasePrice = Decimal.Parse(txt_PurchasePrice.Text.Trim().Replace("'", "''").ToString());
            if (txt_MRP.Text == "0" || txt_MRP.Text == "0.00") mainMaster.ProdMaster.MRP = null; else mainMaster.ProdMaster.MRP = Decimal.Parse(txt_MRP.Text.Trim().Replace("'", "''").ToString());
            mainMaster.ProdMaster.PurchasePrice = Decimal.Parse(txt_PurchasePrice.Text.Trim().Replace("'", "''").ToString());
            mainMaster.ProdMaster.MRP = Decimal.Parse(txt_MRP.Text.Trim().Replace("'", "''").ToString());
            mainMaster.ProdMaster.Offer = txt_OfferDiscount.Text.Trim().Replace("'", "''").ToString();
            mainMaster.ProdMaster.PNote = txt_Note.Text.Trim().Replace("'", "''").ToString();
            mainMaster.ProdMaster.ProductCategory = txt_ProductType.Text;
            mainMaster.ProdMaster.ActiveStatus = chk_Status.Checked;
            mainMaster.ProdMaster.UserID = Global.LoginID;
            return mainMaster.GetProductSetup();
        }

        #endregion


        private void lbl_AddUnit_Click(object sender, EventArgs e)
        {
            var IsPassed = Global.IsAdmin;
            var Session = Global.CurrentSession;
            if (IsPassed is 1 || Session is 1)
            {
                var form = new frm_Unit(false);
                form.ShowDialog();
            }
            else
            {
                if (MessageBox.Show("You Dont have Admin Permission. Click yes to Admin login!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                MDI_UserPanel.sessionPermission_Click(sender, e);
            }
        }

        private bool chkInventoryIncrement()
        {
            var dt = mainMaster.GetInventoryData(ProdID);

            if (dt.Rows.Count>0)
            {
                var quantity = (decimal)dt.Rows[0]["Quantity"];
                var altQuantity = (decimal)dt.Rows[0]["AlternateQuantity"];
                if (quantity > 0 || altQuantity > 0) return true;
                else return false;
            }
            else return false;
        }

        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            if(FormIsOK())
            {
                //progress bar implememtation starts
                
                
                if (ProductSetup() != 0)
                {
                    if(_NewEntry) // function to access data from another form
                    {
                        Prod_Name = txt_Name.Text;
                        Prod_Code = txt_Code.Text;
                        Prod_BCode = txt_BCode.Text;
                        Unit = txt_Unit.Text;
                        Qnty = txt_Quantity.Text;
                        AltUnit = txt_AltUnit.Text;
                        AltQnty = txt_AltQuantity.Text;
                        Pprice = txt_PurchasePrice.Text;
                        PMrp = txt_MRP.Text;
                        PDisc = txt_OfferDiscount.Text; ;
                        PNote = txt_Note.Text;
                        Pcategory = txt_ProductType.Text;
                        
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

        private void globalTab_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar is (char)Keys.Enter) SendKeys.Send("{TAB}");  
        }
        private void txt_PurchasePrice_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txt_PurchasePrice.Text)) txt_PurchasePrice.Text = "0.00";
        }

        private void txt_MRP_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_MRP.Text)) txt_MRP.Text = "0.00";
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            ToPerform = "Insert";
            FormStatus(false, true);
            txtreadonly(false);
            txt_Name.Focus();
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frm_ProductEntry_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar is (char)Keys.Escape)
            {
                MouseBtn = 1;
                btn_Refresh_Click(sender, e);
            }
        }

        private void txt_Name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.F1 && ToPerform is "Update" || ToPerform is "Delete"  && txt_Name.ReadOnly is true) btn_Search.PerformClick();
        }

        private void lbl_AddType_Click(object sender, EventArgs e)
        {
            var form = new frm_ProductTypes(false);
            form.ShowDialog();
        }

        private void txt_Unit_KeyDown(object sender, KeyEventArgs e)
        {
            if (ToPerform != "Delete" && e.KeyCode is Keys.F1)
            {
                var popup = new frm_PopUpSearch(0, "MSM.UnitMaster", DbName, "GetUnit", 1, string.Empty, 0);
                {
                    popup.ShowDialog();
                    if (popup.SelectedRow.Count > 0)
                    {
                        unitID = Int32.Parse(popup.SelectedRow[0]["UnitID"].ToString());
                        txt_Unit.Text = popup.SelectedRow[0]["UnitCode"].ToString();
                    }
                }
            }

            if (e.Control is true && e.KeyCode is Keys.N)
            {
                var frm = new frm_Unit(true);
                frm.ShowDialog();
                unitID = frm.Unitid;
                txt_Unit.Text = frm.UnitCode;
                return;
            }
        }

        private void txt_AltUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (ToPerform != "Delete" && e.KeyCode is Keys.F1)
            {
                var popup = new frm_PopUpSearch(0, "MSM.UnitMaster", DbName, "GetUnit", 1, string.Empty, 0);
                {
                    popup.ShowDialog();
                    if (popup.SelectedRow.Count > 0)
                    {
                        altUnitID = Int32.Parse(popup.SelectedRow[0]["UnitID"].ToString());
                        txt_AltUnit.Text = popup.SelectedRow[0]["UnitCode"].ToString();
                    }
                }
            }

            if (e.Control is true && e.KeyCode is Keys.N)
            {
                var frm = new frm_Unit(true);
                frm.ShowDialog();
                altUnitID = frm.Unitid;
                txt_AltUnit.Text = frm.UnitCode;
                return;
            }
        }

        private void txt_ProductType_KeyDown(object sender, KeyEventArgs e)
        {
            if (ToPerform != "Delete" && e.KeyCode is Keys.F1)
            {
                var popup = new frm_PopUpSearch(0, "MSM.ProductCategory", DbName, "GetCategory", 1, string.Empty, 0);
                {
                    popup.ShowDialog();
                    if (popup.SelectedRow.Count > 0)
                    {
                        //altUnitID = Int32.Parse(popup.SelectedRow[0]["UnitID"].ToString());
                        txt_ProductType.Text = popup.SelectedRow[0]["Category"].ToString();
                    }
                }
            }

            if (e.Control is true && e.KeyCode is Keys.N)
            {
                var frm = new frm_ProductTypes(true);
                frm.ShowDialog();
                //altUnitID = frm.Unitid;
                txt_ProductType.Text = frm.ProdType;
                return;
            }
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

        private void txt_Name_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_Name.Text.Trim()) && ToPerform is "Insert")
                txt_Code.Text = string.IsNullOrEmpty(txt_Code.Text.Trim().Replace("'", "''")) ?
                    ClsIncrement.AutoIncrement("ProductCode", txt_Name.Text.Trim().Replace("'", "''"))
                    : txt_Code.Text.Trim();
        }

        private void txt_Code_Validating(object sender, CancelEventArgs e)
        {
            if (ProdCode != txt_Code.Text.ToString())
            {
                var dt = mainMaster.CheckAvailability("MSM.ProductMaster", "PCode", txt_Code.Text.Trim().Replace("'", "''"));
                if (dt == null || dt.Rows.Count <= 0) return;
                MessageBox.Show(@"Code Is Taken..!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Code.Focus();
            }
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
            var popup = new frm_PopUpSearch(ProdID, TableName, DbName, "ProductSelect", 0, string.Empty, 0);
            if (frm_PopUpSearch.dt.Rows.Count > 0)
            {
                popup.ShowDialog();
                if (popup.SelectedRow.Count > 0)
                {
                    ProdID = Int32.Parse(popup.SelectedRow[0]["PID"].ToString());
                    InventID = Int32.Parse(popup.SelectedRow[0]["InventID"].ToString());
                    txt_Name.Text = popup.SelectedRow[0]["PName"].ToString();
                    txt_Code.Text = ProdCode = popup.SelectedRow[0]["PCode"].ToString();
                    txt_BCode.Text = popup.SelectedRow[0]["PBarcode"].ToString();

                    unitID = Int32.Parse(popup.SelectedRow[0]["UnitID"].ToString());
                    txt_Unit.Text = popup.SelectedRow[0]["MainUnitCode"].ToString();
                    //if (unitID == 0) cmb_Unit.SelectedIndex = 0; else cmb_Unit.SelectedIndex = unitID - 1;

                    var Quantity = Decimal.Parse(popup.SelectedRow[0]["UnitQnty"].ToString());
                    txt_Quantity.Text = Quantity == 0 ? "0" : Quantity.ToString("##.##########");

                    TestCode = popup.SelectedRow[0]["AltUnitId"].ToString();
                    if (TestCode != "")
                    {
                        altUnitID = Int32.Parse(popup.SelectedRow[0]["AltUnitId"].ToString());
                        txt_AltUnit.Text = popup.SelectedRow[0]["AltUnitCode"].ToString();
                        //if (altUnitID == 0) cmb_AltUnit.SelectedIndex = 0; else cmb_AltUnit.SelectedIndex = altUnitID - 1;
                        var AltQuantity = Decimal.Parse(popup.SelectedRow[0]["AltUnitQnty"].ToString());
                        txt_AltQuantity.Text = AltQuantity == 0 ? "0" : AltQuantity.ToString("##.##########");
                    }
                    else
                    {
                        altUnitID = 0; 
                        txt_AltUnit.Text=""; 
                        //txt_AltQuantity.Text = popup.SelectedRow[0]["AltUnitQnty"].ToString();
                        txt_AltQuantity.Text = "0";
                    }

                    var PurchasePrice = Decimal.Parse(popup.SelectedRow[0]["PurchasePrice"].ToString());
                    txt_PurchasePrice.Text = PurchasePrice == 0 ? "0" : PurchasePrice.ToString("##.##########");
                    var MRP = Decimal.Parse(popup.SelectedRow[0]["MRP"].ToString());
                    txt_MRP.Text = MRP == 0 ? "0" : MRP.ToString("##.##########");
                    txt_OfferDiscount.Text = popup.SelectedRow[0]["Offer"].ToString();
                    txt_Note.Text = popup.SelectedRow[0]["PNote"].ToString();
                    TestCode = popup.SelectedRow[0]["ProductCategory"].ToString();
                    if (TestCode != "") txt_ProductType.Text = TestCode; else txt_ProductType.Text = "";
                    var status = popup.SelectedRow[0]["ActiveStatus"].ToString();
                    if (status == "True") chk_Status.Checked = true;
                    else chk_Status.Checked = false;
                }
            }
            else
            {
                MessageBox.Show("No Data..!!", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void txt_Global_Numeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                //return;
            }

            // checks to make sure only 1 decimal is allowed
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
            if (e.KeyChar is (char)Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txt_AltQuantity_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_AltQuantity.Text)) txt_AltQuantity.Text = "0.00";
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MouseBtn = 1;
            btn_Refresh_Click(sender, e);
        }

        private void txt_Quantity_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Quantity.Text)) txt_Quantity.Text = "0.00";
        }
    }
}
