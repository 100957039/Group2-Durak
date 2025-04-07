namespace DurakCardGame
{
    partial class RulesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RulesForm));
            btnLeft = new Button();
            btnRight = new Button();
            lblRules = new Label();
            btnRules = new Button();
            pnlRules = new Panel();
            pnlPage3 = new Panel();
            lblPlayerHand = new Label();
            lblTrumpCard = new Label();
            pbPage3Deck = new PictureBox();
            pbPage3Hand = new PictureBox();
            lblPage3Text = new Label();
            btnPage3TextBg = new Button();
            btnPage3DeckBg = new Button();
            pnlPage1 = new Panel();
            pbCard6H = new PictureBox();
            pbCard7H = new PictureBox();
            pbCard8H = new PictureBox();
            pbCard9H = new PictureBox();
            pbCard10H = new PictureBox();
            pbCardJH = new PictureBox();
            pbCardQH = new PictureBox();
            pbCardKH = new PictureBox();
            pbCardAH = new PictureBox();
            lblPage1Text = new Label();
            btnPage1TextBg = new Button();
            pnlPage2 = new Panel();
            pb1stAttacker = new PictureBox();
            btn1stAttackerBg = new Button();
            lbl1stAttacker = new Label();
            pb2ndAttacker = new PictureBox();
            btn2ndAttackerBg = new Button();
            lbl2ndAttacker = new Label();
            pb3rdAttacker = new PictureBox();
            btn3rdAttackerBg = new Button();
            lbl3rdAttacker = new Label();
            pbWinner = new PictureBox();
            btnWinnerBg = new Button();
            lblWinner = new Label();
            pbDefender = new PictureBox();
            btnDefenderBg = new Button();
            lblDefender = new Label();
            pbBrokenDefender = new PictureBox();
            btnBrokenDefenderBg = new Button();
            lblBrokenDefender = new Label();
            lblPage2Text = new Label();
            btnPage2TextBg = new Button();
            btnRulesBg = new Button();
            pnlPage4 = new Panel();
            lblPage4Text = new Label();
            btnPage4TextBg = new Button();
            pnlRules.SuspendLayout();
            pnlPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPage3Deck).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPage3Hand).BeginInit();
            pnlPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbCard6H).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbCard7H).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbCard8H).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbCard9H).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbCard10H).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbCardJH).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbCardQH).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbCardKH).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbCardAH).BeginInit();
            pnlPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb1stAttacker).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb2ndAttacker).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb3rdAttacker).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbWinner).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbDefender).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBrokenDefender).BeginInit();
            pnlPage4.SuspendLayout();
            SuspendLayout();
            // 
            // btnLeft
            // 
            btnLeft.BackColor = SystemColors.ActiveCaptionText;
            btnLeft.Font = new Font("Copperplate Gothic Bold", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLeft.ForeColor = SystemColors.ButtonHighlight;
            btnLeft.Location = new Point(20, 284);
            btnLeft.Name = "btnLeft";
            btnLeft.Size = new Size(40, 74);
            btnLeft.TabIndex = 1;
            btnLeft.Text = "&<";
            btnLeft.UseVisualStyleBackColor = false;
            btnLeft.Click += BtnLeftClick;
            // 
            // btnRight
            // 
            btnRight.BackColor = SystemColors.ActiveCaptionText;
            btnRight.Font = new Font("Copperplate Gothic Bold", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRight.ForeColor = SystemColors.ButtonHighlight;
            btnRight.Location = new Point(722, 284);
            btnRight.Name = "btnRight";
            btnRight.Size = new Size(40, 74);
            btnRight.TabIndex = 0;
            btnRight.Text = "&>";
            btnRight.UseVisualStyleBackColor = false;
            btnRight.Click += BtnRightClick;
            // 
            // lblRules
            // 
            lblRules.AutoSize = true;
            lblRules.BackColor = SystemColors.ActiveCaptionText;
            lblRules.Font = new Font("Castellar", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRules.ForeColor = SystemColors.ButtonHighlight;
            lblRules.Location = new Point(300, 18);
            lblRules.Name = "lblRules";
            lblRules.Size = new Size(181, 57);
            lblRules.TabIndex = 2;
            lblRules.Text = "Rules";
            // 
            // btnRules
            // 
            btnRules.BackColor = Color.Black;
            btnRules.Enabled = false;
            btnRules.FlatAppearance.BorderSize = 6;
            btnRules.FlatStyle = FlatStyle.Flat;
            btnRules.Font = new Font("Castellar", 72F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRules.ForeColor = Color.White;
            btnRules.Location = new Point(294, 10);
            btnRules.Name = "btnRules";
            btnRules.Size = new Size(193, 70);
            btnRules.TabIndex = 3;
            btnRules.UseVisualStyleBackColor = false;
            // 
            // pnlRules
            // 
            pnlRules.BackColor = Color.Transparent;
            pnlRules.Controls.Add(lblRules);
            pnlRules.Controls.Add(btnRules);
            pnlRules.Controls.Add(btnLeft);
            pnlRules.Controls.Add(btnRight);
            pnlRules.Controls.Add(pnlPage4);
            pnlRules.Controls.Add(pnlPage1);
            pnlRules.Controls.Add(pnlPage2);
            pnlRules.Controls.Add(pnlPage3);
            pnlRules.Controls.Add(btnRulesBg);
            pnlRules.Location = new Point(0, 0);
            pnlRules.Name = "pnlRules";
            pnlRules.Size = new Size(782, 590);
            pnlRules.TabIndex = 0;
            // 
            // pnlPage3
            // 
            pnlPage3.BackColor = Color.Black;
            pnlPage3.Controls.Add(pbPage3Deck);
            pnlPage3.Controls.Add(btnPage3DeckBg);
            pnlPage3.Controls.Add(lblTrumpCard);
            pnlPage3.Controls.Add(lblPlayerHand);
            pnlPage3.Controls.Add(pbPage3Hand);
            pnlPage3.Controls.Add(lblPage3Text);
            pnlPage3.Controls.Add(btnPage3TextBg);
            pnlPage3.Location = new Point(72, 92);
            pnlPage3.Name = "pnlPage3";
            pnlPage3.Size = new Size(638, 458);
            pnlPage3.TabIndex = 72;
            pnlPage3.Visible = false;
            // 
            // lblPlayerHand
            // 
            lblPlayerHand.AutoSize = true;
            lblPlayerHand.Font = new Font("Copperplate Gothic Light", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPlayerHand.ForeColor = Color.White;
            lblPlayerHand.Location = new Point(247, 111);
            lblPlayerHand.Name = "lblPlayerHand";
            lblPlayerHand.Size = new Size(144, 42);
            lblPlayerHand.TabIndex = 16;
            lblPlayerHand.Text = "Player Hand\r\n            V";
            // 
            // lblTrumpCard
            // 
            lblTrumpCard.AutoSize = true;
            lblTrumpCard.Font = new Font("Copperplate Gothic Light", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTrumpCard.ForeColor = Color.White;
            lblTrumpCard.Location = new Point(186, 69);
            lblTrumpCard.Name = "lblTrumpCard";
            lblTrumpCard.Size = new Size(164, 21);
            lblTrumpCard.TabIndex = 15;
            lblTrumpCard.Text = "<--- Trump Card";
            // 
            // pbPage3Deck
            // 
            pbPage3Deck.ImageLocation = "../../../GUI_Images/RulesImages/RulesDeck.png";
            pbPage3Deck.Location = new Point(46, 30);
            pbPage3Deck.Name = "pbPage3Deck";
            pbPage3Deck.Size = new Size(130, 116);
            pbPage3Deck.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPage3Deck.TabIndex = 13;
            pbPage3Deck.TabStop = false;
            // 
            // pbPage3Hand
            // 
            pbPage3Hand.ImageLocation = "../../../GUI_Images/RulesImages/RulesHand.png";
            pbPage3Hand.Location = new Point(39, 160);
            pbPage3Hand.Name = "pbPage3Hand";
            pbPage3Hand.Size = new Size(560, 130);
            pbPage3Hand.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPage3Hand.TabIndex = 12;
            pbPage3Hand.TabStop = false;
            // 
            // lblPage3Text
            // 
            lblPage3Text.AutoSize = true;
            lblPage3Text.Font = new Font("Copperplate Gothic Light", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPage3Text.ForeColor = Color.White;
            lblPage3Text.Location = new Point(28, 313);
            lblPage3Text.Name = "lblPage3Text";
            lblPage3Text.Size = new Size(516, 105);
            lblPage3Text.TabIndex = 11;
            lblPage3Text.Text = "At game start, each player is dealt 6 cards.\r\n\r\nThe player with the lowest trump card starts.\r\n\r\nThe trump suit is shown in the top left corner.";
            // 
            // btnPage3TextBg
            // 
            btnPage3TextBg.BackColor = Color.Black;
            btnPage3TextBg.Enabled = false;
            btnPage3TextBg.FlatAppearance.BorderSize = 3;
            btnPage3TextBg.FlatStyle = FlatStyle.Flat;
            btnPage3TextBg.Font = new Font("Castellar", 72F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPage3TextBg.ForeColor = Color.White;
            btnPage3TextBg.Location = new Point(19, 300);
            btnPage3TextBg.Name = "btnPage3TextBg";
            btnPage3TextBg.Size = new Size(600, 142);
            btnPage3TextBg.TabIndex = 10;
            btnPage3TextBg.UseVisualStyleBackColor = false;
            // 
            // btnPage3DeckBg
            // 
            btnPage3DeckBg.BackColor = Color.Black;
            btnPage3DeckBg.Enabled = false;
            btnPage3DeckBg.FlatAppearance.BorderSize = 4;
            btnPage3DeckBg.FlatStyle = FlatStyle.Flat;
            btnPage3DeckBg.Font = new Font("Castellar", 72F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPage3DeckBg.ForeColor = Color.White;
            btnPage3DeckBg.Location = new Point(42, 26);
            btnPage3DeckBg.Name = "btnPage3DeckBg";
            btnPage3DeckBg.Size = new Size(138, 124);
            btnPage3DeckBg.TabIndex = 14;
            btnPage3DeckBg.UseVisualStyleBackColor = false;
            // 
            // pnlPage1
            // 
            pnlPage1.BackColor = Color.Black;
            pnlPage1.Controls.Add(pbCard6H);
            pnlPage1.Controls.Add(pbCard7H);
            pnlPage1.Controls.Add(pbCard8H);
            pnlPage1.Controls.Add(pbCard9H);
            pnlPage1.Controls.Add(pbCard10H);
            pnlPage1.Controls.Add(pbCardJH);
            pnlPage1.Controls.Add(pbCardQH);
            pnlPage1.Controls.Add(pbCardKH);
            pnlPage1.Controls.Add(pbCardAH);
            pnlPage1.Controls.Add(lblPage1Text);
            pnlPage1.Controls.Add(btnPage1TextBg);
            pnlPage1.Location = new Point(72, 92);
            pnlPage1.Name = "pnlPage1";
            pnlPage1.Size = new Size(638, 458);
            pnlPage1.TabIndex = 5;
            // 
            // pbCard6H
            // 
            pbCard6H.ImageLocation = "../../../GUI_Images/cards/6H.png";
            pbCard6H.Location = new Point(91, 24);
            pbCard6H.Name = "pbCard6H";
            pbCard6H.Size = new Size(80, 122);
            pbCard6H.SizeMode = PictureBoxSizeMode.StretchImage;
            pbCard6H.TabIndex = 0;
            pbCard6H.TabStop = false;
            // 
            // pbCard7H
            // 
            pbCard7H.ImageLocation = "../../../GUI_Images/cards/7H.png";
            pbCard7H.Location = new Point(185, 24);
            pbCard7H.Name = "pbCard7H";
            pbCard7H.Size = new Size(80, 122);
            pbCard7H.SizeMode = PictureBoxSizeMode.StretchImage;
            pbCard7H.TabIndex = 1;
            pbCard7H.TabStop = false;
            // 
            // pbCard8H
            // 
            pbCard8H.ImageLocation = "../../../GUI_Images/cards/8H.png";
            pbCard8H.Location = new Point(279, 24);
            pbCard8H.Name = "pbCard8H";
            pbCard8H.Size = new Size(80, 122);
            pbCard8H.SizeMode = PictureBoxSizeMode.StretchImage;
            pbCard8H.TabIndex = 2;
            pbCard8H.TabStop = false;
            // 
            // pbCard9H
            // 
            pbCard9H.ImageLocation = "../../../GUI_Images/cards/9H.png";
            pbCard9H.Location = new Point(373, 24);
            pbCard9H.Name = "pbCard9H";
            pbCard9H.Size = new Size(80, 122);
            pbCard9H.SizeMode = PictureBoxSizeMode.StretchImage;
            pbCard9H.TabIndex = 4;
            pbCard9H.TabStop = false;
            // 
            // pbCard10H
            // 
            pbCard10H.ImageLocation = "../../../GUI_Images/cards/10H.png";
            pbCard10H.Location = new Point(467, 24);
            pbCard10H.Name = "pbCard10H";
            pbCard10H.Size = new Size(80, 122);
            pbCard10H.SizeMode = PictureBoxSizeMode.StretchImage;
            pbCard10H.TabIndex = 5;
            pbCard10H.TabStop = false;
            // 
            // pbCardJH
            // 
            pbCardJH.ImageLocation = "../../../GUI_Images/cards/JH.png";
            pbCardJH.Location = new Point(137, 156);
            pbCardJH.Name = "pbCardJH";
            pbCardJH.Size = new Size(80, 122);
            pbCardJH.SizeMode = PictureBoxSizeMode.StretchImage;
            pbCardJH.TabIndex = 8;
            pbCardJH.TabStop = false;
            // 
            // pbCardQH
            // 
            pbCardQH.ImageLocation = "../../../GUI_Images/cards/QH.png";
            pbCardQH.Location = new Point(232, 156);
            pbCardQH.Name = "pbCardQH";
            pbCardQH.Size = new Size(80, 122);
            pbCardQH.SizeMode = PictureBoxSizeMode.StretchImage;
            pbCardQH.TabIndex = 7;
            pbCardQH.TabStop = false;
            // 
            // pbCardKH
            // 
            pbCardKH.ImageLocation = "../../../GUI_Images/cards/KH.png";
            pbCardKH.Location = new Point(326, 156);
            pbCardKH.Name = "pbCardKH";
            pbCardKH.Size = new Size(80, 122);
            pbCardKH.SizeMode = PictureBoxSizeMode.StretchImage;
            pbCardKH.TabIndex = 6;
            pbCardKH.TabStop = false;
            // 
            // pbCardAH
            // 
            pbCardAH.ImageLocation = "../../../GUI_Images/cards/AH.png";
            pbCardAH.Location = new Point(421, 156);
            pbCardAH.Name = "pbCardAH";
            pbCardAH.Size = new Size(80, 122);
            pbCardAH.SizeMode = PictureBoxSizeMode.StretchImage;
            pbCardAH.TabIndex = 3;
            pbCardAH.TabStop = false;
            // 
            // lblPage1Text
            // 
            lblPage1Text.AutoSize = true;
            lblPage1Text.Font = new Font("Copperplate Gothic Light", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPage1Text.ForeColor = Color.White;
            lblPage1Text.Location = new Point(28, 313);
            lblPage1Text.Name = "lblPage1Text";
            lblPage1Text.Size = new Size(475, 63);
            lblPage1Text.TabIndex = 11;
            lblPage1Text.Text = "Durak is a game played with 2-4 players.\r\n\r\nThe deck uses 36 cards, 6-10, J, Q, K, and A.";
            // 
            // btnPage1TextBg
            // 
            btnPage1TextBg.BackColor = Color.Black;
            btnPage1TextBg.Enabled = false;
            btnPage1TextBg.FlatAppearance.BorderSize = 3;
            btnPage1TextBg.FlatStyle = FlatStyle.Flat;
            btnPage1TextBg.Font = new Font("Castellar", 72F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPage1TextBg.ForeColor = Color.White;
            btnPage1TextBg.Location = new Point(19, 300);
            btnPage1TextBg.Name = "btnPage1TextBg";
            btnPage1TextBg.Size = new Size(600, 106);
            btnPage1TextBg.TabIndex = 10;
            btnPage1TextBg.UseVisualStyleBackColor = false;
            // 
            // pnlPage2
            // 
            pnlPage2.BackColor = Color.Black;
            pnlPage2.Controls.Add(pb1stAttacker);
            pnlPage2.Controls.Add(btn1stAttackerBg);
            pnlPage2.Controls.Add(lbl1stAttacker);
            pnlPage2.Controls.Add(pb2ndAttacker);
            pnlPage2.Controls.Add(btn2ndAttackerBg);
            pnlPage2.Controls.Add(lbl2ndAttacker);
            pnlPage2.Controls.Add(pb3rdAttacker);
            pnlPage2.Controls.Add(btn3rdAttackerBg);
            pnlPage2.Controls.Add(lbl3rdAttacker);
            pnlPage2.Controls.Add(pbWinner);
            pnlPage2.Controls.Add(btnWinnerBg);
            pnlPage2.Controls.Add(lblWinner);
            pnlPage2.Controls.Add(pbDefender);
            pnlPage2.Controls.Add(btnDefenderBg);
            pnlPage2.Controls.Add(lblDefender);
            pnlPage2.Controls.Add(pbBrokenDefender);
            pnlPage2.Controls.Add(btnBrokenDefenderBg);
            pnlPage2.Controls.Add(lblBrokenDefender);
            pnlPage2.Controls.Add(lblPage2Text);
            pnlPage2.Controls.Add(btnPage2TextBg);
            pnlPage2.Location = new Point(72, 92);
            pnlPage2.Name = "pnlPage2";
            pnlPage2.Size = new Size(638, 458);
            pnlPage2.TabIndex = 12;
            pnlPage2.Visible = false;
            // 
            // pb1stAttacker
            // 
            pb1stAttacker.BackColor = Color.Black;
            pb1stAttacker.ImageLocation = "../../../GUI_Images/RoleIcons/1stAttackerIcon.png";
            pb1stAttacker.Location = new Point(73, 29);
            pb1stAttacker.Name = "pb1stAttacker";
            pb1stAttacker.Size = new Size(92, 92);
            pb1stAttacker.SizeMode = PictureBoxSizeMode.StretchImage;
            pb1stAttacker.TabIndex = 54;
            pb1stAttacker.TabStop = false;
            // 
            // btn1stAttackerBg
            // 
            btn1stAttackerBg.BackColor = Color.Transparent;
            btn1stAttackerBg.Enabled = false;
            btn1stAttackerBg.FlatAppearance.BorderSize = 4;
            btn1stAttackerBg.FlatStyle = FlatStyle.Flat;
            btn1stAttackerBg.Font = new Font("Copperplate Gothic Light", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn1stAttackerBg.ForeColor = Color.White;
            btn1stAttackerBg.Location = new Point(69, 25);
            btn1stAttackerBg.Name = "btn1stAttackerBg";
            btn1stAttackerBg.Size = new Size(100, 100);
            btn1stAttackerBg.TabIndex = 55;
            btn1stAttackerBg.UseVisualStyleBackColor = false;
            // 
            // lbl1stAttacker
            // 
            lbl1stAttacker.AutoSize = true;
            lbl1stAttacker.BackColor = Color.Black;
            lbl1stAttacker.Font = new Font("Copperplate Gothic Light", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl1stAttacker.ForeColor = Color.White;
            lbl1stAttacker.Location = new Point(54, 128);
            lbl1stAttacker.Name = "lbl1stAttacker";
            lbl1stAttacker.Size = new Size(130, 19);
            lbl1stAttacker.TabIndex = 56;
            lbl1stAttacker.Text = "1st Attacker";
            lbl1stAttacker.TextAlign = ContentAlignment.TopCenter;
            // 
            // pb2ndAttacker
            // 
            pb2ndAttacker.BackColor = Color.Black;
            pb2ndAttacker.ImageLocation = "../../../GUI_Images/RoleIcons/2ndAttackerIcon.png";
            pb2ndAttacker.Location = new Point(273, 29);
            pb2ndAttacker.Name = "pb2ndAttacker";
            pb2ndAttacker.Size = new Size(92, 92);
            pb2ndAttacker.SizeMode = PictureBoxSizeMode.StretchImage;
            pb2ndAttacker.TabIndex = 57;
            pb2ndAttacker.TabStop = false;
            // 
            // btn2ndAttackerBg
            // 
            btn2ndAttackerBg.BackColor = Color.Transparent;
            btn2ndAttackerBg.Enabled = false;
            btn2ndAttackerBg.FlatAppearance.BorderSize = 4;
            btn2ndAttackerBg.FlatStyle = FlatStyle.Flat;
            btn2ndAttackerBg.Font = new Font("Copperplate Gothic Light", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn2ndAttackerBg.ForeColor = Color.White;
            btn2ndAttackerBg.Location = new Point(269, 25);
            btn2ndAttackerBg.Name = "btn2ndAttackerBg";
            btn2ndAttackerBg.Size = new Size(100, 100);
            btn2ndAttackerBg.TabIndex = 58;
            btn2ndAttackerBg.UseVisualStyleBackColor = false;
            // 
            // lbl2ndAttacker
            // 
            lbl2ndAttacker.AutoSize = true;
            lbl2ndAttacker.BackColor = Color.Black;
            lbl2ndAttacker.Font = new Font("Copperplate Gothic Light", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl2ndAttacker.ForeColor = Color.White;
            lbl2ndAttacker.Location = new Point(252, 128);
            lbl2ndAttacker.Name = "lbl2ndAttacker";
            lbl2ndAttacker.Size = new Size(134, 19);
            lbl2ndAttacker.TabIndex = 59;
            lbl2ndAttacker.Text = "2nd Attacker";
            lbl2ndAttacker.TextAlign = ContentAlignment.TopCenter;
            // 
            // pb3rdAttacker
            // 
            pb3rdAttacker.BackColor = Color.Black;
            pb3rdAttacker.ImageLocation = "../../../GUI_Images/RoleIcons/3rdAttackerIcon.png";
            pb3rdAttacker.Location = new Point(473, 29);
            pb3rdAttacker.Name = "pb3rdAttacker";
            pb3rdAttacker.Size = new Size(92, 92);
            pb3rdAttacker.SizeMode = PictureBoxSizeMode.StretchImage;
            pb3rdAttacker.TabIndex = 60;
            pb3rdAttacker.TabStop = false;
            // 
            // btn3rdAttackerBg
            // 
            btn3rdAttackerBg.BackColor = Color.Transparent;
            btn3rdAttackerBg.Enabled = false;
            btn3rdAttackerBg.FlatAppearance.BorderSize = 4;
            btn3rdAttackerBg.FlatStyle = FlatStyle.Flat;
            btn3rdAttackerBg.Font = new Font("Copperplate Gothic Light", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn3rdAttackerBg.ForeColor = Color.White;
            btn3rdAttackerBg.Location = new Point(469, 25);
            btn3rdAttackerBg.Name = "btn3rdAttackerBg";
            btn3rdAttackerBg.Size = new Size(100, 100);
            btn3rdAttackerBg.TabIndex = 61;
            btn3rdAttackerBg.UseVisualStyleBackColor = false;
            // 
            // lbl3rdAttacker
            // 
            lbl3rdAttacker.AutoSize = true;
            lbl3rdAttacker.BackColor = Color.Black;
            lbl3rdAttacker.Font = new Font("Copperplate Gothic Light", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl3rdAttacker.ForeColor = Color.White;
            lbl3rdAttacker.Location = new Point(452, 128);
            lbl3rdAttacker.Name = "lbl3rdAttacker";
            lbl3rdAttacker.Size = new Size(133, 19);
            lbl3rdAttacker.TabIndex = 62;
            lbl3rdAttacker.Text = "3rd Attacker";
            lbl3rdAttacker.TextAlign = ContentAlignment.TopCenter;
            // 
            // pbWinner
            // 
            pbWinner.BackColor = Color.Black;
            pbWinner.ImageLocation = "../../../GUI_Images/RoleIcons/WinnerIcon.png";
            pbWinner.Location = new Point(73, 164);
            pbWinner.Name = "pbWinner";
            pbWinner.Size = new Size(92, 92);
            pbWinner.SizeMode = PictureBoxSizeMode.StretchImage;
            pbWinner.TabIndex = 63;
            pbWinner.TabStop = false;
            // 
            // btnWinnerBg
            // 
            btnWinnerBg.BackColor = Color.Transparent;
            btnWinnerBg.Enabled = false;
            btnWinnerBg.FlatAppearance.BorderSize = 4;
            btnWinnerBg.FlatStyle = FlatStyle.Flat;
            btnWinnerBg.Font = new Font("Copperplate Gothic Light", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnWinnerBg.ForeColor = Color.White;
            btnWinnerBg.Location = new Point(69, 160);
            btnWinnerBg.Name = "btnWinnerBg";
            btnWinnerBg.Size = new Size(100, 100);
            btnWinnerBg.TabIndex = 64;
            btnWinnerBg.UseVisualStyleBackColor = false;
            // 
            // lblWinner
            // 
            lblWinner.AutoSize = true;
            lblWinner.BackColor = Color.Black;
            lblWinner.Font = new Font("Copperplate Gothic Light", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWinner.ForeColor = Color.White;
            lblWinner.Location = new Point(81, 263);
            lblWinner.Name = "lblWinner";
            lblWinner.Size = new Size(76, 19);
            lblWinner.TabIndex = 65;
            lblWinner.Text = "Winner";
            lblWinner.TextAlign = ContentAlignment.TopCenter;
            // 
            // pbDefender
            // 
            pbDefender.BackColor = Color.Black;
            pbDefender.ImageLocation = "../../../GUI_Images/RoleIcons/DefenderIcon.png";
            pbDefender.Location = new Point(273, 164);
            pbDefender.Name = "pbDefender";
            pbDefender.Size = new Size(92, 92);
            pbDefender.SizeMode = PictureBoxSizeMode.StretchImage;
            pbDefender.TabIndex = 66;
            pbDefender.TabStop = false;
            // 
            // btnDefenderBg
            // 
            btnDefenderBg.BackColor = Color.Transparent;
            btnDefenderBg.Enabled = false;
            btnDefenderBg.FlatAppearance.BorderSize = 4;
            btnDefenderBg.FlatStyle = FlatStyle.Flat;
            btnDefenderBg.Font = new Font("Copperplate Gothic Light", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDefenderBg.ForeColor = Color.White;
            btnDefenderBg.Location = new Point(269, 160);
            btnDefenderBg.Name = "btnDefenderBg";
            btnDefenderBg.Size = new Size(100, 100);
            btnDefenderBg.TabIndex = 67;
            btnDefenderBg.UseVisualStyleBackColor = false;
            // 
            // lblDefender
            // 
            lblDefender.AutoSize = true;
            lblDefender.BackColor = Color.Black;
            lblDefender.Font = new Font("Copperplate Gothic Light", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDefender.ForeColor = Color.White;
            lblDefender.Location = new Point(270, 263);
            lblDefender.Name = "lblDefender";
            lblDefender.Size = new Size(98, 19);
            lblDefender.TabIndex = 68;
            lblDefender.Text = "Defender";
            lblDefender.TextAlign = ContentAlignment.TopCenter;
            // 
            // pbBrokenDefender
            // 
            pbBrokenDefender.BackColor = Color.Black;
            pbBrokenDefender.ImageLocation = "../../../GUI_Images/RoleIcons/BrokenDefenderIcon.png";
            pbBrokenDefender.Location = new Point(473, 164);
            pbBrokenDefender.Name = "pbBrokenDefender";
            pbBrokenDefender.Size = new Size(92, 92);
            pbBrokenDefender.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBrokenDefender.TabIndex = 69;
            pbBrokenDefender.TabStop = false;
            // 
            // btnBrokenDefenderBg
            // 
            btnBrokenDefenderBg.BackColor = Color.Transparent;
            btnBrokenDefenderBg.Enabled = false;
            btnBrokenDefenderBg.FlatAppearance.BorderSize = 4;
            btnBrokenDefenderBg.FlatStyle = FlatStyle.Flat;
            btnBrokenDefenderBg.Font = new Font("Copperplate Gothic Light", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBrokenDefenderBg.ForeColor = Color.White;
            btnBrokenDefenderBg.Location = new Point(469, 160);
            btnBrokenDefenderBg.Name = "btnBrokenDefenderBg";
            btnBrokenDefenderBg.Size = new Size(100, 100);
            btnBrokenDefenderBg.TabIndex = 70;
            btnBrokenDefenderBg.UseVisualStyleBackColor = false;
            // 
            // lblBrokenDefender
            // 
            lblBrokenDefender.AutoSize = true;
            lblBrokenDefender.BackColor = Color.Black;
            lblBrokenDefender.Font = new Font("Copperplate Gothic Light", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBrokenDefender.ForeColor = Color.White;
            lblBrokenDefender.Location = new Point(433, 263);
            lblBrokenDefender.Name = "lblBrokenDefender";
            lblBrokenDefender.Size = new Size(171, 19);
            lblBrokenDefender.TabIndex = 71;
            lblBrokenDefender.Text = "Broken Defender";
            lblBrokenDefender.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblPage2Text
            // 
            lblPage2Text.AutoSize = true;
            lblPage2Text.Font = new Font("Copperplate Gothic Light", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPage2Text.ForeColor = Color.White;
            lblPage2Text.Location = new Point(28, 313);
            lblPage2Text.Name = "lblPage2Text";
            lblPage2Text.Size = new Size(503, 105);
            lblPage2Text.TabIndex = 11;
            lblPage2Text.Text = "A round of Durak consists of 1-3 Attackers\r\n attacking 1 Defender.\r\n\r\nThe role of a player is displayed with an icon.\r\n\r\n";
            // 
            // btnPage2TextBg
            // 
            btnPage2TextBg.BackColor = Color.Black;
            btnPage2TextBg.Enabled = false;
            btnPage2TextBg.FlatAppearance.BorderSize = 3;
            btnPage2TextBg.FlatStyle = FlatStyle.Flat;
            btnPage2TextBg.Font = new Font("Castellar", 72F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPage2TextBg.ForeColor = Color.White;
            btnPage2TextBg.Location = new Point(19, 300);
            btnPage2TextBg.Name = "btnPage2TextBg";
            btnPage2TextBg.Size = new Size(600, 142);
            btnPage2TextBg.TabIndex = 10;
            btnPage2TextBg.UseVisualStyleBackColor = false;
            // 
            // btnRulesBg
            // 
            btnRulesBg.BackColor = Color.Black;
            btnRulesBg.Enabled = false;
            btnRulesBg.FlatAppearance.BorderSize = 6;
            btnRulesBg.FlatStyle = FlatStyle.Flat;
            btnRulesBg.Font = new Font("Castellar", 72F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRulesBg.ForeColor = Color.White;
            btnRulesBg.Location = new Point(66, 86);
            btnRulesBg.Name = "btnRulesBg";
            btnRulesBg.Size = new Size(650, 470);
            btnRulesBg.TabIndex = 4;
            btnRulesBg.UseVisualStyleBackColor = false;
            // 
            // pnlPage4
            // 
            pnlPage4.BackColor = Color.Black;
            pnlPage4.Controls.Add(lblPage4Text);
            pnlPage4.Controls.Add(btnPage4TextBg);
            pnlPage4.Location = new Point(72, 92);
            pnlPage4.Name = "pnlPage4";
            pnlPage4.Size = new Size(638, 458);
            pnlPage4.TabIndex = 73;
            pnlPage4.Visible = false;
            // 
            // lblPage4Text
            // 
            lblPage4Text.AutoSize = true;
            lblPage4Text.Font = new Font("Copperplate Gothic Light", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPage4Text.ForeColor = Color.White;
            lblPage4Text.Location = new Point(28, 313);
            lblPage4Text.Name = "lblPage4Text";
            lblPage4Text.Size = new Size(516, 105);
            lblPage4Text.TabIndex = 11;
            lblPage4Text.Text = "At game start, each player is dealt 6 cards.\r\n\r\nThe player with the lowest trump card starts.\r\n\r\nThe trump suit is shown in the top left corner.";
            // 
            // btnPage4TextBg
            // 
            btnPage4TextBg.BackColor = Color.Black;
            btnPage4TextBg.Enabled = false;
            btnPage4TextBg.FlatAppearance.BorderSize = 3;
            btnPage4TextBg.FlatStyle = FlatStyle.Flat;
            btnPage4TextBg.Font = new Font("Castellar", 72F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPage4TextBg.ForeColor = Color.White;
            btnPage4TextBg.Location = new Point(19, 300);
            btnPage4TextBg.Name = "btnPage4TextBg";
            btnPage4TextBg.Size = new Size(600, 142);
            btnPage4TextBg.TabIndex = 10;
            btnPage4TextBg.UseVisualStyleBackColor = false;
            // 
            // RulesForm
            // 
            AcceptButton = btnRight;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            CancelButton = btnLeft;
            ClientSize = new Size(782, 590);
            Controls.Add(pnlRules);
            MaximizeBox = false;
            Name = "RulesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RulesForm";
            pnlRules.ResumeLayout(false);
            pnlRules.PerformLayout();
            pnlPage3.ResumeLayout(false);
            pnlPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbPage3Deck).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPage3Hand).EndInit();
            pnlPage1.ResumeLayout(false);
            pnlPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbCard6H).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbCard7H).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbCard8H).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbCard9H).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbCard10H).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbCardJH).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbCardQH).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbCardKH).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbCardAH).EndInit();
            pnlPage2.ResumeLayout(false);
            pnlPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pb1stAttacker).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb2ndAttacker).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb3rdAttacker).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbWinner).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbDefender).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBrokenDefender).EndInit();
            pnlPage4.ResumeLayout(false);
            pnlPage4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label lblRules;
        private Button btnRight;
        private Button btnLeft;
        private Button btnRules;
        private Panel pnlRules;
        private Panel pnlPage1;
        private PictureBox pbCard6H;
        private Button btnRulesBg;
        private PictureBox pbCardJH;
        private PictureBox pbCardQH;
        private PictureBox pbCardKH;
        private PictureBox pbCard10H;
        private PictureBox pbCard9H;
        private PictureBox pbCardAH;
        private PictureBox pbCard8H;
        private PictureBox pbCard7H;
        private Button btnPage1TextBg;
        private Label lblPage1Text;
        private Panel pnlPage2;
        private Label lblPage2Text;
        private Button btnPage2TextBg;
        private PictureBox pb1stAttacker;
        private Button btn1stAttackerBg;
        private Label lbl1stAttacker;
        private Label lblBrokenDefender;
        private PictureBox pbBrokenDefender;
        private Button btnBrokenDefenderBg;
        private Label lblDefender;
        private PictureBox pbDefender;
        private Button btnDefenderBg;
        private Label lblWinner;
        private PictureBox pbWinner;
        private Button btnWinnerBg;
        private Label lbl3rdAttacker;
        private PictureBox pb3rdAttacker;
        private Button btn3rdAttackerBg;
        private Label lbl2ndAttacker;
        private PictureBox pb2ndAttacker;
        private Button btn2ndAttackerBg;
        private Panel pnlPage3;
        private Label lblPage3Text;
        private Button btnPage3TextBg;
        private PictureBox pbPage3Hand;
        private PictureBox pbPage3Deck;
        private Button btnPage3DeckBg;
        private Label lblPlayerHand;
        private Label lblTrumpCard;
        private Panel pnlPage4;
        private Label lblPage4Text;
        private Button btnPage4TextBg;
    }
}