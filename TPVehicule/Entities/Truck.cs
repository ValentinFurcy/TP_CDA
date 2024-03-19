using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Truck : Vehicle
    {
        public int Poids { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}, Poids : {Poids}";
        }
    }
}
