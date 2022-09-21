namespace InterviewTest.Data
{
    #region Using Directives

    using InterviewTest.Controllers.Data;
    using Remotion.Linq.Clauses.ResultOperators;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Policy;
    using InterviewTest.Controllers;

    #endregion //Using Directives

    public class HeroCache
    {
        #region Constructors

        public HeroCache()
        {
            ResetHeroes();
        }

        #endregion //Constructors

        //#region Singleton Setup

        //private static HeroCache _instance = null;
        //private static object _lock = new object();

        //private HeroCache()
        //{
        //    ResetHeroes();
        //}

        //public static HeroCache Instance
        //{
        //    get
        //    {
        //        lock (_lock)
        //        {
        //            if (_instance == null)
        //            {
        //                _instance = new HeroCache();
        //            }
        //            return _instance;
        //        }
        //    }
        //}

        //#endregion //Singleton Setup

        #region Fields

        private List<Hero> _heroes;

        #endregion //Fields

        #region Methods

        public void ResetHeroes()
        {
            _heroes = new List<Hero>()
            {
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
        }

        public List<Hero> GetAll()
        {
            return _heroes;
        }

        public Hero Get(string name, bool throwExceptionOnNotFound)
        {
            string nameNormalized = name.Trim().ToLower();
            Hero result = _heroes.Where(p => p.name.ToLower().Equals(nameNormalized)).FirstOrDefault();
            if (result == null && throwExceptionOnNotFound)
            {
                throw new Exception($"Could not find hero with name {name}.");
            }
            return result;
        }

        public bool Exists(string name, out Hero hero)
        {
            hero = Get(name, throwExceptionOnNotFound: false);
            return hero != null;
        }

        public void Add(Hero hero)
        {
            hero.IsValid(throwExceptionOnNotValid: true);
            if (Exists(hero.name, out Hero originalHero))
            {
                throw new ArgumentException($"A hero with the {nameof(Hero.name)} of {hero.name} already exists.");
            }
            _heroes.Add(hero);
        }

        public bool Delete(string name, bool throwExceptionOnNotFound)
        {
            Hero hero = Get(name, throwExceptionOnNotFound);
            if (hero != null)
            {
                _heroes.Remove(hero);
                return true;
            }
            return false;
        }

        #endregion //Methods
    }
}
