using InterviewTest.Interface;
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
            var currentStats = this.stats;

            foreach (KeyValuePair<string, int> kvp in currentStats.ToList())
            {
                int removeStatus = this.stats.RemoveAll(x => x.Key == kvp.Key);

                if (removeStatus == 1)
                {
                    this.stats.Add(new KeyValuePair<string, int>(kvp.Key, (kvp.Value != 0) ? kvp.Value + (kvp.Value / 2) : 0));
                }
            }
        }
    }
}
