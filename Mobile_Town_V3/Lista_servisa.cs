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
    public partial class Lista_servisa : Form
    {
        public Lista_servisa()
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

        private void Lista_servisa_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            Servis_ s = new Servis_();
            List<Servis_> ls = s.get_seris_ls();

            foreach(Servis_ i in ls)
            {
                dataGridView1.Rows.Add(i.id_servisa, i.serviser, i.DateTime, i.cena_popravke, i.ime_prezime, i.broj_telefona, i.opis_kvara);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Servis_ s = new Servis_();

            try
            {
                if(e.ColumnIndex == 7)
                {
                    int n = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

                    if (MessageBox.Show("Zelite li da izbrisete servisiranje sa sifrom: " + n + " ?", "Poruka", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (s.izbrisi_servis(n))
                        {
                            MessageBox.Show("Servisiranje je obrisano!");
                        }
                        else
                        {
                            MessageBox.Show("Servisiranje nije obrisano!");
                        }
                    }

                }
                else if(e.ColumnIndex == 8)
                {
                    int sifra = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    string serviser = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    DateTime dt_ost = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    decimal cena_popravke = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                    string ime_prezime = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    string br_tel = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    string opis_kvara = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                    

                    Naplati_servis ns = new Naplati_servis(sifra, serviser, dt_ost, cena_popravke, ime_prezime, br_tel, opis_kvara);
                    ns.ShowDialog();
                }
                else if(e.ColumnIndex == 9)
                {
                    int sifra = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    string serviser = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    decimal cena_popravke = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());

                    Izmeni_servis izs = new Izmeni_servis(sifra, serviser, cena_popravke);
                    izs.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Lista_servisa_Load(sender, e);
        }
    }
}
