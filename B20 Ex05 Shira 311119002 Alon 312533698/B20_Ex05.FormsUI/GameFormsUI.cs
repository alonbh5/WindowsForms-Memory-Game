using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex05.FormsUI
{
    public delegate void ClickInvoker();

    class GameFormsUI
    {
        internal event ClickInvoker PvpClicked;

        WelcomPage FormSetting = new WelcomPage();
        
        

        public GameFormsUI()
        {
            FormSetting.Show();
        }

        
    }
}
