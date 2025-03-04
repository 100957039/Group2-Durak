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
        private String trump;
        public Player defender;
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
        // add a player to the game
        public void addPlayer(string name)
        {
            // draw 6 cards from the deck and add them to the player's hand
            List<Card> hand = new List<Card>();
            for (int i = 0; i < 6; i++)
            {
                hand.Add(deck.Draw());
            }
            players.Add(new Player(name, hand));
        }
        
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

        public void startGame()
        {
            // draw a card from the deck to determine the trump
            //foreach (Player player in players)
            //{                 
                //for (int i = 0; i < 6; i++)
                //{
                //    //player.Hand.Add(deck.Draw());
                //}
                
            //}
            //trump = deck.Draw().Suit;
        }
        // fill hand with 6 cards
        public void fillHand()
        {
            foreach (Player player in players)
            {
                int howManyCards = player.Hand.Count;
                if (howManyCards < 6)
                {
                    for (int i = 0; i < 6 - howManyCards; i++)
                    {
                        player.Hand.Add(deck.Draw());
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
