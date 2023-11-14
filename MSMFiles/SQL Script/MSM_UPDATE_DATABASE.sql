
IF NOT EXISTS
(
  SELECT s.name
   FROM sys.schemas s
   WHERE s.name = 'MSM'
)
  BEGIN
    DECLARE @MSM NVARCHAR(MAX);
    SET @MSM = 'CREATE SCHEMA MSM AUTHORIZATION dbo;';
    --PRINT @SQL
    EXEC sys.sp_executesql @MSM;
  END;

IF OBJECT_ID ('[MSM].[CompanyMaster]') IS NULL BEGIN CREATE TABLE [MSM].[CompanyMaster]([cid] [bigint] IDENTITY(1,1) NOT NULL,[cname] [varchar](100) NULL,[regno] [varchar](30) NULL,[address] [varchar](200) NULL,[contact] [varchar](50) NULL,[email] [varchar](100) NULL,[city] [varchar](100) NULL,[country] [varchar](20) NULL,[catalog] [varchar](50) NOT NULL,[Location] [varchar](100) NULL,CONSTRAINT [PK_CompanyMaster] PRIMARY KEY (cid) ) END;

IF OBJECT_ID ('[MSM].[UsersMaster]') IS NULL BEGIN CREATE TABLE [MSM].[UsersMaster]([userid] [bigint] NOT NULL,[usrname] [varchar](20) NOT NULL,[loginid] [varchar](20) NOT NULL,[password] [varchar](15) NOT NULL,[dept] [varchar](10) NULL,[status] [BIT] NULL,[ActiveStatus] [BIT] NULL CONSTRAINT [PK_MasterUsersMaster] PRIMARY KEY (userid)); End

