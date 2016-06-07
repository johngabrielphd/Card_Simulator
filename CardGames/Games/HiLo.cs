using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGames.Cards;
using System.Threading;

namespace CardGames.Games
{
    public class HiLo : Game
    {

        public static void HiLoGame()
        {

            int sleeptime = 1000;
            Deck HiLoDeck = new Deck();
            HiLoDeck.Shuffle();

            Console.WriteLine("Welcome to Hi-Lo!");
            Console.WriteLine("--------------------------");

            do
            {

                Card Card1 = UpdateCount(HiLoDeck.Deal());
                Card Card2 = HiLoDeck.Deal();

                Console.WriteLine();
                Console.WriteLine("The dealer turns over the {0} of {1}.", Card1.Name, Card1.Suit);
                Thread.Sleep(sleeptime);

                if (HiLoMenu() != Eval(Card1, UpdateCount(Card2)) && Eval(Card1, Card2) != 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("The next card is the {0} of {1}", Card2.Name, Card2.Suit);
                    Thread.Sleep(sleeptime);
                    Console.WriteLine();
                    Console.WriteLine("Good guess.  You win!");
                    PlayerScore++;

                }

                else
                {

                    Console.WriteLine();
                    Console.WriteLine("The next card is the {0} of {1}", Card2.Name, Card2.Suit);
                    Thread.Sleep(sleeptime);
                    Console.WriteLine();
                    Console.WriteLine("Too bad.  You lose.");
                    CPUScore++;

                }

            } while (true);

        }

        public static int HiLoMenu()
        {

            ConsoleKeyInfo input;

            do
            {

                Console.WriteLine();
                Console.WriteLine("What will the next card be?");
                Console.WriteLine("1:  Higher");
                Console.WriteLine("2:  Lower");
                Console.WriteLine("3:  See score");

                input = Console.ReadKey(true);

                switch (input.KeyChar.ToString())
                {

                    case "1":
                    case "2":
                        return Convert.ToInt32(input.KeyChar.ToString());

                    case "3":
                        Console.WriteLine();
                        Console.WriteLine("Current Score:  You have guessed right {0} times.  You have guessed wrong {1} times.", PlayerScore, CPUScore);
                        break;

                    case "c":
                        Console.WriteLine();
                        Console.WriteLine("The count stands at {0}.", Count);
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
