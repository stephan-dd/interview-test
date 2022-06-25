using InterviewTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Domain
{
    public class Hero : IHero
    {
        public string Name { get; set; }
        public string Power { get; set; }
        public List<KeyValuePair<string, int>> Stats { get; set; }
        public List<KeyValuePair<string, int>> evolve(List<KeyValuePair<string, int>> stats)
        {
            var newStats = new List<KeyValuePair<string, int>>();

            //foreach stat in stat increment by stat + stat*0.5
            foreach (var stat in stats)
            {
                newStats.Add(new KeyValuePair<string, int>(stat.Key, stat.Value + Convert.ToInt32(stat.Value * 0.5)));
            }

            return newStats;
        }
    }
}
