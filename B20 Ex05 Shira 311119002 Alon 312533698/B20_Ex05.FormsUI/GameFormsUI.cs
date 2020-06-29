using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex05.FormsUI
{
    

    class GameFormsUI
    {
        //internal event StartInvoker StartClicked;

        WelcomPage FormSetting = new WelcomPage();
        Game m_game;

        
        

        public GameFormsUI()
        {
            FormSetting.StartClicked += OnStartClick;
            FormSetting.ShowDialog();
            
        }

        internal void OnStartClick (string i_Name1, string i_Name2, bool i_Pvc, int i_Row, int i_Col)
        {
            m_game = new Game(i_Name1, i_Name2, i_Pvc, i_Row, i_Col);
        }



    }
}
