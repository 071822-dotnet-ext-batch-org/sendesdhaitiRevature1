---------------------------VIEWER SECTION-----------------------------
CREATE PROCEDURE truncate_table_BEFORE_CREATE_VIEWER
AS
	truncate table Viewers;
	truncate table Admins;
	truncate table Wallets_Viewer;
GO; 

CREATE PROCEDURE 