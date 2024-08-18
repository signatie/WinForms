using BoardLogic;
using System;
using System.Windows.Forms;

namespace TicTacGUI
{
    public partial class Form1 : Form
    {
        // The game board instance
        private Board game = new Board();

        // Array to store the buttons representing the Tic-Tac-Toe grid
        private Button[] buttons;

        // Random number generator for the computer's moves
        private Random rand = new Random();

        public Form1()
        {
            InitializeComponent();

            // Initialize the buttons array with the buttons from the UI
            buttons = new Button[] { button1, button2, button3, button4, button5, button6, button7, button8, button9 };

            // Assign event handlers and tags to the buttons
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Click += HandleButtonClick;
                buttons[i].Tag = i;
            }
        }

        // Event handler for when a button is clicked by the player
        private void HandleButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int gameSquareNumber = (int)clickedButton.Tag;

            // Mark the player's move on the game board
            game.Grid[gameSquareNumber] = 1;

            // Update the UI to reflect the move
            UpdateBoard();

            // Check if the player has won or if the board is full
            if (game.CheckForWinner() == 1)
            {
                MessageBox.Show("Player human wins!");
                DisableAllButtons();
            }
            else if (game.IsBoardFull())
            {
                MessageBox.Show("The board is full");
                DisableAllButtons();
            }
            else
            {
                // Let the computer make its move
                ComputerChoose();
            }
        }

        // Disables all buttons after a game ends
        private void DisableAllButtons()
        {
            foreach (var button in buttons)
            {
                button.Enabled = false;
            }
        }

        // Logic for the computer's move
        private void ComputerChoose()
        {
            int computerTurn;

            // Ensure the computer chooses an empty square
            do
            {
                computerTurn = rand.Next(9);
            } while (game.Grid[computerTurn] != 0);

            // Mark the computer's move on the game board
            game.Grid[computerTurn] = 2;

            // Update the UI to reflect the move
            UpdateBoard();

            // Check if the computer has won or if the board is full
            if (game.CheckForWinner() == 2)
            {
                MessageBox.Show("Player computer wins!");
                DisableAllButtons();
            }
            else if (game.IsBoardFull())
            {
                MessageBox.Show("The board is full");
                DisableAllButtons();
            }
        }

        // Event handler for when the form loads
        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateBoard();
        }

        // Updates the UI to reflect the current state of the game board
        private void UpdateBoard()
        {
            for (int i = 0; i < game.Grid.Length; i++)
            {
                if (game.Grid[i] == 0)
                {
                    buttons[i].Text = "";
                    buttons[i].Enabled = true;
                    buttons[i].ForeColor = System.Drawing.Color.Black;
                }
                else if (game.Grid[i] == 1)
                {
                    buttons[i].Text = "X";
                    buttons[i].Enabled = false;
                    buttons[i].ForeColor = System.Drawing.Color.Red;
                }
                else if (game.Grid[i] == 2)
                {
                    buttons[i].Text = "O";
                    buttons[i].Enabled = false;
                    buttons[i].ForeColor = System.Drawing.Color.Green;
                }
            }
        }

        // Enables all buttons to start a new game and clears the board
        private void EnableButtons()
        {
            foreach (var button in buttons)
            {
                button.Enabled = true;
            }

            UpdateBoard();
        }

        // Event handler for the "New Game" button
        private void Button10_Click(object sender, EventArgs e)
        {
            game = new Board();
            EnableButtons();
        }
    }
}

