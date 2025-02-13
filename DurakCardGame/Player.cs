using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakCardGame
{
    internal class Player
    {
        public string Name { get; set; }
        public List<Card> Hand { get; set; } = new List<Card>();
        public bool CanAttacker { get; set; } = false;
        public Player(string name, List<Card> hand) 
        {
            Name = name;
            Hand = hand;
            SortHand();
        }
        public Card PlayCard(int cardIndex)
        {
            Card card = Hand[cardIndex];
            Hand.RemoveAt(cardIndex);
            return card;
        }

        public void DrawCard(Card card)
        {
            Hand.Add(card);
            SortHand();
        }

        // might work on this later
        public void SortHand()
        {
            Hand.Sort((x, y) => x.Rank.CompareTo(y.Rank));
        }


    }
}
