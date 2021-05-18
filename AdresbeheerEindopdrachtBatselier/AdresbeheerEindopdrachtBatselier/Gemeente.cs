using System;

namespace AdresbeheerEindopdrachtBatselier
{
    public class Gemeente
    {
        public string Naam { get; set; }
        public int NISCode { get; set; }

        public Gemeente(string naam, int niscode)
        {
            Naam = naam;
            NISCode = niscode;
        }

        public override bool Equals(object obj)
        {
            return obj is Gemeente gemeente && Naam == gemeente.Naam && NISCode == gemeente.NISCode;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Naam, NISCode);
        }
    }
}
