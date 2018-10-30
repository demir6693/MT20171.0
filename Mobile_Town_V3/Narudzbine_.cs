using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_Town_V3
{
    class Narudzbine_
    {
        public string connString = "Data Source=mobiletown.database.windows.net;Initial Catalog=Mobile_Town;User ID=demir;Password=Agovic6693;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public int id_narudzbine { get; set; }
        public string broj_telefona { get; set; }
        public string ime_prezime { get; set; }
        public string opis_narudzbine { get; set; }

        public bool unesi_narudzbinu()
        {
            bool ndz;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO Narudzbine(ime_prezime, broj_telefona, opis_narudzbine) VALUES (@ime_prezime, @broj_telefona, @opis_narudzbine)";
                    cmd.Parameters.AddWithValue("@ime_prezime", ime_prezime);
                    cmd.Parameters.AddWithValue("@broj_telefona", broj_telefona);
                    cmd.Parameters.AddWithValue("@opis_narudzbine", opis_narudzbine);
                    
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        ndz = true;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                        ndz = false;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }

            return ndz;
        }

        public List<Narudzbine_> get_narudzbine()
        {
            List<Narudzbine_> ls = new List<Narudzbine_>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Narudzbine", conn);
                    
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Narudzbine_ n = new Narudzbine_();

                            n.id_narudzbine = int.Parse(reader["id_narudzbine"].ToString());
                            n.ime_prezime = reader["ime_prezime"].ToString();
                            n.broj_telefona = reader["broj_telefona"].ToString();
                            n.opis_narudzbine = reader["opis_narudzbine"].ToString();

                            ls.Add(n);
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

        public bool del_narudzbina(int sifra_tmp)
        {
            bool del;

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Narudzbine WHERE id_narudzbine=" + sifra_tmp + "", conn))
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
                        cmd.CommandText = ("SELECT * FROM Narudzbine");
                        SqlDataAdapter data = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable("narudzbine_xml");
                        data.Fill(dataTable);
                        DateTime dt = DateTime.Now;
                        dataTable.WriteXml(dir_mb + "\\Narudzbine" + dt.Day + dt.Month + dt.Year + dt.Hour + dt.Minute + dt.Second + ".xls");
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
