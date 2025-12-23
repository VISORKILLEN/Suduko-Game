using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Suduko_Game
{
    internal class PlayGame
    {

        static int[,] board = SudukoGenerator.GenerateSuduko();
        internal static void Run()
        {
            PlaySuduko();
        }

        internal static void PlaySuduko()
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

                SolvedBoard();
                RestartGame();
            }
        }

        private static void RestartGame(bool playing = true)
        {
            Console.Write("Vill du spela igen? y/n: ");

            string answer = Console.ReadLine().ToLower();

            if (answer == "y")
            {
                Console.Clear();
            }
            else if (answer == "n")
            {
                Console.WriteLine("Tack för att du har spelat mitt suduko!");
                playing = false;
            }
            else
            {
                Console.WriteLine("Felaktigt val, skriv igen.");
            }

        }

        private static void SolvedBoard()
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

        private static void PrintBoard()
        {
            for (int r = 0; r < 9; r++)
            {

                if (r % 3 == 0 && r != 0)
                {
                    Console.WriteLine("------+-------+------");
                }

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
