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
    public partial class FrmSchoolOverview : Form
    {
        private SchoolController schoolContr = new SchoolController();
        private Panel pnlForms;
        public FrmSchoolOverview(Panel PnlForms)
        {
            InitializeComponent();
            pnlForms = PnlForms;
        }

        private void FrmSchoolOverview_Load(object sender, EventArgs e)
        {
            lvScholen.Columns.Add("Naam", 500);

            lvScholen.FullRowSelect = true;

            lvScholen.View = System.Windows.Forms.View.Details;

            FillListView();
        }

        public void FillListView()
        {
            List<SchoolModel> schoolList = schoolContr.ReadAll();
            foreach(SchoolModel school in schoolList)
            {
                ListViewItem lvItem = new ListViewItem(school.Naam);

                lvItem.Tag = school;

                lvScholen.Items.Add(lvItem);
            }
        }
    }
}
