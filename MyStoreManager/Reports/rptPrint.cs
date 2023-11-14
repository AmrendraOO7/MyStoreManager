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

namespace MyStoreManager.Reports
{
    public partial class rptPrint : Form
    {
        private readonly IMainMaster mainMaster = new ClsMainMaster();
        private readonly INumbetToWords Towords = new ClsNumberToWord();
        public string voucherNo = string.Empty;
        public string voucherType = string.Empty;
        public int POID, SAID, PEID, PRID;
        private int currentColumn;
        public string POVNUM, PVNUM, SVNUM;
        private int MouseBtn; //mouse button status holder
        public rptPrint(string vno, string voucher )
        {
            InitializeComponent();
            voucherNo = vno;
            if (voucher == string.Empty) voucherType = "PurchaseOrder";
            else voucherType = voucher;
            //voucher = ""  ? voucherType == "PurchaseOrder" : voucherType == voucher;
            DataGridColumns();
        }
        private void clear()
        {
            POID = SAID = PEID = PRID = 0;
            //txt_voucherNumber.Clear();
            txt_voucherNumber.Text = "Press F1 here";
            POVNUM = PVNUM = SVNUM = string.Empty;

            txtPrintDate.Text = DateTime.Now.ToString("M/d/yyyy");
            txtMiti.Text = "";

            lbl_Operator.Text = "";
            lbl_CompanyName.Text = "";
            lbl_Address.Text = "";
            lbl_Phone.Text = "";
            lbl_CurrentTotal.Text = "";

            TxtPname.Text = "";
            txtCname.Text = "";
            txtPaddress.Text = "";
            txtPContactnum.Text = "";
            TxtTransection.Text = "";

            lbl_VatPC.Text = "";
            lbl_VAT_Amt.Text = "";
            lbl_DiscountPC.Text = "";
            lbl_discount_Amt.Text = "";
            lbl_Total.Text = "";
            lbl_Words.Text = "";
            lblChange_Bal.Text = "0.00";
            lbl_CompanyName.Text = Global.CompanyName;
            lbl_Address.Text = Global.Address;
            lbl_Phone.Text = Global.Contact;

            lblReceivedAmt.Visible = receivedLbl.Visible = false;
            lblChange_Bal.Visible = lbl_text.Visible = false;

            POText.Visible = lbl_PONumber.Visible = false;
            refText.Visible = lbl_refNumber.Visible = false;
            PO_ReferenceNoText.Visible = PO_ReferenceNo.Visible = false;
            //ProddataGridView.Enabled = true;
            ProddataGridView.Columns.Clear();
            ProddataGridView.Rows.Clear();
            //if (voucherNo != string.Empty)
            //{
            //    txt_voucherNumber.Text = voucherNo = "";
            //    voucherType = "PurchaseOrder";
            //    txt_voucherNumber.Enabled = false;
            //}
            //else
            //{
            //    txt_voucherNumber.Enabled = true;
            //    voucherType = voucherNo = string.Empty;

            //}
        }

        public void DataGridColumns()
        {
            if(cmd_VoucherType.SelectedIndex == 0 || cmd_VoucherType.SelectedIndex == 1 || cmd_VoucherType.SelectedIndex == 2)
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
                ProddataGridView.Columns[1].Visible = false;
                ProddataGridView.Columns[2].Width = 200;
                ProddataGridView.Columns[3].Width = 100;
                ProddataGridView.Columns[4].Width = 100;
                ProddataGridView.Columns[5].Width = 100;
                ProddataGridView.Columns[6].Width = 100;
                if (voucherType == "PurchaseOrder") ProddataGridView.Columns[7].Width = 100;
                else if (voucherType == "PurchaseEntry" || voucherType == "PurchaseReturnEntry") ProddataGridView.Columns[7].Visible = false;
                ProddataGridView.Columns[8].Width = 100;
                ProddataGridView.Columns[9].Width = 100;
            }
            else if(cmd_VoucherType.SelectedIndex == 3 || cmd_VoucherType.SelectedIndex == 4)
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
                ProddataGridView.Columns[9].Name = "Note";
                ProddataGridView.Columns[10].Name = "Short Name";
                ProddataGridView.Columns[11].Name = "BarCode";
                //Autosize
                ProddataGridView.Columns[0].Width = 40;
                ProddataGridView.Columns[1].Visible = false;
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
            else 
            { 
                //ignore
            }
        }

        private void rptPurchaseOrder_Load(object sender, EventArgs e)
        {
            lbl_formName.Text = "Purchase Order Print";
            lbl_voucherForm.Text = "PO_Voucher No:-";
            clear();
            valueOnSelect();
            cmd_VoucherType.SelectedIndex = 0;
            cmd_VoucherType.Focus();
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            panel.BackColor = ColorTranslator.FromHtml(Global.BackgroundColor);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MouseBtn = 1;
            reloadEventFunction(sender, e);
            MouseBtn = 0;
        }

        private void viewInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var popup = new frm_PopUpSearch(0, string.Empty, Global.InitialCatalogMain, "ProductInventory", 0, string.Empty, 0);
            if (frm_PopUpSearch.dt.Rows.Count > 0) popup.ShowDialog();
        }

        private void reloadEventFunction(object sender, EventArgs e)
        {
            if (MouseBtn == 1)
            {
                clear();
                //frmOrderCard_Load(sender, e);
                //FormStatus(true, false);
            }
            else  // else case is for the button on the form
            {
                if (MessageBox.Show("Are you sure to Refresh...!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                clear();
                //frmOrderCard_Load(sender, e);
                //FormStatus(true, false);
            }
        }



        private void valueOnSelect()
        {
            clear();
            if (cmd_VoucherType.Text == "Purchase Order") 
            {
                lbl_formName.Text = "Purchase Order Print";
                voucherType = "PurchaseOrder";
                grpBillMaster.Text = "Quotation Customer Details";
                lbl_voucherForm.Text = "PO_Voucher No:-"; 
            }
            else if (cmd_VoucherType.Text == "Purchase Entry") 
            {
                lbl_formName.Text = "Purchase Entry Print";
                voucherType = "PurchaseEntry";
                grpBillMaster.Text = "Purchase Customer Details";
                lbl_voucherForm.Text = "PE_Voucher No:-";

                POText.Visible = lbl_PONumber.Visible = true;
                lbl_PONumber.Text = "";

                refText.Visible = lbl_refNumber.Visible = true;
                lbl_refNumber.Text = "";

                PO_ReferenceNoText.Visible = PO_ReferenceNo.Visible = true;
                PO_ReferenceNo.Text = "";
            }
            else if (cmd_VoucherType.Text == "Purchase Return") 
            {
                lbl_formName.Text = "Purchase Return Print";
                voucherType = "PurchaseReturnEntry";
                grpBillMaster.Text = "Receiver Customer Details";
                lbl_voucherForm.Text = "PR_Voucher No:-"; 
            }
            else if(cmd_VoucherType.Text == "Sales Entry")
            {
                lbl_formName.Text = "Sales Entry Print";
                voucherType = "SalesEntry";

                grpBillMaster.Text = "Sales Details";
                lbl_voucherForm.Text = "SE_Voucher No:-";

                lblReceivedAmt.Visible = receivedLbl.Visible = true;
                lblReceivedAmt.Text = "";

                lblChange_Bal.Visible =  lbl_text.Visible = true;
                lblChange_Bal.Text = "0.00";
            }
            else if (cmd_VoucherType.Text == "Sales Return")
            {
                lbl_formName.Text = "Sales Return Print";
                voucherType = "SalesReturn";
                grpBillMaster.Text = "Sales Return Details";
                lbl_voucherForm.Text = "SR_Voucher No:-";
            }
        }

        private void cmd_VoucherType_SelectedIndexChanged(object sender, EventArgs e)
        {
            valueOnSelect();
            DataGridColumns();
        }

        private void txt_voucherNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (voucherType != "")
                {
                    switch (voucherType)
                    {
                        case "PurchaseOrder":
                            {
                                var popup = new frm_PopUpSearch(0, string.Empty, Global.InitialCatalogMain, "PurchaseOrder", 0, string.Empty, 1);
                                if (frm_PopUpSearch.dt.Rows.Count > 0)
                                {
                                    popup.ShowDialog();
                                    if (popup.SelectedRow.Count > 0)
                                    {
                                        POID = Int32.Parse(popup.SelectedRow[0]["POID"].ToString());
                                        txt_voucherNumber.Text = POVNUM = popup.SelectedRow[0]["POVNUM"].ToString();
                                        //txtPrintDate.Text = popup.SelectedRow[0]["Order_Date"].ToString();
                                        txtMiti.Text = popup.SelectedRow[0]["Order_Miti"].ToString();
                                        //OldloginID = Int32.Parse(popup.SelectedRow[0]["ReceiverID"].ToString());
                                        lbl_Operator.Text = popup.SelectedRow[0]["usrname"].ToString();
                                        lbl_CompanyName.Text = popup.SelectedRow[0]["Dup_cname"].ToString();
                                        lbl_Address.Text = popup.SelectedRow[0]["Dup_address"].ToString();
                                        lbl_Phone.Text = popup.SelectedRow[0]["Dup_contact"].ToString();
                                        //CustoID = Int32.Parse(popup.SelectedRow[0]["SenderID"].ToString());
                                        TxtPname.Text = popup.SelectedRow[0]["PartyName"].ToString();
                                        txtCname.Text = popup.SelectedRow[0]["PartyCompany"].ToString();
                                        txtPaddress.Text = popup.SelectedRow[0]["PartyAddress"].ToString();
                                        txtPContactnum.Text = popup.SelectedRow[0]["PartyContact"].ToString();
                                        TxtTransection.Text = popup.SelectedRow[0]["TransectionOn"].ToString();
                                        var curTotal = Decimal.Parse(popup.SelectedRow[0]["Total"].ToString());
                                        lbl_CurrentTotal.Text = curTotal == 0 ? "0" : curTotal.ToString("##.##########");
                                        var Vat = Decimal.Parse(popup.SelectedRow[0]["Vat"].ToString());
                                        lbl_VatPC.Text = Vat == 0 ? "0" + "%" : Vat.ToString("##.##########") + "%";
                                        var VatAmt = Decimal.Parse(popup.SelectedRow[0]["VatAmt"].ToString());
                                        lbl_VAT_Amt.Text = VatAmt == 0 ? "0" : VatAmt.ToString("##.##########");
                                        var Dis = Decimal.Parse(popup.SelectedRow[0]["Discount"].ToString());
                                        lbl_DiscountPC.Text = Dis == 0 ? "0" + "%" : Dis.ToString("##.##########") + "%";
                                        var DisAmt = Decimal.Parse(popup.SelectedRow[0]["DiscAmount"].ToString());
                                        lbl_discount_Amt.Text = DisAmt == 0 ? "0" : DisAmt.ToString("##.##########");
                                        var TotalAmt = Decimal.Parse(popup.SelectedRow[0]["BillTotal"].ToString());
                                        lbl_Total.Text = TotalAmt == 0 ? "0" : TotalAmt.ToString("##.##########");
                                        lbl_Words.Text = popup.SelectedRow[0]["InWords"].ToString();
                                        //OldCreatorUserID = Int32.Parse(popup.SelectedRow[0]["UserID"].ToString());
                                        //OldCreatedDate = Convert.ToDateTime(popup.SelectedRow[0]["DateCreated"].ToString());
                                        //var status = popup.SelectedRow[0]["PO_Bill_Status"].ToString();
                                        //if (status == "PENDING") chk_BillStatus.Checked = false; else chk_BillStatus.Checked = true;
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
                                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Quantity"].Value = dgv["Quantiy"].ToString();
                                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Unit"].Value = dgv["UnitCode"].ToString();
                                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["P. Price"].Value = dgv["PPrice"].ToString();
                                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Total"].Value = dgv["TotalPrice"].ToString();
                                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["P.Note"].Value = dgv["PNote"].ToString();
                                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Short Name"].Value = dgv["PCode"].ToString();
                                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["BarCode"].Value = dgv["PBarcode"].ToString();
                                                ProddataGridView.CurrentCell = ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells[currentColumn];
                                            }
                                            ProddataGridView.ClearSelection();
                                        }
                                    }
                                }
                                break;
                            }
                        case "PurchaseEntry":
                            {
                                var popup = new frm_PopUpSearch(0, string.Empty, Global.InitialCatalogMain, "PurchaseEntry", 0, string.Empty, 0);
                                if (frm_PopUpSearch.dt.Rows.Count > 0)
                                {
                                    popup.ShowDialog();
                                    if (popup.SelectedRow.Count > 0)
                                    {

                                        PEID = Int32.Parse(popup.SelectedRow[0]["PEID"].ToString());
                                        //POID = Int32.Parse(popup.SelectedRow[0]["POID"].ToString());
                                        txt_voucherNumber.Text = PVNUM = popup.SelectedRow[0]["PVNUM"].ToString();
                                        lbl_PONumber.Text = popup.SelectedRow[0]["Purchase_OrderNo"].ToString();
                                        //English_dateTimePicker.Value = DateTime.Parse(popup.SelectedRow[0]["Purchase_Date"].ToString());
                                        lbl_refNumber.Text = popup.SelectedRow[0]["ref_bill_No"].ToString();
                                        txtMiti.Text = popup.SelectedRow[0]["Purchase_Miti"].ToString();
                                        //receiverId = Int32.Parse(popup.SelectedRow[0]["ReceiverID"].ToString());
                                        PO_ReferenceNo.Text = popup.SelectedRow[0]["PO_ReferenceNo"].ToString();
                                        //CustoID = Int32.Parse(popup.SelectedRow[0]["SenderID"].ToString());
                                        TxtPname.Text = popup.SelectedRow[0]["PartyName"].ToString();
                                        txtCname.Text = popup.SelectedRow[0]["PartyCompany"].ToString();
                                        txtPaddress.Text = popup.SelectedRow[0]["PartyAddress"].ToString();
                                        txtPContactnum.Text = popup.SelectedRow[0]["PartyContact"].ToString();
                                        TxtTransection.Text = popup.SelectedRow[0]["TransectionOn"].ToString();
                                        var curTotal = Decimal.Parse(popup.SelectedRow[0]["Total"].ToString());
                                        lbl_CurrentTotal.Text = curTotal == 0 ? "0" : curTotal.ToString("##.##########");
                                        var Vat = Decimal.Parse(popup.SelectedRow[0]["Vat"].ToString());
                                        lbl_VatPC.Text = Vat == 0 ? "0" + "%" : Vat.ToString("##.##########") + "%";
                                        var VatAmt = Decimal.Parse(popup.SelectedRow[0]["VatAmt"].ToString());
                                        lbl_VAT_Amt.Text = VatAmt == 0 ? "0" : VatAmt.ToString("##.##########");
                                        var Dis = Decimal.Parse(popup.SelectedRow[0]["Discount"].ToString());
                                        lbl_DiscountPC.Text = Dis == 0 ? "0" + "%" : Dis.ToString("##.##########") + "%";
                                        var DisAmt = Decimal.Parse(popup.SelectedRow[0]["DiscAmount"].ToString());
                                        lbl_discount_Amt.Text = DisAmt == 0 ? "0" : DisAmt.ToString("##.##########");
                                        var TotalAmt = Decimal.Parse(popup.SelectedRow[0]["BillTotal"].ToString());
                                        lbl_Total.Text = TotalAmt == 0 ? "0" : TotalAmt.ToString("##.##########");
                                        lbl_Words.Text = popup.SelectedRow[0]["InWords"].ToString();
                                        lbl_Operator.Text = popup.SelectedRow[0]["Entered_By"].ToString();
                                        lblNote.Text = popup.SelectedRow[0]["Note"].ToString();
                                        //var Vat = Decimal.Parse(popup.SelectedRow[0]["Vat"].ToString());
                                        //txtVAT.Text = Vat == 0 ? "0" : Vat.ToString("##.##########");
                                        //var Dis = Decimal.Parse(popup.SelectedRow[0]["Discount"].ToString());
                                        //txtDiscount.Text = Dis == 0 ? "0" : Dis.ToString("##.##########");
                                        var ds = mainMaster.GetPurchaseEntryDetails(PVNUM);
                                        if (ds.Tables.Count > 0)
                                        {
                                            ProddataGridView.Rows.Clear();
                                            foreach (DataRow dgv in ds.Tables[0].Rows)
                                            {
                                                var rows = ProddataGridView.Rows.Count;
                                                ProddataGridView.Rows.Add();
                                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["PID"].Value = dgv["PID"].ToString();
                                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Product"].Value = dgv["PName"].ToString();
                                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Quantity"].Value = (decimal.Parse(dgv["Quantiy"].ToString())).ToString("##.##########");
                                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Unit"].Value = dgv["UnitCode"].ToString();
                                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["P. Price"].Value = decimal.Parse(dgv["PPrice"].ToString()).ToString("##.##########");
                                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Total"].Value = decimal.Parse(dgv["TotalPrice"].ToString()).ToString("##.##########");
                                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Short Name"].Value = dgv["PCode"].ToString();
                                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["BarCode"].Value = dgv["PBarcode"].ToString();
                                                ProddataGridView.CurrentCell = ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells[currentColumn];
                                            }
                                            ProddataGridView.ClearSelection();
                                        }
                                    }
                                }
                                break;
                            }
                        case "PurchaseReturnEntry":
                            {
                                var popup = new frm_PopUpSearch(0, string.Empty, Global.InitialCatalogMain, "PurchaseReturnEntry", 0, string.Empty, 0);
                                if (frm_PopUpSearch.dt.Rows.Count > 0)
                                {
                                    popup.ShowDialog();
                                    if (popup.SelectedRow.Count > 0)
                                    {
                                        PRID = Int32.Parse(popup.SelectedRow[0]["PRID"].ToString());
                                        txt_voucherNumber.Text = PVNUM = popup.SelectedRow[0]["PRVNUM"].ToString();
                                        //English_dateTimePicker.Value = DateTime.Parse(popup.SelectedRow[0]["Purchase_Return_Date"].ToString());
                                        txtMiti.Text = popup.SelectedRow[0]["Purchase_Return_Miti"].ToString();
                                        //senderId = Int32.Parse(popup.SelectedRow[0]["SenderID"].ToString()); //sender in purchase entry is receiver here in return entry
                                        //CustoID = Int32.Parse(popup.SelectedRow[0]["ReceiverID"].ToString());
                                        TxtPname.Text = popup.SelectedRow[0]["PartyName"].ToString();
                                        txtCname.Text = popup.SelectedRow[0]["PartyCompany"].ToString();
                                        txtPaddress.Text = popup.SelectedRow[0]["PartyAddress"].ToString();
                                        txtPContactnum.Text = popup.SelectedRow[0]["PartyContact"].ToString();
                                        TxtTransection.Text = popup.SelectedRow[0]["TransectionOn"].ToString();
                                        var curTotal = Decimal.Parse(popup.SelectedRow[0]["Total"].ToString());
                                        lbl_CurrentTotal.Text = curTotal == 0 ? "0" : curTotal.ToString("##.##########");
                                        var Vat = Decimal.Parse(popup.SelectedRow[0]["Vat"].ToString());
                                        lbl_VatPC.Text = Vat == 0 ? "0" + "%" : Vat.ToString("##.##########") + "%";
                                        var VatAmt = Decimal.Parse(popup.SelectedRow[0]["VatAmt"].ToString());
                                        lbl_VAT_Amt.Text = VatAmt == 0 ? "0" : VatAmt.ToString("##.##########");
                                        var Dis = Decimal.Parse(popup.SelectedRow[0]["Discount"].ToString());
                                        lbl_DiscountPC.Text = Dis == 0 ? "0" + "%" : Dis.ToString("##.##########") + "%";
                                        var DisAmt = Decimal.Parse(popup.SelectedRow[0]["DiscAmount"].ToString());
                                        lbl_discount_Amt.Text = DisAmt == 0 ? "0" : DisAmt.ToString("##.##########");
                                        var TotalAmt = Decimal.Parse(popup.SelectedRow[0]["BillTotal"].ToString());
                                        lbl_Total.Text = TotalAmt == 0 ? "0" : TotalAmt.ToString("##.##########");
                                        lbl_Words.Text = popup.SelectedRow[0]["InWords"].ToString();
                                        lbl_Operator.Text = popup.SelectedRow[0]["Entered_By"].ToString();
                                        lblNote.Text = popup.SelectedRow[0]["Note"].ToString();
                                        //var Vat = Decimal.Parse(popup.SelectedRow[0]["Vat"].ToString());
                                        //txtVAT.Text = Vat == 0 ? "0" : Vat.ToString("##.##########");
                                        //var Dis = Decimal.Parse(popup.SelectedRow[0]["Discount"].ToString());
                                        //txtDiscount.Text = Dis == 0 ? "0" : Dis.ToString("##.##########");
                                        //var is_Deleted = popup.SelectedRow[0]["is_Deleted"].ToString();
                                        //if (is_Deleted == "ACTIVE") isDeleted = false; else isDeleted = true;
                                        //OldCreatorUserID = Int32.Parse(popup.SelectedRow[0]["UserID"].ToString());
                                        //OldCreatedDate = Convert.ToDateTime(popup.SelectedRow[0]["DateCreated"].ToString());
                                        var ds = mainMaster.GetPurchaseReturnEntry(PVNUM);
                                        if (ds.Tables.Count > 0)
                                        {
                                            ProddataGridView.Rows.Clear();
                                            //if (UpdateProddataGridViewData != null) UpdateProddataGridViewData.Rows.Clear();
                                            foreach (DataRow dgv in ds.Tables[0].Rows)
                                            {
                                                var rows = ProddataGridView.Rows.Count;
                                                ProddataGridView.Rows.Add();
                                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["PID"].Value = dgv["PID"].ToString();
                                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Product"].Value = dgv["PName"].ToString();
                                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Quantity"].Value = dgv["Quantiy"].ToString();
                                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Unit"].Value = dgv["UnitCode"].ToString();
                                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["P. Price"].Value = dgv["PPrice"].ToString();
                                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Total"].Value = dgv["TotalPrice"].ToString();
                                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Short Name"].Value = dgv["PCode"].ToString();
                                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["BarCode"].Value = dgv["PBarcode"].ToString();
                                                ProddataGridView.CurrentCell = ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells[currentColumn];
                                            }
                                            ProddataGridView.ClearSelection();
                                        }
                                    }
                                }
                                break;
                            }
                        case "SalesEntry":
                            {
                                var popup = new frm_PopUpSearch(0, string.Empty, Global.InitialCatalogMain, "SalesEntry", 0, string.Empty, 1); //here status is used to show hold bill
                                if (frm_PopUpSearch.dt.Rows.Count > 0)
                                {
                                    popup.ShowDialog();
                                    if (popup.SelectedRow.Count > 0)
                                    {
                                        SAID = Int32.Parse(popup.SelectedRow[0]["SAID"].ToString());
                                        txt_voucherNumber.Text = SVNUM = popup.SelectedRow[0]["SVNUM"].ToString();
                                        //English_dateTimePicker.Value = DateTime.Parse(popup.SelectedRow[0]["Sales_Date"].ToString());
                                        txtMiti.Text = popup.SelectedRow[0]["Sales_Miti"].ToString();
                                       
                                        ///lbl_CompanyName.Text = Global.CompanyName;
                                        ///lbl_Address.Text = Global.Address;
                                        ///lbl_Phone.Text =Global.Contact;
                                        //senderId = Int32.Parse(popup.SelectedRow[0]["SalerID"].ToString()); //sender in purchase entry is receiver here in return entry
                                        var CustoID = Int32.Parse(popup.SelectedRow[0]["BuyerID"].ToString());
                                        if (CustoID > 0)
                                        {
                                            TxtPname.Text = popup.SelectedRow[0]["PartyName"].ToString();
                                            txtCname.Text = popup.SelectedRow[0]["PartyCompany"].ToString();
                                            txtPaddress.Text = popup.SelectedRow[0]["PartyAddress"].ToString();
                                            txtPContactnum.Text = popup.SelectedRow[0]["PartyContact"].ToString();
                                        }
                                        else TxtPname.Text = popup.SelectedRow[0]["PartyName"].ToString();

                                        TxtTransection.Text = popup.SelectedRow[0]["TransectionOn"].ToString();

                                        
                                        var curTotal = Decimal.Parse(popup.SelectedRow[0]["Total"].ToString());
                                        lbl_CurrentTotal.Text = curTotal == 0 ? "0" : curTotal.ToString("##.##########");
                                        var Vat = Decimal.Parse(popup.SelectedRow[0]["Vat"].ToString());
                                        lbl_VatPC.Text = Vat == 0 ? "0" + "%" : Vat.ToString("##.##########") + "%";
                                        var VatAmt = Decimal.Parse(popup.SelectedRow[0]["VatAmt"].ToString());
                                        lbl_VAT_Amt.Text = VatAmt == 0 ? "0" : VatAmt.ToString("##.##########");
                                        var Dis = Decimal.Parse(popup.SelectedRow[0]["Discount"].ToString());
                                        lbl_DiscountPC.Text = Dis == 0 ? "0" + "%" : Dis.ToString("##.##########") + "%";
                                        var DisAmt = Decimal.Parse(popup.SelectedRow[0]["DiscAmount"].ToString());
                                        lbl_discount_Amt.Text = DisAmt == 0 ? "0" : DisAmt.ToString("##.##########");
                                        var TotalAmt = Decimal.Parse(popup.SelectedRow[0]["BillTotal"].ToString());
                                        lbl_Total.Text = TotalAmt == 0 ? "0" : TotalAmt.ToString("##.##########");

                                        //chkHoldBill.Checked = Convert.ToBoolean(popup.SelectedRow[0]["is_hold"]);

                                        var receivedAmt = Decimal.Parse(popup.SelectedRow[0]["receivedAmt"].ToString());
                                        if (receivedAmt > 0) lblReceivedAmt.Text = receivedAmt.ToString("##.##########"); else lblReceivedAmt.Text = "0.00";
                                        var toPay = Decimal.Parse(popup.SelectedRow[0]["changeGiven"].ToString());
                                        var dueBal = Decimal.Parse(popup.SelectedRow[0]["dueBalance"].ToString());
                                        if (toPay > 0)
                                        {
                                            lbl_text.Text = "To Pay Amount:-";
                                            lblChange_Bal.Text = toPay.ToString("##.##########");
                                        }
                                        if (dueBal > 0)
                                        {
                                            lbl_text.Text = "Due Balance:-";
                                            lblChange_Bal.Text = dueBal.ToString("##.##########");
                                        }
                                        //var changeBal = Decimal.Parse(popup.SelectedRow[0]["changeGiven"].ToString());
                                        //if (changeBal > 0) lbl_ChangeBalAmt.Text = changeBal.ToString("##.##########");
                                        //else lbl_ChangeBalAmt.Text = "0.00";
                                        lbl_Words.Text = popup.SelectedRow[0]["InWords"].ToString();
                                        lblNote.Text = popup.SelectedRow[0]["Note"].ToString();

                                        //var is_Deleted = popup.SelectedRow[0]["is_Deleted"].ToString();
                                        //if (is_Deleted == "ACTIVE") isDeleted = false; else isDeleted = true;
                                        //OldCreatorUserID = Int32.Parse(popup.SelectedRow[0]["UserID"].ToString());
                                        //OldCreatedDate = Convert.ToDateTime(popup.SelectedRow[0]["DateCreated"].ToString());
                                        lbl_Operator.Text = popup.SelectedRow[0]["Entered_By"].ToString();
                                        var ds = mainMaster.GetSalesEntry(SVNUM);
                                        if (ds.Tables.Count > 0)
                                        {
                                            ProddataGridView.Rows.Clear();
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
                                        }
                                    }
                                }
                                break;
                            }
                            //ProddataGridView.Enabled = false;
                    }
                }
                else MessageBox.Show("Please Select Voucher Type", "Please Choose", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (voucherType != "")
            {
                switch (voucherType)
                {
                    case "PurchaseOrder":
                        {
                            printPreviewDialog.Document = printDocument;
                            DialogResult result = printPreviewDialog.ShowDialog();
                            if (result == DialogResult.OK) printDocument.Print();
                            break;
                        }
                    case "PurchaseEntry":
                        {                            
                            break;
                        }
                    case "PurchaseReturnEntry":
                        {                            
                            break;
                        }
                    case "SalesEntry":
                        {                            
                            break;
                        }
                        //ProddataGridView.Enabled = false;
                }
            }
            else MessageBox.Show("Please Select Voucher Type", "Please Choose", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void POprintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            printDocument.DocumentName = $@"{voucherType}";
            StringFormat center = new StringFormat();
            center.LineAlignment = StringAlignment.Center;
            center.Alignment = StringAlignment.Center;
            const int X = 50, Y = 100;
            e.Graphics.DrawString($@"{Global.CompanyName}", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, new Point(425, 40), center);
            e.Graphics.DrawString($@"{Global.Address}, {Global.City}, {Global.State}, {Global.Country}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(425, 60), center);
            e.Graphics.DrawString($@"Comp. Reg:-{Global.Registration}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(425, 75), center);
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new PointF(00.0F, 90.0F), new PointF(850.0F, 90.0F)); //Ref line:- https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics.drawline?view=windowsdesktop-7.0
            e.Graphics.DrawString($@"PO-BILL-No.:- {txt_voucherNumber.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X, Y + 10));
            //e.Graphics.DrawString($@"Date:- {txtMiti.Text}  ({txtDateTime.Text})", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 450, Y + 10));
            e.Graphics.DrawString($@"Supplier Name:- {txtCname.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X, Y + 40));
            e.Graphics.DrawString($@"Address:- {txtPaddress.Text}", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(X, Y + 60));
            e.Graphics.DrawString($@"Contact:- {txtPContactnum.Text}", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(X, Y + 80));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new PointF(00.0F, 200.0F), new PointF(850.0F, 200.0F));
            e.Graphics.DrawString($@"SNO.", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X, Y + 105));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new PointF(00.0F, 220.0F), new PointF(850.0F, 220.0F));
            e.Graphics.DrawString($@"Items", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 50, Y + 105));
            e.Graphics.DrawString($@"Quantity", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 250, Y + 105));
            e.Graphics.DrawString($@"Price", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 350, Y + 105));
            e.Graphics.DrawString($@"Total", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 450, Y + 105));
            e.Graphics.DrawString($@"Note", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 550, Y + 105));
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
            //e.Graphics.DrawString($@"{lblTotalAmount.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 450, Y + 125 + i));
            e.Graphics.DrawString($@"Discount ", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 340, Y + 145 + i));
            //e.Graphics.DrawString($@"({txtDiscount.Text})%", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 393, Y + 145 + i));
            e.Graphics.DrawString($@" :-", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 433, Y + 145 + i));
            //e.Graphics.DrawString($@"{lbldiscamt.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 450, Y + 145 + i));
            e.Graphics.DrawString($@"VAT", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 370, Y + 165 + i));
            //e.Graphics.DrawString($@"({txtVAT.Text})%", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 393, Y + 165 + i));
            e.Graphics.DrawString($@" :-", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 433, Y + 165 + i));
            //e.Graphics.DrawString($@"{lblVatamt.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 450, Y + 165 + i));
            //e.Graphics.DrawString($@"Discount ({txtDiscount.Text})% :-", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 355, Y + 145 + i));
            //e.Graphics.DrawString($@"{lbldiscamt.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 450, Y + 145 + i));
            //e.Graphics.DrawString($@"VAT ({txtVAT.Text})% :-", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 375, Y + 165 + i));
            //e.Graphics.DrawString($@"{lblVatamt.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 450, Y + 165 + i));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new PointF(380.0F, 282.0F + i), new PointF(600.0F, 282.0F + i));
            e.Graphics.DrawString($@"Grand Total :- ", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 366, Y + 185 + i));
           // e.Graphics.DrawString($@"{lblTotalBill.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 450, Y + 185 + i));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new PointF(00.0F, 300.0F + i), new PointF(850.0F, 300.0F + i));
            //e.Graphics.DrawString($@"Words :- {lblToWords.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X, Y + 205 + i));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new PointF(00.0F, 320.0F + i), new PointF(850.0F, 320.0F + i));
            e.Graphics.DrawString($@"Signature:- {Global.UserName}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X, Y + 225 + i));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new PointF(00.0F, 340.0F + i), new PointF(850.0F, 340.0F + i));
            e.Graphics.DrawString($@"{Global.billMessage}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 250, Y + 225 + i));
            e.Graphics.DrawString($@"{Global.copyrightYear}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 575, Y + 225 + i));
        }

        private void txt_voucherNumber_Enter(object sender, EventArgs e)
        {
            if(txt_voucherNumber.Text == "Press F1 here") txt_voucherNumber.Clear();
        }

        private void txt_voucherNumber_Leave(object sender, EventArgs e)
        {
            if (txt_voucherNumber.Text == "") txt_voucherNumber.Text = "Press F1 here";
            //if (txt_voucherNumber.Text == "Press F1 here" || txt_voucherNumber.Text == string.Empty) ProddataGridView.Enabled = true;
            //else ProddataGridView.Enabled = false;
        }
    }
}
