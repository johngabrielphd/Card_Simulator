using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Cards
{
    public class Shuffler
    {

        private List<Leaf> _leaves = new List<Leaf>();

        public List<Leaf> Leaves { get { return _leaves; } }

        public Shuffler()
        {

            Random rnd = new Random();

            for (int i = 1; i <= 52; i++)
            {

                this._leaves.Add(new Leaf(i, rnd.Next(999999)));
            
            }

           this._leaves.Sort();

        }
 
    }
}
