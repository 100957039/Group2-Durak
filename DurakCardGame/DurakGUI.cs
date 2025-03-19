using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

/* 
 * The different screens are made of seperate panels, the easiest
 *  way to work with them is by using the Document Outline.
 *  
 * On the DurakGUI Form go View -> Other Windows -> Document Outline
 *  or hit CTRL + ALT + T.
 */

namespace DurakCardGame
{
    public partial class DurakGUI : Form
    {
        // Constants
        int IconsPerPage = 6;

        // Variables
        int numPlayers = 2;
        int numAI = 1;
        int iconPage = 0;

        public DurakGUI()
        {
            InitializeComponent();
        }

        //
        // Main Menu
        //

        /// <summary>
        /// Moves to Player Select from Main Menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStartClick(object sender, EventArgs e)
        {
            pnlMainMenu.Visible = false;
            pnlPlayerSelect.Visible = true;
        }

        /// <summary>
        /// Opens a new form displaying the Durak Rules
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowRules(object sender, EventArgs e)
        {
            List<RulesForm> childForms = Application.OpenForms.OfType<RulesForm>().ToList();
            if (childForms.Count() == 1)
            {
                childForms.FirstOrDefault()!.Close();
            }
            Form rules = new RulesForm();
            rules.Show();
        }

        /// <summary>
        /// Moves to Options from Main Menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOptionsClick(object sender, EventArgs e)
        {
            pnlMainMenu.Visible = false;
            pnlOptions.Visible = true;
        }

        /// <summary>
        /// Closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnQuitClick(object sender, EventArgs e)
        {
            // Closes the window
            Close();
        }

        //
        // Options
        //

        /// <summary>
        /// Moves to Main Menu from Options
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBackOClick(object sender, EventArgs e)
        {
            pnlOptions.Visible = false;
            pnlMainMenu.Visible = true;
        }

        //
        // Player Select
        //

        /// <summary>
        /// Moves to Main Menu from Player Select
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBackPSClick(object sender, EventArgs e)
        {
            pnlPlayerSelect.Visible = false;
            pnlMainMenu.Visible = true;
        }

        /// <summary>
        /// Moves to Customize from PlayerSelect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConfirmPSClick(object sender, EventArgs e)
        {
            pnlPlayerSelect.Visible = false;
            pnlCustomize.Visible = true;
            //ShowIcons();
        }

        /// <summary>
        /// Sets number of game players to 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rb2PlayersClick(object sender, EventArgs e)
        {
            numPlayers = 2;
            rb2AI.Enabled = false;
            lblHide2AI.Visible = true;
            rb3AI.Enabled = false;
            lblHide3AI.Visible = true;

            if (rb2AI.Checked == true || rb3AI.Checked == true)
            {
                rb1AI.Checked = true;
                numAI = 1;
            }
        }

        /// <summary>
        /// Sets number of game players to 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rb3PlayersClick(object sender, EventArgs e)
        {
            numPlayers = 3;
            rb2AI.Enabled = true;
            lblHide2AI.Visible = false;
            rb3AI.Enabled = false;
            lblHide3AI.Visible = true;

            if (rb3AI.Checked == true)
            {
                rb2AI.Checked = true;
                numAI = 2;
            }
        }

        /// <summary>
        /// Sets number of game players to 4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rb4PlayersClick(object sender, EventArgs e)
        {
            numPlayers = 4;
            rb2AI.Enabled = true;
            lblHide2AI.Visible = false;
            rb3AI.Enabled = true;
            lblHide3AI.Visible = false;
        }

        /// <summary>
        /// Sets number of AI players to 0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rb0AIClick(object sender, EventArgs e)
        {
            numAI = 0;
        }

        /// <summary>
        /// Sets number of AI players to 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rb1AIClick(object sender, EventArgs e)
        {
            numAI = 1;
        }

        /// <summary>
        /// Sets number of AI players to 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rb2AIClick(object sender, EventArgs e)
        {
            numAI = 2;
        }

        /// <summary>
        /// Sets number of AI players to 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rb3AIClick(object sender, EventArgs e)
        {
            numAI = 3;
        }

        //
        // Customize
        //

        /// <summary>
        /// Moves to Player Select from Customize Screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBackNClick(object sender, EventArgs e)
        {
            pnlCustomize.Visible = false;
            pnlPlayerSelect.Visible = true;
            iconPage = 0;
        }
   
        /// <summary>
        /// Moves to Game from Customize Screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConfirmNClick(object sender, EventArgs e)
        {
            pnlCustomize.Visible = false;
            pnlGame.Visible = true;
            iconPage = 0;
        }

        private void ShowIcons(Panel iconSelect)
        {
            int iconSize = 50;
            int[] iconLocationX = {34, 90, 146};
            int[] iconLocationY = {13, 69, 0};
            List<PictureBox> iconList = new List<PictureBox>();
            List<PictureBox> panelList = new List<PictureBox>() {pbPlayer1SelectedIcon, pbPlayer2SelectedIcon, pbPlayer3SelectedIcon, pbPlayer4SelectedIcon};
            String iconLocation = "../../../GUI_Images/Icons/";
            String[] icons = ["Acorn_Boy.jpg", "Beard_Man.jpg", "Inventor.jpg", "Queen.jpg", "Skull_Man.jpg", "Surprise.jpg", "Robot_Knight.jpg"];

            int index = (IconsPerPage * iconPage);

            for (int i = 0; i < IconsPerPage; i++)
            {
                for (int j = 0; j < iconLocationX.Length; j++)
                {
                    iconList[i + j] = new PictureBox
                    {
                        Size = new Size(iconSize, iconSize),
                        Location = new Point(iconLocationX[j], iconLocationY[i]),
                        ImageLocation = iconLocation + icons[index + i],
                        BackgroundImageLayout = ImageLayout.Stretch
                    };

                    //iconList[i + j].Click += (sender, e) =>
                    //{
                            
                    //};
                }

            }
        }
            

        //
        // Game
        //

        /// <summary>
        /// Brings up an alert and lets player return to Main Menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMenu(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Exit to Main Menu? (Game will not be saved)", "Exit to Menu", MessageBoxButtons.OKCancel);

            if (dialogResult == DialogResult.OK)
            {
                pnlGame.Visible = false;
                pnlMainMenu.Visible = true;
            }
        }
    }
}
