using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jeu
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            this.Name = "Jeu de la bataille corse";
            this.Text = "Jeu de la bataille corse";
        }

        public Form1 jeu { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            //lancer une partie
            jeu = new Form1();
            jeu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Règles
            new Regles(jeu).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Quitter
            if(jeu!=null)
                jeu.Close();
            this.Close();
            
        }

    }
}
