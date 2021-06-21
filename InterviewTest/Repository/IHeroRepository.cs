using InterviewTest.Entity;
using System.Collections.Generic;

namespace InterviewTest.Repository
{
    public interface IHeroRepository
    {
        void AddHero(IHero hero);
        bool DeleteHero(string name);
        IHero GetHero(string name);
        IEnumerable<IHero> GetHeroes();
        bool UpdateHero(IHero hero);
        bool CheckHeroExists(string name);
    }
}