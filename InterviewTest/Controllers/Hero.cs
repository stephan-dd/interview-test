using System.Collections.Generic;
using System.Linq;

namespace InterviewTest.Controllers
{
    public class Hero : IHero
    {
        public string name { get; set; }
        public string power { get; set; }
        public List<KeyValuePair<string, int>> stats { get; set; }
        public void evolve(int statIncrease = 5)
        {
            int length = stats.Count;
            for (int i = 0; i < length; i++)
            {
                int min = stats.Where(f => f.Key == stats[i].Key).Min(entry => entry.Value);
                stats.Add(new KeyValuePair<string, int>(stats[i].Key, stats[i].Value + (min / 2 * statIncrease)));
            }
        }
    }
}
