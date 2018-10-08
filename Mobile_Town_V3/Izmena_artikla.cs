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
    public partial class Izmena_artikla : Form
    {
        public int sifra_tmp;
        public string query;
        public Izmena_artikla(int sifra, string query)
        {
            this.query = query;
            this.sifra_tmp = sifra;
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

        private void Izmena_artikla_Load(object sender, EventArgs e)
        {
            try
            {
                Artikal art = new Artikal();
                List<Artikal> ls = art.daj_artikal(sifra_tmp, query);

                textBox1.Text = ls[0].sifra.ToString();
                comboBox1.Text = ls[0].grupa.ToString();
                textBox3.Text = ls[0].artikal.ToString();
                numericUpDown1.Value = int.Parse(ls[0].kolicina.ToString());
                textBox4.Text = ls[0].nabavna_cena.ToString();
                textBox5.Text = ls[0].prodajna_cena.ToString();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            Artikal art = new Artikal();

            art.sifra = int.Parse(textBox1.Text);
            art.grupa = comboBox1.Text;
            art.artikal = textBox3.Text;
            art.kolicina = Convert.ToInt32(numericUpDown1.Value);
            art.nabavna_cena = decimal.Parse(textBox4.Text);
            art.prodajna_cena = decimal.Parse(textBox5.Text);

          

            if (art.izmeni_artkal(sifra_tmp, query))
            {
                MessageBox.Show("Artikal je izmenjen!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Artikal nije izmenjen!");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            panel7_Click(sender, e);
        }
    }
}
