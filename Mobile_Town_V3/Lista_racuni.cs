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
    public partial class Lista_racuni : Form
    {
        public Lista_racuni()
        {
            InitializeComponent();
        }

        private void Lista_racuni_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mobile_TownDataSet.Racuni' table. You can move, or remove it, as needed.
            this.racuniTableAdapter.Fill(this.mobile_TownDataSet.Racuni);

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
                if(e.ColumnIndex == 5)
                {
                    int id_racuna = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    string prodavac = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    DateTime dt = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    string artikli = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    decimal iznos = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());

                    Vidi_racun vr = new Vidi_racun(id_racuna, prodavac, dt, artikli, iznos);
                    vr.ShowDialog();
                }
                else if(e.ColumnIndex == 6)
                {
                    Racun r = new Racun();
                    int id_racuna = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

                    if (MessageBox.Show("Zelite li da izbrisete racun sa id brojem: " + id_racuna + " ?", "Poruka", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (r.del_racun(id_racuna))
                        {
                            MessageBox.Show("Racun je izbrisan!");
                        }
                        else
                        {
                            MessageBox.Show("Racun nije izbrisan!");
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
            Lista_racuni_Load(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Racun r = new Racun();

            try
            {
                int id = int.Parse(textBox1.Text);
                List<Racun> ls = r.daj_racun(id);

                dataGridView1.DataSource = ls;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
