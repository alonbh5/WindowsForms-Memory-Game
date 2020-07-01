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



        public GameWinUI()
        {
            m_FormSetting.StartClicked += OnStartClick;
            m_FormSetting.ShowDialog();
            if (m_GameForm != null)         
            {
                m_GameForm.PairsWaschosen += OnClick;
                m_GameForm.ShowDialog();
            }
            
        }

        internal void OnStartClick(string i_Name1, string i_Name2, bool i_Pvc, int i_Row, int i_Col)
        {
            
            m_Game = new Game(i_Name1, i_Name2, i_Pvc, i_Row, i_Col);
            m_GameForm = new GameForm(i_Col, i_Row, i_Name1, i_Name2);             
        }

        //internal void OnCra
               

        internal bool OnReveal(int i_Row1, int i_Col1, int i_Row2, int i_Col2, bool i_IsTurnPlayer1)
        {
            bool Isplayer1 = i_IsTurnPlayer1;
            bool foundPair = false;
            m_Game.FirstReveal(i_Row1, i_Col1, i_IsTurnPlayer1);
            m_Game.SecondReveal(i_Row2, i_Col2);
            m_Game.CheckTurn(i_Row1, i_Col1, i_Row2, i_Col2,ref i_IsTurnPlayer1);

            if (Isplayer1 == i_IsTurnPlayer1)
            {
                foundPair = true;
            }
            return foundPair;
        }

        internal bool OnClick (int i_col,int i_row, object sender)
        {
            
            //gets it from Form,
            if (!m_SecondClick)
            {
                //case first click, need to update text
                //as button sender all of that
                m_SecondClick = true;
                m_Game.FirstReveal(i_row, i_col, m_IsPlayer1Turn);
                m_FirstRow = i_row;
                m_FirstCol = i_col;
                FirstButton = (sender as Button);


                char t = (char)m_Game.GetIndexAtBoard(i_row, i_col);
                t += 'A';
                (sender as Button).Text = t.ToString();
                if (m_IsPlayer1Turn)
                {
                    (sender as Button).BackColor = Color.LightGreen;
                }
                else
                {
                    (sender as Button).BackColor = Color.LightBlue;
                }
            }
            else 
            {
                m_SecondClick = false;
                m_Game.SecondReveal(i_row, i_col);                
                m_Game.CheckTurn(m_FirstRow, m_FirstCol, i_row, i_col, ref m_IsPlayer1Turn); // add delgeage?


                char t = (char)m_Game.GetIndexAtBoard(i_row, i_col);
                t += 'A';
                (sender as Button).Text = t.ToString();
                if (m_IsPlayer1Turn)
                {
                    (sender as Button).BackColor = Color.LightGreen;
                }
                else
                {
                    (sender as Button).BackColor = Color.LightBlue;
                }

            }

            // update board........
            while ((!m_Game.IsGameOver()) && !m_IsPlayer1Turn && m_Game.IsAIPlay()) 
            {
                Thread.Sleep(1000);
                m_Game.GetInputFromAI(ref m_FirstRow, ref m_FirstCol);
                m_Game.FirstReveal(m_FirstRow, m_FirstCol, m_IsPlayer1Turn); //add to revele..
                Thread.Sleep(1000);
                m_Game.GetInputFromAI(ref i_row, ref i_col);
                m_Game.SecondReveal(i_row, i_col);
                m_Game.CheckTurn(m_FirstRow, m_FirstCol, i_row, i_col, ref m_IsPlayer1Turn);
            }

            return true;
        }


        



    }
}
