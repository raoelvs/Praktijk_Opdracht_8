/*
 * Author: Jarno van Overdijk
 * Date: 14-6-2022
 * Description: Scheidsrechter update form
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
    public partial class FrmScheidsrechterUpdate : Form
    {
        private ScheidsrechterController scheidsrechterController = new ScheidsrechterController();
        private ScheidsrechterModel permScheidsrechter;
        private FrmScheidsrechterOverview scheidsrechterOverview;

        public FrmScheidsrechterUpdate(FrmScheidsrechterOverview ScheidsrechterOverview, ScheidsrechterModel tmpScheidsrechter)
        {
            InitializeComponent();

            //tijdelijk opslaan in een globale variable
            permScheidsrechter = tmpScheidsrechter;
            scheidsrechterOverview = ScheidsrechterOverview;
        }

        private void FrmScheidsrechterUpdate_Load(object sender, EventArgs e)
        {
            //text boxen vullen met informatie die geselecteerd is in de listview
            txtVoornaam.Text = permScheidsrechter.Voornaam;
            txtTussenvoegsel.Text = permScheidsrechter.Tussenvoegsel;
            txtAchternaam.Text = permScheidsrechter.Achternaam;
        }

        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            if (txtVoornaam.Text != "" &&
                txtAchternaam.Text != "")
            {
                // scheidsrechtermodel aanmaken met de aagepaste gegevens
                ScheidsrechterModel updatedScheidsrechter = new ScheidsrechterModel();

                updatedScheidsrechter.Voornaam = txtVoornaam.Text;
                updatedScheidsrechter.Tussenvoegsel = txtTussenvoegsel.Text;
                updatedScheidsrechter.Achternaam = txtAchternaam.Text;

                //speler gebruiken van de geslecteerde speler uit listview
                updatedScheidsrechter.ScheidsrechterCode = permScheidsrechter.ScheidsrechterCode;
                updatedScheidsrechter.Wachtwoord = permScheidsrechter.Wachtwoord;


                try
                {
                    scheidsrechterController.Update(updatedScheidsrechter);
                    MessageBox.Show("Scheidsrechter is geupdate");
                    scheidsrechterOverview.FormBorderStyle = FormBorderStyle.None;
                    scheidsrechterOverview.TopLevel = false;
                    scheidsrechterOverview.TopMost = true;
                    scheidsrechterOverview.Dock = DockStyle.Fill;
                    this.Close();
                    scheidsrechterOverview.FillListVieuw();
                    scheidsrechterOverview.pnlForms.Controls.Add(scheidsrechterOverview);
                    scheidsrechterOverview.Show();
                }
                catch
                {
                    MessageBox.Show("Het is niet gelukt");
                }
            }
            else
            {
                MessageBox.Show("Niet alle verplichte velden zijn gevuld");
            }
           

        }

        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            scheidsrechterOverview.FormBorderStyle = FormBorderStyle.None;
            scheidsrechterOverview.TopLevel = false;
            scheidsrechterOverview.TopMost = true;
            scheidsrechterOverview.Dock = DockStyle.Fill;
            this.Close();
            scheidsrechterOverview.pnlForms.Controls.Add(scheidsrechterOverview);
            scheidsrechterOverview.Show();
        }
    }
}
