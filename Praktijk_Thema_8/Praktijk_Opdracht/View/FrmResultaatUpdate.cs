/*
 * Author: Raoel van Schaijk
 * Date: 10-6-2022
 * Description: Resultaat controller with methods for CRUD
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
    public partial class FrmResultaatUpdate : Form
    {
        //Fields
        private ResultaatController ResultaatController = new ResultaatController();
        private SpelerController spelContr = new SpelerController();
        private WedstrijdController wedsContr = new WedstrijdController();

        private int thuisScore;
        private int uitScore;

        private ResultaatModel thuisSpeler;
        private ResultaatModel uitSpeler;

        private WedstrijdModel wedstrijd;
        private FrmResultatenOverview resultaatOverview;

        public FrmResultaatUpdate(FrmResultatenOverview ResultatenOverview, WedstrijdModel Wedstrijd)
        {
            InitializeComponent();
            resultaatOverview = ResultatenOverview;
            wedstrijd = Wedstrijd;
            
        }

        /// <summary>
        /// Vult de teksten van de combo boxen en tekst boxen bij het laden van deze form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmResultaatUpdate_Load(object sender, EventArgs e)
        {
            // Wilt weten welke thuis en uitspeler bij welke wedstrijd hoort
            thuisSpeler = ResultaatController.ReadWhereMatchPlayer(wedstrijd.WedstrijdId, wedstrijd.Thuis.SpelerId);
            uitSpeler = ResultaatController.ReadWhereMatchPlayer(wedstrijd.WedstrijdId, wedstrijd.Uit.SpelerId);

            // vullen lables
            lblThuisNaam.Text = wedstrijd.Thuis.FullName;
            lblUitNaam.Text = wedstrijd.Uit.FullName;

            lblThuis.Text = thuisSpeler.Punt.ToString();
            lblUit.Text = uitSpeler.Punt.ToString();

            // vullen checkboxes
            ckbThuis.Checked= thuisSpeler.Overgave;
            ckbUit.Checked = uitSpeler.Overgave;

            // Speler model opgeroepen voor thuis en uit
            SpelerModel thuis = wedstrijd.Thuis;
            SpelerModel uit = wedstrijd.Uit;

            // vullen combobox met spelers wedstrijd
            cmbWinnaar.Items.Add(thuis);
            cmbWinnaar.Items.Add(uit);

            // Toont de volledige naam in de combobox
            cmbWinnaar.DisplayMember = "FullName";

            // vraagt of winnaar bekend is
            if(wedstrijd.Winnaar.SpelerId != 0)
            {
                cmbWinnaar.Text = wedstrijd.Winnaar.FullName;
            }

            // Convert naar int
            thuisScore = Convert.ToInt32(lblThuis.Text);
            uitScore = Convert.ToInt32(lblUit.Text);
        }

        /// <summary>
        /// Min button voor thuis speler score
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThuisMin_Click(object sender, EventArgs e)
        {
            //  Als je erop drukt verminderd
            if (thuisScore > 0 )
            {
                thuisScore -= 1;
                lblThuis.Text = thuisScore.ToString();
            }
        }

        /// <summary>
        /// Plus button voor thuis speler score
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThuisPlus_Click(object sender, EventArgs e)
        {
            // Als je erop drukt verhoogd
            if (thuisScore < 10)
            {
                thuisScore += 1;
                lblThuis.Text = thuisScore.ToString();
            }
        }
        
        /// <summary>
        /// Min button voor uit speler score
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUitMin_Click(object sender, EventArgs e)
        {
            // Als je erop drukt verlaagd
            if (uitScore > 0)
            {
                uitScore -= 1;
                lblUit.Text = uitScore.ToString();
            }
        }

        /// <summary>
        /// Plus button voor uit speler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnuitPlus_Click(object sender, EventArgs e)
        {
            // Als je erop drukt verhoogd
            if (uitScore < 10)
            {
                uitScore += 1;
                lblUit.Text = uitScore.ToString();
            }
        }

        /// <summary>
        /// Slaat de aangegeven resultaat op in database en update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            // Er moet een winnaar geselecteerd zijn
            if (cmbWinnaar.SelectedItem != null)
            {
                // krijgt winnaar van combo box
                wedstrijd.Winnaar = (SpelerModel)cmbWinnaar.SelectedItem;

                // Het thuisresultaat wordt gevuld
                thuisSpeler.Punt = thuisScore;
                thuisSpeler.Overgave = ckbThuis.Checked;
                
                // Het uitresultaat wordt gevuld
                uitSpeler.Punt = uitScore;
                uitSpeler.Overgave = ckbUit.Checked;

                // Houdt errors tegen
                try 
                {
                    // Past de resultaten aan geeft de winnaar resultaat aan
                    ResultaatController.Update(thuisSpeler);
                    ResultaatController.Update(uitSpeler);
                    wedsContr.UpdateWinner(wedstrijd);

                    // Geeft melding
                    MessageBox.Show("Resultaat is opgeslagen!");

                    // Sluit dit formulier
                    resultaatOverview.FormBorderStyle = FormBorderStyle.None;
                    resultaatOverview.TopLevel = false;
                    resultaatOverview.TopMost = true;
                    resultaatOverview.Dock = DockStyle.Fill;
                    this.Close();
                    resultaatOverview.FillListView();
                    resultaatOverview.PnlResultaatUpdate.Controls.Clear();
                }

                // Vangt errors op
                catch (Exception ex)
                {
                    MessageBox.Show("Er is iets misgegaan");
                }
            }
        }

        /// <summary>
        /// Sluit dit formulier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            resultaatOverview.FormBorderStyle = FormBorderStyle.None;
            resultaatOverview.TopLevel = false;
            resultaatOverview.TopMost = true;
            resultaatOverview.Dock = DockStyle.Fill;
            this.Close();
            resultaatOverview.FillListView();
            resultaatOverview.PnlResultaatUpdate.Controls.Clear();
        }
    }
}
