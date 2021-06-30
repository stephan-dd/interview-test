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
            foreach (KeyValuePair<string, int> stat in stats.ToList())
            {
                int currentValue = stats.RemoveAll(s => s.Key == stat.Key);
                int updatedValue = (stat.Value + (stat.Value * statIncrease / 100));
                stats.Add(new KeyValuePair<string, int>(stat.Key, updatedValue));
            }
        }
    }
}
