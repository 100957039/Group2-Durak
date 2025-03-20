using System;
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        // #########################################################################################################
        //                                              GAME LOGIC STARTS HERE  March 19th
        // #########################################################################################################
        //******************    //ProductionGUI.cs ALWAY USE player.PlayCard2  *****************
        // #########################################################################################################
        GameLogic game = new GameLogic();

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
            textBoxTrump.Text = game.trump;
            textBoxTurn.Text = game.turnIndex.ToString();
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
            foreach (Card card in currentPlayer.Hand)
            {

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
                            int attackerIndex = game.turnIndex - game.distanceIndexDiffernceBetweenAttackerDefender;
                            if (attackerIndex > 0)
                            {
                                attackerIndex = game.players.Count() - attackerIndex;
                            }
                            //check if the player can attack the defender again
                            bool canAttackAgain = game.canStillAttack(game.players[attackerIndex].Hand);
                            if (!canAttackAgain)
                            {
                                // remove all the played cards
                                game.cardsDefend.Clear();
                                game.cardsAttack.Clear();
                                Console.WriteLine("attacker cant attack again, next attacker index: ", game.turnIndex + game.distanceIndexDiffernceBetweenAttackerDefender);
                                game.turnIndex += game.distanceIndexDiffernceBetweenAttackerDefender; ;
                            }
                            // other players might be able to attack ########### leave for later ############# 
                            else
                            {
                                displayPlayedCards();
                                /// use below this line (distanceIndexDiffernceBetweenAttackerDefender)
                                /// do not forget to code for the other attacker as well above this line
                                /// if the player can attack again, change turn 
                                /// 
                                int turnIndex = game.defenderIndex + game.distanceIndexDiffernceBetweenAttackerDefender;
                                Console.WriteLine("turnIndex: " + turnIndex);
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

                                foreach (Card card in game.cardsAttack)
                                {
                                    defender.DrawCard(card);
                                }
                            }
                            else
                            {
                                displayPlayedCards();
                            }
                        }
                    }
                    panelHand.Controls.Add(cardButton);
                };

                //panelTableBottom.Controls.Add(cardButton);
            }
        }

        private void btnTableTopBg_Click(object sender, EventArgs e)
        {

        }

        private void buttonConsole_Click(object sender, EventArgs e)
        {
            // 1- add two player
            startGame();
            // 2- display table
            displayPlayedCards();
            Console.WriteLine("running" + game.trump);
            //current player
            displayCurrentPlayerHand();
        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            startGame();
            displayPlayedCards();
            displayCurrentPlayerHand();
        }


        // #########################################################################################################
        //                                              GAME LOGIC ENDS HERE
        // #########################################################################################################
    }
}
