using InterviewTest.Interfaces;
using InterviewTest.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace InterviewTest.Controllers
{
    public class Hero : IHero
    {

        private HeroAttributes[] heroes = new HeroAttributes[]
        {
            //I added a few extra heroes to fill up the table
            new HeroAttributes()
            {
                id = 1,
                name= "Hulk",
                power="Strength from gamma radiation",
                stats=
                new List<KeyValuePair<string, int>>()
                {
                    new KeyValuePair<string, int>( "strength", 5000 ),
                    new KeyValuePair<string, int>( "intelligence", 50),
                    new KeyValuePair<string, int>( "stamina", 2500 )
                }, 
            },
            new HeroAttributes()
            {
                id = 2,
                name= "Iron Man",
                power="Genius intellect Proficient scientist",
                stats=
                new List<KeyValuePair<string, int>>()
                {
                    new KeyValuePair<string, int>( "strength", 4000 ),
                    new KeyValuePair<string, int>( "intelligence", 3000),
                    new KeyValuePair<string, int>( "stamina", 2000 )
                },
            },
            new HeroAttributes()
            {
                id = 3,
                name= "Thor",
                power="Superhuman strength, speed, endurance & resistance to injury",
                stats=
                new List<KeyValuePair<string, int>>()
                {
                    new KeyValuePair<string, int>( "strength", 4500 ),
                    new KeyValuePair<string, int>( "intelligence", 500),
                    new KeyValuePair<string, int>( "stamina", 3000 )
                },
            },
            new HeroAttributes()
            {
                id = 4,
                name= "Captain America",
                power="Super-Soldier: Agility, strength, speed, endurance",
                stats=
                new List<KeyValuePair<string, int>>()
                {
                    new KeyValuePair<string, int>( "strength", 2500 ),
                    new KeyValuePair<string, int>( "intelligence", 600),
                    new KeyValuePair<string, int>( "stamina", 5000 )
                },
            },
            new HeroAttributes()
            {
                id = 5,
                name= "Black Widow",
                power=" Master in the covert arts of espionage, infiltration & subterfugen",
                stats=
                new List<KeyValuePair<string, int>>()
                {
                    new KeyValuePair<string, int>( "strength", 500 ),
                    new KeyValuePair<string, int>( "intelligence", 600),
                    new KeyValuePair<string, int>( "stamina", 1500 )
                },
            }
        };

        public HeroAttributes evolve(HeroAttributes hero)
        {

            int heroStrength = (from stat in hero.stats where stat.Key == "strength" select stat.Value).FirstOrDefault();
            int heroIntelligence = (from stat in hero.stats where stat.Key == "intelligence" select stat.Value).FirstOrDefault();
            int heroStamina = (from stat in hero.stats where stat.Key == "stamina" select stat.Value).FirstOrDefault();

            return new HeroAttributes
            {
                id = hero.id, 
                name = hero.name,
                power = hero.power,
                stats = new List<KeyValuePair<string, int>>()
                {
                    //I understood the "multiple of half the original stat value" as you add half of the original stat, by the original stat
                    new KeyValuePair<string, int>("strength", heroStrength + (heroStrength/2)),
                    new KeyValuePair<string, int>("intelligence", heroIntelligence + (heroIntelligence/2)),
                    new KeyValuePair<string, int>("stamina", heroStamina + (heroStamina/2))
                }
            };

        }

        public List<HeroAttributes> getHeroes()
        {

            return heroes.ToList();
        }
    }
}
