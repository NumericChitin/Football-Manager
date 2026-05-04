namespace WinFormsApp1.Forms
{
    partial class StatsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label9 = new Label();
            cboLeague = new ComboBox();
            dgvStats = new DataGridView();
            Club = new DataGridViewTextBoxColumn();
            Matches = new DataGridViewTextBoxColumn();
            Wins = new DataGridViewTextBoxColumn();
            Draws = new DataGridViewTextBoxColumn();
            Losses = new DataGridViewTextBoxColumn();
            Goals = new DataGridViewTextBoxColumn();
            Points = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvStats).BeginInit();
            SuspendLayout();
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 14F);
            label9.Location = new Point(12, 12);
            label9.Name = "label9";
            label9.Size = new Size(57, 25);
            label9.TabIndex = 27;
            label9.Text = "Лига:";
            // 
            // cboLeague
            // 
            cboLeague.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLeague.Font = new Font("Segoe UI", 14F);
            cboLeague.FormattingEnabled = true;
            cboLeague.Items.AddRange(new object[] { "Гол", "Жълт картон", "Червен картон", "Фал" });
            cboLeague.Location = new Point(75, 9);
            cboLeague.Name = "cboLeague";
            cboLeague.Size = new Size(129, 33);
            cboLeague.TabIndex = 26;
            // 
            // dgvStats
            // 
            dgvStats.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStats.Columns.AddRange(new DataGridViewColumn[] { Club, Matches, Wins, Draws, Losses, Goals, Points });
            dgvStats.Location = new Point(12, 48);
            dgvStats.Name = "dgvStats";
            dgvStats.Size = new Size(776, 390);
            dgvStats.TabIndex = 28;
            // 
            // Club
            // 
            Club.HeaderText = "Отбор";
            Club.Name = "Club";
            Club.Width = 175;
            // 
            // Matches
            // 
            Matches.HeaderText = "Мачове";
            Matches.Name = "Matches";
            Matches.Width = 75;
            // 
            // Wins
            // 
            Wins.HeaderText = "Победи";
            Wins.Name = "Wins";
            // 
            // Draws
            // 
            Draws.HeaderText = "Равни";
            Draws.Name = "Draws";
            // 
            // Losses
            // 
            Losses.HeaderText = "Загуби";
            Losses.Name = "Losses";
            // 
            // Goals
            // 
            Goals.HeaderText = "Голове";
            Goals.Name = "Goals";
            // 
            // Points
            // 
            Points.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Points.HeaderText = "Точки";
            Points.Name = "Points";
            // 
            // StatsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvStats);
            Controls.Add(label9);
            Controls.Add(cboLeague);
            Name = "StatsForm";
            Text = "StatsForm";
            Load += StatsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStats).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label9;
        private ComboBox cboLeague;
        private DataGridView dgvStats;
        private DataGridViewTextBoxColumn Club;
        private DataGridViewTextBoxColumn Matches;
        private DataGridViewTextBoxColumn Wins;
        private DataGridViewTextBoxColumn Draws;
        private DataGridViewTextBoxColumn Losses;
        private DataGridViewTextBoxColumn Goals;
        private DataGridViewTextBoxColumn Points;
    }
}