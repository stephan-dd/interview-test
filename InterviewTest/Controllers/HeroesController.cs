using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InterviewTest.Controllers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace InterviewTest.Controllers
{
    [Route("api/heroes")]
    [ApiController]
    public class HeroesController : Controller
    {
        private Hero[] heroes = new Hero[] {
               new Hero()
               {
                   name= "Hulk",
                   power="Strength from gamma radiation",
                   stats=
                    new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 5000 ),
                       new KeyValuePair<string, int>( "intelligence", 50),
                       new KeyValuePair<string, int>( "stamina", 2500 )
                   }
               }

        };

        //JsonSerializerSettings settings = new JsonSerializerSettings { Converters = new[] { new HeroConverter() } };
            
        // GET: api/Heroes
        [HttpGet]
        public IEnumerable<Hero> Get()
        {
            //var settings = new JsonSerializerSettings
            //{
            //    ContractResolver = new CamelCasePropertyNamesContractResolver()
            //};
            // var model = this.heroes;
            // return (IEnumerable<Hero>)Json(heroes, settings);

            // return Json(countries, new Newtonsoft.Json.JsonSerializerSettings());

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
        public IEnumerable<Hero> Post([FromBody] string value)
        {
            //Evolve each of the heroes
            if (value.ToLower().Equals("evolve"))
                foreach (var hero in heroes)
                    hero.evolve();

            return this.heroes;
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

        //internal static class ViewHelpers
        //{
        //    public static JsonSerializerSettings CamelCase
        //    {
        //        get
        //        {
        //            return new JsonSerializerSettings
        //            {
        //                ContractResolver = new CamelCasePropertyNamesContractResolver()
        //            };
        //        }
        //    }
        //}
    }
}