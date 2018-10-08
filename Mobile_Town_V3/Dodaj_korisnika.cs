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
    public partial class Dodaj_korisnika : Form
    {
        public Dodaj_korisnika()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            Korisnici_ k = new Korisnici_();
            k.ime_korisnika = textBox1.Text;
            k.prezime_korisnika = textBox2.Text;
            k.korisnicko_ime = textBox3.Text;
            k.sifra_korisnika = textBox4.Text;
            k.nivo = 0;

            if(k.Unesi_korisnika())
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Korisnik nije unet!");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Korisnici_ k = new Korisnici_();
            k.ime_korisnika = textBox1.Text;
            k.prezime_korisnika = textBox2.Text;
            k.korisnicko_ime = textBox3.Text;
            k.sifra_korisnika = textBox4.Text;
            k.nivo = 0;

            if (k.Unesi_korisnika())
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Korisnik nije unet!");
            }
        }

        private void Dodaj_korisnika_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Korisnici_ k = new Korisnici_();
                k.ime_korisnika = textBox1.Text;
                k.prezime_korisnika = textBox2.Text;
                k.korisnicko_ime = textBox3.Text;
                k.sifra_korisnika = textBox4.Text;
                k.nivo = 0;

                if (k.Unesi_korisnika())
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Korisnik nije unet!");
                }
            }
        }
    }
}
