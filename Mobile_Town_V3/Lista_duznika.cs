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
    public partial class Lista_duznika : Form
    {
        public Lista_duznika()
        {
            InitializeComponent();
        }

        private void Lista_duznika_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            Dug d = new Dug();
            List<Dug> ls = d.get_dug();

            foreach(Dug i in ls)
            {
                dataGridView1.Rows.Add(i.id_duga, i.ime_prezime, i.broj_telefona, i.datum_izdavanja, i.datum_vracanja, i.sifra_artikla, i.artikal, i.cena);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(e.ColumnIndex == 8)
                {
                    int i = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    Dug d = new Dug();

                    if (MessageBox.Show("Zelite li da otkazete dug sa brojem: " + i + " ?", "Poruka", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (d.del_dug(i))
                        {
                            MessageBox.Show("Artikal je izbrisan!");
                        }
                        else
                        {
                            MessageBox.Show("Artikal nije izbrisan!");
                        }
                    }
                }
                else if(e.ColumnIndex == 9)
                {
                    int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    string ime_p = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    string broj_mob = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    DateTime dt1 = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                    DateTime dt2 = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                    int sifra_art = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                    string artikal = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                    decimal cena = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());

                    Izmena_duga idf = new Izmena_duga(id, ime_p, broj_mob, dt1, dt2, sifra_art, artikal, cena);
                    idf.ShowDialog();
                }
                else if(e.ColumnIndex == 10)
                {

                    int id_tmp = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    int sifra_artikla = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());

                    if (sifra_artikla != 0)
                    {
                        
                        Dug d = new Dug();
                        List<Dug> ls = d.get_jedan_dug(id_tmp);

                        if (ls[0].knjizeno == 1)
                        {
                            Racun r = new Racun();
                            r.artikli = ls[0].artikal;
                            r.datum_izdavanja = DateTime.Now;
                            r.iznos = ls[0].cena;

                            if (r.unesi_racun_knjizeno())
                            {
                                MessageBox.Show("Artikal naplacen");
                                d.del_dug(id_tmp);
                            }
                            else
                            {
                                MessageBox.Show("Artikal nije naplacen");
                            }
                        }
                        else if (ls[0].knjizeno == 0)
                        {
                            Racun r = new Racun();
                            r.prodavac = "dug";
                            r.artikli = ls[0].artikal;
                            r.datum_izdavanja = DateTime.Now;
                            r.iznos = ls[0].cena;


                            if (r.unesi_racun())
                            {
                                MessageBox.Show("Artikal naplacen");
                                d.del_dug(id_tmp);
                            }
                            else
                            {
                                MessageBox.Show("Artikal nije naplacen");
                            }
                        }

                    }
                    else if(sifra_artikla == 0)
                    {
                        Dug d = new Dug();
                        int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

                        if (d.del_dug(id))
                        {
                            MessageBox.Show("Dug je izbrisan");
                        }
                        else
                        {
                            MessageBox.Show("Dug nije izbrisan");
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Lista_duznika_Load(sender, e);
        }
    }
}
