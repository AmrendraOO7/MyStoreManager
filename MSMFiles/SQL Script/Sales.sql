IF OBJECT_ID('MSM.SalesMaster') IS NULL
BEGIN
	CREATE TABLE MSM.SalesMaster (
		SAID INT NOT NULL
	   ,SVNUM VARCHAR(20) NOT NULL
	   ,Sales_Date DATE NULL
	   ,Sales_Miti VARCHAR(10) NULL
	   ,SalerID INT NULL
	   ,BuyerID INT NULL
	   ,TransectionOn VARCHAR(10)
	   ,Total MONEY
	   ,Vat DECIMAL(18, 4)
	   ,VatAmt MONEY
	   ,TotalAmount MONEY
	   ,Discount DECIMAL(18, 4)
	   ,DiscAmount MONEY
	   ,BillTotal MONEY
	   ,receivedAmt MONEY NOT NULL
	   ,changeGiven MONEY NOT NULL
	   ,dueBalance MONEY NOT NULL
	   ,InWords VARCHAR(MAX)
	   ,is_hold BIT NULL
	   ,is_Paid BIT NOT NULL
	   ,is_complete_paid NOT NULL
	   ,Note VARCHAR(MAX)
	   ,is_Deleted BIT NULL
	   ,UserID INT NOT NULL
	   ,DateCreated DATETIME NOT NULL
	   ,MUserID INT NULL
	   ,ModifiedDate DATETIME NULL
	   ,extraNote VARCHAR(255)
	   ,balanceAmt MONEY NOT NULL
	   ,PRIMARY KEY (SAID)
	   ,UNIQUE (SVNUM)
	   ,FOREIGN KEY (SalerID) REFERENCES MSM.CompanyMasterInfo (Dup_cid)
	   ,FOREIGN KEY (BuyerID) REFERENCES MSM.CustomerMaster (CID)
	   ,FOREIGN KEY (UserID) REFERENCES MSM.UsersMaster (UserID)
	   ,FOREIGN KEY (MUserID) REFERENCES MSM.UsersMaster (UserID)
	)
END;
IF OBJECT_ID('MSM.SalesDetails') IS NULL
BEGIN
	CREATE TABLE MSM.SalesDetails (
		SAID INT NOT NULL
	   ,SVNUM VARCHAR(20) NOT NULL
	   ,PID INT NOT NULL
	   ,PName VARCHAR(MAX) NOT NULL
	   ,PCode NVARCHAR(10)
	   ,PBarcode NVARCHAR(30)
	   ,Quantiy DECIMAL(18, 6) NULL
	   ,UnitID INT NULL
	   ,PPrice MONEY
	   ,TotalPrice MONEY
	   ,Note VARCHAR(MAX) NULL
	   ,UserID INT NOT NULL
	   ,DateCreated DATETIME NOT NULL
	   ,MUserID INT NULL
	   ,ModifiedDate DATETIME NULL
	   ,is_Deleted BIT NULL
	   ,FOREIGN KEY (SAID) REFERENCES MSM.SalesMaster (SAID)
	   ,FOREIGN KEY (SVNUM) REFERENCES MSM.SalesMaster (SVNUM)
	   ,FOREIGN KEY (PID) REFERENCES MSM.ProductMaster (PID)
	   ,FOREIGN KEY (UserID) REFERENCES MSM.UsersMaster (UserID)
	   ,FOREIGN KEY (MUserID) REFERENCES MSM.UsersMaster (UserID)
	   ,FOREIGN KEY (UnitID) REFERENCES MSM.UnitMaster (UnitID)
	)
END;