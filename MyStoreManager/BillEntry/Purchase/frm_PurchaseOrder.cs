using DotVVM.Framework.Compilation.ControlTree;
using MSMControl.Class;
using MSMControl.ClassMiti;
using MSMControl.Connection;
using MSMControl.Interface;
using MyStoreManager.PleaseWaitControl;
using MyStoreManager.PreEntry;
using MyStoreManager.Print.PrintForm;
using MyStoreManager.Setup;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace MyStoreManager.BillEntry.Purchase
{
    public partial class frm_PurchaseOrder : Form
    {
        #region Global
        private readonly IMainMaster mainMaster = new ClsMainMaster();
        private readonly INumbetToWords Towords = new ClsNumberToWord();
        public int VoucherNum;
        private int ProdID;
        private int loginID, count;
        private int clickCount;
        private int OldloginID;
        private int OldCreatorUserID;
        private DateTime OldCreatedDate;
        private int CustoID = 0;
        private int POID = 0;
        private int rowIndex;
        private int currentColumn;
        private string POVNUM = string.Empty;
        private string ToPerform, msg = string.Empty;
        private string isDeleted = string.Empty; //by default it is false
        private string Search = string.Empty;
        private string DbName = Global.InitialCatalogMain;
        private int unitID;
        private string ProdCode = string.Empty;
        private string TestCode = string.Empty;
        private string Prod_Name = string.Empty;
        protected int PO_Master_ID;
        protected int PO_Details_ID;
        private int MouseBtn = 0;
        private int DuplicateValue = 0;
        private bool fromPrint = false;
        private decimal quantity;
        private readonly DataTable dtPO_Details = new DataTable("PurchaseOrderDetails");
        clsPleaseWaitForm PleaseWait = new clsPleaseWaitForm(); 

        public frm_PurchaseOrder()
        {
            InitializeComponent();
            DataGridColumns();
        }
        #endregion

        #region Functions
        public void FormStatus(bool btn, bool txt)
        {
            btn_Delete.Enabled = btn_Edit.Enabled = btn_Save.Enabled = btn;
            ProddataGridView.Enabled = Btn_CustoSearch.Enabled = TxtPname.Enabled = txtCname.Enabled = txtPaddress.Enabled = txtPContactnum.Enabled = cmbTransection.Enabled = txtVAT.Enabled = txtDiscount.Enabled = txt_Name.Enabled = txt_Quantity.Enabled = txt_PurchasePrice.Enabled = txt_Note.Enabled = txtUnit.Enabled = btn_Product_Search.Enabled = Btn_Ok.Enabled = btn_ProductClear.Enabled = Btn_Insert.Enabled = chk_BillStatus.Enabled = txtDateTime.Enabled = txt;
        }
        private void txtreadonly(bool ReadOnly)
        {
            txtPaddress.ReadOnly = txtVAT.ReadOnly = txtDiscount.ReadOnly = txtCname.ReadOnly = txtPaddress.ReadOnly = txtPContactnum.ReadOnly = txt_Quantity.ReadOnly = txt_PurchasePrice.ReadOnly = txt_Note.ReadOnly = ProddataGridView.ReadOnly = ReadOnly;
        }
        private void txtCustomerReadonly(bool customerReadOnly)
        {
            TxtPname.ReadOnly = txtCname.ReadOnly = txtPaddress.ReadOnly = txtPContactnum.ReadOnly = customerReadOnly;
        }
        public void ConfigInitials()
        {
            var Configdt = mainMaster.checkConfig();
            var VAT = decimal.Parse(Configdt.Rows[0]["VAT"].ToString());
            txtVAT.Text = VAT == 0 ? "0.00" : VAT.ToString("##.##########");
            var Discount = decimal.Parse(Configdt.Rows[0]["Discount"].ToString());
            txtDiscount.Text = Discount == 0 ? "0.00" : Discount.ToString("##.##########");
        }
        private void frm_PurchaseOrder_Load(object sender, EventArgs e)
        {
            clear();
            ToPerform = string.Empty;
            txtCustomerReadonly(false);
            FormStatus(true, false);
            btn_Save.Focus();
        }
        protected void VoucherNumber()
        {
            VoucherNum = ClsMainMaster.getInt("MSM.PurchaseOrderMaster", "POID");
            //txtVoucherNum.Text = "PO-"+$"{Global.Year}" +"-"+"00"+VoucherNum;
            if (VoucherNum.ToString().Length == 1) txtVoucherNum.Text = "PO-" + $"{Global.Year}" + "-" + "00" + VoucherNum;
            else if (VoucherNum.ToString().Length == 2) txtVoucherNum.Text = "PO-" + $"{Global.Year}" + "-" + "0" + VoucherNum;
            else txtVoucherNum.Text = "PO-" + $"{Global.Year}" + "-" + VoucherNum;
        }
        private void clear()
        {
            POID = 0;
            VoucherNum = 0;
            ToPerform = msg = string.Empty;
            txt_Name.ReadOnly = true;
            isDeleted = string.Empty;
            CustoID = 0;
            quantity = 0;
            fromPrint = false;
            //TableName = "[MSM].[ProductMaster]";
            DbName = Global.InitialCatalogMain;
            unitID = 0;
            MouseBtn = 0;
            ProdCode = string.Empty;
            TestCode = string.Empty;
            txtVoucherNum.Clear();
            txtDateTime.ResetText();
            TxtPname.Clear();
            txtCname.Clear();
            txtPaddress.Clear();
            txtPContactnum.Clear();
            cmbTransection.Text = "CASH";
            ProductEntryClear();
            //txtDateTime.Text = txtDateTime.Value.ToShortDateString(); //txtDate.Text = txtDateTime.Now.ToShortDateString();
            txtMiti.Clear();
            Btn_CustoSearch.Enabled = true;
            loginID = Global.LoginID;
            lbl_Person.Text = Global.UserName;
            lbl_RoleName.Text = $@"({Global.LoginUser})";
            lbl_CompanyName.Text = Global.CompanyName;
            lbl_Address.Text = $@"{Global.Address},{Global.City},{Global.State},{Global.Country}";
            lbl_Phone.Text = Global.Contact;
            lbl_TagStatus.Text = Global.copyrightYear;
            lbl_CompanyName.TextAlign = ContentAlignment.MiddleCenter;
            lbl_Address.TextAlign = ContentAlignment.MiddleCenter;
            lbl_Phone.TextAlign = ContentAlignment.MiddleCenter;
            GetMiti();
            ConfigInitials();
            ProddataGridView.Rows.Clear();
            Btn_Ok.Text = "&Save";
            btn_Save.Focus();
        }
        private void GetMiti()
        {
            txtMiti.Text = mainMaster.GetMiti(txtDateTime.Text);
        }
        public void ProductEntryClear()
        {
            ProdID = 0;
            btn_Product_Search.Enabled = true;
            txt_Name.Clear();
            lbl_ProductID.Text = "";
            lbl_Barcode.Text = "";
            lblPShortname.Text = "";
            txt_Quantity.Clear();
            txt_PurchasePrice.Clear();
            txt_Note.Clear();
            txtUnit.Clear();
            lblToWords.Text = string.Empty;
            DuplicateValue = 0;
            lblTotal.Text = lbldiscamt.Text = lblVatamt.Text = lblBillBDiscount.Text = lblTotalBill.Text = lblTotalAmount.Text = "0.00";
        }
        private void escFunction(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar is (char)Keys.Escape)
            {
                if (string.IsNullOrEmpty(TxtPname.Text.Trim()) && CustoID == 0)
                {
                    if (MessageBox.Show("Are you sure to Close...!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                    this.Close();
                }
                else
                {
                    if (MessageBox.Show("Are you sure to Clear...!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                    clear();
                    frm_PurchaseOrder_Load(sender, e);
                    //btn_sendtoGrid.Enabled = false;
                }
            }
        }
        private void panel_Paint(object sender, PaintEventArgs e)
        {
            panel.BackColor = ColorTranslator.FromHtml(Global.BackgroundColor);
            //Graphics VerticalLine = panel.CreateGraphics();
            //Graphics HorizontalLine = panel.CreateGraphics();
            //Brush White = new SolidBrush(Color.White);
            //Pen Whitepen = new Pen(White, 1);
            //length,angle,pointPlace,line Depth
            //VerticalLine.DrawLine(Whitepen, 588, 100, 588, 1050);
            //HorizontalLine.DrawLine(Whitepen, 00, 100, 1100, 100);
            //HorizontalLine.DrawLine(Whitepen, 00, 100, 1100, 100);
            //HorizontalLine.DrawLine(Whitepen, 00, 260, 588, 260);
            //HorizontalLine.DrawLine(Whitepen, 588, 500, 1100, 500);
        }
        private void txt_Name_KeyDown(object sender, KeyEventArgs e)
        {
            //if (ProddataGridView.Rows.Count > 0 && string.IsNullOrEmpty(txt_Name.Text) && e.KeyCode is Keys.Enter) Btn_Ok.Focus();

            if (e.Control is true && e.KeyCode is Keys.N)
            {
                var frm = new frm_ProductEntry(true);
                frm.ShowDialog();
                txt_Name.Text = frm.Prod_Name;
                ProdID = frm.ProdID;
                lbl_ProductID.Text = frm.ProdID.ToString();
                lblPShortname.Text = frm.Prod_Code;
                lbl_Barcode.Text = frm.Prod_BCode;
                txt_Quantity.Text = frm.Qnty;
                txtUnit.Text = frm.Unit;
                //txtAltUnit.Text = frm.AltUnit;
                //txtProductType.Text = frm.Pcategory;
                txt_PurchasePrice.Text = frm.Pprice;
                //txt_MRP.Text = frm.PMrp;
                //txt_OfferDiscount.Text = frm.PDisc;
                txt_Note.Text = frm.PNote;

            }
            if (e.KeyCode is Keys.F1 && txt_Name.ReadOnly is true) btn_Product_Search.PerformClick();
        }
        private void txt_Name_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Name.Text) && ProddataGridView.Rows.Count < 1) btn_Product_Search.PerformClick();
        }
        private void txtDateTime_Leave(object sender, EventArgs e)
        {
            Miti npDate = ConvertToMiti.GetMiti(DateTime.Parse(txtDateTime.Text));
            txtMiti.Text = npDate.npDate.ToString();
        }
        public void Btn_CustoSearch_Click(object sender, EventArgs e)
        {
            //Btn_CustoSearch.Enabled = false;
            if (ToPerform == "Insert")
            {
                var popup = new frm_PopUpSearch(0, string.Empty, DbName, "CustomerSelect", 1, string.Empty, 0);
                if (frm_PopUpSearch.dt.Rows.Count > 0)
                {
                    popup.ShowDialog();
                    if (popup.SelectedRow.Count > 0)
                    {
                        CustoID = Int32.Parse(popup.SelectedRow[0]["CID"].ToString());
                        TxtPname.Text = popup.SelectedRow[0]["PartyName"].ToString();
                        txtCname.Text = popup.SelectedRow[0]["PartyCompany"].ToString();
                        txtPaddress.Text = popup.SelectedRow[0]["PartyAddress"].ToString();
                        txtPContactnum.Text = popup.SelectedRow[0]["PartyContact"].ToString();
                        //txt_Note.Text = popup.SelectedRow[0]["PartyNote"].ToString();
                        var status = popup.SelectedRow[0]["ActiveStatus"].ToString();
                        txtCustomerReadonly(true);
                    }
                }
                else
                {
                    MessageBox.Show("No Data..!!", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                TxtPname.Focus();
            }
            else if (ToPerform == "Update" || ToPerform == "Delete")
            {
                var popup = new frm_PopUpSearch(0, string.Empty, Global.InitialCatalogMain, "PurchaseOrder", 0, string.Empty, 0);
                if (frm_PopUpSearch.dt.Rows.Count > 0)
                {
                    popup.ShowDialog();
                    if (popup.SelectedRow.Count > 0)
                    {
                        POID = Int32.Parse(popup.SelectedRow[0]["POID"].ToString());
                        txtVoucherNum.Text = POVNUM = popup.SelectedRow[0]["POVNUM"].ToString();
                        txtDateTime.Value = DateTime.Parse(popup.SelectedRow[0]["Order_Date"].ToString());
                        txtMiti.Text = popup.SelectedRow[0]["Order_Miti"].ToString();
                        OldloginID = Int32.Parse(popup.SelectedRow[0]["ReceiverID"].ToString());
                        lbl_Person.Text = popup.SelectedRow[0]["usrname"].ToString();
                        lbl_CompanyName.Text = popup.SelectedRow[0]["Dup_cname"].ToString();
                        lbl_Address.Text = popup.SelectedRow[0]["Dup_address"].ToString();
                        lbl_Phone.Text = popup.SelectedRow[0]["Dup_contact"].ToString();
                        CustoID = Int32.Parse(popup.SelectedRow[0]["SenderID"].ToString());
                        TxtPname.Text = popup.SelectedRow[0]["PartyName"].ToString();
                        txtCname.Text = popup.SelectedRow[0]["PartyCompany"].ToString();
                        txtPaddress.Text = popup.SelectedRow[0]["PartyAddress"].ToString();
                        txtPContactnum.Text = popup.SelectedRow[0]["PartyContact"].ToString();
                        cmbTransection.Text = popup.SelectedRow[0]["TransectionOn"].ToString();
                        var Vat = Decimal.Parse(popup.SelectedRow[0]["Vat"].ToString());
                        txtVAT.Text = Vat == 0 ? "0.00" : Vat.ToString("##.##########");
                        var Dis = Decimal.Parse(popup.SelectedRow[0]["Discount"].ToString());
                        txtDiscount.Text = Dis == 0 ? "0.00" : Dis.ToString("##.##########");
                        OldCreatorUserID = Int32.Parse(popup.SelectedRow[0]["UserID"].ToString());
                        isDeleted = popup.SelectedRow[0]["is_Deleted"].ToString();
                        OldCreatedDate = Convert.ToDateTime(popup.SelectedRow[0]["DateCreated"].ToString());
                        var status = popup.SelectedRow[0]["PO_Bill_Status"].ToString();
                        if (status == "PENDING") chk_BillStatus.Checked = false; else chk_BillStatus.Checked = true;
                        var ds = mainMaster.GetPurchaseOrderDetails(POVNUM);
                        if (ds.Tables.Count > 0)
                        {
                            ProddataGridView.Rows.Clear();
                            foreach (DataRow dgv in ds.Tables[0].Rows)
                            {
                                var rows = ProddataGridView.Rows.Count;
                                ProddataGridView.Rows.Add();
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["PID"].Value = dgv["PID"].ToString();
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Product"].Value = dgv["PName"].ToString();
                                var qnty = Decimal.Parse(dgv["Quantiy"].ToString());
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Quantity"].Value = qnty == 0 ? "0.00" : qnty.ToString("##.##########");
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Unit"].Value = dgv["UnitCode"].ToString();
                                var price = Decimal.Parse(dgv["PPrice"].ToString());
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["P. Price"].Value = price == 0 ? "0.00" : price.ToString("##.##########");
                                var total = Decimal.Parse(dgv["TotalPrice"].ToString());
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Total"].Value = total == 0 ? "0.00" : total.ToString("##.##########");
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["P.Note"].Value = dgv["PNote"].ToString();
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Short Name"].Value = dgv["PCode"].ToString();
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["BarCode"].Value = dgv["PBarcode"].ToString();
                                ProddataGridView.CurrentCell = ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells[currentColumn];
                            }
                            ProddataGridView.ClearSelection();
                            if (ToPerform == "Delete")
                            {
                                txtreadonly(true);
                                FormStatus(false, false);
                                Btn_Ok.Enabled = true;
                                Btn_Ok.Text = "Delete";
                                Btn_Ok.Focus();
                            }
                        }
                        if (fromPrint == true)
                        {
                            txtreadonly(true);
                            FormStatus(false, false);
                            Total_click(sender, e);
                            fromPrint = false;
                            btnPrint.PerformClick();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No Data..!!", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                // MessageBox.Show("Something Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void DGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
        }
        private void DGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            currentColumn = e.ColumnIndex;
        }
        private void btn_Product_Search_Click(object sender, EventArgs e)
        {
            //btn_Product_Search.Enabled = false;
            //if (ToPerform == "Update") txtreadonly(false);
            //else if (ToPerform == "Delete")
            //{
            //    FormStatus(false, false);
            //    txt_Name.Enabled = Btn_Ok.Enabled = true;
            //    Btn_Ok.Focus();
            //}
            var popup = new frm_PopUpSearch(0, string.Empty, Global.InitialCatalogMain, "ProductSelect", 1, string.Empty, 0);
            if (frm_PopUpSearch.dt.Rows.Count > 0)
            {
                popup.ShowDialog();
                if (popup.SelectedRow.Count > 0)
                {
                    ProdID = Int32.Parse(popup.SelectedRow[0]["PID"].ToString());
                    txt_Name.Text = popup.SelectedRow[0]["PName"].ToString();
                    lbl_ProductID.Text = ProdID.ToString();
                    lblPShortname.Text = ProdCode = popup.SelectedRow[0]["PCode"].ToString();
                    lbl_Barcode.Text = popup.SelectedRow[0]["PBarcode"].ToString();

                    var QntiString = popup.SelectedRow[0]["UnitQnty"].ToString();

                    var Quantity = QntiString == "" ? Decimal.Parse("0") : Decimal.Parse(QntiString);
                    txt_Quantity.Text = Quantity == 0 ? "0" : Quantity.ToString("##.##########");
                    unitID = Int32.Parse(popup.SelectedRow[0]["UnitID"].ToString());
                    txtUnit.Text = popup.SelectedRow[0]["MainUnitCode"].ToString();
                    //var AltQntiString = popup.SelectedRow[0]["AltUnitQnty"].ToString();
                    //var AltQuantity = AltQntiString == ""? Decimal.Parse("0") : Decimal.Parse(AltQntiString);
                    //txt_AltQuantity.Text = AltQuantity == 0 ? "0" : AltQuantity.ToString("##.##########");
                    //altUnitID = Int32.Parse(popup.SelectedRow[0]["AltUnitId"].ToString());
                    //txtAltUnit.Text = popup.SelectedRow[0]["AltUnitCode"].ToString();
                    var PurchasePrice = Decimal.Parse(popup.SelectedRow[0]["PurchasePrice"].ToString());
                    txt_PurchasePrice.Text = PurchasePrice == 0 ? "0" : PurchasePrice.ToString("##.##########");
                    var MRP = Decimal.Parse(popup.SelectedRow[0]["MRP"].ToString());
                    // txt_MRP.Text = MRP == 0 ? "0" : MRP.ToString("##.##########");
                    // txt_OfferDiscount.Text = popup.SelectedRow[0]["Offer"].ToString();
                    // txtProductType.Text = popup.SelectedRow[0]["ProductCategory"].ToString();
                    txt_Note.Text = popup.SelectedRow[0]["PNote"].ToString();

                }
                else btn_Product_Search.Enabled = true;
            }
            else
            {
                MessageBox.Show("No Data..!!", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            txt_Name.Focus();
        }
        public bool FormIsOK()
        {
            if (ToPerform != null)
            {
                if (MessageBox.Show($@"Are you sure to {msg}...!!", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return false;
            }
            if (string.IsNullOrWhiteSpace(txtMiti.Text.Trim()))
            {
                MessageBox.Show("Please select english date to set Miti", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //errorProvider.SetError(txtMiti, "Please enter Miti.");
                txtDateTime.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(TxtPname.Text.Trim())) //this is the company name/ party name
            {
                MessageBox.Show("You must Enter Supplier Name", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //errorProvider.SetError(TxtPname, "Please enter Supplier name");
                TxtPname.Focus();
                return false;
            }
            //if (string.IsNullOrWhiteSpace(txtCname.Text.Trim()))
            //{
            //    MessageBox.Show("You must Enter Supplier Company Name", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    //errorProvider.SetError(txtCname, "Please enter Company name.");
            //    txtCname.Focus();
            //    return false;
            //}
            if (string.IsNullOrWhiteSpace(txtPaddress.Text.Trim()))
            {
                MessageBox.Show("You must Enter Supplier Address", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //errorProvider.SetError(txtPaddress, "Please enter Address.");
                txtPaddress.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPContactnum.Text.Trim()))
            {
                MessageBox.Show("You must Enter Supplier Contact ", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //errorProvider.SetError(txtPContactnum, "Please enter Supplier Contact.");
                txtPContactnum.Focus();
                return false;
            }
            if (ProddataGridView.Rows.Count == 0)
            {
                MessageBox.Show("You have not made any selection", "Please Select Product", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Name.Focus();
                return false;
            }
            //if(ToPerform is "Delete" && chk_BillStatus.Checked is false)
            //{
            //    MessageBox.Show("The Bill you trying to delete is already Deleted.", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    //errorProvider.SetError(TxtPname, "Please enter Supplier name");
            //    TxtPname.Focus();
            //    return false;
            //}
            if (ToPerform is "Delete" && isDeleted == "Yes")
            {
                MessageBox.Show("This bill is already deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                TxtPname.Focus();
                clear();
                return false;
            }
            else return true;
        }
        public bool IsProductOk()
        {
            if (string.IsNullOrWhiteSpace(txt_Name.Text.Trim()))
            {
                MessageBox.Show("You must Enter Product Name", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //errorProvider.SetError(txt_Name, "Please enter Product name.");
                txt_Name.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_Quantity.Text.Trim()))
            {
                MessageBox.Show("You must Enter Product Quantity", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //errorProvider.SetError(txt_Quantity, "Please enter Quantity.");
                txt_Quantity.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_PurchasePrice.Text.Trim()))
            {
                MessageBox.Show("You must Enter Product Rate", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //errorProvider.SetError(txt_PurchasePrice, "Please enter Purchase Price.");
                txt_PurchasePrice.Focus();
                return false;
            }
            else return true;
        }
        private void AddRow(string Sno, string PID, string Pname, string quantity, string unit, string total, string PPrice, string Pnote, string SName, string Barcode)
        {
            string[] rows = { Sno, PID, Pname, quantity, unit, total, PPrice, Pnote, SName, Barcode };
            ProddataGridView.Rows.Add(rows);
        }
        public int PurchaseOrderSave()
        {
            mainMaster.PO_Master.ToPerform = ToPerform;
            mainMaster.PO_Master.POID = ToPerform is "Insert" ? ClsMainMaster.getInt("MSM.PurchaseOrderMaster", "POID") : POID;
            mainMaster.PO_Master.POVNUM = txtVoucherNum.Text.Trim().Replace("'", "''");
            mainMaster.PO_Master.Order_Date = txtDateTime.Value;
            mainMaster.PO_Master.Order_Miti = txtMiti.Text.Trim().Replace("'", "''");
            mainMaster.PO_Master.ReceiverID = (int)Global.CompanyID;
            mainMaster.PO_Master.SenderID = CustoID;
            mainMaster.PO_Master.TransectionOn = cmbTransection.Text;
            mainMaster.PO_Master.Total = decimal.Parse(lblTotalAmount.Text);
            mainMaster.PO_Master.Vat = decimal.Parse(txtVAT.Text.Trim().Replace("'", "''"));
            mainMaster.PO_Master.VatAmt = decimal.Parse(lblVatamt.Text);
            mainMaster.PO_Master.TotalAmount = decimal.Parse(lblBillBDiscount.Text);
            mainMaster.PO_Master.Discount = decimal.Parse(txtDiscount.Text.Trim().Replace("'", "''"));
            mainMaster.PO_Master.DiscAmount = decimal.Parse(lbldiscamt.Text);
            mainMaster.PO_Master.BillTotal = decimal.Parse(lblTotalBill.Text);
            mainMaster.PO_Master.InWords = lblToWords.Text;
            mainMaster.PO_Master.PO_Bill_Status = chk_BillStatus.Checked;
            mainMaster.PO_Master.UserID = Global.LoginID;
            mainMaster.PO_Master.goods_quantity = quantity;
            mainMaster.PO_Master.is_Deleted = false;
            mainMaster.PO_Details.ToPerform = mainMaster.PO_Master.ToPerform;
            mainMaster.PO_Details.POID = mainMaster.PO_Master.POID;
            mainMaster.PO_Details.POVNUM = mainMaster.PO_Master.POVNUM;
            //this update values are stored while updating and restoring the values in details table table after delete and re insert in case of update.
            if (ToPerform == "Update")
            {
                mainMaster.PO_Details.UserID = OldCreatorUserID;
                mainMaster.PO_Details.DateCreated = OldCreatedDate;
                mainMaster.PO_Details.MUserID = mainMaster.PO_Master.UserID;
            }
            else
            {
                mainMaster.PO_Details.UserID = mainMaster.PO_Master.UserID;
            }
            mainMaster.PO_Details.GetGridViewData = ProddataGridView;
            return mainMaster.GetPurchaseOrderSetup();
        }
        public void DataGridColumns()
        {
            ProddataGridView.ColumnCount = 10;
            ProddataGridView.Columns[0].Name = "SNO";
            ProddataGridView.Columns[1].Name = "PID";
            ProddataGridView.Columns[2].Name = "Product";
            ProddataGridView.Columns[3].Name = "Quantity";
            ProddataGridView.Columns[4].Name = "Unit";
            ProddataGridView.Columns[5].Name = "P. Price";
            ProddataGridView.Columns[6].Name = "Total";
            ProddataGridView.Columns[7].Name = "P.Note";
            ProddataGridView.Columns[8].Name = "Short Name";
            ProddataGridView.Columns[9].Name = "BarCode";
            //Autosize
            ProddataGridView.Columns[0].Width = 40;
            ProddataGridView.Columns[1].Width = 40;
            ProddataGridView.Columns[2].Width = 200;
            ProddataGridView.Columns[3].Width = 100;
            ProddataGridView.Columns[4].Width = 100;
            ProddataGridView.Columns[5].Width = 100;
            ProddataGridView.Columns[6].Width = 100;
            ProddataGridView.Columns[7].Width = 100;
            ProddataGridView.Columns[8].Width = 100;
            ProddataGridView.Columns[9].Width = 100;
        }
        #endregion

        #region Events
        private void btn_Save_Click(object sender, EventArgs e)
        {
            ToPerform = "Insert";
            if (ToPerform == "Insert") VoucherNumber(); // Just to be sure
            FormStatus(false, true);
            txtreadonly(false);
            txtDateTime.Focus();
        }
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            ToPerform = "Update";
            FormStatus(false, true);
            txtreadonly(false);
            txtVoucherNum.Focus();
            Btn_Ok.Text = "&Update";
        }
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            ToPerform = "Delete";
            FormStatus(false, false);
            //txtreadonly(true);
            TxtPname.Enabled = txtVoucherNum.Enabled = Btn_CustoSearch.Enabled = true;
            btn_Product_Search.Enabled = Btn_Ok.Enabled = true;
            Btn_Ok.Text = "&Delete";
        }
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
        private void BtnProgressBar_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Change the value of the ProgressBar  
            // BtnProgressBar.Value = e.ProgressPercentage;
            // Set the text.  
            this.Text = "Progress: " + e.ProgressPercentage.ToString() + "%";
        }
        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                if (ToPerform is null) return;
                msg = ToPerform == "Insert" ? "Save" : ToPerform;
                if (FormIsOK())
                {
                    Total_click(sender, e);
                    //progress bar implememtation starts
                    PleaseWait.Show();
                    if (PurchaseOrderSave() != 0)
                    {
                        PleaseWait.Close();
                        //Thread.Sleep(50);
                        MessageBox.Show($@"{msg}d Sucessfully...!!!", "Done", MessageBoxButtons.OK, MessageBoxIcon.None);
                        if (Global.printMessage is true) if (MessageBox.Show("Do you want to print this?", "Print Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) btnPrint.PerformClick();
                        if (Global.autoPrint is true) btnPrint.PerformClick();
                        frm_PurchaseOrder_Load(sender, e);
                        //FormStatus(true, false);
                    }
                    else
                    {
                        PleaseWait.Close();
                        MessageBox.Show($@"{msg} Error...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.None);
                        txt_Name.Focus();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.None);
                txt_Name.Focus();
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (txtVoucherNum.Text.Trim() == "")
            {
                ToPerform = "Update";
                fromPrint = true;
                Btn_CustoSearch_Click(sender, e);
            }
            //Print
            else if (ToPerform != "Delete" && !string.IsNullOrEmpty(txtVoucherNum.Text.Trim()))
            {
                printPreviewDialog.Document = printDocument;
                DialogResult result = printPreviewDialog.ShowDialog();
                if (result == DialogResult.OK) printDocument.Print();
            }
        }


        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            printDocument.DocumentName = $@"{txtVoucherNum.Text}";
            StringFormat center = new StringFormat();
            center.LineAlignment = StringAlignment.Center;
            center.Alignment = StringAlignment.Center;
            const int X = 50, Y = 100;
            e.Graphics.DrawString($@"{Global.CompanyName}", new Font("Arial", 11,FontStyle.Bold), Brushes.Black, new Point(425, 40),center);
            e.Graphics.DrawString($@"{Global.Address}, {Global.City}, {Global.State}, {Global.Country}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(425, 60), center);
            e.Graphics.DrawString($@"Comp. Reg:-{Global.Registration}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(425, 75), center);
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new PointF(00.0F, 90.0F), new PointF(850.0F, 90.0F)); //Ref line:- https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics.drawline?view=windowsdesktop-7.0
            e.Graphics.DrawString($@"PO-BILL-No.:- {txtVoucherNum.Text}", new Font("Arial", 8,FontStyle.Bold), Brushes.Black, new Point(X, Y + 10));
            e.Graphics.DrawString($@"Date:- {txtMiti.Text}  ({txtDateTime.Text})", new Font("Arial", 8,FontStyle.Bold), Brushes.Black, new Point(X + 450, Y + 10));
            e.Graphics.DrawString($@"Supplier Name:- {txtCname.Text}", new Font("Arial", 8,FontStyle.Bold), Brushes.Black, new Point(X, Y + 40));
            e.Graphics.DrawString($@"Address:- {txtPaddress.Text}", new Font("Arial", 8,FontStyle.Regular), Brushes.Black, new Point(X, Y + 60));
            e.Graphics.DrawString($@"Contact:- {txtPContactnum.Text}", new Font("Arial", 8,FontStyle.Regular), Brushes.Black, new Point(X, Y + 80));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new PointF(00.0F, 200.0F), new PointF(850.0F, 200.0F));           
            e.Graphics.DrawString($@"SNO.", new Font("Arial", 8,FontStyle.Bold), Brushes.Black, new Point(X, Y + 105));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new PointF(00.0F, 220.0F), new PointF(850.0F, 220.0F));
            e.Graphics.DrawString($@"Items", new Font("Arial", 8,FontStyle.Bold), Brushes.Black, new Point(X+50, Y + 105));
            e.Graphics.DrawString($@"Quantity", new Font("Arial", 8,FontStyle.Bold), Brushes.Black, new Point(X + 250, Y + 105));
            e.Graphics.DrawString($@"Price", new Font("Arial", 8,FontStyle.Bold), Brushes.Black, new Point(X + 350, Y + 105));
            e.Graphics.DrawString($@"Total", new Font("Arial", 8,FontStyle.Bold), Brushes.Black, new Point(X + 450, Y + 105));
            e.Graphics.DrawString($@"Note", new Font("Arial", 8,FontStyle.Bold), Brushes.Black, new Point(X + 550, Y + 105));
            int i = 5;
            int index = 0; 
            for (int j = 0; j < ProddataGridView.Rows.Count; j++)
            {
                i = i + 15;
                e.Graphics.DrawString($@"{index += 1}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 8, Y + 105 + i));
                e.Graphics.DrawString($@"{ProddataGridView.Rows[j].Cells[2].Value}", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(X + 50, Y + 105 + i));
                e.Graphics.DrawString($@"{ProddataGridView.Rows[j].Cells[3].Value} {ProddataGridView.Rows[j].Cells[4].Value}", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(X + 252, Y + 105 + i));
                e.Graphics.DrawString($@"{ProddataGridView.Rows[j].Cells[5].Value}", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(X + 350, Y + 105 + i));
                e.Graphics.DrawString($@"{ProddataGridView.Rows[j].Cells[6].Value}", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(X + 450, Y + 105 + i));
                e.Graphics.DrawString($@"{ProddataGridView.Rows[j].Cells[7].Value}", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(X + 550, Y + 105 + i));                
            }
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new PointF(00.0F, 220.0F + i), new PointF(850.0F, 220.0F + i));
            e.Graphics.DrawString($@"Total :-", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 404, Y + 125 + i));
            e.Graphics.DrawString($@"{lblTotalAmount.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 450, Y + 125 + i));
            e.Graphics.DrawString($@"Discount ", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 340, Y + 145 + i));
            e.Graphics.DrawString($@"({txtDiscount.Text})%", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 393, Y + 145 + i));
            e.Graphics.DrawString($@" :-", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 433, Y + 145 + i));
            e.Graphics.DrawString($@"{lbldiscamt.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 450, Y + 145 + i));
            e.Graphics.DrawString($@"VAT", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 370, Y + 165 + i));
            e.Graphics.DrawString($@"({txtVAT.Text})%", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 393, Y + 165 + i));
            e.Graphics.DrawString($@" :-", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 433, Y + 165 + i));
            e.Graphics.DrawString($@"{lblVatamt.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 450, Y + 165 + i));
            //e.Graphics.DrawString($@"Discount ({txtDiscount.Text})% :-", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 355, Y + 145 + i));
            //e.Graphics.DrawString($@"{lbldiscamt.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 450, Y + 145 + i));
            //e.Graphics.DrawString($@"VAT ({txtVAT.Text})% :-", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 375, Y + 165 + i));
            //e.Graphics.DrawString($@"{lblVatamt.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 450, Y + 165 + i));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new PointF(380.0F, 282.0F + i), new PointF(600.0F, 282.0F + i));
            e.Graphics.DrawString($@"Grand Total :- ", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 366, Y + 185 + i));
            e.Graphics.DrawString($@"{lblTotalBill.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 450, Y + 185 + i));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new PointF(00.0F, 300.0F + i), new PointF(850.0F, 300.0F + i));
            e.Graphics.DrawString($@"Words :- {lblToWords.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X, Y + 205 + i));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new PointF(00.0F, 320.0F + i), new PointF(850.0F, 320.0F + i));
            e.Graphics.DrawString($@"Signature:- {Global.UserName}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X, Y + 225 + i));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new PointF(00.0F, 340.0F + i), new PointF(850.0F, 340.0F + i));
            e.Graphics.DrawString($@"{Global.billMessage}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 250, Y + 225 + i));
            e.Graphics.DrawString($@"{Global.copyrightYear}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 575, Y + 225 + i));
        }

        private void btn_UnitAdd_Click(object sender, EventArgs e)
        {
            var frm = new frm_Unit(true);
            frm.ShowDialog();
        }
        private void btn_GodownAdd_Click(object sender, EventArgs e)
        {
            var frm = new frm_Godown(true);
            frm.ShowDialog();
        }
        public void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MouseBtn = 1;
            btn_Refresh_Click(sender, e);
        }
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            if (MouseBtn == 1)
            {
                frm_PurchaseOrder_Load(sender, e);
                FormStatus(true, false);
            }
            else
            {
                if (MessageBox.Show("Are you sure to Refresh...!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                frm_PurchaseOrder_Load(sender, e);
                FormStatus(true, false);
            }
        }
        private void globalTab_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar is (char)Keys.Enter) SendKeys.Send("{TAB}");
            escFunction(sender, e);
        }
        private void GlobalDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (e.KeyChar is (char)Keys.Enter) SendKeys.Send("{TAB}");
        }
        private void btnUnitAdd_Click(object sender, EventArgs e)
        {
            var frm = new frm_Unit(true);
            frm.ShowDialog();
            refreshToolStripMenuItem_Click(sender, e);
        }
        private void btnGodownAdd_Click(object sender, EventArgs e)
        {
            var frm = new frm_Godown(true);
            frm.ShowDialog();
            refreshToolStripMenuItem_Click(sender, e);
        }
        private void txtDate_Leave(object sender, EventArgs e)
        {
            GetMiti();
        }
        private void ProddataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            ProddataGridView.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }
        public void Total_click(object sender, EventArgs e)
        {
            lbldiscamt.Text = lblVatamt.Text = lblToWords.Text = lblBillBDiscount.Text = lblTotalBill.Text = lblTotalAmount.Text = string.Empty;
            lbldiscamt.Text = lblVatamt.Text = lblBillBDiscount.Text = lblTotalBill.Text = lblTotalAmount.Text = "0";
            quantity = 0;
            for (int i = 0; i < ProddataGridView.Rows.Count; i++)
            {
                lblTotalAmount.Text = Convert.ToString(double.Parse(lblTotalAmount.Text) + double.Parse(ProddataGridView.Rows[i].Cells[6].Value.ToString()));

                var discamt = Convert.ToDecimal(double.Parse(lblTotalAmount.Text) * (double.Parse(txtDiscount.Text) / 100));
                lbldiscamt.Text = Decimal.Round(discamt, 2).ToString();

                var BillBDiscount = Convert.ToDecimal(double.Parse(lblTotalAmount.Text) - double.Parse(lbldiscamt.Text));
                lblBillBDiscount.Text = Decimal.Round(BillBDiscount, 2).ToString();

                var VatAmt = Convert.ToDecimal(double.Parse(lblBillBDiscount.Text) * (double.Parse(txtVAT.Text) / 100));
                lblVatamt.Text = Decimal.Round(VatAmt, 2).ToString();

                var TotalBill = Convert.ToDecimal(double.Parse(lblBillBDiscount.Text) + double.Parse(lblVatamt.Text));
                lblTotalBill.Text = Decimal.Round(TotalBill, 2).ToString();

                lblToWords.Text = Towords.NumberToWords(double.Parse(lblTotalBill.Text));
                var disp = ProddataGridView.Rows[i].Cells[3].Value.ToString();
                var dippp = quantity;

                quantity = (Convert.ToDecimal(ProddataGridView.Rows[i].Cells[3].Value) + quantity);

            }
        }
        private void btn_Recalculate_Click(object sender, EventArgs e)
        {
            if (count != 1)
            {
                Total_click(sender, e);
                count++;
            }
            else txtDiscount.Focus();


        }
        private void btn_ChkGrid_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ProddataGridView.Rows.Count; i++)
            {
                if (lbl_ProductID.Text == ProddataGridView.Rows[i].Cells[1].Value.ToString())
                {
                    MessageBox.Show("Duplicate Value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    DuplicateValue = 1;
                    return;
                    //txt_Name.Focus();
                }
                else DuplicateValue = 0;
            }
        }
        private void Btn_Insert_Click(object sender, EventArgs e)
        {
            if (ProdID == 0 && ProddataGridView.RowCount > 0)
            {
                txtDiscount.Focus();
            }
            else
            {
                btn_ChkGrid_Click(sender, e);
                if (DuplicateValue == 0)
                {
                    txt_PurchasePrice_Leave(sender, e);
                    if (IsProductOk())
                    {
                        string Sno = string.Empty;
                        AddRow(Sno, lbl_ProductID.Text, txt_Name.Text, txt_Quantity.Text, txtUnit.Text, txt_PurchasePrice.Text, lblTotal.Text, txt_Note.Text, lblPShortname.Text, lbl_Barcode.Text);
                        ProductEntryClear();
                        Total_click(sender, e);
                        txt_Name.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Please Enter data..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ProductEntryClear();
                        txt_Name.Focus();
                    }
                }
                else
                {
                    ProductEntryClear();
                    txt_Name.Focus();
                }
            }

        }

        private void TxtPname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control is true && e.KeyCode is Keys.N)
            {
                var frm = new frm_CustomerEntry(true);
                frm.ShowDialog();
                CustoID = frm.custoid;
                TxtPname.Text = frm.CustoName;
                txtCname.Text = frm.companyName;
                txtPaddress.Text = frm.address;
                txtPContactnum.Text = frm.contact;
            }
            if (e.KeyCode is Keys.F1 && CustoID == 0)
            {
                Btn_CustoSearch.PerformClick();
            }
        }
        private void TxtPname_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtPname.Text)) Btn_CustoSearch.PerformClick();
        }

        private void txtVoucherNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtVoucherNum.ReadOnly is true)
            {
                if (e.KeyCode is Keys.F1 && ToPerform is "Update" || ToPerform is "Delete" && TxtPname.ReadOnly is true) Btn_CustoSearch.PerformClick();
            }
        }
        private void ProddataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ProddataGridView.Rows.Count > 0)
            {
                if (MessageBox.Show("Are you sure to select Row", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ProductEntryClear();
                    ProdID = Int32.Parse(ProddataGridView.CurrentRow.Cells["PID"].Value.ToString()); lbl_ProductID.Text = ProdID.ToString();
                    lblPShortname.Text = ProddataGridView.CurrentRow.Cells["Short Name"].Value.ToString();
                    lbl_Barcode.Text = ProddataGridView.CurrentRow.Cells["BarCode"].Value.ToString();
                    txt_Name.Text = ProddataGridView.CurrentRow.Cells["Product"].Value.ToString();
                    var Quantity = double.Parse(ProddataGridView.CurrentRow.Cells["Quantity"].Value.ToString());
                    txt_Quantity.Text = Quantity == 0 ? "0" : Quantity.ToString("##.##########");
                    txtUnit.Text = ProddataGridView.CurrentRow.Cells["Unit"].Value.ToString();
                    //txt_AltQuantity.Text = ProddataGridView.CurrentRow.Cells["Alt. Quantity"].Value.ToString();
                    //txtAltUnit.Text = ProddataGridView.CurrentRow.Cells["Alt. Unit"].Value.ToString();
                    var PurchasePrice = double.Parse(ProddataGridView.CurrentRow.Cells["P. Price"].Value.ToString());
                    txt_PurchasePrice.Text = PurchasePrice == 0 ? "0" : PurchasePrice.ToString("##.##########");
                    var Total = double.Parse(ProddataGridView.CurrentRow.Cells["Total"].Value.ToString());
                    lblTotal.Text = Total == 0 ? "0" : Total.ToString("##.##########");
                    //txt_MRP.Text = ProddataGridView.CurrentRow.Cells["MRP"].Value.ToString();
                    //txt_OfferDiscount.Text = ProddataGridView.CurrentRow.Cells["Discount"].Value.ToString();
                    //txtGodown.Text = ProddataGridView.CurrentRow.Cells["Godown"].Value.ToString();
                    //txtMFP_Date.Text = ProddataGridView.CurrentRow.Cells["MFPDate"].Value.ToString();
                    //txtEXP_Date.Text = ProddataGridView.CurrentRow.Cells["EXPDate"].Value.ToString();
                    //txtProductType.Text = ProddataGridView.CurrentRow.Cells["Type"].Value.ToString();
                    txt_Note.Text = ProddataGridView.CurrentRow.Cells["P.Note"].Value.ToString();
                    var rowIndex = ProddataGridView.CurrentCell.RowIndex;
                    ProddataGridView.Rows.RemoveAt(rowIndex);
                    btn_Product_Search.Enabled = false;
                }
            }

        }
        private void btn_ProductClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to Reload product details.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) ProductEntryClear();
        }
        private void btn_Unit_Search_Click(object sender, EventArgs e)
        {
            if (Search == "Unit")
            {
                var popup = new frm_PopUpSearch(0, "MSM.UnitMaster", DbName, "GetUnit", 1, string.Empty, 0);
                if (frm_PopUpSearch.dt.Rows.Count > 0)
                {
                    popup.ShowDialog();
                    if (popup.SelectedRow.Count > 0)
                    {
                        unitID = int.Parse(popup.SelectedRow[0]["UnitID"].ToString());
                        txtUnit.Text = popup.SelectedRow[0]["UnitCode"].ToString();
                    }
                }
                Search = string.Empty;
            }
        }
        private void txtUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUnit.Text) && !string.IsNullOrEmpty(txt_Quantity.Text))
            {
                Search = "Unit";
                btn_Unit_Search_Click(sender, e);
            }
            else globalTab_KeyPress(sender, e);
        }
        private void txtUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.F1 && !string.IsNullOrEmpty(txt_Quantity.Text)) btn_Unit_Search_Click(sender, e);
            else if (e.Control is true && e.KeyCode is Keys.N)
            {
                var frm = new frm_Unit(true);
                frm.Show();
                unitID = frm.Unitid;
                txtUnit.Text = frm.UnitCode;
            }
        }
        private void txt_PurchasePrice_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_Name.Text))
            {
                var Total = Convert.ToDecimal(double.Parse(txt_Quantity.Text) * double.Parse(txt_PurchasePrice.Text));
                lblTotal.Text = Decimal.Round(Total, 3).ToString();
            }

        }
        private void recalculateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Total_click(sender, e);
        }
        private void txtDiscount_Enter(object sender, EventArgs e)
        {
            Total_click(sender, e);
        }
        private void txtVAT_Enter(object sender, EventArgs e)
        {
            Total_click(sender, e);
        }

        private void txtVAT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.F2) btn_Recalculate.Focus();
        }

        private void txt_PurchasePrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.Enter)
            {
                if (ProdID > 0 || ProddataGridView.RowCount > 0) SendKeys.Send("{TAB}");
                else txt_Name.Focus();
            }
        }

        private void viewInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var popup = new frm_PopUpSearch(0, "[MSM].[ProductInventory]", Global.InitialCatalogMain, "ProductInventory", 0, string.Empty, 0);
            if (frm_PopUpSearch.dt.Rows.Count > 0) popup.ShowDialog();
        }

        private void txtVAT_Leave(object sender, EventArgs e)
        {
            Total_click(sender, e);
        }
        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            Total_click(sender, e);
        }
        #endregion

        #region Might be usefull in another form
        //private void btn_Godown_Search_Click(object sender, EventArgs e)
        //{
        //    var popup = new frm_PopUpSearch(GodownID, "MSM.StoreGodown", DbName, "GetGodown", 1);
        //    if (frm_PopUpSearch.dt.Rows.Count > 0)
        //    {
        //        popup.ShowDialog();
        //        if (popup.SelectedRow.Count > 0)
        //        {
        //            GodownID = int.Parse(popup.SelectedRow[0]["GodID"].ToString());
        //            txtGodown.Text = popup.SelectedRow[0]["GodName"].ToString();
        //        }
        //    }
        //}

        //private void btn_Unit_Search_Click(object sender, EventArgs e)
        //{
        //    if (Search == "Unit")
        //    {
        //        var popup = new frm_PopUpSearch(unitID, "MSM.UnitMaster", DbName, "GetUnit", 1);
        //        if (frm_PopUpSearch.dt.Rows.Count > 0)
        //        {
        //            popup.ShowDialog();
        //            if (popup.SelectedRow.Count > 0)
        //            {
        //                unitID = int.Parse(popup.SelectedRow[0]["UnitID"].ToString());
        //                txtUnit.Text = popup.SelectedRow[0]["UnitCode"].ToString();
        //            }
        //        }
        //        Search = string.Empty;
        //    }
        //    //else
        //    //{
        //    //    var popup = new frm_PopUpSearch(altUnitID, "MSM.UnitMaster", DbName, "GetUnit", 1);
        //    //    if (frm_PopUpSearch.dt.Rows.Count > 0)
        //    //    {
        //    //        popup.ShowDialog();
        //    //        if (popup.SelectedRow.Count > 0)
        //    //        {
        //    //            altUnitID = int.Parse(popup.SelectedRow[0]["UnitID"].ToString());
        //    //            txtAltUnit.Text = popup.SelectedRow[0]["UnitCode"].ToString();
        //    //        }
        //    //    }
        //    //}
        //}


        //private void btn_ProductType_Search_Click(object sender, EventArgs e)
        //{
        //    var popup = new frm_PopUpSearch(ProdTypeID, "MSM.StoreGodown", DbName, "GetCategory", 1);
        //    if (frm_PopUpSearch.dt.Rows.Count > 0)
        //    {
        //        popup.ShowDialog();
        //        if (popup.SelectedRow.Count > 0)
        //        {
        //            ProdTypeID = int.Parse(popup.SelectedRow[0]["CatID"].ToString());
        //            txtProductType.Text = popup.SelectedRow[0]["Category"].ToString();
        //        }
        //    }
        //}

        //private void txtAltUnit_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (string.IsNullOrEmpty(txtAltUnit.Text) && !string.IsNullOrEmpty(txt_AltQuantity.Text)) btn_Unit_Search_Click(sender, e);
        //    else globalTab_KeyPress(sender, e);
        //}

        //private void txtGodown_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (string.IsNullOrEmpty(txtGodown.Text)) btn_Godown_Search_Click(sender, e);
        //    else globalTab_KeyPress(sender, e);
        //}

        //private void txtProductType_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (string.IsNullOrEmpty(txtProductType.Text)) btn_ProductType_Search_Click(sender, e);
        //    else globalTab_KeyPress(sender, e);
        //}

        //private void txtAltUnit_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode is Keys.F1 && !string.IsNullOrEmpty(txt_AltQuantity.Text)) btn_Unit_Search_Click(sender, e);
        //    else if (e.Control is true && e.KeyCode is Keys.N)
        //    {
        //        var frm = new frm_Unit(true);
        //        frm.Show();
        //        altUnitID = frm.Unitid;
        //        txtAltUnit.Text = frm.UnitCode;
        //    }
        //}

        //private void txtGodown_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode is Keys.F1 && !string.IsNullOrEmpty(txtGodown.Text)) btn_Godown_Search_Click(sender, e);
        //    else if (e.Control is true && e.KeyCode is Keys.N)
        //    {
        //        var frm = new frm_Godown(true);
        //        frm.Show();
        //        GodownID = frm.Godownid;
        //        txtGodown.Text = frm.GodownName;
        //    }
        //}

        //private void txtProductType_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode is Keys.F1 && !string.IsNullOrEmpty(txtProductType.Text)) btn_ProductType_Search_Click(sender, e);
        //    else if (e.Control is true && e.KeyCode is Keys.N)
        //    {
        //        var frm = new frm_ProductTypes(true);
        //        frm.Show();
        //        ProdTypeID = frm.CategoryID;
        //        txtProductType.Text = frm.ProdType;
        //    }
        //}
        #endregion
    }
}
