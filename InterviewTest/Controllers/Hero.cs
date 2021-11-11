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
                for (int i = stats.Count - 1; i >= 0; --i)
                {
                    KeyValuePair<string, int> kvp = stats[i];
                   
                    if (stats.Any(l => l.Key == kvp.Key))
                    {
                        var newKeyValue = kvp.Value + ((kvp.Value / 2) * statIncrease);
                        stats.Remove(kvp);
                        stats.Add(new KeyValuePair<string, int>(kvp.Key, newKeyValue));
                    }
                }
        }
    }
}
