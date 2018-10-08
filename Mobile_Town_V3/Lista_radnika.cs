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
    public partial class Lista_radnika : Form
    {
        public Lista_radnika()
        {
            InitializeComponent();
        }

        private void Lista_radnika_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mobile_TownDataSet2.Korisnici' table. You can move, or remove it, as needed.
            this.korisniciTableAdapter.Fill(this.mobile_TownDataSet2.Korisnici);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(e.ColumnIndex == 5)
                {
                    Korisnici_ k = new Korisnici_();
                    if(k.brisi_korisnika(int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString())))
                    {
                        MessageBox.Show("Korisnik je obrisan!");
                    }
                    else
                    {
                        MessageBox.Show("Korisnik nije obrisan!");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Lista_radnika_Load(sender, e);
        }
    }
}
