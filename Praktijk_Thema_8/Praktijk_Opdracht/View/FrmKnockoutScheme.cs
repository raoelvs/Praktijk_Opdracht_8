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
    public partial class FrmKnockoutScheme : Form
    {
        private WedstrijdController wedContr = new WedstrijdController();
        private List<Label> labels = new List<Label>();
        public FrmKnockoutScheme()
        {
            InitializeComponent();
        }

        private void FrmKnockoutScheme_Load(object sender, EventArgs e)
        {
            List<Label> labels = new List<Label>();
            int[] roundMatches = { 16, 8, 4, 2, 1 };
            for (int i = 0; i < 5; i++)
            {
                labels = this.Controls.OfType<Label>().Where(name => name.Name.StartsWith("lblRonde" + (i + 1))).ToList();
                for(int count = 0; count < roundMatches[i]; count++)
                {
                    string labelName = "lblRonde" + (i + 1) + "Wedstrijd" + (count + 1);
                    WedstrijdModel wedstrijd = wedContr.ReadWhereRound(i + 1, count + 1);
                    if (wedstrijd.WedstrijdId != 0)
                    {
                        foreach (Label label in labels)
                        {
                            if (label.Name == labelName + "Thuis")
                            {
                                label.Text = wedstrijd.Thuis.FullName;
                            }
                            else if (label.Name == labelName + "Uit")
                            {
                                label.Text = wedstrijd.Uit.FullName;
                            }
                        }
                    }
                }
                labels.Clear();                
            }            
        }
    }
}
