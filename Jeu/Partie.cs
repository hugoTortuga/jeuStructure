using Jeu.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu
{
    public class Partie
    {

        public Joueur Ordi { get; set; }
        public Joueur Joueur { get; set; }
        public Paquet PaquetInitial { get; set; }
        public Paquet PliEnCours { get; set; }

        public bool FirstPlayer { get; set; }

        public Partie()
        {
            //On initialise 2 joueurs
            Ordi = new Joueur("Ordi");
            Ordi.Memoire = new ArbreBinaire();
            Joueur = new Joueur("Joueur1");

            //On initialise le paquet
            PaquetInitial = new Paquet();
            PaquetInitial.InitialiserPaquet();

            PliEnCours = new Paquet();
            FirstPlayer = true;
        }

        //Distribue 26 cartes dans la main de l'ordi et 26 cartes dans la main du joueur en alternant
        public void DistribuerCartes()
        {
            bool interupteur = false;

            for(int i = 0; i < 52; i++)
            {
                if (interupteur)
                {
                    Ordi.AjouterEnMain(PaquetInitial.Piocher());
                    interupteur = false;
                }
                else
                {
                    Joueur.AjouterEnMain(PaquetInitial.Piocher());
                    interupteur = true;
                }
            }
        }

        public Carte JoueurJoue()
        {
            Carte c = null;
            try
            {
                //Tire une carte et l'ajoute dans le pli
                c = Joueur.JouerProchaineCarte();
                PliEnCours.AjouterCarteDessus(c);
                //On ajoute la carte jouée à la mémoire de l'ordi
                Ordi.Memoire.Ajouter(c);
            }
            catch(MainVideException ex)
            {
                throw ex;
            }

            return c;

        }

        public Carte OrdiJoue()
        {
            Carte c = null;
            try
            {
                //Tire une carte et l'ajoute dans le pli
                c = Ordi.JouerProchaineCarte();
                PliEnCours.AjouterCarteDessus(c);
                //On ajoute la carte jouée à la mémoire de l'ordi
                Ordi.Memoire.Ajouter(c);

            }
            catch (MainVideException ex)
            {
                throw ex;
            }
            return c;
        }

    }
}
