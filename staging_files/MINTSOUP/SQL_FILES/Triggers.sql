---------------------------VIEWER SECTION-----------------------------
--The viewer Signs up and has their wallet automatically made for them
CREATE TRIGGER truncate wallet_when_Viewers_is_truncated
ON [dbo].[Viewers]
AFTER truncate
AS
	truncate table Wallets_Viewer;
	truncate table Admins;
GO



CREATE TRIGGER createPersonalWallet_when_viewerIs_Created
ON [dbo].[Viewers]
AFTER INSERT
AS 
	INSERT INTO Wallets_Viewer(FK_ViewerID_WalletOwner, Balance) VALUES((SELECT ID FROM inserted), 0);
GO

CREATE TRIGGER delete_wallets_AND_other_acounts_when_ViewerIs_Deleted
ON [dbo].[Viewers]
AFTER DELETE
AS 
	
	DELETE from ShowDonations where FK_Wallets_ViewerID = (SELECT ID FROM inserted);
	DELETE from Admins where Auth0ID = (SELECT Auth0ID FROM inserted);
	DELETE from Wallets_Viewer where FK_ViewerID_WalletOwner = (SELECT ID FROM inserted);
	DELETE from Wallets_Show where FK_ViewerID_WalletOwner = (SELECT ID FROM inserted);
	DELETE from Shows where FK_ViewerID_Owner = (SELECT ID FROM inserted);
GO

CREATE TRIGGER updatePersonalWallet_when_donationIS_Created
ON [dbo].[ShowDonations]
AFTER INSERT
AS 
	UPDATE Wallets_Viewer SET Balance = Balance - (select Amount from inserted), DateUpdated = (select DonationDate from inserted) WHERE FK_ViewerID_WalletOwner = (select FK_ViewerID_Donater From inserted);
	UPDATE Wallets_Show SET Balance = Balance + (select Amount from inserted), DateUpdated = (select DonationDate from inserted) WHERE FK_ShowID_WalletShow = (select FK_Wallets_ShowID From inserted);
GO

--On create of show, create show wallet
CREATE TRIGGER createShowWallet_when_showIs_Created
ON [dbo].[Shows]
AFTER INSERT
AS 
	INSERT INTO Wallets_Show(FK_ShowID_WalletShow, FK_ViewerID_WalletOwner, Balance) VALUES((SELECT ID FROM inserted), (SELECT FK_ViewerID_Owner FROM inserted), 0);
GO


CREATE TRIGGER delShowWallet_when_showIs_Deleted
ON [dbo].[Shows]
AFTER DELETE
AS 
    DELETE FROM Wallets_Show WHERE FK_ShowID_WalletShow = (SELECT ID FROM inserted) ;
GO


---------------------------SHOW SECTION-----------------------------

--THe viewer can watch a show and when they do, a view is added to the show
CREATE TRIGGER updateShow_when_showSessionIs_Created
ON [dbo].[ShowSessions]
AFTER INSERT
AS
	UPDATE [dbo].[Shows]
	SET LastLive = getdate()
	WHERE ID = (SELECT FK_ShowID from inserted)
GO

---------------------------SHOW SESSION SECTION-----------------------------

CREATE TRIGGER updateShow_when_showSessionIs_Updated
ON [dbo].[ShowSessions]
AFTER UPDATE
AS
	UPDATE [dbo].[Shows]
	SET LastLive = getdate(), Views = (select Views from inserted),
		Likes = (select Likes from inserted), Comments = (select Comments from inserted)
	WHERE ID = (SELECT FK_ShowID from inserted)
GO

---------------------------SHOW JOIN SECTION-----------------------------

CREATE TRIGGER updateShow_when_showSessionJoinIs_Created
ON [dbo].[ShowSessionJoins]
AFTER INSERT
AS
	UPDATE [dbo].[ShowSessions]
	SET Views = Views + 1
	WHERE ID = (SELECT FK_ShowSessionID from inserted)
GO


---------------------------SHOW LIKES SECTION-----------------------------


CREATE TRIGGER update_to_ShowSession_when_showLikeIs_Created
ON [dbo].[ShowLikes]
AFTER INSERT
AS 
	UPDATE [dbo].[ShowSessions]
	SET Likes = Likes + 1
	WHERE ID = (SELECT FK_ShowSessionID FROM inserted);
GO

CREATE TRIGGER update_to_ShowSession_when_showLikeIs_Deleted
ON [dbo].[ShowLikes]
AFTER DELETE
AS 
	UPDATE [dbo].[ShowSessions]
	SET Likes = Likes - 1
	WHERE ID = (SELECT FK_ShowSessionID FROM inserted);
GO

---------------------------SHOW COMMENT LIKES SECTION-----------------------------

CREATE TRIGGER update_to_ShowComment_when_showCommentLikeIs_Created
ON [dbo].[ShowCommentLikes]
AFTER INSERT
AS 
	UPDATE [dbo].[ShowComments]
	SET Likes = Likes + 1
	WHERE ID = (SELECT FK_ShowCommentID FROM inserted);
GO

CREATE TRIGGER update_to_ShowComment_when_showCommentLikeIs_Deleted
ON [dbo].[ShowCommentLikes]
AFTER DELETE
AS 
	UPDATE [dbo].[ShowComments]
	SET Likes = Likes - 1
	WHERE ID = (SELECT FK_ShowCommentID FROM inserted);
GO

---------------------------SHOW COMMENTS SECTION-----------------------------


CREATE TRIGGER update_CommentCount_to_ShowSession_when_showCommentIs_Created
ON [dbo].[ShowComments]
AFTER INSERT
AS 
	UPDATE [dbo].[ShowSessions]
	SET Comments = Comments + 1
	WHERE ID = (SELECT FK_ShowSessionID FROM inserted);
GO

CREATE TRIGGER removeCommentCount_from_Show_when_showCommentIs_Deleted
ON [dbo].[ShowComments]
AFTER DELETE
AS 
	UPDATE [dbo].[ShowSessions]
	SET Comments = Comments - 1
	WHERE ID = (SELECT FK_ShowSessionID FROM inserted);
GO

---------------------------SHOW SUBSCRIBERS SECTION-----------------------------

--We will add a subscriber trigger to add to a show's subscriber count

CREATE TRIGGER update_Show_when_ShowSubscriberIs_Created
ON [dbo].[Subscribers]
AFTER INSERT
AS
	UPDATE [dbo].[Shows]
	SET  Subscribers = Subscribers + 1
	WHERE ID = (SELECT FK_ShowID_Subscribie from inserted)
GO

CREATE TRIGGER update_Show_when_ShowSubscriberIs_DELETED
ON [dbo].[Subscribers]
AFTER DELETE
AS
	UPDATE [dbo].[Shows]
	SET  Subscribers = Subscribers - 1
	WHERE ID = (SELECT FK_ShowID_Subscribie from inserted)
GO