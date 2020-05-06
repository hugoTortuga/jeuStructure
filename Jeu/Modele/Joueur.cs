using Jeu.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu
{
    public class Joueur
    {

        public string Pseudo { get; set; }
        public Main MainJoueur { get; set; }

        public Joueur(string _pseudo)
        {
            Pseudo = _pseudo;
            MainJoueur = new Main();
        }

        public Carte JouerProchaineCarte()
        {
            if (MainJoueur.TestPerdu())
                throw new MainVideException("Main vide");

            Carte c = MainJoueur.RetirerCarte();
            return c;
        }

        public void AjouterEnMain(Carte c)
        {
            MainJoueur.AjouterCarte(c);
        }

        public void AjouterEnMain(Carte[] cs)
        {
            foreach (var c in cs)
            {
                if(c != null)
                    MainJoueur.AjouterCarte(c);
            }
        }

        public void AjouterSousMain(Carte[] cs)
        {
            foreach (var c in cs)
            {
                if (c != null)
                    MainJoueur.AjouterCarteSous(c);
            }
        }



    }
}
