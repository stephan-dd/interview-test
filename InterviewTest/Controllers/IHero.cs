using System.Collections.Generic;

namespace InterviewTest.Controllers
{
    public interface IHero
    {
        #region Properties

        string name { get; set; }

        #endregion //Properties

        #region Methods

        void evolve();

        string power { get; set; }

        List<KeyValuePair<string, int>> stats { get; set; }

        #endregion //Methods
    }
}
