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
            SolveSuduko(solution);

            for (int r = 0; r < 4; r++)
            {
                for( int c = 0; c < 4; c++)
                {
                    puzzle[r, c] = solution[r, c];
                }
            }

            RemoveCells(removeCount);

            return puzzle;
        }



    }
}
