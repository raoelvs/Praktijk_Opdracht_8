/*
 * Author: Quinten Kornalijnslijper
 * Date: 13-6-2022
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

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
/*            // Maakt csv bestand aan
            StreamWriter writer = File.CreateText(@"c:\Praktijk\CSV.csv");
            // Maakt de tabellen
            writer.WriteLine("ResultaatId;Punt;Overgave;WedstrijdId;WedstrijdId;SpelerId;");
            // Krijg alle items.
            List<ResultaatModel> listToCSV = new List<ResultaatModel>();
            listToCSV = ResultaatContr.ReadAll();
            foreach (ResultaatModel item in listToCSV)
            {
                // Schrijft alle taken uit
                
                string Punt = item.Punt.ToString();
                string Overgave = item.Overgave.ToString();
                string WedstrijdId = item.WedstrijdId.ToString();
                string SpelerId = item.SpelerId.ToString();
                writer.WriteLine(Punt + ";" + Overgave + ";" + WedstrijdId + ";" + SpelerId );
            }
            // kijkt of het geschreven kan worden
            bool writable = writer.BaseStream.CanWrite;

            writer.Close();

            // Bepaal of het is gelukt
            if (writable == true)
            {
                MessageBox.Show("CSV is gemaakt");
            }
            else
            {
                MessageBox.Show("CSV is mislukt");
            }*/


        }
    }
    
}
