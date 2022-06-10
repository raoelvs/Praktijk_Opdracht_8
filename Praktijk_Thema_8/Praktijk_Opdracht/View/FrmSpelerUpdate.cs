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
        private SpelerModel permSpeler;

        public FrmSpelerUpdate(SpelerModel tmpSpeler)
        {
            InitializeComponent();

            //tijdelijk opslaan in een globale variable
            permSpeler = tmpSpeler;
        }

        private void FrmSpelerUpdate_Load(object sender, EventArgs e)
        {
            txtVoornaam.Text = permSpeler.Voornaam.ToString();
            txtTussenvoegsel.Text = permSpeler.Tussenvoegsel.ToString();
            txtAchternaam.Text = permSpeler.Achternaam.ToString();
            dtpGeboortedatum.Value = permSpeler.Geboortedatum;
            txtGroep.Text = permSpeler.Groep.ToString();

            // Uit de SpelerController Readall() uitvoeren
            List<SpelerModel> schoolList = spelerController.ReadAll();

            foreach (SpelerModel item in schoolList)
            {
                // Combobox Item vullen
                cbSchool.Items.Add(item.SchoolId);
            }

            cbSchool.Text = permSpeler.SchoolId.Naam;
        }

        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            // klantmodel aanmaken met de aagepaste gegevens
            SpelerModel updatedspeler = new SpelerModel();

            updatedspeler.Voornaam = txtVoornaam.Text;
            updatedspeler.Tussenvoegsel = txtTussenvoegsel.Text;
            updatedspeler.Achternaam = txtAchternaam.Text;
            updatedspeler.Geboortedatum = dtpGeboortedatum.Value;
            updatedspeler.Groep = Convert.ToInt32(txtGroep.Text);
            updatedspeler.SchoolId.Naam = cbSchool.Text;  //////////////////// aanpassen naar een model nog geen idee hoe >:) 

            //doctor nummer gebruiken van de geslecteerde doctor uit listview
            updatedspeler.SpelerId = permSpeler.SpelerId;

            this.Close();
        }

        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
