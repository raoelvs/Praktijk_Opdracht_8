/*
 * Author: Jarno van Overdijk
 * Date: 14-6-2022
 * Description: Speler add form
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
    public partial class FrmSpelerAdd : Form
    {
        private SpelerController spelerController = new SpelerController();
        private SchoolController schoolController = new SchoolController();
        private FrmSpelersOverview spelersOverview;

        public FrmSpelerAdd(FrmSpelersOverview SpelersOverview)
        {
            InitializeComponent();
            spelersOverview = SpelersOverview;
        }

        private void FrmSpelerAdd_Load(object sender, EventArgs e)
        {
            List<SchoolModel> schoolList = schoolController.ReadAll();

            foreach(SchoolModel school in schoolList)
            {
                cbSchool.Items.Add(school);
            }

            cbSchool.DisplayMember = "Naam";
        }

        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            spelersOverview.FormBorderStyle = FormBorderStyle.None;
            spelersOverview.TopLevel = false;
            spelersOverview.TopMost = true;
            spelersOverview.Dock = DockStyle.Fill;
            this.Close();
            spelersOverview.pnlForms.Controls.Add(spelersOverview);
            spelersOverview.Show();
        }

        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            if (txtVoornaam.Text == "" ||
                txtAchternaam.Text == "" ||
                txtGroep.Text == "" ||
                cbSchool.SelectedItem == null)
            {
                MessageBox.Show("Alle verplichten velden zijn niet gevuld");
            }
            else
            {
                SpelerModel item = new SpelerModel();

                item.Voornaam = txtVoornaam.Text;
                item.Tussenvoegsel = txtTussenvoegsel.Text;
                item.Achternaam = txtAchternaam.Text;
                item.Geboortedatum = dtpGeboortedatum.Value;
                item.Groep = Convert.ToInt32(txtGroep.Text);
                item.SchoolId = (SchoolModel)cbSchool.SelectedItem;

                try
                {
                    int rowsAffected = spelerController.Create(item);

                    if (rowsAffected > 0)
                    {
                        spelersOverview.FormBorderStyle = FormBorderStyle.None;
                        spelersOverview.TopLevel = false;
                        spelersOverview.TopMost = true;
                        spelersOverview.Dock = DockStyle.Fill;
                        this.Close();
                        spelersOverview.FillListVieuw();
                        spelersOverview.pnlForms.Controls.Add(spelersOverview);
                        spelersOverview.Show();

                        MessageBox.Show("Speler is toegevoegd");
                    }
                    else
                    {
                        MessageBox.Show("Speler " + item.FullName + " is niet toegevoegd");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("er is iets mis gegeaan");
                }
            }
            
        }
    }
}
