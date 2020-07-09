using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace B20_Ex05.FormsUI
{
    public class GameWinUI
    {
        private SettingForm m_FormSetting = new SettingForm();
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
            ////Function for SettingForm to Invoke when User press "Start"
            ////Gets all of the game setting and create a new game

            createNewGame(o_Name1, o_Name2, o_Pvc, o_Row, o_Col);            
        }

        internal void OnPlayAgain()
        {
            ////Function for GameOver to Invoke when User press "Play Again"
            ////Create a new game with the same setting as the previous game

            createNewGame(m_Game.Player1Name(), m_Game.Player2Name(), m_Game.IsAIPlay(), m_Game.BoardRows(), m_Game.BoardCols());
        }

        private void createNewGame(string o_Name1, string o_Name2, bool o_Pvc, int o_Row, int o_Col)
        {            
            ////Gets all of the game setting and create a new game

            m_Game = new Game(o_Name1, o_Name2, o_Pvc, o_Row, o_Col);
            m_GameForm = new GameForm(o_Col, o_Row, o_Name1, o_Name2);
            m_Game.PairWasFound += OnPairFound;
            m_Game.Reveal += OnReveal;
            makePictures((o_Row * o_Col) / 2);
            m_IsPlayer1Turn = true;
            m_SecondClick = false;
        }

        internal bool OnClick(Button i_Sender)
        {
            ////Function for GameForm to Invoke when User press any tile button
            ////Gets what button was pressed, 
            ////Play the game based on witch turn it was by calling GameLogic Function

            int row = int.Parse(i_Sender.Name[0].ToString());
            int col = int.Parse(i_Sender.Name[2].ToString());

            if (!m_SecondClick)
            {
                m_SecondClick = true;
                m_Game.FirstReveal(row, col, m_IsPlayer1Turn);                
                m_FirstRow = row;
                m_FirstCol = col;
                m_FirstButton = i_Sender;
            }
            else 
            {
                m_SecondClick = false;
                m_Game.SecondReveal(row, col);
                m_SecondButton = i_Sender;
                m_Game.CheckTurn(m_FirstRow, m_FirstCol, row, col, ref m_IsPlayer1Turn);           
            }
            
            if ((!m_Game.IsGameOver()) && !m_IsPlayer1Turn && m_Game.IsAIPlay()) 
            {
                m_GameForm.Enabled = false;
                Cursor.Current = Cursors.WaitCursor;
                m_GameForm.Refresh();
                
                playAI();

                m_GameForm.Enabled = true;
                Cursor.Current = Cursors.Default;
                m_GameForm.Refresh();
            }

            return m_Game.IsGameOver();
        }       

        private void playAI()
        {
            ////Function called when AI is playing & it is his turn to play
            ////Call AI Input and let's it play until the game is over or when his turn passed

            int row = -1, col = -1;
            
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
            ////Reset button to "Hidden" mode in the game

            i_Button.BackColor = Color.LightGray;
            i_Button.BackgroundImage = null;
            i_Button.Refresh();
        }

        internal void OnReveal(int io_Row, int io_Col)
        {
            ////Function for GameLogic to Invoke when the tile is reveled
            ////Gets what indexes was reveled  
            ////Set the correct button on GameForm to "Expose" state

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
            ////Function for GameLogic to Invoke when the Turn is finished
            ////Gets if the last turn exposed a pair or not:
            ////    1.If pair was found : Update Score 
            ////    2.If pair was not found : Hide the tiles

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
            ////Write Score and Creating gameOver Form for last game playied
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
                "{2}{0} with {1} pair(s) revealed.{2}{3} with {4} pair(s) revealed.",
                m_Game.Player1Name(),
                m_Game.Player1Score(),
                Environment.NewLine,
                m_Game.Player2Name(),
                m_Game.Player2Score());
            prompt.Append(msg);

            m_GameOver = new GameOver(prompt.ToString());
            m_GameOver.PlayAgainClicked += OnPlayAgain;
        }

        private void makePictures(int i_AmountOfPairsInGame)
        {
            ////Gets Amount of pairs in game
            ////Create an Araay of String, and Puts a random Image URL string in each cell
            
            m_Pictures = new string[i_AmountOfPairsInGame];
            string ImgUrl = string.Empty;

            for (int i = 0; i < i_AmountOfPairsInGame; i++) 
            {
                System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create("https://picsum.photos/80");
                System.Net.HttpWebResponse myResp = (System.Net.HttpWebResponse)req.GetResponse();
                m_Pictures[i] = myResp.ResponseUri.ToString();
                myResp.Close();
            }
        }
    }
}