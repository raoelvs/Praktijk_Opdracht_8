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
    public partial class StartViewEditor : Form
    {
        private string role;
        public StartViewEditor(string Role)
        {
            InitializeComponent();
            role = Role;
        }

        private void btnSluiten_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void StartViewEditor_Load(object sender, EventArgs e)
        {
            FrmKnockoutScheme frm = new FrmKnockoutScheme();
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.TopLevel = false;
            frm.TopMost = true;
            frm.Dock = DockStyle.Fill;
            pnlForms.Controls.Add(frm);
            frm.Show();

            if(role == "Scheidsrechter")
            {
                btnScheidsrechter.Enabled = false;
                btnScholen.Enabled = false;
                btnSpelers.Enabled = false;
                btnWedstrijden.Enabled = false;
            }
            else if (role == "Organisator")
            {
                btnResultaten.Enabled = false;
            }
            else
            {
                btnResultaten.Enabled = false;
                btnScheidsrechter.Enabled = false;
                btnScholen.Enabled = false;
                btnSpelers.Enabled = false;
                btnWedstrijden.Enabled = false;
            }
        }

        private void btnScheidsrechter_Click(object sender, EventArgs e)
        {
            FrmScheidsrechterOverview frm = new FrmScheidsrechterOverview(pnlForms);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.TopLevel = false;
            frm.TopMost = true;
            frm.Dock = DockStyle.Fill;
            pnlForms.Controls.Clear();
            pnlForms.Controls.Add(frm);
            frm.Show();
        }

        private void btnSpelers_Click(object sender, EventArgs e)
        {
            FrmSpelersOverview frm = new FrmSpelersOverview(pnlForms);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.TopLevel = false;
            frm.TopMost = true;
            frm.Dock = DockStyle.Fill;
            pnlForms.Controls.Clear();
            pnlForms.Controls.Add(frm);
            frm.Show();
        }

        private void btnResultaten_Click(object sender, EventArgs e)
        {
            FrmResultatenOverview frm = new FrmResultatenOverview();
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.TopLevel = false;
            frm.TopMost = true;
            frm.Dock = DockStyle.Fill;
            pnlForms.Controls.Clear();
            pnlForms.Controls.Add(frm);
            frm.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            FrmKnockoutScheme frm = new FrmKnockoutScheme();
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.TopLevel = false;
            frm.TopMost = true;
            frm.Dock = DockStyle.Fill;
            pnlForms.Controls.Clear();
            pnlForms.Controls.Add(frm);
            frm.Show();
        }

        private void btnWedstrijden_Click(object sender, EventArgs e)
        {
            FrmWedstrijdOverview frm = new FrmWedstrijdOverview(pnlForms);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.TopLevel = false;
            frm.TopMost = true;
            frm.Dock = DockStyle.Fill;
            pnlForms.Controls.Clear();
            pnlForms.Controls.Add(frm);
            frm.Show();
        }

        private void btnScholen_Click(object sender, EventArgs e)
        {
            FrmSchoolOverview frm = new FrmSchoolOverview(pnlForms);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.TopLevel = false;
            frm.TopMost = true;
            frm.Dock = DockStyle.Fill;
            pnlForms.Controls.Clear();
            pnlForms.Controls.Add(frm);
            frm.Show();
        }
    }
}
