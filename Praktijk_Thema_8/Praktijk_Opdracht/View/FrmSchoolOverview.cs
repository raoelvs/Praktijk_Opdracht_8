/*
 * Author: Quinten Kornalijnslijper
 * Date: 12-6-2022
 * Description: form to show all schools
 */
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
    public partial class FrmSchoolOverview : Form
    {
        // fields
        private SchoolController schoolContr = new SchoolController();
        public Panel pnlForms;

        public FrmSchoolOverview(Panel PnlForms)
        {
            InitializeComponent();
            pnlForms = PnlForms;
        }

        /// <summary>
        /// styling and filling the listview by this form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSchoolOverview_Load(object sender, EventArgs e)
        {
            lvScholen.Columns.Add("Naam", 500);

            lvScholen.FullRowSelect = true;

            lvScholen.View = System.Windows.Forms.View.Details;

            FillListView();

            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }

        /// <summary>
        /// fill the listview
        /// </summary>
        public void FillListView()
        {
            List<SchoolModel> schoolList = schoolContr.ReadAll();
            lvScholen.Items.Clear();
            foreach(SchoolModel school in schoolList)
            {
                ListViewItem lvItem = new ListViewItem(school.Naam);

                lvItem.Tag = school;

                lvScholen.Items.Add(lvItem);
            }
        }

        /// <summary>
        /// open form to add a school
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmSchoolAdd frm = new FrmSchoolAdd(this);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.TopLevel = false;
            frm.TopMost = true;
            frm.Dock = DockStyle.Fill;
            pnlForms.Controls.Clear();
            pnlForms.Controls.Add(frm);
            frm.Show();
        }

        /// <summary>
        /// enabled update and delete button if listview has a selected item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvScholen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvScholen.SelectedItems.Count == 1)
            {
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
            }
        }

        /// <summary>
        /// opens a form for update a school
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FrmSchoolUpdate frm = new FrmSchoolUpdate(this, (SchoolModel) lvScholen.SelectedItems[0].Tag);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.TopLevel = false;
            frm.TopMost = true;
            frm.Dock = DockStyle.Fill;
            pnlForms.Controls.Clear();
            pnlForms.Controls.Add(frm);
            frm.Show();
        }

        /// <summary>
        /// open form to confirm the delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            FrmSchoolDelete frm = new FrmSchoolDelete((SchoolModel)lvScholen.SelectedItems[0].Tag);
            frm.ShowDialog();
            FillListView();
        }
    }
}
