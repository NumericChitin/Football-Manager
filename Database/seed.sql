USE FootballManager
GO

--Clubs data
INSERT INTO Clubs (Name, City, Stadium) VALUES
(N'FC Alpha', N'Alpha City', N'Alpha Stadium'),
(N'FC Beta', N'Beta City', N'Beta Arena'),
(N'FC Gamma', N'Gamma City', N'Gamma Park'),
(N'FC Delta', N'Delta City', N'Delta Stadium')
GO

--League data
INSERT INTO Leagues (Name, Season, NumberClubs)
VALUES (N'Premier League', N'2025/2026', 4)
GO

--LeagueTeams data
INSERT INTO LeagueTeams (LeagueId, ClubId) VALUES
(1, 1),
(1, 2),
(1, 3),
(1, 4)
GO

--Players data
INSERT INTO Players
(FullName, DateOfBirth, Nationality, Position, Number, DominantFoot, ClubId, DateOfContract, Salary, Status)
VALUES
(N'John Smith', '1998-05-12', N'England', N'Forward', 9, N'right', 1, '2024-07-01', 50000, N'active'),
(N'Michael Brown', '2000-03-21', N'England', N'Midfielder', 8, N'left', 1, '2024-07-01', 45000, N'active'),

(N'David Miller', '1996-11-10', N'Spain', N'Defender', 4, N'right', 2, '2023-07-01', 48000, N'active'),
(N'Carlos Gomez', '2002-02-14', N'Spain', N'Forward', 11, N'left', 2, '2024-01-01', 52000, N'active'),

(N'Alex Rossi', '1999-07-30', N'Italy', N'Midfielder', 10, N'right', 3, '2024-07-01', 47000, N'active'),
(N'Luca Bianchi', '2001-09-18', N'Italy', N'Defender', 5, N'left', 3, '2024-07-01', 44000, N'active'),

(N'Mark Novak', '1997-04-03', N'Croatia', N'Forward', 7, N'right', 4, '2023-07-01', 51000, N'active'),
(N'Ivan Horvat', '2003-06-22', N'Croatia', N'Midfielder', 6, N'left', 4, '2024-07-01', 43000, N'active'),

(N'Tom Young', '2004-08-15', N'England', N'Defender', 2, N'right', 1, '2025-01-01', 30000, N'active'),
(N'Pedro Silva', '1995-12-01', N'Portugal', N'Goalkeeper', 1, N'right', 2, '2023-07-01', 55000, N'active')
GO

--Matches data
INSERT INTO Matches (LeagueId, HomeClubId, AwayClubId, Date, Round)
VALUES
(1, 1, 2, '2025-08-15', 1),
(1, 3, 4, '2025-08-16', 1)
GO

--Goals data
INSERT INTO Goals (Minute, PlayerId, MatchId) VALUES
(23, 1, 1),
(45, 4, 1),
(67, 5, 2),
(89, 7, 2)
GO

--Cards data
INSERT INTO Cards (Type, Minute, PlayerId, MatchId) VALUES
(N'yellow', 30, 2, 1),
(N'red', 78, 3, 1),
(N'yellow', 55, 6, 2)
GO

--Fouls data
INSERT INTO Fouls (Minute, PlayerId, MatchId, Type) VALUES
(12, 1, 1, N'handball'),
(40, 3, 1, N'tackle'),
(60, 5, 2, N'push'),
(75, 8, 2, N'trip')
GO

--Users data
INSERT INTO Users (UserName, Type, Password) VALUES
(N'SystemAdmin', N'admin', N'qwerty123456789')
GO
