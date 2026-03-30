using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.ComponentModel;
using WinFormsApp1.Data;
using WinFormsApp1.Data.Models;

namespace WinFormsApp1
{
    public partial class LeaguesForm : Form
    {
        private FootballManagerContext _context;

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
            string connString = Program.Configuration.GetConnectionString("FootballManagerDb");

            _context = new FootballManagerContext(connString);

            _context.Leagues
                .Include(l => l.Clubs)
                .Load();

            _context.Clubs.Load();

            _leagues = _context.Leagues.Local.ToBindingList();

            leagueBindingSource.DataSource = _leagues;

            dgvParticipants.AutoGenerateColumns = false;
            dgvMatches.AutoGenerateColumns = false;

            _context.Matches
            .Include(m => m.HomeClub)
            .Include(m => m.AwayClub)
            .Load();

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
            if (!ValidateLeague())
                return;

            var league = new League
            {
                Name = tbLeagueName.Text.Trim(),
                Season = tbSeason.Text.Trim(),
                NumberClubs = 0
            };

            _context.Leagues.Add(league);
        }

        private void buttonEditLeague_Click(object sender, EventArgs e)
        {
            if (leagueBindingSource.Current is not League league)
                return;

            if (!ValidateLeague())
                return;

            league.Name = tbLeagueName.Text.Trim();
            league.Season = tbSeason.Text.Trim();

            dgvLeagues.Refresh();
        }

        private void buttonDeleteLeague_Click(object sender, EventArgs e)
        {
            if (leagueBindingSource.Current is not League league)
                return;

            bool hasMatches = _context.Matches.Any(m => m.LeagueId == league.LeagueId);

            if (hasMatches)
            {
                MessageBox.Show("Не може да изтриете лига с изиграни мачове.");
                return;
            }

            var confirm = MessageBox.Show(
                "Сигурни ли сте, че искате да изтриете лигата?",
                "Потвърждение",
                MessageBoxButtons.YesNo);

            if (confirm != DialogResult.Yes)
                return;

            league.Clubs.Clear(); // remove LeagueTeams entries

            _context.Leagues.Remove(league);
        }

        private void buttonAddClubToLeague_Click(object sender, EventArgs e)
        {
            if (leagueBindingSource.Current is not League league)
                return;

            if (cboAvailableClubs.SelectedItem is not Club club)
                return;

            league.Clubs.Add(club);

            _participants.Add(club);
            _availableClubs.Remove(club);

            league.NumberClubs = league.Clubs.Count;
        }

        private void buttonRemoveClubFromLeague_Click(object sender, EventArgs e)
        {
            if (leagueBindingSource.Current is not League league)
                return;

            if (dgvParticipants.CurrentRow?.DataBoundItem is not Club club)
                return;

            if (!ValidateClubRemoval())
            {
                MessageBox.Show("Не може да се изтрие клуб с изиграни мачове в лигата");
                return;
            }

            var confirm = MessageBox.Show(
                "Сигурни ли сте?",
                "Потвърждение",
                MessageBoxButtons.YesNo);

            if (confirm != DialogResult.Yes)
                return;

            league.Clubs.Remove(club);

            _participants.Remove(club);
            _availableClubs.Add(club);

            league.NumberClubs = league.Clubs.Count;
        }

        private void buttonSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                _context.SaveChanges();
                MessageBox.Show("Промените са записани успешно.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool ValidateLeague()
        {
            string name = tbLeagueName.Text.Trim();
            string season = tbSeason.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(season))
            {
                MessageBox.Show("Името на лигата и сезонът са задължителни.");
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(season, @"^\d{4}/\d{4}$"))
            {
                MessageBox.Show("Сезонът трябва да е във формат yyyy/yyyy.");
                return false;
            }

            int currentLeagueId = (leagueBindingSource.Current as League)?.LeagueId ?? 0;

            bool exists = _context.Leagues.Any(l =>
                l.Name == name &&
                l.Season == season &&
                l.LeagueId != currentLeagueId);

            if (exists)
            {
                MessageBox.Show("Вече съществува лига със същото име и сезон.");
                return false;
            }

            return true;
        }

        private bool ValidateClubRemoval()
        {
            if (leagueBindingSource.Current is not League league)
                return false;

            if (dgvParticipants.CurrentRow?.DataBoundItem is not Club club)
                return false;

            bool hasMatches = _context.Matches.Any(m =>
                m.LeagueId == league.LeagueId &&
                (m.HomeClubId == club.ClubId || m.AwayClubId == club.ClubId));

            return !hasMatches;
        }

        private void GenerateMatches()
        {
            if (leagueBindingSource.Current is not League league)
                return;

            bool hasMatches = _context.Matches
            .Any(m => m.LeagueId == league.LeagueId);

            if (hasMatches)
            {
                MessageBox.Show("Мачовете за тази лига вече са генерирани.");
                return;
            }

            var clubs = league.Clubs.ToList();

            for (int i = 0; i < clubs.Count; i++)
            {
                for (int j = i + 1; j < clubs.Count; j++)
                {
                    var clubA = clubs[i];
                    var clubB = clubs[j];

                    // Match 1
                    _context.Matches.Add(new Match
                    {
                        LeagueId = league.LeagueId,
                        HomeClubId = clubA.ClubId,
                        AwayClubId = clubB.ClubId,
                        Round = 1
                    });

                    // Match 2 (reverse)
                    _context.Matches.Add(new Match
                    {
                        LeagueId = league.LeagueId,
                        HomeClubId = clubB.ClubId,
                        AwayClubId = clubA.ClubId,
                        Round = 2
                    });
                }
            }

            MessageBox.Show("Мачовете (домакин/гост) са генерирани.");
        }

        private void buttonGenerateMatches_Click(object sender, EventArgs e)
        {
            if (leagueBindingSource.Current is not League league)
                return;

            if (league.Clubs.Count < 2)
            {
                MessageBox.Show("Лигата трябва да има поне 2 клуба.");
                return;
            }

            GenerateMatches();
        }

        private void LoadLeagueDetails(League league)
        {
            tbLeagueName.Text = league.Name;
            tbSeason.Text = league.Season;

            _participants = new BindingList<Club>(league.Clubs.ToList());
            clubBindingSource.DataSource = _participants;
            dgvParticipants.DataSource = clubBindingSource;

            var leagueClubIds = league.Clubs.Select(lc => lc.ClubId).ToList();

            var available = _context.Clubs
                .Where(c => !leagueClubIds.Contains(c.ClubId))
                .ToList();

            _availableClubs = new BindingList<Club>(available);

            cboAvailableClubs.DataSource = _availableClubs;
            cboAvailableClubs.DisplayMember = "Name";
            cboAvailableClubs.ValueMember = "ClubId";

            _matches = new BindingList<Match>(
                _context.Matches.Local
                    .Where(m => m.LeagueId == league.LeagueId)
                    .ToList()
            );

            dgvMatches.DataSource = _matches;
        }
    }
}
