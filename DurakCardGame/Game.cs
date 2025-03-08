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
        // test 1 detemine order of attakers starts here
        public Queue<Player> AttackerQueue = new Queue<Player>();
        // test 1 detemine order of attakers ends here 
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

        // test 1 starts here
        // choose first attacker base on their hand, who has the lowest trump card
        public String chooseFirstAttacker()
        {
            // 15 is a random number just to compare with, it could be a 100 or 1000
            int lowestTrumpCard = 15;
            // store index of the player who has the lowest trump card
            int playerIndex = -1;
            for (int i = 0; i <players.Count(); i++) { 
                foreach (Card card in players[i].Hand)
                {
                    //Console.WriteLine(card.Suit);
                    if (card.Suit == trump[0].ToString())
                    {
                        //Console.WriteLine(card.Value + " " + card.Suit, card.Rank < lowestTrumpCard);
                        if (card.Rank < lowestTrumpCard)
                        {
                            //Console.WriteLine(card.Rank);
                            lowestTrumpCard = card.Rank;
                            playerIndex = i;
                        }
                    }
                }
            }
            // if no player has a trump card, the first one to attack will be the first player inserted 
            if (playerIndex == -1)
            {
                playerIndex = 0;
            }

            // add player to the queue 
            // player.Count() - playerIndex => take only the player that are after this index 
            for (int i = 0; i < players.Count() - playerIndex; i++)
            {
                // take only the players at and after this index
                AttackerQueue.Enqueue(players[i + playerIndex]);
            }
            // add rest of the player before that index to the queue
            int playersLeft = players.Count() - AttackerQueue.Count();
            Console.WriteLine(playersLeft +" " + players.Count() + " " + AttackerQueue.Count());
            for (int i = 0; i < playersLeft; i++) 
            {
                AttackerQueue.Enqueue(players[i]);
            }
            String names = "";
            foreach (Player player in AttackerQueue)
            {
                names += player.Name + " ";
            }
            return names;
        }
        // test one ends here

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
                trump = "Spades " + trumpCard.Rank.ToString();
            }else if (trumpCard.Suit == "H")
            {
                trump = "Hearts " + trumpCard.Rank.ToString();
            }else if (trumpCard.Suit == "C")
            {
                trump = "Clubs " + trumpCard.Rank.ToString();
            }
            else
            {
                trump = "Diamonds " + trumpCard.Rank.ToString();
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
