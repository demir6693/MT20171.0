using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_Town_V3
{
    class Servis_
    {
        public string connString = "Data Source=mobiletownserver.database.windows.net;Initial Catalog=Mobile_Town;Persist Security Info=True;User ID=demir6693;Password=Agovic6693";
        public int id_servisa { get; set; }
        public string serviser { get; set; }
        public DateTime DateTime { get; set; }
        public string ime_prezime { get; set; }
        public string broj_telefona { get; set; }
        public string opis_kvara { get; set; }
        public decimal cena_popravke { get; set; }
        public decimal cena_naplate { get; set; }


        public bool unesi_servis()
        {
            bool s;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO Servis(serviser, datum_preuzimanja, ime_prezime, broj_telefona, opis_kvara, cena_popravke) VALUES (@serviser, @datum_preuzimanja, @ime_prezime, @broj_telefona, @opis_kvara, @cena_popravke)";
                    cmd.Parameters.AddWithValue("@serviser", serviser);
                    cmd.Parameters.AddWithValue("@datum_preuzimanja", DateTime);
                    cmd.Parameters.AddWithValue("@ime_prezime", ime_prezime);
                    cmd.Parameters.AddWithValue("@broj_telefona", broj_telefona);
                    cmd.Parameters.AddWithValue("@opis_kvara", opis_kvara);
                    cmd.Parameters.AddWithValue("@cena_popravke", cena_popravke);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        s = true;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                        s = false;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }

            return s;
        }

        public List<Servis_> get_seris_ls()
        {
            List<Servis_> ls = new List<Servis_>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM  Servis", conn);
                    
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Servis_ s = new Servis_();

                            s.id_servisa = int.Parse(reader["id_servisa"].ToString());
                            s.serviser = reader["serviser"].ToString();
                            s.DateTime = DateTime.Parse(reader["datum_preuzimanja"].ToString());
                            s.cena_popravke = decimal.Parse(reader["cena_popravke"].ToString());
                            s.ime_prezime = reader["ime_prezime"].ToString();
                            s.broj_telefona = reader["broj_telefona"].ToString();
                            s.opis_kvara = reader["opis_kvara"].ToString();

                            ls.Add(s);
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

        public bool izbrisi_servis(int s)
        {
            bool del;

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Servis WHERE id_servisa=" + s + "", conn))
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

        public bool update_serivs(int sifra_pom)
        {
            bool edit;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "UPDATE Servis SET serviser = @serviser, cena_popravke = @cena_popravke WHERE id_servisa = @id_servisa";
                    cmd.Parameters.AddWithValue("@id_servisa", sifra_pom);
                    cmd.Parameters.AddWithValue("@serviser", serviser);
                    cmd.Parameters.AddWithValue("@cena_popravke", cena_popravke);

                    
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        edit = true;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                        edit = false;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }

            return edit;
        }

    }
}
