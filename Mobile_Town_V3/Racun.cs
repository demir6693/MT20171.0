using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_Town_V3
{
    class Racun
    {
        public string connString = "Data Source=mobiletown.database.windows.net;Initial Catalog=Mobile_Town;User ID=demir;Password=Agovic6693;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public int id_racuna { get; set; }
        public string prodavac { get; set; }
        public DateTime datum_izdavanja { get; set; }
        public string artikli { get; set; }
        public decimal iznos { get; set; }
        public decimal iznos_nabavna { get; set; }
        public int knjizeno { get; set; }

        public bool unesi_racun()
        {
            bool racun;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO Racuni(prodavac, datum_izdavanja, artikli, iznos, iznos_nabavna) VALUES (@prodavac, @datum_izdavanja, @artikli, @iznos, @iznos_nabavna)";
               
                    cmd.Parameters.AddWithValue("@prodavac", prodavac);
                    cmd.Parameters.AddWithValue("@datum_izdavanja", datum_izdavanja);
                    cmd.Parameters.AddWithValue("@artikli", artikli);
                    cmd.Parameters.AddWithValue("@iznos", iznos);
                    cmd.Parameters.AddWithValue("@iznos_nabavna", iznos_nabavna);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        racun = true;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                        racun = false;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }

            return racun;
        }

        public bool unesi_racun_knjizeno()
        {
            bool racun;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO Racuni_knjizeno(artikli, datum_izdavanja, iznos, iznos_nabavna) VALUES (@artikli, @datum_izdavanja, @iznos, @iznos_nabavna)";

                    cmd.Parameters.AddWithValue("@artikli", artikli);
                    cmd.Parameters.AddWithValue("@datum_izdavanja", datum_izdavanja); 
                    cmd.Parameters.AddWithValue("@iznos", iznos);
                    cmd.Parameters.AddWithValue("@iznos_nabavna", iznos_nabavna);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        racun = true;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                        racun = false;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }

            return racun;
        }

        public bool del_racun(int id_tmp)
        {
            bool del;

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Racuni WHERE id_racuna=" + id_tmp + "", conn))
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

        public List<Racun> daj_racun(int id_racuna)
        {
            List<Racun> ls_a = new List<Racun>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Racuni WHERE id_racuna=@id_racuna", conn);
                    cmd.Parameters.AddWithValue("@id_racuna", id_racuna);


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Racun r = new Racun();

                            r.id_racuna = int.Parse(reader["id_racuna"].ToString());
                            r.prodavac = reader["prodavac"].ToString();
                            r.datum_izdavanja = DateTime.Parse(reader["datum_izdavanja"].ToString());
                            r.artikli = reader["artikli"].ToString();
                            r.iznos = decimal.Parse(reader["iznos"].ToString());
                            r.iznos_nabavna = decimal.Parse(reader["iznos_nabavna"].ToString());

                            ls_a.Add(r);
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

        public List<Racun> daj_racun_prodavac_dnevni(string prodavac)
        {
            List<Racun> ls_a = new List<Racun>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd;
                    if (prodavac.Equals("Svi"))
                    {
                        cmd = new SqlCommand("SELECT * FROM Racuni", conn);
                    }
                    else
                    {
                        cmd = new SqlCommand("SELECT * FROM Racuni WHERE prodavac = @prodavac", conn);
                        cmd.Parameters.AddWithValue("@prodavac", prodavac);
                    }

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime racun = new DateTime();
                            racun = DateTime.Parse(reader["datum_izdavanja"].ToString());
                            int rr = (int)racun.Day;
                            int dr = (int)DateTime.Now.Day;

                            int mrr = (int)racun.Month;
                            int dmr = (int)DateTime.Now.Month;

                            if(rr == dr && mrr == dmr)
                            {   
                                Racun r = new Racun();

                                r.id_racuna = int.Parse(reader["id_racuna"].ToString());
                                r.prodavac = reader["prodavac"].ToString();
                                r.datum_izdavanja = DateTime.Parse(reader["datum_izdavanja"].ToString());
                                r.artikli = reader["artikli"].ToString();
                                r.iznos = decimal.Parse(reader["iznos"].ToString());
                                r.iznos_nabavna = decimal.Parse(reader["iznos_nabavna"].ToString());

                                ls_a.Add(r);
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

            return ls_a;
        }

        public List<Racun> daj_racun_prodavac_mesecni(string prodavac)
        {
            List<Racun> ls_a = new List<Racun>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd;

                    if (prodavac.Equals("Svi"))
                    {
                        cmd = new SqlCommand("SELECT * FROM Racuni", conn);
                    }
                    else
                    {
                        cmd = new SqlCommand("SELECT * FROM Racuni WHERE prodavac = @prodavac", conn);
                        cmd.Parameters.AddWithValue("@prodavac", prodavac);
                    }
                   
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime racun = new DateTime();
                            racun = DateTime.Parse(reader["datum_izdavanja"].ToString());
                            

                            int mrr = (int)racun.Month;
                            int dmr = (int)DateTime.Now.Month;

                            int yr = (int)racun.Year;
                            int dyr = (int)DateTime.Now.Year;
                            if (yr == dyr && mrr == dmr)
                            {
                                Racun r = new Racun();

                                r.id_racuna = int.Parse(reader["id_racuna"].ToString());
                                r.prodavac = reader["prodavac"].ToString();
                                r.datum_izdavanja = DateTime.Parse(reader["datum_izdavanja"].ToString());
                                r.artikli = reader["artikli"].ToString();
                                r.iznos = decimal.Parse(reader["iznos"].ToString());
                                r.iznos_nabavna = decimal.Parse(reader["iznos_nabavna"].ToString());

                                ls_a.Add(r);
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

            return ls_a;
        }

        public List<Racun> daj_racun_prodavac_godisnji(string prodavac)
        {
            List<Racun> ls_a = new List<Racun>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd;
                    if (prodavac.Equals("Svi"))
                    {
                        cmd = new SqlCommand("SELECT * FROM Racuni", conn);
                    }
                    else
                    {
                        cmd = new SqlCommand("SELECT * FROM Racuni WHERE prodavac = @prodavac", conn);
                        cmd.Parameters.AddWithValue("@prodavac", prodavac);
                    }

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime racun = new DateTime();
                            racun = DateTime.Parse(reader["datum_izdavanja"].ToString());

                            int yr = (int)racun.Year;
                            int dyr = (int)DateTime.Now.Year;
                            if (yr == dyr)
                            {
                                Racun r = new Racun();

                                r.id_racuna = int.Parse(reader["id_racuna"].ToString());
                                r.prodavac = reader["prodavac"].ToString();
                                r.datum_izdavanja = DateTime.Parse(reader["datum_izdavanja"].ToString());
                                r.artikli = reader["artikli"].ToString();
                                r.iznos = decimal.Parse(reader["iznos"].ToString());
                                r.iznos_nabavna = decimal.Parse(reader["iznos_nabavna"].ToString());

                                ls_a.Add(r);
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

            return ls_a;
        }

        public List<Racun> daj_racun_prodavac_dnevni_knjizeno()
        {
            List<Racun> ls_a = new List<Racun>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Racuni_knjizeno", conn);
                   
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime racun = new DateTime();
                            racun = DateTime.Parse(reader["datum_izdavanja"].ToString());
                            int rr = (int)racun.Day;
                            int dr = (int)DateTime.Now.Day;

                            int mrr = (int)racun.Month;
                            int dmr = (int)DateTime.Now.Month;

                            if (rr == dr && mrr == dmr)
                            {
                                Racun r = new Racun();

                                r.id_racuna = int.Parse(reader["id_racuna"].ToString());
                                r.prodavac = "knjizeno";
                                r.datum_izdavanja = DateTime.Parse(reader["datum_izdavanja"].ToString());
                                r.artikli = reader["artikli"].ToString();
                                r.iznos = decimal.Parse(reader["iznos"].ToString());
                                r.iznos_nabavna = decimal.Parse(reader["iznos_nabavna"].ToString());

                                ls_a.Add(r);
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

            return ls_a;
        }

        public List<Racun> daj_racun_prodavac_mesecni_knjizeno()
        {
            List<Racun> ls_a = new List<Racun>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Racuni_knjizeno", conn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime racun = new DateTime();
                            racun = DateTime.Parse(reader["datum_izdavanja"].ToString());


                            int mrr = (int)racun.Month;
                            int dmr = (int)DateTime.Now.Month;

                            int yr = (int)racun.Year;
                            int dyr = (int)DateTime.Now.Year;
                            if (yr == dyr && mrr == dmr)
                            {
                                Racun r = new Racun();

                                r.id_racuna = int.Parse(reader["id_racuna"].ToString());
                                r.prodavac = "knjizeno";
                                r.datum_izdavanja = DateTime.Parse(reader["datum_izdavanja"].ToString());
                                r.artikli = reader["artikli"].ToString();
                                r.iznos = decimal.Parse(reader["iznos"].ToString());
                                r.iznos_nabavna = decimal.Parse(reader["iznos_nabavna"].ToString());

                                ls_a.Add(r);
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

            return ls_a;
        }

        public List<Racun> daj_racun_prodavac_godisnji_knjizeno()
        {
            List<Racun> ls_a = new List<Racun>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Racuni_knjizeno", conn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime racun = new DateTime();
                            racun = DateTime.Parse(reader["datum_izdavanja"].ToString());

                            int yr = (int)racun.Year;
                            int dyr = (int)DateTime.Now.Year;
                            if (yr == dyr)
                            {
                                Racun r = new Racun();

                                r.id_racuna = int.Parse(reader["id_racuna"].ToString());
                                r.prodavac = "knjizeno";
                                r.datum_izdavanja = DateTime.Parse(reader["datum_izdavanja"].ToString());
                                r.artikli = reader["artikli"].ToString();
                                r.iznos = decimal.Parse(reader["iznos"].ToString());
                                r.iznos_nabavna = decimal.Parse(reader["iznos_nabavna"].ToString());

                                ls_a.Add(r);
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

            return ls_a;
        }

        public bool del_racun_knjizeno(int id_tmp)
        {
            bool del;

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Racuni_knjizeno WHERE id_racuna=" + id_tmp + "", conn))
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

        public List<Racun> daj_racun_knizeno(int id_racuna)
        {
            List<Racun> ls_a = new List<Racun>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Racuni_knjizeno WHERE id_racuna=@id_racuna", conn);
                    cmd.Parameters.AddWithValue("@id_racuna", id_racuna);


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Racun r = new Racun();

                            r.id_racuna = int.Parse(reader["id_racuna"].ToString());
                            r.datum_izdavanja = DateTime.Parse(reader["datum_izdavanja"].ToString());
                            r.artikli = reader["artikli"].ToString();
                            r.iznos = decimal.Parse(reader["iznos"].ToString());
                            r.iznos_nabavna = decimal.Parse(reader["iznos_nabavna"].ToString());

                            ls_a.Add(r);
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

        public bool unesi_racun_mob_hov()
        {
            bool racun;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO Racuni_hover_mob(prodavac, datum_izdavanja, artikal, iznos, iznos_nabavna, knjizeno) VALUES (@prodavac, @datum_izdavanja, @artikli, @iznos, @iznos_nabavna, @knjizeno)";

                    cmd.Parameters.AddWithValue("@prodavac", prodavac);
                    cmd.Parameters.AddWithValue("@datum_izdavanja", datum_izdavanja);
                    cmd.Parameters.AddWithValue("@artikli", artikli);
                    cmd.Parameters.AddWithValue("@iznos", iznos);
                    cmd.Parameters.AddWithValue("@iznos_nabavna", iznos_nabavna);
                    cmd.Parameters.AddWithValue("@knjizeno", knjizeno);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        racun = true;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                        racun = false;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }

            return racun;
        }

        public List<Racun> daj_racun_mob_hover(int knjizeno)
        {
            List<Racun> ls_a = new List<Racun>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Racuni_hover_mob WHERE knjizeno=@knjizeno", conn);
                    cmd.Parameters.AddWithValue("@knjizeno", knjizeno);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Racun r = new Racun();

                            r.id_racuna = int.Parse(reader["id_racuna"].ToString());
                            r.prodavac = reader["prodavac"].ToString();
                            r.datum_izdavanja = DateTime.Parse(reader["datum_izdavanja"].ToString());
                            r.artikli = reader["artikal"].ToString();
                            r.iznos = decimal.Parse(reader["iznos"].ToString());
                            r.iznos_nabavna = decimal.Parse(reader["iznos_nabavna"].ToString());
                            r.knjizeno = int.Parse(reader["knjizeno"].ToString());

                            ls_a.Add(r);
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

        public List<Racun> daj_racun_mob_hover_svi()
        {
            List<Racun> ls_a = new List<Racun>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Racuni_hover_mob", conn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Racun r = new Racun();

                            r.id_racuna = int.Parse(reader["id_racuna"].ToString());
                            r.prodavac = reader["prodavac"].ToString();
                            r.datum_izdavanja = DateTime.Parse(reader["datum_izdavanja"].ToString());
                            r.artikli = reader["artikal"].ToString();
                            r.iznos = decimal.Parse(reader["iznos"].ToString());
                            r.iznos_nabavna = decimal.Parse(reader["iznos_nabavna"].ToString());
                            r.knjizeno = int.Parse(reader["knjizeno"].ToString());

                            ls_a.Add(r);
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

        public bool del_racun_mob_hover(int id_tmp)
        {
            bool del;

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Racuni_hover_mob WHERE id_racuna=" + id_tmp + "", conn))
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

        public List<Racun> daj_racun_prodavac_dnevni_mob_hover()
        {
            List<Racun> ls_a = new List<Racun>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Racuni_hover_mob", conn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime racun = new DateTime();
                            racun = DateTime.Parse(reader["datum_izdavanja"].ToString());
                            int rr = (int)racun.Day;
                            int dr = (int)DateTime.Now.Day;

                            int mrr = (int)racun.Month;
                            int dmr = (int)DateTime.Now.Month;

                            if (rr == dr && mrr == dmr)
                            {
                                Racun r = new Racun();

                                r.id_racuna = int.Parse(reader["id_racuna"].ToString());
                                r.prodavac = reader["prodavac"].ToString();
                                r.datum_izdavanja = DateTime.Parse(reader["datum_izdavanja"].ToString());
                                r.artikli = reader["artikal"].ToString();
                                r.iznos = decimal.Parse(reader["iznos"].ToString());
                                r.iznos_nabavna = decimal.Parse(reader["iznos_nabavna"].ToString());
                                r.knjizeno = int.Parse(reader["knjizeno"].ToString());

                                ls_a.Add(r);
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

            return ls_a;
        }

        public List<Racun> daj_racun_prodavac_mesecni_mob_hover()
        {
            List<Racun> ls_a = new List<Racun>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Racuni_hover_mob", conn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime racun = new DateTime();
                            racun = DateTime.Parse(reader["datum_izdavanja"].ToString());


                            int mrr = (int)racun.Month;
                            int dmr = (int)DateTime.Now.Month;

                            int yr = (int)racun.Year;
                            int dyr = (int)DateTime.Now.Year;
                            if (yr == dyr && mrr == dmr)
                            {
                                Racun r = new Racun();

                                r.id_racuna = int.Parse(reader["id_racuna"].ToString());
                                r.prodavac = reader["prodavac"].ToString();
                                r.datum_izdavanja = DateTime.Parse(reader["datum_izdavanja"].ToString());
                                r.artikli = reader["artikal"].ToString();
                                r.iznos = decimal.Parse(reader["iznos"].ToString());
                                r.iznos_nabavna = decimal.Parse(reader["iznos_nabavna"].ToString());
                                r.knjizeno = int.Parse(reader["knjizeno"].ToString());

                                ls_a.Add(r);
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

            return ls_a;
        }

        public List<Racun> daj_racun_prodavac_godisnji_mob_hover()
        {
            List<Racun> ls_a = new List<Racun>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Racuni_hover_mob", conn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime racun = new DateTime();
                            racun = DateTime.Parse(reader["datum_izdavanja"].ToString());

                            int yr = (int)racun.Year;
                            int dyr = (int)DateTime.Now.Year;
                            if (yr == dyr)
                            {
                                Racun r = new Racun();

                                r.id_racuna = int.Parse(reader["id_racuna"].ToString());
                                r.prodavac = reader["prodavac"].ToString();
                                r.datum_izdavanja = DateTime.Parse(reader["datum_izdavanja"].ToString());
                                r.artikli = reader["artikal"].ToString();
                                r.iznos = decimal.Parse(reader["iznos"].ToString());
                                r.iznos_nabavna = decimal.Parse(reader["iznos_nabavna"].ToString());
                                r.knjizeno = int.Parse(reader["knjizeno"].ToString());

                                ls_a.Add(r);
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

            return ls_a;
        }

        public List<Racun> pretraga_po_datumu(DateTime dt)
        {
            List<Racun> ls = new List<Racun>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Racuni WHERE datum_izdavanja = @dt", conn);
                    cmd.Parameters.AddWithValue("@dt", dt);


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Racun r = new Racun();

                            r.id_racuna = int.Parse(reader["id_racuna"].ToString());
                            r.prodavac = reader["prodavac"].ToString();
                            r.datum_izdavanja = DateTime.Parse(reader["datum_izdavanja"].ToString());
                            r.artikli = reader["artikli"].ToString();
                            r.iznos = decimal.Parse(reader["iznos"].ToString());
                            r.iznos_nabavna = decimal.Parse(reader["iznos_nabavna"].ToString());

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

        public void backup()
        {
            string dir_mb = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MBBackup";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = ("SELECT * FROM Racuni");
                        SqlDataAdapter data = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable("racuni_xml");
                        data.Fill(dataTable);
                        DateTime dt = DateTime.Now;
                        dataTable.WriteXml(dir_mb + "\\Racuni" + dt.Day + dt.Month + dt.Year + dt.Hour + dt.Minute + dt.Second + ".xls");
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
            }
        }

        public void backup_knjizeno()
        {
            string dir_mb = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MBBackup";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = ("SELECT * FROM Racuni_knjizeno");
                        SqlDataAdapter data = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable("racuni_xml");
                        data.Fill(dataTable);
                        DateTime dt = DateTime.Now;
                        dataTable.WriteXml(dir_mb + "\\Racuniknjizeno" + dt.Day + dt.Month + dt.Year + dt.Hour + dt.Minute + dt.Second + ".xls");
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
            }
        }

        public void backup_hover_mob()
        {
            string dir_mb = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MBBackup";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = ("SELECT * FROM Racuni_hover_mob");
                        SqlDataAdapter data = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable("racunihover_xml");
                        data.Fill(dataTable);
                        DateTime dt = DateTime.Now;
                        dataTable.WriteXml(dir_mb + "\\Racunihover" + dt.Day + dt.Month + dt.Year + dt.Hour + dt.Minute + dt.Second + ".xls");
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
            }
        }
    }
}
