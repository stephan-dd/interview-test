using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Controllers
{
    public class Hero
    {
        public string name { get; set; }
        public string power { get; set; }
        public List<KeyValuePair<string, int>> stats { get; set; }
        public void evolve(int statIncrease = 5)
        {
            List<KeyValuePair<string, int>> IncrementedStats = new List<KeyValuePair<string, int>>();
            foreach (KeyValuePair<string, int> stat in stats)
            {
                IncrementedStats.Add(new KeyValuePair<string, int>(stat.Key, Convert.ToInt32((stat.Value / 2)) * statIncrease));
            }
            this.stats = IncrementedStats;
        }


    }
}

