using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

/* 
 * The different screens are made of seperate panels, the easiest
 *  way to work with them is by using the Document Outline.
 *  
 * On the ProductionGUI Form go View -> Other Windows -> Document Outline
 *  or hit CTRL + ALT + T.
 */

namespace DurakCardGame
{
    public partial class ProductionGUI : Form
    {
        // Constants
        const int IconsPerPage = 6;

        // Variables
        int numPlayers = 2;
        int numAI = 1;
        int iconPage = 0;

        public ProductionGUI()
        {
            InitializeComponent();
        }

        //*******************************************************************************************************************************************************
        // Main Menu
        //*******************************************************************************************************************************************************

        /// <summary>
        /// Moves to Player Select from Main Menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStartClick(object sender, EventArgs e)
        {
            pnlMainMenu.Visible = false;
            pnlPlayerSelect.Visible = true;
            pnlPlayerSelect.BringToFront();
        }

        /// <summary>
        /// Opens a new form displaying the Durak Rules
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowRules(object sender, EventArgs e)
        {
            List<RulesForm> childForms = Application.OpenForms.OfType<RulesForm>().ToList();
            if (childForms.Count() == 1)
            {
                childForms.FirstOrDefault()!.Close();
            }
            Form rules = new RulesForm();
            rules.Show();
        }

        /// <summary>
        /// Moves to Options from Main Menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOptionsClick(object sender, EventArgs e)
        {
            pnlMainMenu.Visible = false;
            pnlOptions.Visible = true;
            pnlOptions.BringToFront();
        }

        /// <summary>
        /// Closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnQuitClick(object sender, EventArgs e)
        {
            // Closes the window
            Close();
        }

        //
        // Options
        //

        /// <summary>
        /// Moves to Main Menu from Options
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBackOClick(object sender, EventArgs e)
        {
            pnlOptions.Visible = false;
            pnlMainMenu.Visible = true;
            pnlMainMenu.BringToFront();
        }

        //*******************************************************************************************************************************************************
        // Player Select
        //*******************************************************************************************************************************************************

        /// <summary>
        /// Moves to Main Menu from Player Select
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBackPSClick(object sender, EventArgs e)
        {
            pnlPlayerSelect.Visible = false;
            pnlMainMenu.Visible = true;
            pnlMainMenu.BringToFront();
        }

        /// <summary>
        /// Moves to Customize from PlayerSelect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConfirmPSClick(object sender, EventArgs e)
        {
            pnlPlayerSelect.Visible = false;
            pnlCustomize.Visible = true;
            pnlCustomize.BringToFront();
            //ShowIcons();
        }

        /// <summary>
        /// Sets number of game players to 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rb2PlayersClick(object sender, EventArgs e)
        {
            numPlayers = 2;
            rb2AI.Enabled = false;
            lblHide2AI.Visible = true;
            rb3AI.Enabled = false;
            lblHide3AI.Visible = true;

            if (rb2AI.Checked == true || rb3AI.Checked == true)
            {
                rb1AI.Checked = true;
                numAI = 1;
            }
        }

        /// <summary>
        /// Sets number of game players to 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rb3PlayersClick(object sender, EventArgs e)
        {
            numPlayers = 3;
            rb2AI.Enabled = true;
            lblHide2AI.Visible = false;
            rb3AI.Enabled = false;
            lblHide3AI.Visible = true;

            if (rb3AI.Checked == true)
            {
                rb2AI.Checked = true;
                numAI = 2;
            }
        }

        /// <summary>
        /// Sets number of game players to 4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rb4PlayersClick(object sender, EventArgs e)
        {
            numPlayers = 4;
            rb2AI.Enabled = true;
            lblHide2AI.Visible = false;
            rb3AI.Enabled = true;
            lblHide3AI.Visible = false;
        }

        /// <summary>
        /// Sets number of AI players to 0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rb0AIClick(object sender, EventArgs e)
        {
            numAI = 0;
        }

        /// <summary>
        /// Sets number of AI players to 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rb1AIClick(object sender, EventArgs e)
        {
            numAI = 1;
        }

        /// <summary>
        /// Sets number of AI players to 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rb2AIClick(object sender, EventArgs e)
        {
            numAI = 2;
        }

        /// <summary>
        /// Sets number of AI players to 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rb3AIClick(object sender, EventArgs e)
        {
            numAI = 3;
        }

        //*******************************************************************************************************************************************************
        // Customize
        //*******************************************************************************************************************************************************

        /// <summary>
        /// Moves to Player Select from Customize Screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBackNClick(object sender, EventArgs e)
        {
            pnlCustomize.Visible = false;
            pnlPlayerSelect.Visible = true;
            pnlPlayerSelect.BringToFront();
            iconPage = 0;
        }

        /// <summary>
        /// Moves to Game from Customize Screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConfirmNClick(object sender, EventArgs e)
        {
            pnlCustomize.Visible = false;
            pnlGame.Visible = true;
            pnlGame.BringToFront();
            iconPage = 0;
        }

        /// <summary>
        /// Displays the icons players can choose on the customization page
        /// (Not priority so will continue later)
        /// </summary>
        private void ShowIcons()
        {
            const int iconSize = 50;
            int[] iconLocationX = { 34, 90, 146 };
            int[] iconLocationY = { 13, 69, 0 };
            List<PictureBox> iconList = new List<PictureBox>();
            List<PictureBox> panelList = new List<PictureBox>() { pbPlayer1SelectedIcon, pbPlayer2SelectedIcon, pbPlayer3SelectedIcon, pbPlayer4SelectedIcon };
            const String iconLocation = "../../../GUI_Images/Icons/";
            String[] icons = ["Acorn_Boy.jpg", "Beard_Man.jpg", "Inventor.jpg", "Queen.jpg", "Skull_Man.jpg", "Surprise.jpg", "Robot_Knight.jpg"];

            int index = (IconsPerPage * iconPage);

            for (int i = 0; i < IconsPerPage; i++)
            {
                for (int j = 0; j < iconLocationX.Length; j++)
                {
                    iconList[i + j] = new PictureBox
                    {
                        Size = new Size(iconSize, iconSize),
                        Location = new Point(iconLocationX[j], iconLocationY[i]),
                        ImageLocation = iconLocation + icons[index + i],
                        BackgroundImageLayout = ImageLayout.Stretch
                    };

                    //iconList[i + j].Click += (sender, e) =>
                    //{

                    //};
                }

            }
        }


        //*******************************************************************************************************************************************************
        // Game
        //*******************************************************************************************************************************************************

        /// <summary>
        /// Brings up an alert and lets player return to Main Menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMenu(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Exit to Main Menu? (Game will not be saved)", "Exit to Menu", MessageBoxButtons.OKCancel);

            if (dialogResult == DialogResult.OK)
            {
                pnlGame.Visible = false;
                pnlMainMenu.Visible = true;
                pnlMainMenu.BringToFront();
            }
        }



        /// <summary>
        /// Gets a players hand and displays it
        /// </summary>
        /// <param name="hand"></param>
        private void DisplayHand(List<Card> hand)
        {
            const int CardWidth = 80;
            const int CardHeight = 122;
            const int CardY = 12;
            const int CardHover = 10;
            const double SpacePerCard = 2.65;
            const double CardXModifier = 93;
            const double BaseHandCount = 6;
            double handCount = hand.Count;
            int cardXModifier;
            int cardX = 12;


            // Calculate how much space should be between cards
            cardXModifier = (int)(CardXModifier - ((handCount - BaseHandCount) * SpacePerCard));

            foreach (Card card in hand)
            {
                card.X = cardX;
                card.Y = CardY;
                PictureBox cardPb = new PictureBox
                {
                    // Remove card width and height from card class
                    Size = new Size(CardWidth, CardHeight),
                    Location = new Point(cardX, CardY),
                    ImageLocation = card.ImageLocation,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };

                // Add card click event
                cardPb.Click += (sender, e) =>
                {

                    Console.WriteLine(cardPb.Location);
                    // Add Functions from the Game class


                    // If card can be played, Play card


                };

                // Add mouse hover events
                cardPb.MouseEnter += (sender, e) =>
                {
                    // Moves card slightly up
                    cardPb.Location = new Point(card.X, card.Y - CardHover);
                };

                // Mouse Leave Event (Return to original position and restore order if necessary)
                cardPb.MouseLeave += (sender, e) =>
                {
                    // Resets card to default position
                    cardPb.Location = new Point(card.X, card.Y);
                };

                panelHand.Controls.Add(cardPb);
                cardPb.BringToFront();

                // Add to card x
                cardX += cardXModifier;
            }
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
            //game.addPlayer(playerOne);
            //game.addPlayer(playerTwo);
        }

        //STEP #2
        public void startGame()
        {
            addPlayers();
            game.determineTrumpCard();
            string attacker = game.chooseFirstAttacker();
        }

        // clear both panels to display the new cards
        public void refreshTopBottomPanels()
        {
            panelTableBottom.Controls.Clear();
            panelTableBottom.Refresh();
            panelTableTop.Controls.Clear();
            panelTableTop.Refresh();
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
                panelTableBottom.Controls.Add(cardButton);
            }

            // add to the top panel the defending cards
            foreach (Card card in game.cardsDefend)
            {
                Button cardButton = card.CreateCardButton();
                panelTableTop.Controls.Add(cardButton);
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


        // #########################################################################################################
        //                                              GAME LOGIC ENDS HERE
        // #########################################################################################################
    }
}
