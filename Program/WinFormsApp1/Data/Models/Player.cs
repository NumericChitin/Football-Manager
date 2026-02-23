using System;
using System.Collections.Generic;

namespace WinFormsApp1.Data.Models;

public partial class Player
{
    public int PlayerId { get; set; }

    public string FullName { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public string Nationality { get; set; } = null!;

    public string Position { get; set; } = null!;

    public int Number { get; set; }

    public string DominantFoot { get; set; } = null!;

    public int ClubId { get; set; }

    public DateOnly DateOfContract { get; set; }

    public double Salary { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Card> Cards { get; set; } = new List<Card>();

    public virtual Club Club { get; set; } = null!;

    public virtual ICollection<Foul> Fouls { get; set; } = new List<Foul>();

    public virtual ICollection<Goal> Goals { get; set; } = new List<Goal>();

    public virtual ICollection<Transfer> Transfers { get; set; } = new List<Transfer>();
}
