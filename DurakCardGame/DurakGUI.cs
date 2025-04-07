using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
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
        int optionTCT = 0;
        int[] iconPage = { 0, 0, 0, 0 };
        string difficulty = "easy";
        List<Player> resultList = new List<Player>();

        // Game variable
        GameLogic game = new GameLogic();

        public DurakGUI()
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
        /// Moves to Credits from Main Menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCreditsClick(object sender, EventArgs e)
        {
            pnlMainMenu.Visible = false;
            pnlCredits.Visible = true;
            pnlCredits.BringToFront();
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


        //*******************************************************************************************************************************************************
        // Options
        //*******************************************************************************************************************************************************

        /// <summary>
        /// Enables trump card trading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RbTCTEnableClick(object sender, EventArgs e)
        {
            optionTCT = 0;
        }

        /// <summary>
        /// Disables trump card trading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RbTCTDisableClick(object sender, EventArgs e)
        {
            optionTCT = 1;
        }

        /// <summary>
        /// Enables trump card trading for Ace only
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RbTCTAceClick(object sender, EventArgs e)
        {
            optionTCT = 2;
        }

        /// <summary>
        /// Opens the rules to the page explaining trump trading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTrumpTradeHelp(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Moves to Main Menu from Options
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBackOClick(object sender, EventArgs e)
        {
            pnlOptions.Visible = false;
            pnlCredits.Visible = false;
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

            if (valid != -1 && valid != -2 && IconValidation())
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
            else if (valid == -2)
            {
                DialogResult dialogResult = MessageBox.Show("Player names must be unique.", "Error", MessageBoxButtons.OK);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("All players must select an icon.", "Error", MessageBoxButtons.OK);
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
            int[] IconLocationY = { 13, 13, 13, 69, 69, 69 };
            List<PictureBox> iconList = new List<PictureBox>();
            const string IconLocation = "../../../GUI_Images/HumanIcons/";
            string[] icons = ["Astronaut1.jpg", "Astronaut2.jpg", "Astronaut3.jpg", "Astronaut4.jpg", "Cat1.jpg", "Cat2.jpg",
                              "Cat3.jpg", "Clown1.jpg", "Clown2.jpg", "Diver1.jpg", "Diver2.jpg", "Diver3.jpg", "Diver4.jpg",
                              "Dog1.jpg", "Dog2.jpg", "Dog3.jpg", "Dog4.jpg", "Dog5.jpg", "Flamingo.jpg", "Fred.jpg", "King1.jpg",
                              "King2.jpg", "King3.jpg", "King4.jpg", "King5.jpg", "King6.jpg", "Man1.jpg", "Man2.jpg", "Man3.jpg",
                              "Man4.jpg", "Man5.jpg", "Man6.jpg", "Man7.jpg", "Man8.jpg", "Man9.jpg", "Man10.jpg", "Man11.jpg",
                              "Man12.jpg","Man13.jpg", "Man14.jpg", "Man15.jpg", "Man16.jpg", "Man17.jpg", "Man18.jpg", "Man19.jpg",
                              "Man20.jpg", "Man21.jpg", "Man22.jpg", "Man23.jpg", "Man24.jpg", "Man25.jpg", "Man26.jpg", "Man27.jpg",
                              "Man28.jpg", "Mask1.jpg", "Mask2.jpg", "Mask3.jpg", "Mask4.jpg", "Penguin.jpg", "Penguin2.jpg", "Queen1.jpg",
                              "Queen2.jpg", "Queen3.jpg", "Queen4.jpg", "Queen5.jpg", "Queen6.jpg", "Queen7.jpg", "Seal1.jpg", "Seal2.jpg",
                              "Skull1.jpg", "Skull2.jpg", "Skull3.jpg", "Woman1.jpg", "Woman2.jpg", "Woman3.jpg", "Woman4.jpg", "Woman5.jpg",
                              "Woman6.jpg", "Woman7.jpg", "Woman8.jpg", "Woman9.jpg", "Woman10.jpg", "Woman11.jpg", "Woman12.jpg", "Woman13.jpg",
                              "Woman14.jpg", "Woman15.jpg", "Woman16.jpg", "Woman17.jpg", "Woman18.jpg", "Woman19.jpg", "Woman20.jpg",
                              "Woman21.jpg", "Woman22.jpg", "Woman23.jpg", "Woman24.jpg", "Woman25.jpg", "Woman26.jpg", "Woman27.jpg",
                              "Woman28.jpg", "Woman29.jpg","Woman30.jpg", "Woman31.jpg", "Woman32.jpg"];

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
            for (int i = 0; i < numPlayers - numAi; i++)
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
        /// Ensures that all players have selected an icon
        /// </summary>
        /// <returns></returns>
        private bool IconValidation()
        {
            bool valid = true;
            List<String> selectedIcon = new List<String> { pbPlayer1SelectedIcon.ImageLocation, pbPlayer2SelectedIcon.ImageLocation, pbPlayer3SelectedIcon.ImageLocation, pbPlayer4SelectedIcon.ImageLocation };
            for (int i = 0; i < numPlayers - numAi; i++)
            {
                if (string.IsNullOrWhiteSpace(selectedIcon[i]))
                {
                    valid = false;
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
            DialogResult dialogResult = MessageBox.Show("Exit to Main Menu?" + Environment.NewLine + "(Game will not be saved)", "Exit to Menu", MessageBoxButtons.OKCancel);

            if (dialogResult == DialogResult.OK)
            {
                pnlGame.Visible = false;
                pnlMainMenu.Visible = true;
                pnlMainMenu.BringToFront();
            }
        }

        /// <summary>
        /// Starts a new game and sets up the game screen
        /// </summary>
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
            UpdateHandCounts();
            UpdateDeckCount();
            NextPlayerMessageBox();
            DisplayHand();
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
                game.addComputer(difficulty, playerNames);
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
            const string CardBackLocation = "../../../GUI_Images/DeckImages/Card_Back.png";
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
        /// Lets the player take the deck trump card if option is enabled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PbTrumpCardClick(object sender, EventArgs e)
        {
            if (optionTCT == 0)
            {
                bool exchangeTrump = game.TakeTrumpCardFromDeck();
                if (exchangeTrump)
                {
                    SetupTrump();
                    DisplayHand();
                    UpdateActionLog();
                };
            }
            else if (optionTCT == 2)
            {
                bool exchangeTrump = game.TakeTrumpAceFromDeck();
                if (exchangeTrump)
                {
                    SetupTrump();
                    DisplayHand();
                    UpdateActionLog();
                };
            }
        }

        /// <summary>
        /// Displays a message box for when multiple human players are player to give players time to hide their cards
        /// </summary>
        private void NextPlayerMessageBox()
        {
            pnlHand.Controls.Clear();
            Player player = game.players[game.turnIndex];

            if (player.GetType() == game.typeHuman && (numPlayers - numAi) > 1)
            {
                DialogResult dialogResult = MessageBox.Show(player.Name + " is up next."+ Environment.NewLine +"Hide the screen from the other players.", player.Name + "'s Turn", MessageBoxButtons.OK);
            }
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
                                DisplayTableTop();
                                DisplayTableBottom();
                                UpdateHandCounts();
                                UpdateDeckCount();
                                UpdateActionLog();
                                NextPlayerMessageBox();
                                DisplayHand();
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
            else
            {
                ComputersTurn();
            }

            // Checks if the game is over
            IsGameEnded();
        }

        /// <summary>
        /// Gets the attacking cards and displays them in the top table panel
        /// </summary>
        /// <param name="hand"></param>
        private void DisplayTableTop()
        {
            const int CardWidth = 80;
            const int CardY = 12;
            const int DefaultHandCount = 6;

            List<Card> hand = game.cardsAttack;

            double spacePerCard = 0;
            double handCount = hand.Count;
            int cardXModifier = 92;
            int cardX = 12;

            // Clear the panel
            pnlTableTop.Controls.Clear();

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
        /// Lets the computer play a card
        /// </summary>
        private async void ComputersTurn()
        {
            const int sleep = 1500;
            UpdatePlayerLocations();
            DisplayTableTop();
            DisplayTableBottom();
            UpdateHandCounts();
            UpdateDeckCount();
            UpdateActionLog();
            await Task.Delay(sleep);
            game.ComputerPlayCard();
            DisplayTableTop();
            DisplayTableBottom();
            UpdateActionLog();
            await Task.Delay(sleep);
            UpdateHandCounts();
            UpdatePlayerLocations();
            UpdateDeckCount();
            NextPlayerMessageBox();
            DisplayHand();
        }

        /// <summary>
        /// Updates the player names and icons on the game screen
        /// </summary>
        private void UpdatePlayerLocations()
        {
            List<Label> playerGameNames = new List<Label>();
            List<PictureBox> playerGameIcons = new List<PictureBox>();
            List<PictureBox> playerRoleIcons = new List<PictureBox>();
            const string RoleLocation = "../../../GUI_Images/RoleIcons/";
            List<String> roleIcons = new List<String>() { "DefenderIcon.png", "1stAttackerIcon.png", "2ndAttackerIcon.png", "3rdAttackerIcon.png", "BrokenDefenderIcon.png", "WinnerIcon.png" };

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
                playerGameNames[i].Text = game.players[turnIndex].Name;
                playerGameIcons[i].ImageLocation = game.players[turnIndex].IconLocation;

                int handCount = game.players[turnIndex].Hand.Count();

                // Figures out the players role and sets their icon
                if (handCount == 0 && game.deck.cards.Count() == 0)
                {
                    playerRoleIcons[i].ImageLocation = RoleLocation + roleIcons[5];
                }
                else if (!game.players[turnIndex].CanAttack)
                {
                    playerRoleIcons[i].ImageLocation = RoleLocation + roleIcons[4];

                    // Checks if there's 4 players and changes 3rd attacker icon to 2nd attacker icon
                    if (game.players.Count() > 3 && i - 1 >= 0)
                    {
                        playerRoleIcons[i - 1].ImageLocation = RoleLocation + roleIcons[2];
                    }
                    else if (game.players.Count() > 3)
                    {
                        playerRoleIcons[(i - 1) + game.players.Count()].ImageLocation = RoleLocation + roleIcons[2];
                    }
                }
                else if (turnIndex == game.defenderIndex)
                {
                    playerRoleIcons[i].ImageLocation = RoleLocation + roleIcons[0];
                }
                else if (turnIndex == game.defenderIndex - 1 || turnIndex == ((game.defenderIndex - 1) + numPlayers))
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

                turnIndex += 1;
            }
        }

        /// <summary>
        /// Updates player hand counts
        /// </summary>
        private void UpdateHandCounts()
        {
            List<Label> playerHandCounts = new List<Label>();

            // Ensures that, depending on player number, card counts are placed right
            if (numPlayers == 2)
            {
                playerHandCounts.AddRange([lblPlayer1Cards, lblPlayer2Cards]);
            }
            else
            {
                playerHandCounts.AddRange([lblPlayer1Cards, lblPlayer3Cards, lblPlayer2Cards, lblPlayer4Cards]);
            }

            // Checks where each player is before updating card count
            int turnIndex = game.turnIndex;

            for (int i = 0; i < numPlayers; i++)
            {
                if ((turnIndex) > numPlayers - 1)
                {
                    turnIndex -= numPlayers;
                }
                playerHandCounts[i].Text = (game.players[turnIndex].Hand.Count()).ToString();
                turnIndex++;
            }
        }

        /// <summary>
        /// Updates the deck count and deck cards depending on card count
        /// </summary>
        private void UpdateDeckCount()
        {
            const string TrumpSuitLocation = "../../../GUI_Images/DeckImages/Trump";
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
            tbActionLog.SelectionStart = tbActionLog.Text.Length;
            tbActionLog.ScrollToCaret();
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
                UpdatePlayerLocations();
                DisplayTableTop();
                DisplayTableBottom();
                UpdateHandCounts();
                UpdateDeckCount();
                UpdateActionLog();
                NextPlayerMessageBox();
                DisplayHand();
            }
        }

        /// <summary>
        /// Checks if the games ended and displays the game result
        /// </summary>
        /// <returns></returns>
        private void IsGameEnded()
        {
            if (game.GameEnded())
            {
                string result =
                    "--------------------------------" + Environment.NewLine +
                    "          GAME RESULTS          " + Environment.NewLine + 
                    "--------------------------------" + Environment.NewLine;
                List<string> places = new List<string>() { "1st: ", "2nd: ", "3rd: ", "4th: ", "DURAK: " };

                for (int i = 0; i < resultList.Count(); i++)
                {
                    if (resultList[i].Hand.Count() <= 0)
                    {
                        result += places[i] + resultList[i].Name + Environment.NewLine;
                    }
                    else
                    {
                        result += places[4] + resultList[i].Name;
                    }
                }
                
                result += Environment.NewLine + Environment.NewLine + " Play again?";
                DialogResult dialogResult = MessageBox.Show(result, "Game Results", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    GameSetup();
                }
                else
                {
                    pnlGame.Visible = false;
                    pnlMainMenu.Visible = true;
                    pnlMainMenu.BringToFront();
                }
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
