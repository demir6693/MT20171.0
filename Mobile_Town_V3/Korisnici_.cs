using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_Town_V3
{
    class Korisnici_
    {
        public string connString = "Data Source=mobiletownserver.database.windows.net;Initial Catalog=Mobile_Town;Persist Security Info=True;User ID=demir6693;Password=Agovic6693";
        public int id_korisnika { get; set; }
        public string ime_korisnika { get; set; }
        public string prezime_korisnika { get; set; }
        public string korisnicko_ime { get; set; }
        public string sifra_korisnika { get; set; }
        public int nivo { get; set; }


        public bool Unesi_korisnika()
        {
            bool unos;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO Korisnici(Ime, Prezime, Korisnicko_ime, Sifra, Nivo) VALUES (@Ime, @Prezime, @Korisnicko_ime, @Sifra, @Nivo)";
                    cmd.Parameters.AddWithValue("@Ime", ime_korisnika);
                    cmd.Parameters.AddWithValue("@Prezime", prezime_korisnika);
                    cmd.Parameters.AddWithValue("@Korisnicko_ime", korisnicko_ime);
                    cmd.Parameters.AddWithValue("@Sifra", sifra_korisnika);
                    cmd.Parameters.AddWithValue("@Nivo", nivo);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        unos = true;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                        unos = false;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }

            return unos;
        }

        public bool login(string user_name, string password)
        {
            bool log = false;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Korisnici WHERE Korisnicko_ime = @Korisnicko_ime AND Sifra = @Sifra", conn);
                    cmd.Parameters.AddWithValue("@Korisnicko_ime", user_name);
                    cmd.Parameters.AddWithValue("@Sifra", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            log = true;
                            break;
                        }
                    }

                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    log = false;
                }
                finally
                {
                    conn.Close();
                }
            }


            return log;
        }

        public bool brisi_korisnika(int sifra_tmp)
        {
            bool del;

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Korisnici WHERE id_korisnika=" + sifra_tmp + "", conn))
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

        public List<string> daj_korisnike()
        {
            List<string> ls = new List<string>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT korisnicko_ime FROM Korisnici", conn);
                  
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Korisnici_ k = new Korisnici_();

                            k.korisnicko_ime = reader["korisnicko_ime"].ToString();

                            ls.Add(k.korisnicko_ime);
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
    }
}
