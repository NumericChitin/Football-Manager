using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WinFormsApp1
{
    public partial class ClubsForm : Form
    {
        private FootballManagerContext _db;

        public ClubsForm()
        {
            InitializeComponent();
        }

        private void ClubsForm_Load(object sender, EventArgs e)
        {
            string connString = Program.Configuration.GetConnectionString("FootballManagerDb");

            _db = new FootballManagerContext(connString);
            _db.Clubs.Load();
            clubBindingSource.DataSource = _db.Clubs.Local.ToBindingList();
            dataGridViewClubs.SelectionChanged += (s, ev) => LoadSelectedClubToTextBoxes();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _db?.Dispose();
            base.OnFormClosed(e);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (dataGridViewClubs.CurrentRow == null)
                return;

            var selectedClub = dataGridViewClubs.CurrentRow.DataBoundItem as Club;
            if (selectedClub == null)
                return;

            try
            {
                // Validate textbox input first
                if (!ValidateClubs())
                    return;

                // Update entity from textboxes
                selectedClub.Name = textBoxName.Text.Trim();
                selectedClub.City = textBoxCity.Text.Trim();
                selectedClub.Stadium = textBoxStadium.Text.Trim();

                clubBindingSource.ResetBindings(false);
                _db.SaveChanges();

                MessageBox.Show("Промените бяха запазени!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при запис:\n" + ex.Message);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var newClub = new Club
            {
                Name = "",
                City = "",
                Stadium = ""
            };

            _db.Clubs.Add(newClub);
            clubBindingSource.ResetBindings(false);

            // Select the newly added row
            dataGridViewClubs.ClearSelection();
            int rowIndex = clubBindingSource.IndexOf(newClub);
            if (rowIndex >= 0)
            {
                dataGridViewClubs.Rows[rowIndex].Selected = true;
                dataGridViewClubs.CurrentCell = dataGridViewClubs.Rows[rowIndex].Cells[0];
            }

            LoadSelectedClubToTextBoxes();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // Make sure a row is selected
            if (dataGridViewClubs.CurrentRow == null)
                return;

            // Get the bound Club from the selected row
            var selectedClub = dataGridViewClubs.CurrentRow.DataBoundItem as Club;

            if (selectedClub == null)
            {
                // If it's a new row (not yet added to the BindingSource)
                MessageBox.Show("Този ред все още не е запазен и не може да бъде изтрит.");
                return;
            }

            // Confirm deletion
            var confirm = MessageBox.Show(
                $"Да се изтрие ли клубът \"{selectedClub.Name}\"?",
                "Потвърждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                // Remove from BindingSource
                clubBindingSource.Remove(selectedClub);

                // Remove from EF context (only if it has a valid ID)
                if (selectedClub.ClubId != 0)
                {
                    _db.Clubs.Remove(selectedClub);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Клубът не може да бъде изтрит.\n" +
                    "Вероятно има свързани записи.\n\n" +
                    ex.Message,
                    "Грешка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private bool ValidateClubs()
        {
            string name = textBoxName.Text.Trim();
            string city = textBoxCity.Text.Trim();
            string stadium = textBoxStadium.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(city) ||
                string.IsNullOrWhiteSpace(stadium))
            {
                MessageBox.Show("Име, град и стадион са задължителни!");
                return false;
            }

            // Duplicate name check (excluding current entity)
            var selectedClub = dataGridViewClubs.CurrentRow?.DataBoundItem as Club;

            bool duplicateExists = _db.Clubs.Local
                .Any(c => c != selectedClub &&
                          c.Name.ToLower().Trim() == name.ToLower());

            if (duplicateExists)
            {
                MessageBox.Show("Има клуб със същото име!");
                return false;
            }

            return true;
        }

        private void LoadSelectedClubToTextBoxes()
        {
            if (dataGridViewClubs.CurrentRow == null)
                return;

            var selectedClub = dataGridViewClubs.CurrentRow.DataBoundItem as Club;
            if (selectedClub == null)
                return;

            textBoxName.Text = selectedClub.Name;
            textBoxCity.Text = selectedClub.City;
            textBoxStadium.Text = selectedClub.Stadium;
        }
    }
}
