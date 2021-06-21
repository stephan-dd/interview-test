using InterviewTest.Entity;
using System;
using System.Collections.Generic;

namespace InterviewTest.Repository
{
    public class HeroRepository : IHeroRepository
    {
        private readonly IDictionary<string, IHero> heroes = new Dictionary<string, IHero>(StringComparer.OrdinalIgnoreCase)
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
            },
             { "Shang Tsung", new Hero()
                {
                    Name = "Shang Tsung",
                    Power = "Steal the souls of those he defeats",
                    Stats = new List<KeyValuePair<string, int>>()
                    {
                        new KeyValuePair<string, int>( "strength", 7000 ),
                        new KeyValuePair<string, int>( "intelligence", 100),
                        new KeyValuePair<string, int>( "stamina", 3000 )
                    }
                }
            },
              { "Nightwolf", new Hero()
                {
                    Name = "Nightwolf",
                    Power = "Green magic manipulation and lightning manipulation",
                    Stats = new List<KeyValuePair<string, int>>()
                    {
                        new KeyValuePair<string, int>( "strength", 400 ),
                        new KeyValuePair<string, int>( "intelligence", 150),
                        new KeyValuePair<string, int>( "stamina", 3500 )
                    }
                }
            },
               { "Scorpion ", new Hero()
                {
                    Name = "Scorpion ",
                    Power = "Burn, sometimes vaporize, anything he touches",
                    Stats = new List<KeyValuePair<string, int>>()
                    {
                        new KeyValuePair<string, int>( "strength", 8000 ),
                        new KeyValuePair<string, int>( "intelligence", 200),
                        new KeyValuePair<string, int>( "stamina", 4000 )
                    }
                }
            }
        };

        public HeroRepository()
        {
        }

        public HeroRepository(IDictionary<string, IHero> heroes)
        {
            this.heroes = heroes ?? throw new ArgumentNullException(nameof(heroes));
        }

        public IEnumerable<IHero> GetHeroes()
        {
            return heroes.Values;
        }

        public IHero GetHero(string name)
        {
            if (heroes.ContainsKey(name))
            {
                return heroes[name];
            }

            return null;
        }

        public void AddHero(IHero hero)
        {
            heroes.Add(hero.Name, hero);
        }

        public bool UpdateHero(IHero hero)
        {
            if (!heroes.ContainsKey(hero.Name))
            {
                return false;
            }

            heroes[hero.Name] = hero;
            return true;
        }

        public bool DeleteHero(string name)
        {
            if (heroes.ContainsKey(name))
            {
                return heroes.Remove(name);
            }

            return false;
        }

        public bool CheckHeroExists(string name)
        {
            return heroes.ContainsKey(name);
        }
    }
}