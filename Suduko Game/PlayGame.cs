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

        // Medium 9x9 Suduko board
        static int[,] mediumBoard = SudukoGenerator.GenerateSuduko(40);
        internal static void Run()
        {
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
                while (gameRunning && !SudukoGenerator.isSolved(mediumBoard))
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
                    if (SudukoGenerator.IsSafe(mediumBoard, r - 1, c - 1, num))
                    {
                        mediumBoard[r - 1, c - 1] = num;
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
                if (SudukoGenerator.isSolved(mediumBoard))
                {
                    SolvedBoard();
                    Console.WriteLine("Tryck på valfri tanget för att återgå till menyn.");
                    Console.ReadKey();
                    playing = false;
                }
            }
        }

        // Display solved message
        internal static void SolvedBoard()
        {
            if (SudukoGenerator.isSolved(mediumBoard))
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
                    int val = mediumBoard[r, c];
                    Console.Write(val == 0 ? ". " : val + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
