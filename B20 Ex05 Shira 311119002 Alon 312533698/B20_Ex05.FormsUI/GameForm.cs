using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B20_Ex05.FormsUI
{

    public delegate bool PairInvoker(string i_Name1, string i_Name2, bool i_Pvc, int i_NumOfRows, int i_NumOfCols);
    public partial class GameForm : Form
    {
        bool m_firstClick = false; //when click on square this go to true, after second click it invoke pairinvoker
        internal event PairInvoker PairsWaschosen;

        public GameForm()
        {
            InitializeComponent();
        }

        //for each botton the same invoker...

        
    }
}
