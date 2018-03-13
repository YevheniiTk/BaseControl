using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWork2
{
    public class City
    {
        public string Name { get; private set; }
        public int Population { get; private set; }

        public City (string name, int population)
        {
            this.Name = name;
            this.Population = population;
        }
    }
}
