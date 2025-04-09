using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

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

        // Indexes
        public int attackerIndex { get; set; } = 0;
        // this will always be the attacker 
        public int defenderIndex { get; set; } = 0;
        // determine the index of the current player (might be attacker or defender)
        public int turnIndex { get; set; } = 0;
        
        public String trump;

        // For checking if a player is human or Ai
        public Type typeHuman = typeof(Human);

        // For checking if the game needs to be ended
        private const int EndGame = -1;

        public GameLogic()
        {
            // shuffle the cards before the game starts
            deck.Shuffle();

            // Update action log
            actionLog.Add("Game Start!");
            actionLog.Add("");
        }

        /// <summary>
        /// Adds a human player to the game
        /// </summary>
        /// <param name="name"></param>
        /// <param name="icon"></param>
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

        /// <summary>
        /// Adds a computer player to the game
        /// </summary>
        /// <param name="playerNames"></param>
        public void addComputer(List<string> playerNames)
        {
            // draw 6 cards from the deck and add them to the player's hand
            List<Card> hand = new List<Card>();
            for (int i = 0; i < 6; i++)
            {
                hand.Add(deck.Draw());
            }
            players.Add(new Computer(hand));

            // Set the name and icon for the computer
            usedAiCustomization.Add(((Computer)players[players.Count - 1]).AiCustomization(usedAiCustomization, playerNames));

            // important value for sub-attack
            // it's two, because winning_defender + first_lossing_attacker = 2
            // can not attack again at the same turn
        }

        /// <summary>
        /// Draws the trump card and sets its suit to the trump suit
        /// </summary>
        public void determineTrumpCard()
        {
            // after giving each player 6 cards, draw card to set as trump suit
            Card trumpCard = deck.Draw();
            // set trump suit
            trump = trumpCard.Suit;

            deck.cards.Add(trumpCard);

            // Update action log
            actionLog.Add("- The trump suit is " + trumpCard.SuitToString());
        }

        /// <summary>
        /// Gets the first attacker for a new game
        /// </summary>
        /// <returns></returns>
        public String chooseFirstAttacker()
        {
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
            if (players.Count() <= calculateDefenderIndex)
            {
                // the defender will be the first player in the list
                defenderIndex = 0;
            }
            else
            {
                defenderIndex = calculateDefenderIndex;
            }

            // Update action log
            actionLog.Add("- " + players[playerIndex].Name + " is the first attacker");

            String names = players[turnIndex].Name;
            return "Attack Order: " + names;
        }

        /// <summary>
        /// Creates a list with the attackers in order at the start of the list and the 
        ///  defender at the end
        /// </summary>
        /// <returns></returns>
        public List<Player> AttackerFirstList()
        {
            List<Player> playerList = new List<Player>();
            int numPlayers = players.Count;

            // Adds 1st attacker to list
            if (defenderIndex - 1 < 0) 
            {
                playerList.Add(players[numPlayers - 1]);
            }
            else
            {
                playerList.Add(players[defenderIndex - 1]);
            }

            // Adds 2nd and 3rd attacker to list if applicable
            for(int i = 1; i < numPlayers - 1; i++)
            {
                if (defenderIndex + i > numPlayers - 1)
                {
                    playerList.Add(players[(defenderIndex + i) - numPlayers]);
                }
                else
                {
                    playerList.Add(players[defenderIndex + i]);
                }
            }

            // Adds defender to list
            playerList.Add(players[defenderIndex]);

            return playerList;
        }

        /// <summary>
        /// Fills all player hands baack to 6 cards
        /// </summary>
        public void fillHand()
        {
            List<Player> playerList = AttackerFirstList();

            foreach (Player player in playerList)
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
                        if (deck.cards.Count() < 1)
                        {
                            break;
                        }
                        player.Hand.Add(deck.Draw());  
                    }
                    // check how many cards are left in the deck to break the outter loop
                    if (deck.cards.Count() < 1)
                    {
                        break;
                    }
                }
            }
            // Checks if a player is human and sorts their hand
            SortAllHands();
        }

        /// <summary>
        /// Collects all the cards on the table and gives them to the defender
        /// </summary>
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

        /// <summary>
        /// Changes the turn if defender has defended against 6 cards
        /// </summary>
        private void MaxAttackReached()
        {
            int indexCheck1 = 0;
            int indexCheck2 = 0;

            subAttackDistance = 0;
            cardsDefend.Clear();
            cardsAttack.Clear();
            fillHand();

            // Enables attacking again for previous broken defenders
            EnablePlayerCanAttack();
            
            // If the defender still has cards
            if (players[defenderIndex].Hand.Count() != 0)
            {
                Console.WriteLine("Max Case 1");
                attackerIndex = defenderIndex;
                turnIndex = attackerIndex;

                indexCheck1 = FindNextAvailablePlayer(turnIndex);

                // Checks if the game should end before switching turn
                if (indexCheck1 != EndGame)
                {
                    defenderIndex = indexCheck1;
                }
            }
            // Defender is out of cards and won
            else
            {
                Console.WriteLine("Max Case 2");

                indexCheck1 = FindNextAvailablePlayer(defenderIndex);
                indexCheck2 = FindNextAvailablePlayer(indexCheck1);

                // Checks if the game should end before switching turn
                if (indexCheck1 != EndGame && indexCheck2 != EndGame)
                {
                    attackerIndex = indexCheck1;
                    turnIndex = attackerIndex;
                    defenderIndex = indexCheck2;
                }
                else
                {
                    GameEnded();
                }
            }

            // Update action log
            actionLog.Add("- Max cards has been reached");
            actionLog.Add("- Defender won the round");

            actionLog.Add("");
            actionLog.Add("- Next Round");
            actionLog.Add("- " + players[turnIndex].Name + " is the first attacker");
        }

        /// <summary>
        /// Determines the next players index
        /// </summary>
        public void DetermineDefenderAndAttackerIndex()
        {
            int indexCheck1 = 0;
            int indexCheck2 = 0;

            // Checks if max attack has been reached without the defender losing
            if (cardsAttack.Count() == 6 && cardsDefend.Count() == 6 && players[defenderIndex].CanAttack)
            {
                // Max attack has been reached, next round
                MaxAttackReached();
            }
            else
            {
                // If it's the defenders turn
                if (turnIndex == defenderIndex)
                {
                    // If the defender isn't out of cards switch the turn to attacker
                        
                        turnIndex = attackerIndex;
                }
                // If it's the attackers turn and the defender lost, switch it back to them
                else if (turnIndex == attackerIndex && cardsAttack.Count() > cardsDefend.Count() + 1)
                {
                    Console.WriteLine("Case 2 -------");
                    //turnIndex = FindCurrentAvailablePlayer(attackerIndex);
                    turnIndex = attackerIndex;
                }
                // If it's the attackers turn and the defender hasn't lost
                else
                {
                    Console.WriteLine("Case 3 -------");
                    if (players[defenderIndex].Hand.Count() == 0)
                    {
                        // no cards left (defender won the game)
                        if (deck.cards.Count() == 0)
                        {
                            Console.WriteLine("What about you?");
                            EnablePlayerCanAttack();

                            indexCheck1 = FindNextAvailablePlayer(defenderIndex);
                            indexCheck2 = FindNextAvailablePlayer(indexCheck1);

                            if (indexCheck1 != EndGame && indexCheck2 != EndGame)
                            {
                                turnIndex = indexCheck1;
                                attackerIndex = turnIndex;
                                defenderIndex = indexCheck2;
                            }
                            else
                            {
                                GameEnded();
                            }
                        }
                        // still cards in the deck, the defender becomes the next attacker
                        else
                        {
                            Console.WriteLine("How about this?");
                            EnablePlayerCanAttack();

                            indexCheck1 = FindNextAvailablePlayer(defenderIndex);

                            if (indexCheck1 != EndGame)
                            {
                                turnIndex = defenderIndex;
                                attackerIndex = defenderIndex;
                                defenderIndex = indexCheck1;
                            }
                            else
                            {
                                GameEnded();
                            } 
                        }
                    }
                    // player has cards
                    else
                    {
                        Console.WriteLine("Is it you?");
                        turnIndex = defenderIndex;
                    }
                }
            }
        }
          
        /// <summary>
        /// Finds the next available player who still has cards bassed on the current index
        /// </summary>
        /// <param name="afterThisIndex"></param>
        /// <returns></returns>
        public int FindNextAvailablePlayer(int afterThisIndex)
        {
            int nextAvailablePlayerIndex = afterThisIndex + 1;

            // Checks if the index is greater than list length and loops it back to start
            if (nextAvailablePlayerIndex >= players.Count())
            {
                nextAvailablePlayerIndex -= players.Count();
                Console.WriteLine("here");
                //nextAvailablePlayerIndex = 0;
            }
            // Checks if the player selected has already won or can't attack
            if (players[nextAvailablePlayerIndex].Hand.Count() == 0 || (!players[nextAvailablePlayerIndex].CanAttack && PlayersWithHand().Count() > 2))
            {
                Console.WriteLine("here 2");
                for (int i = 0; i < players.Count(); i++)
                {
                    nextAvailablePlayerIndex++;

                    // Ensures index isn't out of range
                    if (nextAvailablePlayerIndex > (players.Count() - 1))
                    {
                        nextAvailablePlayerIndex -= players.Count();
                    }

                    // Checks if the player selected hasn't won
                    if ((players[nextAvailablePlayerIndex].Hand.Count() != 0 && players[nextAvailablePlayerIndex].CanAttack) || PlayersWithHand().Count() <= 2)
                    {
                        //Console.WriteLine("here ");
                        Console.WriteLine("found the next: " + nextAvailablePlayerIndex + " | old was: " + afterThisIndex);
                        break;
                    }
                }
                // Sets the index to -1 if it's looped back to original index
                if (nextAvailablePlayerIndex == afterThisIndex)
                {
                    nextAvailablePlayerIndex = -1;
                }
            }
            return nextAvailablePlayerIndex;
        }

        /// <summary>
        /// Initialtes a turn for a computer player
        /// </summary>
        /// <returns></returns>
        public bool ComputerPlayCard()
        {
            bool doAction = false;
            Player player = players[turnIndex];
            bool isComputer = player.GetType() == typeof(Computer);

            // Ensures the player is a Computer
            if (isComputer)
            {
                Console.WriteLine("here");
                Computer computerPlayer = (Computer)player;
                List<Card> cardsCanPlay = new List<Card>();

                // Checks through all the cards in the Computers hand
                foreach (Card card in computerPlayer.Hand)
                {
                    // Finds the cards the computer can play as the defender
                    if (turnIndex == defenderIndex)
                    {
                        if (CanDefendWithThisCard(card, cardsAttack[cardsAttack.Count() - 1])) { cardsCanPlay.Add(card); }
                    }
                    // Finds the cards the computer can play as the attacker
                    else
                    {
                        if (cardsAttack.Count() == 0)
                        {
                            Console.WriteLine("first attacker");
                            //doAction = true;
                            cardsCanPlay.Add(card);
                        }
                        else if (CanAttackWithThisCard(card))
                        {
                            Console.WriteLine("might not be first");
                            cardsCanPlay.Add(card);
                        }
                    }
                }

                // Checks if the computer is able to play a card
                if (cardsCanPlay.Count() > 0)
                {
                    Console.WriteLine("have cards to play");
                    // Computer defends with card
                    if (turnIndex == defenderIndex)
                    {
                        Card bestOption = computerPlayer.ChooseBestCard(cardsCanPlay, false, trump);
                        cardsDefend.Add(bestOption);
                        computerPlayer.PlayCard(bestOption);
                        
                        // Updates action log
                        actionLog.Add("- " + players[turnIndex].Name + " played " + bestOption.ToString());
                        
                        DetermineDefenderAndAttackerIndex();
                        doAction = true;
                    }
                    // Computer attacks with card
                    else
                    {
                        //Console.WriteLine("attacking ");

                        Card bestOption = computerPlayer.ChooseBestCard(cardsCanPlay, true, trump);

                        // Checks if the defender already lost and passes instead of giving them a trump card
                        if (!players[defenderIndex].CanAttack && bestOption.Suit == trump)
                        {
                            Pass();
                        }
                        else
                        {
                            cardsAttack.Add(bestOption);
                            computerPlayer.PlayCard(bestOption);

                            // Updates action log
                            actionLog.Add("- " + players[turnIndex].Name + " played " + bestOption.ToString());

                            DetermineDefenderAndAttackerIndex();

                            doAction = true;
                        }
                    }
                }
                else
                {
                    Pass();
                }
            }
            return doAction;
        }

        /// <summary>
        /// Passes the turn to the next player
        /// </summary>
        public void Pass()
        {
            Console.WriteLine("######################################");
            Console.WriteLine("attacker Index: " + attackerIndex);
            Console.WriteLine("defender Index: " + defenderIndex);
            Console.WriteLine("turn index: " + turnIndex);
            Console.WriteLine("distance: " + subAttackDistance);

            // For seeing if the game needs to end
            int indexCheck1 = 0;
            int indexCheck2 = 0;

            // is defender
            if (turnIndex == defenderIndex) 
            {
                // Update action log
                actionLog.Add("- " + players[defenderIndex].Name + " lost the defence");

                // Sets the defender to can't attack
                players[defenderIndex].CanAttack = false;

                //turnIndex = FindNextAvailablePlayer(attackerIndex);
                turnIndex = attackerIndex;
            }

            // if attacker
            else
            {
                int totalPlayers = PlayersWithHand().Count();
                int maxSubAttack = totalPlayers - 2;

                // Subtracts 1 from max sub attack if 1 of the attackers can't attack
                for (int i = 0; i < players.Count(); i++)
                {
                    if (i != defenderIndex && !players[i].CanAttack)
                    {
                        maxSubAttack--;
                        Console.WriteLine("Max Sub: " + maxSubAttack);
                    }
                }

                // Update action log
                actionLog.Add("- " + players[turnIndex].Name + " ended their attack");

                // Defender lost
                if (cardsAttack.Count() > cardsDefend.Count())
                {
                    // All attackers have passed, Defender lost
                    if (maxSubAttack <= subAttackDistance)
                    {
                        Console.WriteLine("case: 1");
                        subAttackDistance = 0;
                        LoserTakeAllCards();
                        cardsDefend.Clear();
                        cardsAttack.Clear();
                        fillHand();

                        // Enables attacking again for previous broken defenders
                        EnablePlayerCanAttack();

                        indexCheck1 = FindNextAvailablePlayer(defenderIndex);
                        indexCheck2 = FindNextAvailablePlayer(indexCheck1);

                        // Checks if the game should end before switching turn
                        if (indexCheck1 != EndGame && indexCheck2 != EndGame)
                        {
                            attackerIndex = indexCheck1;
                            turnIndex = attackerIndex;
                            defenderIndex = indexCheck2;

                            // Update action log
                            actionLog.Add("");
                            actionLog.Add("- Next Round");
                            actionLog.Add("- " + players[turnIndex].Name + " is the first attacker");
                        }
                        else
                        {
                            GameEnded();
                        } 
                    }
                    // not the last one
                    else
                    {
                        Console.WriteLine("case: 2");

                        indexCheck1 = FindNextAvailablePlayer(defenderIndex + subAttackDistance);

                        // Checks if the game should end before switching turn
                        if (indexCheck1 != EndGame)
                        {
                            attackerIndex = indexCheck1;
                            turnIndex = attackerIndex;
                            subAttackDistance++;
                        }
                        else
                        {
                            GameEnded();
                        }
                    }
                }
                // Defender hasn't lost yet
                else
                {
                    // All attackers have passed, Defender won
                    if (maxSubAttack <= subAttackDistance)
                    {
                        subAttackDistance = 0;
                        cardsDefend.Clear();
                        cardsAttack.Clear();
                        fillHand();

                        // Enables attacking again for previous broken defenders
                        EnablePlayerCanAttack();

                        // defender still have cards     ##########################################################
                        if (players[defenderIndex].Hand.Count() != 0)
                        {
                            Console.WriteLine("case: 3");
                            attackerIndex = defenderIndex;
                            turnIndex = attackerIndex;

                            indexCheck1 = FindNextAvailablePlayer(turnIndex);

                            // Checks if the game should end before switching turn
                            if (indexCheck1 != EndGame)
                            {
                                defenderIndex = indexCheck1;
                            }
                            else
                            {
                                GameEnded();
                            }
                        }
                        // no cards left with the defender to be the next attacker  ###############################################
                        else
                        {
                            Console.WriteLine("case: 4");

                            indexCheck1 = FindNextAvailablePlayer(defenderIndex);
                            indexCheck2 = FindNextAvailablePlayer(indexCheck1);

                            // Checks if the game should end before switching turn
                            if (indexCheck1 != EndGame && indexCheck2 != EndGame)
                            {
                                attackerIndex = indexCheck1;
                                turnIndex = attackerIndex;
                                defenderIndex = indexCheck2;
                            }
                            else
                            {
                                GameEnded();
                            }
                        }

                        // Update action log
                        actionLog.Add("");
                        actionLog.Add("- Next Round");
                        actionLog.Add("- " + players[turnIndex].Name + " is the first attacker");
                    }
                    // not the last one
                    else
                    {
                        Console.WriteLine("case: 5");

                        indexCheck1 = FindNextAvailablePlayer(defenderIndex + subAttackDistance);

                        // Checks if the game should end before switching turn
                        if(indexCheck1 != EndGame)
                        {
                            attackerIndex = indexCheck1;
                            turnIndex = attackerIndex;
                            subAttackDistance++;
                        }
                        else
                        {
                            GameEnded();
                        }
                    }
                }
            }
        }

        // get all players with hand
        private List<Player> PlayersWithHand()
        {
            List<Player> allPlayers = new List<Player>();
            if (deck.cards.Count() > 0)
            {
                foreach (Player player in players)
                {
                    if (player.Hand.Count() != 0)
                    {
                        allPlayers.Add(player);
                    }
                }
            }
            
            return allPlayers;
        }

        /// <summary>
        /// Checks if a players card can be used to attack
        /// </summary>
        /// <param name="attackCard"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Checks if a players card can be used to defend
        /// </summary>
        /// <param name="defendCard"></param>
        /// <param name="attackCard"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Moves a played card to the attack list or defend list depending on who played it
        /// </summary>
        /// <param name="card"></param>
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

            // Updates action log
            actionLog.Add("- " + players[turnIndex].Name + " played " + card.ToString());
        }

        /// <summary>
        /// Checks if the game has ended or not
        /// </summary>
        /// <returns></returns>
        public bool GameEnded()
        {
            int playersLeft = 0;
            bool result;

            if (deck.cards.Count() == 0)
            {
                foreach (Player player in players)
                {
                    if (player.Hand.Count() > 0)
                    {
                        playersLeft++;
                    }
                }

                // only one left = lost
                int numberToStopGame = 1;

                result = playersLeft <= numberToStopGame;

                // Ensures the defender can defend 1 last time if they still have cards, possibly letting them draw instead of lose
                if (result && players[defenderIndex].Hand.Count() > 0 && turnIndex == defenderIndex && cardsAttack.Count() > cardsDefend.Count())
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Enables a player to attack again after having lost a defence round
        /// </summary>
        private void EnablePlayerCanAttack()
        {
            if (PlayersWithHand().Count() == 2)
            {
                players[defenderIndex].CanAttack = true;
            }
            else
            {
                if (defenderIndex - 2 < 0)
                {
                    players[(defenderIndex - 2) + players.Count()].CanAttack = true;
                }
                else
                {
                    players[(defenderIndex - 2)].CanAttack = true;
                }
            }
            
        }

        /// <summary>
        /// Sorts all human players hands
        /// </summary>
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

        /// <summary>
        /// If player has 6 of trump, switches it with the deck trump card
        /// </summary>
        /// <returns></returns>
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

                // Updates action log
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

                // Updates action log
                actionLog.Add("- " + players[currentPlayerIndex].Name + " traded " + tempCard.ToString() + " for deck trump " + lastTrumpCardDeck.ToString());

                Console.WriteLine("changed");
                Console.WriteLine("last card in deck=  " + deck.cards[deck.cards.Count() - 1].Rank + " suit: " + deck.cards[deck.cards.Count() - 1].Suit);
                Console.WriteLine("players new card=  " + players[currentPlayerIndex].Hand[index].Rank + " suit: " + players[currentPlayerIndex].Hand[index].Suit);
                return true;
            }
            return false;
        }
    }
}
