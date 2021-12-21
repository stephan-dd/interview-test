using InterviewTest.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Models
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
                var evolvedStats = Convert.ToInt32(Stats[i].Value * 0.5) + Stats[i].Value;

                Stats[i] = new KeyValuePair<string, int>(Stats[i].Key, evolvedStats );
            }
               
        }
    }
}
