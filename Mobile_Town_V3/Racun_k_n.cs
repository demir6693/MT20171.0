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
    public partial class Racun_k_n : Form
    {
        public Racun_k_n()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lista_racuni lr = new Lista_racuni();
            lr.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Racuni_knjizeno rk = new Racuni_knjizeno();
            rk.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
