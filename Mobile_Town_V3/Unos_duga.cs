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
    public partial class Unos_duga : Form
    {
        public Unos_duga()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Unos_duga_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd-MM-yy";
            dateTimePicker2.CustomFormat = "dd-MM-yy";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dug d = new Dug();

            d.ime_prezime = textBox1.Text;
            d.broj_telefona = textBox2.Text;
            d.datum_izdavanja = dateTimePicker1.Value.Date;
            d.datum_vracanja = dateTimePicker2.Value.Date;
            d.cena = decimal.Parse(textBox4.Text);

            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                d.sifra_artikla = 0;
            }
            else
            {
                d.sifra_artikla = int.Parse(textBox3.Text);
            }

            if(textBox5.Equals(""))
            {
                d.artikal = "0";
            }
            else
            {
                d.artikal = textBox5.Text;
            }

            if(checkBox1.Checked)
            {
                d.knjizeno = 1;
            }
            else
            {
                d.knjizeno = 0;
            }

            if(d.unesi_dug())
            {
                MessageBox.Show("Dug je unet!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Dug nije unet!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Artikal a = new Artikal();
            string knjizeno;
            if(checkBox1.Checked)
            {
                knjizeno = "Artikli_knjizeno";
            }
            else
            {
                knjizeno = "Artikli";
            }

            try
            {
                int sifra_art = int.Parse(textBox3.Text);

                List<Artikal> ls = a.daj_artikal(sifra_art, knjizeno);
                textBox5.Text = ls[0].artikal;
                textBox4.Text = ls[0].prodajna_cena.ToString();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
