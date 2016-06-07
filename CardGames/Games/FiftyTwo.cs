using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGames.Cards;
using System.Threading;

namespace CardGames.Games
{
    public class FiftyTwo : Game
    {

        public static void FiftyTwoGame()
        {

            Deck FTDeck = new Deck();

            if (FTShuffle)
                FTDeck.Shuffle();

            Console.WriteLine("Welcome to Fifty-two Pickup!");
            Console.WriteLine("--------------------------");
            Console.WriteLine();

            for (int counter = 0; counter < 52; counter++)
            {

                Card temp = FTDeck.Deal();

                if (temp.Position == 1)
                    Console.Write("{0} of {1}", temp.Name, temp.Suit);
                else
                    Console.Write(", {0} of {1}", temp.Name, temp.Suit);

                Thread.Sleep(500);

            }

            Console.WriteLine();

        }

    }
}
