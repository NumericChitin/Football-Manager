namespace WinFormsApp1
{
    partial class ClubsForm
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
            buttonAdd = new Button();
            dataGridViewClubs = new DataGridView();
            clubIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            stadiumDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            clubBindingSource = new BindingSource(components);
            buttonSave = new Button();
            buttonDelete = new Button();
            textBoxName = new TextBox();
            textBoxCity = new TextBox();
            textBoxStadium = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewClubs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clubBindingSource).BeginInit();
            SuspendLayout();
            // 
            // buttonAdd
            // 
            buttonAdd.Font = new Font("Segoe UI", 12F);
            buttonAdd.Location = new Point(10, 270);
            buttonAdd.Margin = new Padding(3, 2, 3, 2);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(112, 50);
            buttonAdd.TabIndex = 0;
            buttonAdd.Text = "Добави";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // dataGridViewClubs
            // 
            dataGridViewClubs.AutoGenerateColumns = false;
            dataGridViewClubs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewClubs.Columns.AddRange(new DataGridViewColumn[] { clubIdDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, cityDataGridViewTextBoxColumn, stadiumDataGridViewTextBoxColumn });
            dataGridViewClubs.DataSource = clubBindingSource;
            dataGridViewClubs.Location = new Point(10, 75);
            dataGridViewClubs.Margin = new Padding(3, 2, 3, 2);
            dataGridViewClubs.Name = "dataGridViewClubs";
            dataGridViewClubs.RowHeadersWidth = 51;
            dataGridViewClubs.Size = new Size(629, 184);
            dataGridViewClubs.TabIndex = 1;
            // 
            // clubIdDataGridViewTextBoxColumn
            // 
            clubIdDataGridViewTextBoxColumn.DataPropertyName = "ClubId";
            clubIdDataGridViewTextBoxColumn.HeaderText = "Id на клуб";
            clubIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            clubIdDataGridViewTextBoxColumn.Name = "clubIdDataGridViewTextBoxColumn";
            clubIdDataGridViewTextBoxColumn.ReadOnly = true;
            clubIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Име";
            nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            nameDataGridViewTextBoxColumn.Width = 150;
            // 
            // cityDataGridViewTextBoxColumn
            // 
            cityDataGridViewTextBoxColumn.DataPropertyName = "City";
            cityDataGridViewTextBoxColumn.HeaderText = "Град";
            cityDataGridViewTextBoxColumn.MinimumWidth = 6;
            cityDataGridViewTextBoxColumn.Name = "cityDataGridViewTextBoxColumn";
            cityDataGridViewTextBoxColumn.ReadOnly = true;
            cityDataGridViewTextBoxColumn.Width = 150;
            // 
            // stadiumDataGridViewTextBoxColumn
            // 
            stadiumDataGridViewTextBoxColumn.DataPropertyName = "Stadium";
            stadiumDataGridViewTextBoxColumn.HeaderText = "Стадион";
            stadiumDataGridViewTextBoxColumn.MinimumWidth = 6;
            stadiumDataGridViewTextBoxColumn.Name = "stadiumDataGridViewTextBoxColumn";
            stadiumDataGridViewTextBoxColumn.ReadOnly = true;
            stadiumDataGridViewTextBoxColumn.Width = 150;
            // 
            // clubBindingSource
            // 
            clubBindingSource.DataSource = typeof(Data.Models.Club);
            // 
            // buttonSave
            // 
            buttonSave.Font = new Font("Segoe UI", 12F);
            buttonSave.Location = new Point(279, 271);
            buttonSave.Margin = new Padding(3, 2, 3, 2);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(112, 50);
            buttonSave.TabIndex = 2;
            buttonSave.Text = "Запази промените";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Font = new Font("Segoe UI", 12F);
            buttonDelete.Location = new Point(527, 270);
            buttonDelete.Margin = new Padding(3, 2, 3, 2);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(112, 50);
            buttonDelete.TabIndex = 3;
            buttonDelete.Text = "Изтрий";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(12, 35);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(154, 23);
            textBoxName.TabIndex = 4;
            // 
            // textBoxCity
            // 
            textBoxCity.Location = new Point(248, 35);
            textBoxCity.Name = "textBoxCity";
            textBoxCity.Size = new Size(154, 23);
            textBoxCity.TabIndex = 5;
            // 
            // textBoxStadium
            // 
            textBoxStadium.Location = new Point(484, 35);
            textBoxStadium.Name = "textBoxStadium";
            textBoxStadium.Size = new Size(154, 23);
            textBoxStadium.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(12, 8);
            label1.Name = "label1";
            label1.Size = new Size(123, 25);
            label1.TabIndex = 7;
            label1.Text = "Име на клуб:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(248, 8);
            label2.Name = "label2";
            label2.Size = new Size(122, 25);
            label2.TabIndex = 8;
            label2.Text = "Име на град:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(484, 8);
            label3.Name = "label3";
            label3.Size = new Size(154, 25);
            label3.TabIndex = 9;
            label3.Text = "Име на стадион:";
            // 
            // ClubsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 330);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxStadium);
            Controls.Add(textBoxCity);
            Controls.Add(textBoxName);
            Controls.Add(buttonDelete);
            Controls.Add(buttonSave);
            Controls.Add(dataGridViewClubs);
            Controls.Add(buttonAdd);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ClubsForm";
            Text = "ClubsForm";
            Load += ClubsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewClubs).EndInit();
            ((System.ComponentModel.ISupportInitialize)clubBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonAdd;
        private DataGridView dataGridViewClubs;
        private BindingSource clubBindingSource;
        private Button buttonSave;
        private Button buttonDelete;
        private TextBox textBoxName;
        private DataGridViewTextBoxColumn clubIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cityDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn stadiumDataGridViewTextBoxColumn;
        private TextBox textBoxCity;
        private TextBox textBoxStadium;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}