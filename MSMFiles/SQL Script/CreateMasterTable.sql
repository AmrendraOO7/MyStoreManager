

IF object_id('[master.ServerInfo]') is NULL CREATE TABLE [master.ServerInfo]([ServerID] [int] IDENTITY(1,1),[ServerName] [nvarchar](200) NOT NULL,[UserId] [varchar](20) NULL,[UserPassword] [nvarchar](20)NULL) ; insert into dbo.[master.ServerInfo] ([ServerName], [UserId], [UserPassword]) values('DESKTOP-RJRSTJN\MY_WORK_LAB','sa', '321');




insert into dbo.[master.ServerInfo] ([ServerName], [UserId], [UserPassword]) values('DESKTOP-RJRSTJN\MY_WORK_LAB','sa','321');


insert into dbo.[master.ServerInfo] ([ServerName], [UserId], [UserPassword]) values(null,'','')

select ServerID From dbo.[master.ServerInfo]

SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'master.ServerInfo'

SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'master.ServerConnInfo' and TABLE_NAME ='master.CompanyMasterInfo'

SELECT DISTINCT 1 as IsExists FROM dbo.sysobjects where id = object_id('[dbo].[master.ServerConnInfo]')

--      DESKTOP-RJRSTJN\MY_WORK_LAB

--bool exists;
--            var chktb = new SqlCommand("select case when exists(select table_schema,table_name from information_schema.tables where schema_name='inventoryDB.mdf' and table_name='dbo.tempoutlet')", con);
--            exists = (int)chktb.ExecuteScalar() == 1;

--select case when exists(select * from information_schema.tables where TABLE_SCHEMA='dbo' and TABLE_NAME='master.ServerInfo') 

--  IF object_id('[master.ServerInfo]') is NULL   insert into dbo.[master.ServerInfo] (ServerName, UserId, UserPassword) values('"+Database+"','"+ UserId+ "', '"+Password+"');

if OBJECT_ID ('[dbo].[master.ServerInfo]') is null return 0


IF object_id('[master.ServerInfo]') is NULL CREATE TABLE [master.ServerInfo]([ServerID] [int] IDENTITY(1,1),[ServerName] [nvarchar](200) NOT NULL,[UserId] [varchar](20) NULL,[UserPassword] [nvarchar](20) NULL) ; insert into dbo.[master.ServerInfo] ([ServerName], [UserId], [UserPassword]) values('{DESKTOP-RJRSTJN\MY_WORK_LAB}','{sa}', '{321}')

SELECT * FROM [master.ServerConnInfo]

IF object_id('[master.ServerInfo]') is NULL CREATE TABLE [master.ServerInfo] (ServerID int IDENTITY(1,1),ServerName nvarchar(200) NOT NULL,UserId varchar(20) NULL,UserPassword nvarchar(20) NULL) ; insert into [master.ServerInfo] (ServerName, UserId, UserPassword) values('DESKTOP-RJRSTJN\MY_WORK_LAB','sa', '321');

CREATE TABLE [master.ServerConnInfo]([ServerID] [int] IDENTITY(1,1),[ServerName] [nvarchar](200) NOT NULL,[UserId] [varchar](20) NULL,UserPassword nvarchar(20) NULL);

insert into [master.ServerConnInfo] (ServerName, UserId, UserPassword) values('DESKTOP-RJRSTJN\MY_WORK_LAB','sa', '321')

