using System.Collections.Generic;

namespace InterviewTest.Models
{
    public class Hero
    {
        public string Name { get; set; }
        public string Power { get; set; }
        public List<KeyValuePair<string, int>> Stats { get; set; }
    }
}
