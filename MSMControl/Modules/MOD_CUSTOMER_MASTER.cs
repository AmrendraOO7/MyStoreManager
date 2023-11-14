using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSMControl.Modules
{
    public class MOD_CUSTOMER_MASTER
    {
        public string ToPerform { get; set; }
        public int CID { get; set; }
        public string PartyName { get; set; }
        public string PartyCode { get; set; }
        public string PartyEmail { get; set; }
        public string PartyCompany { get; set; }
        public string PartyAddress { get; set; }
        public string PartyState { get; set; }
        public string PartyCountry { get; set; }
        public string PartyContact { get; set; }
        public string PartyReg { get; set; }
        public string PartyNote { get; set; }
        public bool? ActiveStatus { get; set; }
        public int UserID { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int? MUserID { get; set; }
        public System.DateTime? ModifiedDate { get; set; }
        
    }
}
