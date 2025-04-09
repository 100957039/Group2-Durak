using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakCardGame
{
    internal class Deck
    {
        public List<Card> cards = new List<Card>();

        public Deck()
        {
            string[] suits = { "H", "D", "C", "S" };
            string[] values = { "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            int[] ranks = { 6, 7, 8, 9, 10, 11, 12, 13, 14 };

            // Inserts 1 of each card into the deck
            foreach (string suit in suits)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    cards.Insert(i, new Card(suit, values[i], ranks[i], "../../../GUI_Images/cards/" + values[i] + suit + ".png"));
                }
            }
        }

        /// <summary>
        /// Shuffles the cards in the deck
        /// </summary>
        public void Shuffle()
        {
            Random random = new Random();
            //List<Card> cardList = cards.ToList(); // Convert Stack to List
            for (int i = 0; i < cards.Count; i++)
            {
                int j = random.Next(i, cards.Count);
                Card temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
            //cards = new List<Card>(cardList);
        }

        /// <summary>
        /// Removes and returns the top card from the deck
        /// </summary>
        /// <returns></returns>
        public Card Draw()
        {
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
    }
}
