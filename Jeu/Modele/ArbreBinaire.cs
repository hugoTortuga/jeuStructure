using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu.Modele
{

    public class ArbreBinaire
    {
        public Noeud Racine { get; set; }

        public ArbreBinaire()
        {
            Racine = null;
        }
        public bool EstVide()
        {
            if (Racine == null)
                return true;
            else
                return false;
        }

        public void Ajouter(Carte v)
        {
            if (Racine == null)
                Racine = new Noeud(v);
            else
                AjouterNoeud(Racine, v);
        }
        public void AjouterNoeud(Noeud r, Carte v)
        {
            if (r.Valeur.Valeur >= v.Valeur)
            {
                if (r.FilsGauche == null)
                    r.FilsGauche = new Noeud(v);
                else
                    AjouterNoeud(r.FilsGauche, v);
            }
            else
            {
                if (r.FilsDroit == null)
                    r.FilsDroit = new Noeud(v);
                else
                    AjouterNoeud(r.FilsDroit, v);
            }
        }


    }
}