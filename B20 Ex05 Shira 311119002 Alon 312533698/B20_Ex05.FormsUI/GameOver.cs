using System;
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
            this.m_ScoreLabel.Text = i_Msg;
        }

        private void again_Click(object i_sender, EventArgs i_e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();

            if (PlayAgainClicked != null)
            {
                PlayAgainClicked.Invoke();
            }
        }

        private void exit_Click(object i_sender, EventArgs i_e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}