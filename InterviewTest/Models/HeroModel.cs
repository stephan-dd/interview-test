using System.Collections.Generic;

namespace InterviewTest.Models
{
    public class HeroModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Power { get; set; }
        public List<KeyValuePair<string, int>> Stats { get; set; }
    }
}
