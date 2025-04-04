using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
        // A list for ensuring that each Ai name and icon is different
        public List<int> usedAiCustomization = new List<int>();
        public List<Card> cardPlayedDuringGame = new List<Card>();
        //temprary store cards to campare the atack and defence
        // store the cards used in single attack
        public List<Card> cardsAttack = new List<Card>();
        // store cards used in signle attack
        public List<Card> cardsDefend = new List<Card>();
        // For storing what happens during a game
        public List<string> actionLog = new List<string>();

        // multiple attack
        int subAttackDistance { set; get; } = 0;

        // new test
        public int attackerIndex { get; set; } = 0;
        // this will always be the attacker 
        public int defenderIndex { get; set; } = 0;
        // determine the index of the current player (might be attacker or defender)
        public int turnIndex { get; set; } = 0;

        
        public String trump;

        // For checking if a player is human or Ai
        public Type typeHuman = typeof(Human);


        //######################### GUI variable #############################
        // DO NOT FORGET TO RESET ALL THE VALUES AFTER THE ATTACK IS OVER
        public int AttackerXAxis { get; set; } = 0;
        public int DefenderXAxis { get; set; } = 0;
        // DO NOT FORGET TO RESET ALL THE VALUES AFTER THE ATTACK IS OVER

        public GameLogic()
        {
            // shuffle the cards before the game starts
            deck.Shuffle();

            // Update action log
            actionLog.Add("Game Start!");

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

        // test 1 starts here
        // choose first attacker base on their hand, who has the lowest trump card
        // only used when the game start, it probably needs to be (private) and executed in startGame()
        public String chooseFirstAttacker()
        {
            // Update action log
            actionLog.Add("- The player with the lowest trump card attacks first");

            // Store the lowest trump card for the action log
            Card cardLowestTrump = new Card("", "", -1, "");

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
                            cardLowestTrump = card;
                        }
                    }
                }
            }
            // if no player has a trump card, the first one to attack will be the first player inserted 
            if (playerIndex == -1)
            {
                playerIndex = 0;

                // Update action log
                actionLog.Add("- No one has a trump card");
            }
            else
            {
                // Update action log
                actionLog.Add("- " + players[playerIndex].Name + " has the " + cardLowestTrump.ToString());
            }

            turnIndex = playerIndex;
            attackerIndex = playerIndex;
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

            // Update action log
            actionLog.Add("- " + players[playerIndex].Name + " is the first attacker");

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
            // Checks if a player is human and sorts their hand
            SortAllHands();
        }


        // add a player to the game ########### DONE #############
        public void addPlayer(string name, string icon)
        {
            // draw 6 cards from the deck and add them to the player's hand
            List<Card> hand = new List<Card>();
            for (int i = 0; i < 6; i++)
            {
                hand.Add(deck.Draw());
            }
            players.Add(new Human(name, icon, hand));

            // important value for sub-attack
            // it's two, because winning_defender + first_lossing_attacker = 2
            // can not attack again at the same turn
        }

        // add a computer to the game ########### DONE #############
        public void addComputer(String difficulty)
        {
            // draw 6 cards from the deck and add them to the player's hand
            List<Card> hand = new List<Card>();
            for (int i = 0; i < 6; i++)
            {
                hand.Add(deck.Draw());
            }
            players.Add(new Computer(hand, difficulty));

            // Set the name and icon for the computer
            usedAiCustomization.Add(((Computer)players[players.Count - 1]).AiCustomization(usedAiCustomization));

            // important value for sub-attack
            // it's two, because winning_defender + first_lossing_attacker = 2
            // can not attack again at the same turn
        }


        // run this after adding players and computers 
        // ############## DONE ##############
        public void determineTrumpCard()
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

        // stop attack when it reachs 6 cards
        private void AttackReachMaxCards()
        {
            //Console.WriteLine("cardsattack: " + cardsAttack.Count() + " | cardsdefende: " + cardsDefend.Count());
            //Console.WriteLine("turn index: " + turnIndex);
            if (cardsAttack.Count() == 6 & cardsDefend.Count() == 6)
            {
                // means defender won
                // check if defender still have cards
                if (players[defenderIndex].Hand.Count() == 0 & deck.Count() == 0)
                {
                    turnIndex = FindNextAvailablePlayer(defenderIndex);
                    defenderIndex = FindNextAvailablePlayer(turnIndex);
                    attackerIndex = turnIndex;
                }
                // if defender still have cards
                else
                {
                    turnIndex = defenderIndex;
                    attackerIndex = turnIndex;
                    defenderIndex = FindNextAvailablePlayer(turnIndex);
                }
                cardsDefend.Clear();
                cardsAttack.Clear();
                fillHand();
            }
            // defender lost
            else if (cardsAttack.Count() == 6 & canStillDefend(players[defenderIndex].Hand, cardsAttack[cardsAttack.Count()-1])) 
            {
                //LoserTakeAllCards();
                //cardsAttack.Clear();
                //cardsDefend.Clear();
                turnIndex = defenderIndex;
                //defenderIndex = FindNextAvailablePlayer(turnIndex);
                //attackerIndex = turnIndex;
                //fillHand();
            }
            else 
            {
                LoserTakeAllCards();
                cardsAttack.Clear();
                cardsDefend.Clear();
                turnIndex = FindNextAvailablePlayer(defenderIndex);
                defenderIndex = FindNextAvailablePlayer(turnIndex);
                attackerIndex = turnIndex;
                fillHand();
            }
            
        }

        //two steps back to activate the player to be able to attack again after one lost,
        // join as subattacker after two rounds

        public void LoserTakeAllCards()
        {
            foreach (Card card in cardsAttack)
            {
                players[defenderIndex].Hand.Add(card);
            }
            foreach (Card card in cardsDefend)
            {
                players[defenderIndex].Hand.Add(card);
            }

            // Sort hands
            SortAllHands();
        }

        
        // new function to determine next player and support multiple attack and maybe pass as well ENDS HERE
        public void DetermineDefenderAndAttackerIndex()
        {
            
            if (cardsAttack.Count() == 6)
            {
                AttackReachMaxCards();
            }
            else
            {
                if (turnIndex == defenderIndex | (turnIndex == attackerIndex & cardsAttack.Count() > cardsDefend.Count() + 1))
                {
                    //Console.WriteLine("this one 2");
                    turnIndex = attackerIndex;

                }
                // regular attacks or defence
                else
                {
                    turnIndex = defenderIndex;
                }
            }
            
        }


        private int NumberOfPlayer()
        {
            int counter = 0;
            foreach(Player player in players)
            {
                if (player.Hand.Count() != 0)
                {
                    counter++;
                }
            }
            return counter;
        }

        // new TEST START HERE
        public void Pass()
        {
            Console.WriteLine("######################################");
            Console.WriteLine("attacker Index: " + attackerIndex);
            Console.WriteLine("defender Index: " + defenderIndex);
            Console.WriteLine("turn index: " + turnIndex);
            // is defender
            if (turnIndex == defenderIndex) 
            {
                turnIndex = attackerIndex;
            }

            // if attacker
            else
            {
                int totalPlayers = NumberOfPlayer();
                int maxSubAttack = totalPlayers - 2;
                // defender lost 
                if (cardsAttack.Count() > cardsDefend.Count() +1)
                {
                    // if it is the last sub-aatacker
                    if (maxSubAttack == subAttackDistance)
                    {
                        Console.WriteLine("case: 1");
                        subAttackDistance = 0;
                        LoserTakeAllCards();
                        cardsDefend.Clear();
                        cardsAttack.Clear();
                        fillHand();
                        attackerIndex = FindNextAvailablePlayer(defenderIndex);
                        turnIndex = attackerIndex;
                        defenderIndex = FindNextAvailablePlayer(attackerIndex);
                    }
                    // not the last one
                    else
                    {
                        Console.WriteLine("case: 2");
                        attackerIndex = FindNextAvailablePlayer(defenderIndex + subAttackDistance);
                        turnIndex = attackerIndex;
                        subAttackDistance++;
                    }
                }
                //defender not lost yet
                else
                {
                    if (maxSubAttack == subAttackDistance)
                    {

                        subAttackDistance = 0;
                        cardsDefend.Clear();
                        cardsAttack.Clear();
                        fillHand();
                        // defender still have cards
                        if (players[defenderIndex].Hand.Count() != 0)
                        {
                            Console.WriteLine("case: 3");
                            attackerIndex = defenderIndex;
                            turnIndex = attackerIndex;
                            defenderIndex = FindNextAvailablePlayer(turnIndex);
                        }
                        // no cards left with the defender to  be the next attacker 
                        else
                        {
                            Console.WriteLine("case: 4");
                            attackerIndex = FindNextAvailablePlayer(defenderIndex);
                            turnIndex = attackerIndex;
                            defenderIndex = FindNextAvailablePlayer(turnIndex);
                        }
                    }
                    // not the last one
                    else
                    {
                        Console.WriteLine("case: 5");
                        attackerIndex = FindNextAvailablePlayer(defenderIndex + subAttackDistance);
                        turnIndex = attackerIndex;
                        subAttackDistance++;
                    }
                }
            }
        }
        // new TEST START HERE

        
        // ############################### helper function to determine the next available player ##########
        // -1 => means no other player is available
        public int FindNextAvailablePlayer(int afterThisIndex)
        {
            int nextAvailablePlayerIndex = afterThisIndex + 1;
            if (nextAvailablePlayerIndex >= players.Count())
            {
                nextAvailablePlayerIndex -= players.Count();
            }
            if (players[nextAvailablePlayerIndex].Hand.Count() == 0)
            {
                int fromStartIndex = 0;
                for (int i = 0; i < players.Count(); i++)
                {
                    if (i + nextAvailablePlayerIndex < players.Count())
                    {
                        if (players[i + nextAvailablePlayerIndex].Hand.Count() != 0)
                        {
                            nextAvailablePlayerIndex = i + nextAvailablePlayerIndex; break;
                        }
                    }
                    else
                    {
                        if (players[fromStartIndex].Hand.Count() != 0)
                        {
                            nextAvailablePlayerIndex = fromStartIndex; break;
                        }
                        fromStartIndex++;
                    }
                }
                if (nextAvailablePlayerIndex == afterThisIndex)
                {
                    nextAvailablePlayerIndex = -1;
                }

            }
            return nextAvailablePlayerIndex;
        }
        // ############################## helper function to determine the next available player ends here #####

        // ########## add card to cardsAttack or cardsDefend based on turnIndex ##########
        //                   this will help make the GUI code shorter I guess
        public void PlayCardToAttckOrDefendList(Card card)
        {
            bool isDefender = turnIndex == defenderIndex;
            if (isDefender)
            {
                cardsDefend.Add(card);
            }
            else
            {
                cardsAttack.Add(card);
            }
        }
        // ########## add card to cardsAttack or cardsDefend based on turnIndex ##########

        
        //can attck with this card
        public bool CanAttackWithThisCard(Card attackCard)
        {
            //return true;
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

        //constantly setting $player.CanAttack$ to true for the player who is two steps far from the attacker starts here
        //run this function after each time a player plays a card (not efficient) but works
        //OR ### run this function after each time defender wins or losses efficient but needs mor work (also when defender clicks PASS)
        // attacker Index changes (might have sub-attacks), use defender index instead
        // **** refrence should be 3 at least (attacker won, defender won, defender pass, maybe attacker pass)
        private void EnablePlayerCanAttack()
        {
            List<Player> defenderFirst = new List<Player>();
            // will not be correct if one of the playrs has won
            // fix (only loop though players who's hand is not empty

            // only players with hand not empty
            List<Player> playersWithHand = new List<Player>();
            foreach (Player player in players)
            {
                if (player.Hand.Count() != 0)
                {
                    playersWithHand.Add(player);
                }
            }


            // less than 3 means two, no need for that value, because it is only used for sub-aatack
            if (playersWithHand.Count() -1 >= 3)
            {
                // defender first list
                for (int i = 0; i < playersWithHand.Count(); i++)
                {
                    int remainder = (defenderIndex + i) % playersWithHand.Count();
                    //Console.WriteLine("remainder: " + remainder);
                    defenderFirst.Add(playersWithHand[remainder]);
                }

                // enable player who is -2 steps away from the defender
                // chaning th value here will change the value also in the players list,
                // because it's only a reference of that player, not another copy (both point to th same player in memory)
                defenderFirst[defenderFirst.Count() - 2].CanAttack = true;
            }

        }

        public void SortAllHands()
        {
            foreach (Player player in players)
            {
                // Checks if a player is human and sorts their hand
                if (player.GetType().Equals(typeHuman))
                {
                    ((Human)player).SortHand(trump);
                }
            }
        }

        

        // ####################################################################
        // if there is time left implement later

        //1- take trump card from the deck if you have (6 of trump)
        public bool TakeTrumpCardFromDeck()
        {
            Card lastTrumpCardDeck = deck.cards[deck.cards.Count() - 1];
            Card tempCard;
            int currentPlayerIndex = turnIndex;
            int index = players[currentPlayerIndex].Hand.FindIndex(card => card.Rank == 6 && card.Suit == trump);
            if (index != -1)
            {
                tempCard = players[currentPlayerIndex].Hand[index];
                players[currentPlayerIndex].Hand[index] = lastTrumpCardDeck;
                deck.cards[deck.cards.Count() - 1] = tempCard;

                // Sort player hand if human
                SortAllHands();

                // Adds action to action log
                actionLog.Add("- " + players[currentPlayerIndex].Name + " traded " + tempCard.ToString() + " for deck trump " + lastTrumpCardDeck.ToString());

                Console.WriteLine("changed");
                Console.WriteLine("last card in deck=  " + deck.cards[deck.cards.Count() - 1].Rank + " suit: " + deck.cards[deck.cards.Count() - 1].Suit);
                Console.WriteLine("players new card=  " + players[currentPlayerIndex].Hand[index].Rank + " suit: " + players[currentPlayerIndex].Hand[index].Suit);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Lets the player take only the Ace of trump if they have the 6 of Trump
        /// </summary>
        /// <returns></returns>
        public bool TakeTrumpAceFromDeck()
        {
            Card lastTrumpCardDeck = deck.cards[deck.cards.Count() - 1];
            Card tempCard;
            const int ace = 14;
            int currentPlayerIndex = turnIndex;
            int index = players[currentPlayerIndex].Hand.FindIndex(card => card.Rank == 6 && card.Suit == trump);
            if (index != -1 && lastTrumpCardDeck.Rank == ace)
            {
                tempCard = players[currentPlayerIndex].Hand[index];
                players[currentPlayerIndex].Hand[index] = lastTrumpCardDeck;
                deck.cards[deck.cards.Count() - 1] = tempCard;

                // Sort player hand if human
                SortAllHands();

                // Adds action to action log
                actionLog.Add("- " + players[currentPlayerIndex].Name + " traded " + tempCard.ToString() + " for deck trump " + lastTrumpCardDeck.ToString());

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
