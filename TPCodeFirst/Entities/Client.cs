using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateNaissance { get; set; }
        public List<Location> Location { get; set; }

        public override string ToString()
        {
            return $"ID : {Id} , Nom : {FirstName}, Prenom : {LastName} , Date de naissance : {DateNaissance}";
        }
    }
}
