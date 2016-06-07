using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGames.Cards;

namespace CardGames.Games
{
    public abstract class Game
    {

        private static bool _ftShuffle = true;
        private static bool _warInteract = true;
        private static int _bjHands = 1;

        public static int PlayerScore { get; set; }
        public static int CPUScore { get; set; }
        public static int Count { get; set; }

        public static bool FTShuffle { get { return _ftShuffle; } set { _ftShuffle = value; } }
        public static bool WarInteract { get { return _warInteract; } set { _warInteract = value; } }
        public static int BJHands { get { return _bjHands; } set { _bjHands = value; } }

        public static int Eval(Card card1, Card card2)
        {

            if (card1 is Face && card2 is Face)
            {

                if (card1.Name == card2.Name)
                    return 0;
                else if (card1.Name == "King")
                    return 1;
                else if (card1.Name == "Queen" && card2.Name == "Jack")
                    return 1;
                else
                    return 2;
            }

            else
            {

                if (card1.Value > card2.Value)
                    return 1;
                else if (card2.Value > card1.Value)
                    return 2;
                else if (card1 is Face)
                    return 1;
                else if (card2 is Face)
                    return 2;
                else
                    return 0;

            }

        }

        public static Card UpdateCount(Card card)
        {

            if (card.Value < 7)
                Count += 1;
            else if (card.Value < 10)
                Count = Count;
            else
                Count = Count - 1;

            return card;

        }

    }
}
