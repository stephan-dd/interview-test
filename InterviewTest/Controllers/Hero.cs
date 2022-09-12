using InterviewTest.Interfaces;
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
            //should increment all stats of the hero with a multiple of half the original stat value.
            var NewStats = new List<KeyValuePair<string, int>>();
            foreach (var item in stats)
            {
                int newVal = item.Value * (item.Value / 2);
                
                NewStats.Add(new KeyValuePair<string, int>(item.Key, newVal));
            }
            stats = NewStats;
        }
    }
}
