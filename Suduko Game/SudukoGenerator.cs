
namespace Suduko_Game
{
    internal class SudukoGenerator
    {

        static int[,] solution = new int[9, 9];
        static int[,] puzzle = new int[9, 9];
        static Random rnd = new Random();

        internal static int[,] GenerateSuduko(int removeCount = 40)
        {
            // Initialize grids
            Array.Clear(solution, 0, solution.Length);
            Array.Clear(puzzle, 0, puzzle.Length);

            FillDiagonal();
            SolveSuduko(solution);

            // Copy solution to puzzle
            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    puzzle[r, c] = solution[r, c];
                }
            }

            RemoveCells(removeCount);
            return puzzle;
        }

        private static void FillDiagonal()
        {
            // Fill the diagonal 3x3 boxes
            for (int i = 0; i < 9; i += 3)
            {
                FillBox(i, i);

            }
        }

        private static void FillBox(int row, int col)
        {
            bool[] used = new bool[10];

            // Fill the 3x3 box
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int num;
                    do
                    {
                        num = rnd.Next(1, 10);
                    }
                    while (used[num]);

                    used[num] = true;
                    solution[row + i, col + j] = num;
                }
            }
        }

        private static bool FindEmpty(int[,] grid, out int row, out int col)
        {
            // Search for an empty cell
            for (row = 0; row < 9; row++)
                for (col = 0; col < 9; col++)
                    if (grid[row, col] == 0)
                    {
                        return true;
                    }

            row = col = -1;
            return false;
        }


        private static bool SolveSuduko(int[,] grid)
        {
            // Find an empty cell
            if (!FindEmpty(grid, out int row, out int col))
            {
                return true;
            }

            // Try numbers 1-9
            for (int num = 1; num <= 9; num++)
            {
                if (IsSafe(grid, row, col, num))
                {
                    grid[row, col] = num;
                    if (SolveSuduko(grid))
                    {
                        return true;
                    }
                }
            }

            grid[row, col] = 0;
            return false;
        }

        // Check if the Sudoku is solved
        internal static bool isSolved(int[,] grid)
        {
            for (int r = 0; r < 9; r++)
            {
                // Check each cell
                for (int c = 0; c < 9; c++)
                {
                    int num = grid[r, c];

                    if (num == 0)
                    {
                        return false;
                    }

                    grid[r, c] = 0;

                    // Check if the number placement is valid
                    if (!IsSafe(grid, r, c, num))
                    {
                        grid[r, c] = num;
                        return false;
                    }

                    grid[r, c] = num;
                }
            }
            return true;
        }

        // Check if placing num at grid[row, col] is valid
        internal static bool IsSafe(int[,] grid, int row, int col, int num)
        {
            for (int c = 0; c < 9; c++)
            {
                if (grid[row, c] == num)
                {
                    return false;
                }
            }

            for (int r = 0; r < 9; r++)
            {
                if (grid[r, col] == num)
                {
                    return false;
                }
            }

            int startRow = row - row % 3;
            int startCol = col - col % 3;


            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    if (grid[startRow + r, startCol + c] == num)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        // Remove cells to create the puzzle
        private static void RemoveCells(int count)
        {
            while (count > 0)
            {
                int r = rnd.Next(0, 9);
                int c = rnd.Next(0, 9);

                if (puzzle[r, c] != 0)
                {
                    puzzle[r, c] = 0;
                    count--;
                }
            }
        }
    }
}
