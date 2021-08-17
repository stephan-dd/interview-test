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
        public void Evolve(int statIncrease = 5)
        {
            for (int i = 0; i < Stats.Count; i++)
            {
                int halfVal = (Stats[i].Value / 2);
                int newVal = Stats[i].Value + (halfVal * statIncrease);
                Stats[i] = new KeyValuePair<string, int>(Stats[i].Key, newVal);
            }
        }
    }
}
