namespace B20_Ex05.FormsUI
{
    public partial class GameOver
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
            this.m_ScoreLabel = new System.Windows.Forms.Label();
            this.m_AgainButton = new System.Windows.Forms.Button();
            this.m_ExitButton = new System.Windows.Forms.Button();
            this.m_QuestionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_ScoreLabel
            // 
            this.m_ScoreLabel.AutoSize = true;
            this.m_ScoreLabel.BackColor = System.Drawing.Color.Yellow;
            this.m_ScoreLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.m_ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.m_ScoreLabel.Location = new System.Drawing.Point(30, 18);
            this.m_ScoreLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_ScoreLabel.Name = "m_ScoreLabel";
            this.m_ScoreLabel.Size = new System.Drawing.Size(60, 24);
            this.m_ScoreLabel.TabIndex = 3;
            this.m_ScoreLabel.Text = "Score";
            // 
            // m_AgainButton
            // 
            this.m_AgainButton.Location = new System.Drawing.Point(34, 183);
            this.m_AgainButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_AgainButton.Name = "m_AgainButton";
            this.m_AgainButton.Size = new System.Drawing.Size(112, 35);
            this.m_AgainButton.TabIndex = 0;
            this.m_AgainButton.Text = "Play Again!";
            this.m_AgainButton.UseVisualStyleBackColor = true;
            this.m_AgainButton.Click += new System.EventHandler(this.again_Click);
            // 
            // m_ExitButton
            // 
            this.m_ExitButton.Location = new System.Drawing.Point(228, 183);
            this.m_ExitButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_ExitButton.Name = "m_ExitButton";
            this.m_ExitButton.Size = new System.Drawing.Size(112, 35);
            this.m_ExitButton.TabIndex = 1;
            this.m_ExitButton.Text = "Exit";
            this.m_ExitButton.UseVisualStyleBackColor = true;
            this.m_ExitButton.Click += new System.EventHandler(this.exit_Click);
            // 
            // m_QuestionLabel
            // 
            this.m_QuestionLabel.AutoSize = true;
            this.m_QuestionLabel.BackColor = System.Drawing.Color.Aqua;
            this.m_QuestionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.m_QuestionLabel.Location = new System.Drawing.Point(29, 138);
            this.m_QuestionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_QuestionLabel.Name = "m_QuestionLabel";
            this.m_QuestionLabel.Size = new System.Drawing.Size(316, 25);
            this.m_QuestionLabel.TabIndex = 2;
            this.m_QuestionLabel.Text = "Do You Wish To Play Again?";
            // 
            // GameOver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 248);
            this.ControlBox = false;
            this.Controls.Add(this.m_QuestionLabel);
            this.Controls.Add(this.m_ExitButton);
            this.Controls.Add(this.m_AgainButton);
            this.Controls.Add(this.m_ScoreLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "GameOver";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameOver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_ScoreLabel;
        private System.Windows.Forms.Button m_AgainButton;
        private System.Windows.Forms.Button m_ExitButton;
        private System.Windows.Forms.Label m_QuestionLabel;
    }
}