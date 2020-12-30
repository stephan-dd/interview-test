using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using InterviewTest.Controllers;

namespace InterviewTest.Data
{
    public class TestDbContext: DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options)
           : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        var config = new ConfigurationBuilder()
        //            .SetBasePath(Directory.GetCurrentDirectory())
        //            .AddJsonFile("appsettings.json")
        //            .Build();

        //        // optionsBuilder.UseSqlServer(config.GetConnectionString(""));
        //    }
        // }

        public DbSet<Controllers.Hero> Hero { get; set; }
    }
}
