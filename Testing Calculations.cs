        public Hero Post([FromBody] Hero hero, string value = "none")
        {
            try 
            {
                if(hero is null)
                {
                    //Do nothing
                    return new Hero();
                }
                else
                {
                    if (value == "evolve")
                    {
                        return new Hero
                        {
                            Name = hero.Name,
                            Power = hero.Power,
                            Stats = hero.evolve(hero.Stats)
                        };
                    }
                    else
                    {
                        return new Hero
                        {
                            Name = hero.Name,
                            Power = hero.Power,
                            Stats = hero.Stats
                        };
                    }
                }

            } 
            catch 
            {
                //Do nothing
                return new Hero();
            }
        }



//void
        public void Post([FromBody] Hero hero, string value = "none")
        {
            try 
            {
                if(hero is null)
                {
                    //Do nothing
                }
                else
                {
                    if (value == "evolve")
                    {
                        new Hero
                        {
                            Name = hero.Name,
                            Power = hero.Power,
                            Stats = hero.evolve(hero.Stats)
                        };
                    }
                    else
                    {
                        new Hero
                        {
                            Name = hero.Name,
                            Power = hero.Power,
                            Stats = hero.Stats
                        };
                    }
                }
            } 
            catch 
            {
                //Do nothing
            }
        }
