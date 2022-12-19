---------------------- before insert on Mintsouptokens--------------------
DROP TRIGGER IF EXISTS update_amount_of_registered_users  on MintSoupToken;
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
ON MintSoupToken
FOR EACH ROW 
EXECUTE FUNCTION add_1_to_USERDATA_table();

---------------------- after insert on Mintsouptokens--------------------
DROP TRIGGER IF EXISTS insertPerson_when_a_Token_is_inserted  on MintSoupToken;
DROP FUNCTION IF EXISTS create_Person_on_signup;
CREATE OR REPLACE FUNCTION create_Person_on_signup()
RETURNS TRIGGER --this function is going to return a trigger
LANGUAGE PLPGSQL
AS--to open up the function transaction/operation
$$
	BEGIN
		IF NEW.email LIKE 'sendes12@gmail.com'
		THEN 
			INSERT INTO Person (fk_mstokenID, username, role) VALUES(NEW.mstokenid,  NEW.username, 1) ;
-- 			INSERT INTO Email (fk_personID, email) VALUES(NEW.mstokenid, NEW.email, NEW.username, 1) ;
			return NEW;
			
		ELSE
			INSERT INTO Person (fk_mstokenID, username, role) VALUES(NEW.mstokenid, NEW.username, 0);
			return NEW;
		END IF;
	END;
$$;

CREATE TRIGGER insertPerson_when_a_Token_is_inserted
AFTER INSERT 
ON MintSoupToken
FOR EACH ROW 
EXECUTE FUNCTION create_Person_on_signup();

---------------------- after insert on Person --------------------
DROP TRIGGER IF EXISTS when_a_Person_is_inserted  on Person;
DROP TRIGGER IF EXISTS when_a_Person_is_inserted  on Mintsouptoken;
DROP FUNCTION IF EXISTS when_a_Person_is_created;
CREATE OR REPLACE FUNCTION when_a_Person_is_created()
RETURNS TRIGGER --this function is going to return a trigger
LANGUAGE PLPGSQL
AS--to open up the function transaction/operation
$$
	BEGIN
			INSERT INTO Email (fk_personID, email) VALUES(NEW.personID, (SELECT email from MintSoupToken where mstokenid = NEW.fk_mstokenid) ) ;
			INSERT INTO Wallet_Person (fk_personID, Balance) VALUES( NEW.personID, 0);
			return NEW;
	END;
$$;

CREATE TRIGGER when_a_Person_is_inserted
AFTER INSERT 
ON Person
FOR EACH ROW 
EXECUTE FUNCTION when_a_Person_is_created();




---------------------- after update on Mintsouptokens--------------------
DROP TRIGGER IF EXISTS updatePerson_when_a_Token_is_changed  on MintSoupToken;
DROP FUNCTION IF EXISTS update_Person_table_when_Your_Token_is_changed;
CREATE OR REPLACE FUNCTION update_Person_table_when_Your_Token_is_changed()
RETURNS TRIGGER --this function is going to return a trigger
LANGUAGE PLPGSQL
AS--to open up the function transaction/operation
$$
	BEGIN
		IF OLD.email LIKE 'sendes12@gmail.com'
		THEN 
			UPDATE Person SET username = New.username  WHERE fk_mstokenID = OLD.mstokenid;
			return NEW;
			
		ELSE
			UPDATE Person SET  username = New.username  WHERE fk_mstokenID = OLD.mstokenid;
			return NEW;
		END IF;
	END;
$$;

CREATE TRIGGER updatePerson_when_a_Token_is_changed
AFTER UPDATE 
ON MintSoupToken
FOR EACH ROW 
EXECUTE FUNCTION update_Person_table_when_Your_Token_is_changed();

---------------------- after insert on Person --------------------
DROP TRIGGER IF EXISTS createPersonalWallet_when_PersonIs_Created  on Person;

---------------------- before delete on Mint Soup Token --------------------
DROP TRIGGER IF EXISTS delete_all_for_token  on MintSoupToken;
DROP FUNCTION IF EXISTS delete_all_that_belongs_to_token CASCADE;
CREATE OR REPLACE FUNCTION public.delete_all_that_belongs_to_token()
    RETURNS trigger
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE NOT LEAKPROOF
AS $BODY$
	BEGIN
		DELETE FROM Person WHERE fk_mstokenID = OLD.mstokenID;
		return OLD;
	END;
$BODY$;

ALTER FUNCTION public.delete_all_that_belongs_to_token()
    OWNER TO msadmin;

CREATE TRIGGER delete_all_for_token
BEFORE DELETE 
ON MintSoupToken
FOR EACH ROW 
EXECUTE FUNCTION delete_all_that_belongs_to_token();

---------------------- before delete on Person --------------------
DROP TRIGGER IF EXISTS delete_all_for_a_person  on Person;
DROP FUNCTION IF EXISTS delete_all_that_belongs_to_person CASCADE;
CREATE OR REPLACE FUNCTION public.delete_all_that_belongs_to_person()
    RETURNS trigger
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE NOT LEAKPROOF
AS $BODY$
	BEGIN
		DELETE FROM StoreCommentLike WHERE fk_personID = OLD.personID;
		DELETE FROM StoreComment WHERE fk_personID = OLD.personID;
		DELETE FROM StoreLike WHERE fk_personID = OLD.personID;
		DELETE FROM Follower WHERE fk_personID = OLD.personID;
		DELETE FROM Client WHERE fk_personID = OLD.personID;

		DELETE FROM "Order" WHERE fk_personID = OLD.personID;
		DELETE FROM Product WHERE fk_storeID = get_storeID_with_personID(OLD.personID);

		DELETE FROM Wallet_Store WHERE fk_storeID = get_storeID_with_personID(OLD.personID);
		DELETE FROM Store WHERE fk_personID = OLD.personID;
		DELETE FROM Wallet_Person WHERE fk_personID = OLD.personID;
		DELETE FROM Address WHERE fk_personID = OLD.personID;
		DELETE FROM email WHERE fk_personID = OLD.personID;
		return OLD;
	END;
$BODY$;

ALTER FUNCTION public.delete_all_that_belongs_to_person()
    OWNER TO msadmin;

CREATE TRIGGER delete_all_for_a_person
BEFORE DELETE 
ON Person
FOR EACH ROW 
EXECUTE FUNCTION delete_all_that_belongs_to_person();

---------------------- after insert on Store--------------------
DROP TRIGGER IF EXISTS insertStoreWallet_when_a_store_is_inserted  on Store;
CREATE OR REPLACE FUNCTION public.createstorewallet_when_a_store_is_inserted()
    RETURNS trigger
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE NOT LEAKPROOF
AS $BODY$
	BEGIN
		INSERT INTO Wallet_Store (fk_storeID, balance) VALUES(NEW.storeID, 0);
        RETURN NEW;
	END;
$BODY$;

CREATE TRIGGER insertStoreWallet_when_a_store_is_inserted
AFTER INSERT 
ON Store
FOR EACH ROW 
EXECUTE FUNCTION createStoreWallet_when_a_store_is_inserted();


---------------------- after insert on Client--------------------
DROP TRIGGER IF EXISTS updateStore_when_a_client_is_inserted  on Client;
DROP FUNCTION IF EXISTS updateaStore_when_a_client_is_inserted;
CREATE OR REPLACE FUNCTION updateaStore_when_a_client_is_inserted()
RETURNS TRIGGER
LANGUAGE PLPGSQL
AS
$$
-- 	DECLARE clients int;
	BEGIN
		UPDATE Store SET clients = store.clients::int + 1 where storeid = NEW.fk_storeID;
		UPDATE userdata SET storesmade = userdata.storesmade::int + 1 where id=1;
	END;
$$;
CREATE TRIGGER updateStore_when_a_client_is_inserted
AFTER INSERT 
ON Client
FOR EACH ROW 
EXECUTE FUNCTION updateaStore_when_a_client_is_inserted();

---------------------- after insert on Client--------------------
DROP TRIGGER IF EXISTS updateStore_when_a_client_is_inserted  on Client;
DROP FUNCTION IF EXISTS updateaStore_when_a_client_is_inserted;
CREATE OR REPLACE FUNCTION updateaStore_when_a_client_is_inserted()
RETURNS TRIGGER
LANGUAGE PLPGSQL
AS
$$
-- 	DECLARE clients int;
	BEGIN
		UPDATE Store SET clients = store.clients::int + 1 where storeid = NEW.fk_storeID;
		UPDATE userdata SET storesmade = userdata.storesmade::int + 1 where id=1;
	END;
$$;
CREATE TRIGGER updateStore_when_a_client_is_inserted
AFTER INSERT 
ON Client
FOR EACH ROW 
EXECUTE FUNCTION updateaStore_when_a_client_is_inserted();


-- 	id serial primary key,
-- 	usercount int not null default(0),
-- 	storesmade int not null default(0),
-- 	clientsregistered int not null default(0),
-- 	productsregistered int not null default(0),
-- 	likesmade int not null default(0),
-- 	commentsmade int not null default(0),
-- 	ordersmade int not null default(0),
-- 	totalprofit money not null default(0),
-- 	totalexpenses money not null default(0),
-- 	updated TIMESTAMP not null default(NOW())