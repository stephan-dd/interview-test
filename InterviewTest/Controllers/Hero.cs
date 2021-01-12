using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Controllers
{
    public class Hero : IHero
    {
        public string id { get; set; }
        public string name { get; set; }
        public string power { get; set; }
        public List<KeyValuePair<string, int>> stats { get; set; }

        public void evolve(int statIncrease = 5)
        {
            //The `evolve` method on the class should increment all stats of the hero with a multiple of half the original stat value.

            for (int i = 0; i < stats.Count; i++)
            {
                int iniVal = (stats[i].Value);
                int v = iniVal / 2;
                int newVal = v * iniVal;

                var newKvp = new KeyValuePair<string, int>(stats[i].Key, newVal);

                stats.RemoveAt(i);
                stats.Insert(i, newKvp);
            }
        }
    }
}
