using InterviewTest.Entity;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitTest
{
    public class HeroUnitTests
    {
        [Fact]
        public void Evolve_UpdateHeroStats_ReturnsVoid()
        {
            //Arrange
            var originalStats = new KeyValuePair<string, int>[]
            {
                new KeyValuePair<string, int>( "strength", 5000),
                new KeyValuePair<string, int>( "intelligence", 50),
                new KeyValuePair<string, int>( "stamina", 2500 )
            };

            var hero = new Hero
            {
                Name = "Hulk",
                Power = "Strength from gamma radiation",
                Stats = originalStats.ToList()
            };

            //Act
            hero.Evolve();

            //Assert
            Assert.Equal((originalStats[0].Value / 2) + originalStats[0].Value, hero.Stats[0].Value);
            Assert.Equal((originalStats[1].Value / 2) + originalStats[1].Value, hero.Stats[1].Value);
            Assert.Equal((originalStats[2].Value / 2) + originalStats[2].Value, hero.Stats[2].Value);
        }
    }
}