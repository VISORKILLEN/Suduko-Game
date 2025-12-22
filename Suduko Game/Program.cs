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
                    "Vilken svårihetsgrad vill du köra?\n" +
                    "1. Enkel\n" +
                    "2. Vanlig\n" +
                    "3. Svår\n" +
                    "0. Stäng av spelkonsolen");

                int choice;
                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
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
