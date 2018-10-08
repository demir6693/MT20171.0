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
    public partial class Naplati_servis : Form
    {
        int sifra;
        string serviser;
        DateTime dt_ost;
        decimal cena_popravke;
        string ime_prezime;
        string opis_kvara;
        string br_tel;

        public Naplati_servis(int sifra, string serviser, DateTime dt_ost, decimal cena_popravke, string ime_prezime, string br_tel, string opis_kvara)
        {
            this.sifra = sifra;
            this.serviser = serviser;
            this.dt_ost = dt_ost;
            this.cena_popravke = cena_popravke;
            this.br_tel = br_tel;
            this.opis_kvara = opis_kvara;
            this.ime_prezime = ime_prezime;
            InitializeComponent();
        }

        private void Naplati_servis_Load(object sender, EventArgs e)
        {
            label1.Text = sifra.ToString();
            label2.Text = serviser;
            label3.Text = dt_ost.ToString("dd-MM-yy");
            label4.Text = DateTime.Now.ToString("dd-MM-yy HH:mm");
            label5.Text = cena_popravke.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Racun r = new Racun();

            try
            {
                r.prodavac = "servis";
                r.datum_izdavanja = DateTime.Now;
                r.artikli = ime_prezime;
                r.iznos = decimal.Parse(textBox1.Text);
                r.iznos_nabavna = cena_popravke;
                if(r.unesi_racun())
                {
                    MessageBox.Show("Servis naplacen");
                    Servis_ s = new Servis_();
                    s.izbrisi_servis(sifra);
                    this.Close();
                    stampaj_racun();
                }
                else
                {
                    MessageBox.Show("Servis nije naplacen");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void stampaj_racun()
        {
            
            iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4.Rotate());
            string date_time = (DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second).ToString();
            try
            {
                string dir_mb = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MobileTown_racuni";

                if (Directory.Exists(dir_mb))
                {
                    PdfWriter.GetInstance(doc, new FileStream(dir_mb + "\\servis" + date_time + ".pdf", FileMode.Create));
                    doc.Open();
                }
                else
                {
                    Directory.CreateDirectory(dir_mb);
                    PdfWriter.GetInstance(doc, new FileStream(dir_mb + "\\servis" + date_time + ".pdf", FileMode.Create));
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
                podaci.Add("           " + "Servis");
                podaci.Font.Size = 14;
                doc.Add(podaci);

                iTextSharp.text.Paragraph razmak = new iTextSharp.text.Paragraph("\n");
                doc.Add(razmak);

                PdfPTable table = new PdfPTable(4);
                table.AddCell("id Servisa");
                table.AddCell("Opis kvara");
                table.AddCell("Datum izdavanja");
                table.AddCell("Iznos");

                table.AddCell(sifra.ToString());
                table.AddCell(opis_kvara);
                table.AddCell(DateTime.Now.ToString("dd-MM-yyyy HH:mm"));
                table.AddCell(textBox1.Text);

                doc.Add(table);

                iTextSharp.text.Paragraph razmak1 = new iTextSharp.text.Paragraph("\n");
                doc.Add(razmak1);

                PdfPTable table_konacno = new PdfPTable(2);
                table_konacno.AddCell("Ukupno");
                table_konacno.AddCell("PDV(20%) Ukupno");

                table_konacno.AddCell(textBox1.Text);
                table_konacno.AddCell((double.Parse(textBox1.Text) * 0.2).ToString());
                doc.Add(table_konacno);

                iTextSharp.text.Paragraph razmak2 = new iTextSharp.text.Paragraph("\n");
                doc.Add(razmak2);

                PdfPTable potpis_pecat = new PdfPTable(2);
                potpis_pecat.AddCell("Racun izdaje");
                potpis_pecat.AddCell("Racun prima");

                potpis_pecat.AddCell(ime_prezime);
                potpis_pecat.AddCell("");
                doc.Add(potpis_pecat);

                System.Diagnostics.Process.Start(dir_mb + "\\servis" + date_time + ".pdf");
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
