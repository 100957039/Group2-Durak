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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBoxTurn = new TextBox();
            textBoxTrump = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(0, 0);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // buttonStartGame
            // 
            buttonStartGame.Location = new Point(660, 55);
            buttonStartGame.Name = "buttonStartGame";
            buttonStartGame.Size = new Size(75, 23);
            buttonStartGame.TabIndex = 1;
            buttonStartGame.Text = "start";
            buttonStartGame.UseVisualStyleBackColor = true;
            buttonStartGame.Click += buttonStartGame_Click;
            // 
            // button3
            // 
            button3.Location = new Point(458, 40);
            button3.Name = "button3";
            button3.Size = new Size(97, 23);
            button3.TabIndex = 2;
            button3.Text = "console.log";
            button3.UseVisualStyleBackColor = true;
            // 
            // panelDefend
            // 
            panelDefend.Location = new Point(150, 148);
            panelDefend.Name = "panelDefend";
            panelDefend.Size = new Size(634, 100);
            panelDefend.TabIndex = 3;
            // 
            // panelAttack
            // 
            panelAttack.Location = new Point(150, 290);
            panelAttack.Name = "panelAttack";
            panelAttack.Size = new Size(647, 100);
            panelAttack.TabIndex = 4;
            // 
            // panelHand
            // 
            panelHand.Location = new Point(66, 454);
            panelHand.Name = "panelHand";
            panelHand.Size = new Size(913, 126);
            panelHand.TabIndex = 5;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(919, 274);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(919, 203);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 7;
            // 
            // textBoxTurn
            // 
            textBoxTurn.Location = new Point(919, 129);
            textBoxTurn.Name = "textBoxTurn";
            textBoxTurn.Size = new Size(100, 23);
            textBoxTurn.TabIndex = 8;
            // 
            // textBoxTrump
            // 
            textBoxTrump.Location = new Point(919, 71);
            textBoxTrump.Name = "textBoxTrump";
            textBoxTrump.Size = new Size(100, 23);
            textBoxTrump.TabIndex = 9;
            // 
            // SimpleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1084, 631);
            Controls.Add(textBoxTrump);
            Controls.Add(textBoxTurn);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
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
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBoxTurn;
        private TextBox textBoxTrump;
    }
}