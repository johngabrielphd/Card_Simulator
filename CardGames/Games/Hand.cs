using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGames.Cards;

namespace CardGames.Games
{
    public class Hand
    {

        private int _multiplier = 1;
        private bool _complete = false;
        private List<Card> _cards = new List<Card>();

        public List<Card> Cards { get { return _cards; } }
        public int Multiplier { get { return _multiplier; } set { _multiplier = value; } }
        public bool Complete { get { return _complete; } set { _complete = value; } }
        public int Result { get; set; }

        public int Total
        {

            get
            {

                int total = 0;

                foreach (Card card in _cards)
                {

                    total += card.Value;

                }

                return total;

            }

        }

        public bool AnyAce
        {

            get
            {

                bool anyace = false;

                foreach (Card card in this._cards)
                {

                    if (card is Ace)
                        anyace = true;

                }

                return anyace;

            }

        }

        public bool AllAces
        {
            get
            {
                bool allaces = true;

                foreach (Card card in this._cards)
                {

                    if (!(card is Ace))
                        allaces = false;

                }

                return allaces;

             }

        }

        public bool AcesSwitched
        {

            get
            {
                bool acesswitched = true;

                foreach (Card card in this._cards)
                {

                    if (card is Ace && card.Value != 1)
                        acesswitched = false;

                }

                return acesswitched;

            }

        }

        public string Contents
        {

            get
            {

                string contents = "";

                foreach (Card card in this._cards)
                {

                    if (contents == "")
                        contents = String.Concat(contents, String.Format("{0} of {1}", card.Name, card.Suit));
                    else
                        contents = String.Concat(contents, String.Format(", {0} of {1}", card.Name, card.Suit));

                }

                return contents;
            }

        }

        public void SwitchAce()
        {

            foreach (Card card in this._cards)
            {

                if (card is Ace && card.Value != 1)
                {

                    card.Value = 1;
                    break;
                }

            }

        }

    }
}
