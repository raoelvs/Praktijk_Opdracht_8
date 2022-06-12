/*
 * Author: Quinten Kornalijnslijper
 * Date: 11-6-2022
 * Description: Shows all matches and has editor buttons for matches
 */
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
        //fields
        private WedstrijdController wedContr = new WedstrijdController();
        public Panel pnlForms;

        public FrmWedstrijdOverview(Panel PnlForms)
        {
            InitializeComponent();
            pnlForms = PnlForms;
        }

        /// <summary>
        /// styling listview and fill listview by this form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmWedstrijdOverview_Load(object sender, EventArgs e)
        {
            // gives de listview column names and lengths
            lvWedstrijden.Columns.Add("Ronde", 100);
            lvWedstrijden.Columns.Add("Wedstrijd", 100);
            lvWedstrijden.Columns.Add("Starttijd", 150);
            lvWedstrijden.Columns.Add("Eindtijd",150);
            lvWedstrijden.Columns.Add("Thuis speler", 250);
            lvWedstrijden.Columns.Add("Uit speler", 250);
            lvWedstrijden.Columns.Add("Scheidsrechter", 250);
            lvWedstrijden.Columns.Add("Wedstrijd winnaar", 250);

            // listview stylen
            lvWedstrijden.FullRowSelect = true;
            lvWedstrijden.View = System.Windows.Forms.View.Details;
            lvWedstrijden.MultiSelect = false;

            FillListView();

            // disable the delete and update button
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }

        /// <summary>
        /// Fills and refreshed the listview
        /// </summary>
        public void FillListView()
        {
            List<WedstrijdModel> wedstrijdList = wedContr.ReadAll();

            lvWedstrijden.Items.Clear();

            // create listview item for everey record and add it to the listview
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

                // saves data of the match in the tag
                lvItem.Tag = wedstrijd;

                lvWedstrijden.Items.Add(lvItem);
            }
        }

        /// <summary>
        /// disabled and enabled update and delete button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvWedstrijden_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Is an item selected?
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

        /// <summary>
        /// Opens the add form for matches
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// opens the update form for matches
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FrmWedstrijdUpdate frm = new FrmWedstrijdUpdate(this, (WedstrijdModel)lvWedstrijden.SelectedItems[0].Tag);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.TopLevel = false;
            frm.TopMost = true;
            frm.Dock = DockStyle.Fill;
            pnlForms.Controls.Clear();
            pnlForms.Controls.Add(frm);
            frm.Show();
        }

        /// <summary>
        /// opens a messege for deleting a match
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // selected item to delete
            FrmWedstrijdDelete frm = new FrmWedstrijdDelete((WedstrijdModel)lvWedstrijden.SelectedItems[0].Tag);
            frm.ShowDialog();

            //refresh and fill listview afrter closing the message
            FillListView();

            // disbaled the update and delete button
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }
    }
}
