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
    public partial class FrmWedstrijdAdd : Form
    {
        private SpelerController spelContr = new SpelerController();
        private ScheidsrechterController scheidsContr = new ScheidsrechterController();
        private int[,] RoundWithMatches = new int[5, 1]
            {
                { 16 },
                { 8 },
                { 4 },
                { 2 },
                { 1 }
            };
        private FrmWedstrijdOverview wedstrijdOverview;
        public FrmWedstrijdAdd(FrmWedstrijdOverview WedstrijdOverview)
        {
            InitializeComponent();
            wedstrijdOverview = WedstrijdOverview;
        }

        private void FrmWedstrijdAdd_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < RoundWithMatches.Length; i++)
            {
                cmbRound.Items.Add(i + 1);
            }
            cmbWedstrijd.Enabled = false;
        }

        private void cmbRound_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbRound.SelectedItem != null)
            {
                
            }
        }

        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            wedstrijdOverview.FormBorderStyle = FormBorderStyle.None;
            wedstrijdOverview.TopLevel = false;
            wedstrijdOverview.TopMost = true;
            wedstrijdOverview.Dock = DockStyle.Fill;
            this.Close();
            wedstrijdOverview.pnlForms.Controls.Add(wedstrijdOverview);
            wedstrijdOverview.Show();
        }
    }
}
