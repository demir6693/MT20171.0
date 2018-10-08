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
    public partial class Unesi_narudzbinu : Form
    {
        public Unesi_narudzbinu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Narudzbine_ n = new Narudzbine_();

            n.ime_prezime = textBox1.Text;
            n.broj_telefona = textBox2.Text;
            n.opis_narudzbine = textBox3.Text;

            if(n.unesi_narudzbinu())
            {
                MessageBox.Show("Narudzbina je uneta!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Narudzbina nije uneta!");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
