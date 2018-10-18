using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_Town_V3
{
    class Artikal
    {
        public string connString = "Data Source=mobiletownserver.database.windows.net;Initial Catalog=Mobile_Town;Persist Security Info=True;User ID=demir6693;Password=Agovic6693";
        public int sifra { get; set; }
        public string grupa { get; set; }
        public string artikal { get; set; }
        public int kolicina { get; set; }
        public decimal nabavna_cena { get; set; }
        public decimal prodajna_cena { get; set; }      
        public int knjizeno { get; set; }

        public static List<Artikal> get_list = new List<Artikal>();


        public List<Artikal> Pretraga(string search, string grupa_tmp, string query)
        {
            List<Artikal> ls_artikal = new List<Artikal>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                   
                    SqlCommand cmd = new SqlCommand("SELECT * FROM " + query + " WHERE Grupa=@Grupa AND Artikal LIKE @search", conn);
                    cmd.Parameters.AddWithValue("@Grupa", grupa_tmp);
                    cmd.Parameters.AddWithValue("@search", search + "%");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Artikal a = new Artikal();
                            a.sifra = int.Parse(reader["Sifra"].ToString());
                            a.grupa = reader["Grupa"].ToString();
                            a.artikal = reader["Artikal"].ToString();
                            a.kolicina = int.Parse(reader["Kolicina"].ToString());
                            a.nabavna_cena = decimal.Parse(reader["Nabavna_cena"].ToString());
                            a.prodajna_cena = decimal.Parse(reader["Prodajna_cena"].ToString());

                            if (query.Equals("Artikli"))
                            {
                                a.knjizeno = 0;
                            }
                            else if (query.Equals("Artikli_knjizeno"))
                            {
                                a.knjizeno = 1;
                            }
                            
                            ls_artikal.Add(a);
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

            return ls_artikal;
        }
        public bool Unesi_artikal(string query)
        {
            bool unos;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO " +query + "(Sifra, Grupa, Artikal, Kolicina, Nabavna_cena, Prodajna_cena) VALUES (@Sifra, @Grupa, @Artikal, @Kolicina, @Nabavna_cena, @Prodajna_cena)";
                    cmd.Parameters.AddWithValue("@Sifra", sifra);
                    cmd.Parameters.AddWithValue("@Grupa", grupa);
                    cmd.Parameters.AddWithValue("@Artikal", artikal);
                    cmd.Parameters.AddWithValue("@Kolicina", kolicina);
                    cmd.Parameters.AddWithValue("@Nabavna_cena", nabavna_cena);
                    cmd.Parameters.AddWithValue("@Prodajna_cena", prodajna_cena);
                    

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

        public bool Unesi_artikal_mob_hover(string query)
        {
            bool unos;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO " +query+ "(Sifra, Grupa, Artikal, Kolicina, Nabavna_cena, Prodajna_cena) VALUES (@Sifra, @Grupa, @Artikal, @Kolicina, @Nabavna_cena, @Prodajna_cena)";
                    cmd.Parameters.AddWithValue("@Sifra", sifra);
                    cmd.Parameters.AddWithValue("@Grupa", grupa);
                    cmd.Parameters.AddWithValue("@Artikal", artikal);
                    cmd.Parameters.AddWithValue("@Kolicina", kolicina);
                    cmd.Parameters.AddWithValue("@Nabavna_cena", nabavna_cena);
                    cmd.Parameters.AddWithValue("@Prodajna_cena", prodajna_cena);


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

        public List<Artikal> get_artikli(string grupa_tmp, string query)
        {
            List<Artikal> ls_a = new List<Artikal>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM " +query + " WHERE Grupa=@Grupa", conn);
                    cmd.Parameters.AddWithValue("@Grupa", grupa_tmp);
          

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Artikal a = new Artikal();
                            a.sifra = int.Parse(reader["Sifra"].ToString());
                            a.grupa = reader["Grupa"].ToString();
                            a.artikal = reader["Artikal"].ToString();
                            a.kolicina = int.Parse(reader["Kolicina"].ToString());
                            a.nabavna_cena = decimal.Parse(reader["Nabavna_cena"].ToString());
                            a.prodajna_cena = decimal.Parse(reader["Prodajna_cena"].ToString());

                            if (query.Equals("Artikli"))
                            {
                                a.knjizeno = 0;
                            }
                            else if(query.Equals("Artikli_knjizeno"))
                            {
                                a.knjizeno = 1;
                            }

                            ls_a.Add(a);
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

            return ls_a;
        }

        public List<Artikal> get_hover_mob(string grupa_tmp, string query)
        {
            List<Artikal> ls_a = new List<Artikal>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM " + query + " WHERE Grupa=@Grupa", conn);
                    cmd.Parameters.AddWithValue("@Grupa", grupa_tmp);


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Artikal a = new Artikal();
                            a.sifra = int.Parse(reader["Sifra"].ToString());
                            a.grupa = reader["Grupa"].ToString();
                            a.artikal = reader["Artikal"].ToString();
                            a.kolicina = int.Parse(reader["Kolicina"].ToString());
                            a.nabavna_cena = decimal.Parse(reader["Nabavna_cena"].ToString());
                            a.prodajna_cena = decimal.Parse(reader["Prodajna_cena"].ToString());

                            ls_a.Add(a);
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

            return ls_a;
        }

        public bool brisi_artikal(int sifra_tmp, string query)
        {
            bool del;

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM " +query+ " WHERE Sifra=" + sifra_tmp + "", conn))
                    {
                        cmd.ExecuteNonQuery();
                        del = true;
                    }
                    conn.Close();
                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
                del = false;
            }

            return del;
        }

        public List<Artikal> daj_artikal(int sifra_pom, string query)
        {
            List<Artikal> ls_a = new List<Artikal>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM " +query+ " WHERE Sifra=@Sifra", conn);
                    cmd.Parameters.AddWithValue("@Sifra", sifra_pom);


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Artikal a = new Artikal();
                            a.sifra = int.Parse(reader["Sifra"].ToString());
                            a.grupa = reader["Grupa"].ToString();
                            a.artikal = reader["Artikal"].ToString();
                            a.kolicina = int.Parse(reader["Kolicina"].ToString());
                            a.nabavna_cena = decimal.Parse(reader["Nabavna_cena"].ToString());
                            a.prodajna_cena = decimal.Parse(reader["Prodajna_cena"].ToString());
                           

                            ls_a.Add(a);
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

            return ls_a;
        }

        public bool izmeni_artkal(int sifra_pom, string query)
        {
            bool edit;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "UPDATE " +query+ " SET Sifra = @Sifra, Grupa = @Grupa, Artikal = @Artikal, Kolicina = @Kolicina, Nabavna_cena = @Nabavna_cena, Prodajna_cena = @Prodajna_cena WHERE Sifra = @Sifra";
                    cmd.Parameters.AddWithValue("@Sifra", sifra);
                    cmd.Parameters.AddWithValue("@Grupa", grupa);
                    cmd.Parameters.AddWithValue("@Artikal", artikal);
                    cmd.Parameters.AddWithValue("@Kolicina", kolicina);
                    cmd.Parameters.AddWithValue("@Nabavna_cena", nabavna_cena);
                    cmd.Parameters.AddWithValue("@Prodajna_cena", prodajna_cena);
                    

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

        public void set_ls(Artikal a)
        {
            get_list.Add(a);
        }

        public bool proveri_stanje(string query, int trazeno, int sifra_tmp)
        {
            bool stanje = false;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT kolicina FROM " + query + " WHERE sifra=" + sifra_tmp + ";", conn);
   
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                           if(trazeno > int.Parse(reader["kolicina"].ToString()))
                            {
                                stanje = false;
                            }
                           else
                            {
                                stanje = true;
                            }
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

            return stanje;
        }

        public void update_artikli(int sifra_tmp, int kolicina_tmp)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT kolicina FROM Artikli WHERE sifra=" + sifra_tmp + ";", conn);
                    int nova_kolicina = 0;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            nova_kolicina = int.Parse(reader["kolicina"].ToString()) - kolicina_tmp;
                        }
                    }


                    using (SqlCommand cmd1 = new SqlCommand())
                    {
                        cmd1.Connection = conn;
                        cmd1.CommandType = System.Data.CommandType.Text;
                        cmd1.CommandText = "UPDATE Artikli SET Kolicina = @Kolicina WHERE Sifra =" + sifra_tmp + "";

                        cmd1.Parameters.AddWithValue("@Kolicina", nova_kolicina);

                        try
                        {
                            cmd1.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine(ex.Message);
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
        }

        public void update_artikli_knjizeno(int sifra_tmp, int kolicina_tmp)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT kolicina FROM Artikli_knjizeno WHERE sifra=" + sifra_tmp + ";", conn);
                    int nova_kolicina = 0;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            nova_kolicina = int.Parse(reader["kolicina"].ToString()) - kolicina_tmp;
                        }
                    }


                    using (SqlCommand cmd1 = new SqlCommand())
                    {
                        cmd1.Connection = conn;
                        cmd1.CommandType = System.Data.CommandType.Text;
                        cmd1.CommandText = "UPDATE Artikli_knjizeno SET Kolicina = @Kolicina WHERE Sifra =" + sifra_tmp + "";

                        cmd1.Parameters.AddWithValue("@Kolicina", nova_kolicina);

                        try
                        {
                            cmd1.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine(ex.Message);
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
        }

        public void update_artikli_uvecaj(string query, int sifra_tmp, int kolicina_tmp)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT kolicina FROM " + query + " WHERE sifra=" + sifra_tmp + ";", conn);
                    int nova_kolicina = 0;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            nova_kolicina = int.Parse(reader["kolicina"].ToString()) + kolicina_tmp;
                        }
                    }


                    using (SqlCommand cmd1 = new SqlCommand())
                    {
                        cmd1.Connection = conn;
                        cmd1.CommandType = System.Data.CommandType.Text;
                        cmd1.CommandText = "UPDATE " + query + " SET Kolicina = @Kolicina WHERE Sifra =" + sifra_tmp + "";

                        cmd1.Parameters.AddWithValue("@Kolicina", nova_kolicina);

                        try
                        {
                            cmd1.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine(ex.Message);
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
        }

        public void update_artikli_mob_hover(string query, int sifra_tmp)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT kolicina FROM " + query + " WHERE sifra=" + sifra_tmp + ";", conn);
                    int nova_kolicina = 0;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            nova_kolicina = int.Parse(reader["kolicina"].ToString());
                        }
                    }

                    nova_kolicina--;
                    using (SqlCommand cmd1 = new SqlCommand())
                    {
                        cmd1.Connection = conn;
                        cmd1.CommandType = System.Data.CommandType.Text;
                        cmd1.CommandText = "UPDATE " + query + " SET Kolicina = @Kolicina WHERE Sifra =" + sifra_tmp + "";

                        cmd1.Parameters.AddWithValue("@Kolicina", nova_kolicina);

                        try
                        {
                            cmd1.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine(ex.Message);
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
        }

        public bool brisi_artikal_mob_hover(int sifra_tmp, string query)
        {
            bool del;

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM " + query + " WHERE Sifra=" + sifra_tmp + "", conn))
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
