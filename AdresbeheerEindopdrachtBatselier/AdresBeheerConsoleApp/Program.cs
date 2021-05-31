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

            Console.WriteLine(domainsql.BestaatAdres(tmpAdres));
            Console.WriteLine(domainsql.BestaatGemeente(tmpGemeente));
            Console.WriteLine(domainsql.BestaatStraatnaam(tmpStraat.Naam, tmpGemeente));

            Console.WriteLine();
            var gekregenAdres = domainsql.SelecteerAdres(1000333174);
            Console.WriteLine($"{gekregenAdres.StraatID.ToString()} {gekregenAdres.HuisNummer.ToString()} {gekregenAdres.Straat}");
            
        }
    }
}
