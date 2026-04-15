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
using WinFormsApp1.Logic;

namespace WinFormsApp1
{
    public partial class TransfersForm : Form
    {
        private TransferOperation _op;
        private bool _loading;

        public TransfersForm()
        {
            InitializeComponent();
        }

        private void TransfersForm_Load(object sender, EventArgs e)
        {
            _loading = true;

            _op = new TransferOperation();

            var db = _op.Context;

            db.Players.Load();
            db.Clubs.Load();
            db.Transfers.Load();

            transferBindingSource.DataSource = db.Transfers.Local.ToBindingList();

            // Player combobox
            comboBoxPlayer.DataSource = db.Players.Local.ToList();
            comboBoxPlayer.DisplayMember = "FullName";
            comboBoxPlayer.ValueMember = "PlayerId";

            // FILTER PLAYER
            var playersFilter = db.Players.Local.ToList();
            playersFilter.Insert(0, new Player { PlayerId = 0, FullName = "" });

            comboBoxFilterByPlayer.DataSource = playersFilter;
            comboBoxFilterByPlayer.DisplayMember = "FullName";
            comboBoxFilterByPlayer.ValueMember = "PlayerId";

            // Clubs
            comboBoxClubFrom.DataSource = db.Clubs.Local.ToList();
            comboBoxClubFrom.DisplayMember = "Name";
            comboBoxClubFrom.ValueMember = "ClubId";

            comboBoxClubTo.DataSource = db.Clubs.Local.ToList();
            comboBoxClubTo.DisplayMember = "Name";
            comboBoxClubTo.ValueMember = "ClubId";

            // FILTER CLUBS
            var clubsFilterFrom = db.Clubs.Local.ToList();
            clubsFilterFrom.Insert(0, new Club { ClubId = 0, Name = "" });

            comboBoxFilterByClubFrom.DataSource = clubsFilterFrom;
            comboBoxFilterByClubFrom.DisplayMember = "Name";
            comboBoxFilterByClubFrom.ValueMember = "ClubId";

            var clubsFilterTo = db.Clubs.Local.ToList();
            clubsFilterTo.Insert(0, new Club { ClubId = 0, Name = "" });

            comboBoxFilterByClubTo.DataSource = clubsFilterTo;
            comboBoxFilterByClubTo.DisplayMember = "Name";
            comboBoxFilterByClubTo.ValueMember = "ClubId";

            comboBoxPlayer.SelectedIndexChanged += ComboBoxPlayer_SelectedIndexChanged;

            comboBoxTransferType.Items.AddRange(new[] { "постоянен", "временен" });

            dateTimePickerFilterByDateStart.Value = new DateTime(1753, 1, 1);
            dateTimePickerFilterByDateEnd.Value = DateTime.Today;

            comboBoxFilterByPlayer.SelectedIndexChanged += (_, __) => ApplyFilters();
            comboBoxFilterByClubFrom.SelectedIndexChanged += (_, __) => ApplyFilters();
            comboBoxFilterByClubTo.SelectedIndexChanged += (_, __) => ApplyFilters();

            dateTimePickerFilterByDateStart.ValueChanged += (_, __) => ApplyFilters();
            dateTimePickerFilterByDateEnd.ValueChanged += (_, __) => ApplyFilters();

            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;

            _loading = false;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _op?.Dispose();
            base.OnFormClosed(e);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var db = _op.Context;

            if (!db.Players.Any() || !db.Clubs.Any())
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

            _op.Add(newTransfer);

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
            var transfer = dataGridView1.CurrentRow?.DataBoundItem as Transfer;
            if (transfer == null)
                return;

            if (!_op.ValidateTransfer(transfer, out string error))
            {
                MessageBox.Show(error);
                return;
            }

            if (transfer.TransferId != 0)
            {
                MessageBox.Show("Редактирането не е позволено.");
                return;
            }

            try
            {
                _op.ApplyTransferEffects(transfer);
                _op.Save();

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

        private void ComboBoxPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_loading) return;

            if (comboBoxPlayer.SelectedValue == null)
                return;

            var db = _op.Context;

            int playerId = GetSelectedId(comboBoxPlayer);

            var player = db.Players.FirstOrDefault(p => p.PlayerId == playerId);

            if (player != null)
            {
                comboBoxClubFrom.SelectedValue = player.ClubId;
            }
        }

        private void ApplyFilters()
        {
            if (_loading) return;

            var filteredIds = _op.GetFiltered(
            GetSelectedId(comboBoxFilterByPlayer),
            GetSelectedId(comboBoxFilterByClubFrom),
            GetSelectedId(comboBoxFilterByClubTo),
            DateOnly.FromDateTime(dateTimePickerFilterByDateStart.Value),
            DateOnly.FromDateTime(dateTimePickerFilterByDateEnd.Value)
            )
            .Select(t => t.TransferId)
            .ToHashSet();

            dataGridView1.CurrentCell = null;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.DataBoundItem is Transfer t)
                    row.Visible = filteredIds.Contains(t.TransferId);
            }
        }

        private void ResetFilters()
        {
            comboBoxFilterByPlayer.SelectedIndex = 0;
            comboBoxFilterByClubFrom.SelectedIndex = 0;
            comboBoxFilterByClubTo.SelectedIndex = 0;

            dateTimePickerFilterByDateStart.Value = new DateTime(1753, 1, 1);
            dateTimePickerFilterByDateEnd.Value = DateTime.Today;

        }

        private int GetSelectedId(ComboBox box)
        {
            if (box.SelectedValue is int id)
                return id;

            if (box.SelectedValue is Player p)
                return p.PlayerId;

            if (box.SelectedValue is Club c)
                return c.ClubId;

            return 0;
        }
    }
}
