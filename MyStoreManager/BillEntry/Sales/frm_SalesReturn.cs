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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStoreManager.BillEntry.Sales
{
    public partial class frm_SalesReturn : Form
    {
        private readonly IMainMaster mainMaster = new ClsMainMaster();
        private readonly INumbetToWords Towords = new ClsNumberToWord();
        private string ToPerform, msg = string.Empty;
        private int VoucherNum; //string for voucher number
        private int Pid; //Person id
        private int MouseBtn; //mouse button status holder
        private int loginID; //Login id
        private int SRID; //Sales return id
        private int SAID; //sales id
        private int CustoID; //Customer Id 
        private int ProdID; //Product ID
        private int unitID; //Unit ID // uitlized in grid
        private decimal quantity;
        private int senderId;
        private int OldCreatorUserID;
        private int currentColumn;
        private bool NoteMandatory; //saves note while order is updated
        private bool isDeleted = false; //by default it is false
        private int DuplicateValue; //to check duplicate product in grid
        private int count; //count the value in recalculate
        private int updatedRowVal = 0; // to keep record of the original rows in case of update
        private decimal invData; // to check inventory value before returning the good
        private string Search = string.Empty;
        private string SRVNUM, SVNUM;
        private int showHold;
        private DateTime OldCreatedDate;
        private DateTime NullDate; //kept to hold its default value null.
        private bool enteringWithoutBillDetails;
        private bool fromPrint = false;
        private bool holdStatus = false;
        clsPleaseWaitForm PleaseWait = new clsPleaseWaitForm();

        public frm_SalesReturn()
        {
            InitializeComponent();
            DataGridColumns();
        }
        private void frm_SalesReturn_Load(object sender, EventArgs e)
        {
            clear();
            FormStatus(true, false);
        }

        public int SalesReturnEntrySave()
        {
            mainMaster.SR_Master.ToPerform = ToPerform;
            mainMaster.SR_Master.SRID = ToPerform is "Insert" ? ClsMainMaster.getInt("MSM.SalesReturnMaster", "SRID") : SRID;
            mainMaster.SR_Master.SRVNUM = txtVoucherNum.Text.Trim().Replace("'", "''");
            mainMaster.SR_Master.Sales_Date = English_dateTimePicker.Value;
            mainMaster.SR_Master.Sales_Miti = txtMiti.Text.Trim().Replace("'", "''");
            mainMaster.SR_Master.BuyerID = CustoID;
            mainMaster.SR_Master.SalerID = (int)Global.CompanyID;
            mainMaster.SR_Master.TransectionOn = cmbTransection.Text.Trim().Replace("'", "''");
            mainMaster.SR_Master.Total = decimal.Parse(lblTotalAmount.Text);
            mainMaster.SR_Master.Discount = decimal.Parse(txtDiscount.Text);
            mainMaster.SR_Master.DiscAmount = decimal.Parse(lbldiscamt.Text);
            mainMaster.SR_Master.TotalAmount = decimal.Parse(lblBillBDiscount.Text);
            mainMaster.SR_Master.Vat = decimal.Parse(txtVAT.Text.Trim().Replace("'", "''"));
            mainMaster.SR_Master.VatAmt = decimal.Parse(lblVatamt.Text);
            mainMaster.SR_Master.BillTotal = decimal.Parse(lblTotalBill.Text);
            mainMaster.SR_Master.InWords = lblToWords.Text;
            mainMaster.SR_Master.Note = txt_Note.Text.Trim().Replace("'", "''");
            mainMaster.SR_Master.is_Deleted = isDeleted;
            mainMaster.SR_Master.UserID = Global.LoginID;
            mainMaster.SR_Master.extraNote = null;
            mainMaster.SR_Master.status = true;
            mainMaster.SR_Master.paid_amount = Convert.ToDecimal(lblPaidAmt.Text);
            mainMaster.SR_Master.return_amount = Convert.ToDecimal(lblReturnAmt.Text);
            mainMaster.SR_Master.SAID = SAID;
            mainMaster.SR_Master.SVNUM = txtSalesVoucherNum.Text.Trim();
            mainMaster.SR_Master.previous_balance = Convert.ToDecimal(lbl_dueBalance.Text);
            mainMaster.SR_Master.sales_bill_amt = Convert.ToDecimal(lblPaidAmt.Text); 

            mainMaster.SR_Details.ToPerform = mainMaster.SR_Master.ToPerform;
            mainMaster.SR_Details.SRID = mainMaster.SR_Master.SRID;
            mainMaster.SR_Details.SRVNUM = mainMaster.SR_Master.SRVNUM;
            mainMaster.SR_Details.UserID = mainMaster.SR_Master.UserID;
            //this update values are stored while updating and restoring the values in details table table after delete and re insert in case of update.
            if (ToPerform == "Update")
            {
                mainMaster.SR_Details.UserID = OldCreatorUserID;
                mainMaster.SR_Details.DateCreated = OldCreatedDate;
                mainMaster.SR_Details.MUserID = mainMaster.PE_Master.UserID;
            }
            else
            {
                mainMaster.SR_Details.UserID = mainMaster.PE_Master.UserID;
                mainMaster.SR_Details.DateCreated = NullDate; //done to match pattern
            }
            mainMaster.SR_Details.GetGridViewData = ProddataGridView;
            if (ToPerform == "Update" || ToPerform == "Delete") mainMaster.SR_Details.updateGetGridViewData = UpdateProddataGridViewData;
            return mainMaster.GetSalesReturnSetup();
        }

        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                //checkProduct();
                if (ToPerform is null) return;
                if (ToPerform is "Delete" && isDeleted == true)
                {
                    MessageBox.Show("This bill is already deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                msg = ToPerform == "Insert" ? "Save" : ToPerform;
                //progress bar implememtation starts


                //Total_click(sender, e); cannot run here now make sure all transection correct before saving
                if (FormIsOK())
                {
                    PleaseWait.Show();
                    if (SalesReturnEntrySave() != 0)
                    {
                        //chkQuantity();
                        PleaseWait.Close();
                        MessageBox.Show($@"{msg}d Sucessfully...!!!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frm_SalesReturn_Load(sender, e);
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
            Btn_Ok.Text = "&Update";
            FormStatus(false, true);
            UpdateDataGrid();
            UpdateProddataGridViewData.Visible = true;
            txtVoucherNum.Focus();;
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            ToPerform = "Delete";
            Btn_Ok.Text = "&Delete";
            UpdateProddataGridViewData.Visible = false;
            ProddataGridView.Enabled = false;
            TxtPersonName.Enabled = txtVoucherNum.Enabled = Btn_CustoSearch.Enabled = true;
            btn_Product_Search.Enabled = Btn_Ok.Enabled = true;
        }

        #region ------------------------Methods----------------------------
        protected void VoucherNumber()
        {
            if (ToPerform == "Insert")
            {
                VoucherNum = ClsMainMaster.getInt("MSM.SalesReturnMaster", "SRID");
                if (VoucherNum.ToString().Length == 1) txtVoucherNum.Text = "SR-" + $"{Global.Year}" + "-" + "00" + VoucherNum;
                else if (VoucherNum.ToString().Length == 2) txtVoucherNum.Text = "SR-" + $"{Global.Year}" + "-" + "0" + VoucherNum;
                else txtVoucherNum.Text = "SR-" + $"{Global.Year}" + "-" + VoucherNum;
            }
        }
        private void FormStatus(bool btn, bool txt)
        {
            btn_New.Enabled = btn_Edit.Enabled = btn_Delete.Enabled = btn;
            //buttons bellow will enable with the text enable
            txtVoucherNum.Enabled = English_dateTimePicker.Enabled = txtMiti.Enabled = TxtPersonName.Enabled = txtCompanyName.Enabled = txtCompanyAddress.Enabled = txtCompanyContactNum.Enabled = cmbTransection.Enabled = txtProductName.Enabled = txt_Quantity.Enabled = txtUnit.Enabled = txt_PurchasePrice.Enabled = txt_ProductDisc.Enabled = txt_Note.Enabled = txtDiscount.Enabled = txtVAT.Enabled = txt;
            txtSalesVoucherNum.Enabled = btnSalesBillSearch.Enabled = btn_PR_VoucherSearch.Enabled = ProddataGridView.Enabled =  Btn_Ok.Enabled = btn_ProductClear.Enabled = Btn_Product_Insert.Enabled = Btn_CustoSearch.Enabled = btn_Product_Search.Enabled = btn_Recalculate.Enabled = txt;
        }
        private void GetMiti()
        {
            txtMiti.Text = mainMaster.GetMiti(English_dateTimePicker.Text);
        }
        public void ConfigInitials()
        {
            var Configdt = mainMaster.checkConfig();
            var VAT = decimal.Parse(Configdt.Rows[0]["VAT"].ToString());
            txtVAT.Text = VAT == 0 ? "0.00" : VAT.ToString("##.##########");
            var Discount = decimal.Parse(Configdt.Rows[0]["Discount"].ToString());
            txtDiscount.Text = Discount == 0 ? "0.00" : Discount.ToString("##.##########");
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
            ProddataGridView.ColumnCount = 12;
            ProddataGridView.Columns[0].Name = "SNO";
            ProddataGridView.Columns[1].Name = "PID";
            ProddataGridView.Columns[2].Name = "Product";
            ProddataGridView.Columns[3].Name = "Quantity";
            ProddataGridView.Columns[4].Name = "Unit";
            ProddataGridView.Columns[5].Name = "s. Price";
            ProddataGridView.Columns[6].Name = "s. Disc";
            ProddataGridView.Columns[7].Name = "s. Disc Amt";
            ProddataGridView.Columns[8].Name = "Total";
            ProddataGridView.Columns[9].Name = "S.Note";
            ProddataGridView.Columns[10].Name = "Short Name";
            ProddataGridView.Columns[11].Name = "BarCode";
            //Autosize
            ProddataGridView.Columns[0].Width = 40;
            ProddataGridView.Columns[1].Width = 40;
            ProddataGridView.Columns[2].Width = 200;
            ProddataGridView.Columns[3].Width = 60;
            ProddataGridView.Columns[4].Width = 70;
            ProddataGridView.Columns[5].Width = 100;
            ProddataGridView.Columns[6].Width = 70;
            ProddataGridView.Columns[7].Width = 100;
            ProddataGridView.Columns[8].Width = 100;
            ProddataGridView.Columns[9].Visible = false;
            ProddataGridView.Columns[10].Width = 100;
            ProddataGridView.Columns[11].Width = 100;
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

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MouseBtn = 1;
            reloadEventFunction(sender, e);
            MouseBtn = 0;
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
                }
            }
        }
        private void reloadEventFunction(object sender, EventArgs e)
        {
            if (MouseBtn == 1) frm_SalesReturn_Load(sender, e);
            else  // else case is for the button on the form
            {
                if (MessageBox.Show("Are you sure to Refresh...!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                frm_SalesReturn_Load(sender, e);
            }
        }

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

        private void Btn_CustoSearch_Click(object sender, EventArgs e)
        {
            if (ToPerform == "Insert")
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

        private void btn_Product_Search_Click(object sender, EventArgs e)
        {
            var popup = new frm_PopUpSearch(0, string.Empty, Global.InitialCatalogMain, "ProductSelect", 1, string.Empty, 0);
            if (frm_PopUpSearch.dt.Rows.Count > 0)
            {
                popup.ShowDialog();
                if (popup.SelectedRow.Count > 0)
                {
                    ProdID = Int32.Parse(popup.SelectedRow[0]["PID"].ToString());
                    if (ProdID > 0)
                    {
                        var purchasedQuantity = ClsMainMaster.getproductQuantity(SAID, SVNUM, ProdID,"SAID", "SVNUM", "PID", "MSM.SalesDetails");
                        lblOldQuantity.Text = purchasedQuantity == 0 ? "0.00" : purchasedQuantity.ToString("##.##########");

                        //if(enteringWithoutBillDetails == true)
                        //{
                        //    lblAlreadyReturned.Visible = lblAlreadyReturnedAmt.Visible = true;
                        //    var returnedQuantity = ClsMainMaster.getproductQuantity(SRID, SRVNUM, ProdID, "SRID", "SRVNUM", "PID", "MSM.SalesReturnDetails");
                        //    lblAlreadyReturnedAmt.Text = returnedQuantity == 0 ? "0.00" : returnedQuantity.ToString("##.##########");
                        //}
                        //else lblAlreadyReturned.Visible = lblAlreadyReturnedAmt.Visible = false;
                    }
                    txtProductName.Text = popup.SelectedRow[0]["PName"].ToString();
                    lbl_ProductID.Text = ProdID.ToString();
                    lblPShortname.Text = popup.SelectedRow[0]["PCode"].ToString();
                    lbl_Barcode.Text = popup.SelectedRow[0]["PBarcode"].ToString();
                    //var QntiString = popup.SelectedRow[0]["UnitQnty"].ToString();
                    //var Quantity = QntiString == "" ? Decimal.Parse("0") : Decimal.Parse(QntiString);
                    //txt_Quantity.Text = Quantity == 0 ? "0" : Quantity.ToString("##.##########");
                    txt_Quantity.Text = "0.00"; // initial of return quantity
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
        private int checkInventoryErr()
        {
            if (ProdID <= 0) return 1;
            else
            {
                invData = ClsMainMaster.getInvData(ProdID);

                if (Convert.ToDecimal(txt_Quantity.Text.ToString()) > invData)
                {
                    MessageBox.Show("Your selected amount crocess stock linit." + "\n" + $@"Current Quantity {invData} ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return 1;
                }
                else return 0;
            }
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
        private void AddRow(string Sno, string PID, string Pname, string quantity, string unit, string total, string PPrice, string disc, string discAmt, string Pnote, string SName, string Barcode)
        {
            string[] rows = { Sno, PID, Pname, quantity, unit, total, PPrice, disc, discAmt, Pnote, SName, Barcode };
            ProddataGridView.Rows.Add(rows);
        }

        private void Btn_Product_Insert_Click(object sender, EventArgs e)
        {
            //checkProduct();
            if (ProdID == 0 && ProddataGridView.RowCount > 0) txtDiscount.Focus();
            else if (checkInventoryErr() == 1)
            {
                txtProductName.Focus();
                return;
            }
            else
            {
                btn_ChkGrid_Click(sender, e);
                if (DuplicateValue == 0)
                {
                    //txt_Disc_Leave(sender, e);
                    if (IsProductOk())
                    {
                        ProddataGridView.Enabled = true;
                        string Sno = string.Empty;
                        AddRow(Sno, lbl_ProductID.Text, txtProductName.Text, txt_Quantity.Text, txtUnit.Text, txt_PurchasePrice.Text, txt_ProductDisc.Text, lbl_PDiscAmt.Text, lblTotal.Text, txt_Note.Text, lblPShortname.Text, lbl_Barcode.Text);
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

        private void btn_ProductClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to Reload product details.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) ProductEntryClear();
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
            if(ToPerform == "Insert") txt_Note.Clear();
            txtUnit.Clear();
            txt_ProductDisc.Text = "0.00";
            lblToWords.Text = string.Empty;
            DuplicateValue = 0;
            lblTotal.Text = lbldiscamt.Text = lblVatamt.Text = lblBillBDiscount.Text = lblTotalBill.Text = lblTotalAmount.Text = lbl_PDiscAmt.Text = "0.00";
        }

        private void txtUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.F1) btn_Unit_Search_Click(sender, e);
            else if (e.Control is true && e.KeyCode is Keys.N)
            {
                var frm = new frm_Unit(true);
                frm.Show();
                unitID = frm.Unitid;
                txtUnit.Text = frm.UnitCode;
            }
        }
        private void btn_Unit_Search_Click(object sender, EventArgs e)
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

        private void btn_Recalculate_Click(object sender, EventArgs e)
        {
            if (count != 1)
            {
                //var receivedAmt = txtReceivedAmt.Text;
                Total_click(sender, e);
                //txtReceivedAmt.Text = receivedAmt;
                //TotalCalculate();
                count++;
            }
            else Btn_Ok.Focus();
        }

        public void Total_click(object sender, EventArgs e)
        {
            lbldiscamt.Text = lblVatamt.Text = lblToWords.Text = lblBillBDiscount.Text = lblTotalBill.Text = lblTotalAmount.Text = string.Empty;
            lbldiscamt.Text = lblVatamt.Text = lblBillBDiscount.Text = lblTotalBill.Text = lblTotalAmount.Text = "0.00";
            quantity = 0;
            for (int i = 0; i < ProddataGridView.Rows.Count; i++)
            {
                lblTotalAmount.Text = Convert.ToString(double.Parse(lblTotalAmount.Text) + double.Parse(ProddataGridView.Rows[i].Cells[8].Value.ToString()));

                var discamt = Convert.ToDecimal(double.Parse(lblTotalAmount.Text) * (double.Parse(txtDiscount.Text) / 100));
                lbldiscamt.Text = Decimal.Round(discamt, 2).ToString();

                var BillBDiscount = Convert.ToDecimal(double.Parse(lblTotalAmount.Text) - double.Parse(lbldiscamt.Text));
                lblBillBDiscount.Text = Decimal.Round(BillBDiscount, 2).ToString();

                var VatAmt = Convert.ToDecimal(double.Parse(lblBillBDiscount.Text) * (double.Parse(txtVAT.Text) / 100));
                lblVatamt.Text = Decimal.Round(VatAmt, 2).ToString();

                var TotalBill = Convert.ToDecimal(double.Parse(lblBillBDiscount.Text) + double.Parse(lblVatamt.Text));
                lblTotalBill.Text = Decimal.Round(TotalBill, 2).ToString();

                lblReturnAmt.Text = (TotalBill - Convert.ToDecimal(double.Parse(lbl_dueBalance.Text))).ToString();

                ////var totalBillAmt = Convert.ToDecimal(TotalBill);
                //var paidAmount = Convert.ToDecimal(lblPaidAmt.Text);
                //var totalReturn = paidAmount - TotalBill;
                //if (enteringWithoutBillDetails == true) totalReturn = totalReturn * -1;
                ////var dueBal = Convert.ToDecimal(lbl_dueBalance.Text);

                //if (totalReturn < 0 && enteringWithoutBillDetails == false)
                //{
                //    MessageBox.Show("Returning amount cannot cross paying limit.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //    clear();
                //    frm_SalesReturn_Load(sender, e);
                //    return;
                //}
                //else lblReturnAmt.Text = totalReturn.ToString();

                lblToWords.Text = Towords.NumberToWords(double.Parse(lblReturnAmt.Text));
            }
        }

        private void clear()
        {
            loginID = Global.LoginID;
            lbl_Person.Text = Global.UserName;
            lbl_RoleName.Text = $@"({Global.LoginUser})";
            lbl_CompanyName.Text = Global.CompanyName;
            lbl_Address.Text = $@"{Global.Address},{Global.City},{Global.State},{Global.Country}";
            lbl_Phone.Text = Global.Contact;
            lbl_TagStatus.Text = Global.copyrightYear;
            NoteMandatory = Global.checkReturnNote;
            lbl_CompanyName.TextAlign = ContentAlignment.MiddleCenter;
            lbl_Address.TextAlign = ContentAlignment.MiddleCenter;
            lbl_Phone.TextAlign = ContentAlignment.MiddleCenter;
            SRID = SAID = Pid = loginID = CustoID = ProdID = unitID = VoucherNum = senderId = OldCreatorUserID = currentColumn = MouseBtn = DuplicateValue = count = updatedRowVal = 0;
            isDeleted = false;
            fromPrint = false;
            holdStatus = false;
            txtVoucherNum.Clear();
            SRVNUM = SVNUM = "";
            TxtPersonName.Clear();
            txtCompanyName.Clear();
            txtCompanyAddress.Clear();
            txtCompanyContactNum.Clear();
            txtSalesVoucherNum.Clear();
            cmbTransection.Text = "CASH";
            txtProductName.Clear();
            txt_Quantity.Clear();
            txtUnit.Clear();
            txt_PurchasePrice.Clear();
            //txt_RefBillNo.Clear();
            lblAlreadyReturnedAmt.Text = lblAdvanceGiven.Text = lbl_dueBalance.Text = lblReturnAmt.Text = lblPaidAmt.Text = lblOldQuantity.Text = txt_ProductDisc.Text = txt_ProductDisc.Text = lblTotal.Text = lblTotalAmount.Text = lbldiscamt.Text = lblBillBDiscount.Text = lblVatamt.Text = lblTotalBill.Text = lbl_PDiscAmt.Text = "0.00";
            lblToWords.Text = txt_Note.Text = lbl_ProductID.Text = lblPShortname.Text = lbl_Barcode.Text = "";
            ConfigInitials();
            GetMiti();
            ProddataGridView.Rows.Clear();
            UpdateProddataGridViewData.Rows.Clear();
            UpdateProddataGridViewData.Visible = false;
            ProddataGridView.Enabled = true;
            enteringWithoutBillDetails = false;
            lblAlreadyReturned.Visible = lblAlreadyReturnedAmt.Visible = false;
        }

        private void txt_PurchasePrice_Leave(object sender, EventArgs e)
        {
            productTotalCalculate();
        }

        private void txt_ProductDisc_Leave(object sender, EventArgs e)
        {
            productTotalCalculate();
        }
        private void productTotalCalculate()
        {
            if (!string.IsNullOrEmpty(txtProductName.Text) && ProdID != 0)
            {
                var subTotal = Convert.ToDecimal(double.Parse(txt_Quantity.Text) * double.Parse(txt_PurchasePrice.Text));
                var disc = Convert.ToDecimal(double.Parse(txt_ProductDisc.Text.Trim()) / double.Parse("100"));
                var discAmt = subTotal * disc;
                lbl_PDiscAmt.Text = discAmt.ToString();
                var total = subTotal - discAmt;
                lblTotal.Text = Decimal.Round(total, 3).ToString();
            }
        }

        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            Total_click(sender, e);
        }

        private void txtVAT_Leave(object sender, EventArgs e)
        {
            Total_click(sender, e);
        }

        private void TxtPersonName_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxtPersonName.Text.Trim()))
            {
                //ignore
            }
            else
            {
                if (ToPerform != "Insert") txtVoucherNum.Focus();
                else
                {
                    TxtPersonName.Text = "CASH A/C";
                    txtSalesVoucherNum.Focus();
                }
            }
        }

        private void txtMiti_Leave(object sender, EventArgs e)
        {
            GetMiti();
        }

        private void ProddataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            ProddataGridView.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void ProddataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                    if (ProddataGridView.CurrentRow.Cells["Quantity"].Value.ToString() != "")
                    {
                        //var Quantity = double.Parse(ProddataGridView.CurrentRow.Cells["Quantity"].Value.ToString());
                        var Quantity = ClsMainMaster.getproductQuantity(SAID, SVNUM, ProdID, "SAID", "SVNUM", "PID", "MSM.SalesDetails");
                        lblOldQuantity.Text = Quantity == 0 ? "0.00" : Quantity.ToString("##.##########");
                    }
                    else lblOldQuantity.Text = "0.00";

                    txtUnit.Text = ProddataGridView.CurrentRow.Cells["Unit"].Value.ToString();

                    if (ProddataGridView.CurrentRow.Cells["s. Price"].Value.ToString() != "")
                    {
                        var PurchasePrice = double.Parse(ProddataGridView.CurrentRow.Cells["s. Price"].Value.ToString());
                        txt_PurchasePrice.Text = PurchasePrice == 0 ? "0.00" : PurchasePrice.ToString("##.##########");
                    }
                    else txt_PurchasePrice.Text = "0.00";
                    if (ProddataGridView.CurrentRow.Cells["s. Disc"].Value.ToString() != "")
                    {
                        var PriceDiscount = double.Parse(ProddataGridView.CurrentRow.Cells["s. Disc"].Value.ToString());
                        txt_ProductDisc.Text = PriceDiscount == 0 ? "0.00" : PriceDiscount.ToString("##.##########");
                    }
                    else txt_ProductDisc.Text = "0.00";
                    if (ProddataGridView.CurrentRow.Cells["s. Disc Amt"].Value.ToString() != "")
                    {
                        var DiscountAmt = double.Parse(ProddataGridView.CurrentRow.Cells["s. Disc Amt"].Value.ToString());
                        lbl_PDiscAmt.Text = DiscountAmt == 0 ? "0.00" : DiscountAmt.ToString("##.##########");
                    }
                    else lbl_PDiscAmt.Text = "0.00";
                    if (ProddataGridView.CurrentRow.Cells["Total"].Value.ToString() != "")
                    {
                        var Total = double.Parse(ProddataGridView.CurrentRow.Cells["Total"].Value.ToString());
                        lblTotal.Text = Total == 0 ? "0.00" : Total.ToString("##.##########");
                    }
                    else lblTotal.Text = "0.00";
                    var rowIndex = ProddataGridView.CurrentCell.RowIndex;
                    ProddataGridView.Rows.RemoveAt(rowIndex);
                    btn_Product_Search.Enabled = false;
                    ProddataGridView.Enabled = false;
                }
            }
        }

        private void txt_Quantity_Leave(object sender, EventArgs e)
        {
            if (lbl_ProductID.Text != "" && enteringWithoutBillDetails == false)
            {
                var oldQnty = Convert.ToDecimal(lblOldQuantity.Text);
                var newQnty = Convert.ToDecimal(txt_Quantity.Text);
                if (newQnty > oldQnty)
                {
                    MessageBox.Show("return quantity cannot be greater then sold quantity", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txt_Quantity.Text = "0.00";
                    txt_Quantity.Focus();
                    return;
                }
            }


            //if (enteringWithoutBillDetails == true)
            //{
            //    lblAlreadyReturned.Visible = lblAlreadyReturnedAmt.Visible = true;
            //    var oldQnty = Convert.ToDecimal(lblOldQuantity.Text);
            //    var alreadyReturnedQuantity = Convert.ToDecimal(lblAlreadyReturnedAmt.Text);
            //    var activeQnty = oldQnty - alreadyReturnedQuantity;
            //    var newQnty = Convert.ToDecimal(txt_Quantity.Text);
            //    if (newQnty > activeQnty)
            //    {
            //        MessageBox.Show("return quantity cannot be greater then sold quantity", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //        txt_Quantity.Text = "0.00";
            //        txt_Quantity.Focus();
            //        return;
            //    }
            //}

        }

        private void txtSalesVoucherNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.F1 && ToPerform == "Insert") btnSalesBillSearch_Click(sender, e);
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            panel.BackColor = ColorTranslator.FromHtml(Global.BackgroundColor);
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

        private void UpdateProddataGridViewData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            UpdateProddataGridViewData.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void btn_PR_VoucherSearch_Click(object sender, EventArgs e)
        {
            if (ToPerform == "Update" || ToPerform == "Delete")
            {
                //var popup = new frm_PopUpSearch(0, string.Empty, Global.InitialCatalogMain, "CustomerSelect", 1, string.Empty, 0);

                var popup = new frm_PopUpSearch(0, string.Empty, Global.InitialCatalogMain, "SalesReturnEntry", 0, string.Empty, 0);
                if (frm_PopUpSearch.dt.Rows.Count > 0)
                {
                    popup.ShowDialog();
                    if (popup.SelectedRow.Count > 0)
                    {
                        SRID = Int32.Parse(popup.SelectedRow[0]["SRID"].ToString());
                        txtVoucherNum.Text = SRVNUM = popup.SelectedRow[0]["SRVNUM"].ToString();
                        English_dateTimePicker.Value = DateTime.Parse(popup.SelectedRow[0]["Sales_Date"].ToString());
                        txtMiti.Text = popup.SelectedRow[0]["Sales_Miti"].ToString();
                        senderId = Int32.Parse(popup.SelectedRow[0]["SalerID"].ToString()); //sender in purchase entry is receiver here in return entry
                        //CustoID = Int32.Parse(popup.SelectedRow[0]["BuyerID"].ToString());
                        var partyName = popup.SelectedRow[0]["PartyName"].ToString();
                        if (partyName != "CASH A/C")
                        {
                            TxtPersonName.Text = popup.SelectedRow[0]["PartyName"].ToString();
                            txtCompanyName.Text = popup.SelectedRow[0]["PartyCompany"].ToString();
                            txtCompanyAddress.Text = popup.SelectedRow[0]["PartyAddress"].ToString();
                            txtCompanyContactNum.Text = popup.SelectedRow[0]["PartyContact"].ToString();
                        }
                        else TxtPersonName.Text = partyName;

                        SAID = Int32.Parse(popup.SelectedRow[0]["SAID"].ToString());
                        txtSalesVoucherNum.Text = SVNUM =  popup.SelectedRow[0]["SVNUM"].ToString();
                        var previousBalance = Decimal.Parse(popup.SelectedRow[0]["previous_balance"].ToString());
                        lbl_dueBalance.Text = previousBalance == 0 ? "0" : previousBalance.ToString("##.##########");
                        var salesBillAmt = Decimal.Parse(popup.SelectedRow[0]["sales_bill_amt"].ToString());//sales_bill_amt
                        lblPaidAmt.Text = salesBillAmt == 0 ? "0" : salesBillAmt.ToString("##.##########");
                        var returnedAmt = Decimal.Parse(popup.SelectedRow[0]["return_amount"].ToString());
                        lblReturnAmt.Text = returnedAmt == 0 ? "0" : returnedAmt.ToString("##.##########");
                        var advanceGiven = Decimal.Parse(popup.SelectedRow[0]["advance_given"].ToString());
                        lblAdvanceGiven.Text = advanceGiven == 0 ? "0" : advanceGiven.ToString("##.##########");

                        cmbTransection.Text = popup.SelectedRow[0]["TransectionOn"].ToString();

                        lblTotalAmount.Text = Decimal.Parse(popup.SelectedRow[0]["Total"].ToString()).ToString("##.##########");

                        var Dis = Decimal.Parse(popup.SelectedRow[0]["Discount"].ToString());
                        txtDiscount.Text = Dis == 0 ? "0.00" : Dis.ToString("##.##########");
                        lbldiscamt.Text = Decimal.Parse(popup.SelectedRow[0]["DiscAmount"].ToString()).ToString("##.##########"); // Decimal.Parse().ToString("##.##########");
                        lblBillBDiscount.Text = Decimal.Parse(popup.SelectedRow[0]["TotalAmount"].ToString()).ToString("##.##########");
                        //holdStatus = Convert.ToBoolean(popup.SelectedRow[0]["is_hold"]);
                        var Vat = Decimal.Parse(popup.SelectedRow[0]["Vat"].ToString());
                        txtVAT.Text = Vat == 0 ? "0.00" : Vat.ToString("##.##########");
                        lblVatamt.Text = Decimal.Parse(popup.SelectedRow[0]["VatAmt"].ToString()).ToString("##.##########");
                        lblTotalBill.Text = Decimal.Parse(popup.SelectedRow[0]["BillTotal"].ToString()).ToString("##.##########");
                        //var receivedAmt = Decimal.Parse(popup.SelectedRow[0]["receivedAmt"].ToString());
                        //if (receivedAmt > 0) txtReceivedAmt.Text = receivedAmt.ToString("##.##########"); else txtReceivedAmt.Text = "0.00";
                        //start work thinking for due balance
                        //var toPay = Decimal.Parse(popup.SelectedRow[0]["changeGiven"].ToString());
                        //var dueBal = Decimal.Parse(popup.SelectedRow[0]["dueBalance"].ToString());
                        //if (toPay > 0)
                        //{
                        //    lblChange_Bal.Text = "To Pay Amount";
                        //    lbl_dueBalance.Text = toPay.ToString("##.##########");
                        //}
                        //if (dueBal > 0)
                        //{
                        //    lblChange_Bal.Text = "Due Balance";
                        //    lbl_dueBalance.Text = dueBal.ToString("##.##########");
                        //}
                        //var changeBal = Decimal.Parse(popup.SelectedRow[0]["changeGiven"].ToString());
                        //if (changeBal > 0) lbl_ChangeBalAmt.Text = changeBal.ToString("##.##########");
                        //else lbl_ChangeBalAmt.Text = "0.00";
                        lblToWords.Text = popup.SelectedRow[0]["InWords"].ToString();
                        txt_Note.Text = popup.SelectedRow[0]["Note"].ToString();

                        var is_Deleted = popup.SelectedRow[0]["is_Deleted"].ToString();
                        if (is_Deleted == "ACTIVE") isDeleted = false; else isDeleted = true;
                        OldCreatorUserID = Int32.Parse(popup.SelectedRow[0]["UserID"].ToString());
                        OldCreatedDate = Convert.ToDateTime(popup.SelectedRow[0]["DateCreated"].ToString());
                        var ds = mainMaster.GetSalesReturnEntry(SRVNUM);
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
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Quantity"].Value = (decimal.Parse(dgv["Quantiy"].ToString())).ToString("##.##########");
                                if (!fromPrint) UpdateProddataGridViewData.Rows[UpdateProddataGridViewData.RowCount - 1].Cells["Quantity"].Value = decimal.Parse(dgv["Quantiy"].ToString()).ToString("##.##########");
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Unit"].Value = dgv["UnitCode"].ToString();
                                if (!fromPrint) UpdateProddataGridViewData.Rows[UpdateProddataGridViewData.RowCount - 1].Cells["Unit"].Value = dgv["UnitCode"].ToString();
                                var PPrice = decimal.Parse(dgv["PPrice"].ToString()).ToString("##.##########");
                                var pDisc = decimal.Parse(dgv["pDisc"].ToString()).ToString("##.##########");
                                var pamount = decimal.Parse(dgv["pamount"].ToString()).ToString("##.##########");
                                var TotalPrice = decimal.Parse(dgv["TotalPrice"].ToString()).ToString("##.##########");

                                if (PPrice == "") ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["s. Price"].Value = "0.00"; else ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["s. Price"].Value = PPrice;
                                if (pDisc == "") ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["s. Disc"].Value = "0.00"; else ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["s. Disc"].Value = pDisc;
                                if (pamount == "") ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["s. Disc Amt"].Value = "0.00"; else ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["s. Disc Amt"].Value = pamount;
                                if (TotalPrice == "") ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Total"].Value = "0.00"; else ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Total"].Value = TotalPrice;
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Short Name"].Value = dgv["PCode"].ToString();
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["BarCode"].Value = dgv["PBarcode"].ToString();
                                ProddataGridView.CurrentCell = ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells[currentColumn];
                            }
                            ProddataGridView.ClearSelection();
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
                else MessageBox.Show("No data found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
                if (holdStatus) { MessageBox.Show("Hold bills cannot be printed..", "Wait", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
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
            const int increment = 150;
            e.Graphics.DrawString($@"{Global.CompanyName}", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, new Point(425, 40), center);
            e.Graphics.DrawString($@"{Global.Address}, {Global.City}, {Global.State}, {Global.Country}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(425, 60), center);
            e.Graphics.DrawString($@"Comp. Reg:-{Global.Registration}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(425, 75), center);
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new PointF(00.0F, 90.0F), new PointF(850.0F, 90.0F)); //Ref line:- https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics.drawline?view=windowsdesktop-7.0
            e.Graphics.DrawString($@"SL-BILL-No.:- {txtVoucherNum.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X, Y + 10));
            e.Graphics.DrawString($@"Ref Bill No :- {txtSalesVoucherNum.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 450, Y + 40));
            e.Graphics.DrawString($@"Date:- {txtMiti.Text}  ({English_dateTimePicker.Text})", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 450, Y + 10));
            e.Graphics.DrawString($@"Customer Name:- {TxtPersonName.Text}  ({cmbTransection.Text})", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X, Y + 40));
            e.Graphics.DrawString($@"Address:- {txtCompanyAddress.Text}", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(X, Y + 60));
            e.Graphics.DrawString($@"Contact:- {txtCompanyContactNum.Text}", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(X, Y + 80));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new PointF(00.0F, 200.0F), new PointF(850.0F, 200.0F));
            e.Graphics.DrawString($@"SNO.", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X, Y + 105));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new PointF(00.0F, 220.0F), new PointF(850.0F, 220.0F));
            e.Graphics.DrawString($@"Items", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 50, Y + 105));
            e.Graphics.DrawString($@"Quantity", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 250, Y + 105));
            e.Graphics.DrawString($@"M.R.P", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 350, Y + 105));
            e.Graphics.DrawString($@"%", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 450, Y + 105));
            e.Graphics.DrawString($@"S.P", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 520, Y + 105));
            e.Graphics.DrawString($@"Total", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 450 + increment, Y + 105));
            int i = 5;
            int index = 0;
            for (int j = 0; j < ProddataGridView.Rows.Count; j++)
            {
                i = i + 15;
                e.Graphics.DrawString($@"{index += 1}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 8, Y + 105 + i));
                e.Graphics.DrawString($@"{ProddataGridView.Rows[j].Cells[2].Value}", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(X + 50, Y + 105 + i));
                e.Graphics.DrawString($@"{ProddataGridView.Rows[j].Cells[3].Value} {ProddataGridView.Rows[j].Cells[4].Value}", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(X + 252, Y + 105 + i));
                e.Graphics.DrawString($@"{ProddataGridView.Rows[j].Cells[5].Value}/{ProddataGridView.Rows[j].Cells[4].Value}", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(X + 350, Y + 105 + i));
                e.Graphics.DrawString($@"{ProddataGridView.Rows[j].Cells[6].Value}", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(X + 450, Y + 105 + i));
                e.Graphics.DrawString($@"{ProddataGridView.Rows[j].Cells[7].Value}", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(X + 520, Y + 105 + i));
                e.Graphics.DrawString($@"{ProddataGridView.Rows[j].Cells[8].Value}", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(X + 450 + increment, Y + 105 + i));
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

            e.Graphics.DrawString($@"Previous Remainings:- {lbl_dueBalance.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X, Y + 205 + i));
            e.Graphics.DrawString($@"Taken Qnty:- {lblOldQuantity.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X, Y + 225 + i));
            e.Graphics.DrawString($@"Already Returned :- {lblAlreadyReturnedAmt.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X, Y + 245 + i));

            e.Graphics.DrawString($@"Grand Total :- ", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 367 + increment, Y + 185 + i));
            e.Graphics.DrawString($@"{lblTotalBill.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 450 + increment, Y + 185 + i));

            e.Graphics.DrawString($@"Sale Bill Amt :- ", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 362 + increment, Y + 205 + i));
            e.Graphics.DrawString($@"{lblPaidAmt.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 450 + increment, Y + 205 + i));

            e.Graphics.DrawString($@"Advance :- ", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 384 + increment, Y + 225 + i));
            e.Graphics.DrawString($@"{lblAdvanceGiven.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 450 + increment, Y + 225 + i));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new PointF(520.0F, 342.0F + i), new PointF(740.0F, 342.0F + i));
            e.Graphics.DrawString($@"Total Returned :- ", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 351 + increment, Y + 245 + i));
            e.Graphics.DrawString($@"{lblReturnAmt.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 450 + increment, Y + 245 + i));


            e.Graphics.DrawLine(new Pen(Color.Black, 1), new PointF(00.0F, 365.0F + i), new PointF(850.0F, 365.0F + i));
            e.Graphics.DrawString($@"Words :- {lblToWords.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X, Y + 270 + i));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new PointF(00.0F, 385.0F + i), new PointF(850.0F, 385.0F + i));
            e.Graphics.DrawString($@"Note:- {txt_Note.Text.Trim()}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X, Y + 290 + i));
            e.Graphics.DrawString($@"Signature:- {Global.UserName}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X, Y + 310 + i));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new PointF(00.0F, 405.0F + i), new PointF(850.0F, 405.0F + i));
            e.Graphics.DrawString($@"{Global.billMessage}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 250, Y + 310 + i));
            e.Graphics.DrawString($@"{Global.copyrightYear}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 575, Y + 310 + i));
        }

        private void btnSalesBillSearch_Click(object sender, EventArgs e)
        {
            if (ToPerform != "Insert") return;
            var popup = new frm_PopUpSearch(0, string.Empty, Global.InitialCatalogMain, "SalesEntry", showHold, string.Empty, 0); //here status is used to show hold bill
            if (frm_PopUpSearch.dt.Rows.Count > 0)
            {
                popup.ShowDialog();
                if (popup.SelectedRow.Count > 0)
                {
                    var is_Deleted = popup.SelectedRow[0]["is_Deleted"].ToString();
                    if (is_Deleted == "DELETED")
                    {
                        MessageBox.Show("This bill is deleted cannot return", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    var chkHoldBill = Convert.ToBoolean(popup.SelectedRow[0]["is_hold"]);
                    if (chkHoldBill)
                    {
                        MessageBox.Show("This bill is in hold cannot return", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    SAID = Int32.Parse(popup.SelectedRow[0]["SAID"].ToString());
                    txtSalesVoucherNum.Text = SVNUM = popup.SelectedRow[0]["SVNUM"].ToString();
                    var dueBal = Decimal.Parse(popup.SelectedRow[0]["dueBalance"].ToString());
                    if (dueBal > 0)
                    {
                        lblChange_Bal.Text = "Due Balance";
                        lbl_dueBalance.Text = dueBal.ToString("##.##########");
                    }
                    senderId = Int32.Parse(popup.SelectedRow[0]["SalerID"].ToString()); //sender in purchase entry is receiver here in return entry
                    CustoID = Int32.Parse(popup.SelectedRow[0]["BuyerID"].ToString());
                    if (CustoID > 0)
                    {
                        TxtPersonName.Text = popup.SelectedRow[0]["PartyName"].ToString();
                        txtCompanyName.Text = popup.SelectedRow[0]["PartyCompany"].ToString();
                        txtCompanyAddress.Text = popup.SelectedRow[0]["PartyAddress"].ToString();
                        txtCompanyContactNum.Text = popup.SelectedRow[0]["PartyContact"].ToString();
                    }
                    else TxtPersonName.Text = popup.SelectedRow[0]["PartyName"].ToString();
                    cmbTransection.Text = popup.SelectedRow[0]["TransectionOn"].ToString();

                    

                    var Dis = Decimal.Parse(popup.SelectedRow[0]["Discount"].ToString());
                    txtDiscount.Text = Dis == 0 ? "0" : Dis.ToString("##.##########");
                    

                    var Vat = Decimal.Parse(popup.SelectedRow[0]["Vat"].ToString());
                    txtVAT.Text = Vat == 0 ? "0" : Vat.ToString("##.##########");

                    lblPaidAmt.Text = lblTotalBill.Text = Decimal.Parse(popup.SelectedRow[0]["BillTotal"].ToString()).ToString("##.##########");
                    var receivedAmt = Decimal.Parse(popup.SelectedRow[0]["receivedAmt"].ToString());
                    lblAdvanceGiven.Text = receivedAmt == 0 ? "0" : receivedAmt.ToString("##.##########");

                    OldCreatorUserID = Int32.Parse(popup.SelectedRow[0]["UserID"].ToString());
                    OldCreatedDate = Convert.ToDateTime(popup.SelectedRow[0]["DateCreated"].ToString());

                    if (MessageBox.Show("If you want voucher details then click yes.\nElse click No for voucher number only.", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        enteringWithoutBillDetails = true;
                        return;
                    }
                    lblTotalAmount.Text = Decimal.Parse(popup.SelectedRow[0]["Total"].ToString()).ToString("##.##########");
                    lbldiscamt.Text = Decimal.Parse(popup.SelectedRow[0]["DiscAmount"].ToString()).ToString("##.##########"); // Decimal.Parse().ToString("##.##########");
                    lblBillBDiscount.Text = Decimal.Parse(popup.SelectedRow[0]["TotalAmount"].ToString()).ToString("##.##########");
                    lblVatamt.Text = Decimal.Parse(popup.SelectedRow[0]["VatAmt"].ToString()).ToString("##.##########");
                    
                    lblToWords.Text = popup.SelectedRow[0]["InWords"].ToString();
                    var ds = mainMaster.GetSalesEntry(SVNUM);
                    if (ds.Tables.Count > 0)
                    {
                        ProddataGridView.Rows.Clear();
                        if (UpdateProddataGridViewData != null) UpdateProddataGridViewData.Rows.Clear();
                        foreach (DataRow dgv in ds.Tables[0].Rows)
                        {
                            var rows = ProddataGridView.Rows.Count;
                            ProddataGridView.Rows.Add();
                            ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["PID"].Value = dgv["PID"].ToString();
                            ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Product"].Value = dgv["PName"].ToString();
                            ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Quantity"].Value = (decimal.Parse(dgv["Quantiy"].ToString())).ToString("##.##########");
                            ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Unit"].Value = dgv["UnitCode"].ToString();
                            ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["s. Price"].Value = decimal.Parse(dgv["PPrice"].ToString()).ToString("##.##########");
                            ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["s. Disc"].Value = decimal.Parse(dgv["pDisc"].ToString()).ToString("##.##########");
                            ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["s. Disc Amt"].Value = decimal.Parse(dgv["pamount"].ToString()).ToString("##.##########");
                            ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Total"].Value = decimal.Parse(dgv["TotalPrice"].ToString()).ToString("##.##########");
                            ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Short Name"].Value = dgv["PCode"].ToString();
                            ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["BarCode"].Value = dgv["PBarcode"].ToString();
                            ProddataGridView.CurrentCell = ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells[currentColumn];
                        }
                        ProddataGridView.ClearSelection();
                    }
                }
            }
            else MessageBox.Show("No data found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (string.IsNullOrWhiteSpace(TxtPersonName.Text.Trim()))
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
            //if (string.IsNullOrWhiteSpace(txtCompanyAddress.Text.Trim()))
            //{
            //    MessageBox.Show("You must Enter Receiver(Supplier) Address", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    //errorProvider.SetError(txtPaddress, "Please enter Address.");
            //    txtCompanyAddress.Focus();
            //    return false;
            //}
            //if (string.IsNullOrWhiteSpace(txtCompanyContactNum.Text.Trim()))
            //{
            //    MessageBox.Show("You must Enter Receiver(Supplier) Contact ", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    //errorProvider.SetError(txtPContactnum, "Please enter Supplier Contact.");
            //    txtCompanyContactNum.Focus();
            //    return false;
            //}

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
        #endregion
    }
}
