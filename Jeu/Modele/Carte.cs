using Jeu.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu
{

    //Une carte a une valeur et une couleur
    public class Carte
    {
        public int Valeur { get; set; }
        public CouleurCarte Couleur { get; set; }

        public Carte(int _valeur, CouleurCarte _couleur)
        {
            Valeur = _valeur;
            Couleur = _couleur;
        }

        public string GetStringValeur()
        {
            switch (Valeur)
            {
                case 2:
                    return "2";
                case 3:
                    return "3";
                case 4:
                    return "4";
                case 5:
                    return "5";
                case 6:
                    return "6";
                case 7:
                    return "7";
                case 8:
                    return "8";
                case 9:
                    return "9";
                case 10:
                    return "10";
                case 11:
                    return "Valet";
                case 12:
                    return "Dame";
                case 13:
                    return "Roi";
                case 14:
                    return "As";
                default:
                    throw new Exception("La valeur de la carte ne peut pas être égale à : " + Valeur);
            }
        }

        public string GetStringUrlImage()
        {
            return Couleur.ToString().ToLower() + " (" + Valeur + ").gif";
        }

        public override string ToString()
        {
            return GetStringValeur() + " de " + Couleur;
        }

    }
}
