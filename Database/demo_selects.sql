USE FootballManager
GO

--All clubs
SELECT ClubId, Name, City, Stadium FROM Clubs
ORDER BY Name
GO

--All players in a club
SELECT p.PlayerId, p.FullName, p.Position, p.Number, p.Nationality, p.Status FROM Players p
JOIN Clubs c ON p.ClubId = c.ClubId
WHERE c.ClubId = 1
ORDER BY p.Number
GO

--All matches
SELECT m.MatchId, l.Name AS League, l.Season, hc.Name AS HomeTeam,
	   ac.Name AS AwayTeam, m.Date, m.Round FROM Matches m
JOIN Leagues l ON m.LeagueId = l.LeagueId
JOIN Clubs hc ON m.HomeClubId = hc.ClubId
JOIN Clubs ac ON m.AwayClubId = ac.ClubId
ORDER BY m.Date
GO

--All goals in a match
SELECT g.Minute, p.FullName AS Scorer, c.Name AS Team FROM Goals g
JOIN Players p ON g.PlayerId = p.PlayerId
JOIN Clubs c ON g.ClubId = c.ClubId
WHERE g.MatchId = 1
ORDER BY g.Minute
GO

--All cards in a match
SELECT ca.Minute, ca.Type, p.FullName AS Player, c.Name AS Team FROM Cards ca
JOIN Players p ON ca.PlayerId = p.PlayerId
JOIN Clubs c ON ca.ClubId = c.ClubId
WHERE ca.MatchId = 1
ORDER BY ca.Minute
GO

--Number of goals of a team
SELECT c.Name AS Team, COUNT(g.GoalId) AS TotalGoals FROM Clubs c
LEFT JOIN Goals g ON c.ClubId = g.ClubId
WHERE c.ClubId = 1
GROUP BY c.Name
GO

--All fouls of a player
SELECT f.Minute, f.Type, m.Date AS MatchDate, hc.Name AS HomeTeam, ac.Name AS AwayTeam
FROM Fouls f
JOIN Matches m ON f.MatchId = m.MatchId
JOIN Clubs hc ON m.HomeClubId = hc.ClubId
JOIN Clubs ac ON m.AwayClubId = ac.ClubId
WHERE f.PlayerId = 3
ORDER BY m.Date, f.Minute
GO
