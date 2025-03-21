using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// how it works 
// 1- add player => will automatically get 6 cards
// 2- after adding player RUN (determinTrumpCard()) to determin the TRUMP card and place it at the bottom of the deck
// 3- after determining the TRUMP card, RUN (chooseFirstAttacker()) whoever has the lowest trump card
// 4- RUN (GameEnded()) if TRUE, game ends, if not => step 5
// 5- check if list variable |cardsAttack| is empty => can attack else RUN (canStillAttack())


// IMPORTANT NOTES
// 1- after each attack, DO NOT FORGET To chnage the DEFENDER index to the next defender

namespace DurakCardGame
{
    internal class GameLogic
    {
        public Deck deck = new Deck();
        public List<Player> players = new List<Player>();
        // all the played cards will be stored here for AI 
        // if defender loses, transfer cards to the loser, then clear after each trun (do not forget to transfer to AI)
        public List<Card> cardPlayedDuringGame = new List<Card>();
        //temprary store cards to campare the atack and defence
        // store the cards used in single attack
        public List<Card> cardsAttack = new List<Card>();
        // store cards used in signle attack
        public List<Card> cardsDefend = new List<Card>();

        // this will always be the attacker 
        public int defenderIndex { get; set; } = 0;
        // determine the index of the current player (might be attacker or defender)
        public int turnIndex { get; set; } = 0;

        //difference between players index to go back and forth between the attacker and defender 
        //usefull if there are other players who can join the attack, otherwise useless
        public int distanceIndexDiffernceBetweenAttackerDefender { get; set; } = 1;

        // during one attack, who else can attack too
        public List<Player> CanAlsoAttack = new List<Player>();

        public String trump;

        private String Separator = "|";


        //######################### GUI variable #############################
        // DO NOT FORGET TO RESET ALL THE VALUES AFTER THE ATTACK IS OVER
        public int AttackerXAxis { get; set; } = 0;
        public int DefenderXAxis { get; set; } = 0;
        // DO NOT FORGET TO RESET ALL THE VALUES AFTER THE ATTACK IS OVER

        public GameLogic()
        {
            // shuffle the cards before the game starts
            deck.Shuffle();
            // draw a card from the deck to determine the trump
            // trump = deck.Draw().Suit;
        }



        //check if the player can still attack
        public bool canStillAttack(List<Card> hand)
        {
            bool canAttack = false;
            foreach (Card card in hand)
            {
                if (cardsAttack.Any(attackCard => attackCard.Rank == card.Rank))
                {
                    return canAttack = true;
                }
                if (cardsDefend.Any(attackCard => attackCard.Rank == card.Rank))
                {
                    return canAttack = true;
                }
            }
            return canAttack;
        }

        // check if the player has the proper suit to defend
        public bool canStillDefend(List<Card> hand, Card attackedBy)
        {
            bool canDefend = false;
            foreach (Card card in hand)
            {
                // if the attackedBy is a trump card
                if (attackedBy.Suit.Equals(trump) && card.Suit.Equals(trump))
                {
                    if (attackedBy.Rank < card.Rank)
                    {
                        canDefend = true;
                        break;
                    }
                }
                // if the attackedBy is not trump card
                else
                {
                    //if the defender has higher rank than the played card from the same suit
                    if (attackedBy.Suit.Equals(card.Suit) && attackedBy.Rank < card.Rank)
                    {
                        canDefend = true;
                        break;
                        // if the attacker did not play a trump card, and defender can use trump to defend
                    }
                    else if (card.Suit == trump)
                    {
                        canDefend = true;
                        break;
                    }
                }
            }
            return canDefend;
        }

        //compare attackers card with defender's
        public bool defendAttack(Card attackerCard, Card defenderCard)
        {
            //attacker's card is trump
            if (attackerCard.Suit.Equals(trump))
            {
                //defenders card is trump
                if (defenderCard.Suit.Equals(trump))
                {
                    //Console.WriteLine("attacker card 1: " + attackerCard.Suit + " " + attackerCard.Rank + " | " + defenderCard.Suit + " " + defenderCard.Rank);
                    return defenderCard.Rank > attackerCard.Rank;
                }
                //defender's card is not trump
                else
                {
                    //Console.WriteLine("attacker card 2: " + attackerCard.Suit + " " + attackerCard.Rank + " | " + defenderCard.Suit + " " + defenderCard.Rank);
                    return false;
                }
            }
            // attacker's card not trump
            else
            {
                // if defender plays trump vs attacker not trump
                if (defenderCard.Suit.Equals(trump))
                {
                    //Console.WriteLine("attacker card 3: " + attackerCard.Suit + " " + attackerCard.Rank + " | " + defenderCard.Suit + " " + defenderCard.Rank);
                    return true;
                }
                // if defender and attacker do not play a trump card
                else
                {
                    //Console.WriteLine("suit: " + defenderCard.Suit);
                    //Console.WriteLine("tump suit fom game: " + trump);
                    //Console.WriteLine("attacker card 4: " + attackerCard.Suit + " " + attackerCard.Rank + " | " + defenderCard.Suit + " " + defenderCard.Rank);
                    return defenderCard.Rank > attackerCard.Rank && defenderCard.Suit.Equals(attackerCard.Suit);
                }
            }

        }


        // test 1 starts here
        // choose first attacker base on their hand, who has the lowest trump card
        // only used when the game start, it probably needs to be (private) and executed in startGame()
        public String chooseFirstAttacker()
        {
            // 15 is a random number just to compare with, it could be a 100 or 1000
            int lowestTrumpCard = 15;
            // store index of the player who has the lowest trump card
            int playerIndex = -1;
            for (int i = 0; i < players.Count(); i++)
            {
                foreach (Card card in players[i].Hand)
                {
                    //Console.WriteLine(card.Suit);
                    // check if the card is trump suit
                    if (card.Suit == trump[0].ToString())
                    {
                        //Console.WriteLine(card.Value + " " + card.Suit, card.Rank < lowestTrumpCard);
                        // check if it is lower than the assigned value
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
            turnIndex = playerIndex;
            //determin the defender (((((((attacker will not work))))))))))
            int calculateDefenderIndex = playerIndex + 1;
            // if attacker is the last player in the list
            if (players.Count() <= calculateDefenderIndex) {
                // the defender will be the first player in the list
                defenderIndex = 0;
            }
            else
            {
                defenderIndex = calculateDefenderIndex;
            }
            

            // add player to the queue 
            ////player.Count() - playerIndex => take only the player that are after this index
            //for (int i = 0; i < players.Count() - playerIndex; i++)
            //{
            //    // take only the players at and after this index
            //    AttackerQueue.Add(players[i + playerIndex]);
            //    Console.WriteLine("add to queue: " + players[i + playerIndex].Name);
            //}
            // add rest of the player before that index to the queue
            //int playersLeft = players.Count() - AttackerQueue.Count();
            //Console.WriteLine(playersLeft + " " + players.Count() + " " + AttackerQueue.Count());
            //for (int i = 0; i < playersLeft; i++)
            //{
            //    AttackerQueue.Add(players[i]);
            //}
            //Console.WriteLine("game.cs : "+AttackerQueue.ToArray());
            String names = players[turnIndex].Name;
            //foreach (Player player in AttackerQueue)
            //{
            //    names += player.Name + " | ";
                //Console.WriteLine("game.cs : " + player.Name);
                //Console.WriteLine(AttackerQueue.ToArray());
            //}
            return "Attack Order: " + names;
        }
        // test one ends here


        // fill hand with 6 cards | ##### Done ######
        public void fillHand()
        {

            foreach (Player player in players)
            {

                int howManyCards = player.Hand.Count;
                //Console.WriteLine("before loop: " + player.Name + " " + howManyCards.ToString());
                if (howManyCards < 6)
                {
                    //Console.WriteLine()
                    for (int i = 0; i < (6 - howManyCards); i++)
                    {
                        //Console.WriteLine("before loop: " + (6 - howManyCards).ToString());
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

        // add a computer to the game ########### DONE #############
        public void addComputer(string name, String difficulty)
        {
            // draw 6 cards from the deck and add them to the player's hand
            List<Card> hand = new List<Card>();
            for (int i = 0; i < 6; i++)
            {
                hand.Add(deck.Draw());
            }
            players.Add(new Computer(name, hand, difficulty));
        }


        // run this after adding players and computers 
        // ############## DONE ##############
        public void determinTrumpCard()
        {
            // after giving each player 6 cards, draw card to set as trump suit
            Card trumpCard = deck.Draw();
            // set ttrump suit
            trump = trumpCard.Suit;
            ////////////################################ might use lines below ####################
            //if (trumpCard.Suit == "S")
            //{
            //    trump = "Spades " + trumpCard.Rank.ToString();
            //}else if (trumpCard.Suit == "H")
            //{
            //    trump = "Hearts " + trumpCard.Rank.ToString();
            //}else if (trumpCard.Suit == "C")
            //{
            //    trump = "Clubs " + trumpCard.Rank.ToString();
            //}
            //else
            //{
            //    trump = "Diamonds " + trumpCard.Rank.ToString();
            //}
            // insert trump card back to the deck to be the last card
            ////////////################################ might use lines below ####################
            deck.AddCard(trumpCard);
        }


        // run this after each turn to check if the game has ended or not
        // test start attack March 15th
        public bool GameEnded()
        {
            int playersLeft = 0;
            foreach (Player player in players)
            {
                if (player.Hand.Count() > 0)
                {
                    playersLeft++;
                }
            }
            // only one left = lost
            int numberToStopGame = 1;

            return playersLeft == numberToStopGame;
        }


        // example [player_1, player_2, player_3, current_player_attacker] => defender_index (3 + 3) out of rnage
        // example [current_player_defender, player_2, player_3, player_4] => attacker_index (0 - 3) out of range
        public int CalculateNextPlayerIndex(int currentIndex, int differenceDistanceBetweenNextPlayer, bool currentPlayerDefender)
        {
            //Console.WriteLine(" ");
            //Console.WriteLine("currentIndex: " + currentIndex + " distance: " + differenceDistanceBetweenNextPlayer + "  players.Count() " + players.Count() + " isCurrentPlayerDefender: " + currentPlayerDefender);
            if (currentPlayerDefender)
            {
                int nextAttackerIndex = currentIndex - differenceDistanceBetweenNextPlayer;
                if (nextAttackerIndex < 0)
                {
                    nextAttackerIndex =  players.Count() - Math.Abs(nextAttackerIndex);
                }
                //Console.WriteLine("GameLogic.cs| nextAttackerIndex: " + nextAttackerIndex);
                //return nextAttackerIndex;
                // new code starts here ############################### TEST ################################
                // if Hand.Count() == 0 => means player won
                if (players[nextAttackerIndex].Hand.Count() == 0)
                {
                    for (int nextAvailablePlayerIndex=0 ; nextAvailablePlayerIndex < players.Count(); nextAvailablePlayerIndex++) 
                    {
                        if (players[nextAvailablePlayerIndex].Hand.Count() > 0)
                        {
                            return nextAvailablePlayerIndex;
                        }
                    }
                }
                return nextAttackerIndex;
                // new code ends here ############################### TEST ################################

            }
            else
            {
                int nextDefenderIndex = currentIndex + differenceDistanceBetweenNextPlayer;
                // error here
                //Console.WriteLine("nextDefenderIndex: "+ nextDefenderIndex + " | currentIndex: "+ currentIndex + " | differenceDistanceBetweenNextPlayer: " + differenceDistanceBetweenNextPlayer);
                if (nextDefenderIndex >= players.Count())
                {
                    nextDefenderIndex -= players.Count();
                }
                //Console.WriteLine("GameLogic.cs| nextDefenderIndex: " + nextDefenderIndex);
                //return nextDefenderIndex;
                // new code starts here ############################### TEST ################################
                // if Hand.Count() == 0 => means player won
                if (players[nextDefenderIndex].Hand.Count() == 0)
                {
                    for (int nextAvailablePlayerIndex = 0; nextAvailablePlayerIndex < players.Count(); nextAvailablePlayerIndex++)
                    {
                        if (players[nextAvailablePlayerIndex].Hand.Count() > 0)
                        {
                            return nextAvailablePlayerIndex;
                        }
                    }
                }
                return nextDefenderIndex;
                // new code ends here ############################### TEST ################################
            }

        }

        //  ############################### TEST starts here ################################
        // new function to keep track of attacker and defender
        public void DetermineDefenderAndAttackerIndex(bool won)
        {
            int nextDefenderIndex;
            int nextAttackerIndex; // ====== turnIndex
            // if defender 
            if (defenderIndex == turnIndex)
            {
                // if defender won the attack
                // attacker = 0 | defender = 1 | => nextAttacker = 1 | next defender = 2
                // defender 1 + X = 2 => x = 1
                if (won)
                {
                    // implement code to allow other players to attack if the attacker no longer has the right cards


                    // implement code to allow other players to attack if the attacker no longer has the right cards
                    nextDefenderIndex = turnIndex + 1; //x
                }
                
                // if defender lost the attack
                // attacker = 0 | defender = 1 | => nextAttacker = 2 | next defender = 3
                // defender 1 + X = 3 => x = 2
                else
                {
                    nextDefenderIndex = turnIndex + 2; //x
                }
            }
            // if attacker
            else
            {
                // if attacker won 
                // attacker = 0 | defender = 1 | => nextAttacker = 2 | next defender = 3
                // attacker 0 + X = 3 => x = 3
                if (won)
                {
                    nextDefenderIndex = turnIndex + 3; //x
                }
                // if aatcker loses
                // attacker = 0 | defender = 1 | => nextAttacker = 1 | next defender = 2
                // attacker 0 + X = 2 => x = 2 
                else
                {
                    // implement code to allow other players to attack if the attacker no longer has the right cards


                    // implement code to allow other players to attack if the attacker no longer has the right cards
                    nextDefenderIndex = turnIndex + 2; //x;
                }
            }

            // get valid index not out of range
            // players [000, 111, 222, 333]
            // nextDefenderIndex 5  === 000
            // nextDefenderIndex 5 % len(players) 4 = 1 => 1 == 111
            // 1 - x = 0 | => x = 1 
            if (nextDefenderIndex >= players.Count()) {
                nextDefenderIndex = (nextDefenderIndex % players.Count()) - 1; //x;
            }
            // check attacker first because the defender is next tot he attacker
            // the attacker has to be available first then determine the defender after
            nextAttackerIndex = nextDefenderIndex - 1;
            if (nextAttackerIndex < 0) {
                nextAttackerIndex = players.Count() - 1;
            }

            // lastly check if the next attacker's hand is not empty ####### choose the next available one
            if (players[nextAttackerIndex].Hand.Count() == 0)
            {
                int fromStartIndex = 0;
                for (int i = 0; i < players.Count(); i++)
                {
                    if (i + nextAttackerIndex < players.Count())
                    {
                        if (players[i + nextAttackerIndex].Hand.Count() != 0)
                        {
                            nextAttackerIndex = i + nextAttackerIndex; break;
                        }
                    }
                    else
                    {
                        if (players[fromStartIndex].Hand.Count() != 0)
                        {
                            nextAttackerIndex = fromStartIndex; break;
                        }
                        fromStartIndex++;
                    }
                }
            }

            // find the next defender
            nextDefenderIndex = nextAttackerIndex + 1;
            if (nextDefenderIndex >= players.Count())
            {
                nextDefenderIndex = 0;
            }
            // check if this player has cards
            if (players[nextDefenderIndex].Hand.Count() == 0)
            {
                int fromStartIndex = 0;
                for (int i = 0; i < players.Count(); i++)
                {
                    if (i + nextDefenderIndex < players.Count())
                    {
                        // i dont think this (& (i + nextDefenderIndex != nextAttackerIndex) is nedded here
                        if (players[i + nextDefenderIndex].Hand.Count() != 0 & (i + nextDefenderIndex != nextAttackerIndex))
                        {
                            nextDefenderIndex = i + nextDefenderIndex; break;
                        }
                        else
                        {
                            // just to let me know no other player is left to defend and the game has reached an end
                            // I dont think it should ever reach this condition, because it should check this first
                            nextDefenderIndex = -1;
                        }
                    }
                    else
                    {
                        if ((players[fromStartIndex].Hand.Count() != 0) & (i + nextDefenderIndex != nextAttackerIndex))
                        {
                            nextDefenderIndex = fromStartIndex; break;
                        }
                        else
                        {
                            // just to let me know no other player is left to defend and the game has reached an end
                            // I dont think it should ever reach this condition, because it should check this first
                            nextDefenderIndex = -1;
                        }
                        fromStartIndex++;
                    }
                }
            }

            turnIndex = nextAttackerIndex;
            defenderIndex = nextDefenderIndex;
        }



        // ############################### TEST ends here ################################

        public void Pass(int currentIndex) {
            //if (currentPlayerDefender)
            //{

            //}
            //// if attacker refuses to attack again during the same turn
            //else
            //{
            //Console.WriteLine("  ");
            //Console.WriteLine("currentIndex: " + currentIndex);
            // attcker calculation starts here
            // only works after attack starts
            //if (cardsAttack.Count != 0)
            //{
                int calculateTurnIndex = currentIndex + 1;
                Console.WriteLine("calculateTurnIndex: " + calculateTurnIndex);
                if (calculateTurnIndex >= players.Count())
                {
                    turnIndex = 0;
                }
                else
                {
                    turnIndex = calculateTurnIndex;
                }
                Console.WriteLine("gameLogic: turn index: " + turnIndex);
                // attcker calculation starts here

                // defender calculation starts here
                int calculateDefenderIndex = currentIndex + 2;
                Console.WriteLine("calculateDefenderIndex: " + calculateDefenderIndex);
                if (calculateDefenderIndex >= players.Count())
                {
                    int difference = calculateDefenderIndex - players.Count();
                    defenderIndex = difference;
                }
                else
                {
                    defenderIndex = calculateDefenderIndex;
                }
            //}
            //Console.WriteLine("gameLogic: defender index: " + defenderIndex);
            // defender calculation ends here
            //}
        }


        //can attck with this card
        public bool CanAttackWithThisCard(Card attackCard)
        {
            // check cards played in attcak panel
            foreach (Card card in cardsAttack)
            {
                if (card.Rank == attackCard.Rank)
                {
                    return true;
                }
            }
            // check cards played in defend panel 
            foreach (Card card in cardsDefend)
            {
                if (card.Rank == attackCard.Rank)
                {
                    return true;
                }
            }
            return false;
        }

        // can defend with this card
        public bool CanDefendWithThisCard(Card defendCard, Card attackCard)
        {
            // if attack card is trump 
            if (attackCard.Suit == trump) {
                if ((defendCard.Suit == trump) & (defendCard.Rank > attackCard.Rank))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // not trump card
            else { 
                if (defendCard.Suit != trump)
                {
                    if (defendCard.Suit  == attackCard.Suit)
                    {
                        if (defendCard.Rank > attackCard.Rank)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                // it means this card is a trump
                else {
                    return true;
                }
            }
        }

        // ####################################################################
        // if there is time left implement later

        //1- take trump card from the deck if you have (6 of trump)
        public bool TakeTumpCardFromDeck(int currentPlayerIndex)
        {
            Card lastTrumpCardDeck = deck.cards[deck.cards.Count() - 1];
            Card tempCard;
            int index = players[currentPlayerIndex].Hand.FindIndex(card => card.Rank == 6 & card.Suit == trump);
            if (index != -1)
            {
                tempCard = players[currentPlayerIndex].Hand[index];
                players[currentPlayerIndex].Hand[index] = lastTrumpCardDeck;
                deck.cards[deck.cards.Count() - 1] = tempCard;
                Console.WriteLine("changed");
                Console.WriteLine("last card in deck=  " + deck.cards[deck.cards.Count() - 1].Rank + " suit: " + deck.cards[deck.cards.Count() - 1].Suit);
                Console.WriteLine("players new card=  " + players[currentPlayerIndex].Hand[index].Rank + " suit: " + players[currentPlayerIndex].Hand[index].Suit);
                return true;
            }
            return false;
        }

        //2- reverse attack
        // ####################################################################







    }
}
