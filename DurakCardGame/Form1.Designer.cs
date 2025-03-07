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
            components = new System.ComponentModel.Container();
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
            textBoxTrump = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
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
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(880, 114);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // button1
            // 
            button1.Location = new Point(765, 74);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(82, 22);
            button1.TabIndex = 11;
            button1.Text = "Reset";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // buttonStartGame
            // 
            buttonStartGame.Location = new Point(645, 73);
            buttonStartGame.Name = "buttonStartGame";
            buttonStartGame.Size = new Size(79, 23);
            buttonStartGame.TabIndex = 10;
            buttonStartGame.Text = "Start";
            buttonStartGame.UseVisualStyleBackColor = true;
            buttonStartGame.Click += OnGameStart;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(663, 24);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 9;
            label5.Text = "Difficulty";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Easy", "Medium", "Hard" });
            comboBox1.Location = new Point(753, 19);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 8;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // textBoxPLayerFour
            // 
            textBoxPLayerFour.Location = new Point(402, 62);
            textBoxPLayerFour.Name = "textBoxPLayerFour";
            textBoxPLayerFour.Size = new Size(185, 23);
            textBoxPLayerFour.TabIndex = 7;
            // 
            // textBoxPlayerThree
            // 
            textBoxPlayerThree.Location = new Point(402, 16);
            textBoxPlayerThree.Name = "textBoxPlayerThree";
            textBoxPlayerThree.Size = new Size(185, 23);
            textBoxPlayerThree.TabIndex = 6;
            // 
            // textBoxPlayerTwo
            // 
            textBoxPlayerTwo.Location = new Point(92, 64);
            textBoxPlayerTwo.Name = "textBoxPlayerTwo";
            textBoxPlayerTwo.Size = new Size(174, 23);
            textBoxPlayerTwo.TabIndex = 5;
            // 
            // textBoxPlayerOne
            // 
            textBoxPlayerOne.Location = new Point(88, 16);
            textBoxPlayerOne.Name = "textBoxPlayerOne";
            textBoxPlayerOne.Size = new Size(178, 23);
            textBoxPlayerOne.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(319, 65);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 3;
            label4.Text = "PLayer 4";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(319, 19);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 2;
            label3.Text = "PLayer 3";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 65);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 1;
            label2.Text = "Player 2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 24);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 0;
            label1.Text = "Player 1";
            // 
            // richTextBox
            // 
            richTextBox.Location = new Point(926, 61);
            richTextBox.Name = "richTextBox";
            richTextBox.Size = new Size(161, 109);
            richTextBox.TabIndex = 2;
            richTextBox.Text = "";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(980, 28);
            label6.Name = "label6";
            label6.Size = new Size(44, 15);
            label6.TabIndex = 3;
            label6.Text = "Results";
            // 
            // button2
            // 
            button2.Location = new Point(292, 687);
            button2.Name = "button2";
            button2.Size = new Size(161, 23);
            button2.TabIndex = 4;
            button2.Text = "Pass (not willing to attack";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(567, 687);
            button3.Name = "button3";
            button3.Size = new Size(153, 23);
            button3.TabIndex = 5;
            button3.Text = "Cheat (show hand)";
            button3.UseVisualStyleBackColor = true;
            // 
            // panelCurrentPlayer
            // 
            panelCurrentPlayer.Location = new Point(163, 533);
            panelCurrentPlayer.Name = "panelCurrentPlayer";
            panelCurrentPlayer.Size = new Size(751, 148);
            panelCurrentPlayer.TabIndex = 7;
            // 
            // panelTwo
            // 
            panelTwo.Location = new Point(163, 132);
            panelTwo.Name = "panelTwo";
            panelTwo.Size = new Size(740, 146);
            panelTwo.TabIndex = 8;
            // 
            // panelPlayGroundAttack
            // 
            panelPlayGroundAttack.Location = new Point(163, 408);
            panelPlayGroundAttack.Name = "panelPlayGroundAttack";
            panelPlayGroundAttack.Size = new Size(740, 103);
            panelPlayGroundAttack.TabIndex = 9;
            // 
            // panelPlayGroundDefense
            // 
            panelPlayGroundDefense.Location = new Point(165, 291);
            panelPlayGroundDefense.Name = "panelPlayGroundDefense";
            panelPlayGroundDefense.Size = new Size(738, 100);
            panelPlayGroundDefense.TabIndex = 10;
            // 
            // buttonFillHand
            // 
            buttonFillHand.Location = new Point(777, 687);
            buttonFillHand.Name = "buttonFillHand";
            buttonFillHand.Size = new Size(75, 23);
            buttonFillHand.TabIndex = 11;
            buttonFillHand.Text = "Fill Hand";
            buttonFillHand.UseVisualStyleBackColor = true;
            buttonFillHand.Click += buttonFillHand_Click;
            // 
            // textBoxCountDeckCards
            // 
            textBoxCountDeckCards.Location = new Point(12, 147);
            textBoxCountDeckCards.Name = "textBoxCountDeckCards";
            textBoxCountDeckCards.Size = new Size(100, 23);
            textBoxCountDeckCards.TabIndex = 12;
            // 
            // panelOne
            // 
            panelOne.Location = new Point(19, 190);
            panelOne.Name = "panelOne";
            panelOne.Size = new Size(140, 321);
            panelOne.TabIndex = 13;
            // 
            // panelThree
            // 
            panelThree.Location = new Point(934, 188);
            panelThree.Name = "panelThree";
            panelThree.Size = new Size(200, 473);
            panelThree.TabIndex = 14;
            // 
            // textBoxTrump
            // 
            textBoxTrump.Location = new Point(1057, 32);
            textBoxTrump.Name = "textBoxTrump";
            textBoxTrump.Size = new Size(100, 23);
            textBoxTrump.TabIndex = 15;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 738);
            Controls.Add(textBoxTrump);
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
            Margin = new Padding(3, 2, 3, 2);
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
        private TextBox textBoxTrump;
        private ContextMenuStrip contextMenuStrip1;
    }
}
