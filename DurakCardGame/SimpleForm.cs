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

        

        //STEP #1
        public void addPlayers()
        {
            string playerOne = "1";
            string playerTwo = "2";
            game.addPlayer(playerOne);
            game.addPlayer(playerTwo);
        }

        //STEP #2
        public void startGame()
        {
            addPlayers();
            game.determinTrumpCard();
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
            // clear the table to display the new cards
            refreshTopBottomPanels();
            // add to the bottom panel the attacking cards
            foreach (Card card in game.cardsAttack)
            {
                Button cardButton = card.CreateCardButton();
                panelAttack.Controls.Add(cardButton);
            }

            // add to the top panel the defending cards
            foreach (Card card in game.cardsDefend)
            {
                Button cardButton = card.CreateCardButton();
                panelDefend.Controls.Add(cardButton);
            }
        }




        public void displayCurrentPlayerHand()
        {
            panelHand.Controls.Clear();
            panelHand.Refresh(); // I dont know what refresh does, I do not think it's needed
            Player currentPlayer = game.players[game.turnIndex];
            int xAxis = 0;
            foreach (Card card in currentPlayer.Hand)
            {
                card.X = xAxis;

                Button cardButton = card.CreateCardButton();

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
                            int attackerIndex = game.CalculateNextPlayerIndex(game.turnIndex, game.distanceIndexDiffernceBetweenAttackerDefender, defenderIndex);
                            //check if the player can attack the defender again
                            bool canAttackAgain = game.canStillAttack(game.players[attackerIndex].Hand);
                            if (!canAttackAgain)
                            {
                                // remove all the played cards
                                game.cardsDefend.Clear();
                                game.cardsAttack.Clear();
                                Console.WriteLine("attacker cant attack again, next attacker index: ", game.turnIndex + game.distanceIndexDiffernceBetweenAttackerDefender);
                                // I think game.turnIndx should be + 1 not game.distance....
                                game.turnIndex = game.CalculateNextPlayerIndex(game.turnIndex, game.distanceIndexDiffernceBetweenAttackerDefender, defenderIndex);

                                // ***************************** DO NOT FORGET to CHANGE the DEFENDER INDEX 
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

                            //change turn to the defender after playing a card
                            game.turnIndex = game.CalculateNextPlayerIndex(game.turnIndex, game.distanceIndexDiffernceBetweenAttackerDefender, defenderIndex);

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

                                //the defender lost, he no longer is able to be the next attacker
                                //the next attacker will be the player after the current defender
                                // change distance to 2
                                game.distanceIndexDiffernceBetweenAttackerDefender = 2;
                                game.turnIndex = 1 + game.CalculateNextPlayerIndex(game.turnIndex, game.distanceIndexDiffernceBetweenAttackerDefender, defenderIndex);
                                // change distance back to 1
                                game.distanceIndexDiffernceBetweenAttackerDefender = 1;

                            }
                            else
                            {
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


                //panelTableBottom.Controls.Add(cardButton);
            }
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

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            startGame();
            displayCurrentPlayerHand();
        }


        //                                    ##############################################
        //                                                       DEBUG CODE 
        //                                    ##############################################
        public void PrintPlayersHand()
        {
            Console.WriteLine("       ");
            foreach (Player player in game.players)
            {
                // I stole this (string result = String.Join(" ", player.Hand.Select(obj => obj.Rank));) from chatGPT
                string result = String.Join(" ", player.Hand.Select(obj => obj.Value + obj.Suit));
                Console.WriteLine("player: " + player.Name + " | " + result);
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
            Console.WriteLine("cardsAttack: "  + result);
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
            Console.WriteLine("Defender PLayer Index: " + game.defenderIndex);
            Console.WriteLine("Curent Player Index: " + game.turnIndex);
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
