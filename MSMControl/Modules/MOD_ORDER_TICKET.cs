using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSMControl.Modules
{
    public class MOD_ORDER_TICKET_MASTER
    {
        public string ToPerform { get; set; }
        public int OID { get; set; }
        public string OVNUM { get; set; }
        public System.DateTime? Order_Date { get; set; }
        public string Order_Miti { get; set; }
        public System.DateTime? Delivery_Date { get; set; }
        public string Delivery_Miti { get; set; }
        public int? SenderID { get; set; }
        public int? BuyerID { get; set; }
        public string Est_Time { get; set; }
        public string Note { get; set; }
        public string OrderStatus { get; set; }
        public bool? is_Deleted { get; set; }
        public int UserID { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int? MUserID { get; set; }
        public System.DateTime? ModifiedDate { get; set; }
    }

    public class MOD_ORDER_TICKET_DETAILS
    {
        public DataGridView GetGridViewData { get; set; }
        public string ToPerform { get; set; }
        public int OID { get; set; }
        public string OVNUM { get; set; }
        public int PID { get; set; }
        public string PName { get; set; }
        public string PCode { get; set; }
        public string PBarcode { get; set; }
        public decimal? Quantiy { get; set; }
        public int? UnitID { get; set; }
        public string EST_HrsPerUnit { get; set; }
        public string TotalEST_HrsPerUnit { get; set; }
        public int UserID { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int? MUserID { get; set; }
        public System.DateTime? ModifiedDate { get; set; }
        public bool? is_Deleted { get; set; }
    }
}
