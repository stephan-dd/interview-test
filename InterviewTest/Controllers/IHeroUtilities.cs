using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Controllers
{
    public interface IHeroUtilities
    {
        int StatIncrease { get; }
        Hero[] GetHeroes();
        Hero UpdateHeroStats(List<KeyValuePair<string, int>> newStats);
    }
}
