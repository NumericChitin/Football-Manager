namespace WinFormsApp1
{
    partial class TransfersForm
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
            dataGridView1 = new DataGridView();
            transferIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            playerDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            clubFromDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            clubToDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            typeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            commentDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            transferBindingSource = new BindingSource(components);
            buttonClearFilters = new Button();
            buttonSave = new Button();
            buttonAdd = new Button();
            comboBoxClubFrom = new ComboBox();
            label8 = new Label();
            comboBoxClubTo = new ComboBox();
            label1 = new Label();
            dateTimePickerTransferDate = new DateTimePicker();
            label3 = new Label();
            comboBoxPlayer = new ComboBox();
            label2 = new Label();
            comboBoxTransferType = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            textBoxComment = new TextBox();
            comboBoxFilterByPlayer = new ComboBox();
            label6 = new Label();
            comboBoxFilterByClubFrom = new ComboBox();
            label7 = new Label();
            comboBoxFilterByClubTo = new ComboBox();
            label9 = new Label();
            dateTimePickerFilterByDateStart = new DateTimePicker();
            label10 = new Label();
            label11 = new Label();
            dateTimePickerFilterByDateEnd = new DateTimePicker();
            label12 = new Label();
            label13 = new Label();
            transferIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            playerDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            clubFromDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            clubToDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            typeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            commentDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)transferBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { transferIdDataGridViewTextBoxColumn, playerDataGridViewTextBoxColumn, clubFromDataGridViewTextBoxColumn, clubToDataGridViewTextBoxColumn, dateDataGridViewTextBoxColumn, typeDataGridViewTextBoxColumn, commentDataGridViewTextBoxColumn });
            dataGridView1.DataSource = transferBindingSource;
            dataGridView1.Location = new Point(12, 137);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(772, 383);
            dataGridView1.TabIndex = 0;
            // 
            // transferIdDataGridViewTextBoxColumn
            // 
            transferIdDataGridViewTextBoxColumn.DataPropertyName = "TransferId";
            transferIdDataGridViewTextBoxColumn.HeaderText = "ID";
            transferIdDataGridViewTextBoxColumn.Name = "transferIdDataGridViewTextBoxColumn";
            transferIdDataGridViewTextBoxColumn.ReadOnly = true;
            transferIdDataGridViewTextBoxColumn.Width = 50;
            // 
            // playerDataGridViewTextBoxColumn
            // 
            playerDataGridViewTextBoxColumn.DataPropertyName = "PlayerName";
            playerDataGridViewTextBoxColumn.HeaderText = "Играч";
            playerDataGridViewTextBoxColumn.Name = "playerDataGridViewTextBoxColumn";
            playerDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // clubFromDataGridViewTextBoxColumn
            // 
            clubFromDataGridViewTextBoxColumn.DataPropertyName = "ClubFromName";
            clubFromDataGridViewTextBoxColumn.HeaderText = "Клуб от";
            clubFromDataGridViewTextBoxColumn.Name = "clubFromDataGridViewTextBoxColumn";
            clubFromDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // clubToDataGridViewTextBoxColumn
            // 
            clubToDataGridViewTextBoxColumn.DataPropertyName = "ClubToName";
            clubToDataGridViewTextBoxColumn.HeaderText = "Клуб до";
            clubToDataGridViewTextBoxColumn.Name = "clubToDataGridViewTextBoxColumn";
            clubToDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            dateDataGridViewTextBoxColumn.HeaderText = "Дата";
            dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            dateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            typeDataGridViewTextBoxColumn.HeaderText = "Вид трансфер";
            typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            typeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // commentDataGridViewTextBoxColumn
            // 
            commentDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            commentDataGridViewTextBoxColumn.DataPropertyName = "Comment";
            commentDataGridViewTextBoxColumn.HeaderText = "Коментар";
            commentDataGridViewTextBoxColumn.Name = "commentDataGridViewTextBoxColumn";
            commentDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // transferBindingSource
            // 
            transferBindingSource.DataSource = typeof(Data.Models.Transfer);
            // 
            // buttonClearFilters
            // 
            buttonClearFilters.Font = new Font("Segoe UI", 12F);
            buttonClearFilters.Location = new Point(666, 644);
            buttonClearFilters.Margin = new Padding(3, 2, 3, 2);
            buttonClearFilters.Name = "buttonClearFilters";
            buttonClearFilters.Size = new Size(112, 50);
            buttonClearFilters.TabIndex = 16;
            buttonClearFilters.Text = "Изчисти филтрите";
            buttonClearFilters.UseVisualStyleBackColor = true;
            buttonClearFilters.Click += buttonClear_Click;
            // 
            // buttonSave
            // 
            buttonSave.Font = new Font("Segoe UI", 12F);
            buttonSave.Location = new Point(344, 644);
            buttonSave.Margin = new Padding(3, 2, 3, 2);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(112, 50);
            buttonSave.TabIndex = 15;
            buttonSave.Text = "Запази промените";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.Font = new Font("Segoe UI", 12F);
            buttonAdd.Location = new Point(12, 644);
            buttonAdd.Margin = new Padding(3, 2, 3, 2);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(112, 50);
            buttonAdd.TabIndex = 14;
            buttonAdd.Text = "Добави";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // comboBoxClubFrom
            // 
            comboBoxClubFrom.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxClubFrom.FormattingEnabled = true;
            comboBoxClubFrom.Location = new Point(200, 36);
            comboBoxClubFrom.Name = "comboBoxClubFrom";
            comboBoxClubFrom.Size = new Size(154, 23);
            comboBoxClubFrom.TabIndex = 36;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14F);
            label8.Location = new Point(200, 9);
            label8.Name = "label8";
            label8.Size = new Size(81, 25);
            label8.TabIndex = 35;
            label8.Text = "Клуб от:";
            // 
            // comboBoxClubTo
            // 
            comboBoxClubTo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxClubTo.FormattingEnabled = true;
            comboBoxClubTo.Location = new Point(377, 36);
            comboBoxClubTo.Name = "comboBoxClubTo";
            comboBoxClubTo.Size = new Size(154, 23);
            comboBoxClubTo.TabIndex = 38;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(377, 9);
            label1.Name = "label1";
            label1.Size = new Size(83, 25);
            label1.TabIndex = 37;
            label1.Text = "Клуб до:";
            // 
            // dateTimePickerTransferDate
            // 
            dateTimePickerTransferDate.Location = new Point(578, 36);
            dateTimePickerTransferDate.Name = "dateTimePickerTransferDate";
            dateTimePickerTransferDate.Size = new Size(200, 23);
            dateTimePickerTransferDate.TabIndex = 40;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(578, 9);
            label3.Name = "label3";
            label3.Size = new Size(171, 25);
            label3.TabIndex = 39;
            label3.Text = "Дата на трансфер:";
            // 
            // comboBoxPlayer
            // 
            comboBoxPlayer.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPlayer.FormattingEnabled = true;
            comboBoxPlayer.Location = new Point(12, 36);
            comboBoxPlayer.Name = "comboBoxPlayer";
            comboBoxPlayer.Size = new Size(154, 23);
            comboBoxPlayer.TabIndex = 42;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(69, 25);
            label2.TabIndex = 41;
            label2.Text = "Играч:";
            // 
            // comboBoxTransferType
            // 
            comboBoxTransferType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTransferType.FormattingEnabled = true;
            comboBoxTransferType.Location = new Point(12, 104);
            comboBoxTransferType.Name = "comboBoxTransferType";
            comboBoxTransferType.Size = new Size(154, 23);
            comboBoxTransferType.TabIndex = 44;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F);
            label4.Location = new Point(12, 77);
            label4.Name = "label4";
            label4.Size = new Size(136, 25);
            label4.TabIndex = 43;
            label4.Text = "Вид трансфер:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F);
            label5.Location = new Point(200, 77);
            label5.Name = "label5";
            label5.Size = new Size(101, 25);
            label5.TabIndex = 46;
            label5.Text = "Коментар:";
            // 
            // textBoxComment
            // 
            textBoxComment.Location = new Point(200, 104);
            textBoxComment.Name = "textBoxComment";
            textBoxComment.Size = new Size(578, 23);
            textBoxComment.TabIndex = 45;
            // 
            // comboBoxFilterByPlayer
            // 
            comboBoxFilterByPlayer.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFilterByPlayer.FormattingEnabled = true;
            comboBoxFilterByPlayer.Location = new Point(12, 590);
            comboBoxFilterByPlayer.Name = "comboBoxFilterByPlayer";
            comboBoxFilterByPlayer.Size = new Size(154, 23);
            comboBoxFilterByPlayer.TabIndex = 48;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14F);
            label6.Location = new Point(12, 563);
            label6.Name = "label6";
            label6.Size = new Size(96, 25);
            label6.TabIndex = 47;
            label6.Text = "По играч:";
            // 
            // comboBoxFilterByClubFrom
            // 
            comboBoxFilterByClubFrom.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFilterByClubFrom.FormattingEnabled = true;
            comboBoxFilterByClubFrom.Location = new Point(188, 548);
            comboBoxFilterByClubFrom.Name = "comboBoxFilterByClubFrom";
            comboBoxFilterByClubFrom.Size = new Size(154, 23);
            comboBoxFilterByClubFrom.TabIndex = 50;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14F);
            label7.Location = new Point(188, 521);
            label7.Name = "label7";
            label7.Size = new Size(109, 25);
            label7.TabIndex = 49;
            label7.Text = "По клуб от:";
            // 
            // comboBoxFilterByClubTo
            // 
            comboBoxFilterByClubTo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFilterByClubTo.FormattingEnabled = true;
            comboBoxFilterByClubTo.Location = new Point(188, 607);
            comboBoxFilterByClubTo.Name = "comboBoxFilterByClubTo";
            comboBoxFilterByClubTo.Size = new Size(154, 23);
            comboBoxFilterByClubTo.TabIndex = 52;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 14F);
            label9.Location = new Point(188, 580);
            label9.Name = "label9";
            label9.Size = new Size(111, 25);
            label9.TabIndex = 51;
            label9.Text = "По клуб до:";
            // 
            // dateTimePickerFilterByDateStart
            // 
            dateTimePickerFilterByDateStart.Location = new Point(353, 591);
            dateTimePickerFilterByDateStart.Name = "dateTimePickerFilterByDateStart";
            dateTimePickerFilterByDateStart.Size = new Size(200, 23);
            dateTimePickerFilterByDateStart.TabIndex = 54;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 14F);
            label10.Location = new Point(353, 521);
            label10.Name = "label10";
            label10.Size = new Size(198, 25);
            label10.TabIndex = 53;
            label10.Text = "По дата на трансфер:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 18F);
            label11.Location = new Point(12, 522);
            label11.Name = "label11";
            label11.Size = new Size(141, 32);
            label11.TabIndex = 55;
            label11.Text = "Филтрирай:";
            // 
            // dateTimePickerFilterByDateEnd
            // 
            dateTimePickerFilterByDateEnd.Location = new Point(578, 591);
            dateTimePickerFilterByDateEnd.Name = "dateTimePickerFilterByDateEnd";
            dateTimePickerFilterByDateEnd.Size = new Size(200, 23);
            dateTimePickerFilterByDateEnd.TabIndex = 57;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 14F);
            label12.Location = new Point(578, 563);
            label12.Name = "label12";
            label12.Size = new Size(40, 25);
            label12.TabIndex = 56;
            label12.Text = "До:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 14F);
            label13.Location = new Point(353, 563);
            label13.Name = "label13";
            label13.Size = new Size(38, 25);
            label13.TabIndex = 58;
            label13.Text = "От:";
            // 
            // transferIdDataGridViewTextBoxColumn
            // 
            transferIdDataGridViewTextBoxColumn.DataPropertyName = "TransferId";
            transferIdDataGridViewTextBoxColumn.HeaderText = "ID";
            transferIdDataGridViewTextBoxColumn.Name = "transferIdDataGridViewTextBoxColumn";
            transferIdDataGridViewTextBoxColumn.ReadOnly = true;
            transferIdDataGridViewTextBoxColumn.Width = 50;
            // 
            // playerDataGridViewTextBoxColumn
            // 
            playerDataGridViewTextBoxColumn.DataPropertyName = "PlayerName";
            playerDataGridViewTextBoxColumn.HeaderText = "Играч";
            playerDataGridViewTextBoxColumn.Name = "playerDataGridViewTextBoxColumn";
            playerDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // clubFromDataGridViewTextBoxColumn
            // 
            clubFromDataGridViewTextBoxColumn.DataPropertyName = "ClubFromName";
            clubFromDataGridViewTextBoxColumn.HeaderText = "Клуб от";
            clubFromDataGridViewTextBoxColumn.Name = "clubFromDataGridViewTextBoxColumn";
            clubFromDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // clubToDataGridViewTextBoxColumn
            // 
            clubToDataGridViewTextBoxColumn.DataPropertyName = "ClubToName";
            clubToDataGridViewTextBoxColumn.HeaderText = "Клуб до";
            clubToDataGridViewTextBoxColumn.Name = "clubToDataGridViewTextBoxColumn";
            clubToDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            dateDataGridViewTextBoxColumn.HeaderText = "Дата";
            dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            dateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            typeDataGridViewTextBoxColumn.HeaderText = "Вид трансфер";
            typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            typeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // commentDataGridViewTextBoxColumn
            // 
            commentDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            commentDataGridViewTextBoxColumn.DataPropertyName = "Comment";
            commentDataGridViewTextBoxColumn.HeaderText = "Коментар";
            commentDataGridViewTextBoxColumn.Name = "commentDataGridViewTextBoxColumn";
            commentDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // TransfersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(792, 700);
            Controls.Add(label13);
            Controls.Add(dateTimePickerFilterByDateEnd);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(dateTimePickerFilterByDateStart);
            Controls.Add(label10);
            Controls.Add(comboBoxFilterByClubTo);
            Controls.Add(label9);
            Controls.Add(comboBoxFilterByClubFrom);
            Controls.Add(label7);
            Controls.Add(comboBoxFilterByPlayer);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(textBoxComment);
            Controls.Add(comboBoxTransferType);
            Controls.Add(label4);
            Controls.Add(comboBoxPlayer);
            Controls.Add(label2);
            Controls.Add(dateTimePickerTransferDate);
            Controls.Add(label3);
            Controls.Add(comboBoxClubTo);
            Controls.Add(label1);
            Controls.Add(comboBoxClubFrom);
            Controls.Add(label8);
            Controls.Add(buttonClearFilters);
            Controls.Add(buttonSave);
            Controls.Add(buttonAdd);
            Controls.Add(dataGridView1);
            Name = "TransfersForm";
            Text = "TransfersForm";
            Load += TransfersForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)transferBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private BindingSource transferBindingSource;
        private Button buttonClearFilters;
        private Button buttonSave;
        private Button buttonAdd;
        private ComboBox comboBoxClubFrom;
        private Label label8;
        private ComboBox comboBoxClubTo;
        private Label label1;
        private DateTimePicker dateTimePickerTransferDate;
        private Label label3;
        private ComboBox comboBoxPlayer;
        private Label label2;
        private ComboBox comboBoxTransferType;
        private Label label4;
        private Label label5;
        private TextBox textBoxComment;
        private ComboBox comboBoxFilterByPlayer;
        private Label label6;
        private ComboBox comboBoxFilterByClubFrom;
        private Label label7;
        private ComboBox comboBoxFilterByClubTo;
        private Label label9;
        private DateTimePicker dateTimePickerFilterByDateStart;
        private Label label10;
        private Label label11;
        private DateTimePicker dateTimePickerFilterByDateEnd;
        private Label label12;
        private Label label13;
        private DataGridViewTextBoxColumn transferIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn playerDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn clubFromDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn clubToDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn commentDataGridViewTextBoxColumn;
    }
}