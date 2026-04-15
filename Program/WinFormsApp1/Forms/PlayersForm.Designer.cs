namespace WinFormsApp1
{
    partial class PlayersForm
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
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBoxNationality = new TextBox();
            textBoxPlayerName = new TextBox();
            buttonDelete = new Button();
            buttonSave = new Button();
            dataGridViewPlayers = new DataGridView();
            playerIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fullNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dateOfBirthDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nationalityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            positionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            numberDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dominantFootDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            salaryDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            statusDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ClubName = new DataGridViewTextBoxColumn();
            playerBindingSource = new BindingSource(components);
            buttonAdd = new Button();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            textBoxSalary = new TextBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            textBoxNumber = new TextBox();
            comboBoxDominantFoot = new ComboBox();
            comboBoxPosition = new ComboBox();
            comboBoxClubName = new ComboBox();
            dateTimePickerBirthDate = new DateTimePicker();
            comboBoxStatus = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPlayers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)playerBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(328, 24);
            label3.Name = "label3";
            label3.Size = new Size(170, 32);
            label3.TabIndex = 19;
            label3.Text = "Рождена дата:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(17, 24);
            label2.Name = "label2";
            label2.Size = new Size(170, 32);
            label2.TabIndex = 18;
            label2.Text = "Име на играч:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(657, 24);
            label1.Name = "label1";
            label1.Size = new Size(178, 32);
            label1.TabIndex = 17;
            label1.Text = "Националност:";
            // 
            // textBoxNationality
            // 
            textBoxNationality.Location = new Point(657, 60);
            textBoxNationality.Margin = new Padding(3, 4, 3, 4);
            textBoxNationality.Name = "textBoxNationality";
            textBoxNationality.Size = new Size(175, 27);
            textBoxNationality.TabIndex = 15;
            // 
            // textBoxPlayerName
            // 
            textBoxPlayerName.Location = new Point(17, 60);
            textBoxPlayerName.Margin = new Padding(3, 4, 3, 4);
            textBoxPlayerName.Name = "textBoxPlayerName";
            textBoxPlayerName.Size = new Size(175, 27);
            textBoxPlayerName.TabIndex = 14;
            // 
            // buttonDelete
            // 
            buttonDelete.Font = new Font("Segoe UI", 12F);
            buttonDelete.Location = new Point(944, 513);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(128, 67);
            buttonDelete.TabIndex = 13;
            buttonDelete.Text = "Изтрий";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonSave
            // 
            buttonSave.Font = new Font("Segoe UI", 12F);
            buttonSave.Location = new Point(491, 513);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(128, 67);
            buttonSave.TabIndex = 12;
            buttonSave.Text = "Запази промените";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // dataGridViewPlayers
            // 
            dataGridViewPlayers.AutoGenerateColumns = false;
            dataGridViewPlayers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPlayers.Columns.AddRange(new DataGridViewColumn[] { playerIdDataGridViewTextBoxColumn, fullNameDataGridViewTextBoxColumn, dateOfBirthDataGridViewTextBoxColumn, nationalityDataGridViewTextBoxColumn, positionDataGridViewTextBoxColumn, numberDataGridViewTextBoxColumn, dominantFootDataGridViewTextBoxColumn, salaryDataGridViewTextBoxColumn, statusDataGridViewTextBoxColumn, ClubName });
            dataGridViewPlayers.DataSource = playerBindingSource;
            dataGridViewPlayers.Location = new Point(11, 253);
            dataGridViewPlayers.Name = "dataGridViewPlayers";
            dataGridViewPlayers.RowHeadersWidth = 51;
            dataGridViewPlayers.Size = new Size(1061, 245);
            dataGridViewPlayers.TabIndex = 11;
            // 
            // playerIdDataGridViewTextBoxColumn
            // 
            playerIdDataGridViewTextBoxColumn.DataPropertyName = "PlayerId";
            playerIdDataGridViewTextBoxColumn.HeaderText = "ID";
            playerIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            playerIdDataGridViewTextBoxColumn.Name = "playerIdDataGridViewTextBoxColumn";
            playerIdDataGridViewTextBoxColumn.ReadOnly = true;
            playerIdDataGridViewTextBoxColumn.Width = 50;
            // 
            // fullNameDataGridViewTextBoxColumn
            // 
            fullNameDataGridViewTextBoxColumn.DataPropertyName = "FullName";
            fullNameDataGridViewTextBoxColumn.HeaderText = "Име";
            fullNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
            fullNameDataGridViewTextBoxColumn.ReadOnly = true;
            fullNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // dateOfBirthDataGridViewTextBoxColumn
            // 
            dateOfBirthDataGridViewTextBoxColumn.DataPropertyName = "DateOfBirth";
            dateOfBirthDataGridViewTextBoxColumn.HeaderText = "Рождена дата";
            dateOfBirthDataGridViewTextBoxColumn.MinimumWidth = 6;
            dateOfBirthDataGridViewTextBoxColumn.Name = "dateOfBirthDataGridViewTextBoxColumn";
            dateOfBirthDataGridViewTextBoxColumn.ReadOnly = true;
            dateOfBirthDataGridViewTextBoxColumn.Width = 125;
            // 
            // nationalityDataGridViewTextBoxColumn
            // 
            nationalityDataGridViewTextBoxColumn.DataPropertyName = "Nationality";
            nationalityDataGridViewTextBoxColumn.HeaderText = "Националност";
            nationalityDataGridViewTextBoxColumn.MinimumWidth = 6;
            nationalityDataGridViewTextBoxColumn.Name = "nationalityDataGridViewTextBoxColumn";
            nationalityDataGridViewTextBoxColumn.ReadOnly = true;
            nationalityDataGridViewTextBoxColumn.Width = 125;
            // 
            // positionDataGridViewTextBoxColumn
            // 
            positionDataGridViewTextBoxColumn.DataPropertyName = "Position";
            positionDataGridViewTextBoxColumn.HeaderText = "Позиция";
            positionDataGridViewTextBoxColumn.MinimumWidth = 6;
            positionDataGridViewTextBoxColumn.Name = "positionDataGridViewTextBoxColumn";
            positionDataGridViewTextBoxColumn.ReadOnly = true;
            positionDataGridViewTextBoxColumn.Width = 75;
            // 
            // numberDataGridViewTextBoxColumn
            // 
            numberDataGridViewTextBoxColumn.DataPropertyName = "Number";
            numberDataGridViewTextBoxColumn.HeaderText = "Номер";
            numberDataGridViewTextBoxColumn.MinimumWidth = 6;
            numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
            numberDataGridViewTextBoxColumn.ReadOnly = true;
            numberDataGridViewTextBoxColumn.Width = 75;
            // 
            // dominantFootDataGridViewTextBoxColumn
            // 
            dominantFootDataGridViewTextBoxColumn.DataPropertyName = "DominantFoot";
            dominantFootDataGridViewTextBoxColumn.HeaderText = "Доминираш крак";
            dominantFootDataGridViewTextBoxColumn.MinimumWidth = 6;
            dominantFootDataGridViewTextBoxColumn.Name = "dominantFootDataGridViewTextBoxColumn";
            dominantFootDataGridViewTextBoxColumn.ReadOnly = true;
            dominantFootDataGridViewTextBoxColumn.Width = 75;
            // 
            // salaryDataGridViewTextBoxColumn
            // 
            salaryDataGridViewTextBoxColumn.DataPropertyName = "Salary";
            salaryDataGridViewTextBoxColumn.HeaderText = "Заплата";
            salaryDataGridViewTextBoxColumn.MinimumWidth = 6;
            salaryDataGridViewTextBoxColumn.Name = "salaryDataGridViewTextBoxColumn";
            salaryDataGridViewTextBoxColumn.ReadOnly = true;
            salaryDataGridViewTextBoxColumn.Width = 125;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            statusDataGridViewTextBoxColumn.HeaderText = "Статус";
            statusDataGridViewTextBoxColumn.MinimumWidth = 6;
            statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            statusDataGridViewTextBoxColumn.ReadOnly = true;
            statusDataGridViewTextBoxColumn.Width = 125;
            // 
            // ClubName
            // 
            ClubName.DataPropertyName = "ClubName";
            ClubName.HeaderText = "Клуб";
            ClubName.MinimumWidth = 6;
            ClubName.Name = "ClubName";
            ClubName.ReadOnly = true;
            ClubName.Width = 125;
            // 
            // playerBindingSource
            // 
            playerBindingSource.DataSource = typeof(Data.Models.Player);
            // 
            // buttonAdd
            // 
            buttonAdd.Font = new Font("Segoe UI", 12F);
            buttonAdd.Location = new Point(11, 513);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(128, 67);
            buttonAdd.TabIndex = 10;
            buttonAdd.Text = "Добави";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F);
            label4.Location = new Point(442, 140);
            label4.Name = "label4";
            label4.Size = new Size(105, 32);
            label4.TabIndex = 25;
            label4.Text = "Заплата:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F);
            label5.Location = new Point(230, 140);
            label5.Name = "label5";
            label5.Size = new Size(212, 32);
            label5.TabIndex = 24;
            label5.Text = "Доминиращ крак:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14F);
            label6.Location = new Point(657, 140);
            label6.Name = "label6";
            label6.Size = new Size(89, 32);
            label6.TabIndex = 23;
            label6.Text = "Статус:";
            // 
            // textBoxSalary
            // 
            textBoxSalary.Location = new Point(442, 176);
            textBoxSalary.Margin = new Padding(3, 4, 3, 4);
            textBoxSalary.Name = "textBoxSalary";
            textBoxSalary.Size = new Size(175, 27);
            textBoxSalary.TabIndex = 22;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14F);
            label7.Location = new Point(17, 140);
            label7.Name = "label7";
            label7.Size = new Size(94, 32);
            label7.TabIndex = 31;
            label7.Text = "Номер:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14F);
            label8.Location = new Point(865, 24);
            label8.Name = "label8";
            label8.Size = new Size(115, 32);
            label8.TabIndex = 30;
            label8.Text = "Позиция:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 14F);
            label9.Location = new Point(865, 140);
            label9.Name = "label9";
            label9.Size = new Size(158, 32);
            label9.TabIndex = 29;
            label9.Text = "Име на клуб:";
            // 
            // textBoxNumber
            // 
            textBoxNumber.Location = new Point(17, 176);
            textBoxNumber.Margin = new Padding(3, 4, 3, 4);
            textBoxNumber.Name = "textBoxNumber";
            textBoxNumber.Size = new Size(175, 27);
            textBoxNumber.TabIndex = 28;
            // 
            // comboBoxDominantFoot
            // 
            comboBoxDominantFoot.FormattingEnabled = true;
            comboBoxDominantFoot.Location = new Point(230, 176);
            comboBoxDominantFoot.Margin = new Padding(3, 4, 3, 4);
            comboBoxDominantFoot.Name = "comboBoxDominantFoot";
            comboBoxDominantFoot.Size = new Size(175, 28);
            comboBoxDominantFoot.TabIndex = 33;
            // 
            // comboBoxPosition
            // 
            comboBoxPosition.FormattingEnabled = true;
            comboBoxPosition.Location = new Point(865, 60);
            comboBoxPosition.Margin = new Padding(3, 4, 3, 4);
            comboBoxPosition.Name = "comboBoxPosition";
            comboBoxPosition.Size = new Size(175, 28);
            comboBoxPosition.TabIndex = 34;
            // 
            // comboBoxClubName
            // 
            comboBoxClubName.Enabled = false;
            comboBoxClubName.FormattingEnabled = true;
            comboBoxClubName.Location = new Point(865, 176);
            comboBoxClubName.Margin = new Padding(3, 4, 3, 4);
            comboBoxClubName.Name = "comboBoxClubName";
            comboBoxClubName.Size = new Size(175, 28);
            comboBoxClubName.TabIndex = 35;
            // 
            // dateTimePickerBirthDate
            // 
            dateTimePickerBirthDate.Location = new Point(328, 60);
            dateTimePickerBirthDate.Margin = new Padding(3, 4, 3, 4);
            dateTimePickerBirthDate.Name = "dateTimePickerBirthDate";
            dateTimePickerBirthDate.Size = new Size(228, 27);
            dateTimePickerBirthDate.TabIndex = 36;
            // 
            // comboBoxStatus
            // 
            comboBoxStatus.FormattingEnabled = true;
            comboBoxStatus.Location = new Point(657, 176);
            comboBoxStatus.Margin = new Padding(3, 4, 3, 4);
            comboBoxStatus.Name = "comboBoxStatus";
            comboBoxStatus.Size = new Size(175, 28);
            comboBoxStatus.TabIndex = 37;
            // 
            // PlayersForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1080, 600);
            Controls.Add(comboBoxStatus);
            Controls.Add(dateTimePickerBirthDate);
            Controls.Add(comboBoxClubName);
            Controls.Add(comboBoxPosition);
            Controls.Add(comboBoxDominantFoot);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(textBoxNumber);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(textBoxSalary);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxNationality);
            Controls.Add(textBoxPlayerName);
            Controls.Add(buttonDelete);
            Controls.Add(buttonSave);
            Controls.Add(dataGridViewPlayers);
            Controls.Add(buttonAdd);
            Margin = new Padding(3, 4, 3, 4);
            Name = "PlayersForm";
            Text = "PlayersForm";
            FormClosing += PlayersForm_FormClosing;
            Load += PlayersForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewPlayers).EndInit();
            ((System.ComponentModel.ISupportInitialize)playerBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBoxNationality;
        private TextBox textBoxPlayerName;
        private Button buttonDelete;
        private Button buttonSave;
        private DataGridView dataGridViewPlayers;
        private BindingSource playerBindingSource;
        private Button buttonAdd;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textBoxSalary;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox textBoxNumber;
        private ComboBox comboBoxDominantFoot;
        private ComboBox comboBoxPosition;
        private ComboBox comboBoxClubName;
        private DateTimePicker dateTimePickerBirthDate;
        private ComboBox comboBoxStatus;
        private DataGridViewTextBoxColumn playerIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dateOfBirthDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nationalityDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn positionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dominantFootDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn salaryDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ClubName;
    }
}