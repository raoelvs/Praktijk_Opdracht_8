/*
 * Author: Quinten Kornalijnslijper
 * Date: 12-6-2022
 * Description: form to confirm a delete for school
 */
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
    public partial class FrmSchoolDelete : Form
    {
        // fields
        private SchoolModel school;
        private SchoolController schoolContr = new SchoolController();
        public FrmSchoolDelete(SchoolModel School)
        {
            InitializeComponent();
            school = School;
        }

        /// <summary>
        /// close this form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// try to delete school
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnYes_Click(object sender, EventArgs e)
        {
            // Verwijderen!
            // try to delete school
            try
            {
                int speler = schoolContr.Delete(school);
                MessageBox.Show("Het is geluk om de school te verwijderen)");

                this.Close();
            }
            catch (SqlException ex)
            {
                // relation exception
                if (ex.Number == 547)
                {
                    this.Close();

                    MessageBox.Show("Deze school: (" + school.Naam + ") heeft nog een relatie. " +
                        "Verwijder deze school eerst bij de spelers");

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

        /// <summary>
        /// Gives description for deleting the school
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSchoolDelete_Load(object sender, EventArgs e)
        {
            txtDescription.Text = "Weet u zeker dat u de school(" + school.Naam + ") wilt verwijderen?";
        }
    }
}
