using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame_demo1
{
    public class Spiller
    {
        public List<string> har;
        public Rom rom;
        public string items;

        public Spiller()
        {
            har = new List<string>();
        }

        public string inventory()
        {
            string items = "";

            if (har.Count == 0)
            {
                items = "ingenting";
            }

            else
            {
                foreach (var ting in har)
                {
                    items += $" {ting}";
                   
                }
            }
            return items;

        }
    }
}

