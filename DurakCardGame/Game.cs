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
        private Deck deck = new Deck();
        private List<Player> players = new List<Player>();
        private List<Card> playedCards = new List<Card>();
        private List<Card> played = new List<Card>();
        private String trump;
        //private List<Card> discard = new List<Card>();
        private int turn = 0;

        public Game() 
        {
//          shuffle the cards before the game starts
            deck.Shuffle();
            //          draw a card from the deck to determine the trump
            trump = deck.Draw().Suit;

        }
        //      add a player to the game
        public void addPlayer(string name)
        {
            //     draw 6 cards from the deck and add them to the player's hand
            List<Card> hand = new List<Card>();
            for (int i = 0; i < 6; i++)
            {
                hand.Add(deck.Draw());
            }
            players.Add(new Player(name, hand));
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
    }
}

//for (int i = 0; i < 6; i++)
//{
//    List<Card> hand = new List<Card>();
//    for (int j = 0; j < 6; j++)
//    {
//        hand.Add(deck.Draw());
//    }
//    players.Add(new Player($"Player {i + 1}", hand));
//}