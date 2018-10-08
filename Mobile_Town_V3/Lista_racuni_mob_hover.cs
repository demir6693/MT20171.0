using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mobile_Town_V3
{
    public partial class Lista_racuni_mob_hover : Form
    {
        string izvestaj;
        public Lista_racuni_mob_hover()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Lista_racuni_mob_hover_Load(object sender, EventArgs e)
        {
            Korisnici_ k = new Korisnici_();
            List<string> ls_k = k.daj_korisnike();

            comboBox1.Items.Clear();
            for(int i = 0; i < ls_k.Count; i++)
            {
                comboBox1.Items.Add(ls_k[i]);
            }
            comboBox1.Items.Add("Svi");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(e.ColumnIndex == 7)
                {
                    int sifra = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    Racun r = new Racun();
                    if (r.del_racun_mob_hover(sifra))
                    {
                        MessageBox.Show("Racun je izbrisan");
                        Lista_racuni_mob_hover_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Racun je izbrisan");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            suma();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            Racun r = new Racun();
            List<Racun> ls = r.daj_racun_prodavac_dnevni_mob_hover();
            if(checkBox1.Checked)
            {
                foreach (Racun i in ls)
                {   
                    if(i.knjizeno == 1)
                    {
                        if (comboBox1.Text.Equals("Svi"))
                        {
                            dataGridView1.Rows.Add(i.id_racuna, i.prodavac, i.datum_izdavanja, i.artikli, i.iznos, i.iznos_nabavna, i.knjizeno);
                        }
                        else if (comboBox1.Text.Equals(i.prodavac))
                        {
                            dataGridView1.Rows.Add(i.id_racuna, i.prodavac, i.datum_izdavanja, i.artikli, i.iznos, i.iznos_nabavna, i.knjizeno);
                        }
                    }
                    
                }
            }
            else
            {
                foreach (Racun i in ls)
                {
                    if (comboBox1.Text.Equals("Svi"))
                    {
                        dataGridView1.Rows.Add(i.id_racuna, i.prodavac, i.datum_izdavanja, i.artikli, i.iznos, i.iznos_nabavna, i.knjizeno);
                    }
                    else if (comboBox1.Text.Equals(i.prodavac))
                    {
                        dataGridView1.Rows.Add(i.id_racuna, i.prodavac, i.datum_izdavanja, i.artikli, i.iznos, i.iznos_nabavna, i.knjizeno);
                    }
                }
            }
            suma();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            Racun r = new Racun();
            List<Racun> ls = r.daj_racun_prodavac_mesecni_mob_hover();
            if (checkBox1.Checked)
            {
                foreach (Racun i in ls)
                {
                    if (i.knjizeno == 1)
                    {
                        if (comboBox1.Text.Equals("Svi"))
                        {
                            dataGridView1.Rows.Add(i.id_racuna, i.prodavac, i.datum_izdavanja, i.artikli, i.iznos, i.iznos_nabavna, i.knjizeno);
                        }
                        else if (comboBox1.Text.Equals(i.prodavac))
                        {
                            dataGridView1.Rows.Add(i.id_racuna, i.prodavac, i.datum_izdavanja, i.artikli, i.iznos, i.iznos_nabavna, i.knjizeno);
                        }
                    }

                }
            }
            else
            {
                foreach (Racun i in ls)
                {
                    if (comboBox1.Text.Equals("Svi"))
                    {
                        dataGridView1.Rows.Add(i.id_racuna, i.prodavac, i.datum_izdavanja, i.artikli, i.iznos, i.iznos_nabavna, i.knjizeno);
                    }
                    else if (comboBox1.Text.Equals(i.prodavac))
                    {
                        dataGridView1.Rows.Add(i.id_racuna, i.prodavac, i.datum_izdavanja, i.artikli, i.iznos, i.iznos_nabavna, i.knjizeno);
                    }
                }
            }
            suma();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            Racun r = new Racun();
            List<Racun> ls = r.daj_racun_prodavac_godisnji_mob_hover();
            if (checkBox1.Checked)
            {
                foreach (Racun i in ls)
                {
                    if (i.knjizeno == 1)
                    {
                        if (comboBox1.Text.Equals("Svi"))
                        {
                            dataGridView1.Rows.Add(i.id_racuna, i.prodavac, i.datum_izdavanja, i.artikli, i.iznos, i.iznos_nabavna, i.knjizeno);
                        }
                        else if (comboBox1.Text.Equals(i.prodavac))
                        {
                            dataGridView1.Rows.Add(i.id_racuna, i.prodavac, i.datum_izdavanja, i.artikli, i.iznos, i.iznos_nabavna, i.knjizeno);
                        }
                    }

                }
            }
            else
            {
                foreach (Racun i in ls)
                {
                    if (comboBox1.Text.Equals("Svi"))
                    {
                        dataGridView1.Rows.Add(i.id_racuna, i.prodavac, i.datum_izdavanja, i.artikli, i.iznos, i.iznos_nabavna, i.knjizeno);
                    }
                    else if (comboBox1.Text.Equals(i.prodavac))
                    {
                        dataGridView1.Rows.Add(i.id_racuna, i.prodavac, i.datum_izdavanja, i.artikli, i.iznos, i.iznos_nabavna, i.knjizeno);
                    }
                }
            }
            suma();
        }

        private void suma()
        {
            decimal sum = 0;
            decimal nabavna = 0;
            foreach (DataGridViewRow datarow in dataGridView1.Rows)
            {
                sum += decimal.Parse(datarow.Cells[4].Value.ToString());
                nabavna += decimal.Parse(datarow.Cells[5].Value.ToString());
            }
            textBox1.Text = sum + " e";
            textBox2.Text = (sum - nabavna) + " e";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            izvestaj = "Izvestaj";
            crtaj_fakturu();
        }

        private void crtaj_fakturu()
        {

            iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4.Rotate());
            try
            {
                PdfWriter.GetInstance(doc, new FileStream("racun.pdf", FileMode.Create));
                doc.Open();

                iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph("Mobile Town");
                title.Alignment = Element.ALIGN_CENTER;
                title.Font.Size = 32;
                doc.Add(title);

                iTextSharp.text.Paragraph podaci;
                podaci = new iTextSharp.text.Paragraph("\n");
                podaci.Add("\n");
                podaci.Add("           Datum:" + DateTime.Now.ToString("       dd-MM-yyyy HH-mm"));
                podaci.Add("\n");
                podaci.Add("           " + izvestaj);
                podaci.Font.Size = 14;
                doc.Add(podaci);

                iTextSharp.text.Paragraph razmak = new iTextSharp.text.Paragraph("\n");
                doc.Add(razmak);

                PdfPTable table = new PdfPTable(5);
                table.AddCell("id Racuna");
                table.AddCell("Prodavac");
                table.AddCell("Artikli");
                table.AddCell("Datum izdavanja");
                table.AddCell("Iznos");
                double suma = 0;
                foreach (DataGridViewRow datarow in dataGridView1.Rows)
                {
                    table.AddCell(datarow.Cells[0].Value.ToString());
                    table.AddCell(datarow.Cells[1].Value.ToString());
                    table.AddCell(datarow.Cells[3].Value.ToString());
                    table.AddCell(datarow.Cells[2].Value.ToString());
                    table.AddCell(datarow.Cells[4].Value.ToString());

                    suma += double.Parse(datarow.Cells[4].Value.ToString());
                }

                doc.Add(table);

                iTextSharp.text.Paragraph razmak1 = new iTextSharp.text.Paragraph("\n");
                doc.Add(razmak1);

                PdfPTable table_konacno = new PdfPTable(2);
                table_konacno.AddCell("Ukupno");
                table_konacno.AddCell("PDV(20%) Ukupno");

                table_konacno.AddCell(suma.ToString());
                table_konacno.AddCell((suma * 0.2).ToString());
                doc.Add(table_konacno);

                System.Diagnostics.Process.Start("racun.pdf");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                doc.Close();
            }

        }
    }
}
