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
     
    public partial class Naslovna : Form
    {
        public int sifra;
        public string artikal;
        public int kolicina;
        public decimal cena;
        decimal sum;

        public string user;
        public Naslovna(String user)
        {
            this.user = user;
            InitializeComponent();
        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void mobilniTelefoniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Unos un = new Unos("Mobilni telefoni");
            un.ShowDialog();

        }

        

        private void stakloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Unos un = new Unos("Staklo");
            un.ShowDialog();
        }

        private void futroleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Unos un = new Unos("Futrole");
            un.ShowDialog();
        }

        private void baterijeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Unos un = new Unos("Baterije");
            un.ShowDialog();
        }

        private void punjaciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Unos un = new Unos("Punjaci");
            un.ShowDialog();
        }

        private void memorijeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Unos un = new Unos("Memorije");
            un.ShowDialog();
        }

        private void ostaloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Unos un = new Unos("Ostalo");
            un.ShowDialog();
        }

       

        private void izmenaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Izmena iz = new Izmena(user);
            iz.ShowDialog();
        }

        private void Naslovna_Load(object sender, EventArgs e)
        {
            if(!user.Equals("mobiletown"))
            {
                dodatnoToolStripMenuItem.Visible = false;
                dodajKorisnikaToolStripMenuItem.Enabled = false;
            }
        }

        private void dodajKorisnikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        void fmr_FormClosed(object sender, FormClosedEventArgs e)
        {
            puni_tablu();
            sum_row();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Prikazi_artikle pa = new Prikazi_artikle("Mobilni telefoni", user);
            pa.FormClosed += new FormClosedEventHandler(fmr_FormClosed);
            pa.ShowDialog();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Prikazi_artikle pa = new Prikazi_artikle("Staklo", user);
            pa.FormClosed += new FormClosedEventHandler(fmr_FormClosed);
            pa.ShowDialog();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Prikazi_artikle pa = new Prikazi_artikle("Futrole", user);
            pa.FormClosed += new FormClosedEventHandler(fmr_FormClosed);
            pa.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Prikazi_artikle pa = new Prikazi_artikle("Baterije", user);
            pa.FormClosed += new FormClosedEventHandler(fmr_FormClosed);
            pa.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Prikazi_artikle pa = new Prikazi_artikle("Punjaci", user);
            pa.FormClosed += new FormClosedEventHandler(fmr_FormClosed);
            pa.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Prikazi_artikle pa = new Prikazi_artikle("Memorije", user);
            pa.FormClosed += new FormClosedEventHandler(fmr_FormClosed);
            pa.ShowDialog();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Prikazi_artikle pa = new Prikazi_artikle("Ostalo", user);
            pa.FormClosed += new FormClosedEventHandler(fmr_FormClosed);
            pa.ShowDialog();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            List<int> sifre = new List<int>();
            List<string> artikli = new List<string>();
            List<int> kolicina = new List<int>();
            List<decimal> cena = new List<decimal>();
            List<int> knjizeno = new List<int>();
            decimal suma_nabavna = 0;
            decimal suma_zarada_knjizeno = 0;
            Artikal a = new Artikal();

            foreach (DataGridViewRow datarow in dataGridView1.Rows)
            {
                sifre.Add(int.Parse(datarow.Cells[0].Value.ToString()));
                
                artikli.Add((datarow.Cells[1].Value.ToString()));
                
                kolicina.Add(int.Parse(datarow.Cells[2].Value.ToString()));
                
                cena.Add(decimal.Parse(datarow.Cells[3].Value.ToString()));

                knjizeno.Add(int.Parse(datarow.Cells[4].Value.ToString()));

                suma_nabavna += decimal.Parse(datarow.Cells[5].Value.ToString()) * int.Parse(datarow.Cells[2].Value.ToString());
             
                if(int.Parse(datarow.Cells[4].Value.ToString()) == 1)
                {
                    suma_zarada_knjizeno += decimal.Parse(datarow.Cells[5].Value.ToString()) * int.Parse(datarow.Cells[2].Value.ToString());
                    a.update_artikli_knjizeno(int.Parse(datarow.Cells[0].Value.ToString()), int.Parse(datarow.Cells[2].Value.ToString()));
                }
                else if(int.Parse(datarow.Cells[4].Value.ToString()) == 0)
                {
                    a.update_artikli(int.Parse(datarow.Cells[0].Value.ToString()), int.Parse(datarow.Cells[2].Value.ToString()));
                }
 
            }

            Stampaj_racun sr = new Stampaj_racun(user, sifre, artikli, kolicina, cena, knjizeno, sum, suma_nabavna, suma_zarada_knjizeno);
            sr.FormClosed += new FormClosedEventHandler(pictureBox17_Click);
            sr.ShowDialog();
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            sum_row();
        }

        public void puni_tablu()
        {
            foreach(Artikal a in Artikal.get_list)
            {
                dataGridView1.Rows.Add(a.sifra.ToString(), a.artikal, a.kolicina.ToString(), a.prodajna_cena.ToString(), a.knjizeno.ToString(), a.nabavna_cena.ToString());
            }
            Artikal.get_list.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(e.ColumnIndex == 6)
                {
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                    sum_row();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sum_row()
        {
            this.sum = 0;
            for(int i = 0; i < dataGridView1.RowCount; i++)
            {
                this.sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value) * int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
            }
            label14.Text = sum + " din";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Servis s = new Servis();
            s.ShowDialog();
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            Narudzbina n = new Narudzbina();
            n.ShowDialog();
        }

        private void rezervacijaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lista_rezervacija lr = new Lista_rezervacija();
            lr.ShowDialog();
        }

        private void unesiDugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Unos_duga ud = new Unos_duga();
            ud.ShowDialog();
        }

        private void listaDuznikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lista_duznika ld = new Lista_duznika();
            ld.ShowDialog();
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            Racun_k_n rkn = new Racun_k_n();
            rkn.ShowDialog();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Dnevni_pazar dp = new Dnevni_pazar("DNEVNI", user);
            dp.ShowDialog();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Dnevni_pazar dp = new Dnevni_pazar("MESECNI", user);
            dp.ShowDialog();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Dnevni_pazar dp = new Dnevni_pazar("GODISNJI", user);
            dp.ShowDialog();
        }

        private void izlogujSeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            Form1 frm1 = new Form1();
            frm1.ShowDialog();
        }

        private void dodajKorisnikaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Dodaj_korisnika dk = new Dodaj_korisnika();
            dk.ShowDialog();
        }

        private void listaKorisnikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lista_radnika lr = new Lista_radnika();
            lr.ShowDialog();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            mob_hover_pocetna mhp = new mob_hover_pocetna(user);
            mhp.ShowDialog();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            sum_row();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                sum_row();
            }
        }
    }
}
