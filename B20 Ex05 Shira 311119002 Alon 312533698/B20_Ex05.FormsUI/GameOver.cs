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
    public delegate void PlayAgainInvoker();

    public partial class GameOver : Form
    {
        internal event PlayAgainInvoker PlayAgainClicked;

        public GameOver(string i_Msg)
        {
            InitializeComponent();
            this.EndGame.Text = i_Msg;
        }

        private void Again_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();

            if (PlayAgainClicked != null)
            {
                PlayAgainClicked.Invoke();
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
