using Praktijk_Opdracht.Controller;
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
    public partial class FrmSpelerDeleteConstraint : Form
    {
        private SchoolController schoolController = new SchoolController();
        private SpelerModel delSpeler;

        public FrmSpelerDeleteConstraint(SpelerModel spelerDel)
        {
            InitializeComponent();
            delSpeler = spelerDel;
        }


        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            // verwijderen
            try
            {
                int speler = schoolController.DeleteSchoolFromSpeler(delSpeler);
                MessageBox.Show("Het is geluk om de speler te verwijderen. Nu kunt u de speler verwijderen van tabellen");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Alle andere onbekende error (geen database error i.i.g)");
                MessageBox.Show(ex.Message);
            }
        }
    }
}
