using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WinFormsApp1.Data;
using WinFormsApp1.Data.Models;

namespace WinFormsApp1.Business
{
    public class StatsOperation
    {
        public StatsOperation()
        {
            string connString = Program.Configuration.GetConnectionString("FootballManagerDb");
            Context = new FootballManagerContext(connString);
        }

        private FootballManagerContext Context;

        public List<League> GetAllLeagues() => Context.Leagues.ToList();

        public List<ClubStatsViewModel> GetLeagueTable(int leagueId)
        {
            var league = Context.Leagues
                .Include(l => l.Clubs)
                .Include(l => l.Matches).ThenInclude(m => m.Goals)
                .Include(l => l.Matches).ThenInclude(m => m.Cards)
                .Include(l => l.Matches).ThenInclude(m => m.Fouls)
                .FirstOrDefault(l => l.LeagueId == leagueId);

            if (league == null) return new List<ClubStatsViewModel>();

            var statsList = new List<ClubStatsViewModel>();

            foreach (var club in league.Clubs)
            {
                var clubStats = new ClubStatsViewModel { ClubName = club.Name };

                // A match is "played" if it has any events (Goals, Cards, or Fouls)
                var playedMatches = league.Matches.Where(m =>
                    (m.HomeClubId == club.ClubId || m.AwayClubId == club.ClubId) &&
                    (m.Goals.Any() || m.Cards.Any() || m.Fouls.Any())).ToList();

                foreach (var match in playedMatches)
                {
                    clubStats.Matches++;

                    int homeGoals = match.Goals.Count(g => g.ClubId == match.HomeClubId);
                    int awayGoals = match.Goals.Count(g => g.ClubId == match.AwayClubId);

                    bool isHome = match.HomeClubId == club.ClubId;
                    int scored = isHome ? homeGoals : awayGoals;
                    int allowed = isHome ? awayGoals : homeGoals;

                    clubStats.GoalsScored += scored;
                    clubStats.GoalsAllowed += allowed;

                    if (scored > allowed) clubStats.Wins++;
                    else if (scored == allowed) clubStats.Draws++;
                    else clubStats.Losses++;
                }
                statsList.Add(clubStats);
            }

            // Sorting: Points DESC -> Goal Difference DESC -> Goals Scored DESC
            return statsList
                .OrderByDescending(s => s.Points)
                .ThenByDescending(s => s.GoalDifference)
                .ThenByDescending(s => s.GoalsScored)
                .ToList();
        }
    }
}