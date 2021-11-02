using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Controllers
{
     public interface IHero
     {
        Hero[] evolve(Hero hero);
     }
}
