using MSMControl.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSMControl.Interface
{
    public interface IMainMaster
    {
        MOD_COMPANY_INFO compInfo { get; set; }
        MOD_DUPLICATE_COMPANY_INFO dupcompInfo { get; set; }
        MOD_COUNTRY_STATE ComboInfo { get; set; }
        MOD_USER_ROLE UserRole { get; set; }
        MOD_USER_ENTRY UserEntry { get; set; }
        MOD_CONFIGURATION Config { get; set; }
        MOD_UNIT UnitEntry { get; set; }
        MOD_CUSTOMER_MASTER CustoMaster { get; set; }
        MOD_PRODUCT_MASTER ProdMaster { get; set; }
        MOD_PRODUCT_TYPE TypeMaster { get; set; }
        MOD_GODOWN_MASTER GodownMaster { get; set; }
        MOD_PURCHASE_ORDER_MASTER PO_Master { get; set; }
        MOD_PURCHASE_ORDER_DETAILS PO_Details { get; set; }
        MOD_PURCHASE_ENTRY_MASTER PE_Master { get; set; }
        MOD_PURCHASE_ENTRY_DETAILS PE_Details { get; set; }
        MOD_PURCHASE_RETURN_MASTER PR_Master { get; set; }
        MOD_PURCHASE_RETURN_DETAILS PR_Details { get; set; }
        MOD_SALES_ENTRY_MASTER SE_Master { get; set; }
        MOD_SALES_ENTRY_DETAILS SE_Details { get; set; }
        MOD_SALES_RETURN_MASTER SR_Master { get; set; }
        MOD_SALES_RETURN_DETAILS SR_Details { get; set; }
        MOD_ORDER_TICKET_MASTER OT_Master { get; set; }
        MOD_ORDER_TICKET_DETAILS OT_Details { get; set; }
        MOD_ISSUE_CARD_MASTER IC_Master { get; set; }
        MOD_ISSUE_CARD_DETAILS IC_Details { get; set; }
        MOD_START_PROCESSING Start_Processing { get; set; }
        int CompanyInfo();
        int ConfigurationSetup();
        int ComboBoxValueTaskDone();
        int UserRoleSetup();
        int UserEntrySetup();
        int GodownSetup();
        int GetUnitSetup();
        int GetCustomerSetup();
        int GetProductSetup();
        int GetProcuctTypeSetup();
        int GetPurchaseOrderSetup();
        int GetPurchaseGoodsSetup();
        int GetPurchaseReturnSetup();
        int GetSalesEntrySetup();
        int GetSalesReturnSetup();
        int GetOrderTicketSetup();
        int GetIssueCardSetup();
        int GetStartProcessing();
        string GetMiti(string EngDate);
        //string todayMiti();
        //string NumberToWords(decimal number);

        //public static void DoWork(IProgress<int> progress);
        //void BtnProgressBar_Click(object sender, EventArgs e);
        System.Drawing.Color BackgroundColor();
        DataTable checkConfig();
        DataTable checkTransectionOnPE();
        DataTable checkTransectionOnSE();
        DataTable Get_FiscalYear();
        DataTable getlicsence();
        DataTable GetID(string column,string tablename, string columname, string value);
        DataTable GetValue(string column, string tablename, string columname, int value);
        DataTable GetKeyID(string column, string tablename, string columname, string value);
        DataTable Get_State();
        DataTable Get_Country();
        DataTable Get_Unit();
        DataTable Get_Godown();
        DataTable Get_ProductType();
        DataTable GetComboBoxValue();
        DataTable CheckPurchaseEntryDetails(string Voucher);
        DataTable GetInventoryData(int Pid);
        //DataTable GetCustomer();
        DataTable getUserLogin(string usrname, string password,int BackgroundColor);
       // DataTable chkAvaialiblity(string ToPerform, string Table, string ColumnName, string TxtboxValue, string reText);
        DataTable CheckAvailability(string table, string Column, string Value);
        DataSet GetPurchaseOrderDetails(string Voucher);
        DataSet GetOrderTicketDetails(string Voucher);
        DataSet GetIssueCardDetails(string Voucher);
        DataSet GetPurchaseEntryDetails(string Voucher);
        DataSet GetPurchaseReturnEntry(string Voucher);
        DataSet GetSalesEntry(string Voucher);
        DataSet GetSalesReturnEntry(string Voucher);
        DataSet GetProcessing(string value1, string value2, string searchType);
        DataSet GetOrderTicketReport(string value1, string value2);
        DataTable chk_PO_QuantityMaster(int POID);
        DataTable chk_PE_QuantityDetails(string VNUM);
        DataTable get_Product_From_barcode(string barCode);
        DataTable getReport(string type, string dateType, string dateFrom, string dateTo);
    }

    
}
