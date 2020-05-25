using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Models
{

    public class HeroAction
    {
        public string action { get; set; } = "none";
        public HeroAttributes hero { get; set; }
    }

    public class HeroAttributes
    {
        public int id { get; set; }
        public string name { get; set; }
        public string power { get; set; }
        public List<KeyValuePair<string, int>> stats { get; set; }
    }

}
