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
    public partial class Spelers : Form
    {

        SpelerController spelerController = new SpelerController();

        public Spelers()
        {
            InitializeComponent();
        }

        private void Spelers_Load(object sender, EventArgs e)
        {
            //listvieuw tonen 
            lvSpeler.Columns.Add("SpelerID", 50);
            lvSpeler.Columns.Add("Voornaam", 150);
            lvSpeler.Columns.Add("Tussenvoegsel", 150);
            lvSpeler.Columns.Add("Achternaam", 150);
            lvSpeler.Columns.Add("Geboortedatum", 150);
            lvSpeler.Columns.Add("Groep", 150);
            lvSpeler.Columns.Add("SchoolId", 150);
            lvSpeler.Columns.Add("SchoolNaam", 50);

            //geeft itema weer als in een row
            lvSpeler.View = System.Windows.Forms.View.Details;

            //bij selectie toon blaue lijn over alle colums
            lvSpeler.FullRowSelect = true;

            // zorgt dat je op de header style kan klikken
            lvSpeler.HeaderStyle = ColumnHeaderStyle.Clickable;

            FillListVieuw();
        }

        private void FillListVieuw()
        {

            List<SpelerModel> spelerList = spelerController.ReadAll();

            lvSpeler.Items.Clear();

            foreach (SpelerModel item in spelerList)
            {
                //listvieuw item aanmaken

                ListViewItem lvItem = new ListViewItem(item.SpelerId.ToString());
                lvItem.SubItems.Add(item.Voornaam);
                lvItem.SubItems.Add(item.Tussenvoegsel);
                lvItem.SubItems.Add(item.Achternaam);
                lvItem.SubItems.Add(item.Geboortedatum.ToString());
                lvItem.SubItems.Add(item.Groep.ToString());
                lvItem.SubItems.Add(item.SchoolId.SchoolId.ToString());
                lvItem.SubItems.Add(item.SchoolId.Naam);

                lvItem.Tag = item;

                lvSpeler.Items.Add(lvItem);
            }
        }

        private void btnVerwijderen_Click(object sender, EventArgs e)
        {
            // Welk item willen we verwijderen?
            SpelerModel spelerDel = (SpelerModel)lvSpeler.SelectedItems[0].Tag;

            // Verwijderen! 
            try
            {
                int doctor = spelerController.Delete(spelerDel);
                MessageBox.Show("Het is geluk om de episode te verwijderen aantal rows affected: " + doctor);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    MessageBox.Show("Deze Speler (" + spelerDel.SpelerId + ") heeft nog een relatie met een andere tabel");
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
