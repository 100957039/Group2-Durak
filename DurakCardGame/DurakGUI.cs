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
 * On the DurakGUI Form go View -> Other Windows -> Document Outline
 *  or hit CTRL + ALT + T.
 */

namespace DurakCardGame
{
    public partial class DurakGUI : Form
    {
        // Variables
        int numPlayers = 2;
        int numAI = 1;
        int[] iconPage = { 0, 0, 0, 0 };

        // Game variable
        GameLogic game = new GameLogic();

        public DurakGUI()
        {
            InitializeComponent();
            BtnConfirmNClick(null, null);
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
        /// 
        /// </summary>
        private void SetupCustomization()
        {
            if (numPlayers == 2 && numAI == 1 || numPlayers == 3 && numAI == 2 || numPlayers == 4 && numAI == 3)
            {
                gbPlayer2Customize.Visible = false;
                gbPlayer3Customize.Visible = false;
                gbPlayer4Customize.Visible = false;
            }
            else if (numPlayers == 2 && numAI == 0 || numPlayers == 3 && numAI == 1 || numPlayers == 4 && numAI == 2)
            {
                gbPlayer2Customize.Visible = true;
                gbPlayer3Customize.Visible = false;
                gbPlayer4Customize.Visible = false;
            }
            else if (numPlayers == 3 && numAI == 0 || numPlayers == 4 && numAI == 1)
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
            //ShowIcons();
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
            iconPage[0] = 0;
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
            iconPage[0] = 0;
            GameSetup();
        }

        /// <summary>
        /// Displays the icons players can choose on the customization page
        /// (Not priority so will continue later)
        /// </summary>
        private void ShowIcons()
        {
            const int IconsPerPage = 6;
            const int iconSize = 50;
            int[] iconLocationX = { 34, 90, 146 };
            int[] iconLocationY = { 13, 69 };
            List<Player> playerList = new List<Player>();
            List<PictureBox> iconList = new List<PictureBox>();
            List<PictureBox> pbList = new List<PictureBox>() { pbPlayer1SelectedIcon, pbPlayer2SelectedIcon, pbPlayer3SelectedIcon, pbPlayer4SelectedIcon };
            List<Panel> panelList = new List<Panel>() { pnlPlayer1IconSelect, pnlPlayer2IconSelect, pnlPlayer3IconSelect, pnlPlayer4IconSelect };
            const String iconLocation = "../../../GUI_Images/Icons/";
            String[] icons = ["Acorn_Boy.jpg", "Beard_Man.jpg", "Inventor.jpg", "Queen.jpg", "Skull_Man.jpg", "Surprise.jpg", "Robot_Knight.jpg"];

            // Clear all the icon panels
            for (int f = 0; f < pbList.Count; f++)
            {
                panelList[f].Controls.Clear();
            }

            // Set the players in the list
            for (int g = 0; g < numPlayers - 1; g++)
            {
                playerList.Add(game.players[g]);
            }

            int index = (IconsPerPage * iconPage[0]);

            for (int h = 0; h < numPlayers; h++)
            {
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

                        iconList[i + j].Click += (sender, e) =>
                        {
                            playerList[h].IconPath = iconList[i + j].ImageLocation;
                            pbList[h].ImageLocation = iconLocation;
                        };

                        panelList[h].Controls.Add(iconList[i +j]);
                    }
                }  
            }
        }

        private void nameValidation()
        {

        }


        //*******************************************************************************************************************************************************
        // Game
        //*******************************************************************************************************************************************************

        /// <summary>
        /// 
        /// </summary>
        private void SetupPlayers()
        {

            List<String> playersList = new List<String> { "1", "2", "3", "4" };
            foreach (String player in playersList)
            {
                game.addPlayer(player);
            }
        }
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
            const int defaultHandCount = 6;

            Player currentPlayer = game.players[game.turnIndex];
            List<Card> hand = currentPlayer.Hand;

            double spacePerCard = 0;
            double handCount = hand.Count;
            int cardXModifier = 92;
            int cardX = 12;

            // Clear the panel
            pnlHand.Controls.Clear();

            // Calculate how much space should be between cards
            if (handCount > defaultHandCount)
            {
                spacePerCard = CardWidth / handCount;
                cardXModifier = (int)(defaultHandCount * spacePerCard);
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
                        DisplayTableTop();
                        DisplayTableBottom();
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

                pnlHand.Controls.Add(cardPb);
                cardPb.BringToFront();

                // Add to card x
                cardX += cardXModifier;
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

                pnlTableBottom.Controls.Add(cardPb);
                cardPb.BringToFront();

                // Add to card x
                cardX += cardXModifier;
            }
        }
    }
}
