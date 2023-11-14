using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MSMControl.DataBase;

namespace MSMControl.Connection
{ 
    public class Connection
    {
        public static string Database = Global.ServerName;
        public static string InitialCatalogMaster = Global.InitialCatalogMaster;
        public static string UserId = Global.UserId;
        public static string Password = Global.Password;

        public static string ConnectionMain =>
            $"data source={Global.ServerName};initial catalog={Global.InitialCatalogMain};integrated security=False;Encrypt=False;user id={Global.UserId}; password={Global.Password}";

        public static string ConnectionMaster =>
            $"data source={Global.ServerName};initial catalog=master;integrated security=False;Encrypt=False;user id={Global.UserId}; password={Global.Password}";

        public static string ConnectionLocalMaster =>
            $"data source=(LocalDB)\\My Store Manager;initial catalog=master;integrated security=False;Encrypt=False;user id=MSM; password=msmClientId007";

    };
}

