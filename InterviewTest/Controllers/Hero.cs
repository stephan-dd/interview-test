using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewTest.Interfaces;

namespace InterviewTest.Controllers
{
    public class Hero : IHero 
    {
        public string name { get; set; }
        public string power { get; set; }
        public List<KeyValuePair<string, int>> stats {get;set;}

        public int evolve(int statIncrease = 5)
        {
            //increment all stats with mulitple of half of the original stat val
            //eg: stat "strength" = 5000
            //half = 2500 (NB: multiples of 2500 is inifinity)
            //Assumption: increment stat with half - *do confirm 


            //
            statIncrease += (statIncrease / 2);

            return statIncrease;

        }
    }
}
