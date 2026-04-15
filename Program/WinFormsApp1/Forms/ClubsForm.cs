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
using WinFormsApp1.Logic;

namespace WinFormsApp1
{
    public partial class ClubsForm : Form
    {
        private readonly ClubOperation Op = new ClubOperation();

        public ClubsForm()
        {
            InitializeComponent();
        }

        private void ClubsForm_Load(object sender, EventArgs e)
        {
            clubBindingSource.DataSource = Op.GetBindingList();

            // Bind textboxes directly
            textBoxName.DataBindings.Add("Text", clubBindingSource, "Name", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxCity.DataBindings.Add("Text", clubBindingSource, "City", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxStadium.DataBindings.Add("Text", clubBindingSource, "Stadium", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void ClubsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Op.Dispose();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var selectedClub = dataGridViewClubs.CurrentRow?.DataBoundItem as Club;
            if (selectedClub == null)
                return;

            try
            {
                // Just validate — values are already in the entity
                if (!Op.Validate(selectedClub, out string error))
                {
                    MessageBox.Show(error);
                    return;
                }

                clubBindingSource.ResetBindings(false);
                Op.Save();

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

            Op.Add(newClub);
            clubBindingSource.ResetBindings(false);

            // Select the newly added row
            dataGridViewClubs.ClearSelection();
            int rowIndex = clubBindingSource.IndexOf(newClub);
            if (rowIndex >= 0)
            {
                dataGridViewClubs.Rows[rowIndex].Selected = true;
                dataGridViewClubs.CurrentCell = dataGridViewClubs.Rows[rowIndex].Cells[0];
            }
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
                    Op.Remove(selectedClub);
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
    }
}
