using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewTest.Controllers;

namespace InterviewTest.Repository
{
    public class HeroRepo : IHero
    {
        //could make it asnc and generic but netcore2.1 is having trouble accessing Entity classes and keyword.
        public HeroData _hero = new HeroData();
        public List<Hero> GetHero()
        {
            return _hero.heroes.ToList();
        }

        public Hero GetHeroById(int id)
        {
            return _hero.heroes.FirstOrDefault();
        }
    }

}