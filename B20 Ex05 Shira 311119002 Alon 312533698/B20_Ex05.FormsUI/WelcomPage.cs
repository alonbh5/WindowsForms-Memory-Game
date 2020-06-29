using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace B20_Ex05.FormsUI
{
    
    enum eBoardSize
    {
        SixBySix ,
        FourbyFour,
        FourByFive,
        FourBySix,
        FiveByFour,
        FiveBySix,
        SixByFour,
        SixByFive // 7
    }

    public delegate void StartInvoker(string i_Name1, string i_Name2, bool i_Pvc, int i_Row, int i_Col);

    public partial class WelcomPage : Form
    {
        const int NumOfBoardSizes = 8;

        internal event StartInvoker StartClicked;

        eBoardSize m_BoardSize = 0;
        private int m_BoardCol = 6;
        private int m_BoardRow = 6;
        private int m_choice = 0;
        private bool m_PvC = false;

        public WelcomPage()
        {
            InitializeComponent();            
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
            if (Player1NameTextBox.Text == string.Empty || Player1NameTextBox.Text == string.Empty)
            {
                //warningor something
            }
            else
            {
                if (StartClicked != null)
                {
                    StartClicked.Invoke(Player1Name, Player2Name, m_PvC, m_BoardRow, m_BoardCol);
                }
            }
        }

        private void BoardSizeButton_Click(object sender, EventArgs e)
        {
            m_choice++;
            m_choice = m_choice % NumOfBoardSizes;
            m_BoardSize = (eBoardSize)m_choice;

            switch (m_BoardSize)
            {
                case eBoardSize.FiveByFour:
                    BoardSizeButton.Text = "5x5";
                    m_BoardCol = 5;
                    m_BoardRow = 5;
                    break;
                case eBoardSize.FiveBySix:
                    BoardSizeButton.Text = "5x6";
                    m_BoardCol = 5;
                    m_BoardRow = 6;
                    break;
                case eBoardSize.FourByFive:
                    BoardSizeButton.Text = "4x5";
                    m_BoardCol = 4;
                    m_BoardRow = 5;
                    break;
                case eBoardSize.FourbyFour:
                    BoardSizeButton.Text = "4x4";
                    m_BoardCol = 4;
                    m_BoardRow = 4;
                    break;
                case eBoardSize.FourBySix:
                    BoardSizeButton.Text = "5x6";
                    m_BoardCol = 5;
                    m_BoardRow = 6;
                    break;
                case eBoardSize.SixByFive:
                    BoardSizeButton.Text = "6x5";
                    m_BoardCol = 6;
                    m_BoardRow = 5;
                    break;
                case eBoardSize.SixByFour:
                    BoardSizeButton.Text = "6x4";
                    m_BoardCol = 6;
                    m_BoardRow = 4;
                    break;
                case eBoardSize.SixBySix:
                    BoardSizeButton.Text = "6x6";
                    m_BoardCol = 6;
                    m_BoardRow = 6;
                    break;
            }
        }
    }
}
