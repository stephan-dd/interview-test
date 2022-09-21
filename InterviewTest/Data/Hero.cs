namespace InterviewTest.Controllers.Data
{
    using Microsoft.AspNetCore.Rewrite.Internal.ApacheModRewrite;
    #region Using Directives

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    #endregion //Using Directives

    public class Hero : IHero
    {
        #region Properties

        public string name { get; set; }
        public string power { get; set; }
        public List<KeyValuePair<string, int>> stats { get; set; }

        #endregion //Properties

        #region Methods

        public void evolve(int statIncrease = 5)
        {
            List<KeyValuePair<string, int>> result = new List<KeyValuePair<string, int>>();
            foreach (KeyValuePair<string, int> s in stats)
            {
                int value = s.Value + (s.Value / 2);
                result.Add(new KeyValuePair<string, int>(s.Key, value));
            }
            this.stats = result;
        }

        public bool IsValid(bool throwExceptionOnNotValid)
        {
            if (string.IsNullOrEmpty(this.name))
            {
                if (throwExceptionOnNotValid)
                {
                    throw new NullReferenceException($"{nameof(name)} not provided for hero.");
                }
                return false;
            }
            if (string.IsNullOrEmpty(this.power))
            {
                if (throwExceptionOnNotValid)
                {
                    throw new NullReferenceException($"{nameof(power)} not provided for hero.");
                }
            }
            return true;
        }

        public void CopyFrom(Hero copy)
        {
            this.name = copy.name;
            this.power = copy.power;
            this.stats = stats;
        }

        #endregion //Methods
    }
}
