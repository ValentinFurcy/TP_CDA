using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Location
    {
        public int Id { get; set; }
        public int Nb_KM {  get; set; }
        public DateOnly Date_Start { get; set; }
        public DateOnly Date_End { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public override string ToString()
        {
            return $"Location : Date de début : {Date_Start} , Date de Fin : {Date_End}";
        }
    }
}
