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

            // https://github.com/geirnilsskog/cardgame
            // https://github.com/finkmoritz/csbcgf/tree/master/demos/hearthstone

            /*            
            CardForAttack:
            This function takes the AI's hand and a list of playable ranks.
            It filters the hand for cards matching the playable ranks.

            Among the valid cards, it selects the card with the lowest rank and returns its index.
            If no cards are playable, it returns -1.
            */
        
        public static int CardForAttack(List<Card> hand, List<int> playableRanks)
        {
            // Filter the hand to find cards that can beat defending card
            var validCards = hand.Where(card => playableRanks.Contains(card.Rank)).ToList();

            if (validCards.Count == 0)
                return -1; // No playable card, return -1

            // Find the card with the lowest rank
            var selectedCard = validCards.OrderBy(card => card.Rank).First();
            return hand.IndexOf(selectedCard); // Return the index of the selected card
        }

            /*
            CardForDefense:
            This function takes the AI's hand and the attacking card.
            It filters the hand for cards that have the same suit as the 
            attacking card and a higher rank.

            Among the valid cards, it selects the card with the lowest rank that can still 
            beat the attacking card and returns its index.If no suitable card is found, it returns -1.
            */

        public static int CardForDefense(List<Card> hand, Card attackingCard)
        {
            // Filter the hand to find cards that can beat the attacking card
            var validCards = hand.Where(card =>
                card.Suit == attackingCard.Suit && card.Rank > attackingCard.Rank).ToList();

            if (validCards.Count == 0)
                return -1; // No card can defend, return -1

            // Find the card with the lowest rank that can beat the attacking card
            var selectedCard = validCards.OrderBy(card => card.Rank).First();
            return hand.IndexOf(selectedCard); // Return the index of the selected card
        }
    }
}
