using InterviewTest.Models;
using InterviewTest.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Repository
{
    public class HeroRepository : IHeroRepository
    {
        private readonly HeroContext _context;

        public HeroRepository(HeroContext context)
        {
            _context = context;
            SeedData(_context);
        }

        private static void SeedData(HeroContext context)
        {
            if (!Globals.SEED_ONCE)
            {
                context.Database.EnsureCreated();
                Globals.SEED_ONCE = true;
            }
        }

        public List<Hero> GetHeroes()
        {
            return _context.Heroes.ToList();
        }

        public void Update(Hero hero)
        {
            
            _context.SaveChanges();
        }
    }
}
