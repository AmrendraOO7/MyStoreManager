using MSMControl.DataBase;
using MyStoreManager.BillEntry.Purchase;
using MyStoreManager.PreEntry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSMControl
{
   static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        ///
       


        [STAThread]
        static void Main()
        {
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Frm_Server_Entry());
            //Application.Run(new frm_PurchaseOrder());    
        }
    }
}
