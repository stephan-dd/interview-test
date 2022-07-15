using InterviewTest.Data;
using System.Collections.Generic;

namespace InterviewTest.Services
{
    public interface IHeroService
    {
        Hero Evolve(string heroName);
        //void AddHero(string name, string power);
        //void RemoveHero(string name);
        Hero GetHeroByName(string name);
        Hero[] GetHeroList();    
    }
}
