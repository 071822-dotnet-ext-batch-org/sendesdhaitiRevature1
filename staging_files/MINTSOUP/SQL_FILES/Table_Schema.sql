SELECT TABLE_NAME,
       CONSTRAINT_TYPE,CONSTRAINT_NAME
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
WHERE TABLE_NAME='ShowComments';

----------------------DROP TABLE Section------------------------

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

----------------------USER AUTH Section------------------------
Create table MintSoupTokens(
    ID uniqueidentifier not null default(newid()) 
    Email nvarchar(100) unique not null,
    Password nvarchar(200) not null,
    DateSignedUp DateTime not null default(getdate())
    LastSignedIn DateTime not null default(getdate())
    Constraint PK_MintSoupToken PRIMARY KEY (ID, Email)
);


----------------------Viewer Section------------------------
Create table Viewers(
ID uniqueidentifier not null default(newid()), --unique
FK_MINTSOUPTOKEN nvarchar(1000) not null,
Fn nvarchar(100) default('') null,
Ln nvarchar(100) default('') null,
FK_Email nvarchar(100) unique not null, --unique
Image nvarchar(150) default('') null,
Username nvarchar(100) default('') not null, --unique
AboutMe nvarchar(200) default('')  null,
StreetAddy nvarchar(100) default('') null,
City nvarchar(100) default('') null,
State nvarchar(100) default('') null,
Country nvarchar(100) default('') null,
AreaCode int default('') null,
Role nvarchar(30) not null default('Viewer'),
MembershipStatus nvarchar(30) not null default('Viewer'),

DateSignedUp DateTime not null default(getdate()),
LastSignedIn DateTime not null default(getdate()),
Constraint FK_MintSoupToken foreign key MintSoupTokens(ID, Email)
Constraint PK_Viewer PRIMARY KEY (ID)
);

Create table Admins(
ID uniqueidentifier not null default(newid()) primary key,
Auth0ID nvarchar(1000) not null,
Email nvarchar(100) unique not null, --unique
Username nvarchar(100) unique null, --unique
AdminStatus nvarchar(100) default('Admin') not null, --unique

DateCreated DateTime not null default(getdate()),
LastSignedIn DateTime not null default(getdate()),
);

Create table Friends(
ID uniqueidentifier not null default(newid()) primary key,

FK_ViewerID_Friender uniqueidentifier not null  CONSTRAINT FK_Viewer_Friender 
    foreign key references Viewers(ID),

FK_ViewerID_Friendie uniqueidentifier not null CONSTRAINT FK_Viewer_Friendie 
    foreign key references Viewers(ID),
    
FriendshipStatus nvarchar(30) not null default('PendingFriend'),

FriendDate DateTime not null default(getdate()),
FriendUpdateDate DateTime not null default(getdate())
);

Create table Shows(
ID uniqueidentifier not null default(newid()) primary key,
FK_ViewerID_Owner uniqueidentifier not null foreign key references Viewers(ID),
ShowName nvarchar(100) unique not null,
ShowImage nvarchar(200) not null,
Subscribers int not null default(0),
Views int not null default(0),
Likes int not null default(0),
Comments int not null default(0),
Rating float(24) not null default(0),
Rank int not null default(0),
PrivacyLevel nvarchar(30) not null,
ShowStatus nvarchar(30) not null default('Great'),

DateCreated DateTime not null default(getdate()),
LastLive DateTime not null default(getdate()),
);



-- if (( showID?.GetType()  != typeof(Guid)) && (auth0ID != null))
-- if (( showID?.GetType()  != typeof(Guid)) && (Auth0ID != null))

-- if (getmyViewerDTO?.Auth0ID?.GetType() != typeof(string)){return Conflict($"\n\n\t The id '{getmyViewerDTO?.Auth0ID}' is not valid \n");}

-- 

-- (select ID from Viewers where Auth0ID = @Auth0ID)
-- (select ID from Viewers where Auth0ID = @auth0ID)

-- string? auth0ID,  Guid? followidID
-- string? Auth0ID,  Guid? followidID




Create table Followers(
ID uniqueidentifier not null default(newid()) primary key,
FK_ViewerID_Follower uniqueidentifier not null foreign key references Viewers(ID),
FK_ViewerID_Followie uniqueidentifier null foreign key references Viewers(ID),
FK_ShowID_Followie uniqueidentifier null foreign key references Shows(ID),
FollowerStatus nvarchar(30) not null default('Follower'),

FollowDate DateTime not null default(getdate()),
StatusUpdateDate DateTime not null default(getdate())
);

Create table Subscribers(
ID uniqueidentifier not null default(newid()) primary key,
FK_ViewerID_Subscriber uniqueidentifier not null foreign key references Viewers(ID),
FK_ShowID_Subscribie uniqueidentifier not null foreign key references Shows(ID),
MembershipStatus nvarchar (30) not null default('Subscriber'),

SubscribeDate DateTime not null default(getdate()),
SubscriptionUpdateDate DateTime not null default(getdate())
);

Create Table ShowSessions(
ID uniqueidentifier not null default(newid()) primary key,
FK_ShowID uniqueidentifier not null foreign key references Shows(ID),
Views int not null default(0),
Likes int not null default(0),
Comments int not null default(0),

SessionStartDate DateTime not null default(getdate()),
SessionEndDate DateTime not null default(getdate())
);

Create Table ShowSessionJoins(
ID uniqueidentifier not null default(newid()) primary key,
FK_ShowSessionID uniqueidentifier not null foreign key references ShowSessions(ID),
FK_ViewerID_ShowViewer uniqueidentifier not null foreign key references Viewers(ID),

SessionJoinDate DateTime not null default(getdate()),
SessionLeaveDate DateTime not null default(getdate()),
);

Create table ShowLikes(
ID uniqueidentifier not null default(newid()) primary key,
FK_ViewerID_Liker uniqueidentifier not null foreign key references Viewers(ID),
FK_ShowSessionID uniqueidentifier not null foreign key references ShowSessions(ID),
LikeDate DateTime not null default(getdate())
);

Create table ShowComments(
ID uniqueidentifier not null default(newid()) primary key,
FK_ViewerID_Commenter uniqueidentifier not null foreign key references Viewers(ID),
FK_ShowSessionID uniqueidentifier not null foreign key references ShowSessions(ID),
Comment nvarchar(200) not null,
Likes int not null default(0),

CommentDate DateTime not null default(getdate()),
CommentUpdateDate DateTime not null default(getdate())
);

Create table ShowCommentLikes(
ID uniqueidentifier not null default(newid()) primary key,
FK_ViewerID_Liker uniqueidentifier not null foreign key references Viewers(ID),
FK_ShowCommentID uniqueidentifier not null foreign key references ShowComments(ID),
LikeDate DateTime not null default(getdate())
);

Create table Wallets_Viewer(
ID uniqueidentifier not null default(newid()) primary key,
FK_ViewerID_WalletOwner uniqueidentifier not null foreign key references Viewers(ID),
Balance smallmoney not null,

DateCreated DateTime not null default(getdate()),
DateUpdated DateTime not null default(getdate())
);

Create table Wallets_Show(
ID uniqueidentifier not null default(newid()) primary key,
FK_ViewerID_WalletOwner uniqueidentifier not null foreign key references Viewers(ID),
FK_ShowID_WalletShow uniqueidentifier not null foreign key references Shows(ID),
Balance smallmoney not null,

DateCreated DateTime not null default(getdate()),
DateUpdated DateTime not null default(getdate())
);

Create table ShowDonations(
ID uniqueidentifier not null default(newid()) primary key,
FK_ViewerID_Donater uniqueidentifier not null foreign key references Viewers(ID),
FK_Wallets_ViewerID uniqueidentifier not null foreign key references Wallets_Viewer(ID),
FK_Wallets_ShowID uniqueidentifier not null foreign key references Wallets_Show(ID),
Amount smallmoney not null,
Note nvarchar(200) null,
DonationDate DateTime not null default(getdate())
);

