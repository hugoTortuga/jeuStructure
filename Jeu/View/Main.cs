using Jeu.Modele;
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
        public bool tourDeJoueur { get; set; }
        public int nbCarteAJouerAvantPerte { get; set; }

        public Form1()
        {
            InitializeComponent();
            this.Name = "Jeu de la bataille corse";
            this.Text = "Jeu de la bataille corse";
            InitialiserImagesLabel();
            partie = new Partie();
            partie.DistribuerCartes();
            nbCarteAJouerAvantPerte = 100000;
        }

        private void RemporterPli(bool joueur)
        {
            Thread.Sleep(1000);
            if (joueur)
            {
                SetLabel("Le Joueur a remporté le pli (" + (partie.PliEnCours.Taille + 1) + " cartes)");
                partie.Joueur.AjouterSousMain(partie.PliEnCours.Cartes);
                partie.PliEnCours.Vider();
                SetImageCenter(null);
                SetTaillePaquet(partie.Joueur.MainJoueur.Taille, partie.Ordi.MainJoueur.Taille, partie.PliEnCours.Taille);

                Thread.Sleep(1500);
                SetLabel("A vous");
                nbCarteAJouerAvantPerte = 10000;
                button1.Enabled = true;
            }
            else
            {
                SetLabel("L'ordi a remporté le pli (" + (partie.PliEnCours.Taille + 1) + " cartes)");
                partie.Ordi.AjouterSousMain(partie.PliEnCours.Cartes);
                partie.PliEnCours.Vider();
                SetImageCenter(null);
                SetTaillePaquet(partie.Joueur.MainJoueur.Taille, partie.Ordi.MainJoueur.Taille, partie.PliEnCours.Taille);
                //
                Thread.Sleep(1500);
                nbCarteAJouerAvantPerte = 10000;
                tourOrdiClassique();
            }
        }

        public bool tourOrdiJoueurTete()
        {
            Thread.Sleep(2000);
            Carte carteDuBot = null;
            try
            {
                carteDuBot = partie.OrdiJoue();
            }
            
            catch (MainVideException)
            {
                new GameOver("Gagné !").Show();
                this.Close();
                return false;
            }
            SetImageCenter(partie.PliEnCours.RegarderCarteDuDessus().GetStringUrlImage());
            SetTaillePaquet(partie.Joueur.MainJoueur.Taille, partie.Ordi.MainJoueur.Taille, partie.PliEnCours.Taille);
            Thread.Sleep(500);
            SetLabel("Ordi a joué");

            if (carteDuBot.Valeur == 11 || carteDuBot.Valeur == 12 || carteDuBot.Valeur == 13 || carteDuBot.Valeur == 14)
            {
                //au joueur de reprendre
                button1.Enabled = true;

                switch (carteDuBot.Valeur)
                {
                    case 11:
                        nbCarteAJouerAvantPerte = 1;
                        break;
                    case 12:
                        nbCarteAJouerAvantPerte = 2;
                        break;
                    case 13:
                        nbCarteAJouerAvantPerte = 3;
                        break;
                    case 14:
                        nbCarteAJouerAvantPerte = 4;
                        break;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public void tourOrdiClassique()
        {
            Thread.Sleep(1500);
            Carte carteDuBot = null;
            try
            {
                carteDuBot = partie.OrdiJoue();
            }

            catch (MainVideException)
            {
                new GameOver("Gagné !").Show();
                this.Close();
                return;
            }

            SetImageCenter(partie.PliEnCours.RegarderCarteDuDessus().GetStringUrlImage());
            SetTaillePaquet(partie.Joueur.MainJoueur.Taille, partie.Ordi.MainJoueur.Taille, partie.PliEnCours.Taille);
            Thread.Sleep(500);
            SetLabel("Ordi a joué");

            if (carteDuBot.Valeur == 11 || carteDuBot.Valeur == 12 || carteDuBot.Valeur == 13 || carteDuBot.Valeur == 14)
            {
                //au joueur de reprendre
                button1.Enabled = true;

                switch (carteDuBot.Valeur)
                {
                    case 11:
                        nbCarteAJouerAvantPerte = 1;
                        break;
                    case 12:
                        nbCarteAJouerAvantPerte = 2;
                        break;
                    case 13:
                        nbCarteAJouerAvantPerte = 3;
                        break;
                    case 14:
                        nbCarteAJouerAvantPerte = 4;
                        break;
                }
            }
        }

        //Bouton
        private void Bouton_JouerCarte(object sender, EventArgs e)
        {
            button1.Enabled = false;
            Carte carteDuJoueur = null;
            try
            {
                carteDuJoueur = partie.JoueurJoue();
            }
            catch(MainVideException)
            {
                new GameOver("Perdu !").Show();
                this.Close();
            }
            SetImageCenter(partie.PliEnCours.RegarderCarteDuDessus().GetStringUrlImage());
            SetTaillePaquet(partie.Joueur.MainJoueur.Taille, partie.Ordi.MainJoueur.Taille, partie.PliEnCours.Taille);

            Thread.Sleep(1000);

            --nbCarteAJouerAvantPerte;
            if (nbCarteAJouerAvantPerte == 0 && !(carteDuJoueur.Valeur == 11 || carteDuJoueur.Valeur == 12 || carteDuJoueur.Valeur == 13 || carteDuJoueur.Valeur == 14))
            {
                RemporterPli(false);
            }


            //si on a joué une tete ou un as
            if (carteDuJoueur.Valeur == 11 || carteDuJoueur.Valeur == 12 || carteDuJoueur.Valeur == 13 || carteDuJoueur.Valeur == 14)
            {
                switch (carteDuJoueur.Valeur)
                {
                    case 11:
                        if(!tourOrdiJoueurTete())
                            RemporterPli(true);
                        break;
                    case 12:
                        int i2 = 2;
                        while(i2 > 0 && !tourOrdiJoueurTete())
                        {
                            i2--;

                        }
                        if(i2==0)
                            RemporterPli(true);
                        break;
                    case 13:
                        int i3 = 3;
                        while (i3 > 0 && !tourOrdiJoueurTete())
                        {
                            i3--;
                        }
                        if (i3 == 0)
                            RemporterPli(true);
                        break;
                    case 14:
                        int i4 = 4;
                        while (i4 > 0 && !tourOrdiJoueurTete())
                        {
                            i4--;
                        }
                        if (i4 == 0)
                            RemporterPli(true);
                        break;
                }
            }

            //si on l'ordi n'a pas joué de tete ou d'as
            else if(nbCarteAJouerAvantPerte > 100)
            {
                tourOrdiClassique();
                SetLabel("A vous");
            }

            //si l'ordi a joué une tete ou un as
            else
            {
                Thread.Sleep(1000);
                SetLabel("A vous - reste " + nbCarteAJouerAvantPerte);
            }

            button1.Enabled = true;
        }

        private void Pli_Clicked(object sender, EventArgs e)
        {
            if (partie.PliEnCours.EstVide())
                SetLabel("Le pli est vide");

            else
            {
                if (partie.PliEnCours.ADouble() || partie.PliEnCours.ASandwich())
                {
                    SetLabel("Vous remportez le pli !");
                    for (int i = 0; i < partie.PliEnCours.Taille; i++)
                    {
                        partie.Joueur.AjouterEnMain(partie.PliEnCours.Piocher());
                    }
                }

            }
        }
    }
}
