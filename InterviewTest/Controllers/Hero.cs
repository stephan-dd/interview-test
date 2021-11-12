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
        public List<KeyValuePair<string, int>> Stats {get;set;}
        public void Evolve()
        {
                for (int i = Stats.Count - 1; i >= 0; --i)
                {
                    KeyValuePair<string, int> kvp = Stats[i];
                   
                    if (Stats.Any(h => h.Key == kvp.Key))
                    {
                    var newKeyValue = kvp.Value + (kvp.Value / 2);
                    Stats.Remove(kvp);
                    Stats.Add(new KeyValuePair<string, int>(kvp.Key, newKeyValue));
                    }
                }
        }
    }
}
