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
            List<KeyValuePair<string, int>> tempValue = new List<KeyValuePair<string, int>>();

            foreach(KeyValuePair<string, int> item in stats.ToList())
            {
                //Increment each stat value with a multiple of half of the original value
                tempValue.Add(new KeyValuePair<string, int>(item.Key, (int)(item.Value+(item.Value/2))));
            }

            //assign the result to stats
            stats = tempValue;
        }
    }
}
