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
        int numPlayers = 2;
        int numAI = 1;

        public DurakGUI()
        {
            InitializeComponent();
        }

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
        /// Closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnQuitClick(object sender, EventArgs e)
        {
            // Closes the window
            Close();
        }

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
        /// Moves to Game from Player Select
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConfirmPSClick(object sender, EventArgs e)
        {
            pnlPlayerSelect.Visible = false;
            pnlName.Visible = true;
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

        private void BtnMenu(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Exit to Main Menu? (Game will not be saved)", "Exit to Menu", MessageBoxButtons.OKCancel);

            if (dialogResult == DialogResult.OK)
            {
                pnlGame.Visible = false;
                pnlMainMenu.Visible = true;
            }
        }

        /// <summary>
        /// Moves to Player Select from Name Screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBackNClick(object sender, EventArgs e)
        {
            pnlName.Visible = false;
            pnlPlayerSelect.Visible = true;
        }

        /// <summary>
        /// Moves to Game from Name Screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConfirmNClick(object sender, EventArgs e)
        {
            pnlName.Visible = false;
            pnlGame.Visible = true;
        }


    }
}
