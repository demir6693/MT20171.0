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
    public partial class Lista_rezervacija : Form
    {
        public Lista_rezervacija()
        {
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

        private void Lista_rezervacija_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            Rezervacija_ r = new Rezervacija_();
            List<Rezervacija_> ls = r.get_rezervacija();

            foreach(Rezervacija_ i in ls)
            {
                dataGridView1.Rows.Add(i.id_rezervacija, i.sifra_artikla, i.ime_prezime, i.broj_telefona, i.artikal, i.cena, i.kolicina, i.knjizeno);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(e.ColumnIndex == 9)
                {
                    int i = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    Rezervacija_ r = new Rezervacija_();

                    if (MessageBox.Show("Zelite li da otkazete rezervaciju sa brojem: " + i + " ?", "Poruka", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Artikal a = new Artikal();
                        if(int.Parse(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString()) == 0)
                        {
                            a.update_artikli_uvecaj("Artikli", int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()), int.Parse(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString()));
                        }
                        else if(int.Parse(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString()) == 1)
                        {
                            a.update_artikli_uvecaj("Artikli_knjizeno", int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()), int.Parse(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString()));
                        }

                        if (r.del_rezervacija(i))
                        {
                            MessageBox.Show("Rezervacija je izbrisana!");
                        }
                        else
                        {
                            MessageBox.Show("Rezervacija nije izbrisana!");
                        }
                    }
                }
                else if(e.ColumnIndex == 8)
                {   
                    int sifra_rezervacije = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    int sifra = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    string ime_prezime = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    string broj_telefona = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    string artikal = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    decimal cena = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                    int kolicina = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
                    int knjizeno = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
                    Naplati_rezervaciju nr = new Naplati_rezervaciju(sifra, ime_prezime, broj_telefona, artikal, cena, kolicina, knjizeno, sifra_rezervacije);
                    nr.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Lista_rezervacija_Load(sender, e);
        }
    }
}
