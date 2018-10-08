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
    public partial class Unos_artikla_u_racun : Form
    {
        int sifra;
        string artikal;
        decimal cena;
        int knjizeno;
        decimal nabavna_cena;
        public Unos_artikla_u_racun(int sifra, string artikal, decimal cena, int knjizeno, decimal nabavna_cena)
        {
            this.sifra = sifra;
            this.artikal = artikal;
            this.cena = cena;
            this.knjizeno = knjizeno;
            this.nabavna_cena = nabavna_cena;
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = null;

            if(knjizeno == 0)
            {
                query = "Artikli";
            }
            else if(knjizeno == 1)
            {
                query = "Artikli_knjizeno";
            }

            
            Artikal a = new Artikal();

            a.sifra = sifra;
            a.artikal = artikal;
            a.kolicina = Convert.ToInt32(numericUpDown1.Value);
            a.nabavna_cena = nabavna_cena;
            a.prodajna_cena = cena;
            a.knjizeno = knjizeno;


            if(a.proveri_stanje(query, a.kolicina, a.sifra))
            {
                a.set_ls(a);

                this.Close();
            }
            else
            {
                MessageBox.Show("Trazenog artikla nema dovoljno na stanju!");
            }

            

        }

        private void Unos_artikla_u_racun_Load(object sender, EventArgs e)
        {
            label1.Text = sifra.ToString();
            label2.Text = artikal;
            label3.Text = cena.ToString();
        }
    }
}
