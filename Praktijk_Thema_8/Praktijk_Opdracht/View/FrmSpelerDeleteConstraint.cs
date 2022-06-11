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
    public partial class FrmSpelerDeleteConstraint : Form
    {
        private SpelerController spelerController = new SpelerController();
        private SpelerModel delSpeler;

        public FrmSpelerDeleteConstraint(SpelerModel spelerDel)
        {
            InitializeComponent();
            delSpeler = spelerDel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Verwijderen! 
            try
            {
                int scheidsrechter = spelerController.DeleteConstraint(delSpeler);
                MessageBox.Show("Het is geluk om de speler te verwijderen)");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Alle andere onbekende error (geen database error i.i.g)");
                MessageBox.Show(ex.Message);
            }
        }
    }
}
