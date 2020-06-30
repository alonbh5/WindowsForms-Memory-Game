﻿namespace B20_Ex05.FormsUI
{
    partial class WelcomPage
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
            this.Player2NameTextBox = new System.Windows.Forms.TextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Player1NameTextBox = new System.Windows.Forms.TextBox();
            this.PVPButton = new System.Windows.Forms.Button();
            this.BoardSizeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Player2NameTextBox
            // 
            this.Player2NameTextBox.Location = new System.Drawing.Point(141, 46);
            this.Player2NameTextBox.Name = "Player2NameTextBox";
            this.Player2NameTextBox.Size = new System.Drawing.Size(132, 20);
            this.Player2NameTextBox.TabIndex = 1;
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.StartButton.Location = new System.Drawing.Point(329, 155);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 4;
            this.StartButton.Text = "Start!";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
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
            // Player1NameTextBox
            // 
            this.Player1NameTextBox.Location = new System.Drawing.Point(141, 19);
            this.Player1NameTextBox.Name = "Player1NameTextBox";
            this.Player1NameTextBox.Size = new System.Drawing.Size(132, 20);
            this.Player1NameTextBox.TabIndex = 0;
            // 
            // PVPButton
            // 
            this.PVPButton.Location = new System.Drawing.Point(279, 46);
            this.PVPButton.Name = "PVPButton";
            this.PVPButton.Size = new System.Drawing.Size(125, 20);
            this.PVPButton.TabIndex = 2;
            this.PVPButton.Text = "Aginst A Friend";
            this.PVPButton.UseVisualStyleBackColor = true;
            this.PVPButton.Click += new System.EventHandler(this.PVPButton_Click);
            // 
            // BoardSizeButton
            // 
            this.BoardSizeButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BoardSizeButton.Location = new System.Drawing.Point(12, 107);
            this.BoardSizeButton.Name = "BoardSizeButton";
            this.BoardSizeButton.Size = new System.Drawing.Size(126, 71);
            this.BoardSizeButton.TabIndex = 3;
            this.BoardSizeButton.Text = "6 X 6";
            this.BoardSizeButton.UseVisualStyleBackColor = false;
            this.BoardSizeButton.Click += new System.EventHandler(this.BoardSizeButton_Click);
            // 
            // WelcomPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 193);
            this.Controls.Add(this.BoardSizeButton);
            this.Controls.Add(this.PVPButton);
            this.Controls.Add(this.Player1NameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.Player2NameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WelcomPage";
            this.ShowIcon = false;
            this.Text = "Memory Game - Setting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Player2NameTextBox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Player1NameTextBox;
        private System.Windows.Forms.Button PVPButton;
        private System.Windows.Forms.Button BoardSizeButton;
    }
}