using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Controllers
{
    public class Hero : IHero
    {
        public string name { get; set; }
        public string power { get; set; }
        public List<KeyValuePair<string, int>> stats { get; set; }
        public void evolve(int statIncrease = 5)
        {
            var keyPairStat = new List< KeyValuePair<string, int>>();
            foreach (var stat in stats)
            {
                var increasedStat = ((stat.Value * 1 / 2) * statIncrease) + stat.Value;
                keyPairStat.Add(new KeyValuePair<string, int>(stat.Key, increasedStat));
            }
            stats=  keyPairStat;
        }
    }
}
