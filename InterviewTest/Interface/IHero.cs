using System.Collections.Generic;
using InterviewTest.Data;

namespace InterviewTest.Interface
{
    public interface IHero
    {
        int Id { get; set; }
        string name { get; set; }
        string power { get; set; }
        List<KeyValuePair<string, int>> stats { get; set; }
    }
}