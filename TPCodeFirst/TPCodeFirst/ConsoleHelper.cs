using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Console;

namespace TPCodeFirst
{
    public static class ConsoleHelper
    {
        public static string GetStringFromConsole(string label = "")
        {
            WriteLine(label);
            var input = ReadLine();

            while (string.IsNullOrWhiteSpace(input))
            {
                WriteLine("Entrée incorrecte, veuilllez réessayer");
                input = ReadLine();
            }
            return input;
        }
        public static int GetIntFromConsole(string label = "")
        {
            int inputNumber;
            var input = GetStringFromConsole(label);

            while (!int.TryParse(input, out inputNumber))
            {
                WriteLine("Entrée incorrecte, veuillez réessayer");
                input = ReadLine();
            }

            return inputNumber;
        }

        public static List<ListImmat> Deserialize() 
        {
            var fileContent = File.ReadAllText("Immat_10.json");
            var listImmat = JsonSerializer.Deserialize<List<ListImmat>>(fileContent);

            foreach(var i in listImmat) 
            { 
                WriteLine(i.immat);
            }
            return ListImmat.listImmats = listImmat;

        }
    }
}
