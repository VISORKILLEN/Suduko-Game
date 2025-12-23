namespace Suduko_Game
{
    internal class Program
    {
        static void Main(string[] args)
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
                        Play4x4Suduko.Run();
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
