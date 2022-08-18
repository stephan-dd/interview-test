using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace InterviewTest.Models
{
    public class HeroContext : DbContext
    {
        public HeroContext(DbContextOptions<HeroContext> options)
    : base(options)
        {
        }

        public DbSet<Hero> Heroes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hero>()
               .Property(_ => _.stats)
               .HasConversion(
                   v => JsonConvert.SerializeObject(v),
                   v => JsonConvert.DeserializeObject<List<KeyValuePair<string, int>>>(v));

            modelBuilder.SeedHeroes();
              

        }

    }
}
