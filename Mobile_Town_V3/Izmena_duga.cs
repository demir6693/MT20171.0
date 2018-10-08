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
    public partial class Izmena_duga : Form
    {
        int id;
        string ime_p;
        string broj_mob;
        DateTime dt1;
        DateTime dt2;
        int sifra_art;
        string artikal;
        decimal cena;

        public Izmena_duga(int id, string ime_p, string broj_mob, DateTime dt1, DateTime dt2, int sifra_art, string artikal, decimal cena)
        {
            this.id = id;
            this.ime_p = ime_p;
            this.broj_mob = broj_mob;
            this.dt1 = dt1;
            this.dt2 = dt2;
            this.sifra_art = sifra_art;
            this.artikal = artikal;
            this.cena = cena;
            InitializeComponent();
        }

        private void Izmena_duga_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd-MM-yy HH:mm";
            dateTimePicker2.CustomFormat = "dd-MM-yy HH:mm";

            label9.Text = id.ToString();
            textBox1.Text = ime_p;
            textBox2.Text = broj_mob;
            dateTimePicker1.Value = dt1;
            dateTimePicker2.Value = dt2;
            textBox5.Text = cena.ToString();


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dug d = new Dug();

            try
            {
                d.ime_prezime = textBox1.Text;
                d.broj_telefona = textBox2.Text;
                d.datum_izdavanja = dateTimePicker1.Value;
                d.datum_vracanja = dateTimePicker2.Value;
                d.cena = decimal.Parse(textBox5.Text);

                if (d.izmeni_dug(id))
                {
                    MessageBox.Show("Dug je izmenjen!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Dug nije izmenjen!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
