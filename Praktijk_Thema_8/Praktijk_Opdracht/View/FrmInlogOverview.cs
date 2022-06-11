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
    }
}
