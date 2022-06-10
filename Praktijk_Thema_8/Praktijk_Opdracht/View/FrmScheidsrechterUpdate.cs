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
    public partial class FrmScheidsrechterUpdate : Form
    {
        private ScheidsrechterController scheidsrechterController = new ScheidsrechterController();
        private ScheidsrechterModel permScheidsrechter;

        public FrmScheidsrechterUpdate(ScheidsrechterModel tmpScheidsrechter)
        {
            InitializeComponent();

            //tijdelijk opslaan in een globale variable
            permScheidsrechter = tmpScheidsrechter;
        }

        private void FrmScheidsrechterUpdate_Load(object sender, EventArgs e)
        {
            //text boxen vullen met informatie die geselecteerd is in de listview
            txtVoornaam.Text = permScheidsrechter.Voornaam;
            txtTussenvoegsel.Text = permScheidsrechter.Tussenvoegsel;
            txtAchternaam.Text = permScheidsrechter.Achternaam;
        }

        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            // scheidsrechtermodel aanmaken met de aagepaste gegevens
            ScheidsrechterModel updatedScheidsrechter = new ScheidsrechterModel();

            updatedScheidsrechter.Voornaam = txtVoornaam.Text;
            updatedScheidsrechter.Tussenvoegsel = txtTussenvoegsel.Text;
            updatedScheidsrechter.Achternaam = txtAchternaam.Text;

            //speler gebruiken van de geslecteerde speler uit listview
            updatedScheidsrechter.ScheidsrechterCode = permScheidsrechter.ScheidsrechterCode;

            try
            {
                scheidsrechterController.Update(updatedScheidsrechter);
                MessageBox.Show("Klant is geupdate");
            }
            catch
            {
                MessageBox.Show("Het is niet gelukt");
            }

            this.Close();

        }

        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
