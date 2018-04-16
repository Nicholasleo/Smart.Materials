using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nicholas.Smart.Materials.Enity
{
    public class MyEnt
    {
        public List<Ent2> EntList { get; set; }

        public string Key { get; set; }
    }

    public class Ent1
    {
        public int Length { get; set; }

        public int Qty { get; set; }

        public int Area { get; set; }
        public string Depth { get; set; }

        public string Path { get; set; }
    }

    public class Ent2
    {
        public Ent1 MyEnt { get; set; }

        public string Key { get; set; }

        public int Area { get; set; }
        
        public string MainKey { get; set; }

    }

    public class Ent3 : Ent2
    {
        
    }
}
