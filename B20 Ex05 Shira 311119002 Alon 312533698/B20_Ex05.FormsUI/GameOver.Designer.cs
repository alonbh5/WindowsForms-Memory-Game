namespace B20_Ex05.FormsUI
{
    partial class GameOver
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
            this.EndGame = new System.Windows.Forms.Label();
            this.Again = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.msgQuestion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // EndGame
            // 
            this.EndGame.AutoSize = true;
            this.EndGame.BackColor = System.Drawing.Color.Yellow;
            this.EndGame.Cursor = System.Windows.Forms.Cursors.Default;
            this.EndGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.EndGame.Location = new System.Drawing.Point(30, 18);
            this.EndGame.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EndGame.Name = "EndGame";
            this.EndGame.Size = new System.Drawing.Size(0, 24);
            this.EndGame.TabIndex = 0;
            // 
            // Again
            // 
            this.Again.Location = new System.Drawing.Point(34, 183);
            this.Again.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Again.Name = "Again";
            this.Again.Size = new System.Drawing.Size(112, 35);
            this.Again.TabIndex = 1;
            this.Again.Text = "Play Again!";
            this.Again.UseVisualStyleBackColor = true;
            this.Again.Click += new System.EventHandler(this.Again_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(228, 183);
            this.Exit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(112, 35);
            this.Exit.TabIndex = 2;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // msgQuestion
            // 
            this.msgQuestion.AutoSize = true;
            this.msgQuestion.BackColor = System.Drawing.Color.Aqua;
            this.msgQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.msgQuestion.Location = new System.Drawing.Point(29, 138);
            this.msgQuestion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.msgQuestion.Name = "msgQuestion";
            this.msgQuestion.Size = new System.Drawing.Size(316, 25);
            this.msgQuestion.TabIndex = 3;
            this.msgQuestion.Text = "Do You Wish To Play Again?";
            // 
            // GameOver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 248);
            this.Controls.Add(this.msgQuestion);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Again);
            this.Controls.Add(this.EndGame);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "GameOver";
            this.Text = "GameOver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label EndGame;
        private System.Windows.Forms.Button Again;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Label msgQuestion;
    }
}