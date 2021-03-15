using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Controllers
{
    interface IHero
    {

        string name { get; set; }
        string power { get; set; }
        List<KeyValuePair<string, double>> stats { get; set; }
        double evolve(double stat, double statIncrease);
      
    }
}
