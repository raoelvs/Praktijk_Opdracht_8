/*
 * Author: Jarno van Overdijk
 * Date: 14-6-2022
 * Description: Scheidsrechter model
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktijk_Opdracht.Model
{
    public class ScheidsrechterModel
    {
        public string ScheidsrechterCode { get; set; }

        public string Voornaam { get; set; }

        public string Tussenvoegsel { get; set; }

        public string Achternaam { get; set; }

        public string Wachtwoord { get; set; }

        public string FullName
        {
            get
            {
                if (Tussenvoegsel == "")
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
