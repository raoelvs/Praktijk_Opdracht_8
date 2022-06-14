/*
 * Author: Raoel van Schaijk
 * Date: 10-6-2022
 * Description: Resultaat Model 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktijk_Opdracht.Model
{
    public class ResultaatModel
    {
        public int ResultaatId { get; set; }                 //primary key

        public int Punt { get; set; }

        public bool Overgave { get; set; }

        public WedstrijdModel WedstrijdId { get; set; }     // Foreign key

        public SpelerModel SpelerId { get; set; }           // Foreign key
    }
}
