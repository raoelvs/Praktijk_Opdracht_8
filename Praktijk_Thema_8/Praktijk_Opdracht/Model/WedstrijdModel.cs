using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktijk_Opdracht.Model
{
    public class WedstrijdModel
    {
        public int WedstrijdId { get; set; }
        public int Ronde { get; set; }
        public int WedstrijdNummer { get; set; }
        public DateTime Starttijd { get; set; }
        public DateTime Eindtijd { get; set; }
        public SpelerModel Thuis { get; set; }
        public SpelerModel Uit { get; set; }
        public ScheidsrechterModel ScheidsrechterCode { get; set; }
        public SpelerModel Winnaar { get; set; }
    }
}
