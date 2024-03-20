using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TPVehicule.Tools
{
    public static class ConsoleHelper
    {
        /// <summary>
        /// récupère la saisie de l'utilisateur, vérifie quelle soit pas null ou qu'avec des espaces
        /// </summary>
        /// <param name="label"></param>
        /// <returns> retourne la saisie en string</returns>
        public static string GetStringFromConsole(string label)
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
        /// <summary>
        /// récupère la saisie numérique de l'utilisateur sous forme de string
        /// </summary>
        /// <param name="label"></param>
        /// <returns>retourne la saisie sous forme de int</returns>
        public static int GetIntFromConsole(string label) 
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

        public static void ExitConsoleApp()
        {
            WriteLine("----- Programe terminé, appuyez sur Entrée pour quitter -----");
            ReadLine();
        }
    }
}
