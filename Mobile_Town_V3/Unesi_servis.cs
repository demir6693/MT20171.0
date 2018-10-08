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
    public partial class Unesi_servis : Form
    {
        public Unesi_servis()
        {
            InitializeComponent();
        }

        private void Unesi_servis_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd-MM-yy HH:mm";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Servis_ a = new Servis_();

            try
            {   
                if(string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    a.serviser = "";
                }
                else
                {
                    a.serviser = textBox1.Text;
                }
                
                a.DateTime = dateTimePicker1.Value.Date;

                if(string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    a.cena_popravke = 0;
                }
                else
                {
                    a.cena_popravke = decimal.Parse(textBox2.Text);
                }
                
                a.ime_prezime = textBox3.Text;
                a.broj_telefona = textBox4.Text;
                a.opis_kvara = textBox5.Text;

                if (a.unesi_servis())
                {
                    MessageBox.Show("Servis je unesen!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Servis nije unesen!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
