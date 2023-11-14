using MSMControl.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSMControl.Class
{
    public class ClsIncrement
    {
        public static string AutoIncrement(string Case, string Code)
        {
            var cmdtext = string.Empty;
            var datatable = new DataTable();
            Code = Code.PadRight(2, 'A').ToUpper();
            switch (Case)
            {
                case "Unit":
                    {
                        cmdtext = $@"SELECT  COUNT(SUBSTRING(UnitCode,1,2))+1 UnitCode  FROM MSM.UnitMaster  where SUBSTRING(UnitCode,1,2)='{Code.Substring(0,2)}'";
                        datatable = Execute.ExecuteDataSetOnMain(cmdtext).Tables[0];
                        Code = Code.Substring(0, 2) + datatable.Rows[0]["UnitCode"].ToString().PadLeft(2,'0');
                        break;
                    }
                case "PartyCode":
                    {
                        cmdtext = $@"SELECT  COUNT(SUBSTRING(PartyCode,1,2))+1 PartyCode  FROM MSM.CustomerMaster  where SUBSTRING(PartyCode,1,2)='{Code.Substring(0, 2)}'";
                        datatable = Execute.ExecuteDataSetOnMain(cmdtext).Tables[0];
                        Code = Code.Substring(0, 2) + datatable.Rows[0]["PartyCode"].ToString().PadLeft(2, '0');
                        break;
                    }
                case "CategoryID":
                    {
                        cmdtext = $@"SELECT  COUNT(SUBSTRING(CategoryID,1,2))+1 CategoryID  FROM MSM.ProductCategory  where SUBSTRING(CategoryID,1,2)='{Code.Substring(0, 2)}'";
                        datatable = Execute.ExecuteDataSetOnMain(cmdtext).Tables[0];
                        Code = Code.Substring(0, 2) + datatable.Rows[0]["CategoryID"].ToString().PadLeft(2, '0');
                        break;
                    }
                case "ProductCode":
                    {
                        cmdtext = $@"SELECT  COUNT(SUBSTRING(PCode,1,2))+1 PCode  FROM MSM.ProductMaster  where SUBSTRING(PCode,1,2)='{Code.Substring(0, 2)}'";
                        datatable = Execute.ExecuteDataSetOnMain(cmdtext).Tables[0];
                        Code = Code.Substring(0, 2) + datatable.Rows[0]["PCode"].ToString().PadLeft(2, '0');
                        break;
                    }
                case "Godown":
                    {
                        cmdtext = $@"SELECT  COUNT(SUBSTRING(GodCode,1,2))+1 GodCode  FROM MSM.StoreGodown  where SUBSTRING(GodCode,1,2)='{Code.Substring(0, 2)}'";
                        datatable = Execute.ExecuteDataSetOnMain(cmdtext).Tables[0];
                        Code = Code.Substring(0, 2) + datatable.Rows[0]["GodCode"].ToString().PadLeft(2, '0');
                        break;
                    }
            }
            return Code;
        }

    }
}
