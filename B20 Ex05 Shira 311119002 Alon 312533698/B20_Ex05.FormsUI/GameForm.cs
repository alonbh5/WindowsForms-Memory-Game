using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace B20_Ex05.FormsUI
{
    public delegate bool PairInvoker(Button i_Sender);

    public partial class GameForm : Form
    {
        internal event PairInvoker PairWasChosen;

        private Button[,] m_Buttons;      
        private int m_Player1Pairs = 0;
        private int m_Player2Pairs = 0;
        private string m_Player1Name;
        private string m_Player2Name;

        public GameForm(int o_Col, int o_Row, string i_Player1Name, string i_Player2Name)
        {
            InitializeComponent();
            createButtons(o_Col, o_Row);
            m_Player1Name = i_Player1Name;
            m_Player2Name = i_Player2Name;

            m_Player1Label.Text = string.Format("{0}: {1} Pair(s)", Player1Name, m_Player1Pairs);
            m_Player2Label.Text = string.Format("{0}: {1} Pair(s)", Player2Name, m_Player2Pairs);
            m_CurrentPlayer.Text = string.Format("Current Player: {0}", Player1Name);
        }        
        
        internal string Player1Name
        {
            get { return m_Player1Name; }
            set { m_Player1Name = value; }            
        }

        internal string Player2Name
        {
            get { return m_Player2Name; }
            set { m_Player2Name = value; }            
        }

        internal Button[,] Buttons
        {
            get { return m_Buttons; }
        }

        internal void Player1FoundPair()
        {
            //// Adds 1 point to Player 1
            
            m_Player1Pairs++;
            m_Player1Label.Text = string.Format("{0}: {1} Pair(s)", Player1Name, m_Player1Pairs);
            m_Player1Label.Refresh();
        }

        internal void Player2FoundPair()
        {
            //// Adds 1 point to Player 2

            m_Player2Pairs++;
            m_Player2Label.Text = string.Format("{0}: {1} Pair(s)", Player2Name, m_Player2Pairs);
            m_Player2Label.Refresh();
        }

        internal Color Player1Color 
        {
            get { return m_Player1Label.BackColor; }
        }

        internal Color Player2Color
        {
            get { return m_Player2Label.BackColor; }
        }

        internal void ChangeCurrentPlayer(string i_PlayerName)
        {
            if (i_PlayerName == Player1Name)
            {
                m_CurrentPlayer.BackColor = m_Player1Label.BackColor;
            }
            else
            {
                m_CurrentPlayer.BackColor = m_Player2Label.BackColor;
            }

            m_CurrentPlayer.Text = string.Format("Current Player: {0}", i_PlayerName);    
            m_CurrentPlayer.Refresh();
        }

        private void createButtons(int i_Col, int i_Row)
        {
            ////Create all the tiles buttons on form and fix the form size 

            m_Buttons = new Button[i_Row, i_Col];
            Button currButton;
            int xAxis = 25;
            int yAxis = 25;
            int spaceForX = 115;
            int spaceForY = 105;

            this.Size = new Size(130 * i_Col, 145 * i_Row);

            for (int i = 0; i < i_Row; i++) 
            {
                for (int j = 0; j < i_Col; j++) 
                {
                    m_Buttons[i, j] = new Button();                    
                    currButton = m_Buttons[i, j];
                    currButton.AutoSize = true;
                    currButton.Location = new Point(xAxis, yAxis);
                    currButton.Size = new Size(100, 100);
                    currButton.TabIndex = (i * 10) + j;
                    currButton.Name = i + "-" + j;
                    currButton.UseVisualStyleBackColor = true;                    
                    currButton.Anchor = AnchorStyles.Right;
                    currButton.BackColor = Color.LightGray;
                    currButton.Click += tileButton_Click;
                    this.Controls.Add(currButton);
                    xAxis += spaceForX;
                }

                xAxis = 25;
                yAxis += spaceForY;
            }           
        }

        private void tileButton_Click(object i_sender, EventArgs i_e)
        {
            ////Invoke when button is pressed
            ////Close form is the response from invoker was true (Game-Over)

            if (this.Enabled)
            {
                if (i_sender is Button)
                {
                    if ((i_sender as Button).BackColor == Color.LightGray)
                    {   
                        if (PairWasChosen != null)
                        {
                            if (PairWasChosen.Invoke(i_sender as Button)) 
                            {
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