﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Controllers
{
    public interface IHero
    {
        /// <summary>
        /// Gets or sets the Name property of the <see cref="Hero"/> object.
        /// </summary>
        string Name { get; set; }

        string Power { get; set; }

        List<KeyValuePair<string, int>> Stats { get; set; }

        void Evolve(int statIncrease);
    }
}
