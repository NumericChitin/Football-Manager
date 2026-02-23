using System;
using System.Collections.Generic;

namespace WinFormsApp1.Data.Models;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Password { get; set; } = null!;
}
