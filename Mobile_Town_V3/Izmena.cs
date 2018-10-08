using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Mobile_Town_V3
{
    public partial class Izmena : Form
    {
        string user;
        public Izmena(string user)
        {
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

        private void Izmena_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            if(!user.Equals("mobiletown"))
            {
                dataGridView1.Columns[4].Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            string query = "Artikli";
            if(checkBox1.Checked)
            {
                query = "Artikli_knjizeno";
            }

            Artikal art = new Artikal();
            List<Artikal> ls = art.get_artikli(comboBox1.Text, query);

            foreach(Artikal a in ls)
            {
                artikalBindingSource.Add(new Artikal() { sifra = a.sifra, grupa = a.grupa, artikal = a.artikal, kolicina = a.kolicina, nabavna_cena = a.nabavna_cena, prodajna_cena = a.prodajna_cena });
            }
  
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string query = "Artikli";
            if(checkBox1.Checked)
            {
                query = "Artikli_knjizeno";
            }
            try
            {   
                if (e.ColumnIndex == 6)
                {
                int s = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                Izmena_artikla ia = new Izmena_artikla(s, query);
                ia.ShowDialog();
                }
                else if(e.ColumnIndex == 7)
                {
                    Artikal a = new Artikal();
                    int s = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

                    if(MessageBox.Show("Zelite li da izbrisete artikal sa sifrom:" +s + " ?", "Poruka", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if(a.brisi_artikal(s, query))
                        {
                            MessageBox.Show("Artikal je obrisan!");
                        }
                        else
                        {
                            MessageBox.Show("Artikal nije obrisan!");
                        }
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
