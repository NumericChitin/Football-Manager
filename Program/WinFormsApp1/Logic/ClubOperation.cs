using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Data.Models;

namespace WinFormsApp1.Logic
{
    public class ClubOperation : BaseOperation<Club>
    {
        public bool DuplicateExists(Club club)
        {
            if (string.IsNullOrWhiteSpace(club.Name))
                return false;

            string name = club.Name.Trim();

            return Set.Local.Any(c =>
                !ReferenceEquals(c, club) &&
                c.ClubId != club.ClubId && // extra safety
                string.Equals(c.Name?.Trim(), name, StringComparison.OrdinalIgnoreCase));
        }

        public bool Validate(Club club, out string error)
        {
            if (string.IsNullOrWhiteSpace(club.Name) ||
                string.IsNullOrWhiteSpace(club.City) ||
                string.IsNullOrWhiteSpace(club.Stadium))
            {
                error = "Име, град и стадион са задължителни!";
                return false;
            }

            if (DuplicateExists(club))
            {
                error = "Има клуб със същото име!";
                return false;
            }

            error = null;
            return true;
        }
    }

}
