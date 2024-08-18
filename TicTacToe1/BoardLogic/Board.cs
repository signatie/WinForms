using System;

namespace BoardLogic
{
    public class Board
    {
        // Represents the game board grid where 0 = empty, 1 = player, 2 = computer
        public int[] Grid { get; set; }

        public Board()
        {
            // Initialize a 3x3 grid with all positions empty
            Grid = new int[9];
        }

        // Checks if the board is full (i.e., no more moves possible)
        public bool IsBoardFull()
        {
            foreach (var cell in Grid)
            {
                if (cell == 0) return false;
            }
            return true;
        }

        // Checks if there is a winner on the board
        public int CheckForWinner()
        {
            // Possible winning combinations
            int[][] winningCombinations = new int[][]
            {
                new int[] { 0, 1, 2 }, // Top row
                new int[] { 3, 4, 5 }, // Middle row
                new int[] { 6, 7, 8 }, // Bottom row
                new int[] { 0, 3, 6 }, // First column
                new int[] { 1, 4, 7 }, // Second column
                new int[] { 2, 5, 8 }, // Third column
                new int[] { 0, 4, 8 }, // First diagonal
                new int[] { 2, 4, 6 }  // Second diagonal
            };

            // Check each combination for a winner
            foreach (var combo in winningCombinations)
            {
                if (Grid[combo[0]] != 0 && Grid[combo[0]] == Grid[combo[1]] && Grid[combo[1]] == Grid[combo[2]])
                {
                    return Grid[combo[0]];
                }
            }

            // No winner found
            return 0;
        }
    }
}