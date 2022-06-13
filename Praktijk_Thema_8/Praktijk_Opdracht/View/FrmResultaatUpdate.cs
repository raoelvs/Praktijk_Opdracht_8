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
    public partial class FrmResultaatUpdate : Form
    {
        private ResultaatController ResultaatController = new ResultaatController();
        private SpelerController spelContr = new SpelerController();
        private WedstrijdController wedsContr = new WedstrijdController();

        private int thuisScore;
        private int uitScore;

        private WedstrijdModel wedstrijd;
        private FrmResultatenOverview resultaatOverview;

        public FrmResultaatUpdate(FrmResultatenOverview ResultatenOverview, WedstrijdModel Wedstrijd)
        {
            InitializeComponent();
            resultaatOverview = ResultatenOverview;
            wedstrijd = Wedstrijd;
            
        }

        private void FrmResultaatUpdate_Load(object sender, EventArgs e)
        {
            ResultaatModel thuisSpeler = ResultaatController.ReadWhereMatchPlayer(wedstrijd.WedstrijdId, wedstrijd.Thuis.SpelerId);
            ResultaatModel uitSpeler = ResultaatController.ReadWhereMatchPlayer(wedstrijd.WedstrijdId, wedstrijd.Uit.SpelerId);

            lblThuisNaam.Text = wedstrijd.Thuis.FullName;
            lblUitNaam.Text = wedstrijd.Uit.FullName;

            lblThuis.Text = thuisSpeler.Punt.ToString();
            lblUit.Text = uitSpeler.Punt.ToString();

            ckbThuis.Checked= thuisSpeler.Overgave;
            ckbUit.Checked = uitSpeler.Overgave;

            cmbWinnaar.Items.Add(wedstrijd.Thuis);
            cmbWinnaar.Items.Add(wedstrijd.Uit);

            cmbWinnaar.DisplayMember = "FullName";

            thuisScore = Convert.ToInt32(lblThuis.Text);
            uitScore = Convert.ToInt32(lblUit.Text);
        }

        private void btnThuisMin_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lblThuis.Text) > 0 )
            {
                thuisScore -= 1;
                lblThuis.Text = thuisScore.ToString();
            }
        }

        private void btnThuisPlus_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lblThuis.Text) < 10)
            {
                thuisScore += 1;
                lblThuis.Text = thuisScore.ToString();
            }
        }

        private void btnUitMin_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lblUit.Text) > 0)
            {
                uitScore -= 1;
                lblUit.Text = uitScore.ToString();
            }
        }

        private void btnuitPlus_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lblUit.Text) < 10)
            {
                uitScore += 1;
                lblUit.Text = uitScore.ToString();
            }
        }

        private void btnOpslaan_Click(object sender, EventArgs e)
        {

        }
    }
}
