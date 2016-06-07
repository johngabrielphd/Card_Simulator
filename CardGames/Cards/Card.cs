using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Cards
{
    public class Card
    {

        private int _rank;
        private int _value;
        private string _suit;
        private string _name;

        public int Rank { get { return _rank; } }
        public int Value { get { return _value; } set { this._value = value; } }
        public string Suit { get { return _suit; } }
        public string Name { get { return _name; } }

        public int Position { get; set; }

        public Card(int rank, int value, string suit, string name)
        {

            this._rank = rank;
            this._value = value;
            this._suit = suit;
            this._name = name;
            Position = rank;

        }
    }
}
