using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSMControl.Modules
{
    public class MOD_USER_ROLE
    {
        public string ToPerform { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool? RoleStatus { get; set; }
        public int Creator { get; set; }
    }
}
