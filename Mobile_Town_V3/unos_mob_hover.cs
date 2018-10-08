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
    public partial class unos_mob_hover : Form
    {
        public unos_mob_hover()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Artikal art = new Artikal();

                art.sifra = int.Parse(textBox1.Text);
                art.grupa = comboBox1.Text;
                art.artikal = textBox2.Text;
                art.kolicina = Convert.ToInt32(numericUpDown1.Value);
                art.nabavna_cena = decimal.Parse(textBox3.Text);
                art.prodajna_cena = decimal.Parse(textBox4.Text);

                string query = null;

                if (checkBox1.Checked)
                {
                    query = "mob_hover_knjizeno";
                }
                else
                {
                    query = "mob_hover";
                }


                if(art.Unesi_artikal_mob_hover(query))
                {
                    MessageBox.Show("Artikal je unet!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Artikal nije unet!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void unos_mob_hover_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
