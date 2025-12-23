namespace Suduko_Game
{
    internal class _4x4SudukoGenerator
    {
        static int[,] solution = new int[4, 4];
        static int[,] puzzle = new int[4, 4];
        static Random rnd = new Random();

        internal static int[,] Generate4x4Suduko(int removeCount = 10)
        {
            Array.Clear(solution, 0, solution.Length);
            Array.Clear(puzzle, 0, puzzle.Length);

            FillDiagonal();
            //SolveSuduko(solution);

            for (int r = 0; r < 4; r++)
            {
                for (int c = 0; c < 4; c++)
                {
                    puzzle[r, c] = solution[r, c];
                }
            }

            //RemoveCells(removeCount);

            return puzzle;
        }

        private static void FillDiagonal()
        {
            for (int i = 0; i < 4; i++)
            {
                FillBox(i, i);
            }
        }

        private static void FillBox(int row, int col)
        {
            bool[] used = new bool[5];

            // Fill the 2x2 box
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    int num;
                    do
                    {
                        num = rnd.Next(1, 5);
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
            for (row = 0; row < 4; row++)
                for (col = 0; col < 4; col++)
                    if (grid[row, col] == 0)
                    {
                        return true;
                    }

            row = col = -1;
            return false;
        }

        private static bool Solve4x4Suduko(int[,] grid)
        {
            // Find an empty cell
            if(!FindEmpty(grid, out int row, out int col))
            {
                return true;
            }

            for (int num = 1; num  <= 4; num++)
            {
                if(IsSafe(grid, row, col, num))
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

        internal static bool is4x4Solved(int[,] grid)
        {
            for (int r = 0; r < 4; r++)
            {
                for (int c = 0; c < 4; c++)
                {
                    int num = grid[r, c];

                    if (num == 0)
                    {
                        return false;
                    }

                    grid[r, c] = 0;

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


        //Method to check if 
        internal static bool IsSafe(int[,] grid, int row, int col, int num)
        {
            // Check if the number already exists in the same row
            for (int c = 0; c < 4; c++)
            {
                if (grid[row, c] == num)
                {
                    return false;
                }
            }

            // Check if the number already exists in the same column
            for (int r = 0; r < 4; r++)
            {
                if (grid[r, col] == num)
                {
                    return false;
                }
            }

            // Calculate the starting row and column of the 2×2 sub-grid
            int startRow = row - row % 2;
            int startCol = col - col % 2;

            for (int r = 0; r < 2; r++)
            {
                for (int c = 0; c < 2; c++)
                {
                    if (grid[startRow + r, startCol + c] == num)
                    {
                        return false;
                    }
                }
            }

            return true;
        }


    }
}
