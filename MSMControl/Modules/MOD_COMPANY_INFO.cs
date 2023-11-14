using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSMControl.Modules
{   
    public class MOD_COMPANY_INFO
    {
        public string ToPerform { get; set; }
        public int cid { get; set; }
        public string cname { get; set; }
        public string regno { get; set; }
        public string address { get; set; }
        public string contact { get; set; }
        public string email { get; set; }
        public string city { get; set; }
        public string StateName { get; set; }
        public string country { get; set; }
        public string Location { get; set; }
        public string catalog { get; set; }
    }

    public class MOD_COUNTRY_STATE
    {
        public string ToPerform { get; set; }
        public int CbId { get; set; }
        public string StateName { get; set; }
        public string Country { get; set; }
    }
}
