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
    public partial class FrmSpelerAdd : Form
    {
        private SpelerController spelerController = new SpelerController();

        public FrmSpelerAdd()
        {
            InitializeComponent();
        }

        private void FrmSpelerAdd_Load(object sender, EventArgs e)
        {
            List<SpelerModel> spelers = spelerController.ReadAll();

            foreach(SpelerModel speler in spelers)
            {
                cbSchool.Items.Add(speler.SchoolId.Naam);
            }
        }

        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            this.Close();

            FrmSpelersOverview frm = new FrmSpelersOverview();
            frm.Show();
        }

        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            SpelerModel item = new SpelerModel();

            item.Voornaam = txtVoornaam.Text;
            item.Tussenvoegsel = txtTussenvoegsel.Text;
            item.Achternaam = txtAchternaam.Text;
            item.Geboortedatum = dtpGeboortedatum.Value;
            item.Groep = Convert.ToInt32(txtGroep.Text);
            item.SchoolId.Naam = cbSchool.Text;                  //Hier ook nog iets aanpassen zodat hij hem opslaat >;)

            int rowsAffected = spelerController.Create(item);

            if (rowsAffected > 0)
            {
                this.DialogResult = DialogResult.Yes;
            }
            else
            {
                this.DialogResult = DialogResult.No;
            }

            this.Close();

            FrmSpelersOverview frm = new FrmSpelersOverview();
            frm.Show();
        }
    }
}
