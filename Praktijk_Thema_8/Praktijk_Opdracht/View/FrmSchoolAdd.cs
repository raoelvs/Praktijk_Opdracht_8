/*
 * Author: Quinten Kornalijnslijper
 * Date: 12-6-2022
 * Description: form to show all schools
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
    public partial class FrmSchoolAdd : Form
    {
        // fields
        private FrmSchoolOverview schoolOverview;
        private SchoolController schoolContr = new SchoolController();
        public FrmSchoolAdd(FrmSchoolOverview SchoolOverview)
        {
            InitializeComponent();
            schoolOverview = SchoolOverview;
        }

        /// <summary>
        /// close this form and go to the previous
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
        /// try to add school
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            // checks if naam is empty
            if(txtNaam.Text != "")
            {
                SchoolModel school = new SchoolModel();
                school.Naam = txtNaam.Text;
                // try to add school
                try
                {
                    schoolContr.Create(school);
                    MessageBox.Show("School(" + school.Naam + ") is toegevoegd");
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
                    MessageBox.Show("Er is iets misgegaan. School(" + school.Naam + ") niet kunnen toevoegen");
                }
            }
            else
            {
                MessageBox.Show("Vul alle velden in!");
            }    
        }
    }
}
