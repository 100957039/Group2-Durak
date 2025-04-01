namespace DurakCardGame
{
    partial class SimpleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            buttonStartGame = new Button();
            button3 = new Button();
            panelDefend = new Panel();
            panelAttack = new Panel();
            panelHand = new Panel();
            textBoxDefenderIndex = new TextBox();
            textBoxttackerIndex = new TextBox();
            textBoxTurn = new TextBox();
            textBoxTrump = new TextBox();
            buttonPlayedCards = new Button();
            textBoxDeckNumber = new TextBox();
            textBoxWinners = new TextBox();
            buttonPass = new Button();
            button2 = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(174, 12);
            button1.Name = "button1";
            button1.Size = new Size(73, 23);
            button1.TabIndex = 0;
            button1.Text = "Turns";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // buttonStartGame
            // 
            buttonStartGame.Location = new Point(660, 12);
            buttonStartGame.Name = "buttonStartGame";
            buttonStartGame.Size = new Size(124, 23);
            buttonStartGame.TabIndex = 1;
            buttonStartGame.Text = "start/restart";
            buttonStartGame.UseVisualStyleBackColor = true;
            buttonStartGame.Click += buttonStartGame_Click;
            // 
            // button3
            // 
            button3.Location = new Point(434, 12);
            button3.Name = "button3";
            button3.Size = new Size(97, 23);
            button3.TabIndex = 2;
            button3.Text = "All Hands";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // panelDefend
            // 
            panelDefend.Location = new Point(718, 76);
            panelDefend.Name = "panelDefend";
            panelDefend.Size = new Size(575, 139);
            panelDefend.TabIndex = 3;
            // 
            // panelAttack
            // 
            panelAttack.Location = new Point(718, 232);
            panelAttack.Name = "panelAttack";
            panelAttack.Size = new Size(575, 133);
            panelAttack.TabIndex = 4;
            // 
            // panelHand
            // 
            panelHand.Location = new Point(15, 493);
            panelHand.Name = "panelHand";
            panelHand.Size = new Size(899, 126);
            panelHand.TabIndex = 5;
            // 
            // textBoxDefenderIndex
            // 
            textBoxDefenderIndex.Location = new Point(718, 415);
            textBoxDefenderIndex.Name = "textBoxDefenderIndex";
            textBoxDefenderIndex.Size = new Size(155, 23);
            textBoxDefenderIndex.TabIndex = 6;
            // 
            // textBoxttackerIndex
            // 
            textBoxttackerIndex.Location = new Point(718, 386);
            textBoxttackerIndex.Name = "textBoxttackerIndex";
            textBoxttackerIndex.Size = new Size(155, 23);
            textBoxttackerIndex.TabIndex = 7;
            // 
            // textBoxTurn
            // 
            textBoxTurn.Location = new Point(884, 415);
            textBoxTurn.Name = "textBoxTurn";
            textBoxTurn.Size = new Size(188, 23);
            textBoxTurn.TabIndex = 8;
            // 
            // textBoxTrump
            // 
            textBoxTrump.Location = new Point(884, 386);
            textBoxTrump.Name = "textBoxTrump";
            textBoxTrump.Size = new Size(188, 23);
            textBoxTrump.TabIndex = 9;
            // 
            // buttonPlayedCards
            // 
            buttonPlayedCards.Location = new Point(291, 12);
            buttonPlayedCards.Name = "buttonPlayedCards";
            buttonPlayedCards.Size = new Size(113, 23);
            buttonPlayedCards.TabIndex = 10;
            buttonPlayedCards.Text = "Played Cards";
            buttonPlayedCards.UseVisualStyleBackColor = true;
            buttonPlayedCards.Click += buttonPlayedCards_Click;
            // 
            // textBoxDeckNumber
            // 
            textBoxDeckNumber.Location = new Point(997, 444);
            textBoxDeckNumber.Name = "textBoxDeckNumber";
            textBoxDeckNumber.Size = new Size(100, 23);
            textBoxDeckNumber.TabIndex = 11;
            // 
            // textBoxWinners
            // 
            textBoxWinners.Location = new Point(718, 444);
            textBoxWinners.Name = "textBoxWinners";
            textBoxWinners.Size = new Size(267, 23);
            textBoxWinners.TabIndex = 12;
            // 
            // buttonPass
            // 
            buttonPass.Location = new Point(997, 504);
            buttonPass.Name = "buttonPass";
            buttonPass.Size = new Size(75, 23);
            buttonPass.TabIndex = 13;
            buttonPass.Text = "Pass";
            buttonPass.UseVisualStyleBackColor = true;
            buttonPass.Click += buttonPass_Click;
            // 
            // button2
            // 
            button2.Location = new Point(977, 544);
            button2.Name = "button2";
            button2.Size = new Size(95, 23);
            button2.TabIndex = 14;
            button2.Text = "switch trump";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // panel1
            // 
            panel1.Location = new Point(15, 41);
            panel1.Name = "panel1";
            panel1.Size = new Size(685, 132);
            panel1.TabIndex = 15;
            // 
            // panel2
            // 
            panel2.Location = new Point(15, 189);
            panel2.Name = "panel2";
            panel2.Size = new Size(682, 130);
            panel2.TabIndex = 16;
            // 
            // panel3
            // 
            panel3.Location = new Point(13, 332);
            panel3.Name = "panel3";
            panel3.Size = new Size(684, 135);
            panel3.TabIndex = 17;
            // 
            // SimpleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1317, 631);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(button2);
            Controls.Add(buttonPass);
            Controls.Add(textBoxWinners);
            Controls.Add(textBoxDeckNumber);
            Controls.Add(buttonPlayedCards);
            Controls.Add(textBoxTrump);
            Controls.Add(textBoxTurn);
            Controls.Add(textBoxttackerIndex);
            Controls.Add(textBoxDefenderIndex);
            Controls.Add(panelHand);
            Controls.Add(panelAttack);
            Controls.Add(panelDefend);
            Controls.Add(button3);
            Controls.Add(buttonStartGame);
            Controls.Add(button1);
            Name = "SimpleForm";
            Text = "SimpleForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button buttonStartGame;
        private Button button3;
        private Panel panelDefend;
        private Panel panelAttack;
        private Panel panelHand;
        private TextBox textBoxDefenderIndex;
        private TextBox textBoxttackerIndex;
        private TextBox textBoxTurn;
        private TextBox textBoxTrump;
        private Button buttonPlayedCards;
        private TextBox textBoxDeckNumber;
        private TextBox textBoxWinners;
        private Button buttonPass;
        private Button button2;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
    }
}