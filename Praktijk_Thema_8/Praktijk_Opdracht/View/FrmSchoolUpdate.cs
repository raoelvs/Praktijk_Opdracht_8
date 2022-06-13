/*
 * Author: Quinten Kornalijnslijper
 * Date: 12-6-2022
 * Description: form to update a school
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
    public partial class FrmSchoolUpdate : Form
    {
        // fields
        private FrmSchoolOverview schoolOverview;
        private SchoolModel schoolToBeUpdated;
        private SchoolController schoolContr = new SchoolController();

        public FrmSchoolUpdate(FrmSchoolOverview SchoolOverview, SchoolModel School)
        {
            InitializeComponent();
            schoolOverview = SchoolOverview;
            schoolToBeUpdated = School;
        }

        /// <summary>
        /// close this form and opens the previous
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            schoolOverview.FormBorderStyle = FormBorderStyle.None;
            schoolOverview.TopLevel = false;
            schoolOverview.TopMost = true;
            schoolOverview.Dock = DockStyle.Fill;
            this.Close();
            schoolOverview.pnlForms.Controls.Add(schoolOverview);
            schoolOverview.Show();
        }

        /// <summary>
        /// try to update the school
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            // checks if schoolnaam is not empty
            if (txtNaam.Text != null)
            {
                SchoolModel school = new SchoolModel();
                school.Naam = txtNaam.Text;
                school.SchoolId = schoolToBeUpdated.SchoolId;

                // try to update the school
                try
                {
                    schoolContr.Update(school);
                    MessageBox.Show("School(" + school.Naam + ") is bewerkt");
                    schoolOverview.FormBorderStyle = FormBorderStyle.None;
                    schoolOverview.TopLevel = false;
                    schoolOverview.TopMost = true;
                    schoolOverview.Dock = DockStyle.Fill;
                    schoolOverview.FillListView();
                    this.Close();
                    schoolOverview.pnlForms.Controls.Add(schoolOverview);
                    schoolOverview.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Er is iets misgegaan. School(" + school.Naam + ") niet kunnen bewerken");
                }
            }
            else
            {
                MessageBox.Show("Vul alle velden in!");
            }
        }

        /// <summary>
        /// set the naam value that we already know
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSchoolUpdate_Load(object sender, EventArgs e)
        {
            txtNaam.Text = schoolToBeUpdated.Naam;
        }
    }
}
