using System;
using System.ComponentModel;
using System.Windows.Forms;
using WinFormsApp1.Business;
using WinFormsApp1.Data.Models;

namespace WinFormsApp1
{
    public partial class MatchesForm : Form
    {
        private MatchOperation _operations;
        private BindingList<Match> _matchesBinding;
        private BindingList<MatchEventViewModel> _eventsBinding;

        public MatchesForm()
        {
            InitializeComponent();
            _operations = new MatchOperation();

            dgvMatches.AutoGenerateColumns = false;
            dgvEvents.AutoGenerateColumns = false;

            EventType.DataPropertyName = "EventType";
        }

        private void MatchesForm_Load(object sender, EventArgs e)
        {
            // Load Leagues
            cboLeague.DataSource = _operations.GetLeagues();
            cboLeague.DisplayMember = "Name";
            cboLeague.ValueMember = "LeagueId";

            // Load Clubs
            var clubs = _operations.GetClubs();

            cboHomeClub.DataSource = new BindingList<Club>(clubs);
            cboHomeClub.DisplayMember = "Name";
            cboHomeClub.ValueMember = "ClubId";

            cboAwayClub.DataSource = new BindingList<Club>(clubs);
            cboAwayClub.DisplayMember = "Name";
            cboAwayClub.ValueMember = "ClubId";

            // Load matches in dgvMatches on startup
            LoadLeagueMatchesToDgv();
        }

        private void cboLeague_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLeagueMatchesToDgv();
        }

        private void LoadLeagueMatchesToDgv()
        {
            if (cboLeague.SelectedValue is int leagueId)
            {
                _matchesBinding = new BindingList<Match>(_operations.GetMatches(leagueId));
                dgvMatches.DataSource = _matchesBinding;

                if (_matchesBinding.Count == 0) dgvEvents.DataSource = null;
            }
        }

        private void dgvMatches_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMatches.CurrentRow?.DataBoundItem is Match selectedMatch)
            {
                cboHomeClub.SelectedValue = selectedMatch.HomeClubId;
                cboAwayClub.SelectedValue = selectedMatch.AwayClubId;

                DateTime matchDateTime = selectedMatch.Date.ToDateTime(TimeOnly.MinValue);
                if (matchDateTime < dtpMatchDate.MinDate)
                    dtpMatchDate.Value = dtpMatchDate.MinDate;
                else if (matchDateTime > dtpMatchDate.MaxDate)
                    dtpMatchDate.Value = dtpMatchDate.MaxDate;
                else
                    dtpMatchDate.Value = matchDateTime;

                cboRound.Text = selectedMatch.Round.ToString();

                _eventsBinding = new BindingList<MatchEventViewModel>(_operations.GetMatchEvents(selectedMatch.MatchId));
                dgvEvents.DataSource = _eventsBinding;

                UpdateEventClubs(selectedMatch);
            }
        }

        private void UpdateEventClubs(Match match)
        {
            var clubs = _operations.GetClubs();
            var home = clubs.FirstOrDefault(c => c.ClubId == match.HomeClubId);
            var away = clubs.FirstOrDefault(c => c.ClubId == match.AwayClubId);

            var competingClubs = new List<Club>();
            if (home != null) competingClubs.Add(home);
            if (away != null) competingClubs.Add(away);

            cboEventClub.DataSource = new BindingList<Club>(competingClubs);
            cboEventClub.DisplayMember = "Name";
            cboEventClub.ValueMember = "ClubId";
        }

        private void cboEventClub_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEventClub.SelectedValue is int clubId)
            {
                // Filter players based on the selected club
                var players = _operations.GetPlayersByClub(clubId);
                cboEventPlayer.DataSource = new BindingList<Player>(players);
                cboEventPlayer.DisplayMember = "FullName";
                cboEventPlayer.ValueMember = "PlayerId";
            }
        }

        private void buttonAddMatch_Click(object sender, EventArgs e)
        {
            if (cboLeague.SelectedValue == null) return;

            var newMatch = new Match
            {
                LeagueId = (int)cboLeague.SelectedValue,
                HomeClubId = (int)cboHomeClub.SelectedValue,
                AwayClubId = (int)cboAwayClub.SelectedValue,
                Date = DateOnly.FromDateTime(dtpMatchDate.Value),
                Round = int.Parse(cboRound.Text)
            };

            _operations.AddOrUpdateMatch(newMatch);
            _matchesBinding.Add(newMatch);
        }

        private void buttonSaveChanges_Click(object sender, EventArgs e)
        {
            if (dgvMatches.CurrentRow?.DataBoundItem is Match selectedMatch)
            {
                selectedMatch.HomeClubId = (int)cboHomeClub.SelectedValue;
                selectedMatch.AwayClubId = (int)cboAwayClub.SelectedValue;
                selectedMatch.Date = DateOnly.FromDateTime(dtpMatchDate.Value);
                selectedMatch.Round = int.Parse(cboRound.Text);

                bool successfulSave = _operations.AddOrUpdateMatch(selectedMatch);
                if (!successfulSave)
                {
                    MessageBox.Show("Не може домакин и гост да са един клуб", "Грешка");
                }
                dgvMatches.Refresh();
            }
        }

        private void buttonDeleteMatch_Click(object sender, EventArgs e)
        {
            if (dgvMatches.CurrentRow?.DataBoundItem is Match selectedMatch)
            {
                _operations.DeleteMatch(selectedMatch.MatchId);
                _matchesBinding.Remove(selectedMatch);
            }
        }

        private void buttonAddEvent_Click(object sender, EventArgs e)
        {
            if (dgvMatches.CurrentRow?.DataBoundItem is Match selectedMatch &&
                cboEventType.SelectedItem != null &&
                cboEventPlayer.SelectedValue is int playerId)
            {
                string type = cboEventType.SelectedItem.ToString();
                int minute = (int)numericUpDownMinute.Value;

                _operations.AddEvent(type, selectedMatch.MatchId, minute, playerId);

                // 1. Refresh Events Grid
                _eventsBinding = new BindingList<MatchEventViewModel>(_operations.GetMatchEvents(selectedMatch.MatchId));
                dgvEvents.DataSource = _eventsBinding;

                // 2. Refresh the Matches list so the new score (Result) shows up
                // We re-fetch to ensure the Goals collection in the model is updated
                if (cboLeague.SelectedValue is int leagueId)
                {
                    _matchesBinding = new BindingList<Match>(_operations.GetMatches(leagueId));
                    dgvMatches.DataSource = _matchesBinding;
                }
            }
        }

        private void buttonDeleteEvent_Click(object sender, EventArgs e)
        {
            if (dgvEvents.CurrentRow?.DataBoundItem is MatchEventViewModel selectedEvent)
            {
                _operations.DeleteEvent(selectedEvent.EventCategory, selectedEvent.EventId);
                _eventsBinding.Remove(selectedEvent);
            }
        }

        private void buttonSaveChangesEvents_Click(object sender, EventArgs e)
        {
            // Usually handled dynamically on Add/Delete, or you can implement batch saving in MatchOperations.
            MessageBox.Show("Използвайте 'Добави' и 'Изтрий' за управление на събитията. Бутонът съществува за по-добър дизайн.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}