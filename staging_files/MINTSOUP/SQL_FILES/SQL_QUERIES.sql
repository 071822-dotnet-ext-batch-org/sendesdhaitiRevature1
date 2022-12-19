explain analyze SELECT public.login_with_email_and_password('sendes12@gmail.com', 123);
explain analyze SELECT signup('sendes12@gmail.com', 'sendes', '123');
explain analyze SELECT * from login_with_email_and_password('sendes12@gmail.com', '123'); --this will return the same hashed password if it matches
explain analyze SELECT * from login_with_username_and_password('sendes', '123'); --this will return the same hashed password if it matches
explain analyze SELECT convertpassword_to_a_hash('mintsoup');
explain analyze SELECT * from CHECK_if_mstoken_exists_by_email('sendes12@gmail.com');
explain analyze SELECT * from CHECK_if_mstoken_exists_by_username('sendes');
explain analyze SELECT * from  Mintsouptoken; -- e0929e27-2ab7-449d-b2b5-a4da3fd055c4
explain analyze SELECT * from  Person;
explain analyze SELECT * from  Email;
explain analyze SELECT * from  Wallet_Person;

INSERT INTO MintSoupToken (email, username, password) VALUES('sendes12@gmail.com', 'sendes', crypt('123', gen_salt('md5')) );
INSERT INTO Store (storename, storeimage, fk_personID, privacylevel) VALUES('The Mint Soup Store', 'The Mint Soup Store Logo', get_personID_with_email('sendes12@gmail.com'), 1);

DELETE from Mintsouptoken where email = 'sendes12@gmail.com';
DELETE from Person where username = 'sendes';

truncate table mintsouptoken CASCADE;