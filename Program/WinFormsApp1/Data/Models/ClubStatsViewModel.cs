using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Data.Models
{
    public class ClubStatsViewModel
    {
        public string ClubName { get; set; }
        public int Matches { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsAllowed { get; set; }

        // Calculated Properties
        public string GoalsDisplay => $"{GoalsScored} : {GoalsAllowed}";
        public int Points => (Wins * 3) + (Draws * 1);
        public int GoalDifference => GoalsScored - GoalsAllowed;
    }
}