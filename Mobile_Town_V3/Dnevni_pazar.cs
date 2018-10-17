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
    public partial class Dnevni_pazar : Form
    {
        string izvestaj;
        string user;
        
        public Dnevni_pazar(string izvestaj, string user)
        {
            this.izvestaj = izvestaj;
            this.user = user;
            InitializeComponent();
            Korisnici_ k = new Korisnici_();
            List<string> korisnici = k.daj_korisnike();
            korisnici.Add("Svi");

            comboBox1.DataSource = korisnici;
            comboBox1.Text = "Svi";

            if(!user.Equals("mobiletown"))
            {
                button4.Visible = false;
                comboBox1.Visible = false;
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

        private void Dnevni_pazar_Load(object sender, EventArgs e)
        {
    
            List<Racun> ls = new List<Racun>();
            Racun r = new Racun();
            if (izvestaj.Equals("DNEVNI"))
            {                       
                ls = r.daj_racun_prodavac_dnevni(comboBox1.SelectedItem.ToString());
            }
            else if(izvestaj.Equals("MESECNI"))
            {
                ls = r.daj_racun_prodavac_mesecni(comboBox1.SelectedItem.ToString());
            }
            else if(izvestaj.Equals("GODISNJI"))
            {
                ls = r.daj_racun_prodavac_godisnji(comboBox1.SelectedItem.ToString());
            }

            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.DataSource = ls;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            daj_sumu();
            daj_zaradu();

            if (!user.Equals("mobiletown"))
            {
                panel7.Visible = false;
                label3.Visible = false;
                dataGridView1.Columns[5].Visible = false;
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            crtaj_fakturu();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Racun> ls = new List<Racun>();
            Racun r = new Racun();
            if (izvestaj.Equals("DNEVNI"))
            {
                ls = r.daj_racun_prodavac_dnevni_knjizeno();
            }
            else if (izvestaj.Equals("MESECNI"))
            {
                ls = r.daj_racun_prodavac_mesecni_knjizeno();
            }
            else if (izvestaj.Equals("GODISNJI"))
            {
                ls = r.daj_racun_prodavac_godisnji_knjizeno();
            }

            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.DataSource = ls;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            daj_sumu();
            daj_zaradu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dnevni_pazar_Load(sender, e);
        }

        private void daj_sumu()
        {
            decimal sum = 0;
            foreach (DataGridViewRow datarow in dataGridView1.Rows)
            {
                sum += decimal.Parse(datarow.Cells[4].Value.ToString());
            }
            label1.Text = sum + " din";
        }

        private void daj_zaradu()
        {
            decimal sum_prodajna = 0;
            decimal sum_nabavna = 0;
            foreach (DataGridViewRow datarow in dataGridView1.Rows)
            {
                sum_prodajna += decimal.Parse(datarow.Cells[4].Value.ToString());
                sum_nabavna += decimal.Parse(datarow.Cells[5].Value.ToString());
            }
            decimal zarada = sum_prodajna - sum_nabavna;
            label2.Text = zarada + "din";
        }

        private void crtaj_fakturu()
        {

            iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4.Rotate());
            string date_time = (DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second).ToString();
            try
            {
                string dir_mb = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MobileTown_racuni";

                if (Directory.Exists(dir_mb))
                {
                    PdfWriter.GetInstance(doc, new FileStream(dir_mb + "\\izvestaj" + date_time + ".pdf", FileMode.Create));
                    doc.Open();
                }
                else
                {
                    Directory.CreateDirectory(dir_mb);
                    PdfWriter.GetInstance(doc, new FileStream(dir_mb + "\\izvestaj" + date_time + ".pdf", FileMode.Create));
                    doc.Open();
                }

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

                PdfPTable table = new PdfPTable(4);
                table.AddCell("id Racuna");
                table.AddCell("Artikli");
                table.AddCell("Datum izdavanja");
                table.AddCell("Iznos");
                double suma = 0;
                foreach (DataGridViewRow datarow in dataGridView1.Rows)
                {
                    table.AddCell(datarow.Cells[0].Value.ToString());
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

                System.Diagnostics.Process.Start(dir_mb + "\\izvestaj" + date_time + ".pdf");
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

        private void button4_Click(object sender, EventArgs e)
        {
            Dnevni_pazar_Load(sender, e);
        }
    }
}
