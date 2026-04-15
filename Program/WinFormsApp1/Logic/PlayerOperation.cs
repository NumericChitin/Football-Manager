using System;
using System.Linq;
using WinFormsApp1.Data.Models;

namespace WinFormsApp1.Logic
{
    public class PlayerOperation : BaseOperation<Player>
    {
        public bool DuplicateExists(Player player, string name, int clubId)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            name = name.Trim();

            return Set.Local.Any(p =>
                !ReferenceEquals(p, player) &&
                p.PlayerId != player.PlayerId &&
                string.Equals(p.FullName?.Trim(), name, StringComparison.OrdinalIgnoreCase) &&
                p.ClubId == clubId);
        }

        public bool Validate(Player player, out string error)
        {
            if (string.IsNullOrWhiteSpace(player.FullName) ||
                string.IsNullOrWhiteSpace(player.Nationality) ||
                string.IsNullOrWhiteSpace(player.Position) ||
                string.IsNullOrWhiteSpace(player.DominantFoot) ||
                string.IsNullOrWhiteSpace(player.Status))
            {
                error = "Всички полета са задължителни!";
                return false;
            }

            if (player.Number <= 0)
            {
                error = "Номерът трябва да е валиден!";
                return false;
            }

            if (player.Salary < 0)
            {
                error = "Заплатата не може да е отрицателна!";
                return false;
            }

            var age = CalculateAge(player.DateOfBirth);

            if (age < 14 || age > 50)
            {
                error = "Възрастта трябва да бъде между 14 и 50 години!";
                return false;
            }

            error = null;
            return true;
        }

        private int CalculateAge(DateOnly birthDate)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            int age = today.Year - birthDate.Year;

            if (birthDate > today.AddYears(-age))
                age--;

            return age;
        }
    }
}