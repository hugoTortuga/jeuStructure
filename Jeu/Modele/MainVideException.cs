using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu.Modele
{

    //Exception lancée lorqu'un des 2 joueurs n'a plus de cartes en main
    public class MainVideException : Exception
    {

        public MainVideException(string ex) : base(ex)
        {
            
        }

    }
}
