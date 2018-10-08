using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mobile_Town_V3
{
    public partial class Naplati_narudzbinu : Form
    {
        string ime_prezime;
        string br_mob;
        string narudzbina;
        public Naplati_narudzbinu(string ime_prezime, string br_mob, string narudzbina)
        {
            this.ime_prezime = ime_prezime;
            this.br_mob = br_mob;
            this.narudzbina = narudzbina;
            InitializeComponent();
        }

        private void Naplati_narudzbinu_Load(object sender, EventArgs e)
        {
            label1.Text = ime_prezime;
            label2.Text = br_mob;
            label3.Text = narudzbina;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
