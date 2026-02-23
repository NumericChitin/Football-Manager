using System;
using System.Collections.Generic;

namespace WinFormsApp1.Data.Models;

public partial class Card
{
    public int CardId { get; set; }

    public string Type { get; set; } = null!;

    public int Minute { get; set; }

    public int PlayerId { get; set; }

    public int? ClubId { get; set; }

    public int MatchId { get; set; }

    public virtual Club? Club { get; set; }

    public virtual Match Match { get; set; } = null!;

    public virtual Player Player { get; set; } = null!;
}
