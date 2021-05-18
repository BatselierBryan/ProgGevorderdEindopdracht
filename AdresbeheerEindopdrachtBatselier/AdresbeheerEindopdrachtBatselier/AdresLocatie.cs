using System;

namespace AdresbeheerEindopdrachtBatselier
{
    public class AdresLocatie
    {
        public int ID { get; set; }
        public decimal X { get; set; }
        public decimal Y { get; set; }

        public AdresLocatie(int id, decimal x, decimal y)
        {
            ID = id;
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            return obj is AdresLocatie locatie && ID == locatie.ID && X == locatie.X && Y == locatie.Y;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(ID, X, Y);
        }
    }
}
