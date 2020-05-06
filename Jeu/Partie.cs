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
            Ordi = new Joueur("Ordi");
            Joueur = new Joueur("Joueur1");

            PaquetInitial = new Paquet();
            PaquetInitial.InitialiserPaquet();

            PliEnCours = new Paquet();
            FirstPlayer = true;
        }

        //Distribue 26 cartes dans la main de l'ordi et 26 cartes dans la main du joueur
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
                c = Joueur.JouerProchaineCarte();
                PliEnCours.AjouterCarteDessus(c);
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
                c = Ordi.JouerProchaineCarte();
                PliEnCours.AjouterCarteDessus(c);
            }
            catch (MainVideException ex)
            {
                throw ex;
            }
            return c;
        }
        
        public static void Start()
        {
            


        }

    }
}
