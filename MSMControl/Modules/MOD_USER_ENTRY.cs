using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSMControl.Modules
{
    public class MOD_USER_ENTRY
    {
        public string ToPerform { get; set; }
        public int userid { get; set; }
        public string usrname { get; set; }
        public string loginid { get; set; }
        public string password { get; set; }
        public string dept { get; set; }
        public int RoleID { get; set; }
        public bool? ActiveStatus { get; set; }
        public bool? IsAdmin { get; set; }
        public int? ColorID { get; set; }
        public string Background { get; set; }
    }
}
