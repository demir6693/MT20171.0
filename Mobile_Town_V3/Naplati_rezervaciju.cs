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
    public partial class Naplati_rezervaciju : Form
    {
        int sifra;
        int sifra_rezervacije;
        string ime_prezime;
        string broj_telefona;
        string artikal;
        decimal cena;
        int kolicina;
        int knjizeno;

        public Naplati_rezervaciju(int sifra, string ime_prezime, string broj_telefona, string artikal, decimal cena, int kolicina, int knjizeno, int sifra_rezervacije)
        {
            this.sifra = sifra;
            this.ime_prezime = ime_prezime;
            this.broj_telefona = broj_telefona;
            this.artikal = artikal;
            this.cena = cena;
            this.kolicina = kolicina;
            this.knjizeno = knjizeno;
            this.sifra_rezervacije = sifra_rezervacije;
            InitializeComponent();
        }

        private void Naplati_rezervaciju_Load(object sender, EventArgs e)
        {
            label1.Text = sifra.ToString();
            label2.Text = ime_prezime;
            label3.Text = broj_telefona;
            label4.Text = artikal;
            label5.Text = cena.ToString();
            label6.Text = " X " + kolicina;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Racun r = new Racun();

            r.prodavac = "rezervacija";
            r.datum_izdavanja = DateTime.Now;
            r.artikli = artikal;
            r.iznos = cena;
            
            if(knjizeno == 1)
            {
                if (r.unesi_racun_knjizeno())
                {
                    MessageBox.Show("Racun je unet");
                    Rezervacija_ r_ = new Rezervacija_();
                    r_.del_rezervacija(sifra_rezervacije);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Racun nije unet");
                }
            }
            else if(knjizeno == 0)
            {
                if (r.unesi_racun())
                {
                    MessageBox.Show("Racun je unet");
                    Rezervacija_ r_ = new Rezervacija_();
                    r_.del_rezervacija(sifra_rezervacije);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Racun nije unet");
                }
            }

        }
    }
}
