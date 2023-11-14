using MSMControl.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSMControl.Connection
{
    //DateTime myDateTime = DateTime.Now;
    public static class Global
    {
        public static string ServerName;
        public static string InitialCatalogMaster;
        public static string UserId;
        public static string Password;
        public static long CompanyID;
        public static int RoleID;
        public static int YearID;
        public static string CurrentYear;

        //string year = myDateTime.Year.ToString();

        public static string copyrightYear = $"Copyright@ My Store Manager_{DateTime.Now.Year}";//.ToString().Substring(5, 4)}";
        public static string billMessage; // later implement in config file.
        public static string Year = ClsMainMaster.todayMiti();
        public static bool checkDate;
        public static bool checkNote;
        public static bool checkReturnNote;
        public static bool printMessage;
        public static bool autoPrint;
        public static int compType;
        //public static System.Drawing.Color BackgroundColor;

        public static string CompanyName;
        public static string Registration;
        public static string Contact;
        public static string Address;
        public static string City;
        public static string State;
        public static string Country;
        public static string BackgroundColor;

        public static string licenseKey;
        public static int remainingDays;

        public static string InitialCatalogMain;

        public static int LoginID;
        public static string LoginUser;
        public static string UserName;

        public static int IsAdmin;
        public static int CurrentSession;

        public static int IsFormActive;

        //transection check
        public static int purchaseCheck;
        public static int salesCheck;
    }
}
