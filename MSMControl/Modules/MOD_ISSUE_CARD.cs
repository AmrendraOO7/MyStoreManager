using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSMControl.Modules
{
    public class MOD_ISSUE_CARD_MASTER
    {
        public string ToPerform { get; set; }
        public int ICID { get; set; }
        public string ICVNUM { get; set; }
        public int OID { get; set; }
        public string OVNUM { get; set; }
        public int oldOID { get; set; }
        public string oldOVNUM { get; set; }
        public System.DateTime? Issue_Date { get; set; }
        public string Issue_Miti { get; set; }
        public System.DateTime? Delivery_Date { get; set; }
        public string Delivery_Miti { get; set; }
        public int? SenderID { get; set; }
        public int? BuyerID { get; set; }
        public int? AssigneeId { get; set; }
        public string Est_Time { get; set; }
        public string OrderStatus { get; set; }
        public string Note { get; set; }
        public bool? is_Deleted { get; set; }
        public bool? check_is_Deleted { get; set; }
        public int UserID { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int? MUserID { get; set; }
        public System.DateTime? ModifiedDate { get; set; }
    }

    public class MOD_ISSUE_CARD_DETAILS
    {
        public DataGridView GetGridViewData { get; set; }
        public string ToPerform { get; set; }
        public int ICID { get; set; }
        public string ICVNUM { get; set; }
        public int PID { get; set; }
        public string PName { get; set; }
        public string PCode { get; set; }
        public string PBarcode { get; set; }
        public decimal? Quantiy { get; set; }
        public int? UnitID { get; set; }
        public int UserID { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int? MUserID { get; set; }
        public System.DateTime? ModifiedDate { get; set; }
        public bool? is_Deleted { get; set; }
    }

    public class MOD_START_PROCESSING
    {
        public string ToPerform { get; set; }
        public int ICID { get; set; }
        public string ICVNUM { get; set; }
        public int OID { get; set; }
        public string OVNUM { get; set; }
        public string OrderStatus { get; set; }
        public int oldOID { get; set; }
        public string oldOVNUM { get; set; }
        public int UserID { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int? MUserID { get; set; }
        public System.DateTime? ModifiedDate { get; set; }
    }
}
