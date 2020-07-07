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
        SixBySix // 7
    }

    public delegate void StartInvoker(string i_Name1, string i_Name2, bool i_Pvc, int i_NumOfRows, int i_NumOfCols);    

    public partial class WelcomePage : Form
    {
        internal event StartInvoker StartClicked;

        private const int k_NumOfBoardSizes = 8;        

        private eBoardSize m_BoardSize = 0;
        private int m_BoardCol = 4;
        private int m_BoardRow = 4;
        private int m_choice = 0;
        private bool m_PvC = true;

        public WelcomePage()
        {
            InitializeComponent();
            this.FormClosed += WelcomePage_FormClosing;
        }

        internal string Player1Name
        {
            get { return Player1NameTextBox.Text; }
        }

        internal string Player2Name
        {
            get { return Player2NameTextBox.Text; }            
        }

        private void PVPButton_Click(object sender, EventArgs e)
        {
            m_PvC = !m_PvC;

            if (m_PvC)
            {
                PVPButton.Text = "Aginst a Friend";
                Player2NameTextBox.Enabled = false;
                Player2NameTextBox.Text = "-Computer-";
            }
            else
            {
                PVPButton.Text = "Aginst Computer";
                Player2NameTextBox.Enabled = true;
                Player2NameTextBox.Text = string.Empty;
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (Player1NameTextBox.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Player 1 Name");                
            }
            else
            {
                if (Player2NameTextBox.Text == string.Empty)
                {
                     MessageBox.Show("Please Enter Player 2 Name");                    
                }
                else
                {
                    if (StartClicked != null)
                    {
                        StartClicked.Invoke(Player1Name, Player2Name, m_PvC, m_BoardRow, m_BoardCol);
                        this.FormClosed -= WelcomePage_FormClosing;
                        this.Close();
                    }
                }
            }
        }

        private void BoardSizeButton_Click(object sender, EventArgs e)
        {
            m_choice++;
            m_choice = m_choice % k_NumOfBoardSizes;
            m_BoardSize = (eBoardSize)m_choice;

            switch (m_BoardSize)
            {
                case eBoardSize.FourbyFour:
                    BoardSizeButton.Text = "4x4";
                    m_BoardCol = 4;
                    m_BoardRow = 4;
                    break;
                case eBoardSize.FourByFive:
                    BoardSizeButton.Text = "4x5";
                    m_BoardCol = 4;
                    m_BoardRow = 5;
                    break;
                case eBoardSize.FourBySix:
                    BoardSizeButton.Text = "4x6";
                    m_BoardCol = 4;
                    m_BoardRow = 6;
                    break;
                case eBoardSize.FiveByFour:
                    BoardSizeButton.Text = "5x4";
                    m_BoardCol = 5;
                    m_BoardRow = 4;
                    break;
                case eBoardSize.FiveBySix:
                    BoardSizeButton.Text = "5x6";
                    m_BoardCol = 5;
                    m_BoardRow = 6;
                    break;
                case eBoardSize.SixByFour:
                    BoardSizeButton.Text = "6x4";
                    m_BoardCol = 6;
                    m_BoardRow = 4;
                    break;
                case eBoardSize.SixByFive:
                    BoardSizeButton.Text = "6x5";
                    m_BoardCol = 6;
                    m_BoardRow = 5;
                    break;
                case eBoardSize.SixBySix:
                    BoardSizeButton.Text = "6x6";
                    m_BoardCol = 6;
                    m_BoardRow = 6;
                    break;
            }
        }

        private void WelcomePage_FormClosing(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) 
            {
                if (Player1NameTextBox.Text == string.Empty)
                {
                    Player1NameTextBox.Text = "Player 1";
                }

                if (Player2NameTextBox.Text == string.Empty)
                {
                    Player2NameTextBox.Text = "Player 2";
                }

                StartButton_Click(sender, e);
            }            
        }
    }    
}