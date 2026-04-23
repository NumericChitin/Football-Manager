using System;
using System.Collections.Generic;

namespace WinFormsApp1.Data.Models;

public partial class Match
{
    public int MatchId { get; set; }

    public int LeagueId { get; set; }

    public int HomeClubId { get; set; }

    public int AwayClubId { get; set; }

    public DateOnly Date { get; set; }

    public int Round { get; set; }

    public virtual Club AwayClub { get; set; } = null!;

    public virtual ICollection<Card> Cards { get; set; } = new List<Card>();

    public virtual ICollection<Foul> Fouls { get; set; } = new List<Foul>();

    public virtual ICollection<Goal> Goals { get; set; } = new List<Goal>();

    public virtual Club HomeClub { get; set; } = null!;

    public virtual League League { get; set; } = null!;

    public string HomeClubName => HomeClub?.Name;

    public string AwayClubName => AwayClub?.Name;

    public string Result
    {
        get
        {
            // Safety check: if Goals is null, return 0:0
            if (Goals == null) return "0:0";

            // Compare by ClubId for better reliability
            int homeGoals = Goals.Count(g => g.ClubId == HomeClubId);
            int awayGoals = Goals.Count(g => g.ClubId == AwayClubId);

            return $"{homeGoals}:{awayGoals}";
        }
    }
}
