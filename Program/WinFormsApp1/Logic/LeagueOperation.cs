using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Linq;
using WinFormsApp1.Data.Models;

namespace WinFormsApp1.Logic
{
    public class LeagueOperation : BaseOperation<League>
    {
        public LeagueOperation() : base()
        {
            // Eagerly load the related entities into the local context tracking
            db.Leagues.Include(l => l.Clubs).Load();
            db.Clubs.Load();
            db.Matches.Include(m => m.HomeClub).Include(m => m.AwayClub).Load();
        }

        // Returns a tuple with validation success status and an error message if it fails
        public (bool IsValid, string ErrorMessage) ValidateLeague(string name, string season, int currentLeagueId = 0)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(season))
                return (false, "Името на лигата и сезонът са задължителни.");

            if (!System.Text.RegularExpressions.Regex.IsMatch(season, @"^\d{4}/\d{4}$"))
                return (false, "Сезонът трябва да е във формат yyyy/yyyy.");

            bool exists = Set.Any(l => l.Name == name && l.Season == season && l.LeagueId != currentLeagueId);
            if (exists)
                return (false, "Вече съществува лига със същото име и сезон.");

            return (true, string.Empty);
        }

        public bool CanDeleteLeague(League league)
        {
            return !db.Matches.Any(m => m.LeagueId == league.LeagueId);
        }

        public void DeleteLeague(League league)
        {
            league.Clubs.Clear(); // Clears the mapping table relationships
            Remove(league);
        }

        public bool CanRemoveClub(League league, Club club)
        {
            return !db.Matches.Any(m =>
                m.LeagueId == league.LeagueId &&
                (m.HomeClubId == club.ClubId || m.AwayClubId == club.ClubId));
        }

        public List<Club> GetAvailableClubs(League league)
        {
            var leagueClubIds = league.Clubs.Select(lc => lc.ClubId).ToList();
            return db.Clubs.Where(c => !leagueClubIds.Contains(c.ClubId)).ToList();
        }

        public BindingList<Match> GetMatchesForLeague(int leagueId)
        {
            return new BindingList<Match>(
                db.Matches.Local.Where(m => m.LeagueId == leagueId).ToList()
            );
        }

        public (bool Success, string ErrorMessage) GenerateMatches(League league)
        {
            if (league.Clubs.Count < 2)
                return (false, "Лигата трябва да има поне 2 клуба.");

            if (db.Matches.Any(m => m.LeagueId == league.LeagueId))
                return (false, "Мачовете за тази лига вече са генерирани.");

            var clubs = league.Clubs.ToList();

            for (int i = 0; i < clubs.Count; i++)
            {
                for (int j = i + 1; j < clubs.Count; j++)
                {
                    var clubA = clubs[i];
                    var clubB = clubs[j];

                    // Match 1
                    db.Matches.Add(new Match
                    {
                        LeagueId = league.LeagueId,
                        HomeClubId = clubA.ClubId,
                        AwayClubId = clubB.ClubId,
                        Round = 1
                    });

                    // Match 2 (reverse)
                    db.Matches.Add(new Match
                    {
                        LeagueId = league.LeagueId,
                        HomeClubId = clubB.ClubId,
                        AwayClubId = clubA.ClubId,
                        Round = 2
                    });
                }
            }

            return (true, string.Empty);
        }
    }
}