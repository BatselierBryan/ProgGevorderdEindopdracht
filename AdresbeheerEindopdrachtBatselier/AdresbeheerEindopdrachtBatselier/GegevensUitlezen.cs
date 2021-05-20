using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System;
using System.Threading;
using System.Linq;

namespace AdresbeheerEindopdrachtBatselier
{
    public class GegevensUitlezen
    {
        public string pad = @"C:\tmp\CrabAdressenlijst\GML\CrabAdr.gml";

        public HashSet<Adres> Adressen = new();
        public HashSet<Gemeente> Gemeentes = new();
        public HashSet<Straat> Straten = new();
        public HashSet<AdresLocatie> AdresLocaties = new();
        public int adreslocatieid = 0;

        public void File()
        {
            using (StreamReader str = new StreamReader(pad))               
            {
                int dcount = 0;
                int subcount = 0;
                string conf = "";
                while ((conf = str.ReadLine()) != null)
                {
                    if (conf.Contains("agiv:CrabAdr"))
                    {
                        dcount++;
                        subcount++;
                        string[] fileData = new string[16];
                        
                        while ((conf = str.ReadLine()) != null)
                        {
                            if (conf.Contains("/agiv:CrabAdr")) { adreslocatieid++; break; }
                            if (conf.Contains("agiv:ID")) { fileData[0] = Regex.Match(conf, "(?<=>)(.*)(?=<)").ToString(); }
                            if (conf.Contains("agiv:STRAATNMID")) { fileData[1] = Regex.Match(conf, "(?<=>)(.*)(?=<)").ToString(); }
                            if (conf.Contains("agiv:STRAATNM")) { fileData[2] = Regex.Match(conf, "(?<=>)(.*)(?=<)").ToString(); }
                            if (conf.Contains("agiv:HUISNR")) { fileData[3] = Regex.Match(conf, "(?<=>)(.*)(?=<)").ToString(); }
                            if (conf.Contains("agiv:APPTNR")) { fileData[4] = Regex.Match(conf, "(?<=>)(.*)(?=<)").ToString(); }
                            if (conf.Contains("agiv:BUSNR")) { fileData[5] = Regex.Match(conf, "(?<=>)(.*)(?=<)").ToString(); }
                            if (conf.Contains("agiv:HNRLABEL")) { fileData[6] = Regex.Match(conf, "(?<=>)(.*)(?=<)").ToString(); }
                            if (conf.Contains("agiv:NISCODE")) { fileData[7] = Regex.Match(conf, "(?<=>)(.*)(?=<)").ToString(); }
                            if (conf.Contains("agiv:GEMEENTE")) { fileData[8] = Regex.Match(conf, "(?<=>)(.*)(?=<)").ToString(); }
                            if (conf.Contains("agiv:POSTCODE")) { fileData[9] = Regex.Match(conf, "(?<=>)(.*)(?=<)").ToString(); }
                            if (conf.Contains("gml:X")) { fileData[14] = Regex.Match(conf, "(?<=>)(.*)(?=<)").ToString(); }
                            if (conf.Contains("gml:Y")) { fileData[15] = Regex.Match(conf, "(?<=>)(.*)(?=<)").ToString(); }                            
                        }
                        if (subcount >= 10000)
                        {
                            subcount = 0;
                            Console.WriteLine($"Count is {dcount}");
                        }


                        //Waar staat welke item in de filedata? -> volgorde veranderen van filedata
                        //0 -> ID (int), 1 -> STRAATNMID (int), 2 -> STRAATNM (string), 3 -> HUISNR (string), 4 -> APPTNR (string), 5 -> BUSNR (string)
                        //6 -> HNRLABEL (string), 7->NISCODE(int), 8->GEMEENTE(string), 9->POSTCODE(int), 10 - 13->NULL, 14->X(decimal), 15->Y(decimal)

                        for (int i = 0; i < fileData.Length; i++)
                        {
                            if (fileData[i] == null)
                            {
                                fileData[i] = "";
                            }
                        }
                        if (fileData[7] == "Druivenstraat")
                        {
                            Console.WriteLine(fileData[7] + " Dit klopt niet");
                        }
                        int tmpId;
                        bool tmpIdSucces = int.TryParse(fileData[0], out tmpId);
                        int tmpStraatId;
                        bool tmpStraatIdSucces = int.TryParse(fileData[1], out tmpStraatId);
                        int tmpPostcode;
                        bool tmpPostcodeSucces = int.TryParse(fileData[9], out tmpPostcode);
                        int tmpNiscode;
                        bool tmpNiscodeSucces = int.TryParse(fileData[7], out tmpNiscode);
                        decimal tmpX;
                        bool tmpXSucces = decimal.TryParse(fileData[14], out tmpX);
                        decimal tmpY;
                        bool tmpYSucces = decimal.TryParse(fileData[15], out tmpY);

                        Adres tmpAdres = new(tmpId, tmpStraatId, adreslocatieid, tmpPostcode, fileData[3], fileData[5], fileData[4], fileData[6], fileData[2]);
                        Adressen.Add(tmpAdres);
                        Gemeente tmpGemeente = new(fileData[8], tmpNiscode);
                        Gemeentes.Add(tmpGemeente);
                        Straat tmpStraat = new(tmpId, tmpNiscode, fileData[2]);
                        Straten.Add(tmpStraat);
                        AdresLocatie tmpAdresLocatie = new(adreslocatieid, tmpX, tmpY);
                        AdresLocaties.Add(tmpAdresLocatie);
                    }
                }
            }
        }
    }
}
