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
        // based on this value, it will determine if (REVERSE ATTACKE) is active
        public bool reverseAttackActive { get; set; } = false;

        // multiple attack
        int subAttackNumber { set; get; } = 0;

        // 
        bool gameEnd { get; set; } = false;

        // new test
        public int attackerIndex { get; set; } = 0;
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

                        // Checks if a player is human and sorts their hand
                        if (player.GetType().Equals(typeHuman))
                        {
                            ((Human)player).SortHand(trump);
                        }
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

        public List<Player> CreateListAttackerFirst()
        {
            List<Player> attackerFirst = new List<Player>();

            for (int i = 0; i < players.Count(); i++) // Use Count, not Count()
            {
                int index = (attackerIndex + i) % players.Count(); // Wrap around using modulo
                attackerFirst.Add(players[index]);
            }
            return attackerFirst;
        }

        public List<Player> CreateListDefenderFirst()
        {
            List<Player> defenderFirst = new List<Player>();

            for (int i = 0; i < players.Count; i++) // Use Count, not Count()
            {
                int index = (defenderIndex + i) % players.Count; // Wrap around using modulo
                defenderFirst.Add(players[index]);
            }
            return defenderFirst;
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
        }

       
        // new function to detemine next player and support multiple attack and maybe pass as well STARTS HERE
        public void DetermineDefenderAndAttackerIndex()
        {
            // just to debug starts here
            int caseNumber = -1;
            string caseInfo = "";
            // just to debug ends here

            int nextDefenderIndex;
            int nextAttackerIndex; // ====== turnIndex
            int nextTurnIndex;
            // if defender 
            int result = cardsAttack.Count() - cardsDefend.Count();
            //Console.WriteLine("cardsAttack.Count() - cardsDefend.Count() > 1: " + result);
            if (defenderIndex == turnIndex)
            {
                if (players[turnIndex].Hand.Count() == 0) {
                    nextAttackerIndex = FindNextAvailablePlayer(turnIndex);
                    nextDefenderIndex = FindNextAvailablePlayer(nextAttackerIndex);
                    nextTurnIndex = nextAttackerIndex;
                // 
                }else if (cardsAttack.Count() - cardsDefend.Count() > 1)
                {
                    LoserTakeAllCards();
                    nextAttackerIndex = FindNextAvailablePlayer(turnIndex);
                    nextDefenderIndex = FindNextAvailablePlayer(nextAttackerIndex);
                    nextTurnIndex = nextAttackerIndex;
                    cardsAttack.Clear();
                    cardsDefend.Clear();
                }
                else
                {

                
                // check if the current attcker can attack again
                bool canStillAttackAgainBlah = canStillAttack(players[attackerIndex].Hand);
                if (canStillAttackAgainBlah)
                {
                    //Console.WriteLine("attacker hand: " + string.Join(", ", players[attackerIndex].Hand.Select(card => card.Rank.ToString() + card.Suit)));
                    caseNumber = 1;
                    caseInfo = "defender won, attacker can attack again";
                    nextDefenderIndex = defenderIndex;
                    nextAttackerIndex = attackerIndex;
                    nextTurnIndex = attackerIndex;


                }
                // else the defender won the attack
                else
                {

                    caseNumber = 2;
                    //Console.WriteLine("attacker's hand: " + players[attackerIndex].Hand.Select(card=> card.Rank.ToString()+ card.Suit));
                    caseInfo = "defender won, attcker can not attack again";
                    // implement code to allow other players to attack if the attacker no longer has the right cards starts here

                    //            ######################## DO NOT FORGET ########################
                    // -2 => exclude defender and attacker from total players
                    int possibleNumberOfAttackers = 0;
                    foreach (Player player in players)
                        {
                            if (player.Hand.Count() > 0)
                            {
                                possibleNumberOfAttackers++;
                            }
                        }
                        possibleNumberOfAttackers = possibleNumberOfAttackers - 2;
                    Console.WriteLine("possibleNumberOfAttackers: " + possibleNumberOfAttackers);
                    //int possibleNextAttackerIndex = FindNextAvailablePlayer(turnIndex);
                    //Console.WriteLine(possibleNextAttackerIndex);
                    //int distanceBetweenSubAttckerAndDefender = Math.Abs(possibleNextAttackerIndex - defenderIndex);
                    //Console.WriteLine(distanceBetweenSubAttckerAndDefender);
                    //bool possibleNextAttackerCanAttack = canStillAttack(players[possibleNextAttackerIndex].Hand);
                    //Console.WriteLine("next can attack: " + possibleNextAttackerCanAttack);

                    // test starts here
                    int possibleNextAttackerIndex = 100;             //100 could be any value
                    int distanceBetweenSubAttckerAndDefender = 100;  // any value greater than total number of players
                    bool possibleNextAttackerCanAttack = false;
                    for (int i = 0; i < possibleNumberOfAttackers; i++)
                    {
                        //possibleNextAttackerIndex = FindNextAvailablePlayer(defenderIndex + i);
                        // below new line
                        possibleNextAttackerIndex = FindNextAvailablePlayer(defenderIndex + i + subAttackNumber);
                        Console.WriteLine("                                             ############################# ");
                        Console.WriteLine("debug SUB attack: " + possibleNextAttackerIndex);
                        distanceBetweenSubAttckerAndDefender = Math.Abs(possibleNextAttackerIndex - defenderIndex);
                        Console.WriteLine("debug SUB attack distance: " + distanceBetweenSubAttckerAndDefender);
                        possibleNextAttackerCanAttack = canStillAttack(players[possibleNextAttackerIndex].Hand);
                        Console.WriteLine("debug SUB attack can attack: " + possibleNextAttackerCanAttack);
                        Console.WriteLine("                                             ############################# ");
                        if (possibleNextAttackerCanAttack)
                        {
                            Console.WriteLine("should attack the same defender next: " + possibleNextAttackerIndex);
                            Console.WriteLine("distance between them: " + distanceBetweenSubAttckerAndDefender);
                            break;
                        }
                    }
                    Console.WriteLine(" ");
                    //Console.WriteLine("cards Attack: " + string.Join(", ", cardsAttack.Select(p => p.Rank)));
                    //Console.WriteLine("cards defend: " + string.Join(", ", cardsDefend.Select(p => p.Rank)));
                    //Console.WriteLine("sub-attack| attacker's hand: " + string.Join(" , ", players[possibleNextAttackerIndex].Hand.Select(card => card.Rank)));
                    //Console.WriteLine(" ");
                    // test ends here
                    if (possibleNumberOfAttackers != 0 & possibleNumberOfAttackers >= distanceBetweenSubAttckerAndDefender & possibleNextAttackerCanAttack)
                    {
                        subAttackNumber++;
                        Console.WriteLine("############################case test sub attack ################################");
                        Console.WriteLine("increament subNumber: " + subAttackNumber);
                        Console.WriteLine("previous defender: " + defenderIndex);
                        nextDefenderIndex = defenderIndex;
                        nextAttackerIndex = possibleNextAttackerIndex;
                        nextTurnIndex = possibleNextAttackerIndex;
                    }
                    // defender won and no other attack from any player is made
                    else
                    {
                        // implement code to allow other players to attack if the attacker no longer has the right cards ends here

                        // attacker = 0 | defender = 1 | => nextAttacker = 1 | next defender = 2
                        // defender 1 + X = 2 => x = 1
                        // check if defender who is going to be attacker, still have cards
                        //Console.WriteLine("attacker no longer have valid cards to play: " + string.Join(" , ", players[attackerIndex].Hand.Select(card => card.Rank.ToString() + card.Suit)));
                        subAttackNumber = 0;
                        //Console.WriteLine("reset sub-attack Number: " + subAttackNumber);
                        if (players[defenderIndex].Hand.Count() != 0)
                        {
                            nextDefenderIndex = FindNextAvailablePlayer(defenderIndex); //x
                            nextAttackerIndex = defenderIndex;
                            nextTurnIndex = defenderIndex;
                        }
                        else
                        {
                            nextAttackerIndex = FindNextAvailablePlayer(defenderIndex);
                            nextDefenderIndex = FindNextAvailablePlayer(nextAttackerIndex);
                            nextTurnIndex = nextAttackerIndex;
                        }

                        cardsAttack.Clear();
                        cardsDefend.Clear();
                        fillHand();
                    
                        }
                
                    } 

            
                }

                //}
                // if defender lost the attack
                // attacker = 0 | defender = 1 | => nextAttacker = 2 | next defender = 3
                // defender 1 + X = 3 => x = 2
                //else
                //{
                //    nextDefenderIndex = turnIndex + 2; //x
                //}
            }
            // if attacker
            else
            {

                Card cardAttackedBy = cardsAttack[cardsAttack.Count - 1];
                //Console.WriteLine(" : " + cardAttackedBy.Rank.ToString() + cardAttackedBy.Suit);
                bool canStillDefendAgainBlah = canStillDefend(players[defenderIndex].Hand, cardAttackedBy);
                //Console.WriteLine("can defend: " + canStillDefendAgainBlah);

                // play other cards when defender losses or refuses to defend
                if (cardsAttack.Count() - cardsDefend.Count() > 1 ) 
                {
                    bool canStillAttackAgain = canStillAttack(players[attackerIndex].Hand);
                    if (canStillAttackAgain)
                    {
                        nextAttackerIndex = attackerIndex;
                        nextTurnIndex = attackerIndex;
                        nextDefenderIndex = defenderIndex;
                    }
                    else
                    {
                        LoserTakeAllCards();
                        nextAttackerIndex = FindNextAvailablePlayer(defenderIndex);
                        nextTurnIndex = nextAttackerIndex;
                        nextDefenderIndex = FindNextAvailablePlayer(nextAttackerIndex);
                        cardsAttack.Clear();
                        cardsDefend.Clear();
                        fillHand();
                    }

                        
                    
                }
                // 
                else if (!canStillDefendAgainBlah )
                {
                    caseNumber = 3;
                    caseInfo = "attcker won, defender can not beat this card: " + cardAttackedBy.Suit + cardAttackedBy.Rank;
                    subAttackNumber = 0;
                    //Console.WriteLine("reset sub-attack number: " + subAttackNumber);
                    //Console.WriteLine("defender hand: " + string.Join(" , ",players[defenderIndex].Hand.Select(card => card.Rank.ToString() + card.Suit)));
                    //nextTurnIndex = turnIndex + 2;

                    // if attacker still have card could have played
                    //bool canStillAttackAgain = canStillAttack(players[attackerIndex].Hand);

                    //if (canStillAttackAgain) {
                    //    nextAttackerIndex = attackerIndex;
                    //    nextDefenderIndex = defenderIndex;
                    //    nextTurnIndex = attackerIndex;
                    //}
                    //else
                    //{

                    //}
                    nextTurnIndex = -1; //it will be same as nextAttackerIndex 

                    // test defender lost and the attacer still have cards to play starts here
                    bool attackerStillHaveCardsToPlay = canStillAttack(players[attackerIndex].Hand);
                    if (attackerStillHaveCardsToPlay)
                    {
                        nextAttackerIndex = attackerIndex;
                        nextDefenderIndex = defenderIndex;
                        nextTurnIndex = attackerIndex;
                    }

                    // test defender lost and the attacer still have cards to play ends here

                    else
                    {
                        foreach (Card card in cardsAttack)
                        {
                            players[defenderIndex].Hand.Add(card);
                        }
                        foreach (Card card in cardsDefend)
                        {
                            players[defenderIndex].Hand.Add(card);
                        }

                        // if attacker won 
                        nextAttackerIndex = FindNextAvailablePlayer(defenderIndex);
                        nextDefenderIndex = FindNextAvailablePlayer(nextAttackerIndex);
                        nextTurnIndex = nextAttackerIndex;
                        //clear played cards defence and attack
                        cardsDefend.Clear();
                        cardsAttack.Clear();
                        fillHand();
                    }
                    
                }
                // if attacker loses
                // attacker = 0 | defender = 1 | => nextAttacker = 1 | next defender = 2
                // attacker 0 + X = 2 => x = 2 
                else
                {
                    //Console.WriteLine("defender hand: " + string.Join(" , ", players[defenderIndex].Hand.Select(card => card.Rank.ToString() + card.Suit)));
                    caseNumber = 4;
                    caseInfo = "attcker played card, defender can defend";
                    // implement code to allow other players to attack if the attacker no longer has the right cards


                    // implement code to allow other players to attack if the attacker no longer has the right cards
                    //nextDefenderIndex = turnIndex + 2; //x;
                    nextDefenderIndex = defenderIndex;
                    nextAttackerIndex = attackerIndex;
                    nextTurnIndex = defenderIndex;

                }
            }

            // test stop attack if 6 cards has been played starts here
            int numberAttackCardPlayed = cardsAttack.Count();
            int numberDefendCardPlayed = cardsDefend.Count();
            bool defenderHasNoCardsForLastAttack = players[defenderIndex].Hand.Count() == 0;
            //bool canDefendLastAttack = canStillDefend(players[defenderIndex].Hand, cardsAttack[cardsAttack.Count() - 1]);

            // defender does not have cards
            // I do not think it will ever reach this condition
            if (defenderHasNoCardsForLastAttack)
            {
                //Console.WriteLine("GameLogic.cs| special case 2... defender won and has no cards left");
                nextAttackerIndex = FindNextAvailablePlayer(defenderIndex);
                nextTurnIndex = nextAttackerIndex;
                nextDefenderIndex = FindNextAvailablePlayer(nextAttackerIndex);

            }
            // defender does have cards
            // only usefull if there is 6 cards in cardsAttack
            else if (numberAttackCardPlayed == 6 & numberDefendCardPlayed == 6)
            {
                //Console.WriteLine("GameLogic.cs| special case 2");
                //if ()
                //{
                nextAttackerIndex = defenderIndex;
                nextTurnIndex = defenderIndex;
                nextDefenderIndex = FindNextAvailablePlayer(defenderIndex);
                cardsAttack.Clear();
                cardsDefend.Clear();
                fillHand();

                //}
                // not sure about this and I dont think it will ever reach this point
                //else if (numberDefendCardPlayed == 5 & canDefendLastAttack)
                //{
                //    nextDefenderIndex = defenderIndex;
                //    nextAttackerIndex = attackerIndex;
                //    next
                //}
            }

            //if attack cards = 6 and defender can defend
            //if (canDefendLastAttack) { }
            //if attack cards = 6 and defender can not defend
            //else if (!canDefendLastAttack) { }

            EnablePlayerCanAttack();
            // test stop attack if 6 cards has been played ends here

            turnIndex = nextTurnIndex;
            attackerIndex = nextAttackerIndex;
            defenderIndex = nextDefenderIndex;
            //Console.WriteLine("case number: " + caseNumber);
            //Console.WriteLine("case info: " + caseInfo);
        }

        // new function to determine next player and support multiple attack and maybe pass as well ENDS HERE


       
        // ############################### helper function to determine the next available player ##########
        // -1 => means no other player is available
        public int FindNextAvailablePlayer(int afterThisIndex)
        {
            int nextAvailablePlayerIndex = afterThisIndex + 1;
            if (nextAvailablePlayerIndex >= players.Count())
            {
                nextAvailablePlayerIndex = 0;
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

        // make it work for multiple attacks
        public void Pass()
        {
            int nextPossibleAttacker;
            int nextPossibleTurn;
            int nextPossibleDefender;
            //lis = [1, 2, 3, 4]
            //newlis = lis[3:] + lis[:3] => [3,4,1,2]
            List<Player> playersListAttackerFirstIndex = new List<Player>();
            int fromStartBlah = 0;

            // Updates action log
            actionLog.Add("- " + players[turnIndex].Name + " ended their turn");

            for (int i = 0; i < players.Count()-2; i++)
            {
                bool exceedRange = i + attackerIndex >= players.Count();
                if (exceedRange)
                {
                    playersListAttackerFirstIndex.Add(players[fromStartBlah]);
                    fromStartBlah++;
                }
                else
                {
                    playersListAttackerFirstIndex.Add(players[i + attackerIndex]);
                }
            }
            // last one is the first attacker, not needed
            //int 
            //playersListAttackerFirstIndex = playersListAttackerFirstIndex.GetRange(0, playersListAttackerFirstIndex.Count() - 1);

            bool isDefender = turnIndex == defenderIndex;
            // defender turn (done I think)
            if (isDefender)
            {


                bool attackerCanStillAttackAgain = canStillAttack(players[attackerIndex].Hand);
                // means defender lost
                if (cardsAttack.Count() - cardsDefend.Count() >= 1 & attackerCanStillAttackAgain )
                {

                    // defender refuse to defend and attacker have cards to give
                    nextPossibleAttacker = attackerIndex;
                    nextPossibleTurn = attackerIndex;
                    nextPossibleDefender = defenderIndex;
                   
                    
                }
                else
                {
                    nextPossibleAttacker = FindNextAvailablePlayer(defenderIndex);
                    nextPossibleTurn = nextPossibleAttacker;
                    nextPossibleDefender = FindNextAvailablePlayer(nextPossibleAttacker);

                    //take all the cards
                    foreach (Card card in cardsAttack)
                    {
                        players[defenderIndex].Hand.Add(card);
                    }
                    foreach (Card card in cardsDefend)
                    {
                        players[defenderIndex].Hand.Add(card);
                    }
                    // reset the panels
                    cardsAttack.Clear();
                    cardsDefend.Clear();
                    fillHand();
                }
                //Console.Write("defender refuse to defend");
            }
            // attacker turn 
            else
            {
                // ############## new test function starts hre
                // if cardsAttack less than cardDefend and it's attacker turn, means defender lost
                // and loser should take all the played cards
                if (cardsAttack.Count() > cardsDefend.Count())
                {
                    LoserTakeAllCards();
                    nextPossibleAttacker = FindNextAvailablePlayer(defenderIndex);
                    nextPossibleDefender = FindNextAvailablePlayer(nextPossibleAttacker);
                    nextPossibleTurn = nextPossibleAttacker;

                    cardsAttack.Clear();
                    cardsDefend.Clear();
                    fillHand();
                }
                // regular game and the defender, has not lost yet
                else
                {
                    // ############## new test function ends here


                    // single attack
                    if (playersListAttackerFirstIndex[1].Name == players[defenderIndex].Name)
                    {
                        // available next sub attack
                        nextPossibleAttacker = FindNextAvailablePlayer(defenderIndex);

                        if (players[nextPossibleAttacker].Name != playersListAttackerFirstIndex[0].Name)
                        {
                            bool nextAttackerCanPlay = canStillAttack(players[nextPossibleAttacker].Hand);
                            subAttackNumber++;
                            if (nextAttackerCanPlay)
                            {
                                Console.WriteLine("subattack - first can attacl");
                                nextPossibleDefender = defenderIndex;
                                nextPossibleTurn = nextPossibleAttacker;
                            }
                            else
                            {
                                subAttackNumber++;
                                nextPossibleAttacker = FindNextAvailablePlayer(subAttackNumber);
                                nextAttackerCanPlay = canStillAttack(players[nextPossibleAttacker].Hand);
                                int maxDistance = players.Select(player => player.Hand.Count() != 0).Count() - 2;
                                if (maxDistance != subAttackNumber & nextAttackerCanPlay)
                                {
                                    Console.WriteLine("subattack - second can attacl");
                                    nextPossibleDefender = defenderIndex;
                                    nextPossibleTurn = nextPossibleAttacker;
                                }
                                else
                                {
                                    nextPossibleAttacker = defenderIndex;
                                    nextPossibleDefender = FindNextAvailablePlayer(nextPossibleAttacker);
                                    nextPossibleTurn = defenderIndex;
                                    cardsAttack.Clear();
                                    cardsDefend.Clear();
                                    fillHand();
                                    subAttackNumber = 0;
                                }
                            }

                        }
                        // no attacker left, means defender will be the next attacker
                        else
                        {
                            nextPossibleAttacker = FindNextAvailablePlayer(defenderIndex);
                            nextPossibleTurn = nextPossibleAttacker;
                            nextPossibleDefender = FindNextAvailablePlayer(nextPossibleAttacker);
                            cardsAttack.Clear();
                            cardsDefend.Clear();
                            fillHand();
                        }
                    }
                    else
                    {
                        //multiple attack ##################(for this to work, each player needs to have uniuqe name or ID) ######################
                        //if the second index does not equal the defender name, (it is multiple attack)
                        int maxDistance = players.Select(player => player.Hand.Count() != 0).Count() - 2;
                        Console.WriteLine("gamelogic.cs | maxdistance sub-attack: " + maxDistance);
                        Console.WriteLine("defender index: " + defenderIndex + " | attacker index: " + attackerIndex);
                        if (maxDistance != subAttackNumber)
                        {
                            //calculateTurnIndex = defenderIndex;
                            Console.WriteLine("first sub attacker refuse to attack. see if there is possibale third attacker" + subAttackNumber);
                            //subAttackNumber++;
                            Console.WriteLine("multiple attack");
                            int originalInOriginalOrder = players.FindIndex(player => player.Name == playersListAttackerFirstIndex[subAttackNumber].Name);
                            Console.WriteLine(originalInOriginalOrder);
                            Console.WriteLine("third attacker hand: " + string.Join(" , ", playersListAttackerFirstIndex[subAttackNumber].Hand.Select(card => card.Rank.ToString() + card.Suit)));
                            nextPossibleAttacker = originalInOriginalOrder;
                            nextPossibleTurn = originalInOriginalOrder;
                            nextPossibleDefender = defenderIndex;

                            subAttackNumber++;
                            Console.WriteLine("sub attack number after incrementing: " + subAttackNumber + " | max allowed increment: " + maxDistance);
                        }
                        //single attack (done I think)
                        else
                        {
                            Console.WriteLine("Single attack");
                            //calculateTurnIndex = currentIndex + 1;
                            if (players[defenderIndex].Hand.Count() != 0)
                            {
                                nextPossibleAttacker = defenderIndex;
                                nextPossibleTurn = defenderIndex;
                                nextPossibleDefender = FindNextAvailablePlayer(defenderIndex);
                            }
                            else
                            {
                                nextPossibleAttacker = FindNextAvailablePlayer(defenderIndex);
                                nextPossibleTurn = nextPossibleAttacker;
                                nextPossibleDefender = FindNextAvailablePlayer(nextPossibleAttacker);
                            }
                            subAttackNumber = 0;

                            //clear panel
                            cardsDefend.Clear();
                            cardsAttack.Clear();
                            fillHand();
                        }
                    }

                }
            }
            // Sort Cards
            SortAllHands();
            turnIndex = nextPossibleTurn;
            attackerIndex = nextPossibleAttacker;
            defenderIndex = nextPossibleDefender;
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
                if(players.GetType() == typeHuman)
                {
                    ((Human)players[currentPlayerIndex]).SortHand(trump);
                }

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
