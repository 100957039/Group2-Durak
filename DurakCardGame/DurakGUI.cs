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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

/* 
 * The different screens are made of seperate panels, the easiest
 *  way to work with them is by using the Document Outline.
 *  
 * On the DurakGUI Form go View -> Other Windows -> Document Outline
 *  or hit CTRL + ALT + T.
 */

namespace DurakCardGame
{
    public partial class DurakGUI : Form
    {
        // Variables
        int numPlayers = 2;
        int numAi = 1;
        int[] iconPage = { 0, 0, 0, 0 };
        string difficulty = "easy";

        // Game variable
        GameLogic game = new GameLogic();

        public DurakGUI()
        {
            InitializeComponent();
            //BtnConfirmNClick(null, null);
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
            SetupCustomization();
            pnlPlayerSelect.Visible = false;
            pnlCustomize.Visible = true;
            pnlCustomize.BringToFront();
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
                numAi = 1;
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
                numAi = 2;
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
            numAi = 0;
        }

        /// <summary>
        /// Sets number of AI players to 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rb1AIClick(object sender, EventArgs e)
        {
            numAi = 1;
        }

        /// <summary>
        /// Sets number of AI players to 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rb2AIClick(object sender, EventArgs e)
        {
            numAi = 2;
        }

        /// <summary>
        /// Sets number of AI players to 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rb3AIClick(object sender, EventArgs e)
        {
            numAi = 3;
        }

        //*******************************************************************************************************************************************************
        // Customize
        //*******************************************************************************************************************************************************

        /// <summary>
        /// Makes visible only the chosen number of human players customization
        /// </summary>
        private void SetupCustomization()
        {
            if (numPlayers == 2 && numAi == 1 || numPlayers == 3 && numAi == 2 || numPlayers == 4 && numAi == 3)
            {
                gbPlayer2Customize.Visible = false;
                gbPlayer3Customize.Visible = false;
                gbPlayer4Customize.Visible = false;
            }
            else if (numPlayers == 2 && numAi == 0 || numPlayers == 3 && numAi == 1 || numPlayers == 4 && numAi == 2)
            {
                gbPlayer2Customize.Visible = true;
                gbPlayer3Customize.Visible = false;
                gbPlayer4Customize.Visible = false;
            }
            else if (numPlayers == 3 && numAi == 0 || numPlayers == 4 && numAi == 1)
            {
                gbPlayer2Customize.Visible = true;
                gbPlayer3Customize.Visible = true;
                gbPlayer4Customize.Visible = false;
            }
            else
            {
                gbPlayer2Customize.Visible = true;
                gbPlayer3Customize.Visible = true;
                gbPlayer4Customize.Visible = true;
            }
            
            SetupIcons();
        }

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
            ResetIconPages();
        }

        /// <summary>
        /// Moves to Game from Customize Screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConfirmNClick(object sender, EventArgs e)
        {
            int valid = NameValidation();

            if (valid != -1 && valid != 2)
            {
                pnlCustomize.Visible = false;
                pnlGame.Visible = true;
                pnlGame.BringToFront();
                ResetIconPages();
                GameSetup();
            }
            else if (valid == -1)
            {
                DialogResult dialogResult = MessageBox.Show("Player names cannot be blank.", "Error", MessageBoxButtons.OK);
            }
            else 
            {
                DialogResult dialogResult = MessageBox.Show("Player names must be unique.", "Error", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Displays the icon selections for all human players
        /// </summary>
        private void SetupIcons()
        {
            List<Panel> panelList = new List<Panel>() { pnlPlayer1IconSelect, pnlPlayer2IconSelect, pnlPlayer3IconSelect, pnlPlayer4IconSelect };
            List<PictureBox> selectedIconList = new List<PictureBox>() { pbPlayer1SelectedIcon, pbPlayer2SelectedIcon, pbPlayer3SelectedIcon, pbPlayer4SelectedIcon };
            
            for (int i = 0; i < numPlayers - numAi; i++)
            {
                ShowIcons(panelList[i], selectedIconList[i], i);
            }
        }

        /// <summary>
        /// Displays the icons players can choose on the customization page
        /// (Not priority so will continue later)
        /// </summary>
        private void ShowIcons(Panel iconPanel, PictureBox selectedIcon, int playerIndex)
        {
            const int IconsPerPage = 6;
            const int IconSize = 50;
            int[] IconLocationX = { 34, 90, 146, 34, 90, 146 };
            int[] IconLocationY = { 13, 69, 13, 69, 13, 69 };
            List<PictureBox> iconList = new List<PictureBox>();
            const string IconLocation = "../../../GUI_Images/Icons/";
            string[] icons = ["Acorn_Boy.jpg", "Beard_Man.jpg", "Inventor.jpg", "Queen.jpg", "Skull_Man.jpg", "Fancy_Man.jpg", "Robot_Knight.jpg"];

            const int ArrowWidth = 20;
            const int ArrowHeight = 38;
            Point ArrowLocationL = new Point(7, 47);
            Point ArrowLocationR = new Point(203, 47);
            const string ArrowTextL = "<";
            const string ArrowTextR = ">";
           

            // Clear the icon panel
            iconPanel.Controls.Clear();

            // Calculate where in the icon array to start
            int index = (IconsPerPage * iconPage[playerIndex]);

            // Adds all icon pictureboxs to selection panel
            for (int i = 0; i < IconLocationY.Length; i++)
            {
                iconList.Add(new PictureBox
                {
                    Size = new Size(IconSize, IconSize),
                    Location = new Point(IconLocationX[i], IconLocationY[i]),
                    SizeMode = PictureBoxSizeMode.StretchImage
                });

                if ((index + i) < icons.Length)
                {
                    iconList[i].ImageLocation = IconLocation + icons[index + i];
                    
                    iconList[i].Click += (sender, e) =>
                    {
                        PictureBox icon = sender as PictureBox;
                        selectedIcon.ImageLocation = icon.ImageLocation;
                    };
                }
                else
                {
                    iconList[i].BackColor = Color.Black;
                }

                iconPanel.Controls.Add(iconList[i]);
            }

            // Creates and adds the left arrow
            Button arrowL = new Button
            {
                Size = new Size(ArrowWidth, ArrowHeight),
                Location = ArrowLocationL,
                Text = ArrowTextL,
                BackColor = Color.Black,
                ForeColor = Color.White,
                Font = new Font("Casteller", 14),
                TextAlign = ContentAlignment.TopCenter
            };
            arrowL.Click += (sender, e) =>
            {
                iconPage[playerIndex]--;
                ShowIcons(iconPanel, selectedIcon, playerIndex);
            };

            // Creates and adds the right arrow
            Button arrowR = new Button
            {
                Size = new Size(ArrowWidth, ArrowHeight),
                Location = ArrowLocationR,
                Text = ArrowTextR,
                BackColor = Color.Black,
                ForeColor = Color.White,
                Font = new Font("Casteller", 14),
                TextAlign = ContentAlignment.TopCenter
            };
            arrowR.Click += (sender, e) =>
            {
                iconPage[playerIndex]++;
                ShowIcons(iconPanel, selectedIcon, playerIndex);
            };

            // Disables the arrow if at the first or last page
            if (iconPage[playerIndex] == 0) 
            { 
                arrowL.Enabled = false;
            }
            if (index + IconsPerPage >= icons.Length)
            {
                arrowR.Enabled = false;
            }

            // Add the arrows to the panel
            iconPanel.Controls.Add(arrowL);
            iconPanel.Controls.Add(arrowR);
        }

        /// <summary>
        /// Ensures that all players have a proper name
        /// </summary>
        /// <returns></returns>
        private int NameValidation()
        {
            int valid = 0;
            List<String> playerName = new List<String> { tbPlayer1Name.Text, tbPlayer2Name.Text, tbPlayer3Name.Text, tbPlayer4Name.Text };
            for (int i = 0; i < numPlayers; i++)
            {
                if (string.IsNullOrWhiteSpace(playerName[i]))
                {
                    valid = -1;
                    return valid;
                }
                else if (playerName.Count != playerName.Distinct().Count())
                {
                    valid = -2;
                    return valid;
                }
            }

            return valid;
        }

        /// <summary>
        /// Sets all players icon pages to 0
        /// </summary>
        private void ResetIconPages()
        {
            for (int i = 0; i < iconPage.Length - 1; i++) 
            {
                iconPage[i] = 0;
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


        private void GameSetup()
        {
            game = new GameLogic();
            ResetGameBoard();
            UpdateActionLog();
            SetupPlayers();
            game.determineTrumpCard();
            SetupTrump();
            game.SortAllHands();
            game.chooseFirstAttacker();
            UpdateActionLog();
            UpdatePlayerLocations();
            DisplayHand();
            UpdateHandCounts();
            UpdateDeckCount();
        }

        /// <summary>
        /// Add the players into the game with their chosen names and icons
        /// Also adds the computer players with their selected difficulty
        /// </summary>
        private void SetupPlayers()
        {
            List<String> playerIcons = new List<String> { pbPlayer1SelectedIcon.ImageLocation, pbPlayer2SelectedIcon.ImageLocation, pbPlayer3SelectedIcon.ImageLocation, pbPlayer4SelectedIcon.ImageLocation };
            List<Panel> playerPanels = new List<Panel> { pnlPlayer1, pnlPlayer2, pnlPlayer3, pnlPlayer4 };
            List<String> playerNames = new List<String> { tbPlayer1Name.Text, tbPlayer2Name.Text, tbPlayer3Name.Text, tbPlayer4Name.Text };

            // Add all needed human and computer players
            for (int i = 0; i < numPlayers - numAi; i++)
            {
                game.addPlayer(playerNames[i], playerIcons[i]);
            }
            for (int i = 0; i < numAi; i++)
            {
                game.addComputer(difficulty);
            }

            // Hide all player panels
            for (int i = 0; i < playerPanels.Count; i++)
            {
                playerPanels[i].Visible = false;
            }

            // Show all needed player panels
            for (int i = 0; i < numPlayers; i++)
            {
                playerPanels[i].Visible = true;
                playerNames[i] = game.players[i].Name;
                playerIcons[i] = game.players[i].IconLocation;
            }
        }

        /// <summary>
        /// Changes the trump card by the deck to match the last card in the deck
        /// </summary>
        private void SetupTrump()
        {
            const string CardBackLocation = "../../../GUI_Images/Card_Back.png";
            const int TrumpX = 72;
            const int TrumpY = 15;

            // Resets the deck images and locations
            pbDeck.ImageLocation = CardBackLocation;
            pbDeck.Visible = true;
            pbTrumpCard.Location = new Point(TrumpX, TrumpY);
            pbTrumpCard.Visible = true;

            // Gets the trump card and turns it into a picturebox
            int deckLength = game.deck.cards.Count();
            Card trumpCard = game.deck.cards[deckLength - 1];

            // Set the trump card image
            pbTrumpCard.ImageLocation = trumpCard.ImageLocation;
        }

        /// <summary>
        /// Lets the player take the deck trump card if they have the 6 of trump
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PbTrumpCardClick(object sender, EventArgs e)
        {
            bool exchangeTrump = game.TakeTrumpCardFromDeck();
            if (exchangeTrump)
            {
                SetupTrump();
                DisplayHand();
                UpdateActionLog();
            };
        }

        /// <summary>
        /// Gets a players hand and displays it
        /// </summary>
        /// <param name="hand"></param>
        private void DisplayHand()
        {
            const int CardWidth = 80;
            const int CardY = 12;
            const int CardHover = 10;
            const int DefaultHandCount = 6;

            Player currentPlayer = game.players[game.turnIndex];
            List<Card> hand = currentPlayer.Hand;

            double spacePerCard = 0;
            double handCount = hand.Count;
            int cardXModifier = 92;
            int cardX = 12;

            // Clear the panel
            pnlHand.Controls.Clear();
            btnEndTurn.Enabled = false;
            pbTrumpCard.Enabled = false;

            if (currentPlayer.GetType() == game.typeHuman)
            {
                btnEndTurn.Enabled = true;
                pbTrumpCard.Enabled = true;

                // Calculate how much space should be between cards
                if (handCount > DefaultHandCount)
                {
                    spacePerCard = CardWidth / handCount;
                    cardXModifier = (int)(DefaultHandCount * spacePerCard);
                }

                // Create a picturebox for each card in the list
                foreach (Card card in hand)
                {
                    card.X = cardX;
                    card.Y = CardY;
                    PictureBox cardPb = new PictureBox
                    {
                        // Remove card width and height from card class
                        Size = new Size(card.Width, card.Height),
                        Location = new Point(cardX, CardY),
                        ImageLocation = card.ImageLocation,
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };

                    // Adds click functions if a card can be played
                    // Disables it if it can't
                    if (CanPlayCard(card))
                    {
                        cardPb.Enabled = true;

                        // Add card click event
                        cardPb.Click += (sender, e) =>
                        {
                            // Add Functions from the Game class
                            // ckeck if the game ended
                            bool endGame = game.GameEnded();
                            if (!endGame)
                            {
                                currentPlayer.PlayCard2(card);
                                game.PlayCardToAttckOrDefendList(card);
                                game.DetermineDefenderAndAttackerIndex();
                                UpdatePlayerLocations();
                                DisplayHand();
                                DisplayTableTop();
                                DisplayTableBottom();
                                UpdateHandCounts();
                                UpdateDeckCount();
                                UpdateActionLog();
                            };

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
                    }
                    else
                    {
                        cardPb.Enabled = false;
                    }

                    pnlHand.Controls.Add(cardPb);
                    cardPb.BringToFront();

                    // Add to card x
                    cardX += cardXModifier;
                }
            }  
        }

        /// <summary>
        /// Gets the attacking cards and displays them in the top table panel
        /// </summary>
        /// <param name="hand"></param>
        private void DisplayTableTop()
        {
            const int CardY = 12;
            List<Card> hand = game.cardsAttack;
            double handCount = hand.Count;
            int cardXModifier = 92;
            int cardX = 12;

            // Clear the panel
            pnlTableTop.Controls.Clear();

            // Create a picturebox for each card in the list
            foreach (Card card in hand)
            {
                card.X = cardX;
                card.Y = CardY;
                PictureBox cardPb = new PictureBox
                {
                    // Remove card width and height from card class
                    Size = new Size(card.Width, card.Height),
                    Location = new Point(cardX, CardY),
                    ImageLocation = card.ImageLocation,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };

                pnlTableTop.Controls.Add(cardPb);
                cardPb.BringToFront();

                // Add to card x
                cardX += cardXModifier;
            }
        }

        /// <summary>
        /// Gets the attacking cards and displays them in the top table panel
        /// </summary>
        /// <param name="hand"></param>
        private void DisplayTableBottom()
        {
            const int CardY = 12;
            List<Card> hand = game.cardsDefend;
            double handCount = hand.Count;
            int cardXModifier = 92;
            int cardX = 12;

            // Clear the panel
            pnlTableBottom.Controls.Clear();

            // Create a picturebox for each card in the list
            foreach (Card card in hand)
            {
                card.X = cardX;
                card.Y = CardY;
                PictureBox cardPb = new PictureBox
                {
                    // Remove card width and height from card class
                    Size = new Size(card.Width, card.Height),
                    Location = new Point(cardX, CardY),
                    ImageLocation = card.ImageLocation,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };

                pnlTableBottom.Controls.Add(cardPb);
                cardPb.BringToFront();

                // Add to card x
                cardX += cardXModifier;
            }
        }

        /// <summary>
        /// Updates the player names and icons on the game screen
        /// </summary>
        private void UpdatePlayerLocations()
        {
            List<Label> playerGameNames = new List<Label>();
            List<PictureBox> playerGameIcons = new List<PictureBox>();
            List<PictureBox> playerRoleIcons = new List<PictureBox>();
            const string RoleLocation = "../../../GUI_Images/";
            List<String> roleIcons = new List<String>() { "DefenderIcon.png", "1stAttackerIcon.png", "2ndAttackerIcon.png", "3rdAttackerIcon.png", "BrokenDefenderIcon.png" };

            // Ensures that, depending on player number, names and icons are placed right
            if (numPlayers == 2)
            {
                playerGameNames.AddRange([lblPlayer1NameG, lblPlayer2NameG]);
                playerGameIcons.AddRange([pbPlayer1IconG, pbPlayer2IconG]);
                playerRoleIcons.AddRange([pbPlayer1Role, pbPlayer2Role]);
            }
            else 
            {
                playerGameNames.AddRange([lblPlayer1NameG, lblPlayer3NameG, lblPlayer2NameG, lblPlayer4NameG]);
                playerGameIcons.AddRange([pbPlayer1IconG, pbPlayer3IconG, pbPlayer2IconG, pbPlayer4IconG]);
                playerRoleIcons.AddRange([pbPlayer1Role, pbPlayer3Role, pbPlayer2Role, pbPlayer4Role]);
            }

            // Places players on the screen starting based on the current players turn
            int turnIndex = game.turnIndex;

            for (int i = 0; i < numPlayers; i++)
            {
                if ((turnIndex) > numPlayers - 1)
                {
                    turnIndex -= numPlayers;
                }
                Console.WriteLine(game.defenderIndex);
                Console.WriteLine(game.attackerIndex);
                playerGameNames[i].Text = game.players[turnIndex].Name;
                playerGameIcons[i].ImageLocation = game.players[turnIndex].IconLocation;

                // Figures out the players role and sets their icon
                if (turnIndex == game.defenderIndex)
                {
                    playerRoleIcons[i].ImageLocation = RoleLocation + roleIcons[0];
                }
                else if (turnIndex == game.attackerIndex)
                {
                    playerRoleIcons[i].ImageLocation = RoleLocation + roleIcons[1];
                }
                else if (numPlayers > 2 && turnIndex == game.defenderIndex + 1 || turnIndex == ((game.defenderIndex + 1) - numPlayers))
                {
                    playerRoleIcons[i].ImageLocation = RoleLocation + roleIcons[2];
                }
                else if (numPlayers > 3 && turnIndex == game.defenderIndex + 2 || turnIndex == ((game.defenderIndex + 2) - numPlayers))
                {
                    playerRoleIcons[i].ImageLocation = RoleLocation + roleIcons[3];
                }
                

                //if (!game.players[i].CanAttack)
                //{
                //    playerRoleIcons[i].ImageLocation = RoleLocation + roleIcons[4];
                //}

                turnIndex += 1;
            }
        }

        /// <summary>
        /// Disables the cards in the players hand depending on if they can be played
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        private bool CanPlayCard(Card card)
        {
            bool canPlay = true;
            bool defenderIndex = game.defenderIndex == game.turnIndex;

            // Checks if the player is defender or not
            if (defenderIndex)
            {
                int lastCardIndex = game.cardsAttack.Count() - 1;

                // Ensures there has been a card played as an attack
                if (lastCardIndex >= 0)
                {
                    // Gets the last card attacked with and checks if the current
                    //  card can defend against it
                    Card lastAttackedCard = game.cardsAttack[lastCardIndex];
                    if (!game.CanDefendWithThisCard(card, lastAttackedCard))
                    {
                        canPlay = false;
                    }
                }
            }
            else
            {
                // Checks if an attack has been made and if the current card
                //  can be used to attack again
                if (game.cardsAttack.Count() != 0 & (!game.CanAttackWithThisCard(card)))
                {
                    canPlay = false;
                }
            }
            return canPlay;
        }

        /// <summary>
        /// Updates player hand counts
        /// </summary>
        private void UpdateHandCounts()
        {
            List<Label> playerHandCounts = new List<Label>() { lblPlayer1Cards, lblPlayer2Cards, lblPlayer3Cards, lblPlayer4Cards };
            for (int i = 0; i < game.players.Count(); i++)
            {
                playerHandCounts[i].Text = (game.players[i].Hand.Count()).ToString();
            }
        }

        /// <summary>
        /// Updates the deck count and deck cards depending on card count
        /// </summary>
        private void UpdateDeckCount()
        {
            const string TrumpSuitLocation = "../../../GUI_Images/Trump";
            const string PngString = ".png";
            int deckCount = game.deck.cards.Count();
            lblDeckCount.Text = deckCount.ToString();

            // Updates deck look when there's 0 or 1 cards remaining
            if (deckCount == 1)
            {
                pbDeck.Visible = false;
                pbTrumpCard.Location = pbDeck.Location;
            }
            else if (deckCount == 0)
            {
                pbDeck.Visible = true;
                pbTrumpCard.Visible = false;
                pbDeck.ImageLocation = TrumpSuitLocation + game.trump + PngString;
            }
        }

        /// <summary>
        /// Updates the action log for what happened in the round
        /// </summary>
        private void UpdateActionLog()
        {
            tbActionLog.Lines = game.actionLog.ToArray();
        }

        /// <summary>
        /// Passes the current turn as long as an attack has been made
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEndTurnClick(object sender, EventArgs e)
        {
            // Checks if at least 1 card has been played before allowing the pass
            if (game.cardsAttack.Count() != 0)
            {
                game.Pass();
                UpdateActionLog();
                DisplayTableTop();
                DisplayTableBottom();
            }
        }

        /// <summary>
        /// Resets the game board panels
        /// </summary>
        private void ResetGameBoard()
        {
            pnlHand.Controls.Clear();
            pnlTableTop.Controls.Clear();
            pnlTableBottom.Controls.Clear();
        }

        
    }
}
