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
    public partial class Vidi_racun : Form
    {
        int id_racuna;
        string prodavac;
        DateTime dt1;
        string artikli;
        decimal iznos;

        public Vidi_racun(int id_racuna, string prodavac, DateTime dt1, string artikli, decimal iznos)
        {
            this.id_racuna = id_racuna;
            this.prodavac = prodavac;
            this.dt1 = dt1;
            this.artikli = artikli;
            this.iznos = iznos;
            InitializeComponent();
        }

        private void Vidi_racun_Load(object sender, EventArgs e)
        {
            label2.Text = id_racuna.ToString();
            label4.Text = prodavac;
            label6.Text = dt1.ToString("dd-MM-yyyy");
            label8.Text = artikli;
            label10.Text = iznos.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
