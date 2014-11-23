using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YOUP_Design.Models.Common
{
    public static class DepartementParRegion
    {
        static public Dictionary<String,List<int>> ListeDepartementParRegion = new Dictionary<string,List<int>>()
        {
            {"ALSACE" , new List<int>(){67, 68}},
            {"AQUITAINE" , new List<int>(){24,33,40,47,64}},
            {"AUVERGNE" , new List<int>(){3,15,43,63}},
            {"BASSE-NORMANDIE" , new List<int>(){14,61}},
            {"BOURGOGNE" , new List<int>(){21,58,71,89}},
            {"BRETAGNE" , new List<int>(){22,29,35,56}},
            {"CENTRE" , new List<int>(){18,28,36,37,45,41}},
            {"CHAMPAGNE" , new List<int>(){8,10,52,51}},
            {"FRANCHE-COMTE" , new List<int>(){25,70,39,90}},
            {"HAUTE-NORMANDIE" , new List<int>(){27,76}},
            {"ILE-DE-FRANCE" , new List<int>(){91,92,75,77,93,94,95,78}},
            {"LANGUEDOC" , new List<int>(){11,30,34,48,66}},
            {"LIMOUSIN" , new List<int>(){19,23,87}},
            {"LORRAINE" , new List<int>(){54,55,57,88}},
            {"MIDI-PYRENEES" , new List<int>(){9,12,32,31,65,46,81,82}},
            {"NORD" , new List<int>(){59,62}},
            {"NORMANDIE" , new List<int>(){50}},
            {"PAYS-DE-LA-LOIRE" , new List<int>(){44,49,53,72,85}},
            {"PICARDIE" , new List<int>(){2,60,80}},
            {"POITOU-CHARENTE" , new List<int>(){16,17,79,86}},
            {"PROVENCE-ALPES-COTE-D-AZUR" , new List<int>(){4,6,13,5,83,84}},
            {"RHONE-ALPES" , new List<int>(){1,7,26,74,38,42,69,73}},
        };
    }
}