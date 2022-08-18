using InterviewTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Repository.Interface
{
    public interface IHeroRepository
    {
        List<Hero> GetHeroes();
        void Update(Hero hero);
    }
}
