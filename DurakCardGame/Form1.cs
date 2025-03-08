using System.Security.Cryptography.X509Certificates;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace DurakCardGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();

        }
        int x = 0;
        int y = 0;
        Game game = new Game();
        List<Panel> panels;
        List<String> playersName;


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new Card object
            //Card imgBtn = new Card("Hearts", "5", 5, 150 + y, 600 + x);
            //Card imgBtn = new Card("Hearts", "5", 5, y, x);

            // Update y-coordinate for spacing
            y += 20;

            // Create the button from the Card object
            //Button cardButton = imgBtn.CreateCardButton();
            //Button cardButton2 = imgBtn.CreateCardButton();

            // Add the button to the form
            //panelOpponent.Controls.Add(cardButton);
            //cardButton.BringToFront();
            //panelCurrentPlayer.Controls.Add(cardButton2);
            //cardButton2.BringToFront();
            //this.Controls.Add(cardButton);

            // Bring the button to the front


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RefreshPanels()
        {
            panelCurrentPlayer.Refresh();
            panelTwo.Refresh();
            panelPlayGroundAttack.Refresh();
            //panelPlayGroundDefend.Refresh();
        }

        private void FillHand()
        {
            game.fillHand();
            RefreshPanels();
        }

        private bool ValidatePlayer()
        {
            if (textBoxPlayerOne.Text.Trim() == "" || textBoxPlayerTwo.Text.Trim() == ""
                || textBoxPlayerThree.Text.Trim() == "" || textBoxPLayerFour.Text.Trim() == "")
            {
                MessageBox.Show("Please enter player names");
                return false;
            }
            else
            {
                if (textBoxPlayerOne.Text.Trim() != "")
                {
                    panels.Add(panelCurrentPlayer);
                    playersName.Add(textBoxPlayerOne.Text);
                }
                if (textBoxPlayerTwo.Text.Trim() != "")
                {
                    panels.Add(panelOne);
                    playersName.Add(textBoxPlayerTwo.Text);
                }
                if (textBoxPlayerThree.Text.Trim() != "")
                {
                    panels.Add(panelTwo);
                    playersName.Add(textBoxPlayerThree.Text);
                }
                if (textBoxPLayerFour.Text.Trim() != "")
                {
                    panels.Add(panelThree);
                    playersName.Add(textBoxPLayerFour.Text);
                }
                return true;
            }
        }

        private void OnGameStart(object sender, EventArgs e)
        {
            //ValidatePlayer();
            List<Panel> panels = [panelCurrentPlayer, panelOne, panelTwo, panelThree];
            List<String> pls =  new List<string>();
            if (textBoxPlayerOne.Text != "")
            {
                pls.Add(textBoxPlayerOne.Text);
            }
            if (textBoxPlayerTwo.Text != "")
            {
                pls.Add(textBoxPlayerTwo.Text);
            }
            if (textBoxPlayerThree.Text != "")
            {
                pls.Add(textBoxPlayerThree.Text);
            }
            if (textBoxPLayerFour.Text != "")
            {
                pls.Add(textBoxPLayerFour.Text);
            }

            String playerOneName = textBoxPlayerOne.Text;
            //String playerTwoName = textBoxPlayerTwo.Text;
            //Deck deck = new Deck();
            //deck.Shuffle();
            for (int i = 0; i < pls.Count(); i++)
            {
                String playerName = pls[i];
                game.addPlayer(playerName);
                game.startGame();
                int x = 0;
                foreach (Card card in game.GetPlayer(i).Hand)
                {
                    card.X = x;
                    Button cardButton = card.CreateCardButton();
                    cardButton.Click += (sender, e) =>
                    {
                        // Assuming you have the player's turn logic handled
                        game.playCard(game.GetPlayer(0).Hand.IndexOf(card));  // This gets the index of the clicked card
                        cardButton.Enabled = false;  // Disable button once card is played
                                                     // Add the card to the played cards panel
                        panelPlayGroundAttack.Controls.Add(cardButton);
                    };
                    cardButton.Location = new Point(x, 0);
                    panels[i].Controls.Add(cardButton);
                    cardButton.BringToFront();
                    x += 75;
                }
                x = 0;

            }
            //foreach (Card card in game.GetPlayer(1).Hand)
            //{
            //    card.X = x;
            //    Button cardButton = card.CreateCardButton();
            //    cardButton.Location = new Point(x, 0);
            //    panelTwo.Controls.Add(cardButton);
            //    cardButton.BringToFront();
            //    x += 75;
            //}

            textBoxCountDeckCards.Text = game.deck.Count().ToString();
            textBoxTrump.Text = game.trump;
            // to be deleted, safe to deleted, referenced only here in this block
            String namesOrder = game.chooseFirstAttacker();
            // show order of attack
            textBoxOrderNames.Text = namesOrder;
            // display the trump card 
            panelDeck.Controls.Add(game.deck.cards[game.deck.Count() - 1].CreateCardButton());
            // to be deleted
        }

        private void buttonFillHand_Click(object sender, EventArgs e)
        {
            FillHand();
            foreach (Player player in game.players)
            {
                foreach (Card card in player.Hand)
                {
                    Button cardButton = card.CreateCardButton();
                    panelCurrentPlayer.Controls.Add(cardButton);
                    cardButton.BringToFront();
                }
            }
            RefreshPanels();
            textBoxCountDeckCards.Text = game.deck.Count().ToString();
        }

        private void panelTwo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void player1Cards_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            game.fillHand();
            textBoxCountDeckCards.Text = game.deck.Count().ToString();
        }
    }
}
