using InterviewTest.Data;

namespace InterviewTest.Services
{
    public interface IHero
    {
        /// <summary>
        /// Return all heroes
        /// </summary>
        /// <returns></returns>
        Hero[] GetHeroes();
    }
}
