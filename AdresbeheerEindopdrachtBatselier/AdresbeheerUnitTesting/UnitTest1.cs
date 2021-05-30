using System;
using Xunit;
using AdresbeheerEindopdrachtBatselier;
using AdresbeheerEindopdrachtBatselier.Exceptions;

namespace AdresbeheerUnitTesting
{
    public class UnitTest1
    {
        //Testing voor adreslocatie
        [Theory]
        [InlineData("", "48596", "78458")]
        [InlineData(" ", "48596", "78458")]
        [InlineData(null, "48596", "78458")]
        public void voegVerkeerdeID(string id, string x, string y)
        {
            AdresLocatie adresLocatie;
            var tmp = Assert.Throws<AdreslocatieException>(() => adresLocatie = new AdresLocatie(int.Parse(id), decimal.Parse(x), decimal.Parse(y)));
            Assert.Equal("Klopt niet", tmp.Message);
        }

        [Theory]
        [InlineData("92181", "", "78458")]
        [InlineData("92181", " ", "78458")]
        [InlineData("92181", null, "78458")]
        public void voegVerkeerdeX(string id, string x, string y)
        {
            AdresLocatie adresLocatie;
            var tmp = Assert.Throws<AdreslocatieException>(() => adresLocatie = new AdresLocatie(int.Parse(id), decimal.Parse(x), decimal.Parse(y)));
            Assert.Equal("Klopt niet", tmp.Message);
        }

        [Theory]
        [InlineData("92181", "48596", "")]
        [InlineData("92181", "48596", " ")]
        [InlineData("92181", "48596", null)]
        public void voegVerkeerdeY(string id, string x, string y)
        {
            AdresLocatie adresLocatie;
            var tmp = Assert.Throws<AdreslocatieException>(() => adresLocatie = new AdresLocatie(int.Parse(id), decimal.Parse(x), decimal.Parse(y)));
            Assert.Equal("Klopt niet", tmp.Message);
        }

        //Testing voor gemeente
        [Theory]
        [InlineData("", "02345")]
        [InlineData(" ", "02345")]
        [InlineData(null, "02345")]
        public void voegVerkeerdeNaam(string niscode, string naam)
        {
            Gemeente gemeente;
            var tmp = Assert.Throws<GemeenteException>(() => gemeente = new Gemeente(naam, int.Parse(niscode)));
            Assert.Equal("Klopt niet", tmp.Message);
        }

        [Theory]
        [InlineData("Geraardsbergen", "")]
        [InlineData("Geraardsbergen", " ")]
        [InlineData("Geraardsbergen", null)]
        public void voegVerkeerdeNiscode(string naam, string niscode)
        {
            Gemeente gemeente;
            var tmp = Assert.Throws<GemeenteException>(() => gemeente = new Gemeente(naam, int.Parse(niscode)));
            Assert.Equal("Klopt niet", tmp.Message);
        }

        //Testing voor straat
        [Theory]
        [InlineData("", "Peter", "23009")]
        [InlineData(" ", "Peter", "23009")]
        [InlineData(null, "Peter", "23009")]
        public void voegVerkeerdeStraatID(string id, string naam, string niscode)
        {
            Straat straat;
            var tmp = Assert.Throws<StraatException>(() => straat = new Straat(int.Parse(id), int.Parse(niscode), naam));
            Assert.Equal("Klopt niet", tmp.Message);
        }

        [Theory]
        [InlineData("84265", "", "23009")]
        [InlineData("84265", " ", "23009")]
        [InlineData("84265", null, "23009")]
        public void voegVerkeerdeStraatNaam(string id, string naam, string niscode)
        {
            Straat straat;
            var tmp = Assert.Throws<StraatException>(() => straat = new Straat(int.Parse(id), int.Parse(niscode), naam));
            Assert.Equal("Straatnaam klopt niet", tmp.Message);
        }

        [Theory]
        [InlineData("84265", "Peter", "")]
        [InlineData("84265", "Peter", " ")]
        [InlineData("84265", "Peter", null)]
        public void voegVerkeerdeStraatNiscode(string id, string naam, string niscode)
        {
            Straat straat;
            var tmp = Assert.Throws<StraatException>(() => straat = new Straat(int.Parse(id), int.Parse(niscode), naam));
            Assert.Equal("NISCODE klopt niet", tmp.Message);
        }

        //Testing voor adres
        [Theory]
        [InlineData("", "2", "2", "1", "10", "A12", "9870", "12", "Gemeentestraat")]
        [InlineData(" ", "3", "3", "2", "9", "A13", "1200", "11", "Gemeentestraat")]
        [InlineData(null, "5", "4", "3", "8", "A14", "1111", "10", "Gemeentestraat")]
        public void voegVerkeerdeAdresId(string id, string straatid, string huisnummer, string busnummer, string appnummer, string huisnummerlabel, string postcode, string adreslocatieid, string straat)
        {
            Adres adres;
            var tmp = Assert.Throws<AdresException>(() => adres = new Adres(int.Parse(id), int.Parse(straatid), int.Parse(adreslocatieid), int.Parse(postcode), huisnummer, busnummer, appnummer, huisnummerlabel, straat));
            Assert.Equal("ID klopt niet", tmp.Message);
        }

        [Theory]
        [InlineData("15", "", "2", "1", "10", "A12", "9870", "12", "Gemeentestraat")]
        [InlineData("15", " ", "3", "2", "9", "A13", "1200", "11", "Gemeentestraat")]
        [InlineData("15", null, "4", "3", "8", "A14", "1111", "10", "Gemeentestraat")]
        public void voegVerkeerdeAdresStraatId(string id, string straatid, string huisnummer, string busnummer, string appnummer, string huisnummerlabel, string postcode, string adreslocatieid, string straat)
        {
            Adres adres;
            var tmp = Assert.Throws<AdresException>(() => adres = new Adres(int.Parse(id), int.Parse(straatid), int.Parse(adreslocatieid), int.Parse(postcode), huisnummer, busnummer, appnummer, huisnummerlabel, straat));
            Assert.Equal("StraatID klopt niet", tmp.Message);
        }

        [Theory]
        [InlineData("15", "2", "", "1", "10", "A12", "9870", "12", "Gemeentestraat")]
        [InlineData("15", "3", " ", "2", "9", "A13", "1200", "11", "Gemeentestraat")]
        [InlineData("15", "5", null, "3", "8", "A14", "1111", "10", "Gemeentestraat")]
        public void voegVerkeerdeAdresHuisnummer(string id, string straatid, string huisnummer, string busnummer, string appnummer, string huisnummerlabel, string postcode, string adreslocatieid, string straat)
        {
            Adres adres;
            var tmp = Assert.Throws<AdresException>(() => adres = new Adres(int.Parse(id), int.Parse(straatid), int.Parse(adreslocatieid), int.Parse(postcode), huisnummer, busnummer, appnummer, huisnummerlabel, straat));
            Assert.Equal("Huisnummer klopt niet", tmp.Message);
        }

        [Theory]
        [InlineData("15", "2", "2", "", "10", "A12", "9870", "12", "Gemeentestraat")]
        [InlineData("15", "3", "3", " ", "9", "A13", "1200", "11", "Gemeentestraat")]
        [InlineData("15", "5", "4", null, "8", "A14", "1111", "10", "Gemeentestraat")]
        public void voegVerkeerdeAdresBusnummer(string id, string straatid, string huisnummer, string busnummer, string appnummer, string huisnummerlabel, string postcode, string adreslocatieid, string straat)
        {
            Adres adres;
            var tmp = Assert.Throws<AdresException>(() => adres = new Adres(int.Parse(id), int.Parse(straatid), int.Parse(adreslocatieid), int.Parse(postcode), huisnummer, busnummer, appnummer, huisnummerlabel, straat));
            Assert.Equal("Busnummer klopt niet", tmp.Message);
        }

        [Theory]
        [InlineData("15", "2", "2", "1", "", "A12", "9870", "12", "Gemeentestraat")]
        [InlineData("15", "3", "3", "2", " ", "A13", "1200", "11", "Gemeentestraat")]
        [InlineData("15", "5", "4", "3", null, "A14", "1111", "10", "Gemeentestraat")]
        public void voegVerkeerdeAdresAppnummer(string id, string straatid, string huisnummer, string busnummer, string appnummer, string huisnummerlabel, string postcode, string adreslocatieid, string straat)
        {
            Adres adres;
            var tmp = Assert.Throws<AdresException>(() => adres = new Adres(int.Parse(id), int.Parse(straatid), int.Parse(adreslocatieid), int.Parse(postcode), huisnummer, busnummer, appnummer, huisnummerlabel, straat));
            Assert.Equal("Appnummer klopt niet", tmp.Message);
        }

        [Theory]
        [InlineData("15", "2", "2", "1", "10", "", "9870", "12", "Gemeentestraat")]
        [InlineData("15", "3", "3", "2", "9", " ", "1200", "11", "Gemeentestraat")]
        [InlineData("15", "5", "4", "3", "8", null, "1111", "10", "Gemeentestraat")]
        public void voegVerkeerdeAdresHuisnummerlabel(string id, string straatid, string huisnummer, string busnummer, string appnummer, string huisnummerlabel, string postcode, string adreslocatieid, string straat)
        {
            Adres adres;
            var tmp = Assert.Throws<AdresException>(() => adres = new Adres(int.Parse(id), int.Parse(straatid), int.Parse(adreslocatieid), int.Parse(postcode), huisnummer, busnummer, appnummer, huisnummerlabel, straat));
            Assert.Equal("Huisnummerlabel klopt niet", tmp.Message);
        }

        [Theory]
        [InlineData("15", "2", "2", "1", "10", "A12", "", "12", "Gemeentestraat")]
        [InlineData("15", "3", "3", "2", "9", "A13", " ", "11", "Gemeentestraat")]
        [InlineData("15", "5", "4", "3", "8", "A14", null, "10", "Gemeentestraat")]
        public void voegVerkeerdeAdresPostcode(string id, string straatid, string huisnummer, string busnummer, string appnummer, string huisnummerlabel, string postcode, string adreslocatieid, string straat)
        {
            Adres adres;
            var tmp = Assert.Throws<AdresException>(() => adres = new Adres(int.Parse(id), int.Parse(straatid), int.Parse(adreslocatieid), int.Parse(postcode), huisnummer, busnummer, appnummer, huisnummerlabel, straat));
            Assert.Equal("Postcode klopt niet", tmp.Message);
        }

        [Theory]
        [InlineData("15", "2", "2", "1", "10", "A12", "9870", "", "Gemeentestraat")]
        [InlineData("15", "3", "3", "2", "9", "A13", "1200", " ", "Gemeentestraat")]
        [InlineData("15", "5", "4", "3", "8", "A14", "1111", null, "Gemeentestraat")]
        public void voegVerkeerdeAdresAdreslocatieId(string id, string straatid, string huisnummer, string busnummer, string appnummer, string huisnummerlabel, string postcode, string adreslocatieid, string straat)
        {
            Adres adres;
            var tmp = Assert.Throws<AdresException>(() => adres = new Adres(int.Parse(id), int.Parse(straatid), int.Parse(adreslocatieid), int.Parse(postcode), huisnummer, busnummer, appnummer, huisnummerlabel, straat));
            Assert.Equal("Adreslocatie klopt niet", tmp.Message);
        }

        [Theory]
        [InlineData("15", "2", "2", "1", "10", "A12", "9870", "12", "")]
        [InlineData("15", "3", "3", "2", "9", "A13", "1200", "11", " ")]
        [InlineData("15", "5", "4", "3", "8", "A14", "1111", "10", null)]
        public void voegVerkeerdeAdresStraat(string id, string straatid, string huisnummer, string busnummer, string appnummer, string huisnummerlabel, string postcode, string adreslocatieid, string straat)
        {
            Adres adres;
            var tmp = Assert.Throws<AdresException>(() => adres = new Adres(int.Parse(id), int.Parse(straatid), int.Parse(adreslocatieid), int.Parse(postcode), huisnummer, busnummer, appnummer, huisnummerlabel, straat));
            Assert.Equal("Straat klopt niet", tmp.Message);
        }
    }
}
