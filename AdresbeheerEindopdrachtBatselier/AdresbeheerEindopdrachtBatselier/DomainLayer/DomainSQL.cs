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
        public bool BestaatAdres(Adres adres)
        {
            throw new NotImplementedException();
        }

        public bool BestaatGemeente(Gemeente gemeente)
        {
            throw new NotImplementedException();
        }

        public bool BestaatStraatnaam(string straatnaam, Gemeente gemeente)
        {
            throw new NotImplementedException();
        }

        public Adres SelecteerAdres(int id)
        {
            throw new NotImplementedException();
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
