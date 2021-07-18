using System.Collections.Generic;
using InterviewTest.Interface;

namespace InterviewTest.Data
{

    public class HeroList : IHero
    {
        private List<Hero> heroes;
        public List<Hero> Heroes => heroes;

        public HeroList()
        {
            heroes = new List<Hero>(){
          new Hero()
               {
                    Id = 0,
                    name= "Hulk",
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
                    name= "Adam Warlock",
                    power="Superhuman strength",
                    stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 2000 ),
                       new KeyValuePair<string, int>( "intelligence", 2500),
                       new KeyValuePair<string, int>( "stamina", 1500 )
                   }
               },
                   new Hero()
               {
                    Id = 2,
                    name= "Luke Cage",
                    power="Superhuman strength",
                    stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 3500 ),
                       new KeyValuePair<string, int>( "intelligence", 3000),
                       new KeyValuePair<string, int>( "stamina", 2900 )
                   }
               },
                   new Hero()
               {
                    Id = 3,
                    name= "Groot",
                    power="Flora Colossus Physiology",
                    stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 2800 ),
                       new KeyValuePair<string, int>( "intelligence", 1000),
                       new KeyValuePair<string, int>( "stamina", 1900 )
                   }
               }
        };
        }
    }
}