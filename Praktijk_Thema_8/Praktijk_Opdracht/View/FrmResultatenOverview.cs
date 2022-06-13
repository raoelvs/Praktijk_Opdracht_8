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


                lvItem.Tag = item;

                lvResultaat.Items.Add(lvItem);
            }

        }
    }
}
