using System.Collections.Generic;
namespace InterviewTest.Entity
{
    public class AppHero
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string power { get; set; }
        public List<KeyValuePair<string, int>> stats { get; set; }

    }
}