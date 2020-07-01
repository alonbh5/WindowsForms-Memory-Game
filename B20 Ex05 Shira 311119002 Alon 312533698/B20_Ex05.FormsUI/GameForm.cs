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
        internal Button[,] m_buttons;
        internal event PairInvoker PairsWaschosen;

        public GameForm(int col, int row)
        {
            InitializeComponent();
            createButtons(col, row);            
        }

        //for each botton the same invoker...
        
        internal string Player1Name
        {
            set { m_Player1Label.Text = value; }
        }

        internal string Player2Name
        {
            set { m_Player2Label.Text = value; }
        }

        private void createButtons (int i_col, int i_row)
        {
            m_buttons = new Button[i_row, i_col];
            Button curButton;
            int x = 25;
            int y = 25;
            int spaceX = 115;// (int)(this.ClientSize.Width *0.06);
            int spaceY = 105;// (int)(this.ClientSize.Height * 0.06);

            this.Size = new Size(130 * i_col, 146 * i_row);

            for (int i = 0; i< i_row; i++)
            {
                for (int j = 0; j< i_col; j++)
                {
                    m_buttons[i, j] = new Button();                    
                    curButton = m_buttons[i, j];
                    curButton.AutoSize = true;
                    curButton.Location = new System.Drawing.Point(x, y);
                    //curButton.Name = "button1";
                    curButton.Size = new System.Drawing.Size(100, 100);
                    curButton.TabIndex = i+j;
                    curButton.Text = "button"+i+"."+j;
                    curButton.UseVisualStyleBackColor = true;
                    curButton.Anchor = AnchorStyles.Right;
                    this.Controls.Add(curButton);
                    x += spaceX;
                }
                x = 25;
                y += spaceY;
            }
            
            
        }
    }
}
