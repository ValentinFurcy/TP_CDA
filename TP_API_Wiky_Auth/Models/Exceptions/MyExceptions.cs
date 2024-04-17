using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Exceptions
{
    public class MyExceptions : Exception
    {
        public string invalidUser = "l'utilisateur est invalid pour cette opération";
    }
}
