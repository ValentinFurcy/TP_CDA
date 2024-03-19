using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Car : Vehicle
    {
        public int Puissance { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}, Puissance : {Puissance} ";
        }
    }
}
