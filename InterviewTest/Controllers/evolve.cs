using System;
using System.Collections.Generic;

namespace InterviewTest.Controllers
{
    internal class evolve
    {
        private List<KeyValuePair<string, int>> stats;

        public evolve(List<KeyValuePair<string, int>> stats)
        {
            this.stats = stats;
        }

        public static implicit operator string(evolve v)
        {
            throw new NotImplementedException();
        }
    }
}