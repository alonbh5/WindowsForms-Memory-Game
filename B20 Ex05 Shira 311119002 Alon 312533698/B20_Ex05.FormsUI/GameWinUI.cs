using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace B20_Ex05.FormsUI
{
    public class GameWinUI
    {
        private WelcomePage m_FormSetting = new WelcomePage();
        private GameForm m_GameForm;
        private GameOver m_GameOver;
        private Game m_Game;
        private string[] m_Pictures;
        private bool m_SecondClick = false;
        private bool m_IsPlayer1Turn = true;
        private int m_FirstCol;
        private int m_FirstRow;
        private Button m_FirstButton;
        private Button m_SecondButton;       

        public GameWinUI()
        {
            DialogResult result;
            bool play = true;

            m_FormSetting.StartClicked += OnStartClick;
            m_FormSetting.ShowDialog();

            while (play && m_GameForm != null)
            {
                m_GameForm.PairWasChosen += OnClick;
                result = m_GameForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    gameOver();
                    result = m_GameOver.ShowDialog();                   
                }

                if (result == DialogResult.Cancel)
                {
                    play = false;
                }
            }
        }

        internal void OnStartClick(string o_Name1, string o_Name2, bool o_Pvc, int o_Row, int o_Col)
        {
            m_Game = new Game(o_Name1, o_Name2, o_Pvc, o_Row, o_Col);
            m_GameForm = new GameForm(o_Col, o_Row, o_Name1, o_Name2);
            m_Game.PairWasFound += OnPairFound;
            m_Game.Reveal += OnReveal;            
            makePictures((o_Row * o_Col) / 2);
        }

        internal void OnPlayAgain()
        {
            OnStartClick(m_Game.Player1Name(), m_Game.Player2Name(), m_Game.IsAIPlay(), m_Game.BoardRows(), m_Game.BoardCols());
        }      

        internal bool OnClick(int io_Row, int io_Col, object io_Sender)
        {
            if (!m_SecondClick)
            {
                m_SecondClick = true;
                m_Game.FirstReveal(io_Row, io_Col, m_IsPlayer1Turn);                
                m_FirstRow = io_Row;
                m_FirstCol = io_Col;
                m_FirstButton = io_Sender as Button;
            }
            else 
            {
                m_SecondClick = false;
                m_Game.SecondReveal(io_Row, io_Col);
                m_SecondButton = io_Sender as Button;
                m_Game.CheckTurn(m_FirstRow, m_FirstCol, io_Row, io_Col, ref m_IsPlayer1Turn);           
            }
            
            if ((!m_Game.IsGameOver()) && !m_IsPlayer1Turn && m_Game.IsAIPlay()) 
            {
                m_GameForm.Enabled = false;
                Cursor.Current = Cursors.WaitCursor;
                m_GameForm.Refresh();
                
                playAI();

                m_GameForm.Enabled = true;
                m_GameForm.Refresh();
                Cursor.Current = Cursors.Default;
            }

            return m_Game.IsGameOver();
        }       

        private void playAI()
        {
            int row = -1, col = -1;

            // AI turn until he got a wrong pair, m_IsPlayer1Turn changed to true or end of game
            while ((!m_Game.IsGameOver()) && !m_IsPlayer1Turn && m_Game.IsAIPlay())
            {                            
                Thread.Sleep(1000);                
                m_Game.GetInputFromAI(ref m_FirstRow, ref m_FirstCol);
                m_Game.FirstReveal(m_FirstRow, m_FirstCol, m_IsPlayer1Turn);
                m_FirstButton = m_GameForm.Buttons[m_FirstRow, m_FirstCol];       
                
                Thread.Sleep(1000);                
                m_Game.GetInputFromAI(ref row, ref col);
                m_Game.SecondReveal(row, col);                
                m_SecondButton = m_GameForm.Buttons[row, col];

                m_Game.CheckTurn(m_FirstRow, m_FirstCol, row, col, ref m_IsPlayer1Turn);                
            }           
        }

        private void resetButton(Button i_Button)
        {
            i_Button.BackColor = Color.LightGray;
            i_Button.BackgroundImage = null;
            i_Button.Refresh();
        }

        internal void OnReveal(int io_Row, int io_Col)
        {
            Button currButton = m_GameForm.Buttons[io_Row, io_Col];
            int index = m_Game.GetIndexAtBoard(io_Row, io_Col);

            PictureBox image = new PictureBox();
            image.Load(m_Pictures[index - 1]);

            currButton.BackgroundImage = image.Image;
            currButton.BackgroundImageLayout = ImageLayout.Center;

            if (m_IsPlayer1Turn)
            {
                currButton.BackColor = m_GameForm.Player1Color;
            }
            else
            {
                currButton.BackColor = m_GameForm.Player2Color;
            }

            currButton.Refresh();
        }

        internal void OnPairFound(bool i_FoundPair)
        {
            if (i_FoundPair)
            {                
                if (m_IsPlayer1Turn)
                {
                    m_GameForm.Player1FoundPair();
                }
                else
                {
                    m_GameForm.Player2FoundPair();
                }
            }
            else
            {
                Thread.Sleep(2000);                
                resetButton(m_FirstButton);
                resetButton(m_SecondButton);

                if (m_IsPlayer1Turn)
                {
                    m_GameForm.ChangeCurrentPlayer(m_GameForm.Player1Name);
                }
                else
                {
                    m_GameForm.ChangeCurrentPlayer(m_GameForm.Player2Name);
                }
            }
        }

        private void gameOver()
        {
            StringBuilder prompt = new StringBuilder();
            string msg = string.Empty;

            if (m_Game.GetWinner(out string winner))
            { // Case of tie
                msg = "It's a TIE!";
            }
            else
            {
                msg = string.Format("{0} WON!", winner);
            }

            prompt.Append(msg);
            msg = string.Format(
                "{2}{0} with {1} pairs revealed.{2}{3} with {4} pairs revealed.",
                m_Game.Player1Name(),
                m_Game.Player1Score(),
                Environment.NewLine,
                m_Game.Player2Name(),
                m_Game.Player2Score());
            prompt.Append(msg);

            m_GameOver = new GameOver(prompt.ToString());
            m_GameOver.PlayAgainClicked += OnPlayAgain;
        }

        private void makePictures(int i_Size)
        {
            m_Pictures = new string[i_Size];
            string ImgUrl = string.Empty;

            for (int i = 0; i < i_Size; i++) 
            {
                System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create("https://picsum.photos/80");
                System.Net.HttpWebResponse myResp = (System.Net.HttpWebResponse)req.GetResponse();
                m_Pictures[i] = myResp.ResponseUri.ToString();
                myResp.Close();
            }
        }
    }
}