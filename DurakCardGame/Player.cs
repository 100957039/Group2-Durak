using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakCardGame
{
/// <summary>
/// I think this is done. the only change we may need is to remove CanAttack property
/// </summary>
    internal abstract class  Player
    {
        public string Name { get; set; }

        public string IconLocation { get; set; }

        public List<Card> Hand { get; set; } = new List<Card>();
        public bool CanAttack { get; set; } = true;

        public bool DisableHand { get; set; } = true;

        public Player(string name, string icon, List<Card> hand) 
        {
            Name = name;
            IconLocation = icon;
            Hand = hand;
            //SortHand();
        }

        public Player(List<Card> hand)
        {
            Name = "";
            IconLocation = "";
            Hand = hand;
            //SortHand();
        }

        public Card PlayCard(int cardIndex)
        {
            Card card = Hand[cardIndex];
            Hand.RemoveAt(cardIndex);
            return card;
        }

        public Card PlayCard2(Card card)
        {
            //Card card = Hand[cardIndex];
            //Hand.RemoveAt(cardIndex);
            Hand.Remove(card);
            return card;
        }


        public void DrawCard(Card card)
        {
            Hand.Add(card);
            //SortHand();
        }

        // might work on this later
        //public void SortHand()
        //{
        //    Hand.Sort((x, y) => x.Rank.CompareTo(y.Rank));
        //}


    }
}
