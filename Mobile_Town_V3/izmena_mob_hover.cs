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
    public partial class izmena_mob_hover : Form
    {
        int sifra;
        string grupa;
        string artikal;
        int kolicina;
        decimal nabavna;
        decimal prodajna;
        int knjizeno;
        string query;

        public izmena_mob_hover(int sifra, string grupa, string artikal, int kolicina, decimal nabavna, decimal prodajna, int knjizeno, string query)
        {
            this.sifra = sifra;
            this.grupa = grupa;
            this.artikal = artikal;
            this.kolicina = kolicina;
            this.nabavna = nabavna;
            this.prodajna = prodajna;
            this.knjizeno = knjizeno;
            this.query = query;
            InitializeComponent();
        }

        private void izmena_mob_hover_Load(object sender, EventArgs e)
        {
            checkBox1.Enabled = false;
            textBox1.Enabled = false;

            textBox1.Text = sifra.ToString();
            comboBox1.Text = grupa;
            textBox2.Text = artikal;
            numericUpDown1.Value = int.Parse(kolicina.ToString());
            textBox3.Text = nabavna.ToString();
            textBox4.Text = prodajna.ToString();

            if(knjizeno == 1)
            {
                checkBox1.Checked = true;
            }
            else if(knjizeno == 0)
            {
                checkBox1.Checked = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Artikal a = new Artikal();

                a.sifra = int.Parse(textBox1.Text);
                a.grupa = comboBox1.Text;
                a.artikal = textBox2.Text;
                a.kolicina = Convert.ToInt32(numericUpDown1.Value);
                a.nabavna_cena = decimal.Parse(textBox3.Text);
                a.prodajna_cena = decimal.Parse(textBox4.Text);

                string query = null;
                if (checkBox1.Checked)
                {
                    query = "mob_hover_knjizeno";
                    this.Close();
                }
                else
                {
                    query = "mob_hover";
                }

                if(a.izmeni_artkal(sifra, query))
                {
                    MessageBox.Show("Artikal je izmenjen!");
                }
                else
                {
                    MessageBox.Show("Artikal nije izmenjen!");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
