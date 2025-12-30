using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suduko_Game
{
    internal class Menu
    {
        internal static void SudukoMenu()
        {
            bool playing = true;

            while (playing)
            {
                Console.Clear();

                Console.WriteLine("Välkommen till spelkonsolen\n" +
                    "Vilket typ av Suduko vill du köra?\n" +
                    "\n1. 4x4 Suduko\n" +
                    "2. 9x9 Suduko\n" +
                    "3. 16x16 Suduko\n" +
                    "0. Stäng av spelkonsolen");

                int choice;
                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        Play4x4Suduko.Run4x4();
                        break;

                    case 2:
                        Print9x9Menu();
                        break;

                    case 3:

                        break;

                    case 0:
                        playing = false;
                        break;

                    default:
                        Console.WriteLine("Felaktig inmating\n" +
                            "Tryck på valfri knapp för att gå tillbaka till menyn.");
                        Console.ReadLine();
                        break;

                }
            }
        }

        internal static void Print9x9Menu()
        {
            bool playing = true;

            while (playing)
            {
                Console.Clear();

                Console.WriteLine("Vilken svårighetsgrad vill du ha på ditt Suduko?\n" +
                    "\n1. Enkelt\n" +
                    "2. Mellan\n" +
                    "3. Svårt\n" +
                    "0. Gå tillbaka till vanliga menyn.");

                int choice;
                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        Easy9x9Suduko.PlayEasySuduko();
                        break;

                    case 2:
                        PlayGame.Run();
                        break;

                    case 3:

                        break;

                    case 0:
                        playing = false;
                        break;

                    default:
                        Console.WriteLine("Felaktig inmating\n" +
                            "Tryck på valfri knapp för att gå tillbaka till menyn.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
