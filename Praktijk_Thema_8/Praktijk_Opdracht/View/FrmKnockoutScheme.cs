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
                for (int count = 0; count < roundMatches[i]; count++)
                {
                    string labelName = "lblRonde" + (i + 1) + "Wedstrijd" + (count + 1);

                    // get the match
                    WedstrijdModel wedstrijd = wedContr.ReadWhereRoundMatch(i + 1, count + 1);

                    // does match exist?
                    if (wedstrijd.WedstrijdId != 0)
                    {
                        // loop through all labels of specific round
                        foreach (Label label in labels)
                        {
                            // if label name equal is to labelname where player Home or player Out
                            if (label.Name == labelName + "Thuis")
                            {
                                if (wedstrijd.Winnaar.SpelerId != 0 && wedstrijd.Winnaar.SpelerId == wedstrijd.Thuis.SpelerId)
                                {
                                    label.Font = new Font(Label.DefaultFont, FontStyle.Bold);
                                }
                                label.Text = wedstrijd.Thuis.FullName;
                            }
                            else if (label.Name == labelName + "Uit")
                            {
                                if (wedstrijd.Winnaar.SpelerId != 0 && wedstrijd.Winnaar.SpelerId == wedstrijd.Uit.SpelerId)
                                {
                                    label.Font = new Font(Label.DefaultFont, FontStyle.Bold);
                                }
                                label.Text = wedstrijd.Uit.FullName;
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
