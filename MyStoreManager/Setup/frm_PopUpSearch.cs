using MSMControl.Class;
using MSMControl.Connection;
using MSMControl.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace MyStoreManager.Setup
{
    public partial class frm_PopUpSearch : Form
    {
        #region Global
        public List<DataRow> SelectedRow = new List<DataRow>();
        public static DataTable dt;
        private readonly ClsPopUpSearch _ObjPopUp = new ClsPopUpSearch();
        public string InitialCatalog = string.Empty;
        public string InitialCatalogMain = string.Empty;
        private readonly IMainMaster mainMaster = new ClsMainMaster();
        private string columnValue = string.Empty;
        public string form = string.Empty;
        public string columnName = string.Empty;

        public int ID { get; }
        public int status { get; }
        public int deleted { get; }
        public string V_Num { get; }
        public string ColumnSearch { get; set; }
        public frm_PopUpSearch()
        {
            InitializeComponent();
        }
        #endregion

        #region Functions(Methods)
        
        internal DataTable GetDataTable()
        {
            var dtLocal = new DataTable();
            try
            {
                dtLocal = dt.Clone();
                var colName = DataGrid.Columns[DataGrid.CurrentCell.ColumnIndex].Name;
                foreach (DataGridViewRow dr in DataGrid.Rows)
                {
                    var drLocal = dtLocal.NewRow();
                    for (var i = 0; i < DataGrid.Columns.Count; i++)
                    {
                        var item = DataGrid.Columns[i].DataPropertyName;
                        drLocal[item] = dr.Cells[i].Value;
                    }

                    dtLocal.Rows.Add(drLocal);
                }

                return dtLocal;
            }
            catch (Exception ex)
            {
                var Message = ex.Message;
                return dtLocal;
            }
        }

        public void SelectRowValue()
        {
            SelectedRow.Clear();
            var dt1 = GetDataTable();
            var index = DataGrid.CurrentRow.Index;
            SelectedRow.Add(dt1.Rows[index]);
            Close();
        }

        private void Initialize()
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, DataGrid,new object[] { true });
        }

        private void getCountryOrStateList()
        {
            String[] columnName_ToDisplay = new String[] { "STATE NAME", "COUNTRY NAME" };
            String[] columnName_True = new String[] { "StateName", "CountryName" };
            int[] colsize = new int[] { 200, 120 };
            for (int i = 0; i < columnName_True.Length && i < colsize.Length; i++) DataGrid.Columns($@"{columnName_True[i]}", $@"{columnName_ToDisplay[i]}", $@"{columnName_True[i]}", colsize[i], 0, true);
            String[] columnName_false = new String[] { "ID" };
            for (int i = 0; i < columnName_false.Length; i++) DataGrid.Columns($@"{columnName_false[i]}", $@"{columnName_false[i]}", $@"{columnName_false[i]}", 0, 0, false);
            DataGrid.AutoGenerateColumns = false;
            dt = _ObjPopUp.Get_Country_State(ID);
            DataGrid.DataSource = dt;
        }

        public void getCompanyList()
        {
            DataGrid.Columns("cid", "cid", "cid",0,0,false);
            DataGrid.Columns("cname", "COMPANY NAME", "cname", 350, 0, true);
            DataGrid.Columns("regno", "PAN/VAT", "regno", 150, 0, true);
            DataGrid.Columns("contact", "CONTACT", "contact", 0, 0, false);
            DataGrid.Columns("email", "EMAIL", "email", 0, 0, false);
            DataGrid.Columns("address", "ADDRESS", "address", 150, 0, true);
            DataGrid.Columns("city", "CITY", "city", 150, 0, true);
            DataGrid.Columns("StateName", "STATE NAME", "StateName", 0, 0, false);
            DataGrid.Columns("country", "COUNTRY", "country", 0, 0, false);
            DataGrid.Columns("Location", "LOCATION", "Location", 0, 0, false);
            DataGrid.AutoGenerateColumns = false;
            dt = _ObjPopUp.GetCompanyList(ID);
            DataGrid.DataSource = dt;
        }
        public void getLoginCompanyList()
        {
            DataGrid.Columns("cid", "cid", "cid", 0, 0, false);
            DataGrid.Columns("cname", "COMPANY NAME", "cname", 250, 0, true);
            DataGrid.Columns("regno", "PAN/VAT", "regno", 150, 0, true);
            DataGrid.Columns("contact", "CONTACT", "contact", 0, 0, false);
            DataGrid.Columns("email", "EMAIL", "email", 0, 0, false);
            DataGrid.Columns("address", "ADDRESS", "address", 150, 0, true);
            DataGrid.Columns("city", "CITY", "city", 150, 0, true);
            DataGrid.Columns("StateName", "STATE NAME", "StateName", 0, 0, false);
            DataGrid.Columns("country", "COUNTRY", "country", 0, 0, false);
            DataGrid.Columns("Location", "LOCATION", "Location", 0, 0, false);
            DataGrid.AutoGenerateColumns = false;
            dt = _ObjPopUp.GetLoginCompanyList(ID);
            DataGrid.DataSource = dt;
        }

        public void getUserRole()
        {
            DataGrid.Columns("RoleId", "RoleId", "RoleId", 0, 0, false);
            DataGrid.Columns("RoleName", "ROLE NAME", "RoleName", 250, 0, true);
            DataGrid.Columns("RoleStatus", "ROLE STATUS", "RoleStatus", 250, 0, true);
            DataGrid.AutoGenerateColumns = false;
            dt = _ObjPopUp.GetUserRole(ID, status);
            DataGrid.DataSource = dt;
        }

        public void getUser()
        {
            DataGrid.Columns("userid", "USER ID", "userid", 0, 0, false);
            DataGrid.Columns("usrname", "USER NAME", "usrname", 250, 0, true);
            DataGrid.Columns("loginid", "LOGIN ID", "loginid", 250, 0, true);
            DataGrid.Columns("password", "PASSWORD", "password", 250, 0, false);
            DataGrid.Columns("dept", "DEPARTMENT", "dept", 250, 0, true);
            DataGrid.Columns("RoleID", "RoleID", "RoleID", 250, 0, false);
            DataGrid.Columns("RoleName", "ROLE NAME", "RoleName", 250, 0, false);
            DataGrid.Columns("ActiveStatus", "ACTIVE STATUS", "ActiveStatus", 250, 0, false);
            DataGrid.AutoGenerateColumns = false;
            dt = _ObjPopUp.GetUser(ID);
            DataGrid.DataSource = dt;
        }

        public void getUnit()
        {
            DataGrid.Columns("UnitID", "UNIT ID", "UnitID", 0, 0, false);
            DataGrid.Columns("Unit", "UNIT NAME", "Unit", 250, 0, true);
            DataGrid.Columns("UnitCode", "UNIT CODE", "UnitCode", 250, 0, true);
            DataGrid.Columns("ActiveStatus", "ACTIVE STATUS", "ActiveStatus", 250, 0, false);
            DataGrid.AutoGenerateColumns = false;
            dt = _ObjPopUp.GetUnit(ID, status);
            DataGrid.DataSource = dt;
        }

        public void getCustomer()
        {
            DataGrid.Columns("CID", "CID", "CID", 0, 0, false);
            DataGrid.Columns("PartyName", "NAME", "PartyName", 250, 0, true);
            DataGrid.Columns("PartyCode", "CODE", "PartyCode", 250, 0, true);
            DataGrid.Columns("PartyEmail", "EMAIL", "PartyEmail", 250, 0, false);
            //DataGrid.Columns("PartyCompany", "PARTY COMPANY", "PartyCompany", 150, 0, false);
            DataGrid.Columns("PartyAddress", "ADDRESS", "PartyAddress", 250, 0, true);
            DataGrid.Columns("PartyState", "STATE", "PartyState", 250, 0, true);
            DataGrid.Columns("PartyCountry", "COUNTRY", "PartyCountry", 250, 0, false);
            DataGrid.Columns("PartyContact", "CONTACT", "PartyContact", 250, 0, true);
            DataGrid.Columns("PartyReg", "PAN/VAT", "PartyReg", 250, 0, true);
            DataGrid.Columns("PartyNote", "NOTE", "PartyNote", 250, 0, false);
            DataGrid.Columns("ActiveStatus", "STATUS", "ActiveStatus", 250, 0, false);
            DataGrid.AutoGenerateColumns = false;
            dt = _ObjPopUp.GetCustomer(ID,status);
            DataGrid.DataSource = dt;
        }

        public void getProduct()
        {
            DataGrid.Columns("PID", "PID", "PID", 0, 0, false);
            DataGrid.Columns("InventID", "InventID", "InventID", 0, 0, false);
            DataGrid.Columns("PName", "NAME", "PName", 250, 0, true);
            DataGrid.Columns("PCode", "CODE", "PCode", 250, 0, true);
            DataGrid.Columns("PBarcode", "BARCODE", "PBarcode", 250, 0, true);
            DataGrid.Columns("UnitID", "UNITID", "UnitID", 250, 0, false);
            DataGrid.Columns("MainUnit", "MAINUNIT", "MainUnit", 250, 0, true);
            
            DataGrid.Columns("UnitQnty", "UNITQNTY", "UnitQnty", 250, 0, true);

            DataGrid.Columns("MainUnitCode", "UNITCODE", "MainUnitCode", 250, 0, false);

            DataGrid.Columns("AltUnitId", "ALTUNITID", "AltUnitId", 250, 0, false);
            DataGrid.Columns("AltUnit", "ALTUNIT", "AltUnit", 250, 0, true);
            DataGrid.Columns("AltUnitQnty", "ALTUNITQNTY", "AltUnitQnty", 250, 0, true);

            DataGrid.Columns("AltUnitCode", "ALTUNITCODE", "AltUnitCode", 250, 0, false);

            DataGrid.Columns("PurchasePrice", "PURCHASEPRICE", "PurchasePrice", 250, 0, false);
            DataGrid.Columns("MRP", "MRP", "MRP", 250, 0, false);
            DataGrid.Columns("Offer", "OFFER", "Offer", 250, 0, false);
            DataGrid.Columns("PNote", "NOTE", "PNote", 250, 0, false);
            DataGrid.Columns("CategoryCode", "CATEGORY CODE", "CategoryCode", 100, 0, true);
            DataGrid.Columns("ProductCategory", "TYPE", "ProductCategory", 250, 0, false);
            DataGrid.Columns("ActiveStatus", "STATUS", "ActiveStatus", 250, 0, true);
            DataGrid.AutoGenerateColumns = false;
            dt = _ObjPopUp.GetProduct(ID, status, V_Num);
            DataGrid.DataSource = dt;
        }

        public void getCategory()
        {
            DataGrid.Columns("CatID", "CATEGORY ID", "CatID", 0, 0, false);
            DataGrid.Columns("Category", "CATEGORY NAME", "Category", 250, 0, true);
            DataGrid.Columns("CategoryID", "CATEGORY CODE", "CategoryID", 250, 0, true);
            DataGrid.Columns("ActiveStatus", "ACTIVE STATUS", "ActiveStatus", 250, 0, false);
            DataGrid.AutoGenerateColumns = false;
            dt = _ObjPopUp.getCategory(ID);
            DataGrid.DataSource = dt;
        }

        public void GetGodown()
        {
            DataGrid.Columns("GodID", "CATEGORY ID", "GodID", 0, 0, false);
            DataGrid.Columns("GodName", "GODOWN NAME", "GodName", 250, 0, true);
            DataGrid.Columns("GodCode", "GODOWN CODE", "GodCode", 250, 0, true);
            DataGrid.Columns("GodAddress", "GODOWN ADDRESS", "GodAddress", 250, 0, true);
            DataGrid.Columns("ActiveStatus", "ACTIVE STATUS", "ActiveStatus", 250, 0, false);
            DataGrid.AutoGenerateColumns = false;
            dt = _ObjPopUp.getGodown(ID);
            DataGrid.DataSource = dt;
        }

        public void GetPurchaseOrder()
        {
            String[] columnName_ToDisplay = new String[] { "VOUCHER NUM", "DATE", "MITI", "PARTY NAME",  "PARTY ADDRESS","IS DELETED", "ENTRY USER" };
            String[] columnName_True = new String[] { "POVNUM", "Order_Date", "Order_Miti", "PartyName", "PartyAddress", "is_Deleted", "usrname" };
            int[] colsize = new int[] { 100, 100, 100, 170, 170, 120,80,170 };
            for (int i = 0; i < columnName_True.Length && i < colsize.Length; i++) DataGrid.Columns($@"{columnName_True[i]}", $@"{columnName_ToDisplay[i]}", $@"{columnName_True[i]}", colsize[i], 0, true);
            String[] columnName_false = new String[] { "POID", "ReceiverID" , "usrname", "PartyCompany", "Dup_cname", "Dup_address", "Dup_contact", "SenderID", "PartyAddress", "PartyContact", "PO_Bill_Status", "Total", "Vat", "VatAmt", "TotalAmount", "Discount", "DiscAmount", "BillTotal", "InWords" , "UserID", "DateCreated" , "TransectionOn", "is_Deleted" };
            for (int i = 0; i < columnName_false.Length; i++) DataGrid.Columns($@"{columnName_false[i]}", $@"{columnName_false[i]}", $@"{columnName_false[i]}", 0, 0, false);
            DataGrid.AutoGenerateColumns = false;
            dt = _ObjPopUp.getPurchaseOrder(ID,status,deleted);
            DataGrid.DataSource = dt;
        }

        public void GetPurchaseEntry()
        {
            String[] columnName_ToDisplay = new String[] {"VOUCHER NUM", "DATE", "MITI","REF_BILL","PO_NUMBER","REF_VOUCHER","PARTY NAME" ,"TRANSECTION"};
            String[] columnName_True = new String[] { "PVNUM", "Purchase_Date", "Purchase_Miti", "ref_bill_No", "Purchase_OrderNo", "PO_ReferenceNo", "PartyName", "TransectionOn"};
            int[] colsize = new int[] { 100, 100, 100 ,100,100,120,170,170,120,};
            for (int i = 0; i < columnName_True.Length && i < colsize.Length; i++) DataGrid.Columns($@"{columnName_True[i]}", $@"{columnName_ToDisplay[i]}", $@"{columnName_True[i]}", colsize[i], 0, true);
            String[] columnName_false = new String[] { "PEID","POID","SenderID", "PartyAddress", "PartyContact", "ReceiverID", "Total", "Vat", "VatAmt", "TotalAmount", "Discount", "PartyCompany","DiscAmount", "BillTotal", "InWords", "Note", "PO_Bill_Status", "is_Deleted", "UserID", "DateCreated", "MUserID", "Entered_By", "ModifiedDate" };
            for (int i = 0; i < columnName_false.Length; i++) DataGrid.Columns($@"{columnName_false[i]}", $@"{columnName_false[i]}", $@"{columnName_false[i]}", 0, 0, false);
            DataGrid.AutoGenerateColumns = false;
            dt = _ObjPopUp.getPurchaseEntry(ID, status);
            DataGrid.DataSource = dt;
        }

        public void GetPurchaseReturn()
        {
            String[] columnName_ToDisplay = new String[] { "VOUCHER NUM", "DATE", "MITI", "PARTY NAME", "TRANSECTION" };
            String[] columnName_True = new String[] { "PRVNUM", "Purchase_Return_Date", "Purchase_Return_Miti", "PartyName", "TransectionOn" };
            int[] colsize = new int[] { 100, 100, 120, 170, 170, 120, };
            for (int i = 0; i < columnName_True.Length && i < colsize.Length; i++) DataGrid.Columns($@"{columnName_True[i]}", $@"{columnName_ToDisplay[i]}", $@"{columnName_True[i]}", colsize[i], 0, true);
            String[] columnName_false = new String[] { "PRID", "ReceiverID", "PartyAddress", "PartyContact", "SenderID", "Total", "Vat", "VatAmt", "TotalAmount", "PartyCompany","Discount", "DiscAmount", "BillTotal", "InWords", "Note", "is_Deleted", "UserID", "Entered_By", "DateCreated", "MUserID", "ModifiedDate" };
            for (int i = 0; i < columnName_false.Length; i++) DataGrid.Columns($@"{columnName_false[i]}", $@"{columnName_false[i]}", $@"{columnName_false[i]}", 0, 0, false);
            DataGrid.AutoGenerateColumns = false;
            dt = _ObjPopUp.getPurchaseReturnEntry(ID, status);
            DataGrid.DataSource = dt;
        }

        public void GetRefrenceNumber()
        {
            String[] columnName_ToDisplay = new String[] { "PVNUM", "PURCHASE ORDER NO", "REFERENCE NO" };
            String[] columnName_True = new String[] { "PVNUM", "Purchase_OrderNo", "PO_ReferenceNo" };
            int[] colsize = new int[] { 100, 100, 100};
            for (int i = 0; i < columnName_True.Length && i < colsize.Length; i++)
            {
                DataGrid.Columns($@"{columnName_True[i]}", $@"{columnName_ToDisplay[i]}", $@"{columnName_True[i]}", colsize[i], 0, true);
            }
            DataGrid.AutoGenerateColumns = false;
            dt = _ObjPopUp.Get_RefrenceNumber(V_Num);
            DataGrid.DataSource = dt;
        }

        public void GetProductInventory()
        {
            String[] columnName_ToDisplay = new String[] { "CODE", "PRODUCT NAME", "QUANTITY", "UNIT", "ALTERNATE QUANTITY", "ALTERNATE UNIT", "BARCODE",  "STATUS" };
            String[] columnName_True = new String[] { "PCode","PName" , "Quantity", "UnitCode", "AlternateQuantity", "AltUnitCode", "PBarcode",  "ActiveStatus" };
            int[] colsize = new int[] { 80, 170, 100, 100, 100, 100, 170, 80 };
            for (int i = 0; i < columnName_True.Length && i < colsize.Length; i++)
            {
                DataGrid.Columns($@"{columnName_True[i]}", $@"{columnName_ToDisplay[i]}", $@"{columnName_True[i]}",colsize[i], 0, true);
            }
            String[] columnName_false = new String[] { "InventID" , "prodID", "UnitID", "AltUnitID" };
            for (int i = 0; i < columnName_false.Length; i++)
            {
                DataGrid.Columns($@"{columnName_false[i]}", $@"{columnName_false[i]}", $@"{columnName_false[i]}", 0, 0, false);
            }
            DataGrid.AutoGenerateColumns = false;
            dt = mainMaster.GetInventoryData(ID);
            DataGrid.DataSource = dt;
        }

        public void GetReceivedList()
        {
            String[] columnName_ToDisplay = new String[] { "PVNUM", "PRODUCT NAME", "PURCHASE_ORDER_NO", "ORDER QUANTITY" ,"RECEIVED QNTY", "TOTAL RECEIVED QNTY", "TOTAL ORDER QNTY" };
            String[] columnName_True = new String[] { "PVNUM", "PName", "Purchase_OrderNo", "orderQuantity", "Quantiy", "totalReceived", "totalQuantity" };
            for (int i = 0; i < columnName_True.Length; i++) DataGrid.Columns($@"{columnName_True[i]}", $@"{columnName_ToDisplay[i]}", $@"{columnName_True[i]}", 170, 0, true);
            DataGrid.AutoGenerateColumns = false;
            dt = _ObjPopUp.Get_GoodsReceivedList(V_Num);
            DataGrid.DataSource = dt;
        }
        
        public void GetSalesEntry()
        {
            String[] columnName_ToDisplay = new String[] { "VOUCHER NUM", "DATE", "MITI", "PARTY NAME" };
            String[] columnName_True = new String[] { "SVNUM", "Sales_Date", "Sales_Miti", "PartyName" };
            int[] colsize = new int[] { 100, 100, 120, 170 };
            for (int i = 0; i < columnName_True.Length && i < colsize.Length; i++) DataGrid.Columns($@"{columnName_True[i]}", $@"{columnName_ToDisplay[i]}", $@"{columnName_True[i]}", colsize[i], 0, true);
            String[] columnName_false = new String[] { "SAID", "SalerID", "Dup_cname", "Dup_address", "Dup_contact", "BuyerID", "PartyCompany", "PartyAddress", "PartyContact", "TransectionOn", "Total", "Vat", "VatAmt", "TotalAmount", "Discount", "DiscAmount", "BillTotal", "receivedAmt", "changeGiven", "dueBalance", "InWords", "is_hold", "is_Paid", "is_complete_paid", "Note", "is_Deleted", "UserID", "DateCreated", "MUserID", "Entered_By", "ModifiedDate" };
            for (int i = 0; i < columnName_false.Length; i++) DataGrid.Columns($@"{columnName_false[i]}", $@"{columnName_false[i]}", $@"{columnName_false[i]}", 0, 0, false);
            DataGrid.AutoGenerateColumns = false;
            dt = _ObjPopUp.getSalesEntry(ID, status, deleted);
            DataGrid.DataSource = dt;
        }

        public void getSalesReturnEntry()
        {
            String[] columnName_ToDisplay = new String[] { "VOUCHER NUM", "DATE", "MITI", "PARTY NAME" };
            String[] columnName_True = new String[] { "SRVNUM", "Sales_Date", "Sales_Miti", "PartyName" };
            int[] colsize = new int[] { 100, 100, 120, 170 };
            for (int i = 0; i < columnName_True.Length && i < colsize.Length; i++) DataGrid.Columns($@"{columnName_True[i]}", $@"{columnName_ToDisplay[i]}", $@"{columnName_True[i]}", colsize[i], 0, true);
            String[] columnName_false = new String[] {"SRID","SRVNUM","Sales_Date","Sales_Miti","Return_Date","SalerID", "Dup_cname","Dup_address","Dup_contact","PartyName","PartyCompany","PartyAddress","PartyContact","TransectionOn","Total","Vat","VatAmt","TotalAmount","Discount","DiscAmount","BillTotal","InWords","Note","is_Deleted","UserID","Entered_By","DateCreated","MUserID","Modified_By","ModifiedDate","extraNote","status","paid_amount","return_amount","SAID", "SVNUM", "previous_balance", "sales_bill_amt", "advance_given" };
            for (int i = 0; i < columnName_false.Length; i++) DataGrid.Columns($@"{columnName_false[i]}", $@"{columnName_false[i]}", $@"{columnName_false[i]}", 0, 0, false);
            DataGrid.AutoGenerateColumns = false;
            dt = _ObjPopUp.getReturnSalesEntry(ID, status, deleted);
            DataGrid.DataSource = dt;
        }

        public void getUserMaster()
        {
            String[] columnName_ToDisplay = new String[] { "USER NAME"};
            String[] columnName_True = new String[] { "usrname"};
            int[] colsize = new int[] { 100 };
            for (int i = 0; i < columnName_True.Length && i < colsize.Length; i++) DataGrid.Columns($@"{columnName_True[i]}", $@"{columnName_ToDisplay[i]}", $@"{columnName_True[i]}", colsize[i], 0, true);
            String[] columnName_false = new String[] { "userid", "RoleId" };
            for (int i = 0; i < columnName_false.Length; i++) DataGrid.Columns($@"{columnName_false[i]}", $@"{columnName_false[i]}", $@"{columnName_false[i]}", 0, 0, false);
            DataGrid.AutoGenerateColumns = false;
            dt = _ObjPopUp.GetUser(ID);
            DataGrid.DataSource = dt;
        }

        public void GetOrderTicket()
        {
            String[] columnName_ToDisplay = new String[] { "VOUCHER NUM", "DATE", "MITI", "DLV_DATE", "DLV_MITI", "PARTY NAME", "PARTY ADDRESS", "ORDER STATUS", "IS DELETED", "ENTRY USER" };
            String[] columnName_True = new String[] { "OVNUM", "Order_Date", "Order_Miti", "Delivery_Date", "Delivery_Miti", "PartyName", "PartyAddress", "OrderStatus", "is_Deleted", "Entered_By" };
            int[] colsize = new int[] { 100, 100, 100, 100, 100, 170, 120, 80, 170 };
            for (int i = 0; i < columnName_True.Length && i < colsize.Length; i++) DataGrid.Columns($@"{columnName_True[i]}", $@"{columnName_ToDisplay[i]}", $@"{columnName_True[i]}", colsize[i], 0, true);
            String[] columnName_false = new String[] { "OID", "SenderID", "Dup_cname", "Dup_address", "Dup_contact", "BuyerID", "PartyCompany", "PartyContact", "Note", "Est_Time", "UserID", "DateCreated", "MUserID", "Modified_By", "ModifiedDate" };
            for (int i = 0; i < columnName_false.Length; i++) DataGrid.Columns($@"{columnName_false[i]}", $@"{columnName_false[i]}", $@"{columnName_false[i]}", 0, 0, false);
            DataGrid.AutoGenerateColumns = false;
            dt = _ObjPopUp.getOrderTicketEntry(ID, status, deleted,V_Num);
            DataGrid.DataSource = dt;
        }

        public void getIssueCard()
        {
            String[] columnName_ToDisplay = new String[] { "VOUCHER NUM", "ORDER CARD NUM", "DATE", "MITI", "DLV_DATE", "DLV_MITI", "PARTY NAME", "ASSIGNEE_NAME", "ORDER STATUS", "IS DELETED", "ENTRY USER" };
            String[] columnName_True = new String[] { "ICVNUM", "OVNUM", "Issue_Date", "Issue_Miti", "Delivery_Date", "Delivery_Miti", "PartyName", "Assignee_Name", "OrderStatus", "is_Deleted", "Entered_By" };
            int[] colsize = new int[] { 100, 100 , 100, 100, 100, 100, 170, 120, 80, 170 };
            for (int i = 0; i < columnName_True.Length && i < colsize.Length; i++) DataGrid.Columns($@"{columnName_True[i]}", $@"{columnName_ToDisplay[i]}", $@"{columnName_True[i]}", colsize[i], 0, true);
            String[] columnName_false = new String[] { "ICID", "OID" ,"SenderID", "Dup_cname", "Dup_address", "Dup_contact", "BuyerID", "PartyAddress", "PartyCompany", "PartyContact", "AssigneeId", "Note", "Est_Time", "UserID", "DateCreated", "MUserID", "Modified_By", "ModifiedDate" };
            for (int i = 0; i < columnName_false.Length; i++) DataGrid.Columns($@"{columnName_false[i]}", $@"{columnName_false[i]}", $@"{columnName_false[i]}", 0, 0, false);
            DataGrid.AutoGenerateColumns = false;
            dt = _ObjPopUp.getIssueCardEntry(ID, status, deleted, V_Num);
            DataGrid.DataSource = dt;
        }

        internal void GetOperationCommon(string Types)
        {
            switch(Types)
            {
                case "CountryOrStateList":
                    {
                        form = Types;
                        getCountryOrStateList();
                        ColumnSearch = "StateName";
                        break;
                    }
                case "CompanySelect":
                    {
                        form = Types;
                        getCompanyList();
                        ColumnSearch = "cname";
                        break;
                    }
                case "LoginCompanySelect":
                    {
                        form = Types;
                        getLoginCompanyList();
                        ColumnSearch = "cname";
                        break;
                    }
                case "GetUserRole":
                    {
                        form = Types;
                        getUserRole();
                        ColumnSearch = "RoleName";
                        break;
                    }
                case "GetUser":
                    {
                        form = Types;
                        getUser();
                        ColumnSearch = "usrname";
                        break;
                    }
                case "GetUnit":
                    {
                        form = Types;
                        getUnit();
                        ColumnSearch = "Unit";
                        break;
                    }
                case "CustomerSelect":
                    {
                        form = Types;
                        getCustomer();
                        ColumnSearch = "PartyName";
                        break;
                    }
                case "ProductSelect":
                    {
                        form = Types;
                        getProduct();
                        ColumnSearch = "PName";
                        break;
                    }
                case "GetCategory":
                    {
                        form = Types;
                        getCategory();
                        ColumnSearch = "Category";
                        break;
                    }
                case "GetGodown":
                    {
                        form = Types;
                        GetGodown();
                        ColumnSearch = "Category";
                        break;
                    }
                case "PurchaseOrder":
                    {
                        form = Types;
                        GetPurchaseOrder();
                        ColumnSearch = "POVNUM";
                        break;
                    }
                case "GoodsRecivedList":
                    {
                        form = Types;
                        GetReceivedList();
                        ColumnSearch = "PVNUM";
                        break;
                    }
                case "PurchaseEntry": 
                    {
                        form = Types;
                        GetPurchaseEntry();
                        ColumnSearch = "PVNUM";
                        break;
                    }
                case "RefrenceNumber":
                    {
                        form = Types;
                        GetRefrenceNumber();
                        ColumnSearch = "PVNUM";
                        break;
                    }
                case "ProductInventory":
                    {
                        form = Types;
                        GetProductInventory();
                        ColumnSearch = "PName";
                        break;
                    }
                case "PurchaseReturnEntry":
                    {
                        form = Types;
                        GetPurchaseReturn();
                        ColumnSearch = "PVNUM";
                        break;
                    }
                case "SalesEntry":
                    {
                        form = Types;
                        GetSalesEntry();
                        ColumnSearch = "SVNUM";
                        break;
                    }
                case "SalesReturnEntry":
                    {
                        form = Types;
                        getSalesReturnEntry();
                        ColumnSearch = "SRVNUM";
                        break;
                    }
                case "OrderTicket":
                    {
                        form = Types;
                        GetOrderTicket();
                        ColumnSearch = "OVNUM";
                        break;
                    }
                case "UserMaster":
                    {
                        form = Types;
                        getUserMaster();
                        ColumnSearch = "usrname";
                        break;
                    }
                case "IssueCard":
                    {
                        form = Types;
                        getIssueCard();
                        ColumnSearch = "ICVNUM";
                        break;
                    }
            }
        }

        public frm_PopUpSearch(int id, string TableName, string DbName, string types, int activeStatus,string VNUM, int is_deleted)
        {
            ID = id;
            InitialCatalog = Global.InitialCatalogMaster;
            InitialCatalogMain = Global.InitialCatalogMain;
            InitializeComponent();
            Initialize();
            DataGrid.RowHeadersWidth = 20;
            status = activeStatus;
            deleted = is_deleted;
            V_Num = VNUM; // it can be used also for other string values not just for voucher, in case of issue card it is used for sorting with respect to form.

            if (DbName == InitialCatalog || DbName == InitialCatalogMain) // For company database connection // For main database connection
            {
                GetOperationCommon(types);
                return;
            }
        }

        #endregion

        #region Event

        private void DataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_OK.PerformClick();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (DataGrid.CurrentRow != null) SelectRowValue();
        }
        //Removed perpously--form wont work when database is not created
        private void DataGrid_Paint(object sender, PaintEventArgs e)
        {
            //DataGrid.BackColor = mainMaster.BackgroundColor();
        }

        //private void btn_Exit_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}
        #endregion

        private void DataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.Enter) //SendKeys.Send("{TAB}");
            {
                e.SuppressKeyPress = true;
                btn_OK.PerformClick();
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            if (Global.IsFormActive != 1) Application.Exit();
            else this.Close();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            if (DataGrid.Rows.Count > 0)
            {
                //string Query = string.Empty;
                if (txt_Search.Focused == true)
                {
                    //form is oeration selected while fetching data
                    switch (form)
                    {
                        case "CountryOrStateList":
                            {
                                columnName = "StateName";
                                break;
                            }
                        case "CompanySelect":
                            {
                                columnName = "cname";
                                break;
                            }
                        case "LoginCompanySelect":
                            {
                                columnName = "cname";
                                break;
                            }
                        case "GetUserRole":
                            {
                                columnName = "RoleName";
                                break;
                            }
                        case "GetUser":
                            {
                                columnName = "usrname";
                                break;
                            }
                        case "GetUnit":
                            {
                                columnName = "Unit";
                                break;
                            }
                        case "CustomerSelect":
                            {
                                columnName = "PartyName";
                                break;
                            }
                        case "ProductSelect":
                            {
                                columnName = "PName";
                                break;
                            }
                        case "GetCategory":
                            {
                                columnName = "Category";
                                break;
                            }
                        case "GetGodown":
                            {
                                columnName = "Category";
                                break;
                            }
                        case "PurchaseOrder":
                            {
                                columnName = "POVNUM";
                                break;
                            }
                        case "GoodsRecivedList":
                            {
                                columnName = "PVNUM";
                                break;
                            }
                        case "PurchaseEntry":
                            {
                                columnName = "PVNUM";
                                break;
                            }
                        case "RefrenceNumber":
                            {
                                columnName = "PVNUM";
                                break;
                            }
                        case "ProductInventory":
                            {
                                columnName = "PName";
                                break;
                            }
                        case "PurchaseReturnEntry":
                            {
                                columnName = "PVNUM";
                                break;
                            }
                        case "SalesEntry":
                            {
                                columnName = "SVNUM";
                                break;
                            }
                        case "SalesReturnEntry":
                            {
                                columnName = "SRVNUM";
                                break;
                            }
                        case "OrderTicket":
                            {
                                columnName = "OVNUM";
                                break;
                            }
                        case "UserMaster":
                            {
                                columnName = "usrname";
                                break;
                            }
                        case "IssueCard":
                            {
                                columnName = "ICVNUM";
                                break;
                            }
                    }
                    //(dataGrid.DataSource as DataTable).DefaultView.RowFilter = string.Format($@"{columnName} LIKE '%{0}%'", $@"%{ txt_Search.Text}%");
                    DataView dv = dt.DefaultView;
                    dv.RowFilter = $@"{columnName} LIKE '" + txt_Search.Text + "'";
                    DataGrid.DataSource = dv;

                }
                else
                {
                    DataGrid.Columns.Clear();
                    GetOperationCommon(form);
                }

            }
            else
            {
                DataGrid.Columns.Clear();
                GetOperationCommon(form);
            }
        }

        private void txt_Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar is (char)Keys.Enter) btn_Search.PerformClick();
        }

        private void frm_PopUpSearch_Load(object sender, EventArgs e)
        {
            DataGrid.Font = new Font("Calibri", 9, FontStyle.Regular);
        }
    }
}
