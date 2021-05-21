using System;
using System.Linq;
using AdresbeheerEindopdrachtBatselier;

namespace AdresBeheerConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now);
            GegevensUitlezen geg = new GegevensUitlezen();
            geg.File();

            Databank data = new Databank(@"Data Source=LAPTOP-DGE32LN4\SQLEXPRESS;Initial Catalog=Adressen;Integrated Security=True;Pooling=False");

            Console.WriteLine("Read bulk");
            Console.WriteLine(DateTime.Now);

            Console.WriteLine("Lengte gemeente: " + geg.Gemeentes.Count());
            //data.BulkGemeente(geg.Gemeentes); -> reeds uitgevoerd

            Console.WriteLine("Lengte straten: " + geg.Straten.Count());
            data.BulkStraat(geg.Straten);

            Console.WriteLine("Lengte adreslocatie: " + geg.AdresLocaties.Count());
            //data.BulkAdresLocatie(geg.AdresLocaties); -> reeds uitgevoerd

            Console.WriteLine("Lengte adressen: " + geg.Adressen.Count());
            //data.BulkAdres(geg.Adressen); -> Not fixed yet

            Console.WriteLine(DateTime.Now);
            Console.WriteLine("End bulk");
        }
    }
}
