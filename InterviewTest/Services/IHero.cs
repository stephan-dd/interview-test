using InterviewTest.Models;

namespace InterviewTest.Services
{
    public interface IHero
    {
        HeroModel Evolve(string name, string action, int statIncrease);
        HeroModel[] GetHeroes();
        HeroModel GetById(int id);
        HeroModel GetByName(string name);
    }
}
