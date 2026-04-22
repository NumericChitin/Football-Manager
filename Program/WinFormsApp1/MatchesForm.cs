using System;
using System.ComponentModel;
using System.Windows.Forms;
using WinFormsApp1.Business;
using WinFormsApp1.Data.Models;

namespace WinFormsApp1
{
    public partial class MatchesForm : Form
    {
        private MatchOperations _operations;
        private BindingList<Match> _matchesBinding;
        private BindingList<MatchEventViewModel> _eventsBinding;

        public MatchesForm()
        {
            InitializeComponent();
            _operations = new MatchOperations();

            dgvMatches.AutoGenerateColumns = false;
            dgvEvents.AutoGenerateColumns = false;
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
        }

        private void cboLeague_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLeague.SelectedValue is int leagueId)
            {
                _matchesBinding = new BindingList<Match>(_operations.GetMatches(leagueId));
                dgvMatches.DataSource = _matchesBinding;
            }
        }

        private void dgvMatches_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMatches.CurrentRow?.DataBoundItem is Match selectedMatch)
            {
                // 1. Fill Match Info
                cboHomeClub.SelectedValue = selectedMatch.HomeClubId;
                cboAwayClub.SelectedValue = selectedMatch.AwayClubId;
                dtpMatchDate.Value = selectedMatch.Date.ToDateTime(TimeOnly.MinValue);
                cboRound.Text = selectedMatch.Round.ToString();

                // 2. Load Events
                _eventsBinding = new BindingList<MatchEventViewModel>(_operations.GetMatchEvents(selectedMatch.MatchId));
                dgvEvents.DataSource = _eventsBinding;

                // 3. Update Event Club Selection (Limit to the two teams playing)
                UpdateEventClubs(selectedMatch);
            }
        }

        private void UpdateEventClubs(Match match)
        {
            // We only want the Home and Away clubs to appear in the event dropdown
            var competingClubs = new List<Club> { match.HomeClub, match.AwayClub };
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

                _operations.AddOrUpdateMatch(selectedMatch);
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
                cboEventPlayer.SelectedValue != null)
            {
                string type = cboEventType.SelectedItem.ToString();
                int minute = (int)numericUpDownMinute.Value;
                int playerId = (int)cboEventPlayer.SelectedValue;
                int clubId = (int)cboEventClub.SelectedValue;

                _operations.AddEvent(type, selectedMatch.MatchId, minute, playerId, clubId);

                // Refresh the events grid to show the new event
                _eventsBinding = new BindingList<MatchEventViewModel>(_operations.GetMatchEvents(selectedMatch.MatchId));
                dgvEvents.DataSource = _eventsBinding;
            }
            else
            {
                MessageBox.Show("Моля, изберете клуб и играч за събитието.", "Внимание");
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
            MessageBox.Show("Използвайте 'Добави' и 'Изтрий' за управление на събитията.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}