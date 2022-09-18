using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Controllers
{
    public class Hero: IHero
    {
        public string name { get; set; }
        public string power { get; set; }
        public List<KeyValuePair<string, double>> stats {get;set;}
        public List<KeyValuePair<string, double>> ogStats { get; set; }
        public void evolve(int statIncrease = 5)
        {
            foreach (var ogStat in ogStats)
            {
                stats[ogStats.IndexOf(ogStat)] = new KeyValuePair<string, double>(ogStat.Key, ogStat.Value * 0.5 + stats.FirstOrDefault(stat => stat.Key == ogStat.Key).Value);
            }
        }
    }
}
