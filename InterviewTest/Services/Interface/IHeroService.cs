using InterviewTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Services.Interface
{
    public interface IHeroService
    {
        List<Hero> GetHeroes();
        void Update(Hero hero);
    }
}
