using InterviewTest.Data;
using System.Collections.Generic;
namespace InterviewTest.Services
{
    public class HeroService : IHero
    {
        public Hero[] GetHeroes() => new Hero[]
        {
            new Hero()
            {
                Id = 0,
                name = "Hulk",
                power="Strength from gamma radiation",
                stats=
                new List<KeyValuePair<string, int>>()
                {
                    new KeyValuePair<string, int>( "strength", 5000 ),
                    new KeyValuePair<string, int>( "intelligence", 50),
                    new KeyValuePair<string, int>( "stamina", 2500 )
                }
            },
            new Hero()
            {
                Id = 1,
                name = "Iron Man",
                power="Money",
                stats=
                new List<KeyValuePair<string, int>>()
                {
                    new KeyValuePair<string, int>( "strength", 2200 ),
                    new KeyValuePair<string, int>( "intelligence", 6000),
                    new KeyValuePair<string, int>( "stamina", 1400 )
                }
            },
            new Hero()
            {
                Id = 2,
                name = "Bat Man",
                power="Money & Martial Arts",
                stats=
                new List<KeyValuePair<string, int>>()
                {
                    new KeyValuePair<string, int>( "strength", 1200 ),
                    new KeyValuePair<string, int>( "intelligence", 700),
                    new KeyValuePair<string, int>( "stamina", 600 )
                }
            },
            new Hero()
            {
                Id = 3,
                name = "Spider Man",
                power="Spider webs",
                stats=
                new List<KeyValuePair<string, int>>()
                {
                    new KeyValuePair<string, int>( "strength", 1600 ),
                    new KeyValuePair<string, int>( "intelligence", 30),
                    new KeyValuePair<string, int>( "stamina", 1400 )
                }
            },
            new Hero()
            {
                Id = 4,
                name = "Vision",
                power="A fully unique being",
                stats=
                new List<KeyValuePair<string, int>>()
                {
                    new KeyValuePair<string, int>( "strength", 3200 ),
                    new KeyValuePair<string, int>( "intelligence", 1000),
                    new KeyValuePair<string, int>( "stamina", 3400 )
                }
            }
        };
    }
}
