using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B20_Ex05.FormsUI
{
    //public delegate bool PairInvoker(string i_Name1, string i_Name2, bool i_Pvc, int i_NumOfRows, int i_NumOfCols);
    public delegate bool PairInvoker(int i_row, int i_col, object sender);

    public partial class GameForm : Form
    {        
        internal Button[,] m_buttons;
        internal event PairInvoker PairWasChosen;

        private int m_player1Pairs = 0;
        private int m_player2Pairs = 0;
        private string m_player1Name;
        private string m_player2Name;

        public GameForm(int o_Col, int o_Row, string i_Player1Name, string i_Player2Name)
        {
            InitializeComponent();
            createButtons(o_Col, o_Row);
            m_player1Name = i_Player1Name;
            m_player2Name = i_Player2Name;

            m_Player1Label.Text = String.Format("{0}: {1} Pair(s)", Player1Name, m_player1Pairs);
            m_Player2Label.Text = String.Format("{0}: {1} Pair(s)", Player2Name, m_player2Pairs);
            m_CurrentPlayer.Text = String.Format("Current Player: {0}", Player1Name);
        }        
        
        internal string Player1Name
        {
            set { m_player1Name = value; }
            get { return m_player1Name; }
        }

        internal string Player2Name
        {
            set { m_player2Name = value; }
            get { return m_player2Name; }
        }

        internal Button[,] Buttons
        {
            get { return m_buttons; }
        }

        internal void Player1FoundPair () //updatescore
        {
            m_player1Pairs++;
            m_Player1Label.Text=String.Format("{0}: {1} Pair(s)", Player1Name, m_player1Pairs);
            m_Player1Label.Refresh();
        }

        internal Color Player1Color 
        {
            get { return m_Player1Label.BackColor; }
        }

        internal Color Player2Color
        {
            get { return m_Player2Label.BackColor; }
        }

        internal void Player2FoundPair() //upadte score
        {
            m_player2Pairs++;
            m_Player2Label.Text = String.Format("{0}: {1} Pair(s)", Player2Name, m_player2Pairs);
            m_Player2Label.Refresh();
        }

        internal void ChangeCurrentPlayer(string PlayerName)
        {
            if (PlayerName == Player1Name)
            {
                m_CurrentPlayer.BackColor = m_Player1Label.BackColor;
            }
            else
            {
                m_CurrentPlayer.BackColor = m_Player2Label.BackColor;
            }

            m_CurrentPlayer.Text = String.Format("Current Player: {0}", PlayerName);
            

            m_CurrentPlayer.Refresh();
        }

        private void createButtons(int i_Col, int i_Row)
        {
            m_buttons = new Button[i_Row, i_Col];
            Button currButton;
            int x = 25;
            int y = 25;
            int spaceX = 115;// (int)(this.ClientSize.Width *0.06);
            int spaceY = 105;// (int)(this.ClientSize.Height * 0.06);

            this.Size = new Size(130 * i_Col, 146 * i_Row);

            for (int i = 0; i< i_Row; i++)
            {
                for (int j = 0; j< i_Col; j++)
                {
                    m_buttons[i, j] = new Button();                    
                    currButton = m_buttons[i, j];
                    currButton.AutoSize = true;
                    currButton.Location = new Point(x, y);
                    currButton.Size = new Size(100, 100);
                    currButton.TabIndex = i * 10 + j;
                    currButton.Name = i + "-" + j;
                    currButton.UseVisualStyleBackColor = true;
                    currButton.Anchor = AnchorStyles.Right;
                    currButton.BackColor = Color.LightGray;
                    currButton.Click += tileButton_Click;
                    //currButton.
                    this.Controls.Add(currButton);
                    x += spaceX;
                }

                x = 25;
                y += spaceY;
            }           
        }

        private void tileButton_Click(object sender, EventArgs e)
        {
            if (this.Enabled)
            {
                if (sender is Button)
                {
                    if ((sender as Button).BackColor == Color.LightGray)
                    {
                        int row = int.Parse((sender as Button).Name[0].ToString());
                        int col = int.Parse((sender as Button).Name[2].ToString());

                        if (PairWasChosen != null)
                        {
                            if (PairWasChosen.Invoke(row, col, sender))
                            { // game over
                                this.DialogResult = DialogResult.OK;
                                Thread.Sleep(2000);
                                this.Close();
                            }
                        }
                    }
                }
            }
        }

        
    }
}
