using WinFormsApp1.Forms;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent(); //Make MatchesForm NOT change the match when adding an event
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClubsForm clubsForm = new ClubsForm();
            clubsForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PlayersForm playersForm = new PlayersForm();
            playersForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TransfersForm transfersForm = new TransfersForm();
            transfersForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LeaguesForm leaguesForm = new LeaguesForm();
            leaguesForm.ShowDialog();
        }

        private void buttonOpenMatches_Click(object sender, EventArgs e)
        {
            MatchesForm matchesForm = new MatchesForm();
            matchesForm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StatsForm statsForm = new StatsForm();
            statsForm.ShowDialog();
        }
    }
}
