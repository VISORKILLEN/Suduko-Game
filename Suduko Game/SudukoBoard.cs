namespace Suduko_Game
{
    internal class SudukoBoard
    {
        // Shared board for all Suduko games
        protected static int[,] board;

        // Display solved message
        internal static void SolvedBoard()
        {
            if (SudukoGenerator.isSolved(board))
            {
                Console.Clear();
                PrintBoard();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Grattis! Du har löst Sudokut!");
                Console.ResetColor();
            }
        }

        // Print the current state of the board
        internal static void PrintBoard()
        {
            // Print the 9x9 Suduko board
            for (int r = 0; r < 9; r++)
            {

                // Print horizontal separator
                if (r % 3 == 0 && r != 0)
                {
                    Console.WriteLine("------+-------+------");
                }

                // Print each row
                for (int c = 0; c < 9; c++)
                {
                    if (c % 3 == 0 && c != 0)
                    {
                        Console.Write("| ");
                    }
                    int val = board[r, c];
                    Console.Write(val == 0 ? ". " : val + " ");
                }
                Console.WriteLine();
            }
        }

    }
}
