using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Interfaces
{
    public interface IHero
    {
        string Name { get; set; }

        string Power { get; set; }

        List<KeyValuePair<string, int>> Stats { get; set; }

        void evolve(int statIncrease);
    }
}
