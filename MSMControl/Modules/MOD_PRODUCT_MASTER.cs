using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSMControl.Modules
{
    public class MOD_PRODUCT_MASTER
    {
        public string ToPerform { get; set; }
        public int PID { get; set; }
        public int InventID { get; set; }  
        public string PName { get; set; }
        public string PCode { get; set; }
        public string PBarcode { get; set; }
        public int? UnitID { get; set; }
        public decimal? UnitQnty { get; set; }
        public int? AltUnitId { get; set; }
        public decimal? AltUnitQnty { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? MRP { get; set; }
        public string Offer { get; set; }
        public string PNote { get; set; }
        public string ProductCategory { get; set; }
        public bool? ActiveStatus { get; set; }
        public int? UserID { get; set; }
        public System.DateTime? DateCreated { get; set; }
        public int? MUserID { get; set; }
        public System.DateTime? ModifiedDate { get; set; }
    }
}
