﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu.Modele
{
    public class Noeud
    {
        public object Valeur { get; set; }
        public Noeud FilsGauche { get; set; }
        public Noeud FilsDroit { get; set; }

        public Noeud(object v)
        {
            if (v == null)
                throw new Exception("Impossible de passer une valeur nulle");
            Valeur = v;
            FilsGauche = FilsDroit = null;
        }
    }
}