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
    public partial class Rezervacija : Form
    {
        int sifra;
        string artikal;
        decimal cena;
        int knjizeno;
        public Rezervacija(int sifra, string artikal, decimal cena, int knjizeno)
        {
            this.sifra = sifra;
            this.artikal = artikal;
            this.cena = cena;
            this.knjizeno = knjizeno;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Rezervacija_Load(object sender, EventArgs e)
        {
            label1.Text = sifra + " " + artikal + " " + cena + " din";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Rezervacija_ rz = new Rezervacija_();

            rz.sifra_artikla = sifra;
            rz.ime_prezime = textBox1.Text;
            rz.broj_telefona = textBox2.Text;
            rz.artikal = artikal;
            rz.kolicina = Convert.ToInt32(numericUpDown1.Value);
            rz.cena = cena;
            rz.knjizeno = knjizeno;

            Artikal a = new Artikal();
            string query = null;

            if (knjizeno == 0)
            {
                query = "Artikli";
            }
            else if (knjizeno == 1)
            {
                query = "Artikli_knjizeno";
            }

            if (a.proveri_stanje(query, rz.kolicina, sifra))
            {
                if (rz.unesi_rezervaciju())
                {
                    MessageBox.Show("Rezervacija uneta!");

                    if (knjizeno == 0)
                    {
                        a.update_artikli(sifra, rz.kolicina);
                    }
                    else if (knjizeno == 1)
                    {
                        a.update_artikli_knjizeno(sifra, rz.kolicina);
                    }

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Rezervacija nije uneta!");
                }
            }
            else
            {
                MessageBox.Show("Trazenog artikla nema dovoljno na stanju!");
            }
        }
    }
}
