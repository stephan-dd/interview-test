using InterviewTest.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace InterviewTest.Tests
{
    [TestClass]
    [TestCategory("Heroes")]
    public class HeroesControllerTests
    {
        [TestMethod]
        public void ListHeroes()
        {
            var contr = new HeroesController();

            var res = contr.Get();
            Assert.IsTrue(res.Count() > 0);
        }

        [TestMethod]
        public void GetHeroes()
        {
            var contr = new HeroesController();

            var res = contr.Get(0);
            Assert.IsTrue(!string.IsNullOrEmpty(res.name));
        }


        [TestMethod]
        public void Post()
        {
            IHero hero = new Hero()
            {
                name = "Hulk",
                power = "Strength from gamma radiation",
                stats =
                  new List<KeyValuePair<string, int>>()
                  {
                       new KeyValuePair<string, int>( "strength", 5000 ),
                       new KeyValuePair<string, int>( "intelligence", 50),
                       new KeyValuePair<string, int>( "stamina", 2500 )
                  }
            };

            var contr = new HeroesController();

            // defaulted to 5
            int factorInt = 5;


            HeroPost heroPost = new HeroPost();
            heroPost.hero = hero;

            heroPost.action = Action.evolve;

            var initialStats = hero.stats;

            var strengthStat = initialStats.FirstOrDefault(x => x.Key == "strength");
            var intelligenceStat = initialStats.FirstOrDefault(x => x.Key == "intelligence");
            var staminaStat = initialStats.FirstOrDefault(x => x.Key == "stamina");

            var heroRes = contr.Post(heroPost);

            var evolvedStats = heroRes.stats;

            var evolvedStrengthStat = evolvedStats.FirstOrDefault(x => x.Key == "strength");
            var evolvedIntelligenceStat = evolvedStats.FirstOrDefault(x => x.Key == "intelligence");
            var evolevedStaminaStat = evolvedStats.FirstOrDefault(x => x.Key == "stamina");

            Assert.IsTrue(((strengthStat.Value * 0.5 * factorInt) + strengthStat.Value) == evolvedStrengthStat.Value);
            Assert.IsTrue(((intelligenceStat.Value * 0.5 * factorInt) + intelligenceStat.Value) == evolvedIntelligenceStat.Value);
            Assert.IsTrue(((staminaStat.Value * 0.5 * factorInt) + staminaStat.Value) == evolevedStaminaStat.Value);
        }

        [TestMethod]
        public void PostNoAction()
        {
            IHero hero = new Hero()
            {
                name = "Hulk",
                power = "Strength from gamma radiation",
                stats =
                  new List<KeyValuePair<string, int>>()
                  {
                       new KeyValuePair<string, int>( "strength", 5000 ),
                       new KeyValuePair<string, int>( "intelligence", 50),
                       new KeyValuePair<string, int>( "stamina", 2500 )
                  }
            };

            var contr = new HeroesController();

            HeroPost heroPost = new HeroPost();
            heroPost.hero = hero;

            var initialStats = hero.stats;

            var strengthStat = initialStats.FirstOrDefault(x => x.Key == "strength");
            var intelligenceStat = initialStats.FirstOrDefault(x => x.Key == "intelligence");
            var staminaStat = initialStats.FirstOrDefault(x => x.Key == "stamina");

            var heroRes = contr.Post(heroPost);

            var evolvedStats = heroRes.stats;

            var evolvedStrengthStat = evolvedStats.FirstOrDefault(x => x.Key == "strength");
            var evolvedIntelligenceStat = evolvedStats.FirstOrDefault(x => x.Key == "intelligence");
            var evolevedStaminaStat = evolvedStats.FirstOrDefault(x => x.Key == "stamina");

            Assert.IsTrue(strengthStat.Value == evolvedStrengthStat.Value);
            Assert.IsTrue(intelligenceStat.Value == evolvedIntelligenceStat.Value);
            Assert.IsTrue(staminaStat.Value == evolevedStaminaStat.Value);
        }

        [TestMethod]
        public void PostNoHero()
        {
            var contr = new HeroesController();

            HeroPost heroPost = new HeroPost();

            var heroRes = contr.Post(heroPost);

            Assert.IsNotNull(heroRes);
            Assert.IsNull(heroRes.name);
        }
    }
}
