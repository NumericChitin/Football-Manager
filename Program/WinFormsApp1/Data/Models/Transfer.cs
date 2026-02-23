using System;
using System.Collections.Generic;

namespace WinFormsApp1.Data.Models;

public partial class Transfer
{
    public int TransferId { get; set; }

    public int PlayerId { get; set; }

    public int ClubFrom { get; set; }

    public int ClubTo { get; set; }

    public DateOnly Date { get; set; }

    public string Type { get; set; } = null!;

    public string? Comment { get; set; }

    public virtual Club ClubFromNavigation { get; set; } = null!;

    public virtual Club ClubToNavigation { get; set; } = null!;

    public virtual Player Player { get; set; } = null!;
}
