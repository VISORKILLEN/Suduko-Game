namespace Suduko_Game
{
    internal class Easy9x9Suduko : SudukoBoard
    {
        internal static void RunEasy()
        {
            board = SudukoGenerator.GenerateSuduko(20);
            PlayEasySuduko();
        }

        // Play easy 9x9 Suduko game
        internal static void PlayEasySuduko()
        {
            bool playing = true;

            while (playing)
            {
                Console.Clear();

                bool gameRunning = true;
                while (gameRunning && !SudukoGenerator.isSolved(board))
                {
                    Console.Clear();
                    PrintBoard();
                    Console.WriteLine("\nRad 1-9, 0 för att avsluta: ");

                    // Get user input for row, column and number
                    if (!int.TryParse(Console.ReadLine(), out int r) || r < 0 || r > 9)
                    {
                        continue;
                    }

                    if (r == 0)
                    {
                        gameRunning = false;
                        break;
                    }

                    // Get user input for column
                    Console.Write("Kolumn (1-9): ");
                    if (!int.TryParse(Console.ReadLine(), out int c) || c < 1 || c > 9)
                    {
                        continue;
                    }

                    // Get user input for number
                    Console.Write("Siffra (1-9): ");
                    if (!int.TryParse(Console.ReadLine(), out int num) || num < 1 || num > 9)
                    {
                        continue;
                    }

                    // Check if the number can be placed in the specified position
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

                // Controlle if board is solved
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

