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
            clubDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
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
            label3.Location = new Point(287, 18);
            label3.Name = "label3";
            label3.Size = new Size(136, 25);
            label3.TabIndex = 19;
            label3.Text = "Рождена дата:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(15, 18);
            label2.Name = "label2";
            label2.Size = new Size(134, 25);
            label2.TabIndex = 18;
            label2.Text = "Име на играч:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(575, 18);
            label1.Name = "label1";
            label1.Size = new Size(142, 25);
            label1.TabIndex = 17;
            label1.Text = "Националност:";
            // 
            // textBoxNationality
            // 
            textBoxNationality.Location = new Point(575, 45);
            textBoxNationality.Name = "textBoxNationality";
            textBoxNationality.Size = new Size(154, 23);
            textBoxNationality.TabIndex = 15;
            // 
            // textBoxPlayerName
            // 
            textBoxPlayerName.Location = new Point(15, 45);
            textBoxPlayerName.Name = "textBoxPlayerName";
            textBoxPlayerName.Size = new Size(154, 23);
            textBoxPlayerName.TabIndex = 14;
            // 
            // buttonDelete
            // 
            buttonDelete.Font = new Font("Segoe UI", 12F);
            buttonDelete.Location = new Point(826, 385);
            buttonDelete.Margin = new Padding(3, 2, 3, 2);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(112, 50);
            buttonDelete.TabIndex = 13;
            buttonDelete.Text = "Изтрий";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonSave
            // 
            buttonSave.Font = new Font("Segoe UI", 12F);
            buttonSave.Location = new Point(430, 385);
            buttonSave.Margin = new Padding(3, 2, 3, 2);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(112, 50);
            buttonSave.TabIndex = 12;
            buttonSave.Text = "Запази промените";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // dataGridViewPlayers
            // 
            dataGridViewPlayers.AutoGenerateColumns = false;
            dataGridViewPlayers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPlayers.Columns.AddRange(new DataGridViewColumn[] { playerIdDataGridViewTextBoxColumn, fullNameDataGridViewTextBoxColumn, dateOfBirthDataGridViewTextBoxColumn, nationalityDataGridViewTextBoxColumn, positionDataGridViewTextBoxColumn, numberDataGridViewTextBoxColumn, dominantFootDataGridViewTextBoxColumn, salaryDataGridViewTextBoxColumn, statusDataGridViewTextBoxColumn, clubDataGridViewTextBoxColumn });
            dataGridViewPlayers.DataSource = playerBindingSource;
            dataGridViewPlayers.Location = new Point(10, 190);
            dataGridViewPlayers.Margin = new Padding(3, 2, 3, 2);
            dataGridViewPlayers.Name = "dataGridViewPlayers";
            dataGridViewPlayers.RowHeadersWidth = 51;
            dataGridViewPlayers.Size = new Size(928, 184);
            dataGridViewPlayers.TabIndex = 11;
            // 
            // playerIdDataGridViewTextBoxColumn
            // 
            playerIdDataGridViewTextBoxColumn.DataPropertyName = "PlayerId";
            playerIdDataGridViewTextBoxColumn.HeaderText = "ID";
            playerIdDataGridViewTextBoxColumn.Name = "playerIdDataGridViewTextBoxColumn";
            playerIdDataGridViewTextBoxColumn.ReadOnly = true;
            playerIdDataGridViewTextBoxColumn.Width = 50;
            // 
            // fullNameDataGridViewTextBoxColumn
            // 
            fullNameDataGridViewTextBoxColumn.DataPropertyName = "FullName";
            fullNameDataGridViewTextBoxColumn.HeaderText = "Име";
            fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
            fullNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateOfBirthDataGridViewTextBoxColumn
            // 
            dateOfBirthDataGridViewTextBoxColumn.DataPropertyName = "DateOfBirth";
            dateOfBirthDataGridViewTextBoxColumn.HeaderText = "Рождена дата";
            dateOfBirthDataGridViewTextBoxColumn.Name = "dateOfBirthDataGridViewTextBoxColumn";
            dateOfBirthDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nationalityDataGridViewTextBoxColumn
            // 
            nationalityDataGridViewTextBoxColumn.DataPropertyName = "Nationality";
            nationalityDataGridViewTextBoxColumn.HeaderText = "Националност";
            nationalityDataGridViewTextBoxColumn.Name = "nationalityDataGridViewTextBoxColumn";
            nationalityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // positionDataGridViewTextBoxColumn
            // 
            positionDataGridViewTextBoxColumn.DataPropertyName = "Position";
            positionDataGridViewTextBoxColumn.HeaderText = "Позиция";
            positionDataGridViewTextBoxColumn.Name = "positionDataGridViewTextBoxColumn";
            positionDataGridViewTextBoxColumn.ReadOnly = true;
            positionDataGridViewTextBoxColumn.Width = 75;
            // 
            // numberDataGridViewTextBoxColumn
            // 
            numberDataGridViewTextBoxColumn.DataPropertyName = "Number";
            numberDataGridViewTextBoxColumn.HeaderText = "Номер";
            numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
            numberDataGridViewTextBoxColumn.ReadOnly = true;
            numberDataGridViewTextBoxColumn.Width = 75;
            // 
            // dominantFootDataGridViewTextBoxColumn
            // 
            dominantFootDataGridViewTextBoxColumn.DataPropertyName = "DominantFoot";
            dominantFootDataGridViewTextBoxColumn.HeaderText = "Доминираш крак";
            dominantFootDataGridViewTextBoxColumn.Name = "dominantFootDataGridViewTextBoxColumn";
            dominantFootDataGridViewTextBoxColumn.ReadOnly = true;
            dominantFootDataGridViewTextBoxColumn.Width = 75;
            // 
            // salaryDataGridViewTextBoxColumn
            // 
            salaryDataGridViewTextBoxColumn.DataPropertyName = "Salary";
            salaryDataGridViewTextBoxColumn.HeaderText = "Заплата";
            salaryDataGridViewTextBoxColumn.Name = "salaryDataGridViewTextBoxColumn";
            salaryDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            statusDataGridViewTextBoxColumn.HeaderText = "Статус";
            statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            statusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // clubDataGridViewTextBoxColumn
            // 
            clubDataGridViewTextBoxColumn.DataPropertyName = "Club";
            clubDataGridViewTextBoxColumn.HeaderText = "Клуб";
            clubDataGridViewTextBoxColumn.Name = "clubDataGridViewTextBoxColumn";
            clubDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // playerBindingSource
            // 
            playerBindingSource.DataSource = typeof(Data.Models.Player);
            // 
            // buttonAdd
            // 
            buttonAdd.Font = new Font("Segoe UI", 12F);
            buttonAdd.Location = new Point(10, 385);
            buttonAdd.Margin = new Padding(3, 2, 3, 2);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(112, 50);
            buttonAdd.TabIndex = 10;
            buttonAdd.Text = "Добави";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F);
            label4.Location = new Point(387, 105);
            label4.Name = "label4";
            label4.Size = new Size(85, 25);
            label4.TabIndex = 25;
            label4.Text = "Заплата:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F);
            label5.Location = new Point(201, 105);
            label5.Name = "label5";
            label5.Size = new Size(167, 25);
            label5.TabIndex = 24;
            label5.Text = "Доминиращ крак:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14F);
            label6.Location = new Point(575, 105);
            label6.Name = "label6";
            label6.Size = new Size(72, 25);
            label6.TabIndex = 23;
            label6.Text = "Статус:";
            // 
            // textBoxSalary
            // 
            textBoxSalary.Location = new Point(387, 132);
            textBoxSalary.Name = "textBoxSalary";
            textBoxSalary.Size = new Size(154, 23);
            textBoxSalary.TabIndex = 22;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14F);
            label7.Location = new Point(15, 105);
            label7.Name = "label7";
            label7.Size = new Size(74, 25);
            label7.TabIndex = 31;
            label7.Text = "Номер:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14F);
            label8.Location = new Point(757, 18);
            label8.Name = "label8";
            label8.Size = new Size(92, 25);
            label8.TabIndex = 30;
            label8.Text = "Позиция:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 14F);
            label9.Location = new Point(757, 105);
            label9.Name = "label9";
            label9.Size = new Size(123, 25);
            label9.TabIndex = 29;
            label9.Text = "Име на клуб:";
            // 
            // textBoxNumber
            // 
            textBoxNumber.Location = new Point(15, 132);
            textBoxNumber.Name = "textBoxNumber";
            textBoxNumber.Size = new Size(154, 23);
            textBoxNumber.TabIndex = 28;
            // 
            // comboBoxDominantFoot
            // 
            comboBoxDominantFoot.FormattingEnabled = true;
            comboBoxDominantFoot.Location = new Point(201, 132);
            comboBoxDominantFoot.Name = "comboBoxDominantFoot";
            comboBoxDominantFoot.Size = new Size(154, 23);
            comboBoxDominantFoot.TabIndex = 33;
            // 
            // comboBoxPosition
            // 
            comboBoxPosition.FormattingEnabled = true;
            comboBoxPosition.Location = new Point(757, 45);
            comboBoxPosition.Name = "comboBoxPosition";
            comboBoxPosition.Size = new Size(154, 23);
            comboBoxPosition.TabIndex = 34;
            // 
            // comboBoxClubName
            // 
            comboBoxClubName.FormattingEnabled = true;
            comboBoxClubName.Location = new Point(757, 132);
            comboBoxClubName.Name = "comboBoxClubName";
            comboBoxClubName.Size = new Size(154, 23);
            comboBoxClubName.TabIndex = 35;
            // 
            // dateTimePickerBirthDate
            // 
            dateTimePickerBirthDate.Location = new Point(287, 45);
            dateTimePickerBirthDate.Name = "dateTimePickerBirthDate";
            dateTimePickerBirthDate.Size = new Size(200, 23);
            dateTimePickerBirthDate.TabIndex = 36;
            // 
            // comboBoxStatus
            // 
            comboBoxStatus.FormattingEnabled = true;
            comboBoxStatus.Location = new Point(575, 132);
            comboBoxStatus.Name = "comboBoxStatus";
            comboBoxStatus.Size = new Size(154, 23);
            comboBoxStatus.TabIndex = 37;
            // 
            // PlayersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(945, 450);
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
            Name = "PlayersForm";
            Text = "PlayersForm";
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
        private DataGridViewTextBoxColumn playerIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dateOfBirthDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nationalityDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn positionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dominantFootDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn salaryDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn clubDataGridViewTextBoxColumn;
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
    }
}