using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace DurakCardGame
{
    internal class Human : Player
    {
        public Human(string name, string icon, List<Card> hand) : base(name, icon, hand)
        {
        }

        /// <summary>
        /// Sorts the players cards by Suit and value, putting trump cards last
        /// </summary>
        /// <param name="trump"></param>
        public void SortHand(string trump)
        {
            // A little convoluted but it works :P
            const string heart = "H";
            const string diamond = "D";
            const string club = "C";
            const string spade = "S";
            List<Card> hearts = new List<Card>();
            List<Card> diamonds = new List<Card>();
            List<Card> clubs = new List<Card>();
            List<Card> spades = new List<Card>();
            List<Card> trumpSuit = new List<Card>();

            // Divide up the cards into each suit
            foreach(Card card in Hand)
            {
                switch (card.Suit)
                {
                    case heart:
                        hearts.Add(card);
                        break;
                    case diamond:
                        diamonds.Add(card);
                        break;
                    case club:
                        clubs.Add(card);
                        break;
                    case spade:
                        spades.Add(card);
                        break;
                }
            }

            // Sets the trump suit list to the correct suit
            switch (trump)
            {
                case heart:
                    trumpSuit = hearts;
                    break;
                case diamond:
                    trumpSuit = diamonds;
                    break;
                case club:
                    trumpSuit = clubs;
                    break;
                case spade:
                    trumpSuit = spades;
                    break;
            }

            // Sorts all the cards by rank
            hearts.Sort((x, y) => x.Rank.CompareTo(y.Rank));
            diamonds.Sort((x, y) => x.Rank.CompareTo(y.Rank));
            clubs.Sort((x, y) => x.Rank.CompareTo(y.Rank));
            spades.Sort((x, y) => x.Rank.CompareTo(y.Rank));

            // Replaces the sorted cards in the players hand, adding trump suit last
            Hand.Clear();

            if (!heart.Equals(trump)) 
            {
                Hand.AddRange(hearts);
            }
            if (!diamond.Equals(trump))
            {
                Hand.AddRange(diamonds);
            }
            if (!club.Equals(trump))
            {
                Hand.AddRange(clubs);
            }
            if (!spade.Equals(trump))
            {
                Hand.AddRange(spades);
            }

            Hand.AddRange(trumpSuit);
        }

    }
}
