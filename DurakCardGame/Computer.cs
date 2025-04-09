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
        // Constructor for Computer that uses the base class constructor
        // For setting name and icon manually
        public Computer(string name, string icon, List<Card> hand) : base(name, icon, hand)
        {
        }

        // A constructor for Computer that doesn't require name and icon
        // AiCustomization will need to be called from the game class to set those values
        public Computer(List<Card> hand) : base(hand)
        {
        }

        /// <summary>
        /// Finds and returns the best card the Computer can play
        /// </summary>
        /// <param name="cardsCanPlay"></param>
        /// <param name="thisComputerAttacking"></param>
        /// <param name="trump"></param>
        /// <returns></returns>
        public Card ChooseBestCard(List<Card> cardsCanPlay, bool thisComputerAttacking, string trump)
        {
            Card bestCard;
            List<Card> clubs = new List<Card>();
            List<Card> hearts = new List<Card>();
            List<Card> diamond = new List<Card>();
            List<Card> spades = new List<Card> ();

            foreach (Card card in cardsCanPlay) 
            {
                if (card.Suit == "C")
                {
                    clubs.Add(card);
                }
                else if (card.Suit == "H") 
                {
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
                // defend with trump
                else
                {
                    bestCard = cardsCanPlay.OrderBy(card => card.Rank).First();
                }
            }
            return bestCard;
        }

        /// <summary>
        /// Chooses a random name and icon for a Computer player
        /// </summary>
        public int AiCustomization(List<int> usedIndex, List<string> playerNames)
        {
            Random random = new Random();
            string[] icons = ["BitBot", "Chipz", "Cluckles", "Cosmobot", "D.A.V.E", "Drumdrum", "Eggxon", "Geargrim", "Hauntoid", "Jerry", "Nootron", "Phil", "Porkinator", "Seal-E", "Sir Stache", "Waddlebot"];
            const string iconLocation = "../../../GUI_Images/ComputerIcons/";
            const string jpg = ".jpg";
            int listLength = icons.Length;

            int index = random.Next(listLength);

            // Ensures there's no duplicate Ai's or overlap between Ai names and player names
            while (usedIndex.Contains(index) || playerNames.Contains(icons[index]))
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
