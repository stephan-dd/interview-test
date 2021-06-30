using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Controllers
{
    public interface IHero
    {
        string name { get; set; }
        string power { get; set; }
        List<KeyValuePair<string, int>> stats { get; set; }
    }
}
