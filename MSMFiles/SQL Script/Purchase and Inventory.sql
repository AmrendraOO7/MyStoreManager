IF OBJECT_ID ('MSM.PurchaseMaster') IS NULL BEGIN 
CREATE TABLE MSM.PurchaseMaster(
[PEID] [int] NOT NULL,
[PVNUM] [varchar](20) NOT NULL,
[Purchase_Date] [date] NULL,
[Purchase_Miti] [varchar](10) NULL,
[ReceiverID] [int] NULL,
[SenderID] [int] NULL,
[TransectionOn] [varchar](10),
[Total][money],[Vat][decimal](18,4),
[VatAmt][money],[TotalAmount][money],
[Discount][decimal](18,4),
[DiscAmount][money],
[BillTotal][money],
[InWords][Varchar](MAX),
[PO_Bill_Status] [bit] NULL,
[UserID] [int] NOT NULL,
[DateCreated] [datetime] NOT NULL,
[MUserID] [int] NULL,
[ModifiedDate] [datetime] NULL,
PRIMARY KEY (PEID),
UNIQUE (PVNUM),
FOREIGN KEY (ReceiverID) REFERENCES MSM.CompanyMasterInfo (Dup_cid),
FOREIGN KEY (SenderID) REFERENCES MSM.CustomerMaster (CID),
FOREIGN KEY (UserID) REFERENCES MSM.UsersMaster (userid),
FOREIGN KEY (MUserID) REFERENCES MSM.UsersMaster (userid)) END;

IF OBJECT_ID ('MSM.PurchaseDetails') IS NULL BEGIN 
CREATE TABLE MSM.PurchaseDetails(
PEID int NOT NULL,
PVNUM varchar(20) NOT NULL,
PID INT NOT NULL,
PName VARCHAR(MAX) NOT NULL,
PCode nvarchar(10),
PBarcode nvarchar(30),
Quantiy Decimal(18,6) null,
UnitID int null,
PPrice money,
TotalPrice money,
PNote varchar(MAX),
UserID int NOT NULL,
DateCreated datetime NOT NULL,
MUserID int null,
ModifiedDate datetime null,
FOREIGN KEY (PEID) REFERENCES MSM.PurchaseMaster (PEID),
FOREIGN KEY (PVNUM) REFERENCES MSM.PurchaseMaster (PVNUM),
FOREIGN KEY (PID) REFERENCES MSM.ProductMaster (PID),
FOREIGN KEY (UserID) REFERENCES MSM.UsersMaster (userid),
FOREIGN KEY (MUserID) REFERENCES MSM.UsersMaster (userid),
FOREIGN KEY (UnitID) REFERENCES [MSM].[UnitMaster] (UnitID))END;

IF OBJECT_ID ('MSM.ProductInventory') IS NULL BEGIN 
CREATE TABLE MSM.ProductInventory(
InventID int,
prodID int,
Quantity Decimal(18,6) null,
UnitID int,
AltUnitID int null,
ActiveStatus bit null,
FOREIGN KEY (prodID) REFERENCES MSM.ProductMaster (PID),
FOREIGN KEY (UnitID) REFERENCES [MSM].[UnitMaster] (UnitID)
) END;