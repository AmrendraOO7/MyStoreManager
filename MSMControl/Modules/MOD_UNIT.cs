using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSMControl.Modules
{
    public class MOD_UNIT
    {
        public string ToPerform { get; set; }
        public int UnitID { get; set; }
        public string Unit { get; set; }
        public string UnitCode { get; set; }
        public bool? ActiveStatus { get; set; }
        public int UserID { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int? MUserID { get; set; }
        public System.DateTime? ModifiedDate { get; set; }
    }
}
