namespace Suduko_Game
{
    internal class PlayGame : SudukoBoard
    {

        internal static void Run()
        {
            board = SudukoGenerator.GenerateSuduko(20);
            PlaySuduko();
        }

        // Play 9x9 Suduko game
        internal static void PlaySuduko()
        {
            bool playing = true;

            while (playing)
            {
                Console.Clear();

                // Print initial board
                bool gameRunning = true;
                while (gameRunning && !SudukoGenerator.isSolved(board))
                {
                    // Display board and prompt
                    Console.Clear();
                    PrintBoard();
                    Console.WriteLine("\nRad 1-9, 0 för att avsluta: ");

                    // Get row input
                    if (!int.TryParse(Console.ReadLine(), out int r) || r < 0 || r > 9)
                    {
                        continue;
                    }

                    // Exit game if 0
                    if (r == 0)
                    {
                        gameRunning = false;
                        break;
                    }

                    // Get column and number input
                    Console.Write("Kolumn (1-9): ");
                    if (!int.TryParse(Console.ReadLine(), out int c) || c < 1 || c > 9)
                    {
                        continue;
                    }

                    // Get number input
                    Console.Write("Siffra (1-9): ");
                    if (!int.TryParse(Console.ReadLine(), out int num) || num < 1 || num > 9)
                    {
                        continue;
                    }

                    // Place number if valid
                    if (SudukoGenerator.IsSafe(board, r - 1, c - 1, num))
                    {
                        board[r - 1, c - 1] = num;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Siffra placerad");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ogiltlig placering av nummer");
                        Console.ResetColor();
                    }

                    Console.WriteLine("Tryck på valfri tanget för att fortsätta.");
                    Console.ReadKey();
                }

                // Check if the board is solved
                if (SudukoGenerator.isSolved(board))
                {
                    SolvedBoard();
                    Console.WriteLine("Tryck på valfri tanget för att återgå till menyn.");
                    Console.ReadKey();
                    playing = false;
                }
            }
        }
    }
}
