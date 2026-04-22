using System.ComponentModel;
using WinFormsApp1.Data.Models;
using WinFormsApp1.Logic;

namespace WinFormsApp1
{
    public partial class LeaguesForm : Form
    {
        private LeagueOperations _leagueOps;

        private BindingList<League> _leagues;
        private BindingList<Club> _participants;
        private BindingList<Club> _availableClubs;
        private BindingList<Match> _matches;

        public LeaguesForm()
        {
            InitializeComponent();
        }

        private void LeaguesForm_Load(object sender, EventArgs e)
        {
            // Initialize the business logic layer
            _leagueOps = new LeagueOperations();

            _leagues = _leagueOps.GetBindingList();
            leagueBindingSource.DataSource = _leagues;

            dgvParticipants.AutoGenerateColumns = false;
            dgvMatches.AutoGenerateColumns = false;

            if (_leagues.Count > 0)
            {
                LoadLeagueDetails(_leagues[0]);
            }
        }

        private void dgvLeagues_SelectionChanged(object sender, EventArgs e)
        {
            if (leagueBindingSource.Current is League league)
            {
                LoadLeagueDetails(league);
            }
        }

        private void buttonAddLeague_Click(object sender, EventArgs e)
        {
            string name = tbLeagueName.Text.Trim();
            string season = tbSeason.Text.Trim();

            var validation = _leagueOps.ValidateLeague(name, season);
            if (!validation.IsValid)
            {
                MessageBox.Show(validation.ErrorMessage);
                return;
            }

            var league = new League
            {
                Name = name,
                Season = season,
                NumberClubs = 0
            };

            _leagueOps.Add(league);
        }

        private void buttonEditLeague_Click(object sender, EventArgs e)
        {
            if (leagueBindingSource.Current is not League league)
                return;

            string name = tbLeagueName.Text.Trim();
            string season = tbSeason.Text.Trim();

            var validation = _leagueOps.ValidateLeague(name, season, league.LeagueId);
            if (!validation.IsValid)
            {
                MessageBox.Show(validation.ErrorMessage);
                return;
            }

            league.Name = name;
            league.Season = season;

            dgvLeagues.Refresh();
        }

        private void buttonDeleteLeague_Click(object sender, EventArgs e)
        {
            if (leagueBindingSource.Current is not League league)
                return;

            if (!_leagueOps.CanDeleteLeague(league))
            {
                MessageBox.Show("Не може да изтриете лига с изиграни мачове.");
                return;
            }

            var confirm = MessageBox.Show(
                "Сигурни ли сте, че искате да изтриете лигата?",
                "Потвърждение",
                MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                _leagueOps.DeleteLeague(league);
            }
        }

        private void buttonAddClubToLeague_Click(object sender, EventArgs e)
        {
            if (leagueBindingSource.Current is not League league)
                return;

            if (cboAvailableClubs.SelectedItem is not Club club)
                return;

            // Update Domain model
            league.Clubs.Add(club);
            league.NumberClubs = league.Clubs.Count;

            // Update UI BindingLists
            _participants.Add(club);
            _availableClubs.Remove(club);
        }

        private void buttonRemoveClubFromLeague_Click(object sender, EventArgs e)
        {
            if (leagueBindingSource.Current is not League league)
                return;

            if (dgvParticipants.CurrentRow?.DataBoundItem is not Club club)
                return;

            if (!_leagueOps.CanRemoveClub(league, club))
            {
                MessageBox.Show("Не може да се изтрие клуб с изиграни мачове в лигата");
                return;
            }

            var confirm = MessageBox.Show(
                "Сигурни ли сте?",
                "Потвърждение",
                MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                // Update Domain model
                league.Clubs.Remove(club);
                league.NumberClubs = league.Clubs.Count;

                // Update UI BindingLists
                _participants.Remove(club);
                _availableClubs.Add(club);
            }
        }

        private void buttonGenerateMatches_Click(object sender, EventArgs e)
        {
            if (leagueBindingSource.Current is not League league)
                return;

            var result = _leagueOps.GenerateMatches(league);

            if (!result.Success)
            {
                MessageBox.Show(result.ErrorMessage);
                return;
            }

            MessageBox.Show("Мачовете (домакин/гост) са генерирани.");

            // Refresh the matches grid to show the newly generated matches
            LoadLeagueDetails(league);
        }

        private void buttonSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                _leagueOps.Save();
                MessageBox.Show("Промените са записани успешно.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadLeagueDetails(League league)
        {
            tbLeagueName.Text = league.Name;
            tbSeason.Text = league.Season;

            // Load participants
            _participants = new BindingList<Club>(league.Clubs.ToList());
            clubBindingSource.DataSource = _participants;
            dgvParticipants.DataSource = clubBindingSource;

            // Load available clubs through Business Logic
            _availableClubs = new BindingList<Club>(_leagueOps.GetAvailableClubs(league));
            cboAvailableClubs.DataSource = _availableClubs;
            cboAvailableClubs.DisplayMember = "Name";
            cboAvailableClubs.ValueMember = "ClubId";

            // Load matches through Business Logic
            _matches = _leagueOps.GetMatchesForLeague(league.LeagueId);
            dgvMatches.DataSource = _matches;
        }

        // Always dispose of the Operations class to free the database context
        protected override void OnClosed(EventArgs e)
        {
            _leagueOps?.Dispose();
            base.OnClosed(e);
        }
    }
}