--IF OBJECT_ID ('MSM.FiscalYear') IS NULL BEGIN CREATE TABLE MSM.FiscalYear(YearID INT NOT NULL,YearDesc VARCHAR(10) NOT NULL,PRIMARY KEY (YearID)) END;

--IF OBJECT_ID ('MSM.Configuration') IS NULL BEGIN CREATE TABLE MSM.Configuration(CID INT NOT NULL,YearID INT NOT NULL,Current_Year VARCHAR(10),IsAdmin BIT,ColorID INT,Background VARCHAR(MAX),PRIMARY KEY (CID),FOREIGN KEY ([YearID]) REFERENCES [MSM].[FiscalYear] ([YearID]))END;




--IF OBJECT_ID ('MSM.CompanyMasterInfo') IS NULL BEGIN CREATE TABLE [MSM].[CompanyMasterInfo] ([Dup_cid] [int] NOT NULL,[Dup_cname] [varchar](100) NULL,[Dup_regno] [varchar](30) NULL,[Dup_address] [varchar](200) NULL,[Dup_contact] [varchar](50) NULL,[Dup_email] [varchar](100) NULL,[Dup_city] [varchar](100) NULL,[Dup_country] [varchar](20) NULL,[Dup_catalog] [varchar](50) NOT NULL,[Dup_Location] [varchar](100) NULL,[Dup_StateName] [varchar](100) NULL,[Dup_UserID] int,[Dup_DateCreated] datetime,[Dup_MUserID] int,[Dup_ModifiedDate] datetime) END;
--IF OBJECT_ID ('[MSM].[Configuration]') IS NOT NULL BEGIN EXECUTE ('INSERT INTO [MSM].[Configuration]([CID],[YearID],[Current_Year],[IsAdmin],[ColorID],[Background]) VALUES (1,2,''78/79'',''0'',57,''Indigo'')')END;

--IF OBJECT_ID ('[MSM].[UsersMaster]') IS NOT NULL BEGIN EXECUTE(' ALTER TABLE [MSM].[UsersMaster] DROP COLUMN [status];') END;

--IF OBJECT_ID ('[MSM].[UsersMaster]') IS NOT NULL BEGIN EXECUTE(' ALTER TABLE [MSM].[UsersMaster] ADD [RoleID] int;') END;

--IF OBJECT_ID ('MSM.CompanyMasterInfo') IS NULL BEGIN CREATE TABLE [MSM].[CompanyMasterInfo] ([Dup_cid] int NOT NULL,[Dup_cname] [varchar](100) NULL,[Dup_regno] [varchar](30) NULL,[Dup_address] [varchar](200) NULL,[Dup_contact] [varchar](50) NULL,[Dup_email] [varchar](100) NULL,[Dup_city] [varchar](100) NULL,[Dup_country] [varchar](20) NULL,[Dup_catalog] [varchar](50) NOT NULL,[Dup_Location] [varchar](100) NULL,[Dup_StateName] [varchar](100) NULL,[Dup_UserID] int,[Dup_DateCreated] datetime,[Dup_MUserID] int,[Dup_ModifiedDate] datetime,PRIMARY KEY (Dup_cid)) END;


--IF OBJECT_ID ('MSM.PurchaseOrderMaster') IS NULL BEGIN CREATE TABLE MSM.PurchaseOrderMaster(POID INT NOT NULL,POVNUM VARCHAR(20) NOT NULL,Order_Date DATE,Order_Miti VARCHAR(10),ReceiverID INT,SenderID INT,PO_Bill_Status bit,UserID int NOT NULL,DateCreated datetime NOT NULL,MUserID int null,ModifiedDate datetime null,PRIMARY KEY (POID),UNIQUE (POVNUM),FOREIGN KEY (ReceiverID) REFERENCES MSM.CompanyMasterInfo (Dup_cid) ,FOREIGN KEY (SenderID) REFERENCES MSM.CustomerMaster (CID),FOREIGN KEY (UserID) REFERENCES MSM.UsersMaster (userid),FOREIGN KEY (MUserID) REFERENCES MSM.UsersMaster (userid)) END;
--IF OBJECT_ID ('MSM.PurchaseOrderDetails') IS NULL BEGIN CREATE TABLE MSM.PurchaseOrderDetails(POID int NOT NULL,POVNUM varchar(20) NOT NULL,PID INT NOT NULL,PName VARCHAR(MAX) NOT NULL,PCode nvarchar(10),PBarcode nvarchar(30),UnitQnty Decimal(18,6) null,UnitID int null,AltUnitQnty Decimal(18,6) null,AltUnitId int null,PPrice money,MRP money,Offer nvarchar(10),GodownID INT,MFP_Date VARCHAR(10),EXP_Date VARCHAR(10),ProductCategory NVARCHAR(100),PNote varchar(MAX),UserID int NOT NULL,DateCreated datetime NOT NULL,MUserID int null,ModifiedDate datetime null,FOREIGN KEY (POID) REFERENCES MSM.PurchaseOrderMaster (POID),FOREIGN KEY (POVNUM) REFERENCES MSM.PurchaseOrderMaster (POVNUM),FOREIGN KEY (UserID) REFERENCES MSM.UsersMaster (userid),FOREIGN KEY (MUserID) REFERENCES MSM.UsersMaster (userid),FOREIGN KEY (UnitID) REFERENCES [MSM].[UnitMaster] (UnitID),FOREIGN KEY (AltUnitID) REFERENCES [MSM].[UnitMaster] (UnitID),FOREIGN KEY (GodownID) REFERENCES [MSM].[StoreGodown] (GodID))END;

IF OBJECT_ID ('MSM.Configuration') IS NOT NULL BEGIN ALTER TABLE MSM.Configuration ADD VAT decimal(18,4) END;

IF OBJECT_ID ('MSM.Configuration') IS NOT NULL BEGIN ALTER TABLE MSM.Configuration ADD Discount decimal(18,4) END;

--IF OBJECT_ID('[MSM].[Configuration]') IS NOT NULL BEGIN EXECUTE ('UPDATE MSM.Configuration SET VAT = 0, Discount = 0') END;

--------------------------------------------------------------------------------VIEWS--------------------------------------------------------------------------------------
IF OBJECT_ID('[MSM].[PurchaseOrder]') IS NOT NULL BEGIN EXECUTE('DROP VIEW [MSM].[PurchaseOrder]') END;
IF OBJECT_ID('[MSM].[PurchaseOrder]') IS NULL BEGIN EXECUTE('CREATE VIEW [MSM].[PurchaseOrder] AS SELECT pom.POID ,pom.POVNUM ,pom.Order_Date Purchase_Order_Date,pom.Order_Miti Purchase_Order_Miti,pom.ReceiverID Purchase_Order_Reciver_ID,musrr.usrname Purchase_Order_Creator_Name,cmi.Dup_cname Purchase_Order_Reciver_Company,cmi.Dup_address Purchase_Order_Reciver_Address,cmi.Dup_contact Purchase_Order_Reciver_Contact,pom.SenderID Purchase_Order_Sender_ID,scm.PartyName Purchase_Order_Sender_Name,scm.PartyCompany Purchase_Order_Sender_Company,scm.PartyAddress Purchase_Order_Sender_Address,scm.PartyContact Purchase_Order_Sender_Contact,pom.PO_Bill_Status Purchase_Order_Sender_Status,pom.UserID Purchase_Order_Creater_ID,musrr.usrname Purchase_Order_Creator,pom.DateCreated Purchase_Order_Created_Date,pom.MUserID Purchase_Order_Modifier_ID,mmusr.usrname Purchase_Order_Modifier,pom.ModifiedDate Purchase_Order_Modifier_Date,pod.POID Purchase_Order_ID_Details,pod.POVNUM Purchase_Order_Voucher_Number_Details,pod.PID Details_product_ID,pod.PName Details_product,pod.PCode Details_product_Code,pod.PBarcode Details_product_BarCode,pod.UnitQnty Details_product_Quantity,pod.UnitID Details_product_UnitID,um.Unit Details_product_Unit,um.UnitCode Details_product_Unit_Code,pod.AltUnitQnty Details_product_AltQuantity,pod.AltUnitId Details_product_AltUnitID,aum.Unit Details_product_AltUnit,aum.UnitCode Details_product_Unit_UnitCode,pod.PPrice Details_product_Purchase_Price,pod.MRP Details_product_MRP,pod.Offer Details_product_Discount,pod.GodownID Details_product_GodownID,sg.GodName Details_product_Godown_Name,sg.GodCode Details_product_Godown_Code,sg.GodAddress Details_product_Godown_Address,pod.MFP_Date Details_product_Manufacturing_Date,pod.EXP_Date Details_product_Expiry_Date,pod.ProductCategory Details_product_Category,pod.PNote Details_product_Note,pod.UserID ,usr.usrname Details_User,pod.DateCreated ,pod.MUserID,musr.usrname Details_Modified_User,pod.ModifiedDate FROM MSM.PurchaseOrderMaster as pom left outer join MSM.PurchaseOrderDetails as pod on pod.POID = pom.POID left outer join MSM.CompanyMasterInfo cmi on cmi.Dup_cid = pom.ReceiverID left outer join MSM.CustomerMaster scm on scm.CID = pom.SenderID left outer join MSM.UsersMaster musrr on musrr.userid = pom.UserID left outer join MSM.UsersMaster mmusr on mmusr.userid = pom.MUserID left outer join MSM.ProductMaster pm on pm.PID = pod.PID left outer join MSM.UnitMaster um on um.UnitID = pod.UnitID left outer join MSM.UnitMaster aum on aum.UnitID = pod.AltUnitId left outer join MSM.StoreGodown sg on sg.GodID = pod.GodownID left outer join MSM.UsersMaster usr on usr.userid = pod.UserID left outer join MSM.UsersMaster musr on musr.userid = pod.MUserID WHERE pom.[POID] = pod.POID and pom.[POVNUM] =pod.POVNUM')END;



--IF COL_LENGTH('AMS.CompanyInfo', 'PrintDesc') IS NULL BEGIN
--	ALTER TABLE AMS.CompanyInfo
--	ADD PrintDesc NVARCHAR(200) NULL;
--END;

--IF COL_LENGTH('AMS.CompanyInfo', 'IsSyncOnline') IS NULL BEGIN
--	ALTER TABLE AMS.CompanyInfo
--	ADD IsSyncOnline BIT NULL;
--END;

