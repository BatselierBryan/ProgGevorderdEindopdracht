using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AdresbeheerEindopdrachtBatselier
{
    public class Databank
    {
        public string Connection { get; private set; }

        public Databank(string connection)
        {
            Connection = connection;
        }

        public void BulkGemeente(HashSet<Gemeente> gemeentes)
        {
            using (SqlConnection con = new SqlConnection(Connection))
            {
                con.Open();
                using (SqlBulkCopy sqbc = new SqlBulkCopy(Connection))
                {     
                    DataTable gemeente = new DataTable("gemeente");
                    gemeente.Columns.Add(new DataColumn("NISCODE", Type.GetType("System.String")));
                    gemeente.Columns.Add(new DataColumn("gemeentenaam", Type.GetType("System.String")));

                    foreach (Gemeente g in gemeentes)
                    {
                        gemeente.Rows.Add(g.NISCode, g.Naam);
                    }

                    sqbc.DestinationTableName = "gemeente";
                    sqbc.ColumnMappings.Add("NISCODE", "NISCODE");
                    sqbc.ColumnMappings.Add("gemeentenaam", "gemeentenaam");
                    sqbc.WriteToServer(gemeente);               
                }
            }
        }

        public void BulkStraat(HashSet<Straat> straten)
        {
            using (SqlConnection con = new SqlConnection(Connection))
            {
                con.Open();
                using (SqlBulkCopy sqbc = new SqlBulkCopy(Connection))
                {
                    DataTable straat = new DataTable("straat");
                    straat.Columns.Add(new DataColumn("id", Type.GetType("System.Int32")));
                    straat.Columns.Add(new DataColumn("NISCode", Type.GetType("System.Int32")));
                    straat.Columns.Add(new DataColumn("straatnaam", Type.GetType("System.String")));

                    foreach (Straat s in straten)
                    {
                        straat.Rows.Add(s.ID, s.NISCode, s.Naam);
                    }

                    sqbc.DestinationTableName = "straat";
                    sqbc.WriteToServer(straat);
                }
            }
        }

        public void BulkAdresLocatie(HashSet<AdresLocatie> adreslocaties)
        {
            using (SqlConnection con = new SqlConnection(Connection))
            {
                con.Open();
                using (SqlBulkCopy sqbc = new SqlBulkCopy(Connection))
                {
                    DataTable adreslocatie = new DataTable("adreslocatie");
                    adreslocatie.Columns.Add(new DataColumn("id", Type.GetType("System.Int32")));
                    adreslocatie.Columns.Add(new DataColumn("x", Type.GetType("System.Decimal")));
                    adreslocatie.Columns.Add(new DataColumn("y", Type.GetType("System.Decimal")));

                    foreach (AdresLocatie adr in adreslocaties)
                    {
                        adreslocatie.Rows.Add(adr.ID, adr.X, adr.Y);
                    }

                    sqbc.DestinationTableName = "adreslocatie";
                    sqbc.WriteToServer(adreslocatie);
                }
            }
        }

        public void BulkAdres(HashSet<Adres> adressen)
        {
            using (SqlConnection con = new SqlConnection(Connection))
            {
                con.Open();
                using (SqlBulkCopy sqbc = new SqlBulkCopy(Connection))
                {
                    DataTable adres = new DataTable("adres");
                    adres.Columns.Add(new DataColumn("id", Type.GetType("System.Int32")));
                    adres.Columns.Add(new DataColumn("straatID", Type.GetType("System.Int32")));
                    adres.Columns.Add(new DataColumn("adreslocatieId", Type.GetType("System.Int32")));
                    adres.Columns.Add(new DataColumn("postcode", Type.GetType("System.Int32")));
                    adres.Columns.Add(new DataColumn("huisnummer", Type.GetType("System.String")));
                    adres.Columns.Add(new DataColumn("appartementnummer", Type.GetType("System.String")));
                    adres.Columns.Add(new DataColumn("busnummer", Type.GetType("System.String")));
                    adres.Columns.Add(new DataColumn("huisnummerlabel", Type.GetType("System.String")));

                    foreach (Adres ad in adressen)
                    {
                        adres.Rows.Add(ad.ID, ad.StraatID, ad.AdresLocatieID, ad.Postcode, ad.HuisNummer, ad.AppNummer, ad.BusNummer, ad.HuisNummerLabel);
                    }

                    sqbc.DestinationTableName = "adres";
                    sqbc.WriteToServer(adres);
                }
            }
        }
    }
}
