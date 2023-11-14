
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

IF OBJECT_ID ('[MSM].[CompanyMastertest]') IS NULL BEGIN CREATE TABLE [MSM].[CompanyMastertest]([cid] [bigint] IDENTITY(1,1) NOT NULL,[cname] [varchar](50) NULL,[regno] [varchar](15) NULL,[address] [varchar](50) NULL,[contact] [varchar](10) NULL,[email] [varchar](90) NULL,[city] [varchar](10) NULL,[country] [varchar](20) NULL,[catalog] [varchar](50) NOT NULL,[Location] [varchar](100) NULL,CONSTRAINT [PK_CompanyMaster] PRIMARY KEY (cid) ) END;