using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jeu
{
    public partial class Form1 : Form
    {

        public Partie partie { get; set; }

        public Form1()
        {
            InitializeComponent();
            InitialiserImagesLabel();
            partie = new Partie();
            partie.DistribuerCartes();
        }

        //Bouton
        private void Bouton_JouerCarte(object sender, EventArgs e)
        {
            SetLabel("A vous");
            //Le joueur joue
            partie.JoueurJoue();
            SetImageCenter(partie.PliEnCours.RegarderCarteDuDessus().GetStringUrlImage());
            SetTaillePaquet(partie.Joueur.MainJoueur.Taille, partie.Ordi.MainJoueur.Taille, partie.PliEnCours.Taille);


            //L'ordi joue
            SetLabel("Ordi joue");
            Thread.Sleep(1600);

            partie.OrdiJoue();
            SetImageCenter(partie.PliEnCours.RegarderCarteDuDessus().GetStringUrlImage());
            SetTaillePaquet(partie.Joueur.MainJoueur.Taille, partie.Ordi.MainJoueur.Taille, partie.PliEnCours.Taille);

            SetLabel("À vous");
        }

        private void Pli_Clicked(object sender, EventArgs e)
        {
            if (partie.PliEnCours.EstVide())            
                SetLabel("Le pli est vide");
            
            else
            {
                if (partie.PliEnCours.ADouble() || partie.PliEnCours.ASandwich()) {
                    SetLabel("Vous remportez le pli !");
                    for (int i = 0; i < partie.PliEnCours.Taille; i++ ) {
                        partie.Joueur.AjouterEnMain(partie.PliEnCours.Piocher());
                    }
                    
                }

            }
        }
    }
}
