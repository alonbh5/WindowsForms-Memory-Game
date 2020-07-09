using System.Text;
using System;

//// To Play Game:
//// 1. Create New Game Object 
//// 2. While (IsGameOver)
////    {  
////      2.1. First Reveal 
////      2.2. Second Reveal 
////      2.3. Check Turn
////    }
//// To get Input From AI use GetInputFromAI
//// To get winner use getWinner 
//// To get score use  getScore
//// To Get StringBuilde of the Gameboard use ToStringBuilder (Array of Object (object[i]=pair # i))
//// NOTICE: Object X in Array of Object must have ToString Function!

 namespace B20_Ex05
{
    public delegate void PairFoundInvoker(bool i_Found);

    public delegate void RevealInvoker(int i_row, int i_col);

    public class Game             
    {
        public event PairFoundInvoker PairWasFound;

        public event RevealInvoker Reveal;

        internal static Random s_Random = new Random();
        private Player m_Player1;
        private Player m_Player2;
        private Board m_GameBoard;        

        public Game(string i_Name1, string i_Name2, bool i_Pvc, int i_Row, int i_Col)
        {
            //// Ctor for new game - gets name of player 1, name of player 2,
            //// T / F if Player2 = AI, Row length, Col length

            const bool v_PlayerIsComputer = false;

            m_Player1 = new Player(i_Name1, v_PlayerIsComputer);
            m_Player2 = new Player(i_Name2, i_Pvc);
            m_GameBoard = new Board(i_Row, i_Col);
        }

        public string Player1Name()
        {
            return m_Player1.Name;
        }

        public string Player2Name()
        {
            return m_Player2.Name;
        }

        public int Player1Score()
        {
            return m_Player1.Pairs;
        }

        public int Player2Score()
        {
            return m_Player2.Pairs;
        }

        public int BoardCols()
        {
            return m_GameBoard.Cols;
        }

        public int BoardRows()
        {
            return m_GameBoard.Rows;
        }

        public void FirstReveal(int i_Row, int i_Col, bool i_TurnPlayer1)
        {
            m_GameBoard.Expose(i_Row, i_Col);

            if (Reveal != null)
            {
                Reveal.Invoke(i_Row, i_Col);
            }

            if (m_Player2.Pc && !i_TurnPlayer1) 
            { // Case this is turn of player 2 and it is AI -> need to update memeory of AI.
                m_Player2.m_PlayerVsComputer.UpdateMemory(i_Row, i_Col, m_GameBoard.m_Board[i_Row, i_Col].Value);
            }
        }

        public void SecondReveal(int i_Row, int i_Col)
        {
            m_GameBoard.Expose(i_Row, i_Col);

            if (Reveal != null)
            {
                Reveal.Invoke(i_Row, i_Col);
            }
        }

        public void GetInputFromAI(ref int io_Row, ref int io_Col)
        {            
            m_Player2.m_PlayerVsComputer.PlayTurn(ref io_Row, ref io_Col, m_GameBoard);
        }

        private void unrevealed(int i_Row1, int i_Col1, int i_Row2, int i_Col2)
        {
            m_GameBoard.Unexpose(i_Row1, i_Col1);
            m_GameBoard.Unexpose(i_Row2, i_Col2);
        }

        public void CheckTurn(int i_Row1, int i_Col1, int i_Row2, int i_Col2, ref bool io_TurnPlayer1)
        {
            bool changePlayer = false;
            Player currentPlayer = m_Player1;

            if (!io_TurnPlayer1)
            {
                currentPlayer = m_Player2;
            }

            if (m_GameBoard.CheckPair(i_Row1, i_Col1, i_Row2, i_Col2))
            { // Case found pair
                currentPlayer.Pairs++;
                m_GameBoard.PairFound();
            }
            else
            {
                unrevealed(i_Row1, i_Col1, i_Row2, i_Col2);
                changePlayer = true;
            }            

            if (changePlayer)
            { // Case not found a pair              
                if (m_Player2.Pc)
                {
                    if (io_TurnPlayer1)
                    { // Case not won and not AI turn -> update AI memory for both exposures
                        m_Player2.m_PlayerVsComputer.UpdateMemory(i_Row1, i_Col1, m_GameBoard.m_Board[i_Row1, i_Col1].Value);
                    }

                    m_Player2.m_PlayerVsComputer.UpdateMemory(i_Row2, i_Col2, m_GameBoard.m_Board[i_Row2, i_Col2].Value);
                }

                io_TurnPlayer1 = !io_TurnPlayer1;
            }

            if (PairWasFound != null)
            {
                PairWasFound.Invoke(!changePlayer);
            }
        }

        public bool GetWinner(out string o_Winner)
        { // Return true if it's a tie or false if there is one winner
            bool isTie = false;

            if (m_Player1.Pairs == m_Player2.Pairs)
            {
                isTie = true;
                o_Winner = m_Player1.Name;
            }

            if (m_Player1.Pairs > m_Player2.Pairs)
            {
                o_Winner = m_Player1.Name;
            }
            else
            {
                o_Winner = m_Player2.Name;
            }

            return isTie;
        }

        public bool CheckTile(int io_Col, int io_Row)
        {
            return !m_GameBoard.m_Board[io_Row, io_Col].Expose;
        }

        public bool IsGameOver()
        {
            return m_GameBoard.IsGameOver();
        }

        public int GetIndexAtBoard(int i_Row, int i_Col)
        {
            return m_GameBoard.m_Board[i_Row, i_Col].Value;
        }

        public bool IsAIPlay()
        {
            return m_Player2.Pc;
        }

        public StringBuilder ToStringBuilder(object[] io_CharsToPrint)
        {
            return m_GameBoard.ToStringBuilder(io_CharsToPrint);
        }
    }
}