using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int Width { get; set; } = 50;
        public int Height { get; set; } = 100;
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

    }
}
