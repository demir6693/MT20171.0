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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            password.PasswordChar = '*';
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            panel7.BackColor = Color.DeepSkyBlue;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            panel8.BackColor = Color.DeepSkyBlue;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void login_Click(object sender, EventArgs e)
        {
            Korisnici_ k = new Korisnici_();
            if(k.login(user_name.Text, password.Text))
            {
                Naslovna n = new Naslovna(user_name.Text);
                this.Hide();
                n.ShowDialog();
            }
            else
            {
                MessageBox.Show("Pogresno korisnicko ime ili sifra!");
            }

            user_name.Clear();
            password.Clear();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Korisnici_ k = new Korisnici_();
            if (k.login(user_name.Text, password.Text))
            {
                Naslovna n = new Naslovna(user_name.Text);
                this.Hide();
                n.ShowDialog();
            }
            else
            {
                MessageBox.Show("Pogresno korisnicko ime ili sifra!");
            }

            user_name.Clear();
            password.Clear();
        }

        private void password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Korisnici_ k = new Korisnici_();
                if (k.login(user_name.Text, password.Text))
                {
                    Naslovna n = new Naslovna(user_name.Text);
                    this.Hide();
                    n.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Pogresno korisnicko ime ili sifra!");
                    user_name.Clear();
                    password.Clear();
                }
            }
            panel8.BackColor = Color.DeepSkyBlue;
        }

        private void user_name_KeyDown(object sender, KeyEventArgs e)
        {
            panel7.BackColor = Color.DeepSkyBlue;
        }
    }
}
