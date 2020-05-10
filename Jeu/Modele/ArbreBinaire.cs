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

        public int Hauteur()
        {
            return HauteurNoeud(Racine);
        }

        public int HauteurNoeud(Noeud n)
        {
            if (n == null)
                return 0;
            else
                return 1 +
                Math.Max(HauteurNoeud(n.FilsGauche),
                HauteurNoeud(n.FilsDroit));
        }
        public int Taille()
        {
            return TailleNoeud(Racine);
        }

        public int TailleNoeud(Noeud n)
        {
            if (n == null)
                return 0;
            else
                return 1 + TailleNoeud(n.FilsGauche) + TailleNoeud(n.FilsDroit);
        }

        public int Minimum()
        {
            if (Racine == null)
                return -1;
            else
                return MinimumNoeud(Racine);
        }

        public int MinimumNoeud(Noeud n)
        {
            if (n.FilsGauche != null)
                return MinimumNoeud(n.FilsGauche);
            else
                return n.Valeur.Valeur;
        }

        public int Maximum()
        {
            if (Racine == null)
                return -1;
            else
                return MaximumNoeud(Racine);
        }

        public int MaximumNoeud(Noeud n)
        {
            if (n.FilsDroit != null)
                return MaximumNoeud(n.FilsDroit);
            else
                return n.Valeur.Valeur;
        }



    }
}