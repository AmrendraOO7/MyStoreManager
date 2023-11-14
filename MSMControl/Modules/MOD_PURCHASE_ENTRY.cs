using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSMControl.Modules
{
    public class MOD_PURCHASE_ENTRY_MASTER
    {
        public string ToPerform { get; set; }
        public int PEID { get; set; }
        public string PVNUM { get; set; }
        public System.DateTime? Purchase_Date { get; set; }
        public string Purchase_Miti { get; set; }
        public string ref_bill_No { get; set; }
        public string Purchase_OrderNo { get; set; }
        public string PO_ReferenceNo { get; set; }
        public int? SenderID { get; set; }
        public int? ReceiverID { get; set; }
        public string TransectionOn { get; set; }
        public decimal? Total { get; set; }
        public decimal? Vat { get; set; }
        public decimal? VatAmt { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? Discount { get; set; }
        public decimal? DiscAmount { get; set; }
        public decimal? BillTotal { get; set; }
        public string InWords { get; set; }
        public string Note { get; set; }
        public bool? PO_Bill_Status { get; set; }
        public bool? is_Deleted { get; set; }
        public int UserID { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int? MUserID { get; set; }
        public System.DateTime? ModifiedDate { get; set; }
    }
    public class MOD_PURCHASE_ENTRY_DETAILS
    {
        public DataGridView GetGridViewData { get; set; }
        public DataGridView updateGetGridViewData { get; set; }
        public string ToPerform { get; set; }
        public int PEID { get; set; }
        public string PVNUM { get; set; }
        public int PID { get; set; }
        public string PName { get; set; }
        public string PCode { get; set; }
        public string PBarcode { get; set; }
        public decimal? Quantiy { get; set; }
        public int? UnitID { get; set; }
        public decimal? PPrice { get; set; }
        public decimal? TotalPrice { get; set; }
        public int UserID { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int? MUserID { get; set; }
        public System.DateTime? ModifiedDate { get; set; }
        public bool? is_Deleted { get; set; }
    }
}
