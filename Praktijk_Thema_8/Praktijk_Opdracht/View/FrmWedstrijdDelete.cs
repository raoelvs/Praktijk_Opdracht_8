/*
 * Author: Quinten Kornalijnslijper
 * Date: 12-6-2022
 * Description: delete match
 */
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
    public partial class FrmWedstrijdDelete : Form
    {
        //fields
        private WedstrijdModel wedstrijd;
        public FrmWedstrijdDelete(WedstrijdModel Wedstrijd)
        {
            InitializeComponent();
            wedstrijd = Wedstrijd;
        }

        /// <summary>
        /// fills comboboxes by the form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmWedstrijdDelete_Load(object sender, EventArgs e)
        {
            txtRound.Text = wedstrijd.Ronde.ToString();
            txtMatch.Text = wedstrijd.WedstrijdNummer.ToString();
            txtStarttijd.Text = wedstrijd.Starttijd.ToShortDateString() + wedstrijd.Starttijd.ToShortTimeString();
            txtEindtijd.Text = wedstrijd.Eindtijd.ToShortDateString() + wedstrijd.Eindtijd.ToShortTimeString();
            txtPlayer1.Text = wedstrijd.Thuis.FullName;
            txtPlayer2.Text = wedstrijd.Uit.FullName;
            txtReferee.Text = wedstrijd.ScheidsrechterCode.FullName;

            // standard winner unknown
            txtWinner.Text = "Onbekend";

            if (wedstrijd.Winnaar.SpelerId != 0)
            {
                txtWinner.Text = wedstrijd.Winnaar.FullName;
            }
        }

        /// <summary>
        /// close this form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// go to the next form to confirm the delete and close this form after
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnYes_Click(object sender, EventArgs e)
        {
            // opens form to delete all results of the match and to delete the match itself
            FrmWedstrijdDeleteResults frm = new FrmWedstrijdDeleteResults(wedstrijd);
            frm.ShowDialog();
            this.Close();
        }
    }
}
