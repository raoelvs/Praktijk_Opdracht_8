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
        private FrmSpelersOverview spelersOverview;

        public FrmSpelerAdd(FrmSpelersOverview SpelersOverview)
        {
            InitializeComponent();
            spelersOverview = SpelersOverview;
        }

        private void FrmSpelerAdd_Load(object sender, EventArgs e)
        {
            List<SpelerModel> spelers = spelerController.ReadAll();

            foreach(SpelerModel speler in spelers)
            {
                cbSchool.Items.Add(speler.SchoolId);
            }

            cbSchool.DisplayMember = "Naam";
        }

        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            spelersOverview.FormBorderStyle = FormBorderStyle.None;
            spelersOverview.TopLevel = false;
            spelersOverview.TopMost = true;
            spelersOverview.Dock = DockStyle.Fill;
            this.Close();
            spelersOverview.pnlForms.Controls.Add(spelersOverview);
            spelersOverview.Show();
        }

        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            SpelerModel item = new SpelerModel();

            item.Voornaam = txtVoornaam.Text;
            item.Tussenvoegsel = txtTussenvoegsel.Text;
            item.Achternaam = txtAchternaam.Text;
            item.Geboortedatum = dtpGeboortedatum.Value;
            item.Groep = Convert.ToInt32(txtGroep.Text);
            item.SchoolId = (SchoolModel)cbSchool.SelectedItem;

            int rowsAffected = spelerController.Create(item);

            if (rowsAffected > 0)
            {
                spelersOverview.FormBorderStyle = FormBorderStyle.None;
                spelersOverview.TopLevel = false;
                spelersOverview.TopMost = true;
                spelersOverview.Dock = DockStyle.Fill;
                this.Close();
                spelersOverview.FillListVieuw();
                spelersOverview.pnlForms.Controls.Add(spelersOverview);
                spelersOverview.Show();
            }
            else
            {
                MessageBox.Show("Speler " + item.FullName + " is niet toegevoegd");
            }

            
        }
    }
}
