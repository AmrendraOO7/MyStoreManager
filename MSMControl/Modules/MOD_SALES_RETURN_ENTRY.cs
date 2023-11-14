using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSMControl.Modules
{
    public class MOD_SALES_RETURN_MASTER
    {
        public string ToPerform { get; set; }
        public int SRID { get; set; }
        public string SRVNUM { get; set; }
        public System.DateTime? Sales_Date { get; set; }
        public string Sales_Miti { get; set; }
        public System.DateTime Return_Date { get; set; }
        public int? SalerID { get; set; }
        public int? BuyerID { get; set; }
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
        public bool? is_Deleted { get; set; }
        public int UserID { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int? MUserID { get; set; }
        public System.DateTime? ModifiedDate { get; set; }
        public string extraNote { get; set; }
        public bool? status { get; set; }
        public decimal? old_quantiity { get; set; }
        public decimal? paid_amount { get; set; }
        public decimal? return_amount { get; set; }
        public int? SAID { get; set; }
        public string SVNUM { get; set; }
        public decimal? previous_balance { get; set; }
        public decimal? sales_bill_amt { get; set; }
    }

    public class MOD_SALES_RETURN_DETAILS
    {
        public DataGridView GetGridViewData { get; set; }
        public DataGridView updateGetGridViewData { get; set; }
        public string ToPerform { get; set; }
        public int SRID { get; set; }
        public string SRVNUM { get; set; }
        public int PID { get; set; }
        public string PName { get; set; }
        public string PCode { get; set; }
        public string PBarcode { get; set; }
        public decimal? Quantiy { get; set; }
        public int? UnitID { get; set; }
        public decimal? PPrice { get; set; }
        public decimal? pDisc { get; set; }
        public decimal? pamount { get; set; }
        public decimal? TotalPrice { get; set; }
        public string Note { get; set; }
        public int UserID { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int? MUserID { get; set; }
        public System.DateTime? ModifiedDate { get; set; }
        public bool? is_Deleted { get; set; }
    }
}
