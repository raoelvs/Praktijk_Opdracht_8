/*
 * Author: Quinten Kornalijnslijper
 * Date: 10-6-2022
 * Description: startview layout
 */
using Praktijk_Opdracht.View;
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
        /// go to inlog form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInlog_Click(object sender, EventArgs e)
        {
            // create inlog form
            FrmInlogOverview frm = new FrmInlogOverview(this.pForms);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.TopLevel = false;
            frm.TopMost = true;
            frm.Dock = DockStyle.Fill;

            // clear panel and add new form
            pForms.Controls.Clear();
            pForms.Controls.Add(frm);

            // show form
            frm.Show();
        }

        /// <summary>
        /// shows knockout scheme by this form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartView_Load(object sender, EventArgs e)
        {
            // create new knockout scheme
            FrmKnockoutScheme frm = new FrmKnockoutScheme();
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.TopLevel = false;
            frm.TopMost = true;
            frm.Dock = DockStyle.Fill;

            // add knockout scheme to panel
            pContainer.Controls.Add(frm);

            // show knockout scheme
            frm.Show();
        }
    }
}
