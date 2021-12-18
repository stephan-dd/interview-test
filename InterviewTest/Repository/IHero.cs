using InterviewTest.Models;
using System.Collections.Generic;

namespace InterviewTest.Repository
{
    public interface IHero
    {
        void Evolve(Hero hero, int statIncrease = 5);
        IEnumerable<Hero> GenerateHeroData();
    }
}
