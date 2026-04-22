using System.Collections.Generic;
using System.Linq;
using WinFormsApp1.Data.Models;
using WinFormsApp1.Logic;

namespace WinFormsApp1.Business
{
    public class MatchOperations : BaseOperation<Match>
    {
        // Get all leagues for the dropdown
        public List<League> GetLeagues()
        {
            return Context.Leagues.ToList(); // Assuming a Leagues DbSet exists
        }

        // Get clubs for the home/away dropdowns
        public List<Club> GetClubs()
        {
            return Context.Clubs.ToList();
        }

        // Get matches for the selected league
        public List<Match> GetMatches(int leagueId)
        {
            return Context.Matches
                .Where(m => m.LeagueId == leagueId) // Assuming Match has LeagueId
                .ToList();
        }

        public void AddOrUpdateMatch(Match match)
        {
            if (match.MatchId == 0)
            {
                Context.Matches.Add(match);
            }
            else
            {
                Context.Matches.Update(match);
            }
            Context.SaveChanges();
        }

        public void DeleteMatch(int matchId)
        {
            var match = Context.Matches.Find(matchId);
            if (match != null)
            {
                Context.Matches.Remove(match);
                Context.SaveChanges();
            }
        }

        // Unifies Goals, Fouls, and Cards into a single list for the DataGridView
        public List<MatchEventViewModel> GetMatchEvents(int matchId)
        {
            var events = new List<MatchEventViewModel>();

            var goals = Context.Goals.Where(g => g.MatchId == matchId).Select(g => new MatchEventViewModel
            {
                EventId = g.GoalId,
                EventCategory = "Goal",
                EventType = "Гол",
                Minute = g.Minute,
                PlayerName = g.Player.FullName,
                ClubName = g.Club.Name,
                PlayerId = g.PlayerId,
                ClubId = g.ClubId
            });

            var fouls = Context.Fouls.Where(f => f.MatchId == matchId).Select(f => new MatchEventViewModel
            {
                EventId = f.FoulId,
                EventCategory = "Foul",
                EventType = "Фал",
                Minute = f.Minute,
                PlayerName = f.Player.FullName,
                ClubName = f.Club.Name,
                PlayerId = f.PlayerId,
                ClubId = f.ClubId
            });

            var cards = Context.Cards.Where(c => c.MatchId == matchId).Select(c => new MatchEventViewModel
            {
                EventId = c.CardId,
                EventCategory = "Card",
                EventType = c.Type == "Yellow" ? "Жълт картон" : "Червен картон",
                Minute = c.Minute,
                PlayerName = c.Player.FullName,
                ClubName = c.Club.Name,
                PlayerId = c.PlayerId,
                ClubId = c.ClubId
            });

            events.AddRange(goals);
            events.AddRange(fouls);
            events.AddRange(cards);

            return events.OrderBy(e => e.Minute).ToList();
        }

        public void DeleteEvent(string category, int eventId)
        {
            if (category == "Goal") { var g = Context.Goals.Find(eventId); if (g != null) Context.Goals.Remove(g); }
            else if (category == "Foul") { var f = Context.Fouls.Find(eventId); if (f != null) Context.Fouls.Remove(f); }
            else if (category == "Card") { var c = Context.Cards.Find(eventId); if (c != null) Context.Cards.Remove(c); }

            Context.SaveChanges();
        }

        // Example method to add an event. You will need the specific entity classes initialized here.
        public void AddEvent(string type, int matchId, int minute, int playerId, int clubId)
        {
            if (type == "Гол") Context.Goals.Add(new Goal { MatchId = matchId, Minute = minute, PlayerId = playerId, ClubId = clubId });
            else if (type == "Фал") Context.Fouls.Add(new Foul { MatchId = matchId, Minute = minute, PlayerId = playerId, ClubId = clubId });
            else if (type == "Жълт картон" || type == "Червен картон")
                Context.Cards.Add(new Card { MatchId = matchId, Minute = minute, PlayerId = playerId, ClubId = clubId, Type = type == "Жълт картон" ? "Yellow" : "Red" });

            Context.SaveChanges();
        }

        public List<Player> GetPlayersByClub(int clubId)
        {
            // Returns only players belonging to the specific club
            return Context.Players
                .Where(p => p.ClubId == clubId)
                .ToList();
        }
    }
}