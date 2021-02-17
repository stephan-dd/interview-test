using System.Collections.Generic;

namespace InterviewTest.BusinessLogic
{
    public class Hero : IHero
    {
        public string Name { get; set; }
        public string Power { get; set; }
        public List<KeyValuePair<string, int>> Stats { get; set; }
        public void Evolve(int statIncrease = 5)
        {

        }
    }
}
