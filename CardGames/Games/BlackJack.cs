using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGames.Cards;
using System.Threading;

namespace CardGames.Games
{
    public class BlackJack : Game
    {

        private static int _sleeptime = (1200);
        private static int handcount = 1;

        public static void BJGame()
        {
            PlayerScore = 100;
            CPUScore = 100;
            bool busted;
            bool jacked;
            Deck BJDeck = new Deck();
            BJDeck.Shuffle();

            Console.WriteLine("Welcome to Blackjack!");
            Console.WriteLine("--------------------------");


            do
            {
                busted = true;
                jacked = true;

                List<Hand> PlayerHand = new List<Hand>
                {

                    new Hand()

                };

                PlayerHand.First().Cards.Add(UpdateCount(BJDeck.Deal()));
                PlayerHand.First().Cards.Add(UpdateCount(BJDeck.Deal()));

                
                for (int i = 0; i < BJHands - 1; i++)
                {
                    Hand temp = new Hand();
                    temp.Cards.Add(UpdateCount(BJDeck.Deal()));
                    temp.Cards.Add(UpdateCount(BJDeck.Deal()));
                    PlayerHand.Add(temp);
                }
                

                Hand CPUHand = new Hand();

                CPUHand.Cards.Add(UpdateCount(BJDeck.Deal()));
                CPUHand.Cards.Add(BJDeck.Deal());

                do { } while (!BJSetup(ref PlayerHand, ref CPUHand, ref BJDeck));

                foreach (Hand hand in PlayerHand)
                {

                    if (hand.Total <= 21)
                        busted = false;

                    if (hand.Total != 21 || hand.Cards.Count() > 2)
                        jacked = false;

                }

                if (!jacked)
                    if (!busted)
                        BJDealer(ref CPUHand, ref BJDeck);
                    else
                        UpdateCount(CPUHand.Cards.Last());
                else
                    UpdateCount(CPUHand.Cards.Last());


                Eval(ref PlayerHand, ref CPUHand);

                BJScoring(ref PlayerHand);

            } while (true);

        }

        public static bool BJSetup(ref List<Hand> PlayerHand, ref Hand CPUHand, ref Deck BJDeck)
        {

            bool complete = true;
            Hand split = new Hand();

            Console.WriteLine();
            Console.WriteLine("The dealer shows the {0} of {1}.", CPUHand.Cards.First().Name, CPUHand.Cards.First().Suit);
            Thread.Sleep(_sleeptime);

            Console.WriteLine();
            Console.WriteLine("You have:");

            foreach (Hand hand in PlayerHand)
            {

                Console.WriteLine();

                if (PlayerHand.Count > 1)
                    Console.WriteLine("Hand {0}:", handcount);

                foreach (Card card in hand.Cards)
                {

                    Console.WriteLine("{0} of {1}", card.Name, card.Suit);

                }

                handcount++;
                Thread.Sleep(_sleeptime);

            }

            handcount = 1;

            foreach (Hand hand in PlayerHand)
            {

                if (!hand.Complete && (hand.Total < 21 || hand.AllAces))
                {
                    Console.WriteLine();

                    if (PlayerHand.Count > 1)
                        Console.Write("Hand {0}:  ", handcount);

                    switch (BJMenu())
                    {

                        case 1:     // Hit

                            Card hit = UpdateCount(BJDeck.Deal());
                            Console.WriteLine();
                            Console.WriteLine("You are dealt the {0} of {1}", hit.Name, hit.Suit);
                            hand.Cards.Add(hit);
                            Thread.Sleep(_sleeptime);

                            if (hand.Total > 21 && !hand.AcesSwitched)
                                hand.SwitchAce();

                            if(hand.Total >= 21)
                                hand.Complete = true;

                            break;

                        case 2:     // Double down

                            if (hand.Cards.Count() == 2)
                            {

                                Card ddown = UpdateCount(BJDeck.Deal());
                                Console.WriteLine();
                                Console.WriteLine("You are dealt the {0} of {1}", ddown.Name, ddown.Suit);
                                hand.Cards.Add(ddown);
                                hand.Multiplier += 1;
                                Thread.Sleep(_sleeptime);
                                hand.Complete = true;

                                if (hand.Total > 21)
                                    hand.SwitchAce();

                            }

                            else
                            {

                                Console.WriteLine();
                                Console.WriteLine("You cannot double down.");

                            }

                            break;

                        case 3:     // Split

                            if (hand.Cards.Count() == 2 && hand.Cards.First().Name == hand.Cards.Last().Name)
                            {

                                split.Cards.Add(hand.Cards.Last());
                                split.Cards.Add(UpdateCount(BJDeck.Deal()));

                                hand.Cards.RemoveAt(1);
                                hand.Cards.Add(UpdateCount(BJDeck.Deal()));

                            }

                            else
                            {

                                Console.WriteLine();
                                Console.WriteLine("You cannot split.");

                            }

                            break;

                        case 4:     // Stay

                            hand.Complete = true;
                            break;

                        default:
                            continue;

                    }

                }

                else
                    hand.Complete = true;

                handcount++;

            }

            handcount = 1;

            if (split.Cards.Any())
                PlayerHand.Add(split);

            foreach (Hand hand in PlayerHand)
            { 

                if (!hand.Complete)
                    complete = false;

            }

            return complete;

        }

        public static void BJDealer(ref Hand CPUHand, ref Deck BJDeck)
        {

            Console.WriteLine();
            Console.WriteLine("The dealer's hole card is the {0} of {1}.", CPUHand.Cards.Last().Name, CPUHand.Cards.Last().Suit);
            UpdateCount(CPUHand.Cards.Last());
            Thread.Sleep(_sleeptime);

            if ((CPUHand.Total == 17 && CPUHand.AnyAce) || CPUHand.AllAces)
                CPUHand.SwitchAce();

            while (CPUHand.Total < 17)
            {

                Card hit = UpdateCount(BJDeck.Deal());
                Console.WriteLine();
                Console.WriteLine("The dealer turns over the {0} of {1}", hit.Name, hit.Suit);
                CPUHand.Cards.Add(hit);
                Thread.Sleep(_sleeptime);

                if (CPUHand.Total > 21 && !CPUHand.AcesSwitched)
                    CPUHand.SwitchAce();

            }

        }

        public static void Eval(ref List<Hand> PlayerHand, ref Hand CPUHand)
        {

            List<int> results = new List<int>();

            foreach (Hand hand in PlayerHand)
            {

                Console.WriteLine();

                if (PlayerHand.Count > 1)
                    Console.Write("Hand {0}:  ", handcount);

                if (hand.Total > 21)
                {
                    Console.WriteLine("Bust!  You lose.");
                    hand.Result = 2;
                }
                else if (hand.Total == 21 && hand.Cards.Count() == 2)
                {
                    Console.WriteLine("Blackjack!  You win.");
                    hand.Result = 1;
                }
                else if (CPUHand.Total > 21)
                {
                    Console.WriteLine("Dealer busts!  You win.");
                    hand.Result = 1;
                }
                else if (hand.Total == CPUHand.Total)
                {
                    Console.WriteLine("{0} ties {1}.  Push.", hand.Total, CPUHand.Total);
                    hand.Result = 0;
                }
                else if (hand.Total > CPUHand.Total)
                {
                    Console.WriteLine("{0} beats {1}.  You win!", hand.Total, CPUHand.Total);
                    hand.Result = 1;
                }
                else
                {
                    Console.WriteLine("{0} beats {1}.  You lose.", CPUHand.Total, hand.Total);
                    hand.Result = 2;
                }

                Console.WriteLine("Dealer Hand:  {0}", CPUHand.Contents);
                Console.Write("Your Hand");

                if (PlayerHand.Count > 1)
                    Console.Write(" {0}", handcount);

                Console.WriteLine(":  {0}", hand.Contents);
                Thread.Sleep(_sleeptime);

                handcount++;

            }

            handcount = 1;

        }

        public static void BJScoring(ref List<Hand> PlayerHand)
        {

            foreach(Hand hand in PlayerHand)
            {

                switch (hand.Result)
                {

                    case 0:
                        break;
                    case 1:
                        PlayerScore += (10 * hand.Multiplier);
                        CPUScore = CPUScore - (10 * hand.Multiplier);
                        break;
                    case 2:
                        PlayerScore = PlayerScore - (10 * hand.Multiplier);
                        CPUScore += (10 * hand.Multiplier);
                        break;

                }

            }

        }

        public static int BJMenu()
        {

            ConsoleKeyInfo input;

            do
            {

                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1:  Hit");
                Console.WriteLine("2:  Double down");
                Console.WriteLine("3:  Split");
                Console.WriteLine("4:  Stay");
                Console.WriteLine("5:  See score");
                Console.WriteLine("6:  Refresh");
                input = Console.ReadKey(true);

                switch (input.KeyChar.ToString())
                {

                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "6":
                        return Convert.ToInt32(input.KeyChar.ToString());

                    case "5":
                        Console.WriteLine();
                        Console.WriteLine("Current Score:  You have {0} points.  The dealer has {1} points.", PlayerScore, CPUScore);
                        Console.WriteLine();
                        break;

                    case "c":
                        Console.WriteLine();
                        Console.WriteLine("The count stands at {0}.", Count);
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

