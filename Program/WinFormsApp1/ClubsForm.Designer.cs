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
            ((System.ComponentModel.ISupportInitialize)dataGridViewClubs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clubBindingSource).BeginInit();
            SuspendLayout();
            // 
            // buttonAdd
            // 
            buttonAdd.Font = new Font("Segoe UI", 12F);
            buttonAdd.Location = new Point(12, 272);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(128, 66);
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
            dataGridViewClubs.Location = new Point(12, 12);
            dataGridViewClubs.Name = "dataGridViewClubs";
            dataGridViewClubs.RowHeadersWidth = 51;
            dataGridViewClubs.Size = new Size(629, 245);
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
            nameDataGridViewTextBoxColumn.Width = 150;
            // 
            // cityDataGridViewTextBoxColumn
            // 
            cityDataGridViewTextBoxColumn.DataPropertyName = "City";
            cityDataGridViewTextBoxColumn.HeaderText = "Град";
            cityDataGridViewTextBoxColumn.MinimumWidth = 6;
            cityDataGridViewTextBoxColumn.Name = "cityDataGridViewTextBoxColumn";
            cityDataGridViewTextBoxColumn.Width = 150;
            // 
            // stadiumDataGridViewTextBoxColumn
            // 
            stadiumDataGridViewTextBoxColumn.DataPropertyName = "Stadium";
            stadiumDataGridViewTextBoxColumn.HeaderText = "Стадион";
            stadiumDataGridViewTextBoxColumn.MinimumWidth = 6;
            stadiumDataGridViewTextBoxColumn.Name = "stadiumDataGridViewTextBoxColumn";
            stadiumDataGridViewTextBoxColumn.Width = 150;
            // 
            // clubBindingSource
            // 
            clubBindingSource.DataSource = typeof(Data.Models.Club);
            // 
            // buttonSave
            // 
            buttonSave.Font = new Font("Segoe UI", 12F);
            buttonSave.Location = new Point(262, 272);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(128, 66);
            buttonSave.TabIndex = 2;
            buttonSave.Text = "Запази промените";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Font = new Font("Segoe UI", 12F);
            buttonDelete.Location = new Point(513, 272);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(128, 66);
            buttonDelete.TabIndex = 3;
            buttonDelete.Text = "Изтрий";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // ClubsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(652, 355);
            Controls.Add(buttonDelete);
            Controls.Add(buttonSave);
            Controls.Add(dataGridViewClubs);
            Controls.Add(buttonAdd);
            Name = "ClubsForm";
            Text = "ClubsForm";
            Load += ClubsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewClubs).EndInit();
            ((System.ComponentModel.ISupportInitialize)clubBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonAdd;
        private DataGridView dataGridViewClubs;
        private BindingSource clubBindingSource;
        private Button buttonSave;
        private Button buttonDelete;
        private DataGridViewTextBoxColumn clubIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cityDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn stadiumDataGridViewTextBoxColumn;
    }
}