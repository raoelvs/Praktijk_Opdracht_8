﻿using Praktijk_Opdracht.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praktijk_Opdracht
{
    public partial class StartView : Form
    {
        public StartView()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnInlog_Click(object sender, EventArgs e)
        {
            
            
            
            // code om frm spelers te starten om een test te doen
            //FrmSpelersOverview frm = new FrmSpelersOverview();
            //frm.Show();
        }
    }
}
