using InterviewTest.Entity;
using InterviewTest.Repository;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTest
{
    public class HeroRepositoryTests
    {
        private readonly IDictionary<string, IHero> heroes;

        public HeroRepositoryTests()
        {
            heroes = new Dictionary<string, IHero>(StringComparer.OrdinalIgnoreCase)
            {
                { "Hulk", new Hero()
                    {
                        Name = "Hulk",
                        Power = "Strength from gamma radiation",
                        Stats = new List<KeyValuePair<string, int>>()
                        {
                            new KeyValuePair<string, int>( "strength", 5000 ),
                            new KeyValuePair<string, int>( "intelligence", 50),
                            new KeyValuePair<string, int>( "stamina", 2500 )
                        }
                    }
                }
            };
        }

        [Fact]
        public void GetHeroes_GetAllHeroes_ReturnsIEnumerableHero()
        {
            //Arrange
            var heroRepository = new HeroRepository(heroes);

            //Act
            IEnumerable<IHero> actualHeroes = heroRepository.GetHeroes();

            //Assert
            Assert.Equal(heroes.Values, actualHeroes);
        }

        [Fact]
        public void GetHero_HeroExists_ReturnsHero()
        {
            //Arrange
            var heroRepository = new HeroRepository(heroes);

            //Act
            IHero hero = heroRepository.GetHero("Hulk");

            //Assert
            Assert.Equal(heroes["Hulk"], hero);
        }

        [Fact]
        public void GetHero_HeroDoesNotExists_ReturnsHero()
        {
            //Arrange
            var heroRepository = new HeroRepository(heroes);

            //Act
            IHero hero = heroRepository.GetHero("Hulk2");

            //Assert
            Assert.Null(hero);
        }

        [Fact]
        public void AddHero_HeroAdded_ReturnsVoid()
        {
            //Arrange
            var heroRepository = new HeroRepository(heroes);
            var hero = new Hero { Name = "Hulk3" };

            //Act
            heroRepository.AddHero(hero);

            //Assert
            Assert.Equal(hero, heroes[hero.Name]);
        }

        [Fact]
        public void UpdateHero_HeroUpdated_ReturnsBoolean()
        {
            //Arrange
            var heroRepository = new HeroRepository(heroes);
            var hero = new Hero { Name = "Hulk", Power = "Wings" };

            //Act
            var result = heroRepository.UpdateHero(hero);

            //Assert
            Assert.True(result);
            Assert.Equal(hero, heroes[hero.Name]);
        }

        [Fact]
        public void UpdateHero_HeroDoesNotExist_ReturnsBoolean()
        {
            //Arrange
            var heroRepository = new HeroRepository(heroes);
            var hero = new Hero { Name = "Hulk2", Power = "Wings" };

            //Act
            var result = heroRepository.UpdateHero(hero);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void DeleteHero_HeroDeleted_ReturnsBoolean()
        {
            //Arrange
            var heroRepository = new HeroRepository(heroes);

            //Act
            var result = heroRepository.DeleteHero("Hulk");

            //Assert
            Assert.True(result);
            Assert.False(heroes.ContainsKey("Hulk"));
        }

        [Fact]
        public void DeleteHero_DoesNotExist_ReturnsBoolean()
        {
            //Arrange
            var heroRepository = new HeroRepository(heroes);

            //Act
            var result = heroRepository.DeleteHero("Hulk2");

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void CheckHeroExists_HeroExist_ReturnsBoolean()
        {
            //Arrange
            var heroRepository = new HeroRepository(heroes);

            //Act
            var result = heroRepository.CheckHeroExists("Hulk");

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckHeroExists_HeroDoesNotExist_ReturnsBoolean()
        {
            //Arrange
            var heroRepository = new HeroRepository(heroes);

            //Act
            var result = heroRepository.CheckHeroExists("Hulk2");

            //Assert
            Assert.False(result);
        }
    }
}