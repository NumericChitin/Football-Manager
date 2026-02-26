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
    public partial class PlayersForm : Form
    {
        private FootballManagerContext _db;

        public PlayersForm()
        {
            InitializeComponent();
        }

        private void PlayersForm_Load(object sender, EventArgs e)
        {
            string connString = Program.Configuration.GetConnectionString("FootballManagerDb");

            _db = new FootballManagerContext(connString);

            _db.Clubs.Load();
            _db.Players.Load();

            playerBindingSource.DataSource = _db.Players.Local.ToBindingList();

            // Populate comboboxes
            comboBoxDominantFoot.Items.AddRange(new[] { "left", "right" });
            comboBoxStatus.Items.AddRange(new[] { "active", "hurt", "punished", "free agent" });
            comboBoxPosition.Items.AddRange(new[] { "Forward", "Midfielder", "Defender", "GoalKeeper" });

            comboBoxClubName.DataSource = _db.Clubs.Local.ToList();
            comboBoxClubName.DisplayMember = "Name";
            comboBoxClubName.ValueMember = "ClubId";

            dataGridViewPlayers.SelectionChanged += (s, ev) => LoadSelectedPlayerToInputs();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _db?.Dispose();
            base.OnFormClosed(e);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!_db.Clubs.Any())
            {
                MessageBox.Show("Няма налични клубове! Първо добавете клуб.");
                return;
            }

            var newPlayer = new Player
            {
                FullName = "",
                Nationality = "",
                DateOfBirth = DateOnly.FromDateTime(DateTime.Today),
                Position = "",
                DominantFoot = "",
                Status = "",
                Number = 0,
                Salary = 0.0,
                ClubId = _db.Clubs.First().ClubId
            };

            _db.Players.Add(newPlayer);
            playerBindingSource.ResetBindings(false);

            dataGridViewPlayers.ClearSelection();
            int index = playerBindingSource.IndexOf(newPlayer);

            if (index >= 0)
            {
                dataGridViewPlayers.Rows[index].Selected = true;
                dataGridViewPlayers.CurrentCell =
                    dataGridViewPlayers.Rows[index].Cells[0];
            }

            LoadSelectedPlayerToInputs();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (dataGridViewPlayers.CurrentRow == null)
                return;

            var player = dataGridViewPlayers.CurrentRow.DataBoundItem as Player;
            if (player == null)
                return;

            if (!ValidatePlayers())
                return;

            try
            {
                player.FullName = textBoxPlayerName.Text.Trim();
                player.Nationality = textBoxNationality.Text.Trim();

                // DateOnly conversion
                player.DateOfBirth = DateOnly.FromDateTime(dateTimePickerBirthDate.Value);

                player.Position = comboBoxPosition.SelectedItem?.ToString();
                player.DominantFoot = comboBoxDominantFoot.SelectedItem?.ToString();
                player.Status = comboBoxStatus.SelectedItem?.ToString();

                player.Number = int.Parse(textBoxNumber.Text);

                // Salary is double
                player.Salary = double.Parse(textBoxSalary.Text);

                player.ClubId = (int)comboBoxClubName.SelectedValue;

                playerBindingSource.ResetBindings(false);
                _db.SaveChanges();

                MessageBox.Show("Промените бяха запазени!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при запис:\n" + ex.Message);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewPlayers.CurrentRow == null)
                return;

            var player = dataGridViewPlayers.CurrentRow.DataBoundItem as Player;
            if (player == null)
                return;

            var confirm = MessageBox.Show(
                $"Да се изтрие ли играчът \"{player.FullName}\"?",
                "Потвърждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                playerBindingSource.Remove(player);
                _db.Players.Remove(player);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при изтриване:\n" + ex.Message);
            }
        }

        private bool ValidatePlayers()
        {
            if (string.IsNullOrWhiteSpace(textBoxPlayerName.Text) ||
                string.IsNullOrWhiteSpace(textBoxNationality.Text) ||
                string.IsNullOrWhiteSpace(textBoxNumber.Text) ||
                string.IsNullOrWhiteSpace(textBoxSalary.Text) ||
                comboBoxPosition.SelectedItem == null ||
                comboBoxDominantFoot.SelectedItem == null ||
                comboBoxStatus.SelectedItem == null ||
                comboBoxClubName.SelectedItem == null)
            {
                MessageBox.Show("Всички полета са задължителни!");
                return false;
            }

            if (!int.TryParse(textBoxNumber.Text, out int number))
            {
                MessageBox.Show("Номерът трябва да е число!");
                return false;
            }

            if (!decimal.TryParse(textBoxSalary.Text, out decimal salary))
            {
                MessageBox.Show("Заплатата трябва да е число!");
                return false;
            }

            var selectedPlayer = dataGridViewPlayers.CurrentRow?.DataBoundItem as Player;
            int selectedClubId = (int)comboBoxClubName.SelectedValue;
            string name = textBoxPlayerName.Text.Trim().ToLower();

            bool duplicateExists = _db.Players.Local.Any(p =>
                p != selectedPlayer &&
                p.FullName.ToLower() == name &&
                p.ClubId == selectedClubId);

            if (duplicateExists)
            {
                MessageBox.Show("Играч с това име вече съществува в този клуб!");
                return false;
            }

            return true;
        }

        private void LoadSelectedPlayerToInputs()
        {
            if (dataGridViewPlayers.CurrentRow == null)
                return;

            var player = dataGridViewPlayers.CurrentRow.DataBoundItem as Player;
            if (player == null)
                return;

            textBoxPlayerName.Text = player.FullName;
            textBoxNationality.Text = player.Nationality;
            textBoxNumber.Text = player.Number.ToString();
            textBoxSalary.Text = player.Salary.ToString();

            // DateOnly → DateTime
            dateTimePickerBirthDate.Value = player.DateOfBirth.ToDateTime(TimeOnly.MinValue);

            comboBoxPosition.SelectedItem = player.Position;
            comboBoxDominantFoot.SelectedItem = player.DominantFoot;
            comboBoxStatus.SelectedItem = player.Status;

            comboBoxClubName.SelectedValue = player.ClubId;
        }
    }
}
