using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGames.Cards;
using System.Threading;

namespace CardGames.Games
{
    public class War : Game
    {

        public static void WarGame()
        {

            int sleeptime = 1000;
            List<Card> WarList = new List<Card>();
            Deck WarDeck = new Deck();
            WarDeck.Shuffle();

            Console.WriteLine("Welcome to War!");
            Console.WriteLine("--------------------------");

            do
            {

                Card PlayerCard = WarDeck.Deal();
                Card CPUCard = WarDeck.Deal();
                WarList.Add(PlayerCard);
                WarList.Add(CPUCard);

                Console.WriteLine();
                Console.WriteLine("Your opponent turns over the {0} of {1}.", CPUCard.Name, CPUCard.Suit);
                Thread.Sleep(sleeptime);

                if (WarInteract)
                    WarMenu();

                Console.WriteLine();
                Console.WriteLine("You turn over the {0} of {1}.", PlayerCard.Name, PlayerCard.Suit);
                Thread.Sleep(sleeptime);

                switch (Eval(PlayerCard, CPUCard))
                {

                    case 1:
                        Console.WriteLine();
                        Console.WriteLine("The {0} of {1} beats the {2} of {3}.  You win!", PlayerCard.Name, PlayerCard.Suit, CPUCard.Name, CPUCard.Suit);
                        PlayerScore += WarList.Count;
                        WarList.Clear();
                        Thread.Sleep(sleeptime);
                        break;
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("The {0} of {1} beats the {2} of {3}.  You lose.", CPUCard.Name, CPUCard.Suit, PlayerCard.Name, PlayerCard.Suit);
                        CPUScore += WarList.Count;
                        WarList.Clear();
                        Thread.Sleep(sleeptime);
                        break;
                    case 0:
                        Console.WriteLine();
                        Console.WriteLine("WAR!");
                        Console.WriteLine("--------------------------");
                        Console.WriteLine();
                        Console.WriteLine("You and your opponent each place 3 cards face down.");
                        WarWar(ref WarDeck, ref WarList);
                        break;

                }

                Thread.Sleep(sleeptime);

            } while (true);
        }

        public static void WarWar(ref Deck WarDeck, ref List<Card> WarList)
        {

           for (int counter = 0; counter < 6; counter++)
            {

                WarList.Add(WarDeck.Deal());

            }

        }

        public static void WarMenu()
        {

            ConsoleKeyInfo input;

            do
            {

                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1:  Reveal next card");
                Console.WriteLine("2:  See score");
                input = Console.ReadKey(true);

                switch (input.KeyChar.ToString())
                {

                    case "1":
                        break;
                    case "2":
                        Console.WriteLine();
                        Console.WriteLine("Current Score:  You have won {0} cards.  Your opponent has won {1} cards.", PlayerScore, CPUScore);
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Invalid input.");
                        break;

                }

            } while (input.KeyChar.ToString() != "1");

        }

    }
}
