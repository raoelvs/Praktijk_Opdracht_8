﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktijk_Opdracht.Model
{
    class ResultaatModel
    {
        public int ResultaatId { get; set; }

        public int Punt { get; set; }

        // Meen dat dit bool moet zijn
        public bool Overgave { get; set; }

        public WedstrijdModel WedstrijdId { get; set; }

        public SpelerModel SpelerId { get; set; }
    }
}