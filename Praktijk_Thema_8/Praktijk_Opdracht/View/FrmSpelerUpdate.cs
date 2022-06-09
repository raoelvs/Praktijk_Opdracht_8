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
        SpelerController spelerController = new SpelerController();
        SpelerModel permSpeler = null;

        public FrmSpelerUpdate(SpelerModel tmpSpeler)
        {
            InitializeComponent();

            permSpeler = tmpSpeler;
        }

        private void FrmSpelerUpdate_Load(object sender, EventArgs e)
        {
            txtVoornaam.Text = permSpeler.Voornaam;
            txtTussenvoegsel.Text = permSpeler.Tussenvoegsel;
            txtAchternaam.Text = permSpeler.Achternaam;
            dtpGeboortedatum.Value = permSpeler.Geboortedatum;
            txtGroep.Text = permSpeler.Groep.ToString();

            List<SpelerModel> schoolList = spelerController.ReadAll();

            foreach (SpelerModel item in schoolList)
            {
                // Combobox Item vullen
                cbSchool.Items.Add(item);
            }

            cbSchool.Text = permSpeler.SchoolId.ToString() + permSpeler.SchoolId.Naam;
        }

        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            // opslaan wijzizgen.
        }

        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            // terug naar speler overview.
        }
    }
}
