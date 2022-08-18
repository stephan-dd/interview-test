﻿using System.Collections.Generic;


namespace InterviewTest.Models
{
    public interface IHero
    {
        string name { get; set; }
        string power { get; set; }
        List<KeyValuePair<string, int>> stats { get; set; }

        void evolve(int statIncrease = 5);
    }
}