using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2010.Excel;
using MSMControl.Class;
using MSMControl.Connection;
using MSMControl.Interface;
using MyStoreManager.Setup;
using Stimulsoft.Editor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyStoreManager.Reports
{
    public partial class frm_BulkReport : Form
    {
        private int loginID; //Login id
        private string ToPerform, msg = string.Empty;
        private int MouseBtn; //mouse button status holder
        string fromDate, toDate = string.Empty;
        public string voucherType = string.Empty;
        public string dateType = string.Empty;
        private readonly ClsPopUpSearch reportData = new ClsPopUpSearch();
        private readonly IMainMaster mainMaster = new ClsMainMaster();
        //DataTable dt = new DataTable();
        public frm_BulkReport()
        {
            InitializeComponent();
        }

        private void frm_BulkReport_Load(object sender, EventArgs e)
        {
            clear();
            
        }

        public void DataGridColumns()
        {
            ProddataGridView.Columns.Clear();
            ProddataGridView.DataSource = null;
            if (cmd_VoucherType.Text == "Purchase Order" )
            {
                String[] columnName_ToDisplay = new String[] { "PO VOUCHER", "ORDER DATE", "ORDER MITI", "USER NAME", "COMPANY NAME ", "ADDRESS ", "CONTACT", "PARTY NAME ", "PARTY ADDRESS ", "PARTY CONTACT", "TRANSECTION", "TOTAL", "VAT", "VAT AMT", "SUB AMOUNT", "DISCOUNT", "DISC AMOUNT", "NET TOTAL", "IN WORDS", "GOODS QUANTITY" };
                String[] columnName_True = new String[] { "POVNUM", "Order_Date", "Order_Miti", "usrname", "Dup_cname ", "Dup_address ", "Dup_contact", "PartyName ", "PartyAddress ", "PartyContact", "TransectionOn", "Total", "Vat", "VatAmt", "TotalAmount", "Discount", "DiscAmount", "BillTotal", "InWords", "goods_quantity" };
                int[] colsize = new int[] { 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130 };
                String[] columnName_false = new String[] { "POID", "ReceiverID ", "SenderID ", "PartyCompany", "PO_Bill_Status", "UserID", "DateCreated", "MUserID", "ModifiedDate", "is_Deleted" };
                //Creation of table headder
                for (int i = 0; i < columnName_True.Length && i < colsize.Length; i++) ProddataGridView.Columns($@"{columnName_True[i]}", $@"{columnName_ToDisplay[i]}", $@"{columnName_True[i]}", colsize[i], 0, true);
                for (int i = 0; i < columnName_false.Length; i++) ProddataGridView.Columns($@"{columnName_false[i]}", $@"{columnName_false[i]}", $@"{columnName_false[i]}", 0, 0, false);
                ProddataGridView.AutoGenerateColumns = false;
            }
            else if (cmd_VoucherType.Text == "Purchase Entry")
            {
                String[] columnName_ToDisplay = new String[] { "PV  VOUCHER", "PURCHASE DATE", "PURCHASE MITI", "REF_BILL_NO", "PURCHASE ORDER NO", "PO REFERENCE NO", "PARTY NAME", "PARTY ADDRESS", "PARTY CONTACT", "BUYER NAME", "BUYER ADDRESS", "BUYER CONTACT", "TRANSECTION ON", "TOTAL", "VAT", "VATAMT", "SUB AMOUNT", "DISCOUNT", "DISC AMOUNT", "NET TOTAL", "INWORDS", "NOTE", "PO BILL STATUS", "DELETED", "ENTERED BY", "DATE CREATED", "MODIFIED BY", "MODIFIED DATE" };
                String[] columnName_True = new String[] { "PVNUM", "Purchase_Date", "Purchase_Miti", "ref_bill_No", "Purchase_OrderNo", "PO_ReferenceNo", "PartyName", "PartyAddress", "PartyContact", "Dup_cname", "Dup_address", "Dup_contact", "TransectionOn", "Total", "Vat", "VatAmt", "TotalAmount", "Discount", "DiscAmount", "BillTotal", "InWords", "Note", "PO_Bill_Status", "is_Deleted", "Entered_By", "DateCreated", "Modified_By", "ModifiedDate", };
                int[] colsize = new int[] { 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130 };
                String[] columnName_false = new String[] { "PEID", "POID", "SenderID", "ReceiverID", "UserID", "MUserID", "PartyCompany" };
                //Creation of table headder
                for (int i = 0; i < columnName_True.Length && i < colsize.Length; i++) ProddataGridView.Columns($@"{columnName_True[i]}", $@"{columnName_ToDisplay[i]}", $@"{columnName_True[i]}", colsize[i], 0, true);
                for (int i = 0; i < columnName_false.Length; i++) ProddataGridView.Columns($@"{columnName_false[i]}", $@"{columnName_false[i]}", $@"{columnName_false[i]}", 0, 0, false);
                ProddataGridView.AutoGenerateColumns = false;
            }
            else if (cmd_VoucherType.Text == "Purchase Return")
            {
                String[] columnName_ToDisplay = new String[] { "PR VOUCHER", "RETURN DATE", "RETURN MITI", "BUYER NAME", "BUYER ADDRESS", "BUYER CONTACT", "PARTY NAME", "PARTY COMPANY", "PARTY ADDRESS", "PARTY CONTACT", "TRANSECTION ON", "TOTAL", "VAT", "VATAMT", "TOTAL AMOUNT", "DISCOUNT", "DISC AMOUNT", "BILL TOTAL", "IN WORDS", "NOTE", "DELETED", "ENTERED BY", "DATE CREATED", "MODIFIED BY", "MODIFIED DATE", "EXTRA NOTE" };
                String[] columnName_True = new String[] { "PRVNUM", "Purchase_Return_Date", "Purchase_Return_Miti", "Dup_cname", "Dup_address", "Dup_contact",  "PartyName", "PartyCompany", "PartyAddress", "PartyContact", "TransectionOn", "Total", "Vat", "VatAmt", "TotalAmount", "Discount", "DiscAmount", "BillTotal", "InWords", "Note", "is_Deleted", "Entered_By", "DateCreated", "Modified_By", "ModifiedDate", "extraNote" };
                int[] colsize = new int[] { 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130 };
                String[] columnName_false = new String[] { "PRID", "SenderID", "UserID", "MUserID", "ReceiverID" };
                //Creation of table headder
                for (int i = 0; i < columnName_True.Length && i < colsize.Length; i++) ProddataGridView.Columns($@"{columnName_True[i]}", $@"{columnName_ToDisplay[i]}", $@"{columnName_True[i]}", colsize[i], 0, true);
                for (int i = 0; i < columnName_false.Length; i++) ProddataGridView.Columns($@"{columnName_false[i]}", $@"{columnName_false[i]}", $@"{columnName_false[i]}", 0, 0, false);
                ProddataGridView.AutoGenerateColumns = false;
            }
            else if (cmd_VoucherType.Text == "Sales Entry")
            {
                String[] columnName_ToDisplay = new String[] { "SV VOUCHER", "SALES DATE", "SALES MITI", "SELLER NAME", "SELLER ADDRESS", "SELLER CONTACT", "BUYER NAME", "BUYER COMPANY", "BUYER ADDRESS", "BUYER CONTACT", "TRANSECTION ON", "TOTAL", "VAT", "VAT AMT", "TOTAL AMOUNT", "DISCOUNT", "DISC AMOUNT", "BILL TOTAL", "RECEIVED AMT", "CHANGE GIVEN", "DUE BALANCE", "IN WORDS", "HOLD", "PAID", "COMPLETE PAYMENT", "NOTE", "DELETED", "ENTERED BY", "DATE CREATED", "MODIFIED BY", "MODIFIED DATE", "EXTRA NOTE" };
                String[] columnName_True = new String[] { "SVNUM", "Sales_Date", "Sales_Miti", "Dup_cname", "Dup_address", "Dup_contact", "PartyName", "PartyCompany", "PartyAddress", "PartyContact", "TransectionOn", "Total", "Vat", "VatAmt", "TotalAmount", "Discount", "DiscAmount", "BillTotal", "receivedAmt", "changeGiven", "dueBalance", "InWords", "is_hold", "is_Paid", "is_complete_paid", "Note", "is_Deleted", "Entered_By", "DateCreated", "Modified_By", "ModifiedDate", "extraNote" };
                int[] colsize = new int[] { 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130 };
                String[] columnName_false = new String[] { "SAID", "SalerID", "BuyerID", "UserID", "MUserID" };
                //Creation of table headder
                for (int i = 0; i < columnName_True.Length && i < colsize.Length; i++) ProddataGridView.Columns($@"{columnName_True[i]}", $@"{columnName_ToDisplay[i]}", $@"{columnName_True[i]}", colsize[i], 0, true);
                for (int i = 0; i < columnName_false.Length; i++) ProddataGridView.Columns($@"{columnName_false[i]}", $@"{columnName_false[i]}", $@"{columnName_false[i]}", 0, 0, false);
                ProddataGridView.AutoGenerateColumns = false;
            }
            else if (cmd_VoucherType.Text == "Sales Return")
            {
                String[] columnName_ToDisplay = new String[] { "SR VOUCHER", "RETURN DATE", "RETURN MITI", "SELLER NAME", "SELLER ADDRESS", "SELLER CONTACT", "BUYER NAME", "BUYER COMPANY", "BUYER ADDRESS", "BUYER CONTACT", "TRANSECTION ON", "TOTAL", "SRVAT", "SRVATAMT", "TOTAL", "DISCOUNT", "DISC AMOUNT", "SUB TOTAL", "IN WORDS", "NOTE", "DELETED", "ENTERED BY", "DATE CREATED", "MODIFIED BY", "MODIFIED DATE", "EXTRA NOTE", "STATUS", "PAID AMOUNT", "RETURN AMOUNT", "SALES VOUCHER NUM", "PREVIOUS BALANCE", "SALES BILL AMT", "ADVANCE RECEIVED" };
                String[] columnName_True = new String[] { "srSRVNUM", "return_Date", "return_miti", "cmDup_cname", "cmDup_address", "cmDup_contact", "PartyName", "scPartyCompany", "scPartyAddress", "scPartyContact", "srTransectionOn", "srTotal", "srVat", "srVatAmt", "srTotalAmount", "srDiscount", "srDiscAmount", "srBillTotal", "srInWords", "srNote", "is_Deleted", "Entered_By", "DateCreated", "Modified_By", "ModifiedDate", "extraNote", "status", "paid_amount", "return_amount", "SAID", "SVNUM", "previous_balance", "sales_bill_amt", "advance_given" };
                int[] colsize = new int[] { 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130 };
                String[] columnName_false = new String[] { "SRID", "srSalerID", "UserID", "MUserID", "SAID" };
                //Creation of table headder
                for (int i = 0; i < columnName_True.Length && i < colsize.Length; i++) ProddataGridView.Columns($@"{columnName_True[i]}", $@"{columnName_ToDisplay[i]}", $@"{columnName_True[i]}", colsize[i], 0, true);
                for (int i = 0; i < columnName_false.Length; i++) ProddataGridView.Columns($@"{columnName_false[i]}", $@"{columnName_false[i]}", $@"{columnName_false[i]}", 0, 0, false);
                ProddataGridView.AutoGenerateColumns = false;
            }
            else
            {
                //ignore
            }
        }

        private void btnFilterSearch_Click(object sender, EventArgs e)
        {
            voucherType = cmd_VoucherType.Text;
            fromDate = txtFrom.Text;
            toDate = txtTo.Text;
            if(dateType != "A.D" || dateType != "B.S") dateType = "A.D";
            var dt = mainMaster.getReport(voucherType, dateType, fromDate, toDate);
            ProddataGridView.DataSource = dt;
        }

        private void cmd_VoucherType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridColumns();
        }

        private void rdBtnEnglish_CheckedChanged(object sender, EventArgs e)
        {
            maskChanged();
            dateType = "A.D";
        }

        private void rdBtnNepali_CheckedChanged(object sender, EventArgs e)
        {
            maskChanged();
            dateType = "B.S";
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            ////panel.BackColor = ColorTranslator.FromHtml(Global.BackgroundColor);
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to export file.", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            using (XLWorkbook workbook = new XLWorkbook())
                            {
                                var dt = ProddataGridView.DataSource as DataTable;
                                workbook.Worksheets.Add(dt);
                                workbook.SaveAs(saveFileDialog.FileName);
                            }
                            MessageBox.Show("File saved sucessfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            else return;
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

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MouseBtn = 1;
            reloadEventFunction(sender, e);
            MouseBtn = 0;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
          panel.BackColor = ColorTranslator.FromHtml(Global.BackgroundColor);
        }

        public void maskChanged()
        {
            txtFrom.Clear();
            txtTo.Clear();
            if (rdBtnNepali.Checked == true)
            {
                txtFrom.Mask = "##/##/####";
                txtTo.Mask = "##/##/####";
            }
            else if (rdBtnEnglish.Checked == true)
            {
                txtFrom.Mask = "####/##/##";
                txtTo.Mask = "####/##/##";
            }
            else
            {
                txtFrom.Mask = "####/##/##";
                txtTo.Mask = "####/##/##";
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
            lbl_CompanyName.TextAlign = ContentAlignment.MiddleCenter;
            lbl_Address.TextAlign = ContentAlignment.MiddleCenter;
            lbl_Phone.TextAlign = ContentAlignment.MiddleCenter;
            ToPerform = string.Empty;
            msg = string.Empty;
            ProddataGridView.Columns.Clear();
            ProddataGridView.Rows.Clear();
            maskChanged();
            cmd_VoucherType.SelectedIndex = 0;
            cmd_VoucherType.Focus();
            DataGridColumns();
        }
    }
}
