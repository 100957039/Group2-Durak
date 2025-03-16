namespace DurakCardGame
{
    partial class DurakGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DurakGUI));
            pnlMainMenu = new Panel();
            lblTitle = new Label();
            btnTitle = new Button();
            btnQuit = new Button();
            btnHTP = new Button();
            btnOptions = new Button();
            btnStart = new Button();
            pnlMainMenu.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMainMenu
            // 
            pnlMainMenu.AutoScroll = true;
            pnlMainMenu.BackgroundImage = (Image)resources.GetObject("pnlMainMenu.BackgroundImage");
            pnlMainMenu.Controls.Add(lblTitle);
            pnlMainMenu.Controls.Add(btnTitle);
            pnlMainMenu.Controls.Add(btnQuit);
            pnlMainMenu.Controls.Add(btnHTP);
            pnlMainMenu.Controls.Add(btnOptions);
            pnlMainMenu.Controls.Add(btnStart);
            pnlMainMenu.Location = new Point(0, 0);
            pnlMainMenu.Name = "pnlMainMenu";
            pnlMainMenu.Size = new Size(1082, 753);
            pnlMainMenu.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Black;
            lblTitle.Font = new Font("Castellar", 72F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(262, 133);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(560, 128);
            lblTitle.TabIndex = 12;
            lblTitle.Text = "DURAK";
            // 
            // btnTitle
            // 
            btnTitle.BackColor = Color.Black;
            btnTitle.Enabled = false;
            btnTitle.FlatAppearance.BorderSize = 10;
            btnTitle.FlatStyle = FlatStyle.Flat;
            btnTitle.Font = new Font("Castellar", 72F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTitle.ForeColor = Color.White;
            btnTitle.Location = new Point(248, 119);
            btnTitle.Name = "btnTitle";
            btnTitle.Size = new Size(587, 157);
            btnTitle.TabIndex = 11;
            btnTitle.UseVisualStyleBackColor = false;
            // 
            // btnQuit
            // 
            btnQuit.BackColor = Color.Black;
            btnQuit.FlatAppearance.BorderSize = 5;
            btnQuit.FlatStyle = FlatStyle.Flat;
            btnQuit.Font = new Font("Copperplate Gothic Light", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnQuit.ForeColor = Color.White;
            btnQuit.Location = new Point(461, 574);
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new Size(162, 60);
            btnQuit.TabIndex = 10;
            btnQuit.Text = "Quit";
            btnQuit.UseVisualStyleBackColor = false;
            // 
            // btnHTP
            // 
            btnHTP.BackColor = Color.Black;
            btnHTP.FlatAppearance.BorderSize = 5;
            btnHTP.FlatStyle = FlatStyle.Flat;
            btnHTP.Font = new Font("Copperplate Gothic Light", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHTP.ForeColor = Color.White;
            btnHTP.Location = new Point(401, 414);
            btnHTP.Name = "btnHTP";
            btnHTP.Size = new Size(281, 60);
            btnHTP.TabIndex = 9;
            btnHTP.Text = "How to Play";
            btnHTP.UseVisualStyleBackColor = false;
            // 
            // btnOptions
            // 
            btnOptions.BackColor = Color.Black;
            btnOptions.FlatAppearance.BorderSize = 5;
            btnOptions.FlatStyle = FlatStyle.Flat;
            btnOptions.Font = new Font("Copperplate Gothic Light", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOptions.ForeColor = Color.White;
            btnOptions.Location = new Point(446, 494);
            btnOptions.Name = "btnOptions";
            btnOptions.Size = new Size(191, 60);
            btnOptions.TabIndex = 8;
            btnOptions.Text = "Options";
            btnOptions.UseVisualStyleBackColor = false;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.Black;
            btnStart.FlatAppearance.BorderSize = 5;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Copperplate Gothic Light", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnStart.ForeColor = Color.White;
            btnStart.Location = new Point(461, 334);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(162, 60);
            btnStart.TabIndex = 7;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = false;
            // 
            // DurakGUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1082, 753);
            Controls.Add(pnlMainMenu);
            Name = "DurakGUI";
            Text = "DurakGUI";
            pnlMainMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMainMenu;
        private Label lblTitle;
        private Button btnTitle;
        private Button btnQuit;
        private Button btnHTP;
        private Button btnOptions;
        private Button btnStart;
    }
}