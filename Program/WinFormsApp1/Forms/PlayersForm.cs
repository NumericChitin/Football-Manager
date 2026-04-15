using Microsoft.EntityFrameworkCore;
using System;
using System.Windows.Forms;
using WinFormsApp1.Data.Models;
using WinFormsApp1.Logic;

namespace WinFormsApp1
{
    public partial class PlayersForm : Form
    {
        private readonly PlayerOperation Op = new PlayerOperation();

        public PlayersForm()
        {
            InitializeComponent();
        }

        private void PlayersForm_Load(object sender, EventArgs e)
        {
            playerBindingSource.DataSource = Op.GetBindingList();

            comboBoxDominantFoot.Items.AddRange(new[] { "ляв", "десен" });
            comboBoxStatus.Items.AddRange(new[] { "активен", "ранен", "наказан", "свободен агент" });
            comboBoxPosition.Items.AddRange(new[] { "Нападател", "Полузащитник", "Защитник", "Вратар" });

            Op.Context.Set<Club>().Load();

            comboBoxClubName.DataSource = Op.Context.Set<Club>().Local.ToBindingList();
            comboBoxClubName.DisplayMember = "Name";
            comboBoxClubName.ValueMember = "ClubId";

            //binding (replaces manual sync)
            textBoxPlayerName.DataBindings.Add("Text", playerBindingSource, "FullName", true, DataSourceUpdateMode.OnValidation);
            textBoxNationality.DataBindings.Add("Text", playerBindingSource, "Nationality", true, DataSourceUpdateMode.OnValidation);
            textBoxNumber.DataBindings.Add("Text", playerBindingSource, "Number", true, DataSourceUpdateMode.OnValidation);
            textBoxSalary.DataBindings.Add("Text", playerBindingSource, "Salary", true, DataSourceUpdateMode.OnValidation);

            dateTimePickerBirthDate.ValueChanged += DateChanged;

            comboBoxPosition.DataBindings.Add("Text", playerBindingSource, "Position", true, DataSourceUpdateMode.OnValidation);
            comboBoxDominantFoot.DataBindings.Add("Text", playerBindingSource, "DominantFoot", true, DataSourceUpdateMode.OnValidation);
            comboBoxStatus.DataBindings.Add("Text", playerBindingSource, "Status", true, DataSourceUpdateMode.OnValidation);

            comboBoxClubName.DataBindings.Add(
                "SelectedValue",
                playerBindingSource,
                "ClubId",
                true,
            DataSourceUpdateMode.OnValidation);

            dataGridViewPlayers.SelectionChanged += (_, __) =>
            {
                var player = dataGridViewPlayers.CurrentRow?.DataBoundItem as Player;
                if (player == null) return;

                dateTimePickerBirthDate.Value = player.DateOfBirth.ToDateTime(TimeOnly.MinValue);
            };
        }


        private void DateChanged(object sender, EventArgs e)
        {
            var player = dataGridViewPlayers.CurrentRow?.DataBoundItem as Player;
            if (player == null) return;

            player.DateOfBirth = DateOnly.FromDateTime(dateTimePickerBirthDate.Value);
        }

        private void PlayersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            playerBindingSource.EndEdit();
            Op.Dispose();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var newPlayer = new Player
            {
                FullName = "",
                Nationality = "",
                DateOfBirth = DateOnly.FromDateTime(DateTime.Today),
                Position = "",
                DominantFoot = "",
                Status = "",
                Number = 1,
                Salary = 0,
                ClubId = (int?)comboBoxClubName.SelectedValue ?? 0
            };

            Op.Add(newPlayer);

            int rowIndex = playerBindingSource.IndexOf(newPlayer);
            if (rowIndex >= 0)
            {
                dataGridViewPlayers.ClearSelection();
                dataGridViewPlayers.Rows[rowIndex].Selected = true;
                dataGridViewPlayers.CurrentCell = dataGridViewPlayers.Rows[rowIndex].Cells[0];
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var player = dataGridViewPlayers.CurrentRow?.DataBoundItem as Player;
            if (player == null)
                return;

            try
            {
                if (!Op.Validate(player, out string error))
                {
                    MessageBox.Show(error);
                    return;
                }

                if (Op.DuplicateExists(player, player.FullName, player.ClubId))
                {
                    MessageBox.Show("Играч с това име вече съществува в този клуб!");
                    return;
                }

                dataGridViewPlayers.EndEdit();
                playerBindingSource.EndEdit();

                Op.Save();

                MessageBox.Show("Промените бяха запазени!");
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("Database error:\n" + ex.InnerException?.Message);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var player = dataGridViewPlayers.CurrentRow?.DataBoundItem as Player;
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

                if (player.PlayerId != 0)
                    Op.Remove(player);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при изтриване:\n" + ex.Message);
            }
        }
    }
}