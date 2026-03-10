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

            // Populate player comboboxes
            comboBoxPlayer.DataSource = _db.Players.Local.ToList();
            comboBoxPlayer.DisplayMember = "FullName";
            comboBoxPlayer.ValueMember = "PlayerId";

            comboBoxFilterByPlayer.DataSource = _db.Players.Local.ToList();
            comboBoxFilterByPlayer.DisplayMember = "FullName";
            comboBoxFilterByPlayer.ValueMember = "PlayerId";

            // Populate club comboboxes
            comboBoxClubFrom.DataSource = _db.Clubs.Local.ToList();
            comboBoxClubFrom.DisplayMember = "Name";
            comboBoxClubFrom.ValueMember = "ClubId";

            comboBoxClubTo.DataSource = _db.Clubs.Local.ToList();
            comboBoxClubTo.DisplayMember = "Name";
            comboBoxClubTo.ValueMember = "ClubId";

            comboBoxFilterByClubFrom.DataSource = _db.Clubs.Local.ToList();
            comboBoxFilterByClubFrom.DisplayMember = "Name";
            comboBoxFilterByClubFrom.ValueMember = "ClubId";

            comboBoxFilterByClubTo.DataSource = _db.Clubs.Local.ToList();
            comboBoxFilterByClubTo.DisplayMember = "Name";
            comboBoxFilterByClubTo.ValueMember = "ClubId";

            comboBoxPlayer.SelectedIndexChanged += ComboBoxPlayer_SelectedIndexChanged;

            // Transfer type options
            comboBoxTransferType.Items.AddRange(new[] { "permanent", "temporary" });
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
            transferBindingSource.DataSource = _db.Transfers.Local.ToBindingList();
            transferBindingSource.ResetBindings(false);
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
    }
}
