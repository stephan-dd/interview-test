using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Controllers
{
    /// <summary>
    /// Heroes initialized to simulates external storage. 
    /// Retrieves stat increase from config,
    /// 
    /// </summary>
    public class HeroUtilities : IHeroUtilities
    {
        readonly IConfiguration _configuration;
        Hero[] _heroes = new Hero[]
        {
            new Hero()
            {
                id = 1,
                name = "Hulk",
                power = "Strength from gamma radiation",
                stats =
                new List<KeyValuePair<string, int>>()
                {
                    new KeyValuePair<string, int>( "strength", 5000 ),
                    new KeyValuePair<string, int>( "intelligence", 50),
                    new KeyValuePair<string, int>( "stamina", 2500 )
                }
            }
    };

        public HeroUtilities(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public int StatIncrease => int.Parse(_configuration["StatIncrease"]);

        public Hero[] GetHeroes()
        {
            return _heroes;
        }

        public Hero UpdateHeroStats(List<KeyValuePair<string, int>> newStats)
        {
            var hero = _heroes.FirstOrDefault();
            hero.stats = newStats;
            return hero;
        }
    }
}