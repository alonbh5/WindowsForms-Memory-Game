﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex05.FormsUI
{
    static class Program
    {
        public static void Main ()
        {
            //GameFormsUI NewGame = new GameFormsUI();
            WelcomPage FormSetting = new WelcomPage();
            FormSetting.ShowDialog();
        }
    }
}