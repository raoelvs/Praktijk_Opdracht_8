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
    public partial class FrmSpelersOverview : Form
    {

        SpelerController spelerController = new SpelerController();
        public Panel pnlForms;

        public FrmSpelersOverview(Panel PnlForms)
        {
            InitializeComponent();
            pnlForms = PnlForms;
        }

        private void Spelers_Load(object sender, EventArgs e)
        {
            //listvieuw tonen 
            lvSpeler.Columns.Add("Voornaam", 100);
            lvSpeler.Columns.Add("Tussenvoegsel", 125);
            lvSpeler.Columns.Add("Achternaam", 200);
            lvSpeler.Columns.Add("Geboortedatum", 150);
            lvSpeler.Columns.Add("Groep", 100);
            lvSpeler.Columns.Add("SchoolNaam", 250);

            //geeft itema weer als in een row
            lvSpeler.View = System.Windows.Forms.View.Details;

            //bij selectie toon blaue lijn over alle colums
            lvSpeler.FullRowSelect = true;

            // zorgt dat je op de header style kan klikken
            lvSpeler.HeaderStyle = ColumnHeaderStyle.Clickable;

            FillListVieuw();

            List<SpelerModel> spelers = spelerController.ReadAllDistinct();

            foreach(SpelerModel speler in spelers)
            {
                cbFilter.Items.Add(speler.Voornaam);
            }
        }

        public void FillListVieuw()
        {

            List<SpelerModel> spelerList = spelerController.ReadAll();

            lvSpeler.Items.Clear();

            foreach (SpelerModel item in spelerList)
            {
                //listvieuw item aanmaken

                ListViewItem lvItem = new ListViewItem(item.Voornaam);
                lvItem.SubItems.Add(item.Tussenvoegsel);
                lvItem.SubItems.Add(item.Achternaam);
                lvItem.SubItems.Add(item.Geboortedatum.ToString());
                lvItem.SubItems.Add(item.Groep.ToString());
                lvItem.SubItems.Add(item.SchoolId.Naam);

                lvItem.Tag = item;

                lvSpeler.Items.Add(lvItem);
            }
        }

        private void FilterListView(string selectedSpeler)
        {

            List<SpelerModel> filter = spelerController.ReadFilter(selectedSpeler);

            lvSpeler.Items.Clear();

            foreach (SpelerModel item in filter)
            {
                //listvieuw item aanmaken

                ListViewItem lvItem = new ListViewItem(item.Voornaam);
                lvItem.SubItems.Add(item.Tussenvoegsel);
                lvItem.SubItems.Add(item.Achternaam);
                lvItem.SubItems.Add(item.Geboortedatum.ToString());
                lvItem.SubItems.Add(item.Groep.ToString());
                lvItem.SubItems.Add(item.SchoolId.Naam);

                lvItem.Tag = item;

                lvSpeler.Items.Add(lvItem);
            }
        }

        private void btnVerwijderen_Click(object sender, EventArgs e)
        {
            // Welk item willen we verwijderen?
            SpelerModel spelerDel = (SpelerModel)lvSpeler.SelectedItems[0].Tag;

            FrmSpelerDelete frm = new FrmSpelerDelete(spelerDel);
            frm.ShowDialog();

            FillListVieuw();
        }

        private void btnWijzigen_Click(object sender, EventArgs e)
        {
            SpelerModel toBeUpdated = (SpelerModel) lvSpeler.SelectedItems[0].Tag;

            // Versturen naar nieuw UI
            FrmSpelerUpdate frm = new FrmSpelerUpdate(this, toBeUpdated);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.TopLevel = false;
            frm.TopMost = true;
            frm.Dock = DockStyle.Fill;
            pnlForms.Controls.Clear();
            pnlForms.Controls.Add(frm);
            frm.Show();

            FillListVieuw();
        }

        private void btnToevoegen_Click(object sender, EventArgs e)
        {

            FrmSpelerAdd frm = new FrmSpelerAdd(this);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.TopLevel = false;
            frm.TopMost = true;
            frm.Dock = DockStyle.Fill;
            pnlForms.Controls.Clear();
            pnlForms.Controls.Add(frm);
            frm.Show();

            FillListVieuw();
        }

        private void lvSpeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            int amountSelected = lvSpeler.SelectedItems.Count;

            if (amountSelected > 0)
            {
                btnVerwijderen.Enabled = true;
                btnWijzigen.Enabled = true;
            }
            else
            {
                btnVerwijderen.Enabled = false;
                btnWijzigen.Enabled = false;
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string selectedSpeler = cbFilter.SelectedItem.ToString();

            FilterListView(selectedSpeler);
        }

        private void btnClearfilter_Click(object sender, EventArgs e)
        {
            FillListVieuw();
        }
    }
}
