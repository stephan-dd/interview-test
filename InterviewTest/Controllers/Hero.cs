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

        public List<KeyValuePair<string, int>> stats {get;set;}

        public void evolve(int statIncrease = 5)
        {
            //increment all stats of the hero with a multiple of half the original stat value.

            for (int i = 0; i < stats.Count; i++)
            {
                var stat = stats[i];

                var half = (int)Math.Ceiling(stat.Value / 2m);

                var newStat = new KeyValuePair<string, int>(stat.Key, stat.Value + half);

                stats[i] = newStat;
            }
        }
    }
}
