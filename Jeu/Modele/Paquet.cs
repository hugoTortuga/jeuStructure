using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu.Modele
{
    //Le paquet est une pile de carte
    public class Paquet
    {

        public int Taille { get; set; }
        public Carte[] Cartes { get; set; }

        public Paquet()
        {
            Taille = -1;
            Cartes = new Carte[52];
        }

        #region Methodes


        public void Afficher()
        {
            for (int i = Taille; i >= 0; i--)
                Console.WriteLine(Cartes[i] + " ");
            Console.WriteLine("-");
        }

        public bool EstVide()
        {
            return Taille == -1;
        }

        public bool ADouble()
        {
            if (Taille < 2)
                return false;

            if (Cartes[Taille - 1].Valeur == Cartes[Taille - 2].Valeur)
                return true;
            else
                return false;
        }

        public bool ASandwich()
        {
            if (Taille < 3)
                return false;
            if (Cartes[Taille - 1].Valeur == Cartes[Taille - 3].Valeur)
                return true;
            else
                return false;
        }

        public void AjouterCarteDessus(Carte c)
        {
            if (c == null)
                throw new Exception("Impossible d'ajouter une carte nulle");
            
            Taille++;
            Cartes[Taille] = c;
        }

        public Carte Piocher()
        {
            if (EstVide())
                throw new Exception("Le paquet est vide");

            Carte c = Cartes[Taille];

            Taille--;

            return c;
        }

        public Carte RegarderCarteDuDessus()
        {
            if (EstVide())
                throw new Exception("Le paquet est vide");

            Carte c = Cartes[Taille];
            return c;
        }

        public void InitialiserPaquet()
        {
            //On crée nos cartes dans un premier temps
            Carte[] cartesNonMelanges = new Carte[52];
            int position = 0;

            foreach(var couleur in Enum.GetValues(typeof(CouleurCarte)))
            {
                for(int i = 2; i < 15; i++)
                {
                    cartesNonMelanges[position] = new Carte(i, (CouleurCarte)couleur);
                    position++;
                }
            }

            Melange(cartesNonMelanges);

        }

        public void Melange(Carte[] cartesNonMelanges)
        {
            var Randomizer = new Random();
            //Notre paquet est créée, on le mélange
            for (int i = 0; i < 52; i++)
            {

                int random = Randomizer.Next(0, cartesNonMelanges.Length);
                AjouterCarteDessus(cartesNonMelanges[random]);


                // On décale à gauche toutes les cartes
                Carte[] cartesNonMelangesTemp = new Carte[cartesNonMelanges.Length - 1];
                for (int j = 0; j < random; j++)
                {
                    cartesNonMelangesTemp[j] = cartesNonMelanges[j];
                }
                for (int j = random; j < cartesNonMelangesTemp.Length; j++)
                {
                    if (j < cartesNonMelangesTemp.Length)
                        cartesNonMelangesTemp[j] = cartesNonMelanges[j + 1];
                }
                cartesNonMelanges = cartesNonMelangesTemp;
            }
        }

        #endregion

    }
}
