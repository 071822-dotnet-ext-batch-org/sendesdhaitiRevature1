--GAME
CREATE TABLE Game(
    GameID UNIQUEIDENTIFIER PRIMARY KEY,
)
--PLAYER
CREATE TABLE Players(
    PlayerID UNIQUEIDENTIFIER PRIMARY KEY,
    Fname NVARCHAR(50) NOT NULL,
    Lname NVARCHAR(50) NULL,
    Username NVARCHAR(50) NOT NULL,
    Wins INT NOT NULL IDENTITY(0,1) DEFAULT 0,
    Losses INT NOT NULL IDENTITY(0,1) DEFAULT 0,

)

--GAMEPLAY
CREATE TABLE Round(
    RoundID UNIQUEIDENTIFIER PRIMARY KEY,

)

--GAMEPIECES
CREATE TABLE GamePieces(
    GamePieceID INT PRIMARY KEY IDENTITY(0,1),
    GamePieceNumber INT NOT NULL DEFAULT -1,
    GamePieceName NVARCHAR(20) NOT NULL,

)


---SELECT TOP 1000 ROWS
SELECT TOP (1000) * FROM [dbo].[Addresses]

--DELETE/DROP TABLE
DROP TABLE table_name;


--Creating the Employee, Ticket, and Session Tables
--And referencing them all to the junction table
CREATE TABLE Employee(
EmployeeID UNIQUEIDENTIFIER DEFAULT(NEWID()) NOT NULL, --NEWID() function returns a GUID
Username NVARCHAR(50) UNIQUE NOT NULL,
Firstname NVARCHAR(50) NULL,
Lastname NVARCHAR(50) NULL,
Manager BIT DEFAULT(0) NOT NULL,
SignUpDate DATETIME DEFAULT(getdate()) NOT NULL,
LastSignedIn DATETIME DEFAULT(getdate()) NULL,
CONSTRAINT PK_EmployeeID PRIMARY KEY (EmployeeID)--This will enssentially redefine the
--EmployeeID as THE PK for the table
--EmTicketinSessionID UNIQUEIDENTIFIER REFERENCES EmTicketinSession(juncID)--I'll Also have a junction FK relating to ticket
);



CREATE TABLE Ticket(
TicketID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT(NEWID()),
Amount SMALLMONEY DEFAULT(0.00) NOT NULL,
Desciption NVARCHAR(50) NULL,
DateSubmitted DATETIME DEFAULT(getdate()) NOT NULL,
DateReviewed DATETIME DEFAULT(getdate()) NULL,
Approved BIT DEFAULT(0) NULL,
Denied BIT DEFAULT(0) NULL,
PENDING BIT DEFAULT(1)NOT NULL,
--EmTicketinSessionID UNIQUEIDENTIFIER REFERENCES EmTicketinSession(juncID)--FK relation to juntion relating employee with ticket
);

CREATE TABLE AppSession(
SessionID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
EmTicketinSessionID UNIQUEIDENTIFIER REFERENCES EmTicketinSession(juncID)
);

CREATE TABLE EmTicketinSession(
juncID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
EmployeeID UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Employee(EmployeeID),
TicketID UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Ticket(TicketID),
SessionID UNIQUEIDENTIFIER FOREIGN KEY REFERENCES AppSession(SessionID)--FK of Session
);

--TO REFERNECE A FOREIGN KEY
FOREIGN KEY (`Category_ID`,`Supplier_VAT`) REFERENCES tbl_name (index_col_name_1, index_col_name_2)

---TO add foreign key to existing table
ALTER TABLE Employees
ADD CONSTRAINT FK_TicketID
    FOREIGN KEY (EmployeeID)
    REFERENCES Tickets
        (TicketID)
    ON DELETE CASCADE ON UPDATE NO ACTION;


---To change the name of a table
EXEC sp_rename 'Junc_T_and_Employee', 'Junc_T_E';


--The syntax for sp_rename goes like this:

sp_rename
    [ @objname = ] 'object_name' ,
    [ @newname = ] 'new_name'
    [ , [ @objtype = ] 'object_type' ]


  --Change the name of a table ROWS
  EXEC sp_rename '[doc].[_MyTable].[PK_MyTable]', '[PK__MyTable]'



ALTER TABLE [dbo].[Employee]
ADD CONSTRAINT PK_Employee PRIMARY KEY (EmployeeID) ;

--To Make a string case sensitive and Accent sensitive
Alter table Employee
ADD EmPassword NVARCHAR(50) COLLATE  SQL_Latin1_General_CP1_CS_AS DEFAULT('DEFAULTPASS') NOT NULL;

UPDATE Employee
SET EmPassword='MyPassword';



--P1 Creating all Tables
CREATE TABLE Employees(
EmployeeID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT(NEWID()) NOT NULL,
Fname NVARCHAR(50) NULL,
Lname NVARCHAR(50) NULL,
Username NVARCHAR(30) UNIQUE NOT NULL,
Password NVARCHAR(50) NOT NULL,
SignUpDate DATETIME DEFAULT(getdate()) NOT NULL,
LastSignedIn DATETIME DEFAULT(getdate()) NULL
--FK_TicketID UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Ticket(TicketID) NULL
);

Create table Managers(
ManagerID Uniqueidentifier not null default newid()
, Fname nvarchar(50) null default('Fname')
, Lname nvarchar(50) null default('Fname')
, Username nvarchar(50) not null unique
, Password nvarchar(50)  Collate SQL_Latin1_General_CP1_CS_AS  NOT NULL
, Role nvarchar(15) not null Default('Manager')
, SignUpDate datetime not null default getdate()
);

--REFERENCE TO EMPLOYEE TABLE AFTER CREATING TICKET TABLE
--FK_TicketID UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Ticket(TicketID),

CREATE TABLE Tickets(
TicketID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT(NEWID()) NOT NULL,
Amount SMALLMONEY NOT NULL,
Description NVARCHAR(200) NULL,
Ticket_Status INT DEFAULT(1) NOT NULL,
DateSubmitted DateTime DEFAULT(getdate()) NOT NULL,
DateReviewed DateTime DEFAULT(getdate()) NOT NULL,
--FK_EmployeeID UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Employees(EmployeeID), NOT NULL
--FK_ManagerReviewer_ID UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Managers(ManagerID) NULL
);

CREATE TABLE Sessions(
SessionID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT(NEWID()) NOT NULL,
--FK_Junc_Ticket_Session_ID UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Junc_T_and_S(Junc_ID), NOT NULL
);

CREATE TABLE Junc_T_and_S(
Junc_ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT(NEWID()) NOT NULL,
--FK_TicketID UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Ticket(TicketID) NOT NULL
--FK_SessionID UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Sessions(SessionID) NOT NULL

);


--REFERENCE TO EMPLOYEE AND MANAGER TABLES AFTER CREATING MANAGER TABLE
--FK_EmployeeID UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Employees(EmployeeID),
--FK_ManagerReviewer_ID UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Managers(ManagerID) NOT NULL

--------------------list Table Constraints------------------
SELECT TABLE_NAME,
       CONSTRAINT_TYPE,CONSTRAINT_NAME
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
WHERE TABLE_NAME='Employees';



----------------------Add Constraint with Custom name-----------------
ALTER TABLE Users
ADD CONSTRAINT Unique_Email_Constraint
Unique (Email)


---------------------If There is a default value constraint - This might make every new ticket or obj
-------------------------a new ticket or obj, with the same ticket id...IF!!!, the automatic generating method
----------------------------is in the parenthesis (). So... Default(NEWID()) is gonna be THE VERY FIRST id generated
------------_SOLUTION------------------------
----------------------------CHANGE DEFAULT(NEWID()) TO DEFAULT NEWID() - Which means...
--------------------------------the default value is the NEWID() method not the value generated by the NEWID() method
Failed to execute query. Error: The object 'DF__Tickets__TicketI__498EEC8D' is dependent on column 'TicketID'.





-----------------------Failed to execute query. Error: Number of referencing columns in foreign key differs from number of referenced columns, table 'dbo.Junc_T_M'.


ALTER TABLE DROP COLUMN TicketID failed because one or more objects access this column.



---------------------TO drop constraint by name ---------------
ALTER TABLE [dbo].[Tickets]
DROP CONSTRAINT DF__Tickets__Ticket___4A8310C6

----------------------To drop constraint of table --------------------
ALTER TABLE [dbo].[Tickets]
DROP CONSTRAINT DF__Tickets__Ticket___4A8310C6


--------------------SELECT ----------_Tickets
SELECT column1, column2, ...
FROM table_name
WHERE condition;

SELECT TicketID, Amount, Description, Ticket_Status,
DateSubmitted, DateReviewed, FK_EmployeeID, FK_ManagerID
FROM [dbo].[Tickets]
WHERE Ticket_status= 1;

--Seelect all from T where value(cond)
SELECT *FROM Tickets where values( TicketID,  Amount, Description, Ticket_Status, DateSubmitted, DateReviewed, FK_EmployeeID, FK_ManagerID) AND WHERE Ticket_Status=@TStatus);



--Select all from table where value=value
SELECT  TicketID,  Amount, Description, Ticket_Status, DateSubmitted, DateReviewed, FK_EmployeeID, FK_ManagerID FROM Tickets WHERE Ticket_Status=1;












-----------------------------Starting Up the DB Query Editor---------------------------
select * from [dbo].[Tickets]
select * from [dbo].[Managers]
select * from [dbo].[Employees]
select * from [dbo].[Junc_T_M]








---------------------------Creating a Stored Procedure ---------------
CREATE PROCEDURE GetProductDesc
AS
BEGIN
SET NOCOUNT ON

SELECT P.ProductID,P.ProductName,PD.ProductDescription  FROM
Product P
INNER JOIN ProductDescription PD ON P.ProductID=PD.ProductID

END





----------------------------Creating Stored Procedure with Parameter ---------------
CREATE PROCEDURE GetProductDesc_withparameters
(@PID INT)
AS
BEGIN
SET NOCOUNT ON

SELECT P.ProductID,P.ProductName,PD.ProductDescription  FROM
Product P
INNER JOIN ProductDescription PD ON P.ProductID=PD.ProductID
WHERE P.ProductID=@PID

END








---------------------------Execute stored PROCEDURE -----------------------
EXEC GetProductDesc_withparameters 706 ----------with parameter








---------------------Last Session -------( Delete after copying) -------------
select * from [dbo].[Tickets]
select * from [dbo].[Managers]
select * from [dbo].[Employees]
select * from [dbo].[Junc_T_M]

update [dbo].[Tickets]
set FK_EmployeeID='e0369a10-996f-453b-b361-94c902507182'
where FK_EmployeeID='00000000-0000-0000-0000-000000000000';


truncate table [dbo].[Tickets]
truncate column where
FK_Employee =


SELECT TABLE_NAME,
       CONSTRAINT_TYPE,CONSTRAINT_NAME
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
WHERE TABLE_NAME='Tickets';

alter table [dbo].[Junc_T_M]
drop constraint FK_Junc_TicketID

alter table [dbo].[Tickets]
add FK__Tickets__EmployeeID Uniqueidentifier not null default newid() foreign key references Employees(EmployeeID)


--AZURE DEVOPS FULL ACCESS TOKEN: dll3qmh2jxkbmrp3zefz2uc6becihzl4b4nlth65h64ee3lwib5a
--Token2: k3nrlhbuslfoiwdqk5iagfyvxptfamzx2szfztfp2osi54d35rdq

--Creating the Ecommerce Tables Users, Products
CREATE TABLE Users(
PK_EmployeeID UNIQUEIDENTIFIER DEFAULT(NEWID()) NOT NULL primary key, --NEWID() function returns a GUID
Username NVARCHAR(50) UNIQUE NOT NULL,
Password NVARCHAR(50) not null,
Firstname NVARCHAR(50) NULL,
Lastname NVARCHAR(50) NULL,
Email NVARCHAR(100) not null,
Role NVARCHAR(20) NOT NULL,
SignUpDate DATETIME DEFAULT(getdate()) NOT NULL,
);

CREATE TABLE Products(
PK_ProductID UNIQUEIDENTIFIER DEFAULT(NEWID()) NOT NULL primary key, --NEWID() function returns a GUID
PublicID int  IDENTITY(906,37),
Title NVARCHAR(50) UNIQUE NOT NULL,
Description NVARCHAR(150)  not null,
Price smallmoney not NULL,
Inventory int  default(0) not NULL,
DateCreated datetime default(getdate()) not null,
CreatedBy NVARCHAR(50) foreign key references Users(Username) NOT NULL
);

Create Table ProductsOfOrders(
LinkID UNIQUEIDENTIFIER DEFAULT(NEWID()) NOT NULL primary key,
FK_OrderID UNIQUEIDENTIFIER foreign Key references Orders(PK_OrderID) not null,
FK_ProductID UNIQUEIDENTIFIER foreign Key references Products(PK_ProductID) not null,
);


CREATE TABLE Orders(
PK_OrderID UNIQUEIDENTIFIER DEFAULT(NEWID()) NOT NULL primary key, --NEWID() function returns a GUID
Firstname NVARCHAR(50) NOT NULL,
Lastname NVARCHAR(50) not null,
Email NVARCHAR(100) Not NULL,
StreetAddress NVARCHAR(100) Not Null,
City NVARCHAR(100) Not Null,
State NVARCHAR(100) Not Null,
Country NVARCHAR(100) Not Null,
AreaCode INT Not Null,
Total smallmoney not NULL,
DatePurchased datetime default(getdate()) not null,
Status NVARCHAR(20) Not Null
);




Create Table Profiles(
PK_ProfilesID UNIQUEIDENTIFIER DEFAULT(NEWID()) NOT NULL primary key, --NEWID() function returns a GUID
About Nvarchar(150) default('Empty') not null,
FK_Username nvarchar(50) foreign key references Users(Username)
);


---If System.InvalidOperationException: The ConnectionString property has not been initialized.
_dbString["ConnectionStrings:EcomProjectAPIDB"] --the connection string must be used without this keyword
this._dbString["ConnectionStrings:EcomProjectAPIDB"] --Causes
