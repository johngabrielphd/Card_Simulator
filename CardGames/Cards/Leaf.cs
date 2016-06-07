using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Cards
{
    public class Leaf : IComparable<Leaf>
    {

        public int Rank { get; set; }
        public int Position { get; set; }

        public Leaf(int rank, int position)
        {
  
            this.Rank = rank;
            this.Position = position;

        }

        public int CompareTo(Leaf other)
        {

            if (this.Position < other.Position)
                return -1;

            else if (this.Position == other.Position)
                return 0;

            else
                return 1;

        }

    }
}
