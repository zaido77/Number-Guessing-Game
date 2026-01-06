using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Number_Guessing_Game
{
    public partial class frmDifficulty : Form
    {
        public frmDifficulty()
        {
            InitializeComponent();

            btnEasy.Tag = 5;
            btnMedium.Tag = 10;
            btnHard.Tag = 20;
        }

        private void btnDifficulty_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Form form = new frmGame(button.Text.ToUpper(), Convert.ToInt32(button.Tag));

            this.Hide();

            form.FormClosed += (s, args) =>
            {
                this.Show();
            };

            form.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are uou sure you want to exit the game", "Exit Game",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
