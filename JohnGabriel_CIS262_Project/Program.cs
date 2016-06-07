using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGames.Cards;
using CardGames.Games;

namespace JohnGabriel_CIS262_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = 0;

            do
            {
                Game.PlayerScore = 0;
                Game.CPUScore = 0;
                Game.Count = 0;
                Game.FTShuffle = true;
                Game.WarInteract = false;
                Game.BJHands = 1;

                input = MainMenu();

                try
                {

                    switch (input)
                    {

                        case 1:
                            HiLo.HiLoGame();
                            break;
                        case 2:
                            War.WarGame();
                            break;
                        case 3:
                            BlackJack.BJGame();
                            break;
                        case 4:
                            FiftyTwo.FiftyTwoGame();
                            break;
                    }

                }
                catch (Exception e)
                {

                    //Console.WriteLine(e);

                    FinalScore();

                }
            } while (input != 5);

        }

        public static void FinalScore()
        {

            Console.WriteLine();
            Console.WriteLine("There are no more cards in the deck.");
            Console.WriteLine();

            if (Game.PlayerScore > Game.CPUScore)
                Console.WriteLine("Final Score:  You win, {0} to {1}!", Game.PlayerScore, Game.CPUScore);
            else if (Game.CPUScore > Game.PlayerScore)
                Console.WriteLine("Final Score:  You lose, {0} to {1}.", Game.PlayerScore, Game.CPUScore);
            else
                Console.WriteLine("Final Score:  You tie, {0} to {1}.", Game.PlayerScore, Game.CPUScore);

        }

        public static int MainMenu()
        {

            ConsoleKeyInfo entry;
            ConsoleKeyInfo secret;
            int intsecret;

            do
            {
                Console.WriteLine();
                Console.WriteLine("Card Simulator:  Main Menu");
                Console.WriteLine("--------------------------");
                Console.WriteLine();
                Console.WriteLine("What would you like to play?");
                Console.WriteLine("1:  Hi-Lo");
                Console.WriteLine("2:  War");
                Console.WriteLine("3:  Blackjack");
                Console.WriteLine("4:  Fifty-two");
                Console.WriteLine("5:  Exit");
                Console.WriteLine();
                entry = Console.ReadKey(true);

                switch (entry.KeyChar.ToString())
                {

                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                        return Convert.ToInt32(entry.KeyChar.ToString());

                    case "f":
                        Console.Write("Fifty-two Options:  Should the deck be shuffled?");
                        secret = Console.ReadKey(true);
                        if (secret.KeyChar.ToString() == "n")
                            Game.FTShuffle = false;
                        Console.WriteLine();
                        break;

                    case "w":
                        Console.Write("War Options:  Should interactivity be turned on?");
                        secret = Console.ReadKey(true);
                        if (secret.KeyChar.ToString() == "n")
                            Game.WarInteract = false;
                        Console.WriteLine();
                        break;

                    case "b":
                        Console.Write("Blackjack Options:  How many hands to you want to play at once?");
                        secret = Console.ReadKey(true);
                        if (Int32.TryParse(secret.KeyChar.ToString(), out intsecret) && intsecret > 0)
                            Game.BJHands = intsecret;
                        Console.WriteLine();
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Invalid input.");
                        break;

                }
            } while (true);

        }

}
}
