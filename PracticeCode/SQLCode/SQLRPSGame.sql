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