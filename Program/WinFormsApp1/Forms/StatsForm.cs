using System.ComponentModel;
using WinFormsApp1.Business;
using WinFormsApp1.Data.Models;

namespace WinFormsApp1.Forms
{
    public partial class StatsForm : Form
    {
        private StatsOperation _ops = new StatsOperation();

        public StatsForm()
        {
            InitializeComponent();
            SetupGrid();
        }

        private void SetupGrid()
        {
            dgvStats.AutoGenerateColumns = false;

            // Link DataGridView columns to ViewModel properties
            Club.DataPropertyName = "ClubName";
            Matches.DataPropertyName = "Matches";
            Wins.DataPropertyName = "Wins";
            Draws.DataPropertyName = "Draws";
            Losses.DataPropertyName = "Losses";
            Goals.DataPropertyName = "GoalsDisplay";
            Points.DataPropertyName = "Points";
        }

        private void StatsForm_Load(object sender, EventArgs e)
        {
            cboLeague.DataSource = _ops.GetAllLeagues();
            cboLeague.DisplayMember = "Name";
            cboLeague.ValueMember = "LeagueId";

            // Attach event AFTER initial load to prevent double-firing
            cboLeague.SelectedIndexChanged += cboLeague_SelectedIndexChanged;

            LoadStats();
        }

        private void cboLeague_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStats();
        }

        private void LoadStats()
        {
            if (cboLeague.SelectedValue is int leagueId)
            {
                var stats = _ops.GetLeagueTable(leagueId);
                dgvStats.DataSource = new BindingList<ClubStatsViewModel>(stats);
            }
        }
    }
}