﻿/*
 * Author: Raoel van Schaijk
 * Date: 10-6-2022
 * Description: Resultaat controller with methods for CRUD
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
    public partial class FrmResultatenOverview : Form
    {
        private ResultaatController ResultaatContr = new ResultaatController();
        private WedstrijdController wedsContr = new WedstrijdController();
        public Panel pnlForms;
        public Panel PnlResultaatUpdate;
        public FrmResultatenOverview(Panel PnlForms)
        {
            InitializeComponent();
            pnlForms = PnlForms;
            PnlResultaatUpdate = pnlResultaatUpdate;
        }

        private void FrmResultaten_Load(object sender, EventArgs e)
        {
            lvResultaat.Columns.Add("Thuis speler", 250);
            lvResultaat.Columns.Add("Uit speler", 250);
            lvResultaat.Columns.Add("Starttijd", 150);
            lvResultaat.Columns.Add("Eindtijd", 150);
            lvResultaat.Columns.Add("Ronde", 100);
            lvResultaat.Columns.Add("Wedstrijd", 100);
/*            lvResultaat.Columns.Add("Spelernaam", 100);
            lvResultaat.Columns.Add("Geboortedatum", 150);
            lvResultaat.Columns.Add("Groep", 100);*/

            lvResultaat.View = System.Windows.Forms.View.Details;

            lvResultaat.FullRowSelect = true;

            lvResultaat.HeaderStyle = ColumnHeaderStyle.Clickable;

            FillListView();
        }

        public void FillListView()
        {
            List<WedstrijdModel> wedstrijdList = wedsContr.ReadAll();

            lvResultaat.Items.Clear();

            foreach (WedstrijdModel item in wedstrijdList)
            {
                //listvieuw item aanmaken

                ListViewItem lvItem = new ListViewItem(item.Thuis.FullName);
                lvItem.SubItems.Add(item.Uit.FullName);
                lvItem.SubItems.Add(item.Starttijd.ToShortDateString() + " " + item.Starttijd.ToShortTimeString());
                lvItem.SubItems.Add(item.Eindtijd.ToShortDateString() + " " + item.Eindtijd.ToShortTimeString());
                lvItem.SubItems.Add(item.Ronde.ToString());
                lvItem.SubItems.Add(item.WedstrijdNummer.ToString());

                lvItem.Tag = item;

                lvResultaat.Items.Add(lvItem);
            }

        }

        private void lvResultaat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvResultaat.SelectedItems.Count == 1)
            {
                FrmResultaatUpdate frm = new FrmResultaatUpdate(this, (WedstrijdModel)lvResultaat.SelectedItems[0].Tag);
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.TopLevel = false;
                frm.TopMost = true;
                frm.Dock = DockStyle.Fill;                
                pnlResultaatUpdate.Controls.Add(frm);
                frm.Show();
            }
            else
            {
                pnlResultaatUpdate.Controls.Clear();
            }
        }
    }
}
