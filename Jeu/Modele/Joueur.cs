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
                MainJoueur.AjouterCarte(c);
            }
        }



    }
}
