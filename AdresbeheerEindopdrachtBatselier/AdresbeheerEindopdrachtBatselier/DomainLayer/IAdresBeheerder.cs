using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresbeheerEindopdrachtBatselier.DomainLayer
{
    public interface IAdresBeheerder
    {
        // Bool methodes
        bool BestaatAdres(Adres adres);
        bool BestaatGemeente(Gemeente gemeente);
        bool BestaatStraatnaam(string straatnaam, Gemeente gemeente);

        //Adres methodes
        Adres SelecteerAdres(int id);

        //List<Adres> methodes
        List<Adres> SelecteerAdressenInGemeente(int NIScode);
        List<Adres> SelecteerAdressenInStraat(int straatID);

        //Gemeente methodes
        Gemeente SelecteerGemeente(int NIScode);

        //List<Gemeente> methodes
        List<Gemeente> SelecteerGemeenten();

        //Straat methodes
        Straat SelecteerStraat(int id);

        //List<Straat> methodes
        List<Straat> SelecteerStratenInGemeente(int NIScode);
        List<Straat> SelecteerStratenInGemeente(string Gemeente);

        //Void methodes
        void UpdateAdres(Adres adres);
        void UpdateGemeente(Gemeente gemeente);
        void UpdateStraat(Straat straat);
        void VerwijderAdres(int id);
        void VerwijderGemeente(int NIScode);
        void VerwijderStraat(int id);
        void VoegAdresToe(Adres adres);
        void VoegGemeenteToe(Gemeente gemeente);
        void VoegStraatToe(Straat straat);
    }
}
