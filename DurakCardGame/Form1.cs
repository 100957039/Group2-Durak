using System.Security.Cryptography.X509Certificates;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace DurakCardGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();

        }
        int x = 0;
        int y = 0;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new Card object
            Card imgBtn = new Card("Hearts", "5", 5, 600 + y, 600 + x);

            // Update y-coordinate for spacing
            y += 20;

            // Create the button from the Card object
            Button cardButton = imgBtn.CreateCardButton();

            // Add the button to the form
            this.Controls.Add(cardButton);

            // Bring the button to the front
            cardButton.BringToFront();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
