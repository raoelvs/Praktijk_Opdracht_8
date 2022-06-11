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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            // Verwijderen! 
            try
            {
                int scheidsrechter = scheidsrechterController.Delete(delScheidsrechter);
                MessageBox.Show("Het is geluk om de scheidsrechter te verwijderen: ");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {

                    this.Hide();

                    FrmScheidsrechterDeleteConstraint frm = new FrmScheidsrechterDeleteConstraint(delScheidsrechter);
                    frm.Show();
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
