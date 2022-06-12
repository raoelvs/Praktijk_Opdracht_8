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
    public partial class FrmWedstrijdOverview : Form
    {
        private WedstrijdController wedContr = new WedstrijdController();
        public Panel pnlForms;
        public FrmWedstrijdOverview(Panel PnlForms)
        {
            InitializeComponent();
            pnlForms = PnlForms;
        }

        private void FrmWedstrijdOverview_Load(object sender, EventArgs e)
        {
            lvWedstrijden.Columns.Add("Ronde", 100);
            lvWedstrijden.Columns.Add("Wedstrijd", 100);
            lvWedstrijden.Columns.Add("Starttijd", 150);
            lvWedstrijden.Columns.Add("Eindtijd",150);
            lvWedstrijden.Columns.Add("Thuis speler", 250);
            lvWedstrijden.Columns.Add("Uit speler", 250);
            lvWedstrijden.Columns.Add("Scheidsrechter", 250);
            lvWedstrijden.Columns.Add("Wedstrijd winnaar", 250);

            lvWedstrijden.FullRowSelect = true;
            lvWedstrijden.View = System.Windows.Forms.View.Details;
            lvWedstrijden.MultiSelect = false;

            FillListView();

            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }

        public void FillListView()
        {
            List<WedstrijdModel> wedstrijdList = wedContr.ReadAll();

            lvWedstrijden.Items.Clear();

            foreach (WedstrijdModel wedstrijd in wedstrijdList)
            {
                ListViewItem lvItem = new ListViewItem(wedstrijd.Ronde.ToString());
                lvItem.SubItems.Add(wedstrijd.WedstrijdNummer.ToString());
                lvItem.SubItems.Add(wedstrijd.Starttijd.ToShortDateString() + " " + wedstrijd.Starttijd.ToShortTimeString());
                lvItem.SubItems.Add(wedstrijd.Eindtijd.ToShortDateString() + " " + wedstrijd.Eindtijd.ToShortTimeString());
                lvItem.SubItems.Add(wedstrijd.Thuis.FullName);
                lvItem.SubItems.Add(wedstrijd.Uit.FullName);
                lvItem.SubItems.Add(wedstrijd.ScheidsrechterCode.FullName);
                lvItem.SubItems.Add("Onbekend");
                if (wedstrijd.Winnaar.SpelerId != 0)
                {
                    lvItem.SubItems.Add(wedstrijd.Winnaar.FullName);
                }

                lvItem.Tag = wedstrijd;

                lvWedstrijden.Items.Add(lvItem);
            }
        }

        private void lvWedstrijden_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvWedstrijden.SelectedItems.Count == 1)
            {
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmWedstrijdAdd frm = new FrmWedstrijdAdd(this);
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
