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
    public partial class FrmSpelerUpdate : Form
    {
        private SpelerController spelerController = new SpelerController();
        private SchoolController schoolController = new SchoolController();
        private SpelerModel permSpeler;
        private FrmSpelersOverview spelerOverview;

        public FrmSpelerUpdate(FrmSpelersOverview SpelerOverview, SpelerModel tmpSpeler)
        {
            InitializeComponent();

            //tijdelijk opslaan in een globale variable
            permSpeler = tmpSpeler;
            spelerOverview = SpelerOverview;
        }

        private void FrmSpelerUpdate_Load(object sender, EventArgs e)
        {
            //text boxen vullen met informatie die geselecteerd is in de listview
            txtVoornaam.Text = permSpeler.Voornaam.ToString();
            txtTussenvoegsel.Text = permSpeler.Tussenvoegsel.ToString();
            txtAchternaam.Text = permSpeler.Achternaam.ToString();
            dtpGeboortedatum.Value = permSpeler.Geboortedatum;
            txtGroep.Text = permSpeler.Groep.ToString();

            // Uit de SpelerController Readall() uitvoeren
            List<SchoolModel> schoolList = schoolController.ReadAll();

            foreach (SchoolModel item in schoolList)
            {
                // Combobox Item vullen
                cbSchool.Items.Add(item);
            }

            cbSchool.Text = permSpeler.SchoolId.Naam;
            cbSchool.DisplayMember = "Naam"; 
        }

        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            // checken of velden leeg zijn
            if (txtVoornaam.Text == "" ||
                txtAchternaam.Text == ""||
                txtGroep.Text == "" ||
                cbSchool.SelectedItem == null )
            {
                MessageBox.Show("Niet alle velden zijn ingevuld!");
            }
            else
            {
                // spelermodel aanmaken met de aagepaste gegevens
                SpelerModel updatedspeler = new SpelerModel();

                updatedspeler.Voornaam = txtVoornaam.Text;
                updatedspeler.Tussenvoegsel = txtTussenvoegsel.Text;
                updatedspeler.Achternaam = txtAchternaam.Text;
                updatedspeler.Geboortedatum = dtpGeboortedatum.Value;
                updatedspeler.Groep = Convert.ToInt32(txtGroep.Text);
                updatedspeler.SchoolId = (SchoolModel)cbSchool.SelectedItem;


                //speler gebruiken van de geslecteerde speler uit listview
                updatedspeler.SpelerId = permSpeler.SpelerId;

                try
                {
                    spelerController.Update(updatedspeler);
                    MessageBox.Show("Klant is geupdate");


                    spelerOverview.FormBorderStyle = FormBorderStyle.None;
                    spelerOverview.TopLevel = false;
                    spelerOverview.TopMost = true;
                    spelerOverview.Dock = DockStyle.Fill;
                    this.Close();
                    spelerOverview.FillListVieuw();
                    spelerOverview.pnlForms.Controls.Add(spelerOverview);
                    spelerOverview.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Het is niet gelukt: " + ex.Message);

                }
            }
        }

        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            spelerOverview.FormBorderStyle = FormBorderStyle.None;
            spelerOverview.TopLevel = false;
            spelerOverview.TopMost = true;
            spelerOverview.Dock = DockStyle.Fill;
            this.Close();
            spelerOverview.pnlForms.Controls.Add(spelerOverview);
            spelerOverview.Show();
        }
    }
}
