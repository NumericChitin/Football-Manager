using System;
using System.Collections.Generic;

namespace WinFormsApp1.Data.Models;

public partial class League
{
    public int LeagueId { get; set; }

    public string Name { get; set; } = null!;

    public string Season { get; set; } = null!;

    public int NumberClubs { get; set; }

    public virtual ICollection<Match> Matches { get; set; } = new List<Match>();

    public virtual ICollection<Club> Clubs { get; set; } = new List<Club>();
}
