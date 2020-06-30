using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex05.FormsUI
{
    

    class GameWinUI
    {
        //internal event StartInvoker StartClicked;

        WelcomPage m_FormSetting = new WelcomPage();
        GameForm m_GameForm;
        Game m_game;       
        

        public GameWinUI()
        {
            m_FormSetting.StartClicked += OnStartClick;
            m_FormSetting.ShowDialog();
            if (m_GameForm != null)         
            {
               
                m_GameForm.ShowDialog();
            }
            
        }

        internal void OnStartClick (string i_Name1, string i_Name2, bool i_Pvc, int i_Row, int i_Col)
        {
            string name = i_Name1 + ":";
            m_game = new Game(i_Name1, i_Name2, i_Pvc, i_Row, i_Col);
            m_GameForm = new GameForm(i_Col, i_Row); //needs to be: ----> m_GameForm = new GameForm(i_Row, i_Col); 

            m_GameForm.Player1Name = name;
            name = i_Name2 + ":";
            m_GameForm.Player2Name = name;
        }

        //internal void OnCra
               

        internal bool OnReveal(int i_Row1, int i_Col1, int i_Row2, int i_Col2, bool i_IsTurnPlayer1)
        {
            bool Isplayer1 = i_IsTurnPlayer1;
            bool foundPair = false;
            m_game.FirstReveal(i_Row1, i_Col1, i_IsTurnPlayer1);
            m_game.SecondReveal(i_Row2, i_Col2);
            m_game.CheckTurn(i_Row1, i_Col1, i_Row2, i_Col2,ref i_IsTurnPlayer1);

            if (Isplayer1 == i_IsTurnPlayer1)
            {
                foundPair = true;
            }
            return foundPair;
        }



        



    }
}
