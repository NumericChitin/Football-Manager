namespace WinFormsApp1
{
    partial class LeaguesForm
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
            components = new System.ComponentModel.Container();
            dgvLeagues = new DataGridView();
            leagueIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            seasonDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            numberClubsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            leagueBindingSource = new BindingSource(components);
            dgvParticipants = new DataGridView();
            cboAvailableClubs = new ComboBox();
            buttonAddLeague = new Button();
            buttonEditLeague = new Button();
            buttonDeleteLeague = new Button();
            buttonAddClubToLeague = new Button();
            buttonRemoveClubFromLeague = new Button();
            buttonSaveChanges = new Button();
            label1 = new Label();
            tbLeagueName = new TextBox();
            label2 = new Label();
            label3 = new Label();
            tbSeason = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvLeagues).BeginInit();
            ((System.ComponentModel.ISupportInitialize)leagueBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvParticipants).BeginInit();
            SuspendLayout();
            // 
            // dgvLeagues
            // 
            dgvLeagues.AutoGenerateColumns = false;
            dgvLeagues.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLeagues.Columns.AddRange(new DataGridViewColumn[] { leagueIdDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, seasonDataGridViewTextBoxColumn, numberClubsDataGridViewTextBoxColumn });
            dgvLeagues.DataSource = leagueBindingSource;
            dgvLeagues.Location = new Point(12, 12);
            dgvLeagues.Name = "dgvLeagues";
            dgvLeagues.Size = new Size(425, 597);
            dgvLeagues.TabIndex = 0;
            dgvLeagues.SelectionChanged += dgvLeagues_SelectionChanged;
            // 
            // leagueIdDataGridViewTextBoxColumn
            // 
            leagueIdDataGridViewTextBoxColumn.DataPropertyName = "LeagueId";
            leagueIdDataGridViewTextBoxColumn.HeaderText = "ID";
            leagueIdDataGridViewTextBoxColumn.Name = "leagueIdDataGridViewTextBoxColumn";
            leagueIdDataGridViewTextBoxColumn.ReadOnly = true;
            leagueIdDataGridViewTextBoxColumn.Width = 50;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Име на лига";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            nameDataGridViewTextBoxColumn.Width = 175;
            // 
            // seasonDataGridViewTextBoxColumn
            // 
            seasonDataGridViewTextBoxColumn.DataPropertyName = "Season";
            seasonDataGridViewTextBoxColumn.HeaderText = "Сезон";
            seasonDataGridViewTextBoxColumn.Name = "seasonDataGridViewTextBoxColumn";
            seasonDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numberClubsDataGridViewTextBoxColumn
            // 
            numberClubsDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            numberClubsDataGridViewTextBoxColumn.DataPropertyName = "NumberClubs";
            numberClubsDataGridViewTextBoxColumn.HeaderText = "Брой клубове";
            numberClubsDataGridViewTextBoxColumn.Name = "numberClubsDataGridViewTextBoxColumn";
            numberClubsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // leagueBindingSource
            // 
            leagueBindingSource.DataSource = typeof(Data.Models.League);
            // 
            // dgvParticipants
            // 
            dgvParticipants.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvParticipants.Location = new Point(443, 12);
            dgvParticipants.Name = "dgvParticipants";
            dgvParticipants.Size = new Size(476, 374);
            dgvParticipants.TabIndex = 1;
            // 
            // cboAvailableClubs
            // 
            cboAvailableClubs.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAvailableClubs.Font = new Font("Segoe UI", 14F);
            cboAvailableClubs.FormattingEnabled = true;
            cboAvailableClubs.Location = new Point(790, 417);
            cboAvailableClubs.Name = "cboAvailableClubs";
            cboAvailableClubs.Size = new Size(129, 33);
            cboAvailableClubs.TabIndex = 2;
            // 
            // buttonAddLeague
            // 
            buttonAddLeague.Font = new Font("Segoe UI", 14F);
            buttonAddLeague.Location = new Point(451, 470);
            buttonAddLeague.Name = "buttonAddLeague";
            buttonAddLeague.Size = new Size(129, 60);
            buttonAddLeague.TabIndex = 3;
            buttonAddLeague.Text = "Добави лига";
            buttonAddLeague.UseVisualStyleBackColor = true;
            buttonAddLeague.Click += buttonAddLeague_Click;
            // 
            // buttonEditLeague
            // 
            buttonEditLeague.Font = new Font("Segoe UI", 14F);
            buttonEditLeague.Location = new Point(620, 470);
            buttonEditLeague.Name = "buttonEditLeague";
            buttonEditLeague.Size = new Size(129, 60);
            buttonEditLeague.TabIndex = 4;
            buttonEditLeague.Text = "Редактирай лига";
            buttonEditLeague.UseVisualStyleBackColor = true;
            buttonEditLeague.Click += buttonEditLeague_Click;
            // 
            // buttonDeleteLeague
            // 
            buttonDeleteLeague.Font = new Font("Segoe UI", 14F);
            buttonDeleteLeague.Location = new Point(790, 470);
            buttonDeleteLeague.Name = "buttonDeleteLeague";
            buttonDeleteLeague.Size = new Size(129, 60);
            buttonDeleteLeague.TabIndex = 5;
            buttonDeleteLeague.Text = "Изтрий лига";
            buttonDeleteLeague.UseVisualStyleBackColor = true;
            buttonDeleteLeague.Click += buttonDeleteLeague_Click;
            // 
            // buttonAddClubToLeague
            // 
            buttonAddClubToLeague.Font = new Font("Segoe UI", 14F);
            buttonAddClubToLeague.Location = new Point(451, 549);
            buttonAddClubToLeague.Name = "buttonAddClubToLeague";
            buttonAddClubToLeague.Size = new Size(129, 60);
            buttonAddClubToLeague.TabIndex = 6;
            buttonAddClubToLeague.Text = "Добави клуб";
            buttonAddClubToLeague.UseVisualStyleBackColor = true;
            buttonAddClubToLeague.Click += buttonAddClubToLeague_Click;
            // 
            // buttonRemoveClubFromLeague
            // 
            buttonRemoveClubFromLeague.Font = new Font("Segoe UI", 14F);
            buttonRemoveClubFromLeague.Location = new Point(620, 549);
            buttonRemoveClubFromLeague.Name = "buttonRemoveClubFromLeague";
            buttonRemoveClubFromLeague.Size = new Size(129, 60);
            buttonRemoveClubFromLeague.TabIndex = 7;
            buttonRemoveClubFromLeague.Text = "Премахни клуб";
            buttonRemoveClubFromLeague.UseVisualStyleBackColor = true;
            buttonRemoveClubFromLeague.Click += buttonRemoveClubFromLeague_Click;
            // 
            // buttonSaveChanges
            // 
            buttonSaveChanges.Font = new Font("Segoe UI", 14F);
            buttonSaveChanges.Location = new Point(790, 549);
            buttonSaveChanges.Name = "buttonSaveChanges";
            buttonSaveChanges.Size = new Size(129, 60);
            buttonSaveChanges.TabIndex = 8;
            buttonSaveChanges.Text = "Запази промените";
            buttonSaveChanges.UseVisualStyleBackColor = true;
            buttonSaveChanges.Click += buttonSaveChanges_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(751, 389);
            label1.Name = "label1";
            label1.Size = new Size(168, 25);
            label1.TabIndex = 9;
            label1.Text = "Налични клубове:";
            // 
            // tbLeagueName
            // 
            tbLeagueName.Font = new Font("Segoe UI", 14F);
            tbLeagueName.Location = new Point(451, 417);
            tbLeagueName.Name = "tbLeagueName";
            tbLeagueName.Size = new Size(129, 32);
            tbLeagueName.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(451, 389);
            label2.Name = "label2";
            label2.Size = new Size(122, 25);
            label2.TabIndex = 11;
            label2.Text = "Име на лига:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(620, 389);
            label3.Name = "label3";
            label3.Size = new Size(122, 25);
            label3.TabIndex = 13;
            label3.Text = "Име на лига:";
            // 
            // tbSeason
            // 
            tbSeason.Font = new Font("Segoe UI", 14F);
            tbSeason.Location = new Point(620, 417);
            tbSeason.Name = "tbSeason";
            tbSeason.Size = new Size(129, 32);
            tbSeason.TabIndex = 12;
            // 
            // LeaguesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(931, 621);
            Controls.Add(label3);
            Controls.Add(tbSeason);
            Controls.Add(label2);
            Controls.Add(tbLeagueName);
            Controls.Add(label1);
            Controls.Add(buttonSaveChanges);
            Controls.Add(buttonRemoveClubFromLeague);
            Controls.Add(buttonAddClubToLeague);
            Controls.Add(buttonDeleteLeague);
            Controls.Add(buttonEditLeague);
            Controls.Add(buttonAddLeague);
            Controls.Add(cboAvailableClubs);
            Controls.Add(dgvParticipants);
            Controls.Add(dgvLeagues);
            Name = "LeaguesForm";
            Text = "LeaguesForm";
            Load += LeaguesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLeagues).EndInit();
            ((System.ComponentModel.ISupportInitialize)leagueBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvParticipants).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvLeagues;
        private DataGridViewTextBoxColumn leagueIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn seasonDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn numberClubsDataGridViewTextBoxColumn;
        private BindingSource leagueBindingSource;
        private DataGridView dgvParticipants;
        private ComboBox cboAvailableClubs;
        private Button buttonAddLeague;
        private Button buttonEditLeague;
        private Button buttonDeleteLeague;
        private Button buttonAddClubToLeague;
        private Button buttonRemoveClubFromLeague;
        private Button buttonSaveChanges;
        private Label label1;
        private TextBox tbLeagueName;
        private Label label2;
        private Label label3;
        private TextBox tbSeason;
    }
}