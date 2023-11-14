using MSMControl.Connection;
using MSMControl.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSMControl.Class
{
    public class ClsPopUpSearch : IPopUpSearch
    {
        private IMainMaster _ObjMainMaster;

        public ClsPopUpSearch()
        {
            _ObjMainMaster = new ClsMainMaster();
        }

        public DataTable GetCompanyList(int ID)
        {
            if (ID > 0)
            {
                var Query = $@"SELECT * FROM dbo.[master.CompanyMasterInfo] ci ,dbo.[master.ServerConnInfo] sc where ci.cid = {ID};";
                return Execute.ExecuteDataSetOnLocalMaster(Connection.Connection.ConnectionLocalMaster, CommandType.Text, Query).Tables[0];

            }
            else
            {
                var Query = @"SELECT * FROM dbo.[master.CompanyMasterInfo] ci ,dbo.[master.ServerConnInfo] sc;";
                return Execute.ExecuteDataSetOnLocalMaster(Connection.Connection.ConnectionLocalMaster, CommandType.Text, Query).Tables[0];
            }
        }

        public DataTable GetLoginCompanyList(long ID)
        {
            ID = Global.CompanyID;
            var Query = $@"SELECT * FROM dbo.[master.CompanyMasterInfo] ci ,dbo.[master.ServerConnInfo] sc where ci.cid = {ID};";
            return Execute.ExecuteDataSetOnLocalMaster(Connection.Connection.ConnectionLocalMaster, CommandType.Text, Query).Tables[0];
        }

        public DataTable GetUserRole(int ID ,int Status)
        {
            if (ID > 0)
            {
                var Query = $@"select RoleId,RoleName,RoleStatus from MSM.UsersRole where [RoleId] = {ID};";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];

            }
            else if(Status == 1)
            {
                var Query = @"select RoleId,RoleName,RoleStatus from MSM.UsersRole WHERE RoleId <> 1 and RoleStatus = 1;";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
            }
            else
            {
                var Query = @"select RoleId,RoleName,RoleStatus from MSM.UsersRole WHERE RoleId <> 1;";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
            }
        }


        public DataTable GetCustomer(int ID, int Status)
        {
            if (ID > 0)
            {
                var Query = $@"SELECT [CID],[PartyName],[PartyCode],[PartyEmail],[PartyCompany],[PartyAddress],[PartyState],[PartyCountry],[PartyContact],[PartyReg],[PartyNote],[ActiveStatus],[UserID],[DateCreated],[MUserID],[ModifiedDate] FROM MSM.CustomerMaster WHERE [CID] = {ID};";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];

            }
            else if (Status == 1)
            {
                var Query = @"SELECT [CID],[PartyName],[PartyCode],[PartyEmail],[PartyCompany],[PartyAddress],[PartyState],[PartyCountry],[PartyContact],[PartyReg],[PartyNote],[ActiveStatus],[UserID],[DateCreated],[MUserID],[ModifiedDate] FROM MSM.CustomerMaster WHERE ActiveStatus = 1;";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
            }
            else
            {
                var Query = @"SELECT [CID],[PartyName],[PartyCode],[PartyEmail],[PartyCompany],[PartyAddress],[PartyState],[PartyCountry],[PartyContact],[PartyReg],[PartyNote],[ActiveStatus],[UserID],[DateCreated],[MUserID],[ModifiedDate] FROM MSM.CustomerMaster;";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
            }
        }

        public DataTable GetProduct(int ID, int Status, string value)
        {
            if (ID > 0)
            {
                var Query = $@"SELECT PM.[PID],POI.InventID,PM.[PName],PM.[PCode],PM.[PBarcode],PM.[UnitID],UM.Unit MainUnit,UM.UnitCode MainUnitCode,PM.[UnitQnty],PM.[AltUnitId],AUM.Unit AltUnit,AUM.UnitCode AltUnitCode,PM.[AltUnitQnty],PM.[PurchasePrice],PM.[MRP],PM.[Offer],PM.[PNote],PC.CategoryID AS CategoryCode,PM.[ProductCategory],PM.[ActiveStatus],PM.[UserID],PM.[DateCreated],PM.[MUserID],PM.[ModifiedDate] FROM MSM.ProductMaster PM LEFT OUTER JOIN MSM.ProductCategory PC ON  PC.[Category] = PM.[ProductCategory] LEFT OUTER JOIN MSM.UnitMaster UM ON UM.UnitID = PM.UnitID LEFT OUTER JOIN MSM.UnitMaster AUM ON AUM.UnitID = PM.AltUnitId LEFT OUTER JOIN MSM.ProductInventory POI ON PM.PID = POI.prodID WHERE PM.PID = {ID};";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];

            }
            else if (Status == 1)
            {
                var Query = string.Empty;
                if (value != "" && value != "All")
                {
                    Query = $@"SELECT PM.[PID],POI.InventID,PM.[PName],PM.[PCode],PM.[PBarcode],PM.[UnitID],UM.Unit MainUnit,UM.UnitCode MainUnitCode,PM.[UnitQnty],PM.[AltUnitId],AUM.Unit AltUnit,AUM.UnitCode AltUnitCode,PM.[AltUnitQnty],PM.[PurchasePrice],PM.[MRP],PM.[Offer],PM.[PNote],PC.CategoryID AS CategoryCode,PM.[ProductCategory],PM.[ActiveStatus],PM.[UserID],PM.[DateCreated],PM.[MUserID],PM.[ModifiedDate] FROM MSM.ProductMaster PM LEFT OUTER JOIN MSM.ProductCategory PC ON  PC.[Category] = PM.[ProductCategory] LEFT OUTER JOIN MSM.UnitMaster UM ON UM.UnitID = PM.UnitID LEFT OUTER JOIN MSM.UnitMaster AUM ON AUM.UnitID = PM.AltUnitId LEFT OUTER JOIN MSM.ProductInventory POI ON PM.PID = POI.prodID WHERE PC.CategoryID = '{value}';";
                }
                else
                {
                    Query = @"SELECT PM.[PID],POI.InventID,PM.[PName],PM.[PCode],PM.[PBarcode],PM.[UnitID],UM.Unit MainUnit,UM.UnitCode MainUnitCode,PM.[UnitQnty],PM.[AltUnitId],AUM.Unit AltUnit,AUM.UnitCode AltUnitCode,PM.[AltUnitQnty],PM.[PurchasePrice],PM.[MRP],PM.[Offer],PM.[PNote],PC.CategoryID AS CategoryCode,PM.[ProductCategory],PM.[ActiveStatus],PM.[UserID],PM.[DateCreated],PM.[MUserID],PM.[ModifiedDate] FROM MSM.ProductMaster PM LEFT OUTER JOIN MSM.ProductCategory PC ON  PC.[Category] = PM.[ProductCategory] LEFT OUTER JOIN MSM.UnitMaster UM ON UM.UnitID = PM.UnitID LEFT OUTER JOIN MSM.UnitMaster AUM ON AUM.UnitID = PM.AltUnitId LEFT OUTER JOIN MSM.ProductInventory POI ON PM.PID = POI.prodID WHERE PM.ActiveStatus = 1;";
                }
                
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
            }
            else
            {
                var Query = @"SELECT PM.[PID],POI.InventID,PM.[PName],PM.[PCode],PM.[PBarcode],PM.[UnitID],UM.Unit MainUnit,UM.UnitCode MainUnitCode,PM.[UnitQnty],PM.[AltUnitId],AUM.Unit AltUnit,AUM.UnitCode AltUnitCode,PM.[AltUnitQnty],PM.[PurchasePrice],PM.[MRP],PM.[Offer],PM.[PNote],PC.CategoryID AS CategoryCode,PM.[ProductCategory],PM.[ActiveStatus],PM.[UserID],PM.[DateCreated],PM.[MUserID],PM.[ModifiedDate] FROM MSM.ProductMaster PM LEFT OUTER JOIN MSM.ProductCategory PC ON  PC.[Category] = PM.[ProductCategory] LEFT OUTER JOIN MSM.UnitMaster UM ON UM.UnitID = PM.UnitID LEFT OUTER JOIN MSM.UnitMaster AUM ON AUM.UnitID = PM.AltUnitId LEFT OUTER JOIN MSM.ProductInventory POI ON PM.PID = POI.prodID;";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
            }
            
        }

        public DataTable getCategory(int ID)
        {
            if (ID > 0)
            {
                var Query = $@"SELECT [CatID],[Category],[CategoryID],[ActiveStatus],[UserID],[DateCreated],[MUserID],[ModifiedDate] FROM [MSM].[ProductCategory] WHERE [CatID] = {ID};";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];

            }
            else
            {
                var Query = @"SELECT [CatID],[Category],[CategoryID],[ActiveStatus],[UserID],[DateCreated],[MUserID],[ModifiedDate] FROM [MSM].[ProductCategory] ORDER BY [CatID];";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
            }
        }

        public DataTable getGodown(int ID)
        {
            if (ID > 0)
            {
                var Query = $@"SELECT [GodID],[GodName],[GodCode],[GodAddress],[ActiveStatus],[UserID],[DateCreated],[MUserID],[ModifiedDate] FROM [MSM].[StoreGodown] WHERE [GodID] = {ID};";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];

            }
            else
            {
                var Query = @"SELECT [GodID],[GodName],[GodCode],[GodAddress],[ActiveStatus],[UserID],[DateCreated],[MUserID],[ModifiedDate] FROM [MSM].[StoreGodown] ORDER BY [GodID];";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
            }
        }

        public DataTable getPurchaseOrder(int ID, int status , int is_deleted)
        {
            if (status == 1) //status 1 is working for is_deleted = 0
            {
                var Query = $@"SELECT pom.[POID],pom.POVNUM,pom.Order_Date,pom.Order_Miti,pom.ReceiverID ,musrr.usrname,cmi.Dup_cname ,cmi.Dup_address ,cmi.Dup_contact,pom.SenderID ,scm.PartyName ,scm.PartyCompany,scm.PartyAddress ,scm.PartyContact,pom.TransectionOn,pom.Total,pom.Vat,pom.VatAmt,pom.TotalAmount,pom.Discount,pom.DiscAmount,pom.BillTotal,pom.InWords,CASE WHEN pom.PO_Bill_Status = '0' THEN 'PENDING' ELSE 'RECEIVED ALL' END AS PO_Bill_Status,pom.UserID,pom.DateCreated,pom.MUserID,pom.ModifiedDate,goods_quantity,CASE WHEN pom.is_Deleted = '0' THEN 'No' ELSE 'Yes' END AS is_Deleted FROM [MSM].[PurchaseOrderMaster] as pom left outer join MSM.CompanyMasterInfo cmi on cmi.Dup_cid = pom.ReceiverID left outer join MSM.CustomerMaster scm on scm.CID = pom.SenderID left outer join MSM.UsersMaster musrr on musrr.userid = pom.UserID left outer join MSM.UsersMaster mmusr on mmusr.userid = pom.MUserID where pom.is_Deleted = 0 and pom.PO_Bill_Status = 0 ORDER BY pom.POID DESC;
                               SELECT pod.POID D_POID,pod.POVNUM D_POVNUM,pod.PID ,pod.PName ,pod.PCode ,pod.PBarcode ,pod.Quantiy ,pod.UnitID ,um.Unit ,um.UnitCode ,pod.PPrice ,pod.TotalPrice,pod.PNote ,pod.UserID ,usr.usrname ,pod.DateCreated ,pod.MUserID,musr.usrname musrname,pod.ModifiedDate,PO_Bill_Status,is_Deleted from MSM.PurchaseOrderDetails as pod left outer join MSM.UnitMaster um on um.UnitID = pod.UnitID  left outer join MSM.UsersMaster usr on usr.userid = pod.UserID left outer join MSM.UsersMaster musr on musr.userid = pod.MUserID where  pod.is_Deleted = 0 and pod.PO_Bill_Status = 0 ORDER BY D_POID DESC;";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
            }
            if (ID > 0 && status == 1)
            {
                var Query = $@"SELECT pom.[POID],pom.POVNUM,pom.Order_Date,pom.Order_Miti,pom.ReceiverID ,musrr.usrname,cmi.Dup_cname ,cmi.Dup_address ,cmi.Dup_contact,pom.SenderID ,scm.PartyName ,scm.PartyCompany,scm.PartyAddress ,scm.PartyContact,pom.TransectionOn,pom.Total,pom.Vat,pom.VatAmt,pom.TotalAmount,pom.Discount,pom.DiscAmount,pom.BillTotal,pom.InWords,CASE WHEN pom.PO_Bill_Status = '0' THEN 'PENDING' ELSE 'RECEIVED ALL' END AS PO_Bill_Status,pom.UserID,pom.DateCreated,pom.MUserID,pom.ModifiedDate,goods_quantity,CASE WHEN pom.is_Deleted = '0' THEN 'No' ELSE 'Yes' END AS is_Deleted FROM [MSM].[PurchaseOrderMaster] as pom left outer join MSM.CompanyMasterInfo cmi on cmi.Dup_cid = pom.ReceiverID left outer join MSM.CustomerMaster scm on scm.CID = pom.SenderID left outer join MSM.UsersMaster musrr on musrr.userid = pom.UserID left outer join MSM.UsersMaster mmusr on mmusr.userid = pom.MUserID where pom.is_Deleted = 0 and pom.PO_Bill_Status = 0 and POID = {ID};
                               SELECT pod.POID D_POID,pod.POVNUM D_POVNUM,pod.PID ,pod.PName ,pod.PCode ,pod.PBarcode ,pod.Quantiy ,pod.UnitID ,um.Unit ,um.UnitCode ,pod.PPrice ,pod.TotalPrice,pod.PNote ,pod.UserID ,usr.usrname ,pod.DateCreated ,pod.MUserID,musr.usrname musrname,pod.ModifiedDate,PO_Bill_Status,is_Deleted from MSM.PurchaseOrderDetails as pod left outer join MSM.UnitMaster um on um.UnitID = pod.UnitID  left outer join MSM.UsersMaster usr on usr.userid = pod.UserID left outer join MSM.UsersMaster musr on musr.userid = pod.MUserID where  pod.is_Deleted = 0 and pod.PO_Bill_Status = 0 and pod.POID = {ID};";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
            }
            if (ID > 0)
            {
                var Query = $@"SELECT pom.[POID],pom.POVNUM,pom.Order_Date,pom.Order_Miti,pom.ReceiverID ,musrr.usrname,cmi.Dup_cname ,cmi.Dup_address ,cmi.Dup_contact,pom.SenderID ,scm.PartyName ,scm.PartyCompany,scm.PartyAddress ,scm.PartyContact,pom.TransectionOn,pom.Total,pom.Vat,pom.VatAmt,pom.TotalAmount,pom.Discount,pom.DiscAmount,pom.BillTotal,pom.InWords,CASE WHEN pom.PO_Bill_Status = '0' THEN 'PENDING' ELSE 'RECEIVED ALL' END AS PO_Bill_Status,pom.UserID,pom.DateCreated,pom.MUserID,pom.ModifiedDate,goods_quantity,CASE WHEN pom.is_Deleted = '0' THEN 'No' ELSE 'Yes' END AS is_Deleted FROM [MSM].[PurchaseOrderMaster] as pom left outer join MSM.CompanyMasterInfo cmi on cmi.Dup_cid = pom.ReceiverID left outer join MSM.CustomerMaster scm on scm.CID = pom.SenderID left outer join MSM.UsersMaster musrr on musrr.userid = pom.UserID left outer join MSM.UsersMaster mmusr on mmusr.userid = pom.MUserID where POID = {ID}; 
                               SELECT pod.POID D_POID,pod.POVNUM D_POVNUM,pod.PID ,pod.PName ,pod.PCode ,pod.PBarcode ,pod.Quantiy ,pod.UnitID ,um.Unit ,um.UnitCode ,pod.PPrice ,pod.TotalPrice,pod.PNote ,pod.UserID ,usr.usrname ,pod.DateCreated ,pod.MUserID,musr.usrname musrname,pod.ModifiedDate,PO_Bill_Status,is_Deleted from MSM.PurchaseOrderDetails as pod left outer join MSM.UnitMaster um on um.UnitID = pod.UnitID  left outer join MSM.UsersMaster usr on usr.userid = pod.UserID left outer join MSM.UsersMaster musr on musr.userid = pod.MUserID where pod.POID = {ID};";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];

            }
            else
            {
                var midQuery = string.Empty;
                if (is_deleted == 1) midQuery = "where is_Deleted <> 1";
                var Query = $@"SELECT pom.[POID],pom.POVNUM,pom.Order_Date,pom.Order_Miti,pom.ReceiverID ,musrr.usrname,cmi.Dup_cname ,cmi.Dup_address ,cmi.Dup_contact,pom.SenderID ,scm.PartyName ,scm.PartyCompany,scm.PartyAddress ,scm.PartyContact,pom.TransectionOn,pom.Total,pom.Vat,pom.VatAmt,pom.TotalAmount,pom.Discount,pom.DiscAmount,pom.BillTotal,pom.InWords,CASE WHEN pom.PO_Bill_Status = '0' THEN 'PENDING' ELSE 'RECEIVED ALL' END AS PO_Bill_Status,pom.UserID,pom.DateCreated,pom.MUserID,pom.ModifiedDate,goods_quantity,CASE WHEN pom.is_Deleted = '0' THEN 'No' ELSE 'Yes' END AS is_Deleted FROM [MSM].[PurchaseOrderMaster] as pom left outer join MSM.CompanyMasterInfo cmi on cmi.Dup_cid = pom.ReceiverID left outer join MSM.CustomerMaster scm on scm.CID = pom.SenderID left outer join MSM.UsersMaster musrr on musrr.userid = pom.UserID left outer join MSM.UsersMaster mmusr on mmusr.userid = pom.MUserID {midQuery} ORDER BY [POID] DESC;
                              SELECT pod.POID D_POID,pod.POVNUM D_POVNUM,pod.PID ,pod.PName ,pod.PCode ,pod.PBarcode ,pod.Quantiy ,pod.UnitID ,um.Unit ,um.UnitCode ,pod.PPrice ,pod.TotalPrice,pod.PNote ,pod.UserID ,usr.usrname ,pod.DateCreated ,pod.MUserID,musr.usrname musrname,pod.ModifiedDate,PO_Bill_Status,is_Deleted from MSM.PurchaseOrderDetails as pod left outer join MSM.UnitMaster um on um.UnitID = pod.UnitID  left outer join MSM.UsersMaster usr on usr.userid = pod.UserID left outer join MSM.UsersMaster musr on musr.userid = pod.MUserID {midQuery} ORDER BY pod.POID DESC;";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
            }
        }

        public DataTable getPurchaseEntry(int ID, int status)
        {
            if (ID > 0)
            {
                var Query = $@"SELECT pm.PEID,pm.PVNUM,pm.Purchase_Date,pm.Purchase_Miti,pm.ref_bill_No,(select POID from msm.PurchaseOrderMaster pp where pp.POVNUM = pm.Purchase_OrderNo) As POID,pm.Purchase_OrderNo,pm.PO_ReferenceNo,pm.SenderID,scm.PartyName ,scm.PartyCompany,scm.PartyAddress ,scm.PartyContact,pm.ReceiverID,cmi.Dup_cname ,cmi.Dup_address ,cmi.Dup_contact,pm.TransectionOn,pm.Total,pm.Vat,pm.VatAmt,pm.TotalAmount,pm.Discount,pm.DiscAmount,pm.BillTotal,pm.InWords,pm.Note,IIF(pm.PO_Bill_Status = 0,'PENDING','RECEIVED ALL') AS PO_Bill_Status,IIF(pm.is_Deleted = 0, 'ACTIVE','DELETED') AS is_Deleted,pm.UserID,usr.usrname Entered_By,pm.DateCreated,pm.MUserID,musr.usrname Modified_By,pm.ModifiedDate FROM MSM.PurchaseMaster pm left outer join MSM.CompanyMasterInfo cmi on cmi.Dup_cid = pm.ReceiverID left outer join MSM.CustomerMaster scm on scm.CID = pm.SenderID left outer join MSM.UsersMaster usr on usr.userid = pm.UserID left outer join MSM.UsersMaster musr on musr.userid = pm.MUserID where pm.PEID = {ID};
                               SELECT pd.PEID,pd.PVNUM,pd.PID,pd.PName,pd.PCode,pd.PBarcode,pd.Quantiy,pd.UnitID,um.Unit ,um.UnitCode ,pd.PPrice,pd.TotalPrice,pd.UserID,usr.usrname Entered_By,pd.DateCreated,pd.MUserID,musr.usrname Modified_By,pd.ModifiedDate,IIF(pd.is_Deleted = 0, 'ACTIVE','DELETED') AS is_Deleted FROM MSM.PurchaseDetails pd left outer join MSM.UnitMaster um on um.UnitID = pd.UnitID left outer join MSM.UsersMaster usr on usr.userid = pd.UserID left outer join MSM.UsersMaster musr on musr.userid = pd.MUserID where pd.PEID = {ID};";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
            }
            else
            {
                var Query = $@"SELECT pm.PEID,pm.PVNUM,pm.Purchase_Date,pm.Purchase_Miti,pm.ref_bill_No,(select POID from msm.PurchaseOrderMaster pp where pp.POVNUM = pm.Purchase_OrderNo) As POID,pm.Purchase_OrderNo,pm.PO_ReferenceNo,pm.SenderID,scm.PartyName ,scm.PartyCompany,scm.PartyAddress ,scm.PartyContact,pm.ReceiverID,cmi.Dup_cname ,cmi.Dup_address ,cmi.Dup_contact,pm.TransectionOn,pm.Total,pm.Vat,pm.VatAmt,pm.TotalAmount,pm.Discount,pm.DiscAmount,pm.BillTotal,pm.InWords,pm.Note,IIF(pm.PO_Bill_Status = 0,'PENDING','RECEIVED ALL') AS PO_Bill_Status,IIF(pm.is_Deleted = 0, 'ACTIVE','DELETED') AS is_Deleted,pm.UserID,usr.usrname Entered_By,pm.DateCreated,pm.MUserID,musr.usrname Modified_By,pm.ModifiedDate FROM MSM.PurchaseMaster pm left outer join MSM.CompanyMasterInfo cmi on cmi.Dup_cid = pm.ReceiverID left outer join MSM.CustomerMaster scm on scm.CID = pm.SenderID left outer join MSM.UsersMaster usr on usr.userid = pm.UserID left outer join MSM.UsersMaster musr on musr.userid = pm.MUserID order by pm.PEID DESC;
                               SELECT PEID,pd.PVNUM,pd.PID,pd.PName,pd.PCode,pd.PBarcode,pd.Quantiy,pd.UnitID,um.Unit ,um.UnitCode ,pd.PPrice,pd.TotalPrice,pd.UserID,usr.usrname Entered_By,pd.DateCreated,pd.MUserID,musr.usrname Modified_By,pd.ModifiedDate,IIF(pd.is_Deleted = 0, 'ACTIVE','DELETED') AS is_Deleted FROM MSM.PurchaseDetails pd left outer join MSM.UnitMaster um on um.UnitID = pd.UnitID left outer join MSM.UsersMaster usr on usr.userid = pd.UserID left outer join MSM.UsersMaster musr on musr.userid = pd.MUserID  order by pd.PEID DESC;";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
            }
        }

        public DataTable getPurchaseReturnEntry(int ID, int status)
        {
            if (ID > 0)
            {
                var Query = $@"SELECT PRID,prm.PRVNUM,prm.Purchase_Return_Date,prm.Purchase_Return_Miti,prm.SenderID,cmi.Dup_cname,cmi.Dup_address,cmi.Dup_contact,prm.ReceiverID,scm.PartyName,scm.PartyCompany,scm.PartyAddress,scm.PartyContact,prm.TransectionOn,prm.Total,prm.Vat,prm.VatAmt,prm.TotalAmount,prm.Discount,prm.DiscAmount,prm.BillTotal,prm.InWords,prm.Note,IIF(prm.is_Deleted = 0, 'ACTIVE', 'DELETED') AS is_Deleted,prm.UserID,usr.usrname Entered_By,prm.DateCreated,prm.MUserID,musr.usrname Modified_By,prm.ModifiedDate,prm.extraNote FROM MSM.PurchaseReturnMaster prm LEFT OUTER JOIN MSM.CustomerMaster scm ON scm.CID = prm.ReceiverID LEFT OUTER JOIN MSM.CompanyMasterInfo cmi ON cmi.Dup_cid = prm.SenderID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.UserID = prm.UserID LEFT OUTER JOIN MSM.UsersMaster musr ON musr.UserID = prm.MUserID where prm.PRID = {ID};" +
                            $@"SELECT prd.PRID,prd.PRVNUM,prd.PID,prd.PName,prd.PCode,prd.PBarcode,prd.Quantiy,prd.UnitID,um.Unit,um.UnitCode,prd.PPrice,prd.TotalPrice,prd.Note,prd.UserID,usr.usrname Entered_By,prd.DateCreated,prd.MUserID,musr.usrname Modified_By,prd.ModifiedDate,IIF(prd.is_Deleted = 0, 'ACTIVE', 'DELETED') AS is_Deleted FROM MSM.PurchaseReturnDetails prd LEFT OUTER JOIN MSM.UnitMaster um ON um.UnitID = prd.UnitID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.UserID = prd.UserID LEFT OUTER JOIN MSM.UsersMaster musr ON musr.UserID = prd.MUserID  where prd.PRID = {ID};";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
            }
            else
            {
                var Query = $@"SELECT PRID,prm.PRVNUM,prm.Purchase_Return_Date,prm.Purchase_Return_Miti,prm.SenderID,cmi.Dup_cname,cmi.Dup_address,cmi.Dup_contact,prm.ReceiverID,scm.PartyName,scm.PartyCompany,scm.PartyAddress,scm.PartyContact,prm.TransectionOn,prm.Total,prm.Vat,prm.VatAmt,prm.TotalAmount,prm.Discount,prm.DiscAmount,prm.BillTotal,prm.InWords,prm.Note,IIF(prm.is_Deleted = 0, 'ACTIVE', 'DELETED') AS is_Deleted,prm.UserID,usr.usrname Entered_By,prm.DateCreated,prm.MUserID,musr.usrname Modified_By,prm.ModifiedDate,prm.extraNote FROM MSM.PurchaseReturnMaster prm LEFT OUTER JOIN MSM.CustomerMaster scm ON scm.CID = prm.ReceiverID LEFT OUTER JOIN MSM.CompanyMasterInfo cmi ON cmi.Dup_cid = prm.SenderID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.UserID = prm.UserID LEFT OUTER JOIN MSM.UsersMaster musr ON musr.UserID = prm.MUserID ORDER BY prm.PRID DESC;"+
                               "SELECT prd.PRID,prd.PRVNUM,prd.PID,prd.PName,prd.PCode,prd.PBarcode,prd.Quantiy,prd.UnitID,um.Unit,um.UnitCode,prd.PPrice,prd.TotalPrice,prd.Note,prd.UserID,usr.usrname Entered_By,prd.DateCreated,prd.MUserID,musr.usrname Modified_By,prd.ModifiedDate,IIF(prd.is_Deleted = 0, 'ACTIVE', 'DELETED') AS is_Deleted FROM MSM.PurchaseReturnDetails prd LEFT OUTER JOIN MSM.UnitMaster um ON um.UnitID = prd.UnitID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.UserID = prd.UserID LEFT OUTER JOIN MSM.UsersMaster musr ON musr.UserID = prd.MUserID ORDER BY prd.PRID DESC;";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
            }
        }

        public DataTable getSalesEntry(int Id, int status,int is_deleted)
        {
            if (Id > 0)
            {
                var Query = $@"SELECT sm.SAID,sm.SVNUM,sm.Sales_Date,sm.Sales_Miti,sm.SalerID,cmi.Dup_cname,cmi.Dup_address,cmi.Dup_contact,sm.BuyerID,IIF(sm.BuyerID = 0, 'CASH A/C', scm.PartyName) AS PartyName,scm.PartyCompany,scm.PartyAddress,scm.PartyContact,sm.TransectionOn,sm.Total,sm.Vat,sm.VatAmt,sm.TotalAmount,sm.Discount,sm.DiscAmount,sm.BillTotal,sm.receivedAmt,sm.changeGiven,sm.dueBalance,sm.InWords,sm.is_hold,sm.is_Paid,sm.is_complete_paid,sm.Note,IIF(sm.is_Deleted = 0, 'ACTIVE', 'DELETED') AS is_Deleted,sm.UserID,usr.usrname Entered_By,sm.DateCreated,sm.MUserID,musr.usrname Modified_By,sm.ModifiedDate,sm.extraNote FROM MSM.SalesMaster sm LEFT OUTER JOIN MSM.CustomerMaster scm ON scm.CID = sm.BuyerID LEFT OUTER JOIN MSM.CompanyMasterInfo cmi ON cmi.Dup_cid = sm.SalerID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.UserID = sm.UserID LEFT OUTER JOIN MSM.UsersMaster musr ON musr.UserID = sm.MUserID where sm.SAID = {Id};" +
                            $@"SELECT sd.SAID,sd.SVNUM,sd.PID,sd.PName,sd.PCode,sd.PBarcode,sd.Quantiy,sd.UnitID,um.Unit,um.UnitCode,sd.PPrice,sd.pDisc,sd.pamount,sd.TotalPrice,sd.Note,sd.UserID,usr.usrname Entered_By,sd.DateCreated,sd.MUserID,musr.usrname Modified_By,sd.ModifiedDate,IIF(sd.is_Deleted = 0, 'ACTIVE', 'DELETED') AS is_Deleted FROM MSM.SalesDetails sd LEFT OUTER JOIN MSM.UnitMaster um ON um.UnitID = sd.UnitID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.UserID = sd.UserID LEFT OUTER JOIN MSM.UsersMaster musr ON musr.UserID = sd.MUserID where sm.SAID = {Id};";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
            }
            else if(status > 0)
            {
                var Query = $@"SELECT sm.SAID,sm.SVNUM,sm.Sales_Date,sm.Sales_Miti,sm.SalerID,cmi.Dup_cname,cmi.Dup_address,cmi.Dup_contact,sm.BuyerID,IIF(sm.BuyerID = 0, 'CASH A/C', scm.PartyName) AS PartyName,scm.PartyCompany,scm.PartyAddress,scm.PartyContact,sm.TransectionOn,sm.Total,sm.Vat,sm.VatAmt,sm.TotalAmount,sm.Discount,sm.DiscAmount,sm.BillTotal,sm.receivedAmt,sm.changeGiven,sm.dueBalance,sm.InWords,sm.is_hold,sm.is_Paid,sm.is_complete_paid,sm.Note,IIF(sm.is_Deleted = 0, 'ACTIVE', 'DELETED') AS is_Deleted,sm.UserID,usr.usrname Entered_By,sm.DateCreated,sm.MUserID,musr.usrname Modified_By,sm.ModifiedDate,sm.extraNote FROM MSM.SalesMaster sm LEFT OUTER JOIN MSM.CustomerMaster scm ON scm.CID = sm.BuyerID LEFT OUTER JOIN MSM.CompanyMasterInfo cmi ON cmi.Dup_cid = sm.SalerID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.UserID = sm.UserID LEFT OUTER JOIN MSM.UsersMaster musr ON musr.UserID = sm.MUserID where sm.is_hold = {status};" +
                              "SELECT sd.SAID,sd.SVNUM,sd.PID,sd.PName,sd.PCode,sd.PBarcode,sd.Quantiy,sd.UnitID,um.Unit,um.UnitCode,sd.PPrice,sd.pDisc,sd.pamount,sd.TotalPrice,sd.Note,sd.UserID,usr.usrname Entered_By,sd.DateCreated,sd.MUserID,musr.usrname Modified_By,sd.ModifiedDate,IIF(sd.is_Deleted = 0, 'ACTIVE', 'DELETED') AS is_Deleted FROM MSM.SalesDetails sd LEFT OUTER JOIN MSM.UnitMaster um ON um.UnitID = sd.UnitID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.UserID = sd.UserID LEFT OUTER JOIN MSM.UsersMaster musr ON musr.UserID = sd.MUserID ORDER BY sd.SAID DESC;";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
            }
            else
            {
                var midQuery = string.Empty;
                if(is_deleted == 1) midQuery = "where is_Deleted <> 1";

                var Query = $@"SELECT sm.SAID,sm.SVNUM,sm.Sales_Date,sm.Sales_Miti,sm.SalerID,cmi.Dup_cname,cmi.Dup_address,cmi.Dup_contact,sm.BuyerID,IIF(sm.BuyerID = 0, 'CASH A/C', scm.PartyName) AS PartyName,scm.PartyCompany,scm.PartyAddress,scm.PartyContact,sm.TransectionOn,sm.Total,sm.Vat,sm.VatAmt,sm.TotalAmount,sm.Discount,sm.DiscAmount,sm.BillTotal,sm.receivedAmt,sm.changeGiven,sm.dueBalance,sm.InWords,sm.is_hold,sm.is_Paid,sm.is_complete_paid,sm.Note,IIF(sm.is_Deleted = 0, 'ACTIVE', 'DELETED') AS is_Deleted,sm.UserID,usr.usrname Entered_By,sm.DateCreated,sm.MUserID,musr.usrname Modified_By,sm.ModifiedDate,sm.extraNote FROM MSM.SalesMaster sm LEFT OUTER JOIN MSM.CustomerMaster scm ON scm.CID = sm.BuyerID LEFT OUTER JOIN MSM.CompanyMasterInfo cmi ON cmi.Dup_cid = sm.SalerID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.UserID = sm.UserID LEFT OUTER JOIN MSM.UsersMaster musr ON musr.UserID = sm.MUserID {midQuery} ORDER BY sm.SAID DESC;" +
                            $@"SELECT sd.SAID,sd.SVNUM,sd.PID,sd.PName,sd.PCode,sd.PBarcode,sd.Quantiy,sd.UnitID,um.Unit,um.UnitCode,sd.PPrice,sd.pDisc,sd.pamount,sd.TotalPrice,sd.Note,sd.UserID,usr.usrname Entered_By,sd.DateCreated,sd.MUserID,musr.usrname Modified_By,sd.ModifiedDate,IIF(sd.is_Deleted = 0, 'ACTIVE', 'DELETED') AS is_Deleted FROM MSM.SalesDetails sd LEFT OUTER JOIN MSM.UnitMaster um ON um.UnitID = sd.UnitID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.UserID = sd.UserID LEFT OUTER JOIN MSM.UsersMaster musr ON musr.UserID = sd.MUserID {midQuery} ORDER BY sd.SAID DESC;";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
            }
        }

        public DataTable getReturnSalesEntry(int Id, int status, int is_deleted)
        {
            if (Id > 0)
            {
                var Query = $@"SELECT srm.SRID,srm.SRVNUM,srm.Sales_Date,srm.Sales_Miti,srm.Return_Date,srm.SalerID,cmi.Dup_cname,cmi.Dup_address,cmi.Dup_contact,IIF(srm.BuyerID = 0, 'CASH A/C', scm.PartyName) AS PartyName,scm.PartyCompany,scm.PartyAddress,scm.PartyContact,srm.TransectionOn,srm.Total,srm.Vat,srm.VatAmt,srm.TotalAmount,srm.Discount,srm.DiscAmount,srm.BillTotal,srm.InWords,srm.Note,IIF(srm.is_Deleted = 0, 'ACTIVE', 'DELETED') AS is_Deleted,srm.UserID,usr.usrname Entered_By,srm.DateCreated,srm.MUserID,musr.usrname Modified_By,srm.ModifiedDate,srm.extraNote,srm.status,srm.paid_amount,srm.return_amount,srm.SAID,srm.SVNUM,srm.previous_balance,srm.sales_bill_amt,srm.advance_given FROM MSM.SalesReturnMaster srm LEFT OUTER JOIN MSM.CustomerMaster scm ON scm.CID = srm.BuyerID LEFT OUTER JOIN MSM.CompanyMasterInfo cmi ON cmi.Dup_cid = srm.SalerID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.userid = srm.userid LEFT OUTER JOIN MSM.UsersMaster musr ON musr.userid = srm.MUserID WHERE srm.SRID = {Id};" +
                            $@"SELECT srd.SRID,srd.SRVNUM,srd.PID,srd.PName,srd.PCode,srd.PBarcode,srd.Quantiy,srd.UnitID,um.Unit,um.UnitCode,srd.PPrice,srd.pDisc,srd.pamount,srd.TotalPrice,srd.Note,srd.UserID,usr.usrname Entered_By,srd.DateCreated,srd.MUserID,musr.usrname Modified_By,srd.ModifiedDate,IIF(srd.is_Deleted = 0, 'ACTIVE', 'DELETED') AS is_Deleted FROM MSM.SalesReturnDetails srd LEFT OUTER JOIN MSM.UnitMaster um ON um.UnitID = srd.UnitID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.UserID = srd.UserID LEFT OUTER JOIN MSM.UsersMaster musr ON musr.UserID = srd.MUserID WHERE srd.SRID = {Id};";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
            }
            else if (status > 0)
            {
                var Query = $@"SELECT srm.SRID,srm.SRVNUM,srm.Sales_Date,srm.Sales_Miti,srm.Return_Date,srm.SalerID,cmi.Dup_cname,cmi.Dup_address,cmi.Dup_contact,IIF(srm.BuyerID = 0, 'CASH A/C', scm.PartyName) AS PartyName,scm.PartyCompany,scm.PartyAddress,scm.PartyContact,srm.TransectionOn,srm.Total,srm.Vat,srm.VatAmt,srm.TotalAmount,srm.Discount,srm.DiscAmount,srm.BillTotal,srm.InWords,srm.Note,IIF(srm.is_Deleted = 0, 'ACTIVE', 'DELETED') AS is_Deleted,srm.UserID,usr.usrname Entered_By,srm.DateCreated,srm.MUserID,musr.usrname Modified_By,srm.ModifiedDate,srm.extraNote,srm.status,srm.paid_amount,srm.return_amount,srm.SAID,srm.SVNUM,srm.previous_balance,srm.sales_bill_amt,srm.advance_given FROM MSM.SalesReturnMaster srm LEFT OUTER JOIN MSM.CustomerMaster scm ON scm.CID = srm.BuyerID LEFT OUTER JOIN MSM.CompanyMasterInfo cmi ON cmi.Dup_cid = srm.SalerID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.userid = srm.userid LEFT OUTER JOIN MSM.UsersMaster musr ON musr.userid = srm.MUserID WHERE srm.STATUS = 1;" +
                              "SELECT srd.SRID,srd.SRVNUM,srd.PID,srd.PName,srd.PCode,srd.PBarcode,srd.Quantiy,srd.UnitID,um.Unit,um.UnitCode,srd.PPrice,srd.pDisc,srd.pamount,srd.TotalPrice,srd.Note,srd.UserID,usr.usrname Entered_By,srd.DateCreated,srd.MUserID,musr.usrname Modified_By,srd.ModifiedDate,IIF(srd.is_Deleted = 0, 'ACTIVE', 'DELETED') AS is_Deleted FROM MSM.SalesReturnDetails srd LEFT OUTER JOIN MSM.UnitMaster um ON um.UnitID = srd.UnitID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.UserID = srd.UserID LEFT OUTER JOIN MSM.UsersMaster musr ON musr.UserID = srd.MUserID WHERE srd.STATUS = 1;";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
            }
            else
            {
                var midQuery = string.Empty;
                if (is_deleted == 1) midQuery = "where is_Deleted <> 1";

                var Query = $@"SELECT srm.SRID,srm.SRVNUM,srm.Sales_Date,srm.Sales_Miti,srm.Return_Date,srm.SalerID,cmi.Dup_cname,cmi.Dup_address,cmi.Dup_contact,IIF(srm.BuyerID = 0, 'CASH A/C', scm.PartyName) AS PartyName,scm.PartyCompany,scm.PartyAddress,scm.PartyContact,srm.TransectionOn,srm.Total,srm.Vat,srm.VatAmt,srm.TotalAmount,srm.Discount,srm.DiscAmount,srm.BillTotal,srm.InWords,srm.Note,IIF(srm.is_Deleted = 0, 'ACTIVE', 'DELETED') AS is_Deleted,srm.UserID,usr.usrname Entered_By,srm.DateCreated,srm.MUserID,musr.usrname Modified_By,srm.ModifiedDate,srm.extraNote,srm.status,srm.paid_amount,srm.return_amount,srm.SAID,srm.SVNUM,srm.previous_balance,srm.sales_bill_amt,srm.advance_given FROM MSM.SalesReturnMaster srm LEFT OUTER JOIN MSM.CustomerMaster scm ON scm.CID = srm.BuyerID LEFT OUTER JOIN MSM.CompanyMasterInfo cmi ON cmi.Dup_cid = srm.SalerID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.userid = srm.userid LEFT OUTER JOIN MSM.UsersMaster musr ON musr.userid = srm.MUserID {midQuery} ORDER BY srm.SRID DESC;" +
                            $@"SELECT srd.SRID,srd.SRVNUM,srd.PID,srd.PName,srd.PCode,srd.PBarcode,srd.Quantiy,srd.UnitID,um.Unit,um.UnitCode,srd.PPrice,srd.pDisc,srd.pamount,srd.TotalPrice,srd.Note,srd.UserID,usr.usrname Entered_By,srd.DateCreated,srd.MUserID,musr.usrname Modified_By,srd.ModifiedDate,IIF(srd.is_Deleted = 0, 'ACTIVE', 'DELETED') AS is_Deleted FROM MSM.SalesReturnDetails srd LEFT OUTER JOIN MSM.UnitMaster um ON um.UnitID = srd.UnitID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.UserID = srd.UserID LEFT OUTER JOIN MSM.UsersMaster musr ON musr.UserID = srd.MUserID {midQuery} ORDER BY srd.SRID DESC;";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
            }
        }

        public DataTable getOrderTicketEntry(int ID, int status, int is_deleted, string type)
        {
            if(type=="print")
            {
                var midQuery = string.Empty;
                if (is_deleted == 1) midQuery = "where is_Deleted <> 1";

                var Query = $@"SELECT OID,om.OVNUM,om.Order_Date,om.Order_Miti,om.Delivery_Date,om.Delivery_Miti,om.SenderID,cmi.Dup_cname,cmi.Dup_address,cmi.Dup_contact,om.BuyerID,scm.PartyName,scm.PartyCompany,scm.PartyAddress,scm.PartyContact,om.Note,om.Est_Time,om.OrderStatus,CASE WHEN om.is_Deleted = '0' THEN 'No' ELSE 'Yes' END AS is_Deleted,om.UserID,usr.usrname Entered_By,om.DateCreated,om.MUserID,musr.usrname Modified_By,om.ModifiedDate FROM MSM.OrderMaster om LEFT OUTER JOIN MSM.CustomerMaster scm ON scm.CID = om.BuyerID LEFT OUTER JOIN MSM.CompanyMasterInfo cmi ON cmi.Dup_cid = om.SenderID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.UserID = om.UserID LEFT OUTER JOIN MSM.UsersMaster musr ON musr.UserID = om.MUserID  {midQuery} ORDER BY om.OID DESC;" +
                            $@"SELECT od.OID,od.OVNUM,od.PID ,od.PName ,od.PCode ,od.PBarcode ,od.Quantiy ,od.UnitID ,um.Unit ,um.UnitCode, od.EST_HrsPerUnit, od.TotalEST_HrsPerUnit ,od.UserID ,usr.usrname Entered_By,od.DateCreated ,od.MUserID,musr.usrname Modified_By,od.ModifiedDate,od.is_Deleted isDeleted from MSM.OrderDetails as od left outer join MSM.UnitMaster um on um.UnitID = od.UnitID  left outer join MSM.UsersMaster usr on usr.userid = od.UserID left outer join MSM.UsersMaster musr on musr.userid = od.MUserID {midQuery} ORDER BY od.OID DESC;";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
            }
            if (status == 1)  // this query gives the output first pending result then processing results so on others.. this can be used many places except main order entry form.
            {
                var Query = string.Empty;
                if(type != string.Empty)
                {
                    Query = $@"SELECT OID,om.OVNUM,om.Order_Date,om.Order_Miti,om.Delivery_Date,om.Delivery_Miti,om.SenderID,cmi.Dup_cname,cmi.Dup_address,cmi.Dup_contact,om.BuyerID,scm.PartyName,scm.PartyCompany,scm.PartyAddress,scm.PartyContact,om.Note,om.Est_Time,om.OrderStatus,CASE WHEN om.is_Deleted = '0' THEN 'No' ELSE 'Yes' END AS is_Deleted,om.UserID,usr.usrname Entered_By,om.DateCreated,om.MUserID,musr.usrname Modified_By,om.ModifiedDate FROM MSM.OrderMaster om LEFT OUTER JOIN MSM.CustomerMaster scm ON scm.CID = om.BuyerID LEFT OUTER JOIN MSM.CompanyMasterInfo cmi ON cmi.Dup_cid = om.SenderID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.UserID = om.UserID LEFT OUTER JOIN MSM.UsersMaster musr ON musr.UserID = om.MUserID WHERE om.OrderStatus = '{type}' ORDER BY OM.OID DESC;";
                }
                else
                {
                    Query = $@"SELECT OID,om.OVNUM,om.Order_Date,om.Order_Miti,om.Delivery_Date,om.Delivery_Miti,om.SenderID,cmi.Dup_cname,cmi.Dup_address,cmi.Dup_contact,om.BuyerID,scm.PartyName,scm.PartyCompany,scm.PartyAddress,scm.PartyContact,om.Note,om.Est_Time,om.OrderStatus,CASE WHEN om.is_Deleted = '0' THEN 'No' ELSE 'Yes' END AS is_Deleted,om.UserID,usr.usrname Entered_By,om.DateCreated,om.MUserID,musr.usrname Modified_By,om.ModifiedDate FROM MSM.OrderMaster om LEFT OUTER JOIN MSM.CustomerMaster scm ON scm.CID = om.BuyerID LEFT OUTER JOIN MSM.CompanyMasterInfo cmi ON cmi.Dup_cid = om.SenderID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.UserID = om.UserID LEFT OUTER JOIN MSM.UsersMaster musr ON musr.UserID = om.MUserID ORDER BY CASE OM.OrderStatus WHEN 'Pending' THEN 1 WHEN 'InProcess' THEN  2 WHEN 'Processing' THEN 3 ELSE 4 END,OM.OID DESC;
                               SELECT od.OID,od.OVNUM,od.PID ,od.PName ,od.PCode ,od.PBarcode ,od.Quantiy ,od.UnitID ,um.Unit ,um.UnitCode, od.EST_HrsPerUnit, od.TotalEST_HrsPerUnit ,od.UserID ,usr.usrname Entered_By,od.DateCreated ,od.MUserID,musr.usrname Modified_By,od.ModifiedDate,od.is_Deleted isDeleted from MSM.OrderDetails as od left outer join MSM.UnitMaster um on um.UnitID = od.UnitID  left outer join MSM.UsersMaster usr on usr.userid = od.UserID left outer join MSM.UsersMaster musr on musr.userid = od.MUserID  ORDER BY od.OID DESC;";
                }               
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
            }
            else if (ID > 0)
            {
                var Query = $@"SELECT OID,om.OVNUM,om.Order_Date,om.Order_Miti,om.Delivery_Date,om.Delivery_Miti,om.SenderID,cmi.Dup_cname,cmi.Dup_address,cmi.Dup_contact,om.BuyerID,scm.PartyName,scm.PartyCompany,scm.PartyAddress,scm.PartyContact,om.Note,om.Est_Time,om.OrderStatus,CASE WHEN om.is_Deleted = '0' THEN 'No' ELSE 'Yes' END AS is_Deleted,om.UserID,usr.usrname Entered_By,om.DateCreated,om.MUserID,musr.usrname Modified_By,om.ModifiedDate FROM MSM.OrderMaster om LEFT OUTER JOIN MSM.CustomerMaster scm ON scm.CID = om.BuyerID LEFT OUTER JOIN MSM.CompanyMasterInfo cmi ON cmi.Dup_cid = om.SenderID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.UserID = om.UserID LEFT OUTER JOIN MSM.UsersMaster musr ON musr.UserID = om.MUserID where om.OID = {ID};
                               SELECT od.OID,od.OVNUM,od.PID ,od.PName ,od.PCode ,od.PBarcode ,od.Quantiy ,od.UnitID ,um.Unit ,um.UnitCode, od.EST_HrsPerUnit, od.TotalEST_HrsPerUnit ,od.UserID ,usr.usrname Entered_By,od.DateCreated ,od.MUserID,musr.usrname Modified_By,od.ModifiedDate,od.is_Deleted isDeleted from MSM.OrderDetails as od left outer join MSM.UnitMaster um on um.UnitID = od.UnitID  left outer join MSM.UsersMaster usr on usr.userid = od.UserID left outer join MSM.UsersMaster musr on musr.userid = od.MUserID where od.OID = {ID};";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
            }
            else if (ID == 0)
            {
                var Query = $@"SELECT OID,om.OVNUM,om.Order_Date,om.Order_Miti,om.Delivery_Date,om.Delivery_Miti,om.SenderID,cmi.Dup_cname,cmi.Dup_address,cmi.Dup_contact,om.BuyerID,scm.PartyName,scm.PartyCompany,scm.PartyAddress,scm.PartyContact,om.Note,om.Est_Time,om.OrderStatus,CASE WHEN om.is_Deleted = '0' THEN 'No' ELSE 'Yes' END AS is_Deleted,om.UserID,usr.usrname Entered_By,om.DateCreated,om.MUserID,musr.usrname Modified_By,om.ModifiedDate FROM MSM.OrderMaster om LEFT OUTER JOIN MSM.CustomerMaster scm ON scm.CID = om.BuyerID LEFT OUTER JOIN MSM.CompanyMasterInfo cmi ON cmi.Dup_cid = om.SenderID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.UserID = om.UserID LEFT OUTER JOIN MSM.UsersMaster musr ON musr.UserID = om.MUserID WHERE om.OrderStatus = '{type}' ORDER BY OM.OID DESC;
                               SELECT od.OID,od.OVNUM,od.PID ,od.PName ,od.PCode ,od.PBarcode ,od.Quantiy ,od.UnitID ,um.Unit ,um.UnitCode, od.EST_HrsPerUnit, od.TotalEST_HrsPerUnit ,od.UserID ,usr.usrname Entered_By,od.DateCreated ,od.MUserID,musr.usrname Modified_By,od.ModifiedDate,od.is_Deleted isDeleted from MSM.OrderDetails as od left outer join MSM.UnitMaster um on um.UnitID = od.UnitID  left outer join MSM.UsersMaster usr on usr.userid = od.UserID left outer join MSM.UsersMaster musr on musr.userid = od.MUserID  ORDER BY od.OID DESC;";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
            }
            else
            {
                var midQuery = string.Empty;
                if (is_deleted == 1) midQuery = "where is_Deleted <> 1";

                var Query = $@"SELECT OID,om.OVNUM,om.Order_Date,om.Order_Miti,om.Delivery_Date,om.Delivery_Miti,om.SenderID,cmi.Dup_cname,cmi.Dup_address,cmi.Dup_contact,om.BuyerID,scm.PartyName,scm.PartyCompany,scm.PartyAddress,scm.PartyContact,om.Note,om.Est_Time,om.OrderStatus,CASE WHEN om.is_Deleted = '0' THEN 'No' ELSE 'Yes' END AS is_Deleted,om.UserID,usr.usrname Entered_By,om.DateCreated,om.MUserID,musr.usrname Modified_By,om.ModifiedDate FROM MSM.OrderMaster om LEFT OUTER JOIN MSM.CustomerMaster scm ON scm.CID = om.BuyerID LEFT OUTER JOIN MSM.CompanyMasterInfo cmi ON cmi.Dup_cid = om.SenderID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.UserID = om.UserID LEFT OUTER JOIN MSM.UsersMaster musr ON musr.UserID = om.MUserID  {midQuery} ORDER BY om.OID DESC;" +
                            $@"SELECT od.OID,od.OVNUM,od.PID ,od.PName ,od.PCode ,od.PBarcode ,od.Quantiy ,od.UnitID ,um.Unit ,um.UnitCode, od.EST_HrsPerUnit, od.TotalEST_HrsPerUnit ,od.UserID ,usr.usrname Entered_By,od.DateCreated ,od.MUserID,musr.usrname Modified_By,od.ModifiedDate,od.is_Deleted isDeleted from MSM.OrderDetails as od left outer join MSM.UnitMaster um on um.UnitID = od.UnitID  left outer join MSM.UsersMaster usr on usr.userid = od.UserID left outer join MSM.UsersMaster musr on musr.userid = od.MUserID {midQuery} ORDER BY od.OID DESC;";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
            }
        }

        public DataTable getIssueCardEntry(int ID, int status, int is_deleted, string type)
        {
            if (ID > 0)
            {
                var Query = $@"SELECT ICM.ICID,ICM.ICVNUM,ICM.OID,ICM.OVNUM,ICM.Issue_Date,ICM.Issue_Miti,ICM.Delivery_Date,ICM.Delivery_Miti,ICM.SenderID,cmi.Dup_cname,cmi.Dup_address,cmi.Dup_contact,ICM.BuyerID,scm.PartyName,scm.PartyCompany,scm.PartyAddress,scm.PartyContact,ICM.AssigneeId,UM.usrname  AS Assignee_Name,UM.RoleID,ICM.Note,ICM.Est_Time,ICM.OrderStatus,CASE WHEN ICM.is_Deleted = '0' THEN 'No' ELSE 'Yes' END AS is_Deleted,ICM.UserID,usr.usrname Entered_By,ICM.DateCreated,ICM.MUserID,musr.usrname Modified_By,ICM.ModifiedDate FROM MSM.IssueCardMaster ICM LEFT OUTER JOIN MSM.CustomerMaster scm ON scm.CID = ICM.BuyerID LEFT OUTER JOIN MSM.CompanyMasterInfo cmi ON cmi.Dup_cid = ICM.SenderID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.UserID = ICM.UserID LEFT OUTER JOIN MSM.UsersMaster musr ON musr.UserID = ICM.MUserID LEFT OUTER JOIN MSM.UsersMaster um ON UM.userid = ICM.AssigneeId WHERE ICM.ICID = {ID};
                               SELECT ICD.ICID,ICD.ICVNUM,ICD.PID,ICD.PName,ICD.PCode,ICD.PBarcode,ICD.Quantiy,ICD.UnitID,um.Unit,um.UnitCode,ICD.UserID,usr.usrname Entered_By,ICD.DateCreated,ICD.MUserID,musr.usrname Modified_By,ICD.ModifiedDate ,ICD.is_Deleted isDeleted FROM MSM.IssueCardDetails AS ICD LEFT OUTER JOIN MSM.UnitMaster um ON um.UnitID = ICD.UnitID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.userid = ICD.UserID LEFT OUTER JOIN MSM.UsersMaster musr ON musr.userid = ICD.MUserID WHERE ICD.ICID = {ID};";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
            }
            else if (ID == 0)
            {
                var Query = string.Empty;
                if(type != string.Empty)
                {
                    Query = $@"SELECT ICM.ICID,ICM.ICVNUM,ICM.OID,ICM.OVNUM,ICM.Issue_Date,ICM.Issue_Miti,ICM.Delivery_Date,ICM.Delivery_Miti,ICM.SenderID,cmi.Dup_cname,cmi.Dup_address,cmi.Dup_contact,ICM.BuyerID,scm.PartyName,scm.PartyCompany,scm.PartyAddress,scm.PartyContact,ICM.AssigneeId,UM.usrname  AS Assignee_Name,UM.RoleID,ICM.Note,ICM.Est_Time,ICM.OrderStatus,CASE WHEN ICM.is_Deleted = '0' THEN 'No' ELSE 'Yes' END AS is_Deleted,ICM.UserID,usr.usrname Entered_By,ICM.DateCreated,ICM.MUserID,musr.usrname Modified_By,ICM.ModifiedDate FROM MSM.IssueCardMaster ICM LEFT OUTER JOIN MSM.CustomerMaster scm ON scm.CID = ICM.BuyerID LEFT OUTER JOIN MSM.CompanyMasterInfo cmi ON cmi.Dup_cid = ICM.SenderID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.UserID = ICM.UserID LEFT OUTER JOIN MSM.UsersMaster musr ON musr.UserID = ICM.MUserID LEFT OUTER JOIN MSM.UsersMaster um ON UM.userid = ICM.AssigneeId where ICM.OrderStatus = '{type}' ORDER BY ICM.ICID DESC;
                               SELECT ICD.ICID,ICD.ICVNUM,ICD.PID,ICD.PName,ICD.PCode,ICD.PBarcode,ICD.Quantiy,ICD.UnitID,um.Unit,um.UnitCode,ICD.UserID,usr.usrname Entered_By,ICD.DateCreated,ICD.MUserID,musr.usrname Modified_By,ICD.ModifiedDate ,ICD.is_Deleted isDeleted FROM MSM.IssueCardDetails AS ICD LEFT OUTER JOIN MSM.UnitMaster um ON um.UnitID = ICD.UnitID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.userid = ICD.UserID LEFT OUTER JOIN MSM.UsersMaster musr ON musr.userid = ICD.MUserID  ORDER BY ICD.ICID DESC;";
                }
                else
                {
                    Query = $@"SELECT ICM.ICID,ICM.ICVNUM,ICM.OID,ICM.OVNUM,ICM.Issue_Date,ICM.Issue_Miti,ICM.Delivery_Date,ICM.Delivery_Miti,ICM.SenderID,cmi.Dup_cname,cmi.Dup_address,cmi.Dup_contact,ICM.BuyerID,scm.PartyName,scm.PartyCompany,scm.PartyAddress,scm.PartyContact,ICM.AssigneeId,UM.usrname  AS Assignee_Name,UM.RoleID,ICM.Note,ICM.Est_Time,ICM.OrderStatus,CASE WHEN ICM.is_Deleted = '0' THEN 'No' ELSE 'Yes' END AS is_Deleted,ICM.UserID,usr.usrname Entered_By,ICM.DateCreated,ICM.MUserID,musr.usrname Modified_By,ICM.ModifiedDate FROM MSM.IssueCardMaster ICM LEFT OUTER JOIN MSM.CustomerMaster scm ON scm.CID = ICM.BuyerID LEFT OUTER JOIN MSM.CompanyMasterInfo cmi ON cmi.Dup_cid = ICM.SenderID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.UserID = ICM.UserID LEFT OUTER JOIN MSM.UsersMaster musr ON musr.UserID = ICM.MUserID LEFT OUTER JOIN MSM.UsersMaster um ON UM.userid = ICM.AssigneeId ORDER BY ICM.ICID DESC;
                               SELECT ICD.ICID,ICD.ICVNUM,ICD.PID,ICD.PName,ICD.PCode,ICD.PBarcode,ICD.Quantiy,ICD.UnitID,um.Unit,um.UnitCode,ICD.UserID,usr.usrname Entered_By,ICD.DateCreated,ICD.MUserID,musr.usrname Modified_By,ICD.ModifiedDate ,ICD.is_Deleted isDeleted FROM MSM.IssueCardDetails AS ICD LEFT OUTER JOIN MSM.UnitMaster um ON um.UnitID = ICD.UnitID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.userid = ICD.UserID LEFT OUTER JOIN MSM.UsersMaster musr ON musr.userid = ICD.MUserID  ORDER BY ICD.ICID DESC;";
                }
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
            }
            else
            {
                var midQuery = string.Empty;
                if (is_deleted == 1) midQuery = "WHERE is_Deleted <> 1";

                var Query = $@"ICM.ICID,ICM.ICVNUM,ICM.OID,ICM.OVNUM,ICM.Issue_Date,ICM.Issue_Miti,ICM.Delivery_Date,ICM.Delivery_Miti,ICM.SenderID,cmi.Dup_cname,cmi.Dup_address,cmi.Dup_contact,ICM.BuyerID,scm.PartyName,scm.PartyCompany,scm.PartyAddress,scm.PartyContact,ICM.AssigneeId,UM.usrname  AS Assignee_Name,UM.RoleID,ICM.Note,ICM.Est_Time,ICM.OrderStatus,CASE WHEN ICM.is_Deleted = '0' THEN 'No' ELSE 'Yes' END AS is_Deleted,ICM.UserID,usr.usrname Entered_By,ICM.DateCreated,ICM.MUserID,musr.usrname Modified_By,ICM.ModifiedDate FROM MSM.IssueCardMaster ICM LEFT OUTER JOIN MSM.CustomerMaster scm ON scm.CID = ICM.BuyerID LEFT OUTER JOIN MSM.CompanyMasterInfo cmi ON cmi.Dup_cid = ICM.SenderID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.UserID = ICM.UserID LEFT OUTER JOIN MSM.UsersMaster musr ON musr.UserID = ICM.MUserID LEFT OUTER JOIN MSM.UsersMaster um ON UM.userid = ICM.AssigneeId  {midQuery}  ORDER BY ICM.ICID DESC;" +
                            $@"SELECT ICD.ICID,ICD.ICVNUM,ICD.PID,ICD.PName,ICD.PCode,ICD.PBarcode,ICD.Quantiy,ICD.UnitID,um.Unit,um.UnitCode,ICD.UserID,usr.usrname Entered_By,ICD.DateCreated,ICD.MUserID,musr.usrname Modified_By,ICD.ModifiedDate ,ICD.is_Deleted isDeleted FROM MSM.IssueCardDetails AS ICD LEFT OUTER JOIN MSM.UnitMaster um ON um.UnitID = ICD.UnitID LEFT OUTER JOIN MSM.UsersMaster usr ON usr.userid = ICD.UserID LEFT OUTER JOIN MSM.UsersMaster musr ON musr.userid = ICD.MUserID {midQuery} ORDER BY ICD.ICID DESC;";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
            }
        }

        public DataTable GetUser(int ID)
        {
            if (ID > 0)
            {
                var Query = $@"SELECT [userid],[usrname],[loginid],[password],[dept],UM.[RoleID],ur.[RoleName],[ActiveStatus] FROM [MSM].[UsersMaster] UM left outer join MSM.UsersRole ur on ur.RoleId = UM.RoleID where [RoleId] = {ID};";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];

            }
            else
            {
                var Query = @"SELECT [userid],[usrname],[loginid],[password],[dept],UM.[RoleID],ur.[RoleName],[ActiveStatus] FROM [MSM].[UsersMaster] UM left outer join MSM.UsersRole ur on ur.RoleId = UM.RoleID where UM.userid <> 1;";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
            }
        }

        public DataTable GetUnit(int ID ,int status)
        {
            if (status == 1)
            {
                var Query = @"SELECT [UnitID],[Unit],[UnitCode],[ActiveStatus],[UserID],[DateCreated],[MUserID],[ModifiedDate] FROM [MSM].[UnitMaster]  where unitID <> 0 ORDER BY UnitID ;";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];   
            }
            else
            {
                if (ID > 0)
                {
                    var Query = $@"SELECT [UnitID],[Unit],[UnitCode],[ActiveStatus],[UserID],[DateCreated],[MUserID],[ModifiedDate] FROM [MSM].[UnitMaster] WHERE UnitID = {ID};";
                    return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
                }
                else
                {
                    var Query = @"SELECT [UnitID],[Unit],[UnitCode],[ActiveStatus],[UserID],[DateCreated],[MUserID],[ModifiedDate] FROM [MSM].[UnitMaster] WHERE UnitID > 5;";
                    return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
                }
            }  
        }
        
        public DataTable Get_RefrenceNumber(string PVNUM)
        {
            if (PVNUM != "")
            {
                var Query = $@"SELECT PVNUM,Purchase_OrderNo,PO_ReferenceNo from msm.PurchaseMaster WHERE Purchase_OrderNo =  '{PVNUM}' AND is_Deleted <> 1 ORDER BY PVNUM;";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];

            }
            else
            {
                var Query = @"SELECT PVNUM,Purchase_OrderNo,PO_ReferenceNo FROM msm.PurchaseMaster ORDER BY PVNUM";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionMain, CommandType.Text, Query).Tables[0];
            }
        }
        public DataTable Get_Country_State(int ID)
        {
            if(ID > 0)
            {
                var Query = $@"SELECT CbId ID,StateName StateName,Country CountryName FROM [master.ComboBoxVal]  where CbId = {ID};";
                return Execute.ExecuteDataSetOnLocalMaster(Connection.Connection.ConnectionLocalMaster, CommandType.Text, Query).Tables[0];
                
            }
            else
            {
                var Query = @"SELECT CbId ID,StateName StateName,Country CountryName FROM [master.ComboBoxVal] ORDER BY CbId;";
                return Execute.ExecuteDataSetOnLocalMaster(Connection.Connection.ConnectionLocalMaster, CommandType.Text, Query).Tables[0];
            }
            
        }

        public DataTable Get_GoodsReceivedList(string PVNUM)
        {
            try
            {
                var Query = $@"SELECT pd.PVNUM, pd.PName, pd.Purchase_OrderNo, FORMAT(pd.Quantiy,'N') AS Quantiy, (SELECT DISTINCT FORMAT(Quantiy ,'N') as orderQuantity FROM msm.PurchaseOrderDetails pp WHERE pp.PID = pd.pid ) as OrderQuantity, FORMAT((SELECT SUM(Quantiy) FROM msm.PurchaseDetails ppd WHERE ppd.Purchase_OrderNo = pd.Purchase_OrderNo  AND is_Deleted <> 1),'N') AS totalReceived, FORMAT((SELECT goods_quantity FROM msm.PurchaseOrderMaster pom WHERE pom.POVNUM = pd.Purchase_OrderNo AND is_Deleted <> 1), 'N') AS totalQuantity FROM msm.PurchaseDetails pd WHERE pd.Purchase_OrderNo = '{PVNUM}' AND pd.is_Deleted <> 1 ORDER BY PVNUM;";
                return Execute.ExecuteDataSetOnMain(Connection.Connection.ConnectionLocalMaster, CommandType.Text, Query).Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }
    }
}
