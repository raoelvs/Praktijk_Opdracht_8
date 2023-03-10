/* 
 * Author: Quinten Kornalijnslijper
 * Date: 10-6-2022
 * Description: Knockout scheme
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
    public partial class FrmKnockoutScheme : Form
    {
        // fields
        private WedstrijdController wedContr = new WedstrijdController();
        private ResultaatController resuContr = new ResultaatController();
        public FrmKnockoutScheme()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Filling the player1and player 2 where we know the matches of
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmKnockoutScheme_Load(object sender, EventArgs e)
        {
            List<Label> labels = new List<Label>();

            // the matches that are in every round
            int[] roundMatches = { 16, 8, 4, 2, 1 };

            // loop through rounds
            for (int i = 0; i < 5; i++)
            {
                // search all labelsof the specific round in the loop
                labels = this.Controls.OfType<Label>().Where(name => name.Name.StartsWith("lblRonde" + (i + 1))).ToList();
                // loop through matches in the specific round
                for (int count = 0; count < roundMatches[i]; count += 2)
                {
                    // uneven match label
                    string labelName1 = "lblRonde" + (i + 1) + "Wedstrijd" + (count + 1);

                    // get uneven match
                    WedstrijdModel wedstrijd1 = wedContr.ReadWhereRoundMatch(i + 1, count + 1);
                    // does uneven match exist?
                    if (wedstrijd1.WedstrijdId != 0)
                    {
                        // loop through all labels of specific round
                        foreach (Label label in labels)
                        {
                            // if label name equal is to labelname where player Home or player Out
                            if (label.Name == labelName1 + "Thuis")
                            {
                                if (wedstrijd1.Winnaar.SpelerId != 0 && wedstrijd1.Winnaar.SpelerId == wedstrijd1.Thuis.SpelerId)
                                {
                                    label.Font = new Font(Label.DefaultFont, FontStyle.Bold);
                                }
                                label.Text = wedstrijd1.Thuis.FullName;
                            }
                            else if (label.Name == labelName1 + "Uit")
                            {
                                if (wedstrijd1.Winnaar.SpelerId != 0 && wedstrijd1.Winnaar.SpelerId == wedstrijd1.Uit.SpelerId)
                                {
                                    label.Font = new Font(Label.DefaultFont, FontStyle.Bold);
                                }
                                label.Text = wedstrijd1.Uit.FullName;
                            }
                        }
                    }

                    // even match label
                    string labelName2 = "lblRonde" + (i + 1) + "Wedstrijd" + (count + 2);

                    // get even match
                    WedstrijdModel wedstrijd2 = wedContr.ReadWhereRoundMatch(i + 1, count + 2);

                    // does even match exist?
                    if (wedstrijd2.WedstrijdId != 0)
                    {                 
                        // loop through all labels of specific round
                        foreach (Label label in labels)
                        {
                            // if label name equal is to labelname where player Home or player Out
                            if (label.Name == labelName2 + "Thuis")
                            {
                                if (wedstrijd2.Winnaar.SpelerId != 0 && wedstrijd2.Winnaar.SpelerId == wedstrijd2.Thuis.SpelerId)
                                {
                                    label.Font = new Font(Label.DefaultFont, FontStyle.Bold);
                                }
                                label.Text = wedstrijd2.Thuis.FullName;
                            }
                            else if (label.Name == labelName2 + "Uit")
                            {
                                if (wedstrijd2.Winnaar.SpelerId != 0 && wedstrijd2.Winnaar.SpelerId == wedstrijd2.Uit.SpelerId)
                                {
                                    label.Font = new Font(Label.DefaultFont, FontStyle.Bold);
                                }
                                label.Text = wedstrijd2.Uit.FullName;
                            }
                        }
                    }
                    // checks if winneer is not null and if it's not the finale
                    if (
                        wedstrijd1.Winnaar != null &&
                        wedstrijd2.Winnaar != null &&
                        i < 4)
                    {
                        if (wedstrijd1.Winnaar.SpelerId != 0 &&
                            wedstrijd2.Winnaar.SpelerId != 0)
                        {
                            WedstrijdModel controleWedstrijd = wedContr.ReadWhereRoundMatch(i + 2, wedstrijd2.WedstrijdNummer / 2);
                            if (controleWedstrijd.WedstrijdId == 0)
                            {
                                // wedstrijd klaarzetten in juiste ronde en wedstrijd tegen de juiste speler
                                WedstrijdModel wedstrijd = new WedstrijdModel();
                                wedstrijd.Ronde = i + 2;
                                wedstrijd.WedstrijdNummer = wedstrijd2.WedstrijdNummer / 2;
                                wedstrijd.ScheidsrechterCode = wedstrijd1.ScheidsrechterCode;
                                wedstrijd.Thuis = wedstrijd1.Winnaar;
                                wedstrijd.Uit = wedstrijd2.Winnaar;

                                //standaard wedstrijd tijden
                                wedstrijd.Starttijd = DateTime.Parse("1-1-1960 12:00");
                                wedstrijd.Eindtijd = DateTime.Parse("1-1-1960 12:10");

                                // wedstrijd aanmaken en geen message geven als er iets fout gaat
                                try
                                {
                                    int rowsAffected = wedContr.Create(wedstrijd);
                                    if (rowsAffected > 0)
                                    {
                                        // search the match that's created
                                        WedstrijdModel wedstrijdResultaat = wedContr.ReadWhereRoundMatch(wedstrijd.Ronde, wedstrijd.WedstrijdNummer);

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
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Er is iets misgegaan met wedstrijd: " + wedstrijd.Thuis.FullName + " tegen " + wedstrijd.Uit.FullName);
                                }
                            }
                        }
                    }
                }
                labels.Clear();                
            }

            // get finale match
            WedstrijdModel finale = wedContr.ReadWhereRoundMatch(5, 1);

            // does finale match have a winner
            if(finale.WedstrijdId != 0)
            {
                lblWinner.Text = finale.Winnaar.FullName;
            }
        }
    }
}
