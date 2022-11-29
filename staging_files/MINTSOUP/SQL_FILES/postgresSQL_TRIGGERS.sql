---------------------- before insert on Mintsouptokens--------------------
--FIRST to get into the site, you need to signup
DROP TRIGGER IF EXISTS update_amount_of_registered_users  on MintSoupTokens;
DROP FUNCTION IF EXISTS add_1_to_USERDATA_table;
CREATE OR REPLACE FUNCTION add_1_to_USERDATA_table()
RETURNS TRIGGER --this function is going to return a trigger
LANGUAGE PLPGSQL
AS--to open up the function transaction/operation
$$--
	DECLARE usercount int;
	BEGIN
		UPDATE userdata SET usercount = userdata.usercount::int + 1 where id=1;
 		return NEW;
	END;
$$;


CREATE TRIGGER update_amount_of_registered_users
BEFORE INSERT 
ON MintSoupTokens
FOR EACH ROW 
EXECUTE FUNCTION add_1_to_USERDATA_table();

---------------------- after insert on Mintsouptokens--------------------
DROP TRIGGER IF EXISTS insertViewer_when_a_Token_is_inserted  on MintSoupTokens;
DROP FUNCTION IF EXISTS create_viewer_on_signup;
CREATE OR REPLACE FUNCTION create_viewer_on_signup()
RETURNS TRIGGER --this function is going to return a trigger
LANGUAGE PLPGSQL
AS--to open up the function transaction/operation
$$
	BEGIN
		IF NEW.email LIKE 'sendes12@gmail.com'
		THEN 
			INSERT INTO Viewers (FK_MSToken, Email, Username) VALUES(NEW.id, NEW.email, NEW.username) ;
			INSERT INTO Admins (FK_MSToken, Email, Username) VALUES(NEW.id, NEW.email, NEW.username) ;
			return NEW;
			
		ELSE
			INSERT INTO Viewers (FK_MSToken, Email, Username) VALUES(NEW.id, NEW.email, NEW.username);
			return NEW;
		END IF;
	END;
$$;

CREATE TRIGGER insertViewer_when_a_Token_is_inserted
AFTER INSERT 
ON MintSoupTokens
FOR EACH ROW 
EXECUTE FUNCTION create_viewer_on_signup();




---------------------- after update on Mintsouptokens--------------------
DROP TRIGGER IF EXISTS updateViewer_when_a_Token_is_changed  on MintSoupTokens;
DROP FUNCTION IF EXISTS update_viewer_table_when_Your_Token_is_changed;
CREATE OR REPLACE FUNCTION update_viewer_table_when_Your_Token_is_changed()
RETURNS TRIGGER --this function is going to return a trigger
LANGUAGE PLPGSQL
AS--to open up the function transaction/operation
$$
	BEGIN
		IF OLD.email LIKE 'sendes12@gmail.com'
		THEN 
			UPDATE Viewers SET Email = New.email, Username = New.username  WHERE FK_MSToken = OLD.id;
			UPDATE Admins SET Email = New.email, Username = New.username  WHERE FK_MSToken = OLD.id;
			return NEW;
			
		ELSE
			UPDATE Viewers SET Email = New.email, Username = New.username  WHERE FK_MSToken = OLD.id;
			return NEW;
		END IF;
	END;
$$;

CREATE TRIGGER updateViewer_when_a_Token_is_changed
AFTER UPDATE 
ON MintSoupTokens
FOR EACH ROW 
EXECUTE FUNCTION update_viewer_table_when_Your_Token_is_changed();

---------------------- after insert on Viewer --------------------
DROP TRIGGER IF EXISTS createPersonalWallet_when_viewerIs_Created  on Viewers;
DROP FUNCTION IF EXISTS insertViewers_Wallet_when_Viewer_is_made;
CREATE OR REPLACE FUNCTION insertViewers_Wallet_when_Viewer_is_made()
RETURNS TRIGGER --this function is going to return a trigger
LANGUAGE PLPGSQL
AS--to open up the function transaction/operation
$$
	BEGIN
		INSERT INTO Wallets_Viewer (FK_ViewerID_WalletOwner, Balance) VALUES( New.id, 0);
		return NEW;
	END;
$$;

CREATE TRIGGER createPersonalWallet_when_viewerIs_Created
AFTER INSERT 
ON Viewers
FOR EACH ROW 
EXECUTE FUNCTION insertViewers_Wallet_when_Viewer_is_made();

---------------------- before delete on Viewer --------------------
DROP TRIGGER IF EXISTS delete_ALL_where_ViewersID_is_before_Deleting_Viewer  on Viewers;
DROP FUNCTION IF EXISTS delete_ALL_that_belongs_to_Viewer;
CREATE OR REPLACE FUNCTION delete_ALL_that_belongs_to_Viewer()
RETURNS TRIGGER --this function is going to return a trigger
LANGUAGE PLPGSQL
AS--to open up the function transaction/operation
$$
	BEGIN
			DELETE FROM Friends WHERE FK_ViewerID_Friender = OLD.id;
 			DELETE FROM ShowCommentLikes WHERE FK_ViewerID_Liker = OLD.id;
 			DELETE FROM ShowSessionJoins WHERE FK_ViewerID_ShowViewer = OLD.id;
			DELETE FROM Subscribers  WHERE FK_ViewerID_Subscriber = OLD.id;
 			DELETE FROM ShowComments WHERE FK_ViewerID_Commenter = OLD.id;
 			DELETE FROM ShowLikes WHERE FK_ViewerID_Liker = OLD.id;
 			DELETE FROM ShowSessions WHERE FK_ShowID = (select ID from Shows WHERE FK_ViewerID_Owner = OLD.id);
--  			DELETE FROM ShowDonations;
			DELETE FROM Wallets_Show WHERE FK_ViewerID_WalletOwner = OLD.id;
			DELETE FROM Followers WHERE FK_ViewerID_Follower = OLD.id;
 			DELETE FROM Shows WHERE FK_ViewerID_Owner = OLD.id;
			DELETE FROM Wallets_Viewer WHERE FK_ViewerID_WalletOwner = OLD.id;
-- 			DELETE FROM Admins ;
			return NEW;
	END;
$$;

CREATE TRIGGER delete_ALL_where_ViewersID_is_before_Deleting_Viewer
BEFORE DELETE 
ON Viewers
FOR EACH ROW 
EXECUTE FUNCTION delete_ALL_that_belongs_to_Viewer();


---------------------- after insert on ShowDonations --------------------
DROP TRIGGER IF EXISTS updatePersonalWallet_when_donationIS_Created  on ShowDonations;
DROP FUNCTION IF EXISTS updatePersonalWallet_from_Donation;
CREATE OR REPLACE FUNCTION updatePersonalWallet_from_Donation()
RETURNS TRIGGER --this function is going to return a trigger
LANGUAGE PLPGSQL
AS--to open up the function transaction/operation
$$
	BEGIN
		UPDATE Wallets_Viewer SET Balance = Balance - New.amount WHERE FK_ViewerID_WalletOwner = NEW.FK_ViewerID_Donater;
		UPDATE Wallets_Show SET Balance = Balance + New.amount WHERE FK_ShowID_WalletShow = NEW.FK_Wallets_ShowID;
		return NEW;
	END;
$$;

CREATE TRIGGER updatePersonalWallet_when_donationIS_Created
AFTER INSERT 
ON ShowDonations
FOR EACH ROW 
EXECUTE FUNCTION updatePersonalWallet_from_Donation();

---------------------- after insert on Show --------------------
DROP TRIGGER IF EXISTS createShowWallet_when_showIs_Created  on Shows;
DROP FUNCTION IF EXISTS createShowWallet_from_created_show;
CREATE OR REPLACE FUNCTION createShowWallet_from_created_show()
RETURNS TRIGGER --this function is going to return a trigger
LANGUAGE PLPGSQL
AS--to open up the function transaction/operation
$$
	BEGIN
		INSERT INTO Wallets_Show (FK_ShowID_WalletShow, FK_ViewerID_WalletOwner, Balance) VALUES(NEW.id, NEW.FK_ViewerID_Owner, 0 );
		return NEW;
	END;
$$;

CREATE TRIGGER createShowWallet_when_showIs_Created
AFTER INSERT 
ON Shows
FOR EACH ROW 
EXECUTE FUNCTION createShowWallet_from_created_show();


---------------------- after insert on ShowSession --------------------
DROP TRIGGER IF EXISTS updateShow_when_showSessionIs_Created  on ShowSessions;
DROP FUNCTION IF EXISTS updateShow_when_showSessionIs_inserted;
CREATE OR REPLACE FUNCTION updateShow_when_showSessionIs_inserted()
RETURNS TRIGGER --this function is going to return a trigger
LANGUAGE PLPGSQL
AS--to open up the function transaction/operation
$$
	BEGIN
		UPDATE Shows SET LastLive = NOW() WHERE ID = NEW.FK_ShowID;
		return NEW;
	END;
$$;

CREATE TRIGGER updateShow_when_showSessionIs_Created
AFTER INSERT 
ON ShowSessions
FOR EACH ROW 
EXECUTE FUNCTION updateShow_when_showSessionIs_inserted();

---------------------- after insert on SessionJoin --------------------
DROP TRIGGER IF EXISTS update__Session_and_Show__when_showSessionIs_Joined  on ShowSessionJoins;
DROP FUNCTION IF EXISTS update__Session_and_Show__when_SessionJoinIs_inserted;
CREATE OR REPLACE FUNCTION update__Session_and_Show__when_SessionJoinIs_inserted()
RETURNS TRIGGER --this function is going to return a trigger
LANGUAGE PLPGSQL
AS--to open up the function transaction/operation
$$
	BEGIN
		UPDATE ShowSessions SET "Views" = "Views" + 1 WHERE ID = NEW.FK_ShowSessionID;
		UPDATE Shows SET "Views" = "Views" + 1 WHERE ID = (select FK_ShowID from ShowSessions WHERE ID = NEW.FK_ShowSessionID);
		return NEW;
	END;
$$;

CREATE TRIGGER update__Session_and_Show__when_showSessionIs_Joined
AFTER INSERT 
ON ShowSessionJoins
FOR EACH ROW 
EXECUTE FUNCTION update__Session_and_Show__when_SessionJoinIs_inserted();

---------------------- after insert on ShowLikes --------------------
DROP TRIGGER IF EXISTS update_to_ShowSession_when_showLikeIs_Created on showlikes;
DROP FUNCTION IF EXISTS update_to_ShowSession_when_showLikeIs_inserted;
CREATE OR REPLACE FUNCTION update_to_ShowSession_when_showLikeIs_inserted()
RETURNS TRIGGER --this function is going to return a trigger
LANGUAGE PLPGSQL
AS--to open up the function transaction/operation
$$
	BEGIN
		UPDATE ShowSessions SET Likes = Likes + 1 WHERE ID = NEW.FK_ShowSessionID;
		UPDATE Shows SET Likes = Likes + 1 WHERE ID = (select FK_ShowID from ShowSessions WHERE ID = NEW.FK_ShowSessionID);
		return NEW;
	END;
$$;

CREATE TRIGGER update_to_ShowSession_when_showLikeIs_Created
AFTER INSERT 
ON showlikes
FOR EACH ROW 
EXECUTE FUNCTION update_to_ShowSession_when_showLikeIs_inserted();

---------------------- after delete on ShowLikes --------------------
DROP TRIGGER IF EXISTS update_to_ShowSession_when_showLikeIs_Deleted  on ShowLikes;
DROP FUNCTION IF EXISTS update_to_ShowSession_and_Show_when_showLikeIs_deleted;
CREATE OR REPLACE FUNCTION update_to_ShowSession_and_Show_when_showLikeIs_deleted()
RETURNS TRIGGER --this function is going to return a trigger
LANGUAGE PLPGSQL
AS--to open up the function transaction/operation
$$
	BEGIN
		UPDATE ShowSessions SET Likes = Likes - 1 WHERE ID = NEW.FK_ShowSessionID;
		UPDATE Shows SET Likes = Likes - 1 WHERE ID = (select FK_ShowID from ShowSessions WHERE ID = NEW.FK_ShowSessionID);
		return NEW;
	END;
$$;

CREATE TRIGGER update_to_ShowSession_when_showLikeIs_Deleted
AFTER DELETE 
ON ShowLikes
FOR EACH ROW 
EXECUTE FUNCTION update_to_ShowSession_and_Show_when_showLikeIs_deleted();


---------------------- after insert on ShowCommentLikes --------------------
DROP TRIGGER IF EXISTS update_to_ShowComment_when_showCommentLikeIs_Created  on ShowCommentLikes;
DROP FUNCTION IF EXISTS update_to_ShowComment_when_showCommentLikeIs_inserted;
CREATE OR REPLACE FUNCTION update_to_ShowComment_when_showCommentLikeIs_inserted()
RETURNS TRIGGER --this function is going to return a trigger
LANGUAGE PLPGSQL
AS--to open up the function transaction/operation
$$
	BEGIN
	WITH sessionID AS (select FK_ShowSessionID ShowComments where ID = NEW.FK_ShowCommentID)
	, showID AS(select FK_ShowID from ShowSessions where ID = sessionID )
		UPDATE ShowSessions SET Likes = Likes + 1 WHERE ID = sessionID;
		UPDATE ShowComments SET Likes = Likes + 1 WHERE ID = NEW.FK_ShowCommentID;
		UPDATE Shows SET Likes = Likes + 1 WHERE ID = showID;
		return NEW;
	END;
$$;

CREATE TRIGGER update_to_ShowComment_when_showCommentLikeIs_Created
AFTER INSERT 
ON ShowCommentLikes
FOR EACH ROW 
EXECUTE FUNCTION update_to_ShowComment_when_showCommentLikeIs_inserted();

---------------------- after delete on ShowCommentLikes --------------------
DROP TRIGGER IF EXISTS update_to_ShowComment_when_showCommentLikeIs_Deleted  on ShowCommentLikes;
DROP FUNCTION IF EXISTS update_to_ShowComment_when_showCommentLikeIs_removed;
CREATE OR REPLACE FUNCTION update_to_ShowComment_when_showCommentLikeIs_removed()
RETURNS TRIGGER --this function is going to return a trigger
LANGUAGE PLPGSQL
AS--to open up the function transaction/operation
$$
	BEGIN
	WITH sessionID AS (select FK_ShowSessionID ShowComments where ID = NEW.FK_ShowCommentID)
	, showID AS(select FK_ShowID from ShowSessions where ID = sessionID )
		UPDATE ShowSessions SET Likes = Likes - 1 WHERE ID = sessionID;
		UPDATE ShowComments SET Likes = Likes - 1 WHERE ID = NEW.FK_ShowCommentID;
		UPDATE Shows SET Likes = Likes - 1 WHERE ID = showID;
		return NEW;
	END;
$$;

CREATE TRIGGER update_to_ShowComment_when_showCommentLikeIs_Deleted
AFTER DELETE 
ON ShowCommentLikes
FOR EACH ROW 
EXECUTE FUNCTION update_to_ShowComment_when_showCommentLikeIs_removed();


---------------------- after insert on ShowComments --------------------
DROP TRIGGER IF EXISTS update_CommentCount_to_ShowSession_when_showCommentIs_Created  on ShowComments;
DROP FUNCTION IF EXISTS update_CommentCount_to_ShowSession_when_showCommentIs_inserted;
CREATE OR REPLACE FUNCTION update_CommentCount_to_ShowSession_when_showCommentIs_inserted()
RETURNS TRIGGER --this function is going to return a trigger
LANGUAGE PLPGSQL
AS--to open up the function transaction/operation
$$
	BEGIN
	WITH showID AS (select FK_ShowID from ShowSessions where ID = NEW.FK_ShowSessionID )
		UPDATE ShowSessions SET Comments = Comments + 1 WHERE ID = NEW.FK_ShowSessionID;
		UPDATE Shows SET Comments = Comments + 1 WHERE ID = showID;
		return NEW;
	END;
$$;

CREATE TRIGGER update_CommentCount_to_ShowSession_when_showCommentIs_Created
AFTER INSERT 
ON ShowComments
FOR EACH ROW 
EXECUTE FUNCTION update_CommentCount_to_ShowSession_when_showCommentIs_inserted();


---------------------- after deleted on ShowComments --------------------
DROP TRIGGER IF EXISTS removeCommentCount_from_Show_when_showCommentIs_Deleted  on ShowComments;
DROP FUNCTION IF EXISTS removeCommentCount_from_Show_when_showCommentIs_removed;
CREATE OR REPLACE FUNCTION removeCommentCount_from_Show_when_showCommentIs_removed()
RETURNS TRIGGER --this function is going to return a trigger
LANGUAGE PLPGSQL
AS--to open up the function transaction/operation
$$
	BEGIN
	WITH showID AS (select FK_ShowID from ShowSessions where ID = NEW.FK_ShowSessionID )
		UPDATE ShowSessions SET Comments = Comments - 1 WHERE ID = NEW.FK_ShowSessionID;
		UPDATE Shows SET Comments = Comments - 1 WHERE ID = showID;
		return NEW;
	END;
$$;

CREATE TRIGGER removeCommentCount_from_Show_when_showCommentIs_Deleted
AFTER DELETE 
ON ShowComments
FOR EACH ROW 
EXECUTE FUNCTION removeCommentCount_from_Show_when_showCommentIs_removed();

---------------------- after insert on Subscribers --------------------
DROP TRIGGER IF EXISTS update_Show_when_ShowSubscriberIs_Created on Subscribers;
DROP FUNCTION IF EXISTS update_Show_when_ShowSubscriberIs_inserted;
CREATE OR REPLACE FUNCTION update_Show_when_ShowSubscriberIs_inserted()
RETURNS TRIGGER --this function is going to return a trigger
LANGUAGE PLPGSQL
AS--to open up the function transaction/operation
$$
	BEGIN
		UPDATE Shows SET Subscribers = Subscribers + 1 WHERE ID = NEW.FK_ShowID_Subscribie;
		return NEW;
	END;
$$;

CREATE TRIGGER update_Show_when_ShowSubscriberIs_Created
AFTER INSERT 
ON Subscribers
FOR EACH ROW 
EXECUTE FUNCTION update_Show_when_ShowSubscriberIs_inserted();

---------------------- after delete on Subscribers --------------------
DROP TRIGGER IF EXISTS update_Show_when_ShowSubscriberIs_DELETED on Subscribers;
DROP FUNCTION IF EXISTS update_Show_when_ShowSubscriberIs_removed;
CREATE OR REPLACE FUNCTION update_Show_when_ShowSubscriberIs_removed()
RETURNS TRIGGER --this function is going to return a trigger
LANGUAGE PLPGSQL
AS--to open up the function transaction/operation
$$
	BEGIN
		UPDATE Shows SET Subscribers = Subscribers - 1 WHERE ID = NEW.FK_ShowID_Subscribie;
		return NEW;
	END;
$$;

CREATE TRIGGER update_Show_when_ShowSubscriberIs_DELETED
AFTER DELETE 
ON Subscribers
FOR EACH ROW 
EXECUTE FUNCTION update_Show_when_ShowSubscriberIs_removed();

