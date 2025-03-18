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
        List<Panel> panels = new List<Panel>();
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
            //panelCurrentPlayer.Refresh();
            panelCurrentPlayer.Controls.Clear();
            panelTwo.Refresh();
            panelPlayGroundAttack.Refresh();
            //panelPlayGroundDefend.Refresh();
        }

        private void FillHand()
        {
            RefreshPanels();
            game.fillHand();
            //RefreshPanels();
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

        //disable hand

        //enable hand

        private void OnGameStart(object sender, EventArgs e)
        {
            //ValidatePlayer();
            //List<Panel> panels = [panelCurrentPlayer, panelOne, panelTwo, panelThree];
            panels.Add(panelCurrentPlayer);
            panels.Add(panelOne);
            panels.Add(panelTwo);
            panels.Add(panelThree);


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
            // ###################################################################################################################
            // ###################################### difference between attacker and defender ###################################
            // ###################################################################################################################
            // determine how will attack, how will defend (later move to Game.cs class)
            int differenceBetweenAttackerDefender = 1;

            for (int i = 0; i < pls.Count(); i++)
            {
                int playerIndex = i;
                String playerName = pls[i];
                game.addPlayer(playerName);
                game.startGame();
                int x = 0;

                //foreach (Player player in game.AttackerQueue)
                //{
                //    Console.WriteLine("form1.cs" + player.Name);
                //}

                foreach (Card card in game.GetPlayer(playerIndex).Hand)
                {
                    card.X = x;  

                    Button cardButton = card.CreateCardButton();
                    //Console.WriteLine(game.AttackerQueue.ToArray());
                    //if (!game.AttackerQueue[0].Name.Equals(game.GetPlayer(playerIndex).Name))
                    //{
                    //    cardButton.Enabled = false;
                    //}
                    cardButton.Click += (sender, e) =>
                    {
                        

                        // determine whether the player is attacker or defender
                        // in queue, index 0 is alway the attacker
                        // and index 1 is always the defender 
                        bool isDefender = game.AttackerQueue.ToArray()[1].Name.Equals(game.GetPlayer(playerIndex).Name);

                        // card's position when attack starts
                        // to defender panel
                        if (isDefender)
                        {
                            // ##########3not working as it should ###################
                            if (game.players[game.turn].Name == game.players[playerIndex].Name)
                            {
                                cardButton.Enabled = false;
                                cardButton.Location = new Point(game.DefenderXAxis, cardButton.Location.Y);
                                card.X = cardButton.Location.X;
                                panelPlayGroundDefense.Controls.Add(cardButton);
                                game.DefenderXAxis += 75;
                                // if the attacker is the last in the list, defender will be the first
                                int attackerIndex = playerIndex - differenceBetweenAttackerDefender;
                                Console.WriteLine("----------------------------------");
                                Console.WriteLine("attackerIndex: " + attackerIndex);
                                if (attackerIndex < 0)
                                {
                                    //Console.WriteLine("game.players.Count(): " + game.players.Count());
                                    //Console.WriteLine("(attackerIndex - game.players.Count()): " + (attackerIndex - game.players.Count()));
                                    attackerIndex = (game.players.Count() + attackerIndex);
                                    //Console.WriteLine("before absolute value Def: " + attackerIndex);
                                    attackerIndex = Math.Abs(attackerIndex);
                                    //Console.WriteLine("after absolute value Def: " + attackerIndex);
                                }
                                //Console.WriteLine("value Def: " + attackerIndex);
                                game.turn = attackerIndex;
                                game.allowedRankAttack.Add(card.Rank);
                            }

                            //###############################################################################################
                            //####################################### Defend attack #########################################
                            //###############################################################################################
                            // add card to compare it with attacker's card
                            game.played.Add(card);
                            Player defender = game.players[playerIndex];
                            Card attackerCard = game.played[0];
                            Console.WriteLine("game.canStillDefend" + game.canStillDefend(defender.Hand, attackerCard));
                            if (game.canStillDefend(defender.Hand, attackerCard))
                            {
                                Console.WriteLine("can still defend");
                                // == 2 means attacker and defender each played a card
                                if (game.played.Count() == 2)
                                {
                                    Card defenderCard = game.played[1];
                                    bool sucDef = game.defendAttack(attackerCard, defenderCard);
                                    Console.WriteLine("defenece: " + sucDef);
                                }
                            }


                            //###############################################################################################
                            //####################################### Defend attack #########################################
                            //###############################################################################################

                            //Console.WriteLine($"Defender X: {game.DefenderXAxis}");
                        }
                        // to attacker panel
                        else
                        {
                            bool canAttack = true;
                            foreach (int allowedRank in game.allowedRankAttack)
                            {
                                if (allowedRank == card.Rank)
                                {
                                    // #################################
                                    if (game.players[game.turn].Name == game.players[playerIndex].Name)
                                    {
                                        cardButton.Enabled = false;
                                        cardButton.Location = new Point(game.AttackerXAxis, cardButton.Location.Y);
                                        card.X = cardButton.Location.X;
                                        panelPlayGroundAttack.Controls.Add(cardButton);

                                        // add card to the list to compare it with the defender's card
                                        game.played.Add(card);

                                        Console.WriteLine("");
                                        //Console.WriteLine($"Attacker X: {game.AttackerXAxis}");
                                        //Console.WriteLine($"card X: {cardButton.Location.X}");
                                        game.AttackerXAxis += 75;
                                        int defenderIndex = playerIndex + differenceBetweenAttackerDefender;

                                        Console.WriteLine("----------------------------------");
                                        Console.WriteLine("index Att: " + defenderIndex);
                                        if (defenderIndex >= game.players.Count())
                                        {
                                            defenderIndex = Math.Abs(game.players.Count() - defenderIndex);
                                            Console.WriteLine("absolute value Att: " + (game.players.Count() - defenderIndex));
                                        }
                                        game.turn = defenderIndex;
                                    }
                                    // add rank to allowed
                                    game.allowedRankAttack.Add(card.Rank);
                                    Console.WriteLine("can attack");
                                    // #######################################
                                }
                            }

                            if (game.allowedRankAttack.Count() == 0)
                            {
                                // #################################
                                if (game.players[game.turn].Name == game.players[playerIndex].Name)
                                {
                                    cardButton.Enabled = false;
                                    cardButton.Location = new Point(game.AttackerXAxis, cardButton.Location.Y);
                                    card.X = cardButton.Location.X;
                                    panelPlayGroundAttack.Controls.Add(cardButton);

                                    // add card to the list to compare it with the defender's card
                                    game.played.Add(card);

                                    Console.WriteLine("");
                                    //Console.WriteLine($"Attacker X: {game.AttackerXAxis}");
                                    //Console.WriteLine($"card X: {cardButton.Location.X}");
                                    game.AttackerXAxis += 75;
                                    int defenderIndex = playerIndex + differenceBetweenAttackerDefender;

                                    Console.WriteLine("----------------------------------");
                                    Console.WriteLine("index Att: " + defenderIndex);
                                    if (defenderIndex >= game.players.Count())
                                    {
                                        defenderIndex = Math.Abs(game.players.Count() - defenderIndex);
                                        Console.WriteLine("absolute value Att: " + (game.players.Count() - defenderIndex));
                                    }
                                    game.turn = defenderIndex;
                                }
                                // add rank to allowed
                                game.allowedRankAttack.Add(card.Rank);
                                Console.WriteLine("can attack");
                                // #######################################
                            }

                        }
                        Console.WriteLine("game turn: " + game.turn);
                        //game.AttackerQueue.RemoveAt(0);
                        //foreach (Card card in game.AttackerQueue[playerIndex+2].Hand) {
                        //    Console.WriteLine(card.Value);
                        //    cardButton.Enabled = true;
                        //}
                    };

                    //disable hand

                    //enable hand

                    // Set initial position for each card
                    // just for positioning the players if we have only two
                    //Console.WriteLine(pls.Count());
                    if (pls.Count() != 2)
                    {
                        //Console.WriteLine("not two");
                        
                        cardButton.Location = new Point(x, 0);
                        panels[playerIndex].Controls.Add(cardButton);
                        cardButton.BringToFront();
                    }
                    // just for positioning the players if we have only two
                    else
                    {
                        //checked if it's the second player, assign the play to panel 3
                        if (playerIndex == 1)
                        {
                            cardButton.Location = new Point(x, 0);
                            panels[playerIndex + 1].Controls.Add(cardButton);
                        }
                        else
                        {
                            //cardButton.BringToFront();
                            cardButton.Location = new Point(x, 0);
                            panels[playerIndex].Controls.Add(cardButton);
                        }
                        
                    }

                    // Update x for the next card's position
                    //String namesOrder = game.chooseFirstAttacker();
                    //textBoxOrderNames.Text = namesOrder;
                    x += 75;
                }
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
            //Console.WriteLine(namesOrder);
            textBoxOrderNames.Text = namesOrder;
            // display the trump card 
            panelDeck.Controls.Add(game.deck.cards[game.deck.Count() - 1].CreateCardButton());
            // to be deleted
        }

        private void buttonFillHand_Click(object sender, EventArgs e)
        {
            FillHand();
            //foreach (Player player in game.players)
            for (int i = 0; i < game.players.Count(); i++) 
            {
                int x = 0;
                foreach (Card card in game.players[i].Hand)
                {
                    card.X = x;
                    Button cardButton = card.CreateCardButton();
                    cardButton.Click += (sender, e) =>
                    {
                        // Assuming you have the player's turn logic handled
                        game.playCard(i, game.GetPlayer(i).Hand.IndexOf(card));  // This gets the index of the clicked card
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
            //int panelIndex = 0;
            //foreach (Player player in game.players)
            //{
            //    foreach (Card card in player.Hand)
            //    {
            //        Button cardButton = card.CreateCardButton();
            //        panels[panelIndex].Controls.Add(cardButton);
            //        cardButton.BringToFront();
            //    }
            //    panelIndex++;
            //}
            //RefreshPanels();
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
