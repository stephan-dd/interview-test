using InterviewTest.BusinessLogic;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewTest.Test
{
    public class TestHero
    {
        [Test]
        public void Evolve_WhenCalled_ShouldIncrementStatOfHero()
        {
            //Arrange
            var hero = new Hero
            {
                Name = "Hulk",
                Power = "Strength from gamma radiation",
                Stats =
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 8 ),
                       new KeyValuePair<string, int>( "intelligence", 9),
                       new KeyValuePair<string, int>( "stamina", 10 )
                   }
            };

            //Act
            hero.Evolve();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(10, hero.Stats.ElementAt(0).Value, "Assert first Stat");
                Assert.AreEqual(11, hero.Stats.ElementAt(1).Value, "Assert second Stat");
                Assert.AreEqual(12, hero.Stats.ElementAt(2).Value, "Assert third Stat");
            });            
        }

    }
}
