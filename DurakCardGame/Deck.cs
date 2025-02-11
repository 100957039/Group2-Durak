using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakCardGame
{
    internal class Deck
    {
        private List<Card> cards = new List<Card>();

        public Deck()
        {
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] values = { "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
            int[] ranks = { 6, 7, 8, 9, 10, 11, 12, 13, 14 };

            foreach (string suit in suits)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    //cards.Add(new Card(suit, values[i], ranks[i], $"{values[i]}{suit[0]}.jpg"));
                }
            }
        }

        public void Shuffle()
        {
            Random random = new Random();
            for (int i = 0; i < cards.Count; i++)
            {
                int j = random.Next(i, cards.Count);
                Card temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }

        public Card Draw()
        {
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }

        public int Count()
        {
            return cards.Count;
        }
    }
}
