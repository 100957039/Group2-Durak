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
        public Computer(string name, List<Card> hand, string difficulty) : base(name, hand)
        {
            Difficulty = difficulty;
        }

        public Card PlayCard(Card opponentCard, int opponentIndex, bool thisComputerAttacking, bool trump)
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

        
    }
}
