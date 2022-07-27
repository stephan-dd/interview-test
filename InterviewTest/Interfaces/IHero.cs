using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Interfaces
{
    public interface IHero
    {
        List<KeyValuePair<string, int>> evolve(List<KeyValuePair<string, int>> stats);
    }
}
