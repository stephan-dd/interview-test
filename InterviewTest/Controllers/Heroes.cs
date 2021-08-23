using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Controllers
{
    public class Heroes
    {
       
        public static IHero[] GetHeroes()
        {
            return new Hero[] {
               new Hero()
               {
                   Name= "Hulk",
                   Power="Strength from gamma radiation",
                   Stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 5000 ),
                       new KeyValuePair<string, int>( "intelligence", 50),
                       new KeyValuePair<string, int>( "stamina", 2500 )
                   }

               },
               new Hero()
               {
                   Name= "Iron man",
                   Power="Possesses powered armor that gives him superhuman strength and durability, flight, and an array of weapons",
                   Stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 1500 ),
                       new KeyValuePair<string, int>( "intelligence", 3000),
                       new KeyValuePair<string, int>( "stamina", 2000 )
                   }
               },
               new Hero()
               {
                   Name= "Spiderman",
                   Power="Superhuman strength, speed, reflexes, agility, coordination and balance",
                   Stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 1000 ),
                       new KeyValuePair<string, int>( "intelligence", 500),
                       new KeyValuePair<string, int>( "stamina", 3000 )
                   }
               }
            };
        }
    }
}
