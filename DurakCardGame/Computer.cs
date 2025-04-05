using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace DurakCardGame
{
    internal class Computer : Player
    {
        public string Difficulty { get; set; }
        public List<IndexCards> IndexCardPlayers {get; set; }

        // Constructor for Computer that uses the base class constructor
        // For setting name and icon manually
        public Computer(string name, string icon, List<Card> hand, string difficulty) : base(name, icon, hand)
        {
            Difficulty = difficulty;
        }

        // A constructor for Computer that doesn't require name and icon
        // AiCustomization will need to be called from the game class to set those values
        public Computer(List<Card> hand, string difficulty) : base(hand)
        {
            Difficulty = difficulty;
        }

        public Card PlayCardHi(Card opponentCard, int opponentIndex, bool thisComputerAttacking, bool trump)
        {
            // opponentHand = [ ace H, 7H, 9S, jack D, 
            // [ ace H, 7H, 9S, j D, q C, 4D, k S, 3H ]

            // [ 2S, k C, 5H, 8D, 3C, ace D, 6S, j H ]

            // [ 10C, q S, 3D, j S, 8H, 4C, 7D, ace C ]

            // [ 9C, q D, 2H, 5C, 4H, 6D, 10S, j C ]

            // [ 7S, k H, 3S, ace S, 9D, j D, 5S, 8C ]


            //COMPUTER
            //[10H, 3C, j S, 6C, ace D, 8S, 4S, q H]

            Card lowestPossibaleCardToPlay = null;
            // continuos attack
            if (thisComputerAttacking)
            {

            }
            // minimum loss during defence
            // defend with the lowest card & attacker does not have this rank to attack again
            else
            {
                for  (int cardIndex = 0; cardIndex < Hand.Count(); cardIndex++)
                {
                    if (trump)
                    {
                        if (opponentCard.Suit == Hand[cardIndex].Suit & opponentCard.Rank < Hand[cardIndex].Rank)
                        {
                            if (lowestPossibaleCardToPlay == null) {
                                lowestPossibaleCardToPlay = Hand[cardIndex];
                            }else if (Hand[cardIndex].Rank < lowestPossibaleCardToPlay.Rank)
                            {
                                lowestPossibaleCardToPlay = Hand[cardIndex];
                            }
                        }
                    }
                    // not trump card
                    else
                    {
                        
                    }
                }
            }

            
            Card card = null;
            return card;
        }

        // opponentHand = [ ace H, 7H, 9S, jack D, 
        // [ ace H, 7H, 9S, j D, q C, 4D, k S, 3H ]

        // [ 2S, k C, 5H, 8D, 3C, ace D, 6S, j H ]

        // [ 10C, q S, 3D, j S, 8H, 4C, 7D, ace C ]

        // [ 9C, q D, 2H, 5C, 4H, 6D, 10S, j C ]

        // [ 7S, k H, 3S, ace S, 9D, j D, 5S, 8C ]
        //COMPUTER
        //[10H, 3C, j S, 6C, ace D, 8S, 4S, q H]
        public Card ChooseBestCard(List<Card> cardsCanPlay, bool thisComputerAttacking, string trump)
        {
            Card bestCard;
            List<Card> clubs = new List<Card>();
            List<Card> hearts = new List<Card>();
            List<Card> diamond = new List<Card>();
            List<Card> spades = new List<Card> ();

            foreach (Card card in cardsCanPlay) {
                if (card.Suit == "C")
                {
                    clubs.Add(card);
                }
                else if (card.Suit == "H") {
                    hearts.Add(card);
                }else if (card.Suit == "D")
                {
                    diamond.Add(card);
                }
                else
                {
                    spades.Add(card);
                }
            }

            // attacking 
            if (thisComputerAttacking)
            {
                // attack with low none trump card
                List<Card> cardsNoTrump = cardsCanPlay.Where(card => card.Suit != trump).ToList();
                if (cardsNoTrump.Count() != 0)
                {
                    bestCard = cardsNoTrump.OrderBy(card => card.Rank).First();
                }
                // play trump card
                else
                {
                    bestCard = cardsCanPlay.OrderBy(card=> card.Rank).First();
                }
                
            }
            // defending 
            else
            {
                // can defend without using trump
                List<Card> cardsNoTrump = cardsCanPlay.Where(card => card.Suit != trump).ToList();
                if (cardsNoTrump.Count() != 0)
                {
                    bestCard = cardsNoTrump.OrderBy(card => card.Rank).First();
                }
                // play trump card
                else
                {
                    bestCard = cardsCanPlay.OrderBy(card => card.Rank).First();
                }

                // defend with trump
            }
            return bestCard;
        }

        /// <summary>
        /// Choose a random name and icon for a Computer player
        /// </summary>
        public int AiCustomization(List<int> usedIndex)
        {
            Random random = new Random();
            string[] icons = ["BitBot", "Chipz", "Cluckles", "Cosmobot", "D.A.V.E", "Drumdrum", "Eggxon", "Geargrim", "Hauntoid", "Jerry", "Nootron", "Phil", "Porktron", "Seal-E", "Reginald", "Waddlebot"];
            const string iconLocation = "../../../GUI_Images/ComputerIcons/";
            const string jpg = ".jpg";
            int listLength = icons.Length;

            int index = random.Next(listLength);

            while (usedIndex.Contains(index))
            {
                index = random.Next(listLength);
            }
            Name = icons[index];
            IconLocation = iconLocation + icons[index] + jpg;

            // Returns the index to ensure the same Ai won't be used again in a single game
            return index;
        }
    }
}
