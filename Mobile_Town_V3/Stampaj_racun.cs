using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Office.Interop.Word;
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
using Word = Microsoft.Office.Interop.Word;


namespace Mobile_Town_V3
{
    public partial class Stampaj_racun : Form
    {
        string prodavac;
        List<int> sifre;
        List<string> artikli;
        List<int> kolicina;
        List<decimal> cena;
        List<int> knjizeno;
        decimal cena_sum;
        decimal nabavna_sum;
        decimal suma_zarada_knjizeno;

        public Stampaj_racun(string prodavac, List<int> sifre, List<string> artikli, List<int> kolicina, List<decimal> cena, List<int> knjizeno, decimal cena_sum, decimal nabavna_sum, decimal suma_zarada_knjizeno)
        {
            this.prodavac = prodavac;
            this.sifre = sifre;
            this.artikli = artikli;
            this.kolicina = kolicina;
            this.cena = cena;
            this.cena_sum = cena_sum;
            this.knjizeno = knjizeno;
            this.nabavna_sum = nabavna_sum;
            this.suma_zarada_knjizeno = suma_zarada_knjizeno;
            InitializeComponent();
        }

      
        private void Stampaj_racun_Load(object sender, EventArgs e)
        {   
            
            textBox4.Enabled = false;
            textBox2.Enabled = false;
            label9.Text = prodavac;
            label10.Text = DateTime.Now.ToString("dd-MM-yy HH:mm");

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < sifre.Count; i++)
            {
                sb.Append(sifre[i].ToString() + " ");
                sb.Append(artikli[i] + " ");
                sb.Append(kolicina[i].ToString() + "X ");
                sb.Append(cena[i].ToString());
                sb.Append(Environment.NewLine);
            }

            textBox2.Text = sb.ToString();
            label5.Text = cena_sum.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Artikal a = new Artikal();
            decimal uplaceno = decimal.Parse(textBox1.Text);
            decimal racun = decimal.Parse(label5.Text);

            decimal povracaj = uplaceno - racun;
            label8.Text = povracaj.ToString();

            if(povracaj >= 0)
            {
                StringBuilder sb = new StringBuilder();
                StringBuilder sb_knjizeno = new StringBuilder();

                decimal sum = 0;
                for (int i = 0; i < sifre.Count; i++)
                {
                    if (knjizeno[i] == 1)
                    {
                        sum += cena[i] * kolicina[i];
                    }
                }

                for (int i = 0; i < sifre.Count; i++)
                {
                    sb.Append(sifre[i].ToString() + " ");
                    sb.Append(artikli[i] + " ");
                    sb.Append(kolicina[i].ToString() + "X ");
                    sb.Append(cena[i].ToString());
                    sb.Append("\n");

                    if (knjizeno[i] == 1)
                    {
                        sb_knjizeno.Append(sifre[i].ToString() + " ");
                        sb_knjizeno.Append(artikli[i] + " ");
                        sb_knjizeno.Append(kolicina[i].ToString() + "X ");
                        sb_knjizeno.Append(cena[i].ToString());
                        sb_knjizeno.Append("\n");
                    }
                }

                Racun r = new Racun();

                r.prodavac = prodavac;
                r.datum_izdavanja = DateTime.Now;
                r.artikli = sb.ToString();
                r.iznos = cena_sum;
                r.iznos_nabavna = nabavna_sum;

                if (r.unesi_racun())
                {
                    MessageBox.Show("Racun je zaveden!");
                    r.artikli = sb_knjizeno.ToString();
                    r.datum_izdavanja = DateTime.Now;
                    r.iznos = sum;
                    r.iznos_nabavna = suma_zarada_knjizeno;
                    r.unesi_racun_knjizeno();
                    button1.Enabled = false;

                    for(int i = 0; i < knjizeno.Count; i++)
                    {
                        if(knjizeno[i] == 1)
                        {
                            a.update_artikli_knjizeno(sifre[i], kolicina[i]);
                        }
                        else if(knjizeno[i] == 0)
                        {
                            a.update_artikli(sifre[i], kolicina[i]);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Racun nije zaveden!");
                }
            }
            else
            {
                MessageBox.Show("Pogresan unos!");
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {   
            if(!checkBox1.Checked)
            {
                crtaj_fakturu();
            }
            else
            {
                crtaj_fakturu_pravno_lice();
            }
            
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
                    PdfWriter.GetInstance(doc, new FileStream(dir_mb + "\\racun" + date_time + ".pdf", FileMode.Create));
                    doc.Open();
                }
                else
                {
                    Directory.CreateDirectory(dir_mb);
                    PdfWriter.GetInstance(doc, new FileStream(dir_mb + "\\racun" + date_time + ".pdf", FileMode.Create));
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

                for(int i = 0; i < sifre.Count; i++)
                {
                    table.AddCell(sifre[i].ToString() + " " + artikli[i].ToString());
                    table.AddCell(kolicina[i].ToString());
                    table.AddCell(cena[i].ToString());
                    double pdv =  0.2;
                    double cn = double.Parse(cena[i].ToString());
                    double cena_tmp = cn * pdv;
                    table.AddCell(cena_tmp.ToString());
                }

                doc.Add(table);

                iTextSharp.text.Paragraph razmak1 = new iTextSharp.text.Paragraph("\n");
                doc.Add(razmak1);

                PdfPTable table_konacno = new PdfPTable(2);
                table_konacno.AddCell("Ukupno");
                table_konacno.AddCell("PDV(20%) Ukupno");

                double uk_pdv = double.Parse(cena_sum.ToString()) * 0.2;
                table_konacno.AddCell(cena_sum.ToString() + " din");
                table_konacno.AddCell(uk_pdv.ToString() + " din");
                doc.Add(table_konacno);

                iTextSharp.text.Paragraph razmak2 = new iTextSharp.text.Paragraph("\n");
                razmak2.Add("\n");
                razmak2.Add("\n");
                razmak2.Add("\n");
                doc.Add(razmak2);

                PdfPTable table_potpis = new PdfPTable(2);
                table_potpis.AddCell("Racun izdaje");
                table_potpis.AddCell("Racun prima");

                table_potpis.AddCell(" ");
                table_potpis.AddCell(" ");

                doc.Add(table_potpis);

                System.Diagnostics.Process.Start(dir_mb + "\\racun" + date_time + ".pdf");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                doc.Close();
            }

        }

        private void crtaj_fakturu_pravno_lice()
        {

            iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4.Rotate());
            string date_time = (DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second).ToString();
            try
            {
                string dir_mb = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MobileTown_racuni";

                if (Directory.Exists(dir_mb))
                {
                    PdfWriter.GetInstance(doc, new FileStream(dir_mb + "\\racun" + date_time + ".pdf", FileMode.Create));
                    doc.Open();
                }
                else
                {
                    Directory.CreateDirectory(dir_mb);
                    PdfWriter.GetInstance(doc, new FileStream(dir_mb + "\\racun" + date_time + ".pdf", FileMode.Create));
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

                for (int i = 0; i < sifre.Count; i++)
                {
                    table.AddCell(sifre[i].ToString() + " " + artikli[i].ToString());
                    table.AddCell(kolicina[i].ToString());
                    table.AddCell(cena[i].ToString());
                    double pdv = 0.2;
                    double cn = double.Parse(cena[i].ToString());
                    double cena_tmp = cn * pdv;
                    table.AddCell(cena_tmp.ToString());
                }

                doc.Add(table);

                iTextSharp.text.Paragraph razmak1 = new iTextSharp.text.Paragraph("\n");
                doc.Add(razmak1);

                PdfPTable table_konacno = new PdfPTable(2);
                table_konacno.AddCell("Ukupno");
                table_konacno.AddCell("PDV(20%) Ukupno");

                double uk_pdv = double.Parse(cena_sum.ToString()) * 0.2;
                table_konacno.AddCell(cena_sum.ToString() + " din");
                table_konacno.AddCell(uk_pdv.ToString() + " din");
                doc.Add(table_konacno);

                iTextSharp.text.Paragraph razmak2 = new iTextSharp.text.Paragraph("\n");
                razmak2.Add("\n");
                razmak2.Add("\n");
                razmak2.Add("\n");
                doc.Add(razmak2);

                PdfPTable table_potpis = new PdfPTable(2);
                table_potpis.AddCell("Racun izdaje");
                table_potpis.AddCell("Racun prima");

                table_potpis.AddCell(" ");
                table_potpis.AddCell(textBox3.Text + "\nBroj racuna: " +textBox4.Text);

                doc.Add(table_potpis);

                System.Diagnostics.Process.Start(dir_mb + "\\racun" + date_time + ".pdf");
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {            
                textBox4.Enabled = true;
            }
            else
            {              
                textBox4.Enabled = false;

                textBox4.Clear();
            }
        }
    }
}
