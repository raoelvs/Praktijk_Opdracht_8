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
        private SpelerController spelContr = new SpelerController();
        private ScheidsrechterController scheidsContr = new ScheidsrechterController();
        private WedstrijdController wedsContr = new WedstrijdController();
        private int[,] RoundWithMatches = new int[5, 1]
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

        private void FrmWedstrijdAdd_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < RoundWithMatches.Length; i++)
            {
                cmbRound.Items.Add(i + 1);
            }
            cmbWedstrijd.Enabled = false;

            List<SpelerModel> spelerList = spelContr.ReadAll();
            foreach (SpelerModel speler in spelerList)
            {
                cmbPlayer1.Items.Add(speler);
            }
            cmbPlayer1.DisplayMember = "FullName";
            cmbPlayer2.Enabled = false;

            List<ScheidsrechterModel> scheidsrechterList = scheidsContr.ReadAll();
            foreach (ScheidsrechterModel scheidsrechter in scheidsrechterList)
            {
                cmbReferee.Items.Add(scheidsrechter);
            }
            cmbReferee.DisplayMember = "FullName";
        }

        private void cmbRound_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbRound.SelectedItem != null)
            {
                int totalMatches = RoundWithMatches[cmbRound.SelectedIndex, 0];
                cmbWedstrijd.Enabled = true;
                cmbWedstrijd.Items.Clear();
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

        private void btnOpslaan_Click(object sender, EventArgs e)
        {
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
                WedstrijdModel wedstrijd = new WedstrijdModel();
                wedstrijd.Ronde = (int)cmbRound.SelectedItem;
                wedstrijd.WedstrijdNummer = (int)cmbWedstrijd.SelectedItem;
                wedstrijd.Starttijd = dtpStarttime.Value;
                wedstrijd.Eindtijd = dtpEndtime.Value;
                wedstrijd.Thuis = (SpelerModel)cmbPlayer1.SelectedItem;
                wedstrijd.Uit = (SpelerModel)cmbPlayer2.SelectedItem;
                wedstrijd.ScheidsrechterCode = (ScheidsrechterModel)cmbReferee.SelectedItem;
                try
                {
                    wedsContr.Create(wedstrijd);
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
                catch(SqlException ex)
                {
                    if(ex.Number == 2627)
                    {
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
