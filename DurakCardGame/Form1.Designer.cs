namespace DurakCardGame
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        //comment
        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            button1 = new Button();
            buttonStartGame = new Button();
            label5 = new Label();
            comboBox1 = new ComboBox();
            textBoxPLayerFour = new TextBox();
            textBoxPlayerThree = new TextBox();
            textBoxPlayerTwo = new TextBox();
            textBoxPlayerOne = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            richTextBox = new RichTextBox();
            label6 = new Label();
            button2 = new Button();
            button3 = new Button();
            panelCurrentPlayer = new Panel();
            panelTwo = new Panel();
            panelPlayGroundAttack = new Panel();
            panelPlayGroundDefense = new Panel();
            buttonFillHand = new Button();
            textBoxCountDeckCards = new TextBox();
            panelOne = new Panel();
            panelThree = new Panel();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(buttonStartGame);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(textBoxPLayerFour);
            groupBox1.Controls.Add(textBoxPlayerThree);
            groupBox1.Controls.Add(textBoxPlayerTwo);
            groupBox1.Controls.Add(textBoxPlayerOne);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(14, 16);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(1006, 152);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // button1
            // 
            button1.Location = new Point(874, 98);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 11;
            button1.Text = "Reset";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // buttonStartGame
            // 
            buttonStartGame.Location = new Point(737, 97);
            buttonStartGame.Margin = new Padding(3, 4, 3, 4);
            buttonStartGame.Name = "buttonStartGame";
            buttonStartGame.Size = new Size(90, 31);
            buttonStartGame.TabIndex = 10;
            buttonStartGame.Text = "Start";
            buttonStartGame.UseVisualStyleBackColor = true;
            buttonStartGame.Click += OnGameStart;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(758, 32);
            label5.Name = "label5";
            label5.Size = new Size(69, 20);
            label5.TabIndex = 9;
            label5.Text = "Difficulty";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Easy", "Medium", "Hard" });
            comboBox1.Location = new Point(861, 25);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(138, 28);
            comboBox1.TabIndex = 8;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // textBoxPLayerFour
            // 
            textBoxPLayerFour.Location = new Point(459, 83);
            textBoxPLayerFour.Margin = new Padding(3, 4, 3, 4);
            textBoxPLayerFour.Name = "textBoxPLayerFour";
            textBoxPLayerFour.Size = new Size(211, 27);
            textBoxPLayerFour.TabIndex = 7;
            // 
            // textBoxPlayerThree
            // 
            textBoxPlayerThree.Location = new Point(459, 21);
            textBoxPlayerThree.Margin = new Padding(3, 4, 3, 4);
            textBoxPlayerThree.Name = "textBoxPlayerThree";
            textBoxPlayerThree.Size = new Size(211, 27);
            textBoxPlayerThree.TabIndex = 6;
            // 
            // textBoxPlayerTwo
            // 
            textBoxPlayerTwo.Location = new Point(105, 85);
            textBoxPlayerTwo.Margin = new Padding(3, 4, 3, 4);
            textBoxPlayerTwo.Name = "textBoxPlayerTwo";
            textBoxPlayerTwo.Size = new Size(198, 27);
            textBoxPlayerTwo.TabIndex = 5;
            // 
            // textBoxPlayerOne
            // 
            textBoxPlayerOne.Location = new Point(101, 21);
            textBoxPlayerOne.Margin = new Padding(3, 4, 3, 4);
            textBoxPlayerOne.Name = "textBoxPlayerOne";
            textBoxPlayerOne.Size = new Size(203, 27);
            textBoxPlayerOne.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(365, 87);
            label4.Name = "label4";
            label4.Size = new Size(64, 20);
            label4.TabIndex = 3;
            label4.Text = "PLayer 4";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(365, 25);
            label3.Name = "label3";
            label3.Size = new Size(64, 20);
            label3.TabIndex = 2;
            label3.Text = "PLayer 3";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 87);
            label2.Name = "label2";
            label2.Size = new Size(61, 20);
            label2.TabIndex = 1;
            label2.Text = "Player 2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 32);
            label1.Name = "label1";
            label1.Size = new Size(61, 20);
            label1.TabIndex = 0;
            label1.Text = "Player 1";
            // 
            // richTextBox
            // 
            richTextBox.Location = new Point(1058, 81);
            richTextBox.Margin = new Padding(3, 4, 3, 4);
            richTextBox.Name = "richTextBox";
            richTextBox.Size = new Size(183, 144);
            richTextBox.TabIndex = 2;
            richTextBox.Text = "";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1120, 37);
            label6.Name = "label6";
            label6.Size = new Size(55, 20);
            label6.TabIndex = 3;
            label6.Text = "Results";
            // 
            // button2
            // 
            button2.Location = new Point(334, 916);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(184, 31);
            button2.TabIndex = 4;
            button2.Text = "Pass (not willing to attack";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(648, 916);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(175, 31);
            button3.TabIndex = 5;
            button3.Text = "Cheat (show hand)";
            button3.UseVisualStyleBackColor = true;
            // 
            // panelCurrentPlayer
            // 
            panelCurrentPlayer.Location = new Point(186, 711);
            panelCurrentPlayer.Margin = new Padding(3, 4, 3, 4);
            panelCurrentPlayer.Name = "panelCurrentPlayer";
            panelCurrentPlayer.Size = new Size(858, 197);
            panelCurrentPlayer.TabIndex = 7;
            // 
            // panelTwo
            // 
            panelTwo.Location = new Point(186, 176);
            panelTwo.Margin = new Padding(3, 4, 3, 4);
            panelTwo.Name = "panelTwo";
            panelTwo.Size = new Size(846, 195);
            panelTwo.TabIndex = 8;
            // 
            // panelPlayGroundAttack
            // 
            panelPlayGroundAttack.Location = new Point(186, 544);
            panelPlayGroundAttack.Margin = new Padding(3, 4, 3, 4);
            panelPlayGroundAttack.Name = "panelPlayGroundAttack";
            panelPlayGroundAttack.Size = new Size(846, 137);
            panelPlayGroundAttack.TabIndex = 9;
            // 
            // panelPlayGroundDefense
            // 
            panelPlayGroundDefense.Location = new Point(189, 388);
            panelPlayGroundDefense.Margin = new Padding(3, 4, 3, 4);
            panelPlayGroundDefense.Name = "panelPlayGroundDefense";
            panelPlayGroundDefense.Size = new Size(843, 133);
            panelPlayGroundDefense.TabIndex = 10;
            // 
            // buttonFillHand
            // 
            buttonFillHand.Location = new Point(888, 916);
            buttonFillHand.Margin = new Padding(3, 4, 3, 4);
            buttonFillHand.Name = "buttonFillHand";
            buttonFillHand.Size = new Size(86, 31);
            buttonFillHand.TabIndex = 11;
            buttonFillHand.Text = "Fill Hand";
            buttonFillHand.UseVisualStyleBackColor = true;
            buttonFillHand.Click += buttonFillHand_Click;
            // 
            // textBoxCountDeckCards
            // 
            textBoxCountDeckCards.Location = new Point(14, 196);
            textBoxCountDeckCards.Margin = new Padding(3, 4, 3, 4);
            textBoxCountDeckCards.Name = "textBoxCountDeckCards";
            textBoxCountDeckCards.Size = new Size(114, 27);
            textBoxCountDeckCards.TabIndex = 12;
            // 
            // panelOne
            // 
            panelOne.Location = new Point(22, 253);
            panelOne.Margin = new Padding(3, 4, 3, 4);
            panelOne.Name = "panelOne";
            panelOne.Size = new Size(759, 428);
            panelOne.TabIndex = 13;
            // 
            // panelThree
            // 
            panelThree.Location = new Point(1067, 251);
            panelThree.Margin = new Padding(3, 4, 3, 4);
            panelThree.Name = "panelThree";
            panelThree.Size = new Size(229, 631);
            panelThree.TabIndex = 14;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1353, 960);
            Controls.Add(panelThree);
            Controls.Add(panelOne);
            Controls.Add(textBoxCountDeckCards);
            Controls.Add(buttonFillHand);
            Controls.Add(panelPlayGroundDefense);
            Controls.Add(panelPlayGroundAttack);
            Controls.Add(panelTwo);
            Controls.Add(panelCurrentPlayer);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label6);
            Controls.Add(richTextBox);
            Controls.Add(groupBox1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBox1;
        private ComboBox comboBox1;
        private TextBox textBoxPLayerFour;
        private TextBox textBoxPlayerThree;
        private TextBox textBoxPlayerTwo;
        private TextBox textBoxPlayerOne;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label5;
        private RichTextBox richTextBox;
        private Label label6;
        private Button button2;
        private Button button3;
        private Panel panelCurrentPlayer;
        private Panel panelTwo;
        private Button buttonStartGame;
        private Panel panelPlayGroundAttack;
        private Panel panelPlayGroundDefense;
        private Button buttonFillHand;
        private TextBox textBoxCountDeckCards;
        private Panel panelOne;
        private Panel panelThree;
        private Button button1;
    }
}
