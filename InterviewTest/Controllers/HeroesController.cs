using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private Hero[] heroes = new Hero[] {
               new Hero()
               {
                   name= "Hulk",
                   power="Strength from gamma radiation",
                   stats=
                   new List<KeyValuePair<string, double>>()
                   {
                       new KeyValuePair<string, double>( "strength", 5000 ),
                       new KeyValuePair<string, double>( "intelligence", 50),
                       new KeyValuePair<string, double>( "stamina", 2500 )
                   }
               },
               new Hero()
               {
                   name= "Spiderman",
                   power="Strength from spider bite",
                   stats=
                   new List<KeyValuePair<string, double>>()
                   {
                       new KeyValuePair<string, double>( "strength", 2000 ),
                       new KeyValuePair<string, double>( "intelligence", 70),
                       new KeyValuePair<string, double>( "stamina", 2300 )
                   }
               },
               new Hero()
               {
                   name= "Superman",
                   power="Strength from Krypton",
                   stats=
                   new List<KeyValuePair<string, double>>()
                   {
                       new KeyValuePair<string, double>( "strength", 5000 ),
                       new KeyValuePair<string, double>( "intelligence", 70),
                       new KeyValuePair<string, double>( "stamina", 2800 )
                   }
               },
               new Hero()
               {
                   name= "Wonderwoman",
                   power="Strength from Amazon",
                   stats=
                   new List<KeyValuePair<string, double>>()
                   {
                       new KeyValuePair<string, double>( "strength", 3500 ),
                       new KeyValuePair<string, double>( "intelligence", 80),
                       new KeyValuePair<string, double>( "stamina", 2500 )
                   }
               }
            };
        static Hero[] ogStats;

        public HeroesController()
        {
            if (ogStats == null)
            {
                ogStats = new Hero[heroes.Length];
                Array.Copy(heroes, ogStats, heroes.Length);
            }
        }
        // GET: api/Heroes
        [HttpGet]
        public IEnumerable<Hero> Get()
        {
            return this.heroes;
        }

        // POST: api/Heroes
        [HttpPost]
        public Hero Post(HeroPayload heroPayload)
        {
            Hero hero = this.heroes.FirstOrDefault(h => h.name.ToLower() == heroPayload.name.ToLower());
            if (hero == null)
                return null;
            if (heroPayload.action == "evolve")
            {
                hero.ogStats = ogStats.FirstOrDefault(h => h.name.ToLower() == heroPayload.name.ToLower()).stats;
                hero.evolve();                
            }
            return hero;
        }
    }
}
