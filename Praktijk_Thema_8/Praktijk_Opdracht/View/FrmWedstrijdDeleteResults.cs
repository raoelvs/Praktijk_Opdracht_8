/*
 * Author: Quinten Kornalijnslijper
 * Date: 12-6-2022
 * Description: delete match and delete all results of the match
 */
using Praktijk_Opdracht.Controller;
using Praktijk_Opdracht.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praktijk_Opdracht.View
{
    public partial class FrmWedstrijdDeleteResults : Form
    {
        // fields
        private WedstrijdModel wedstrijd;
        private WedstrijdController wedsContr = new WedstrijdController();
        private ResultaatController resuContr = new ResultaatController();

        public FrmWedstrijdDeleteResults(WedstrijdModel Wedstrijd)
        {
            InitializeComponent();
            wedstrijd = Wedstrijd;
        }

        /// <summary>
        /// close this forms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// delete all results of the match and delete the match itself
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnYes_Click(object sender, EventArgs e)
        {
            // try tot delete the match and all the result of the match
            try
            {
                resuContr.DeleteAllFromWedstrijd(wedstrijd);
                wedsContr.Delete(wedstrijd);
                MessageBox.Show("Wedstrijd met alle resultaten verwijdert");
                this.Close();              
            }
            catch(Exception ex)
            {
                MessageBox.Show("Er is iets misgegaan");
                this.Close();
            }
            
        }
    }
}
