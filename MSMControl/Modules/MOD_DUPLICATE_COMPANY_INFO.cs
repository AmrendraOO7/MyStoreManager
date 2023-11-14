using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSMControl.Modules
{
    public class MOD_DUPLICATE_COMPANY_INFO
    {
        public string ToPerform { get; set; }
        public int Dup_cid { get; set; }
        public string Dup_cname { get; set; }
        public string Dup_regno { get; set; }
        public string Dup_address { get; set; }
        public string Dup_contact { get; set; }
        public string Dup_email { get; set; }
        public string Dup_city { get; set; }
        public string Dup_country { get; set; }
        public string Dup_catalog { get; set; }
        public string Dup_Location { get; set; }
        public string Dup_StateName { get; set; }
        public int? Dup_UserID { get; set; }
        public System.DateTime? Dup_DateCreated { get; set; }
        public int? Dup_MUserID { get; set; }
        public System.DateTime? Dup_ModifiedDate { get; set; }
    }
}
