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
    public partial class Izmeni_servis : Form
    {
        int id_servisa;
        string serviser;
        decimal cena_popravke;
        public Izmeni_servis(int id_servisa, string serviser, decimal cena_popravke)
        {
            this.id_servisa = id_servisa;
            this.serviser = serviser;
            this.cena_popravke = cena_popravke;
            InitializeComponent();
        }

        private void Izmeni_servis_Load(object sender, EventArgs e)
        {
            textBox1.Text = serviser;
            textBox2.Text = cena_popravke.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Servis_ s = new Servis_();

            s.serviser = textBox1.Text;
            s.cena_popravke = decimal.Parse(textBox2.Text);

            if(s.update_serivs(id_servisa))
            {
                MessageBox.Show("Servis je izmenjen!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Servis nije izmenjen!");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
