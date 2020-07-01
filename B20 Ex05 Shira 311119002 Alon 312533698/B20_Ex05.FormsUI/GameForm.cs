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

    //public delegate bool PairInvoker(string i_Name1, string i_Name2, bool i_Pvc, int i_NumOfRows, int i_NumOfCols);
    public delegate bool PairInvoker(int i_row,int i_col, object sender);
    public partial class GameForm : Form
    {
        
        internal Button[,] m_buttons;
        internal event PairInvoker PairsWaschosen;
        private int m_player1Pairs = 0;
        private int m_player2Pairs = 0;
        private string m_player1Name;
        private string m_player2Name;

        public GameForm(int col, int row,string player1Name,string player2Name)
        {
            InitializeComponent();
            createButtons(col, row);
            m_Player1Label.Text = String.Format("{0}: {1} Pairs", player1Name, m_player1Pairs);
            m_player1Name = player1Name;
            m_Player2Label.Text = String.Format("{0}: {1} Pairs", player2Name, m_player2Pairs);
            m_player2Name = player2Name;
            m_CurrentPlayer.Text = String.Format("Curent Player: {0}", player1Name);
        }
        
        
        internal string Player1Name
        {
            set { m_player1Name = value; }
            get { return m_player1Name; }
        }

        internal string Player2Name
        {
            set { m_player2Name = value; }
            get { return m_player2Name; }
        }

        internal void Player1FoundPair () //updatescore
        {
            m_player1Pairs++;
            m_Player1Label.Text=String.Format("{0}: {1} Pairs", Player1Name, m_player1Pairs);
        }

        internal void Player2FoundPair() //upadte score
        {
            m_player2Pairs++;
            m_Player2Label.Text = String.Format("{0}: {1} Pairs", Player2Name, m_player2Pairs);
        }


        private void createButtons (int i_Col, int i_Row)
        {
            m_buttons = new Button[i_Row, i_Col];
            Button curButton;
            int x = 25;
            int y = 25;
            int spaceX = 115;// (int)(this.ClientSize.Width *0.06);
            int spaceY = 105;// (int)(this.ClientSize.Height * 0.06);

            this.Size = new Size(130 * i_Col, 146 * i_Row);

            for (int i = 0; i< i_Row; i++)
            {
                for (int j = 0; j< i_Col; j++)
                {
                    m_buttons[i, j] = new Button();                    
                    curButton = m_buttons[i, j];
                    curButton.AutoSize = true;
                    curButton.Location = new System.Drawing.Point(x, y);                    
                    curButton.Size = new System.Drawing.Size(100, 100);
                    curButton.TabIndex = i*10+j;
                    curButton.Name = i+"-"+j;
                    curButton.UseVisualStyleBackColor = true;
                    curButton.Anchor = AnchorStyles.Right;
                    curButton.BackColor = Color.LightGray;
                    curButton.Click += TileButton_Click;
                    this.Controls.Add(curButton);
                    x += spaceX;
                }
                x = 25;
                y += spaceY;
            }
           
        }

        private void TileButton_Click(object sender, EventArgs e)
        {            
            if (sender is Button)
            {
                if ((sender as Button).BackColor == Color.LightGray)
                {
                    int row = int.Parse((sender as Button).Name[0].ToString());
                    int col = int.Parse((sender as Button).Name[2].ToString());
                    if (PairsWaschosen != null)
                    {
                        PairsWaschosen.Invoke(row,col, sender);
                    }
                }
            }
        }
    }
}
