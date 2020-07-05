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

namespace B20_Ex05.FormsUI
{
    class GameWinUI
    {
        //internal event StartInvoker StartClicked;

        WelcomPage m_FormSetting = new WelcomPage();
        GameForm m_GameForm;
        Game m_Game;
        bool m_SecondClick = false; //when click on square this go to true, after second click it invoke pairinvoker
        bool m_IsPlayer1Turn = true;        
        int m_FirstCol;
        int m_FirstRow;
        Button FirstButton;
        Button SecondButton;

        public GameWinUI()
        {
            m_FormSetting.StartClicked += OnStartClick;
            m_FormSetting.ShowDialog();

            if (m_GameForm != null)         
            {
                m_GameForm.PairWasChosen += OnClick;
                m_GameForm.ShowDialog();
            }            
        }

        internal void OnStartClick(string o_Name1, string o_Name2, bool o_Pvc, int o_Row, int o_Col)
        {            
            m_Game = new Game(o_Name1, o_Name2, o_Pvc, o_Row, o_Col);
            m_GameForm = new GameForm(o_Col, o_Row, o_Name1, o_Name2);             
        }

        //internal void OnCra               

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

            changeText(io_Row, io_Col, io_Sender);
            changeColor(io_Sender);

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
                m_Game.CheckTurn(m_FirstRow, m_FirstCol, io_Row, io_Col, ref m_IsPlayer1Turn); // add delgeage?
                SecondButton = (io_Sender as Button);
            }

            // update board........
            if ((!m_Game.IsGameOver()) && !m_IsPlayer1Turn && m_Game.IsAIPlay()) 
            {

                m_GameForm.PairWasChosen -= OnClick;
                m_GameForm.PairWasChosen += OnAIClick;
                //Thread.Sleep(1000);
                //m_Game.GetInputFromAI(ref m_FirstRow, ref m_FirstCol);
                //m_Game.FirstReveal(m_FirstRow, m_FirstCol, m_IsPlayer1Turn); //add to revele..
                //Thread.Sleep(1000);
                //m_Game.GetInputFromAI(ref io_Row, ref io_Col);
                //m_Game.SecondReveal(io_Row, io_Col);
                //m_Game.CheckTurn(m_FirstRow, m_FirstCol, io_Row, io_Col, ref m_IsPlayer1Turn);
            }

            return true;
        }

        private bool OnAIClick(int io_Row, int io_Col, object i_Sender)
        {
            // reset to last turn of user - if got here then last pair reveled was wrong
            resetButton(FirstButton);
            resetButton(SecondButton);

            // AI turn until he got a wrong pair, m_IsPlayer1Turn changed to true or end of game
            while ((!m_Game.IsGameOver()) && !m_IsPlayer1Turn && m_Game.IsAIPlay())
            {
                m_Game.GetInputFromAI(ref m_FirstRow, ref m_FirstCol);
                m_Game.FirstReveal(m_FirstRow, m_FirstCol, m_IsPlayer1Turn); //add to revele..
                FirstButton = m_GameForm.Buttons[m_FirstRow, m_FirstCol];
                changeColor(FirstButton);
                changeText(m_FirstRow, m_FirstCol, FirstButton);

                m_Game.GetInputFromAI(ref io_Row, ref io_Col);
                m_Game.SecondReveal(io_Row, io_Col);
                m_Game.CheckTurn(m_FirstRow, m_FirstCol, io_Row, io_Col, ref m_IsPlayer1Turn);
                SecondButton = m_GameForm.Buttons[m_FirstRow, m_FirstCol];
                changeColor(SecondButton);
                changeText(m_FirstRow, m_FirstCol, SecondButton);

                FirstButton.Show();
                SecondButton.Show();
            }

            if (!m_Game.IsGameOver())
            {
                // reset to last turn of AI - if got here then last pair reveled was wrong and not end of game
                resetButton(FirstButton);
                resetButton(SecondButton);
            }

            // change the next click to user click
            m_GameForm.PairWasChosen -= OnAIClick;
            m_GameForm.PairWasChosen += OnClick;

            return true;
        }

        private void changeColor(object i_Sender)
        {
            if (m_IsPlayer1Turn)
            {
                (i_Sender as Button).BackColor = Color.LightGreen;
            }
            else
            {
                (i_Sender as Button).BackColor = Color.LightBlue;
            }
        }

        private void changeText(int o_Row, int o_Col, object i_Sender)
        {
            char sign = (char)m_Game.GetIndexAtBoard(o_Row, o_Col);
            sign += 'A';
            (i_Sender as Button).Text = sign.ToString();
        }

        private void resetButton(object i_Sender)
        {
            (i_Sender as Button).ResetText();
            (i_Sender as Button).BackColor = Color.LightGray;
        }
    }
}