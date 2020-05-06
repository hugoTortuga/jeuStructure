using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu
{
    public class Main
    {

        public Carte[] Cartes { get; set; }
        public int Taille { get; set; }

        public Main()
        {
            Cartes = new Carte[52];
            Taille = -1;
        }

        public bool TestPerdu()
        {
            if (Taille == -1)
            {
                return true;
            }
            else
                return false;
        }

        public void AjouterCarte(Carte c)
        {
            if (c == null)
                throw new Exception("Carte nulle");

            if (Taille + 1 < 52)
            {
                Taille++;
                Cartes[Taille] = c;
            }
            else
                throw new Exception("Vous essayez d'ajouter plus de 52 cartes dans une main, impossible");
            
        }

        public void AjouterCarteSous(Carte c)
        {
            if (c == null)
                throw new Exception("Carte nulle");

            if (Taille + 1 < 52)
            {
                Taille++;
                for(int i = 0; i < Taille-1; i++)
                {
                    Cartes[i + 1] = Cartes[i];
                }
                Cartes[0] = c;
            }
            else
                throw new Exception("Vous essayez d'ajouter plus de 52 cartes dans une main, impossible");
        }


        public Carte RetirerCarte()
        {
            if (Taille == -1)
                throw new Exception("Main nulle");
            Carte c = Cartes[0];
            for(int i = 0; i < Taille-1; i++)
            {
                Cartes[i] = Cartes[i + 1];
            }
            Taille--;
            return c;
        }

        

        public void Afficher()
        {
            for(int i = 0; i < Taille; i++)
            {
                Console.WriteLine(Cartes[i]);
            }
        }

    }
}
