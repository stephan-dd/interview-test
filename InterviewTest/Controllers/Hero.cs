using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Controllers
{
    public class Hero : IHero
    {
        public string Name { get; set; }
        public string Power { get; set; }
        public string Action { get; set; }
        public List<KeyValuePair<string, int>> Stats { get; set; }
        public void Evolve(int statIncrease)
        {
            List<KeyValuePair<string, int>> copyStats = new List<KeyValuePair<string, int>>();
            Stats.ForEach(x =>
            {
                copyStats.Add(new KeyValuePair<string, int>(x.Key, x.Value + (x.Value / statIncrease)));
            });

            Stats = copyStats;
        } 
    }
}
