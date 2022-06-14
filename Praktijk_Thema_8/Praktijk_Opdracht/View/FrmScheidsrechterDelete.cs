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
    public partial class FrmScheidsrechterDelete : Form
    {

        ScheidsrechterController scheidsrechterController = new ScheidsrechterController();
        private ScheidsrechterModel delScheidsrechter;

        public FrmScheidsrechterDelete(ScheidsrechterModel scheidsrechterDel)
        {
            InitializeComponent();
            delScheidsrechter = scheidsrechterDel;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            // Verwijderen! 
            try
            {
                int rowsAffected = scheidsrechterController.Delete(delScheidsrechter);
                MessageBox.Show("Het is geluk om de scheidsrechter te verwijderen: ");


                this.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    this.Close();
                    MessageBox.Show("Deze scheidsrechter: (" + delScheidsrechter.Voornaam + " " + delScheidsrechter.Tussenvoegsel + " " + delScheidsrechter.Achternaam + ") heeft nog een relatie. " +
                        "Verwijder deze scheidsrechter eerst bij wedstrijden");
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
        }
    }
}
