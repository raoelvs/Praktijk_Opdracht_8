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
    public partial class FrmInlogOverview : Form
    {
        private Panel panel;
        private ScheidsrechterController scheidsrechterController = new ScheidsrechterController();
        private string username = "Organisator";
        private string password = "P@ssword1234";
        public FrmInlogOverview(Panel Panel)
        {
            InitializeComponent();
            panel = Panel;
        }

        private void btnInloggen_Click(object sender, EventArgs e)
        {
            StartViewEditor frm = new StartViewEditor();
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.TopLevel = false;
            frm.TopMost = true;
            frm.Dock = DockStyle.Fill;
            this.Close();
            panel.Controls.Add(frm);
            frm.Show();
        }



        private void FrmInlogOverview_Load(object sender, EventArgs e)
        {

        }

        private void btnInloggen_Click_1(object sender, EventArgs e)
        {
            string gebruikersnaam = txtGebruikersnaam.Text;
            string wachtwoord = txtWachtwoord.Text;

            ScheidsrechterModel scheidsrechter = scheidsrechterController.ReadWhere(gebruikersnaam);

            if (scheidsrechter.ScheidsrechterCode != null)
            {
                if (scheidsrechter.Wachtwoord == wachtwoord)
                {
                    scheidsrechter.role = "scheidsrechter";
                    StartViewEditor frm = new StartViewEditor();
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.TopLevel = false;
                    frm.TopMost = true;
                    frm.Dock = DockStyle.Fill;
                    this.Close();
                    panel.Controls.Add(frm);
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Wachtwoord is incorrect!");

                }

            }
            else
            {
                if (username == txtGebruikersnaam.Text)
                {
                    if (password == txtWachtwoord.Text)
                    {
                        StartViewEditor frm = new StartViewEditor();
                        frm.FormBorderStyle = FormBorderStyle.None;
                        frm.TopLevel = false;
                        frm.TopMost = true;
                        frm.Dock = DockStyle.Fill;
                        this.Close();
                        panel.Controls.Add(frm);
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Wachtwoord is incorrect!");
                    }
                }

                else
                {
                    MessageBox.Show("Gebruikersnaam is incorrect!");
                }
            }
           
        }
    }
}
