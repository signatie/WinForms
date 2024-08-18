using BoardLogic;
using System;

namespace TicTacToe1
{
    class Program
    {
        // boar is the data store for the game
        static Board game = new Board();

        static void Main(string[] args)
        {
            int userTurn = -1;
            int computerTurn = -1;
            Random rand = new Random();

            while (game.CheckForWinner() == 0)
            {
                // don't allow the human to choose an already occupied square
                while (userTurn == -1 || game.Grid[userTurn] != 0)
                {
                    Console.WriteLine("Please enter a number from 0 to 8");
                    userTurn = int.Parse(Console.ReadLine()!);
                    Console.WriteLine("You typed " + userTurn);
                }

                game.Grid[userTurn] = 1;

                if (game.IsBoardFull())
                    break;

                // don't let the computer pick an invalid number
                while (computerTurn == -1 || game.Grid[computerTurn] != 0)
                {
                    computerTurn = rand.Next(8);
                    Console.WriteLine("Computer chooses " + computerTurn);
                }

                game.Grid[computerTurn] = 2;

                if (game.IsBoardFull())
                    break;

                PrintBoard();
            }

            Console.WriteLine("Player " + game.CheckForWinner() + " won the game");
            Console.ReadLine();
        }

        private static void PrintBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                // print the board
                // Console.WriteLine("Square " + i + " constains " + board[i]);

                // print x or o for each square
                // 0 means unoccupied. 1 means player 1 (x) 2 means player 2 (o)

                if (game.Grid[i] == 0)
                {
                    Console.Write(".");
                }
                if (game.Grid[i] == 1)
                {
                    Console.Write("x");
                }
                if (game.Grid[i] == 2)
                {
                    Console.Write("o");
                }

                // print a new line every third character
                if (i == 2 || i == 5 || i == 8)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
