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
                   name = "Hulk",
                   power ="Strength from gamma radiation",
                   stats =
                       new List<KeyValuePair<string, int>>()
                       {
                           new KeyValuePair<string, int>( "strength", 5000 ),
                           new KeyValuePair<string, int>( "intelligence", 50),
                           new KeyValuePair<string, int>( "stamina", 2500 )
                       }
               }
            };


        // GET: api/Heroes
        [HttpGet]
        [Route("Get")]
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
        [Route("Post")]
        public void Post([FromBody] string value)
        {
            //only act on evolve
            if(value == "evolve")
            {
                //stats KeyPair holder
                Dictionary<string, int> newKP = new Dictionary<string, int>();

                for (int i = 0; i < heroes.Count(); i++)
                {
                    //get key value pairs
                    List<KeyValuePair<string,int>> hStats = heroes[i].stats;

                    //evolve each stat on hero
                    for(int j = 0; j < hStats.Count(); j++)
                    {
                        Hero hero = new Hero(); //inject
                        newKP.Add(hStats[j].Key, hero.evolve(hStats[j].Value));
                    }

                    //convert back
                    heroes[i].stats = newKP.ToList();
                }
            }
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
