CREATE DATABASE FootballManager
GO

USE FootballManager
GO

--1 clubs
CREATE TABLE Clubs (
ClubId INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
Name NVARCHAR(64) UNIQUE NOT NULL,
City NVARCHAR(64) NOT NULL,
Stadium NVARCHAR(64) NOT NULL
)
GO

--2 players
CREATE TABLE Players (
PlayerId INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
FullName NVARCHAR(64) NOT NULL,
DateOfBirth DATE NOT NULL,
Nationality NVARCHAR(64) NOT NULL,
Position NVARCHAR(32) NOT NULL,
Number INT NOT NULL,
DominantFoot NVARCHAR(16) NOT NULL CHECK(DominantFoot = N'left' OR DominantFoot = N'right'),
ClubId INT NOT NULL,
DateOfContract DATE NOT NULL,
Salary FLOAT NOT NULL,
Status NVARCHAR(16) NOT NULL CHECK (Status = N'active' OR Status = N'hurt' OR
									Status = N'punished' OR Status = N'free agent')
CONSTRAINT FK_Players_Clubs_ClubId FOREIGN KEY(ClubID) REFERENCES Clubs(ClubId)
)
GO

--3 leagues
CREATE TABLE Leagues (
LeagueId INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
Name NVARCHAR(64) NOT NULL,
Season NVARCHAR(16) NOT NULL, -- e.g. 2025/2026
NumberClubs INT NOT NULL
)
GO

--4 league teams
CREATE TABLE LeagueTeams (
LeagueId INT NOT NULL,
ClubId INT NOT NULL,
CONSTRAINT PK_LeagueTeams PRIMARY KEY (LeagueId, ClubId),
CONSTRAINT FK_LeagueTeams_Leagues_LeagueId FOREIGN KEY (LeagueId) REFERENCES Leagues(LeagueId),
CONSTRAINT FK_LeagueTeams_Clubs_ClubId FOREIGN KEY (ClubId) REFERENCES Clubs(ClubId)
)
GO

--5 transfers
CREATE TABLE Transfers (
TransferId INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
PlayerId INT NOT NULL,
ClubFrom INT NOT NULL,
ClubTo INT NOT NULL,
Date DATE NOT NULL,
Type NVARCHAR(16) NOT NULL CHECK (Type = N'permanent' OR Type = N'temporary'),
Comment NVARCHAR(255),
CONSTRAINT FK_Transfers_Players_PlayerId FOREIGN KEY (PlayerId) REFERENCES Players(PlayerId),
CONSTRAINT FK_Transfers_Clubs_ClubFrom FOREIGN KEY (ClubFrom) REFERENCES Clubs(ClubId),
CONSTRAINT FK_Transfers_Clubs_ClubTo FOREIGN KEY (ClubTo) REFERENCES Clubs(ClubId),
CONSTRAINT CK_Transfers_ClubFrom_ClubTo CHECK (ClubFrom <> ClubTo)
)
GO


--6 matches
CREATE TABLE Matches (
MatchId INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
LeagueId INT NOT NULL,
HomeClubId INT NOT NULL,
AwayClubId INT NOT NULL,
Date DATE NOT NULL,
Round INT NOT NULL,
CONSTRAINT FK_Matches_Leagues_LeagueId FOREIGN KEY (LeagueId) REFERENCES Leagues(LeagueId),
CONSTRAINT FK_Matches_Clubs_HomeClub FOREIGN KEY (HomeClubId) REFERENCES Clubs(ClubId),
CONSTRAINT FK_Matches_Clubs_AwayClub FOREIGN KEY (AwayClubId) REFERENCES Clubs(ClubId),
CONSTRAINT CK_Matches_Home_Away CHECK (HomeClubId <> AwayClubId)
)
GO


--7 goals
CREATE TABLE Goals (
GoalId INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
Minute INT NOT NULL CHECK (Minute >= 1 AND Minute <= 120),
PlayerId INT NOT NULL,
ClubId INT NULL,
MatchId INT NOT NULL,
CONSTRAINT FK_Goals_Players_PlayerId FOREIGN KEY (PlayerId) REFERENCES Players(PlayerId),
CONSTRAINT FK_Goals_Clubs_ClubId FOREIGN KEY (ClubId) REFERENCES Clubs(ClubId),
CONSTRAINT FK_Goals_Matches_MatchId FOREIGN KEY (MatchId) REFERENCES Matches(MatchId)
)
GO


--8 cards
CREATE TABLE Cards (
CardId INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
Type NVARCHAR(16) NOT NULL CHECK (Type = N'yellow' OR Type = N'red'),
Minute INT NOT NULL CHECK (Minute >= 1 AND Minute <= 120),
PlayerId INT NOT NULL,
ClubId INT NULL,
MatchId INT NOT NULL,
CONSTRAINT FK_Cards_Players_PlayerId FOREIGN KEY (PlayerId) REFERENCES Players(PlayerId),
CONSTRAINT FK_Cards_Matches_MatchId FOREIGN KEY (MatchId) REFERENCES Matches(MatchId),
CONSTRAINT FK_Cards_Clubs_ClubId FOREIGN KEY (ClubId) REFERENCES Clubs(ClubId)
)
GO


--9 fouls
CREATE TABLE Fouls (
FoulId INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
Minute INT NOT NULL CHECK (Minute >= 1 AND Minute <= 120),
PlayerId INT NOT NULL,
ClubId INT NULL,
MatchId INT NOT NULL,
Type NVARCHAR(64),
CONSTRAINT FK_Fouls_Players_PlayerId FOREIGN KEY (PlayerId) REFERENCES Players(PlayerId),
CONSTRAINT FK_Fouls_Matches_MatchId FOREIGN KEY (MatchId) REFERENCES Matches(MatchId),
CONSTRAINT FK_Fouls_Clubs_ClubId FOREIGN KEY (ClubId) REFERENCES Clubs(ClubId)
)
GO

--10 users
CREATE TABLE Users (
UserId INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
UserName NVARCHAR(32) UNIQUE NOT NULL,
Type NVARCHAR(16) NOT NULL CHECK(Type = N'Admin' OR Type = N'referee' OR Type = N'User'),
Password NVARCHAR(32) NOT NULL
)
GO

--Preventing goals for players not in a match
CREATE TRIGGER TR_Goals_PlayerClubValidation
ON Goals
AFTER INSERT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN Players p ON i.PlayerId = p.PlayerId
        JOIN Matches m ON i.MatchId = m.MatchId
        WHERE p.ClubId NOT IN (m.HomeClubId, m.AwayClubId)
    )
    BEGIN
        RAISERROR ('Player does not belong to either team in this match.', 16, 1)
        ROLLBACK TRANSACTION
    END
END
GO

--Preventing cards for players not in a match
CREATE TRIGGER TR_Cards_PlayerClubValidation
ON Cards
AFTER INSERT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN Players p ON i.PlayerId = p.PlayerId
        JOIN Matches m ON i.MatchId = m.MatchId
        WHERE p.ClubId NOT IN (m.HomeClubId, m.AwayClubId)
    )
    BEGIN
        RAISERROR ('Player does not belong to either team in this match.', 16, 1)
        ROLLBACK TRANSACTION
    END
END
GO

--Preventing fouls for players not in a match
CREATE TRIGGER TR_Fouls_PlayerClubValidation
ON Fouls
AFTER INSERT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN Players p ON i.PlayerId = p.PlayerId
        JOIN Matches m ON i.MatchId = m.MatchId
        WHERE p.ClubId NOT IN (m.HomeClubId, m.AwayClubId)
    )
    BEGIN
        RAISERROR ('Player does not belong to either team in this match.', 16, 1)
        ROLLBACK TRANSACTION
    END
END
GO

--Auto-assign club in Goals from player
CREATE TRIGGER TR_Goals_AutoAssignClub
ON Goals
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM inserted WHERE ClubId IS NOT NULL)
    BEGIN
        RAISERROR ('ClubId is automatically assigned and must not be provided.', 16, 1)
        ROLLBACK TRANSACTION
        RETURN
    END

    INSERT INTO Goals (Minute, PlayerId, ClubId, MatchId)
    SELECT
        i.Minute,
        i.PlayerId,
        p.ClubId,
        i.MatchId
    FROM inserted i
    JOIN Players p ON i.PlayerId = p.PlayerId
END
GO

--Auto-assign club in Cards from player
CREATE TRIGGER TR_Cards_AutoAssignClub
ON Cards
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM inserted WHERE ClubId IS NOT NULL)
    BEGIN
        RAISERROR ('ClubId is automatically assigned and must not be provided.', 16, 1)
        ROLLBACK TRANSACTION
        RETURN
    END

    INSERT INTO Cards (Type, Minute, PlayerId, ClubId, MatchId)
    SELECT
        i.Type,
        i.Minute,
        i.PlayerId,
        p.ClubId,
        i.MatchId
    FROM inserted i
    JOIN Players p ON i.PlayerId = p.PlayerId
END
GO

--Auto-assign club in Fouls from player
CREATE TRIGGER TR_Fouls_AutoAssignClub
ON Fouls
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM inserted WHERE ClubId IS NOT NULL)
    BEGIN
        RAISERROR ('ClubId is automatically assigned and must not be provided.', 16, 1)
        ROLLBACK TRANSACTION
        RETURN
    END

    INSERT INTO Fouls (Minute, PlayerId, ClubId, MatchId, Type)
    SELECT
        i.Minute,
        i.PlayerId,
        p.ClubId,
        i.MatchId,
        i.Type
    FROM inserted i
    JOIN Players p ON i.PlayerId = p.PlayerId
END
GO

--Validate age in Players (DateOfBirth)
CREATE TRIGGER TR_Players_ValidateAge
ON Players
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        WHERE
            DATEDIFF(YEAR, i.DateOfBirth, GETDATE())
            - CASE
                WHEN DATEADD(YEAR, DATEDIFF(YEAR, i.DateOfBirth, GETDATE()), i.DateOfBirth) > GETDATE()
                THEN 1
                ELSE 0
              END
            NOT BETWEEN 14 AND 50
    )
    BEGIN
        RAISERROR ('Player age must be between 14 and 50 years (inclusive).', 16, 1)
        ROLLBACK TRANSACTION
    END
END
GO
