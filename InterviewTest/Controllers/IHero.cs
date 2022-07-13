using System.Collections.Generic;

namespace InterviewTest.Controllers
{
    public interface IHero
    {
        string Name { get; set; }
        string Power { get; set; }  
        List<KeyValuePair<string, int>> Stats { get; set; }
        void Evolve(int statIncrease);
    }
}