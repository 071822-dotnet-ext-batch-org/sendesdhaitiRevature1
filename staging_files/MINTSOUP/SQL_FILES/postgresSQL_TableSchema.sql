DROP TABLE IF EXISTS StoreCommentLike;-- CASCADE;
DROP TABLE IF EXISTS StoreComment CASCADE;
DROP TABLE IF EXISTS StoreLike CASCADE;
DROP TABLE IF EXISTS Follower CASCADE;
DROP TABLE IF EXISTS Client CASCADE;

DROP TABLE IF EXISTS "Order" CASCADE;
DROP TABLE IF EXISTS Product CASCADE;

DROP TABLE IF EXISTS Wallet_Store CASCADE;
DROP TABLE IF EXISTS Store CASCADE;
DROP TABLE IF EXISTS Wallet_Person CASCADE;
DROP TABLE IF EXISTS Address CASCADE;
DROP TABLE IF EXISTS Email CASCADE;
DROP TABLE IF EXISTS Person CASCADE;
DROP TABLE IF EXISTS mstlocation CASCADE;
DROP TABLE IF EXISTS MintSoupToken CASCADE;
DROP TABLE IF EXISTS USERDATA CASCADE;
DROP TABLE IF EXISTS Category CASCADE;

CREATE TABLE userdata(
	id serial primary key,
	usercount int not null default(0),
	storesmade int not null default(0),
	clientsregistered int not null default(0),
	productsregistered int not null default(0),
	likesmade int not null default(0),
	commentsmade int not null default(0),
	ordersmade int not null default(0),
	totalprofit money not null default(0),
	totalexpenses money not null default(0),
	updated TIMESTAMP not null default(NOW())
);

INSERT INTO userdata (usercount) VALUES(0);

Create table MintSoupToken(
        mstokenID uuid DEFAULT(uuid_generate_v4()),
        email VARCHAR(200) unique not null,
        username VARCHAR(200) unique not null,
        password TEXT not null,
        added TIMESTAMP not null default(NOW()),
        updated TIMESTAMP not null default(NOW()),
        PRIMARY KEY (mstokenID)
);

CREATE TABLE IF NOT EXISTS public.mstlocation
(
    id uuid NOT NULL DEFAULT uuid_generate_v4(),
    asn character varying(200) COLLATE pg_catalog."default" NOT NULL DEFAULT ''::character varying,
    city character varying(150) COLLATE pg_catalog."default" NOT NULL DEFAULT ''::character varying,
    continent_code character varying(20) COLLATE pg_catalog."default" NOT NULL DEFAULT ''::character varying,
    country character varying(100) COLLATE pg_catalog."default" NOT NULL DEFAULT ''::character varying,
    country_area integer NOT NULL DEFAULT 0,
    country_calling_code character varying(10) COLLATE pg_catalog."default" NOT NULL DEFAULT ''::character varying,
    country_capital character varying(150) COLLATE pg_catalog."default" NOT NULL DEFAULT ''::character varying,
    country_code character varying(10) COLLATE pg_catalog."default" NOT NULL DEFAULT ''::character varying,
    country_code_iso3 character varying(10) COLLATE pg_catalog."default" NOT NULL DEFAULT ''::character varying,
    country_name character varying(50) COLLATE pg_catalog."default" NOT NULL DEFAULT ''::character varying,
    country_population integer NOT NULL DEFAULT 0,
    country_tld character varying(10) COLLATE pg_catalog."default" NOT NULL DEFAULT ''::character varying,
    currency character varying(10) COLLATE pg_catalog."default" NOT NULL DEFAULT ''::character varying,
    currency_name character varying(20) COLLATE pg_catalog."default" NOT NULL DEFAULT ''::character varying,
    in_eu boolean NOT NULL DEFAULT false,
    ip character varying(30) COLLATE pg_catalog."default" NOT NULL DEFAULT ''::character varying,
    languages character varying(30) COLLATE pg_catalog."default" NOT NULL DEFAULT ''::character varying,
    latitude double precision NOT NULL DEFAULT 0,
    longitude double precision NOT NULL DEFAULT 0,
    network character varying(30) COLLATE pg_catalog."default" NOT NULL DEFAULT ''::character varying,
    org character varying(25) COLLATE pg_catalog."default" NOT NULL DEFAULT ''::character varying,
    postal character varying(20) COLLATE pg_catalog."default" NOT NULL DEFAULT ''::character varying,
    region character varying(100) COLLATE pg_catalog."default" NOT NULL DEFAULT ''::character varying,
    region_code character varying(15) COLLATE pg_catalog."default" NOT NULL DEFAULT ''::character varying,
    timezone character varying(50) COLLATE pg_catalog."default" NOT NULL DEFAULT ''::character varying,
    utc_offset character varying(10) COLLATE pg_catalog."default" NOT NULL DEFAULT ''::character varying,
    version character varying(10) COLLATE pg_catalog."default" NOT NULL DEFAULT ''::character varying,
    added timestamp without time zone NOT NULL DEFAULT now(),
    updated timestamp without time zone NOT NULL DEFAULT now(),
    fk_mstokenid uuid DEFAULT uuid_generate_v4(),
    CONSTRAINT mstlocation_pkey PRIMARY KEY (id),
    CONSTRAINT fk_mstoken_relation FOREIGN KEY (fk_mstokenid)
        REFERENCES public.mintsouptoken (mstokenid)
);

Create table Person(
	personID uuid DEFAULT(uuid_generate_v4()) primary key, --unique
	username VARCHAR(100) unique not null, --unique
	image VARCHAR(150) default('') not null,
	aboutme VARCHAR(200) default('')  not null,
	role int not null default(0),
	membership int not null default(0),
	added TIMESTAMP not null default(NOW()),
	updated TIMESTAMP not null default(NOW()),
	fk_mstokenID uuid DEFAULT(uuid_generate_v4()),
	CONSTRAINT fk_mstoken_relation FOREIGN KEY(fk_mstokenID)
			REFERENCES MintSoupToken(mstokenID)
);
Create table Email(
	emailID uuid DEFAULT(uuid_generate_v4()) primary key, --unique
	email VARCHAR(200) not null default(''),
	added TIMESTAMP not null default(NOW()),
	updated TIMESTAMP not null default(NOW()),
	fk_personID uuid not null,
	CONSTRAINT fk_person_relation FOREIGN KEY(fk_personID)
			REFERENCES Person(personID)
);

Create Table Address(
	addressID uuid DEFAULT(uuid_generate_v4()) primary key, --unique
	street VARCHAR(200) not null default(''),
	city VARCHAR(200) not null default(''),
	state VARCHAR(200) not null default(''),
	country VARCHAR(200) not null default(''),
	areacode int not null default(0),
	added TIMESTAMP not null default(NOW()),
	updated TIMESTAMP not null default(NOW()),
	fk_personID uuid not null,
	CONSTRAINT fk_person_relation FOREIGN KEY(fk_personID)
			REFERENCES Person(personID)
);

Create table Wallet_Person(
	walletID uuid DEFAULT(uuid_generate_v4()) primary key,
	balance money not null default(0),

	added TIMESTAMP not null default(NOW()),
	updated TIMESTAMP not null default(NOW()), 
	fk_personID uuid not null,
	CONSTRAINT fk_person_walletowner_relation FOREIGN KEY(fk_personID)
				REFERENCES Person(personID)
);


Create table Store(
	storeID uuid DEFAULT(uuid_generate_v4()) primary key,
	fk_personID uuid not null,
	storename VARCHAR(100) unique not null,
	storeimage VARCHAR(200) not null,
	clients int not null default(0),
	views int not null default(0),
	likes int not null default(0),
	comments int not null default(0),
	rating float(24) not null default(0),
	rank int not null default(0),
	privacylevel int not null default(0),
	storestatus int not null default(0),

	added TIMESTAMP not null default(NOW()),
	updated TIMESTAMP not null default(NOW()),

	CONSTRAINT fk_person_storeowner_relation FOREIGN KEY(fk_personID)
			REFERENCES Person(personID)
);

Create table Wallet_Store(
	walletID uuid DEFAULT(uuid_generate_v4()) primary key,
	balance money not null,

	added TIMESTAMP not null default(NOW()),
	updated TIMESTAMP not null default(NOW()), 
	fk_storeID uuid not null,
	CONSTRAINT fk_storeID_walletowner_relation FOREIGN KEY(fk_storeID)
				REFERENCES Store(storeID)
);

Create Table Product(
	productID uuid DEFAULT(uuid_generate_v4()) primary key,
	type int not null default(0), --product or service type
	category VARCHAR(50) not null,
	name VARCHAR(50) not null,
	price money not null,
	description VARCHAR(200) not null,
	productstatus int not null default(0),
	added TIMESTAMP not null default(NOW()),
	updated TIMESTAMP not null default(NOW()),
	
	fk_storeID uuid not null,
	CONSTRAINT fk_store_relation FOREIGN KEY(fk_storeID)
				REFERENCES Store(storeID)
);

Create Table Category(
	categoryID uuid DEFAULT(uuid_generate_v4()) primary key,
	type int not null default(0), --product or service type
	category VARCHAR(50) unique not null,
	added TIMESTAMP not null default(NOW()),
	updated TIMESTAMP not null default(NOW())
);


Create table Follower(
	followerID uuid DEFAULT(uuid_generate_v4()) primary key,
	followerstatus int not null default(0),

	added TIMESTAMP not null default(NOW()),
	updated TIMESTAMP not null default(NOW()),

	fk_personID uuid not null,
	fk_storeID uuid not null,
	CONSTRAINT fk_person_follower_relation FOREIGN KEY(fk_personID)
			REFERENCES Person(personID),
	CONSTRAINT fk_store_relation FOREIGN KEY(fk_storeID)
			REFERENCES Store(storeID)
);

Create table Client(
	clientID uuid DEFAULT(uuid_generate_v4()) primary key,
	clientstatus int not null default(0),

	added TIMESTAMP not null default(NOW()),
	updated TIMESTAMP not null default(NOW()),

	fk_personID uuid not null,
	fk_storeID uuid not null,
	CONSTRAINT fk_person_client_relation FOREIGN KEY(fk_personID)
			REFERENCES Person(personID),
	CONSTRAINT fk_store_relation FOREIGN KEY(fk_storeID)
			REFERENCES Store(storeID)
);

Create Table "Order"(
	orderID uuid DEFAULT(uuid_generate_v4()) primary key,
	type int not null,
	category VARCHAR(50) not null,
	amount money not null default(0),
	description VARCHAR(30) not null default(''),
	orderstatus int not null default(0),-- pending, completed, in progress, canceled, declined
	added TIMESTAMP not null default(NOW()),
	updated TIMESTAMP not null default(NOW()),

	fk_personID uuid not null,
	fk_storeID uuid not null,
	CONSTRAINT fk_person_customer_relation FOREIGN KEY(fk_personID)
			REFERENCES Person(personID),
	CONSTRAINT fk_store_relation FOREIGN KEY(fk_storeID)
			REFERENCES Store(storeID)
);

Create  table StoreLike(
	likeID uuid DEFAULT(uuid_generate_v4()) primary key,
	likestatus int not null default(0),
	added TIMESTAMP not null default(NOW()),
	updated TIMESTAMP not null default(NOW()),
	fk_personID uuid not null,
	fk_storeID uuid not null,
	CONSTRAINT fk_person_like_relation FOREIGN KEY(fk_personID)
			REFERENCES Person(personID),
	CONSTRAINT fk_store_relation FOREIGN KEY(fk_storeID)
			REFERENCES Store(storeID)
);

Create table StoreComment(
	commentID uuid DEFAULT(uuid_generate_v4()) primary key,
	"comment" VARCHAR(200) not null,
	likes int not null default(0),

	added TIMESTAMP not null default(NOW()),
	updated TIMESTAMP not null default(NOW()),

	fk_personID uuid not null,
	fk_storeID uuid not null,
	CONSTRAINT fk_person_comment_relation FOREIGN KEY(fk_personID)
			REFERENCES Person(personID),
	CONSTRAINT fk_store_relation FOREIGN KEY(fk_storeID)
			REFERENCES Store(storeID)
);

Create table StoreCommentLike(
	commentlikeID uuid DEFAULT(uuid_generate_v4()) primary key,
	added TIMESTAMP not null default(NOW()),
	updated TIMESTAMP not null default(NOW()),

	fk_personID uuid not null,
	fk_commentID uuid not null,
	CONSTRAINT fk_person_commentliker_relation FOREIGN KEY(fk_personID)
			REFERENCES Person(personID),
	CONSTRAINT fk_comment_relation FOREIGN KEY(fk_commentID)
			REFERENCES StoreComment(commentID)
);



