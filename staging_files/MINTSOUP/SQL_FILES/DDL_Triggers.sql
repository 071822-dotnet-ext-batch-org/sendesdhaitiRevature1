--The following example shows how a DDL trigger can be used 
--  to prevent any table in a database from being modified or dropped.
CREATE TRIGGER ddl_safety 
ON DATABASE 
FOR DROP_TABLE, ALTER_TABLE 
AS 
   PRINT 'You must disable Trigger "safety" to drop or alter tables!' 
   ROLLBACK ;

--We need a trigger that will alter a table to remove a constriant 
CREATE TRIGGER ddl_viewers_alter_table_trigger 
ON [dbo].[ShowDonations] 
FOR ALTER_TABLE 
AS 
    Alter table ShowDonations drop constraint 
   PRINT 'You must disable Trigger "safety" to drop or alter tables!' 
   ROLLBACK ;

CREATE TRIGGER dml_del_donations_when_viewer_is_del_trigger
ON [dbo].[ShowDonations]
FOR Delete 
AS
    Delete from Wallets_Viewer where FK_ViewerID_WalletOwner = (select FK_Wallets_ViewerID from inserted);

