/*
 * Author: Quinten Kornalijnslijper
 * Date: 10-6-2022
 * Description: startfrom 
 */
using Praktijk_Opdracht.Controller;
using Praktijk_Opdracht.Model;
using Praktijk_Opdracht.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praktijk_Opdracht
{
    public partial class StartView : Form
    {
        // fields
        ResultaatController ResultaatContr = new ResultaatController();
        private WedstrijdController wedsContr = new WedstrijdController();

        public StartView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// close application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// open inlog form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInlog_Click(object sender, EventArgs e)
        {
            // create a new inlog form
            FrmInlogOverview frm = new FrmInlogOverview(this.pForms);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.TopLevel = false;
            frm.TopMost = true;
            frm.Dock = DockStyle.Fill;
            // add form to panel
            pForms.Controls.Clear();
            pForms.Controls.Add(frm);
            //show inlog form
            frm.Show();
        }

        /// <summary>
        /// open knockout scheme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartView_Load(object sender, EventArgs e)
        {
            // create a new knockout scheme
            FrmKnockoutScheme frm = new FrmKnockoutScheme();
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.TopLevel = false;
            frm.TopMost = true;
            frm.Dock = DockStyle.Fill;
            // add form to  panel
            pContainer.Controls.Add(frm);
            //show knockout scheme
            frm.Show();
        }

        /// <summary>
        /// Exporteerd wedstrijd data naar CSV
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            // probeert CSV uit te voeren
            try
            {
                // Maakt CSV bestand aan
                StreamWriter writer = File.CreateText(@"c:\Praktijk\CSV.csv");

                // Maakt de tabellen
                writer.WriteLine("Wedstrijd Ronde;Wedstrijd Nummer;Starttijd;Eindtijd;Thuis Speler;School;Score;Overgave;Uit Speler;School;Score;Overgave;Wedstrijd Winnaar");

                List<WedstrijdModel> listToCSV = wedsContr.ReadAll();

                
                foreach (WedstrijdModel item in listToCSV)
                {
                    ResultaatModel thuis = ResultaatContr.ReadAllWedstrijdResultaat(item.Ronde, item.WedstrijdNummer, item.Thuis);
                    ResultaatModel uit = ResultaatContr.ReadAllWedstrijdResultaat(item.Ronde, item.WedstrijdNummer, item.Uit);

                    // Schrijft alle taken uit
                    string Ronde = item.Ronde.ToString();
                    string Wedstrijd = item.WedstrijdNummer.ToString();
                    string Starttijd = item.Starttijd.ToShortDateString() + " " + item.Starttijd.ToShortTimeString();
                    string Eindtijd = item.Eindtijd.ToShortDateString() + " " + item.Eindtijd.ToShortTimeString();
                    string ThuisSpeler = item.Thuis.FullName;
                    string ThuisSchool = item.Thuis.SchoolId.Naam;
                    string ThuisPunt = thuis.Punt.ToString();
                    string ThuisOvergave = thuis.Overgave.ToString();
                    string UitSpeler = item.Uit.FullName;
                    string UitSchool = item.Uit.SchoolId.Naam;
                    string UitPunt = uit.Punt.ToString();
                    string UitOvergave = uit.Overgave.ToString();
                    string Winnaar = item.Winnaar.FullName;

                    writer.WriteLine(Ronde + ";" + Wedstrijd + ";" + Starttijd + ";" + Eindtijd + ";" + ThuisSpeler + ";" + ThuisSchool + ";" + ThuisPunt + ";" + ThuisOvergave + ";" + UitSpeler + ";" + UitSchool + ";" + UitPunt + ";" + UitOvergave + ";" + Winnaar + ";");
                }

                // kijkt of het geschreven kan worden
                bool writable = writer.BaseStream.CanWrite;

                writer.Close();

                // Bepaalt of het is gelukt
                if (writable == true)
                {
                    MessageBox.Show("CSV is gemaakt");
                }
                else
                {
                    MessageBox.Show("CSV is mislukt");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CSV is mislukt te exporteren, dit kan zijn door open bestand.");
            }
        }
    }
    
}
