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
            List<KeyValuePair<string, int>> newList = new List<KeyValuePair<string, int>>();
            foreach (KeyValuePair<string, int> stat in stats)
            {
                int amountToAdd = (stat.Value / 2) * statIncrease;
                var newEntry = new KeyValuePair<string, int>(stat.Key, stat.Value + amountToAdd);
                newList.Add(newEntry);
            }
            stats = newList;
        }
    }
}
