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
    public partial class WelcomPage : Form
    {
        private int m_BoardCol = 6;
        private int m_BoardRow = 6;
        public bool m_PvP = false;

        public WelcomPage()
        {
            InitializeComponent();
        }

        private void PVPButton_Click(object sender, EventArgs e)
        {
            m_PvP = !m_PvP;

            if (m_PvP)
            {
                PVPButton.Text = "Aginst a Friend";
                Player2NameTextBox.Enabled = false;
                Player2NameTextBox.Text = "-Computer-";
            }
            else
            {
                PVPButton.Text = "Aginst Computer";
                Player2NameTextBox.Enabled = true;
                Player2NameTextBox.Text = string.Empty;
            }

        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (Player1NameTextBox.Text == string.Empty || Player1NameTextBox.Text == string.Empty)
            {

            }
            else
            {
                
            }
        }

        private void BoardSizeButton_Click(object sender, EventArgs e)
        {
           
        }
    }
}
