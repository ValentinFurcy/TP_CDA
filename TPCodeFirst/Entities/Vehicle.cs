using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string? Immatriculation { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }

        public int MarqueId { get; set; }
        public Marque Marque { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public override string ToString()
        {
            return $"Vehicule : {Id}, {Immatriculation}, {Color}, {Model}";
        }
    }
}
