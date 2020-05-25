using InterviewTest.Controllers;
using InterviewTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Interfaces
{
    public interface IHero
    {
        List<HeroAttributes> getHeroes();
        HeroAttributes evolve(HeroAttributes hero);

    }
}
