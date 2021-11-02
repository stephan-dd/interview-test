using System;
using System.Collections.Generic;
using Xunit;
using InterviewTest.Controllers;



namespace HeroTest
{
    public class HeroTest
    {
       
        [Fact]
        public void isHeroStatEvolveIsNotNull()
        {
            Hero[] heroes = new Hero[] {
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

            var heroService = new HeroService();

            Assert.NotNull(heroService.evolve(heroes[0]));
        }
        [Fact]
        public void isHeroStatEvolveExceptionPositive()
        {
            var heroService = new HeroService();

            Exception ex = Assert.Throws<Exception>(() => heroService.evolve(null));
            Assert.Equal("Please check if the Hero is not null", ex.Message);
 
        }

        [Fact]
        public void isHeroStatEvolveExceptionNegative()
        {
            var heroService = new HeroService();

            Exception ex = Assert.Throws<Exception>(() => heroService.evolve(null));
            Assert.NotEqual("Error is not the same", ex.Message);

        }
    }
}
