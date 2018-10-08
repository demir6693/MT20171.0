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
    public partial class Unos : Form
    {
        public string grupa;
        public Unos(string grupa)
        {
            this.grupa = grupa;
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

        private void Unos_Load(object sender, EventArgs e)
        {
            label5.Text = grupa;
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            Artikal art = new Artikal();

            art.sifra = int.Parse(textBox1.Text);
            art.grupa = label5.Text;
            art.artikal = textBox2.Text;
            art.kolicina = Convert.ToInt32(numericUpDown1.Value);
            art.nabavna_cena = decimal.Parse(textBox3.Text);
            art.prodajna_cena = decimal.Parse(textBox4.Text);

            string query = "Artikli";
            if (checkBox1.Checked)
            {
                query = "Artikli_knjizeno";
            }
            

            if(art.Unesi_artikal(query))
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Artikal nije unesen!");
            }
        }

        private void Unesi_Click(object sender, EventArgs e)
        {
            panel7_Click(sender, e);
        }
    }
}
