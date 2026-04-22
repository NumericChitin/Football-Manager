using System;

namespace WinFormsApp1.Data.Models
{
    public class MatchEventViewModel
    {
        public int EventId { get; set; }
        public string EventCategory { get; set; } // "Goal", "Foul", "Card"
        public string EventType { get; set; } // "Гол", "Жълт картон", "Червен картон", "Фал"
        public string ClubName { get; set; }
        public string PlayerName { get; set; }
        public int Minute { get; set; }
        public int PlayerId { get; set; }
        public int? ClubId { get; set; }
    }
}