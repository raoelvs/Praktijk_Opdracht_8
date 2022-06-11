using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktijk_Opdracht.Model
{
    public class SpelerModel
    {
        public int SpelerId { get; set; }

        public string Voornaam { get; set; }

        public string Tussenvoegsel { get; set; }

        public string Achternaam { get; set; }

        public DateTime Geboortedatum { get; set; }

        public int Groep { get; set; }

        public SchoolModel SchoolId { get; set; }

        public string FullName
        {
            get
            {
                if(Tussenvoegsel == "")
                {
                    return this.Voornaam + " " + this.Achternaam;
                }
                else
                {
                    return this.Voornaam + " " + this.Tussenvoegsel + " " + this.Achternaam;
                }
            }
        }
    }
}
