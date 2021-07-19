using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Interfaces
{
    interface IHero
    {
        string Name { get; set; }
        string Power { get; set; }
        //List<KeyValuePair<string, double>> Stats { get; set; }
        //void Evolve(List<KeyValuePair<string, double>> heroStats);        
    }
}
