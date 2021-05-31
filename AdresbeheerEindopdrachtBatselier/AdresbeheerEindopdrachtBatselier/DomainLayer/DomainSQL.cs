using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace AdresbeheerEindopdrachtBatselier.DomainLayer
{
    public class DomainSQL : IAdresBeheerder
    {
        public string connectionString = @"Data Source=LAPTOP-DGE32LN4\SQLEXPRESS;Initial Catalog=Adressen;Integrated Security=True;Pooling=False";

        public bool BestaatAdres(Adres adres)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new("SELECT * FROM adres WHERE id = @GegevenId;");
                command.Parameters.AddWithValue("@GegevenId", adres.ID);
                command.Connection = conn;
                try
                {
                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        return true;
                    }
                    dataReader.Close();
                    conn.Close();
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                } finally
                {
                    conn?.Dispose();
                }
                return false;
            }
        }

        public bool BestaatGemeente(Gemeente gemeente)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new("SELECT * FROM gemeente WHERE NISCODE = @GegevenNIScode;");
                command.Parameters.AddWithValue("@GegevenNIScode", gemeente.NISCode);
                command.Connection = conn;
                try
                {
                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        return true;
                    }
                    dataReader.Close();
                    conn.Close();
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                } finally
                {
                    conn?.Dispose();
                }
                return false;
            }
        }

        public bool BestaatStraatnaam(string straatnaam, Gemeente gemeente)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new("SELECT * FROM straat WHERE straatnaam = @GegevenStraat AND NISCODE = @GegevenNIScode;");
                command.Parameters.AddWithValue("@GegevenStraat", straatnaam);
                command.Parameters.AddWithValue("@GegevenNIScode", gemeente.NISCode);
                command.Connection = conn;
                try
                {
                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        return true;
                    }
                    dataReader.Close();
                    conn.Close();
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                } finally
                {
                    conn?.Dispose();
                }
                return false;
            }
        }

        public Adres SelecteerAdres(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new("SELECT * FROM adres WHERE id = @GegevenId;");
                command.Parameters.AddWithValue("@GegevenId", id);
                command.Connection = conn;
                try
                {
                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var tmpId = dataReader["id"].ToString();
                        var tmpStraatId = dataReader["straatid"].ToString();
                        var tmpHuisnummer = dataReader["huisnummer"].ToString();
                        var tmpBusnummer = dataReader["busnummer"].ToString();
                        var tmpAppNummer = dataReader["appartementnummer"].ToString();
                        var tmpHuisnummerlabel = dataReader["huisnummerlabel"].ToString();
                        var tmpPostcode = dataReader["postcode"].ToString();
                        var tmpAdreslocatieid = dataReader["adreslocatieid"].ToString();
                        var tmpStraatnaam = this.SelecteerStraat(id).Naam;

                        var GeselecteerdeAdres = new Adres(int.Parse(tmpId), int.Parse(tmpStraatId), int.Parse(tmpAdreslocatieid), int.Parse(tmpPostcode), tmpHuisnummer, tmpBusnummer, tmpAppNummer, tmpHuisnummerlabel, tmpStraatnaam);
                        return GeselecteerdeAdres;
                    }
                    dataReader.Close();
                    conn.Close();
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                } finally
                {
                    conn?.Dispose();
                }
                return null;
            }
        }

        public List<Adres> SelecteerAdressenInGemeente(int NIScode)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new("SELECT a.id, a.straatID, a.huisnummer, a.appartementnummer, a.busnummer, a.huisnummerlabel, a.adreslocatieID, a.postcode FROM gemeente as g INNER JOIN straat AS s ON g.NISCODE = s.NISCODE INNER JOIN adres AS a ON a.id = s.id WHERE g.NISCODE = @GegevenNIScode AND g.NISCODE = s.NISCODE AND s.id = a.id;");
                command.Parameters.AddWithValue("@GegevenNIScode", NIScode);
                command.Connection = conn;
                try
                {
                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    var listAdressen = new List<Adres>();
                    while (dataReader.Read())
                    {
                        var tmpId = dataReader["id"].ToString();
                        var tmpStraatId = dataReader["straatid"].ToString();
                        var tmpHuisnummer = dataReader["huisnummer"].ToString();
                        var tmpBusnummer = dataReader["busnummer"].ToString();
                        var tmpAppNummer = dataReader["appartementnummer"].ToString();
                        var tmpHuisnummerlabel = dataReader["huisnummerlabel"].ToString();
                        var tmpPostcode = dataReader["postcode"].ToString();
                        var tmpAdreslocatieid = dataReader["adreslocatieid"].ToString();
                        var tmpStraatnaam = this.SelecteerStraat(int.Parse(tmpId)).Naam;

                        var GeselecteerdeAdres = new Adres(int.Parse(tmpId), int.Parse(tmpStraatId), int.Parse(tmpAdreslocatieid), int.Parse(tmpPostcode), tmpHuisnummer, tmpBusnummer, tmpAppNummer, tmpHuisnummerlabel, tmpStraatnaam);
                        listAdressen.Add(GeselecteerdeAdres);
                    }
                    dataReader.Close();
                    conn.Close();
                    return listAdressen;
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                } finally
                {
                    conn?.Dispose();
                }
            }
        }

        public List<Adres> SelecteerAdressenInStraat(int straatID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new("SELECT a.id, a.straatID, a.huisnummer, a.appartementnummer, a.busnummer, a.huisnummerlabel, a.adreslocatieID, a.postcode, stra.NISCODE FROM adres a LEFT JOIN straat stra ON a.straatID = stra.id WHERE stra.id = @GegevenStraatId;");
                command.Parameters.AddWithValue("@GegevenStraatId", straatID);
                command.Connection = conn;
                try
                {
                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    var listAdressen = new List<Adres>();
                    while (dataReader.Read())
                    {
                        var tmpId = dataReader["id"].ToString();
                        var tmpStraatId = dataReader["straatid"].ToString();
                        var tmpHuisnummer = dataReader["huisnummer"].ToString();
                        var tmpBusnummer = dataReader["busnummer"].ToString();
                        var tmpAppNummer = dataReader["appartementnummer"].ToString();
                        var tmpHuisnummerlabel = dataReader["huisnummerlabel"].ToString();
                        var tmpPostcode = dataReader["postcode"].ToString();
                        var tmpAdreslocatieid = dataReader["adreslocatieid"].ToString();
                        var tmpStraatnaam = this.SelecteerStraat(int.Parse(tmpId)).Naam;

                        var GeselecteerdeAdres = new Adres(int.Parse(tmpId), int.Parse(tmpStraatId), int.Parse(tmpAdreslocatieid), int.Parse(tmpPostcode), tmpHuisnummer, tmpBusnummer, tmpAppNummer, tmpHuisnummerlabel, tmpStraatnaam);
                        listAdressen.Add(GeselecteerdeAdres);
                    }
                    dataReader.Close();
                    conn.Close();
                    return listAdressen;
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                } finally
                {
                    conn?.Dispose();
                }
            }
        }

        public Gemeente SelecteerGemeente(int NIScode)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new("SELECT * FROM gemeente WHERE NISCODE = @GegevenNIScode;");
                command.Parameters.AddWithValue("@GegevenNIScode", NIScode);
                command.Connection = conn;
                try
                {
                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var tmpNiscode = dataReader["NISCODE"].ToString();
                        var tmpGemeentenaam = dataReader["gemeentenaam"].ToString();

                        var GeselecteerdeGemeente = new Gemeente(tmpGemeentenaam, int.Parse(tmpNiscode));
                        return GeselecteerdeGemeente;
                    }
                    dataReader.Close();
                    conn.Close();
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                } finally
                {
                    conn?.Dispose();
                }
                return null;
            }
        }

        public List<Gemeente> SelecteerGemeenten()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new("SELECT * FROM gemeente;");
                command.Connection = conn;
                var listGeselecteerdeGemeente = new List<Gemeente>();
                try
                {
                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var tmpNiscode = dataReader["NISCODE"].ToString();
                        var tmpGemeentenaam = dataReader["gemeentenaam"].ToString();

                        var GeselecteerdeGemeente = new Gemeente(tmpGemeentenaam, int.Parse(tmpNiscode));
                        listGeselecteerdeGemeente.Add(GeselecteerdeGemeente);
                    }
                    dataReader.Close();
                    conn.Close();
                    return listGeselecteerdeGemeente;
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                } finally
                {
                    conn?.Dispose();
                }
            }
        }

        public Straat SelecteerStraat(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new("SELECT * FROM straat WHERE id = @GegevenId;");
                command.Parameters.AddWithValue("@GegevenId", id);
                command.Connection = conn;
                try
                {
                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var tmpId = dataReader["id"].ToString();
                        var tmpStraatnaam = dataReader["straatnaam"].ToString();
                        var tmpNiscode = dataReader["NISCODE"].ToString();

                        var GeselecteerdeStraat = new Straat(int.Parse(tmpId), int.Parse(tmpNiscode), tmpStraatnaam);
                        return GeselecteerdeStraat;
                    }
                    dataReader.Close();
                    conn.Close();
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                } finally
                {
                    conn?.Dispose();
                }
                return null;
            }
        }

        public List<Straat> SelecteerStratenInGemeente(int NIScode)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new("SELECT s.id, s.straatnaam, s.NISCODE FROM gemeente as g INNER JOIN straat AS s ON s.NISCODE = g.NISCODE WHERE s.NISCODE = @GegevenNIScode AND s.NISCODE = g.NISCODE;");
                command.Parameters.AddWithValue("@GegevenNIScode", NIScode);
                command.Connection = conn;
                try
                {
                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    var listStraten = new List<Straat>();
                    while (dataReader.Read())
                    {
                        var tmpId = dataReader["id"].ToString();
                        var tmpNiscode = dataReader["NISCODE"].ToString();
                        var tmpStraatnaam = dataReader["straatnaam"].ToString();

                        var GeselecteerdeStraat = new Straat(int.Parse(tmpId), int.Parse(tmpNiscode), tmpStraatnaam);
                        listStraten.Add(GeselecteerdeStraat);
                    }
                    dataReader.Close();
                    conn.Close();
                    return listStraten;
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                } finally
                {
                    conn?.Dispose();
                }
            }
        }

        public List<Straat> SelecteerStratenInGemeente(string Gemeente)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new("SELECT s.id, s.straatnaam, s.NISCODE FROM gemeente as g INNER JOIN straat AS s ON s.NISCODE = g.NISCODE WHERE g.gemeentenaam = @GegevenGemeente AND g.NISCODE = s.NISCODE;");
                command.Parameters.AddWithValue("@GegevenGemeente", Gemeente);
                command.Connection = conn;
                try
                {
                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    var listStraten = new List<Straat>();
                    while (dataReader.Read())
                    {
                        var tmpId = dataReader["id"].ToString();
                        var tmpNiscode = dataReader["NISCODE"].ToString();
                        var tmpStraatnaam = dataReader["straatnaam"].ToString();

                        var GeselecteerdeStraat = new Straat(int.Parse(tmpId), int.Parse(tmpNiscode), tmpStraatnaam);
                        listStraten.Add(GeselecteerdeStraat);
                    }
                    dataReader.Close();
                    conn.Close();
                    return listStraten;
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                } finally
                {
                    conn?.Dispose();
                }
            }
        }

        public void UpdateAdres(Adres adres)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "UPDATE [dbo].[adres] SET [straatid] = @GegevenStraatid, [huisnummer] = @GegevenHuisnummer, [appartementnummer] = @GegevenAppartementnummer, [busnummer] = @GegevenBusnummer, [huisnummerlabel] = @GegevenHuisnummerlabel, [postcode] = @GegevenPostcode WHERE id = @GegevenId;";
            using (SqlCommand command = conn.CreateCommand())
            {
                conn.Open();
                try
                {
                    command.Parameters.AddWithValue("@GegevenId", adres.ID);
                    command.Parameters.AddWithValue("@GegevenStraatid", adres.StraatID);
                    command.Parameters.AddWithValue("@GegevenHuisnummer", adres.HuisNummer);
                    command.Parameters.AddWithValue("@GegevenAppartementnummer", adres.AppNummer);
                    command.Parameters.AddWithValue("@GegevenBusnummer", adres.BusNummer);
                    command.Parameters.AddWithValue("@GegevenHuisnummerlabel", adres.HuisNummerLabel);
                    command.Parameters.AddWithValue("@GegevenPostcode", adres.Postcode);
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                } catch (Exception e)
                {
                    throw new Exception(e.Message);
                } finally
                {
                    conn.Close();
                }
            }
        }

        public void UpdateGemeente(Gemeente gemeente)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "UPDATE [dbo].[gemeente] SET [gemeentenaam] = @GegevenGemeentenaam WHERE NISCODE = @GegevenNIScode;";
            using (SqlCommand command = conn.CreateCommand())
            {
                conn.Open();
                try
                {
                    command.Parameters.AddWithValue("@GegevenNIScode", gemeente.NISCode);
                    command.Parameters.AddWithValue("@GegevenGemeentenaam", gemeente.Naam);
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                } catch (Exception e)
                {
                    throw new Exception(e.Message);
                } finally
                {
                    conn.Close();
                }
            }
        }

        public void UpdateStraat(Straat straat)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "UPDATE [dbo].[straat] SET [straatnaam] = @GegevenStraatnaam WHERE id = @GegevenId;";
            using (SqlCommand command = conn.CreateCommand())
            {
                conn.Open();
                try
                {
                    command.Parameters.AddWithValue("@GegevenId", straat.ID);
                    command.Parameters.AddWithValue("@GegevenStraatnaam", straat.Naam);
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                } catch (Exception e)
                {
                    throw new Exception(e.Message);
                } finally
                {
                    conn.Close();
                }
            }
        }

        public void VerwijderAdres(int id)
        {
            throw new NotImplementedException();
        }

        public void VerwijderGemeente(int NIScode)
        {
            throw new NotImplementedException();
        }

        public void VerwijderStraat(int id)
        {
            throw new NotImplementedException();
        }

        public void VoegAdresToe(Adres adres)
        {
            throw new NotImplementedException();
        }

        public void VoegGemeenteToe(Gemeente gemeente)
        {
            throw new NotImplementedException();
        }

        public void VoegStraatToe(Straat straat)
        {
            throw new NotImplementedException();
        }
    }
}
