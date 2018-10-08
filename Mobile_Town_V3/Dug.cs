using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_Town_V3
{
    class Dug
    {
        public string connString = "Data Source=mobiletownserver.database.windows.net;Initial Catalog=Mobile_Town;Persist Security Info=True;User ID=demir6693;Password=Agovic6693";
        public int id_duga { get; set; }
        public string ime_prezime { get; set; }
        public string broj_telefona { get; set; }
        public DateTime datum_izdavanja { get; set; }
        public DateTime datum_vracanja { get; set; }
        public int sifra_artikla { get; set; }
        public string artikal { get; set; }
        public decimal cena { get; set; }
        public int knjizeno { get; set; }

        public bool unesi_dug()
        {
            bool dug;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO Dug(ime_prezime, broj_telefona, datum_izdavanja, datum_vracanja, sifra_artikla, artikal, cena, knjizeno) VALUES (@ime_prezime, @broj_telefona, @datum_izdavanja, @datum_vracanja, @sifra_artikla, @artikal, @cena, @knjizeno)";
                    cmd.Parameters.AddWithValue("@ime_prezime", ime_prezime);
                    cmd.Parameters.AddWithValue("@broj_telefona", broj_telefona);
                    cmd.Parameters.AddWithValue("@datum_izdavanja", datum_izdavanja);
                    cmd.Parameters.AddWithValue("@datum_vracanja", datum_vracanja);
                    cmd.Parameters.AddWithValue("@sifra_artikla", sifra_artikla);
                    cmd.Parameters.AddWithValue("@artikal", artikal);
                    cmd.Parameters.AddWithValue("@cena", cena);
                    cmd.Parameters.AddWithValue("@knjizeno", knjizeno);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        dug = true;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                        dug = false;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }

            return dug;
        }

        public List<Dug> get_dug()
        {
            List<Dug> ls = new List<Dug>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Dug", conn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Dug d = new Dug();

                            d.id_duga = int.Parse(reader["id_duga"].ToString());
                            d.ime_prezime = reader["ime_prezime"].ToString();
                            d.broj_telefona = reader["broj_telefona"].ToString();
                            d.datum_izdavanja = DateTime.Parse(reader["datum_izdavanja"].ToString());
                            d.datum_vracanja = DateTime.Parse(reader["datum_vracanja"].ToString());
                            d.sifra_artikla = int.Parse(reader["sifra_artikla"].ToString());
                            d.artikal = reader["artikal"].ToString();
                            d.cena = decimal.Parse(reader["cena"].ToString());
                            d.knjizeno = int.Parse(reader["knjizeno"].ToString());

                            ls.Add(d);
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

        public bool del_dug(int id_tmp)
        {
            bool del;

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Dug WHERE id_duga=" + id_tmp + "", conn))
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

        public bool izmeni_dug(int sifra_pom)
        {
            bool edit;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "UPDATE Dug SET ime_prezime = @ime_prezime, broj_telefona = @broj_telefona, datum_izdavanja = @datum_izdavanja, datum_vracanja = @datum_vracanja, cena = @cena WHERE id_duga =" + sifra_pom+ "";
                    
                    cmd.Parameters.AddWithValue("@ime_prezime", ime_prezime);
                    cmd.Parameters.AddWithValue("@broj_telefona", broj_telefona);
                    cmd.Parameters.AddWithValue("@datum_izdavanja", datum_izdavanja);
                    cmd.Parameters.AddWithValue("@datum_vracanja", datum_vracanja);
                    cmd.Parameters.AddWithValue("@cena", cena);

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

        public List<Dug> get_jedan_dug(int sifra_tmp)
        {
            List<Dug> ls = new List<Dug>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Dug WHERE id_duga=" +sifra_tmp+ ";", conn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Dug d = new Dug();

                            d.id_duga = int.Parse(reader["id_duga"].ToString());
                            d.ime_prezime = reader["ime_prezime"].ToString();
                            d.broj_telefona = reader["broj_telefona"].ToString();
                            d.datum_izdavanja = DateTime.Parse(reader["datum_izdavanja"].ToString());
                            d.datum_vracanja = DateTime.Parse(reader["datum_vracanja"].ToString());
                            d.sifra_artikla = int.Parse(reader["sifra_artikla"].ToString());
                            d.artikal = reader["artikal"].ToString();
                            d.cena = decimal.Parse(reader["cena"].ToString());
                            d.knjizeno = int.Parse(reader["knjizeno"].ToString());

                            ls.Add(d);
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
