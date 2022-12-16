---------------------- get my person --------------------
DROP FUNCTION IF EXISTS get_my_person;
CREATE OR REPLACE FUNCTION get_my_person( mstoken uuid)
RETURNS TABLE 
		(
        personID uuid,
        username VARCHAR,
		image VARCHAR,
		aboutme VARCHAR,
		role int,
		membership int,

		added TIMESTAMP,
		updated TIMESTAMP,
		fk_mstokenid uuid
		) 
	AS $$
BEGIN
  	RETURN  query 	SELECT * 
					FROM Person 
					WHERE fk_mstoken = mstoken
					ORDER BY updated limit 1;
END $$ language plpgsql;

---------------------- create a order invoice --------------------
DROP FUNCTION IF EXISTS create_order_invoice;
CREATE OR REPLACE FUNCTION create_order_invoice(fk_orderID_ uuid, storename_ varchar, payment_method_ varchar, card_number_ int, quantity_ int)
RETURNS boolean --this function is going to return a trigger
LANGUAGE PLPGSQL
AS
 $$
	BEGIN
 		INSERT INTO OrderInvoice (fk_orderID, storename ,payment_method, card_number, quantity) VALUES(fk_orderID_ , storename_ , payment_method_ , card_number_ , quantity_ );
		return TRUE;
		exception when others then 
		return FALSE;
	END;
$$;

---------------------- create a order receipt --------------------
DROP FUNCTION IF EXISTS create_order_receipt;
CREATE OR REPLACE FUNCTION create_order_receipt(fk_personID_ uuid, fk_orderID_ uuid, fk_productID_ uuid, amount_ money, quantity_ money)
RETURNS boolean --this function is going to return a trigger
LANGUAGE PLPGSQL
AS
 $$
	BEGIN
 		INSERT INTO OrderReceipt (fk_personID, fk_orderID, fk_productID,amount, quantity) VALUES(fk_personID_ , fk_orderID_ , fk_productID_ , amount_ , quantity_ );
		return TRUE;
		exception when others then 
		return FALSE;
	END;
$$;

---------------------- check if person exists with person ID --------------------
DROP FUNCTION IF EXISTS check_if_person_exists_with_personID;
CREATE OR REPLACE FUNCTION check_if_person_exists_with_personID(id uuid)
RETURNS boolean
LANGUAGE PLPGSQL
AS
$$
	BEGIN
 		IF (select personID FROM Person where personID = id) = id
		THEN
			return TRUE;
			
		ELSE
			return FALSE;
 		END IF;
	END;
$$;

---------------------- convert password to hash --------------------
DROP FUNCTION IF EXISTS convertpassword_to_a_hash;
CREATE OR REPLACE FUNCTION convertpassword_to_a_hash(a varchar)
RETURNS text --this function is going to return a trigger
LANGUAGE PLPGSQL
AS--to open up the function transaction/operation
$$
	BEGIN
-- 		SELECT   AS pass;
 		return crypt(a, gen_salt('md5'));
	END;
$$;

---------------------- get personID with mstoken--------------------
DROP FUNCTION IF EXISTS get_personID_with_mstokenID;
CREATE OR REPLACE FUNCTION get_personID_with_mstokenID(a uuid)
RETURNS uuid 
LANGUAGE PLPGSQL
AS
$$
	BEGIN
 		return (SELECT personID from Person where fk_mstokenID = a ORDER BY updated LIMIT 1);
	END;
$$;

---------------------- get personID with email--------------------
DROP FUNCTION IF EXISTS get_personID_with_email;
CREATE OR REPLACE FUNCTION get_personID_with_email(a varchar)
RETURNS uuid 
LANGUAGE PLPGSQL
AS
$$
	BEGIN
 		return (SELECT fk_personID from Email where email = a ORDER BY updated LIMIT 1);
	END;
$$;
SELECT get_personID_with_email('sendes12@gmail.com');
---------------------- get store with personID --------------------
DROP FUNCTION IF EXISTS get_storeID_with_personID;
CREATE OR REPLACE FUNCTION get_storeID_with_personID(a uuid)
RETURNS uuid 
LANGUAGE PLPGSQL
AS
$$
	BEGIN
 		return (SELECT storeID from Store where fk_personID = a ORDER BY updated LIMIT 1);
	END;
$$;

---------------------- get all stores --------------------
DROP FUNCTION IF EXISTS get_all_stores;
CREATE OR REPLACE FUNCTION get_all_stores()
RETURNS setof store 
	AS $$
BEGIN
  	return query SELECT * 
	FROM store 
	ORDER BY updated;
END $$ language plpgsql;
	
---------------------- get storeID with productID--------------------
DROP FUNCTION IF EXISTS get_storeID_with_productID;
CREATE OR REPLACE FUNCTION get_storeID_with_productID(a uuid)
RETURNS uuid 
LANGUAGE PLPGSQL
AS
$$
	BEGIN
 		return (SELECT fk_storeID from Product where productID = a ORDER BY updated LIMIT 1);
	END;
$$;

---------------------- CHECK if mstoken exists with email --------------------
DROP FUNCTION IF EXISTS CHECK_if_mstoken_exists_by_email;
CREATE OR REPLACE FUNCTION CHECK_if_mstoken_exists_by_email(input_email varchar)
RETURNS boolean --this function is going to return a trigger
LANGUAGE PLPGSQL
AS--to open up the function transaction/operation
$$
	BEGIN
 		IF (select email FROM mintsouptoken where email = input_email) = input_email
		THEN
			return TRUE;
			
		ELSE
			return FALSE;
 		END IF;
	END;
$$;

---------------------- CHECK if mstoken exists with username --------------------
DROP FUNCTION IF EXISTS CHECK_if_mstoken_exists_by_username;
CREATE OR REPLACE FUNCTION CHECK_if_mstoken_exists_by_username(input_username varchar)
RETURNS boolean --this function is going to return a trigger
LANGUAGE PLPGSQL
AS--to open up the function transaction/operation
$$
	BEGIN
		IF (select username FROM mintsouptoken where username = input_username) = input_username
		THEN
			return TRUE;
			
		ELSE
			return FALSE;
 		END IF;
	END;
$$;

---------------------- login with email and password --------------------
DROP FUNCTION IF EXISTS login_with_email_and_password;
CREATE OR REPLACE FUNCTION login_with_email_and_password(input_email varchar, input_password varchar) 
RETURNS TABLE (
        _mstokenID uuid,
        _email VARCHAR,
		_username VARCHAR
		) 
	AS $$
BEGIN
	UPDATE mintsouptoken SET updated = now() where email = input_email;
	UPDATE person SET updated = now() where fk_mstokenID = (SELECT mstokenID from mintsouptoken where email = input_email);
  	RETURN  query 	SELECT mstokenID, email, username 
					FROM mintsouptoken 
					WHERE email = input_email 
					AND password = crypt(input_password, password);
END $$ language plpgsql;

---------------------- login with username and password --------------------
DROP FUNCTION IF EXISTS login_with_username_and_password;
CREATE OR REPLACE FUNCTION login_with_username_and_password(input_username varchar, input_password varchar) 
RETURNS TABLE (
        _mstokenID uuid,
        _email VARCHAR,
		_username VARCHAR
		) 
	AS $$
BEGIN
	UPDATE mintsouptoken SET updated = now() where username = input_username;
	UPDATE person SET updated = now() where username = input_username;
  	RETURN  query 	SELECT mstokenID, email, username 
					FROM mintsouptoken 
					WHERE username = input_username 
					AND password = crypt(input_password, password);
END $$ language plpgsql;

---------------------- create store with  --------------------
DROP FUNCTION IF EXISTS create_store;
CREATE OR REPLACE FUNCTION create_store(mstokenID uuid, sname varchar, image varchar, privacy int)
RETURNS boolean 
LANGUAGE PLPGSQL
AS
 $$
	BEGIN
 		INSERT INTO Store (fk_personID, storename, storeimage, privacylevel) VALUES( get_personID_with_mstokenID(mstokenID) , sname, image, privacy);
		return TRUE;
		exception when others then 
		return FALSE;
	END;
$$;

---------------------- create product  --------------------
DROP FUNCTION IF EXISTS create_product;
CREATE OR REPLACE FUNCTION create_product(storeID uuid, _type int, _category varchar, _name varchar, _price money, _description varchar, status int)
RETURNS boolean 
LANGUAGE PLPGSQL
AS
 $$
	BEGIN
 		INSERT INTO Product(fk_storeID, type, category, name, price, description, productstatus) VALUES( storeID , _type, _category, _name, _price, _description, status);
		return TRUE;
		exception when others then 
		return FALSE;
	END;
$$;

---------------------- create client  --------------------
DROP FUNCTION IF EXISTS create_client;
CREATE OR REPLACE FUNCTION create_client(personID uuid, storeID uuid)
RETURNS boolean 
LANGUAGE PLPGSQL
AS
 $$
	BEGIN
 		INSERT INTO Client (fk_personID, fk_storeID) VALUES( personID, storeID);
		return TRUE;
		exception when others then 
		return FALSE;
	END;
$$;

---------------------- create order  --------------------
DROP FUNCTION IF EXISTS create_order;
CREATE OR REPLACE FUNCTION create_order( personID uuid, productID uuid, _type int, _category varchar, _amount money, _desc varchar, orderStatus int)
RETURNS boolean 
LANGUAGE PLPGSQL
AS
 $$
	BEGIN
 		INSERT INTO "Order" (fk_personID, fk_productID, type, category, amount, description, orderstatus) VALUES(personID, productID, _type, _category, _amount, _desc, orderstatus);
		return TRUE;
		exception when others then 
		return FALSE;
	END;
$$;

---------------------- signup with email, pass, and username --------------------
DROP FUNCTION IF EXISTS signup;
CREATE OR REPLACE FUNCTION signup(input_email varchar, input_username varchar, input_password varchar)
RETURNS boolean --this function is going to return a trigger
LANGUAGE PLPGSQL
AS
 $$
	BEGIN
 		INSERT INTO mintsouptoken (email, username, password) VALUES(input_email, input_username, convertpassword_to_a_hash(input_password));
		return TRUE;
		exception when others then 
		return FALSE;
	END;
$$;