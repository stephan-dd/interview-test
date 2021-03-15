using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Controllers
{
    public class Hero:IHero
    {
        public string name { get; set; }
        public string power { get; set; }
        public List<KeyValuePair<string, double>> stats {get;set;}
        public double evolve(double stat, double statIncrease = 1.5)
        {

            return stat * statIncrease;



        }
    }
}
