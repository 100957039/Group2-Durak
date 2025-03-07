using DurakCardGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakCardGame
{
    internal class Game
    {
        public Deck deck = new Deck();
        public List<Player> players = new List<Player>();
        private List<Card> playedCards = new List<Card>();
        private List<Card> played = new List<Card>();
        public String trump;
        public Player defender;
        //list to store the rank that can be played during the attack
        public List<int> allowedRank = new List<int>();
        //private Queue<Player>
        //private List<Card> discard = new List<Card>();
        private int turn = 0;

        public Game() 
        {
            // shuffle the cards before the game starts
            deck.Shuffle();
            // draw a card from the deck to determine the trump
            // trump = deck.Draw().Suit;

        }
        // add rank that can be played during the attack
        public void addRank(int rank)
        {
            allowedRank.Add(rank);
        }

        // reset allowedRank after each attack
        public void resetRank()
        {
            allowedRank.Clear();
        }



        // add a player to the game ########### DONE #############
        public void addPlayer(string name)
        {
            // draw 6 cards from the deck and add them to the player's hand
            List<Card> hand = new List<Card>();
            for (int i = 0; i < 6; i++)
            {
                hand.Add(deck.Draw());
            }
            players.Add(new Human(name, hand));
        }
        
        // Might be deleted ******************
        public Card playCard(int index)
        {
            Card card = players[turn].Hand[index];
            players[turn].Hand.RemoveAt(index);
            return card;
        }

        public void attack(Player player)
        {
            if (playedCards.Count > 0)
            {

            }
        }

        // ############## DONE ##############
        public void startGame()
        {
            // after giving each player 6 cards, draw card to set as trump suit
            Card trumpCard = deck.Draw();
            // set ttrump suit
            trump = trumpCard.Suit;
            if (trumpCard.Suit == "S")
            {
                trump = "Spades";
            }else if (trumpCard.Suit == "H")
            {
                trump = "Hearts";
            }else if (trumpCard.Suit == "C")
            {
                trump = "Clubs";
            }
            else
            {
                trump = "Diamonds";
            }
            // insert trump card back to the deck to be the last card
            deck.AddCard(trumpCard);
        }

        // fill hand with 6 cards | ##### Done ######
        public void fillHand()
        {
            foreach (Player player in players)
            {
                int howManyCards = player.Hand.Count;
                if (howManyCards < 6)
                {
                    for (int i = 0; i < 6 - howManyCards; i++)
                    {
                        // check how many cards are left in the deck to break the inner loop
                        if (deck.Count() < 1)
                        {
                            break; 
                        }
                        player.Hand.Add(deck.Draw());
                    }
                    // check how many cards are left in the deck to break the outter loop
                    if (deck.Count() < 1)
                    {
                        break;
                    }
                }
            }

        }

        public Player playerTurn()
        {
            // might need to change this and remove (-1)
            if (turn < players.Count - 1)
            {
                turn++;
            }
            else
            {
                turn = 0;
            }
            return players[turn];
        }

        public Player GetPlayer(int index)
        {
            return players[index];
        }
    }
}
