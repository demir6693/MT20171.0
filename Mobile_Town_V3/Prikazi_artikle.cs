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
    public partial class Prikazi_artikle : Form
    {
        public string grupa;
        string user;
        static string k_or_n = "Artikli";
        public Prikazi_artikle(string grupa_pom, string user)
        {
            this.grupa = grupa_pom;
            this.user = user;
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

        private void Prikazi_artikle_Load(object sender, EventArgs e)
        {
            k_or_n = "Artikli_knjizeno";
            Artikal art = new Artikal();
            List<Artikal> ls = art.get_artikli(grupa, "Artikli_knjizeno");

            foreach (Artikal a in ls)
            {
                artikalBindingSource.Add(new Artikal() { sifra = a.sifra, artikal = a.artikal, kolicina = a.kolicina, prodajna_cena = a.prodajna_cena, knjizeno = a.knjizeno, nabavna_cena = a.nabavna_cena });
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5)
                {
                    Artikal a = new Artikal();

                    a.sifra = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    a.artikal = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    a.prodajna_cena = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                    a.knjizeno = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                    a.nabavna_cena = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
                    Unos_artikla_u_racun uns = new Unos_artikla_u_racun(a.sifra, a.artikal, a.prodajna_cena, a.knjizeno, a.nabavna_cena);
                    uns.ShowDialog();
                }
                else if(e.ColumnIndex == 6)
                {
                    Artikal a = new Artikal();

                    a.sifra = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    a.artikal = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    a.prodajna_cena = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                    a.knjizeno = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());

                    Rezervacija rz = new Rezervacija(a.sifra, a.artikal, a.prodajna_cena, a.knjizeno);
                    rz.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            Prikazi_artikle_Load(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            k_or_n = "Artikli";
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            Artikal art = new Artikal();
            List<Artikal> ls = art.get_artikli(grupa, "Artikli");

            foreach (Artikal a in ls)
            {
                artikalBindingSource.Add(new Artikal() { sifra = a.sifra, artikal = a.artikal, kolicina = a.kolicina, prodajna_cena = a.prodajna_cena, knjizeno = a.knjizeno, nabavna_cena = a.nabavna_cena});
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            string search = textBox1.Text;

            Artikal a = new Artikal();
            List<Artikal> lista_artikala = a.Pretraga(search, grupa, k_or_n);

            foreach(Artikal n in lista_artikala)
            {
                artikalBindingSource.Add(new Artikal() { sifra = n.sifra, artikal = n.artikal, kolicina = n.kolicina, prodajna_cena = n.prodajna_cena, knjizeno = n.knjizeno, nabavna_cena = n.nabavna_cena });
            }
        }
    }
}
