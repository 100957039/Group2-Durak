using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace DurakCardGame
{
    internal class Card
    {
        public string Suit { get; set; }
        public string Value { get; set; }
        public int Rank { get; set; }
        //public string Image { get; set; }
        public string ImageLocation { get; set; }
        public bool Flip { get; set; } = false;
        public int Width { get; set; } = 80;
        public int Height { get; set; } = 122;
        public int X { get; set; }
        public int Y { get; set; }
        //public int AddX { get; set; } = 0;
        //public int AddY { get; set; } = 0;
        public bool wasOnTop { get; set; } = false;

        // can play card in his/her turn only
        public bool canPlay { get; set; } = false;

        //public Card(string suit, string value, int rank, int x, int y)
        //{
        //    Suit = suit;
        //    Value = value;
        //    Rank = rank;
        //    //Image = image;
        //    Flip = false;
        //    X = x;
        //    Y = y;
        //}
        public Card(string suit, string value, int rank, string imageLocation)
        {
            Suit = suit;
            Value = value;
            Rank = rank;
            ImageLocation = imageLocation;
        }

        /// <summary>
        ///  to be deleted, No longer needed.  (CreateButton)
        /// </summary>
        /// <returns></returns>
        public Button CreateButton()
        {
            Button button = new Button();
            button.Text = Value + " " + Suit;
            return button;
        }

        public Button CreateCardButton()
        {

            Button imgButton = new Button
            {
                Size = new Size(Width, Height),
                Location = new Point(X, Y),
                BackgroundImage = Image.FromFile(ImageLocation),
                BackgroundImageLayout = ImageLayout.Stretch
            };

            // Add mouse hover events
            imgButton.MouseEnter += (sender, e) =>
            {

                imgButton.Location = new Point(X, Y - 10); // Move slightly up
            };

            // Mouse Leave Event (Return to original position and restore order if necessary)
            imgButton.MouseLeave += (sender, e) =>
            {
                imgButton.Location = new Point(X, Y); // Reset position
            };

            return imgButton;
        }

        /// <summary>
        /// Returns a string of the card suit
        /// </summary>
        /// <returns></returns>
        public string SuitToString()
        {
            const string Heart = "H";
            const string Diamond = "D";
            const string Club = "C";
            const string Spade = "S";
            const string HeartWord = "Hearts";
            const string DiamondWord = "Diamonds";
            const string ClubWord = "Clubs";
            const string SpadeWord = "Spades";

            string cardString = "";

            // Checks for the card suit and add the full word
            switch (Suit)
            {
                case Heart:
                    cardString = HeartWord;
                    break;
                case Diamond:
                    cardString = DiamondWord;
                    break;
                case Club:
                    cardString = ClubWord;
                    break;
                case Spade:
                    cardString = SpadeWord;
                    break;
            }

            return cardString;
        }

        /// <summary>
        /// Returns a string of the card value
        /// </summary>
        /// <returns></returns>
        public string ValueToString()
        {
            const string Jack = "J";
            const string Queen = "Q";
            const string King = "K";
            const string Ace = "A";
            const string JackWord = "Jack";
            const string QueenWord = "Queen";
            const string KingWord = "King";
            const string AceWord = "Ace";

            string cardString = Value;


            // Checks for the card suit and add the full word
            switch (Value)
            {
                case Jack:
                    cardString = JackWord;
                    break;
                case Queen:
                    cardString = QueenWord;
                    break;
                case King:
                    cardString = KingWord;
                    break;
                case Ace:
                    cardString = AceWord;
                    break;
            }

            return cardString;
        }

        /// <summary>
        /// Returns a string of the card suit and value
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string cardString = ValueToString() + " of " + SuitToString();
            return cardString;
        }

        //public void ChangePosition(x)
        //{
        //    Button cardButton = CreateCardButton();
        //    cardButton.Click += (sender, e) =>
        //    {
        //        cardButton.Enabled = false;  // disable button once card is played
        //                                     // Add the card to the played cards panel
        //        panelPlayGroundAttack.Controls.Add(cardButton);
        //    };
        //    cardButton.Location = new Point(x, 0);
        //    panels[i].Controls.Add(cardButton);
        //    cardButton.BringToFront();
        //}

    }
}
