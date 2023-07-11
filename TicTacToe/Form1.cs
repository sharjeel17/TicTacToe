using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {

        private List<Button> buttons;
        private int P1Wins = 0;
        private int P2Wins = 0;
        public Form1()
        {
            InitializeComponent();

            buttons = new List<Button> { button1, button2, button3, button4,
                button5, button6, button7, button8, button9 };

        }


        int turn = 0;

        private void restartGame(object sender, EventArgs e)
        {
            restartGame();
        }

        private void restartGame() 
        {
            foreach (Button button in buttons) 
            {
                button.Enabled = true;
                button.Text = "";
            }
        }

        public void checkWinner()
        {
            if ((button1.Text == "X" && button2.Text == "X" && button3.Text == "X")
                || (button4.Text == "X" && button5.Text == "X" && button6.Text == "X")
                || (button7.Text == "X" && button8.Text == "X" && button9.Text == "X")
                || (button1.Text == "X" && button5.Text == "X" && button9.Text == "X")
                || (button3.Text == "X" && button5.Text == "X" && button7.Text == "X")
                || (button1.Text == "X" && button4.Text == "X" && button7.Text == "X")
                || (button2.Text == "X" && button5.Text == "X" && button8.Text == "X")
                || (button3.Text == "X" && button6.Text == "X" && button9.Text == "X")) 
            {
                MessageBox.Show("X has won the game!", "We have a winner!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                label1.Text = $"Player 1 wins: {++P1Wins}";
                restartGame();
            }
            else if ((button1.Text == "O" && button2.Text == "O" && button3.Text == "O")
                || (button4.Text == "O" && button5.Text == "O" && button6.Text == "O")
                || (button7.Text == "O" && button8.Text == "O" && button9.Text == "O")
                || (button1.Text == "O" && button5.Text == "O" && button9.Text == "O")
                || (button3.Text == "O" && button5.Text == "O" && button7.Text == "O")
                || (button1.Text == "O" && button4.Text == "O" && button7.Text == "O")
                || (button2.Text == "O" && button5.Text == "O" && button8.Text == "O")
                || (button3.Text == "O" && button6.Text == "O" && button9.Text == "O"))
            {
                MessageBox.Show("O has won the game!", "We have a winner!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                label2.Text = $"Player 2 wins: {++P2Wins}";
                restartGame();
            }
        }
        public string symbol(int turn) 
        {
            if (turn % 2 == 0) return "O";
            else return "X";
        }

        private void PlayerButtons(object sender, EventArgs e)
        {
            turn++;
            var button = (Button)sender;
            button.Text = symbol(turn);
            button.Enabled = false;
            checkWinner();
        }
    }
}
