using InterviewTest.Models;
using System.Collections.Generic;

namespace InterviewTest.Services
{
    public interface IHero
    {
        string name { get; set; }
        string power { get; set; }
        List<KeyValuePair<string, int>> stats {get;set;}
        HeroStats evolve(Hero value);
        //void evolve(int statIncrease = 5);

    }
}