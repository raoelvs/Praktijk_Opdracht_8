/*
 * Author: Quinten Kornalijnslijper
 * Date: 12-6-2022
 * Description: form for adding a match to database
 */
using Praktijk_Opdracht.Controller;
using Praktijk_Opdracht.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praktijk_Opdracht.View
{
    public partial class FrmWedstrijdAdd : Form
    {
        // fields
        private SpelerController spelContr = new SpelerController();
        private ScheidsrechterController scheidsContr = new ScheidsrechterController();
        private WedstrijdController wedsContr = new WedstrijdController();
        private ResultaatController resuContr = new ResultaatController();
        private int[,] roundWithMatches = new int[5, 1]
            {
                { 16 },
                { 8 },
                { 4 },
                { 2 },
                { 1 }
            };
        private FrmWedstrijdOverview wedstrijdOverview;

        
        public FrmWedstrijdAdd(FrmWedstrijdOverview WedstrijdOverview)
        {
            InitializeComponent();
            wedstrijdOverview = WedstrijdOverview;
        }

        /// <summary>
        /// filling the comboboxes by the form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmWedstrijdAdd_Load(object sender, EventArgs e)
        {
            // loop through roundWithMatches and fils combobox
            for (int i = 0; i < roundWithMatches.Length; i++)
            {
                cmbRound.Items.Add(i + 1);
            }
            cmbWedstrijd.Enabled = false;

            List<SpelerModel> spelerList = spelContr.ReadAll();
            // loop through spelerList and fills combobox
            foreach (SpelerModel speler in spelerList)
            {
                cmbPlayer1.Items.Add(speler);
            }
            cmbPlayer1.DisplayMember = "FullName";
            cmbPlayer2.Enabled = false;

            List<ScheidsrechterModel> scheidsrechterList = scheidsContr.ReadAll();
            //loop through scheidsrechterList and fills combobox
            foreach (ScheidsrechterModel scheidsrechter in scheidsrechterList)
            {
                cmbReferee.Items.Add(scheidsrechter);
            }
            cmbReferee.DisplayMember = "FullName";
        }

        /// <summary>
        /// if item selected in combox for round enabled the combobox for matches
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbRound_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbRound.SelectedItem != null)
            {
                // get the total matches in a round
                int totalMatches = roundWithMatches[cmbRound.SelectedIndex, 0];
                cmbWedstrijd.Enabled = true;
                cmbWedstrijd.Items.Clear();
                // loop through totalMatches and fills combobox
                for (int i = 1; i <= totalMatches; i++)
                {
                    cmbWedstrijd.Items.Add(i);
                }
            }
            else
            {
                cmbWedstrijd.Enabled = false;
            }

        }

        /// <summary>
        /// cloose this form and go to the previous
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            wedstrijdOverview.FormBorderStyle = FormBorderStyle.None;
            wedstrijdOverview.TopLevel = false;
            wedstrijdOverview.TopMost = true;
            wedstrijdOverview.Dock = DockStyle.Fill;
            this.Close();
            wedstrijdOverview.pnlForms.Controls.Add(wedstrijdOverview);
            wedstrijdOverview.Show();
        }

        /// <summary>
        /// if item selected in combox for player1 enabled the combobox for player2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbPlayer1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPlayer1.SelectedItem != null)
            {
                List<SpelerModel> spelerList = spelContr.ReadWhereIsNot((SpelerModel)cmbPlayer1.SelectedItem);
                cmbPlayer2.Enabled = true;
                cmbPlayer2.Items.Clear();
                foreach(SpelerModel speler in spelerList)
                {
                    cmbPlayer2.Items.Add(speler);
                }
                cmbPlayer2.DisplayMember = "FullName";
            }
            else
            {
                cmbWedstrijd.Enabled = false;
            }
        }

        /// <summary>
        /// checks if all fields have an input then add it to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            // checks if fields are empty
            if(cmbPlayer1.SelectedItem == null ||
                cmbPlayer2.SelectedItem == null ||
                cmbReferee.SelectedItem == null ||
                cmbRound.SelectedItem == null ||
                cmbWedstrijd.SelectedItem == null)
            {
                MessageBox.Show("Niet alle velden zijn ingevuld!");
            }
            else
            {
                // fills a WedstrijdModel for to be updated
                WedstrijdModel wedstrijd = new WedstrijdModel();
                wedstrijd.Ronde = (int)cmbRound.SelectedItem;
                wedstrijd.WedstrijdNummer = (int)cmbWedstrijd.SelectedItem;
                wedstrijd.Starttijd = dtpStarttime.Value;
                wedstrijd.Eindtijd = dtpEndtime.Value;
                wedstrijd.Thuis = (SpelerModel)cmbPlayer1.SelectedItem;
                wedstrijd.Uit = (SpelerModel)cmbPlayer2.SelectedItem;
                wedstrijd.ScheidsrechterCode = (ScheidsrechterModel)cmbReferee.SelectedItem;

                // try to add the match
                try
                {     
                    // get rows affected
                    int rowsAffected = wedsContr.Create(wedstrijd);
                    if (rowsAffected > 0)
                    {
                        // search the match that's created
                        WedstrijdModel wedstrijdResultaat = wedsContr.ReadWhereRoundMatch(wedstrijd.Ronde, wedstrijd.WedstrijdNummer);
                        
                        ResultaatModel thuisSpeler = new ResultaatModel();
                        thuisSpeler.Punt = 0;
                        thuisSpeler.Overgave = false;
                        thuisSpeler.SpelerId = wedstrijdResultaat.Thuis;
                        thuisSpeler.WedstrijdId = wedstrijdResultaat;

                        ResultaatModel uitSpeler = new ResultaatModel();
                        uitSpeler.Punt = 0;
                        uitSpeler.Overgave = false;
                        uitSpeler.SpelerId = wedstrijdResultaat.Uit;
                        uitSpeler.WedstrijdId = wedstrijdResultaat;

                        // creates also the results for the match that's created
                        resuContr.Create(thuisSpeler);
                        resuContr.Create(uitSpeler);

                        MessageBox.Show("Wedstrijd is toegevoegd");
                        wedstrijdOverview.FormBorderStyle = FormBorderStyle.None;
                        wedstrijdOverview.TopLevel = false;
                        wedstrijdOverview.TopMost = true;
                        wedstrijdOverview.Dock = DockStyle.Fill;
                        this.Close();
                        wedstrijdOverview.FillListView();
                        wedstrijdOverview.pnlForms.Controls.Add(wedstrijdOverview);
                        wedstrijdOverview.Show();
                    }
                    else
                    {
                        MessageBox.Show("Wedstrijd is niet toegevoegd");
                    }
                }
                // catch sql exception
                catch(SqlException ex)
                {
                    if(ex.Number == 2627)
                    {
                        // unique error
                        MessageBox.Show("Wedstrijd niet toe kunnen voegen door database error. Hieronder vind je waar het probleem onstaan kan zijn. \n \n" +
                            "Er is al een wedstrijd op in de ronde met dit wedstrijdnummer. \n" +
                            "Deze spelers hebben al tegen elkaar gevochten. \n" +
                            "De scheidsrechter moet al bij een andere wedstrijd speler om dit tijdstip.");
                    }
                    else
                    {
                        MessageBox.Show("Wedstrijd niet toe kunnen voegen door algemane database error");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Wedstrijd niet toe kunnen voegen door algemene error");
                }                
            }
        }
    }
}
