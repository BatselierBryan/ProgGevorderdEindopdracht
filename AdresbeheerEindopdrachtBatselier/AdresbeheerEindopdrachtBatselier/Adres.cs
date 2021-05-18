using System;

namespace AdresbeheerEindopdrachtBatselier
{
    public class Adres
    {
        public int ID { get; set; }
        public int StraatID { get; set; }
        public int AdresLocatieID { get; set; }
        public int Postcode { get; set; }
        public string HuisNummer { get; set; }
        public string BusNummer { get; set; }
        public string AppNummer { get; set; }
        public string HuisNummerLabel { get; set; }        
        public string Straat { get; set; }

        public Adres(int id, int straatId, int adreslocatieid, int postcode, string huisnummer, string busnummer, string appnummer, string huisnummerlabel, string straat)
        {
            ID = id;
            StraatID = straatId;
            AdresLocatieID = adreslocatieid;
            Postcode = postcode;
            HuisNummer = huisnummer;
            BusNummer = busnummer;
            AppNummer = appnummer;
            HuisNummerLabel = huisnummerlabel;
            Straat = straat;
        }

        public override bool Equals(object obj)
        {
            return obj is Adres adres && ID == adres.ID && StraatID == adres.StraatID && AdresLocatieID == adres.AdresLocatieID && Postcode == adres.Postcode
                                      && HuisNummer == adres.HuisNummer && BusNummer == adres.BusNummer && AppNummer == adres.AppNummer
                                      && HuisNummerLabel == adres.HuisNummerLabel && Straat == adres.Straat;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID, StraatID, AdresLocatieID, Postcode, HuisNummer, BusNummer, AppNummer, HuisNummerLabel);
        }
    }
}
