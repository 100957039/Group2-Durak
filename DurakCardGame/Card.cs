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
        public string ImageLocation { get; set; } = "../../../5.jpg";
        public bool Flip { get; set; } = false;
        public int Width { get; set; } = 50;
        public int Height { get; set; } = 100;
        public int X { get; set; }
        public int Y { get; set; }
        //public int AddX { get; set; } = 0;
        //public int AddY { get; set; } = 0;
        public bool wasOnTop { get; set; } = false;

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
            //imgButton.BringToFront();
            

            // Add mouse hover events
            imgButton.MouseEnter += (sender, e) =>
            {

                //Console.WriteLine("hjgfh");
                Control parent = imgButton.Parent;
                if (parent != null)
                {
                    int currentIndex = parent.Controls.GetChildIndex(imgButton);
                    int lastIndex = parent.Controls.Count - 1;

                    if (currentIndex < lastIndex) // Means something is on top of it
                    {
                        wasOnTop = false;
                        imgButton.BringToFront(); // Bring to front
                    }
                    else
                    {
                        wasOnTop = true; // Already on top, do nothing
                    }
                }

                imgButton.Location = new Point(X, Y - 10); // Move slightly up
            };

            // Mouse Leave Event (Return to original position and restore order if necessary)
            imgButton.MouseLeave += (sender, e) =>
            {
                imgButton.Location = new Point(X, Y); // Reset position

                if (!wasOnTop) // If it was not originally on top, move it back
                {
                    imgButton.SendToBack();
                }
            };

            return imgButton;
        }

    }
}
