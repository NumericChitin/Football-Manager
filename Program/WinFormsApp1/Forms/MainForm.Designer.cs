namespace WinFormsApp1
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            buttonOpenMatches = new Button();
            button5 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 14F);
            button1.Location = new Point(212, 65);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(161, 100);
            button1.TabIndex = 0;
            button1.Text = "Отвори клубовете";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 14F);
            button2.Location = new Point(212, 204);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(161, 100);
            button2.TabIndex = 1;
            button2.Text = "Отвори играчите";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 14F);
            button3.Location = new Point(410, 204);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(161, 100);
            button3.TabIndex = 2;
            button3.Text = "Отвори трансферите";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 14F);
            button4.Location = new Point(410, 65);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(161, 100);
            button4.TabIndex = 3;
            button4.Text = "Отвори лигите";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // buttonOpenMatches
            // 
            buttonOpenMatches.Font = new Font("Segoe UI", 14F);
            buttonOpenMatches.Location = new Point(12, 65);
            buttonOpenMatches.Margin = new Padding(3, 2, 3, 2);
            buttonOpenMatches.Name = "buttonOpenMatches";
            buttonOpenMatches.Size = new Size(161, 100);
            buttonOpenMatches.TabIndex = 4;
            buttonOpenMatches.Text = "Отвори мачовете";
            buttonOpenMatches.UseVisualStyleBackColor = true;
            buttonOpenMatches.Click += buttonOpenMatches_Click;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 14F);
            button5.Location = new Point(12, 204);
            button5.Margin = new Padding(3, 2, 3, 2);
            button5.Name = "button5";
            button5.Size = new Size(161, 100);
            button5.TabIndex = 5;
            button5.Text = "Отвори класирането";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F);
            label1.Location = new Point(131, 9);
            label1.Name = "label1";
            label1.Size = new Size(326, 45);
            label1.TabIndex = 6;
            label1.Text = "Футболен мениджър";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(581, 321);
            Controls.Add(label1);
            Controls.Add(button5);
            Controls.Add(buttonOpenMatches);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            Text = "Футболен мениджър";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button buttonOpenMatches;
        private Button button5;
        private Label label1;
    }
}
