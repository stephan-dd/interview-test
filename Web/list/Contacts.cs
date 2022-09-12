using System.Collections.Generic;

namespace Web.list
{
    public class Contacts
    {
        public string name { get; set; }
        public string power { get; set; }
        public List<Stat> stats { get; set; }
    }

    public class Stat
    {
        public string key { get; set; }
        public int value { get; set; }
    }
}