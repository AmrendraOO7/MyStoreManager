using MSMControl.Class;
using MSMControl.Connection;
using MSMControl.Interface;
using MyStoreManager.PreEntry;
using MyStoreManager.Print.PrintForm;
using MyStoreManager.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStoreManager.BillEntry.Purchase
{
    public partial class frm_PurchaseReturn : Form
    {
        private readonly IMainMaster mainMaster = new ClsMainMaster();
        private readonly INumbetToWords Towords = new ClsNumberToWord();
        private string ToPerform, msg = string.Empty;
        private int VoucherNum; //string for voucher number
        private int CustoID; //Customer Id 
        private int ProdID; //Product ID
        private int unitID; //Unit ID // uitlized in grid
        private decimal quantity;
        private int MouseBtn; //mouse button status holder
        private int loginID; //Login id
        private int PRID; //Purchase Enty id
        private int Pid; //PersonID
        private int POID; //Purchase Order id
        private int senderId;
        private int OldCreatorUserID;
        private int currentColumn;
        private bool NoteMandatory; //saves note while order is updated
        private bool isDeleted = false; //by default it is false
        private int DuplicateValue; //to check duplicate product in grid
        private int count; //count the value in recalculate
        private int updatedRowVal = 0; // to keep record of the original rows in case of update
        private decimal invData; // to check inventory value before returning the good
        private string PVNUM; //purchase voucher number
        private string Search = string.Empty;
        private bool fromPrint = false;
        clsPleaseWaitForm PleaseWait = new clsPleaseWaitForm();
        //public DataGridView UpdateProddataGridViewData;

        private DateTime OldCreatedDate;
        private DateTime NullDate; //kept to hold its default value null.
        //private Data checkPE;

        public String[] oldValue = new String[] { };
        public frm_PurchaseReturn()
        {
            InitializeComponent();
            DataGridColumns();
        }
        private void frm_PurchaseReturn_Load(object sender, EventArgs e)
        {
            clear();
            FormStatus(true, false);
            //DataGridColumns();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MouseBtn = 1;
            reloadEventFunction(sender, e);
            MouseBtn = 0;
        }

        private void recalculateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Total_click(sender, e);
        }

        private void viewInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var popup = new frm_PopUpSearch(0, string.Empty, Global.InitialCatalogMain, "ProductInventory", 0, string.Empty, 0);
            if (frm_PopUpSearch.dt.Rows.Count > 0) popup.ShowDialog();
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            ToPerform = "Insert";
            Btn_Ok.Text = "&Save";
            VoucherNumber(); // Just to be sure
            FormStatus(false, true);
            English_dateTimePicker.Value = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            English_dateTimePicker.Focus();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            ToPerform = "Update";
            txtVoucherNum.Focus();
            Btn_Ok.Text = "&Update";
            FormStatus(false, true);
            UpdateDataGrid();
            UpdateProddataGridViewData.Visible = true;
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            ToPerform = "Delete";
            Btn_Ok.Text = "&Delete";

            //txtreadonly(true);
            //UpdateDataGrid();
            UpdateProddataGridViewData.Visible = false;
            ProddataGridView.Enabled = false;
            TxtPersonName.Enabled = txtVoucherNum.Enabled = Btn_CustoSearch.Enabled = true;
            btn_Product_Search.Enabled = Btn_Ok.Enabled = true;
        }

        private void btn_PR_VoucherSearch_Click(object sender, EventArgs e)
        {
            if (ToPerform == "Update" || ToPerform == "Delete")
            {
                var popup = new frm_PopUpSearch(0, string.Empty, Global.InitialCatalogMain, "PurchaseReturnEntry", 0, string.Empty, 0);
                if (frm_PopUpSearch.dt.Rows.Count > 0)
                {
                    popup.ShowDialog();
                    if (popup.SelectedRow.Count > 0)
                    {
                        PRID = Int32.Parse(popup.SelectedRow[0]["PRID"].ToString());
                        txtVoucherNum.Text = PVNUM = popup.SelectedRow[0]["PRVNUM"].ToString();
                        English_dateTimePicker.Value = DateTime.Parse(popup.SelectedRow[0]["Purchase_Return_Date"].ToString());
                        txtMiti.Text = popup.SelectedRow[0]["Purchase_Return_Miti"].ToString();
                        senderId = Int32.Parse(popup.SelectedRow[0]["SenderID"].ToString()); //sender in purchase entry is receiver here in return entry
                        CustoID = Int32.Parse(popup.SelectedRow[0]["ReceiverID"].ToString());
                        TxtPersonName.Text = popup.SelectedRow[0]["PartyName"].ToString();
                        txtCompanyName.Text = popup.SelectedRow[0]["PartyCompany"].ToString();
                        txtCompanyAddress.Text = popup.SelectedRow[0]["PartyAddress"].ToString();
                        txtCompanyContactNum.Text = popup.SelectedRow[0]["PartyContact"].ToString();
                        cmbTransection.Text = popup.SelectedRow[0]["TransectionOn"].ToString();
                        var Vat = Decimal.Parse(popup.SelectedRow[0]["Vat"].ToString());
                        txtVAT.Text = Vat == 0 ? "0.00" : Vat.ToString("##.##########");
                        var Dis = Decimal.Parse(popup.SelectedRow[0]["Discount"].ToString());
                        txtDiscount.Text = Dis == 0 ? "0.00" : Dis.ToString("##.##########");
                        var is_Deleted = popup.SelectedRow[0]["is_Deleted"].ToString();
                        if (is_Deleted == "ACTIVE") isDeleted = false; else isDeleted = true;
                        OldCreatorUserID = Int32.Parse(popup.SelectedRow[0]["UserID"].ToString());
                        OldCreatedDate = Convert.ToDateTime(popup.SelectedRow[0]["DateCreated"].ToString());
                        txt_Note.Text = popup.SelectedRow[0]["Note"].ToString();
                        var ds = mainMaster.GetPurchaseReturnEntry(PVNUM);
                        if (ds.Tables.Count > 0)
                        {
                            ProddataGridView.Rows.Clear();
                            if (UpdateProddataGridViewData != null) UpdateProddataGridViewData.Rows.Clear();
                            foreach (DataRow dgv in ds.Tables[0].Rows)
                            {
                                var rows = ProddataGridView.Rows.Count;
                                ProddataGridView.Rows.Add();
                                if (!fromPrint) UpdateProddataGridViewData.Rows.Add();
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["PID"].Value = dgv["PID"].ToString();
                                if (!fromPrint) UpdateProddataGridViewData.Rows[UpdateProddataGridViewData.RowCount - 1].Cells["PID"].Value = dgv["PID"].ToString();
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Product"].Value = dgv["PName"].ToString();
                                if (!fromPrint) UpdateProddataGridViewData.Rows[UpdateProddataGridViewData.RowCount - 1].Cells["Product"].Value = dgv["PName"].ToString();
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Quantity"].Value = decimal.Parse(dgv["Quantiy"].ToString()).ToString("##.##########");
                                if (!fromPrint) UpdateProddataGridViewData.Rows[UpdateProddataGridViewData.RowCount - 1].Cells["Quantity"].Value = dgv["Quantiy"].ToString();
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Unit"].Value = dgv["UnitCode"].ToString();
                                if (!fromPrint) UpdateProddataGridViewData.Rows[UpdateProddataGridViewData.RowCount - 1].Cells["Unit"].Value = dgv["UnitCode"].ToString();
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["P. Price"].Value = decimal.Parse(dgv["PPrice"].ToString()).ToString("##.##########");
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Total"].Value = decimal.Parse(dgv["TotalPrice"].ToString()).ToString("##.##########");
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Short Name"].Value = dgv["PCode"].ToString();
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["BarCode"].Value = dgv["PBarcode"].ToString();
                                ProddataGridView.CurrentCell = ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells[currentColumn];
                            }
                            ProddataGridView.ClearSelection();
                            //UpdateProddataGridViewData = ProddataGridView;
                            if (!fromPrint) updatedRowVal = UpdateProddataGridViewData.RowCount; //required because value in object changes so kept in variable
                            if (ToPerform == "Delete")
                            {
                                FormStatus(false, false);
                                Btn_Ok.Enabled = true; Btn_Ok.Focus();
                            }
                            else txtVoucherNum.Focus();
                        }
                        if (fromPrint == true)
                        {
                            //txtreadonly(true);
                            FormStatus(false, false);
                            Total_click(sender, e);
                            fromPrint = false;
                            btnPrint.PerformClick();
                        }
                    }
                }
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
            escFunction(sender, e);
        }

        private void escFunction(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar is (char)Keys.Escape)
            {
                if (string.IsNullOrEmpty(TxtPersonName.Text.Trim()) && Pid == 0)
                {
                    if (MessageBox.Show("Are you sure to Close...!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                    this.Close();
                }
                else
                {
                    if (MessageBox.Show("Are you sure to Clear...!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                    MouseBtn = 1;
                    refreshToolStripMenuItem.PerformClick();
                    //clear();
                    //btn_sendtoGrid.Enabled = false;
                }
            }
        }

        private void Btn_CustoSearch_Click(object sender, EventArgs e)
        {
            if(ToPerform == "Insert")
            {
                var popup = new frm_PopUpSearch(0, string.Empty, Global.InitialCatalogMain, "CustomerSelect", 1, string.Empty, 0);
                if (frm_PopUpSearch.dt.Rows.Count > 0)
                {
                    popup.ShowDialog();
                    if (popup.SelectedRow.Count > 0)
                    {
                        CustoID = Int32.Parse(popup.SelectedRow[0]["CID"].ToString());
                        TxtPersonName.Text = popup.SelectedRow[0]["PartyName"].ToString();
                        txtCompanyName.Text = popup.SelectedRow[0]["PartyCompany"].ToString();
                        txtCompanyAddress.Text = popup.SelectedRow[0]["PartyAddress"].ToString();
                        txtCompanyContactNum.Text = popup.SelectedRow[0]["PartyContact"].ToString();
                        //txt_Note.Text = popup.SelectedRow[0]["PartyNote"].ToString();
                        var status = popup.SelectedRow[0]["ActiveStatus"].ToString();
                        //txtCustomerReadonly(true);
                    }
                }
                else
                {
                    MessageBox.Show("No Data..!!", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                TxtPersonName.Focus();
            }
        }

        private void btn_Product_Search_Click(object sender, EventArgs e)
        {
            var popup = new frm_PopUpSearch(0, string.Empty, Global.InitialCatalogMain, "ProductSelect", 1, string.Empty, 0);
            if (frm_PopUpSearch.dt.Rows.Count > 0)
            {
                popup.ShowDialog();
                if (popup.SelectedRow.Count > 0)
                {
                    ProdID = Int32.Parse(popup.SelectedRow[0]["PID"].ToString());
                    txtProductName.Text = popup.SelectedRow[0]["PName"].ToString();
                    lbl_ProductID.Text = ProdID.ToString();
                    lblPShortname.Text = popup.SelectedRow[0]["PCode"].ToString();
                    lbl_Barcode.Text = popup.SelectedRow[0]["PBarcode"].ToString();
                    var QntiString = popup.SelectedRow[0]["UnitQnty"].ToString();
                    var Quantity = QntiString == "" ? Decimal.Parse("0") : Decimal.Parse(QntiString);
                    txt_Quantity.Text = Quantity == 0 ? "0" : Quantity.ToString("##.##########");
                    unitID = Int32.Parse(popup.SelectedRow[0]["UnitID"].ToString());
                    txtUnit.Text = popup.SelectedRow[0]["MainUnitCode"].ToString();
                    var PurchasePrice = Decimal.Parse(popup.SelectedRow[0]["PurchasePrice"].ToString());
                    txt_PurchasePrice.Text = PurchasePrice == 0 ? "0" : PurchasePrice.ToString("##.##########");
                    var MRP = Decimal.Parse(popup.SelectedRow[0]["MRP"].ToString());
                }
                txtProductName.Focus();
            }
            else
            {
                MessageBox.Show("No Data..!!", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        #region----------------------Functions---------------------
        private void clear()
        {
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
            PRID = Pid = POID = loginID = CustoID = ProdID = unitID = VoucherNum = senderId = OldCreatorUserID = currentColumn = MouseBtn = DuplicateValue = count = updatedRowVal = 0;
            //isEnteredByPO = false;
            NoteMandatory = Global.checkReturnNote;
            isDeleted = false;
            txtVoucherNum.Clear();
            //txtPurchaseOrderNum.Clear();
            //txtReferenceNum.Clear();
            TxtPersonName.Clear();
            txtCompanyName.Clear();
            txtCompanyAddress.Clear();
            txtCompanyContactNum.Clear();
            cmbTransection.Text = "CASH";
            txtProductName.Clear();
            txt_Quantity.Clear();
            txtUnit.Clear();
            txt_PurchasePrice.Clear();
            //txt_RefBillNo.Clear();
            lblTotal.Text = lblTotalAmount.Text = lbldiscamt.Text = lblBillBDiscount.Text = lblVatamt.Text = lblTotalBill.Text = "0.00";
            lblToWords.Text = txt_Note.Text = lbl_ProductID.Text = lblPShortname.Text = lbl_Barcode.Text = "";
            ConfigInitials();
            GetMiti();
            ProddataGridView.Rows.Clear();
            UpdateProddataGridViewData.Rows.Clear();
            UpdateProddataGridViewData.Visible = false;
            ProddataGridView.Enabled = true;
            fromPrint = false;
        }
        protected void VoucherNumber()
        {
            if (ToPerform == "Insert")
            {
                VoucherNum = ClsMainMaster.getInt("MSM.PurchaseReturnMaster", "PRID");
                if (VoucherNum.ToString().Length == 1) txtVoucherNum.Text = "PR-" + $"{Global.Year}" + "-" + "00" + VoucherNum;
                else if (VoucherNum.ToString().Length == 2) txtVoucherNum.Text = "PR-" + $"{Global.Year}" + "-" + "0" + VoucherNum;
                else txtVoucherNum.Text = "PR-" + $"{Global.Year}" + "-" + VoucherNum;
            }
        }

        private void FormStatus(bool btn, bool txt)
        {
            btn_New.Enabled = btn_Edit.Enabled = btn_Delete.Enabled = btn;
            //buttons bellow will enable with the text enable
            txtVoucherNum.Enabled = English_dateTimePicker.Enabled = txtMiti.Enabled = TxtPersonName.Enabled = txtCompanyName.Enabled = txtCompanyAddress.Enabled = txtCompanyContactNum.Enabled = cmbTransection.Enabled = txtProductName.Enabled = txt_Quantity.Enabled = txtUnit.Enabled = txt_PurchasePrice.Enabled = txt_Note.Enabled = txtDiscount.Enabled = txtVAT.Enabled = txt;
            btn_PR_VoucherSearch.Enabled = ProddataGridView.Enabled = Btn_Ok.Enabled = btn_ProductClear.Enabled = Btn_Product_Insert.Enabled =  Btn_CustoSearch.Enabled =  btn_Product_Search.Enabled = btn_Recalculate.Enabled = txt;
        }
        public void Total_click(object sender, EventArgs e)
        {
            lbldiscamt.Text = lblVatamt.Text = lblToWords.Text = lblBillBDiscount.Text = lblTotalBill.Text = lblTotalAmount.Text = string.Empty;
            lbldiscamt.Text = lblVatamt.Text = lblBillBDiscount.Text = lblTotalBill.Text = lblTotalAmount.Text = "0.00";
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

                //quantity = (Convert.ToDecimal(ProddataGridView.Rows[i].Cells[3].Value) + quantity);
            }
        }
        private void reloadEventFunction(object sender, EventArgs e)
        {
            if (MouseBtn == 1)
            {
                frm_PurchaseReturn_Load(sender, e);
                //FormStatus(true, false);
            }
            else  // else case is for the button on the form
            {
                if (MessageBox.Show("Are you sure to Refresh...!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                frm_PurchaseReturn_Load(sender, e);
                //FormStatus(true, false);
            }
        }
        public void ConfigInitials()
        {
            var Configdt = mainMaster.checkConfig();
            var VAT = decimal.Parse(Configdt.Rows[0]["VAT"].ToString());
            txtVAT.Text = VAT == 0 ? "0.00" : VAT.ToString("##.##########");
            var Discount = decimal.Parse(Configdt.Rows[0]["Discount"].ToString());
            txtDiscount.Text = Discount == 0 ? "0.00" : Discount.ToString("##.##########");
        }
        private void GetMiti()
        {
            txtMiti.Text = mainMaster.GetMiti(English_dateTimePicker.Text);
        }

        public void UpdateDataGrid()
        {
            UpdateProddataGridViewData.ColumnCount = 5;
            UpdateProddataGridViewData.Columns[0].Name = "SNO";
            UpdateProddataGridViewData.Columns[1].Name = "PID";
            UpdateProddataGridViewData.Columns[2].Name = "Product";
            UpdateProddataGridViewData.Columns[3].Name = "Quantity";
            UpdateProddataGridViewData.Columns[4].Name = "Unit";

            UpdateProddataGridViewData.Columns[0].Visible = false;
            UpdateProddataGridViewData.Columns[1].Width = 30;
            UpdateProddataGridViewData.Columns[2].Visible = false;
            UpdateProddataGridViewData.Columns[3].Width = 70;
            UpdateProddataGridViewData.Columns[4].Width = 70;
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
            ProddataGridView.Columns[7].Visible = false;
            ProddataGridView.Columns[8].Width = 100;
            ProddataGridView.Columns[9].Width = 100;
        }

        #endregion

        private void English_dateTimePicker_Leave(object sender, EventArgs e)
        {
            if (Global.checkDate)
            {
                var date = Convert.ToDateTime(DateTime.Parse(English_dateTimePicker.Text).ToShortDateString());
                var dateNow = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                if (date > dateNow)
                {
                    MessageBox.Show("Careful you have selected Future date", "Careful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //English_dateTimePicker.Focus();
                }
                else if (date < dateNow)
                {
                    MessageBox.Show("Careful you have selected Previous date", "Careful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //English_dateTimePicker.Focus();
                }
            }
            GetMiti();
        }

        private void txtVoucherNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtVoucherNum.ReadOnly is true)
            {
                if (e.KeyCode is Keys.F1 && ToPerform is "Update" || ToPerform is "Delete") btn_PR_VoucherSearch.PerformClick();
            }
        }

        private void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control is true && e.KeyCode is Keys.N)
            {
                var frm = new frm_ProductEntry(true);
                frm.ShowDialog();
                ProdID = frm.ProdID;
                txtProductName.Text = frm.Prod_Name;
                lbl_ProductID.Text = frm.ProdID.ToString();
                lblPShortname.Text = frm.Prod_Code;
                lbl_Barcode.Text = frm.Prod_BCode;
                txt_Quantity.Text = frm.Qnty;
                txtUnit.Text = frm.Unit;
                txt_PurchasePrice.Text = frm.Pprice;
                txt_Note.Text = frm.PNote;

            }
            if (e.KeyCode is Keys.F1 && txtProductName.ReadOnly is true) btn_Product_Search.PerformClick();
        }

        private void TxtPersonName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control is true && e.KeyCode is Keys.N)
            {
                var frm = new frm_CustomerEntry(true);
                frm.ShowDialog();
                CustoID = frm.custoid;
                TxtPersonName.Text = frm.CustoName;
                txtCompanyName.Text = frm.companyName;
                txtCompanyAddress.Text = frm.address;
                txtCompanyContactNum.Text = frm.contact;
            }
            if (e.KeyCode is Keys.F1 && ToPerform == "Insert") Btn_CustoSearch.PerformClick();
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

        private void ProddataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            ProddataGridView.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }
        private void UpdateProddataGridViewData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            UpdateProddataGridViewData.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void AddRow(string Sno, string PID, string Pname, string quantity, string unit, string total, string PPrice, string Pnote, string SName, string Barcode)
        {
            string[] rows = { Sno, PID, Pname, quantity, unit, total, PPrice, Pnote, SName, Barcode };
            ProddataGridView.Rows.Add(rows);
        }

        private int checkInventoryErr()
        {
            if (ProdID <= 0) return 1;
            else
            {
                invData = ClsMainMaster.getInvData(ProdID);
               
                if(Convert.ToDecimal( txt_Quantity.Text.ToString()) > invData)
                {
                    MessageBox.Show("Your return amount is greater then yor stock amount."+"\n" + $@"Current Quantity {invData} ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return 1;
                }
                else return 0;
            }
        }

        private void checkProduct()
        {
            
            for (int i = 0; i < ProddataGridView.Rows.Count; i++)
            {
                String[] Array = new String[] { ProddataGridView.Rows[i].Cells[1].Value.ToString().Trim() };
                Console.WriteLine(Array);
            }
            //String[] columnName_ToDisplay = new String[] { "PVNUM", "PURCHASE ORDER NO", "REFERENCE NO" };
        }

        private void Btn_Product_Insert_Click(object sender, EventArgs e)
        {
            //checkProduct();
            if (ProdID == 0 && ProddataGridView.RowCount > 0) txtDiscount.Focus();
            else if (checkInventoryErr() == 1)
            {
                txt_Quantity.Focus();
                return;
            }
            else
            {
                btn_ChkGrid_Click(sender, e);
                if (DuplicateValue == 0)
                {
                    txt_PurchasePrice_Leave(sender, e);
                    if (IsProductOk())
                    {
                        ProddataGridView.Enabled = true;
                        string Sno = string.Empty;
                        AddRow(Sno, lbl_ProductID.Text, txtProductName.Text, txt_Quantity.Text, txtUnit.Text, txt_PurchasePrice.Text, lblTotal.Text, txt_Note.Text, lblPShortname.Text, lbl_Barcode.Text);
                        ProductEntryClear();
                        Total_click(sender, e);
                        txtProductName.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Please Enter data..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ProductEntryClear();
                        txtProductName.Focus();
                    }
                }
                else
                {
                    ProductEntryClear();
                    txtProductName.Focus();
                }
            }
        }

        public bool IsProductOk()
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text.Trim()))
            {
                MessageBox.Show("You must Enter Product Name", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //errorProvider.SetError(txt_Name, "Please enter Product name.");
                txtProductName.Focus();
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

        private void txt_PurchasePrice_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProductName.Text) && ProdID != 0)
            {
                var Total = Convert.ToDecimal(double.Parse(txt_Quantity.Text) * double.Parse(txt_PurchasePrice.Text));
                lblTotal.Text = Decimal.Round(Total, 3).ToString();
            }
        }

        public void ProductEntryClear()
        {
            ProdID = 0;
            btn_Product_Search.Enabled = true;
            txtProductName.Clear();
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

        private void btn_ProductClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to Reload product details.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) ProductEntryClear();
        }

        private void btn_Recalculate_Click(object sender, EventArgs e)
        {
            if (count != 1)
            {
                Total_click(sender, e);
                count++;
            }
            else Btn_Ok.Focus();
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
                English_dateTimePicker.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(TxtPersonName.Text.Trim())) //this is the company name
            {
                MessageBox.Show("You must Enter Receiver(Supplier) Name", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //errorProvider.SetError(TxtPname, "Please enter Supplier name");
                TxtPersonName.Focus();
                return false;
            }
            //if (string.IsNullOrWhiteSpace(txtCompanyName.Text.Trim()))
            //{
            //    MessageBox.Show("You must Enter Receiver(Supplier) Company Name", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    //errorProvider.SetError(txtCname, "Please enter Company name.");
            //    txtCompanyName.Focus();
            //    return false;
            //}
            if (string.IsNullOrWhiteSpace(txtCompanyAddress.Text.Trim()))
            {
                MessageBox.Show("You must Enter Receiver(Supplier) Address", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //errorProvider.SetError(txtPaddress, "Please enter Address.");
                txtCompanyAddress.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCompanyContactNum.Text.Trim()))
            {
                MessageBox.Show("You must Enter Receiver(Supplier) Contact ", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //errorProvider.SetError(txtPContactnum, "Please enter Supplier Contact.");
                txtCompanyContactNum.Focus();
                return false;
            }

            if (ProddataGridView.Rows.Count == 0)
            {
                MessageBox.Show("You have not made any selection", "Please Select Product", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductName.Focus();
                return false;
            }

            if (NoteMandatory == true && string.IsNullOrEmpty(txt_Note.Text))
            {
                MessageBox.Show("You must enter the purchase return note.", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_Note.Focus();
                return false;
            }

            if (ToPerform is "Update" && updatedRowVal != ProddataGridView.RowCount)
            {
                MessageBox.Show("You cannot add/remove item from list in case of update...\nYou can make quantity zero insted of removing...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
                return false;
            }
            if (NoteMandatory == true && string.IsNullOrEmpty(txt_Note.Text))
            {
                MessageBox.Show("You must enter the purchase note.", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_Note.Focus();
                return false;
            }
            else return true;
        }

        public int PurchaseReturnSave()
        {
            mainMaster.PR_Master.ToPerform = ToPerform;
            mainMaster.PR_Master.PRID = ToPerform is "Insert" ? ClsMainMaster.getInt("MSM.PurchaseReturnMaster", "PRID") : PRID;
            mainMaster.PR_Master.PRVNUM = txtVoucherNum.Text.Trim().Replace("'", "''");
            mainMaster.PR_Master.Purchase_Return_Date = English_dateTimePicker.Value;
            mainMaster.PR_Master.Purchase_Return_Miti = txtMiti.Text.Trim().Replace("'", "''");
            mainMaster.PR_Master.SenderID = (int)Global.CompanyID;
            mainMaster.PR_Master.ReceiverID = CustoID;
            mainMaster.PR_Master.TransectionOn = cmbTransection.Text.Trim().Replace("'", "''");
            mainMaster.PR_Master.Total = decimal.Parse(lblTotalAmount.Text);
            mainMaster.PR_Master.Discount = decimal.Parse(txtDiscount.Text);
            mainMaster.PR_Master.DiscAmount = decimal.Parse(lbldiscamt.Text);
            mainMaster.PR_Master.TotalAmount = decimal.Parse(lblBillBDiscount.Text);
            mainMaster.PR_Master.Vat = decimal.Parse(txtVAT.Text.Trim().Replace("'", "''"));
            mainMaster.PR_Master.VatAmt = decimal.Parse(lblVatamt.Text);
            mainMaster.PR_Master.BillTotal = decimal.Parse(lblTotalBill.Text);
            mainMaster.PR_Master.InWords = lblToWords.Text;
            mainMaster.PR_Master.Note = txt_Note.Text.Trim().Replace("'", "''");
            mainMaster.PR_Master.is_Deleted = isDeleted;
            mainMaster.PR_Master.UserID = Global.LoginID;

            mainMaster.PR_Details.ToPerform = mainMaster.PR_Master.ToPerform;
            mainMaster.PR_Details.PRID = mainMaster.PR_Master.PRID;
            mainMaster.PR_Details.PRVNUM = mainMaster.PR_Master.PRVNUM;
            //this update values are stored while updating and restoring the values in details table table after delete and re insert in case of update.
            if (ToPerform == "Update")
            {
                mainMaster.PR_Details.UserID = OldCreatorUserID;
                mainMaster.PR_Details.DateCreated = OldCreatedDate;
                mainMaster.PR_Details.MUserID = mainMaster.PR_Master.UserID;
            }
            else
            {
                mainMaster.PR_Details.UserID = mainMaster.PR_Master.UserID;
                mainMaster.PR_Details.DateCreated = NullDate;
            }
            mainMaster.PR_Details.GetGridViewData = ProddataGridView;

            if (ToPerform == "Update" || ToPerform == "Delete") mainMaster.PR_Details.updateGetGridViewData = UpdateProddataGridViewData;

            return mainMaster.GetPurchaseReturnSetup();
        }

        private void btn_Unit_Search_Click(object sender, EventArgs e)
        {
            if (Search == "Unit")
            {
                var popup = new frm_PopUpSearch(0, "MSM.UnitMaster", Global.InitialCatalogMain, "GetUnit", 1, string.Empty, 0);
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

        private void txtDiscount_Enter(object sender, EventArgs e)
        {
            Total_click(sender, e);
        }

        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            Total_click(sender, e);
        }

        private void txtVAT_Enter(object sender, EventArgs e)
        {
            Total_click(sender, e);
        }

        private void txtVAT_Leave(object sender, EventArgs e)
        {
            Total_click(sender, e);
        }

        private void txtVAT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.F2) btn_Recalculate.Focus();
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
                    txtProductName.Text = ProddataGridView.CurrentRow.Cells["Product"].Value.ToString();
                    var Quantity = double.Parse(ProddataGridView.CurrentRow.Cells["Quantity"].Value.ToString());
                    txt_Quantity.Text = Quantity == 0 ? "0.00" : Quantity.ToString("##.##########");
                    txtUnit.Text = ProddataGridView.CurrentRow.Cells["Unit"].Value.ToString();
                    var PurchasePrice = double.Parse(ProddataGridView.CurrentRow.Cells["P. Price"].Value.ToString());
                    txt_PurchasePrice.Text = PurchasePrice == 0 ? "0" : PurchasePrice.ToString("##.##########");
                    var Total = double.Parse(ProddataGridView.CurrentRow.Cells["Total"].Value.ToString());
                    lblTotal.Text = Total == 0 ? "0.00" : Total.ToString("##.##########");
                    var rowIndex = ProddataGridView.CurrentCell.RowIndex;
                    ProddataGridView.Rows.RemoveAt(rowIndex);
                    btn_Product_Search.Enabled = false;
                    ProddataGridView.Enabled = false;
                }
            }
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            panel.BackColor = ColorTranslator.FromHtml(Global.BackgroundColor);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (txtVoucherNum.Text.Trim() == "")
            {
                ToPerform = "Update";
                fromPrint = true;
                btn_PR_VoucherSearch_Click(sender, e);
            }
            //Print
            else if (ToPerform != "Delete" && !string.IsNullOrEmpty(txtVoucherNum.Text.Trim()))
            {
                printPreviewDialog.Document = printDocument;
                DialogResult result = printPreviewDialog.ShowDialog();
                if (result == DialogResult.OK) printDocument.Print();
            }
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            printDocument.DocumentName = $@"{txtVoucherNum.Text}";
            StringFormat center = new StringFormat();
            center.LineAlignment = StringAlignment.Center;
            center.Alignment = StringAlignment.Center;
            const int X = 50, Y = 100;
            const int increment = 150;
            e.Graphics.DrawString($@"{Global.CompanyName}", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, new Point(425, 40), center);
            e.Graphics.DrawString($@"{Global.Address}, {Global.City}, {Global.State}, {Global.Country}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(425, 60), center);
            e.Graphics.DrawString($@"Comp. Reg:-{Global.Registration}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(425, 75), center);
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new PointF(00.0F, 90.0F), new PointF(850.0F, 90.0F)); //Ref line:- https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics.drawline?view=windowsdesktop-7.0
            e.Graphics.DrawString($@"PR-BILL-No.:- {txtVoucherNum.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X, Y + 10));
            e.Graphics.DrawString($@"Date:- {txtMiti.Text}  ({English_dateTimePicker.Text})", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 450, Y + 10));
            e.Graphics.DrawString($@"Supplier Name:- {txtCompanyName.Text}  ({cmbTransection.Text})", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X, Y + 40));
            e.Graphics.DrawString($@"Address:- {txtCompanyAddress.Text}", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(X, Y + 60));
            e.Graphics.DrawString($@"Contact:- {txtCompanyContactNum.Text}", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(X, Y + 80));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new PointF(00.0F, 200.0F), new PointF(850.0F, 200.0F));
            e.Graphics.DrawString($@"SNO.", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X, Y + 105));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new PointF(00.0F, 220.0F), new PointF(850.0F, 220.0F));
            e.Graphics.DrawString($@"Items", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 50, Y + 105));
            e.Graphics.DrawString($@"Quantity", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 250 + increment - 20, Y + 105));
            e.Graphics.DrawString($@"Price", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 350 + increment, Y + 105));
            e.Graphics.DrawString($@"Total", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 450 + increment, Y + 105));
            int i = 5;
            int index = 0;
            for (int j = 0; j < ProddataGridView.Rows.Count; j++)
            {
                i = i + 15;
                e.Graphics.DrawString($@"{index += 1}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 8, Y + 105 + i));
                e.Graphics.DrawString($@"{ProddataGridView.Rows[j].Cells[2].Value}", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(X + 50, Y + 105 + i));
                e.Graphics.DrawString($@"{ProddataGridView.Rows[j].Cells[3].Value} {ProddataGridView.Rows[j].Cells[4].Value}", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(X + 252 + increment - 20, Y + 105 + i));
                e.Graphics.DrawString($@"{ProddataGridView.Rows[j].Cells[5].Value}/{ProddataGridView.Rows[j].Cells[4].Value}", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(X + 350 + increment - 10, Y + 105 + i));
                e.Graphics.DrawString($@"{ProddataGridView.Rows[j].Cells[6].Value}", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(X + 450 + increment, Y + 105 + i));
            }
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new PointF(00.0F, 220.0F + i), new PointF(850.0F, 220.0F + i));
            e.Graphics.DrawString($@"Total :-", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 404 + increment, Y + 125 + i));
            e.Graphics.DrawString($@"{lblTotalAmount.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 450 + increment, Y + 125 + i));
            e.Graphics.DrawString($@"Discount ", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 340 + increment, Y + 145 + i));
            e.Graphics.DrawString($@"({txtDiscount.Text})%", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 393 + increment, Y + 145 + i));
            e.Graphics.DrawString($@" :-", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 433 + increment, Y + 145 + i));
            e.Graphics.DrawString($@"{lbldiscamt.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 450 + increment, Y + 145 + i));
            e.Graphics.DrawString($@"VAT", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 370 + increment, Y + 165 + i));
            e.Graphics.DrawString($@"({txtVAT.Text})%", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 393 + increment, Y + 165 + i));
            e.Graphics.DrawString($@" :-", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 433 + increment, Y + 165 + i));
            e.Graphics.DrawString($@"{lblVatamt.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 450 + increment, Y + 165 + i));
            //e.Graphics.DrawString($@"Discount ({txtDiscount.Text})% :-", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 355 + increment, Y + 145 + i));
            //e.Graphics.DrawString($@"{lbldiscamt.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 450 + increment, Y + 145 + i));
            //e.Graphics.DrawString($@"VAT ({txtVAT.Text})% :-", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 375 + increment, Y + 165 + i));
            //e.Graphics.DrawString($@"{lblVatamt.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 450 + increment, Y + 165 + i));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new PointF(520.0F, 282.0F + i), new PointF(740.0F, 282.0F + i));
            e.Graphics.DrawString($@"Grand Total :- ", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 366 + increment, Y + 185 + i));
            e.Graphics.DrawString($@"{lblTotalBill.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 450 + increment, Y + 185 + i));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new PointF(00.0F, 300.0F + i), new PointF(850.0F, 300.0F + i));
            e.Graphics.DrawString($@"Words :- {lblToWords.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X, Y + 205 + i));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new PointF(00.0F, 320.0F + i), new PointF(850.0F, 320.0F + i));
            e.Graphics.DrawString($@"Note:- {txt_Note.Text.Trim()}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X, Y + 225 + i));
            e.Graphics.DrawString($@"Signature:- {Global.UserName}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X, Y + 250 + i));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new PointF(00.0F, 340.0F + i), new PointF(850.0F, 340.0F + i));
            e.Graphics.DrawString($@"{Global.billMessage}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 250, Y + 250 + i));
            e.Graphics.DrawString($@"{Global.copyrightYear}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 575, Y + 250 + i));
        }

        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                if (ToPerform is null) return;
                if (ToPerform is "Delete" && isDeleted == true)
                {
                    MessageBox.Show("This bill is already deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                msg = ToPerform == "Insert" ? "Save" : ToPerform;
                //These three must be in sequence.
                //if (chkQuantity() != 1) return; // this must run before total.
                Total_click(sender, e);
                //poDiffrence_Chk();
                //progress bar implememtation starts
                
                
                if (FormIsOK())
                {
                    PleaseWait.Show();
                    if (PurchaseReturnSave() != 0)
                    {
                        //chkQuantity();
                        PleaseWait.Close();
                        MessageBox.Show($@"{msg}d Sucessfully...!!!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frm_PurchaseReturn_Load(sender, e);
                    }
                    else
                    {
                        PleaseWait.Close();
                        MessageBox.Show($@"{msg} Error...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TxtPersonName.Focus();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtPersonName.Focus();
            }
        }
    }
}
