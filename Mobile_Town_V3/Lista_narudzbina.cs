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
    public partial class Lista_narudzbina : Form
    {
        public Lista_narudzbina()
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

        private void Lista_narudzbina_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            Narudzbine_ n = new Narudzbine_();
            List<Narudzbine_> ls = n.get_narudzbine();

            foreach(Narudzbine_ i in ls)
            {
                dataGridView1.Rows.Add(i.id_narudzbine, i.ime_prezime, i.broj_telefona, i.opis_narudzbine);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(e.ColumnIndex == 4)
                {
                    int i = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    Narudzbine_ n = new Narudzbine_();
                    
                    if(MessageBox.Show("Zelite li da otkazete narudzbinu sa brojem: " +i+ " ?", "Poruka", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if(n.del_narudzbina(i))
                        {
                            MessageBox.Show("Artikal je izbrisan!");
                        }
                        else
                        {
                            MessageBox.Show("Artikal nije izbrisan!");
                        }
                    }
                }
                else if(e.ColumnIndex == 5)
                {
                    int i = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    string ime_prezime = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    string br_mob = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    string narudzbina = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

                    Naplati_narudzbinu nn = new Naplati_narudzbinu(ime_prezime, br_mob, narudzbina);
                    nn.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Lista_narudzbina_Load(sender, e);
        }
    }
}
