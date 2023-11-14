using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSMControl.Modules
{
    public class MOD_PRODUCT_TYPE
    {
        public string ToPerform { get; set; }
        public int CatID { get; set; }
        public string Category { get; set; }
        public string CategoryID { get; set; }
        public bool? ActiveStatus { get; set; }
        public int? UserID { get; set; }
        public System.DateTime? DateCreated { get; set; }
        public int? MUserID { get; set; }
        public System.DateTime? ModifiedDate { get; set; }
    }
}
