using System;
using System.Collections.Generic;
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
                        var tmpStraatnaam = "Template" ; //Deze moet nog gefixt worden naar -> SelecteerStraat(id)

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
            throw new NotImplementedException();
        }

        public List<Adres> SelecteerAdressenInStraat(int straatID)
        {
            throw new NotImplementedException();
        }

        public Gemeente SelecteerGemeente(int NIScode)
        {
            throw new NotImplementedException();
        }

        public List<Gemeente> SelecteerGemeenten()
        {
            throw new NotImplementedException();
        }

        public Straat SelecteerStraat(int id)
        {
            throw new NotImplementedException();
        }

        public List<Straat> SelecteerStratenInGemeente(int NIScode)
        {
            throw new NotImplementedException();
        }

        public List<Straat> SelecteerStratenInGemeente(string Gemeente)
        {
            throw new NotImplementedException();
        }

        public void UpdateAdres(Adres adres)
        {
            throw new NotImplementedException();
        }

        public void UpdateGemeente(Gemeente gemeente)
        {
            throw new NotImplementedException();
        }

        public void UpdateStraat(Straat straat)
        {
            throw new NotImplementedException();
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
