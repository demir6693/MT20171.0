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
    public partial class Lista_hover_mob : Form
    {
        string user;
        public Lista_hover_mob(string user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void Lista_hover_mob_Load(object sender, EventArgs e)
        {
            Artikal a = new Artikal();
            List<Artikal> ls = a.get_hover_mob("Mobilni telefon", "mob_hover_knjizeno");
            dataGridView1.DataSource = ls;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Artikal a = new Artikal();
            string query = null;
            if(checkBox1.Checked)
            {
                query = "mob_hover_knjizeno";
            }
            else
            {
                query = "mob_hover";
            }

            List<Artikal> ls = a.get_hover_mob(comboBox1.Text, query);
            dataGridView1.DataSource = ls;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {   
            try
            {
                Artikal a = new Artikal();
                if(e.ColumnIndex == 6)
                {
                    int sifra = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    string grupa = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    string artikal = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    int kolicina = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                    decimal cena = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                    decimal nabavna = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());

                    int knjizeno = 0;
                    string query = null;

                    if (checkBox1.Checked)
                    {
                        query = "mob_hover_knjizeno";
                        knjizeno = 1;
                    }
                    else
                    {
                        query = "mob_hover";
                        knjizeno = 0;
                    }

                    if(a.proveri_stanje(query, 1, sifra ))
                    {
                        Racuni_hover_mob rhm = new Racuni_hover_mob(sifra, artikal, grupa, kolicina, cena, nabavna, knjizeno, user, query);
                        rhm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Trazenog artikla nema na stanju!");
                    }  
                }
                else if(e.ColumnIndex == 7)
                {
                    int sifra = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    string grupa = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    string artikal = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    int kolicina = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                    decimal cena = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                    decimal nabavna = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());

                    int knjizeno = 0;
                    string query = null;

                    if (checkBox1.Checked)
                    {
                        query = "mob_hover_knjizeno";
                        knjizeno = 1;
                    }
                    else
                    {
                        query = "mob_hover";
                        knjizeno = 0;
                    }

                    izmena_mob_hover imh = new izmena_mob_hover(sifra, grupa, artikal, kolicina, nabavna, cena, knjizeno, query);
                    imh.ShowDialog();
                }
                else if(e.ColumnIndex == 8)
                {
                    int sifra = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                  
                    string query = null;
                    if (checkBox1.Checked)
                    {
                        query = "mob_hover_knjizeno";
                      
                    }
                    else
                    {
                        query = "mob_hover";
                       
                    }

                    if (a.brisi_artikal_mob_hover(sifra, query))
                    {
                        MessageBox.Show("Artikal je obrisan!");
                    }
                    else
                    {
                        MessageBox.Show("Artikal nije obrisan!");
                    }
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
