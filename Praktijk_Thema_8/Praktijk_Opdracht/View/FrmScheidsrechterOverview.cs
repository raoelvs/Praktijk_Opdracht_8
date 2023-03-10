/*
 * Author: Jarno van Overdijk
 * Date: 14-6-2022
 * Description: Scheidsrechter overview form
 */
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
    public partial class FrmScheidsrechterOverview : Form
    {

        ScheidsrechterController scheidsrechterController = new ScheidsrechterController();
        public Panel pnlForms;
        public FrmScheidsrechterOverview(Panel PnlForms)
        {
            InitializeComponent();
            pnlForms = PnlForms;
        }

        private void FrmScheidsrechterOverview_Load(object sender, EventArgs e)
        {
            //listvieuw tonen 
            lvScheidsrechter.Columns.Add("Voornaam", 100);
            lvScheidsrechter.Columns.Add("Tussenvoegsel", 150);
            lvScheidsrechter.Columns.Add("Achternaam", 100);

            //geeft itema weer als in een row
            lvScheidsrechter.View = System.Windows.Forms.View.Details;

            //bij selectie toon blaue lijn over alle colums
            lvScheidsrechter.FullRowSelect = true;

            // zorgt dat je op de header style kan klikken
            lvScheidsrechter.HeaderStyle = ColumnHeaderStyle.Clickable;

            FillListVieuw();
        }

        // method die de read in de listview zet.
        public void FillListVieuw()
        {

            List<ScheidsrechterModel> scheidsrechterList = scheidsrechterController.ReadAll();

            lvScheidsrechter.Items.Clear();

            foreach (ScheidsrechterModel item in scheidsrechterList)
            {
                //listvieuw item aanmaken

                ListViewItem lvItem = new ListViewItem(item.Voornaam);
                lvItem.SubItems.Add(item.Tussenvoegsel);
                lvItem.SubItems.Add(item.Achternaam);

                lvItem.Tag = item;

                lvScheidsrechter.Items.Add(lvItem);
            }
        }

        // de selectedindexchange ziet waneer er een speler geselecteerd is. Wanneer dit is laat hij de buttons zien.
        private void lvScheidsrechter_SelectedIndexChanged(object sender, EventArgs e)
        {
            int amountSelected = lvScheidsrechter.SelectedItems.Count;

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

        // Deze 
        private void btnWijzigen_Click(object sender, EventArgs e)
        {
            ScheidsrechterModel toBeUpdated = (ScheidsrechterModel) lvScheidsrechter.SelectedItems[0].Tag;

            // Versturen naar nieuw UI
            FrmScheidsrechterUpdate frm = new FrmScheidsrechterUpdate(this, toBeUpdated);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.TopLevel = false;
            frm.TopMost = true;
            frm.Dock = DockStyle.Fill;
            pnlForms.Controls.Clear();
            pnlForms.Controls.Add(frm);
            frm.Show();
        }

        private void btnVerwijderen_Click(object sender, EventArgs e)
        {
            // Welk item willen we verwijderen?
            ScheidsrechterModel scheidsrechterDel = (ScheidsrechterModel)lvScheidsrechter.SelectedItems[0].Tag;

            FrmScheidsrechterDelete frm = new FrmScheidsrechterDelete(scheidsrechterDel);
            frm.ShowDialog();

            FillListVieuw();
        }

        private void btnToevoegen_Click(object sender, EventArgs e)
        {
            FrmScheidsrechterAdd frm = new FrmScheidsrechterAdd(this);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.TopLevel = false;
            frm.TopMost = true;
            frm.Dock = DockStyle.Fill;
            pnlForms.Controls.Clear();
            pnlForms.Controls.Add(frm);
            frm.Show();
        }
    }
}
