﻿using Praktijk_Opdracht.Controller;
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

        public FrmScheidsrechterOverview()
        {
            InitializeComponent();
        }

        private void FrmScheidsrechterOverview_Load(object sender, EventArgs e)
        {
            //listvieuw tonen 
            lvScheidsrechter.Columns.Add("Voornaam", 100);
            lvScheidsrechter.Columns.Add("Tussenvoegsel", 100);
            lvScheidsrechter.Columns.Add("Achternaam", 100);

            //geeft itema weer als in een row
            lvScheidsrechter.View = System.Windows.Forms.View.Details;

            //bij selectie toon blaue lijn over alle colums
            lvScheidsrechter.FullRowSelect = true;

            // zorgt dat je op de header style kan klikken
            lvScheidsrechter.HeaderStyle = ColumnHeaderStyle.Clickable;

            FillListVieuw();
        }

        private void FillListVieuw()
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

        private void btnSluiten_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnWijzigen_Click(object sender, EventArgs e)
        {
            //het sluiten van huidige sherm
            this.Hide();

            ScheidsrechterModel toBeUpdated = (ScheidsrechterModel) lvScheidsrechter.SelectedItems[0].Tag;

            // Versturen naar nieuw UI
            FrmScheidsrechterUpdate frm = new FrmScheidsrechterUpdate(toBeUpdated);
            frm.Show();

            //frm.ShowDialog();

            FillListVieuw();
        }

        private void btnVerwijderen_Click(object sender, EventArgs e)
        {
            // Welk item willen we verwijderen?
            ScheidsrechterModel scheidsrechterDel = (ScheidsrechterModel)lvScheidsrechter.SelectedItems[0].Tag;

            // Verwijderen! 
            try
            {
                int doctor = scheidsrechterController.Delete(scheidsrechterDel);
                MessageBox.Show("Het is geluk om de episode te verwijderen aantal rows affected: " + doctor);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    MessageBox.Show("Deze Speler (" + scheidsrechterDel.Voornaam + scheidsrechterDel.Tussenvoegsel + scheidsrechterDel.Achternaam + ") heeft nog een relatie met een andere tabel");
                }
                else
                {
                    MessageBox.Show("Onbekende database error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Alle andere onbekende error (geen database error i.i.g)");
                MessageBox.Show(ex.Message);
            }

            FillListVieuw();
        }
    }
}
