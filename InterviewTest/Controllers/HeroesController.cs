using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using InterviewTest.Lib;
using InterviewTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace InterviewTest.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class HeroesController : ControllerBase
  {
    private readonly IConfiguration config;
    private readonly string connectionString;
    private List<Hero> heroes = new List<Hero>();

    public HeroesController(IConfiguration config)
    {
      this.config = config;
      this.connectionString = config.GetConnectionString("HeroConnection");
    }

    private void FetchData(int? id = null)
    {
      using (SqlConnection c = new SqlConnection(connectionString))
      {
        c.Open();

        using (SqlCommand cmd = new SqlCommand("dbo.GetHeroList", c))
        {
          cmd.CommandType = System.Data.CommandType.StoredProcedure;
          SqlDataReader reader = cmd.ExecuteReader();

          while (reader.Read())
          {
            Hero hero = new Hero()
            {
              HeroId = reader.GetInt32(0),
              Name = reader.GetString(1),
              Power = reader.GetString(2),
              Stats = new List<KeyValuePair<string, int>>()
                {
                 new KeyValuePair<string, int>("strength", reader.GetInt32(3)),
                 new KeyValuePair<string, int>("intelligence", reader.GetInt32(4)),
                new KeyValuePair<string, int>("stamina", reader.GetInt32(5))
                }
            };

            this.heroes.Add(hero);
          }
        }
      }
    }

    private void UpdateDate(Hero hero)
    {
      try
      {
        using (SqlConnection c = new SqlConnection(connectionString))
        {
          c.Open();

          using (SqlCommand cmd = new SqlCommand("dbo.UpdateStatistics", c))
          {
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@HeroId", hero.HeroId);
            cmd.Parameters.AddWithValue("@Strength", hero.Stats[0].Value);
            cmd.Parameters.AddWithValue("@Intelligence", hero.Stats[1].Value);
            cmd.Parameters.AddWithValue("@Stamina", hero.Stats[2].Value);

            cmd.ExecuteReader();
          }
        }

        var heroToUpdate = this.heroes.First(c => c.HeroId == hero.HeroId);
        heroToUpdate = hero;
      }
      catch (System.Exception ex)
      {
        throw new System.Exception(ex.Message);
      }
    }

    public enum Action
    {
      None,
      Evolve
    }
    public class HeroCommmand
    {
      public string name;
      public Action? action = Action.None;
    }

    // GET: api/Heroes
    [HttpGet]

    public List<Hero> Get()
    {
      this.FetchData();
      return this.heroes;
    }

    // GET: api/Heroes/5
    [HttpGet("{id}", Name = "Get")]
    public Hero Get(int id)
    {

      this.FetchData(id);
      return this.heroes.FirstOrDefault();
    }

    // POST: api/Heroes
    [HttpPost]
    [ApiKeyAuth]
    public Hero Post([FromBody] HeroCommmand hero)
    {
      this.FetchData();
      if (hero.action == Action.Evolve)
      {
        var heroObj = this.heroes.First(c => c.Name == hero.name);
        heroObj.Evolve();
        UpdateDate(heroObj);

        return heroObj;
      }

      return this.heroes.First(c => c.Name == hero.name);
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
