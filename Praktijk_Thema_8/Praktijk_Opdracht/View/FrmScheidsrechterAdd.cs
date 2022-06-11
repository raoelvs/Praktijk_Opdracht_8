﻿using Praktijk_Opdracht.Controller;
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
    public partial class FrmScheidsrechterAdd : Form
    {

        private ScheidsrechterController scheidrechterController = new ScheidsrechterController();
        
        public FrmScheidsrechterAdd()
        {
            InitializeComponent();
        }

        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            this.Hide();

            FrmScheidsrechterOverview frm = new FrmScheidsrechterOverview();
            frm.Show();
        }

        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            ScheidsrechterModel item = new ScheidsrechterModel();

            item.ScheidsrechterCode = txtScheidsrechterCode.Text;
            item.Voornaam = txtVoornaam.Text;
            item.Tussenvoegsel = txtTussenvoegsel.Text;
            item.Achternaam = txtAchternaam.Text;
            item.Wachtwoord = txtWachtwoord.Text;

            int rowsAffected = scheidrechterController.Create(item);

            if (rowsAffected > 0)
            {
                this.DialogResult = DialogResult.Yes;
            }
            else
            {
                this.DialogResult = DialogResult.No;
            }

            this.Hide();

            FrmScheidsrechterOverview frm = new FrmScheidsrechterOverview();
            frm.Show();
        }

        private void btnResultaten_Click(object sender, EventArgs e)
        {
            this.Hide();

            FrmResultatenOverview frmResultaten = new FrmResultatenOverview();
            frmResultaten.Show();
        }

        private void btnSpelers_Click(object sender, EventArgs e)
        {
            this.Hide();

            FrmSpelersOverview frmSpeler = new FrmSpelersOverview();
            frmSpeler.Show();
        }

        private void btnScholen_Click(object sender, EventArgs e)
        {
            this.Hide();

            //FrmScholenOverview frmScholen = new FrmScholenOverview();
            //frmScholen.Show();
        }

        private void btnScheidsrechter_Click(object sender, EventArgs e)
        {
            this.Hide();

            FrmScheidsrechterOverview frmScheidsrechter = new FrmScheidsrechterOverview();
            frmScheidsrechter.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();

            StartView frmStartView = new StartView();
            frmStartView.Show();
        }

        private void btnSluiten_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}