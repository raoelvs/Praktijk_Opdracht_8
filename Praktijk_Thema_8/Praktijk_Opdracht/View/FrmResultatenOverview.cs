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
    public partial class FrmResultatenOverview : Form
    {
        ResultaatController ResultaatContr = new ResultaatController();
        public FrmResultatenOverview()
        {
            InitializeComponent();
        }

        private void FrmResultaten_Load(object sender, EventArgs e)
        {
            lvResultaat.Columns.Add("Punt", 100);
            lvResultaat.Columns.Add("Overgave", 100);
            lvResultaat.Columns.Add("Starttijd", 150);
            lvResultaat.Columns.Add("Eindtijd", 150);
            lvResultaat.Columns.Add("Ronde", 100);
            lvResultaat.Columns.Add("WedstrijdNummer", 100);
            lvResultaat.Columns.Add("Spelernaam", 100);
            lvResultaat.Columns.Add("Geboortedatum", 150);
            lvResultaat.Columns.Add("Groep", 100);

            lvResultaat.View = System.Windows.Forms.View.Details;

            lvResultaat.FullRowSelect = true;

            lvResultaat.HeaderStyle = ColumnHeaderStyle.Clickable;

            FillList();
        }

        private void FillList()
        {
            List<ResultaatModel> resultaatList = ResultaatContr.ReadAll();

            lvResultaat.Items.Clear();

            foreach (ResultaatModel item in resultaatList)
            {
                //listvieuw item aanmaken

                ListViewItem lvItem = new ListViewItem(item.Punt.ToString());
                lvItem.SubItems.Add(item.Overgave.ToString());
                lvItem.SubItems.Add(item.WedstrijdId.Starttijd.ToShortDateString() + " " + item.WedstrijdId.Starttijd.ToShortTimeString());
                lvItem.SubItems.Add(item.WedstrijdId.Eindtijd.ToShortDateString() + " " + item.WedstrijdId.Eindtijd.ToShortTimeString());
                lvItem.SubItems.Add(item.WedstrijdId.Ronde.ToString());
                lvItem.SubItems.Add(item.WedstrijdId.WedstrijdNummer.ToString());
                lvItem.SubItems.Add(item.SpelerId.FullName);
                lvItem.SubItems.Add(item.SpelerId.Geboortedatum.ToString());
                lvItem.SubItems.Add(item.SpelerId.Groep.ToString());

                lvItem.Tag = item;

                lvResultaat.Items.Add(lvItem);
            }

        }
    }
}
