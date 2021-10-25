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
        public void evolve()
        {
            List<KeyValuePair<string, int>> copyStats = new List<KeyValuePair<string, int>>();
            foreach (var stat in stats)
            {
                int statVal = stat.Value + stat.Value / 2;
                copyStats.Add(new KeyValuePair<string, int>(stat.Key, statVal));
            }
            stats = copyStats;
        }
    }
}
