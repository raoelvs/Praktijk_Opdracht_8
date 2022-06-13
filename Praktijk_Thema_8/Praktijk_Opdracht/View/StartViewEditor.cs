/*
 * Author: Quinten Kornalijnslijper
 * Date: 10-6-2022
 * Description: startview layout for editors
 */
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
        // fields
        private string role;
        public StartViewEditor(string Role)
        {
            InitializeComponent();
            role = Role;
        }

        /// <summary>
        /// close application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSluiten_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// shows knockout scheme and set functionalities for roles by this form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartViewEditor_Load(object sender, EventArgs e)
        {
            FrmKnockoutScheme frm = new FrmKnockoutScheme();
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.TopLevel = false;
            frm.TopMost = true;
            frm.Dock = DockStyle.Fill;
            pnlForms.Controls.Add(frm);
            frm.Show();

            // set functionalities for roles
            if(role == "Scheidsrechter")
            {
                btnScheidsrechter.Enabled = false;
                btnScholen.Enabled = false;
                btnSpelers.Enabled = false;
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

        /// <summary>
        /// opens the referee overview in a panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// opens the player overview in a panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// opens the result overview in a panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// opens the knockout scheme in a panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// opens the match overview in a panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWedstrijden_Click(object sender, EventArgs e)
        {
            FrmWedstrijdOverview frm = new FrmWedstrijdOverview(pnlForms, role);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.TopLevel = false;
            frm.TopMost = true;
            frm.Dock = DockStyle.Fill;
            pnlForms.Controls.Clear();
            pnlForms.Controls.Add(frm);
            frm.Show();
        }

        /// <summary>
        /// opens the school overview in a panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
