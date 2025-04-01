using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DurakCardGame
{
    public partial class SimpleForm : Form
    {
        public SimpleForm()
        {
            InitializeComponent();
        }



        // #########################################################################################################
        //                                              GAME LOGIC STARTS HERE  March 19th
        // #########################################################################################################
        //******************    //ProductionGUI.cs ALWAY USE player.PlayCard2  *****************
        // #########################################################################################################
        GameLogic game = new GameLogic();
        string textTrumpField = "Trump Suit: ";
        string textPlayerIndexField = "Player Trun by Index: ";
        string textCardsLeftDeck = "Deck: ";
        string textAttackerIndex = "Attacker Index: ";
        string textDefenderIndex = "Defender Index: ";



        //STEP #1
        public void addPlayers()
        {
            string playerOne = "1";
            string playerTwo = "2";
            List<String> playersList = new List<String> { "1", "2", "3", "4" };
            List<String> iconList = new List<String> { "1", "2", "3", "4" };
            for (int i = 0; i < playersList.Count; i++)
            {
                game.addPlayer(playersList[i], iconList[i]);
            }
        }

        //STEP #2
        public void startGame()
        {
            game = new GameLogic();
            addPlayers();
            game.determineTrumpCard();
            game.SortAllHands();
            string attacker = game.chooseFirstAttacker();
            textBoxTrump.Text = textTrumpField + game.trump;
            textBoxTurn.Text = textPlayerIndexField + game.turnIndex.ToString();
            Console.WriteLine(attacker);
        }

        // clear both panels to display the new cards
        public void refreshTopBottomPanels()
        {
            panelAttack.Controls.Clear();
            panelAttack.Refresh();
            panelDefend.Controls.Clear();
            panelDefend.Refresh();
        }

        // run after each time a card is played
        public void displayPlayedCards()
        {
            //******************************************************************
            //after each time full hand fuction run, update cards left in deck
            textBoxDeckNumber.Text = textCardsLeftDeck + game.deck.Count();
            textBoxTurn.Text = textPlayerIndexField + game.turnIndex.ToString();
            textBoxDefenderIndex.Text = textDefenderIndex + game.defenderIndex;

            string winners = "Winners: ";
            foreach (Player player in game.players)
            {
                if (player.Hand.Count() == 0)
                {
                    winners += player.Name + " ";
                }
            }
            textBoxWinners.Text = winners;
            //******************************************************************

            //textBox
            // clear the table to display the new cards
            refreshTopBottomPanels();
            // add to the bottom panel the attacking cards
            int xAxis = 0;
            foreach (Card card in game.cardsAttack)
            {
                card.X = xAxis;
                Button cardButton = card.CreateCardButton();
                cardButton.Enabled = false;
                panelAttack.Controls.Add(cardButton);
                xAxis += 75;
            }

            //reset xAxis 
            xAxis = 0;
            // add to the top panel the defending cards
            foreach (Card card in game.cardsDefend)
            {
                card.X = xAxis;
                Button cardButton = card.CreateCardButton();
                cardButton.Enabled = false;
                panelDefend.Controls.Add(cardButton);
                xAxis += 75;
            }
        }




        public void displayCurrentPlayerHand3()
        {
            panelHand.Controls.Clear();
            panelHand.Refresh(); // I dont know what refresh does, I do not think it's needed
            Console.WriteLine("    ");
            Console.WriteLine("game.turnIndex: " + game.turnIndex);
            Console.WriteLine("    ");
            Player currentPlayer = game.players[game.turnIndex];
            int xAxis = 0;
            //String winners = "";
            foreach (Card card in currentPlayer.Hand)
            {
                if (currentPlayer.Hand.Count() > 0)
                {
                    card.X = xAxis;

                    Button cardButton = card.CreateCardButton();
                    // ******************************************
                    //Duplicated code, needs not work on it later 
                    // cardButton.Click += (sender, e) => should be inside this if statement 
                    // it will not effect anything, but it's not good practice 
                    bool defenderIndex = game.defenderIndex == game.turnIndex;
                    if (defenderIndex)
                    {
                        int lastCardIndex = game.cardsAttack.Count() - 1;
                        if (lastCardIndex >= 0)
                        {
                            Card lastAttackedCard = game.cardsAttack[game.cardsAttack.Count() - 1];
                            if (!game.CanDefendWithThisCard(card, lastAttackedCard))
                            {
                                cardButton.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        //check if the attacker can use this card to attack
                        if (game.cardsAttack.Count() != 0 & (!game.CanAttackWithThisCard(card)))
                        {
                            cardButton.Enabled = false;
                        }
                    }
                    //Duplicated code, needs not work on it later
                    // ******************************************

                    cardButton.Click += (sender, e) =>
                    {
                        // ckeck if the game ended
                        bool endGame = game.GameEnded();
                        if (!endGame)
                        {
                            //check if player is attacker or defender
                            bool defenderIndex = game.defenderIndex == game.turnIndex;
                            if (defenderIndex)
                            {
                                currentPlayer.PlayCard2(card);
                                game.cardsDefend.Add(card);
                                // attacker index 
                                Console.WriteLine("1 calculate");
                                int attackerIndex = game.CalculateNextPlayerIndex(game.turnIndex, game.distanceIndexDiffernceBetweenAttackerDefender, defenderIndex);
                                //check if the player can attack the defender again
                                bool canAttackAgain = game.canStillAttack(game.players[attackerIndex].Hand);
                                if (!canAttackAgain)
                                {
                                    // remove all the played cards
                                    game.cardsDefend.Clear();
                                    game.cardsAttack.Clear();
                                    //Console.WriteLine("attacker cant attack again, next attacker index: ");
                                    Console.WriteLine("SimpleForm.cs => attcker cann't attack again, run fill hand run");
                                    game.fillHand();
                                    // I think game.turnIndx should be + 1 not game.distance....
                                    game.turnIndex = game.defenderIndex;
                                    // ***************************** DO NOT FORGET to CHANGE the DEFENDER INDEX 
                                    Console.WriteLine("2 calculate");
                                    game.defenderIndex = game.CalculateNextPlayerIndex(game.turnIndex, game.distanceIndexDiffernceBetweenAttackerDefender, false);
                                    // I think the code above will do    
                                    /// CHNAGE INDEX HERE FOR THE DEFENDER
                                    // ***************************** DO NOT FORGET to CHANGE the DEFENDER INDEX 

                                }
                                // other players might be able to attack ########### leave for later ############# 
                                else
                                {
                                    displayPlayedCards();
                                    /// use below this line (distanceIndexDiffernceBetweenAttackerDefender)
                                    /// do not forget to code for the other attacker as well above this line
                                    /// if the player can attack again, change turn 
                                    /// 
                                    //int attackerIndex = game.CalculateNextPlayerIndex(game.turnIndex, game.distanceIndexDiffernceBetweenAttackerDefender, defenderIndex);
                                    Console.WriteLine("turnIndex: " + attackerIndex);
                                    game.turnIndex = attackerIndex;
                                    //if (turnIndex + )
                                    //game.turnIndex = 
                                }
                            }
                            // else attacker
                            else
                            {

                                currentPlayer.PlayCard2(card);
                                game.cardsAttack.Add(card);
                                // check if the defender can defend this card
                                Player defender = game.players[game.defenderIndex];
                                bool canDefend = game.canStillDefend(defender.Hand, card);


                                //if defender no longer able to defend, take all the played cards
                                if (!canDefend)
                                {
                                    foreach (Card card in game.cardsDefend)
                                    {
                                        defender.DrawCard(card);
                                    }
                                    game.cardsDefend.Clear();

                                    foreach (Card card in game.cardsAttack)
                                    {
                                        defender.DrawCard(card);
                                    }
                                    game.cardsAttack.Clear();

                                    Console.WriteLine("SimpleForm.cs => defender cann't defend again, run fill hand run");
                                    game.fillHand();

                                    Console.WriteLine("4 calculate");
                                    //the defender lost, he no longer is able to be the next attacker
                                    //the next attacker will be the player after the current defender
                                    // change distance to 2
                                    game.distanceIndexDiffernceBetweenAttackerDefender = 2;
                                    game.turnIndex = game.CalculateNextPlayerIndex(game.turnIndex, game.distanceIndexDiffernceBetweenAttackerDefender, defenderIndex);
                                    // change distance back to 1
                                    game.distanceIndexDiffernceBetweenAttackerDefender = 1;

                                }
                                else
                                {
                                    Console.WriteLine("3 calculate");
                                    //change turn to the defender after playing a card
                                    game.turnIndex = game.CalculateNextPlayerIndex(game.turnIndex, game.distanceIndexDiffernceBetweenAttackerDefender, defenderIndex);

                                    PrintPlayersHand();
                                    displayPlayedCards();
                                }


                            }
                            displayCurrentPlayerHand();
                        }

                    };
                    panelHand.Controls.Add(cardButton);
                    xAxis += 75;
                    // after each card is being played, refresh the panel to display the new cards
                    displayPlayedCards();

                }
                // add winners
                if (game.players[game.turnIndex].Hand.Count() == 0)
                {
                    textBoxWinners.Text = " " + game.players[game.turnIndex].Name;
                }


                //panelTableBottom.Controls.Add(cardButton);
            }
        }

        public void displayCurrentPlayerHand()
        {
            panelHand.Controls.Clear();
            panelHand.Refresh(); // I dont know what refresh does, I do not think it's needed
            Console.WriteLine("    ");
            Console.WriteLine("game.turnIndex: " + game.turnIndex);
            Console.WriteLine("    ");
            Player currentPlayer = game.players[game.turnIndex];
            int xAxis = 0;
            //String winners = "";
            foreach (Card card in currentPlayer.Hand)
            {
                if (currentPlayer.Hand.Count() > 0)
                {
                    card.X = xAxis;

                    Button cardButton = card.CreateCardButton();
                    // ******************************************
                    //Duplicated code, needs not work on it later 
                    // cardButton.Click += (sender, e) => should be inside this if statement 
                    // it will not effect anything, but it's not good practice 
                    bool defenderIndex = game.defenderIndex == game.turnIndex;
                    if (defenderIndex)
                    {
                        int lastCardIndex = game.cardsAttack.Count() - 1;
                        if (lastCardIndex >= 0)
                        {
                            Card lastAttackedCard = game.cardsAttack[game.cardsAttack.Count() - 1];
                            if (!game.CanDefendWithThisCard(card, lastAttackedCard))
                            {
                                cardButton.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        //check if the attacker can use this card to attack
                        if (game.cardsAttack.Count() != 0 & (!game.CanAttackWithThisCard(card)))
                        {
                            cardButton.Enabled = false;
                        }
                    }
                    //Duplicated code, needs not work on it later
                    // ******************************************

                    cardButton.Click += (sender, e) =>
                    {
                        // ckeck if the game ended
                        bool endGame = game.GameEnded();
                        if (!endGame)
                        {
                            currentPlayer.PlayCard2(card);
                            game.PlayCardToAttckOrDefendList(card);
                            game.DetermineDefenderAndAttackerIndex();
                            displayPlayedCards();
                            displayCurrentPlayerHand();
                        };
                        panelHand.Controls.Add(cardButton);
                        xAxis += 75;
                        // after each card is being played, refresh the panel to display the new cards
                        //displayPlayedCards();

                    };
                    panelHand.Controls.Add(cardButton);
                }
                xAxis += 75;
                // add winners
                if (game.players[game.turnIndex].Hand.Count() == 0)
                {
                    textBoxWinners.Text = " " + game.players[game.turnIndex].Name;
                }



            }
        }

        // all four hands
        public void displayAllFourHand()
        {

            List<Panel> panels = [panelHand, panel1, panel2, panel3];
            panelHand.Controls.Clear();
            panelHand.Refresh(); // I dont know what refresh does, I do not think it's needed
            
            Player currentPlayer = game.players[game.turnIndex];
            int xAxis = 0;
            //String winners = "";
            for (int i = 0; game.players.Count() > i; i++)
            {
                // clear panels
                panels[i].Controls.Clear();
                foreach (Card card in game.players[i].Hand)
                {
                    //if (currentPlayer.Hand.Count() > 0)
                    //{
                    card.X = xAxis;

                    Button cardButton = card.CreateCardButton();
                    // ******************************************
                    //Duplicated code, needs not work on it later 
                    // cardButton.Click += (sender, e) => should be inside this if statement 
                    // it will not effect anything, but it's not good practice 
                    
                    //Duplicated code, needs not work on it later
                    // ******************************************
                    cardButton.Click += (sender, e) =>
                    {
                        // ckeck if the game ended
                        bool endGame = game.GameEnded();
                        if (!endGame)
                        {
                            currentPlayer.PlayCard2(card);
                            game.PlayCardToAttckOrDefendList(card);
                            game.DetermineDefenderAndAttackerIndex();
                            displayPlayedCards();
                            displayCurrentPlayerHand();
                        };
                        //panelHand.Controls.Add(cardButton);
                        xAxis += 75;
                        // after each card is being played, refresh the panel to display the new cards
                        //displayPlayedCards();
                        displayAllFourHand();
                    };
                    // if attacker
                    if (game.turnIndex == i & game.turnIndex == game.attackerIndex)
                    {
                        //check if the attacker can use this card to attack
                        if (game.cardsAttack.Count() != 0 & (!game.CanAttackWithThisCard(card)))
                        {
                            cardButton.Enabled = false;
                        }
                        panels[i].BackColor = Color.GreenYellow;
                        // if defender
                    } else if (game.turnIndex == i & game.turnIndex == game.defenderIndex)
                    {
                        int lastCardIndex = game.cardsAttack.Count() - 1;
                        if (lastCardIndex >= 0)
                        {
                            Card lastAttackedCard = game.cardsAttack[game.cardsAttack.Count() - 1];
                            if (!game.CanDefendWithThisCard(card, lastAttackedCard))
                            {
                                cardButton.Enabled = false;
                            }
                        }
                        panels[i].BackColor = Color.Red;
                    }
                    // other players
                    else
                    {
                        panels[i].BackColor = Color.White;
                        cardButton.Enabled = false;
                    }
                    panels[i].Controls.Add(cardButton);
                    //}
                    xAxis += 75;
                    // add winners
                    if (game.players[game.turnIndex].Hand.Count() == 0)
                    {
                        textBoxWinners.Text = " " + game.players[game.turnIndex].Name;
                    }



                }
                xAxis = 0;

            }
            // ends here
        }

        private void btnTableTopBg_Click(object sender, EventArgs e)
        {

        }

        //debug console button
        private void buttonConsole_Click(object sender, EventArgs e)
        {
            // 1- add two player
            //startGame();
            // 2- display table
            //displayPlayedCards();
            //Console.WriteLine("running" + game.trump);
            //current player
            //displayCurrentPlayerHand();
            PrintPlayersHand();

        }

        // pass attack or defence
        private void buttonPass_Click(object sender, EventArgs e)
        {
            // only works if there is at least one card played in attack list
            if (game.cardsAttack.Count() != 0)
            {
                //bool isDefender = game.turnIndex == game.defenderIndex;
                //if (isDefender)
                //{
                //    foreach (Card card in game.cardsAttack)
                //    {
                //        game.players[game.turnIndex].Hand.Add(card);
                //    }
                //    foreach (Card card in game.cardsDefend)
                //    {
                //        game.players[game.turnIndex].Hand.Add(card);
                //    }
                //}
                //game.cardsDefend.Clear();
                //game.cardsAttack.Clear();

                //game.fillHand();
                game.Pass();
                //game.Pass(game.turnIndex);
                refreshTopBottomPanels();
                displayPlayedCards();
                displayCurrentPlayerHand();
            }

        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {

            startGame();
            // only one hand
            //displayCurrentPlayerHand();

            // all four hands
            displayAllFourHand();
        }

        // switch your card if you have 6 of trump with the last trump card in the dexk
        private void button2_Click(object sender, EventArgs e)
        {
            if (game.TakeTrumpCardFromDeck())
            {
                displayCurrentPlayerHand();
            }
        }

        


        //                                    ##############################################
        //                                                       DEBUG CODE 
        //                                    ##############################################
        public void PrintPlayersHand()
        {
            Console.WriteLine("       ");
            for (int i =0; i < game.players.Count(); i++)
            {
                // I stole this (string result = String.Join(" ", player.Hand.Select(obj => obj.Rank));) from chatGPT
                string result = String.Join(" ", game.players[i].Hand.Select(obj => obj.Value + obj.Suit));
                Console.WriteLine("player index: " + i + " | " + result);
            }
            Console.WriteLine("       ");

        }
        private void button3_Click(object sender, EventArgs e)
        {
            PrintPlayersHand();
        }


        public void PrintPlayedCards()
        {
            Console.WriteLine("       ");
            // I stole this (string result = String.Join(" ", player.Hand.Select(obj => obj.Rank));) from chatGPT
            string result = String.Join(" ", game.cardsAttack.Select(obj => obj.Value + obj.Suit));
            Console.WriteLine("cardsAttack: " + result);
            // I stole this (string result = String.Join(" ", player.Hand.Select(obj => obj.Rank));) from chatGPT
            string result2 = String.Join(" ", game.cardsDefend.Select(obj => obj.Value + obj.Suit));
            Console.WriteLine("cardsDefend: " + result2);
            Console.WriteLine("       ");
        }
        private void buttonPlayedCards_Click(object sender, EventArgs e)
        {
            PrintPlayedCards();
        }

        // print defender index and the current player
        private void PrintDefenderCurrentPlayerIndex()
        {
            Console.WriteLine("   ");
            Console.WriteLine("Curent Player Index: " + game.turnIndex);
            Console.WriteLine("Attacker Player Index: " + game.attackerIndex);
            Console.WriteLine("Defender PLayer Index: " + game.defenderIndex);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            PrintDefenderCurrentPlayerIndex();
        }

        


        //                                    ##############################################
        //                                                       DEBUG CODE 
        //                                    ##############################################


        // #########################################################################################################
        //                                              GAME LOGIC ENDS HERE
        // #########################################################################################################
    }
}
