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
    public partial class Regles : Form
    {

        public Form1 Jeu { get; set; }
        public Regles(Form1 jeu)
        {
            InitializeComponent();
            Jeu = jeu;
            this.Name = "Jeu de la bataille corse";
            this.Text = "Jeu de la bataille corse";
            this.textBox1.Select(0,0);
            //this.textBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Jeu != null)
            {
                Jeu.Focus();
            }
            
            this.Close();
        }
    }
}
