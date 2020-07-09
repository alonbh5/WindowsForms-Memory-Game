using System;
using System.Windows.Forms;

namespace B20_Ex05.FormsUI
{
    internal enum eBoardSize
    {
        FourbyFour,
        FourByFive,
        FourBySix,
        FiveByFour,
        FiveBySix,
        SixByFour,
        SixByFive,
        SixBySix 
    }

    public delegate void StartInvoker(string i_Name1, string i_Name2, bool i_Pvc, int i_NumOfRows, int i_NumOfCols);    

    public partial class SettingForm : Form
    {
        internal event StartInvoker StartClicked;

        private const int k_NumOfBoardSizes = 8;        

        private eBoardSize m_BoardSize = 0;
        private int m_BoardCol = 4;
        private int m_BoardRow = 4;
        private int m_Choice = 0;
        private bool m_PvC = true;

        public SettingForm()
        {
            InitializeComponent();
            this.FormClosed += welcomePage_FormClosing;
        }

        internal string Player1Name
        {
            get { return m_Player1NameTextBox.Text; }
        }

        internal string Player2Name
        {
            get { return m_Player2NameTextBox.Text; }            
        }

        private void pvpButton_Click(object sender, EventArgs e)
        {
            m_PvC = !m_PvC;

            if (m_PvC)
            {
                m_PVPButton.Text = "Against a Friend";
                m_Player2NameTextBox.Enabled = false;
                m_Player2NameTextBox.Text = "-Computer-";
            }
            else
            {
                m_PVPButton.Text = "Against Computer";
                m_Player2NameTextBox.Enabled = true;
                m_Player2NameTextBox.Text = string.Empty;
            }
        }

        private void startButton_Click(object i_sender, EventArgs i_e)
        {
            ////When start button was click Checks if all the text boxs was filled by User
            ////If so, notify UI that user want to start game
            
            if (m_Player1NameTextBox.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Player 1 Name");                
            }
            else
            {
                if (m_Player2NameTextBox.Text == string.Empty)
                {
                     MessageBox.Show("Please Enter Player 2 Name");                    
                }
                else
                {
                    if (StartClicked != null)
                    {
                        StartClicked.Invoke(Player1Name, Player2Name, m_PvC, m_BoardRow, m_BoardCol);
                        this.FormClosed -= welcomePage_FormClosing;
                        this.Close();
                    }
                }
            }
        }

        private void boardSizeButton_Click(object i_sender, EventArgs i_e)
        {
            m_Choice++;
            m_Choice = m_Choice % k_NumOfBoardSizes;
            m_BoardSize = (eBoardSize)m_Choice;

            switch (m_BoardSize)
            {
                case eBoardSize.FourbyFour:
                    m_boardSizeButton.Text = "4x4";
                    m_BoardCol = 4;
                    m_BoardRow = 4;
                    break;
                case eBoardSize.FourByFive:
                    m_boardSizeButton.Text = "4x5";
                    m_BoardCol = 4;
                    m_BoardRow = 5;
                    break;
                case eBoardSize.FourBySix:
                    m_boardSizeButton.Text = "4x6";
                    m_BoardCol = 4;
                    m_BoardRow = 6;
                    break;
                case eBoardSize.FiveByFour:
                    m_boardSizeButton.Text = "5x4";
                    m_BoardCol = 5;
                    m_BoardRow = 4;
                    break;
                case eBoardSize.FiveBySix:
                    m_boardSizeButton.Text = "5x6";
                    m_BoardCol = 5;
                    m_BoardRow = 6;
                    break;
                case eBoardSize.SixByFour:
                    m_boardSizeButton.Text = "6x4";
                    m_BoardCol = 6;
                    m_BoardRow = 4;
                    break;
                case eBoardSize.SixByFive:
                    m_boardSizeButton.Text = "6x5";
                    m_BoardCol = 6;
                    m_BoardRow = 5;
                    break;
                case eBoardSize.SixBySix:
                    m_boardSizeButton.Text = "6x6";
                    m_BoardCol = 6;
                    m_BoardRow = 6;
                    break;
            }
        }

        private void welcomePage_FormClosing(object i_sender, FormClosedEventArgs i_e)
        {
            ////If player closed form - acts as he pressed "Start"
            ////Set default names for players if User didn't filled them 

            if (i_e.CloseReason == CloseReason.UserClosing) 
            {
                if (m_Player1NameTextBox.Text == string.Empty)
                {
                    m_Player1NameTextBox.Text = "Player 1";
                }

                if (m_Player2NameTextBox.Text == string.Empty)
                {
                    m_Player2NameTextBox.Text = "Player 2";
                }

                startButton_Click(i_sender, i_e);
            }            
        }
    }    
}