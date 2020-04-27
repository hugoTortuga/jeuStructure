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

        public int JoueurJoue()
        {
            Carte c = Joueur.JouerProchaineCarte();
            PliEnCours.AjouterCarteDessus(c);

            switch (c.Valeur)
            {
                case 11:
                    return 1;
                case 12:
                    return 2;
                case 13:
                    return 3;
                case 14:
                    return 4;
                default:
                    return 1;
            }

        }

        public int OrdiJoue()
        {
            Carte c = Ordi.JouerProchaineCarte();
            PliEnCours.AjouterCarteDessus(c);

            switch (c.Valeur)
            {
                case 11:
                    return 1;
                case 12:
                    return 2;
                case 13:
                    return 3;
                case 14:
                    return 4;
                default:
                    return 1;
            }
        }
        
        public static void Start()
        {
            


        }

    }
}
