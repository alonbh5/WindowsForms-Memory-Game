using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Policy;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms.VisualStyles;

namespace B20_Ex05.FormsUI
{
    class GameWinUI
    {
        WelcomPage m_FormSetting = new WelcomPage();
        GameForm m_GameForm;
        Game m_Game;
        bool m_SecondClick = false; 
        private string[] m_picture;
        bool m_IsPlayer1Turn = true;
        int m_FirstCol;
        int m_FirstRow;
        Button FirstButton;
        Button SecondButton;
        GameOver m_GameOver;

        public GameWinUI()
        {
            DialogResult Result;
            bool Play = true;

            m_FormSetting.StartClicked += OnStartClick;
            m_FormSetting.ShowDialog();

            while (Play && m_GameForm != null)
            {
                m_GameForm.PairWasChosen += OnClick;
                Result = m_GameForm.ShowDialog();

                if (Result == DialogResult.OK)
                {
                    gameOver();
                    Result = m_GameOver.ShowDialog();
                    if (Result == DialogResult.No)
                    {
                        Play = false;
                    }
                    else
                    {
                        resetGame();
                    }
                }
                else
                {
                    Play = false;
                }
            }
        }

        internal void OnStartClick(string o_Name1, string o_Name2, bool o_Pvc, int o_Row, int o_Col)
        {
            m_Game = new Game(o_Name1, o_Name2, o_Pvc, o_Row, o_Col);
            m_Game.PairWasFound += PairFound;
            m_Game.Reveal += Reveal;

            m_GameForm = new GameForm(o_Col, o_Row, o_Name1, o_Name2);
            makePictures((o_Row*o_Col)/2);
        }

        internal void resetGame()
        {
            m_Game = new Game(m_Game.Player1Name(), m_Game.Player2Name(), m_Game.IsAIPlay(), m_Game.BoardRows(), m_Game.BoardCols());
            m_Game.PairWasFound += PairFound;
            m_GameForm = new GameForm(m_Game.BoardCols(), m_Game.BoardRows(), m_Game.Player1Name(), m_Game.Player2Name());
        }

        internal bool OnReveal(int o_Row1, int o_Col1, int o_Row2, int o_Col2, bool io_IsTurnPlayer1)
        {
            bool Isplayer1 = io_IsTurnPlayer1;
            bool foundPair = false;

            m_Game.FirstReveal(o_Row1, o_Col1, io_IsTurnPlayer1);
            m_Game.SecondReveal(o_Row2, o_Col2);
            m_Game.CheckTurn(o_Row1, o_Col1, o_Row2, o_Col2, ref io_IsTurnPlayer1);

            if (Isplayer1 == io_IsTurnPlayer1)
            {
                foundPair = true;
            }

            return foundPair;
        }

        internal bool OnClick(int io_Row, int io_Col, object io_Sender)
        {

            //changeText(io_Row, io_Col, io_Sender);
            //changeColor(io_Sender);

            if (!m_SecondClick)
            {
                //case first click, need to update text
                //as button sender all of that
                m_SecondClick = true;
                m_Game.FirstReveal(io_Row, io_Col, m_IsPlayer1Turn);                
                m_FirstRow = io_Row;
                m_FirstCol = io_Col;
                FirstButton = (io_Sender as Button);
            }
            else 
            {
                m_SecondClick = false;
                m_Game.SecondReveal(io_Row, io_Col);
                SecondButton = (io_Sender as Button);
                m_Game.CheckTurn(m_FirstRow, m_FirstCol, io_Row, io_Col, ref m_IsPlayer1Turn); // add delgeage?                 
            }

            // update board........
            if ((!m_Game.IsGameOver()) && !m_IsPlayer1Turn && m_Game.IsAIPlay()) 
            {
                m_GameForm.Enabled = false;
                m_GameForm.Refresh();
                Cursor.Current = Cursors.WaitCursor;
                playAI();
                m_GameForm.Enabled = true;
                m_GameForm.Refresh();
                Cursor.Current = Cursors.Default;

            }

            return m_Game.IsGameOver();
        }

        private bool OnAIClick(int i_row, int i_col, object sender)
        {
            return m_Game.IsGameOver();
        }

        private bool playAI()
        {            
            int row = -1, col=-1;

            // AI turn until he got a wrong pair, m_IsPlayer1Turn changed to true or end of game
            while ((!m_Game.IsGameOver()) && !m_IsPlayer1Turn && m_Game.IsAIPlay())
            {
                            
                Thread.Sleep(1000);                
                m_Game.GetInputFromAI(ref m_FirstRow, ref m_FirstCol);
                m_Game.FirstReveal(m_FirstRow, m_FirstCol, m_IsPlayer1Turn);
                FirstButton = m_GameForm.Buttons[m_FirstRow, m_FirstCol];

                //changeColor(FirstButton);
                //changeText(m_FirstRow, m_FirstCol, FirstButton);
                FirstButton.Refresh();

                
                Thread.Sleep(1000);
                
                m_Game.GetInputFromAI(ref row, ref col);
                m_Game.SecondReveal(row, col);                
                SecondButton = m_GameForm.Buttons[row, col];

                //changeColor(SecondButton);
               // changeText(row, col, SecondButton);
                SecondButton.Refresh();

                m_Game.CheckTurn(m_FirstRow, m_FirstCol, row, col, ref m_IsPlayer1Turn);                
            }

            if (!m_Game.IsGameOver())
            {
                // reset to last turn of AI - if got here then last pair reveled was wrong and not end of game
                resetButton(FirstButton);
                resetButton(SecondButton);                
            }            

            return true;
        }

        //private void changeColor(object i_Sender)
        //{
        //    if (m_IsPlayer1Turn)
        //    {
        //        (i_Sender as Button).BackColor = m_GameForm.Player1Color;
                
        //    }
        //    else
        //    {
        //        (i_Sender as Button).BackColor = m_GameForm.Player2Color;
        //    }
        //}

        //private void changeText(int o_Row, int o_Col, object i_Sender)
        //{
        //    //char sign = (char)m_Game.GetIndexAtBoard(o_Row, o_Col);
        //    //sign += 'A';           
        //    // (i_Sender as Button).Text = sign.ToString();
            

        //    int index = m_Game.GetIndexAtBoard(o_Row, o_Col);
        //    PictureBox image = new PictureBox();
        //    image.Load(m_picture[index-1]);
        //    //image.SizeMode = PictureBoxSizeMode.AutoSize;    
            
        //    (i_Sender as Button).BackgroundImage = image.Image;
        //    (i_Sender as Button).BackgroundImageLayout = ImageLayout.Center;
        //    //  (i_Sender as Button).BackgroundImage = new Bitmap((i_Sender as Button).BackgroundImage, new Size((i_Sender as Button).Width, (i_Sender as Button).Height));


        //}

        private void resetButton(object i_Sender)
        {
            (i_Sender as Button).ResetText();
            (i_Sender as Button).BackColor = Color.LightGray;
            

            //add
            (i_Sender as Button).BackgroundImage = null;
            (i_Sender as Button).Refresh();
        }

        public void Reveal(int io_Row, int io_Col)
        {
            Button currButton = m_GameForm.Buttons[io_Row, io_Col];
            int index = m_Game.GetIndexAtBoard(io_Row, io_Col);

            PictureBox image = new PictureBox();
            image.Load(m_picture[index - 1]);

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
            

        public void PairFound(int i_Row1, int i_Col1, int i_Row2, int i_Col2, bool i_Found)
        {
            if (i_Found)
            {
                // update score
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
                //show pair for a few seconde and hide
                SecondButton.Refresh();               
                Thread.Sleep(2000);                
                resetButton(FirstButton);
                resetButton(SecondButton);

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
        }

        private void makePictures (int i_size)
        {
            m_picture = new string[i_size];
            string ImgUrl = string.Empty;

            for (int i = 0; i < i_size; i++) 
            {
                System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create("https://picsum.photos/80");
                System.Net.HttpWebResponse myResp = (System.Net.HttpWebResponse)req.GetResponse();
                m_picture[i] = myResp.ResponseUri.ToString();
                myResp.Close();
            }
        }
    }
}