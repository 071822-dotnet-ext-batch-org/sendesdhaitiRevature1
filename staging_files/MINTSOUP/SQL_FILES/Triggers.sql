---------------------------Viewer Section-----------------------------
--The viewer Signs up and has their wallet automatically made for them

CREATE TRIGGER createPersonalWallet_when_viewerIs_Created
ON [dbo].[Viewers]
AFTER INSERT
AS 
	INSERT INTO Wallets_Viewer(FK_ViewerID_WalletOwner, Balance) VALUES((SELECT ID FROM inserted), 0);
GO

--THe viewer can watch a show and when they do, a view is added to the show
CREATE TRIGGER addToShowView_when_showSessionIs_Created
ON [dbo].[ShowSessions]
AFTER INSERT
AS
	UPDATE [dbo].[Shows]
	SET Views = Views + 1
	WHERE ID = (SELECT FK_ShowID from inserted)
GO

--On create of show, create show wallet
CREATE TRIGGER createShowWallet_when_showIs_Created
ON [dbo].[Shows]
AFTER INSERT
AS 
	INSERT INTO Wallets_Show(FK_ShowID_WalletOwner, Ba lance) VALUES((SELECT ID FROM inserted), 0);
GO


CREATE TRIGGER delShowWallet_when_showIs_Deleted
ON [dbo].[Shows]
AFTER DELETE
AS 
    DELETE FROM Wallets_Show WHERE FK_ShowID_WalletOwner=(SELECT ID FROM inserted) ;
GO

CREATE TRIGGER addLike_to_Show_when_showLikeIs_Created
ON [dbo].[ShowLikes]
AFTER INSERT
AS 
	UPDATE [dbo].[Shows]
	SET Likes = Likes + 1
	WHERE ID = (SELECT FK_ShowID_Likie FROM inserted);
GO

CREATE TRIGGER removeLike_from_Show_when_showLikeIs_Deleted
ON [dbo].[ShowLikes]
AFTER DELETE
AS 
	UPDATE [dbo].[Shows]
	SET Likes = Likes - 1
	WHERE ID = (SELECT FK_ShowID_Likie FROM inserted);
GO


CREATE TRIGGER addCommentCount_to_Show_when_showCommentIs_Created
ON [dbo].[ShowComments]
AFTER INSERT
AS 
	UPDATE [dbo].[Shows]
	SET Comments = Comments + 1
	WHERE ID = (SELECT FK_ShowID_Commentie FROM inserted);
GO

CREATE TRIGGER removeCommentCount_from_Show_when_showCommentIs_Deleted
ON [dbo].[ShowComments]
AFTER DELETE
AS 
	UPDATE [dbo].[Shows]
	SET Comments = Comments - 1
	WHERE ID = (SELECT FK_ShowID_Commentie FROM inserted);
GO


CREATE TRIGGER AddLikeCount_to_ShowCommentLike_when_showCommentLikeIs_Created
ON [dbo].[ShowCommentLikes]
AFTER INSERT
AS 
	UPDATE [dbo].[ShowComments]
	SET Likes = Likes + 1
	WHERE ID = (SELECT FK_ShowCommentID_Likie FROM inserted);

    UPDATE [dbo].[Shows]
	SET Likes = Likes + 1
	WHERE ID = (SELECT FK_ShowID FROM inserted);
GO

CREATE TRIGGER removeLikeCount_from_ShowCommentLike_when_showCommentIs_Deleted
ON [dbo].[ShowCommentLikes]
AFTER DELETE
AS 
	UPDATE [dbo].[ShowComments]
	SET Likes = Likes - 1
	WHERE ID = (SELECT FK_ShowCommentID_Likie FROM inserted);

    UPDATE [dbo].[Shows]
	SET Likes = Likes - 1
	WHERE ID = (SELECT FK_ShowID FROM inserted);
GO


CREATE TRIGGER updateWalletBalance_when_donationIs_Created
ON [dbo].[ShowDonations]
AFTER INSERT
AS 
	UPDATE [dbo].[Wallets_Viewer]
	SET Ballance = Ballance - (SELECT Amount from inserted)
	WHERE FK_ViewerID_WalletOwner = (SELECT FK_ViewerID_Donater FROM inserted);

    UPDATE [dbo].[Wallets_Show]
	SET Ballance = Ballance + (SELECT Amount from inserted)
	WHERE FK_ShowID_WalletOwner = (SELECT FK_ShowID_Donatie FROM inserted);
GO
