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
            foreach (var stat in stats.ToList())
            {
                stats.Remove(stat);
                stats.Add(new KeyValuePair<string, int>(stat.Key, Convert.ToInt32((stat.Value * 0.5))));
            }
        }
    }
}
