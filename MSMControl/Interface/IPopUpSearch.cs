using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSMControl.Interface
{
    public interface IPopUpSearch
    {
        DataTable Get_Country_State(int ID);
        DataTable GetCompanyList(int ID);
    }
}
