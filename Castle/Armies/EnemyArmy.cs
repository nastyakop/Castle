using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Castle
{
    public class EnemyArmy
    {
        public static int Swords { get; set; }
        public static int Archers { get; set; }
        public static int Cavalery { get; set; }
        public EnemyArmy(int swords,int archers,int cavalery)
        {
            Swords = swords;
            Archers = archers;
            Cavalery = cavalery;
        }
    }
}
