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
}
