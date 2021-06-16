using InterviewTest.Infra;
using System.Collections.Generic;
using System.Linq;

namespace InterviewTest.Controllers
{
    public class Hero : IHero
    {
        public string name { get; set; }
        public string power { get; set; }
        public List<KeyValuePair<string, int>> stats {get;set;}
        public void evolve()
        {
            foreach (var stat in stats.ToList())
            {
                var keyValue = stats.Single(x => x.Key == stat.Key);
                var newValue = keyValue.Value * (keyValue.Value/2);
                stats.Add(new KeyValuePair<string, int>(keyValue.Key, newValue));
                stats.Remove(keyValue);
            }
        }
    }
}
