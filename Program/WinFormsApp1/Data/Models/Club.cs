using System;
using System.Collections.Generic;

namespace WinFormsApp1.Data.Models;

public partial class Club
{
    public int ClubId { get; set; }

    public string Name { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Stadium { get; set; } = null!;

    public virtual ICollection<Card> Cards { get; set; } = new List<Card>();

    public virtual ICollection<Foul> Fouls { get; set; } = new List<Foul>();

    public virtual ICollection<Goal> Goals { get; set; } = new List<Goal>();

    public virtual ICollection<Match> MatchAwayClubs { get; set; } = new List<Match>();

    public virtual ICollection<Match> MatchHomeClubs { get; set; } = new List<Match>();

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();

    public virtual ICollection<Transfer> TransferClubFromNavigations { get; set; } = new List<Transfer>();

    public virtual ICollection<Transfer> TransferClubToNavigations { get; set; } = new List<Transfer>();

    public virtual ICollection<League> Leagues { get; set; } = new List<League>();
}
