using InterviewTest.Enums;
using InterviewTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Services
{
    public class Hero:IHero
    {
        public string name { get; set; }
        public string power { get; set; }
        public List<KeyValuePair<string, int>> stats {get;set;}

        public HeroStats evolve(Hero value)
        {
            var heroStats = new HeroStats();
             if(value.stats != null)
              {
                    heroStats.Strength = (int)(value.stats[(int)Stat.Strength].Value * 0.5) + value.stats[0].Value;
                    heroStats.Intelligence = (int)(value.stats[(int)Stat.Intelligence].Value * 0.5) + value.stats[1].Value;
                    heroStats.Stamina = (int)(value.stats[(int)Stat.Stamina].Value * 0.5) + value.stats[2].Value;
             }
           return heroStats;
        }
    }
}
