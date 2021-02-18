using InterviewTest.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewTest.Test
{
    public class TestHeroController
    {
        [Test]
        public void GetAllHeroes_WhenCalled_ShouldReturnHeroes()
        {
            //Arrange
            var sut = CreateHeroController();

            //Act
            var actual = sut.Get();

            //Assert
            Assert.IsTrue(actual.Count() > 0);
        }

        [TestCase(true, 5002, 52, 2502 )]
        [TestCase(false, 5000, 50, 2500 )]
        public void EvolveAllHeroes_WhenCalled_ShouldReturnStats(bool evolve, int stat1Value, int stat2Value, int stat3Value)
        {
            //Arrange
            var sut = CreateHeroController();

            //Act
            var actual = sut.Post(evolve);
            var stats = actual.FirstOrDefault().Stats;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(stat1Value, stats.ElementAt(0).Value, "Assert first Stat");
                Assert.AreEqual(stat2Value, stats.ElementAt(1).Value, "Assert second Stat");
                Assert.AreEqual(stat3Value, stats.ElementAt(2).Value, "Assert third Stat");
            });           
        }

        private static HeroController CreateHeroController()
        {
            //Arrange
            return new HeroController();
        }

    }
}
