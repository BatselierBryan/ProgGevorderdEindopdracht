using System;
using System.Linq;
using AdresbeheerEindopdrachtBatselier;
using AdresbeheerEindopdrachtBatselier.DomainLayer;

namespace AdresBeheerConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(DateTime.Now);
            //GegevensUitlezen geg = new GegevensUitlezen();
            //geg.File();

            //Databank data = new Databank(@"Data Source=LAPTOP-DGE32LN4\SQLEXPRESS;Initial Catalog=Adressen;Integrated Security=True;Pooling=False");

            //Console.WriteLine("Read bulk");
            //Console.WriteLine(DateTime.Now);

            //Console.WriteLine("Lengte gemeente: " + geg.Gemeentes.Count());
            //data.BulkGemeente(geg.Gemeentes);

            //Console.WriteLine("Lengte straten: " + geg.Straten.Count());
            //data.BulkStraat(geg.Straten);

            //Console.WriteLine("Lengte adreslocatie: " + geg.AdresLocaties.Count());
            //data.BulkAdresLocatie(geg.AdresLocaties);

            //Console.WriteLine("Lengte adressen: " + geg.Adressen.Count());
            //data.BulkAdres(geg.Adressen);

            //Console.WriteLine(DateTime.Now);
            //Console.WriteLine("End bulk");
          
            var tmpAdres = new Adres(1000320925, 29299, 2694567, 1800, "4", null, "4", "2 - 4", "GemeenteStraat");
            var tmpGemeente = new Gemeente("Aartselaar", 11001);
            var tmpStraat = new Straat(1000333174, 11001, "Stijn Streuvelslaan");

            var domainsql = new DomainSQL();

            //Console.WriteLine();
            //var gekregenGemeente = domainsql.SelecteerGemeente(11001);
            //Console.WriteLine($"{gekregenGemeente.Naam} {gekregenGemeente.NISCode}");

            Console.WriteLine();
            var gekregenAdres = domainsql.SelecteerAdres(1000320925);
            Console.WriteLine($"{gekregenAdres.ID} {gekregenAdres.StraatID} {gekregenAdres.AdresLocatieID} {gekregenAdres.Postcode} {gekregenAdres.HuisNummer} {gekregenAdres.BusNummer} {gekregenAdres.AppNummer} {gekregenAdres.HuisNummerLabel} {gekregenAdres.Straat}");


            Console.WriteLine();
            var verander = new Adres(1000320925, 29299, 2694567, 1800, "5", "", "4", "2 - 4", "GemeenteStraat");
            domainsql.UpdateAdres(verander);


            Console.WriteLine();
            var gekregenAdres2 = domainsql.SelecteerAdres(1000320925);
            Console.WriteLine($"{gekregenAdres2.ID} {gekregenAdres2.StraatID} {gekregenAdres2.AdresLocatieID} {gekregenAdres2.Postcode} {gekregenAdres2.HuisNummer} {gekregenAdres2.BusNummer} {gekregenAdres2.AppNummer} {gekregenAdres2.HuisNummerLabel} {gekregenAdres2.Straat}");

            //Console.WriteLine();
            //var gekregenStraten = domainsql.SelecteerStratenInGemeente(11001);
            //foreach (var straat in gekregenStraten)
            //{
            //    Console.WriteLine($"{straat.ID} {straat.Naam} {straat.NISCode}");
            //}

            //Console.WriteLine();
            //var gekregenStraten2 = domainsql.SelecteerStratenInGemeente("Aartselaar");
            //foreach (var straat in gekregenStraten2)
            //{
            //    Console.WriteLine($"{straat.ID} {straat.Naam} {straat.NISCode}");
            //}
        }
    }
}
