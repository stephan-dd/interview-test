using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Controllers
{
    interface Ihero 
    {
        string  name();
        string power();  
        List<string> list();
        
    }
    public class Hero  : Ihero
    {
        public string name { get; set; }
        public string power { get; set; }
        public List<KeyValuePair<string, int>> stats {get;set;}
        public void evolve(int statIncrease = 5)
        {
            foreach (KeyValuePair<string, int> stat in stats)
            {
                if (stat.Value > statIncrease)
                {
                    int half;
                   int originalStats;
                    
                   originalStats = stat.Value;
                    half =  originalStats / 2;
                    
                    statIncrease *= half;


                    
                }
            
            }
            
        
        }

        public void post(Boolean evolv1e, bool action )
        {
            this.evolve(0);
            var evolve = new evolve(stats);

            
        
        }

        public List<string> list()
        {
            throw new NotImplementedException();
        }

        string Ihero.name()
        {
            throw new NotImplementedException();
        }

        string Ihero.power()
        {
            throw new NotImplementedException();
        }
    }

    
}
