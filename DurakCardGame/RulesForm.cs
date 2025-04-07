using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DurakCardGame
{
    public partial class RulesForm : Form
    {
        // Variables
        int page = 0;

        List<Panel> pageList = new List<Panel>() { };


        public RulesForm()
        {
            InitializeComponent();
            AddPanelsToList();
        }

        /// <summary>
        /// Adds all the page panels to the panel list
        /// </summary>
        private void AddPanelsToList()
        {
            pageList.AddRange(new List<Panel>
            {
                pnlPage1,
                pnlPage2,
                pnlPage3,
                //pnlPage4,
                //pnlPage5,
                //pnlPage6,
                //pnlPage7,
                //pnlPage8,
                //pnlPage9,
                //pnlPage10,
             });
        }

        /// <summary>
        /// Goes to the previous page in the page list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLeftClick(object sender, EventArgs e)
        {
            // Hides the current page panel
            pageList[page].Visible = false;

            // Changes the page number
            page--;

            // Checks if the page needs to loop to the end
            if (page < 0) 
            {
                page += pageList.Count();
            }

            // Shows the new panel page
            pageList[page].Visible = true;
            pageList[page].BringToFront();
        }

        /// <summary>
        /// Goes to the next page in the page list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRightClick(object sender, EventArgs e)
        {
            // Hides the current page panel
            pageList[page].Visible = false;

            // Changes the page number
            page++;

            // Checks if the page needs to loop to the beginning
            if (page > pageList.Count() - 1)
            {
                page -= pageList.Count();
            }

            // Shows the new panel page
            pageList[page].Visible = true;
            pageList[page].BringToFront();
        }
    }
}
