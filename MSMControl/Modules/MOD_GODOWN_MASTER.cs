using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSMControl.Modules
{
    public class MOD_GODOWN_MASTER
    {
        public string ToPerform { get; set; }
        public int GodID { get; set; }
        public string GodName { get; set; }
        public string GodCode { get; set; }
        public string GodAddress { get; set; }
        public bool? ActiveStatus { get; set; }
        public int? UserID { get; set; }
        public System.DateTime? DateCreated { get; set; }
        public int? MUserID { get; set; }
        public System.DateTime? ModifiedDate { get; set; }
    }
}
