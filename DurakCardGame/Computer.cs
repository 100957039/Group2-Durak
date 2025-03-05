using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakCardGame
{
    internal class Computer : Player
    {
        public string Difficulty { get; set; }

        // Constructor for Computer that uses the base class constructor
        public Computer(string name, List<Card> hand, string difficulty) : base(name, hand)
        {
            Difficulty = difficulty;
        }

        public Card Logic(Card oponentCard)
        {

            Card card = null;
            return card;
        }
    }
}
