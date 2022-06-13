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
        private FrmSchoolOverview schoolOverview;
        private SchoolModel schoolToBeUpdated;
        private SchoolController schoolContr = new SchoolController();
        public FrmSchoolUpdate(FrmSchoolOverview SchoolOverview, SchoolModel School)
        {
            InitializeComponent();
            schoolOverview = SchoolOverview;
            schoolToBeUpdated = School;
        }

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

        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            if (txtNaam.Text != null)
            {
                SchoolModel school = new SchoolModel();
                school.Naam = txtNaam.Text;
                school.SchoolId = schoolToBeUpdated.SchoolId;
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

        private void FrmSchoolUpdate_Load(object sender, EventArgs e)
        {
            txtNaam.Text = schoolToBeUpdated.Naam;
        }
    }
}
