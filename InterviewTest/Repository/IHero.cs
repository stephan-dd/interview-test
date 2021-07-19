using InterviewTest.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Repository
{
    public interface IHero
    {
        List<Hero> GetHero();
        Hero GetHeroById(int id);
    }

}
