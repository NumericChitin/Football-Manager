using Microsoft.EntityFrameworkCore;
using WinFormsApp1.Data.Models;

namespace WinFormsApp1.Logic
{
    public class TransferOperation : BaseOperation<Transfer>
    {
        public IQueryable<Transfer> GetFiltered(
            int playerId,
            int clubFromId,
            int clubToId,
            DateOnly startDate,
            DateOnly endDate)
        {
            var query = db.Transfers
                .Include(t => t.Player)
                .Include(t => t.ClubFromNavigation)
                .Include(t => t.ClubToNavigation)
                .AsQueryable();

            if (playerId != 0)
                query = query.Where(t => t.PlayerId == playerId);

            if (clubFromId != 0)
                query = query.Where(t => t.ClubFrom == clubFromId);

            if (clubToId != 0)
                query = query.Where(t => t.ClubTo == clubToId);

            query = query.Where(t => t.Date >= startDate && t.Date <= endDate);

            return query;
        }

        public List<Transfer> GetFilteredList(int playerId, int clubFromId, int clubToId, DateOnly start, DateOnly end)
        {
            return GetFiltered(playerId, clubFromId, clubToId, start, end).ToList();
        }

        public List<Transfer> ApplyFilters(
            int playerId,
            int clubFromId,
            int clubToId,
            DateOnly startDate,
            DateOnly endDate)
        {
            return GetFiltered(playerId, clubFromId, clubToId, startDate, endDate)
                .ToList();
        }

        public bool TransferExists(int transferId)
            => db.Transfers.Any(t => t.TransferId == transferId);

        public void ApplyTransferEffects(Transfer transfer)
        {
            var player = db.Players.Find(transfer.PlayerId);
            if (player != null)
                player.ClubId = transfer.ClubTo;
        }

        public bool ValidateTransfer(Transfer t, out string error)
        {
            if (t.PlayerId == 0 || t.ClubFrom == 0 || t.ClubTo == 0 || string.IsNullOrWhiteSpace(t.Type))
            {
                error = "Всички полета са задължителни!";
                return false;
            }

            if (t.ClubFrom == t.ClubTo)
            {
                error = "Клубът 'от' и 'до' трябва да са различни!";
                return false;
            }

            if (t.Date > DateOnly.FromDateTime(DateTime.Today))
            {
                error = "Датата на трансфера не може да бъде в бъдещето!";
                return false;
            }

            error = null;
            return true;
        }
    }
}