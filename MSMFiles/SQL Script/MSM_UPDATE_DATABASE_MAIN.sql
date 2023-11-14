
IF OBJECT_ID ('[MSM].[UsersMaster]') IS NULL BEGIN EXECUTE(' ALTER TABLE [MSM].[UsersMaster] DROP COLUMN [status]; ALTER TABLE [MSM].[UsersMaster] ADD [RoleID] int;') END;