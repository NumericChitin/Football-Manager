using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Data.Models;

namespace WinFormsApp1
{
    public partial class TransfersForm : Form
    {
        private FootballManagerContext _db;

        public TransfersForm()
        {
            InitializeComponent();
        }

        private void TransfersForm_Load(object sender, EventArgs e)
        {
            string connString = Program.Configuration.GetConnectionString("FootballManagerDb");

            _db = new FootballManagerContext(connString);

            _db.Players.Load();
            _db.Clubs.Load();
            _db.Transfers.Load();

            transferBindingSource.DataSource = _db.Transfers.Local.ToBindingList();

            // Player combobox (normal)
            comboBoxPlayer.DataSource = _db.Players.Local.ToList();
            comboBoxPlayer.DisplayMember = "FullName";
            comboBoxPlayer.ValueMember = "PlayerId";

            // FILTER PLAYER (add empty option)
            var playersFilter = _db.Players.Local.ToList();
            playersFilter.Insert(0, new Player { PlayerId = 0, FullName = "" });

            comboBoxFilterByPlayer.DataSource = playersFilter;
            comboBoxFilterByPlayer.DisplayMember = "FullName";
            comboBoxFilterByPlayer.ValueMember = "PlayerId";

            // Clubs
            comboBoxClubFrom.DataSource = _db.Clubs.Local.ToList();
            comboBoxClubFrom.DisplayMember = "Name";
            comboBoxClubFrom.ValueMember = "ClubId";

            comboBoxClubTo.DataSource = _db.Clubs.Local.ToList();
            comboBoxClubTo.DisplayMember = "Name";
            comboBoxClubTo.ValueMember = "ClubId";

            // FILTER CLUBS (add empty option)
            var clubsFilterFrom = _db.Clubs.Local.ToList();
            clubsFilterFrom.Insert(0, new Club { ClubId = 0, Name = "" });

            comboBoxFilterByClubFrom.DataSource = clubsFilterFrom;
            comboBoxFilterByClubFrom.DisplayMember = "Name";
            comboBoxFilterByClubFrom.ValueMember = "ClubId";

            var clubsFilterTo = _db.Clubs.Local.ToList();
            clubsFilterTo.Insert(0, new Club { ClubId = 0, Name = "" });

            comboBoxFilterByClubTo.DataSource = clubsFilterTo;
            comboBoxFilterByClubTo.DisplayMember = "Name";
            comboBoxFilterByClubTo.ValueMember = "ClubId";

            comboBoxPlayer.SelectedIndexChanged += ComboBoxPlayer_SelectedIndexChanged;

            comboBoxTransferType.Items.AddRange(new[] { "постоянен", "временен" });

            // DEFAULT FILTER DATES
            dateTimePickerFilterByDateStart.Value = new DateTime(1753, 1, 1);
            dateTimePickerFilterByDateEnd.Value = DateTime.Today;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _db?.Dispose();
            base.OnFormClosed(e);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!_db.Players.Any() || !_db.Clubs.Any())
            {
                MessageBox.Show("Няма налични играчи или клубове!");
                return;
            }

            var newTransfer = new Transfer
            {
                PlayerId = (int)comboBoxPlayer.SelectedValue,
                ClubFrom = (int)comboBoxClubFrom.SelectedValue,
                ClubTo = (int)comboBoxClubTo.SelectedValue,
                Date = DateOnly.FromDateTime(dateTimePickerTransferDate.Value),
                Type = comboBoxTransferType.SelectedItem?.ToString(),
                Comment = textBoxComment.Text.Trim()
            };

            _db.Transfers.Add(newTransfer);

            transferBindingSource.ResetBindings(false);

            int index = transferBindingSource.IndexOf(newTransfer);

            if (index >= 0)
            {
                dataGridView1.ClearSelection();
                dataGridView1.Rows[index].Selected = true;
                dataGridView1.CurrentCell = dataGridView1.Rows[index].Cells[0];
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;

            var transfer = dataGridView1.CurrentRow.DataBoundItem as Transfer;
            if (transfer == null)
                return;

            // Check if this transfer already exists in DB
            bool exists = _db.Transfers.AsNoTracking()
                .Any(t => t.TransferId == transfer.TransferId);

            if (exists)
            {
                MessageBox.Show("Редактирането на съществуващи трансфери не е позволено.");
                return;
            }

            if (!ValidateTransfers())
                return;

            try
            {
                transfer.PlayerId = (int)comboBoxPlayer.SelectedValue;
                transfer.ClubFrom = (int)comboBoxClubFrom.SelectedValue;
                transfer.ClubTo = (int)comboBoxClubTo.SelectedValue;

                transfer.Date = DateOnly.FromDateTime(dateTimePickerTransferDate.Value);
                transfer.Type = comboBoxTransferType.SelectedItem?.ToString();
                transfer.Comment = textBoxComment.Text.Trim();

                // Update player's club ONLY for new transfers
                var player = _db.Players.Find(transfer.PlayerId);
                if (player != null)
                {
                    player.ClubId = transfer.ClubTo;
                }

                _db.SaveChanges();

                transferBindingSource.ResetBindings(false);

                MessageBox.Show("Трансферът беше запазен!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при запис:\n" + ex.Message);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ResetFilters();
            ApplyFilters();
        }

        private bool ValidateTransfers()
        {
            if (comboBoxPlayer.SelectedItem == null ||
                comboBoxClubFrom.SelectedItem == null ||
                comboBoxClubTo.SelectedItem == null ||
                comboBoxTransferType.SelectedItem == null)
            {
                MessageBox.Show("Всички полета са задължителни!");
                return false;
            }

            int clubFrom = (int)comboBoxClubFrom.SelectedValue;
            int clubTo = (int)comboBoxClubTo.SelectedValue;

            if (clubFrom == clubTo)
            {
                MessageBox.Show("Клубът 'от' и 'до' трябва да са различни!");
                return false;
            }

            if (dateTimePickerTransferDate.Value.Date > DateTime.Today)
            {
                MessageBox.Show("Датата на трансфера не може да бъде в бъдещето!");
                return false;
            }

            return true;
        }

        //Method now obsolete
        //private void LoadSelectedTransferToInputs()
        //{
        //    if (dataGridView1.CurrentRow == null)
        //        return;

        //    var transfer = dataGridView1.CurrentRow.DataBoundItem as Transfer;
        //    if (transfer == null)
        //        return;

        //    var entry = _db.Entry(transfer);

        //    // Do NOT load existing transfers
        //    if (entry.State != EntityState.Added)
        //        return;

        //    comboBoxPlayer.SelectedValue = transfer.PlayerId;
        //    comboBoxClubFrom.SelectedValue = transfer.ClubFrom;
        //    comboBoxClubTo.SelectedValue = transfer.ClubTo;

        //    dateTimePickerTransferDate.Value = transfer.Date.ToDateTime(TimeOnly.MinValue);

        //    comboBoxTransferType.SelectedItem = transfer.Type;
        //    textBoxComment.Text = transfer.Comment;
        //}

        private void ComboBoxPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPlayer.SelectedValue == null)
                return;

            int playerId = (int)comboBoxPlayer.SelectedValue;

            var player = _db.Players.FirstOrDefault(p => p.PlayerId == playerId);

            if (player != null)
            {
                comboBoxClubFrom.SelectedValue = player.ClubId;
            }
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            var query = _db.Transfers
                .Include(t => t.Player)
                .Include(t => t.ClubFromNavigation)
                .Include(t => t.ClubToNavigation)
                .AsQueryable();

            // Player filter
            if (comboBoxFilterByPlayer.SelectedValue is int playerId && playerId != 0)
            {
                query = query.Where(t => t.PlayerId == playerId);
            }

            // Club From filter
            if (comboBoxFilterByClubFrom.SelectedValue is int clubFromId && clubFromId != 0)
            {
                query = query.Where(t => t.ClubFrom == clubFromId);
            }

            // Club To filter
            if (comboBoxFilterByClubTo.SelectedValue is int clubToId && clubToId != 0)
            {
                query = query.Where(t => t.ClubTo == clubToId);
            }

            // Date filter
            DateOnly startDate = DateOnly.FromDateTime(dateTimePickerFilterByDateStart.Value);
            DateOnly endDate = DateOnly.FromDateTime(dateTimePickerFilterByDateEnd.Value);

            query = query.Where(t => t.Date >= startDate && t.Date <= endDate);

            transferBindingSource.DataSource = query.ToList();
            transferBindingSource.ResetBindings(false);
        }

        private void ResetFilters()
        {
            comboBoxFilterByPlayer.SelectedIndex = 0;
            comboBoxFilterByClubFrom.SelectedIndex = 0;
            comboBoxFilterByClubTo.SelectedIndex = 0;

            dateTimePickerFilterByDateStart.Value = new DateTime(1753, 1, 1);
            dateTimePickerFilterByDateEnd.Value = DateTime.Today;
        }
    }
}
