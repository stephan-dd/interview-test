using InterviewTest.Models;

namespace InterviewTest.Data
{
    public interface IHeroRepository
    {
        HeroModel[] GetHeroes();
        HeroModel GetById(int id);
        HeroModel GetByName(string name);
    }
}
