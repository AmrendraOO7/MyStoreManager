using MSMControl.ClassMiti;
using MSMControl.Connection;
using MSMControl.Interface;
using MSMControl.Modules;
using MSMControl.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSMControl.Class
{
    public class ClsMainMaster : IMainMaster
    {
        public static int backgroundcolor;
        public ClsMainMaster()
        {
            Config = new MOD_CONFIGURATION();
            compInfo = new MOD_COMPANY_INFO();
            dupcompInfo = new MOD_DUPLICATE_COMPANY_INFO();
            ComboInfo = new MOD_COUNTRY_STATE();
            UserRole = new MOD_USER_ROLE();
            UserEntry = new MOD_USER_ENTRY();
            UnitEntry = new MOD_UNIT();
            CustoMaster = new MOD_CUSTOMER_MASTER();
            ProdMaster = new MOD_PRODUCT_MASTER();
            TypeMaster = new MOD_PRODUCT_TYPE();
            GodownMaster = new MOD_GODOWN_MASTER();
            PO_Master = new MOD_PURCHASE_ORDER_MASTER();
            PO_Details = new MOD_PURCHASE_ORDER_DETAILS();
            PE_Master = new MOD_PURCHASE_ENTRY_MASTER();
            PE_Details = new MOD_PURCHASE_ENTRY_DETAILS();
            PR_Master = new MOD_PURCHASE_RETURN_MASTER();
            PR_Details = new MOD_PURCHASE_RETURN_DETAILS();
            SE_Master = new MOD_SALES_ENTRY_MASTER();
            SE_Details = new MOD_SALES_ENTRY_DETAILS();
            SR_Master = new MOD_SALES_RETURN_MASTER();
            SR_Details = new MOD_SALES_RETURN_DETAILS();
            OT_Master = new MOD_ORDER_TICKET_MASTER();
            OT_Details  = new MOD_ORDER_TICKET_DETAILS();
            IC_Master = new MOD_ISSUE_CARD_MASTER();
            IC_Details = new MOD_ISSUE_CARD_DETAILS();
            Start_Processing = new MOD_START_PROCESSING();
        }

        public string Query = string.Empty;
        public MOD_COMPANY_INFO compInfo { get; set; }
        public MOD_DUPLICATE_COMPANY_INFO dupcompInfo { get; set; }
        public MOD_COUNTRY_STATE ComboInfo { get; set; }
        public MOD_USER_ROLE UserRole { get; set; }
        public MOD_USER_ENTRY UserEntry { get; set; }
        public MOD_CONFIGURATION Config { get; set; }
        public MOD_UNIT UnitEntry { get; set; }
        public MOD_CUSTOMER_MASTER CustoMaster { get; set; }
        public MOD_PRODUCT_MASTER ProdMaster { get; set; }
        public MOD_PRODUCT_TYPE TypeMaster { get; set; }
        public MOD_GODOWN_MASTER GodownMaster { get; set; }
        public MOD_PURCHASE_ORDER_MASTER PO_Master { get; set; }
        public MOD_PURCHASE_ORDER_DETAILS PO_Details { get; set; }
        public MOD_PURCHASE_ENTRY_MASTER PE_Master { get; set; }
        public MOD_PURCHASE_ENTRY_DETAILS PE_Details { get; set; }
        public MOD_PURCHASE_RETURN_MASTER PR_Master { get; set; }
        public MOD_PURCHASE_RETURN_DETAILS PR_Details { get; set; }
        public MOD_SALES_ENTRY_MASTER SE_Master { get; set; }
        public MOD_SALES_ENTRY_DETAILS SE_Details { get; set; }
        public MOD_SALES_RETURN_MASTER SR_Master { get; set; }
        public MOD_SALES_RETURN_DETAILS SR_Details { get; set; }
        public MOD_ORDER_TICKET_MASTER OT_Master { get; set; }
        public MOD_ORDER_TICKET_DETAILS OT_Details { get; set; }
        public MOD_ISSUE_CARD_MASTER IC_Master { get; set; }
        public MOD_ISSUE_CARD_DETAILS IC_Details { get; set; }
        public MOD_START_PROCESSING Start_Processing { get; set; }

        #region Fetch Integer Value
        public static int getInt(string tableName, string columnName)
        {
            var Query = $@"SELECT CAST(ISNULL(MAX({columnName}),0) AS INT) + 1 MaxId FROM {tableName} ";
            var dt = Execute.ExecuteDataSetOnMain(Query).Tables[0];
            return (int)dt.Rows[0]["MaxId"];
        }

        public static long getLong(string tableName, string columnName)
        {
            var Query = $@"SELECT CAST(ISNULL(MAX({columnName}),0) AS LONG) + 1 MaxId FROM {tableName} ";
            var dt = Execute.ExecuteDataSetOnMain(Query).Tables[0];
            return (long)dt.Rows[0]["MaxId"];
        }

        public static decimal getInvData(int id)
        {
            try
            {
                var Query = $@"SELECT Quantity FROM MSM.ProductInventory WHERE prodID = {id}";
                var dt = Execute.ExecuteDataSetOnMain(Query).Tables[0];
                return (decimal)dt.Rows[0]["Quantity"];
            }
            catch
            {
                return 0;
            }

        }

        public static int getIntMaster(string tableName, string columnName)
        {
            var Query = $@"SELECT CAST(ISNULL(MAX({columnName}),0) AS INT) + 1 MaxId FROM {tableName} ";
            var dt = Execute.ExecuteDataSetOnLocalMaster(Query).Tables[0];
            return (int)dt.Rows[0]["MaxId"];
        }

        public static long getLongMaster(string tableName, string columnName)
        {
            var Query = $@"SELECT CAST(ISNULL(MAX({columnName}),0) AS LONG) + 1 MaxId FROM {tableName} ";
            var dt = Execute.ExecuteDataSetOnLocalMaster(Query).Tables[0];
            return (long)dt.Rows[0]["MaxId"];
        }

        public string GetMiti(string EngDate)
        {
            Miti npDate = ConvertToMiti.GetMiti(DateTime.Parse(EngDate));
            return npDate.npDate;
        }
        //function for getting Current Nepali Year for bill creation.
        public static string todayMiti()
        {
            Miti todaysMiti = ConvertToMiti.GetMiti(DateTime.Parse(DateTime.Now.ToShortDateString()));
            return todaysMiti.npDate.Substring(0, 4);
        }

        public static decimal getproductQuantity(int id, string voucherNo, int PID, string columnName_PK, string columnName, string columnName_PID, string tableName )
        {
            var Query = $@"SELECT t.Quantiy AS quantity FROM {tableName} t WHERE SAID = {id} AND {columnName} = '{voucherNo}' AND PID = {PID};";
            var dt = Execute.ExecuteDataSetOnMain(Query).Tables[0];
            return (decimal)dt.Rows[0]["quantity"];
        }
        #endregion

        #region Insert--Update--Delete

        public int UserRoleSetup()
        {
            try
            {
                var cmdtext = new StringBuilder();
                if (UserRole.ToPerform.ToUpper() is null) return 0;
                switch (UserRole.ToPerform.ToUpper())
                {
                    case "INSERT":
                        {
                            cmdtext.Append(@"insert into [MSM].[UsersRole] ([RoleId],[RoleName],[RoleStatus],[Creator]) VALUES(");
                            cmdtext.Append(UserRole.RoleId);
                            cmdtext.Append(!string.IsNullOrEmpty(UserRole.RoleName) ? $@",'{UserRole.RoleName}'" : @",'Error'");
                            cmdtext.Append(UserRole.RoleStatus is true ? ",1," : ",0,");
                            cmdtext.Append(!string.IsNullOrEmpty(UserRole.Creator.ToString()) ? $@"{UserRole.Creator})":"NULL)");
                            break;
                        }
                    case "UPDATE":
                        {
                            cmdtext.Append(@"UPDATE [MSM].[UsersRole] SET ");
                            cmdtext.Append(!string.IsNullOrEmpty(UserRole.RoleName) ? $@"RoleName ='{UserRole.RoleName}'," : @"RoleName = 'Error',");
                            cmdtext.Append(UserRole.RoleStatus is true ? @"RoleStatus= 1": @"RoleStatus= 0"); 
                            cmdtext.Append(!string.IsNullOrEmpty(UserRole.Creator.ToString()) ? $@",Creator = {UserRole.Creator} " : ",Creator = NULL ");
                            cmdtext.Append($@"WHERE RoleId = {UserRole.RoleId}");

                            break;
                        }
                    case "DELETE":
                        {
                            cmdtext.Append($@"DELETE [MSM].[UsersRole] WHERE RoleId = {UserRole.RoleId}");
                            break;
                        }
                }
                var IsOk = Execute.ExecuteNonQueryOnMain(cmdtext.ToString());
                if (IsOk <= 0) return 0;
                return IsOk;
            }
            catch
            {
                return 0;
            }
            
            
            
        }

        public int ConfigurationSetup()
        {
            var cmdtext = new StringBuilder();
            try
            {
                if (Config.ToPerform is "Insert" || Config.ToPerform is "Delete") return 0;
                switch (Config.ToPerform.ToUpper())
                {
                    case "UPDATE":
                        {
                            //config setup
                            cmdtext.Append(@"UPDATE [MSM].[Configuration] SET ");
                            cmdtext.Append($@"[YearID] = { Config.YearID}");
                            cmdtext.Append(!string.IsNullOrEmpty($@"{Config.Current_Year}") ? $@",[Current_Year] = '{Config.Current_Year}'" : ",[Current_Year] = NULL");
                            cmdtext.Append(!string.IsNullOrEmpty(Config.VAT.ToString()) ? $@",[VAT] = {Config.VAT}" : $@",[ColorID] = NULL");
                            cmdtext.Append(!string.IsNullOrEmpty(Config.Discount.ToString()) ? $@",[Discount] = '{Config.Discount}'" : $@",[ColorID] = NULL");   /*[userid] = {Global.LoginID};*/
                            cmdtext.Append(Config.checkDate is true ? ",[checkDate] = '1'" : ",[checkDate] = '0'");
                            cmdtext.Append(Config.notes is true ? ",[notes] = '1'" : ",[notes] = '0'");
                            cmdtext.Append(Config.returnNotes is true ? ",[returnNotes] = '1'" : ",[returnNotes] = '0'");
                            cmdtext.Append(Config.printMessage is true ? ",[printMessage] = '1'" : ",[printMessage] = '0'");
                            cmdtext.Append(Config.autoPrint is true ? ",[autoPrint] = '1'" : ",[autoPrint] = '0'");
                            cmdtext.Append(!string.IsNullOrEmpty($@"{Config.compType}") ? $@",[compType] = '{Config.compType}'" : ",[compType] = 0");
                            cmdtext.Append(!string.IsNullOrEmpty($@"{Config.billMsg}") ? $@",[billMsg] = '{Config.billMsg}'" : ",[Current_Year] = NULL");
                            cmdtext.Append($@" WHERE [CID] = {Config.CID}; ");

                            //admin permission setup
                            cmdtext.Append($@"UPDATE [MSM].[UsersMaster] SET ");
                            cmdtext.Append(Config.IsAdmin is true ? "[IsAdmin] = '1'" : "[IsAdmin] = '0'");
                            cmdtext.Append(!string.IsNullOrEmpty(Config.ColorID.ToString()) ? $@",[ColorID] = {Config.ColorID}" : $@",[ColorID] = 57");
                            cmdtext.Append(!string.IsNullOrEmpty(Config.Background.ToString()) ? $@",[Background] = '{Config.Background}'" : $@",[ColorID] = 'Indigo'");
                            cmdtext.Append($@" WHERE [userid] = {Global.LoginID};");
                            break;
                        }  
                }
                var IsOk = Execute.ExecuteNonQueryOnMain(cmdtext.ToString());
                if (IsOk <= 0) return 0;
                return IsOk;
            }
            catch
            {
                return 0;
            }
        }
        public int CompanyInfo()
        {
            var cmdtext = new StringBuilder();
            var cmdtextMaster = new StringBuilder();
            try
            {
                if (compInfo.ToPerform == "") return 0;
                switch (compInfo.ToPerform.ToUpper())
                {
                    case "INSERT":
                        {             
                            cmdtextMaster.Append($@"INSERT INTO [dbo].[master.CompanyMasterInfo] ([cid],[cname], [regno], [address], [contact], [email], [city], [country], [catalog], [Location],[StateName]) VALUES(");
                            cmdtextMaster.Append(!string.IsNullOrEmpty(compInfo.cid.ToString()) ? $"{compInfo.cid}," : "NULL,");
                            cmdtextMaster.Append(!string.IsNullOrEmpty(compInfo.cname) ? $"'{compInfo.cname}'," : "'Error',");
                            cmdtextMaster.Append(!string.IsNullOrEmpty(compInfo.regno) ? $"'{compInfo.regno}'," : "'NULL',");
                            cmdtextMaster.Append(!string.IsNullOrEmpty(compInfo.address) ? $"'{compInfo.address}'," : "'NULL',");
                            cmdtextMaster.Append(!string.IsNullOrEmpty(compInfo.contact) ? $"'{compInfo.contact}'," : "'NULL',");
                            cmdtextMaster.Append(!string.IsNullOrEmpty(compInfo.email) ? $"'{compInfo.email}'," : "'NULL',");
                            cmdtextMaster.Append(!string.IsNullOrEmpty(compInfo.city) ? $"'{compInfo.city}'," : "'NULL',");
                            cmdtextMaster.Append(!string.IsNullOrEmpty(compInfo.country) ? $"'{compInfo.country}'," : "'NULL',");
                            cmdtextMaster.Append(!string.IsNullOrEmpty(compInfo.catalog) ? $"'{compInfo.catalog}'," : "'NULL',");
                            cmdtextMaster.Append(!string.IsNullOrEmpty(compInfo.Location) ? $"'{compInfo.Location}'," : "'NULL',");
                            cmdtextMaster.Append(!string.IsNullOrEmpty(compInfo.StateName) ? $"'{compInfo.StateName}');" : "'NULL');");

                            cmdtext.Append($@"INSERT INTO [MSM].[CompanyMasterInfo]([Dup_cid],[Dup_cname],[Dup_regno],[Dup_address],[Dup_contact],[Dup_email],[Dup_city],[Dup_country],[Dup_catalog],[Dup_Location],[Dup_StateName],[Dup_UserID],[Dup_DateCreated],[Dup_MUserID],[Dup_ModifiedDate])VALUES(");
                            cmdtext.Append(!string.IsNullOrEmpty(dupcompInfo.Dup_cid.ToString()) ? $"{dupcompInfo.Dup_cid}," : "NULL,");
                            cmdtext.Append(!string.IsNullOrEmpty(dupcompInfo.Dup_cname) ? $"'{dupcompInfo.Dup_cname}'," : "'Error',");
                            cmdtext.Append(!string.IsNullOrEmpty(dupcompInfo.Dup_regno) ? $"'{dupcompInfo.Dup_regno}'," : "'NULL',");
                            cmdtext.Append(!string.IsNullOrEmpty(dupcompInfo.Dup_address) ? $"'{dupcompInfo.Dup_address}'," : "'NULL',");
                            cmdtext.Append(!string.IsNullOrEmpty(dupcompInfo.Dup_contact) ? $"'{dupcompInfo.Dup_contact}'," : "'NULL',");
                            cmdtext.Append(!string.IsNullOrEmpty(dupcompInfo.Dup_email) ? $"'{dupcompInfo.Dup_email}'," : "'NULL',");
                            cmdtext.Append(!string.IsNullOrEmpty(dupcompInfo.Dup_city) ? $"'{dupcompInfo.Dup_city}'," : "'NULL',");
                            cmdtext.Append(!string.IsNullOrEmpty(dupcompInfo.Dup_country) ? $"'{dupcompInfo.Dup_country}'," : "'NULL',");
                            cmdtext.Append(!string.IsNullOrEmpty(dupcompInfo.Dup_catalog) ? $"'{dupcompInfo.Dup_catalog}'," : "'NULL',");
                            cmdtext.Append(!string.IsNullOrEmpty(dupcompInfo.Dup_Location) ? $"'{dupcompInfo.Dup_Location}'," : "'NULL',");
                            cmdtext.Append(!string.IsNullOrEmpty(dupcompInfo.Dup_StateName) ? $"'{dupcompInfo.Dup_StateName}'," : "'NULL',");
                            cmdtext.Append(!string.IsNullOrEmpty(dupcompInfo.Dup_UserID.ToString())?$"'{dupcompInfo.Dup_UserID}',": "'NULL',");
                            cmdtext.Append("GETDATE(),NULL,NULL);");


                            break;
                        }
                    case "UPDATE":
                        {
                            cmdtextMaster.Append(@"UPDATE[dbo].[master.CompanyMasterInfo] SET ");
                            cmdtextMaster.Append(!string.IsNullOrEmpty(compInfo.cname) ? $"[cname] ='{compInfo.cname}'," : "[cname] ='Error',");
                            cmdtextMaster.Append(!string.IsNullOrEmpty(compInfo.regno) ? $"[regno] ='{compInfo.regno}'," : "[regno] ='NULL',");
                            cmdtextMaster.Append(!string.IsNullOrEmpty(compInfo.address) ? $"[address] ='{compInfo.address}'," : "[address] ='NULL',");
                            cmdtextMaster.Append(!string.IsNullOrEmpty(compInfo.contact) ? $"[contact] ='{compInfo.contact}'," : "[contact] ='NULL',");
                            cmdtextMaster.Append(!string.IsNullOrEmpty(compInfo.email) ? $"[email] = '{compInfo.email}'," : "[email] = 'NULL',");
                            cmdtextMaster.Append(!string.IsNullOrEmpty(compInfo.city) ? $"[city] ='{compInfo.city}'," : "[city] ='NULL',");
                            cmdtextMaster.Append(!string.IsNullOrEmpty(compInfo.country) ? $"[country] ='{compInfo.country}'," : "[country] ='NULL',");
                            cmdtextMaster.Append(!string.IsNullOrEmpty(compInfo.catalog) ? $"[catalog] ='{compInfo.catalog}'," : "[catalog] ='NULL',");
                            cmdtextMaster.Append(!string.IsNullOrEmpty(compInfo.Location) ? $"[Location] ='{compInfo.Location}'," : "[Location] ='NULL',");
                            cmdtextMaster.Append(!string.IsNullOrEmpty(compInfo.StateName) ? $"[StateName] ='{compInfo.StateName}'" : "[StateName] ='NULL'");
                            cmdtextMaster.Append($@"WHERE cid={compInfo.cid};");

                            cmdtext.Append(@"UPDATE [MSM].[CompanyMasterInfo] SET ");
                            cmdtext.Append(!string.IsNullOrEmpty(dupcompInfo.Dup_cname) ? $"[Dup_cname] ='{dupcompInfo.Dup_cname}'" : "[Dup_cname] ='Error'");
                            cmdtext.Append(!string.IsNullOrEmpty(dupcompInfo.Dup_regno) ? $",[Dup_regno] ='{dupcompInfo.Dup_regno}'" : ",[Dup_regno] ='NULL'");
                            cmdtext.Append(!string.IsNullOrEmpty(dupcompInfo.Dup_address) ? $",[Dup_address] ='{dupcompInfo.Dup_address}'" : ",[Dup_address] ='NULL'");
                            cmdtext.Append(!string.IsNullOrEmpty(dupcompInfo.Dup_contact) ? $",[Dup_contact] = '{dupcompInfo.Dup_contact}'" : ",[Dup_contact] = 'NULL'");
                            cmdtext.Append(!string.IsNullOrEmpty(dupcompInfo.Dup_email) ? $",[Dup_email] = '{dupcompInfo.Dup_email}'" : ",[Dup_email] = 'NULL'");
                            cmdtext.Append(!string.IsNullOrEmpty(dupcompInfo.Dup_city) ? $",[Dup_city] = '{dupcompInfo.Dup_city}'" : ",[Dup_city] = 'NULL'");
                            cmdtext.Append(!string.IsNullOrEmpty(dupcompInfo.Dup_country) ? $",[Dup_country] ='{dupcompInfo.Dup_country}'" : ",[Dup_country] ='NULL'");
                            cmdtext.Append(!string.IsNullOrEmpty(dupcompInfo.Dup_catalog) ? $",[Dup_catalog] = '{dupcompInfo.Dup_catalog}'" : ",[Dup_catalog] = 'NULL'");
                            cmdtext.Append(!string.IsNullOrEmpty(dupcompInfo.Dup_Location) ? $",[Dup_Location] ='{dupcompInfo.Dup_Location}'" : ",[Dup_Location] ='NULL'");
                            cmdtext.Append(!string.IsNullOrEmpty(dupcompInfo.Dup_StateName) ? $",[Dup_StateName] ='{dupcompInfo.Dup_StateName}'" : ",[Dup_StateName] ='NULL'");
                            cmdtext.Append(!string.IsNullOrEmpty(dupcompInfo.Dup_UserID.ToString()) ? $",[Dup_MUserID] = '{dupcompInfo.Dup_UserID}'" : ",[Dup_MUserID] ='NULL'");
                            cmdtext.Append(",[Dup_ModifiedDate] = GETDATE()");
                            cmdtext.Append($@" WHERE Dup_cid={dupcompInfo.Dup_cid};");

                            break;
                        }
                    case "DELETE":
                        {
                            cmdtextMaster.Append($@"DELETE FROM [dbo].[master.CompanyMasterInfo] WHERE cid = {compInfo.cid};");
                            cmdtext.Append($@"DELETE FROM [MSM].[CompanyMasterInfo] WHERE Dup_cid = {dupcompInfo.Dup_cid};");
                            break;
                        }
                }
                var IsMasterOk = Execute.ExecuteNonQueryLocalMaster(cmdtextMaster.ToString());
                var IsMainOk = Execute.ExecuteNonQueryOnMain(cmdtext.ToString());
                if (IsMasterOk <= 0) return 0;
                return IsMasterOk;
            }
            catch
            {
                return 0; 
            }
        }

        public int ComboBoxValueTaskDone()
        {
            var cmdtext = new StringBuilder();
            try
            {
                switch(ComboInfo.ToPerform.ToUpper())
                {
                    case "INSERT":
                        {
                            cmdtext.Append (@"INSERT INTO [dbo].[master.ComboBoxVal] ([StateName], [Country]) VALUES (" );
                            cmdtext.Append(!string.IsNullOrEmpty(ComboInfo.StateName.ToString())? $"'{ComboInfo.StateName.ToString()}'," : " NULL," );
                            cmdtext.Append(!string.IsNullOrEmpty(ComboInfo.Country.ToString()) ? $"'{ComboInfo.Country.ToString()}')" : " NULL)");                            
                            break;
                        }
                    case "UPDATE":
                        {
                            cmdtext.Append("UPDATE [dbo].[master.ComboBoxVal] SET ");
                            cmdtext.Append(!string.IsNullOrEmpty(ComboInfo.StateName.ToString()) ? $"StateName = '{ComboInfo.StateName.ToString()}'," : "StateName = NULL,");
                            cmdtext.Append(!string.IsNullOrEmpty(ComboInfo.Country.ToString()) ? $"Country = '{ComboInfo.Country.ToString()} '" : $"Country = NULL ");
                            cmdtext.Append($@"WHERE CbId = {ComboInfo.CbId};");
                            break;
                        }
                    case "DELETE":
                        {
                            cmdtext.Append("Delete [dbo].[master.ComboBoxVal] where CbId = ");
                            cmdtext.Append($@"{ComboInfo.CbId};");
                            break;
                        }
                }
                var IsOk = Execute.ExecuteNonQueryLocalMaster(cmdtext.ToString());
                if (IsOk <= 0) return 0;
                return IsOk;
            }
            catch
            {
                return 0;
            }
        }

        public int UserEntrySetup()
        {
            var cmdText = new StringBuilder();
            if (UserEntry.ToPerform is null) return 0;
            try
            {
                switch (UserEntry.ToPerform.ToUpper())
                {

                    case "INSERT":
                        {
                            cmdText.Append(@"INSERT INTO [MSM].[UsersMaster]([userid],[usrname],[loginid],[password],[dept],[RoleID],[ActiveStatus],[IsAdmin],[ColorID],[Background]) VALUES (");
                            cmdText.Append(!string.IsNullOrEmpty(UserEntry.userid.ToString()) ? $@"{UserEntry.userid}," : "NULL,");
                            cmdText.Append(!string.IsNullOrEmpty(UserEntry.usrname.ToString()) ? $@"'{UserEntry.usrname}'," : "NULL,");
                            cmdText.Append(!string.IsNullOrEmpty(UserEntry.loginid.ToString()) ? $@"'{UserEntry.loginid}'," : "NULL,");
                            cmdText.Append(!string.IsNullOrEmpty(UserEntry.password.ToString()) ? $@"'{UserEntry.password}'," : "NULL,");
                            cmdText.Append(!string.IsNullOrEmpty(UserEntry.dept.ToString()) ? $@"'{UserEntry.dept}'," : "NULL,");
                            cmdText.Append($@"{UserEntry.RoleID},");
                            cmdText.Append($@"CAST('{UserEntry.ActiveStatus}' AS BIT) ");
                            cmdText.Append(!string.IsNullOrEmpty(UserEntry.IsAdmin.ToString()) ? $@",CAST('{UserEntry.IsAdmin}' AS BIT) " : ",0");
                            cmdText.Append(!string.IsNullOrEmpty(UserEntry.ColorID.ToString()) ? $@",{UserEntry.ColorID}" : ",57");
                            cmdText.Append(!string.IsNullOrEmpty(UserEntry.Background) ? $@",'{UserEntry.Background}')" : ",'Indigo')");
                            break;
                        }
                    case "UPDATE":
                        {
                            cmdText.Append(@"UPDATE [MSM].[UsersMaster] SET ");
                           // cmdText.Append(!string.IsNullOrEmpty(UserEntry.userid.ToString()) ? $@"[usrname] = {UserEntry.userid}," : @"[usrname] = NULL,");
                            cmdText.Append(!string.IsNullOrEmpty(UserEntry.usrname.ToString()) ? $@"[usrname] = '{UserEntry.usrname}'," : @"[usrname] = NULL,");
                            cmdText.Append(!string.IsNullOrEmpty(UserEntry.loginid.ToString()) ? $@"[loginid] = '{UserEntry.loginid}'," : @"[loginid] = NULL,");
                            cmdText.Append(!string.IsNullOrEmpty(UserEntry.password.ToString()) ? $@"[password] = '{UserEntry.password}'," : @"[password] = NULL,");
                            cmdText.Append(!string.IsNullOrEmpty(UserEntry.dept.ToString()) ? $@"[dept] = '{UserEntry.dept}'," : @"[dept] = NULL,");
                            cmdText.Append($@"[RoleID] = {UserEntry.RoleID},");
                            cmdText.Append($@"[ActiveStatus] = CAST('{UserEntry.ActiveStatus}' AS BIT)");
                            cmdText.Append($@"WHERE [userid] = {UserEntry.userid}");
                            break;
                        }
                    case "DELETE":
                        {
                            cmdText.Append($@"DELETE FROM [MSM].[UsersMaster] WHERE [userid] = {UserEntry.userid}");
                            break;
                        }
                }
                var IsOk = Execute.ExecuteNonQueryOnMain(cmdText.ToString());
                if (IsOk <= 0) return 0;
                return IsOk;
            }
            catch
            {
                return 0;
            }
            
        }

        public int GodownSetup()
        {
            var cmdText = new StringBuilder();
            if (GodownMaster.ToPerform is null) return 0;
            try
            {
                switch (GodownMaster.ToPerform.ToUpper())
                {

                    case "INSERT":
                        {
                            cmdText.Append("INSERT INTO [MSM].[StoreGodown]([GodID],[GodName],[GodCode],[GodAddress],[ActiveStatus],[UserID],[DateCreated],[MUserID],[ModifiedDate]) VALUES (");
                            cmdText.Append(!string.IsNullOrEmpty(GodownMaster.GodID.ToString()) ? $@"{GodownMaster.GodID}" : "NULL");
                            cmdText.Append(!string.IsNullOrEmpty(GodownMaster.GodName.ToString()) ? $@",'{GodownMaster.GodName}'" : ",NULL");
                            cmdText.Append(!string.IsNullOrEmpty(GodownMaster.GodCode.ToString()) ? $@",'{GodownMaster.GodCode}'" : ",NULL");
                            cmdText.Append(!string.IsNullOrEmpty(GodownMaster.GodAddress.ToString()) ? $@",'{GodownMaster.GodAddress}'" : ",NULL");
                            cmdText.Append($@",CAST('{GodownMaster.ActiveStatus}' AS BIT)");
                            cmdText.Append(!string.IsNullOrEmpty(GodownMaster.UserID.ToString()) ? $@",{GodownMaster.UserID}" : ",NULL");
                            cmdText.Append(",GETDATE(),NULL,NULL)");
                            break;
                        }
                    case "UPDATE":
                        {
                            cmdText.Append("UPDATE [MSM].[StoreGodown] SET ");
                            cmdText.Append(!string.IsNullOrEmpty(GodownMaster.GodName.ToString()) ? $@"[GodName] ='{GodownMaster.GodName}'" : "[GodName] = NULL");
                            cmdText.Append(!string.IsNullOrEmpty(GodownMaster.GodCode.ToString()) ? $@",[GodCode] ='{GodownMaster.GodCode}'" : ",[GodCode] = NULL");
                            cmdText.Append(!string.IsNullOrEmpty(GodownMaster.GodAddress.ToString()) ? $@",[GodAddress] ='{GodownMaster.GodAddress}'" : ",[GodAddress] = NULL");
                            cmdText.Append($@",[ActiveStatus] = CAST('{GodownMaster.ActiveStatus}' AS BIT)");
                            cmdText.Append(!string.IsNullOrEmpty(GodownMaster.UserID.ToString()) ? $@",MUserID = {GodownMaster.UserID}" : ",MUserID = NULL");
                            cmdText.Append(",[ModifiedDate] = GETDATE() ");
                            cmdText.Append($@"WHERE GodID = {GodownMaster.GodID}");
                            break;
                        }
                    case "DELETE":
                        {
                            cmdText.Append($@"DELETE FROM [MSM].[StoreGodown] WHERE GodID = {GodownMaster.GodID}");
                            break;
                        }
                }
                var IsOk = Execute.ExecuteNonQueryOnMain(cmdText.ToString());
                if (IsOk <= 0) return 0;
                return IsOk;
            }
            catch
            {
                return 0;
            }
        }

        public int GetUnitSetup()
        {
            var cmdText = new StringBuilder();
            if (UnitEntry.ToPerform is null) return 0;
            try
            {
                switch (UnitEntry.ToPerform.ToUpper())
                {

                    case "INSERT":
                        {
                            cmdText.Append("INSERT INTO [MSM].[UnitMaster] ([UnitID],[Unit],[UnitCode],[ActiveStatus],[UserID],[DateCreated],[MUserID],[ModifiedDate]) VALUES (");
                            cmdText.Append(!string.IsNullOrEmpty(UnitEntry.UnitID.ToString()) ? $@"{UnitEntry.UnitID}" : "NULL");
                            cmdText.Append(!string.IsNullOrEmpty(UnitEntry.Unit.ToString()) ? $@",'{UnitEntry.Unit}'" : ",NULL");
                            cmdText.Append(!string.IsNullOrEmpty(UnitEntry.UnitCode.ToString()) ? $@",'{UnitEntry.UnitCode}'" : ",NULL");
                            cmdText.Append($@",CAST('{UnitEntry.ActiveStatus}' AS BIT)");
                            cmdText.Append(!string.IsNullOrEmpty(UnitEntry.UserID.ToString()) ? $@",{UnitEntry.UserID}" : ",NULL");
                            cmdText.Append(",GETDATE(),NULL,NULL)");
                            break;
                        }
                    case "UPDATE":
                        {
                            cmdText.Append("UPDATE [MSM].[UnitMaster] SET ");
                            //cmdText.Append(!string.IsNullOrEmpty(UnitEntry.UnitID.ToString()) ? $@"{UnitEntry.UnitID}" : "NULL");
                            cmdText.Append(!string.IsNullOrEmpty(UnitEntry.Unit.ToString()) ? $@"Unit ='{UnitEntry.Unit}'" : "Unit = NULL");
                            cmdText.Append(!string.IsNullOrEmpty(UnitEntry.UnitCode.ToString()) ? $@",UnitCode ='{UnitEntry.UnitCode}'" : ",UnitCode = NULL");
                            cmdText.Append($@",ActiveStatus = CAST('{UnitEntry.ActiveStatus}' AS BIT)");
                            cmdText.Append(!string.IsNullOrEmpty(UnitEntry.UserID.ToString()) ? $@",MUserID = {UnitEntry.UserID}" : ",MUserID = NULL");
                            cmdText.Append(",[ModifiedDate] = GETDATE() ");
                            cmdText.Append($@"WHERE UnitID = {UnitEntry.UnitID}");
                            break;
                        }
                    case "DELETE":
                        {
                            cmdText.Append($@"DELETE FROM [MSM].[UnitMaster] WHERE UnitID = {UnitEntry.UnitID}");
                            break;
                        }
                }
                var IsOk = Execute.ExecuteNonQueryOnMain(cmdText.ToString());
                if (IsOk <= 0) return 0;
                return IsOk;
            }
            catch
            {
                return 0;
            }

        }


        public int GetCustomerSetup()
        {
            try
            {
                var cmdText = new StringBuilder();
                if (CustoMaster.ToPerform == null) return 0;
                switch (CustoMaster.ToPerform.ToUpper())
                {
                    case "INSERT":
                        {
                            cmdText.Append("INSERT INTO [MSM].[CustomerMaster]([CID],[PartyName],[PartyCode],[PartyEmail],[PartyCompany],[PartyAddress],[PartyState],[PartyCountry],[PartyContact],[PartyReg],[PartyNote],[ActiveStatus],[UserID],[DateCreated],[MUserID],[ModifiedDate])VALUES (");
                            cmdText.Append(!string.IsNullOrEmpty(CustoMaster.CID.ToString()) ? $@"{CustoMaster.CID}":"NULL");
                            cmdText.Append(!string.IsNullOrEmpty(CustoMaster.PartyName.ToString()) ? $@",'{CustoMaster.PartyName}'" : ",NULL");
                            cmdText.Append(!string.IsNullOrEmpty(CustoMaster.PartyCode.ToString()) ? $@",'{CustoMaster.PartyCode}'" : ",NULL");
                            cmdText.Append(!string.IsNullOrEmpty(CustoMaster.PartyEmail.ToString()) ? $@",'{CustoMaster.PartyEmail}'" : ",NULL");
                            cmdText.Append(!string.IsNullOrEmpty(CustoMaster.PartyCompany.ToString()) ? $@",'{CustoMaster.PartyCompany}'" : ",NULL");
                            cmdText.Append(!string.IsNullOrEmpty(CustoMaster.PartyAddress.ToString()) ? $@",'{CustoMaster.PartyAddress}'" : ",NULL");
                            cmdText.Append(!string.IsNullOrEmpty(CustoMaster.PartyState.ToString()) ? $@",'{CustoMaster.PartyState}'" : ",NULL");
                            cmdText.Append(!string.IsNullOrEmpty(CustoMaster.PartyCountry.ToString()) ? $@",'{CustoMaster.PartyCountry}'" : ",NULL");
                            cmdText.Append(!string.IsNullOrEmpty(CustoMaster.PartyContact.ToString()) ? $@",'{CustoMaster.PartyContact}'" : ",NULL");
                            cmdText.Append(!string.IsNullOrEmpty(CustoMaster.PartyReg.ToString()) ? $@",'{CustoMaster.PartyReg}'" : ",NULL");
                            cmdText.Append(!string.IsNullOrEmpty(CustoMaster.PartyNote.ToString()) ? $@",'{CustoMaster.PartyNote}'" : ",NULL");
                            cmdText.Append($@",CAST('{CustoMaster.ActiveStatus}' AS BIT)");
                            cmdText.Append(!string.IsNullOrEmpty(CustoMaster.UserID.ToString()) ? $@",{CustoMaster.UserID}" : ",NULL");
                            cmdText.Append(",GETDATE(),NULL,NULL)");
                            break;
                        }
                    case "UPDATE":
                        {
                            cmdText.Append("UPDATE [MSM].[CustomerMaster] SET ");
                            cmdText.Append(!string.IsNullOrEmpty(CustoMaster.PartyName.ToString()) ? $@"[PartyName] = '{CustoMaster.PartyName}'" : "[PartyName] = NULL");
                            cmdText.Append(!string.IsNullOrEmpty(CustoMaster.PartyCode.ToString()) ? $@",[PartyCode] = '{CustoMaster.PartyCode}'" : ",[PartyCode] = NULL");
                            cmdText.Append(!string.IsNullOrEmpty(CustoMaster.PartyEmail.ToString()) ? $@",[PartyEmail] = '{CustoMaster.PartyEmail}'" : ",[PartyEmail] = NULL");
                            cmdText.Append(!string.IsNullOrEmpty(CustoMaster.PartyCompany.ToString()) ? $@",[PartyCompany] = '{CustoMaster.PartyCompany}'" : ",[PartyCompany] = NULL");
                            cmdText.Append(!string.IsNullOrEmpty(CustoMaster.PartyAddress.ToString()) ? $@",[PartyAddress] = '{CustoMaster.PartyAddress}'" : ",[PartyAddress] = NULL");
                            cmdText.Append(!string.IsNullOrEmpty(CustoMaster.PartyState.ToString()) ? $@",[PartyState] = '{CustoMaster.PartyState}'" : ",[PartyState] = NULL");
                            cmdText.Append(!string.IsNullOrEmpty(CustoMaster.PartyCountry.ToString()) ? $@",[PartyCountry] = '{CustoMaster.PartyCountry}'" : ",[PartyCountry] = NULL");
                            cmdText.Append(!string.IsNullOrEmpty(CustoMaster.PartyContact.ToString()) ? $@",[PartyContact] = '{CustoMaster.PartyContact}'" : ",[PartyContact] = NULL");
                            cmdText.Append(!string.IsNullOrEmpty(CustoMaster.PartyReg.ToString()) ? $@",[PartyReg] = '{CustoMaster.PartyReg}'" : ",[PartyReg] = NULL");
                            cmdText.Append(!string.IsNullOrEmpty(CustoMaster.PartyNote.ToString()) ? $@",[PartyNote] = '{CustoMaster.PartyNote}'" : ",[PartyNote] = NULL");
                            cmdText.Append($@",ActiveStatus = CAST('{CustoMaster.ActiveStatus}' AS BIT)");
                            cmdText.Append(!string.IsNullOrEmpty(CustoMaster.UserID.ToString()) ? $@",[MUserID] = {CustoMaster.UserID}" : ",[MUserID] = NULL");
                            cmdText.Append(",[ModifiedDate] = GETDATE()");
                            cmdText.Append($@"WHERE [CID] =  {CustoMaster.CID}");
                            break;
                        }
                    case "DELETE":
                        {
                            cmdText.Append($@"DELETE FROM [MSM].[CustomerMaster] WHERE [CID] =  {CustoMaster.CID}");
                            break;
                        }
                }
                var IsOk = Execute.ExecuteNonQueryOnMain(cmdText.ToString());
                if (IsOk <= 0) return 0;
                return IsOk;
            }
            catch
            {
                return 0;
            }

        }

        public int GetProductSetup()
        {
            try
            {
                var cmdText = new StringBuilder();
                if (ProdMaster.ToPerform == null) return 0;
                switch (ProdMaster.ToPerform.ToUpper())
                {
                    case "INSERT":
                        {
                            cmdText.Append("INSERT INTO [MSM].[ProductMaster]([PID],[PName],[PCode],[PBarcode],[UnitID],[UnitQnty],[AltUnitId],[AltUnitQnty],[PurchasePrice],[MRP],[Offer],[PNote],[ProductCategory],[ActiveStatus],[UserID],[DateCreated],[MUserID],[ModifiedDate]) VALUES (");
                            cmdText.Append(!string.IsNullOrEmpty(ProdMaster.PID.ToString())? $@"{ProdMaster.PID}" : "NULL");
                            cmdText.Append(!string.IsNullOrEmpty(ProdMaster.PName.ToString()) ? $@",'{ProdMaster.PName}'" : ",NULL");
                            cmdText.Append(!string.IsNullOrEmpty(ProdMaster.PCode.ToString()) ? $@",'{ProdMaster.PCode}'" : ",NULL");
                            cmdText.Append(!string.IsNullOrEmpty(ProdMaster.PBarcode.ToString()) ? $@",'{ProdMaster.PBarcode}'" : ",NULL");
                            cmdText.Append(!string.IsNullOrEmpty(ProdMaster.UnitID.ToString()) ? $@",{ProdMaster.UnitID}" : ",NULL");
                            cmdText.Append(!string.IsNullOrEmpty(ProdMaster.UnitQnty.ToString()) ? $@",{ProdMaster.UnitQnty}" : ",NULL");
                            cmdText.Append(!string.IsNullOrEmpty(ProdMaster.AltUnitId.ToString()) ? $@",{ProdMaster.AltUnitId}" : ",NULL");
                            cmdText.Append(!string.IsNullOrEmpty(ProdMaster.AltUnitQnty.ToString()) ? $@",{ProdMaster.AltUnitQnty}" : ",NULL");
                            cmdText.Append(!string.IsNullOrEmpty(ProdMaster.PurchasePrice.ToString()) ? $@",{ProdMaster.PurchasePrice}" : ",NULL");
                            cmdText.Append(!string.IsNullOrEmpty(ProdMaster.MRP.ToString()) ? $@",{ProdMaster.MRP}" : ",NULL");
                            cmdText.Append(!string.IsNullOrEmpty(ProdMaster.Offer.ToString()) ? $@",'{ProdMaster.Offer}'" : ",NULL");
                            cmdText.Append(!string.IsNullOrEmpty(ProdMaster.PNote.ToString()) ? $@",'{ProdMaster.PNote}'" : ",NULL");
                            cmdText.Append(!string.IsNullOrEmpty(ProdMaster.ProductCategory.ToString()) ? $@",'{ProdMaster.ProductCategory}'" : ",NULL");
                            cmdText.Append($@",CAST('{ProdMaster.ActiveStatus}' AS BIT)");
                            cmdText.Append(!string.IsNullOrEmpty(ProdMaster.UserID.ToString()) ? $@",{ProdMaster.UserID}" : ",NULL");
                            cmdText.Append(",GETDATE(),NULL,NULL);\n");
                            cmdText.Append("INSERT INTO [MSM].[ProductInventory]([InventID],[prodID],[Quantity],[AlternateQuantity],[UnitID],[AltUnitID],[ActiveStatus])VALUES(");

                            cmdText.Append($@"{ProdMaster.InventID},{ProdMaster.PID},0,0");
                            cmdText.Append(!string.IsNullOrEmpty(ProdMaster.UnitID.ToString()) ? $@",{ProdMaster.UnitID}" : ",NULL");
                            cmdText.Append(!string.IsNullOrEmpty(ProdMaster.AltUnitId.ToString()) ? $@",{ProdMaster.AltUnitId}" : ",NULL");
                            cmdText.Append($@",CAST('{ProdMaster.ActiveStatus}' AS BIT));");
                            //{ ProdMaster.UnitID},{ProdMaster.AltUnitId},CAST('{ProdMaster.ActiveStatus}' AS BIT));");
                            break;
                        }
                    case "UPDATE":
                        {
                            cmdText.Append("UPDATE [MSM].[ProductMaster] SET ");
                            cmdText.Append(!string.IsNullOrEmpty(ProdMaster.PName.ToString()) ? $@"[PName] = '{ProdMaster.PName}'" : "[PName] = NULL");
                            cmdText.Append(!string.IsNullOrEmpty(ProdMaster.PCode.ToString()) ? $@",[PCode] = '{ProdMaster.PCode}'" : ",[PCode] = NULL");
                            cmdText.Append(!string.IsNullOrEmpty(ProdMaster.PBarcode.ToString()) ? $@",[PBarcode] = '{ProdMaster.PBarcode}'" : ",[PBarcode] = NULL");
                            cmdText.Append(!string.IsNullOrEmpty(ProdMaster.UnitID.ToString()) ? $@",[UnitID] = {ProdMaster.UnitID}" : ",[UnitID] = NULL");
                            cmdText.Append(!string.IsNullOrEmpty(ProdMaster.UnitQnty.ToString()) ? $@",[UnitQnty] = {ProdMaster.UnitQnty}" : ",[UnitQnty] = NULL");
                            cmdText.Append(!string.IsNullOrEmpty(ProdMaster.AltUnitId.ToString()) ? $@",[AltUnitId] = {ProdMaster.AltUnitId}" : ",[AltUnitId] = NULL");
                            cmdText.Append(!string.IsNullOrEmpty(ProdMaster.AltUnitQnty.ToString()) ? $@",[AltUnitQnty] = {ProdMaster.AltUnitQnty}" : ",[AltUnitQnty] = NULL");
                            cmdText.Append(!string.IsNullOrEmpty(ProdMaster.PurchasePrice.ToString()) ? $@",[PurchasePrice] = {ProdMaster.PurchasePrice}" : ",[PurchasePrice] = NULL");
                            cmdText.Append(!string.IsNullOrEmpty(ProdMaster.MRP.ToString()) ? $@",[MRP] = {ProdMaster.MRP}" : ",[MRP] = NULL");
                            cmdText.Append(!string.IsNullOrEmpty(ProdMaster.Offer.ToString()) ? $@",[Offer] = '{ProdMaster.Offer}'" : ",[Offer] = NULL");
                            cmdText.Append(!string.IsNullOrEmpty(ProdMaster.PNote.ToString()) ? $@",[PNote] = '{ProdMaster.PNote}'" : ",[PNote] = NULL");
                            cmdText.Append(!string.IsNullOrEmpty(ProdMaster.ProductCategory.ToString()) ? $@",[ProductCategory] = '{ProdMaster.ProductCategory}'" : ",[ProductCategory] = NULL");
                            cmdText.Append($@",[ActiveStatus] = CAST('{ProdMaster.ActiveStatus}' AS BIT)");
                            cmdText.Append(!string.IsNullOrEmpty(ProdMaster.UserID.ToString()) ? $@",[MUserID] = {ProdMaster.UserID}" : ",NULL");
                            cmdText.Append(",[ModifiedDate] = GETDATE() ");
                            cmdText.Append($@"WHERE [PID] =  {ProdMaster.PID};");
                            cmdText.Append("\n");
                            cmdText.Append("UPDATE [MSM].[ProductInventory] SET ");
                            cmdText.Append(!string.IsNullOrEmpty(ProdMaster.UnitID.ToString()) ? $@"[UnitID] = {ProdMaster.UnitID}" : "[UnitID] = NULL");
                            cmdText.Append(!string.IsNullOrEmpty(ProdMaster.AltUnitId.ToString()) ? $@",[AltUnitId] = {ProdMaster.AltUnitId}" : ",[AltUnitId] = NULL");
                            cmdText.Append($@",[ActiveStatus] = CAST('{ProdMaster.ActiveStatus}' AS BIT)");
                            cmdText.Append($@"WHERE InventID = {ProdMaster.InventID} AND [prodID] =  {ProdMaster.PID};");
                            break;
                        }
                    case "DELETE":
                        {
                            //cmdText.Append($@"DELETE FROM [MSM].[ProductMaster] WHERE [PID] =  {ProdMaster.PID}");
                            cmdText.Append($@"UPDATE [MSM].[ProductMaster] SET ActiveStatus = 0 WHERE [PID] =  {ProdMaster.PID}; UPDATE [MSM].[ProductInventory] SET [ActiveStatus] = 0 WHERE InventID = {ProdMaster.InventID} AND [prodID] =  {ProdMaster.PID};");
                            break;
                        }
                }
                var IsOk = Execute.ExecuteNonQueryOnMain(cmdText.ToString());
                if (IsOk <= 0) return 0;
                return IsOk;
            }
            catch
            {
                return 0;
            }

        }

        public int GetProcuctTypeSetup()
        {
            try
            {
                var cmdText = new StringBuilder();
                if (TypeMaster.ToPerform == null) return 0;
                switch (TypeMaster.ToPerform.ToUpper())
                {
                    case "INSERT":
                        {
                            cmdText.Append("INSERT INTO [MSM].[ProductCategory]([CatID],[Category],[CategoryID],[ActiveStatus],[UserID],[DateCreated],[MUserID],[ModifiedDate])VALUES ( ");
                            cmdText.Append(!string.IsNullOrEmpty(TypeMaster.CatID.ToString())?$@"{TypeMaster.CatID}":"Error");
                            cmdText.Append(!string.IsNullOrEmpty(TypeMaster.Category.ToString()) ? $@",'{TypeMaster.Category}'" : ",NULL");
                            cmdText.Append(!string.IsNullOrEmpty(TypeMaster.CategoryID.ToString()) ? $@",'{TypeMaster.CategoryID}'" : ",NULL");
                            cmdText.Append($@",CAST('{TypeMaster.ActiveStatus}' AS BIT)");
                            cmdText.Append(!string.IsNullOrEmpty(TypeMaster.UserID.ToString()) ? $@",{TypeMaster.UserID}" : ",NULL");
                            cmdText.Append(",GETDATE(),NULL,NULL);");
                            break;
                        }
                    case "UPDATE":
                        {
                            cmdText.Append("UPDATE [MSM].[ProductCategory] SET ");
                            cmdText.Append(!string.IsNullOrEmpty(TypeMaster.Category.ToString()) ? $@"[Category] = '{TypeMaster.Category}'" : "[Category] = NULL");
                            cmdText.Append(!string.IsNullOrEmpty(TypeMaster.CategoryID.ToString()) ? $@",[CategoryID] = '{TypeMaster.CategoryID}'" : ",[CategoryID] = NULL");
                            cmdText.Append($@",[ActiveStatus] = CAST('{TypeMaster.ActiveStatus}' AS BIT)");
                            cmdText.Append(!string.IsNullOrEmpty(TypeMaster.UserID.ToString()) ? $@",[MUserID] = {TypeMaster.UserID}" : ",NULL");
                            cmdText.Append(",[ModifiedDate] = GETDATE() ");
                            cmdText.Append($@"WHERE [CatID] =  {TypeMaster.CatID}");
                            break;
                        }
                    case "DELETE":
                        {
                            cmdText.Append($@"DELETE FROM [MSM].[ProductCategory] WHERE [CatID] =  {TypeMaster.CatID}");
                            break;
                        }
                }
                var IsOk = Execute.ExecuteNonQueryOnMain(cmdText.ToString());
                if (IsOk <= 0) return 0;
                return IsOk;
            }
            catch
            {
                return 0;
            }

        }

        public int GetPurchaseOrderSetup()
        {
            try
            {
                var cmdTextMaster = new StringBuilder();
                var cmdTextDetails = new StringBuilder();
                if (PO_Master.ToPerform == null && PO_Details.ToPerform == null) return 0;
                switch (PO_Master.ToPerform.ToUpper())
                {
                    case "INSERT":
                        {
                            cmdTextMaster.Append("INSERT INTO [MSM].[PurchaseOrderMaster]([POID],[POVNUM],[Order_Date],[Order_Miti],[ReceiverID],[SenderID],[TransectionOn],[Total],[Vat],[VatAmt],[TotalAmount],[Discount],[DiscAmount],[BillTotal],[InWords],[PO_Bill_Status],[UserID],[DateCreated],[MUserID],[ModifiedDate],[goods_quantity],[is_Deleted]) VALUES ( ");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PO_Master.POID.ToString()) ? $@"{PO_Master.POID}":"NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PO_Master.POVNUM.ToString()) ? $@",'{PO_Master.POVNUM}'" : ",NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PO_Master.Order_Date.ToString()) ? $@",'{PO_Master.Order_Date}'" : ",NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PO_Master.Order_Miti.ToString()) ? $@",'{PO_Master.Order_Miti}'" : ",NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PO_Master.ReceiverID.ToString()) ? $@",{PO_Master.ReceiverID}" : ",NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PO_Master.SenderID.ToString()) ? $@",{PO_Master.SenderID}" : ",NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PO_Master.TransectionOn.ToString()) ? $@",'{PO_Master.TransectionOn}'" : ",NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PO_Master.Total.ToString()) ? $@",'{PO_Master.Total}'" : ",NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PO_Master.Vat.ToString()) ? $@",'{PO_Master.Vat}'" : ",NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PO_Master.VatAmt.ToString()) ? $@",'{PO_Master.VatAmt}'" : ",NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PO_Master.TotalAmount.ToString()) ? $@",'{PO_Master.TotalAmount}'" : ",NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PO_Master.Discount.ToString()) ? $@",'{PO_Master.Discount}'" : ",NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PO_Master.DiscAmount.ToString()) ? $@",'{PO_Master.DiscAmount}'" : ",NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PO_Master.BillTotal.ToString()) ? $@",'{PO_Master.BillTotal}'" : ",NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PO_Master.InWords.ToString()) ? $@",'{PO_Master.InWords}'" : ",NULL");
                            cmdTextMaster.Append($@",CAST('{PO_Master.PO_Bill_Status}' AS BIT)");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PO_Master.UserID.ToString()) ? $@",{PO_Master.UserID}" : ",NULL");
                            cmdTextMaster.Append(",GETDATE(),NULL,NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PO_Master.goods_quantity.ToString()) ? $@"{PO_Master.goods_quantity}" : "0.00");
                            cmdTextMaster.Append($@",CAST('{PO_Master.is_Deleted}' AS BIT));");
                            if (PO_Details.GetGridViewData != null && PO_Details.GetGridViewData.RowCount > 0)
                            {
                                var Rows = 0;
                                foreach(DataGridViewRow dgv in PO_Details.GetGridViewData.Rows)
                                {
                                    Rows++;
                                    cmdTextDetails.Append("INSERT INTO [MSM].[PurchaseOrderDetails]([POID],[POVNUM],[PID],[PName],[PCode],[PBarcode],[Quantiy],[UnitID],[PPrice],[TotalPrice],[PNote],[UserID],[DateCreated],[MUserID],[ModifiedDate],PO_Bill_Status,is_Deleted)VALUES  \n");
                                    cmdTextDetails.Append(!string.IsNullOrEmpty(PO_Details.POID.ToString()) ? $@"({PO_Details.POID}," : "NULL,");
                                    cmdTextDetails.Append(!string.IsNullOrEmpty(PO_Details.POVNUM.ToString()) ? $@"'{PO_Details.POVNUM}'," : "NULL,");
                                    cmdTextDetails.Append($"{dgv.Cells["PID"].Value},");
                                    cmdTextDetails.Append(dgv.Cells["Product"].Value.ToString() != null ? $"'{dgv.Cells["Product"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["Short Name"].Value.ToString() != null ? $"'{dgv.Cells["Short Name"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["BarCode"].Value.ToString() != null ? $"'{dgv.Cells["BarCode"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["Quantity"].Value.ToString() != null ? $"'{dgv.Cells["Quantity"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["Unit"].Value.ToString() != null ? $"(select UnitID  from MSM.UnitMaster where UnitCode ='{dgv.Cells["Unit"].Value}')," : "NULL,");                                 
                                    cmdTextDetails.Append(dgv.Cells["P. Price"].Value.ToString() != null ? $"'{dgv.Cells["P. Price"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["Total"].Value.ToString() != null ? $"'{dgv.Cells["Total"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["P.Note"].Value.ToString() == null || string.IsNullOrWhiteSpace(dgv.Cells["P.Note"].Value.ToString()) ? "NULL," : $"'{dgv.Cells["P.Note"].Value}',");
                                    cmdTextDetails.Append(!string.IsNullOrEmpty(PO_Details.UserID.ToString()) ? $@"{PO_Details.UserID}," : "NULL,");
                                    cmdTextDetails.Append("GETDATE(),NULL,NULL,");
                                    cmdTextDetails.Append($@"CAST('{PO_Master.PO_Bill_Status}' AS BIT),"); //here status ad deleted option will be used of master.
                                    cmdTextDetails.Append($@"CAST('{PO_Master.is_Deleted}' AS BIT));");
                                    cmdTextDetails.Append("\n");
                                }
                            }

                            break;
                        }
                    case "UPDATE":
                        {
                            cmdTextMaster.Append("UPDATE [MSM].[PurchaseOrderMaster] SET ");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PO_Master.Order_Date.ToString()) ? $@"[Order_Date] = '{PO_Master.Order_Date}'" : ",[Order_Date] = NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PO_Master.Order_Miti.ToString()) ? $@",[Order_Miti] = '{PO_Master.Order_Miti}'" : ",[Order_Miti] = NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PO_Master.ReceiverID.ToString()) ? $@",[ReceiverID] = {PO_Master.ReceiverID}" : ",[ReceiverID] = NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PO_Master.SenderID.ToString()) ? $@",[SenderID] = {PO_Master.SenderID}" : ",[SenderID] = NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PO_Master.TransectionOn.ToString()) ? $@",[TransectionOn] = '{PO_Master.TransectionOn}'" : ",[TransectionOn] =NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PO_Master.Total.ToString()) ? $@",[Total] = '{PO_Master.Total}'" : ",[Total] = NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PO_Master.Vat.ToString()) ? $@",[Vat] = '{PO_Master.Vat}'" : ",[Vat] = NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PO_Master.VatAmt.ToString()) ? $@",[VatAmt] = '{PO_Master.VatAmt}'" : ",[VatAmt] = NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PO_Master.TotalAmount.ToString()) ? $@",[TotalAmount] = '{PO_Master.TotalAmount}'" : ",[TotalAmount] = NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PO_Master.Discount.ToString()) ? $@",[Discount] = '{PO_Master.Discount}'" : ",[Discount] = NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PO_Master.DiscAmount.ToString()) ? $@",[DiscAmount] = '{PO_Master.DiscAmount}'" : ",[DiscAmount] = NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PO_Master.BillTotal.ToString()) ? $@",[BillTotal] = '{PO_Master.BillTotal}'" : ",[BillTotal] = NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PO_Master.InWords.ToString()) ? $@",[InWords] = '{PO_Master.InWords}'" : ", [InWords] = NULL");
                            cmdTextMaster.Append($@",[PO_Bill_Status] = CAST('{PO_Master.PO_Bill_Status}' AS BIT)");
                            cmdTextMaster.Append($@",[is_Deleted] = CAST('{PO_Master.is_Deleted}' AS BIT)");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PO_Master.UserID.ToString()) ? $@",[MUserID] = {PO_Master.UserID}," : ",[MUserID] = NULL,");
                            cmdTextMaster.Append("[ModifiedDate] = GETDATE(),");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PO_Master.goods_quantity.ToString()) ? $@"[goods_quantity] = {PO_Master.goods_quantity}" : "[goods_quantity]=NULL)");
                            cmdTextMaster.Append($@" WHERE [POID] = {PO_Master.POID} and [POVNUM] = '{PO_Master.POVNUM}';");

                            cmdTextDetails.Append($@"DELETE FROM [MSM].[PurchaseOrderDetails] WHERE [POID] = {PO_Details.POID} and [POVNUM] = '{PO_Details.POVNUM}';");
                            cmdTextDetails.Append("\n");

                            if (PO_Details.GetGridViewData != null && PO_Details.GetGridViewData.RowCount > 0)
                            {
                                var Rows = 0;
                                foreach (DataGridViewRow dgv in PO_Details.GetGridViewData.Rows)
                                {
                                    Rows++;
                                    cmdTextDetails.Append("INSERT INTO [MSM].[PurchaseOrderDetails]([POID],[POVNUM],[PID],[PName],[PCode],[PBarcode],[Quantiy],[UnitID],[PPrice],[TotalPrice],[PNote],[UserID],[DateCreated],[MUserID],[ModifiedDate],PO_Bill_Status,is_Deleted) \n VALUES ");
                                    cmdTextDetails.Append(!string.IsNullOrEmpty(PO_Details.POID.ToString()) ? $@"({PO_Details.POID}," : "NULL,");
                                    cmdTextDetails.Append(!string.IsNullOrEmpty(PO_Details.POVNUM.ToString()) ? $@"'{PO_Details.POVNUM}'," : "NULL,");
                                    cmdTextDetails.Append($"{dgv.Cells["PID"].Value},");
                                    cmdTextDetails.Append(dgv.Cells["Product"].Value.ToString() != null ? $"'{dgv.Cells["Product"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["Short Name"].Value.ToString() != null ? $"'{dgv.Cells["Short Name"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["BarCode"].Value.ToString() != null ? $"'{dgv.Cells["BarCode"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["Quantity"].Value.ToString() != null ? $"'{dgv.Cells["Quantity"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["Unit"].Value.ToString() != null ? $"(select UnitID  from MSM.UnitMaster where UnitCode ='{dgv.Cells["Unit"].Value}')," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["P. Price"].Value.ToString() != null ? $"'{dgv.Cells["P. Price"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["Total"].Value.ToString() != null ? $"'{dgv.Cells["Total"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["P.Note"].Value.ToString() == null || string.IsNullOrWhiteSpace(dgv.Cells["P.Note"].Value.ToString()) ? "NULL," : $"'{dgv.Cells["P.Note"].Value}',");
                                    cmdTextDetails.Append(!string.IsNullOrEmpty(PO_Details.UserID.ToString()) ? $@"{PO_Details.UserID}," : "NULL,");
                                    cmdTextDetails.Append(!string.IsNullOrEmpty(PO_Details.DateCreated.ToString()) ? $@"'{PO_Details.DateCreated}'," : "NULL,");
                                    cmdTextDetails.Append(!string.IsNullOrEmpty(PO_Details.MUserID.ToString()) ? $@"{PO_Details.MUserID}," : "NULL,");
                                    cmdTextDetails.Append("GETDATE(),");
                                    cmdTextDetails.Append($@"CAST('{PO_Master.PO_Bill_Status}' AS BIT),"); //here status ad deleted option will be used of master.
                                    cmdTextDetails.Append($@"CAST('{PO_Master.is_Deleted}' AS BIT));");
                                    cmdTextDetails.Append("\n");
                                }
                            }
                            break;
                        }
                    case "DELETE":
                        {
                            //cmdTextMaster.Append($@"DELETE FROM [MSM].[PurchaseOrderDetails] WHERE [POID] = {PO_Details.POID} and [POVNUM] = '{PO_Details.POVNUM}';  DELETE FROM [MSM].[PurchaseOrderMaster] WHERE [POID] = {PO_Master.POID} and [POVNUM] = '{PO_Master.POVNUM}';");
                            cmdTextMaster.Append($@"UPDATE [MSM].[PurchaseOrderDetails] SET is_Deleted = 'True' WHERE [POID] = {PO_Details.POID} and [POVNUM] = '{PO_Details.POVNUM}';");  
                            cmdTextDetails.Append($@"UPDATE [MSM].[PurchaseOrderMaster] set is_Deleted = 'True' WHERE [POID] = {PO_Master.POID} and [POVNUM] = '{PO_Master.POVNUM}';");
                            break;
                        }
                }
               
                var IsMasterOk = Execute.ExecuteNonQueryOnMain(cmdTextMaster.ToString());
                var IsDetailsOk = Execute.ExecuteNonQueryOnMain(cmdTextDetails.ToString());
                if (IsMasterOk <= 0 && IsDetailsOk <= 0) return 0;
                return IsMasterOk;
            }
            catch
            {
                return 0;
            }

        }

        public int GetPurchaseGoodsSetup()
        {
            try
            {
                var cmdTextMaster = new StringBuilder();
                var cmdTextDetails = new StringBuilder();
                if (PE_Master.ToPerform == null && PE_Details.ToPerform == null) return 0;
                switch(PE_Master.ToPerform.ToUpper())
                {
                    case "INSERT":
                        {
                            cmdTextMaster.Append("INSERT INTO [MSM].[PurchaseMaster]([PEID],[PVNUM],[Purchase_Date],[Purchase_Miti],[ref_bill_No],[Purchase_OrderNo],[PO_ReferenceNo],[SenderID],[ReceiverID],[TransectionOn],[Total],[Vat],[VatAmt],[TotalAmount],[Discount],[DiscAmount],[BillTotal],[InWords],[Note],[PO_Bill_Status],[is_Deleted],[UserID],[DateCreated],[MUserID],[ModifiedDate])VALUES(");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PE_Master.PEID.ToString())?$@"{PE_Master.PEID},":"NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PE_Master.PVNUM.ToString())?$@"'{PE_Master.PVNUM}',":"NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PE_Master.Purchase_Date.ToString())?$@"'{PE_Master.Purchase_Date}',":"NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PE_Master.Purchase_Miti.ToString())?$@"'{PE_Master.Purchase_Miti}',":"NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PE_Master.ref_bill_No.ToString())?$@"'{PE_Master.ref_bill_No}',":"NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PE_Master.Purchase_OrderNo.ToString())?$@"'{PE_Master.Purchase_OrderNo}',":"NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PE_Master.PO_ReferenceNo.ToString())?$@"'{PE_Master.PO_ReferenceNo}',":"'N/A',");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PE_Master.SenderID.ToString())?$@"{PE_Master.SenderID},":"NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PE_Master.ReceiverID.ToString())?$@"{PE_Master.ReceiverID},":"NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PE_Master.TransectionOn.ToString())?$@"'{PE_Master.TransectionOn}',":"NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PE_Master.Total.ToString())?$@"'{PE_Master.Total}',":"NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PE_Master.Vat.ToString())?$@"'{PE_Master.Vat}',":"NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PE_Master.VatAmt.ToString())?$@"'{PE_Master.VatAmt}',":"NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PE_Master.TotalAmount.ToString())?$@"'{PE_Master.TotalAmount}',":"NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PE_Master.Discount.ToString())?$@"'{PE_Master.Discount}',":"NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PE_Master.DiscAmount.ToString())?$@"'{PE_Master.DiscAmount}',":"NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PE_Master.BillTotal.ToString())?$@"'{PE_Master.BillTotal}',":"NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PE_Master.InWords.ToString())?$@"'{PE_Master.InWords}',":"NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PE_Master.Note.ToString())?$@"'{PE_Master.Note}',":"NULL,");
                            cmdTextMaster.Append($@"CAST('{PE_Master.PO_Bill_Status}' AS BIT),");
                            cmdTextMaster.Append($@"CAST('{PE_Master.is_Deleted}' AS BIT),");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PE_Master.UserID.ToString())?$@"{PE_Master.UserID},":"NULL,");
                            cmdTextMaster.Append("GETDATE(),NULL,NULL);");

                            if (PE_Details.GetGridViewData != null && PE_Details.GetGridViewData.RowCount > 0)
                            {
                                var Rows = 0;
                                foreach (DataGridViewRow dgv in PE_Details.GetGridViewData.Rows)
                                {
                                    Rows++;
                                    cmdTextDetails.Append("\nINSERT INTO [MSM].[PurchaseDetails](PEID,PVNUM,PID,PName,PCode,PBarcode,Quantiy,UnitID,PPrice,TotalPrice,UserID,DateCreated,MUserID,ModifiedDate,is_Deleted,Purchase_OrderNo)\nVALUES");
                                    cmdTextDetails.Append(!string.IsNullOrEmpty(PE_Details.PEID.ToString()) ? $@"({PE_Details.PEID}," : "NULL,");
                                    cmdTextDetails.Append(!string.IsNullOrEmpty(PE_Details.PVNUM.ToString()) ? $@"'{PE_Details.PVNUM}'," : "NULL,");
                                    cmdTextDetails.Append($"{dgv.Cells["PID"].Value},");
                                    cmdTextDetails.Append(dgv.Cells["Product"].Value.ToString() != null ? $"'{dgv.Cells["Product"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["Short Name"].Value.ToString() != null ? $"'{dgv.Cells["Short Name"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["BarCode"].Value.ToString() != null ? $"'{dgv.Cells["BarCode"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["Quantity"].Value.ToString() != null ? $"'{dgv.Cells["Quantity"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["Unit"].Value.ToString() != null ? $"(select UnitID  from MSM.UnitMaster where UnitCode ='{dgv.Cells["Unit"].Value}')," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["P. Price"].Value.ToString() != null ? $"'{dgv.Cells["P. Price"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["Total"].Value.ToString() != null ? $"'{dgv.Cells["Total"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(!string.IsNullOrEmpty(PE_Details.UserID.ToString()) ? $@"{PE_Details.UserID}," : "NULL,");
                                    cmdTextDetails.Append(PE_Details.DateCreated.ToString() != "1/1/0001 12:00:00 AM" ? $@"'{PE_Details.DateCreated}'," : "GETDATE(),");
                                    cmdTextDetails.Append("NULL,NULL,");
                                    cmdTextDetails.Append($@"CAST('{PE_Master.is_Deleted}' AS BIT),");
                                    cmdTextDetails.Append(!string.IsNullOrEmpty(PE_Master.Purchase_OrderNo.ToString()) ? $@"'{PE_Master.Purchase_OrderNo}');" : "NULL);");
                                    cmdTextDetails.Append("\n");

                                    cmdTextDetails.Append($@"
                                        DECLARE @prodID{Rows} int = {dgv.Cells["PID"].Value};
                                        DECLARE @IncQuantity{Rows} decimal(16,8) = {dgv.Cells["Quantity"].Value};
                                        DECLARE @Quantity{Rows} decimal(16,8) = (select UnitQnty from MSM.ProductMaster where PID = @prodID{Rows});
                                        DECLARE @altQuantity{Rows} decimal(16,8) = (select AltUnitQnty from MSM.ProductMaster where PID = @prodID{Rows});
                                        Begin update MSM.ProductInventory set Quantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) + @IncQuantity{Rows}) where prodID = @prodID{Rows} end; 
                                        if @Quantity{Rows} = @altQuantity{Rows} 
                                        	Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;
                                        if @Quantity{Rows} > @altQuantity{Rows}
                                        	Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) / (select UnitQnty from msm.ProductMaster where PID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;
                                        if @Quantity{Rows} < @altQuantity{Rows}
                                        	Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) * (select AltUnitQnty from msm.ProductMaster where PID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;"
                                    );
                                    cmdTextDetails.Append("\n");
                                }
                            }
                                break;
                        }
                    case "UPDATE":
                        {
                            cmdTextDetails.Append("\n");
                            cmdTextMaster.Append("UPDATE [MSM].[PurchaseMaster]SET");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PE_Master.Purchase_Date.ToString()) ? $@"[Purchase_Date] = '{PE_Master.Purchase_Date}'," : "[Purchase_Date] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PE_Master.Purchase_Miti.ToString()) ? $@"[Purchase_Miti] = '{PE_Master.Purchase_Miti}'," : "[Purchase_Miti] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PE_Master.ref_bill_No.ToString()) ? $@"[ref_bill_No] = '{PE_Master.ref_bill_No}'," : "[ref_bill_No] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PE_Master.Purchase_OrderNo.ToString()) ? $@"[Purchase_OrderNo] = '{PE_Master.Purchase_OrderNo}'," : "[Purchase_OrderNo] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PE_Master.PO_ReferenceNo.ToString()) ? $@"[PO_ReferenceNo]= '{PE_Master.PO_ReferenceNo}'," : "[PO_ReferenceNo]= 'N/A',");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PE_Master.SenderID.ToString()) ? $@"[SenderID] = {PE_Master.SenderID}," : "[SenderID] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PE_Master.ReceiverID.ToString()) ? $@"[ReceiverID] = {PE_Master.ReceiverID}," : "[ReceiverID] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PE_Master.TransectionOn.ToString()) ? $@"[TransectionOn] = '{PE_Master.TransectionOn}'," : "[TransectionOn] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PE_Master.Total.ToString()) ? $@"[Total] = '{PE_Master.Total}'," : "[Total] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PE_Master.Vat.ToString()) ? $@"[Vat] = '{PE_Master.Vat}'," : "[Vat] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PE_Master.VatAmt.ToString()) ? $@"[VatAmt] = '{PE_Master.VatAmt}'," : "[VatAmt] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PE_Master.TotalAmount.ToString()) ? $@"[TotalAmount] = '{PE_Master.TotalAmount}'," : "[TotalAmount] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PE_Master.Discount.ToString()) ? $@"[Discount] = '{PE_Master.Discount}'," : "[Discount] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PE_Master.DiscAmount.ToString()) ? $@"[DiscAmount] = '{PE_Master.DiscAmount}'," : "[DiscAmount] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PE_Master.BillTotal.ToString()) ? $@"[BillTotal] = '{PE_Master.BillTotal}'," : "[BillTotal] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PE_Master.InWords.ToString()) ? $@"[InWords] = '{PE_Master.InWords}'," : "[InWords] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PE_Master.Note.ToString()) ? $@"[Note] = '{PE_Master.Note}'," : "[Note] = NULL,");
                            cmdTextMaster.Append($@"[PO_Bill_Status] = CAST('{PE_Master.PO_Bill_Status}' AS BIT),");
                            cmdTextMaster.Append($@"[is_Deleted] = CAST('False' AS BIT),"); //incase of update deleted bill is reset to active again by default.
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PE_Master.UserID.ToString()) ? $@"[MUserID] = {PE_Master.UserID}," : "[MUserID] = NULL,");
                            cmdTextMaster.Append("[ModifiedDate] = GETDATE()");
                            cmdTextMaster.Append($@" WHERE [PEID] = {PE_Master.PEID} and [PVNUM] = '{PE_Master.PVNUM}';");
                            cmdTextDetails.Append("\n");
                            cmdTextDetails.Append($@"DELETE FROM [MSM].[PurchaseDetails] WHERE [PEID] = {PE_Master.PEID} and [PVNUM] = '{PE_Master.PVNUM}';");
                            cmdTextDetails.Append("\n");

                            if (PE_Details.GetGridViewData != null && PE_Details.GetGridViewData.RowCount > 0)
                            {
                                var Rows = 0;
                                var uRows = 0;

                                //to channge inventory collection of the old values to calculate difference.
                                if (PE_Master.ToPerform.ToUpper() == "UPDATE" && PE_Details.updateGetGridViewData != null && PE_Details.updateGetGridViewData.RowCount > 0)
                                {
                                    cmdTextDetails.Append("\n");
                                    cmdTextDetails.Append("Declare @OldValues TABLE (oPID int, oldQuantity DECIMAL(16,8));\n");
                                    foreach (DataGridViewRow udgv in PE_Details.updateGetGridViewData.Rows) //check why here it is accepting new changed value
                                    {
                                        uRows++;
                                        cmdTextDetails.Append($@"INSERT INTO @OldValues (oPID,oldQuantity) VALUES({udgv.Cells["PID"].Value},{udgv.Cells["Quantity"].Value});");
                                        cmdTextDetails.Append("\n");
                                    }
                                    cmdTextDetails.Append("\n");
                                    foreach (DataGridViewRow dgv in PE_Details.GetGridViewData.Rows )
                                    {
                                        Rows++;
                                        cmdTextDetails.Append("INSERT INTO [MSM].[PurchaseDetails](PEID,PVNUM,PID,PName,PCode,PBarcode,Quantiy,UnitID,PPrice,TotalPrice,UserID,DateCreated,MUserID,ModifiedDate,is_Deleted,Purchase_OrderNo)\nVALUES");
                                        cmdTextDetails.Append(!string.IsNullOrEmpty(PE_Details.PEID.ToString()) ? $@"({PE_Details.PEID}," : "NULL,");
                                        cmdTextDetails.Append(!string.IsNullOrEmpty(PE_Details.PVNUM.ToString()) ? $@"'{PE_Details.PVNUM}'," : "NULL,");
                                        cmdTextDetails.Append($"{dgv.Cells["PID"].Value},");
                                        cmdTextDetails.Append(dgv.Cells["Product"].Value.ToString() != null ? $"'{dgv.Cells["Product"].Value}'," : "NULL,");
                                        cmdTextDetails.Append(dgv.Cells["Short Name"].Value.ToString() != null ? $"'{dgv.Cells["Short Name"].Value}'," : "NULL,");
                                        cmdTextDetails.Append(dgv.Cells["BarCode"].Value.ToString() != null ? $"'{dgv.Cells["BarCode"].Value}'," : "NULL,");
                                        cmdTextDetails.Append(dgv.Cells["Quantity"].Value.ToString() != null ? $"'{dgv.Cells["Quantity"].Value}'," : "NULL,");
                                        cmdTextDetails.Append(dgv.Cells["Unit"].Value.ToString() != null ? $"(select UnitID  from MSM.UnitMaster where UnitCode ='{dgv.Cells["Unit"].Value}')," : "NULL,");
                                        cmdTextDetails.Append(dgv.Cells["P. Price"].Value.ToString() != null ? $"'{dgv.Cells["P. Price"].Value}'," : "NULL,");
                                        cmdTextDetails.Append(dgv.Cells["Total"].Value.ToString() != null ? $"'{dgv.Cells["Total"].Value}'," : "NULL,");
                                        cmdTextDetails.Append(!string.IsNullOrEmpty(PE_Details.UserID.ToString()) ? $@"{PE_Details.UserID}," : "NULL,");
                                        cmdTextDetails.Append(PE_Details.DateCreated.ToString() != "1/1/0001 12:00:00 AM" ? $@"'{PE_Details.DateCreated}'," : "GETDATE(),");
                                        cmdTextDetails.Append(!string.IsNullOrEmpty(PE_Details.MUserID.ToString()) ? $@"{PE_Details.MUserID}," : "NULL,");
                                        cmdTextDetails.Append("GETDATE(),");
                                        cmdTextDetails.Append($@"CAST('{PE_Master.is_Deleted}' AS BIT),");
                                        cmdTextDetails.Append(!string.IsNullOrEmpty(PE_Master.Purchase_OrderNo.ToString()) ? $@"'{PE_Master.Purchase_OrderNo}');" : "NULL);");
                                        cmdTextDetails.Append("\n");
                                    
                                        if(PE_Master.is_Deleted == true)
                                        {
                                            cmdTextDetails.Append
                                                ($@"
                                                    DECLARE @prodID{Rows} int = {dgv.Cells["PID"].Value};
                                                    DECLARE @newQuantity{Rows} decimal(16,8) = {dgv.Cells["Quantity"].Value};
                                                    
                                                    BEGIN UPDATE MSM.ProductInventory SET Quantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows})+ (@newQuantity{Rows})) WHERE prodID = @prodID{Rows} END;

                                                    DECLARE @Quantity{Rows} decimal(16,8) = (select UnitQnty from MSM.ProductMaster where PID = @prodID{Rows});
                                                    DECLARE @altQuantity{Rows} decimal(16,8) = (select AltUnitQnty from MSM.ProductMaster where PID = @prodID{Rows});

                                                    if @Quantity{Rows} = @altQuantity{Rows} 
                                        	            Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;
                                                    if @Quantity{Rows} > @altQuantity{Rows}
                                        	            Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) / (select UnitQnty from msm.ProductMaster where PID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;
                                                    if @Quantity{Rows} < @altQuantity{Rows}
                                        	            Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) * (select AltUnitQnty from msm.ProductMaster where PID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;"
                                                );
                                        }
                                        else
                                        {
                                            cmdTextDetails.Append
                                                ($@"
                                                    DECLARE @prodID{Rows} int = {dgv.Cells["PID"].Value};
                                                    DECLARE @newQuantity{Rows} decimal(16,8) = {dgv.Cells["Quantity"].Value};
                                                    
                                                    BEGIN UPDATE MSM.ProductInventory SET Quantity = (((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) - (SELECT oldQuantity FROM @OldValues WHERE oPID = @prodID{Rows})) + (@newQuantity{Rows})) WHERE prodID = @prodID{Rows} END;

                                                    DECLARE @Quantity{Rows} decimal(16,8) = (select UnitQnty from MSM.ProductMaster where PID = @prodID{Rows});
                                                    DECLARE @altQuantity{Rows} decimal(16,8) = (select AltUnitQnty from MSM.ProductMaster where PID = @prodID{Rows});

                                                    if @Quantity{Rows} = @altQuantity{Rows} 
                                        	            Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;
                                                    if @Quantity{Rows} > @altQuantity{Rows}
                                        	            Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) / (select UnitQnty from msm.ProductMaster where PID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;
                                                    if @Quantity{Rows} < @altQuantity{Rows}
                                        	            Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) * (select AltUnitQnty from msm.ProductMaster where PID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;"
                                                );
                                        }
                                        
                                        cmdTextDetails.Append("\n");
                                    }
                                }
                            }
                            break;
                        }
                    case "DELETE":
                        {
                            cmdTextMaster.Append($@"UPDATE [MSM].[PurchaseMaster] SET is_Deleted = 'True' WHERE [PEID] = {PE_Details.PEID} and [PVNUM] = '{PE_Details.PVNUM}'; UPDATE [MSM].[PurchaseDetails] set is_Deleted = 'True' WHERE [PEID] = {PE_Details.PEID} and [PVNUM] = '{PE_Details.PVNUM}';");
                            cmdTextDetails.Append("\n");
                            if (PE_Details.GetGridViewData != null && PE_Details.GetGridViewData.RowCount > 0)
                            {
                                var Rows = 0;
                                foreach (DataGridViewRow dgv in PE_Details.GetGridViewData.Rows)
                                {
                                    Rows++;
                                    cmdTextDetails.Append($@"
                                        DECLARE @prodID{Rows} int = {dgv.Cells["PID"].Value};
                                        DECLARE @IncQuantity{Rows} decimal(16,8) = {dgv.Cells["Quantity"].Value};
                                        DECLARE @Quantity{Rows} decimal(16,8) = (select UnitQnty from MSM.ProductMaster where PID = @prodID{Rows});
                                        DECLARE @altQuantity{Rows} decimal(16,8) = (select AltUnitQnty from MSM.ProductMaster where PID = @prodID{Rows});
                                        Begin update MSM.ProductInventory set Quantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) - @IncQuantity{Rows}) where prodID = @prodID{Rows} end; 
                                        if @Quantity{Rows} = @altQuantity{Rows} 
                                        	Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;
                                        if @Quantity{Rows} > @altQuantity{Rows}
                                        	Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) / (select UnitQnty from msm.ProductMaster where PID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;
                                        if @Quantity{Rows} < @altQuantity{Rows}
                                        	Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) * (select AltUnitQnty from msm.ProductMaster where PID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;"
                                    );
                                }
                            }
                            break;
                        }
                }

                var IsMasterOk = Execute.ExecuteNonQueryOnMain(cmdTextMaster.ToString());
                var IsDetailsOk = Execute.ExecuteNonQueryOnMain(cmdTextDetails.ToString());
                if (IsMasterOk <= 0 && IsDetailsOk <= 0) return 0;
                return IsMasterOk;
            }
            catch
            {
                return 0;
            }
        }
        public int GetPurchaseReturnSetup()
        {
            try
            {
                var cmdTextMaster = new StringBuilder();
                var cmdTextDetails = new StringBuilder();
                if (PR_Master.ToPerform == null && PR_Details.ToPerform == null) return 0;
                switch (PR_Master.ToPerform.ToUpper())
                {
                    case "INSERT":
                        {
                            cmdTextMaster.Append("INSERT INTO [MSM].[PurchaseReturnMaster]([PRID],[PRVNUM],[Purchase_Return_Date],[Purchase_Return_Miti],[SenderID],[ReceiverID],[TransectionOn],[Total],[Vat],[VatAmt],[TotalAmount],[Discount],[DiscAmount],[BillTotal],[InWords],[Note],[is_Deleted],[UserID],[DateCreated],[MUserID],[ModifiedDate],[extraNote]) \n VALUES(");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PR_Master.PRID.ToString()) ? $@"{PR_Master.PRID}," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PR_Master.PRVNUM.ToString()) ? $@"'{PR_Master.PRVNUM}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PR_Master.Purchase_Return_Date.ToString()) ? $@"'{PR_Master.Purchase_Return_Date}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PR_Master.Purchase_Return_Miti.ToString()) ? $@"'{PR_Master.Purchase_Return_Miti}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PR_Master.SenderID.ToString()) ? $@"{PR_Master.SenderID}," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PR_Master.ReceiverID.ToString()) ? $@"{PR_Master.ReceiverID}," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PR_Master.TransectionOn.ToString()) ? $@"'{PR_Master.TransectionOn}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PR_Master.Total.ToString()) ? $@"'{PR_Master.Total}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PR_Master.Vat.ToString()) ? $@"'{PR_Master.Vat}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PR_Master.VatAmt.ToString()) ? $@"'{PR_Master.VatAmt}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PR_Master.TotalAmount.ToString()) ? $@"'{PR_Master.TotalAmount}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PR_Master.Discount.ToString()) ? $@"'{PR_Master.Discount}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PR_Master.DiscAmount.ToString()) ? $@"'{PR_Master.DiscAmount}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PR_Master.BillTotal.ToString()) ? $@"'{PR_Master.BillTotal}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PR_Master.InWords.ToString()) ? $@"'{PR_Master.InWords}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PR_Master.Note.ToString()) ? $@"'{PR_Master.Note}'," : "NULL,");
                            cmdTextMaster.Append($@"CAST('{PR_Master.is_Deleted}' AS BIT),");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PR_Master.UserID.ToString()) ? $@"{PR_Master.UserID}," : "NULL,");
                            cmdTextMaster.Append("GETDATE(),NULL,NULL,NULL);");

                            if (PR_Details.GetGridViewData != null && PR_Details.GetGridViewData.RowCount > 0)
                            {
                                var Rows = 0;
                                foreach (DataGridViewRow dgv in PR_Details.GetGridViewData.Rows)
                                {
                                    Rows++;
                                    cmdTextDetails.Append("\nINSERT INTO [MSM].[PurchaseReturnDetails]([PRID],[PRVNUM],[PID],[PName],[PCode],[PBarcode],[Quantiy],[UnitID],[PPrice],[TotalPrice],[Note],[UserID],[DateCreated],[MUserID],[ModifiedDate],[is_Deleted]) \n VALUES(");
                                    cmdTextDetails.Append(!string.IsNullOrEmpty(PR_Details.PRID.ToString()) ? $@"{PR_Details.PRID}," : "NULL,");
                                    cmdTextDetails.Append(!string.IsNullOrEmpty(PR_Details.PRVNUM.ToString()) ? $@"'{PR_Details.PRVNUM}'," : "NULL,");
                                    cmdTextDetails.Append($"{dgv.Cells["PID"].Value},");
                                    cmdTextDetails.Append(dgv.Cells["Product"].Value.ToString() != null ? $"'{dgv.Cells["Product"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["Short Name"].Value.ToString() != null ? $"'{dgv.Cells["Short Name"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["BarCode"].Value.ToString() != null ? $"'{dgv.Cells["BarCode"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["Quantity"].Value.ToString() != null ? $"'{dgv.Cells["Quantity"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["Unit"].Value.ToString() != null ? $"(select UnitID  from MSM.UnitMaster where UnitCode ='{dgv.Cells["Unit"].Value}')," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["P. Price"].Value.ToString() != null ? $"'{dgv.Cells["P. Price"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["Total"].Value.ToString() != null ? $"'{dgv.Cells["Total"].Value}'," : "NULL,");
                                    cmdTextDetails.Append("NULL,");
                                    cmdTextDetails.Append(!string.IsNullOrEmpty(PR_Details.UserID.ToString()) ? $@"{PR_Details.UserID}," : "NULL,");
                                    cmdTextDetails.Append(PR_Details.DateCreated.ToString() != "1/1/0001 12:00:00 AM" ? $@"'{PR_Details.DateCreated}'," : "GETDATE(),");
                                    cmdTextDetails.Append("NULL,NULL,");
                                    cmdTextDetails.Append($@"CAST('{PR_Master.is_Deleted}' AS BIT));");
                                    //cmdTextDetails.Append(!string.IsNullOrEmpty(PR_Master.Purchase_OrderNo.ToString()) ? $@"'{PR_Master.Purchase_OrderNo}');" : "NULL);");
                                    cmdTextDetails.Append("\n");

                                    cmdTextDetails.Append($@"
                                        DECLARE @prodID{Rows} int = {dgv.Cells["PID"].Value};
                                        DECLARE @IncQuantity{Rows} decimal(16,8) = {dgv.Cells["Quantity"].Value};
                                        DECLARE @Quantity{Rows} decimal(16,8) = (select UnitQnty from MSM.ProductMaster where PID = @prodID{Rows});
                                        DECLARE @altQuantity{Rows} decimal(16,8) = (select AltUnitQnty from MSM.ProductMaster where PID = @prodID{Rows});
                                        Begin update MSM.ProductInventory set Quantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) - @IncQuantity{Rows}) where prodID = @prodID{Rows} end; 
                                        if @Quantity{Rows} = @altQuantity{Rows} 
                                        	Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;
                                        if @Quantity{Rows} > @altQuantity{Rows}
                                        	Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) / (select UnitQnty from msm.ProductMaster where PID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;
                                        if @Quantity{Rows} < @altQuantity{Rows}
                                        	Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) * (select AltUnitQnty from msm.ProductMaster where PID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;"
                                    );
                                    cmdTextDetails.Append("\n");
                                }
                            }
                            break;
                        }
                    case "UPDATE":
                        {
                            cmdTextMaster.Append("\n");
                            cmdTextMaster.Append("UPDATE [MSM].[PurchaseReturnMaster] SET");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PR_Master.Purchase_Return_Date.ToString()) ? $@"[Purchase_Return_Date] = '{PR_Master.Purchase_Return_Date}'," : "[Purchase_Return_Date] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PR_Master.Purchase_Return_Miti.ToString()) ? $@"[Purchase_Return_Miti] = '{PR_Master.Purchase_Return_Miti}'," : "[Purchase_Return_Miti] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PR_Master.SenderID.ToString()) ? $@"[SenderID] = {PR_Master.SenderID}," : "[SenderID] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PR_Master.ReceiverID.ToString()) ? $@"[ReceiverID] = {PR_Master.ReceiverID}," : "[ReceiverID] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PR_Master.TransectionOn.ToString()) ? $@"[TransectionOn] = '{PR_Master.TransectionOn}'," : "[TransectionOn] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PR_Master.Total.ToString()) ? $@"[Total] = '{PR_Master.Total}'," : "[Total] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PR_Master.Vat.ToString()) ? $@"[Vat] = '{PR_Master.Vat}'," : "[Vat] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PR_Master.VatAmt.ToString()) ? $@"[VatAmt] = '{PR_Master.VatAmt}'," : "[VatAmt] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PR_Master.TotalAmount.ToString()) ? $@"[TotalAmount] = '{PR_Master.TotalAmount}'," : "[TotalAmount] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PR_Master.Discount.ToString()) ? $@"[Discount] = '{PR_Master.Discount}'," : "[Discount] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PR_Master.DiscAmount.ToString()) ? $@"[DiscAmount] = '{PR_Master.DiscAmount}'," : "[DiscAmount] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PR_Master.BillTotal.ToString()) ? $@"[BillTotal] = '{PR_Master.BillTotal}'," : "[BillTotal] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PR_Master.InWords.ToString()) ? $@"[InWords] = '{PR_Master.InWords}'," : "[InWords] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PR_Master.Note.ToString()) ? $@"[Note] = '{PR_Master.Note}'," : "[Note] = NULL,");
                            //cmdTextMaster.Append($@"[PO_Bill_Status] = CAST('{PR_Master.PO_Bill_Status}' AS BIT),");
                            cmdTextMaster.Append($@"[is_Deleted] = CAST('False' AS BIT),"); //incase of update deleted bill is reset to active again by default.
                            cmdTextMaster.Append(!string.IsNullOrEmpty(PR_Master.UserID.ToString()) ? $@"[MUserID] = {PR_Master.UserID}," : "[MUserID] = NULL,");
                            cmdTextMaster.Append("[ModifiedDate] = GETDATE()");
                            cmdTextMaster.Append($@" WHERE [PRID] = {PR_Master.PRID} and [PRVNUM] = '{PR_Master.PRVNUM}';");
                            cmdTextDetails.Append("\n");

                            cmdTextDetails.Append($@"DELETE FROM [MSM].[PurchaseReturnDetails] WHERE [PRID] = {PR_Master.PRID} and [PRVNUM] = '{PR_Master.PRVNUM}';");
                            cmdTextDetails.Append("\n");

                            if (PR_Details.GetGridViewData != null && PR_Details.GetGridViewData.RowCount > 0)
                            {
                                var Rows = 0;
                                var uRows = 0;

                                //to channge inventory collection of the old values to calculate difference.
                                if (PR_Master.ToPerform.ToUpper() == "UPDATE" && PR_Details.updateGetGridViewData != null && PR_Details.updateGetGridViewData.RowCount > 0)
                                {
                                    cmdTextDetails.Append("\n");
                                    cmdTextDetails.Append("Declare @OldValues TABLE (oPID int, oldQuantity DECIMAL(16,8));\n");
                                    foreach (DataGridViewRow udgv in PR_Details.updateGetGridViewData.Rows) //check why here it is accepting new changed value
                                    {
                                        uRows++;
                                        cmdTextDetails.Append($@"INSERT INTO @OldValues (oPID,oldQuantity) VALUES({udgv.Cells["PID"].Value},{udgv.Cells["Quantity"].Value});");
                                        cmdTextDetails.Append("\n");
                                    }
                                    cmdTextDetails.Append("\n");
                                    foreach (DataGridViewRow dgv in PR_Details.GetGridViewData.Rows)
                                    {
                                        Rows++;
                                        cmdTextDetails.Append("\nINSERT INTO [MSM].[PurchaseReturnDetails]([PRID],[PRVNUM],[PID],[PName],[PCode],[PBarcode],[Quantiy],[UnitID],[PPrice],[TotalPrice],[Note],[UserID],[DateCreated],[MUserID],[ModifiedDate],[is_Deleted]) \n VALUES(");
                                        cmdTextDetails.Append(!string.IsNullOrEmpty(PR_Details.PRID.ToString()) ? $@"{PR_Details.PRID}," : "NULL,");
                                        cmdTextDetails.Append(!string.IsNullOrEmpty(PR_Details.PRVNUM.ToString()) ? $@"'{PR_Details.PRVNUM}'," : "NULL,");
                                        cmdTextDetails.Append($"{dgv.Cells["PID"].Value},");
                                        cmdTextDetails.Append(dgv.Cells["Product"].Value.ToString() != null ? $"'{dgv.Cells["Product"].Value}'," : "NULL,");
                                        cmdTextDetails.Append(dgv.Cells["Short Name"].Value.ToString() != null ? $"'{dgv.Cells["Short Name"].Value}'," : "NULL,");
                                        cmdTextDetails.Append(dgv.Cells["BarCode"].Value.ToString() != null ? $"'{dgv.Cells["BarCode"].Value}'," : "NULL,");
                                        cmdTextDetails.Append(dgv.Cells["Quantity"].Value.ToString() != null ? $"'{dgv.Cells["Quantity"].Value}'," : "NULL,");
                                        cmdTextDetails.Append(dgv.Cells["Unit"].Value.ToString() != null ? $"(select UnitID  from MSM.UnitMaster where UnitCode ='{dgv.Cells["Unit"].Value}')," : "NULL,");
                                        cmdTextDetails.Append(dgv.Cells["P. Price"].Value.ToString() != null ? $"'{dgv.Cells["P. Price"].Value}'," : "NULL,");
                                        cmdTextDetails.Append(dgv.Cells["Total"].Value.ToString() != null ? $"'{dgv.Cells["Total"].Value}'," : "NULL,");
                                        cmdTextDetails.Append("NULL,");
                                        cmdTextDetails.Append(!string.IsNullOrEmpty(PR_Details.UserID.ToString()) ? $@"{PR_Details.UserID}," : "NULL,");
                                        cmdTextDetails.Append(PR_Details.DateCreated.ToString() != "1/1/0001 12:00:00 AM" ? $@"'{PR_Details.DateCreated}'," : "GETDATE(),");
                                        cmdTextDetails.Append("NULL,NULL,");
                                        cmdTextDetails.Append($@"CAST('{PR_Master.is_Deleted}' AS BIT));");
                                        cmdTextDetails.Append("\n");

                                        if (PR_Master.is_Deleted == true)
                                        {
                                            cmdTextDetails.Append
                                                ($@"
                                                    DECLARE @prodID{Rows} int = {dgv.Cells["PID"].Value};
                                                    DECLARE @newQuantity{Rows} decimal(16,8) = {dgv.Cells["Quantity"].Value};
                                                    
                                                    BEGIN UPDATE MSM.ProductInventory SET Quantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) - (@newQuantity{Rows})) WHERE prodID = @prodID{Rows} END;

                                                    DECLARE @Quantity{Rows} decimal(16,8) = (select UnitQnty from MSM.ProductMaster where PID = @prodID{Rows});
                                                    DECLARE @altQuantity{Rows} decimal(16,8) = (select AltUnitQnty from MSM.ProductMaster where PID = @prodID{Rows});

                                                    if @Quantity{Rows} = @altQuantity{Rows} 
                                        	            Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;
                                                    if @Quantity{Rows} > @altQuantity{Rows}
                                        	            Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) / (select UnitQnty from msm.ProductMaster where PID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;
                                                    if @Quantity{Rows} < @altQuantity{Rows}
                                        	            Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) * (select AltUnitQnty from msm.ProductMaster where PID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;"
                                                );
                                        }
                                        else
                                        {
                                            cmdTextDetails.Append
                                                ($@"
                                                    DECLARE @prodID{Rows} int = {dgv.Cells["PID"].Value};
                                                    DECLARE @newQuantity{Rows} decimal(16,8) = {dgv.Cells["Quantity"].Value};
                                                    
                                                    BEGIN UPDATE MSM.ProductInventory SET Quantity = (((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) + (SELECT oldQuantity FROM @OldValues WHERE oPID = @prodID{Rows})) - (@newQuantity{Rows})) WHERE prodID = @prodID{Rows} END;

                                                    DECLARE @Quantity{Rows} decimal(16,8) = (select UnitQnty from MSM.ProductMaster where PID = @prodID{Rows});
                                                    DECLARE @altQuantity{Rows} decimal(16,8) = (select AltUnitQnty from MSM.ProductMaster where PID = @prodID{Rows});

                                                    if @Quantity{Rows} = @altQuantity{Rows} 
                                        	            Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;
                                                    if @Quantity{Rows} > @altQuantity{Rows}
                                        	            Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) / (select UnitQnty from msm.ProductMaster where PID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;
                                                    if @Quantity{Rows} < @altQuantity{Rows}
                                        	            Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) * (select AltUnitQnty from msm.ProductMaster where PID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;"
                                                );
                                        }

                                        cmdTextDetails.Append("\n");
                                    }
                                }
                            }
                            break;
                        }
                    case "DELETE":
                        {
                            cmdTextMaster.Append($@"UPDATE [MSM].[PurchaseReturnMaster] SET is_Deleted = 'True' WHERE [PRID] = {PR_Details.PRID} and [PRVNUM] = '{PR_Details.PRVNUM}'; UPDATE [MSM].[PurchaseReturnDetails] set is_Deleted = 'True' WHERE [PRID] = {PR_Details.PRID} and [PRVNUM] = '{PR_Details.PRVNUM}';");
                            cmdTextDetails.Append("\n");
                            if (PR_Details.GetGridViewData != null && PR_Details.GetGridViewData.RowCount > 0)
                            {
                                var Rows = 0;
                                foreach (DataGridViewRow dgv in PR_Details.GetGridViewData.Rows)
                                {
                                    Rows++;
                                    cmdTextDetails.Append($@"
                                        DECLARE @prodID{Rows} int = {dgv.Cells["PID"].Value};
                                        DECLARE @IncQuantity{Rows} decimal(16,8) = {dgv.Cells["Quantity"].Value};
                                        DECLARE @Quantity{Rows} decimal(16,8) = (select UnitQnty from MSM.ProductMaster where PID = @prodID{Rows});
                                        DECLARE @altQuantity{Rows} decimal(16,8) = (select AltUnitQnty from MSM.ProductMaster where PID = @prodID{Rows});
                                        Begin update MSM.ProductInventory set Quantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) + @IncQuantity{Rows}) where prodID = @prodID{Rows} end; 
                                        if @Quantity{Rows} = @altQuantity{Rows} 
                                        	Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;
                                        if @Quantity{Rows} > @altQuantity{Rows}
                                        	Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) / (select UnitQnty from msm.ProductMaster where PID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;
                                        if @Quantity{Rows} < @altQuantity{Rows}
                                        	Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) * (select AltUnitQnty from msm.ProductMaster where PID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;"
                                    );
                                }
                            }
                            break;
                        }                        
                }
                var IsMasterOk = Execute.ExecuteNonQueryOnMain(cmdTextMaster.ToString());
                var IsDetailsOk = Execute.ExecuteNonQueryOnMain(cmdTextDetails.ToString());
                if (IsMasterOk <= 0 && IsDetailsOk <= 0) return 0;
                return IsMasterOk;
            }
            catch
            {
                return 0;
            }

        }

        public int GetSalesEntrySetup()
        {
            try
            {
                var cmdTextMaster = new StringBuilder();
                var cmdTextDetails = new StringBuilder();
                if (SE_Master.ToPerform == null && PR_Details.ToPerform == null) return 0;
                switch (SE_Master.ToPerform.ToUpper())
                {
                    case "INSERT":
                        {
                            cmdTextMaster.Append("INSERT INTO MSM.SalesMaster(SAID,SVNUM,Sales_Date,Sales_Miti,SalerID,BuyerID,TransectionOn,Total,Vat,VatAmt,TotalAmount,Discount,DiscAmount,BillTotal,receivedAmt,changeGiven,dueBalance,InWords,is_hold,is_Paid,is_complete_paid,Note,is_Deleted,UserID,DateCreated,MUserID,ModifiedDate,extraNote) \n VALUES(");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SE_Master.SAID.ToString()) ? $@"{SE_Master.SAID}," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SE_Master.SVNUM.ToString()) ? $@"'{SE_Master.SVNUM}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SE_Master.Sales_Date.ToString()) ? $@"'{SE_Master.Sales_Date}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SE_Master.Sales_Miti.ToString()) ? $@"'{SE_Master.Sales_Miti}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SE_Master.SalerID.ToString()) ? $@"{SE_Master.SalerID}," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SE_Master.BuyerID.ToString()) ? $@"{SE_Master.BuyerID}," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SE_Master.TransectionOn.ToString()) ? $@"'{SE_Master.TransectionOn}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SE_Master.Total.ToString()) ? $@"'{SE_Master.Total}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SE_Master.Vat.ToString()) ? $@"'{SE_Master.Vat}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SE_Master.VatAmt.ToString()) ? $@"'{SE_Master.VatAmt}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SE_Master.TotalAmount.ToString()) ? $@"'{SE_Master.TotalAmount}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SE_Master.Discount.ToString()) ? $@"'{SE_Master.Discount}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SE_Master.DiscAmount.ToString()) ? $@"'{SE_Master.DiscAmount}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SE_Master.BillTotal.ToString()) ? $@"'{SE_Master.BillTotal}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SE_Master.receivedAmt.ToString()) ? $@"'{SE_Master.receivedAmt}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SE_Master.changeGiven.ToString()) ? $@"'{SE_Master.changeGiven}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SE_Master.dueBalance.ToString()) ? $@"'{SE_Master.dueBalance}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SE_Master.InWords.ToString()) ? $@"'{SE_Master.InWords}'," : "NULL,");
                            cmdTextMaster.Append($@"CAST('{SE_Master.is_hold}' AS BIT),");
                            cmdTextMaster.Append($@"CAST('{SE_Master.is_Paid}' AS BIT),");
                            cmdTextMaster.Append($@"CAST('{SE_Master.is_complete_paid}' AS BIT),");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SE_Master.Note.ToString()) ? $@"'{SE_Master.Note}'," : "NULL,");
                            cmdTextMaster.Append($@"CAST('{SE_Master.is_Deleted}' AS BIT),");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SE_Master.UserID.ToString()) ? $@"{SE_Master.UserID}," : "NULL,");
                            cmdTextMaster.Append("GETDATE(),NULL,NULL,NULL);");

                            if (SE_Details.GetGridViewData != null && SE_Details.GetGridViewData.RowCount > 0)
                            {
                                var Rows = 0;
                                foreach (DataGridViewRow dgv in SE_Details.GetGridViewData.Rows)
                                {
                                    Rows++;
                                    cmdTextDetails.Append("\nINSERT INTO [MSM].[SalesDetails](SAID,SVNUM,PID,PName,PCode,PBarcode,Quantiy,UnitID,PPrice,pDisc,pamount,TotalPrice,Note,UserID,DateCreated,MUserID,ModifiedDate,is_Deleted) \n VALUES(");
                                    cmdTextDetails.Append(!string.IsNullOrEmpty(SE_Details.SAID.ToString()) ? $@"{SE_Details.SAID}," : "NULL,");
                                    cmdTextDetails.Append(!string.IsNullOrEmpty(SE_Details.SVNUM.ToString()) ? $@"'{SE_Details.SVNUM}'," : "NULL,");
                                    cmdTextDetails.Append($"{dgv.Cells["PID"].Value},");
                                    cmdTextDetails.Append(dgv.Cells["Product"].Value.ToString() != null ? $"'{dgv.Cells["Product"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["Short Name"].Value.ToString() != null ? $"'{dgv.Cells["Short Name"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["BarCode"].Value.ToString() != null ? $"'{dgv.Cells["BarCode"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["Quantity"].Value.ToString() != null ? $"'{dgv.Cells["Quantity"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["Unit"].Value.ToString() != null ? $"(select UnitID  from MSM.UnitMaster where UnitCode ='{dgv.Cells["Unit"].Value}')," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["s. Price"].Value.ToString() != null ? $"'{dgv.Cells["s. Price"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["s. Disc"].Value.ToString() != null ? $"'{dgv.Cells["s. Disc"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["s. Disc Amt"].Value.ToString() != null ? $"'{dgv.Cells["s. Disc Amt"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["Total"].Value.ToString() != null ? $"'{dgv.Cells["Total"].Value}'," : "NULL,");
                                    cmdTextDetails.Append("NULL,");
                                    cmdTextDetails.Append(!string.IsNullOrEmpty(SE_Details.UserID.ToString()) ? $@"{SE_Master.UserID}," : "NULL,");
                                    cmdTextDetails.Append(SE_Details.DateCreated.ToString() != "1/1/0001 12:00:00 AM" ? $@"'{SE_Details.DateCreated}'," : "GETDATE(),");
                                    cmdTextDetails.Append("NULL,NULL,");
                                    cmdTextDetails.Append($@"CAST('{SE_Master.is_Deleted}' AS BIT));");
                                    cmdTextDetails.Append("\n");

                                    cmdTextDetails.Append($@"
                                        DECLARE @prodID{Rows} int = {dgv.Cells["PID"].Value};
                                        DECLARE @IncQuantity{Rows} decimal(16,8) = {dgv.Cells["Quantity"].Value};
                                        DECLARE @Quantity{Rows} decimal(16,8) = (select UnitQnty from MSM.ProductMaster where PID = @prodID{Rows});
                                        DECLARE @altQuantity{Rows} decimal(16,8) = (select AltUnitQnty from MSM.ProductMaster where PID = @prodID{Rows});
                                        Begin update MSM.ProductInventory set Quantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) - @IncQuantity{Rows}) where prodID = @prodID{Rows} end; 
                                        if @Quantity{Rows} = @altQuantity{Rows} 
                                        	Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;
                                        if @Quantity{Rows} > @altQuantity{Rows}
                                        	Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) / (select UnitQnty from msm.ProductMaster where PID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;
                                        if @Quantity{Rows} < @altQuantity{Rows}
                                        	Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) * (select AltUnitQnty from msm.ProductMaster where PID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;"
                                    );
                                    cmdTextDetails.Append("\n");
                                }
                            }
                            break;
                        }
                    case "UPDATE":
                        {
                            cmdTextMaster.Append("\n");
                            cmdTextMaster.Append("UPDATE [MSM].[SalesMaster] SET ");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SE_Master.Sales_Date.ToString()) ? $@"[Sales_Date] = '{SE_Master.Sales_Date}'," : "[Sales_Date] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SE_Master.Sales_Miti.ToString()) ? $@"[Sales_Miti] = '{SE_Master.Sales_Miti}'," : "[Sales_Miti] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SE_Master.SalerID.ToString()) ? $@"[SalerID] = {SE_Master.SalerID}," : "[SalerID] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SE_Master.BuyerID.ToString()) ? $@"[BuyerID] = {SE_Master.BuyerID}," : "[BuyerID] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SE_Master.TransectionOn.ToString()) ? $@"[TransectionOn] = '{SE_Master.TransectionOn}'," : "[TransectionOn] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SE_Master.Total.ToString()) ? $@"[Total] = '{SE_Master.Total}'," : "[Total] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SE_Master.Vat.ToString()) ? $@"[Vat] = '{SE_Master.Vat}'," : "[Vat] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SE_Master.VatAmt.ToString()) ? $@"[VatAmt] = '{SE_Master.VatAmt}'," : "[VatAmt] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SE_Master.TotalAmount.ToString()) ? $@"[TotalAmount] = '{SE_Master.TotalAmount}'," : "[TotalAmount] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SE_Master.Discount.ToString()) ? $@"[Discount] = '{SE_Master.Discount}'," : "[Discount] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SE_Master.DiscAmount.ToString()) ? $@"[DiscAmount] = '{SE_Master.DiscAmount}'," : "[DiscAmount] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SE_Master.BillTotal.ToString()) ? $@"[BillTotal] = '{SE_Master.BillTotal}'," : "[BillTotal] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SE_Master.receivedAmt.ToString()) ? $@"[receivedAmt] = '{SE_Master.receivedAmt}'," : "[receivedAmt] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SE_Master.changeGiven.ToString()) ? $@"[changeGiven] = '{SE_Master.changeGiven}'," : "[changeGiven] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SE_Master.dueBalance.ToString()) ? $@"[dueBalance] = '{SE_Master.dueBalance}'," : "[dueBalance] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SE_Master.InWords.ToString()) ? $@"[InWords] = '{SE_Master.InWords}'," : "[InWords] = NULL,");
                            cmdTextMaster.Append($@"[is_hold] = CAST('{SE_Master.is_hold}' AS BIT),");
                            cmdTextMaster.Append($@"[is_Paid] = CAST('{SE_Master.is_Paid}' AS BIT),");
                            cmdTextMaster.Append($@"[is_complete_paid] = CAST('{SE_Master.is_complete_paid}' AS BIT),");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SE_Master.Note.ToString()) ? $@"[Note] = '{SE_Master.Note}'," : "[Note] = NULL,");
                            cmdTextMaster.Append($@"[is_Deleted] = CAST('False' AS BIT),"); //incase of update deleted bill is reset to active again by default.
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SE_Master.UserID.ToString()) ? $@"[MUserID] = {SE_Master.UserID}," : "[MUserID] = NULL,");
                            cmdTextMaster.Append("[ModifiedDate] = GETDATE()");
                            cmdTextMaster.Append($@" WHERE [SAID] = {SE_Master.SAID} and [SVNUM] = '{SE_Master.SVNUM}';");
                            cmdTextDetails.Append("\n");

                            cmdTextDetails.Append($@"DELETE FROM [MSM].[SalesDetails] WHERE [SAID] = {SE_Master.SAID} and [SVNUM] = '{SE_Master.SVNUM}';");
                            cmdTextDetails.Append("\n");

                            if (SE_Details.GetGridViewData != null && SE_Details.GetGridViewData.RowCount > 0)
                            {
                                var Rows = 0;
                                var uRows = 0;

                                //to channge inventory collection of the old values to calculate difference.
                                if (SE_Master.ToPerform.ToUpper() == "UPDATE" && SE_Details.updateGetGridViewData != null && SE_Details.updateGetGridViewData.RowCount > 0)
                                {
                                    cmdTextDetails.Append("\n");
                                    cmdTextDetails.Append("Declare @OldValues TABLE (oPID int, oldQuantity DECIMAL(16,8));\n");
                                    foreach (DataGridViewRow udgv in SE_Details.updateGetGridViewData.Rows) //check why here it is accepting new changed value
                                    {
                                        uRows++;
                                        cmdTextDetails.Append($@"INSERT INTO @OldValues (oPID,oldQuantity) VALUES({udgv.Cells["PID"].Value},{udgv.Cells["Quantity"].Value});");
                                        cmdTextDetails.Append("\n");
                                    }
                                    cmdTextDetails.Append("\n");
                                    foreach (DataGridViewRow dgv in SE_Details.GetGridViewData.Rows)
                                    {
                                        Rows++;
                                        cmdTextDetails.Append("\nINSERT INTO [MSM].[SalesDetails](SAID,SVNUM,PID,PName,PCode,PBarcode,Quantiy,UnitID,PPrice,pDisc,pamount,TotalPrice,Note,UserID,DateCreated,MUserID,ModifiedDate,is_Deleted) \n VALUES(");
                                        cmdTextDetails.Append(!string.IsNullOrEmpty(SE_Details.SAID.ToString()) ? $@"{SE_Details.SAID}," : "NULL,");
                                        cmdTextDetails.Append(!string.IsNullOrEmpty(SE_Details.SVNUM.ToString()) ? $@"'{SE_Details.SVNUM}'," : "NULL,");
                                        cmdTextDetails.Append($"{dgv.Cells["PID"].Value},");
                                        cmdTextDetails.Append(dgv.Cells["Product"].Value.ToString() != null ? $"'{dgv.Cells["Product"].Value}'," : "NULL,");
                                        cmdTextDetails.Append(dgv.Cells["Short Name"].Value.ToString() != null ? $"'{dgv.Cells["Short Name"].Value}'," : "NULL,");
                                        cmdTextDetails.Append(dgv.Cells["BarCode"].Value.ToString() != null ? $"'{dgv.Cells["BarCode"].Value}'," : "NULL,");
                                        cmdTextDetails.Append(dgv.Cells["Quantity"].Value.ToString() != null ? $"'{dgv.Cells["Quantity"].Value}'," : "NULL,");
                                        cmdTextDetails.Append(dgv.Cells["Unit"].Value.ToString() != null ? $"(select UnitID  from MSM.UnitMaster where UnitCode ='{dgv.Cells["Unit"].Value}')," : "NULL,");
                                        cmdTextDetails.Append(dgv.Cells["s. Price"].Value.ToString() != null ? $"'{dgv.Cells["s. Price"].Value}'," : "NULL,");
                                        cmdTextDetails.Append(dgv.Cells["s. Disc"].Value.ToString() != null ? $"'{dgv.Cells["s. Disc"].Value}'," : "NULL,");
                                        cmdTextDetails.Append(dgv.Cells["s. Disc Amt"].Value.ToString() != null ? $"'{dgv.Cells["s. Disc Amt"].Value}'," : "NULL,");
                                        cmdTextDetails.Append(dgv.Cells["Total"].Value.ToString() != null ? $"'{dgv.Cells["Total"].Value}'," : "NULL,");
                                        cmdTextDetails.Append("NULL,");
                                        cmdTextDetails.Append(!string.IsNullOrEmpty(SE_Details.UserID.ToString()) ? $@"{SE_Master.UserID}," : "NULL,");
                                        cmdTextDetails.Append(SE_Details.DateCreated.ToString() != "1/1/0001 12:00:00 AM" ? $@"'{SE_Details.DateCreated}'," : "GETDATE(),");
                                        cmdTextDetails.Append("NULL,NULL,");
                                        cmdTextDetails.Append($@"CAST('False' AS BIT));");
                                        cmdTextDetails.Append("\n");

                                        if (SE_Master.is_Deleted == true)
                                        {
                                            cmdTextDetails.Append
                                                ($@"
                                                    DECLARE @prodID{Rows} int = {dgv.Cells["PID"].Value};
                                                    DECLARE @newQuantity{Rows} decimal(16,8) = {dgv.Cells["Quantity"].Value};
                                                    
                                                    BEGIN UPDATE MSM.ProductInventory SET Quantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) - (@newQuantity{Rows})) WHERE prodID = @prodID{Rows} END;

                                                    DECLARE @Quantity{Rows} decimal(16,8) = (select UnitQnty from MSM.ProductMaster where PID = @prodID{Rows});
                                                    DECLARE @altQuantity{Rows} decimal(16,8) = (select AltUnitQnty from MSM.ProductMaster where PID = @prodID{Rows});

                                                    if @Quantity{Rows} = @altQuantity{Rows} 
                                        	            Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;
                                                    if @Quantity{Rows} > @altQuantity{Rows}
                                        	            Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) / (select UnitQnty from msm.ProductMaster where PID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;
                                                    if @Quantity{Rows} < @altQuantity{Rows}
                                        	            Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) * (select AltUnitQnty from msm.ProductMaster where PID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;"
                                                );
                                        }
                                        else
                                        {
                                            cmdTextDetails.Append
                                                ($@"
                                                    DECLARE @prodID{Rows} int = {dgv.Cells["PID"].Value};
                                                    DECLARE @newQuantity{Rows} decimal(16,8) = {dgv.Cells["Quantity"].Value};
                                                    
                                                    BEGIN UPDATE MSM.ProductInventory SET Quantity = (((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) + (SELECT oldQuantity FROM @OldValues WHERE oPID = @prodID{Rows})) - (@newQuantity{Rows})) WHERE prodID = @prodID{Rows} END;

                                                    DECLARE @Quantity{Rows} decimal(16,8) = (select UnitQnty from MSM.ProductMaster where PID = @prodID{Rows});
                                                    DECLARE @altQuantity{Rows} decimal(16,8) = (select AltUnitQnty from MSM.ProductMaster where PID = @prodID{Rows});

                                                    if @Quantity{Rows} = @altQuantity{Rows} 
                                        	            Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;
                                                    if @Quantity{Rows} > @altQuantity{Rows}
                                        	            Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) / (select UnitQnty from msm.ProductMaster where PID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;
                                                    if @Quantity{Rows} < @altQuantity{Rows}
                                        	            Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) * (select AltUnitQnty from msm.ProductMaster where PID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;"
                                                );
                                        }

                                        cmdTextDetails.Append("\n");
                                    }
                                }
                            }
                            break;
                        }
                    case "DELETE":
                        {
                            cmdTextMaster.Append($@"UPDATE [MSM].[SalesMaster] SET is_Deleted = 'True' WHERE [SAID] = {SE_Details.SAID} and [SVNUM] = '{SE_Details.SVNUM}'; UPDATE [MSM].[SalesDetails] set is_Deleted = 'True' WHERE [SAID] = {SE_Details.SAID} and [SVNUM] = '{SE_Details.SVNUM}';");
                            cmdTextDetails.Append("\n");
                            if (SE_Details.GetGridViewData != null && SE_Details.GetGridViewData.RowCount > 0)
                            {
                                var Rows = 0;
                                foreach (DataGridViewRow dgv in SE_Details.GetGridViewData.Rows)
                                {
                                    Rows++;
                                    cmdTextDetails.Append($@"
                                        DECLARE @prodID{Rows} int = {dgv.Cells["PID"].Value};
                                        DECLARE @IncQuantity{Rows} decimal(16,8) = {dgv.Cells["Quantity"].Value};
                                        DECLARE @Quantity{Rows} decimal(16,8) = (select UnitQnty from MSM.ProductMaster where PID = @prodID{Rows});
                                        DECLARE @altQuantity{Rows} decimal(16,8) = (select AltUnitQnty from MSM.ProductMaster where PID = @prodID{Rows});
                                        Begin update MSM.ProductInventory set Quantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) + @IncQuantity{Rows}) where prodID = @prodID{Rows} end; 
                                        if @Quantity{Rows} = @altQuantity{Rows} 
                                        	Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;
                                        if @Quantity{Rows} > @altQuantity{Rows}
                                        	Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) / (select UnitQnty from msm.ProductMaster where PID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;
                                        if @Quantity{Rows} < @altQuantity{Rows}
                                        	Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) * (select AltUnitQnty from msm.ProductMaster where PID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;"
                                    );
                                }
                            }
                            break;
                        }
                }
                var IsMasterOk = Execute.ExecuteNonQueryOnMain(cmdTextMaster.ToString());
                var IsDetailsOk = Execute.ExecuteNonQueryOnMain(cmdTextDetails.ToString());
                if (IsMasterOk <= 0 && IsDetailsOk <= 0) return 0;
                return IsMasterOk;
            }
            catch
            {
                return 0;
            }

        }

        public int GetSalesReturnSetup()
        {
            try
            {
                var cmdTextMaster = new StringBuilder();
                var cmdTextDetails = new StringBuilder();
                if (SR_Master.ToPerform == null && SR_Details.ToPerform == null) return 0;
                switch (SR_Master.ToPerform.ToUpper())
                {
                    case "INSERT":
                        {
                            cmdTextMaster.Append("INSERT INTO [MSM].[SalesReturnMaster]([SRID],[SRVNUM],[Sales_Date],[Sales_Miti],[Return_Date],[SalerID],[BuyerID],[TransectionOn],[Total],[Vat],[VatAmt],[TotalAmount],[Discount],[DiscAmount],[BillTotal],[InWords],[Note],[is_Deleted],[UserID],[DateCreated],[MUserID],[ModifiedDate],[extraNote],[status],[paid_amount],[return_amount],[SAID],[SVNUM],[previous_balance],[sales_bill_amt])VALUES(");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.SRID.ToString()) ? $@"{SR_Master.SRID}," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.SRVNUM.ToString()) ? $@"'{SR_Master.SRVNUM}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.Sales_Date.ToString()) ? $@"'{SR_Master.Sales_Date}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.Sales_Miti.ToString()) ? $@"'{SR_Master.Sales_Miti}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.Return_Date.ToString()) ? $@"'{SR_Master.Return_Date}'," : "NULL,");
                            //cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.ref_bill_No.ToString()) ? $@"'{SR_Master.ref_bill_No}'," : "NULL,");                            
                            //cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.PO_ReferenceNo.ToString()) ? $@"'{SR_Master.PO_ReferenceNo}'," : "'N/A',");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.SalerID.ToString()) ? $@"{SR_Master.SalerID}," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.BuyerID.ToString()) ? $@"{SR_Master.BuyerID}," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.TransectionOn.ToString()) ? $@"'{SR_Master.TransectionOn}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.Total.ToString()) ? $@"'{SR_Master.Total}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.Vat.ToString()) ? $@"'{SR_Master.Vat}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.VatAmt.ToString()) ? $@"'{SR_Master.VatAmt}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.TotalAmount.ToString()) ? $@"'{SR_Master.TotalAmount}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.Discount.ToString()) ? $@"'{SR_Master.Discount}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.DiscAmount.ToString()) ? $@"'{SR_Master.DiscAmount}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.BillTotal.ToString()) ? $@"'{SR_Master.BillTotal}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.InWords.ToString()) ? $@"'{SR_Master.InWords}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.Note.ToString()) ? $@"'{SR_Master.Note}'," : "NULL,");
                            cmdTextMaster.Append($@"CAST('{SR_Master.is_Deleted}' AS BIT),");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.UserID.ToString()) ? $@"{SR_Master.UserID}," : "NULL,");
                            cmdTextMaster.Append("GETDATE(),NULL,NULL,NULL,");
                            //cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.extraNote.ToString()) ? $@"'{SR_Master.extraNote}'," : "NULL,");
                            cmdTextMaster.Append($@"CAST('{SR_Master.status}' AS BIT),");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.paid_amount.ToString()) ? $@"'{SR_Master.paid_amount}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.return_amount.ToString()) ? $@"'{SR_Master.return_amount}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.SRID.ToString()) ? $@"{SR_Master.SAID}," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.SVNUM.ToString()) ? $@"'{SR_Master.SVNUM}'," : "NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.previous_balance.ToString()) ? $@"'{SR_Master.previous_balance}'," : "NULL,"); 
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.sales_bill_amt.ToString()) ? $@"'{SR_Master.sales_bill_amt}');" : "NULL);");
                            if (SR_Details.GetGridViewData != null && SR_Details.GetGridViewData.RowCount > 0)
                            {
                                var Rows = 0;
                                foreach (DataGridViewRow dgv in SR_Details.GetGridViewData.Rows)
                                {
                                    Rows++;
                                    cmdTextDetails.Append("\nINSERT INTO [MSM].[SalesReturnDetails]([SRID],[SRVNUM],[PID],[PName],[PCode],[PBarcode],[Quantiy],[UnitID],[PPrice],[pDisc],[pamount],[TotalPrice],[Note],[UserID],[DateCreated],[MUserID],[ModifiedDate],[is_Deleted]) \n VALUES");
                                    cmdTextDetails.Append(!string.IsNullOrEmpty(SR_Details.SRID.ToString()) ? $@"({SR_Details.SRID}," : "NULL,");
                                    cmdTextDetails.Append(!string.IsNullOrEmpty(SR_Details.SRVNUM.ToString()) ? $@"'{SR_Details.SRVNUM}'," : "NULL,");
                                    cmdTextDetails.Append($"{dgv.Cells["PID"].Value},");
                                    cmdTextDetails.Append(dgv.Cells["Product"].Value.ToString() != null ? $"'{dgv.Cells["Product"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["Short Name"].Value.ToString() != null ? $"'{dgv.Cells["Short Name"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["BarCode"].Value.ToString() != null ? $"'{dgv.Cells["BarCode"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["Quantity"].Value.ToString() != null ? $"'{dgv.Cells["Quantity"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["Unit"].Value.ToString() != null ? $"(select UnitID  from MSM.UnitMaster where UnitCode ='{dgv.Cells["Unit"].Value}')," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["s. Price"].Value.ToString() != null ? $"'{dgv.Cells["s. Price"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["s. Disc"].Value.ToString() != null ? $"'{dgv.Cells["s. Disc"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["s. Disc Amt"].Value.ToString() != null ? $"'{dgv.Cells["s. Disc Amt"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["Total"].Value.ToString() != null ? $"'{dgv.Cells["Total"].Value}'," : "NULL,");
                                    cmdTextDetails.Append("NULL,");
                                    cmdTextDetails.Append(!string.IsNullOrEmpty(SR_Master.UserID.ToString()) ? $@"{SR_Master.UserID}," : "NULL,");
                                    cmdTextDetails.Append(SR_Master.DateCreated.ToString() != "1/1/0001 12:00:00 AM" ? $@"'{SR_Master.DateCreated}'," : "GETDATE(),");
                                    cmdTextDetails.Append("NULL,NULL,");
                                    cmdTextDetails.Append($@"CAST('{SR_Master.is_Deleted}' AS BIT));");
                                    cmdTextDetails.Append("\n");

                                    cmdTextDetails.Append($@"
                                        DECLARE @prodID{Rows} int = {dgv.Cells["PID"].Value};
                                        DECLARE @IncQuantity{Rows} decimal(16,8) = {dgv.Cells["Quantity"].Value};
                                        DECLARE @Quantity{Rows} decimal(16,8) = (select UnitQnty from MSM.ProductMaster where PID = @prodID{Rows});
                                        DECLARE @altQuantity{Rows} decimal(16,8) = (select AltUnitQnty from MSM.ProductMaster where PID = @prodID{Rows});
                                        Begin update MSM.ProductInventory set Quantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) + @IncQuantity{Rows}) where prodID = @prodID{Rows} end; 
                                        if @Quantity{Rows} = @altQuantity{Rows} 
                                        	Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;
                                        if @Quantity{Rows} > @altQuantity{Rows}
                                        	Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) / (select UnitQnty from msm.ProductMaster where PID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;
                                        if @Quantity{Rows} < @altQuantity{Rows}
                                        	Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) * (select AltUnitQnty from msm.ProductMaster where PID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;"
                                    );
                                    cmdTextDetails.Append("\n");
                                }
                            }
                            break;
                        }
                    case "UPDATE":
                        {
                            cmdTextDetails.Append("\n");
                            cmdTextMaster.Append("UPDATE [MSM].[SalesReturnMaster] SET");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.Sales_Date.ToString()) ? $@"[Sales_Date] = '{SR_Master.Sales_Date}'," : "[Sales_Date] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.Sales_Miti.ToString()) ? $@"[Sales_Miti] = '{SR_Master.Sales_Miti}'," : "[Sales_Miti] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.Return_Date.ToString()) ? $@"[Return_Date] = '{SR_Master.Return_Date}'," : "[Return_Date] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.SalerID.ToString()) ? $@"[SalerID] = {SR_Master.SalerID}," : "[SalerID] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.BuyerID.ToString()) ? $@"[BuyerID] = {SR_Master.BuyerID}," : "[BuyerID] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.TransectionOn.ToString()) ? $@"[TransectionOn] = '{SR_Master.TransectionOn}'," : "[TransectionOn] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.Total.ToString()) ? $@"[Total] = '{SR_Master.Total}'," : "[Total] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.Vat.ToString()) ? $@"[Vat] = '{SR_Master.Vat}'," : "[Vat] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.VatAmt.ToString()) ? $@"[VatAmt] = '{SR_Master.VatAmt}'," : "[VatAmt] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.TotalAmount.ToString()) ? $@"[TotalAmount] = '{SR_Master.TotalAmount}'," : "[TotalAmount] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.Discount.ToString()) ? $@"[Discount] = '{SR_Master.Discount}'," : "[Discount] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.DiscAmount.ToString()) ? $@"[DiscAmount] = '{SR_Master.DiscAmount}'," : "[DiscAmount] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.BillTotal.ToString()) ? $@"[BillTotal] = '{SR_Master.BillTotal}'," : "[BillTotal] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.InWords.ToString()) ? $@"[InWords] = '{SR_Master.InWords}'," : "[InWords] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.Note.ToString()) ? $@"[Note] = '{SR_Master.Note}'," : "[Note] = NULL,");
                            cmdTextMaster.Append($@"[is_Deleted] = CAST('False' AS BIT),"); //incase of update deleted bill is reset to active again by default.
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.UserID.ToString()) ? $@"[MUserID] = {SR_Master.UserID}," : "[MUserID] = NULL,");
                            cmdTextMaster.Append("[ModifiedDate] = GETDATE(),");
                            //cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.extraNote.ToString()) ? $@"[extraNote] = '{SR_Master.extraNote}'," : "[extraNote] = NULL,"); //not required no need to update
                            //,[paid_amount],[return_amount]
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.paid_amount.ToString()) ? $@"[paid_amount] = '{SR_Master.paid_amount}'," : "[paid_amount] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(SR_Master.return_amount.ToString()) ? $@"[return_amount] = '{SR_Master.return_amount}'" : "[return_amount] = NULL");
                            cmdTextDetails.Append("\n");
                            cmdTextMaster.Append($@"WHERE [SRID] = {SR_Master.SRID} and [SRVNUM] = '{SR_Master.SRVNUM}';");
                            cmdTextDetails.Append("\n");

                            cmdTextDetails.Append($@"DELETE FROM [MSM].[SalesReturnDetails] WHERE [SRID] = {SR_Master.SRID} and [SRVNUM] = '{SR_Master.SRVNUM}';");
                            cmdTextDetails.Append("\n");

                            if (SR_Details.GetGridViewData != null && SR_Details.GetGridViewData.RowCount > 0)
                            {
                                var Rows = 0;
                                var uRows = 0;

                                //to channge inventory collection of the old values to calculate difference.
                                if (SR_Master.ToPerform.ToUpper() == "UPDATE" && SR_Details.updateGetGridViewData != null && SR_Details.updateGetGridViewData.RowCount > 0)
                                {
                                    cmdTextDetails.Append("\n");
                                    cmdTextDetails.Append("Declare @OldValues TABLE (oPID int, oldQuantity DECIMAL(16,8));\n");
                                    foreach (DataGridViewRow udgv in SR_Details.updateGetGridViewData.Rows) //check why here it is accepting new changed value
                                    {
                                        uRows++;
                                        cmdTextDetails.Append($@"INSERT INTO @OldValues (oPID,oldQuantity) VALUES({udgv.Cells["PID"].Value},{udgv.Cells["Quantity"].Value});");
                                        cmdTextDetails.Append("\n");
                                    }
                                    cmdTextDetails.Append("\n");
                                    foreach (DataGridViewRow dgv in SR_Details.GetGridViewData.Rows)
                                    {
                                        Rows++;
                                        cmdTextDetails.Append("\nINSERT INTO [MSM].[SalesReturnDetails]([SRID],[SRVNUM],[PID],[PName],[PCode],[PBarcode],[Quantiy],[UnitID],[PPrice],[pDisc],[pamount],[TotalPrice],[Note],[UserID],[DateCreated],[MUserID],[ModifiedDate],[is_Deleted]) \n VALUES");
                                        cmdTextDetails.Append(!string.IsNullOrEmpty(SR_Details.SRID.ToString()) ? $@"({SR_Details.SRID}," : "NULL,");
                                        cmdTextDetails.Append(!string.IsNullOrEmpty(SR_Details.SRVNUM.ToString()) ? $@"'{SR_Details.SRVNUM}'," : "NULL,");
                                        cmdTextDetails.Append($"{dgv.Cells["PID"].Value},");
                                        cmdTextDetails.Append(dgv.Cells["Product"].Value.ToString() != null ? $"'{dgv.Cells["Product"].Value}'," : "NULL,");
                                        cmdTextDetails.Append(dgv.Cells["Short Name"].Value.ToString() != null ? $"'{dgv.Cells["Short Name"].Value}'," : "NULL,");
                                        cmdTextDetails.Append(dgv.Cells["BarCode"].Value.ToString() != null ? $"'{dgv.Cells["BarCode"].Value}'," : "NULL,");
                                        cmdTextDetails.Append(dgv.Cells["Quantity"].Value.ToString() != null ? $"'{dgv.Cells["Quantity"].Value}'," : "NULL,");
                                        cmdTextDetails.Append(dgv.Cells["Unit"].Value.ToString() != null ? $"(select UnitID  from MSM.UnitMaster where UnitCode ='{dgv.Cells["Unit"].Value}')," : "NULL,");
                                        cmdTextDetails.Append(dgv.Cells["s. Price"].Value.ToString() != null ? $"'{dgv.Cells["s. Price"].Value}'," : "NULL,");
                                        cmdTextDetails.Append(dgv.Cells["s. Disc"].Value.ToString() != null ? $"'{dgv.Cells["s. Disc"].Value}'," : "NULL,");
                                        cmdTextDetails.Append(dgv.Cells["s. Disc Amt"].Value.ToString() != null ? $"'{dgv.Cells["s. Disc Amt"].Value}'," : "NULL,");
                                        cmdTextDetails.Append(dgv.Cells["Total"].Value.ToString() != null ? $"'{dgv.Cells["Total"].Value}'," : "NULL,");
                                        cmdTextDetails.Append("NULL,");
                                        cmdTextDetails.Append(!string.IsNullOrEmpty(SR_Master.UserID.ToString()) ? $@"{SR_Master.UserID}," : "NULL,");
                                        cmdTextDetails.Append(SR_Master.DateCreated.ToString() != "1/1/0001 12:00:00 AM" ? $@"'{SR_Master.DateCreated}'," : "GETDATE(),");
                                        cmdTextDetails.Append("NULL,NULL,");
                                        cmdTextDetails.Append($@"CAST('{SR_Master.is_Deleted}' AS BIT));");
                                        cmdTextDetails.Append("\n");

                                        if (SR_Master.is_Deleted == true)
                                        {
                                            cmdTextDetails.Append
                                                ($@"
                                                    DECLARE @prodID{Rows} int = {dgv.Cells["PID"].Value};
                                                    DECLARE @newQuantity{Rows} decimal(16,8) = {dgv.Cells["Quantity"].Value};
                                                    
                                                    BEGIN UPDATE MSM.ProductInventory SET Quantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows})+ (@newQuantity{Rows})) WHERE prodID = @prodID{Rows} END;

                                                    DECLARE @Quantity{Rows} decimal(16,8) = (select UnitQnty from MSM.ProductMaster where PID = @prodID{Rows});
                                                    DECLARE @altQuantity{Rows} decimal(16,8) = (select AltUnitQnty from MSM.ProductMaster where PID = @prodID{Rows});

                                                    if @Quantity{Rows} = @altQuantity{Rows} 
                                        	            Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;
                                                    if @Quantity{Rows} > @altQuantity{Rows}
                                        	            Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) / (select UnitQnty from msm.ProductMaster where PID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;
                                                    if @Quantity{Rows} < @altQuantity{Rows}
                                        	            Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) * (select AltUnitQnty from msm.ProductMaster where PID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;"
                                                );
                                        }
                                        else
                                        {
                                            cmdTextDetails.Append
                                                ($@"
                                                    DECLARE @prodID{Rows} int = {dgv.Cells["PID"].Value};
                                                    DECLARE @newQuantity{Rows} decimal(16,8) = {dgv.Cells["Quantity"].Value};
                                                    
                                                    BEGIN UPDATE MSM.ProductInventory SET Quantity = (((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) - (SELECT oldQuantity FROM @OldValues WHERE oPID = @prodID{Rows})) + (@newQuantity{Rows})) WHERE prodID = @prodID{Rows} END;

                                                    DECLARE @Quantity{Rows} decimal(16,8) = (select UnitQnty from MSM.ProductMaster where PID = @prodID{Rows});
                                                    DECLARE @altQuantity{Rows} decimal(16,8) = (select AltUnitQnty from MSM.ProductMaster where PID = @prodID{Rows});

                                                    if @Quantity{Rows} = @altQuantity{Rows} 
                                        	            Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;
                                                    if @Quantity{Rows} > @altQuantity{Rows}
                                        	            Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) / (select UnitQnty from msm.ProductMaster where PID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;
                                                    if @Quantity{Rows} < @altQuantity{Rows}
                                        	            Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) * (select AltUnitQnty from msm.ProductMaster where PID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;"
                                                );
                                        }

                                        cmdTextDetails.Append("\n");
                                    }
                                }
                            }
                            break;
                        }
                    case "DELETE":
                        {
                            cmdTextMaster.Append($@"UPDATE [MSM].[SalesReturnMaster] SET is_Deleted = 'True' WHERE [SRID] = {SR_Details.SRID} and [SRVNUM] = '{SR_Details.SRVNUM}'; UPDATE [MSM].[SalesReturnDetails] set is_Deleted = 'True' WHERE [SRID] = {SR_Details.SRID} and [PVNUM] = '{SR_Details.SRVNUM}';");
                            cmdTextDetails.Append("\n");
                            if (SR_Details.GetGridViewData != null && SR_Details.GetGridViewData.RowCount > 0)
                            {
                                var Rows = 0;
                                foreach (DataGridViewRow dgv in SR_Details.GetGridViewData.Rows)
                                {
                                    Rows++;
                                    cmdTextDetails.Append($@"
                                        DECLARE @prodID{Rows} int = {dgv.Cells["PID"].Value};
                                        DECLARE @IncQuantity{Rows} decimal(16,8) = {dgv.Cells["Quantity"].Value};
                                        DECLARE @Quantity{Rows} decimal(16,8) = (select UnitQnty from MSM.ProductMaster where PID = @prodID{Rows});
                                        DECLARE @altQuantity{Rows} decimal(16,8) = (select AltUnitQnty from MSM.ProductMaster where PID = @prodID{Rows});
                                        Begin update MSM.ProductInventory set Quantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) - @IncQuantity{Rows}) where prodID = @prodID{Rows} end; 
                                        if @Quantity{Rows} = @altQuantity{Rows} 
                                        	Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;
                                        if @Quantity{Rows} > @altQuantity{Rows}
                                        	Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) / (select UnitQnty from msm.ProductMaster where PID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;
                                        if @Quantity{Rows} < @altQuantity{Rows}
                                        	Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID{Rows}) * (select AltUnitQnty from msm.ProductMaster where PID = @prodID{Rows}))  where prodID = @prodID{Rows}  End;"
                                    );
                                }
                            }
                            break;
                        }
                }

                var IsMasterOk = Execute.ExecuteNonQueryOnMain(cmdTextMaster.ToString());
                var IsDetailsOk = Execute.ExecuteNonQueryOnMain(cmdTextDetails.ToString());
                if (IsMasterOk <= 0 && IsDetailsOk <= 0) return 0;
                return IsMasterOk;
            }
            catch
            {
                return 0;
            }
        }

        public int GetOrderTicketSetup()
        {
            try
            {
                var cmdTextMaster = new StringBuilder();
                var cmdTextDetails = new StringBuilder();
                if (OT_Master.ToPerform == null && OT_Details.ToPerform == null) return 0;
                switch (OT_Master.ToPerform.ToUpper())
                {
                    case "INSERT":
                        {
                            cmdTextMaster.Append("INSERT INTO MSM.OrderMaster(OID,OVNUM,Order_Date,Order_Miti,Delivery_Date,Delivery_Miti,SenderID,BuyerID,Est_Time,Note,OrderStatus,is_Deleted,UserID,DateCreated,MUserID,ModifiedDate)VALUES(");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(OT_Master.OID.ToString()) ? $@"{ OT_Master.OID}" : "NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(OT_Master.OVNUM.ToString()) ? $@",'{OT_Master.OVNUM}'" : ",NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(OT_Master.Order_Date.ToString()) ? $@",'{OT_Master.Order_Date}'" : ",NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(OT_Master.Order_Miti.ToString()) ? $@",'{OT_Master.Order_Miti}'" : ",NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(OT_Master.Delivery_Date.ToString()) ? $@",'{OT_Master.Delivery_Date}'" : ",NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(OT_Master.Delivery_Miti.ToString()) ? $@",'{OT_Master.Delivery_Miti}'" : ",NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(OT_Master.SenderID.ToString()) ? $@",'{OT_Master.SenderID}'" : ",NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(OT_Master.BuyerID.ToString()) ? $@",'{OT_Master.BuyerID}'" : ",NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(OT_Master.Est_Time.ToString()) ? $@",'{OT_Master.Est_Time}'" : ",NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(OT_Master.Note.ToString()) ? $@",'{OT_Master.Note}'" : ",NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(OT_Master.OrderStatus.ToString()) ? $@",'{OT_Master.OrderStatus}'" : ",NULL");
                            cmdTextMaster.Append($@",CAST('{OT_Master.is_Deleted}' AS BIT)");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(OT_Master.UserID.ToString()) ? $@",{OT_Master.UserID}" : ",NULL");
                            cmdTextMaster.Append(",GETDATE(),NULL,NULL)");

                            if (OT_Details.GetGridViewData != null && OT_Details.GetGridViewData.RowCount > 0)
                            {
                                var Rows = 0;
                                foreach (DataGridViewRow dgv in OT_Details.GetGridViewData.Rows)
                                {
                                    Rows++;
                                    cmdTextDetails.Append("\nINSERT INTO MSM.OrderDetails(OID,OVNUM,PID,PName,PCode,PBarcode,Quantiy,UnitID,EST_HrsPerUnit,TotalEST_HrsPerUnit,UserID,DateCreated,MUserID,ModifiedDate,is_Deleted) \nVALUES(");
                                    cmdTextDetails.Append(!string.IsNullOrEmpty(OT_Master.OID.ToString()) ? $@"{OT_Master.OID}," : "NULL,");
                                    cmdTextDetails.Append(!string.IsNullOrEmpty(OT_Master.OVNUM.ToString()) ? $@"'{OT_Master.OVNUM}'," : "NULL,");
                                    cmdTextDetails.Append($"{dgv.Cells["PID"].Value},");
                                    cmdTextDetails.Append(dgv.Cells["Product"].Value.ToString() != null ? $"'{dgv.Cells["Product"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["Short Name"].Value.ToString() != null ? $"'{dgv.Cells["Short Name"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["BarCode"].Value.ToString() != null ? $"'{dgv.Cells["BarCode"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["Quantity"].Value.ToString() != null ? $"'{dgv.Cells["Quantity"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["Unit"].Value.ToString() != null ? $"(select UnitID  from MSM.UnitMaster where UnitCode ='{dgv.Cells["Unit"].Value}')," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["EST Time/Unit"].Value.ToString() != null ? $"'{dgv.Cells["EST Time/Unit"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["EST Total Time"].Value.ToString() != null ? $"'{dgv.Cells["EST Total Time"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(!string.IsNullOrEmpty(OT_Master.UserID.ToString()) ? $@"{OT_Master.UserID}," : "NULL,");
                                    cmdTextDetails.Append(OT_Master.DateCreated.ToString() != "1/1/0001 12:00:00 AM" ? $@"'{OT_Master.DateCreated}'," : "GETDATE(),");
                                    cmdTextDetails.Append("NULL,NULL,");
                                    cmdTextDetails.Append($@"CAST('{OT_Master.is_Deleted}' AS BIT));");
                                    cmdTextDetails.Append("\n");
                                }
                            }
                            break;
                        }
                    case "UPDATE":
                        {
                            cmdTextDetails.Append("\n");
                            cmdTextMaster.Append("UPDATE [MSM].[OrderMaster] SET ");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(OT_Master.Order_Date.ToString()) ? $@"[Order_Date] = '{OT_Master.Order_Date}'," : "[Order_Date] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(OT_Master.Order_Miti.ToString()) ? $@"[Order_Miti] = '{OT_Master.Order_Miti}'," : "[Order_Miti] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(OT_Master.Delivery_Date.ToString()) ? $@"[Delivery_Date] = '{OT_Master.Delivery_Date}'," : "[Delivery_Date] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(OT_Master.Delivery_Miti.ToString()) ? $@"[Delivery_Miti] = '{OT_Master.Delivery_Miti}'," : "[Delivery_Miti] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(OT_Master.SenderID.ToString()) ? $@"[SenderID] = {OT_Master.SenderID}," : "[SenderID] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(OT_Master.BuyerID.ToString()) ? $@"[BuyerID] = {OT_Master.BuyerID}," : "[BuyerID] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(OT_Master.Est_Time.ToString()) ? $@"[Est_Time] = '{OT_Master.Est_Time}'," : "[Est_Time] = NULL,");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(OT_Master.Note.ToString()) ? $@"[Note] = '{OT_Master.Note}'," : "[Note] = NULL,");
                            cmdTextMaster.Append($@"[is_Deleted] = CAST('False' AS BIT),"); //incase of update deleted bill is reset to active again by default.
                            cmdTextMaster.Append(!string.IsNullOrEmpty(OT_Master.UserID.ToString()) ? $@"[MUserID] = {OT_Master.UserID}," : "[MUserID] = NULL,");
                            cmdTextMaster.Append("[ModifiedDate] = GETDATE() ");
                            cmdTextDetails.Append("\n");
                            cmdTextMaster.Append($@"WHERE [OID] = {OT_Master.OID} and [OVNUM] = '{OT_Master.OVNUM}';");
                            cmdTextDetails.Append("\n");

                            cmdTextDetails.Append($@"DELETE FROM [MSM].[OrderDetails] WHERE [OID] = {OT_Master.OID} and [OVNUM] = '{OT_Master.OVNUM}';");
                            cmdTextDetails.Append("\n");

                            if (OT_Details.GetGridViewData != null && OT_Details.GetGridViewData.RowCount > 0)
                            {
                                var Rows = 0;
                                foreach (DataGridViewRow dgv in OT_Details.GetGridViewData.Rows)
                                {
                                    Rows++;
                                    cmdTextDetails.Append("\nINSERT INTO MSM.OrderDetails(OID,OVNUM,PID,PName,PCode,PBarcode,Quantiy,UnitID,EST_HrsPerUnit,TotalEST_HrsPerUnit,UserID,DateCreated,MUserID,ModifiedDate,is_Deleted) \nVALUES(");
                                    cmdTextDetails.Append(!string.IsNullOrEmpty(OT_Master.OID.ToString()) ? $@"{OT_Master.OID}," : "NULL,");
                                    cmdTextDetails.Append(!string.IsNullOrEmpty(OT_Master.OVNUM.ToString()) ? $@"'{OT_Master.OVNUM}'," : "NULL,");
                                    cmdTextDetails.Append($"{dgv.Cells["PID"].Value},");
                                    cmdTextDetails.Append(dgv.Cells["Product"].Value.ToString() != null ? $"'{dgv.Cells["Product"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["Short Name"].Value.ToString() != null ? $"'{dgv.Cells["Short Name"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["BarCode"].Value.ToString() != null ? $"'{dgv.Cells["BarCode"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["Quantity"].Value.ToString() != null ? $"'{dgv.Cells["Quantity"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["Unit"].Value.ToString() != null ? $"(select UnitID  from MSM.UnitMaster where UnitCode ='{dgv.Cells["Unit"].Value}')," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["EST Time/Unit"].Value.ToString() != null ? $"'{dgv.Cells["EST Time/Unit"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["EST Total Time"].Value.ToString() != null ? $"'{dgv.Cells["EST Total Time"].Value}'," : "NULL,");
                                    cmdTextDetails.Append($@"(Select UserID from MSM.OrderMaster where OID = {OT_Master.OID}),");
                                    cmdTextDetails.Append($@"(Select DateCreated from MSM.OrderMaster where OID = {OT_Master.OID}),");
                                    cmdTextDetails.Append(!string.IsNullOrEmpty(OT_Master.UserID.ToString()) ? $@"{OT_Master.UserID}," : "NULL,");
                                    cmdTextDetails.Append("GETDATE(),");
                                    cmdTextDetails.Append($@"CAST('{OT_Master.is_Deleted}' AS BIT));");
                                    cmdTextDetails.Append("\n");
                                }
                            }                            
                            break;
                        }
                    case "DELETE":
                        {
                            cmdTextMaster.Append($@"UPDATE [MSM].[OrderMaster] SET is_Deleted = 'True' WHERE [OID] = {OT_Master.OID} and [OVNUM] = '{OT_Master.OVNUM}'; UPDATE [MSM].[OrderDetails] set is_Deleted = 'True' WHERE [OID] = {OT_Master.OID} and [OVNUM] = '{OT_Master.OVNUM}';");
                            cmdTextDetails.Append("\n");
                            break;
                        }
                }

                var IsMasterOk = Execute.ExecuteNonQueryOnMain(cmdTextMaster.ToString());
                var IsDetailsOk = Execute.ExecuteNonQueryOnMain(cmdTextDetails.ToString());
                if (IsMasterOk <= 0 && IsDetailsOk <= 0) return 0;
                return IsMasterOk;
            }
            catch
            {
                return 0;
            }
        }

        public int GetIssueCardSetup()
        {
            try
            {
                var cmdTextMaster = new StringBuilder();
                var cmdTextDetails = new StringBuilder();
                if (IC_Master.ToPerform == null && IC_Details.ToPerform == null) return 0;
                switch (IC_Master.ToPerform.ToUpper())
                {
                    case "INSERT":
                        {
                            cmdTextMaster.Append("INSERT INTO MSM.IssueCardMaster(ICID,ICVNUM,OID,OVNUM,Issue_Date,Issue_Miti,Delivery_Date,Delivery_Miti,SenderID,BuyerID,AssigneeId,Est_Time,OrderStatus,Note,is_Deleted,UserID,DateCreated,MUserID,ModifiedDate)VALUES(");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(IC_Master.ICID.ToString()) ? $@"{IC_Master.ICID}" : "NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(IC_Master.ICVNUM.ToString()) ? $@",'{IC_Master.ICVNUM}'" : ",NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(IC_Master.OID.ToString()) ? $@",{IC_Master.OID}" : ",NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(IC_Master.OVNUM.ToString()) ? $@",'{IC_Master.OVNUM}'" : ",NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(IC_Master.Issue_Date.ToString()) ? $@",'{IC_Master.Issue_Date}'" : ",NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(IC_Master.Issue_Miti.ToString()) ? $@",'{IC_Master.Issue_Miti}'" : ",NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(IC_Master.Delivery_Date.ToString()) ? $@",'{IC_Master.Delivery_Date}'" : ",NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(IC_Master.Delivery_Miti.ToString()) ? $@",'{IC_Master.Delivery_Miti}'" : ",NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(IC_Master.SenderID.ToString()) ? $@",'{IC_Master.SenderID}'" : ",NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(IC_Master.BuyerID.ToString()) ? $@",'{IC_Master.BuyerID}'" : ",NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(IC_Master.AssigneeId.ToString()) ? $@",'{IC_Master.AssigneeId}'" : ",NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(IC_Master.Est_Time.ToString()) ? $@",'{IC_Master.Est_Time}'" : ",NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(IC_Master.OrderStatus.ToString()) ? $@",'{IC_Master.OrderStatus}'" : ",NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(IC_Master.Note.ToString()) ? $@",'{IC_Master.Note}'" : ",NULL");
                            cmdTextMaster.Append($@",CAST('{IC_Master.is_Deleted}' AS BIT)");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(IC_Master.UserID.ToString()) ? $@",{IC_Master.UserID}" : ",NULL");
                            cmdTextMaster.Append(",GETDATE(),NULL,NULL);");
                            cmdTextMaster.Append("\n");
                            cmdTextMaster.Append($@"UPDATE [MSM].[OrderMaster] SET [OrderStatus] = '{IC_Master.OrderStatus}' WHERE OID = {IC_Master.OID} AND OVNUM = '{IC_Master.OVNUM}';");
                            cmdTextMaster.Append("\n");

                            if (IC_Details.GetGridViewData != null && IC_Details.GetGridViewData.RowCount > 0)
                            {
                                var Rows = 0;
                                foreach (DataGridViewRow dgv in IC_Details.GetGridViewData.Rows)
                                {
                                    Rows++;
                                    cmdTextDetails.Append("\nINSERT INTO MSM.IssueCardDetails(ICID,ICVNUM,PID,PName,PCode,PBarcode,Quantiy,UnitID,UserID,DateCreated,MUserID,ModifiedDate,is_Deleted) \n VALUES(");
                                    cmdTextDetails.Append(!string.IsNullOrEmpty(IC_Master.ICID.ToString()) ? $@"{IC_Master.ICID}" : "NULL");
                                    cmdTextDetails.Append(!string.IsNullOrEmpty(IC_Master.ICVNUM.ToString()) ? $@",'{IC_Master.ICVNUM}'" : ",NULL");
                                    cmdTextDetails.Append($",{dgv.Cells["PID"].Value},");
                                    cmdTextDetails.Append(dgv.Cells["Product"].Value.ToString() != null ? $"'{dgv.Cells["Product"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["Short Name"].Value.ToString() != null ? $"'{dgv.Cells["Short Name"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["BarCode"].Value.ToString() != null ? $"'{dgv.Cells["BarCode"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["Quantity"].Value.ToString() != null ? $"'{dgv.Cells["Quantity"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["Unit"].Value.ToString() != null ? $"(select UnitID  from MSM.UnitMaster where UnitCode ='{dgv.Cells["Unit"].Value}')," : "NULL,");
                                    cmdTextDetails.Append(!string.IsNullOrEmpty(IC_Master.UserID.ToString()) ? $@"{IC_Master.UserID}," : "NULL,");
                                    cmdTextDetails.Append(IC_Master.DateCreated.ToString() != "1/1/0001 12:00:00 AM" ? $@"'{IC_Master.DateCreated}'," : "GETDATE(),");
                                    cmdTextDetails.Append("NULL,NULL,");
                                    cmdTextDetails.Append($@"CAST('{IC_Master.is_Deleted}' AS BIT));");
                                    cmdTextDetails.Append("\n");
                                }
                            }
                            break;
                        }
                    case "UPDATE":
                        {
                            cmdTextDetails.Append("\n");
                            cmdTextMaster.Append("UPDATE [MSM].[IssueCardMaster] SET ");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(IC_Master.OID.ToString()) ? $@"[OID] = {IC_Master.OID}" : "[OID] = NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(IC_Master.OVNUM.ToString()) ? $@",[OVNUM] ='{IC_Master.OVNUM}'" : ",[OVNUM] =NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(IC_Master.Issue_Date.ToString()) ? $@",[Issue_Date] = '{IC_Master.Issue_Date}'" : ",[Issue_Date] = NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(IC_Master.Issue_Miti.ToString()) ? $@",[Issue_Miti] = '{IC_Master.Issue_Miti}'" : ",[Issue_Miti] = NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(IC_Master.Delivery_Date.ToString()) ? $@",[Delivery_Date] ='{IC_Master.Delivery_Date}'" : ",[Delivery_Date] = NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(IC_Master.Delivery_Miti.ToString()) ? $@",[Delivery_Miti] ='{IC_Master.Delivery_Miti}'" : ",[Delivery_Miti] = NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(IC_Master.SenderID.ToString()) ? $@",[SenderID] ='{IC_Master.SenderID}'" : ",[SenderID] = NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(IC_Master.BuyerID.ToString()) ? $@",[BuyerID] = '{IC_Master.BuyerID}'" : ",[BuyerID] = NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(IC_Master.AssigneeId.ToString()) ? $@",[AssigneeId] = '{IC_Master.AssigneeId}'" : ",[AssigneeId] = NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(IC_Master.Est_Time.ToString()) ? $@",[Est_Time] = '{IC_Master.Est_Time}'" : ",[Est_Time] = NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(IC_Master.OrderStatus.ToString()) ? $@",[OrderStatus] = '{IC_Master.OrderStatus}'" : ",[OrderStatus] = NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(IC_Master.Note.ToString()) ? $@",[Note] = '{IC_Master.Note}'" : ",[Note] = NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(IC_Master.UserID.ToString()) ? $@",[MUserID] = {IC_Master.UserID}" : ",[MUserID] = NULL");
                            cmdTextMaster.Append(",[ModifiedDate] = GETDATE() ");
                            cmdTextMaster.Append($@",[is_Deleted] = CAST('{IC_Master.is_Deleted}' AS BIT) ");
                            cmdTextMaster.Append("\n");
                            cmdTextMaster.Append($@"WHERE [ICID] = {IC_Master.ICID} and [ICVNUM] = '{IC_Master.ICVNUM}';");

                            if(IC_Master.OVNUM != IC_Master.oldOVNUM)
                            {
                                cmdTextDetails.Append("\n");
                                cmdTextMaster.Append($@"UPDATE [MSM].[OrderMaster] SET [OrderStatus] = 'Pending' WHERE OID = {IC_Master.oldOID} AND OVNUM = '{IC_Master.oldOVNUM}';");
                                cmdTextMaster.Append("\n");
                                cmdTextMaster.Append($@"UPDATE [MSM].[OrderMaster] SET [OrderStatus] = '{IC_Master.OrderStatus}' WHERE OID = {IC_Master.OID} AND OVNUM = '{IC_Master.OVNUM}';");
                            }
                            if (IC_Master.check_is_Deleted == true)
                            {
                                cmdTextMaster.Append("\n");
                                cmdTextMaster.Append($@"UPDATE [MSM].[OrderMaster] SET [OrderStatus] = '{IC_Master.OrderStatus}' WHERE OID = {IC_Master.OID} AND OVNUM = '{IC_Master.OVNUM}';");
                            }

                            cmdTextDetails.Append($@"DELETE FROM [MSM].[IssueCardDetails] WHERE [ICID] = {IC_Master.ICID} and [ICVNUM] = '{IC_Master.ICVNUM}';");
                            cmdTextDetails.Append("\n");

                            if (IC_Details.GetGridViewData != null && IC_Details.GetGridViewData.RowCount > 0)
                            {
                                var Rows = 0;
                                foreach (DataGridViewRow dgv in IC_Details.GetGridViewData.Rows)
                                {
                                    Rows++;
                                    cmdTextDetails.Append("\nINSERT INTO MSM.IssueCardDetails(ICID,ICVNUM,PID,PName,PCode,PBarcode,Quantiy,UnitID,UserID,DateCreated,MUserID,ModifiedDate,is_Deleted) \n VALUES(");
                                    cmdTextDetails.Append(!string.IsNullOrEmpty(IC_Master.ICID.ToString()) ? $@"{IC_Master.ICID}" : "NULL");
                                    cmdTextDetails.Append(!string.IsNullOrEmpty(IC_Master.ICVNUM.ToString()) ? $@",'{IC_Master.ICVNUM}'" : ",NULL");
                                    cmdTextDetails.Append($",{dgv.Cells["PID"].Value},");
                                    cmdTextDetails.Append(dgv.Cells["Product"].Value.ToString() != null ? $"'{dgv.Cells["Product"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["Short Name"].Value.ToString() != null ? $"'{dgv.Cells["Short Name"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["BarCode"].Value.ToString() != null ? $"'{dgv.Cells["BarCode"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["Quantity"].Value.ToString() != null ? $"'{dgv.Cells["Quantity"].Value}'," : "NULL,");
                                    cmdTextDetails.Append(dgv.Cells["Unit"].Value.ToString() != null ? $"(select UnitID  from MSM.UnitMaster where UnitCode ='{dgv.Cells["Unit"].Value}')," : "NULL,");
                                    cmdTextDetails.Append($@"(Select UserID from MSM.IssueCardMaster where ICID = {IC_Master.ICID}),");
                                    cmdTextDetails.Append($@"(Select DateCreated from MSM.IssueCardMaster where ICID = {IC_Master.ICID}),");
                                    cmdTextDetails.Append(!string.IsNullOrEmpty(IC_Master.UserID.ToString()) ? $@"{IC_Master.UserID}," : "NULL,");
                                    cmdTextDetails.Append("GETDATE(),");
                                    cmdTextDetails.Append($@"CAST('{IC_Master.is_Deleted}' AS BIT));");
                                    cmdTextDetails.Append("\n");
                                }
                            }
                            break;
                        }
                    case "DELETE":
                        {
                            cmdTextMaster.Append($@"UPDATE [MSM].[IssueCardMaster] SET is_Deleted = 'True' WHERE [ICID] = {IC_Master.ICID} and [ICVNUM] = '{IC_Master.ICVNUM}'; UPDATE [MSM].[IssueCardDetails] set is_Deleted = 'True' WHERE [ICID] = {IC_Master.ICID} and [ICVNUM] = '{IC_Master.ICVNUM}';");
                            cmdTextMaster.Append("\n");
                            cmdTextMaster.Append($@"UPDATE [MSM].[OrderMaster] SET [OrderStatus] = 'Pending' WHERE OID = {IC_Master.OID} AND OVNUM = '{IC_Master.OVNUM}';");
                            cmdTextDetails.Append("\n");
                            
                            break;
                        }
                }

                var IsMasterOk = Execute.ExecuteNonQueryOnMain(cmdTextMaster.ToString());
                var IsDetailsOk = Execute.ExecuteNonQueryOnMain(cmdTextDetails.ToString());
                if (IsMasterOk <= 0 && IsDetailsOk <= 0) return 0;
                return IsMasterOk;
            }
            catch
            {
                return 0;
            }
        }

        public int GetStartProcessing()
        {
            try
            {
                var cmdTextMaster = new StringBuilder();
                var cmdTextDetails = new StringBuilder();
                if (Start_Processing.ToPerform == null && Start_Processing.ToPerform == null) return 0;
                switch (Start_Processing.ToPerform.ToUpper())
                {
                    case "UPDATE":
                        {
                            cmdTextDetails.Append("\n");
                            cmdTextMaster.Append("UPDATE [MSM].[IssueCardMaster] SET ");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(Start_Processing.OrderStatus.ToString()) ? $@"[OrderStatus] = '{Start_Processing.OrderStatus}'" : "[OrderStatus] = NULL");
                            cmdTextMaster.Append(!string.IsNullOrEmpty(Start_Processing.UserID.ToString()) ? $@",[MUserID] = {Start_Processing.UserID}" : ",[MUserID] = NULL");
                            cmdTextMaster.Append(",[ModifiedDate] = GETDATE() ");
                            cmdTextMaster.Append("\n");
                            cmdTextMaster.Append($@"WHERE [ICID] = {Start_Processing.ICID} and [ICVNUM] = '{Start_Processing.ICVNUM}';");
                            cmdTextMaster.Append("\n");
                            cmdTextMaster.Append($@"UPDATE [MSM].[OrderMaster] SET [OrderStatus] = '{Start_Processing.OrderStatus}', [MUserID] = {Start_Processing.UserID} ,[ModifiedDate] = GETDATE()  WHERE OID = {Start_Processing.OID} AND OVNUM = '{Start_Processing.OVNUM}';");
                            break;
                        }
                }

                var IsMasterOk = Execute.ExecuteNonQueryOnMain(cmdTextMaster.ToString());
                var IsDetailsOk = Execute.ExecuteNonQueryOnMain(cmdTextDetails.ToString());
                if (IsMasterOk <= 0 && IsDetailsOk <= 0) return 0;
                return IsMasterOk;
            }
            catch
            {
                return 0;
            }
        }

        #endregion

        #region DataTable
        public System.Drawing.Color BackgroundColor()
        {
            // backgroundcolor = 1;
            try
            {
                var initials = getUserLogin(Global.LoginUser, string.Empty, 1);
                var Mycolor = System.Drawing.ColorTranslator.FromHtml(initials.Rows[0]["Background"].ToString());
                return Mycolor;
            }
            catch
            {
                var initials = getUserLogin(Global.LoginUser, string.Empty, 1);
                var Mycolor = System.Drawing.ColorTranslator.FromHtml("indigo");
                return Mycolor;
            }  
        }

        public DataTable GetComboBoxValue()
        {
            var Query = @"SELECT CbId ID,StateName StateName, Country CountryName FROM [master.ComboBoxVal] ORDER BY CbId;";
            return Execute.ExecuteDataSetOnLocalMaster(Connection.Connection.ConnectionLocalMaster, CommandType.Text, Query).Tables[0];
        }
        public DataTable Get_State()
        {
            var Query = @"SELECT CbId ID,StateName Name FROM [master.ComboBoxVal] ORDER BY CbId;";
            return Execute.ExecuteDataSetOnLocalMaster(Connection.Connection.ConnectionLocalMaster, CommandType.Text, Query).Tables[0];
        }
        public DataTable Get_Unit()
        {
            var Query = @"SELECT [UnitID],[Unit],[UnitCode],[ActiveStatus],[UserID],[DateCreated],[MUserID],[ModifiedDate]FROM [MSM].[UnitMaster] ORDER BY [UnitID];";
            return Execute.ExecuteDataSetOnLocalMaster(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
        }
        public DataTable Get_Godown()
        {
            var Query = @"SELECT [GodID],[GodName],[GodCode],[GodAddress],[ActiveStatus],[UserID],[DateCreated],[MUserID],[ModifiedDate]FROM [MSM].[StoreGodown] ORDER BY [GodID];";
            return Execute.ExecuteDataSetOnLocalMaster(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
        }

        public DataTable Get_ProductType()
        {
            var Query = @"SELECT [CatID],[Category],[CategoryID],[ActiveStatus],[UserID],[DateCreated],[MUserID],[ModifiedDate] FROM [MSM].[ProductCategory] ORDER BY [CatID];";
            return Execute.ExecuteDataSetOnLocalMaster(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
        }
        public DataTable Get_Country()
        {
            var Query = @"SELECT DISTINCT Country Name FROM [master.ComboBoxVal];";
            return Execute.ExecuteDataSetOnLocalMaster(Connection.Connection.ConnectionLocalMaster, CommandType.Text, Query).Tables[0];
        }

        public DataTable checkConfig()
        {
            var Query = @"select CID,YearID,Current_Year CurrentYear,IsAdmin,ColorID,Background,VAT,Discount,checkDate,notes,returnNotes,printMessage,autoPrint,compType,billMsg from [MSM].[Configuration];";
            return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
        }

        public DataTable checkTransectionOnPE()
        {
            var Query = "SELECT COUNT(PEID) AS PEBills FROM MSM.PurchaseMaster;";
            return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
        }

        public DataTable checkTransectionOnSE()
        {
            var Query = "SELECT COUNT(SAID) AS SABills FROM MSM.SalesMaster;";
            return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
        }

        public DataTable Get_FiscalYear()
        {
            var Query = @"SELECT YearID,YearDesc FROM msm.FiscalYear ORDER BY YearID;";
            return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
        }

        public DataTable getlicsence()
        {
            try
            {
                var Query = $@"select * from MSM.licsence where Id = 1;";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
            }
            catch (Exception ex)
            {
                return null;
                //no message
            }

        }

        public DataTable GetID(string column, string tablename, string columname, string value)
        {
            var Query = $@"SELECT {column} FROM MSM.{tablename} where {columname} = '{value}'";
            return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
        }

        public DataTable GetValue(string column, string tablename, string columname, int value)
        {
            var Query = $@"select {column} from msm.{tablename} where UnitID = {value};";
            return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
        }

        public DataTable GetKeyID(string column, string tablename, string columname, string value)
        {
            var Query = $@"SELECT {column} FROM MSM.{tablename} where {columname} = '{value}'";
            return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
        }

        public DataTable CheckAvailability(string table, string Column, string Value)
        {
            var cmdText = $"Select * From {table} where {Column}='{Value}'";
            return Execute.ExecuteDataSetOnMain(cmdText).Tables[0];
        }

        public DataTable CheckPurchaseEntryDetails(string Voucher)
        {
            var Query = $@"select * from msm.PurchaseDetails where PVNUM = (select top 1 PVNUM from msm.PurchaseMaster where Purchase_OrderNo = '{Voucher}' AND is_Deleted  <> 1  order by PVNUM asc);";
            return Execute.ExecuteDataSetOnMain(Query).Tables[0];
        }
        //public static int GetID(string tablename, string columname, string value)
        //{
        //    var Query = $@"SELECT * FROM msm.{tablename} where {columname} = '{value}'";
        //    var IsOk = Execute.ExecuteNonQueryOnMain(Query.ToString());
        //    return IsOk;
        //    //return Execute.ExecuteDataSetOnLocalMaster(Connection.Connection.ConnectionMain, CommandType.Text, Query);
        //}

        public DataTable chk_PO_QuantityMaster(int POID)
        {
            var cmdText = $@"select goods_quantity from msm.PurchaseOrderMaster where [POID] = {POID} AND is_Deleted <> 1;";
            return Execute.ExecuteDataSetOnMain(cmdText).Tables[0];
        }

        public DataTable chk_PE_QuantityDetails(string VNUM)
        {
            var cmdText = $@"select sum(Quantiy) as Quantiy  from msm.PurchaseDetails where Purchase_OrderNo = '{VNUM}' AND is_Deleted <> 1;";
            return Execute.ExecuteDataSetOnMain(cmdText).Tables[0];
        }

        public DataTable get_Product_From_barcode(string barCode)
        {
            if (barCode == string.Empty) return null;
            var cmdText = $@"SELECT PM.[PID],POI.InventID,PM.[PName],PM.[PCode],PM.[PBarcode],PM.[UnitID],UM.Unit MainUnit,UM.UnitCode MainUnitCode,PM.[UnitQnty],PM.[AltUnitId],AUM.Unit AltUnit,AUM.UnitCode AltUnitCode,PM.[AltUnitQnty],PM.[PurchasePrice],PM.[MRP],PM.[Offer],PM.[PNote],PM.[ProductCategory],PM.[ActiveStatus],PM.[UserID],PM.[DateCreated],PM.[MUserID],PM.[ModifiedDate] FROM MSM.ProductMaster PM LEFT OUTER JOIN MSM.UnitMaster UM ON UM.UnitID = PM.UnitID LEFT OUTER JOIN MSM.UnitMaster AUM ON AUM.UnitID = PM.AltUnitId LEFT OUTER JOIN MSM.ProductInventory POI ON PM.PID = POI.prodID WHERE PM.[PBarcode] = '{barCode}' AND PM.ActiveStatus = 1;";
            return Execute.ExecuteDataSetOnMain(cmdText).Tables[0];
        }


        public DataTable getUserLogin(string usrname, string password,int BackgroundColor)
        {
            if(BackgroundColor == 1)
            {
                var Query = $@"select [IsAdmin],[ColorID],[Background] from msm.UsersMaster where loginid = '{Global.LoginUser}' AND ActiveStatus = 1;";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
            }
            else
            {
                var Query = $@"select * from msm.UsersMaster where loginid = '{usrname}' and password = '{password}' AND ActiveStatus = 1;";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
            }
        }

        public static DataTable GetCustomer()
        {
            var Query = @"SELECT [CID],[PartyName],[PartyCode],[PartyEmail],[PartyAddress],[PartyState],[PartyCountry],[PartyContact],[PartyReg],[PartyNote],[ActiveStatus],[UserID],[DateCreated],[MUserID],[ModifiedDate] FROM MSM.CustomerMaster ORDER BY [CID];";
            var dt = Execute.ExecuteDataSetOnMain(Query).Tables[0];
            return dt;
        }

        public static DataTable GetProduct()
        {
            var Query = @"SELECT [PID],[PName],[PCode],[PBarcode],[UnitID],[UnitQnty],[AltUnitId],[AltUnitQnty],[PurchasePrice],[MRP],[Offer],[PNote],[ActiveStatus],[UserID],[DateCreated],[MUserID],[ModifiedDate]FROM [MSM].[ProductMaster] ORDER BY [PID];";
            var dt = Execute.ExecuteDataSetOnMain(Query).Tables[0];
            return dt;
        }

        public DataTable GetInventoryData(int Pid)
        {
            //Active status not required to check.
            var Query = string.Empty; //casting not done while selecting id because need to do decimal calculation.
            if (Pid > 0) Query = $@"SELECT pin.InventID,pin.prodID,pm.PName,pm.PCode,pm.PBarcode,pin.UnitID,pin.Quantity,um.UnitCode,pin.AltUnitID,pin.AlternateQuantity,aum.UnitCode AS AltUnitCode,IIF(pin.ActiveStatus = 1 , 'In Use' , 'Not In Use') as  ActiveStatus FROM MSM.ProductInventory pin LEFT OUTER JOIN MSM.ProductMaster pm on pin.prodID = pm.PID LEFT OUTER JOIN MSM.UnitMaster um ON pin.UnitID = um.UnitID LEFT OUTER JOIN MSM.UnitMaster aum ON pin.AltUnitID = aum.UnitID WHERE prodID = {Pid} ORDER BY PName;";
            else Query = $@"SELECT pin.InventID,pin.prodID,pm.PName,pm.PCode,pm.PBarcode,pin.UnitID,CAST((pin.Quantity) as float) as Quantity,um.UnitCode,pin.AltUnitID,CAST((pin.AlternateQuantity) as float) as AlternateQuantity,aum.UnitCode AS AltUnitCode,IIF(pin.ActiveStatus = 1, 'In Use', 'Not In Use') AS ActiveStatus FROM MSM.ProductInventory pin LEFT OUTER JOIN MSM.ProductMaster pm ON pin.prodID = pm.PID LEFT OUTER JOIN MSM.UnitMaster um ON pin.UnitID = um.UnitID LEFT OUTER JOIN MSM.UnitMaster aum ON pin.AltUnitID = aum.UnitID ORDER BY PName;";
            var dt = Execute.ExecuteDataSetOnMain(Query).Tables[0];
            return dt;
        }

        public DataSet GetPurchaseOrderDetails(string Voucher)
        {
            var Query = $@"SELECT pod.POID D_POID,pod.POVNUM D_POVNUM,pod.PID ,pod.PName ,pod.PCode ,pod.PBarcode ,pod.Quantiy ,pod.UnitID ,um.Unit ,um.UnitCode ,pod.PPrice ,pod.TotalPrice,pod.PNote ,pod.UserID ,usr.usrname ,pod.DateCreated ,pod.MUserID,musr.usrname musrname,pod.ModifiedDate from MSM.PurchaseOrderDetails as pod left outer join MSM.UnitMaster um on um.UnitID = pod.UnitID  left outer join MSM.UsersMaster usr on usr.userid = pod.UserID left outer join MSM.UsersMaster musr on musr.userid = pod.MUserID where pod.POVNUM = '{Voucher}';";
            var dt = Execute.ExecuteDataSetOnMain(Query);
            return dt;
        }

        public DataSet GetProcessing(string value1, string value2 , string searchType)
        {
            var Query = string.Empty;
            var midQuery = string.Empty;
            if (searchType != string.Empty)
            {
                if (searchType == "miti") midQuery = "Issue_Miti";
                else if (searchType == "date") midQuery = "Issue_Date";
                Query = $@"SELECT ICM.ICID,ICM.ICVNUM,ICM.OID,ICM.OVNUM,ICM.Issue_Date,ICM.Issue_Miti,ICM.Delivery_Date,ICM.Delivery_Miti,ICM.SenderID,cmi.Dup_cname,cmi.Dup_address,cmi.Dup_contact,ICM.BuyerID,scm.PartyName,scm.PartyCompany,scm.PartyAddress,scm.PartyContact,ICM.AssigneeId,UM.usrname  AS Assignee_Name,UM.RoleID,ICM.Note,ICM.Est_Time,ICM.OrderStatus,CASE WHEN ICM.is_Deleted = '0' THEN 'No' ELSE 'Yes' END AS is_Deleted,ICM.UserID,usr.usrname Entered_By,ICM.DateCreated,ICM.MUserID,musr.usrname Modified_By,ICM.ModifiedDate FROM MSM.IssueCardMaster ICM LEFT OUTER JOIN MSM.CustomerMaster scm ON scm.CID = ICM.BuyerID LEFT OUTER JOIN MSM.CompanyMasterInfo cmi ON cmi.Dup_cid = ICM.SenderID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.UserID = ICM.UserID LEFT OUTER JOIN MSM.UsersMaster musr ON musr.UserID = ICM.MUserID LEFT OUTER JOIN MSM.UsersMaster um ON UM.userid = ICM.AssigneeId WHERE {midQuery} BETWEEN '{value1}' AND '{value2}' ORDER BY ICM.ICID DESC;";
            }            
            else Query = $@"SELECT ICM.ICID,ICM.ICVNUM,ICM.OID,ICM.OVNUM,ICM.Issue_Date,ICM.Issue_Miti,ICM.Delivery_Date,ICM.Delivery_Miti,ICM.SenderID,cmi.Dup_cname,cmi.Dup_address,cmi.Dup_contact,ICM.BuyerID,scm.PartyName,scm.PartyCompany,scm.PartyAddress,scm.PartyContact,ICM.AssigneeId,UM.usrname  AS Assignee_Name,UM.RoleID,ICM.Note,ICM.Est_Time,ICM.OrderStatus,CASE WHEN ICM.is_Deleted = '0' THEN 'No' ELSE 'Yes' END AS is_Deleted,ICM.UserID,usr.usrname Entered_By,ICM.DateCreated,ICM.MUserID,musr.usrname Modified_By,ICM.ModifiedDate FROM MSM.IssueCardMaster ICM LEFT OUTER JOIN MSM.CustomerMaster scm ON scm.CID = ICM.BuyerID LEFT OUTER JOIN MSM.CompanyMasterInfo cmi ON cmi.Dup_cid = ICM.SenderID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.UserID = ICM.UserID LEFT OUTER JOIN MSM.UsersMaster musr ON musr.UserID = ICM.MUserID LEFT OUTER JOIN MSM.UsersMaster um ON UM.userid = ICM.AssigneeId WHERE OrderStatus LIKE '%{value1}%' OR OrderStatus LIKE '%{value2}%' ORDER BY ICM.ICID DESC;";
            var dt = Execute.ExecuteDataSetOnMain(Query);
            return dt;
        }

        public DataSet GetOrderTicketReport(string value1, string value2) //ICVNUM OVNUM Issue_Date Issue_Miti Delivery_Date Delivery_Miti OrderStatus
        {
            var Query = $@"SELECT ICM.ICID,ICM.ICVNUM,ICM.OID,ICM.OVNUM,ICM.Issue_Date,ICM.Issue_Miti,ICM.Delivery_Date,ICM.Delivery_Miti,ICM.SenderID,cmi.Dup_cname,cmi.Dup_address,cmi.Dup_contact,ICM.BuyerID,scm.PartyName,scm.PartyCompany,scm.PartyAddress,scm.PartyContact,ICM.AssigneeId,UM.usrname  AS Assignee_Name,UM.RoleID,ICM.Note,ICM.Est_Time,ICM.OrderStatus,CASE WHEN ICM.is_Deleted = '0' THEN 'No' ELSE 'Yes' END AS is_Deleted,ICM.UserID,usr.usrname Entered_By,ICM.DateCreated,ICM.MUserID,musr.usrname Modified_By,ICM.ModifiedDate FROM MSM.IssueCardMaster ICM LEFT OUTER JOIN MSM.CustomerMaster scm ON scm.CID = ICM.BuyerID LEFT OUTER JOIN MSM.CompanyMasterInfo cmi ON cmi.Dup_cid = ICM.SenderID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.UserID = ICM.UserID LEFT OUTER JOIN MSM.UsersMaster musr ON musr.UserID = ICM.MUserID LEFT OUTER JOIN MSM.UsersMaster um ON UM.userid = ICM.AssigneeId WHERE OrderStatus LIKE '%{value1}%' OR OrderStatus LIKE '%{value2}%' ORDER BY ICM.ICID DESC;";
            var dt = Execute.ExecuteDataSetOnMain(Query);
            return dt;
        }

        public DataSet GetOrderTicketDetails(string Voucher)
        {
            var Query = $@"SELECT od.OID,od.OVNUM,od.PID ,od.PName ,od.PCode ,od.PBarcode ,od.Quantiy ,od.UnitID ,um.Unit ,um.UnitCode, od.EST_HrsPerUnit, od.TotalEST_HrsPerUnit ,od.UserID ,usr.usrname ,od.DateCreated ,od.MUserID,musr.usrname musrname,od.ModifiedDate,od.is_Deleted isDeleted from MSM.OrderDetails as od left outer join MSM.UnitMaster um on um.UnitID = od.UnitID  left outer join MSM.UsersMaster usr on usr.userid = od.UserID left outer join MSM.UsersMaster musr on musr.userid = od.MUserID where od.OVNUM = '{Voucher}';";
            var dt = Execute.ExecuteDataSetOnMain(Query);
            return dt;
        }

        public DataSet GetIssueCardDetails(string Voucher)
        {
            var Query = $@"SELECT ICD.ICID,ICD.ICVNUM,ICD.PID,ICD.PName,ICD.PCode,ICD.PBarcode,ICD.Quantiy,ICD.UnitID,um.Unit,um.UnitCode,ICD.UserID,usr.usrname Entered_By,ICD.DateCreated,ICD.MUserID,musr.usrname Modified_By,ICD.ModifiedDate ,ICD.is_Deleted isDeleted FROM MSM.IssueCardDetails AS ICD LEFT OUTER JOIN MSM.UnitMaster um ON um.UnitID = ICD.UnitID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.userid = ICD.UserID LEFT OUTER JOIN MSM.UsersMaster musr ON musr.userid = ICD.MUserID where ICD.ICVNUM = '{Voucher}';";
            var dt = Execute.ExecuteDataSetOnMain(Query);
            return dt;
        }


        public DataSet GetPurchaseEntryDetails(string Voucher)
        {
            var Query = $@"SELECT pd.PEID,pd.PVNUM,pd.PID,pd.PName,pd.PCode,pd.PBarcode,pd.Quantiy,pd.UnitID,um.Unit ,um.UnitCode ,pd.PPrice,pd.TotalPrice,pd.UserID,usr.usrname Entered_By,pd.DateCreated,pd.MUserID,musr.usrname Modified_By,pd.ModifiedDate,IIF(pd.is_Deleted = 0, 'ACTIVE','DELETED') AS is_Deleted FROM MSM.PurchaseDetails pd left outer join MSM.UnitMaster um on um.UnitID = pd.UnitID left outer join MSM.UsersMaster usr on usr.userid = pd.UserID left outer join MSM.UsersMaster musr on musr.userid = pd.MUserID where pd.PVNUM = '{Voucher}';";
            var dt = Execute.ExecuteDataSetOnMain(Query);
            return dt;
        }

        public DataSet GetPurchaseReturnEntry(string Voucher)
        {
            var Query = $@"SELECT prd.PRID,prd.PRVNUM,prd.PID,prd.PName,prd.PCode,prd.PBarcode,prd.Quantiy,prd.UnitID,um.Unit,um.UnitCode,prd.PPrice,prd.TotalPrice,prd.Note,prd.UserID,usr.usrname Entered_By,prd.DateCreated,prd.MUserID,musr.usrname Modified_By,prd.ModifiedDate,IIF(prd.is_Deleted = 0, 'ACTIVE', 'DELETED') AS is_Deleted FROM MSM.PurchaseReturnDetails prd LEFT OUTER JOIN MSM.UnitMaster um ON um.UnitID = prd.UnitID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.UserID = prd.UserID LEFT OUTER JOIN MSM.UsersMaster musr ON musr.UserID = prd.MUserID  where prd.PRVNUM = '{Voucher}';";
            var dt = Execute.ExecuteDataSetOnMain(Query);
            return dt;
        }

        public DataSet GetSalesEntry(string Voucher)
        {
            var Query = $@"SELECT sd.SAID,sd.SVNUM,sd.PID,sd.PName,sd.PCode,sd.PBarcode,sd.Quantiy,sd.UnitID,um.Unit,um.UnitCode,sd.PPrice,sd.pDisc,sd.pamount,sd.TotalPrice,sd.Note,sd.UserID,usr.usrname Entered_By,sd.DateCreated,sd.MUserID,musr.usrname Modified_By,sd.ModifiedDate,IIF(sd.is_Deleted = 0, 'ACTIVE', 'DELETED') AS is_Deleted FROM MSM.SalesDetails sd LEFT OUTER JOIN MSM.UnitMaster um ON um.UnitID = sd.UnitID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.UserID = sd.UserID LEFT OUTER JOIN MSM.UsersMaster musr ON musr.UserID = sd.MUserID where SVNUM = '{Voucher}';";
            var dt = Execute.ExecuteDataSetOnMain(Query);
            return dt;
        }

        public DataSet GetSalesReturnEntry(string Voucher)
        {
            var Query = $@"SELECT srd.SRID,srd.SRVNUM,srd.PID,srd.PName,srd.PCode,srd.PBarcode,srd.Quantiy,srd.UnitID,um.Unit,um.UnitCode,srd.PPrice,srd.pDisc,srd.pamount,srd.TotalPrice,srd.Note,srd.UserID,usr.usrname Entered_By,srd.DateCreated,srd.MUserID,musr.usrname Modified_By,srd.ModifiedDate,IIF(srd.is_Deleted = 0, 'ACTIVE', 'DELETED') AS is_Deleted FROM MSM.SalesReturnDetails srd LEFT OUTER JOIN MSM.UnitMaster um ON um.UnitID = srd.UnitID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.UserID = srd.UserID LEFT OUTER JOIN MSM.UsersMaster musr ON musr.UserID = srd.MUserID  where SRVNUM = '{Voucher}';";
            var dt = Execute.ExecuteDataSetOnMain(Query);
            return dt;
        }

        public DataTable getReport(string type, string dateType, string dateFrom, string dateTo)
        {
            try
            {
                var Query = string.Empty;
                if (type == "Purchase Order")
                {
                    if (dateType == "A.D") Query = $@"WITH PurchaseOrderData AS (SELECT pom.POID,pom.POVNUM,pom.Order_Date,pom.Order_Miti,pom.ReceiverID,musrr.usrname,cmi.Dup_cname,cmi.Dup_address,cmi.Dup_contact,pom.SenderID,scm.PartyName,scm.PartyCompany,scm.PartyAddress,scm.PartyContact,pom.TransectionOn,pom.Total,pom.Vat,pom.VatAmt,pom.TotalAmount,pom.Discount,pom.DiscAmount,pom.BillTotal,pom.InWords,CASE WHEN pom.PO_Bill_Status = '0' THEN 'PENDING' ELSE 'RECEIVED ALL' END AS PO_Bill_Status,pom.UserID,pom.DateCreated,pom.MUserID,pom.ModifiedDate,CASE WHEN pom.is_Deleted = '0' THEN 'No' ELSE 'Yes' END AS is_Deleted,goods_quantity FROM [MSM].[PurchaseOrderMaster] AS pom LEFT OUTER JOIN MSM.CompanyMasterInfo cmi ON cmi.Dup_cid = pom.ReceiverID LEFT OUTER JOIN MSM.CustomerMaster scm ON scm.CID = pom.SenderID LEFT OUTER JOIN MSM.UsersMaster musrr ON musrr.userid = pom.UserID LEFT OUTER JOIN MSM.UsersMaster mmusr ON mmusr.userid = pom.MUserID WHERE pom.is_Deleted = 0AND pom.PO_Bill_Status = 0AND pom.Order_Date BETWEEN '{dateFrom}' and '{dateTo}' )SELECT *FROM PurchaseOrderData ORDER BY POID DESC;";
                    else Query = $@"WITH PurchaseOrderData AS (SELECT pom.POID,pom.POVNUM,pom.Order_Date,pom.Order_Miti,pom.ReceiverID,musrr.usrname,cmi.Dup_cname,cmi.Dup_address,cmi.Dup_contact,pom.SenderID,scm.PartyName,scm.PartyCompany,scm.PartyAddress,scm.PartyContact,pom.TransectionOn,pom.Total,pom.Vat,pom.VatAmt,pom.TotalAmount,pom.Discount,pom.DiscAmount,pom.BillTotal,pom.InWords,CASE WHEN pom.PO_Bill_Status = '0' THEN 'PENDING' ELSE 'RECEIVED ALL' END AS PO_Bill_Status,pom.UserID,pom.DateCreated,pom.MUserID,pom.ModifiedDate,CASE WHEN pom.is_Deleted = '0' THEN 'No' ELSE 'Yes' END AS is_Deleted,goods_quantity FROM [MSM].[PurchaseOrderMaster] AS pom LEFT OUTER JOIN MSM.CompanyMasterInfo cmi ON cmi.Dup_cid = pom.ReceiverID LEFT OUTER JOIN MSM.CustomerMaster scm ON scm.CID = pom.SenderID LEFT OUTER JOIN MSM.UsersMaster musrr ON musrr.userid = pom.UserID LEFT OUTER JOIN MSM.UsersMaster mmusr ON mmusr.userid = pom.MUserID WHERE pom.is_Deleted = 0AND pom.PO_Bill_Status = 0AND pom.Order_Miti BETWEEN '{dateFrom}' and '{dateTo}' )SELECT *FROM PurchaseOrderData ORDER BY POID DESC;";

                }
                else if (type == "Purchase Entry")
                {
                    if (dateType == "A.D") Query = $@"WITH PurchaseInfo AS ( SELECT pm.PEID, pm.PVNUM, pm.Purchase_Date, pm.Purchase_Miti, pm.ref_bill_No, pm.Purchase_OrderNo, pm.PO_ReferenceNo, pm.SenderID, pm.ReceiverID, pm.TransectionOn, pm.Total, pm.Vat, pm.VatAmt, pm.TotalAmount, pm.Discount, pm.DiscAmount, pm.BillTotal, pm.InWords, pm.Note, IIF(pm.PO_Bill_Status = 0, 'PENDING', 'RECEIVED ALL') AS PO_Bill_Status, IIF(pm.is_Deleted = 0, 'ACTIVE', 'DELETED') AS is_Deleted, pm.UserID, pm.DateCreated, pm.MUserID, pm.ModifiedDate FROM MSM.PurchaseMaster pm WHERE pm.Purchase_Date BETWEEN '{dateFrom}' and '{dateTo}' ), PurchaseOrderInfo AS ( SELECT     pp.POVNUM,     pp.POID FROM msm.PurchaseOrderMaster pp ) SELECT pi.PEID, pi.PVNUM, pi.Purchase_Date, pi.Purchase_Miti, pi.ref_bill_No, poi.POID AS POID, pi.Purchase_OrderNo, pi.PO_ReferenceNo, pi.SenderID, scm.PartyName, scm.PartyCompany, scm.PartyAddress, scm.PartyContact, pi.ReceiverID, cmi.Dup_cname, cmi.Dup_address, cmi.Dup_contact, pi.TransectionOn, pi.Total, pi.Vat, pi.VatAmt, pi.TotalAmount, pi.Discount, pi.DiscAmount, pi.BillTotal, pi.InWords, pi.Note, pi.PO_Bill_Status, pi.is_Deleted, pi.UserID, usr.usrname AS Entered_By, pi.DateCreated, pi.MUserID, musr.usrname AS Modified_By, pi.ModifiedDate FROM PurchaseInfo pi LEFT JOIN PurchaseOrderInfo poi ON poi.POVNUM = pi.Purchase_OrderNo LEFT JOIN MSM.CompanyMasterInfo cmi ON cmi.Dup_cid = pi.ReceiverID LEFT JOIN MSM.CustomerMaster scm ON scm.CID = pi.SenderID LEFT JOIN MSM.UsersMaster usr ON usr.userid = pi.UserID LEFT JOIN MSM.UsersMaster musr ON musr.userid = pi.MUserID ORDER BY pi.Purchase_Date DESC;";
                    else Query = $@" WITH PurchaseInfo AS ( SELECT pm.PEID, pm.PVNUM, pm.Purchase_Date, pm.Purchase_Miti, pm.ref_bill_No, pm.Purchase_OrderNo, pm.PO_ReferenceNo, pm.SenderID, pm.ReceiverID, pm.TransectionOn, pm.Total, pm.Vat, pm.VatAmt, pm.TotalAmount, pm.Discount, pm.DiscAmount, pm.BillTotal, pm.InWords, pm.Note, IIF(pm.PO_Bill_Status = 0, 'PENDING', 'RECEIVED ALL') AS PO_Bill_Status, IIF(pm.is_Deleted = 0, 'ACTIVE', 'DELETED') AS is_Deleted, pm.UserID, pm.DateCreated, pm.MUserID, pm.ModifiedDate FROM MSM.PurchaseMaster pm WHERE pm.Purchase_Miti BETWEEN '{dateFrom}' and '{dateTo}' ), PurchaseOrderInfo AS ( SELECT     pp.POVNUM,     pp.POID FROM msm.PurchaseOrderMaster pp ) SELECT pi.PEID, pi.PVNUM, pi.Purchase_Date, pi.Purchase_Miti, pi.ref_bill_No, poi.POID AS POID, pi.Purchase_OrderNo, pi.PO_ReferenceNo, pi.SenderID, scm.PartyName, scm.PartyCompany, scm.PartyAddress, scm.PartyContact, pi.ReceiverID, cmi.Dup_cname, cmi.Dup_address, cmi.Dup_contact, pi.TransectionOn, pi.Total, pi.Vat, pi.VatAmt, pi.TotalAmount, pi.Discount, pi.DiscAmount, pi.BillTotal, pi.InWords, pi.Note, pi.PO_Bill_Status, pi.is_Deleted, pi.UserID, usr.usrname AS Entered_By, pi.DateCreated, pi.MUserID, musr.usrname AS Modified_By, pi.ModifiedDate FROM PurchaseInfo pi LEFT JOIN PurchaseOrderInfo poi ON poi.POVNUM = pi.Purchase_OrderNo LEFT JOIN MSM.CompanyMasterInfo cmi ON cmi.Dup_cid = pi.ReceiverID LEFT JOIN MSM.CustomerMaster scm ON scm.CID = pi.SenderID LEFT JOIN MSM.UsersMaster usr ON usr.userid = pi.UserID LEFT JOIN MSM.UsersMaster musr ON musr.userid = pi.MUserID ORDER BY pi.Purchase_Date DESC;";

                }
                else if (type == "Purchase Return")
                {
                    if (dateType == "A.D") Query = $@"WITH PurchaseReturnData AS ( SELECT PRID, prm.PRVNUM, prm.Purchase_Return_Date, prm.Purchase_Return_Miti, prm.SenderID, cmi.Dup_cname, cmi.Dup_address, cmi.Dup_contact, prm.ReceiverID, scm.PartyName, scm.PartyCompany, scm.PartyAddress, scm.PartyContact, prm.TransectionOn, prm.Total, prm.Vat, prm.VatAmt, prm.TotalAmount, prm.Discount, prm.DiscAmount, prm.BillTotal, prm.InWords, prm.Note, CASE WHEN prm.is_Deleted = 0 THEN 'ACTIVE' ELSE 'DELETED' END AS is_Deleted, prm.UserID, usr.usrname AS Entered_By, prm.DateCreated, prm.MUserID, musr.usrname AS Modified_By, prm.ModifiedDate, prm.extraNote FROM MSM.PurchaseReturnMaster prm LEFT OUTER JOIN MSM.CustomerMaster scm ON scm.CID = prm.ReceiverID LEFT OUTER JOIN MSM.CompanyMasterInfo cmi ON cmi.Dup_cid = prm.SenderID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.UserID = prm.UserID LEFT OUTER JOIN MSM.UsersMaster musr ON musr.UserID = prm.MUserID WHERE prm.Purchase_Return_Date BETWEEN '{dateFrom}' and '{dateTo}' ) SELECT * FROM PurchaseReturnData ORDER BY Purchase_Return_Date DESC;";
                    else Query = $@"WITH PurchaseReturnData AS ( SELECT PRID, prm.PRVNUM, prm.Purchase_Return_Date, prm.Purchase_Return_Miti, prm.SenderID, cmi.Dup_cname, cmi.Dup_address, cmi.Dup_contact, prm.ReceiverID, scm.PartyName, scm.PartyCompany, scm.PartyAddress, scm.PartyContact, prm.TransectionOn, prm.Total, prm.Vat, prm.VatAmt, prm.TotalAmount, prm.Discount, prm.DiscAmount, prm.BillTotal, prm.InWords, prm.Note, CASE WHEN prm.is_Deleted = 0 THEN 'ACTIVE' ELSE 'DELETED' END AS is_Deleted, prm.UserID, usr.usrname AS Entered_By, prm.DateCreated, prm.MUserID, musr.usrname AS Modified_By, prm.ModifiedDate, prm.extraNote FROM MSM.PurchaseReturnMaster prm LEFT OUTER JOIN MSM.CustomerMaster scm ON scm.CID = prm.ReceiverID LEFT OUTER JOIN MSM.CompanyMasterInfo cmi ON cmi.Dup_cid = prm.SenderID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.UserID = prm.UserID LEFT OUTER JOIN MSM.UsersMaster musr ON musr.UserID = prm.MUserID WHERE prm.Purchase_Return_Miti BETWEEN '{dateFrom}' and '{dateTo}' ) SELECT * FROM PurchaseReturnData ORDER BY Purchase_Return_Date DESC;";

                }
                else if (type == "Sales Entry")
                {
                    if (dateType == "A.D") Query = $@"WITH SalesMasterData AS ( SELECT sm.SAID, sm.SVNUM, sm.Sales_Date, sm.Sales_Miti, sm.SalerID, cmi.Dup_cname, cmi.Dup_address, cmi.Dup_contact, sm.BuyerID, IIF(sm.BuyerID = 0, 'CASH A/C', scm.PartyName) AS PartyName, scm.PartyCompany, scm.PartyAddress, scm.PartyContact, sm.TransectionOn, sm.Total, sm.Vat, sm.VatAmt, sm.TotalAmount, sm.Discount, sm.DiscAmount, sm.BillTotal, sm.receivedAmt, sm.changeGiven, sm.dueBalance, sm.InWords, sm.is_hold, sm.is_Paid, sm.is_complete_paid, sm.Note, CASE WHEN sm.is_Deleted = 0 THEN 'ACTIVE' ELSE 'DELETED' END AS is_Deleted, sm.UserID, usr.usrname AS Entered_By, sm.DateCreated, sm.MUserID, musr.usrname AS Modified_By, sm.ModifiedDate, sm.extraNote FROM MSM.SalesMaster sm LEFT OUTER JOIN MSM.CustomerMaster scm ON scm.CID = sm.BuyerID LEFT OUTER JOIN MSM.CompanyMasterInfo cmi ON cmi.Dup_cid = sm.SalerID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.UserID = sm.UserID LEFT OUTER JOIN MSM.UsersMaster musr ON musr.UserID = sm.MUserID WHERE sm.Sales_Date BETWEEN '{dateFrom}' and '{dateTo}' ) SELECT * FROM SalesMasterData ORDER BY Sales_Date DESC;";
                    else Query = $@"WITH SalesMasterData AS ( SELECT sm.SAID, sm.SVNUM, sm.Sales_Date, sm.Sales_Miti, sm.SalerID, cmi.Dup_cname, cmi.Dup_address, cmi.Dup_contact, sm.BuyerID, IIF(sm.BuyerID = 0, 'CASH A/C', scm.PartyName) AS PartyName, scm.PartyCompany, scm.PartyAddress, scm.PartyContact, sm.TransectionOn, sm.Total, sm.Vat, sm.VatAmt, sm.TotalAmount, sm.Discount, sm.DiscAmount, sm.BillTotal, sm.receivedAmt, sm.changeGiven, sm.dueBalance, sm.InWords, sm.is_hold, sm.is_Paid, sm.is_complete_paid, sm.Note, CASE WHEN sm.is_Deleted = 0 THEN 'ACTIVE' ELSE 'DELETED' END AS is_Deleted, sm.UserID, usr.usrname AS Entered_By, sm.DateCreated, sm.MUserID, musr.usrname AS Modified_By, sm.ModifiedDate, sm.extraNote FROM MSM.SalesMaster sm LEFT OUTER JOIN MSM.CustomerMaster scm ON scm.CID = sm.BuyerID LEFT OUTER JOIN MSM.CompanyMasterInfo cmi ON cmi.Dup_cid = sm.SalerID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.UserID = sm.UserID LEFT OUTER JOIN MSM.UsersMaster musr ON musr.UserID = sm.MUserID WHERE sm.Sales_Miti BETWEEN '{dateFrom}' and '{dateTo}' ) SELECT * FROM SalesMasterData ORDER BY Sales_Date DESC;";

                }
                else if (type == "Sales Return")
                {
                    if (dateType == "A.D") Query = $@"WITH SalesReturnMasterData AS ( SELECT srm.SRID, srm.SRVNUM, srm.Sales_Date AS return_Date, srm.Sales_Miti AS return_miti, srm.SalerID, cmi.Dup_cname, cmi.Dup_address, cmi.Dup_contact, IIF(srm.BuyerID = 0, 'CASH A/C', scm.PartyName) AS PartyName, scm.PartyCompany, scm.PartyAddress, scm.PartyContact, srm.TransectionOn, srm.Total, srm.Vat, srm.VatAmt, srm.TotalAmount, srm.Discount, srm.DiscAmount, srm.BillTotal, srm.InWords, srm.Note, CASE WHEN srm.is_Deleted = 0 THEN 'ACTIVE' ELSE 'DELETED' END AS is_Deleted, srm.UserID, usr.usrname AS Entered_By, srm.DateCreated, srm.MUserID, musr.usrname AS Modified_By, srm.ModifiedDate, srm.extraNote, srm.status, srm.paid_amount, srm.return_amount, srm.SAID, srm.SVNUM, srm.previous_balance, srm.sales_bill_amt, srm.advance_given FROM MSM.SalesReturnMaster srm LEFT OUTER JOIN MSM.CustomerMaster scm ON scm.CID = srm.BuyerID LEFT OUTER JOIN MSM.CompanyMasterInfo cmi ON cmi.Dup_cid = srm.SalerID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.userid = srm.userid LEFT OUTER JOIN MSM.UsersMaster musr ON musr.userid = srm.MUserID WHERE srm.Sales_Date BETWEEN '{dateFrom}' and '{dateTo}' ) SELECT * FROM SalesReturnMasterData ORDER BY Sales_Date DESC;";
                    else Query = $@"WITH SalesReturnMasterData AS ( SELECT srm.SRID, srm.SRVNUM, srm.Sales_Date AS return_Date, srm.Sales_Miti AS return_miti, srm.SalerID, cmi.Dup_cname, cmi.Dup_address, cmi.Dup_contact, IIF(srm.BuyerID = 0, 'CASH A/C', scm.PartyName) AS PartyName, scm.PartyCompany, scm.PartyAddress, scm.PartyContact, srm.TransectionOn, srm.Total, srm.Vat, srm.VatAmt, srm.TotalAmount, srm.Discount, srm.DiscAmount, srm.BillTotal, srm.InWords, srm.Note, CASE WHEN srm.is_Deleted = 0 THEN 'ACTIVE' ELSE 'DELETED' END AS is_Deleted, srm.UserID, usr.usrname AS Entered_By, srm.DateCreated, srm.MUserID, musr.usrname AS Modified_By, srm.ModifiedDate, srm.extraNote, srm.status, srm.paid_amount, srm.return_amount, srm.SAID, srm.SVNUM, srm.previous_balance, srm.sales_bill_amt, srm.advance_given FROM MSM.SalesReturnMaster srm LEFT OUTER JOIN MSM.CustomerMaster scm ON scm.CID = srm.BuyerID LEFT OUTER JOIN MSM.CompanyMasterInfo cmi ON cmi.Dup_cid = srm.SalerID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.userid = srm.userid LEFT OUTER JOIN MSM.UsersMaster musr ON musr.userid = srm.MUserID WHERE srm.Sales_Miti BETWEEN '{dateFrom}' and '{dateTo}' ) SELECT * FROM SalesReturnMasterData ORDER BY Sales_Date DESC;";

                }
                else
                {
                    //ignore
                }
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionLocalMaster, CommandType.Text, Query).Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        //public string NumberToWords(decimal number)
        //{
        //    if (number == 0) return " zero";
        //    if (number < 0) return " minus" + NumberToWords(Math.Abs(number));
        //    string words = string.Empty;
        //    if((number/1000000) > 0)
        //    {
        //        words += NumberToWords(number / 1000000) + " million";
        //        number %= 1000000;
        //    }
        //    if ((number / 1000) > 0)
        //    {
        //        words += NumberToWords(number / 1000) + " thousend";
        //        number %= 1000;
        //    }
        //    if ((number / 100) > 0)
        //    {
        //        words += NumberToWords(number / 1000) + " hundred";
        //        number %= 100;
        //    }
        //    if (number > 0)
        //    {
        //        if (words != "") words += "and";
        //        var unitMap = new []
        //        {
        //            " zero",
        //            " one",
        //            " two",
        //            " three",
        //            " four",
        //            " five",
        //            " six",
        //            " seven",
        //            " eight",
        //            " nine",
        //            " ten",
        //            " eleven",
        //            " twelve",
        //            " thirteen",
        //            " fourteen",
        //            " fifteen",
        //            " sixteen",
        //            " seventeen",
        //            " eighteen",
        //            " nineteen"
        //        };

        //        var tensMap = new[]
        //        {
        //            " zero",
        //            " ten",
        //            " twenty",
        //            " thirty",
        //            " fourty",
        //            " fifty",
        //            " sixty",
        //            " seventy",
        //            " eighty",
        //            " ninety",
        //        };

        //        if(number<20)
        //        {
        //            //words += unitMap[Int32.Parse(number.ToString())];
        //            //words += unitMap[number];
        //            //words = unitMap + number
        //        }
        //        else
        //        {
        //            //words += tensMap[number / 10];
        //            //if ((number % 10) > 0)
        //            //    words += "-" + unitMap[number % 10];
        //            words += tensMap[Int32.Parse((number / 10).ToString())];
        //            if ((number % 10) > 0)
        //                words += "-" + unitMap[Int32.Parse((number % 10).ToString())];
        //        }
        //    }
        //    return words;
        //}

        //public DataTable chkAvaialiblity(string ToPerform, string Table, string ColumnName, string TxtboxValue, string reText)
        //{
        //    var Query = $"Select * From {Table} where {ColumnName} ='{TxtboxValue}'";
        //    return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
        //}
        #endregion




    }
}
