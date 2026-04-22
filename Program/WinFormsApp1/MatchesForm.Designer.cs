namespace WinFormsApp1
{
    partial class MatchesForm
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
            cboLeague = new ComboBox();
            label1 = new Label();
            dgvMatches = new DataGridView();
            MatchId = new DataGridViewTextBoxColumn();
            HomeClubName = new DataGridViewTextBoxColumn();
            AwayClubName = new DataGridViewTextBoxColumn();
            Date = new DataGridViewTextBoxColumn();
            Round = new DataGridViewTextBoxColumn();
            label2 = new Label();
            label3 = new Label();
            cboHomeClub = new ComboBox();
            label4 = new Label();
            cboAwayClub = new ComboBox();
            dtpMatchDate = new DateTimePicker();
            label5 = new Label();
            cboRound = new ComboBox();
            label6 = new Label();
            buttonSaveChanges = new Button();
            buttonDeleteMatch = new Button();
            buttonAddMatch = new Button();
            label7 = new Label();
            dgvEvents = new DataGridView();
            EventType = new DataGridViewTextBoxColumn();
            ClubName = new DataGridViewTextBoxColumn();
            PlayerName = new DataGridViewTextBoxColumn();
            Minute = new DataGridViewTextBoxColumn();
            label8 = new Label();
            label9 = new Label();
            cboEventType = new ComboBox();
            label10 = new Label();
            numericUpDownMinute = new NumericUpDown();
            buttonSaveChangesEvents = new Button();
            buttonDeleteEvent = new Button();
            buttonAddEvent = new Button();
            label11 = new Label();
            cboEventClub = new ComboBox();
            label12 = new Label();
            cboEventPlayer = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvMatches).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEvents).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMinute).BeginInit();
            SuspendLayout();
            // 
            // cboLeague
            // 
            cboLeague.Font = new Font("Segoe UI", 14F);
            cboLeague.FormattingEnabled = true;
            cboLeague.Location = new Point(14, 49);
            cboLeague.Margin = new Padding(3, 4, 3, 4);
            cboLeague.Name = "cboLeague";
            cboLeague.Size = new Size(171, 39);
            cboLeague.TabIndex = 0;
            cboLeague.SelectedIndexChanged += cboLeague_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(14, 12);
            label1.Name = "label1";
            label1.Size = new Size(178, 32);
            label1.TabIndex = 1;
            label1.Text = "Избор на лига:";
            // 
            // dgvMatches
            // 
            dgvMatches.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMatches.Columns.AddRange(new DataGridViewColumn[] { MatchId, HomeClubName, AwayClubName, Date, Round });
            dgvMatches.Location = new Point(14, 137);
            dgvMatches.Margin = new Padding(3, 4, 3, 4);
            dgvMatches.Name = "dgvMatches";
            dgvMatches.RowHeadersWidth = 51;
            dgvMatches.Size = new Size(706, 327);
            dgvMatches.TabIndex = 5;
            dgvMatches.SelectionChanged += dgvMatches_SelectionChanged;
            // 
            // MatchId
            // 
            MatchId.DataPropertyName = "MatchId";
            MatchId.HeaderText = "ID";
            MatchId.MinimumWidth = 6;
            MatchId.Name = "MatchId";
            MatchId.ReadOnly = true;
            MatchId.Width = 50;
            // 
            // HomeClubName
            // 
            HomeClubName.DataPropertyName = "HomeClubName";
            HomeClubName.HeaderText = "Домакин";
            HomeClubName.MinimumWidth = 6;
            HomeClubName.Name = "HomeClubName";
            HomeClubName.ReadOnly = true;
            HomeClubName.Width = 150;
            // 
            // AwayClubName
            // 
            AwayClubName.DataPropertyName = "AwayClubName";
            AwayClubName.HeaderText = "Гост";
            AwayClubName.MinimumWidth = 6;
            AwayClubName.Name = "AwayClubName";
            AwayClubName.ReadOnly = true;
            AwayClubName.Width = 150;
            // 
            // Date
            // 
            Date.DataPropertyName = "Date";
            Date.HeaderText = "Дата";
            Date.MinimumWidth = 6;
            Date.Name = "Date";
            Date.ReadOnly = true;
            Date.Width = 125;
            // 
            // Round
            // 
            Round.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Round.DataPropertyName = "Round";
            Round.HeaderText = "Рунд";
            Round.MinimumWidth = 6;
            Round.Name = "Round";
            Round.ReadOnly = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(14, 100);
            label2.Name = "label2";
            label2.Size = new Size(173, 32);
            label2.TabIndex = 6;
            label2.Text = "Избор на мач:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(192, 12);
            label3.Name = "label3";
            label3.Size = new Size(119, 32);
            label3.TabIndex = 11;
            label3.Text = "Домакин:";
            // 
            // cboHomeClub
            // 
            cboHomeClub.DropDownStyle = ComboBoxStyle.DropDownList;
            cboHomeClub.Font = new Font("Segoe UI", 14F);
            cboHomeClub.FormattingEnabled = true;
            cboHomeClub.Location = new Point(192, 49);
            cboHomeClub.Margin = new Padding(3, 4, 3, 4);
            cboHomeClub.Name = "cboHomeClub";
            cboHomeClub.Size = new Size(147, 39);
            cboHomeClub.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F);
            label4.Location = new Point(346, 12);
            label4.Name = "label4";
            label4.Size = new Size(65, 32);
            label4.TabIndex = 13;
            label4.Text = "Гост:";
            // 
            // cboAwayClub
            // 
            cboAwayClub.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAwayClub.Font = new Font("Segoe UI", 14F);
            cboAwayClub.FormattingEnabled = true;
            cboAwayClub.Location = new Point(346, 49);
            cboAwayClub.Margin = new Padding(3, 4, 3, 4);
            cboAwayClub.Name = "cboAwayClub";
            cboAwayClub.Size = new Size(147, 39);
            cboAwayClub.TabIndex = 12;
            // 
            // dtpMatchDate
            // 
            dtpMatchDate.Location = new Point(655, 63);
            dtpMatchDate.Margin = new Padding(3, 4, 3, 4);
            dtpMatchDate.Name = "dtpMatchDate";
            dtpMatchDate.Size = new Size(228, 27);
            dtpMatchDate.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F);
            label5.Location = new Point(501, 12);
            label5.Name = "label5";
            label5.Size = new Size(71, 32);
            label5.TabIndex = 16;
            label5.Text = "Рунд:";
            // 
            // cboRound
            // 
            cboRound.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRound.Font = new Font("Segoe UI", 14F);
            cboRound.FormattingEnabled = true;
            cboRound.Items.AddRange(new object[] { "1", "2" });
            cboRound.Location = new Point(501, 49);
            cboRound.Margin = new Padding(3, 4, 3, 4);
            cboRound.Name = "cboRound";
            cboRound.Size = new Size(147, 39);
            cboRound.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14F);
            label6.Location = new Point(655, 12);
            label6.Name = "label6";
            label6.Size = new Size(70, 32);
            label6.TabIndex = 17;
            label6.Text = "Дата:";
            // 
            // buttonSaveChanges
            // 
            buttonSaveChanges.Font = new Font("Segoe UI", 14F);
            buttonSaveChanges.Location = new Point(736, 264);
            buttonSaveChanges.Margin = new Padding(3, 4, 3, 4);
            buttonSaveChanges.Name = "buttonSaveChanges";
            buttonSaveChanges.Size = new Size(147, 80);
            buttonSaveChanges.TabIndex = 20;
            buttonSaveChanges.Text = "Запази промените";
            buttonSaveChanges.UseVisualStyleBackColor = true;
            buttonSaveChanges.Click += buttonSaveChanges_Click;
            // 
            // buttonDeleteMatch
            // 
            buttonDeleteMatch.Font = new Font("Segoe UI", 14F);
            buttonDeleteMatch.Location = new Point(736, 384);
            buttonDeleteMatch.Margin = new Padding(3, 4, 3, 4);
            buttonDeleteMatch.Name = "buttonDeleteMatch";
            buttonDeleteMatch.Size = new Size(147, 80);
            buttonDeleteMatch.TabIndex = 19;
            buttonDeleteMatch.Text = "Изтрий мач";
            buttonDeleteMatch.UseVisualStyleBackColor = true;
            buttonDeleteMatch.Click += buttonDeleteMatch_Click;
            // 
            // buttonAddMatch
            // 
            buttonAddMatch.Font = new Font("Segoe UI", 14F);
            buttonAddMatch.Location = new Point(736, 136);
            buttonAddMatch.Margin = new Padding(3, 4, 3, 4);
            buttonAddMatch.Name = "buttonAddMatch";
            buttonAddMatch.Size = new Size(147, 80);
            buttonAddMatch.TabIndex = 18;
            buttonAddMatch.Text = "Добави мач";
            buttonAddMatch.UseVisualStyleBackColor = true;
            buttonAddMatch.Click += buttonAddMatch_Click;
            // 
            // label7
            // 
            label7.BackColor = SystemColors.ControlDark;
            label7.Location = new Point(19, 480);
            label7.Name = "label7";
            label7.Size = new Size(857, 1);
            label7.TabIndex = 21;
            // 
            // dgvEvents
            // 
            dgvEvents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEvents.Columns.AddRange(new DataGridViewColumn[] { EventType, ClubName, PlayerName, Minute });
            dgvEvents.Location = new Point(14, 527);
            dgvEvents.Margin = new Padding(3, 4, 3, 4);
            dgvEvents.Name = "dgvEvents";
            dgvEvents.RowHeadersWidth = 51;
            dgvEvents.Size = new Size(706, 312);
            dgvEvents.TabIndex = 22;
            // 
            // EventType
            // 
            EventType.HeaderText = "Събитие";
            EventType.MinimumWidth = 6;
            EventType.Name = "EventType";
            EventType.Width = 150;
            // 
            // ClubName
            // 
            ClubName.DataPropertyName = "ClubName";
            ClubName.HeaderText = "Клуб";
            ClubName.MinimumWidth = 6;
            ClubName.Name = "ClubName";
            ClubName.ReadOnly = true;
            ClubName.Width = 150;
            // 
            // PlayerName
            // 
            PlayerName.DataPropertyName = "PlayerName";
            PlayerName.HeaderText = "Играч";
            PlayerName.MinimumWidth = 6;
            PlayerName.Name = "PlayerName";
            PlayerName.ReadOnly = true;
            PlayerName.Width = 150;
            // 
            // Minute
            // 
            Minute.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Minute.DataPropertyName = "Minute";
            Minute.HeaderText = "Минута";
            Minute.MinimumWidth = 6;
            Minute.Name = "Minute";
            Minute.ReadOnly = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14F);
            label8.Location = new Point(14, 489);
            label8.Name = "label8";
            label8.Size = new Size(112, 32);
            label8.TabIndex = 23;
            label8.Text = "Събития:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 14F);
            label9.Location = new Point(736, 525);
            label9.Name = "label9";
            label9.Size = new Size(157, 32);
            label9.TabIndex = 25;
            label9.Text = "Тип събитие:";
            // 
            // cboEventType
            // 
            cboEventType.Font = new Font("Segoe UI", 14F);
            cboEventType.FormattingEnabled = true;
            cboEventType.Items.AddRange(new object[] { "Гол", "Жълт картон", "Червен картон", "Фал" });
            cboEventType.Location = new Point(736, 562);
            cboEventType.Margin = new Padding(3, 4, 3, 4);
            cboEventType.Name = "cboEventType";
            cboEventType.Size = new Size(147, 39);
            cboEventType.TabIndex = 24;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 14F);
            label10.Location = new Point(736, 762);
            label10.Name = "label10";
            label10.Size = new Size(103, 32);
            label10.TabIndex = 27;
            label10.Text = "Минута:";
            // 
            // numericUpDownMinute
            // 
            numericUpDownMinute.Font = new Font("Segoe UI", 14F);
            numericUpDownMinute.Location = new Point(736, 800);
            numericUpDownMinute.Margin = new Padding(3, 4, 3, 4);
            numericUpDownMinute.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            numericUpDownMinute.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownMinute.Name = "numericUpDownMinute";
            numericUpDownMinute.Size = new Size(147, 39);
            numericUpDownMinute.TabIndex = 28;
            numericUpDownMinute.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // buttonSaveChangesEvents
            // 
            buttonSaveChangesEvents.Font = new Font("Segoe UI", 14F);
            buttonSaveChangesEvents.Location = new Point(296, 847);
            buttonSaveChangesEvents.Margin = new Padding(3, 4, 3, 4);
            buttonSaveChangesEvents.Name = "buttonSaveChangesEvents";
            buttonSaveChangesEvents.Size = new Size(147, 80);
            buttonSaveChangesEvents.TabIndex = 31;
            buttonSaveChangesEvents.Text = "Запази промените";
            buttonSaveChangesEvents.UseVisualStyleBackColor = true;
            buttonSaveChangesEvents.Click += buttonSaveChangesEvents_Click;
            // 
            // buttonDeleteEvent
            // 
            buttonDeleteEvent.Font = new Font("Segoe UI", 14F);
            buttonDeleteEvent.Location = new Point(573, 847);
            buttonDeleteEvent.Margin = new Padding(3, 4, 3, 4);
            buttonDeleteEvent.Name = "buttonDeleteEvent";
            buttonDeleteEvent.Size = new Size(147, 80);
            buttonDeleteEvent.TabIndex = 30;
            buttonDeleteEvent.Text = "Изтрий събитие";
            buttonDeleteEvent.UseVisualStyleBackColor = true;
            buttonDeleteEvent.Click += buttonDeleteEvent_Click;
            // 
            // buttonAddEvent
            // 
            buttonAddEvent.Font = new Font("Segoe UI", 14F);
            buttonAddEvent.Location = new Point(14, 847);
            buttonAddEvent.Margin = new Padding(3, 4, 3, 4);
            buttonAddEvent.Name = "buttonAddEvent";
            buttonAddEvent.Size = new Size(147, 80);
            buttonAddEvent.TabIndex = 29;
            buttonAddEvent.Text = "Добави събитие";
            buttonAddEvent.UseVisualStyleBackColor = true;
            buttonAddEvent.Click += buttonAddEvent_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 14F);
            label11.Location = new Point(736, 606);
            label11.Name = "label11";
            label11.Size = new Size(72, 32);
            label11.TabIndex = 33;
            label11.Text = "Клуб:";
            // 
            // cboEventClub
            // 
            cboEventClub.Font = new Font("Segoe UI", 14F);
            cboEventClub.FormattingEnabled = true;
            cboEventClub.Items.AddRange(new object[] { "Гол", "Жълт картон", "Червен картон", "Фал" });
            cboEventClub.Location = new Point(736, 643);
            cboEventClub.Margin = new Padding(3, 4, 3, 4);
            cboEventClub.Name = "cboEventClub";
            cboEventClub.Size = new Size(147, 39);
            cboEventClub.TabIndex = 32;
            cboEventClub.SelectedIndexChanged += cboEventClub_SelectedIndexChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 14F);
            label12.Location = new Point(736, 684);
            label12.Name = "label12";
            label12.Size = new Size(86, 32);
            label12.TabIndex = 35;
            label12.Text = "Играч:";
            // 
            // cboEventPlayer
            // 
            cboEventPlayer.Font = new Font("Segoe UI", 14F);
            cboEventPlayer.FormattingEnabled = true;
            cboEventPlayer.Items.AddRange(new object[] { "Гол", "Жълт картон", "Червен картон", "Фал" });
            cboEventPlayer.Location = new Point(736, 721);
            cboEventPlayer.Margin = new Padding(3, 4, 3, 4);
            cboEventPlayer.Name = "cboEventPlayer";
            cboEventPlayer.Size = new Size(147, 39);
            cboEventPlayer.TabIndex = 34;
            // 
            // MatchesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(891, 940);
            Controls.Add(label12);
            Controls.Add(cboEventPlayer);
            Controls.Add(label11);
            Controls.Add(cboEventClub);
            Controls.Add(buttonSaveChangesEvents);
            Controls.Add(buttonDeleteEvent);
            Controls.Add(buttonAddEvent);
            Controls.Add(numericUpDownMinute);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(cboEventType);
            Controls.Add(label8);
            Controls.Add(dgvEvents);
            Controls.Add(label7);
            Controls.Add(buttonSaveChanges);
            Controls.Add(buttonDeleteMatch);
            Controls.Add(buttonAddMatch);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(cboRound);
            Controls.Add(dtpMatchDate);
            Controls.Add(label4);
            Controls.Add(cboAwayClub);
            Controls.Add(label3);
            Controls.Add(cboHomeClub);
            Controls.Add(label2);
            Controls.Add(dgvMatches);
            Controls.Add(label1);
            Controls.Add(cboLeague);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MatchesForm";
            Text = "MatchesForm";
            Load += MatchesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMatches).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEvents).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMinute).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboLeague;
        private Label label1;
        private DataGridView dgvMatches;
        private Label label2;
        private Label label3;
        private ComboBox cboHomeClub;
        private Label label4;
        private ComboBox cboAwayClub;
        private DateTimePicker dtpMatchDate;
        private Label label5;
        private ComboBox cboRound;
        private Label label6;
        private DataGridViewTextBoxColumn MatchId;
        private DataGridViewTextBoxColumn HomeClubName;
        private DataGridViewTextBoxColumn AwayClubName;
        private DataGridViewTextBoxColumn Date;
        private DataGridViewTextBoxColumn Round;
        private Button buttonSaveChanges;
        private Button buttonDeleteMatch;
        private Button buttonAddMatch;
        private Label label7;
        private DataGridView dgvEvents;
        private Label label8;
        private Label label9;
        private ComboBox cboEventType;
        private Label label10;
        private NumericUpDown numericUpDownMinute;
        private Button buttonSaveChangesEvents;
        private Button buttonDeleteEvent;
        private Button buttonAddEvent;
        private DataGridViewTextBoxColumn EventType;
        private DataGridViewTextBoxColumn ClubName;
        private DataGridViewTextBoxColumn PlayerName;
        private DataGridViewTextBoxColumn Minute;
        private Label label11;
        private ComboBox cboEventClub;
        private Label label12;
        private ComboBox cboEventPlayer;
    }
}