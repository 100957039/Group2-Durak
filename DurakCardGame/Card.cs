using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace DurakCardGame
{
    internal class Card
    {
        public string Suit { get; set; }
        public string Value { get; set; }
        public int Rank { get; set; }
        //public string Image { get; set; }
        public string ImageLocation { get; set; }
        public int Width { get; set; } = 80;
        public int Height { get; set; } = 122;
        public int X { get; set; }
        public int Y { get; set; }

        public Card(string suit, string value, int rank, string imageLocation)
        {
            Suit = suit;
            Value = value;
            Rank = rank;
            ImageLocation = imageLocation;
        }

        /// <summary>
        /// Returns a string of the card suit
        /// </summary>
        /// <returns></returns>
        public string SuitToString()
        {
            const string Heart = "H";
            const string Diamond = "D";
            const string Club = "C";
            const string Spade = "S";
            const string HeartWord = "Hearts";
            const string DiamondWord = "Diamonds";
            const string ClubWord = "Clubs";
            const string SpadeWord = "Spades";

            string cardString = "";

            // Checks for the card suit and add the full word
            switch (Suit)
            {
                case Heart:
                    cardString = HeartWord;
                    break;
                case Diamond:
                    cardString = DiamondWord;
                    break;
                case Club:
                    cardString = ClubWord;
                    break;
                case Spade:
                    cardString = SpadeWord;
                    break;
            }

            return cardString;
        }

        /// <summary>
        /// Returns a string of the card value
        /// </summary>
        /// <returns></returns>
        public string ValueToString()
        {
            const string Jack = "J";
            const string Queen = "Q";
            const string King = "K";
            const string Ace = "A";
            const string JackWord = "Jack";
            const string QueenWord = "Queen";
            const string KingWord = "King";
            const string AceWord = "Ace";

            string cardString = Value;


            // Checks for the card suit and add the full word
            switch (Value)
            {
                case Jack:
                    cardString = JackWord;
                    break;
                case Queen:
                    cardString = QueenWord;
                    break;
                case King:
                    cardString = KingWord;
                    break;
                case Ace:
                    cardString = AceWord;
                    break;
            }

            return cardString;
        }

        /// <summary>
        /// Returns a string of the card suit and value
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string cardString = ValueToString() + " of " + SuitToString();
            return cardString;
        }
    }
}
