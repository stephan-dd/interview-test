using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InterviewTest.Entity
{
    public class Hero : IHero
    {
        [Required(ErrorMessage = "Hero name cannot be null or empty.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Hero power cannot be null or empty.")]
        public string Power { get; set; }

        [Required(ErrorMessage = "Hero stats cannot be null or empty.")]
        public List<KeyValuePair<string, int>> Stats { get; set; }

        public void Evolve()
        {
            for (int i = 0; i < Stats.Count; i++)
            {
                Stats[i] = new KeyValuePair<string, int>(Stats[i].Key, (Stats[i].Value / 2) + Stats[i].Value);
            }
        }
    }
}