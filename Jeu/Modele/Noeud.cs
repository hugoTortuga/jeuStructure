using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu.Modele
{

    //représente un noeud dans l'arbre, contient une carte et des fils
    public class Noeud
    {
        public Carte Valeur { get; set; }
        public Noeud FilsGauche { get; set; }
        public Noeud FilsDroit { get; set; }

        public Noeud(Carte v)
        {
            if (v == null)
                throw new Exception("Impossible de passer une valeur nulle");
            Valeur = v;
            FilsGauche = FilsDroit = null;
        }
    }
}
