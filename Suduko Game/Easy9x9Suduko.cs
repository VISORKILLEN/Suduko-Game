using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suduko_Game
{
    internal class Easy9x9Suduko : PlayGame
    {
        static int[,] easyBoard = SudukoGenerator.GenerateSuduko(25);
        internal static void Run()
        {
            PlayEasySuduko();
        }


        internal static void PlayEasySuduko()
        {
            bool playing = true;

            while (playing)
            {
                Console.Clear();

                bool gameRunning = true;
                while (gameRunning && !SudukoGenerator.isSolved(easyBoard))
                {
                    Console.Clear();
                    PrintBoard();
                    Console.WriteLine("\nRad 1-9, 0 för att avsluta: ");

                    if (!int.TryParse(Console.ReadLine(), out int r) || r < 0 || r > 9)
                    {
                        continue;
                    }

                    if (r == 0)
                    {
                        gameRunning = false;
                        break;
                    }

                    Console.Write("Kolumn (1-9): ");
                    if (!int.TryParse(Console.ReadLine(), out int c) || c < 1 || c > 9)
                    {
                        continue;
                    }

                    Console.Write("Siffra (1-9): ");
                    if (!int.TryParse(Console.ReadLine(), out int num) || num < 1 || num > 9)
                    {
                        continue;
                    }

                    if (SudukoGenerator.IsSafe(easyBoard, r - 1, c - 1, num))
                    {
                        easyBoard[r - 1, c - 1] = num;
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

                SolvedBoard();
            }
        }

    }
}
