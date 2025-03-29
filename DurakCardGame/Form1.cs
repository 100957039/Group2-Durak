namespace DurakCardGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();

        }
        // defender index to pass card to once lost
        int defenderIndexToPassCards = -1;
        int x = 0;
        int y = 0;
        Game game = new Game();
        List<Panel> panels = new List<Panel>();
        List<String> playersName;


        

        

        private void RefreshPanels()
        {
            //panelCurrentPlayer.Refresh();
            panelTwo.Controls.Clear();
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


        private void OnGameStart(object sender, EventArgs e)
        {
            //ValidatePlayer();
            //List<Panel> panels = [panelCurrentPlayer, panelOne, panelTwo, panelThree];
            panels.Add(panelCurrentPlayer);
            panels.Add(panelOne);
            panels.Add(panelTwo);
            panels.Add(panelThree);


            List<String> pls = new List<string>();
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
                //game.addPlayer(playerName);
                game.startGame();
                int x = 0;
                //////here
                ///    ref from $$$$$$$ GROK AI $$$$$$$
                InitializePlayerCards(game, playerIndex, differenceBetweenAttackerDefender, ref x);
                //////here
            }


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

        private void InitializePlayerCards(Game game, int playerIndex, int differenceBetweenAttackerDefender, ref int x)
        {
            foreach (Card card in game.GetPlayer(playerIndex).Hand)
            {
                card.X = x;

                Button cardButton = card.CreateCardButton();

                cardButton.Click += (sender, e) =>
                {
                    bool isDefender = game.AttackerQueue.ToArray()[1].Name.Equals(game.GetPlayer(playerIndex).Name);

                    if (isDefender)
                    {
                        //global variable to store defender index, to pass card after attack is done
                        defenderIndexToPassCards = playerIndex;
                        if (game.players[game.turn].Name == game.players[playerIndex].Name)
                        {
                            Player defender = game.players[playerIndex];
                            Card attackerCard = game.played[0];

                            Console.WriteLine(game.canStillDefend(defender.Hand, attackerCard));
                            if (game.canStillDefend(defender.Hand, attackerCard))
                            {
                                Console.WriteLine(game.canStillDefend(defender.Hand, attackerCard));
                                Console.WriteLine("If worked.  Can still defend");

                                if (game.played.Count() == 1)
                                {
                                    bool sucDef = game.defendAttack(attackerCard, card);
                                    if (sucDef)
                                    {
                                        cardButton.Enabled = false;
                                        // discard and store it in a list
                                        //when the defender losses, takes all the cards and add them to his hand
                                        game.playedCards.Add(card);
                                        //remove from defender's hand
                                        game.players[playerIndex].Hand.Remove(card);
                                        Console.WriteLine("defenderHand: " + game.players[playerIndex].Hand.Count());

                                        cardButton.Location = new Point(game.DefenderXAxis, cardButton.Location.Y);
                                        card.X = cardButton.Location.X;
                                        panelPlayGroundDefense.Controls.Add(cardButton);
                                        game.DefenderXAxis += 75;

                                        int attackerIndex = playerIndex - differenceBetweenAttackerDefender;
                                        if (attackerIndex < 0)
                                        {
                                            attackerIndex = (game.players.Count() + attackerIndex);
                                            attackerIndex = Math.Abs(attackerIndex);
                                        }
                                        game.turn = attackerIndex;
                                        game.allowedRankAttack.Add(card.Rank);



                                        game.played.Add(card);
                                        game.played.Clear();
                                    }


                                    Console.WriteLine("defenece: " + sucDef);
                                }
                                bool nextRound = game.canStillDefend(defender.Hand, attackerCard);
                                if (!nextRound)
                                {
                                    //// add cards to the loser, but not working because it's either if or else not both. it should be add to next round button
                                    //foreach (Card card in game.playedCards)
                                    //{
                                    //    game.players[playerIndex].Hand.Add(card);
                                    //}
                                    Console.WriteLine("game.players[playerIndex].Hand.Count(): " + game.players[playerIndex].Hand.Count());

                                    buttonNextRound.Enabled = true;
                                }
                            } 
                            else
                            {
                                Console.WriteLine("Else worked.");
                                buttonNextRound.Enabled = true;
                            }
                        }
                    }
                    else
                    {
                        // allow attack if the player has cards that he can play
                        bool canAttack = false;
                        for (int i = 0; i < game.allowedRankAttack.Count(); i++)
                        {
                            if (game.allowedRankAttack[i] == card.Rank)
                            {
                                canAttack = true;
                                if (game.players[game.turn].Name == game.players[playerIndex].Name)
                                {
                                    //add card to played card, if attacker wins, loser takes all the cards
                                    game.playedCards.Add(card);
                                    // remove from the attackers hand
                                    game.players[playerIndex].Hand.Remove(card);
                                    Console.WriteLine("attckerHand: " + game.players[playerIndex].Hand.Count());

                                    cardButton.Enabled = false;
                                    //
                                    Console.WriteLine("attacker: " + game.players[playerIndex].Hand.Count());
                                    cardButton.Location = new Point(game.AttackerXAxis, cardButton.Location.Y);
                                    card.X = cardButton.Location.X;
                                    panelPlayGroundAttack.Controls.Add(cardButton);

                                    game.played.Add(card);

                                    game.AttackerXAxis += 75;
                                    int defenderIndex = playerIndex + differenceBetweenAttackerDefender;

                                    if (defenderIndex >= game.players.Count())
                                    {
                                        defenderIndex = Math.Abs(game.players.Count() - defenderIndex);
                                    }
                                    game.turn = defenderIndex;

                                    bool nextRound = game.canStillAttack(game.players[playerIndex].Hand);
                                    if (nextRound)
                                    {
                                        buttonNextRound.Enabled = true;
                                    }
                                }
                            }
                        }
                        if (canAttack)
                        {
                            game.allowedRankAttack.Add(card.Rank);
                            Console.WriteLine("            ");
                            Console.WriteLine("can attack");
                        }

                        // allow attack if no card has been played yet
                        if (game.allowedRankAttack.Count() == 0)
                        {
                            if (game.players[game.turn].Name == game.players[playerIndex].Name)
                            {
                                //add card to played card, if attacker wins, loser takes all the cards
                                game.playedCards.Add(card);
                                // remove from the attackers hand
                                game.players[playerIndex].Hand.Remove(card);
                                cardButton.Enabled = false;
                                Console.WriteLine("attacker: " + game.players[playerIndex].Hand.Count());
                                cardButton.Location = new Point(game.AttackerXAxis, cardButton.Location.Y);
                                card.X = cardButton.Location.X;
                                panelPlayGroundAttack.Controls.Add(cardButton);

                                game.played.Add(card);

                                game.AttackerXAxis += 75;
                                int defenderIndex = playerIndex + differenceBetweenAttackerDefender;

                                if (defenderIndex >= game.players.Count())
                                {
                                    defenderIndex = Math.Abs(game.players.Count() - defenderIndex);
                                }
                                game.turn = defenderIndex;
                            }
                            game.allowedRankAttack.Add(card.Rank);
                            //Console.WriteLine("can attack");
                        }
                    }
                    Console.WriteLine("game turn: " + game.turn);
                };

                if (game.players.Count() != 2)
                {
                    cardButton.Location = new Point(x, 0);
                    panels[playerIndex].Controls.Add(cardButton);
                    cardButton.BringToFront();
                }
                else
                {
                    if (playerIndex == 1)
                    {
                        cardButton.Location = new Point(x, 0);
                        panels[playerIndex + 1].Controls.Add(cardButton);
                    }
                    else
                    {
                        cardButton.Location = new Point(x, 0);
                        panels[playerIndex].Controls.Add(cardButton);
                    }
                }

                x += 75;
            }
        }

        private void fill_hand_works(object sender, EventArgs e)
        {
            FillHand();
            int differenceBetweenAttackerDefender = 1;

            for (int playerIndex = 0; playerIndex < game.players.Count(); playerIndex++)
            {
                int x = 0;

                //////here
                ///    ref from $$$$$$$ GROK AI $$$$$$$
                InitializePlayerCards(game, playerIndex, differenceBetweenAttackerDefender, ref x);
                //////here
            }


            textBoxCountDeckCards.Text = game.deck.Count().ToString();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            game.fillHand();
            textBoxCountDeckCards.Text = game.deck.Count().ToString();
        }


        // go to next round: 1- add cards to loser, 2- delete cards from game.playedCard
        private void buttonNextRound_Click(object sender, EventArgs e)
        {
            // add cards to the loser, but not working because it's either if or else not both. it should be add to next round button
            foreach (Card card in game.playedCards)
            {
                game.players[defenderIndexToPassCards].Hand.Add(card);
            }
            // clear list of the played cards in game class
            game.playedCards.Clear();

            foreach (Player player in game.players)
            {
                Console.WriteLine(player.Name + " : " + player.Hand.Count());
            }

            
            FillHand();
            int differenceBetweenAttackerDefender = 1;

            for (int playerIndex = 0; playerIndex < game.players.Count(); playerIndex++)
            {
                int x = 0;

                //////here
                ///    ref from $$$$$$$ GROK AI $$$$$$$
                InitializePlayerCards(game, playerIndex, differenceBetweenAttackerDefender, ref x);
                //////here
            }

            textBoxCountDeckCards.Text = game.deck.Count().ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (Player player in game.players)
            {
                Console.WriteLine(player.Name + " : " + player.Hand.Count());
            }
            Console.WriteLine("game.played cards count: " + game.playedCards.Count());
        }
    }
}
