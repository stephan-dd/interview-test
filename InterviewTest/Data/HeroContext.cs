using InterviewTest.Services;
using System.Collections.Generic;

namespace InterviewTest.Data
{
    public class HeroContext
    {
        public Hero[] heroes = new Hero[] {
               new Hero()
               {
                   Name = "Hulk",
                   Power = "Strength from gamma radiation",
                   Stats =
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 5000 ),
                       new KeyValuePair<string, int>( "intelligence", 50),
                       new KeyValuePair<string, int>( "stamina", 2500 )
                   }
               }
        };
    }
}
