using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSMControl.DataBase
{

    public class CompanyInfoModel
    { 
        public string DB_Name { get; set; }
        public string DB_Path { get; set; }
    }
    class CreateDB
    {
        public CompanyInfoModel cmpInfo;

        public CreateDB()
        {
            cmpInfo = new CompanyInfoModel();
        }
    }
}
