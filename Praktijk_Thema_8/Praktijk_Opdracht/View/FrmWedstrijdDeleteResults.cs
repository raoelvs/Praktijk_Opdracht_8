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
    public partial class FrmWedstrijdDeleteResults : Form
    {
        private WedstrijdModel wedstrijd;
        private WedstrijdController wedsContr = new WedstrijdController();
        private ResultaatController resuContr = new ResultaatController();
        public FrmWedstrijdDeleteResults(WedstrijdModel Wedstrijd)
        {
            InitializeComponent();
            wedstrijd = Wedstrijd;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                resuContr.DeleteAllFromWedstrijd(wedstrijd);
                wedsContr.Delete(wedstrijd);
                MessageBox.Show("Wedstrijd met alle resultaten verwijdert");
                this.Close();              
            }
            catch(Exception ex)
            {
                MessageBox.Show("Er is iets misgegaan");
                this.Close();
            }
            
        }
    }
}
