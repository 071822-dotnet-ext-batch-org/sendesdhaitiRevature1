-- DROP EXTENSION IF EXISTS "uuid-ossp" CASCADE;
-- CREATE EXTENSION IF NOT EXISTS "uuid-ossp";--to use uuids in postgres

DROP TABLE IF EXISTS Friends;
DROP TABLE IF EXISTS ShowCommentLikes;
DROP TABLE IF EXISTS ShowSessionJoins;
DROP TABLE IF EXISTS Subscribers;
DROP TABLE IF EXISTS ShowComments;
DROP TABLE IF EXISTS ShowLikes;
DROP TABLE IF EXISTS ShowSessions;
DROP TABLE IF EXISTS ShowDonations;
DROP TABLE IF EXISTS Wallets_Show;
DROP TABLE IF EXISTS Followers;
DROP TABLE IF EXISTS Shows;
DROP TABLE IF EXISTS Wallets_Viewer;
DROP TABLE IF EXISTS Viewers;
DROP TABLE IF EXISTS Admins;
DROP TABLE IF EXISTS MintSoupTokens;
DROP TABLE IF EXISTS USERDATA;

CREATE TABLE userdata(
	id serial primary key,
	usercount int not null default(0),
	lastmodified TIMESTAMP not null default(NOW())
);

INSERT INTO userdata (usercount) VALUES(0);

Create table MintSoupTokens(
    ID uuid DEFAULT(uuid_generate_v4()),
    -- ID uniqueidentifier not null default(newid()),
    Email VARCHAR(100) unique not null,
    Username VARCHAR(100) unique not null,
    Password_Hash TEXT not null,
    Password_Salt TEXT not null,
    DateSignedUp TIMESTAMP not null default(NOW()),
    LastSignedIn TIMESTAMP not null default(NOW()),
    PRIMARY KEY (ID)
);


----------------------Viewer Section------------------------
Create  table Viewers(
ID uuid DEFAULT(uuid_generate_v4()) primary key, --unique
FK_MSToken uuid DEFAULT(uuid_generate_v4()),
Fn VARCHAR(100) default('') not null,
Ln VARCHAR(100) default('') not null,
Email VARCHAR(100) unique not null,
Image VARCHAR(150) default('') not null,
Username VARCHAR(100) unique not null, --unique
AboutMe VARCHAR(200) default('')  not null,
StreetAddy VARCHAR(100) default('') not null,
City VARCHAR(100) default('') not null,
State VARCHAR(100) default('') not null,
Country VARCHAR(100) default('') not null,
AreaCode int default(0) not null,
Role VARCHAR(30) not null default('Viewer'),
MembershipStatus VARCHAR(30) not null default('Viewer'),

DateSignedUp TIMESTAMP not null default(NOW()),
LastSignedIn TIMESTAMP not null default(NOW()),

CONSTRAINT FK_MSToken_Viewer FOREIGN KEY(FK_MSToken)
        REFERENCES MintSoupTokens(ID)
);

Create  table Admins(
ID uuid DEFAULT(uuid_generate_v4()) primary key,
FK_MSToken uuid DEFAULT(uuid_generate_v4()),
Email VARCHAR(100) unique not null , --unique
Username VARCHAR(100) unique not null , --unique
AdminStatus VARCHAR(100) default('Admin') not null, --unique

DateCreated TIMESTAMP not null default(NOW()),
LastSignedIn TIMESTAMP not null default(NOW()),

CONSTRAINT FK_MSToken_Admin FOREIGN KEY(FK_MSToken)
        REFERENCES MintSoupTokens(ID)
);

Create  table Friends(
ID uuid DEFAULT(uuid_generate_v4()) primary key,

FK_ViewerID_Friender uuid DEFAULT(uuid_generate_v4()),

FK_ViewerID_Friendie uuid DEFAULT(uuid_generate_v4()),
    
FriendshipStatus VARCHAR(30) not null default('PendingFriend'),

FriendDate TIMESTAMP not null default(NOW()),
FriendUpdateDate TIMESTAMP not null default(NOW()),

CONSTRAINT FK_ViewerID_Friender FOREIGN KEY(FK_ViewerID_Friender)
        REFERENCES Viewers(ID),
CONSTRAINT FK_ViewerID_Friendie FOREIGN KEY(FK_ViewerID_Friendie)
        REFERENCES Viewers(ID)
);

Create table Shows(
ID uuid DEFAULT(uuid_generate_v4()) primary key,
FK_ViewerID_Owner uuid DEFAULT(uuid_generate_v4()),
ShowName VARCHAR(100) unique not null,
ShowImage VARCHAR(200) not null,
Subscribers int not null default(0),
Views int not null default(0),
Likes int not null default(0),
Comments int not null default(0),
Rating float(24) not null default(0),
Rank int not null default(0),
PrivacyLevel VARCHAR(30) not null,
ShowStatus VARCHAR(30) not null default('Great'),

DateCreated TIMESTAMP not null default(NOW()),
LastLive TIMESTAMP not null default(NOW()),

CONSTRAINT FK_ViewerID_Owner FOREIGN KEY(FK_ViewerID_Owner)
        REFERENCES Viewers(ID)
);


Create table Followers(
ID uuid DEFAULT(uuid_generate_v4()) primary key,
FK_ViewerID_Follower uuid DEFAULT(uuid_generate_v4()),
FK_ViewerID_Followie uuid DEFAULT(uuid_generate_v4()),
FK_ShowID_Followie uuid DEFAULT(uuid_generate_v4()),
FollowerStatus VARCHAR(30) not null default('Follower'),

FollowDate TIMESTAMP not null default(NOW()),
StatusUpdateDate TIMESTAMP not null default(NOW()),

CONSTRAINT FK_ViewerID_Follower FOREIGN KEY(FK_ViewerID_Follower)
        REFERENCES Viewers(ID),
CONSTRAINT FK_ViewerID_Followie FOREIGN KEY(FK_ViewerID_Followie)
        REFERENCES Viewers(ID),
CONSTRAINT FK_ShowID_Followie FOREIGN KEY(FK_ShowID_Followie)
        REFERENCES Shows(ID)
);

Create  table Subscribers(
ID uuid DEFAULT(uuid_generate_v4()) primary key,
FK_ViewerID_Subscriber uuid DEFAULT(uuid_generate_v4()),
FK_ShowID_Subscribie uuid DEFAULT(uuid_generate_v4()),
MembershipStatus VARCHAR (30) not null default('Subscriber'),

SubscribeDate TIMESTAMP not null default(NOW()),
SubscriptionUpdateDate TIMESTAMP not null default(NOW()),

CONSTRAINT FK_ViewerID_Subscriber FOREIGN KEY(FK_ViewerID_Subscriber)
        REFERENCES Viewers(ID),
CONSTRAINT FK_ShowID_Subscribie FOREIGN KEY(FK_ShowID_Subscribie)
        REFERENCES Shows(ID)
);

Create Table ShowSessions(
ID uuid DEFAULT(uuid_generate_v4()) primary key,
FK_ShowID uuid DEFAULT(uuid_generate_v4()),
Views int not null default(0),
Likes int not null default(0),
Comments int not null default(0),

SessionStartDate TIMESTAMP not null default(NOW()),
SessionEndDate TIMESTAMP not null default(NOW()),

CONSTRAINT FK_ShowID_SessionShow FOREIGN KEY(FK_ShowID)
        REFERENCES Shows(ID)
);

Create Table ShowSessionJoins(
ID uuid DEFAULT(uuid_generate_v4()) primary key,
FK_ShowSessionID uuid DEFAULT(uuid_generate_v4()),
FK_ViewerID_ShowViewer uuid DEFAULT(uuid_generate_v4()),

SessionJoinDate TIMESTAMP not null default(NOW()),
SessionLeaveDate TIMESTAMP not null default(NOW()),

CONSTRAINT FK_ShowSessionID_sessionJoined FOREIGN KEY(FK_ShowSessionID)
        REFERENCES ShowSessions(ID),
CONSTRAINT FK_ViewerID_ShowViewer FOREIGN KEY(FK_ViewerID_ShowViewer)
        REFERENCES Viewers(ID)
);

Create  table ShowLikes(
ID uuid DEFAULT(uuid_generate_v4()) primary key,
FK_ViewerID_Liker uuid DEFAULT(uuid_generate_v4()),
FK_ShowSessionID uuid DEFAULT(uuid_generate_v4()),
LikeDate TIMESTAMP not null default(NOW()),

CONSTRAINT FK_ViewerID_Liker FOREIGN KEY(FK_ViewerID_Liker)
        REFERENCES Viewers(ID),
CONSTRAINT FK_ShowSessionID FOREIGN KEY(FK_ShowSessionID)
        REFERENCES ShowSessions(ID)
);

Create table ShowComments(
ID uuid DEFAULT(uuid_generate_v4()) primary key,
FK_ViewerID_Commenter uuid DEFAULT(uuid_generate_v4()),
FK_ShowSessionID uuid DEFAULT(uuid_generate_v4()),
Comment VARCHAR(200) not null,
Likes int not null default(0),

CommentDate TIMESTAMP not null default(NOW()),
CommentUpdateDate TIMESTAMP not null default(NOW()),

CONSTRAINT FK_ViewerID_Commenter FOREIGN KEY(FK_ViewerID_Commenter)
        REFERENCES Viewers(ID),
CONSTRAINT FK_ShowSessionID FOREIGN KEY(FK_ShowSessionID)
        REFERENCES ShowSessions(ID)
);

Create table ShowCommentLikes(
ID uuid DEFAULT(uuid_generate_v4()) primary key,
FK_ViewerID_Liker uuid DEFAULT(uuid_generate_v4()),
FK_ShowCommentID uuid DEFAULT(uuid_generate_v4()),
LikeDate TIMESTAMP not null default(NOW()),

CONSTRAINT FK_ViewerID_Liker FOREIGN KEY(FK_ViewerID_Liker)
        REFERENCES Viewers(ID),
CONSTRAINT FK_ShowCommentID FOREIGN KEY(FK_ShowCommentID)
        REFERENCES ShowComments(ID)
);

Create table Wallets_Viewer(
ID uuid DEFAULT(uuid_generate_v4()) primary key,
FK_ViewerID_WalletOwner uuid DEFAULT(uuid_generate_v4()),
Balance int not null,

DateCreated TIMESTAMP not null default(NOW()),
DateUpdated TIMESTAMP not null default(NOW()), 

CONSTRAINT FK_ViewerID_WalletOwner FOREIGN KEY(FK_ViewerID_WalletOwner)
        REFERENCES Viewers(ID)
);

Create table Wallets_Show(
ID uuid DEFAULT(uuid_generate_v4()) primary key,
FK_ViewerID_WalletOwner uuid DEFAULT(uuid_generate_v4()),
FK_ShowID_WalletShow uuid DEFAULT(uuid_generate_v4()),
Balance int not null,

DateCreated TIMESTAMP not null default(NOW()),
DateUpdated TIMESTAMP not null default(NOW()), 

CONSTRAINT FK_ViewerID_WalletOwner FOREIGN KEY(FK_ViewerID_WalletOwner)
        REFERENCES Viewers(ID),
CONSTRAINT FK_ShowID_WalletShow FOREIGN KEY(FK_ShowID_WalletShow)
        REFERENCES Shows(ID)
);


Create table ShowDonations(
ID uuid DEFAULT(uuid_generate_v4()) primary key,
FK_ViewerID_Donater uuid DEFAULT(uuid_generate_v4()),
FK_Wallets_ViewerID uuid DEFAULT(uuid_generate_v4()),
FK_Wallets_ShowID uuid DEFAULT(uuid_generate_v4()),
Amount int not null,
Note VARCHAR(200) null,
DonationDate TIMESTAMP not null default(NOW()),

CONSTRAINT FK_ViewerID_Donater FOREIGN KEY(FK_ViewerID_Donater)
        REFERENCES Viewers(ID),

CONSTRAINT FK_Wallets_ViewerID FOREIGN KEY(FK_Wallets_ViewerID)
        REFERENCES Wallets_Viewer(ID),

CONSTRAINT FK_Wallets_ShowID FOREIGN KEY(FK_Wallets_ShowID)
        REFERENCES Wallets_Show(ID)

);

