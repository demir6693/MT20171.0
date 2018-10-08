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
    public partial class Racuni_hover_mob : Form
    {
        int sifra;
        string artikal;
        string grupa;
        int kolicina;
        decimal cena;
        decimal nabavna;
        int knjizeno;
        string prodavac;
        string query;

        public Racuni_hover_mob(int sifra, string artikal, string grupa, int kolicina, decimal cena, decimal nabavna, int knjizeno, string prodavac, string query)
        {
            this.sifra = sifra;
            this.artikal = artikal;
            this.grupa = grupa;
            this.kolicina = kolicina;
            this.cena = cena;
            this.knjizeno = knjizeno;
            this.prodavac = prodavac;
            this.nabavna = nabavna;
            this.query = query;
            InitializeComponent();
        }

        private void Racuni_hover_mob_Load(object sender, EventArgs e)
        {
            textBox3.Enabled = false;

            label9.Text = prodavac;
            label10.Text = DateTime.Now.ToString("dd-MM-yyyy");
            label11.Text = sifra + " " + grupa + " " + artikal + " " + cena + "e";
            label7.Text = cena.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox3.Enabled = true;
            }
            else
            {
                textBox3.Enabled = false;
                textBox3.Clear();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal cena = decimal.Parse(label7.Text);
            decimal uplaceno = decimal.Parse(textBox1.Text);

            decimal povracaj = uplaceno - cena;
            label8.Text = povracaj.ToString();

            

            if(povracaj >= 0)
            {
                try
                {
                    Racun r = new Racun();
                    r.prodavac = prodavac;
                    r.datum_izdavanja = DateTime.Now;
                    r.artikli = grupa + " " + artikal;
                    r.iznos = cena;
                    r.iznos_nabavna = nabavna;
                    r.knjizeno = knjizeno;

                    if (r.unesi_racun_mob_hov())
                    {
                        MessageBox.Show("Racun je unet!");
                        Artikal a = new Artikal();
                        a.update_artikli_mob_hover(query, sifra);
                        button1.Enabled = false;
                        crtaj_fakturu();
                    }
                    else
                    {
                        MessageBox.Show("Racun nije unet!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Pogresan unos!");
            }
            


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
                podaci.Add("           Prodavac:  " + prodavac);
                podaci.Font.Size = 14;
                doc.Add(podaci);

                iTextSharp.text.Paragraph razmak = new iTextSharp.text.Paragraph("\n");
                doc.Add(razmak);

                PdfPTable table = new PdfPTable(4);
                table.AddCell("Artikli");
                table.AddCell("Kolicina");
                table.AddCell("Cena");
                table.AddCell("PDV(20%)");

                table.AddCell(sifra + " " + grupa + " " + artikal);
                table.AddCell(kolicina.ToString());
                table.AddCell(cena.ToString());
                double pdv = double.Parse(cena.ToString()) * 0.2;
                table.AddCell(pdv.ToString());

                doc.Add(table);

                iTextSharp.text.Paragraph razmak1 = new iTextSharp.text.Paragraph("\n");
                doc.Add(razmak1);

                PdfPTable table_konacno = new PdfPTable(2);
                table_konacno.AddCell("Ukupno");
                table_konacno.AddCell("PDV(20%) Ukupno");

               
                table_konacno.AddCell(cena + " e");
                table_konacno.AddCell(pdv + " e");
                doc.Add(table_konacno);

                iTextSharp.text.Paragraph razmak2 = new iTextSharp.text.Paragraph("\n");
                razmak2.Add("\n");
                razmak2.Add("\n");
                razmak2.Add("\n");
                doc.Add(razmak2);

                PdfPTable table_potpis = new PdfPTable(2);
                table_potpis.AddCell("Racun izdaje");
                table_potpis.AddCell("Racun prima");

                table_potpis.AddCell(textBox2.Text);
                table_potpis.AddCell(textBox3.Text);

                doc.Add(table_potpis);

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
