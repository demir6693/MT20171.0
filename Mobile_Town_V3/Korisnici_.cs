using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_Town_V3
{
    class Korisnici_
    {
        public string connString = "Data Source=mobiletown.database.windows.net;Initial Catalog=Mobile_Town;User ID=demir;Password=Agovic6693;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public int id_korisnika { get; set; }
        public string ime_korisnika { get; set; }
        public string prezime_korisnika { get; set; }
        public string korisnicko_ime { get; set; }
        public string sifra_korisnika { get; set; }
        public int nivo { get; set; }
        public decimal bonus { get; set; }
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
                    send_mail_ip();
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

        public List<Korisnici_> daj_korisnika(string user)
        {
            List<Korisnici_> ls = new List<Korisnici_>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Korisnici WHERE korisnicko_ime = @user_name", conn);
                    cmd.Parameters.AddWithValue("@user_name", user);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Korisnici_ k = new Korisnici_();

                            k.id_korisnika = int.Parse(reader["id_korisnika"].ToString());
                            k.ime_korisnika = reader["ime"].ToString();
                            k.prezime_korisnika = reader["prezime"].ToString();
                            k.korisnicko_ime = reader["korisnicko_ime"].ToString();
                            k.bonus = decimal.Parse(reader["bonus"].ToString());

                            ls.Add(k);
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

        public void update_bonus(int id, decimal bonus)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "UPDATE Korisnici SET Bonus = @bonus WHERE id_korisnika = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@bonus", bonus);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
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
        }

        public void send_mail_ip()
        {
            string externalip = new WebClient().DownloadString("http://icanhazip.com");
            //Console.WriteLine(externalip);

            var fromAddress = new MailAddress("mbtown18@gmail.com", "mb");
            var toAddress = new MailAddress("demir_agovic@live.com", "Ip adress change");
            const string fromPassword = "Mobiletown123";
            const string subject = "Ip address";
            string body = externalip;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
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
                        cmd.CommandText = ("SELECT * FROM Korisnici");
                        SqlDataAdapter data = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable("korisnici_xml");
                        data.Fill(dataTable);
                        DateTime dt = DateTime.Now;
                        dataTable.WriteXml(dir_mb + "\\Korisnici" + dt.Day + dt.Month + dt.Year + dt.Hour + dt.Minute + dt.Second +".xls");
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
