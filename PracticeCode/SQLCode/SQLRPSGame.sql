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

CREATE TABLE Managers(
ManagerID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT(NEWID()) NOT NULL,
MFname NVARCHAR(50) NULL,
MLname NVARCHAR(50) NULL,
MFUsername NVARCHAR(30) UNIQUE NOT NULL,
MFPassword NVARCHAR(50) NOT NULL
--FK_TicketID UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Ticket(TicketID) NULL
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
