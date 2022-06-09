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
    public partial class FrmSpelerUpdate : Form
    {
        SpelerController spelerController = new SpelerController();
        SpelerModel permSpeler = null;

        public FrmSpelerUpdate(SpelerModel tmpSpeler)
        {
            InitializeComponent();

            permSpeler = tmpSpeler;
        }

        private void FrmSpelerUpdate_Load(object sender, EventArgs e)
        {

        }
    }
}
