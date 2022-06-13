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
    public partial class FrmScheidsrechterAdd : Form
    {

        private ScheidsrechterController scheidrechterController = new ScheidsrechterController();
        private FrmScheidsrechterOverview scheidsrechterOverview;
        public FrmScheidsrechterAdd( FrmScheidsrechterOverview ScheidsrechterOverview)
        {
            InitializeComponent();

            scheidsrechterOverview = ScheidsrechterOverview;
        }
        
        // Speler toevoegen anuleren en terug naar scheidsrechter overview
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

        // Speler toevoegen  daarna terug naar scheidsrechter overview
        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            ScheidsrechterModel item = new ScheidsrechterModel();

            item.ScheidsrechterCode = txtScheidsrechterCode.Text;
            item.Voornaam = txtVoornaam.Text;
            item.Tussenvoegsel = txtTussenvoegsel.Text;
            item.Achternaam = txtAchternaam.Text;
            item.Wachtwoord = txtWachtwoord.Text;

            // als er een sql fout optreed vangt hij hem op in de catch
            try
            {
                scheidrechterController.Create(item);
                MessageBox.Show("Scheidsrechter is toegevoegd");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Er is iets misgegaan");
            }

            scheidsrechterOverview.FormBorderStyle = FormBorderStyle.None;
            scheidsrechterOverview.TopLevel = false;
            scheidsrechterOverview.TopMost = true;
            scheidsrechterOverview.Dock = DockStyle.Fill;
            this.Close();
            scheidsrechterOverview.FillListVieuw();
            scheidsrechterOverview.pnlForms.Controls.Add(scheidsrechterOverview);
            scheidsrechterOverview.Show();
        }
    }
}
