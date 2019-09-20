using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Castle
{
    public class CastleFeatures
    {
        public static double Water { get; set; }
        public static double Bread { get; set; }
        public static double Beer { get; set; }
        public static double Meat { get; set; }
        public static int Archers { get; set; }
        public static int Swords { get; set; }
        public static int Cavalery { get; set; }
        public static double SecurityLevel { get; set; }
        public CastleFeatures(int water, int bread, int beer, int meat,
                              int archers, int swords, int cavalery)
        {
            Water = water;
            Bread = bread;
            Beer = beer;
            Meat = meat;
            Archers = archers;
            Swords = swords;
            Cavalery = cavalery;
            SecurityLevel = 100;
        }
    }
    
}
