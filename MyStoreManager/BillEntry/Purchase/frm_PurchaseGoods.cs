using MSMControl.Class;
using MSMControl.ClassMiti;
using MSMControl.Connection;
using MSMControl.Interface;
using MyStoreManager.PleaseWaitControl;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStoreManager.BillEntry.Purchase
{
    public partial class frm_PurchaseGoods : Form
    {
        private readonly IMainMaster mainMaster = new ClsMainMaster();
        private readonly INumbetToWords Towords = new ClsNumberToWord();
        //pleaseWaitForm pleaseWait = new pleaseWaitForm();
        private int PEID; //Purchase Enty id
        private int Pid; //PersonID
        private int POID; //Purchase Order id
        private int loginID; //Login id
        private int CustoID; //Customer Id 
        private int ProdID; //Product ID
        private int unitID; //Unit ID
        private int DuplicateValue; //to check duplicate product in grid
        private int count; //count the value in recalculate
        int startPoint = 0; //progress bar value
        private int VoucherNum; //string for voucher number
        private int receiverId;
        private int OldCreatorUserID;
        private int currentColumn;
        private int MouseBtn; //mouse button status holder
        private bool isEnteredByPO; // if bill entery is by purchase order selection
        private bool PO_billStatus;
        private bool is_DeletedValue;
        private string POVNUM; //purchase order voucher number
        private string PVNUM; //purchase voucher number
        private decimal PO_Quantity;
        private decimal quantity;
        private bool NoteMandatory; //saves note while order is updated
        private string orderStatus; //carries order status message
        private bool isDeleted = false;
        private bool fromPrint = false; //carrties printing status

        private int updatedRowVal = 0; // to keep record of the original rows in case of update

        //public DataGridView UpdateProddataGridViewData;

        private DateTime OldCreatedDate;
        private DateTime NullDate; //kept to hold its default value null.
        //private Data checkPE;

        private string ToPerform, msg = string.Empty;

        public String[] oldValue = new String[] { };

        clsPleaseWaitForm PleaseWait = new clsPleaseWaitForm();
        public frm_PurchaseGoods()
        {
            InitializeComponent();
            DataGridColumns();
        }
        #region---------------------------Methods---------------------------
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
            PEID = Pid = POID = loginID = CustoID = ProdID = unitID = VoucherNum = receiverId = OldCreatorUserID = currentColumn = MouseBtn = DuplicateValue = count = updatedRowVal = 0;
            isEnteredByPO = false;
            NoteMandatory = false;
            isDeleted = false;
            fromPrint = false;
            txtVoucherNum.Clear();
            txtPurchaseOrderNum.Clear();
            txtReferenceNum.Clear();
            TxtPersonName.Clear();
            txtCompanyName.Clear();
            txtCompanyAddress.Clear();
            txtCompanyContactNum.Clear();
            cmbTransection.Text = "CASH";
            txtProductName.Clear();
            txt_Quantity.Clear();
            txtUnit.Clear();
            txt_PurchasePrice.Clear();
            txt_RefBillNo.Clear();
            lblTotal.Text = lblTotalAmount.Text = lbldiscamt.Text= lblBillBDiscount.Text= lblVatamt.Text= lblTotalBill.Text="0.00";
            lblToWords.Text = txt_Note.Text = lbl_ProductID.Text= lblPShortname.Text = lbl_Barcode.Text = "";
            ConfigInitials();
            GetMiti();
            ProddataGridView.Rows.Clear();
            UpdateProddataGridViewData.Rows.Clear();
            UpdateProddataGridViewData.Visible = false;
            ProddataGridView.Enabled = true;
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
            if (string.IsNullOrWhiteSpace(TxtPersonName.Text.Trim())) // person name is party name
            {
                MessageBox.Show("You must Enter Supplier Name", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //errorProvider.SetError(TxtPname, "Please enter Supplier name");
                TxtPersonName.Focus();
                return false;
            }
            //if (string.IsNullOrWhiteSpace(txtCompanyName.Text.Trim()))
            //{
            //    MessageBox.Show("You must Enter Supplier Company Name", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    //errorProvider.SetError(txtCname, "Please enter Company name.");
            //    txtCompanyName.Focus();
            //    return false;
            //}
            if (string.IsNullOrWhiteSpace(txtCompanyAddress.Text.Trim()))
            {
                MessageBox.Show("You must Enter Supplier Address", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //errorProvider.SetError(txtPaddress, "Please enter Address.");
                txtCompanyAddress.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCompanyContactNum.Text.Trim()))
            {
                MessageBox.Show("You must Enter Supplier Contact ", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //errorProvider.SetError(txtPContactnum, "Please enter Supplier Contact.");
                txtCompanyContactNum.Focus();
                return false;
            }
            if(string.IsNullOrWhiteSpace(txt_RefBillNo.Text.Trim()))
            {
                MessageBox.Show("You must Enter Refrence Bill Number", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //errorProvider.SetError(txtPContactnum, "Please enter Supplier Contact.");
                txt_RefBillNo.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_RefBillNo.Text.Trim()))
            {
                MessageBox.Show("You must Enter Refrence Bill Number", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //errorProvider.SetError(txtPContactnum, "Please enter Supplier Contact.");
                txt_RefBillNo.Focus();
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
                MessageBox.Show("You must enter the purchase note.", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_Note.Focus();
                return false;
            }

            if(ToPerform is "Update" &&  updatedRowVal != ProddataGridView.RowCount)
            {
                MessageBox.Show("You cannot add/remove item from list in case of update...\nYou can make quantity zero insted of removing...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
                return false;
            }
            else return true;
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

        private void reloadEventFunction(object sender, EventArgs e) 
        {
            if (MouseBtn == 1)
            {
                frm_PurchaseGoods_Load(sender, e);
                //FormStatus(true, false);
            }
            else  // else case is for the button on the form
            {
                if (MessageBox.Show("Are you sure to Refresh...!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                frm_PurchaseGoods_Load(sender, e);
                //FormStatus(true, false);
            }
        }
        private void FormStatus(bool btn, bool txt)
        {
            btn_New.Enabled = btn_Edit.Enabled = btn_Delete.Enabled = btn;
            //buttons bellow will enable with the text enable
            txtVoucherNum.Enabled = English_dateTimePicker.Enabled = txtMiti.Enabled = txt_RefBillNo.Enabled = txtPurchaseOrderNum.Enabled = txtReferenceNum.Enabled = TxtPersonName.Enabled = txtCompanyName.Enabled = txtCompanyAddress.Enabled = txtCompanyContactNum.Enabled = cmbTransection.Enabled = txtProductName.Enabled = txt_Quantity.Enabled = txtUnit.Enabled = txt_PurchasePrice.Enabled = txt_Note.Enabled = txtDiscount.Enabled = txtVAT.Enabled = txt;
            btn_PE_VoucherSearch.Enabled = ProddataGridView.Enabled = Btn_Ok.Enabled = btn_ProductClear.Enabled = Btn_Product_Insert.Enabled = btn_PurchaseOrderSearch.Enabled = Btn_CustoSearch.Enabled = btn_ReferenceNumber.Enabled = btn_Product_Search.Enabled= btn_Recalculate.Enabled = txt;
        }
        protected void VoucherNumber()
        {
            if (ToPerform == "Insert")
            { 
                VoucherNum = ClsMainMaster.getInt("MSM.PurchaseMaster", "PEID");
                if(VoucherNum.ToString().Length == 1) txtVoucherNum.Text = "PG-" + $"{Global.Year}" + "-" + "00" + VoucherNum;
                else if(VoucherNum.ToString().Length == 2) txtVoucherNum.Text = "PG-" + $"{Global.Year}" + "-" + "0" + VoucherNum;
                else txtVoucherNum.Text = "PG-" + $"{Global.Year}" + "-"  + VoucherNum;
            }
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

        public void UpdateDataGrid()
        {
            UpdateProddataGridViewData.ColumnCount = 5;
            UpdateProddataGridViewData.Columns[0].Name = "SNO";
            UpdateProddataGridViewData.Columns[1].Name = "PID";
            UpdateProddataGridViewData.Columns[2].Name = "Product";
            UpdateProddataGridViewData.Columns[3].Name = "Quantity";
            UpdateProddataGridViewData.Columns[4].Name = "Unit";

            UpdateProddataGridViewData.Columns[0].Visible =false;
            UpdateProddataGridViewData.Columns[1].Width = 30;
            UpdateProddataGridViewData.Columns[2].Visible = false;
            UpdateProddataGridViewData.Columns[3].Width = 70;
            UpdateProddataGridViewData.Columns[4].Width = 70;
        }
        public int PurchaseEntrySave()
        {
            mainMaster.PE_Master.ToPerform = ToPerform;
            mainMaster.PE_Master.PEID = ToPerform is "Insert" ? ClsMainMaster.getInt("MSM.PurchaseMaster", "PEID") : PEID;
            mainMaster.PE_Master.PVNUM = txtVoucherNum.Text.Trim().Replace("'", "''");
            mainMaster.PE_Master.Purchase_Date = English_dateTimePicker.Value;
            mainMaster.PE_Master.Purchase_Miti = txtMiti.Text.Trim().Replace("'", "''");
            mainMaster.PE_Master.ref_bill_No = txt_RefBillNo.Text.Trim().Replace("'", "''");
            mainMaster.PE_Master.Purchase_OrderNo = txtPurchaseOrderNum.Text.Trim().Replace("'", "''");
            mainMaster.PE_Master.PO_ReferenceNo = !string.IsNullOrEmpty(txtReferenceNum.Text) ? txtReferenceNum.Text.Trim().Replace("'", "''") : "N/A";
            mainMaster.PE_Master.SenderID = CustoID;
            mainMaster.PE_Master.ReceiverID = (int)Global.CompanyID;
            mainMaster.PE_Master.TransectionOn = cmbTransection.Text.Trim().Replace("'", "''");
            mainMaster.PE_Master.Total = decimal.Parse(lblTotalAmount.Text);
            mainMaster.PE_Master.Discount = decimal.Parse(txtDiscount.Text);
            mainMaster.PE_Master.DiscAmount = decimal.Parse(lbldiscamt.Text);
            mainMaster.PE_Master.TotalAmount = decimal.Parse(lblBillBDiscount.Text);
            mainMaster.PE_Master.Vat = decimal.Parse(txtVAT.Text.Trim().Replace("'", "''"));
            mainMaster.PE_Master.VatAmt = decimal.Parse(lblVatamt.Text);
            mainMaster.PE_Master.BillTotal = decimal.Parse(lblTotalBill.Text);
            mainMaster.PE_Master.InWords = lblToWords.Text;
            mainMaster.PE_Master.Note = txt_Note.Text.Trim().Replace("'", "''");
            mainMaster.PE_Master.PO_Bill_Status = false;
            mainMaster.PE_Master.is_Deleted = isDeleted;
            mainMaster.PE_Master.UserID = Global.LoginID;

            mainMaster.PE_Details.ToPerform = mainMaster.PE_Master.ToPerform;
            mainMaster.PE_Details.PEID = mainMaster.PE_Master.PEID;
            mainMaster.PE_Details.PVNUM = mainMaster.PE_Master.PVNUM;
            //this update values are stored while updating and restoring the values in details table table after delete and re insert in case of update.
            if (ToPerform == "Update")
            {
                mainMaster.PE_Details.UserID = OldCreatorUserID;
                mainMaster.PE_Details.DateCreated = OldCreatedDate;
                mainMaster.PE_Details.MUserID = mainMaster.PE_Master.UserID;
            }
            else
            {
                mainMaster.PE_Details.UserID = mainMaster.PE_Master.UserID;
                mainMaster.PE_Details.DateCreated = NullDate;
            }
            mainMaster.PE_Details.GetGridViewData = ProddataGridView;

            if (ToPerform == "Update" || ToPerform == "Delete") mainMaster.PE_Details.updateGetGridViewData = UpdateProddataGridViewData;

            return mainMaster.GetPurchaseGoodsSetup();
        }

        public void chkQuantity()
        {
            if (!string.IsNullOrEmpty(txtPurchaseOrderNum.Text.Trim()) && POID > 0)
            {
                var dt_master = mainMaster.chk_PO_QuantityMaster(POID); 
                var dt_Details = mainMaster.chk_PE_QuantityDetails(txtPurchaseOrderNum.Text.Trim());

                if (ToPerform != "Delete" && dt_master.Rows.Count > 0 && dt_Details.Rows.Count > 0)
                {
                    var Q_Check1 = !string.IsNullOrEmpty(dt_master.Rows[0]["goods_quantity"].ToString()) ? Convert.ToDecimal(dt_master.Rows[0]["goods_quantity"].ToString()) : 0;
                    var Q_Check2 = !string.IsNullOrEmpty( dt_Details.Rows[0]["Quantiy"].ToString()) ? Convert.ToDecimal(dt_Details.Rows[0]["Quantiy"].ToString()) : 0;
                    if (Q_Check2 == Q_Check1)
                    {
                        var Query = $@"UPDATE MSM.PurchaseOrderMaster SET PO_Bill_Status = 1 WHERE POVNUM = '{txtPurchaseOrderNum.Text.Trim()}'; UPDATE MSM.PurchaseMaster SET PO_Bill_Status = 1 WHERE Purchase_OrderNo = '{txtPurchaseOrderNum.Text.Trim()}';";
                        var exe = Execute.ExecuteNonQueryOnMain(Query);
                        orderStatus = "Your Order status is Completed";
                    }
                    else if (Q_Check2 < Q_Check1)
                    {
                        var Query = $@"UPDATE MSM.PurchaseOrderMaster SET PO_Bill_Status = 0 WHERE POVNUM = '{txtPurchaseOrderNum.Text.Trim()}'; UPDATE MSM.PurchaseMaster SET PO_Bill_Status = 0 , extraNote = '' WHERE Purchase_OrderNo = '{txtPurchaseOrderNum.Text.Trim()}';";
                        var exe = Execute.ExecuteNonQueryOnMain(Query);
                        orderStatus = "Your Order status is Pending";
                    }
                    else if (Q_Check2 > Q_Check1)
                    {
                        if (MessageBox.Show("Your purchase quantity has more value then quotation.\n Is your Order Completely received.", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            var Query = $@"UPDATE MSM.PurchaseOrderMaster SET PO_Bill_Status = 0 WHERE POVNUM = '{txtPurchaseOrderNum.Text.Trim()}'; UPDATE MSM.PurchaseMaster SET PO_Bill_Status = 0 , extraNote = '' WHERE Purchase_OrderNo = '{txtPurchaseOrderNum.Text.Trim()}';";
                            var exe = Execute.ExecuteNonQueryOnMain(Query);
                            orderStatus = "Your Order status is Pending";
                        }
                        else
                        {
                            var Query = $@"UPDATE MSM.PurchaseOrderMaster SET PO_Bill_Status = 1 WHERE POVNUM = '{txtPurchaseOrderNum.Text.Trim()}'; UPDATE MSM.PurchaseMaster SET PO_Bill_Status = 1,extraNote = 'Order completed with extra goods on {DateTime.Now} by {Global.UserName}.' WHERE Purchase_OrderNo = '{txtPurchaseOrderNum.Text.Trim()}';";
                            var exe = Execute.ExecuteNonQueryOnMain(Query);
                            orderStatus = "Your Order status is Completed";
                        }
                    }
                }
                else
                {
                    //MessageBox.Show("Some issue while updating quantity.\nPlease check Quotation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    var Query = $@"UPDATE MSM.PurchaseOrderMaster SET PO_Bill_Status = 0 WHERE POVNUM = '{txtPurchaseOrderNum.Text.Trim()}'; UPDATE MSM.PurchaseOrderDetails SET PO_Bill_Status = 0 WHERE POVNUM = '{txtPurchaseOrderNum.Text.Trim()}';UPDATE MSM.PurchaseMaster SET PO_Bill_Status = 1 , extraNote = 'Bill Cancelled' WHERE Purchase_OrderNo = '{txtPurchaseOrderNum.Text.Trim()}';";
                    var exe = Execute.ExecuteNonQueryOnMain(Query);
                    orderStatus = "Your Current Purchase bill is Cancelled..!!\nYour Quotation status is updated to Pending now.";
                }
            }
        }
        #endregion

        #region---------------------------Events---------------------------
        private void frm_PurchaseGoods_Load(object sender, EventArgs e)
        {
            clear();
            //ProddataGridView.Rows.Clear();
            //DataGridColumns();
            FormStatus(true, false);
        }

        private void English_dateTimePicker_Leave(object sender, EventArgs e)
        {
            if(Global.checkDate)
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

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            panel.BackColor = ColorTranslator.FromHtml(Global.BackgroundColor);
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
            UpdateDataGrid();
            UpdateProddataGridViewData.Visible = false;
            ProddataGridView.Enabled = false;
            TxtPersonName.Enabled = txtVoucherNum.Enabled = Btn_CustoSearch.Enabled = true;
            btn_Product_Search.Enabled = Btn_Ok.Enabled = true;

        }
        private void btn_PurchaseOrderSearch_Click(object sender, EventArgs e)
        {
            if (ToPerform == "Update" || ToPerform == "Delete") return;
            var popup = new frm_PopUpSearch(0, string.Empty, Global.InitialCatalogMain, "PurchaseOrder", 1, string.Empty, 0);
            if (frm_PopUpSearch.dt.Rows.Count > 0)
            {
                popup.ShowDialog();
                if (popup.SelectedRow.Count > 0)
                {
                    POID = Int32.Parse(popup.SelectedRow[0]["POID"].ToString());
                    txtPurchaseOrderNum.Text = POVNUM = popup.SelectedRow[0]["POVNUM"].ToString();
                    English_dateTimePicker.Value = DateTime.Parse(popup.SelectedRow[0]["Order_Date"].ToString());
                    txtMiti.Text = popup.SelectedRow[0]["Order_Miti"].ToString();
                    receiverId = Int32.Parse(popup.SelectedRow[0]["ReceiverID"].ToString());
                    lbl_Person.Text = popup.SelectedRow[0]["usrname"].ToString();
                    lbl_CompanyName.Text = popup.SelectedRow[0]["Dup_cname"].ToString();
                    lbl_Address.Text = popup.SelectedRow[0]["Dup_address"].ToString();
                    lbl_Phone.Text = popup.SelectedRow[0]["Dup_contact"].ToString();
                    CustoID = Int32.Parse(popup.SelectedRow[0]["SenderID"].ToString());
                    TxtPersonName.Text = popup.SelectedRow[0]["PartyName"].ToString();
                    txtCompanyName.Text = popup.SelectedRow[0]["PartyCompany"].ToString();
                    txtCompanyAddress.Text = popup.SelectedRow[0]["PartyAddress"].ToString();
                    txtCompanyContactNum.Text = popup.SelectedRow[0]["PartyContact"].ToString();
                    cmbTransection.Text = popup.SelectedRow[0]["TransectionOn"].ToString();
                    var Vat = Decimal.Parse(popup.SelectedRow[0]["Vat"].ToString());
                    txtVAT.Text = Vat == 0 ? "0" : Vat.ToString("##.##########");
                    var Dis = Decimal.Parse(popup.SelectedRow[0]["Discount"].ToString());
                    txtDiscount.Text = Dis == 0 ? "0" : Dis.ToString("##.##########");
                    OldCreatorUserID = Int32.Parse(popup.SelectedRow[0]["UserID"].ToString());
                    OldCreatedDate = Convert.ToDateTime(popup.SelectedRow[0]["DateCreated"].ToString());

                    var checkPE = mainMaster.CheckPurchaseEntryDetails(POVNUM);
                    ProddataGridView.Rows.Clear();
                    if (checkPE.Rows.Count == 0)
                    {
                        var ds = mainMaster.GetPurchaseOrderDetails(POVNUM);
                        if (ds.Tables.Count > 0)
                        {
                            
                            foreach (DataRow dgv in ds.Tables[0].Rows)
                            {
                                var rows = ProddataGridView.Rows.Count;
                                ProddataGridView.Rows.Add();
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["PID"].Value = dgv["PID"].ToString();
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Product"].Value = dgv["PName"].ToString();
                                var qnty = Decimal.Parse(dgv["Quantiy"].ToString());
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Quantity"].Value = qnty == 0 ? "0.00" : qnty.ToString("##.##########");
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Unit"].Value = dgv["UnitCode"].ToString();
                                var pPrice = Decimal.Parse(dgv["PPrice"].ToString());
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["P. Price"].Value = pPrice == 0 ? "0.00" : pPrice.ToString("##.##########");
                                var totalPrice = Decimal.Parse(dgv["TotalPrice"].ToString());
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Total"].Value = totalPrice == 0 ? "0.00" : totalPrice.ToString("##.##########");
                                //ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["P.Note"].Value = dgv["PNote"].ToString();
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Short Name"].Value = dgv["PCode"].ToString();
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["BarCode"].Value = dgv["PBarcode"].ToString();
                                ProddataGridView.CurrentCell = ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells[currentColumn];
                            }
                        }
                    }
                    ProddataGridView.ClearSelection();
                    _ = isEnteredByPO = true;
                    txtPurchaseOrderNum.Focus();
                }   
                    
            }
            
        }

        private void btn_ReferenceNumber_Click(object sender, EventArgs e)
        {
            if (ToPerform == "Delete") return;
            var popup = new frm_PopUpSearch(0, string.Empty, Global.InitialCatalogMain, "RefrenceNumber", 0, txtPurchaseOrderNum.Text, 0);
            if (frm_PopUpSearch.dt.Rows.Count > 0)
            {
                popup.ShowDialog();
                if (popup.SelectedRow.Count > 0)
                {
                    txtReferenceNum.Text = popup.SelectedRow[0]["PVNUM"].ToString();
                }
                else txtReferenceNum.Clear();
            }
            else
            {
                MessageBox.Show("No Data", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtReferenceNum.Clear();
            }
            txtReferenceNum.Focus();
        }
        private void txtReferenceNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.F1 && ToPerform != "Delete") btn_ReferenceNumber.PerformClick();
        }
        private void txtPurchaseOrderNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.F1 && ToPerform == "Insert") btn_PurchaseOrderSearch.PerformClick();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MouseBtn = 1;
            reloadEventFunction(sender, e);
            MouseBtn = 0;
        }

        private void Btn_CustoSearch_Click(object sender, EventArgs e)
        {
            if (isEnteredByPO == true)
            {
                MessageBox.Show("Selection By purchase order doesnot allow to change this selection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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
                }
            }
            else
            {
                MessageBox.Show("No Data..!!", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            TxtPersonName.Focus();
        }

        private void btn_Product_Search_Click(object sender, EventArgs e)
        {
            var popup = new frm_PopUpSearch( 0, string.Empty, Global.InitialCatalogMain, "ProductSelect", 1, string.Empty, 0);
            if (frm_PopUpSearch.dt.Rows.Count > 0)
            {
                popup.ShowDialog();
                if (popup.SelectedRow.Count > 0)
                {
                    ProdID = Int32.Parse(popup.SelectedRow[0]["PID"].ToString());
                    txtProductName.Text = popup.SelectedRow[0]["PName"].ToString();
                    lbl_ProductID.Text = ProdID.ToString();
                    lblPShortname.Text  = popup.SelectedRow[0]["PCode"].ToString();
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

        private void btn_Unit_Search_Click(object sender, EventArgs e)
        {
            var popup = new frm_PopUpSearch(0, string.Empty, Global.InitialCatalogMain, "GetUnit", 1, string.Empty, 0);
            if (frm_PopUpSearch.dt.Rows.Count > 0)
            {
                popup.ShowDialog();
                if (popup.SelectedRow.Count > 0)
                {
                    unitID = int.Parse(popup.SelectedRow[0]["UnitID"].ToString());
                    txtUnit.Text = popup.SelectedRow[0]["UnitCode"].ToString();
                }
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
                txtUnit.Text = frm.UnitCode;
            }
        }
       
        private void txt_PurchasePrice_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProductName.Text))
            {
                var Total = Convert.ToDecimal(double.Parse(txt_Quantity.Text) * double.Parse(txt_PurchasePrice.Text));
                lblTotal.Text = Decimal.Round(Total, 3).ToString();
            }
        }
        #endregion

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
        private void Btn_Product_Insert_Click(object sender, EventArgs e)
        {
            if (isEnteredByPO == true && string.IsNullOrEmpty(txt_RefBillNo.Text))
            {
                MessageBox.Show("You are about to edit purchase order entry.\nPlease enter Reference number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_RefBillNo.Focus();
                return;
            }
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

        private void btn_ProductClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to Reload product details.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) ProductEntryClear();
        }
        private void ProddataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isEnteredByPO == true)
            {
                if (MessageBox.Show("You are about to make changes in Purchase Order selection. \nSure to select.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            }
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
                    //txt_Note.Text = ProddataGridView.CurrentRow.Cells["P.Note"].Value.ToString();
                    var rowIndex = ProddataGridView.CurrentCell.RowIndex;
                    ProddataGridView.Rows.RemoveAt(rowIndex);
                    btn_Product_Search.Enabled = false;
                    ProddataGridView.Enabled = false;
                }
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

        private void btn_Recalculate_Click(object sender, EventArgs e)
        {
            if (count != 1)
            {
                Total_click(sender, e);
                count++;
            }
            else Btn_Ok.Focus();
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
        private void txtVAT_Leave(object sender, EventArgs e)
        {
            Total_click(sender, e);
        }
        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            Total_click(sender, e);
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

        private void btn_PE_VoucherSearch_Click(object sender, EventArgs e)
        {
            if(ToPerform == "Update" || ToPerform == "Delete")
            {
                var popup = new frm_PopUpSearch(0, string.Empty, Global.InitialCatalogMain, "PurchaseEntry", 0, string.Empty, 0);
                if (frm_PopUpSearch.dt.Rows.Count > 0)
                {
                    popup.ShowDialog();
                    if (popup.SelectedRow.Count > 0)
                    {
                        
                        PEID = Int32.Parse(popup.SelectedRow[0]["PEID"].ToString());
                        POID = popup.SelectedRow[0]["POID"].ToString() != "" ?  Int32.Parse(popup.SelectedRow[0]["POID"].ToString()) : 0;
                        txtVoucherNum.Text = PVNUM = popup.SelectedRow[0]["PVNUM"].ToString();
                        txtPurchaseOrderNum.Text = popup.SelectedRow[0]["Purchase_OrderNo"].ToString();
                        English_dateTimePicker.Value = DateTime.Parse(popup.SelectedRow[0]["Purchase_Date"].ToString());
                        txt_RefBillNo.Text = popup.SelectedRow[0]["ref_bill_No"].ToString();
                        txtMiti.Text = popup.SelectedRow[0]["Purchase_Miti"].ToString();
                        receiverId = Int32.Parse(popup.SelectedRow[0]["ReceiverID"].ToString());
                        txtReferenceNum.Text = popup.SelectedRow[0]["PO_ReferenceNo"].ToString();
                        CustoID = Int32.Parse(popup.SelectedRow[0]["SenderID"].ToString());
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
                        var ds = mainMaster.GetPurchaseEntryDetails(PVNUM);
                        if (ds.Tables.Count > 0)
                        {
                            ProddataGridView.Rows.Clear();
                            if (UpdateProddataGridViewData != null) UpdateProddataGridViewData.Rows.Clear();
                            foreach (DataRow dgv in ds.Tables[0].Rows)
                            {
                                var rows = ProddataGridView.Rows.Count;
                                ProddataGridView.Rows.Add();
                                if(!fromPrint) UpdateProddataGridViewData.Rows.Add();
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["PID"].Value = dgv["PID"].ToString();
                                if (!fromPrint) UpdateProddataGridViewData.Rows[UpdateProddataGridViewData.RowCount - 1].Cells["PID"].Value = dgv["PID"].ToString();
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Product"].Value = dgv["PName"].ToString();
                                if (!fromPrint) UpdateProddataGridViewData.Rows[UpdateProddataGridViewData.RowCount - 1].Cells["Product"].Value = dgv["PName"].ToString();
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Quantity"].Value = decimal.Parse(dgv["Quantiy"].ToString()).ToString("##.##########");
                                if (!fromPrint) UpdateProddataGridViewData.Rows[UpdateProddataGridViewData.RowCount - 1].Cells["Quantity"].Value = decimal.Parse(dgv["Quantiy"].ToString()).ToString("##.##########");
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
                            if(ToPerform == "Delete")
                            {
                                FormStatus(false, false);
                                Btn_Ok.Enabled = true;Btn_Ok.Focus();
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

        private void txtVoucherNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtVoucherNum.ReadOnly is true)
            {
                if (e.KeyCode is Keys.F1 && ToPerform is "Update" || ToPerform is "Delete") btn_PE_VoucherSearch.PerformClick();
            }
        }

        private void btn_ViewDetails_Click(object sender, EventArgs e)
        {
            //get all purchase entry details with there quantity received
            if (string.IsNullOrEmpty(txtPurchaseOrderNum.Text) && POID == 0) return;
            var popup = new frm_PopUpSearch(0, "PurchaseDetails", Global.InitialCatalogMain, "GoodsRecivedList",0, txtPurchaseOrderNum.Text, 0);
            popup.ShowDialog();
        }

        private void viewInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var popup = new frm_PopUpSearch(0, "[MSM].[ProductInventory]", Global.InitialCatalogMain, "ProductInventory", 0, string.Empty, 0);
            if (frm_PopUpSearch.dt.Rows.Count > 0) popup.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (txtVoucherNum.Text.Trim() == "")
            {
                ToPerform = "Update";
                fromPrint = true;
                btn_PE_VoucherSearch_Click(sender, e);
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
            e.Graphics.DrawString($@"PG-BILL-No.:- {txtVoucherNum.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X, Y + 10));
            e.Graphics.DrawString($@"Date:- {txtMiti.Text}  ({English_dateTimePicker.Text})", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 450, Y + 10));
            e.Graphics.DrawString($@"PO Num:- {txtPurchaseOrderNum.Text}", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(X + 450, Y + 40));
            e.Graphics.DrawString($@"Ref. Bill Num:- {txtReferenceNum.Text}", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(X + 450, Y + 60));
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
                //e.Graphics.DrawString($@"{ProddataGridView.Rows[j].Cells[7].Value}", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(X + 550, Y + 105 + i));
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



        //private void poDiffrence_Chk()
        //{
        //    if (!string.IsNullOrEmpty(POVNUM) && POID > 0)
        //    {
        //        if (quantity < PO_Quantity) PO_billStatus = false;
        //        else if (quantity == PO_Quantity) PO_billStatus = true;
        //        else if (quantity > PO_Quantity)
        //        {
        //            if (MessageBox.Show("Goods recived Is more than the value quantity.", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) NoteMandatory = PO_billStatus = true;
        //            else PO_billStatus = false;
        //        }
        //    }
        //}

        //private void checkProduct()
        //{
        //    for (int i = 0; i < UpdateProddataGridViewData.Rows.Count; i++)
        //    {
        //        var oldData = UpdateProddataGridViewData.Rows[i].Cells[1].Value.ToString().Trim();
        //        for (int j = 0; j < ProddataGridView.Rows.Count; j++)
        //        {
        //            var newData = ProddataGridView.Rows[j].Cells[1].Value.ToString().Trim();
        //            try
        //            {
        //                if (newData == oldData) break;
        //            }
        //            catch
        //            {
        //                MessageBox.Show("Your current products are diffrent from previous \n Not allowed", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //                return;
        //            }

        //        }
        //    }


        //    //String[] prodIdList = new String[] { ProddataGridView.Rows[1].Cells[1].Value.ToString().Trim() };

        //    //String[] prodIdList = new String[ProddataGridView.Rows.Count];
        //    //var pid = 0;
        //    //foreach (DataGridViewColumn dr in ProddataGridView.Columns)
        //    //{
        //    //    prodIdList[dr.Index] = ProddataGridView.Rows[1].Cells[1].Value.ToString().Trim();
        //    //    Console.WriteLine(dr.Index);
        //    //}

        //    //List<MyObject> myList = new List<MyObject>();
        //    //myList.Add(new MyObject(1, "Tables"));

        //    //var prodIdList = new List<>(ProddataGridView.Rows[1].Cells[1].Value.ToString().Trim());

        //    //for (int i = 0; i < ProddataGridView.Rows.Count; i++)
        //    //{
        //    //    String[] prodIdList = new String[] { ProddataGridView.Rows[1].Cells[1].Value.ToString().Trim() };
        //    //    //prodIdList[pid] = ProddataGridView.Rows[i].Cells[1].Value.ToString().Trim();
        //    //    Console.WriteLine(prodIdList);
        //    //}
        //}

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
                //These three must be in sequence.
                //if (chkQuantity() != 1) return; // this must run before total.
                Total_click(sender, e);
                
                if (FormIsOK())
                {
                    PleaseWait.Show();
                    if (PurchaseEntrySave() != 0)
                    {
                        chkQuantity();
                        PleaseWait.Close();
                        MessageBox.Show($@"{msg}d Sucessfully...!!!"+ "\n" + $@"{orderStatus}", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frm_PurchaseGoods_Load(sender, e);
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
