

IF OBJECT_ID ('MSM.PurchaseOrderMaster') IS NULL BEGIN 
CREATE TABLE MSM.PurchaseOrderMaster(
 POID INT NOT NULL
,POVNUM VARCHAR(20) NOT NULL
,Order_Date DATE
,Order_Miti VARCHAR(10)
,ReceiverID INT
,SenderID INT
,PPriceTotal money
,MrpTotal money
,MarginTotal money
,DiscountTotal decimal(18,3)
,PO_Bill_Status bit
,TransectionOn varchar(10)
,UserID int NOT NULL
,DateCreated datetime NOT NULL
,MUserID int null
,ModifiedDate datetime null
,PRIMARY KEY (POID)
,UNIQUE (POVNUM)
,FOREIGN KEY (ReceiverID) REFERENCES MSM.CompanyMasterInfo (Dup_cid) 
,FOREIGN KEY (SenderID) REFERENCES MSM.CustomerMaster (CID)
,FOREIGN KEY (UserID) REFERENCES MSM.UsersMaster (userid)
,FOREIGN KEY (MUserID) REFERENCES MSM.UsersMaster (userid)
) END;

IF OBJECT_ID ('MSM.PurchaseOrderDetails') IS NULL BEGIN CREATE TABLE MSM.PurchaseOrderDetails(
POID int NOT NULL
,POVNUM varchar(20) NOT NULL
,PID INT NOT NULL
,PName VARCHAR(MAX) NOT NULL
,PCode nvarchar(10)
,PBarcode nvarchar(30)
,UnitQnty Decimal(18,6) null
,UnitID int null
,AltUnitQnty Decimal(18,6) null
,AltUnitId int null
,PPrice money
,TotalPPrice money
,MRP money
,totalMRP money
,Offer nvarchar(10)
,GodownID INT
,MFP_Date VARCHAR(10)
,EXP_Date VARCHAR(10)
,ProductCategory NVARCHAR(100)
,PNote varchar(MAX)
,UserID int NOT NULL
,DateCreated datetime NOT NULL
,MUserID int null
,ModifiedDate datetime null
,FOREIGN KEY (POID) REFERENCES MSM.PurchaseOrderMaster (POID)
,FOREIGN KEY (POVNUM) REFERENCES MSM.PurchaseOrderMaster (POVNUM)
,FOREIGN KEY (UserID) REFERENCES MSM.UsersMaster (userid)
,FOREIGN KEY (MUserID) REFERENCES MSM.UsersMaster (userid)
,FOREIGN KEY (UnitID) REFERENCES [MSM].[UnitMaster] (UnitID)
,FOREIGN KEY (AltUnitID) REFERENCES [MSM].[UnitMaster] (UnitID)
,FOREIGN KEY (GodownID) REFERENCES [MSM].[StoreGodown] (GodID)
)END;