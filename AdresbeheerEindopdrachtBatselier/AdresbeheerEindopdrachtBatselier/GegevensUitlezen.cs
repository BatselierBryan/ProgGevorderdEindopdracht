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
            using (
                StreamReader str = new StreamReader(pad))
            {
                string conf = "";
                while ((conf = str.ReadLine()) != null)
                {
                    if (conf.Contains("agiv:CrabAdr"))
                    {
                        string[] fileData = new string[16];

                        for (int i = 0; i < 16; i++)
                        {
                            conf = str.ReadLine();

                            if (conf.Contains("agiv:ID")) { fileData[i] = Regex.Match(conf, "(?<=>)(.*)(?=<)").ToString(); adreslocatieid++; }
                            if (conf.Contains("agiv:STRAATNMID")) { fileData[i] = Regex.Match(conf, "(?<=>)(.*)(?=<)").ToString(); }
                            if (conf.Contains("agiv:STRAATNM")) { fileData[i] = Regex.Match(conf, "(?<=>)(.*)(?=<)").ToString(); }
                            if (conf.Contains("agiv:HUISNR")) { fileData[i] = Regex.Match(conf, "(?<=>)(.*)(?=<)").ToString(); }
                            if (conf.Contains("agiv:APPTNR")) { fileData[i] = Regex.Match(conf, "(?<=>)(.*)(?=<)").ToString(); }
                            if (conf.Contains("agiv:BUSNR")) { fileData[i] = Regex.Match(conf, "(?<=>)(.*)(?=<)").ToString(); }
                            if (conf.Contains("agiv:HNRLABEL")) { fileData[i] = Regex.Match(conf, "(?<=>)(.*)(?=<)").ToString(); }
                            if (conf.Contains("agiv:NISCODE")) { fileData[i] = Regex.Match(conf, "(?<=>)(.*)(?=<)").ToString(); }
                            if (conf.Contains("agiv:GEMEENTE")) { fileData[i] = Regex.Match(conf, "(?<=>)(.*)(?=<)").ToString(); }
                            if (conf.Contains("agiv:POSTCODE")) { fileData[i] = Regex.Match(conf, "(?<=>)(.*)(?=<)").ToString(); }
                            if (conf.Contains("gml:X")) { fileData[i] = Regex.Match(conf, "(?<=>)(.*)(?=<)").ToString(); }
                            if (conf.Contains("gml:Y")) { fileData[i] = Regex.Match(conf, "(?<=>)(.*)(?=<)").ToString(); }
                        }


                        //Waar staat welke item in de filedata?
                        //0 -> ID (int), 1 -> STRAATNMID (int), 2 -> STRAATNM (string), 3 -> HUISNR (string), 4 -> APPTNR (string), 5 -> BUSNR (string)
                        //6 -> HNRLABEL (string), 7->NISCODE(int), 8->GEMEENTE(string), 9->POSTCODE(int), 10 - 13->NULL, 14->X(decimal), 15->Y(decimal)

                        for (int i = 0; i < fileData.Length; i++)
                        {
                            if (fileData[i] == null)
                            {
                                fileData[i] = "";
                            }
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
