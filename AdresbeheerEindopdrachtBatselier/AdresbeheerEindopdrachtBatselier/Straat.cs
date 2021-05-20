using System;

namespace AdresbeheerEindopdrachtBatselier
{
    public class Straat
    {
        public int ID { get; set; }        
        public int NISCode { get; set; }
        public string Naam { get; set; }

        public Straat(int id, int niscode, string naam)
        {
            ID = id;
            NISCode = niscode;
            Naam = naam;
        }

        public override bool Equals(object obj)
        {
            return obj is Straat straat && ID == straat.ID && Naam == straat.Naam && NISCode == straat.NISCode;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(ID, Naam, NISCode);
        }
    }
}
