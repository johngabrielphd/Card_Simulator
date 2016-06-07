using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Cards
{
    public class Deck
    {

        private int _placeholder = 1;
        private Card[] _cards = new Card[52];
        
        public Card[] Cards { get { return _cards; } }

        public Deck()
        {
            int counter = 0;
            string[] suits = {"Clubs", "Diamonds", "Hearts", "Spades" };
            string[] faces = {"Jack",  "Queen", "King"};

            for (int outer = 0; outer < 4; outer++)
            {

                for (int inner1 = 0; inner1 < 9; inner1++)
                {

                    this._cards[counter] = new Card(counter + 1, inner1 + 2, suits[outer], (inner1 + 2).ToString());
                    counter++;

                }

                for (int inner2 = 0; inner2 < 3; inner2++)
                {

                    this._cards[counter] = new Face(counter + 1, 10, suits[outer], faces[inner2]);
                    counter++;

                }

                this._cards[counter] = new Ace(counter + 1, 11, suits[outer], "Ace");
                counter++;

            }

        }

        public Card Deal()
        {
            Card joker = new Card(0, 0, "Wild", "Joker");

            if (_placeholder > 52)
                throw new ApplicationException("There are no more cards in the deck.");

            for(int counter = 0; counter < 52; counter++)
            {

                if (this._cards[counter].Position == _placeholder)
                {

                    _placeholder++;
                    return this._cards[counter];

                }

            }

            return joker;

        }

        public void Shuffle()
        {
            int counter = 0;
            Shuffler randomizer = new Shuffler();

            foreach(Leaf leaf in randomizer.Leaves)
            {

                this._cards[counter].Position = leaf.Rank;
                counter++;

            }

        }

    }
}
