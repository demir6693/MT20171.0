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

        private void button1_Click(object sender, EventArgs e)
        {
            Stampaj_Listu();
        }

        private void Stampaj_Listu()
        {
            iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4.Rotate());
            string date_time = (DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second).ToString();
            try
            {
                string dir_mb = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MobileTown_narudzbine";

                if (Directory.Exists(dir_mb))
                {
                    PdfWriter.GetInstance(doc, new FileStream(dir_mb + "\\narudzbina" + date_time + ".pdf", FileMode.Create));
                    doc.Open();
                }
                else
                {
                    Directory.CreateDirectory(dir_mb);
                    PdfWriter.GetInstance(doc, new FileStream(dir_mb + "\\narudzbina" + date_time + ".pdf", FileMode.Create));
                    doc.Open();
                }

                iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph("Mobile Town");
                title.Alignment = Element.ALIGN_CENTER;
                title.Font.Size = 32;
                doc.Add(title);

                iTextSharp.text.Paragraph podaci;
                podaci = new iTextSharp.text.Paragraph("\n");
                podaci.Add("           Narudzbine");
                podaci.Add("\n");
                podaci.Add("           Datum:" + DateTime.Now.ToString("       dd-MM-yyyy HH-mm"));
                podaci.Add("\n");
     
                podaci.Font.Size = 14;
                doc.Add(podaci);

                iTextSharp.text.Paragraph razmak = new iTextSharp.text.Paragraph("\n");
                doc.Add(razmak);

                PdfPTable table = new PdfPTable(4);
                table.AddCell("Id narudzbine");
                table.AddCell("Ime i prezime");
                table.AddCell("Broj telefona");
                table.AddCell("Opis");

                //for (int i = 0; i < sifre.Count; i++)
                //{
                //    table.AddCell(sifre[i].ToString() + " " + artikli[i].ToString());
                //    table.AddCell(kolicina[i].ToString());
                //    table.AddCell(cena[i].ToString());
                //    double pdv = 0.2;
                //    double cn = double.Parse(cena[i].ToString());
                //    double cena_tmp = cn * pdv;
                //    table.AddCell(cena_tmp.ToString());
                //}

                foreach(DataGridViewRow datarow in dataGridView1.Rows)
                {
                    table.AddCell(datarow.Cells[0].Value.ToString());
                    table.AddCell(datarow.Cells[1].Value.ToString());
                    table.AddCell(datarow.Cells[2].Value.ToString());
                    table.AddCell(datarow.Cells[3].Value.ToString());
                }

                doc.Add(table);

                System.Diagnostics.Process.Start(dir_mb + "\\narudzbina" + date_time + ".pdf");
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
