using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                   power="Spider web",
                   stats=
                   new List<KeyValuePair<string, double>>()
                   {
                       new KeyValuePair<string, double>( "strength", 3000 ),
                       new KeyValuePair<string, double>( "intelligence", 70),
                       new KeyValuePair<string, double>( "stamina", 2000 )
                   }
               },
                new Hero()
               {
                   name= "Superman",
                   power="flying speed",
                   stats=
                   new List<KeyValuePair<string, double>>()
                   {
                       new KeyValuePair<string, double>( "strength", 4000 ),
                       new KeyValuePair<string, double>( "intelligence", 90),
                       new KeyValuePair<string, double>( "stamina", 5000 )
                   }
               }

            };

        // GET: api/Heroes
        [HttpGet]
        public IEnumerable<Hero> Get()
        {
            return this.heroes;
        }

        // GET: api/Heroes/5
        [HttpGet("{id}", Name = "Get")]
        public Hero Get(int id)
        {
            return this.heroes.FirstOrDefault();
        }

        // POST: api/Heroes
        [HttpPost]
        public IEnumerable<Hero> Post(string name, string action="none")
        {
            if(action == "evolve")
            {
                List < KeyValuePair<string, double> > heroStats = new List<KeyValuePair<string, double>>();

                Hero theHero = this.heroes.FirstOrDefault(x => x.name.ToLower() == name.ToLower());

                theHero.stats.ForEach(x => {
                    heroStats.Add(new KeyValuePair<string, double>(x.Key, theHero.evolve(x.Value)));
                });

                //return new Hero()
                //{
                //    name = theHero.name,
                //    power = theHero.power,
                //    stats = heroStats                  
                //};


               return new Hero[] {
               new Hero()
               {
                    name = theHero.name,
                    power = theHero.power,
                    stats = heroStats
               }
            };




            }

            return null;
        }

        // PUT: api/Heroes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
