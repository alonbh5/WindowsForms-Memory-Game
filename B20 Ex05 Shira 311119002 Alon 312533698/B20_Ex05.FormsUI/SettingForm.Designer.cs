namespace B20_Ex05.FormsUI
{
    public partial class SettingForm
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
            this.m_Player2NameTextBox = new System.Windows.Forms.TextBox();
            this.m_StartButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_Player1NameTextBox = new System.Windows.Forms.TextBox();
            this.m_PVPButton = new System.Windows.Forms.Button();
            this.m_boardSizeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_Player2NameTextBox
            // 
            this.m_Player2NameTextBox.Enabled = false;
            this.m_Player2NameTextBox.Location = new System.Drawing.Point(141, 46);
            this.m_Player2NameTextBox.Name = "m_Player2NameTextBox";
            this.m_Player2NameTextBox.Size = new System.Drawing.Size(132, 20);
            this.m_Player2NameTextBox.TabIndex = 1;
            this.m_Player2NameTextBox.Text = "-Computer-";
            // 
            // m_StartButton
            // 
            this.m_StartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_StartButton.Location = new System.Drawing.Point(329, 155);
            this.m_StartButton.Name = "m_StartButton";
            this.m_StartButton.Size = new System.Drawing.Size(75, 23);
            this.m_StartButton.TabIndex = 4;
            this.m_StartButton.Text = "Start!";
            this.m_StartButton.UseVisualStyleBackColor = false;
            this.m_StartButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Board Size:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Second Player Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "First Player Name:";
            // 
            // m_Player1NameTextBox
            // 
            this.m_Player1NameTextBox.Location = new System.Drawing.Point(141, 19);
            this.m_Player1NameTextBox.Name = "m_Player1NameTextBox";
            this.m_Player1NameTextBox.Size = new System.Drawing.Size(132, 20);
            this.m_Player1NameTextBox.TabIndex = 0;
            // 
            // m_PVPButton
            // 
            this.m_PVPButton.Location = new System.Drawing.Point(279, 46);
            this.m_PVPButton.Name = "m_PVPButton";
            this.m_PVPButton.Size = new System.Drawing.Size(125, 20);
            this.m_PVPButton.TabIndex = 2;
            this.m_PVPButton.Text = "Against A Friend";
            this.m_PVPButton.UseVisualStyleBackColor = true;
            this.m_PVPButton.Click += new System.EventHandler(this.pvpButton_Click);
            // 
            // m_boardSizeButton
            // 
            this.m_boardSizeButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.m_boardSizeButton.Location = new System.Drawing.Point(12, 107);
            this.m_boardSizeButton.Name = "m_boardSizeButton";
            this.m_boardSizeButton.Size = new System.Drawing.Size(126, 71);
            this.m_boardSizeButton.TabIndex = 3;
            this.m_boardSizeButton.Text = "4x4";
            this.m_boardSizeButton.UseVisualStyleBackColor = false;
            this.m_boardSizeButton.Click += new System.EventHandler(this.boardSizeButton_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 193);
            this.Controls.Add(this.m_boardSizeButton);
            this.Controls.Add(this.m_PVPButton);
            this.Controls.Add(this.m_Player1NameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_StartButton);
            this.Controls.Add(this.m_Player2NameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memory Game - Setting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox m_Player2NameTextBox;
        private System.Windows.Forms.Button m_StartButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox m_Player1NameTextBox;
        private System.Windows.Forms.Button m_PVPButton;
        private System.Windows.Forms.Button m_boardSizeButton;
    }
}