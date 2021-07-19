using InterviewTest.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest
{
    public class HeroData
    {
        public Hero[] heroes = new Hero[] {
               new Hero()
               {
                   name= "Hulk",
                   power="Strength from gamma radiation",
                   stats=
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
