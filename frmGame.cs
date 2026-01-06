using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Number_Guessing_Game
{
    public partial class frmGame : Form
    {
        static Random random = new Random();

        static int _MaxNumberToGuess;

        public frmGame(string sDifficultyMode, int DifficultyTagNumber)
        {
            InitializeComponent();

            _MaxNumberToGuess = DifficultyTagNumber;

            lblTitle.Text = "Guess Between 1 - " + DifficultyTagNumber.ToString();
            lblSubTitle.Text = "Mode: " + sDifficultyMode;
        }

        int _NumberToGuess = GenerateRandomNumber();

        static int GenerateRandomNumber()
        {
            return random.Next(1, _MaxNumberToGuess + 1);
        }

        void AddOneTolblNumberGuess()
        {
            int NumberGuessValue = Convert.ToInt32(lblNumberGuess.Text);

            if (NumberGuessValue < _MaxNumberToGuess)
            {
                lblNumberGuess.Text = (NumberGuessValue + 1).ToString();
            }
        }

        void SubtractOneFromlblNumberGuess()
        {
            int NumberGuessValue = Convert.ToInt32(lblNumberGuess.Text);

            if (NumberGuessValue > 1)
            {
                lblNumberGuess.Text = (NumberGuessValue - 1).ToString();
            }
        }

        void UpdateNumberGuess(Button button)
        {
            if (Convert.ToChar(button.Tag) == '+')
            {
                AddOneTolblNumberGuess();
            }
            else
            {
                SubtractOneFromlblNumberGuess();
            }
        }

        void PerformCorrectAnswerAction()
        {
            SystemSounds.Beep.Play();

            lblCorrectWrong.Text = "Correct!";
            lblCorrectWrong.ForeColor = Color.LightGreen;

            btnSubmit.Enabled = false;
            btnAdd.Enabled = false;
            btnSubtract.Enabled = false;
        }

        void PerformWrongAnswerAction()
        {
            SystemSounds.Hand.Play();

            lblCorrectWrong.Text = "Wrong!";
            lblCorrectWrong.ForeColor = Color.Red;
        }

        void ShowSubmitMessage()
        {
            lblCorrectWrong.Visible = true;

            if (lblNumberGuess.Text == _NumberToGuess.ToString())
            {
                PerformCorrectAnswerAction();
            }
            else
            {
                PerformWrongAnswerAction();
            }
        }

        void ResetFrom()
        {
            _NumberToGuess = GenerateRandomNumber();

            lblNumberGuess.Text = "1";
            lblCorrectWrong.Text = "";

            btnSubmit.Enabled = true;
            btnAdd.Enabled = true;
            btnSubtract.Enabled = true;
        }

        private void btnAddSubtract_Click(object sender, EventArgs e)
        {
            UpdateNumberGuess((Button) sender);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are uou sure you want to exit the game", "Exit Game", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            ShowSubmitMessage();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            ResetFrom();
        }
    }
}
