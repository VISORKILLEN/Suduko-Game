using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Suduko_Game
{
    internal class Play4x4Suduko
    {
        static int[,] board = _4x4SudukoGenerator.Generate4x4Suduko();

        internal static void Run4x4()
        {
            Play4x4SudukoGame();
        }

        internal static void Play4x4SudukoGame()
        {
            bool playing = true;

            while (playing)
            {
                Console.Clear();

                bool gameRunning = true;
                while (gameRunning && !_4x4SudukoGenerator.is4x4Solved(board))
                {
                    Console.Clear();
                    PrintBoard();
                    Console.WriteLine("Rad 1-4, 0 för att avluta:");
                    if (!int.TryParse(Console.ReadLine(), out int r) || r < 0 || r > 4)
                    {
                        continue;
                    }

                    if (r == 0)
                    {
                        gameRunning = false;
                        break;
                    }

                    Console.Write("Kolumn (1-4): ");
                    if (!int.TryParse(Console.ReadLine(), out int c) || c < 1 || c > 4)
                    {
                        continue;
                    }

                    Console.Write("Siffra (1-4): ");
                    if (!int.TryParse(Console.ReadLine(), out int num) || num < 1 || num > 4)
                    {
                        continue;
                    }

                    if (_4x4SudukoGenerator.Is4x4Safe(board, r - 1, c - 1, num))
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
            }
        }

        private static void SolvedBoard()
        {
            if (_4x4SudukoGenerator.is4x4Solved(board))
            {
                Console.Clear();
                PrintBoard();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Grattis! Du har löst Sudokut!");
                Console.ResetColor();
                Console.WriteLine("Tryck på valfri knapp för att gå tillbaka till menyn.");
                Console.ReadLine();
            }
        }

        private static void PrintBoard()
        {
            for (int r = 0; r < 4; r++)
            {

                if (r % 2 == 0 && r != 0)
                {
                    Console.WriteLine("----+----");
                }

                for (int c = 0; c < 4; c++)
                {
                    if (c % 2 == 0 && c != 0)
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