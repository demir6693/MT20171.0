using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_Town_V3
{
    class Rezervacija_
    {
        public string connString = "Data Source=mobiletownserver.database.windows.net;Initial Catalog=Mobile_Town;Persist Security Info=True;User ID=demir6693;Password=Agovic6693";
        public int id_rezervacija { get; set; }
        public int sifra_artikla { get; set; }
        public string ime_prezime { get; set; }
        public string broj_telefona { get; set; }
        public string artikal { get; set; }
        public int kolicina { get; set; }
        public decimal cena { get; set; }
        public int knjizeno { get; set; }


        public bool unesi_rezervaciju()
        {
            bool rez;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO Rezervacija(sifra_artikla, knjizeno, ime_prezime, broj_telefona, artikal, cena, kolicina) VALUES (@sifra_artikla, @knjizeno, @ime_prezime, @broj_telefona, @artikal, @cena, @kolicina)";
                    cmd.Parameters.AddWithValue("@sifra_artikla", sifra_artikla);
                    cmd.Parameters.AddWithValue("@knjizeno", knjizeno);
                    cmd.Parameters.AddWithValue("@ime_prezime", ime_prezime);
                    cmd.Parameters.AddWithValue("@broj_telefona", broj_telefona);
                    cmd.Parameters.AddWithValue("@artikal", artikal);
                    cmd.Parameters.AddWithValue("@cena", cena);
                    cmd.Parameters.AddWithValue("@kolicina", kolicina);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        rez = true;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                        rez = false;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }   
            }

            return rez;

        }

        public List<Rezervacija_> get_rezervacija()
        {
            List<Rezervacija_> ls = new List<Rezervacija_>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Rezervacija", conn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Rezervacija_ r = new Rezervacija_();

                            r.id_rezervacija = int.Parse(reader["id_rezervacija"].ToString());
                            r.sifra_artikla = int.Parse(reader["sifra_artikla"].ToString());
                            r.knjizeno = int.Parse(reader["knjizeno"].ToString());
                            r.ime_prezime = reader["ime_prezime"].ToString();
                            r.broj_telefona = reader["broj_telefona"].ToString();
                            r.artikal = reader["artikal"].ToString();
                            r.cena = decimal.Parse(reader["cena"].ToString());
                            r.kolicina = int.Parse(reader["kolicina"].ToString());

                            ls.Add(r);
                        }
                    }

                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);

                }
                finally
                {
                    conn.Close();
                }
            }

            return ls;
        }

        public bool del_rezervacija(int sifra_tmp)
        {
            bool del;

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Rezervacija WHERE id_rezervacija=" + sifra_tmp + "", conn))
                    {
                        cmd.ExecuteNonQuery();
                        del = true;
                    }
                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                del = false;
            }

            return del;
        }
    }
}
