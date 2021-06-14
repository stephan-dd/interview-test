using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interfaces
{
    public interface IHero
    {
        string Name { get; set; }
        string Power { get; set; }
        List<KeyValuePair<string, int>> Stats { get; set; }
        void Evolve(int statIncrease = 5);
    }
}
