using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakCardGame
{

    internal abstract class  Player
    {
        public string Name { get; set; }

        public string IconLocation { get; set; }

        public List<Card> Hand { get; set; } = new List<Card>();
        public bool CanAttack { get; set; } = true;

        public Player(string name, string icon, List<Card> hand) 
        {
            Name = name;
            IconLocation = icon;
            Hand = hand;
        }

        public Player(List<Card> hand)
        {
            Name = "";
            IconLocation = "";
            Hand = hand;
        }

        /// <summary>
        /// Removes a card from player hand
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public Card PlayCard(Card card)
        {
            Hand.Remove(card);
            return card;
        }
    }
}
